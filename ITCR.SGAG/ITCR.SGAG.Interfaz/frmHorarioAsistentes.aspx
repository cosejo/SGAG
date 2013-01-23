<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmHorarioAsistentes.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmHorarioAsistentes" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type='text/css'>
  body {
    font-family: "Lucida Grande",Helvetica,Arial,Verdana,sans-serif;
    margin: 0;
  }

  h1 {
    margin: 0 0 1em;
    padding: 0.5em;
  }

  p.description {
    font-size: 0.8em;
    padding: 1em;
    position: absolute;
    top: 3.2em;
    margin-right: 400px;
  }

  #message {
    font-size: 0.7em;
    position: absolute;
    top: 1em;
    right: 1em;
    width: 350px;
    display: none;
    padding: 1em;
    background: #ffc;
    border: 1px solid #dda;
  }
  </style>

<%--  <script type='text/javascript' src='js/jquery-1.4.4.min.js'></script>
  <script type='text/javascript' src='js/jquery-ui-1.8.11.custom.min.js'></script>
  <link href="css/jquery-ui-1.8.11.custom.css" rel="stylesheet" type="text/css" />
--%>  <link href="css/jquery.weekcalendar.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="js/date.js"></script>
  <script type='text/javascript' src='js/jquery.weekcalendar.js'></script>
  <script src="js/HorarioAsistentes.js" type="text/javascript"></script>
    <script src="js/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
    <script src="js/jquery-ui-timepicker-addon.js" type="text/javascript"></script>

    <style type="text/css">
        .style2
        {
            width: 655px;
        }
        #calendar
        {
            width: 973px;
        }
        .style3
        {
            width: 275px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 93%; margin-bottom: 0px; margin-left: 0px;">
        <tr align = "center">
            <td style="font-size: large" class="style3">
                &nbsp;</td>
            <td style="font-size: large" class="style2">
                <asp:ScriptManager ID="ScriptManager" runat="server">
                </asp:ScriptManager>
                
                Horario de Asistentes</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-size: large" class="style3">
                &nbsp;</td>
            <td style="font-size: large" class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                :
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Carné:" style="margin-left:175px"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="TextoError" ValidationGroup="Agregar"
                    ErrorMessage="Número de Carné">*</asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBoxCarne" runat="server" Height="20px" Width="185px"></asp:TextBox>
                <asp:Button ID="BotonAgregar" runat="server" style="margin-left: 43px" ValidationGroup="Agregar"
                    Text="Agregar Asistente" onclick="Boton_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Nombre del Asistente:" style="margin-left: 115px"></asp:Label>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="TextoError"
                    ErrorMessage="Nombre del Asistente">*</asp:RequiredFieldValidator>

                <asp:DropDownList ID="DropDownListAsistentes" runat="server" Height="16px" 
                    style="margin-left: 0px" Width="210px" 
                    onselectedindexchanged="DropDownListAsistentes_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                <asp:Button ID="BotonEliminar" runat="server" style="margin-left: 155px" 
                    Text="Eliminar Asistente" onclick="BotonEliminar_Click" />
                    <asp:Button ID="BotonEliminarHorario" runat="server" 
                    Text="Eliminar Hora Asignada" style="margin-left: 56px" Width="160px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
                <br />
                <br />
                   <div id="dt_horario">
                            <div id="container">
                                <div id="dynamic">
                                </div>
                                <div class="spacer">
                                </div>
                            </div>
                        </div>
                         <br />
                         <br />
                 <div style="height: 256px">

                     <asp:Label ID="LabelAgregarHorario" runat="server" Text="Asignar Horario" 
                         style="margin-left:570px" Font-Size="Large"></asp:Label>
                         <br />
                         <br />
                         <br />
                     <asp:Label ID="Label1" runat="server" Text="Fecha Inicio:" style="margin-left:515px"></asp:Label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="TextoError" 
                         ErrorMessage="Fecha Inicio" ValidationGroup="Asignar" ControlToValidate="tpfechainicio">*</asp:RequiredFieldValidator>
                         <input type="text" name="fechaInicio" id="tpfechainicio" value="" runat="server" 
                         class="hasDatepicker" style="margin-left:4px"/>
                          <br />
                         <br />
                         <br />
                         <asp:Label ID="Label4" runat="server" Text="Fecha Final:" style="margin-left:515px"></asp:Label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="TextoError" ValidationGroup="Asignar" 
                         ErrorMessage="Fecha Inicio" ControlToValidate="tpfechafinal">*</asp:RequiredFieldValidator>
                         <input type="text" name="fechaFinal" id="tpfechafinal" value="" runat="server"
                         class="hasDatepicker" style="margin-left:4px"/>
                         <br />
                         <br />
                         <br />
                         <asp:Label ID="Label5" runat="server" Text="Día:" style="margin-left:570px"></asp:Label>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="TextoError" ValidationGroup="Asignar"
                         ErrorMessage="Día" ControlToValidate="DropDownListDias">*</asp:RequiredFieldValidator>
                     <asp:DropDownList ID="DropDownListDias" runat="server" Height="16px" Width="128px">
                         <asp:ListItem Value="0">Domingo</asp:ListItem>
                         <asp:ListItem Value="1">Lunes</asp:ListItem>
                         <asp:ListItem Value="2">Martes</asp:ListItem>
                         <asp:ListItem Value="3">Miercoles</asp:ListItem>
                         <asp:ListItem Value="4">Jueves</asp:ListItem>
                         <asp:ListItem Value="5">Viernes</asp:ListItem>
                         <asp:ListItem Value="6">Sabado</asp:ListItem>
                     </asp:DropDownList>
                                              <br />
                         <br />
                         <br />
                         <asp:Button ID="BotonCancelar" runat="server" Text="Cancelar" 
                         onclick="BotonCancelar_Click" style="margin-left: 522px" />
                         <asp:Button ID="BotonAsignar" runat="server" Text="Asignar" 
                         onclick="BotonAsignar_Click" style="margin-left: 99px" />
                </div>
                      <br />
                         <br />
</asp:Content>
