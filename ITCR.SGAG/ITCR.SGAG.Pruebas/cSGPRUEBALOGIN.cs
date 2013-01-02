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
        public void TestMethod1()
        {
            String IdUsuario = "201012345"; 
            wsSeguridad.SeguridadSoapClient wsseg = new wsSeguridad.SeguridadSoapClient();
            wsseg.ObtenerCedula(IdUsuario); //obtener número de cédula si tiene.
            wsseg.ObtenerNombreUsuario(IdUsuario); //obtener nombre completo del usuario.
        }
    }
}
