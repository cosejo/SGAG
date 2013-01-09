using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITCR.SGAG.Negocios;

namespace ITCR.SGAG.Interfaz
{
    public partial class frmIngresoSalaFuerza : System.Web.UI.Page
    {
        string Nombre = "NATALIA MARÍA QUIRÓS PORRAS";

        protected void Page_Load(object sender, EventArgs e)
        {
            ButRegistrar.Enabled = false;
        }

        protected void ButVerificar_Click(object sender, EventArgs e)
        {
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
            cSGPRINGRESONegocios Negocios = new cSGPRINGRESONegocios(Global.gCOD_APLICACION, "CA", 1, "naquiros");
            string[] stringFecha = TextBoxFecha.Text.Split('/');
            DateTime fecha = new DateTime(Int32.Parse(stringFecha[2]), Int32.Parse(stringFecha[0]), Int32.Parse(stringFecha[1]));
            Negocios.FEC_INGRESO = fecha;
            Negocios.FEC_SISTEMA = DateTime.Now.Date;
            Negocios.CAR_USUARIOGIMNASIO = Nombre;
            Response.Write("<SCRIPT>alert('Se ha registrado correctamente dentro del sistema.')</SCRIPT>");
        }
    }
}