<%@ Page Title="" Language="C#" MasterPageFile="~/SinAutenticar.Master" AutoEventWireup="true" CodeBehind="frmReportes.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmReportes" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #titulo
        {
            height: 42px;
        }
        #contenidoBotones
        {
            height: 221px;
            margin-top: 16px;
        }
        #reporte
        {
            height: 43px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contenido" style="height: 593px">
        <div id="titulo">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Label ID="LabelTitulo" runat="server" Text="Generación de Reportes" 
                Font-Size="Large"></asp:Label>
            </div>
         <div id="contenidoBotones" align="center">
             <asp:Button ID="BotonReportesIngresos" runat="server" 
                 Text="Ingresos a la Sala de Fuerza" Width="185px" 
                 onclick="BotonReportesIngresos_Click" ValidationGroup="Fecha" />
             <br />
             <br />
             <br />
             <asp:Button ID="BotonReportesInventario" runat="server" 
                 Text="Inventario Actual de Equipo" Width="185px" 
                 onclick="BotonReportesInventario_Click"  />
             <br />
             <br />
             <br />
             <asp:Button ID="BotonHistorialPrestamos" runat="server" 
                 Text="Historial de Prestamos" Width="185px" ValidationGroup="Fecha" 
                 onclick="BotonHistorialPrestamos_Click" />
             <br />
             <br />
             <br />
             <asp:Label ID="LabelFechaInicio" runat="server" Text="Fecha Inicio:" style="margin-right:15px"></asp:Label>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaInicio" runat="server" CssClass="TextoError" 
                 ErrorMessage="Fecha Inicio" ControlToValidate="TextBoxFechaInicio" ValidationGroup="Fecha">*</asp:RequiredFieldValidator>
             <asp:TextBox ID="TextBoxFechaInicio" runat="server" style="margin-right:75px"></asp:TextBox>

             <asp:Label ID="LabelFechaFinal" runat="server" Text="Fecha Final:" style="margin-right:15px"></asp:Label>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaFinal" runat="server" CssClass="TextoError"
                 ErrorMessage="Fecha Final" ControlToValidate="TextBoxFechaFinal" ValidationGroup="Fecha">*</asp:RequiredFieldValidator>
             <asp:TextBox ID="TextBoxFechaFinal" runat="server"></asp:TextBox>

             <br />
             <br />
             <asp:Label ID="LabelMensaje" runat="server" Text=""></asp:Label>
             <!-- Falta el summary validator-->
            </div>

            <div id="reporte">
                <rsweb:ReportViewer ID="ReportViewerSGAG" runat="server" Font-Names="Verdana" 
                    Font-Size="8pt" Height="309px" InteractiveDeviceInfos="(Colección)" 
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="689px">
                    <LocalReport >
                    </LocalReport>
                </rsweb:ReportViewer>
                </div>
    </div>
</asp:Content>
