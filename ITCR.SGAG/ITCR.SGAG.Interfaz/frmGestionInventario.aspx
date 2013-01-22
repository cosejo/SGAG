<%@ Page Title="" Language="C#" MasterPageFile="~/SinAutenticar.Master" AutoEventWireup="true" CodeBehind="frmGestionInventario.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmGestionInventario" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="DataTable_Plugin/css/jquery-ui-1.8.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="DataTable_Plugin/css/jquery.dataTables_themeroller.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="DataTable_Plugin/jquery.dataTables.js" type="text/javascript"></script>
    <script src="js/TableTools.js" type="text/javascript"></script>
    <script src="js/ZeroClipboard.js" type="text/javascript"></script>
    <script src="js/gestionInventario.js" type="text/javascript"></script>
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
              <div align="center">
              </div>
                        <div style="width: 866px">
                            <table align="center" style="width: 99%;">
                                <tr>
                                    <td class="style26">
                                        &nbsp;
                                    </td>
                                    <td class="style27">
                                        &nbsp;
                                        <asp:Label ID="Label3" runat="server" Font-Size="Large" style="margin-bottom:10px"
                                            Text="Gestión de Inventario"></asp:Label>
                                    </td>
                                    <td class="style28">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style24" align="right">
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
                                        <asp:Button ID="BotonModificar" runat="server" style="margin-left: 0px" 
                                            Text="Modificar" />
                                    </td>
                                    <td class="style25">
                                        <asp:Button ID="BotonReportarDano" runat="server" style="margin-left: 26px" 
                                            Text="Reportar Daño" />
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="BotonEliminar" runat="server" style="margin-left: 0px" 
                                            Text="Eliminar" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="dt_inventario">
                            <div id="container">
                                <div id="dynamic">
                                </div>
                                <div class="spacer">
                                </div>
                            </div>
                        </div>
                        <div style="width: 865px; height: 20px;">
                        </div>
                        <div style="width: 687px">
                            <hr style="width: 877px" />
                        </div>
                        <div align="left" style="height: 93px; width: 873px;">
                            <table style="width: 100%; margin-right:10px;">
                                <tr align="center">
                                    <td class="style29">
                                        <div style="width: 444px">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:Panel ID="Panel1" runat="server" CssClass="MultiColumnContextMenuPanel" 
                                                        Style="display: none; visibility: hidden;">
                                                    </asp:Panel>
                                                    <asp:Label ID="Label4" runat="server" Text="Tipo Implemento:    "></asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                        ControlToValidate="TextBoxImplementoNuevo" CssClass="TextoError" 
                                                        ErrorMessage="Nombre del Implemento" ValidationGroup="TipoImplemento">*</asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                        ControlToValidate="TextBoxImplementoNuevo" CssClass="TextoError" 
                                                        ErrorMessage="Tipo del Implemento" ValidationGroup="Implemento">*</asp:RequiredFieldValidator>
                                                    <asp:TextBox ID="TextBoxImplementoNuevo" runat="server" 
                                                        style="margin-left: 0px" ValidationGroup="TipoImplemento" Width="195px"></asp:TextBox>
                                                    <asp:DropDownExtender ID="TextBoxImplementoNuevo_DropDownExtender" 
                                                        runat="server" DropDownControlID="Panel1" DynamicServicePath="" Enabled="True" 
                                                        TargetControlID="TextBoxImplementoNuevo">
                                                    </asp:DropDownExtender>
                                                    <asp:TextBoxWatermarkExtender ID="TextBoxImplementoNuevo_TextBoxWatermarkExtender" 
                                                        runat="server" Enabled="True" TargetControlID="TextBoxImplementoNuevo" 
                                                        WatermarkCssClass="TextoMarcaAgua" WatermarkText="Tipo de Implemento Nuevo">
                                                    </asp:TextBoxWatermarkExtender>
                                                    <br />
                                                    <br />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:Label ID="LblSelectedItemComboBoxMultiColumnaImp" runat="server" Text=""></asp:Label>
                                            <asp:Button ID="BotonAgregarImplemento" runat="server" 
                                                onclick="BotonAgregarTipoImplemento_Click" 
                                                style="margin-left: 122px; margin-top:5px;" Text="Agregar Tipo Implemento" 
                                                ValidationGroup="TipoImplemento" Width="195px" />
                                        </div>
                                    </td>
                                    <td>
                                        <div align="center" style="height: 87px; width: 399px; margin-top:10px;">
                                            <asp:UpdatePanel ID="UPnlComboBoxMultiColumna" runat="server">
                                                <ContentTemplate>
                                                    <asp:Panel ID="PnlComboBoxMultiColumna" runat="server" 
                                                        CssClass="MultiColumnContextMenuPanel" 
                                                        Style="display: none; visibility: hidden;">
                                                    </asp:Panel>
                                                    <asp:Label ID="Label5" runat="server" Text="Deporte:    "></asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                        ControlToValidate="TextBoxDeporteNuevo" CssClass="TextoError" 
                                                        ErrorMessage="Nombre del Deporte" ValidationGroup="Deporte">*</asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                        ControlToValidate="TextBoxDeporteNuevo" CssClass="TextoError" 
                                                        ErrorMessage="Deporte del Implemento" ValidationGroup="Implemento">*</asp:RequiredFieldValidator>
                                                    <asp:TextBox ID="TextBoxDeporteNuevo" runat="server" style="margin-left: 0px" 
                                                        text="" ValidationGroup="Deporte" Width="195px"></asp:TextBox>
                                                    <asp:TextBoxWatermarkExtender ID="TextBoxDeporteNuevo_TextBoxWatermarkExtender" 
                                                        runat="server" Enabled="True" TargetControlID="TextBoxDeporteNuevo" 
                                                        WatermarkCssClass="TextoMarcaAgua" WatermarkText="Deporte Nuevo">
                                                    </asp:TextBoxWatermarkExtender>
                                                    <asp:DropDownExtender ID="TextBoxDeporteNuevo_DropDownExtender" runat="server" 
                                                        DropDownControlID="PnlComboBoxMultiColumna" DynamicServicePath="" 
                                                        Enabled="True" TargetControlID="TextBoxDeporteNuevo">
                                                    </asp:DropDownExtender>
                                                    <br />
                                                    <br />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:Label ID="LblSelectedItemComboBoxMultiColumna" runat="server" Text=""></asp:Label>
                                            <asp:Button ID="BotonAgregarDeporte" runat="server" 
                                                onclick="BotonAgregarDeporte_Click" style="margin-left: 69px; margin-top:7px;" 
                                                Text="Agregar Deporte" ValidationGroup="Deporte" Width="195px" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div align="right" style="width: 581px; height: 293px; margin-top:30px;">
                            <br />
                            <asp:Label ID="Label1" runat="server" Text="Descripción Implemento: "></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescripcionImplemento" 
                                runat="server" ControlToValidate="TextBoxNombre" CssClass="TextoError" 
                                ErrorMessage="Descripción de Implemento" ValidationGroup="Implemento">*</asp:RequiredFieldValidator>
                            <asp:TextBox ID="TextBoxNombre" runat="server" style="margin-left: 0px" 
                                Width="195px"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="TextBoxNombre_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TextBoxNombre" 
                                WatermarkCssClass="TextoMarcaAgua" 
                                WatermarkText="Descripción max. 30 caractéres">
                            </asp:TextBoxWatermarkExtender>
                            <br />
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="Cantidad:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="TextBoxCantidad" CssClass="TextoError" 
                                ErrorMessage="Cantidad de Implementos" ValidationGroup="Implemento">*</asp:RequiredFieldValidator>
                            <asp:TextBox ID="TextBoxCantidad" runat="server" style="margin-left: 0px" 
                                Width="195px"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="TextBoxCantidad_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TextBoxCantidad" 
                                WatermarkCssClass="TextoMarcaAgua" 
                                WatermarkText="Digite un número ej: 8, 14, 5">
                            </asp:TextBoxWatermarkExtender>
                            <br />
                            <br />
                            <asp:Label ID="Label6" runat="server" Text="Descripcion del Daño:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescripcionDano" 
                                runat="server" ControlToValidate="TextBoxDescripcion" CssClass="TextoError" 
                                ErrorMessage="Descripcion del Daño" ValidationGroup="Implemento" 
                                Visible="false">*</asp:RequiredFieldValidator>
                            <asp:TextBox ID="TextBoxDescripcion" runat="server" Enabled="false" 
                                Height="37px" TextMode="MultiLine" Width="195px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="BotonCancelar" runat="server" onclick="BotonCancelar_Click" 
                                Text="Cancelar" />
                            <asp:Button ID="BotonGuardar" runat="server" onclick="BotonGuardar_Click" 
                                style="margin-left: 31px" Text="Guardar Cambios" ValidationGroup="Implemento" />
                            <br/>
                            <br/>
                            <asp:Label ID="LabelMensaje" runat="server" CssClass="TextoError" 
                                ForeColor="Blue" Text=""> </asp:Label>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                CssClass="TextoError" DisplayMode="List" 
                                HeaderText="El siguiente campo es requerido:" Height="31px" 
                                ValidationGroup="Implemento" Width="209px" />
                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" 
                                CssClass="TextoError" DisplayMode="List" 
                                HeaderText="Es requerido que seleccione el siguiente campo:" Height="31px" 
                                ValidationGroup="TipoImplemento" Width="207px" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                                CssClass="TextoError" DisplayMode="List" 
                                HeaderText="Es requerido que seleccione el siguiente campo:" Height="31px" 
                                ValidationGroup="Deporte" Width="207px" />
                        </div>
                </div>

            </asp:Content>
