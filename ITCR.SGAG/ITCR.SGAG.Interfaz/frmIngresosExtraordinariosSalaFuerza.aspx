<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmIngresosExtraordinariosSalaFuerza.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmIngresosExtraordinariosSalaFuerza" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td style="font-size: large">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="font-size: large">
                Ingreso a la Sala de Fuerza</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Fecha:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RequiredFieldValidator 
                     ID="RequiredFieldValidator1" runat="server" CssClass="TextoError"
                    ErrorMessage="Fecha" ValidationGroup="Ingreso" ControlToValidate="TextBoxFecha">*</asp:RequiredFieldValidator>
&nbsp;<asp:TextBox ID="TextBoxFecha" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="TextBoxFecha_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TextBoxFecha" >
                </asp:CalendarExtender>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Identificación:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="TextoError" ControlToValidate="TextBoxId"
                    runat="server" ErrorMessage="Identificación" ValidationGroup="Ingreso">*</asp:RequiredFieldValidator>
&nbsp;<asp:TextBox ID="TextBoxId" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
&nbsp;<asp:Label ID="LabelNombre" runat="server" Text="Label" ForeColor="#666666" 
                    Visible="False"></asp:Label>
                <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="ButVerificar" runat="server" onclick="ButVerificar_Click" 
                    Text="Verificar" ValidationGroup="Ingreso"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                    ID="ButRegistrar" runat="server" onclick="ButRegistrar_Click" 
                    Text="Registrar" ValidationGroup="Ingreso" />
                &nbsp;&nbsp;&nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary" runat="server" Height="1px" HeaderText="Los siguientes campos son requeridos:" ValidationGroup="Ingreso" CssClass="TextoError" ShowMessageBox="true" ShowSummary="false"/>
</asp:Content>
