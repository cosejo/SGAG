using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using ITCR.SGAG.Negocios;

namespace ITCR.SGAG.Interfaz
{
    public partial class frmVerPrestamos : System.Web.UI.Page
    {
        static DataTable _prestamos;
        static Panel _prestamoElegido;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WrapperDetalle.Controls.Clear();
                _prestamoElegido = null;
                HtmlGenericControl body = this.Master.FindControl("body") as HtmlGenericControl;
                body.Attributes.Add("onLoad", "OnLoad();");
            }

            if (_prestamoElegido != null)
            {
                WrapperDetalle.Controls.Add(_prestamoElegido);
                AgregarEventos();
            }

            ObtenerPrestamos();
            CrearTablaPrestamos();
            btnVerDetalle.Attributes.Add("onclick", "javascritp:MostrarDetallePrestamo();");
        }

        public void ObtenerPrestamos()
        {
            cSGPRPRESTAMONegocios prestamos = new cSGPRPRESTAMONegocios(Global.gCOD_APLICACION, "CA", 0, "0");
            _prestamos = prestamos.SeleccionarTodos();
        }

        public void CrearTablaPrestamos()
        {
            String aDataSet = "[";

            foreach (DataRow prestamo in _prestamos.Rows)
            {
                String tipo = (prestamo["FK_IDTIPOPRESTAMO"].ToString() == "1") ? "Normal" : "Especial";
                String nombre = "";

                // Descomentar esta línea para realizar pruebas en ambiente de desarrollo
                // ----------------------------------------------------------------------
               // nombre = "Mauricio Muñoz Chaves";
                // ----------------------------------------------------------------------

                // Comentar estas líneas para realizar pruebas en ambiente de desarrollo
                // ---------------------------------------------------------------------
                wsSeguridad.SeguridadSoapClient wsseg = new wsSeguridad.SeguridadSoapClient();
                wsseg.ComprobarEstudiante(out nombre, prestamo["CAR_USUARIOGIMNASIO"].ToString());
                if (nombre == "")
                {
                    wsseg.ComprobarUsuarioAD(out nombre, prestamo["CAR_USUARIOGIMNASIO"].ToString());
                    if (nombre == "")
                    {
                        nombre = "Nombre desconocido";
                    }
                }
                // ---------------------------------------------------------------------

                aDataSet += "['"
                    + prestamo["ID_PRESTAMO"] + "', '"
                    + prestamo["CAR_USUARIOGIMNASIO"] + "', '"
                    + nombre + "', '"
                    + prestamo["FEC_PRESTAMO"] + "', '"
                    + tipo + "', '"
                    + prestamo["ESTADO"] + "'],"; 
            }

            aDataSet = aDataSet.Remove(aDataSet.Length-1, 1);

            aDataSet += "]";

            btnVerDetalle.Enabled = true;
            if (_prestamos.Rows.Count == 0)
            {
                aDataSet = "[]";
                btnVerDetalle.Enabled = false;
            }

            if (!Page.ClientScript.IsStartupScriptRegistered("TablaPrestamos"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "TablaPrestamos", "<script type=\"text/javascript\"> CrearTablaPrestamos(" + aDataSet + ");</script>");
            }

        }

        public void AgregarEventos()
        {
            foreach (Control implementos in _prestamoElegido.Controls)
            {
                if (implementos is Panel && implementos.ID.StartsWith("implementos_"))
                {
                    foreach (Control implemento in implementos.Controls)
                    {
                        if (implemento is Panel && implemento.ID.StartsWith("panelImplemento_"))
                        {
                            foreach (Control elementoHijo in implemento.Controls)
                            {
                                if (elementoHijo is DropDownList && elementoHijo.ID.StartsWith("drpCantDevolver_"))
                                {
                                    ((DropDownList)elementoHijo).SelectedIndexChanged += new EventHandler(drpCantDevolver_IndexChanged);
                                }
                            }
                        }
                    }
                }
            }

            Button btnOcultarDetalle = (Button)_prestamoElegido.FindControl("btnOcultarDetalle");
            btnOcultarDetalle.Click += new EventHandler(btnOcultarDetalle_Click);

            Button btnRealizarDevolucion = (Button)_prestamoElegido.FindControl("btnRealizarDevolucion");
            btnRealizarDevolucion.Click += new EventHandler(btnRealizarDevolucion_Click);
            
        }

        private void VerificarPrestamoSeleccionado()
        {
            if (Request["__EVENTTARGET"] == "MostrarDetallePrestamo")
            {
                String idPrestamoSeleccionado = Request["__EVENTARGUMENT"];

                int idConvertido;
                bool resultadoConversion = int.TryParse(idPrestamoSeleccionado, out idConvertido);

                if (resultadoConversion)
                {
                    WrapperDetalle.Controls.Clear();
                    CrearDetallePrestamo(int.Parse(idPrestamoSeleccionado));
                    ObtenerInfoPrestamo(int.Parse(idPrestamoSeleccionado));
                    AgregarEventos();
                    return;
                }
                else
                {
                    if (!Page.ClientScript.IsStartupScriptRegistered("AlertaVerDetalle"))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertaVerDetalle",
                            "<script type=\"text/javascript\"> alert('Para ver el detalle, primero debe elegir el préstamo.'); </script>");
                    }
                }
            }
        }

        private void CrearDetallePrestamo(int pIdPrestamo)
        {
            cSGPRIMPLEMENTOPORPRESTAMONegocios implementosTemp = new cSGPRIMPLEMENTOPORPRESTAMONegocios(Global.gCOD_APLICACION, "CA", 0, "0");
            implementosTemp.FK_IDPRESTAMO = pIdPrestamo;
            DataTable tablaImplementos = implementosTemp.SeleccionarTodos_Con_FK_IDPRESTAMO_FK();

            #region Generación del detalle de un préstamo
            String html;

            Panel panelDetalle = new Panel();
            panelDetalle.ID = "panelDetalle_" + pIdPrestamo;
            html = "<h3>Detalle del Préstamo</h3><div id='infoPrestamo'><p><b>Identificación: </b>";
            panelDetalle.Controls.Add(new LiteralControl(html));
            Label lblIdentificacion = new Label();
            lblIdentificacion.ID = "lblIdentificacion";
            panelDetalle.Controls.Add(lblIdentificacion);

            html = "</p><p><b>Nombre: </b>";
            panelDetalle.Controls.Add(new LiteralControl(html));
            Label lblNombre = new Label();
            lblNombre.ID = "lblNombre";
            panelDetalle.Controls.Add(lblNombre);

            html = "</p><p><b>Fecha del préstamo: </b>";
            panelDetalle.Controls.Add(new LiteralControl(html));
            Label lblFechaPrestamo = new Label();
            lblFechaPrestamo.ID = "lblFechaPrestamo";
            panelDetalle.Controls.Add(lblFechaPrestamo);

            html = "</p><p><b>Tipo de préstamo: </b>";
            panelDetalle.Controls.Add(new LiteralControl(html));
            Label lblTipoPrestamo = new Label();
            lblTipoPrestamo.ID = "lblTipoPrestamo";
            panelDetalle.Controls.Add(lblTipoPrestamo);

            html = "</p><p><b>Estado del préstamo: </b>";
            panelDetalle.Controls.Add(new LiteralControl(html));
            Label lblEstadoPrestamo = new Label();
            lblEstadoPrestamo.ID = "lblEstadoPrestamo";
            panelDetalle.Controls.Add(lblEstadoPrestamo);

            html = "</p></div>";
            Panel implementos = new Panel();
            implementos.ID = "implementos_" + pIdPrestamo;
            // ============================================================ INICIA CICLO DE IMPLEMENTOS
            foreach (DataRow _implemento in tablaImplementos.Rows)
            {
                int idImplemento = int.Parse(_implemento["ID_IMPLEMENTO"].ToString());
                Panel implemento = new Panel();
                implemento.ID = "panelImplemento_" + idImplemento;
                html = "<fieldset><legend>Implemento Prestado</legend><p><b>Implemento: </b>";
                implemento.Controls.Add(new LiteralControl(html));
                Label lblImplemento = new Label();
                lblImplemento.Text = _implemento["NOM_IMPLEMENTO"].ToString();
                lblImplemento.ID = "lblImplemento_" + idImplemento;
                implemento.Controls.Add(lblImplemento);
                html = "</p><p><b>Fecha de Devolución: </b>";
                implemento.Controls.Add(new LiteralControl(html));
                Label lblFechaDevolucion = new Label();
                lblFechaDevolucion.Text = _implemento["FEC_ENTREGA"].ToString();
                lblFechaDevolucion.ID = "lblFechaDevolucion_" + idImplemento;
                implemento.Controls.Add(lblFechaDevolucion);
                html = "</p><p><b>Cantidad Pendiente: </b>";
                implemento.Controls.Add(new LiteralControl(html));
                Label lblCantidadPendiente = new Label();
                lblCantidadPendiente.Text = _implemento["CANT_PENDIENTE"].ToString();
                lblCantidadPendiente.ID = "lblCantidadPendiente_" + idImplemento;
                implemento.Controls.Add(lblCantidadPendiente);
                html = "</p><p class='pCantDevolver'><b>Cantidad a devolver: </b>";
                implemento.Controls.Add(new LiteralControl(html));
                DropDownList drpCantDevolver = new DropDownList();
                drpCantDevolver.CssClass = "CampoCombo";
                drpCantDevolver.ID = "drpCantDevolver_" + idImplemento;
                drpCantDevolver.AutoPostBack = true;
                for (int i = 0; i <= Convert.ToInt32(_implemento["CANT_PENDIENTE"]); i++)
                {
                    drpCantDevolver.Items.Add(i + "");
                }
                implemento.Controls.Add(drpCantDevolver);
                html = "</p><p class='pCantDanada'><b>Cantidad con daños: </b>";
                implemento.Controls.Add(new LiteralControl(html));
                DropDownList drpCantDanada = new DropDownList();
                drpCantDanada.CssClass = "CampoCombo";
                drpCantDanada.ID = "drpCantDanada_" + idImplemento;
                implemento.Controls.Add(drpCantDanada);
                drpCantDanada.Items.Add("0");
                html = "&nbsp;[Opcional]</p><p class='pObservaciones'><b>Observaciones de los daños: </b><br />";
                implemento.Controls.Add(new LiteralControl(html));
                TextBox txtObservaciones = new TextBox();
                txtObservaciones.CssClass = "CampoTexto";
                txtObservaciones.ID = "txtObservaciones_" + idImplemento;
                txtObservaciones.MaxLength = 100;
                implemento.Controls.Add(txtObservaciones);
                html = "[Opcional]</p></fieldset>";
                implemento.Controls.Add(new LiteralControl(html));
                implementos.Controls.Add(implemento);
            }
            // ============================================================ TERMINA CICLO DE IMPLEMENTOS
            panelDetalle.Controls.Add(implementos);
            html = "<div id='dRealizarDevolucion' class='dBotonesCentrados'>";
            panelDetalle.Controls.Add(new LiteralControl(html));
            Button btnRealizarDevolucion = new Button();
            btnRealizarDevolucion.ID = "btnRealizarDevolucion";
            btnRealizarDevolucion.Text = "Realizar Devolución";
            panelDetalle.Controls.Add(btnRealizarDevolucion);
            Button btnOcultarDetalle = new Button();
            btnOcultarDetalle.ID = "btnOcultarDetalle";
            btnOcultarDetalle.Text = "Ocultar Detalle"; 
            panelDetalle.Controls.Add(btnOcultarDetalle);
            html = "</div>";
            panelDetalle.Controls.Add(new LiteralControl(html));
            _prestamoElegido = panelDetalle;
            WrapperDetalle.Controls.Add(panelDetalle);
            #endregion
        }

        private void ObtenerInfoPrestamo(int pIdPrestamo)
        {
            foreach (DataRow prestamo in _prestamos.Rows)
            {
                if (int.Parse(prestamo["ID_PRESTAMO"].ToString()) == pIdPrestamo)
                {
                    String nombre = "";

                    // Descomentar esta línea para realizar pruebas en ambiente de desarrollo
                    // ----------------------------------------------------------------------
                   // nombre = "Mauricio Muñoz Chaves";
                    // ----------------------------------------------------------------------

                    // Comentar estas líneas para realizar pruebas en ambiente de desarrollo
                    // ---------------------------------------------------------------------
                    wsSeguridad.SeguridadSoapClient wsseg = new wsSeguridad.SeguridadSoapClient();
                    wsseg.ComprobarEstudiante(out nombre, prestamo["CAR_USUARIOGIMNASIO"].ToString());
                    if (nombre == "")
                    {
                        wsseg.ComprobarUsuarioAD(out nombre, prestamo["CAR_USUARIOGIMNASIO"].ToString());
                        if (nombre == "")
                        {
                            nombre = "Nombre desconocido";
                        }
                    }
                    // ---------------------------------------------------------------------

                    Label lblIdentifiacion = (Label)_prestamoElegido.FindControl("lblIdentificacion");
                    lblIdentifiacion.Text = prestamo["CAR_USUARIOGIMNASIO"].ToString();
                    Label lblNombre = (Label)_prestamoElegido.FindControl("lblNombre");
                    lblNombre.Text = nombre;
                    Label lblFechaPrestamo = (Label)_prestamoElegido.FindControl("lblFechaPrestamo");
                    lblFechaPrestamo.Text = prestamo["FEC_PRESTAMO"].ToString();
                    String tipo = (prestamo["FK_IDTIPOPRESTAMO"].ToString() == "1") ? "Normal" : "Especial";
                    Label lblTipoPrestamo = (Label)_prestamoElegido.FindControl("lblTipoPrestamo");
                    lblTipoPrestamo.Text = tipo;
                    Label lblEstadoPrestamo = (Label)_prestamoElegido.FindControl("lblEstadoPrestamo");
                    lblEstadoPrestamo.Text = prestamo["ESTADO"].ToString();
                    break;
                }
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            VerificarPrestamoSeleccionado();
        }

        protected void btnOcultarDetalle_Click(object sender, EventArgs e)
        {
            WrapperDetalle.Controls.Clear();
            _prestamoElegido = null;
        }

        protected void drpCantDevolver_IndexChanged(object sender, EventArgs e)
        {
            DropDownList drpCantDevolver = (DropDownList)sender;
            Char[] delimiter = { '_' };

            string idCombo = drpCantDevolver.ID;
            string idImplemento = idCombo.Split(delimiter)[1];

            string idPanel = _prestamoElegido.ID;
            string idPrestamo = idPanel.Split(delimiter)[1];

            Panel panelImplemento = (Panel)_prestamoElegido.FindControl("implementos_" + idPrestamo).FindControl("panelImplemento_" + idImplemento);
            DropDownList lblCantDanada = (DropDownList)panelImplemento.FindControl("drpCantDanada_" + idImplemento);

            int cantElegida = int.Parse(drpCantDevolver.SelectedValue);
            lblCantDanada.Items.Clear();

            for (int i = 0; i <= cantElegida; i++)
            {
                lblCantDanada.Items.Add(i + "");
            }
        }

        protected void btnRealizarDevolucion_Click(object sender, EventArgs e)
        {
            cSGPRDEVOLUCIONNegocios devolucion = new cSGPRDEVOLUCIONNegocios(Global.gCOD_APLICACION, "CA", 0, "0");
            devolucion.FEC_DEVOLUCION = DateTime.Now;
            Label lblIdentifiacion = (Label)_prestamoElegido.FindControl("lblIdentificacion");
            devolucion.CAR_USUARIOGIMNASIO = lblIdentifiacion.Text;

            Char[] delimiter = { '_' };
            string idPanel = _prestamoElegido.ID;
            string idPrestamo = idPanel.Split(delimiter)[1];

            devolucion.FK_IDPRESTAMO = int.Parse(idPrestamo);

            if (!ComprobarDevolucionValida(devolucion))
            {
                if (!Page.ClientScript.IsStartupScriptRegistered("DevolucionInvalida"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "DevolucionInvalida",
                        "<script type=\"text/javascript\"> alert('Debe ingresar alguna cantidad a devolver para al menos uno de los implementos.'); </script>");
                }
                return;
            }

            devolucion.Insertar();

            AgregarImplementosDevueltos(devolucion);

            WrapperDetalle.Controls.Clear();
            _prestamoElegido = null;

            cSGPRIMPLEMENTOPORPRESTAMONegocios implementosTemp = new cSGPRIMPLEMENTOPORPRESTAMONegocios(Global.gCOD_APLICACION, "CA", 0, "0");
            implementosTemp.FK_IDPRESTAMO = int.Parse(idPrestamo);
            DataTable tablaImplementos = implementosTemp.SeleccionarTodos_Con_FK_IDPRESTAMO_FK();
            if (tablaImplementos.Rows.Count == 0)
            {
                cSGPRPRESTAMONegocios prestamos = new cSGPRPRESTAMONegocios(Global.gCOD_APLICACION, "CA", 0, "0");
                prestamos.ID_PRESTAMO = int.Parse(idPrestamo);
                prestamos.ESTADO = true;
                prestamos.Actualizar();
            }

            if (!Page.ClientScript.IsStartupScriptRegistered("DevolucionSatisfactoria"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "DevolucionSatisfactoria",
                    "<script type=\"text/javascript\"> __doPostBack(); alert('La devolución se realizó satisfactoriamente.'); </script>");
            }
      
        }

        private Boolean ComprobarDevolucionValida(cSGPRDEVOLUCIONNegocios pDevolucion)
        {
            Panel implementos = (Panel)_prestamoElegido.FindControl("implementos_" + pDevolucion.FK_IDPRESTAMO);
            Char[] delimiter = { '_' };

            foreach (Control implemento in implementos.Controls)
            {
                string idPanel = implemento.ID;
                string sIdImplemento = idPanel.Split(delimiter)[1];
                int idImplemento = int.Parse(sIdImplemento);

                DropDownList drpCantDevolver = (DropDownList)implemento.FindControl("drpCantDevolver_" + idImplemento);

                if (drpCantDevolver.SelectedIndex > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void AgregarImplementosDevueltos(cSGPRDEVOLUCIONNegocios pDevolucion)
        {
            Panel implementos = (Panel)_prestamoElegido.FindControl("implementos_" + pDevolucion.FK_IDPRESTAMO);
            Char[] delimiter = { '_' };

            foreach (Control implemento in implementos.Controls)
            {
                string idPanel = implemento.ID;
                string sIdImplemento = idPanel.Split(delimiter)[1];
                int idImplemento = int.Parse(sIdImplemento);

                DropDownList drpCantDevolver = (DropDownList)implemento.FindControl("drpCantDevolver_" + idImplemento);

                if (drpCantDevolver.SelectedIndex > 0)
                {
                    cSGPRIMPLEMENTOSPORDEVOLUCIONNegocios implementoDevuelto = new cSGPRIMPLEMENTOSPORDEVOLUCIONNegocios(Global.gCOD_APLICACION, "CA", 0, "0");
                    implementoDevuelto.FK_IMPLEMENTO = idImplemento;
                    implementoDevuelto.FK_DEVOLUCION = pDevolucion.ID_DEVOLUCION;
                    implementoDevuelto.CANT_DEVUELTOS = drpCantDevolver.SelectedIndex;
                    implementoDevuelto.Insertar();

                    cSGGIIMPLEMENTONegocios implementoInventario = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 0, "0");
                    implementoInventario.ID_IMPLEMENTO = idImplemento;
                    DataTable tablaBusqueda = implementoInventario.Buscar();
                    implementoInventario.CAN_DISPONIBLE = int.Parse(tablaBusqueda.Rows[0]["CAN_DISPONIBLE"].ToString()) + drpCantDevolver.SelectedIndex;
                    implementoInventario.Actualizar();

                    DropDownList drpCantDanada = (DropDownList)implemento.FindControl("drpCantDanada_" + idImplemento);

                    if (drpCantDanada.SelectedIndex > 0)
                    {
                        cSGGIDANOPORIMPLEMENTONegocios dano = new cSGGIDANOPORIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 0, "0");
                        dano.FK_IDIMPLEMENTO = idImplemento;
                        dano.FEC_REPORTE = DateTime.Now;
                        dano.CAN_IMPLEMENTOS = drpCantDanada.SelectedIndex;
                        TextBox txtObservaciones = (TextBox)implemento.FindControl("txtObservaciones_" + idImplemento);
                        dano.DSC_DANO = txtObservaciones.Text;
                        dano.Insertar();

                        cSGPRDANOPORDEVOLUCIONNegocios danoDevolucion = new cSGPRDANOPORDEVOLUCIONNegocios(Global.gCOD_APLICACION, "CA", 0, "0");
                        danoDevolucion.FK_IDDEVOLUCION = pDevolucion.ID_DEVOLUCION;
                        danoDevolucion.FK_IDDANO = dano.ID_DANO;
                        danoDevolucion.Insertar();
                    }
                }
            }
        }
    }
}