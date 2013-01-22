<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRealizarPrestamo.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmRealizarPrestamo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="css/itcr.css" rel="stylesheet" type="text/css" />
    <link href="css/realizarPrestamo.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
<%--    <script src="js/jquery.js" type="text/javascript"></script>--%>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/realizarPrestamo.js" type="text/javascript"></script>

    <script type="text/javascript">
        var cantImplementos = 0;
        $(function () {
            $("#MainContent_cldFechaDevolucionGeneral").datepicker({ dateFormat: 'dd-mm-yy', minDate: 0 });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"> 
        </asp:ScriptManager>

    <div id="content">
        <div id="dRealizarPrestamo"><asp:Label ID="lblRealizarPrestamo" class="SubTituloPagina" runat="server" Text="Realizar Prestamo"></asp:Label></div>

        <div id="encabezado">
            <div id="dIdentificacion">
                <asp:TextBox ID="txtIdentificacion" class="CampoTexto" runat="server" value="Identificación" 
                    onfocus="if(this.value=='Identificación') this.value=''" onblur="if(this.value=='') this.value='Identificación'"></asp:TextBox>
                <asp:Button ID="btnVerificar" runat="server" Text="Verificar" OnClick="btnVerificar_Click" />
            </div>
            <p id="pInfoUsuario"><b>Nombre: </b><asp:Label ID="lblNombreUsuario" class="lblNombreUsuario" runat="server" Text="---"></asp:Label>
            <b>Estado: </b><asp:Label ID="lblEstadoUsuario" runat="server" Text="---"></asp:Label></p>
            <p><b>Fecha de devolución general: </b><asp:TextBox ID="cldFechaDevolucionGeneral" CssClass="CampoTexto" runat="server" AutoPostBack="true" OnTextChanged="cldFechaDevolucionGeneral_OnChange"></asp:TextBox><br />
                <span class="warning">* Si modifica este campo se calculará automáticamente la cantidad de días del préstamo para cada implemento.</span></p>
            <p><b>Tipo de préstamo: </b>
            <asp:DropDownList ID="drpTipoPrestamo" CssClass="CampoCombo" runat="server">
                <asp:ListItem Value="0">Normal</asp:ListItem>
                <asp:ListItem Value="0">Especial</asp:ListItem>
            </asp:DropDownList><br /></p>
        </div>

        <asp:Panel ID="implementos" runat="server"> 

        </asp:Panel>

        <asp:Button ID="btnAgregarImplemento" runat="server" Text="Agregar más" onclick="btnAgregarImplemento_Click" />
        <div id="dRealizar"><asp:Button ID="btnRealizar" runat="server" Text="Realizar" onclick="btnRealizar_Click" /></div>
    </div>
    
</asp:Content>
