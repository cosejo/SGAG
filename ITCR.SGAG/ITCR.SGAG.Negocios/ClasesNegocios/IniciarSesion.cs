using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITCR.SGAG.Negocios.ClasesNegocios
{
    public class IniciarSesion
    {
        public Boolean iniciarSesionEstudiante(String IdUsuario, String Contrasena)
        {
            wsSeguridad.SeguridadSoapClient wsseg = new wsSeguridad.SeguridadSoapClient();
            if (wsseg.EsEstudianteActivo(IdUsuario))
            {
                if ((IdUsuario != null || !IdUsuario.Equals("")) || Contrasena != null || !Contrasena.Equals(""))
                return true;
                else
                    return false;
            }

            return false;
        }

        public Boolean iniciarSesionFuncionario(String IdUsuario, String Contrasena)
        {
            wsSeguridad.SeguridadSoapClient wsseg = new wsSeguridad.SeguridadSoapClient();
            string Nombre = "";
            wsseg.ComprobarUsuarioAD(out Nombre, IdUsuario);
            if (!Nombre.Equals(""))
                return true;

            return false;
        }
    }
}
