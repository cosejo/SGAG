﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using ITCR.SGAG.Negocios;

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
                    validarFechaInicio();
                    validarFechaFinal();
                    cSGPRINGRESONegocios Ingreso = new cSGPRINGRESONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                    string[] arregloFechas = TextBoxFechaInicio.Text.Split('/');
                    string fechaInicio = arregloFechas[1] + "/" + arregloFechas[0] + "/" + arregloFechas[2];
                    arregloFechas = TextBoxFechaFinal.Text.Split('/');
                    string fechaFinal = arregloFechas[1] + "/" + arregloFechas[0] + "/" + arregloFechas[2];
                    DataTable DT_Ingresos = Ingreso.SeleccionarPorFecha(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFinal));
                    llenarTablaIngresos(TextBoxFechaInicio.Text, TextBoxFechaFinal.Text, DT_Ingresos);
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
                cSGGIIMPLEMENTONegocios Implemento = new cSGGIIMPLEMENTONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                DataTable DT_Implementos = Implemento.SeleccionarTodos();
                llenarTablaImplementos(DT_Implementos);
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
                    validarFechaInicio();
                    validarFechaFinal();
                    cSGPRPRESTAMONegocios Prestamo = new cSGPRPRESTAMONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                    string[] arregloFechas = TextBoxFechaInicio.Text.Split('/');
                    string fechaInicio = arregloFechas[1] + "/" + arregloFechas[0] + "/" + arregloFechas[2];
                    arregloFechas = TextBoxFechaFinal.Text.Split('/');
                    string fechaFinal = arregloFechas[1] + "/" + arregloFechas[0] + "/" + arregloFechas[2];
                    DataTable DT_Prestamos = Prestamo.obtenerReporte(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFinal));
                    llenarTablaPrestamos(TextBoxFechaInicio.Text, TextBoxFechaFinal.Text, DT_Prestamos);
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

        protected void BotonCantidadPrestados_Click(object sender, EventArgs e)
        {
            String MensajeDevuelto = "";
            try
            {
                if (Page.IsValid)
                {
                    validarFechaInicio();
                    validarFechaFinal();
                    cSGPRIMPLEMENTOPORPRESTAMONegocios Prestamo = new cSGPRIMPLEMENTOPORPRESTAMONegocios(Global.gCOD_APLICACION, "CA", 2, "cosejo");
                    string[] arregloFechas = TextBoxFechaInicio.Text.Split('/');
                    string fechaInicio = arregloFechas[1] + "/" + arregloFechas[0] + "/" + arregloFechas[2];
                    arregloFechas = TextBoxFechaFinal.Text.Split('/');
                    string fechaFinal = arregloFechas[1] + "/" + arregloFechas[0] + "/" + arregloFechas[2];
                    DataTable DT_Prestamos = Prestamo.obtenerReporte(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFinal));
                    llenarTablaPrestamosImp(TextBoxFechaInicio.Text, TextBoxFechaFinal.Text, DT_Prestamos);
                }
                LabelMensaje.ForeColor = System.Drawing.Color.Blue;
            }
            catch (Exception ex)
            {
                MensajeDevuelto = ex.Message;
                LabelMensaje.ForeColor = System.Drawing.Color.Red;
            }
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

        private void llenarTablaImplementos(DataTable DT_Implementos)
        {
            try
            {
                String aDataSet = "[";
                for (int IndiceImplementos = 0; IndiceImplementos < DT_Implementos.Rows.Count; IndiceImplementos++)
                {

                    aDataSet += "['" + DT_Implementos.Rows[IndiceImplementos][1].ToString() + "','" + DT_Implementos.Rows[IndiceImplementos][3].ToString() + "','" + DT_Implementos.Rows[IndiceImplementos][4] + "','" + DT_Implementos.Rows[IndiceImplementos][2].ToString() + "']";
                    if (IndiceImplementos + 1 != DT_Implementos.Rows.Count)
                    {
                        aDataSet += ",";
                    }
                }
                aDataSet += "]";

                if (!Page.ClientScript.IsStartupScriptRegistered("ReporteInventario"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ReporteInventario", "<script type=\"text/javascript\"> CrearTablaReporteInventario(" + aDataSet + ");</script>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void llenarTablaIngresos(string FechaInicio, string FechaFinal, DataTable DT_Ingresos)
        {
            try
            {
                String sfechaReporte;
                String sfechaIngreso;
                string[] arregloFechas;
                String aDataSet = "[";
                for (int IndiceImplementos = 0; IndiceImplementos < DT_Ingresos.Rows.Count; IndiceImplementos++)
                {
                    sfechaIngreso = DT_Ingresos.Rows[IndiceImplementos][1].ToString().Split(' ')[0];
                    arregloFechas = sfechaIngreso.Split('/');
                    sfechaIngreso = arregloFechas[1] + "/" + arregloFechas[0] + "/" + arregloFechas[2];
                    sfechaReporte = DT_Ingresos.Rows[IndiceImplementos][2].ToString().Split(' ')[0];
                    arregloFechas = sfechaReporte.Split('/');
                    sfechaReporte = arregloFechas[1] + "/" + arregloFechas[0] + "/" + arregloFechas[2];
                    aDataSet += "['" + DT_Ingresos.Rows[IndiceImplementos][0].ToString() + "','" + sfechaIngreso + "','" + sfechaReporte + "']";
                    if (IndiceImplementos + 1 != DT_Ingresos.Rows.Count)
                    {
                        aDataSet += ",";
                    }
                }
                aDataSet += "]";

                FechaInicio = "'" + FechaInicio + "'";
                FechaFinal = "'" +  FechaFinal + "'";
                if (!Page.ClientScript.IsStartupScriptRegistered("ReporteIngreso"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ReporteIngreso", "<script type=\"text/javascript\"> CrearTablaReporteIngresos(" + aDataSet + "," + FechaInicio +"," + FechaFinal + ");</script>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void llenarTablaPrestamosImp(string FechaInicio, string FechaFinal, DataTable DT_Prestamos)
        {
            try
            {
                String aDataSet = "[";
                for (int IndiceImplementos = 0; IndiceImplementos < DT_Prestamos.Rows.Count; IndiceImplementos++)
                {
                    aDataSet += "['" + DT_Prestamos.Rows[IndiceImplementos][1].ToString() + "','" + DT_Prestamos.Rows[IndiceImplementos][2].ToString() + "']";
                    if (IndiceImplementos + 1 != DT_Prestamos.Rows.Count)
                    {
                        aDataSet += ",";
                    }
                }
                aDataSet += "]";

                FechaInicio = "'" + FechaInicio + "'";
                FechaFinal = "'" + FechaFinal + "'";
                if (!Page.ClientScript.IsStartupScriptRegistered("ReportePrestamosImp"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ReportePrestamosImp", "<script type=\"text/javascript\"> CrearTablaReportePrestamosImp(" + aDataSet + "," + FechaInicio + "," + FechaFinal + ");</script>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void llenarTablaPrestamos(string FechaInicio, string FechaFinal, DataTable DT_Prestamos)
        {
            try
            {
                String sfechaPrestamo;
                string[] arregloFechas;
                String aDataSet = "[";
                for (int IndiceImplementos = 0; IndiceImplementos < DT_Prestamos.Rows.Count; IndiceImplementos++)
                {
                    sfechaPrestamo = DT_Prestamos.Rows[IndiceImplementos][2].ToString().Split(' ')[0];
                    arregloFechas = sfechaPrestamo.Split('/');
                    sfechaPrestamo = arregloFechas[1] + "/" + arregloFechas[0] + "/" + arregloFechas[2];
                    aDataSet += "['" + DT_Prestamos.Rows[IndiceImplementos][1].ToString() + "','" + sfechaPrestamo + "','" + DT_Prestamos.Rows[IndiceImplementos][3].ToString() + "','" + DT_Prestamos.Rows[IndiceImplementos][4].ToString() + "']";
                    if (IndiceImplementos + 1 != DT_Prestamos.Rows.Count)
                    {
                        aDataSet += ",";
                    }
                }
                aDataSet += "]";

                FechaInicio = "'" + FechaInicio + "'";
                FechaFinal = "'" + FechaFinal + "'";
                if (!Page.ClientScript.IsStartupScriptRegistered("ReportePrestamos"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ReportePrestamos", "<script type=\"text/javascript\"> CrearTablaReportePrestamos(" + aDataSet + "," + FechaInicio + "," + FechaFinal + ");</script>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        #endregion

    }
}