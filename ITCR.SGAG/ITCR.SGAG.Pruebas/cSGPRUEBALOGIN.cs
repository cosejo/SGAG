using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ITCR.SGAG.Pruebas
{
    [TestClass]
    public class cSGPRUEBALOGIN
    {
        [TestMethod]
        public void TestConexion()
        {
            String IdUsuario = "201012345"; 
            wsSeguridad.SeguridadSoapClient wsseg = new wsSeguridad.SeguridadSoapClient();
            bool actual = wsseg.EsEstudiante(IdUsuario);
            bool expected = false; // TODO: Inicializar en un valor adecuado
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestObtenerInformacion()
        {
            string Nombre;
            wsSeguridad.SeguridadSoapClient wsseg = new wsSeguridad.SeguridadSoapClient();
            Boolean estudiante = wsseg.EsEstudianteActivo("201021236");
            /*Boolean estudiante = wsseg.EsEstudianteActivo("201022376");
            Boolean estudiante = wsseg.EsEstudianteActivo("200949216");*/
            Boolean expected = true;
            Assert.AreEqual(expected, estudiante);
            wsseg.ComprobarEstudiante(out Nombre, "201022376");
        }

        [TestMethod]
        public void TestLogin()
        {
            Negocios.ClasesNegocios.IniciarSesion inicio = new Negocios.ClasesNegocios.IniciarSesion();
            string IdUsuario = "201021236"; // TODO: Inicializar en un valor adecuado
            string Contrasena = "password"; // TODO: Inicializar en un valor adecuado
            bool expected = true; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = inicio.iniciarSesionEstudiante(IdUsuario, Contrasena);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestLoginFuncionario()
        {
            Negocios.ClasesNegocios.IniciarSesion inicio = new Negocios.ClasesNegocios.IniciarSesion();
            string IdUsuario = "ivcerdas"; // TODO: Inicializar en un valor adecuado
            string Contrasena = "password"; // TODO: Inicializar en un valor adecuado
            bool expected = true; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = inicio.iniciarSesionFuncionario(IdUsuario, Contrasena);
            Assert.AreEqual(expected, actual);
        }
    }
}
