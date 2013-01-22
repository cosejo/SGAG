using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ITCR.SGAG.Interfaz
{

    public partial class frmAutenticacion : System.Web.UI.Page
    {
        #region Declaraciones de propiedades publicas de la clase
        //código de funcionalidad de login
        public int CodFuncionalidad = 1;

        public int TipoUsuarioSeleccionado
        {
            get
            {
                return System.Int32.Parse(this.ddlTipoUsuario.SelectedValue.ToString());
            }
            set
            {
                if ((value < 4) && (value > 0))
                    this.ddlTipoUsuario.SelectedIndex = value -1;   //selecciona el value - 1, pues los items en el ddl son base 0
                else
                {
                    Exception ex = new Exception("Valor incorrecto para el tipo de usuario. Utilice 1=Funcionario, 2=Estudiante, 3=Sistema.");
                    Session.Add("ObjetoError", ex);
                }
            }
        }

        public string SedeSeleccionada
        {
            get
            {
                return "CA";
            }
            set
            {
                //eliminado el campo de sede a solicitud de Kattia 22/3/2012
            }
        }

        public string imagen
        {
            get
            {
                return imgAplicacion.ImageUrl;
            }
            set
            {
                imgAplicacion.ImageUrl = imagen;
            }
        }

        public string PaginaRedireccionar;

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //cerrar sesion si ya existe una
                if (Session != null)
                {
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                }

                // Inicializar los valores en el combo de sede
                Titulo.Text = Global.gSubTituloPagina;
                //LlenarComboSedes(DropSede);           //eliminado a solicitud de Kattia 22/3/2012
                // Seleccionar el primer elemento en el combolist.
                ddlTipoUsuario.SelectedIndex = 0;
                // Colocar el focus inicial en el textos del nombre de usuario
                string s = "<SCRIPT language='javascript'>document.getElementById('MainContent_txtUsuario').focus() </SCRIPT>";
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "onload", s);

                //colocar datos del usuario loggeado actualmente por default
                try
                {
                    string nombreUsuarioActual = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
                    //quitar el nombre de dominioy el \
                    int tamanoNombre = nombreUsuarioActual.Length - nombreUsuarioActual.IndexOf("\\") + 1;  //tamano completo dominio\\usuario
                    tamanoNombre -= 2; //quitarle el tamaño de \\
                    nombreUsuarioActual = nombreUsuarioActual.Substring(nombreUsuarioActual.IndexOf("\\") + 1, tamanoNombre);
                    txtUsuario.Text = nombreUsuarioActual;
                }
                catch   // no es importante si da algún error al poner el usuario actual como valor default
                {  }
            }
        }

        public static void LlenarComboSedes(DropDownList sSedes)
        {
            try
            {
                DataTable oDt;
                DataSet oDs;
                wsSeguridad.SeguridadSoapClient wsseg = new wsSeguridad.SeguridadSoapClient();
                oDs = wsseg.ObtenerListaSedes();
                oDt = oDs.Tables[0];
                sSedes.DataSource = new DataView(oDt);
                sSedes.DataTextField = "NOM_SEDE";
                sSedes.DataValueField = "COD_SEDE";
                sSedes.DataBind();
                oDt.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEntrar_Click(object sender, ImageClickEventArgs e)
        {
            lblMensajeError.Text = "";
            if (txtUsuario.Text == "")
            {
                lblMensajeError.Text = "El nombre de usuario no puede ser vacío";
            }
            else
            {
                if (txtPassword.Text == "")
                {
                    lblMensajeError.Text = "La clave de acceso no puede ser vacía";
                }
                else
                {
                    try
                    {
                        string IdUsuario = txtUsuario.Text;
                        string Password = txtPassword.Text;
                        Session["COD_SEDE"] = "CA"; // DropSede.SelectedItem.Value;      //modificado a solicitud de Kattia 22/3/2012
                        int CodAplicacion = Global.gCOD_APLICACION;

                        wsSeguridad.SeguridadSoapClient wsseg = new wsSeguridad.SeguridadSoapClient();

                        if (wsseg.TieneAccesoAplicacion(CodAplicacion, IdUsuario, Session["COD_SEDE"].ToString()))
                        {
                            switch (System.Int32.Parse(ddlTipoUsuario.SelectedItem.Value))
                            {
                                case 1://Funcionario
                                    wsseg.ValidarFuncionarioBit(IdUsuario, Password, Global.gCOD_APLICACION, Session["COD_SEDE"].ToString());
                                    break;
                                case 2://Estudiante
                                    if (!wsseg.ValidarEstudianteBit(IdUsuario, Password, Global.gCOD_APLICACION, Session["COD_SEDE"].ToString()))
                                    {
                                        throw new Exception("El Pin es incorrecto.");
                                    }
                                    break;
                                case 3://Usuario Sistema
                                    wsseg.ValidarUsuarioSistema(IdUsuario, Password, CodAplicacion, Session["COD_SEDE"].ToString());
                                    break;
                            }
                            Session.Add("ID_USUARIO", IdUsuario);
                            Session.Add("NUM_CEDULA", wsseg.ObtenerCedula(IdUsuario)); //obtener número de cédula si tiene.
                            Session.Add("NOM_USUARIO", wsseg.ObtenerNombreUsuario(IdUsuario)); //obtener nombre completo del usuario.
                            Session.Add("COD_SEDE", Session["COD_SEDE"].ToString());
                            if (FormsAuthentication.GetRedirectUrl(IdUsuario, false) == "")
                            {
                                FormsAuthentication.SetAuthCookie(IdUsuario, false);
                                Response.Redirect(this.PaginaRedireccionar);
                            }
                            else
                            {
                                FormsAuthentication.RedirectFromLoginPage(IdUsuario, false);
                            }
                        }
                        else
                        {
                            txtUsuario.Text = "";
                            txtPassword.Text = "";
                        }
                    }
                    catch (COMException ex)// captura y manejo de errores
                    {
                        if (ex.ErrorCode == -2147024810)
                        {
                            lblMensajeError.ForeColor = Color.Red;
                            lblMensajeError.Font.Bold = true;
                            lblMensajeError.Text = "La contraseña de red especificada no es válida";
                            txtPassword.Text = "";
                        }
                        else if (ex.ErrorCode == -2147023570)
                        {
                            lblMensajeError.ForeColor = Color.Red;
                            lblMensajeError.Font.Bold = true;
                            lblMensajeError.Text = "Error de inicio de sesión: nombre de usuario desconocido o contraseña incorrecta";
                            txtPassword.Text = "";
                        }
                        else
                        {
                            lblMensajeError.Text = ex.Message;
                            txtPassword.Text = "";
                        }
                    }
                    catch (Exception ex) // captura y manejo de errores
                    {
                        lblMensajeError.ForeColor = Color.Red;
                        lblMensajeError.Font.Bold = true;
                        lblMensajeError.Text = ex.Message;
                        txtPassword.Text = "";
                    }
                }
            }
        }

    }
}