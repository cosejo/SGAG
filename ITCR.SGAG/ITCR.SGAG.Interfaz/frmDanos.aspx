<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDanos.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmDanos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<%--<link href="DataTable_Plugin/css/jquery-ui-1.8.4.custom.css" rel="stylesheet" type="text/css" />--%>
    <link href="DataTable_Plugin/css/jquery.dataTables_themeroller.css" rel="stylesheet" type="text/css" />
    <%--<script src="js/jquery.js" type="text/javascript"></script>--%>
    <script src="DataTable_Plugin/jquery.dataTables.js" type="text/javascript"></script>
    <script src="js/TableTools.js" type="text/javascript"></script>
    <script src="js/ZeroClipboard.js" type="text/javascript"></script>
    <script src="js/gestionDanos.js" type="text/javascript"></script>
    <style type="text/css">
    #table_id
    {
        margin-top: 24px;
    }
        </style>
    <style type="text/css">
        
     .TextoMarcaAgua
     {
         font-size:12px; 
         font-family:"Calibri","sans-serif";
         font-style:italic;
         color:Gray;
      }   
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
        
        #dynamic
        {
            width: 863px;
        }
        .spacer
        {
            width: 864px;
            height: 23px;
        }
        
        .style24
        {
            width: 322px;
        }
        .style25
        {
            width: 181px;
        }
        .style26
        {
            width: 322px;
            height: 41px;
        }
        .style27
        {
            width: 181px;
            height: 41px;
        }
        .style28
        {
            height: 41px;
        }
        
        .style29
        {
            width: 438px;
        }
        
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <div style="width: 866px; margin-left: 0px" align="left"> 
              <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
                    <div>

                        <table align="center" style="width: 99%;">
                            <tr>
                                <td class="style26">
                                    &nbsp;
                                </td>
                                <td class="style27">
                                    &nbsp;
                                    <asp:Label ID="Label7" runat="server" Font-Size="Large" 
                                        style="margin-bottom:10px" Text="Gestión de Daños"></asp:Label>
                                </td>
                                <td class="style28">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style24">
                                    &nbsp;
                                </td>
                                <td class="style25">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style24">
                                    &nbsp;</td>
                                <td class="style25" align="center">
                                    <asp:Button ID="BotonModificarDanos" runat="server" style="margin-left: 0px" 
                                        Text="Modificar" />
                                    <asp:Button ID="BotonEliminarDanos" runat="server" style="margin-left: 20px" 
                                        Text="Eliminar" />
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                        </table>

                    </div>
                        <div id="dt_danos">
                            <div id="containerDanos">
                                <div id="dynamico">
                                </div>
                                <div class="spacer">
                                </div>
                            </div>
                        </div>
                        <div style="width: 687px">
                            <hr style="width: 877px" />
                        </div>
                            <div align="right" style="width: 602px; height: 293px; margin-top:0px;">
                                <br />
                                <asp:Label ID="Label8" runat="server" Text="Implemento: "></asp:Label>
                                <asp:TextBox ID="TextBoxDescricpionImplemento" runat="server" style="margin-left: 0px" 
                                    Width="195px" Enabled="false"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Label ID="Label11" runat="server" Text="Fecha del reporte del Daño:"></asp:Label>
                                <asp:TextBox ID="TextBoxFechaDano" runat="server" Width="195px" Enabled="false"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Label ID="Label9" runat="server" Text="Cantidades Dañadas:"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                    ControlToValidate="TextBoxCantidad0" CssClass="TextoError" 
                                    ErrorMessage="Cantidades Dañadas" ValidationGroup="Daños">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="TextBoxCantidad0" runat="server" style="margin-left: 0px" 
                                    Width="195px"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="TextBoxCantidad0_TextBoxWatermarkExtender" 
                                    runat="server" Enabled="True" TargetControlID="TextBoxCantidad0" 
                                    WatermarkCssClass="TextoMarcaAgua" 
                                    WatermarkText="Digite un número ej: 8, 14, 5">
                                </asp:TextBoxWatermarkExtender>
                                <br />
                                <br />
                                <asp:Label ID="Label10" runat="server" Text="Descripcion del Daño:"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescripcionDano1" 
                                    runat="server" ControlToValidate="TextBoxDescripcionDano" CssClass="TextoError" 
                                    ErrorMessage="Descripcion del Daño" ValidationGroup="Daños" 
                                    >*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="TextBoxDescripcionDano" runat="server" 
                                    Height="37px" TextMode="MultiLine" Width="195px"></asp:TextBox>
                                 <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" 
                                    runat="server" Enabled="True" TargetControlID="TextBoxDescripcionDano" 
                                    WatermarkCssClass="TextoMarcaAgua" 
                                    WatermarkText="Descripción General del Daño">
                                </asp:TextBoxWatermarkExtender>
                                <br />
                                <br />
                                <asp:Button ID="BotonCancelarDanos" runat="server"  
                                    Text="Cancelar" onclick="BotonCancelarDanos_Click" />
                                <asp:Button ID="BotonGuardarDanos" runat="server"  
                                    style="margin-left: 31px" Text="Guardar Cambios" ValidationGroup="Daños" 
                                    onclick="BotonGuardarDanos_Click" />
                                <br/>
                                <br/>
                                <asp:Label ID="LabelMensajeDanos" runat="server" CssClass="TextoError" 
                                    ForeColor="Blue" Text=""> </asp:Label>
                                <asp:ValidationSummary ID="ValidationSummary6" runat="server" 
                                    CssClass="TextoError" DisplayMode="List" 
                                    HeaderText="Se requiere llenar el siguiente campo:" Height="31px" 
                                    ValidationGroup="Daños" Width="207px" />
                            </div>
                </div>

</asp:Content>
