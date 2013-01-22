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
    public partial class frmDanos : System.Web.UI.Page
    {
        #region Atributos
        private static DataTable DT_Danos;
        private const int Ind_Id = 0;
        private const int Ind_Nombre = 1;
        private static String _DatosSeleccionadosDanos = "";

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            agregarFuncionesJSBotones();
            if (IsPostBack)
            {
                verificarComandoPostBack();
            }
            obtenerDanos();
        }

        protected void BotonCancelarDanos_Click(object sender, EventArgs e)
        {
            try
            {
                TextBoxDescricpionImplemento.Text = "";
                TextBoxFechaDano.Text = "";
                TextBoxCantidad0.Text = "";
                TextBoxDescripcionDano.Text = "";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BotonGuardarDanos_Click(object sender, EventArgs e)
        {
            String MensajeDevuelto = "";
            LabelMensajeDanos.Text = MensajeDevuelto;
            try
            {
                Page.Validate("Daños");

                if (Page.IsValid)
                {
                    if (modificarDano())
                    {
                        MensajeDevuelto = "El Daño ha sido modificado satisfactoriamente";
                        obtenerDanos();
                        BotonCancelarDanos_Click(new object(), new EventArgs());
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeDevuelto = ex.Message;
            }
            LabelMensajeDanos.ForeColor = System.Drawing.Color.Blue;
            LabelMensajeDanos.Text = MensajeDevuelto;
        }

        private void BotonModificarDanos_Click()
        {
            String MensajeDevuelto = "";
            LabelMensajeDanos.Text = MensajeDevuelto;
            try
            {
                llenarCamposDanos();
            }
            catch (Exception ex)
            {
                MensajeDevuelto = ex.Message;
            }
            LabelMensajeDanos.ForeColor = System.Drawing.Color.Blue;
            LabelMensajeDanos.Text = MensajeDevuelto;
        }

        private void BotonEliminarDanos_Click()
        {
            String MensajeDevuelto = "";
            LabelMensajeDanos.Text = MensajeDevuelto;
            try
            {
                if (eliminarDano())
                {
                    MensajeDevuelto = "El Daño ha sido eliminado satisfactoriamente";
                    obtenerDanos();
                }
                else
                {
                    MensajeDevuelto = "El Daño no ha podido ser eliminado";
                }
            }
            catch (Exception ex)
            {
                MensajeDevuelto = ex.Message;
            }
            LabelMensajeDanos.ForeColor = System.Drawing.Color.Blue;
            LabelMensajeDanos.Text = MensajeDevuelto;
        }

        #endregion

        #region Metodos

        private void agregarFuncionesJSBotones()
        {
            try
            {
                BotonModificarDanos.Attributes.Add("onclick", "javascritp:ObtenerDatosModificarDanos();");
                BotonEliminarDanos.Attributes.Add("onclick", "javascritp:ObtenerDatosEliminarDanos();");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void verificarComandoPostBack()
        {
            try
            {

                if (Request["__EVENTTARGET"] == "ModificarDaños")
                {
                    _DatosSeleccionadosDanos = Request["__EVENTARGUMENT"];
                    if (verificarDatosSeleccionados(_DatosSeleccionadosDanos))
                        BotonModificarDanos_Click();
                    return;
                }


                if (Request["__EVENTTARGET"] == "EliminarDaños")
                {
                    _DatosSeleccionadosDanos = Request["__EVENTARGUMENT"];
                    if (verificarDatosSeleccionados(_DatosSeleccionadosDanos))
                        BotonEliminarDanos_Click();
                    return;
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script type=\"text/javascript\"> alert(" + "'" + ex.Message + "'" + ");</script>");
            }
        }

        private bool verificarDatosSeleccionados(string _DatosSeleccionados)
        {
            try
            {
                if (_DatosSeleccionados != null && _DatosSeleccionados != "" && _DatosSeleccionados != "undefined")
                    return true;
                else
                    throw new Exception("No se ha seleccionado ninguna columna para realizar esta acción");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void obtenerDanos()
        {
            try
            {
                cSGGIDANOPORIMPLEMENTONegocios Danos = new cSGGIDANOPORIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                DT_Danos = new DataTable();
                DT_Danos = Danos.SeleccionarTodos();
                String aDataSet = "[";
                int cantidadColumnas = DT_Danos.Columns.Count;
                for (int IndiceDanos = 0; IndiceDanos < DT_Danos.Rows.Count; IndiceDanos++)
                {

                    aDataSet += "['" + DT_Danos.Rows[IndiceDanos][0] + "','" + DT_Danos.Rows[IndiceDanos][1].ToString() + "','" + DT_Danos.Rows[IndiceDanos][2].ToString() + "','" + DT_Danos.Rows[IndiceDanos][3] + "','" + DT_Danos.Rows[IndiceDanos][4].ToString().Split(' ')[0] + "']";
                    if (IndiceDanos + 1 != DT_Danos.Rows.Count)
                    {
                        aDataSet += ",";
                    }
                }
                aDataSet += "]";

                if (!Page.ClientScript.IsStartupScriptRegistered("TablaDanos"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "TablaDanos", "<script type=\"text/javascript\"> CrearTablaDanos(" + aDataSet + ");</script>");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertaDaños", "<script type=\"text/javascript\"> alert(" + "'" + ex.Message + "'" + ");</script>");
            }
        }

        private Boolean eliminarDano()
        {
            try
            {
                cSGGIDANOPORIMPLEMENTONegocios DanoAEliminar = new cSGGIDANOPORIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                DanoAEliminar.ID_DANO = Int32.Parse(_DatosSeleccionadosDanos.Split(',')[0]);
                return DanoAEliminar.Eliminar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Boolean modificarDano()
        {
            try
            {
                cSGGIDANOPORIMPLEMENTONegocios DanoAModificar = new cSGGIDANOPORIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                cSGGIIMPLEMENTONegocios Implemento = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                DanoAModificar.ID_DANO = Int32.Parse(_DatosSeleccionadosDanos.Split(',')[0]);
                Implemento.DSC_IMPLEMENTO = TextBoxDescricpionImplemento.Text;
                int cantidadIngresada = Int32.Parse(TextBoxCantidad0.Text);
                DataTable DT_Imp = Implemento.Buscar();
                int cantidadImplementos = Int32.Parse(DT_Imp.Rows[0][DT_Imp.Columns.Count - 2].ToString());
                if (cantidadIngresada > cantidadImplementos)
                {
                    throw new Exception("El Número dañados debe ser menor o igual a : " + cantidadImplementos.ToString() + ", Ya que esta es la cantidad de implementos registrados en el inventario");
                }
                DanoAModificar.FK_IDIMPLEMENTO = Int32.Parse(DT_Imp.Rows[0][0].ToString());
                DanoAModificar.CAN_IMPLEMENTOS = cantidadIngresada;
                DanoAModificar.DSC_DANO = TextBoxDescripcionDano.Text;
                DanoAModificar.FEC_REPORTE = DateTime.Today;
                return DanoAModificar.Actualizar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void llenarCamposDanos()
        {
            try
            {
                String datos = _DatosSeleccionadosDanos;
                String[] arregloDatos = datos.Split(',');
                TextBoxDescricpionImplemento.Text = arregloDatos[1];
                TextBoxFechaDano.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
                TextBoxCantidad0.Text = arregloDatos[arregloDatos.Length - 2];
                TextBoxDescripcionDano.Text = arregloDatos[2];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}