using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlTypes;
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
        private static Boolean _Daño = false;
        private static SqlInt32 IdDeporte = 0;
        private static SqlInt32 IdTipoImplemento = 0;
        private static String _DatosSeleccionados = "";
        private static String _DatosSeleccionadosActuales = "";
        private static int _CantidadMaxImplementosDanados = 0;

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            agregarFuncionesJSBotones();
            if (IsPostBack) 
            {
                verificarComandoPostBack();
            }
            obtenerDeportes();
            obtenerTiposImplementos();
            obtenerImplementos();
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

        protected void BotonGuardar_Click(object sender, EventArgs e)
        {
            String MensajeDevuelto = "";
            try
            {
                int resultado;
                if(! int.TryParse(TextBoxCantidad.Text, out resultado))
                {
                    throw new Exception("Debe digitar un número válido en el campo Cantidad");
                }

                if (!_Modificacion)
                {
                    if (_Daño)
                    {
                        if ((ReportarDano()))
                        {
                            MensajeDevuelto = "El Daño al implemento seleccionado ha sido agregado satisfactoriamente";
                            BotonReportarDano_Click();
                            obtenerImplementos();
                        }
                        else
                        {
                            MensajeDevuelto = "El Daño no ha podido ser agregado";
                        }
                    }
                    else 
                    {
                        if (agregarImplemento())
                        {
                            MensajeDevuelto = "El Implemento ha sido agregado satisfactoriamente";
                            TextBoxCantidad.Text = "";
                            TextBoxNombre.Text = "";
                            TextBoxImplementoNuevo.Text = "";
                            TextBoxDeporteNuevo.Text = "";
                            obtenerImplementos();
                        }
                        else
                        {
                            MensajeDevuelto = "El Implemento no ha podido ser agregado, intentelo nuevamente";
                        }
                    }
                }
                else 
                {
                    if (modificarImplemento())
                    {
                        _Modificacion = false;
                        _Daño = false;
                        MensajeDevuelto = "El Implemento ha sido modificado satisfactoriamente";
                        TextBoxCantidad.Text = "";
                        TextBoxNombre.Text = "";
                        TextBoxImplementoNuevo.Text = "";
                        TextBoxDeporteNuevo.Text = "";
                        obtenerImplementos();
                    }
                    else 
                    {
                        MensajeDevuelto = "El Implemento no ha podido ser modificado";
                    }
                }
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "refrescarPagina", "<script type=\"text/javascript\"> __doPostBack('refrescar', 'refrescar');</script>");
            }
            catch (Exception ex)
            {
                MensajeDevuelto = ex.Message;
            }
            LabelMensaje.ForeColor = System.Drawing.Color.Blue;
            LabelMensaje.Text = MensajeDevuelto;
        }

        private Boolean ReportarDano()
        {
            try
            {
                cSGGIDANOPORIMPLEMENTONegocios DanoNuevo = new cSGGIDANOPORIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                DanoNuevo.FK_IDIMPLEMENTO = Int32.Parse(_DatosSeleccionados.Split(',')[0].ToString());
                DanoNuevo.DSC_DANO = TextBoxDescripcion.Text;
                DanoNuevo.CAN_IMPLEMENTOS = Int32.Parse(TextBoxCantidad.Text.ToString());
                DanoNuevo.FEC_REPORTE = new SqlDateTime(DateTime.Now);
                return DanoNuevo.Insertar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BotonModificar_Click()
        {
            try 
            {
                if (_DatosSeleccionados == "")
                    throw new Exception("Debe seleccionar una fila para ser modificada");
                _DatosSeleccionadosActuales = _DatosSeleccionados;
                _Modificacion = true;
                llenarCamposImplemento();
            }
            catch(Exception ex)
            {
                LabelMensaje.ForeColor = System.Drawing.Color.Blue;
                LabelMensaje.Text = ex.Message;
            }
        }

        protected void BotonEliminar_Click()
        {
            String MensajeDevuelto = "";
            LabelMensaje.Text = MensajeDevuelto;
            try 
            {
                if (eliminarImplemento())
                {
                    MensajeDevuelto = "El Implemento ha sido eliminado satisfactoriamente";
                }
                else 
                {
                    MensajeDevuelto = "El Implemento no ha podido ser eliminado";
                }
            }
            catch(Exception ex)
            {
                MensajeDevuelto = ex.Message;
            }
            LabelMensaje.ForeColor = LabelMensaje.ForeColor = System.Drawing.Color.Blue;
            LabelMensaje.Text = MensajeDevuelto;
        }

        private void BotonReportarDano_Click()
        {
            try
            {
                Boolean condicion = !TextBoxDescripcion.Enabled;
                TextBoxDescripcion.Enabled = condicion;
                RequiredFieldValidatorDescripcionDano.Visible = condicion;
                RequiredFieldValidatorDescripcionImplemento.Visible = !condicion;
                _Daño = condicion;
                if (!condicion)
                {
                    BotonCancelar_Click(new object(), new EventArgs());
                }
                else
                {
                    _DatosSeleccionadosActuales = _DatosSeleccionados;
                    llenarCamposImplemento();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void BotonCancelar_Click(object sender, EventArgs e)
        {
            try 
            { 
             _Modificacion = false;
             _Daño = false;
             IdDeporte = 0;
             IdTipoImplemento = 0;
             _DatosSeleccionados = "";
             _DatosSeleccionadosActuales = "";
             TextBoxImplementoNuevo.Text = "";
             TextBoxDeporteNuevo.Text = "";
             TextBoxNombre.Text = "";
             TextBoxCantidad.Text = "";
             TextBoxDescripcion.Text = "";
             TextBoxDescripcion.Enabled = false;
             RequiredFieldValidatorDescripcionDano.Visible = false;
             RequiredFieldValidatorDescripcionImplemento.Visible = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void LinkButtonInventario_Click(object sender, EventArgs e)
        {
            MultiViewInventario.ActiveViewIndex = 0;
        }

        protected void LinkButtonDanos_Click(object sender, EventArgs e)
        {
            MultiViewInventario.ActiveViewIndex = 1;
        }

        #endregion

        #region Metodos

        private void agregarFuncionesJSBotones() 
        {
            try
            {
                BotonModificar.Attributes.Add("onclick", "javascritp:ObtenerDatosModificar();");
                BotonEliminar.Attributes.Add("onclick", "javascritp:ObtenerDatosEliminar();");
                BotonReportarDano.Attributes.Add("onclick", "javascritp:ObtenerDatosDanos();");
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
                if (Request["__EVENTTARGET"] == "Modificar")
                {
                    _DatosSeleccionados = Request["__EVENTARGUMENT"];
                    if (verificarDatosSeleccionados(_DatosSeleccionados))
                        BotonModificar_Click();
                    return;
                }

                if (Request["__EVENTTARGET"] == "Eliminar")
                {
                    _DatosSeleccionados = Request["__EVENTARGUMENT"];
                    if (verificarDatosSeleccionados(_DatosSeleccionados))
                        BotonEliminar_Click();
                    return;
                }

                if (Request["__EVENTTARGET"] == "Danos")
                {
                    if (_Daño) 
                    {
                        BotonReportarDano_Click();
                        return;
                    }
                    _DatosSeleccionados = Request["__EVENTARGUMENT"];
                    if(verificarDatosSeleccionados(_DatosSeleccionados))
                        BotonReportarDano_Click();
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private Boolean modificarImplemento()
        {
            try
            {
                cSGGIIMPLEMENTONegocios ImplementoNuevo = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                ImplementoNuevo.CAN_DISPONIBLE = int.Parse(TextBoxCantidad.Text.ToString());
                ImplementoNuevo.CAN_ENINVENTARIO = ImplementoNuevo.CAN_DISPONIBLE;
                ImplementoNuevo.DSC_IMPLEMENTO = TextBoxNombre.Text;
                ImplementoNuevo.ID_IMPLEMENTO = int.Parse(_DatosSeleccionadosActuales.Split(',').First());
                if (!verificarNombreDeporte(TextBoxDeporteNuevo.Text))
                {
                    throw new Exception("El Deporte ingresado no existe en el sistema, intente de nuevo con uno válido");
                }

                ImplementoNuevo.FK_IDDEPORTE = IdDeporte;

                if (!verificarTipoImplemento(TextBoxImplementoNuevo.Text))
                {
                    throw new Exception("El Tipo de Implemento ingresado no existe en el sistema, intente de nuevo con uno válido");
                }

                ImplementoNuevo.FK_IDTIPOIMPLEMENTO = IdTipoImplemento;

                return ImplementoNuevo.Actualizar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Boolean eliminarImplemento()
        {
            try
            {
                cSGGIIMPLEMENTONegocios Implemento = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                Implemento.ID_IMPLEMENTO = int.Parse(_DatosSeleccionados.Split(',').First());
                return Implemento.Eliminar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void llenarCamposImplemento()
        {
            String datos = _DatosSeleccionadosActuales;
            String[] arregloDatos = datos.Split(',');
            TextBoxImplementoNuevo.Text = arregloDatos[1];
            TextBoxDeporteNuevo.Text = arregloDatos[arregloDatos.Length - 1];
            TextBoxCantidad.Text = arregloDatos[arregloDatos.Length - 2];
            TextBoxNombre.Text="";
            int diferencia = (arregloDatos.Length - 2);
            for (int i = 2; i < diferencia;i++ )
            {
                TextBoxNombre.Text+= arregloDatos[i];
            }
        }

        private void obtenerImplementos() 
        {
            try
            {
                cSGGIIMPLEMENTONegocios Implemento = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                DT_Implementos = new DataTable();
                DT_Implementos = Implemento.SeleccionarTodos();
                String aDataSet = "[";
                int cantidadColumnas = DT_Implementos.Columns.Count;
                for (int IndiceImplementos = 0; IndiceImplementos < DT_Implementos.Rows.Count; IndiceImplementos++)
                {

                    aDataSet += "['" + DT_Implementos.Rows[IndiceImplementos][0] + "','" + DT_Implementos.Rows[IndiceImplementos][1].ToString() + "','" + DT_Implementos.Rows[IndiceImplementos][3].ToString() + "','" + DT_Implementos.Rows[IndiceImplementos][4] + "','" + DT_Implementos.Rows[IndiceImplementos][2].ToString() + "']";
                    if (IndiceImplementos + 1 != DT_Implementos.Rows.Count)
                    {
                        aDataSet += ",";
                    }
                }
                aDataSet += "]";

                if (!Page.ClientScript.IsStartupScriptRegistered("TablaInventario"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "TablaInventario", "<script type=\"text/javascript\"> CrearTablaInventario(" + aDataSet + ");</script>");
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script type=\"text/javascript\"> RedibujarTabla();</script>");
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
                DT_Deportes = new DataTable();
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
                DT_TipoImplementos = new DataTable();
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
                throw new Exception("El Nombre digitado ya se encuentra dentro del sistema");
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
                DataTable busqueda = TipoImplementoIngresado.Buscar();
                if (busqueda.Rows.Count > 0)
                {
                    IdTipoImplemento = Int32.Parse(busqueda.Rows[0][0].ToString());
                    return true;
                }
                else
                {
                    IdTipoImplemento = -1;
                    return false;
                }
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
                throw new Exception("El Nombre digitado ya se encuentra dentro del sistema");
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
                DataTable busqueda = DeporteNuevo.Buscar();
                if (busqueda.Rows.Count > 0)
                {
                    IdDeporte = Int32.Parse(busqueda.Rows[0][0].ToString());
                    return true;
                }
                else
                {
                    IdDeporte = -1;
                    return false;
                }
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
                cSGGIIMPLEMENTONegocios ImplementoNuevo = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                ImplementoNuevo.CAN_DISPONIBLE = int.Parse(TextBoxCantidad.Text.ToString());
                ImplementoNuevo.CAN_ENINVENTARIO = ImplementoNuevo.CAN_DISPONIBLE;
                ImplementoNuevo.DSC_IMPLEMENTO = TextBoxNombre.Text;
                if (!verificarNombreDeporte(TextBoxDeporteNuevo.Text))
                {
                    throw new Exception("El Deporte ingresado no existe en el sistema, intente de nuevo con uno válido");
                }

                ImplementoNuevo.FK_IDDEPORTE = IdDeporte;

                if (!verificarTipoImplemento(TextBoxImplementoNuevo.Text))
                {
                    throw new Exception("El Tipo de Implemento ingresado no existe en el sistema, intente de nuevo con uno válido");
                }

                ImplementoNuevo.FK_IDTIPOIMPLEMENTO = IdTipoImplemento;

                return ImplementoNuevo.Insertar();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
  
        #endregion

    }
}