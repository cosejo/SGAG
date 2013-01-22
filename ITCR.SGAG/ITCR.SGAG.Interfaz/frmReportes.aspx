<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReportes.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmReportes" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="DataTable_Plugin/css/jquery.dataTables_themeroller.css" rel="stylesheet" type="text/css" />
    <script src="DataTable_Plugin/jquery.dataTables.js" type="text/javascript"></script>
    <script src="js/TableTools.js" type="text/javascript"></script>
    <script src="js/ZeroClipboard.js" type="text/javascript"></script>
    <script src="js/reportes.js" type="text/javascript"></script>
    <style type="text/css">
        #titulo
        {
            height: 42px;
        }
        #contenidoBotones
        {
            height: 249px;
            margin-top: 16px;
        }
        #reporte
        {
            height: 152px;
            width: 980px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contenido" style="height: 435px">
        <div id="titulo">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Label ID="LabelTitulo" runat="server" Text="Generación de Reportes" style="margin-left:570px" Font-Size="Large"></asp:Label>
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

             <asp:CalendarExtender ID="TextBoxFechaInicio_CalendarExtender" runat="server" 
                 Enabled="True" TargetControlID="TextBoxFechaInicio">
             </asp:CalendarExtender>

             <asp:Label ID="LabelFechaFinal" runat="server" Text="Fecha Final:" style="margin-right:15px"></asp:Label>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaFinal" runat="server" CssClass="TextoError"
                 ErrorMessage="Fecha Final" ControlToValidate="TextBoxFechaFinal" ValidationGroup="Fecha">*</asp:RequiredFieldValidator>
             <asp:TextBox ID="TextBoxFechaFinal" runat="server"></asp:TextBox>

             <asp:CalendarExtender ID="TextBoxFechaFinal_CalendarExtender" runat="server" 
                 Enabled="True" TargetControlID="TextBoxFechaFinal">
             </asp:CalendarExtender>

             <br />
             <asp:ValidationSummary ID="ValidationSummary" runat="server" 
                 ValidationGroup="Fecha" HeaderText="Los siguientes campos son requeridos: " 
                 ShowMessageBox="true" ShowSummary="false" Height="1px" />
             <br />
             <asp:Label ID="LabelMensaje" runat="server" Text=""></asp:Label>
             <hr style="width: 1200px" />
            </div>
            <div id="reporte" style="margin-left:225px">
                <div id="container">
                    <div id="dynamic">
                    </div>
                    <div class="spacer">
                    </div>
                </div>
             </div>
    </div>
    <br />
    <br />
    <hr style="width: 1200px" style="margin-top:35px; margin-left:75px" />
</asp:Content>
