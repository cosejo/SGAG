using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ITCR.SGAG.Negocios;

namespace ITCR.SGAG.Interfaz
{
    public partial class frmGestionInventario : System.Web.UI.Page
    {
        #region Atributos

        private DataTable DT_Deportes;
        private DataTable DT_Implementos;
        private static int Ind_Id = 0;
        private static int Ind_Nombre = 1;

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            cSGGIDEPORTENegocios DeporteNuevo = new cSGGIDEPORTENegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
            DeporteNuevo.NOM_DEPORTE = TextBoxDeporteNuevo.Text;
            DeporteNuevo.Insertar();
            //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "IniciarTabla();", true);
          /*  if (!Page.IsPostBack)
            {*/
                obtenerDeportes();
                obtenerImplementos();
            //}
        }

        protected void BotonAgregarImplemento_Click(object sender, EventArgs e)
        {
            String MensajeDevuelto = "";
            try
            {
                Page.Validate("Implemento");

                if (Page.IsValid)
                {
                    if (agregarImplemento())
                    {
                        MensajeDevuelto = "El Implemento ha sido agregado satisfactoriamente";
                        LabelMensaje.ForeColor = System.Drawing.Color.Blue;
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeDevuelto = ex.Message;
                LabelMensaje.ForeColor = LabelMensaje.ForeColor = System.Drawing.Color.Blue;
            }
            LabelMensaje.Text = MensajeDevuelto;
        }

        protected void BotonAgregarDeporte_Click(object sender, EventArgs e)
        {
            String MensajeDevuelto = "";
            try
            {
                Page.Validate("Deporte");

                if (Page.IsValid)
                {
                    if (agregarDeporte())
                    {
                        MensajeDevuelto = "El Deporte ha sido agregado satisfactoriamente";
                        LabelMensaje.ForeColor = System.Drawing.Color.Blue;
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeDevuelto = ex.Message;
                LabelMensaje.ForeColor = LabelMensaje.ForeColor = System.Drawing.Color.Blue;
            }
            LabelMensaje.Text = MensajeDevuelto;
        }

        protected void ComboBoxMultiColumnaItem_onClick(object sender, EventArgs e)
        {
            string linkButtonText = ((LinkButton)sender).Text;
            string ID = linkButtonText.Split('\u00A0')[1];
            string VALUE = linkButtonText.Split('\u00A0')[3];
            LblComboBoxMultiColumna.Text = ID;
            LblSelectedItemComboBoxMultiColumna.Text = " Elemento seleccionado: " + VALUE;
        }

        #endregion

        #region Metodos

        private void obtenerImplementos() 
        {
            cSGGIIMPLEMENTONegocios Implemento = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION,"CA",2,"cosejo");
            DT_Implementos = Implemento.SeleccionarTodos();
            DataRow row = DT_Implementos.Rows[0];
            string e = row[0].ToString();
            llenarTablaImplementos();
        }

        private void obtenerDeportes()
        {
            cSGGIDEPORTENegocios Deporte = new cSGGIDEPORTENegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
            DT_Deportes = Deporte.SeleccionarTodos();
            llenarComboBoxDeportes();
        }

        private void llenarTablaImplementos() 
        { 
        }

        private void llenarComboBoxDeportes() 
        {
            List<String> listaDeportes = new List<String>();
            for (int IndiceDeportes = 0; IndiceDeportes < DT_Deportes.Rows.Count; IndiceDeportes++)
            {
                listaDeportes.Add(DT_Deportes.Rows[IndiceDeportes][Ind_Nombre].ToString());
            }
              
                foreach (String deporte in listaDeportes)
                {
                    if (LblComboBoxMultiColumna.Text == "")
                    {
                        LblComboBoxMultiColumna.Text = deporte;
                    }

                    LinkButton lb = new LinkButton();
                    lb.ID = "Lbl" + deporte + "ComboBoxMultiColumna";
                    lb.CssClass = "MultiColumnContextMenuItem";
                    lb.Click += new EventHandler(ComboBoxMultiColumnaItem_onClick);

                    lb.Text = "<div>";
                    lb.Text += "<span style=\"width: 40px;\">" + '\u00A0' + deporte + '\u00A0' + "</span>";
                    lb.Text += "" + '\u00A0' + deporte + '\u00A0' + "";
                    lb.Text += "</div>";



                    PnlComboBoxMultiColumna.Controls.Add(lb);
                }
        }

        private Boolean agregarImplemento() 
        {
            cSGGITIPOIMPLEMENTONegocios tipoImplementoNuevo = new cSGGITIPOIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
            cSGGIDEPORTENegocios Deporte = new cSGGIDEPORTENegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
            tipoImplementoNuevo.NOM_TIPOIMPLEMENTO = TextBoxImplementoNuevo.Text;
            tipoImplementoNuevo.DSP_IMPLEMENTO = true;
            tipoImplementoNuevo.FK_IDDEPORTE = int.Parse(DT_Deportes.Rows[Ind_Id][Ind_Id].ToString());//Cambiar cuando haya el extender
            return tipoImplementoNuevo.Insertar();
        }

        private Boolean agregarDeporte()
        {
            cSGGIDEPORTENegocios DeporteNuevo = new cSGGIDEPORTENegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
            DeporteNuevo.NOM_DEPORTE = TextBoxDeporteNuevo.Text;
            return DeporteNuevo.Insertar();
        }

        #endregion
    }
}