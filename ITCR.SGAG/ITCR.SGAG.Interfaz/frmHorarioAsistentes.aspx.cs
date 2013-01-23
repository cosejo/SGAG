using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITCR.SGAG.Negocios;
using System.Data;
using System.Data.SqlTypes;

namespace ITCR.SGAG.Interfaz
{
    public partial class frmHorarioAsistentes : System.Web.UI.Page
    {
        private static DataTable DT_Asistentes;
        private static DataTable DT_Horarios;
        private static String _DatosSeleccionados = "";

        enum Dias { Dom, Lun, Mar, Mie, Jue, Vie, Sab };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarTimePicker();
            }
            else 
            {
                verificarComandoPostBack();
            }
            agregarFuncionesJSBotones();
            cargarAsistentes();
            cargarHorario();
        }

        private void cargarHorario() 
        {
            try 
            {
                string[] Seleccion = DropDownListAsistentes.SelectedValue.Split('-');
                cSGPRUSUARIOGIMNASIONegocios Asistente = new cSGPRUSUARIOGIMNASIONegocios(Global.gCOD_APLICACION, "CA", 1, "naquiros");
                Asistente.CAR_USUARIOGIMNASIO = Seleccion[0];
                Asistente.NOM_USUARIOGIMNASIO = Seleccion[1];
                Asistente.APE_USUARIOGIMNASIO = "";
                cSGMHHORARIOPORUSUARIONegocios HorarioPorUsuario = new cSGMHHORARIOPORUSUARIONegocios(Global.gCOD_APLICACION, "CA", 1, "naquiros");
                HorarioPorUsuario.FK_CARUSUARIO = Asistente.CAR_USUARIOGIMNASIO;
                DT_Horarios = HorarioPorUsuario.SeleccionarTodosPorCarne();
                String aDataSet = "[";
                for (int Indice = 0; Indice < DT_Horarios.Rows.Count; Indice++)
                {

                    aDataSet += "['" + DT_Horarios.Rows[Indice][0] + "','" + convertirIntEnDia(int.Parse(DT_Horarios.Rows[Indice][1].ToString())) + "','" + DT_Horarios.Rows[Indice][2].ToString() + "','" + DT_Horarios.Rows[Indice][3].ToString() + "']";
                    if (Indice + 1 != DT_Horarios.Rows.Count)
                    {
                        aDataSet += ",";
                    }
                }
                aDataSet += "]";
                if (!Page.ClientScript.IsStartupScriptRegistered("Horario"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Horario", "<script type=\"text/javascript\"> CrearTablaHorario(" + aDataSet + ");</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<SCRIPT>alert(''" + ex.Message + ")</SCRIPT>");
            }
        }

        protected void Boton_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre;
                wsSeguridad.SeguridadSoapClient wsseg = new wsSeguridad.SeguridadSoapClient();
                wsseg.ComprobarEstudiante(out Nombre, TextBoxCarne.Text);
                if (Nombre == "")
                {
                    throw new Exception("Identificación no registrada");
                }
                else
                {
                    cSGPRUSUARIOGIMNASIONegocios Asistente = new cSGPRUSUARIOGIMNASIONegocios(Global.gCOD_APLICACION, "CA", 1, "naquiros");
                    Asistente.CAR_USUARIOGIMNASIO = TextBoxCarne.Text;
                    Asistente.NOM_USUARIOGIMNASIO = Nombre;
                    Asistente.APE_USUARIOGIMNASIO = "";
                }
            }
            catch (Exception ex) 
            {
                Response.Write("<SCRIPT>alert(''" + ex.Message + ")</SCRIPT>");
            }
        }

        protected void BotonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] Seleccion = DropDownListAsistentes.SelectedValue.Split('-');
                cSGMHHORARIOPORUSUARIONegocios HorarioPorUsuario = new cSGMHHORARIOPORUSUARIONegocios(Global.gCOD_APLICACION, "CA", 1, "naquiros");
                HorarioPorUsuario.FK_CARUSUARIO = Seleccion[0];
                HorarioPorUsuario.EliminarTodo_Con_FK_CARUSUARIO_FK();
                cSGPRUSUARIOGIMNASIONegocios Asistente = new cSGPRUSUARIOGIMNASIONegocios(Global.gCOD_APLICACION, "CA", 1, "naquiros");
                Asistente.CAR_USUARIOGIMNASIO = Seleccion[0];
                Asistente.NOM_USUARIOGIMNASIO = Seleccion[1];
                Asistente.APE_USUARIOGIMNASIO = "";
                Asistente.Eliminar();
            }
            catch (Exception ex)
            {
                Response.Write("<SCRIPT>alert(''" + ex.Message + ")</SCRIPT>");
            }
        }

        private void cargarAsistentes()
        {
            try
            {
                cSGPRUSUARIOGIMNASIONegocios Asistentes = new cSGPRUSUARIOGIMNASIONegocios(Global.gCOD_APLICACION, "CA", 1, "naquiros");
                DT_Asistentes = Asistentes.SeleccionarTodos();
                List<String> ListaAsistentes = new List<String>();
                for (int indice = 0; indice < DT_Asistentes.Rows.Count; indice++)
                {
                    ListaAsistentes.Add(DT_Asistentes.Rows[indice][0].ToString()+ "-" + DT_Asistentes.Rows[indice][1]);
                }
                DropDownListAsistentes.DataSource = ListaAsistentes;
                DropDownListAsistentes.DataBind();
                if(ListaAsistentes.Count>0)
                {
                    DropDownListAsistentes.SelectedIndex = 0;
                }
            }
            catch (Exception ex) 
            {
                Response.Write("<SCRIPT>alert(''" + ex.Message + ")</SCRIPT>");
            }
        }

        private String convertirIntEnDia(int NumeroDia)
        {
            try
            {
                switch (NumeroDia)
                {
                    case (int)Dias.Dom: return "Domingo";
                    case (int)Dias.Lun: return "Lúnes";
                    case (int)Dias.Mar: return "Martes";
                    case (int)Dias.Mie: return "Miércoles";
                    case (int)Dias.Jue: return "Jueves";
                    case (int)Dias.Vie: return "Viernes";
                    case (int)Dias.Sab: return "Sábado";
                    default: return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int convertirDiaEnInt(String Dia)
        {
            try
            {
                switch (Dia)
                {
                    case "Domingo": return (int)Dias.Dom;
                    case "Lúnes": return (int)Dias.Lun;
                    case "Martes": return (int)Dias.Mar;
                    case "Miércoles": return (int)Dias.Mie;
                    case "Jueves": return (int)Dias.Jue;
                    case "Viernes": return (int)Dias.Vie;
                    case "Sábado": return (int)Dias.Sab;
                    default: return -1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DropDownListAsistentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try 
            {
                cargarHorario();
            }
            catch(Exception ex)
            {
                Response.Write("<SCRIPT>alert(''" + ex.Message + ")</SCRIPT>");
            }
        }

        protected void BotonCancelar_Click(object sender, EventArgs e)
        {
            try 
            {
                DropDownListDias.SelectedIndex = -1;
                tpfechainicio.Value = "";
                tpfechafinal.Value = "";
            }
            catch(Exception ex)
            {
                Response.Write("<SCRIPT>alert(''" + ex.Message + ")</SCRIPT>");
            }
        }

        protected void BotonAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                cSGMHHORARIONegocios Horario = new cSGMHHORARIONegocios(Global.gCOD_APLICACION, "CA", 1, "naquiros");
                Horario.NUM_DIA = Int32.Parse(DropDownListDias.SelectedValue);
                Horario.HOR_INICIO = SqlDateTime.Parse(tpfechainicio.Value);
                Horario.HOR_FINAL = SqlDateTime.Parse(tpfechafinal.Value);
                cSGMHHORARIOPORUSUARIONegocios HorarioPorUsuario = new cSGMHHORARIOPORUSUARIONegocios(Global.gCOD_APLICACION, "CA", 1, "naquiros");
                DataTable DT_Horario = Horario.Buscar();
                SqlInt32 IdHorarioEncontrado;
                if (DT_Horario.Rows.Count > 0)
                {
                    IdHorarioEncontrado = Int32.Parse(DT_Horario.Rows[0][0].ToString());
                }
                else 
                {
                    Horario.Insertar();
                    IdHorarioEncontrado = Horario.ID_HORARIO;
                }
                HorarioPorUsuario.FK_IDHORARIO = IdHorarioEncontrado;
                HorarioPorUsuario.FK_CARUSUARIO = DropDownListAsistentes.SelectedValue.Split('-')[0];
                HorarioPorUsuario.Insertar();
                Response.Write("<SCRIPT>alert(''" + "El Horario ha sido Asignado satisfactoriamente" + ")</SCRIPT>");
                BotonCancelar_Click(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                Response.Write("<SCRIPT>alert(''" + ex.Message + ")</SCRIPT>");
            }
        }

        private void cargarTimePicker()
        {
            try 
            {
                if (!Page.ClientScript.IsStartupScriptRegistered("TimePicker"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "TimePicker", "<script type=\"text/javascript\"> CargarTimePicker();</script>");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void agregarFuncionesJSBotones()
        {
            try
            {
                BotonEliminarHorario.Attributes.Add("onclick", "javascritp:ObtenerDatosEliminar();");
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

                if (Request["__EVENTTARGET"] == "Eliminar")
                {
                    _DatosSeleccionados = Request["__EVENTARGUMENT"];
                    if (verificarDatosSeleccionados(_DatosSeleccionados))
                        BotonEliminarHorario_Click();
                    return;
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script type=\"text/javascript\"> alert(" + "'" + ex.Message + "'" + ");</script>");
            }
        }

        private void BotonEliminarHorario_Click()
        {
            try
            {
                cSGMHHORARIOPORUSUARIONegocios HorarioPorUsuario = new cSGMHHORARIOPORUSUARIONegocios(Global.gCOD_APLICACION, "CA", 1, "naquiros");
                HorarioPorUsuario.FK_IDHORARIO = Int32.Parse(_DatosSeleccionados.Split(',')[0].ToString()); ;
                HorarioPorUsuario.FK_CARUSUARIO = DropDownListAsistentes.SelectedValue.Split('-')[0];
                DataTable DT_HoarioPorUsuario = HorarioPorUsuario.Buscar();
                HorarioPorUsuario.ID_HORARIOPORUSUARIO = Int32.Parse(DT_HoarioPorUsuario.Rows[0][0].ToString());
                HorarioPorUsuario.Eliminar();
                Response.Write("<SCRIPT>alert(''" + "El Horario ha sido modificado satisfactoriamente" + ")</SCRIPT>");
                BotonCancelar_Click(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                Response.Write("<SCRIPT>alert(''" + ex.Message + ")</SCRIPT>");
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
    }
}