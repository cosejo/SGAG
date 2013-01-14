using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITCR.SGAG.Negocios;

namespace ITCR.SGAG.Interfaz
{
    public partial class frmRealizarPrestamo : System.Web.UI.Page
    {
        static List<Control> _implementos;
        static int _sigIdImplemento;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _implementos = new List<Control>();
                _sigIdImplemento = 0;
                AgregarImplemento();
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
                            if (elementoHijo is Button) { ((Button)elementoHijo).Click += new EventHandler(btnQuitar_Click); }
                        }
                    }
                }
            }
        }

        private void AgregarImplemento()
        {
            //Panel nuevoImplemento = new Panel();
            //nuevoImplemento.ID = "implemento_" + _sigIdImplemento;
            //TextBox txt;
            //txt = new TextBox();
            //txt.ID = _sigIdImplemento + "";
            //txt.Text = txt.ID;
            //nuevoImplemento.Controls.Add(txt);
            //_implementos.Add(nuevoImplemento);
            //implementos.Controls.Add(nuevoImplemento);
            //_sigIdImplemento++;

            //((TextBox)_implementos[0].Controls[0]).Text = "BIEEEN";

            // ==============================================================================================

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
            drpImplemento.Items.Insert(0, "-- Seleccione un implemento --");
            nuevoImplemento.Controls.Add(drpImplemento);
            html = "</p><p><b>Disponible: </b>";
            nuevoImplemento.Controls.Add(new LiteralControl(html));
            Label lblDisponible = new Label();
            lblDisponible.ID = "lblDisponible_" + _sigIdImplemento;
            nuevoImplemento.Controls.Add(lblDisponible);
            html = "</p><p><b>Próxima devolución: </b>";
            nuevoImplemento.Controls.Add(new LiteralControl(html));
            Label lblProxDevolucion = new Label();
            lblDisponible.ID = "lblProxDevolucion_" + _sigIdImplemento;
            nuevoImplemento.Controls.Add(lblProxDevolucion);
            html = "</p><p><b>Cantidad solicitada: </b>";
            nuevoImplemento.Controls.Add(new LiteralControl(html));
            DropDownList drpCantSolicitada = new DropDownList();
            drpImplemento.ID = "drpCantSolicitada_" + _sigIdImplemento;
            drpImplemento.CssClass = "CampoCombo";
            nuevoImplemento.Controls.Add(drpCantSolicitada);
            html = "</p><p id='pDurante'><b>Durante: </b>";
            nuevoImplemento.Controls.Add(new LiteralControl(html));
            TextBox txtDurante = new TextBox();
            txtDurante.ID = "txtDurante_" + _sigIdImplemento;
            txtDurante.CssClass = "CampoTextoNumerico";
            nuevoImplemento.Controls.Add(txtDurante);
            DropDownList drpUnidDurante = new DropDownList();
            drpUnidDurante.ID = "drpUnidDurante_" + _sigIdImplemento;
            drpUnidDurante.CssClass = "CampoCombo";
            drpUnidDurante.Items.Insert(0, "Días");
            drpUnidDurante.Items.Insert(1, "Horas");
            nuevoImplemento.Controls.Add(drpUnidDurante);
            html = "</p><p><b>Tipo de préstamo: </b>";
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
            implementos.Controls.Add(nuevoImplemento);
            _sigIdImplemento++;
            btnRealizar.Enabled = true;
            #endregion
        }

        private cSGMUUSUARIONegocios Verificar()
        {
            return null;
        }

        private bool VerificarHabilitado(cSGMUUSUARIONegocios pUsuarioGimnasio)
        {
            return true;
        }
        
        private bool RealizarPrestamo()
        {

            return true;
        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {

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