using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITCR.SGAG.Negocios.ClasesNegocios;

namespace ITCR.SGAG.Pruebas
{
    [TestClass]
    public class cSGPRUEBALOGIN
    {/*
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
      /*      Boolean expected = true;
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
        */
        [TestMethod]
        public void TestModificarImplemento()
        {
            try
            {
                Negocios.cSGGIIMPLEMENTONegocios ImplementoNuevo = new Negocios.cSGGIIMPLEMENTONegocios(0, "CA", 2, "cosejo");
                ImplementoNuevo.CAN_DISPONIBLE = 7;
                ImplementoNuevo.CAN_ENINVENTARIO = ImplementoNuevo.CAN_DISPONIBLE;
                ImplementoNuevo.DSC_IMPLEMENTO = "Falta";
                ImplementoNuevo.ID_IMPLEMENTO = 1;
                ImplementoNuevo.FK_IDDEPORTE = 1;
                ImplementoNuevo.FK_IDTIPOIMPLEMENTO = 2;
                Boolean result = ImplementoNuevo.Actualizar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void TestEliminarImplemento()
        {
            try
            {
                Negocios.cSGGIIMPLEMENTONegocios Implemento = new Negocios.cSGGIIMPLEMENTONegocios(0, "CA", 2, "cosejo");
                Implemento.ID_IMPLEMENTO = 2;
                Boolean result = Implemento.Eliminar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void TestAgregarImplemento()
        {
            try
            {
                Negocios.cSGGIIMPLEMENTONegocios ImplementoNuevo = new Negocios.cSGGIIMPLEMENTONegocios(0, "CA", 2, "cosejo");
                ImplementoNuevo.CAN_DISPONIBLE = 12;
                ImplementoNuevo.CAN_ENINVENTARIO = ImplementoNuevo.CAN_DISPONIBLE;
                ImplementoNuevo.DSC_IMPLEMENTO = "Nuevo";
                ImplementoNuevo.FK_IDDEPORTE = 2;
                ImplementoNuevo.FK_IDTIPOIMPLEMENTO = 1;
                Boolean result = ImplementoNuevo.Insertar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void TestIngreso()
        {
            try
            {
                Negocios.cSGPRINGRESONegocios Negocios = new Negocios.cSGPRINGRESONegocios(0, "CA", 1, "naquiros");
                string[] stringFecha = {"01","15","2013"};
                DateTime fecha = new DateTime(Int32.Parse(stringFecha[2]), Int32.Parse(stringFecha[0]), Int32.Parse(stringFecha[1]));
                Negocios.FEC_INGRESO = fecha;
                Negocios.FEC_SISTEMA = DateTime.Now.Date;
                Negocios.CAR_USUARIOGIMNASIO = "201021236";
                //Response.Write("<SCRIPT>alert('Se ha registrado correctamente dentro del sistema.')</SCRIPT>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }

    }
}
