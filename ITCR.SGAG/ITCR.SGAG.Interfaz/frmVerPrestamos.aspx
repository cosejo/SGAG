<%@ Page MaintainScrollPositionOnPostback="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmVerPrestamos.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmVerPrestamos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
    <link href="css/itcr.css" rel="stylesheet" type="text/css" />
    <link href="DataTable_Plugin/css/jquery-ui-1.8.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="DataTable_Plugin/css/jquery.dataTables_themeroller.css" rel="stylesheet" type="text/css" />
    <link href="DataTable_Plugin/css/TableTools.css" rel="stylesheet" type="text/css" />
    <link href="css/verPrestamos.css" rel="stylesheet" type="text/css" />

<%--    <script src="js/jquery.js" type="text/javascript"></script>--%>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="DataTable_Plugin/jquery.dataTables.js" type="text/javascript"></script>
    <script src="DataTable_Plugin/ZeroClipboard.js" type="text/javascript"></script>
    <script src="DataTable_Plugin/TableTools.js" type="text/javascript"></script>
    <script src="js/verPrestamos.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="content" style="margin-left:250px">
        <div id="dRealizarPrestamo"><asp:Label ID="lblRealizarDevolucion" class="SubTituloPagina" runat="server" Text="Préstamos y Devoluciones"></asp:Label></div>

        <div id="dt_prestamos">
		    <div id="container">
			    <div id="dynamic"></div>
			    <div class="spacer"></div>
		    </div>
	    </div>

        <div class="dBotonesCentrados"><asp:Button ID="btnVerDetalle" runat="server" 
                Text="Ver Detalle" onclick="btnVerDetalle_Click" /></div>
        
        <asp:Panel ID="WrapperDetalle" runat="server">
        </asp:Panel>
    </div>  

</asp:Content>
