<%@ Page Title="" Language="C#" MasterPageFile="~/SinAutenticar.Master" AutoEventWireup="true" CodeBehind="frmRealizarPrestamo.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmRealizarPrestamo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="css/realizarPrestamo.css" rel="stylesheet" type="text/css" />
    <link href="css/itcr.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $("#cldFechaDevolucionGeneral").datepicker();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div id="encabezado">
            <asp:TextBox ID="txtIdentificacion" class="CampoTexto" runat="server" Text="Identificación"></asp:TextBox>
            <asp:Button ID="btnVerificar" runat="server" Text="Verificar" /><br />
            <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre: "></asp:Label>
            <asp:Label ID="lblEstadoUsuario" runat="server" Text="Estado: "></asp:Label>
            <p>Fecha de devolución general: <input type="text" id="cldFechaDevolucionGeneral" /></p>
        </div>

        <div id="implemento">
            <asp:DropDownList ID="drpImplemento" class="CampoCombo" runat="server">
                <asp:ListItem>-- Elige un implemento --</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblDisponible" runat="server" Text="Disponible: "></asp:Label>
            <asp:Label ID="lblProxDevolucion" runat="server" Text="Próxima devolución: "></asp:Label>
            <p>Cantidad solicitada: 
            <asp:DropDownList ID="drpCantSolicitada" class="CampoCombo" runat="server">
                <asp:ListItem>0</asp:ListItem>
            </asp:DropDownList></p>
            <p>Durante: <asp:TextBox ID="txtDurante" class="CampoTextoNumerico" runat="server"></asp:TextBox></p>
            <p>Tipo de préstamo: 
            <asp:DropDownList ID="drpTipoPrestamo" class="CampoCombo" runat="server">
                <asp:ListItem>Normal</asp:ListItem>
                <asp:ListItem>Especial</asp:ListItem>
            </asp:DropDownList></p>
        </div>
    </div>
</asp:Content>
