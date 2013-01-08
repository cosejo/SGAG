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

        protected void obtenerImplementos() 
        {
            cSGGIIMPLEMENTONegocios Implemento = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION,"CA",2,"cosejo");
            Implemento.SeleccionarTodos();
        }
    }
}