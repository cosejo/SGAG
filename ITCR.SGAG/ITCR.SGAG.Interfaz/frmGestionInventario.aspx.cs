using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITCR.SGAG.Negocios;

namespace ITCR.SGAG.Interfaz
{
    public partial class frmGestionInventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "IniciarTabla();", true);
        }

        private void obtenerImplementos() 
        {
            cSGGIIMPLEMENTONegocios Implemento = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION,"CA",2,"cosejo");
            Implemento.SeleccionarTodos();
        }

        private Boolean agregarImplemento() 
        {
            /*Falta implementar
            cSGGIIMPLEMENTONegocios ImplementoNuevo = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
            ImplementoNuevo.DSC_IMPLEMENTO = TextBoxImplementoNuevo.Text;
            return ImplementoNuevo.Insertar();*/
            return false;
        }

        private Boolean agregarDeporte()
        {
            cSGGIDEPORTENegocios DeporteNuevo = new cSGGIDEPORTENegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
            DeporteNuevo.NOM_DEPORTE = TextBoxDeporteNuevo.Text;
            return DeporteNuevo.Insertar();
        }

        protected void BotonAgregarImplemento_Click(object sender, EventArgs e)
        {
            try {
                Page.Validate("Implemento");

                if (Page.IsValid)
                {
                    if (agregarImplemento())
                    {
                    }
                    else
                    { 
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void BotonAgregarDeporte_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("Deporte");

                if (Page.IsValid)
                {
                    if (agregarDeporte())
                    {
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}