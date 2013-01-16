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
        .style16
        {
            width: 300px;
            height: 55px;
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
        
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
          <div style="width: 866px; margin-left: 0px" align="left"> 
              <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
                </div>

            <div style="width: 866px"> 
                <table style="width: 99%;">
                    <tr>
                        <td class="style26">
                            &nbsp;
                        </td>
                        <td class="style27">
                            &nbsp;
                        <asp:Label ID="Label3" runat="server" Font-Size="Large" 
                      Text="Gestión de Inventario"></asp:Label>
                        </td>
                        <td class="style28">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style24">
                            &nbsp;
                            <asp:Button ID="BotonModificar" runat="server" Text="Modificar" 
                                />
                        </td>
                        <td class="style25">
                            <asp:Button ID="BotonReportarDano" runat="server" Text="Reportar Daño" />
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="BotonEliminar" runat="server" Text="Eliminar"/>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style24">
                            &nbsp;
                        </td>
                        <td class="style25">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                </div>
            <div id="dt_prestamos">
                <div id="container">
                    <div id="dynamic"></div>
                        <div class="spacer"></div>
                        </div>
        </div>
    <div style="width: 865px; height: 20px;">
    </div>
        <div style="width: 687px">
            <hr style="width: 877px" />
    </div>
        
            <div style="height: 99px; width: 511px;" align="right">
                  
                                  	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

        <asp:Panel ID="Panel1" runat="server" CssClass="MultiColumnContextMenuPanel" Style="display: none; visibility: hidden;">
       </asp:Panel>

                        <asp:Label ID="Label4" runat="server" Text="Tipo Implemento:    "></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="TextoError" ValidationGroup="TipoImplemento"
                        ErrorMessage="Nombre del Implemento" ControlToValidate="TextBoxImplementoNuevo">*</asp:RequiredFieldValidator>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                      CssClass="TextoError" ValidationGroup="Implemento" ControlToValidate="TextBoxImplementoNuevo"
                        ErrorMessage="Tipo del Implemento">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="TextBoxImplementoNuevo" runat="server" style="margin-left: 0px" ValidationGroup="TipoImplemento"
                        Width="195px" ></asp:TextBox>
                                     <asp:DropDownExtender ID="TextBoxImplementoNuevo_DropDownExtender" 
                        runat="server" DynamicServicePath="" Enabled="True" DropDownControlID="Panel1"
                        TargetControlID="TextBoxImplementoNuevo">
                    </asp:DropDownExtender>
                                     <asp:TextBoxWatermarkExtender ID="TextBoxImplementoNuevo_TextBoxWatermarkExtender" WatermarkText="Tipo de Implemento Nuevo"
                        runat="server" Enabled="True" TargetControlID="TextBoxImplementoNuevo" WatermarkCssClass="TextoMarcaAgua">
                    </asp:TextBoxWatermarkExtender>
                                        <br />
                                        <br />
                                        </ContentTemplate> 
                </asp:UpdatePanel>
                <asp:Label ID="LblSelectedItemComboBoxMultiColumnaImp" runat="server" Text=""></asp:Label> 

                                    <asp:Button ID="BotonAgregarImplemento" runat="server" style="margin-left: 103px" 
                        Text="Agregar Tipo Implemento" onclick="BotonAgregarTipoImplemento_Click" 
                        ValidationGroup="TipoImplemento" Width="195px" />
                
                                    
                
            </div>
  <div style="height: 87px; width: 516px;" align="right">
                	<asp:UpdatePanel ID="UPnlComboBoxMultiColumna" runat="server">
                    <ContentTemplate>

        <asp:Panel ID="PnlComboBoxMultiColumna" runat="server" CssClass="MultiColumnContextMenuPanel" Style="display: none; visibility: hidden;">
       </asp:Panel>

                        <asp:Label ID="Label5" runat="server" Text="Deporte:    "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="TextBoxDeporteNuevo" CssClass="TextoError" 
                            ErrorMessage="Nombre del Deporte" ValidationGroup="Deporte">*</asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="TextBoxDeporteNuevo" CssClass="TextoError" 
                            ErrorMessage="Deporte del Implemento" ValidationGroup="Implemento">*</asp:RequiredFieldValidator>

                    <asp:TextBox ID="TextBoxDeporteNuevo" text="" runat="server" 
                            style="margin-left: 0px" ValidationGroup="Deporte"
                        Width="195px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="TextBoxDeporteNuevo_TextBoxWatermarkExtender" WatermarkText="Deporte Nuevo"
                        runat="server" Enabled="True" TargetControlID="TextBoxDeporteNuevo" WatermarkCssClass="TextoMarcaAgua">
                    </asp:TextBoxWatermarkExtender>
                    <asp:DropDownExtender ID="TextBoxDeporteNuevo_DropDownExtender" runat="server"
                        DynamicServicePath="" Enabled="True" TargetControlID="TextBoxDeporteNuevo" DropDownControlID="PnlComboBoxMultiColumna">
                    </asp:DropDownExtender>
                        <br />
                        <br />
                </ContentTemplate> 
                </asp:UpdatePanel>
                                 <asp:Label ID="LblSelectedItemComboBoxMultiColumna" runat="server" Text=""></asp:Label>
                    <asp:Button ID="BotonAgregarDeporte" runat="server" Text="Agregar Deporte" 
                        style="margin-left: 91px" onclick="BotonAgregarDeporte_Click" 
                         ValidationGroup="Deporte" Width="197px"/>
                                    </div>
                <div style="width: 514px; height: 127px" align="right">
                <asp:Label ID="Label1" runat="server" Text="Descripción Implemento: "></asp:Label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="TextoError" ValidationGroup="Implemento"
                        ErrorMessage="Cantidad de Implementos" ControlToValidate="TextBoxNombre">*</asp:RequiredFieldValidator>
                  <asp:TextBox ID="TextBoxNombre" runat="server" Width="195px" 
                      style="margin-left: 0px"></asp:TextBox>
                  <asp:TextBoxWatermarkExtender ID="TextBoxNombre_TextBoxWatermarkExtender" WatermarkText="Descripción max. 30 caractéres"
                      runat="server" Enabled="True" TargetControlID="TextBoxNombre" WatermarkCssClass="TextoMarcaAgua">
                  </asp:TextBoxWatermarkExtender>
                    <br />
                    <br />
                  <asp:Label ID="Label2" runat="server" Text="Cantidad:"></asp:Label> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                      CssClass="TextoError" ValidationGroup="Implemento" ControlToValidate="TextBoxCantidad"
                        ErrorMessage="Nombre de Implemento">*</asp:RequiredFieldValidator>
                           <asp:TextBox ID="TextBoxCantidad" runat="server" Width="195px" 
                      style="margin-left: 0px"></asp:TextBox>
                  <asp:TextBoxWatermarkExtender ID="TextBoxCantidad_TextBoxWatermarkExtender" WatermarkText="Digite un número ej: 8, 14, 5"
                      runat="server" Enabled="True" TargetControlID="TextBoxCantidad" WatermarkCssClass="TextoMarcaAgua">
                  </asp:TextBoxWatermarkExtender>
   
                   <br />
                  <br />
                  <asp:Label ID="LabelMensaje" runat="server" Text="" CssClass="TextoError" ForeColor="Blue"> </asp:Label>
                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        HeaderText="El siguiente campo es requerido:" ValidationGroup="Implemento"
                        CssClass="TextoError" Height="31px" Width="209px" 
                        DisplayMode="List"/>
                        <asp:ValidationSummary ID="ValidationSummary3" 
                        runat="server" 
                        HeaderText="Es requerido que seleccione el siguiente campo:" ValidationGroup="TipoImplemento"
                        CssClass="TextoError" Height="31px" Width="207px" 
                        DisplayMode="List"/>
                        <asp:ValidationSummary ID="ValidationSummary2" 
                        runat="server" 
                        HeaderText="Es requerido que seleccione el siguiente campo:" ValidationGroup="Deporte"
                        CssClass="TextoError" Height="31px" Width="207px" 
                        DisplayMode="List"/>
                  <br />
                  <br />
                   <br />
                    <br />
                    <asp:Button ID="BotonCancelar" runat="server" Text="Cancelar" 
                        onclick="BotonCancelar_Click" />

                  <asp:Button ID="BotonGuardar" runat="server" Text="Guardar Cambios" 
                      ValidationGroup="Implemento" onclick="BotonGuardar_Click" 
                      style="margin-left: 31px" />
                </div>
  <div style="width: 514px; height: 166px" align="right">
   
   
  </div>

    </asp:Content>
