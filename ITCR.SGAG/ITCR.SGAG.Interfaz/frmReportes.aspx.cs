using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

namespace ITCR.SGAG.Interfaz
{
    public partial class frmReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region eventos

        protected void BotonReportesIngresos_Click(object sender, EventArgs e)
        {
            String MensajeDevuelto = "";
            try
            {
                if(Page.IsValid)
                {
                    //generar reporte
                    validarFechaInicio();
                    validarFechaFinal();
                   // ReportViewerSGAG.LocalReport.ReportPath = "~Reportes\rptIngresoSalaFuerza.rdlc";

                    // Set the processing mode for the ReportViewer to Local
                   /* ReportViewerSGAG.ProcessingMode = ProcessingMode.Local;
                    LocalReport rep = ReportViewerSGAG.LocalReport;
                    rep.ReportPath = "Reportes\rptIngresoSalaFuerza.rdlc";
                    DataSet ds = new DataSet();

                    // Create a report data source for the sales order data
                    ReportDataSource dsMaintenanceDS = new ReportDataSource();
                    dsMaintenanceDS.Name = "DataSetIngresosSalaFuerza";
                    dsMaintenanceDS.Value = ds.Tables["SGPRINGRESO"];
                    rep.DataSources.Clear();


                    string[] _p1 = new string[] { "pDtFechaInicio", "01/01/2012"};
                    string[] _p2 = new string[] { "pDtFechaInicio", "01/02/2013" };


                    ReportParameter p1 = new ReportParameter("pDtFechaInicio", _p1);
                    ReportParameter p2 = new ReportParameter("pDtFechaInicio", _p2);


                    this.ReportViewerSGAG.LocalReport.SetParameters(new ReportParameter[] { p1, p2});


                    rep.DataSources.Add(dsMaintenanceDS);
                    rep.Refresh();*/
                }
                LabelMensaje.ForeColor = System.Drawing.Color.Blue;
            }
            catch (Exception ex)
            {
                MensajeDevuelto = ex.Message;
                LabelMensaje.ForeColor = System.Drawing.Color.Red;
            }
            LabelMensaje.Text = MensajeDevuelto;

        }

        protected void BotonReportesInventario_Click(object sender, EventArgs e)
        {
            String MensajeDevuelto = "";
            try
            {
                LabelMensaje.ForeColor = System.Drawing.Color.Blue;
            }
            catch (Exception ex)
            {
                MensajeDevuelto = ex.Message;
                LabelMensaje.ForeColor = System.Drawing.Color.Red;
            }
            LabelMensaje.Text = MensajeDevuelto;
        }

        protected void BotonHistorialPrestamos_Click(object sender, EventArgs e)
        {
            String MensajeDevuelto = "";
            try
            {
                if (Page.IsValid)
                {
                    //generar reporte
                    validarFechaInicio();
                    validarFechaFinal();
                }
                LabelMensaje.ForeColor = System.Drawing.Color.Blue;
            }
            catch (Exception ex)
            {
                MensajeDevuelto = ex.Message;
                LabelMensaje.ForeColor = System.Drawing.Color.Red;
            }
            LabelMensaje.Text = MensajeDevuelto;
        }
        #endregion

        #region metodos

        private void validarFechaFinal()
        {
            try
            {
                //Validar rango de fecha
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void validarFechaInicio()
        {
            try
            {
                //Validar rango de fecha y que sea mayor que la de inicio
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}