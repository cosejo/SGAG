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

        private static DataTable DT_Deportes;
        private static DataTable DT_TipoImplementos;
        private static DataTable DT_Implementos;
        private static int Ind_Deporte = -1;
        private const int Ind_Id = 0;
        private const int Ind_Nombre = 1;
        private static Boolean _Modificacion = false;

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            obtenerDeportes();
            obtenerTiposImplementos();
            obtenerImplementos();
            LabelMensaje.Text = "";
        }

        protected void BotonAgregarTipoImplemento_Click(object sender, EventArgs e)
        {
            String MensajeDevuelto = "";
            LabelMensaje.Text = MensajeDevuelto;
            try
            {
                Page.Validate("TipoImplemento");

                if (Page.IsValid)
                {
                    if (agregarTipoImplemento())
                    {
                        MensajeDevuelto = "El Tipo Implemento ha sido agregado satisfactoriamente";
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
            TextBoxImplementoNuevo.Text = "";
            TextBoxDeporteNuevo.Text = "";
        }

        protected void BotonAgregarDeporte_Click(object sender, EventArgs e)
        {
            String MensajeDevuelto = "";
            LabelMensaje.Text = MensajeDevuelto;
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
            TextBoxDeporteNuevo.Text = "";
        }

        protected void ComboBoxMultiColumnaItem_onClick(object sender, EventArgs e)
        {
            string linkButtonText = ((LinkButton)sender).Text;
            string Nombre = linkButtonText.Split('\u00A0')[1];
            TextBoxDeporteNuevo.Text = Nombre;
        }

        protected void ComboBoxMultiColumnaItemImp_onClick(object sender, EventArgs e)
        {
            string linkButtonText = ((LinkButton)sender).Text;
            string Nombre = linkButtonText.Split('\u00A0')[1];
           TextBoxImplementoNuevo.Text = Nombre;
        }

        #endregion

        #region Metodos

        private void obtenerImplementos() 
        {
            try
            {
                cSGGIIMPLEMENTONegocios Implemento = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                DT_Implementos = Implemento.SeleccionarTodos();
                String aDataSet = "[";
                int cantidadColumnas = DT_Implementos.Columns.Count;
                for (int IndiceImplementos = 0; IndiceImplementos < DT_Implementos.Rows.Count; IndiceImplementos++)
                {

                    aDataSet += "['" + DT_Implementos.Rows[IndiceImplementos][0] + "','" + DT_Implementos.Rows[IndiceImplementos][1].ToString() + "','" + DT_Implementos.Rows[IndiceImplementos][3].ToString() + "','" + DT_Implementos.Rows[IndiceImplementos][4] + "','" + DT_Implementos.Rows[IndiceImplementos][2].ToString() + "']";
                    if (IndiceImplementos + 1 != DT_Deportes.Rows.Count - 2)
                    {
                        aDataSet += ",";
                    }
                }
                aDataSet += "]";

                if (!Page.ClientScript.IsStartupScriptRegistered("TablaInventario"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "TablaInventario", "<script type=\"text/javascript\"> CrearTablaInventario(" + aDataSet + ");</script>");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script type=\"text/javascript\"> alert(" + "'" + ex.Message + "'" + ");</script>");
            }
        }

        private void obtenerDeportes()
        {
            try
            {
                cSGGIDEPORTENegocios Deporte = new cSGGIDEPORTENegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                DT_Deportes = Deporte.SeleccionarTodos();
                llenarComboBoxDeportes();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta2", "<script type=\"text/javascript\"> alert(" + "'" + ex.Message + "'" + ");</script>");
            }
        }

        private void obtenerTiposImplementos()
        {
            try
            {
                cSGGITIPOIMPLEMENTONegocios TipoImplemento = new cSGGITIPOIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                DT_TipoImplementos = TipoImplemento.SeleccionarTodos();
                llenarComboBoxTipoImplemento();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta4", "<script type=\"text/javascript\"> alert(" + "'" + ex.Message + "'" + ");</script>");
            }
        }

        private void llenarComboBoxTipoImplemento()
        {
            try
            {
                List<String> listaTipoImplementos = new List<String>();
                for (int IndiceDeportes = 0; IndiceDeportes < DT_TipoImplementos.Rows.Count; IndiceDeportes++)
                {
                    listaTipoImplementos.Add(DT_TipoImplementos.Rows[IndiceDeportes][Ind_Nombre].ToString());
                }

                foreach (String tipo in listaTipoImplementos)
                {
                    LinkButton lb = new LinkButton();
                    lb.ID = "Lbl" + tipo + "ComboBoxMultiColumnaImp";
                    lb.CssClass = "MultiColumnContextMenuItem";
                    lb.Click += new EventHandler(ComboBoxMultiColumnaItemImp_onClick);

                    lb.Text = "<div>";
                    lb.Text += "<span style=\"width: 40px;\">" + '\u00A0' + tipo + '\u00A0' + "</span>";
                    lb.Text += "</div>";

                    Panel1.Controls.Add(lb);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta5", "<script type=\"text/javascript\"> alert(" + "'" + ex.Message + "'" + ");</script>");
            }
        }

        private void llenarTablaImplementos() 
        { 
        }

        private void llenarComboBoxDeportes() 
        {
            try
            {
                List<String> listaDeportes = new List<String>();
                for (int IndiceDeportes = 0; IndiceDeportes < DT_Deportes.Rows.Count; IndiceDeportes++)
                {
                    listaDeportes.Add(DT_Deportes.Rows[IndiceDeportes][Ind_Nombre].ToString());
                }

                foreach (String deporte in listaDeportes)
                {
                    LinkButton lb = new LinkButton();
                    lb.ID = "Lbl" + deporte + "ComboBoxMultiColumna";
                    lb.CssClass = "MultiColumnContextMenuItem";
                    lb.Click += new EventHandler(ComboBoxMultiColumnaItem_onClick);

                    lb.Text = "<div>";
                    lb.Text += "<span style=\"width: 40px;\">" + '\u00A0' + deporte + '\u00A0' + "</span>";
                    lb.Text += "</div>";

                    PnlComboBoxMultiColumna.Controls.Add(lb);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta3", "<script type=\"text/javascript\"> alert(" + "'" + ex.Message + "'" + ");</script>");
            }
        }

        private Boolean agregarTipoImplemento() 
        {
            try
            {
                cSGGITIPOIMPLEMENTONegocios TipoImplementoIngresado = new cSGGITIPOIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                TipoImplementoIngresado.NOM_TIPOIMPLEMENTO = TextBoxImplementoNuevo.Text;
                if (!verificarTipoImplemento(TextBoxImplementoNuevo.Text))
                {
                    return TipoImplementoIngresado.Insertar();
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean verificarTipoImplemento(String pTipoImplemento)
        {
            try
            {
                cSGGITIPOIMPLEMENTONegocios TipoImplementoIngresado = new cSGGITIPOIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                TipoImplementoIngresado.NOM_TIPOIMPLEMENTO = TextBoxImplementoNuevo.Text;
                if (TipoImplementoIngresado.Buscar().Rows.Count>0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private Boolean agregarDeporte()
        {
            try 
            {
                cSGGIDEPORTENegocios DeporteNuevo = new cSGGIDEPORTENegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                DeporteNuevo.NOM_DEPORTE = TextBoxDeporteNuevo.Text;
                if (!verificarNombreDeporte(TextBoxDeporteNuevo.Text))
                {
                    return DeporteNuevo.Insertar();
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean verificarNombreDeporte(String pNombreDeporte) 
        {
            try
            {
                cSGGIDEPORTENegocios DeporteNuevo = new cSGGIDEPORTENegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                DeporteNuevo.NOM_DEPORTE = pNombreDeporte;
                if (DeporteNuevo.Buscar().Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private Boolean agregarImplemento() 
        {
            try 
            {
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
  
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            String nuevo = TextBoxInfo.Text;
            Response.Write(nuevo);
        }

        protected void BotonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                cSGGIIMPLEMENTONegocios ImplementoNuevo = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                ImplementoNuevo.CAN_DISPONIBLE = int.Parse(TextBoxCantidad.Text.ToString());
                ImplementoNuevo.CAN_ENINVENTARIO = ImplementoNuevo.CAN_DISPONIBLE;
                ImplementoNuevo.DSC_IMPLEMENTO = TextBoxNombre.Text;
               /* ImplementoNuevo.FK_IDDEPORTE = IdDeporte;
                ImplementoNuevo.FK_IDTIPOIMPLEMENTO = IdTipoImplemento;*/
            }
            catch (Exception ex)
            { 
            }
         }

    }
}