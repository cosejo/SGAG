<%@ Page Title="" Language="C#" MasterPageFile="~/SinAutenticar.Master" AutoEventWireup="true" CodeBehind="frmGestionInventario.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmGestionInventario" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="DataTable_Plugin/css/jquery-ui-1.8.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="DataTable_Plugin/css/jquery.dataTables_themeroller.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="DataTable_Plugin/jquery.dataTables.js" type="text/javascript"></script>
    <script src="js/gestionInventario.js" type="text/javascript"></script>
    <style type="text/css">
    #table_id
    {
        margin-top: 24px;
    }
        .style2
        {
            width: 242px;
        }
        .style5
        {
            width: 19px;
        }
        .style7
        {
            width: 60px;
        }
        .style8
        {
            width: 242px;
            height: 50px;
        }
        .style10
        {
            width: 48px;
            height: 50px;
        }
        .style12
        {
            width: 242px;
            height: 20px;
        }
        .style13
        {
            width: 19px;
            height: 20px;
        }
        .style14
        {
            width: 48px;
            height: 20px;
        }
        .style16
        {
            width: 300px;
            height: 55px;
        }
    </style>
    <style type="text/css">
        
     .MultiColumnTextBoxStyle
        {            
            border: 1px solid #99bbe8;
	        padding: 1px 1px 0px 3px;	        
	        font-size:12px;  
            font-family:"Calibri","sans-serif"; 
            background-color:#ffffe1;    
        }
     
        .MultiColumnContextMenuPanel 
        {
            height:150px;            
            overflow:scroll;            
            overflow-x: hidden;
	        border: 1px solid #868686;
	        z-index: 1000;
	        background: url(menu-bg.gif) repeat-y 0 0 #FAFAFA;
	        background-color:#FFF;	        
	        cursor: default;
	        padding: 1px 1px 0px 1px;
	        font-size:12px; 
            font-family:"Calibri","sans-serif"; 
        }
 
        a.MultiColumnContextMenuItem
        {            
	        margin: 1px 0 1px 0;
	        display: block;
	        color: #003399;
	        text-decoration: none;
	        cursor: pointer;	
	        padding: 4px 19px 4px 4px;
	        white-space: nowrap;
        }

        a.MultiColumnContextMenuItem-Selected
        {
	        font-weight: bold;
        }

        a.MultiColumnContextMenuItem:hover
        {
	        background-color: #FFE6A0;
	        color: #003399;
	        border: 1px solid #D2B47A;
	        padding: 3px 18px 3px 3px;
	        text-decoration:none;
	        
        }
        
        .style17
        {
            width: 48px;
        }
        
        .style18
        {
            width: 5px;
        }
        .style19
        {
            width: 5px;
            height: 20px;
        }
        
        .style20
        {
            width: 19px;
            height: 50px;
        }
        
    </style>
    		<script type="text/javascript" charset="utf-8">
    		    $(document).ready(function () {
    		        $('#table_id').dataTable();
    		    });
		</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
          <div style="width: 873px; margin-left: 0px" align="left"> 
              <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>

            <div id="dt_prestamos">
                <div id="container">
                    <div id="dynamic"></div>
                        <div class="spacer"></div>
                        </div>
        </div>
    <div style="width: 856px">
    </div>
        <div style="width: 687px">
            <hr style="width: 877px" />
    </div>
        <div style="width: 856px; height: 36px;">
            <div>
            </div>
    </div>
    <div style="width: 875px; height: 141px;">
        <table style="width:100%; margin-bottom: 0px;">
            <tr>
                <td class="style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="TextoError" ValidationGroup="Implemento"
                        ErrorMessage="Nombre del Implemento" ControlToValidate="TextBoxImplementoNuevo">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="TextBoxImplementoNuevo" runat="server" style="margin-left: 32px" ValidationGroup="Implemento"
                        Width="195px"></asp:TextBox>
                                     <asp:TextBoxWatermarkExtender ID="TextBoxImplementoNuevo_TextBoxWatermarkExtender" WatermarkText="Tipo de Implemento Nuevo"
                        runat="server" Enabled="True" TargetControlID="TextBoxImplementoNuevo">
                    </asp:TextBoxWatermarkExtender>
                                     </td>
                <td align="right" class="style5">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="TextoError" ValidationGroup="Implemento"
                        ErrorMessage="Nombre del Deporte" ControlToValidate="TextBoxDeporteNuevo">*</asp:RequiredFieldValidator>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                        runat="server" CssClass="TextoError" ValidationGroup="Deporte"
                        ErrorMessage="Nombre del Deporte" ControlToValidate="TextBoxDeporteNuevo">*</asp:RequiredFieldValidator>

                </td>
                <td class="style17" align="left">

                	<asp:UpdatePanel ID="UPnlComboBoxMultiColumna" runat="server">
                    <ContentTemplate>

        <asp:Panel ID="PnlComboBoxMultiColumna" runat="server" CssClass="MultiColumnContextMenuPanel" Style="display: none; visibility: hidden;">
       </asp:Panel>

                    <asp:TextBox ID="TextBoxDeporteNuevo" text="" runat="server" style="margin-left: 22px" ValidationGroup="Deporte"
                        Width="200px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="TextBoxDeporteNuevo_TextBoxWatermarkExtender" WatermarkText="Deporte Nuevo"
                        runat="server" Enabled="True" TargetControlID="TextBoxDeporteNuevo">
                    </asp:TextBoxWatermarkExtender>
                    <asp:DropDownExtender ID="TextBoxDeporteNuevo_DropDownExtender" runat="server"
                        DynamicServicePath="" Enabled="True" TargetControlID="TextBoxDeporteNuevo" DropDownControlID="PnlComboBoxMultiColumna">
                    </asp:DropDownExtender>
                </ContentTemplate> 
                </asp:UpdatePanel>
                </td>
                 <td class="style7">
                    <asp:Button ID="BotonAgregarDeporte" runat="server" Text="Agregar Deporte" 
                        style="margin-left: 25px" onclick="BotonAgregarDeporte_Click" ValidationGroup="Deporte"/>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    </td>
                <td class="style13">
                    </td>
                <td class="style14">
                    <asp:Label ID="LblSelectedItemComboBoxMultiColumna" runat="server" Text=""></asp:Label> 
                    </td>
                 <td class="style19">
                     </td>
            </tr>
            <tr>
                <td class="style8">
                    <asp:Button ID="BotonAgregarImplemento" runat="server" style="margin-left: 50px" 
                        Text="Agregar Implemento" onclick="BotonAgregarImplemento_Click" ValidationGroup="Implemento" />
                </td>
                <td class="style20" align="center">
                </td>
                <td class="style10" align="left">
                    <asp:Label ID="LabelMensaje" runat="server" Text="" CssClass="TextoError" ForeColor="Blue"> </asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        HeaderText="El siguiente campo es requerido:" ValidationGroup="Implemento"
                        CssClass="TextoError" Height="31px" Width="209px"/>
                                            <asp:ValidationSummary ID="ValidationSummary2" 
                        runat="server" HeaderText="Es requerido que seleccione el siguiente campo:" ValidationGroup="Deporte"
                        CssClass="TextoError" Height="31px" Width="207px"/>
                </td>
                <td class="style18">
               
                </td>
            </tr>
        </table>
    </div>
        <table style="width:127%; margin-bottom: 0px; height: 24px;">
                        <tr>
                <td class="style16">
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Content>
