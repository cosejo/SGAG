using ITCR.SGAG.Interfaz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.UI;

namespace ITCR.SGAG.Pruebas
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para frmAutenticacionTest y se pretende que
    ///contenga todas las pruebas unitarias frmAutenticacionTest.
    ///</summary>
    [TestClass()]
    public class frmAutenticacionTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Una prueba de btnEntrar_Click
        ///</summary>
        // TODO: Asegúrese de que el atributo UrlToTest especifica una dirección URL de una página ASP.NET (por ejemplo, 
        // http://.../Default.aspx). Esto es necesario para ejecutar la prueba unitaria en el servidor web,
        // si va a probar una página, un servicio web o un servicio WCF.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Nat\\Documents\\GitHub\\SGAG\\ITCR.SGAG\\ITCR.SGAG.Interfaz", "/")]
        [UrlToTest("http://localhost:49336/")]
        [DeploymentItem("ITCR.SGAG.Interfaz.dll")]
        public void btnEntrar_ClickTest()
        {
            frmAutenticacion_Accessor target = new frmAutenticacion_Accessor(); // TODO: Inicializar en un valor adecuado
            object sender = null; // TODO: Inicializar en un valor adecuado
            ImageClickEventArgs e = null; // TODO: Inicializar en un valor adecuado
            target.btnEntrar_Click(sender, e);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }
    }
}
