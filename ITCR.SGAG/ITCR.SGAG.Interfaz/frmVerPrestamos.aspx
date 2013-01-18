<%@ Page Title="" Language="C#" MasterPageFile="~/SinAutenticar.Master" AutoEventWireup="true" CodeBehind="frmVerPrestamos.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmVerPrestamos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
    <link href="css/itcr.css" rel="stylesheet" type="text/css" />
    <link href="DataTable_Plugin/css/jquery-ui-1.8.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="DataTable_Plugin/css/jquery.dataTables_themeroller.css" rel="stylesheet" type="text/css" />
    <link href="DataTable_Plugin/css/TableTools.css" rel="stylesheet" type="text/css" />
    <link href="css/verPrestamos.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="DataTable_Plugin/jquery.dataTables.js" type="text/javascript"></script>
    <script src="DataTable_Plugin/ZeroClipboard.js" type="text/javascript"></script>
    <script src="DataTable_Plugin/TableTools.js" type="text/javascript"></script>
    <script src="js/verPrestamos.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="content">
        <div id="dRealizarPrestamo"><asp:Label ID="lblRealizarPrestamo" class="SubTituloPagina" runat="server" Text="Préstamos y Devoluciones"></asp:Label></div>

        <div id="dt_prestamos">
		    <div id="container">
			    <div id="dynamic"></div>
			    <div class="spacer"></div>
		    </div>
	    </div>

        <div class="dBotonesCentrados"><asp:Button ID="btnVerDetalle" runat="server" Text="Ver Detalle" /></div>

        <h3>Detalle del Préstamo</h3>
        <div id="infoPrestamo">
            <p><b>Nombre: </b><asp:Label ID="lblNombre" runat="server" Text="Mauricio Muñoz Chaves"></asp:Label></p>
            <p><b>Identificación: </b><asp:Label ID="lblIdentificacion" runat="server" Text="200949216"></asp:Label></p>
        </div>
        <div id="implementos">
            <asp:Panel ID="panelImplemento" runat="server">
                <fieldset id="fieldImplemento">
                <legend>Implemento Prestado</legend>
                    <p><b>Implemento: </b><asp:Label ID="lblImplemento" runat="server" Text="Balón de fútbol - Marca Addidas"></asp:Label></p>
                    <p><b>Fecha de Devolución: </b><asp:Label ID="lblFechaDevolucion" runat="server" Text="17/02-2013 -- -- --"></asp:Label></p>
                    <p><b>Cantidad Pendiente: </b><asp:Label ID="lblCantidadPendiente" runat="server" Text="6"></asp:Label></p>
                    <p id="pCantDevolver"><b>Cantidad a devolver: </b><asp:TextBox ID="txtCantDevolver" CssClass="CampoTextoNumerico" runat="server"></asp:TextBox></p>
                </fieldset>
            </asp:Panel>
        <div id="dRealizarDevolucion" class="dBotonesCentrados"><asp:Button ID="btnRealizarDevolucion" runat="server" Text="Realizar Devolución" /></div>

        

    </div>
    

</asp:Content>
