using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ITCR.SGAG.Negocios;
using System.Web.UI.HtmlControls;

namespace ITCR.SGAG.Interfaz
{
    public partial class frmRealizarPrestamo : System.Web.UI.Page
    {
        static List<Control> _implementos;
        static int _sigIdImplemento;
        static DataTable _inventario;
        static int _diferenciaDias;

        const Boolean _PENDIENTE = false;
        const Boolean _DEVUELTO = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _implementos = new List<Control>();
                _sigIdImplemento = 0;
                _diferenciaDias = 1;
                ObtenerImplementos();
                AgregarImplemento();

                Char[] delimiter = { ' ' };
                string fechaHoy = String.Format("{0:dd-MM-yyyy}", DateTime.Today.AddDays(1));
                cldFechaDevolucionGeneral.Text = fechaHoy;

                HtmlGenericControl body = this.Master.FindControl("body") as HtmlGenericControl;
                body.Attributes.Add("onLoad", "OnLoad();");
            }
            else
            {
                foreach (Control panelImplemento in _implementos)
                {
                    if (panelImplemento != null)
                    {
                        implementos.Controls.Add(panelImplemento);
                        foreach (Control elementoHijo in panelImplemento.Controls)
                        {
                            if (elementoHijo is Button) 
                            { 
                                ((Button)elementoHijo).Click += new EventHandler(btnQuitar_Click); 
                            }
                            else if (elementoHijo is DropDownList && elementoHijo.ID.StartsWith("drpImplemento_"))
                            {
                                ((DropDownList)elementoHijo).SelectedIndexChanged += new EventHandler(drpImplemento_IndexChanged); 
                            }

                        }
                    }
                }
            }
        }

        private void AgregarImplemento()
        {
            #region Generación dinámica de un panel para agregar un implemento a la lista
            String html;

            Panel nuevoImplemento = new Panel();
            nuevoImplemento.ID = "implemento_" + _sigIdImplemento;
            html = "<fieldset><legend>Detalle del préstamo</legend>";
            nuevoImplemento.Controls.Add(new LiteralControl(html));
            Button btnQuitar = new Button();
            btnQuitar.ID = "btnQuitar_" + _sigIdImplemento;
            btnQuitar.CssClass = "btnQuitar";
            btnQuitar.Text = "Quitar";
            nuevoImplemento.Controls.Add(btnQuitar);
            html = "<p><b>Implemento: </b>";
            nuevoImplemento.Controls.Add(new LiteralControl(html));
            DropDownList drpImplemento = new DropDownList();
            drpImplemento.ID = "drpImplemento_" + _sigIdImplemento;
            drpImplemento.CssClass = "CampoCombo";
            drpImplemento.AutoPostBack = true;
            drpImplemento.Items.Insert(0, "-- Seleccione un implemento --");
            nuevoImplemento.Controls.Add(drpImplemento);
            html = "</p><p><b>Disponible: </b>";
            nuevoImplemento.Controls.Add(new LiteralControl(html));
            Label lblDisponible = new Label();
            lblDisponible.ID = "lblDisponible_" + _sigIdImplemento;
            lblDisponible.Text = "---";
            nuevoImplemento.Controls.Add(lblDisponible);
            html = "</p><p><b>Próxima devolución: </b>";
            nuevoImplemento.Controls.Add(new LiteralControl(html));
            Label lblProxDevolucion = new Label();
            lblProxDevolucion.ID = "lblProxDevolucion_" + _sigIdImplemento;
            lblProxDevolucion.Text = "---";
            nuevoImplemento.Controls.Add(lblProxDevolucion);
            html = "</p><p><b>Cantidad solicitada: </b>";
            nuevoImplemento.Controls.Add(new LiteralControl(html));
            DropDownList drpCantSolicitada = new DropDownList();
            drpCantSolicitada.ID = "drpCantSolicitada_" + _sigIdImplemento;
            drpCantSolicitada.CssClass = "CampoCombo";
            drpCantSolicitada.Items.Add("---");
            nuevoImplemento.Controls.Add(drpCantSolicitada);
            html = "</p><p id='pDurante'><b>Durante: </b>";
            nuevoImplemento.Controls.Add(new LiteralControl(html));
            TextBox txtDurante = new TextBox();
            txtDurante.ID = "txtDurante_" + _sigIdImplemento;
            txtDurante.Text = _diferenciaDias + "";
            txtDurante.CssClass = "CampoTextoNumerico";
            nuevoImplemento.Controls.Add(txtDurante);
            DropDownList drpUnidDurante = new DropDownList();
            drpUnidDurante.ID = "drpUnidDurante_" + _sigIdImplemento;
            drpUnidDurante.CssClass = "CampoCombo";
            drpUnidDurante.Items.Insert(0, "Días");
            drpUnidDurante.Items.Insert(1, "Horas");
            nuevoImplemento.Controls.Add(drpUnidDurante);
            html = " a partir de la hora en que se realice el préstamo (hora del sistema).</p><p><b>Tipo de préstamo: </b>";
            nuevoImplemento.Controls.Add(new LiteralControl(html));
            DropDownList drpTipoPrestamo = new DropDownList();
            drpTipoPrestamo.ID = "drpTipoPrestamo_" + _sigIdImplemento;
            drpTipoPrestamo.CssClass = "CampoCombo";
            drpTipoPrestamo.Items.Insert(0, "Normal");
            drpTipoPrestamo.Items.Insert(1, "Especial");
            nuevoImplemento.Controls.Add(drpTipoPrestamo);
            html = "</fieldset>";
            nuevoImplemento.Controls.Add(new LiteralControl(html));
            _implementos.Add(nuevoImplemento);
            LlenarComboImplementos(_sigIdImplemento);
            implementos.Controls.Add(nuevoImplemento);
            _sigIdImplemento++;
            btnRealizar.Enabled = true;
            #endregion
        }

        private void ObtenerImplementos()
        {
            cSGGIIMPLEMENTONegocios tempImplemento = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 0, "200949216");
            _inventario = tempImplemento.SeleccionarTodos();        
        }

        private void LlenarComboImplementos(int pIndexImplemento)
        {
            Control panelImplemento = _implementos[pIndexImplemento];
            foreach (Control elementoHijo in panelImplemento.Controls)
            {
                if (elementoHijo is DropDownList && String.Equals(elementoHijo.ID, "drpImplemento_" + pIndexImplemento)) 
                {
                    DropDownList drpImplementos = (DropDownList)elementoHijo;
                    foreach (DataRow regImplemento in _inventario.Rows)
                    {
                        drpImplementos.Items.Add(regImplemento["NOM_TIPOIMPLEMENTO"] + " de " + regImplemento["NOM_DEPORTE"] + ": " + regImplemento["DSC_IMPLEMENTO"]);
                    }
                    break;
                }
            }
        }

        private cSGMUUSUARIONegocios Verificar()
        {
            cSGMUUSUARIONegocios usuarioSolicitante = new cSGMUUSUARIONegocios(Global.gCOD_APLICACION, "CA", 0, "200949216");
            usuarioSolicitante.CAR_USUARIO = txtIdentificacion.Text;
            usuarioSolicitante.NOM_USUARIO = "Mauricio M. Chaves";
            return usuarioSolicitante;
        }

        private String VerificarHabilitado(cSGMUUSUARIONegocios pUsuarioGimnasio)
        {
            cSGPRPRESTAMONegocios tempPrestamo = new cSGPRPRESTAMONegocios(Global.gCOD_APLICACION, "CA", 0, "200949216");
            tempPrestamo.CAR_USUARIOGIMNASIO = pUsuarioGimnasio.CAR_USUARIO;
            tempPrestamo.ESTADO = _PENDIENTE;
            DataTable prestamosPendientes = tempPrestamo.Buscar();
            if (prestamosPendientes.Rows.Count == 0)
            {
                return "No tiene préstamos pendientes";
            }

            return "Tiene préstamos pendientes";
        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            cSGMUUSUARIONegocios usuarioSolicitante = Verificar();
            if (usuarioSolicitante != null)
            {
                lblEstadoUsuario.Text = VerificarHabilitado(usuarioSolicitante);
                lblNombreUsuario.Text = usuarioSolicitante.NOM_USUARIO.ToString();
            }
            else
            {
                lblEstadoUsuario.Text = "---";
                lblNombreUsuario.Text = "Usuario no identificado";
            }
            
        }

        private bool RealizarPrestamo()
        {
            return true;
        }

        protected void ActualizarCantidadDiasPrestamo(DateTime pFechaHoy, DateTime pFechaIngresada)
        {
            _diferenciaDias = pFechaIngresada.Subtract(pFechaHoy).Days;

            foreach (Control panelImplemento in _implementos)
            {
                if (panelImplemento != null)
                {
                    foreach (Control elementoHijo in panelImplemento.Controls)
                    {
                        if (elementoHijo is TextBox && elementoHijo.ID.StartsWith("txtDurante_"))
                        {
                            ((TextBox)elementoHijo).Text = _diferenciaDias + "";
                        }
                        else if (elementoHijo is DropDownList && elementoHijo.ID.StartsWith("drpUnidDurante_"))
                        {
                            ((DropDownList)elementoHijo).SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        protected void cldFechaDevolucionGeneral_OnChange(object sender, EventArgs e)
        {
            DateTime fechaIngresada = DateTime.Parse(cldFechaDevolucionGeneral.Text);
            DateTime fechaHoy = DateTime.Today;
            int resultado = fechaHoy.CompareTo(fechaIngresada);

            if (resultado == 1)
            {
                if (!Page.ClientScript.IsStartupScriptRegistered("AlertaFechaInvalida"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertaFechaInvalida", "<script type=\"text/javascript\"> _MensajeAlerta = 'La fecha ingresada es inválida. El campo se actualizará con la fecha hoy.'; </script>");
                }
                cldFechaDevolucionGeneral.Text = String.Format("{0:dd-MM-yyyy}", fechaHoy);
                fechaIngresada = fechaHoy.AddDays(1);
            }

            ActualizarCantidadDiasPrestamo(fechaHoy, fechaIngresada);
        }

        protected void drpImplemento_IndexChanged(object sender, EventArgs e)
        {
            DropDownList drpSender = (DropDownList)sender;

            Char[] delimiter = { '_' };
            string idCombo = drpSender.ID;
            string idPanel = idCombo.Split(delimiter)[1];

            int indexSeleccionado = drpSender.SelectedIndex-1;

            DataRow implemento = (drpSender.SelectedIndex == 0) ? null : _inventario.Rows[indexSeleccionado];

            Control panelImplemento = _implementos[int.Parse(idPanel)];
            foreach (Control elementoHijo in panelImplemento.Controls)
            {
                #region Actualización lblDisponible
                if (elementoHijo is Label && elementoHijo.ID.StartsWith("lblDisponible_"))
                {
                    Label lblDisponible = (Label)elementoHijo;

                    lblDisponible.Text = (implemento == null) ? "---" : implemento["CAN_DISPONIBLE"].ToString();
                }
                #endregion
                #region Actualización lblProxDevolucion
                else if (elementoHijo is Label && elementoHijo.ID.StartsWith("lblProxDevolucion_"))
                {
                    Label lblProxDevolucion = (Label)elementoHijo;
                    cSGGIIMPLEMENTONegocios tempImplemento = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 0, "200949216");

                    if (implemento != null)
                    {
                        tempImplemento.ID_IMPLEMENTO = Convert.ToInt32(implemento["ID_IMPLEMENTO"]);
                        DataTable tblProxDevolucion = tempImplemento.ConocerProxDevolucion();
                        if (tblProxDevolucion.Rows.Count > 0)
                        {
                            lblProxDevolucion.Text = tblProxDevolucion.Rows[0]["PROX_DEVOLUCION"].ToString();
                        }
                        else
                        {
                            lblProxDevolucion.Text = "No hay pendientes por devolver";
                        }
                    }
                    else
                    {
                        lblProxDevolucion.Text = "---";
                    }
                }
                #endregion
                #region Actualización drpCantSolicitada
                else if (elementoHijo is DropDownList && elementoHijo.ID.StartsWith("drpCantSolicitada_"))
                {
                    DropDownList drpCantSolicitada = (DropDownList)elementoHijo;
                    drpCantSolicitada.Items.Clear();
                    if (implemento != null)
                    {
                        for (int i = 1; i <= Convert.ToInt32(implemento["CAN_DISPONIBLE"]); i++)
                        {
                            drpCantSolicitada.Items.Add(i + "");
                        }
                    }
                    else
                    {
                        drpCantSolicitada.Items.Add("---");
                    }
                }
                #endregion
            }
        }

        protected void btnAgregarImplemento_Click(object sender, EventArgs e)
        {
            AgregarImplemento();
        }

        protected void btnRealizar_Click(object sender, EventArgs e)
        {
            RealizarPrestamo();
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            Control btnSender = (Control)sender;
            Char[] delimiter = { '_' };
            string idButton = btnSender.ID;
            string id = idButton.Split(delimiter)[1];

            _implementos.RemoveAt(int.Parse(id));
            _implementos.Insert(int.Parse(id), null);
            implementos.Controls.Remove(implementos.FindControl("implemento_" + id));

            Boolean sinImplementos = true;
            foreach (Control panelImplemento in _implementos)
            {
                if (panelImplemento != null) { sinImplementos = false; break; }
            }
            if (sinImplementos) { btnRealizar.Enabled = false; }
        }
    }
}