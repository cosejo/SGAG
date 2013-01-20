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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObtenerPrestamos();

                HtmlGenericControl body = this.Master.FindControl("body") as HtmlGenericControl;
                body.Attributes.Add("onLoad", "OnLoad();");
            }

            CrearTablaPrestamos();
            btnVerDetalle.Attributes.Add("onclick", "javascritp:MostrarDetallePrestamo();");
        }

        public void ObtenerPrestamos()
        {
            cSGPRPRESTAMONegocios prestamos = new cSGPRPRESTAMONegocios(Global.gCOD_APLICACION, "CA", 0, "200949216");
            _prestamos = prestamos.SeleccionarTodos();
        }

        public void CrearTablaPrestamos()
        {
            String aDataSet = "[";

            foreach (DataRow prestamo in _prestamos.Rows)
            {
                String tipo = (prestamo["FK_IDTIPOPRESTAMO"].ToString() == "1") ? "Normal" : "Especial";

                aDataSet += "['"
                    + prestamo["ID_PRESTAMO"] + "', '"
                    + prestamo["CAR_USUARIOGIMNASIO"] + "', '"
                    + "Mauricio Muñoz Chaves" + "', '" // AQUÍ SE DEBE VERIFICAR EL USUARIO CON EL WEB SERVICE Y PONER EL NOMBRE CORRESPONDIENTE
                    + prestamo["FEC_PRESTAMO"] + "', '"
                    + tipo + "', '"
                    + prestamo["ESTADO"] + "'],"; 
            }

            aDataSet = aDataSet.Remove(aDataSet.Length-1, 1);

            aDataSet += "]";

            if (!Page.ClientScript.IsStartupScriptRegistered("TablaPrestamos"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "TablaPrestamos", "<script type=\"text/javascript\"> CrearTablaPrestamos(" + aDataSet + ");</script>");
            }

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
                    CrearDetallePrestamo(int.Parse(idPrestamoSeleccionado));
                    return;
                }
            }
        }

        private void CrearDetallePrestamo(int pIdPrestamoSeleccionado)
        {
            String html;

            html = "<h3>Detalle del Préstamo</h3><div id='infoPrestamo'><p><b>Nombre: </b>";
            panelDetalle.Controls.Add(new LiteralControl(html));
            Label lblNombre = new Label();
            lblNombre.Text = "Mauricio Muñoz Chaves";
            lblNombre.ID = "lblNombre";
            panelDetalle.Controls.Add(lblNombre);
            html = "</p><p><b>Identificación: </b>";
            panelDetalle.Controls.Add(new LiteralControl(html));
            Label lblIdentificacion = new Label();
            lblNombre.Text = "200949216";
            lblNombre.ID = "lblIdentificacion";
            panelDetalle.Controls.Add(lblIdentificacion);
            html = "</p></div>";
            Panel implementos = new Panel();
            implementos.ID = "implementos";
            // ============================================================ INICIA CICLO DE IMPLEMENTOS
            Panel implemento = new Panel();
            implemento.ID = "panelImplemento_" + "X";
            html = "<fieldset><legend>Implemento Prestado</legend><p><b>Implemento: </b>";
            implemento.Controls.Add(new LiteralControl(html));
            Label lblImplemento = new Label();
            lblImplemento.Text = "Balón de fútbol - Marca Addidas";
            lblImplemento.ID = "lblImplemento_" + "X";
            implemento.Controls.Add(lblImplemento);
            html = "</p><p><b>Fecha de Devolución: </b>";
            implemento.Controls.Add(new LiteralControl(html));
            Label lblFechaDevolucion = new Label();
            lblFechaDevolucion.Text = "17/02-2013 -- : -- : --";
            lblFechaDevolucion.ID = "lblFechaDevolucion_" + "X";
            implemento.Controls.Add(lblFechaDevolucion);
            html = "</p><p><b>Cantidad Pendiente: </b>";
            implemento.Controls.Add(new LiteralControl(html));
            Label lblCantidadPendiente = new Label();
            lblCantidadPendiente.Text = "6";
            lblCantidadPendiente.ID = "lblCantidadPendiente_" + "X";
            implemento.Controls.Add(lblCantidadPendiente);
            html = "</p><p class='pCantDevolver'><b>Cantidad a devolver: </b>";
            implemento.Controls.Add(new LiteralControl(html));
            TextBox txtCantDevolver = new TextBox();
            txtCantDevolver.CssClass = "CampoTextoNumerico";
            txtCantDevolver.ID = "txtCantDevolver_" + "X";
            implemento.Controls.Add(txtCantDevolver);
            html = "</p><p class='pCantDanada'><b>Cantidad con daños: </b>";
            implemento.Controls.Add(new LiteralControl(html));
            TextBox txtCantDanada = new TextBox();
            txtCantDanada.CssClass = "CampoTextoNumerico";
            txtCantDanada.ID = "txtCantDanada_" + "X";
            implemento.Controls.Add(txtCantDanada);
            html = "[OPCIONAL]</p><p class='pObservaciones'><b>Observaciones de los daños: </b><br />";
            implemento.Controls.Add(new LiteralControl(html));
            TextBox txtObservaciones = new TextBox();
            txtObservaciones.CssClass = "CampoTexto";
            txtObservaciones.ID = "txtObservaciones_" + "X";
            txtObservaciones.MaxLength = 100;
            implemento.Controls.Add(txtObservaciones);
            html = "[OPCIONAL]</p></fieldset>";
            implemento.Controls.Add(new LiteralControl(html));
            implementos.Controls.Add(implemento);
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
            btnOcultarDetalle.Click += new EventHandler(btnOcultarDetalle_Click); 
            panelDetalle.Controls.Add(btnOcultarDetalle);
            html = "</div>";
            panelDetalle.Controls.Add(new LiteralControl(html));
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            VerificarPrestamoSeleccionado();
        }

        protected void btnOcultarDetalle_Click(object sender, EventArgs e)
        {
            panelDetalle.Controls.Clear();
        }
    }
}