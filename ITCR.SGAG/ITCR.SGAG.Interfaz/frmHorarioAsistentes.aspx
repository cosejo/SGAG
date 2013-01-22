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
                <asp:Label ID="Label2" runat="server" Text="Nombre del Asistente"></asp:Label>
                :
                <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" 
                    style="margin-left: 0px" Width="210px">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Identificación"></asp:Label>
                :&nbsp;
                <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="140px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>

            <td 
             </td class="style3">

                <br />
                <br />
                <br />
                <br />
                <br />

        </tr>
    </table>

    <div id="calendar" align="left" style="margin-left:180px"</div>
</asp:Content>
