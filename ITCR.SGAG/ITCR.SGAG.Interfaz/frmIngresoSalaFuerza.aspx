<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmIngresoSalaFuerza.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmIngresoSalaFuerza" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            width: 358px;
        }
        .style4
        {
            height: 25px;
            width: 358px;
        }
        .style5
        {
            width: 286px;
        }
        .style6
        {
            height: 25px;
            width: 286px;
        }
        .style7
        {
            width: 481px;
        }
        .style8
        {
            height: 25px;
            width: 481px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:87%; height: 315px;">
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td style="font-size: large" class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style3">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td style="font-size: large" class="style3" align="center">
                Ingreso a la Sala de Fuerza</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="Label2" runat="server" Text="Fecha:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBoxFecha" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="Label1" runat="server" Text="Identificación:" style="margin-right:4px"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:RequiredFieldValidator ID="RequiredFieldValidatorIdentificacion" ControlToValidate="TextBoxId" ValidationGroup="Id"
                    runat="server" ErrorMessage="Identificación" CssClass="TextoError">*</asp:RequiredFieldValidator>
&nbsp;<asp:TextBox ID="TextBoxId" runat="server"></asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                </td>
            <td class="style4">
&nbsp;<asp:Label ID="LabelNombre" runat="server" Text="Label" ForeColor="#666666" 
                    Visible="False"></asp:Label>
                <br />
            </td>
            <td class="style6">
                </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style3" align="center">
                <asp:Button ID="ButVerificar" runat="server" onclick="ButVerificar_Click" 
                    Text="Verificar" ValidationGroup="Id" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                    ID="ButRegistrar" runat="server" onclick="ButRegistrar_Click" 
                    Text="Registrar" ValidationGroup="Id" />
                &nbsp;&nbsp;&nbsp;
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
    </table>
                    <asp:ValidationSummary ID="ValidationSummary" runat="server" Height="1px" 
                    HeaderText="Los siguientes campos son requeridos:" ValidationGroup="Id" 
                    ShowMessageBox="true" ShowSummary="false"
                    CssClass="TextoError" Width="898px"/>
</asp:Content>
