using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITCR.SGAG.Interfaz
{
    public partial class frmIngresoSalaFuerza : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ButRegistrar.Enabled = false;
        }

        protected void ButVerificar_Click(object sender, EventArgs e)
        {
            string Nombre = "NATALIA MARÍA QUIRÓS PORRAS";
            /*wsSeguridad.SeguridadSoapClient wsseg = new wsSeguridad.SeguridadSoapClient();
            wsseg.ComprobarEstudiante(out Nombre, TextBoxId.Text);*/
            if (Nombre == "")
            {
                /* wsseg.ComprobarUsuarioAD(out Nombre, TextBoxId.Text);*/
                if (Nombre == "")
                {
                    LabelNombre.Text = "Identificación no registrada";
                    LabelNombre.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                }
            }
            else
            {
                LabelNombre.Text = "Nombre: " + Nombre;
                ButRegistrar.Enabled = true;
            }
             LabelNombre.Visible = true;
             
        }

        protected void ButRegistrar_Click(object sender, EventArgs e)
        {

        }
    }
}