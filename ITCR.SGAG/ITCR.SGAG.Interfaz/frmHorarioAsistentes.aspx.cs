using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITCR.SGAG.Interfaz
{
    public partial class frmHorarioAsistentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarHorario();
        }

        private void cargarHorario() 
        { 
           int year = 2013;
            int month = 1;
            int day = 11;

              String eventData = "["
                + "{ 'id': 1, 'start': new Date(" + year + "," + month + "," + day + ", 12), 'end': new Date(" + year + "," + month + "," + day + ", 13,35), 'title': 'Lunch with Fat' },"
                + " { 'id': 2, 'start': new Date(" + year + "," + month + "," + day + ", 14), 'end': new Date(" + year + "," + month + "," + day + ",  14, 45), 'title': 'Prety Fat Meeting' },"
                + " { 'id': 3, 'start': new Date(" + year + "," + month + "," + day + ", 1, 18), 'end': new Date(" + year + "," + month + "," + day + ", 1, 18, 45), 'title': 'Hair cut Fat' },"
                + " { 'id': 4, 'start': new Date(" + year + "," + month + "," + day + ", - 1, 8), 'end': new Date(" + year + "," + month + "," + day + ", - 1, 9, 30), 'title': 'Fat breakfast' },"
                + " { 'id': 5, 'start': new Date(" + year + "," + month + "," + day + ", + 1, 14), 'end': new Date(" + year + "," + month + "," + day + ", 1, 15), 'title': 'Product Fat' }"
                + "]";

            if (!Page.ClientScript.IsStartupScriptRegistered("Horario"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Horario", "<script type=\"text/javascript\"> crearHorario("+eventData+");</script>");
            }
        }
    }
}