<%@ Page Title="" Language="C#" MasterPageFile="~/SinAutenticar.Master" AutoEventWireup="true" CodeBehind="frmHorarioAsistentes.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmHorarioAsistentes" %>
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

  <script type='text/javascript' src='js/jquery-1.4.4.min.js'></script>
  <script type='text/javascript' src='js/jquery-ui-1.8.11.custom.min.js'></script>
  <link href="css/jquery-ui-1.8.11.custom.css" rel="stylesheet" type="text/css" />
  <link href="css/jquery.weekcalendar.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="js/date.js"></script>
  <script type='text/javascript' src='js/jquery.weekcalendar.js'></script>
  <script src="js/HorarioAsistentes.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 605px;
        }
        #calendar
        {
            width: 973px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 142%; margin-bottom: 0px; margin-left: 0px;">
        <tr align = "center">
            <td style="font-size: large">
                &nbsp;</td>
            <td style="font-size: large" class="style2">
                <asp:ScriptManager ID="ScriptManager" runat="server">
                </asp:ScriptManager>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Horario de Asistentes</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-size: large">
                &nbsp;</td>
            <td style="font-size: large" class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
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
                <asp:Label ID="Label4" runat="server" Text="Desde"></asp:Label>
                :&nbsp;
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <br />
                <asp:CalendarExtender ID="TextBox3_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TextBox3">
                </asp:CalendarExtender>
                <asp:Label ID="Label5" runat="server" Text="Hasta"></asp:Label>
                :&nbsp;&nbsp;
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="TextBox4_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TextBox4">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>

            <td 
             </td>

                <br />
                <br />
                <br />
                <br />
                <br />

        </tr>
    </table>

    <div id="calendar"></div>
</asp:Content>
