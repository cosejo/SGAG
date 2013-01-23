<%@ Page Title="" Language="C#" MasterPageFile="~/SinAutenticar.Master" AutoEventWireup="true" CodeBehind="frmAutenticacion.aspx.cs" Inherits="ITCR.SGAG.Interfaz.frmAutenticacion" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/itcr.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function entrar() {
            // con jQuery
//            $("#MainContent_lblMensajeError").css("display:none");
//            $("#ManContent_imgProcesando").css("visibility", "visible");

            //      sin jQuery
            //document.getElementById("MainContent_lblMensajeError").style.cssText = "display:none";
           //document.getElementById("ManContent_imgProcesando").style.cssText = "visibility:visible";
	    }
     </script>
     <style type="text/css">
         div.centro
         {
             text-align:center;
         }
         table.centro
         {
             margin-left:auto;
             margin-right:auto;
         }
         .style3
         {
             height: 38px;
             width: 301px;
         }
         .style4
         {
             height: 2px;
             width: 301px;
         }
         .style5
         {
             width: 95px;
             height: 39px;
         }
         .style6
         {
             width: 152px;
             height: 39px;
         }
     </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:center" class="centro">
	    <table align="center" class="centro">
	        <tr>
		        <td style="text-align:center; vertical-align:top" class="style3">
			        <asp:Image ID="imgAplicacion" runat="server" 
                        ImageUrl="~/imagenes/candado.png" />
                </TD>
	        </TR>
	        <tr>
		        <td style="text-align:left;vertical-align:middle" class="style3">
			        <P style="text-align:center">
				        <asp:Label id="Titulo" runat="server" CssClass="TituloPagina">gNombreAplicacion</asp:Label></P>
		        </TD>
	        </TR>
	        <TR>
		        <TD align="center" bgColor="whitesmoke" class="style4">
			        <TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				        <TR>
					        <TD style="WIDTH: 252px">
							        &nbsp;</TD>
					        <TD align="center">
						        &nbsp;</TD>
				        </TR>
				        <TR>
					        <TD style="WIDTH: 252px">
						        <TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							        <TR>
								        <TD style="text-align:center" colspan="2">&nbsp;</TD>
							        </TR>
							        <TR>
								        <TD style="WIDTH: 95px;text-align:right">Usuario:&nbsp;
								        </TD>
								        <TD style="WIDTH: 152px">
									        <asp:TextBox id="txtUsuario" runat="server" Width="130px" onFocus="javascript:this.select()" autofocus=autofocus ></asp:TextBox>
									        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" 
                                                CssClass="TextoError" ErrorMessage="Identificación de usuario"
										        ControlToValidate="txtUsuario">*</asp:RequiredFieldValidator></TD>
							        </TR>
							        <TR>
								        <TD style="width: 95px; text-align:right">Clave:&nbsp;
									        <br />
								        </TD>
								        <TD style="WIDTH: 152px; margin-left: 120px;">
									        <asp:TextBox id="txtPassword" runat="server" Width="130px" TextMode="Password" onFocus="javascript:this.select()"></asp:TextBox>
									        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" 
                                                CssClass="TextoError" ErrorMessage="Contraseña del usuario"
										        ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
									        <br />
								        </TD>
							        </TR>
							        <TR>
								        <TD align="right" class="style5">Tipo de usuario:</TD>
								        <TD style="margin-left: 120px;" class="style6">
									        <asp:DropDownList ID="ddlTipoUsuario" runat="server" Height="27px" 
                                                Width="140px">
                                                <asp:ListItem Selected="True" Value="1">Funcionario</asp:ListItem>
                                                <asp:ListItem Value="2">Estudiante</asp:ListItem>
                                                <asp:ListItem Value="3">Sistema</asp:ListItem>
                                            </asp:DropDownList>
                                        </TD>
							        </TR>
							        <TR>
								        <TD style="WIDTH: 95px" align="right">&nbsp;</TD>
								        <TD style="WIDTH: 152px">
									        &nbsp;</TD>
							        </TR>
						        </TABLE>
					        </TD>
					        <TD align="center">
						        <br />
                                <asp:ImageButton ID="btnEntrar" runat="server" CausesValidation="False" 
                                    ImageUrl="~/imagenes/login_peq.png" onclick="btnEntrar_Click" 
                                    onclientclick="entrar()" />
                            </TD>
				        </TR>
			        </TABLE>
			        <asp:ValidationSummary id="ValidationSummary1" runat="server" 
				        CssClass="CSSClass" HeaderText="Los siguientes campos son requeridos:" 
				        ForeColor="Red"></asp:ValidationSummary>
			        <asp:Label id="lblMensajeError" runat="server" CssClass="TextoError" 
				        ForeColor="Red"></asp:Label>
			        <img id="ManContent_imgProcesando" alt="Procesando" style="width: 32px; height: 32px; visibility:hidden;" 
				        src="../imagenes/procesando.png" />
                </TD>
		    </TR>
        </TABLE>
    </div>
</asp:Content>