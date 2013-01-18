<%@ Page Title="" Language="C#" MasterPageFile="~/SinAutenticar.Master" AutoEventWireup="true" CodeBehind="frmReportes.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmReportes" %>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contenido" style="height: 299px">
        <div id="titulo">
            <asp:Label ID="LabelTitulo" runat="server" Text="Generación de Reportes" 
                Font-Size="Large"></asp:Label>
            </div>
         <div id="contenidoBotones" align="center">
             <asp:Button ID="BotonReportesIngresos" runat="server" 
                 Text="Ingresos a la Sala de Fuerza" Width="185px" />
             <br />
             <br />
             <br />
             <asp:Button ID="BotonReportesInventario" runat="server" 
                 Text="Inventario Actual de Equipo" Width="185px" />
             <br />
             <br />
             <br />
             <asp:Button ID="BotonHistorialPrestamos" runat="server" 
                 Text="Historial de Prestamos" Width="185px" />
             <br />
             <br />
             <br />
             <asp:Label ID="LabelFechaInicio" runat="server" Text="Fecha Inicio:" style="margin-right:15px"></asp:Label>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaInicio" runat="server" CssClass="TextoError" 
                 ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
             <asp:TextBox ID="TextBoxFechaInicio" runat="server" style="margin-right:75px"></asp:TextBox>
             <asp:Label ID="LabelFechaFinal" runat="server" Text="Fecha Final:" style="margin-right:15px"></asp:Label>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaFinal" runat="server" CssClass="TextoError"
                 ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
             <asp:TextBox ID="TextBoxFechaFinal" runat="server"></asp:TextBox>
            </div>
    </div>
</asp:Content>
