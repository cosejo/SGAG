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
            VerificarPrestamoSeleccionado();
            
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
        }
    }
}