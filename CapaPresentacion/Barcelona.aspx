<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Barcelona.aspx.cs" Inherits="Barcelona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.1/jquery.validate.min.js" integrity="sha256-sPB0F50YUDK0otDnsfNHawYmA5M0pjjUf4TvRJkGFrI=" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.11/jquery.validate.unobtrusive.min.js" integrity="sha256-9GycpJnliUjJDVDqP0UEu/bsm9U+3dnQUH8+3W10vkY=" crossorigin="anonymous"></script>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <title></title>
<style type="text/css">
 .hiddencol
  {
    display: none;
  }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:Label ID="nomUsuario" runat="server" Text="Label"></asp:Label>
            <table>
                <tr>
                    <td><h2>Barcelona FC</h2></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtBusqueda" runat="server" placeholder="Buscar por DNI o Nombre" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnAgregarModal" runat="server" Text="Agregar" OnClick="btnAgregarModal_Click" />
                    </td>
                </tr>
                <tr>
                            <asp:GridView ID="gvBarcelona" runat="server" AutoGenerateColumns="false" CellPading="4"
                                AllowPaging="true" OnPageIndexChanging="gvBarcelona_PageIndexChanging" OnRowCommand="gvBarcelona_RowCommand" DataKeyNames="IdJugador" PageSize="5">
                                <Columns>
                                    <asp:BoundField DataField="IdJugador" HeaderText="Codigo" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                    <asp:BoundField DataField="DniJugador" HeaderText="DNI" />
                                    <asp:BoundField DataField="NomJugador" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="EdadJugador" HeaderText="Edad" />
                                    <asp:BoundField DataField="NomEquipo" HeaderText="Equipo" />
                                    <asp:ButtonField CommandName="editRecord" ButtonType="Button" Text="Editar" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <h2>No se hallaron registros!</h2>
                                </EmptyDataTemplate>
                            </asp:GridView>
                </tr>
            </table>
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
        </div>
        <!-- Add Record Modal Starts here-->
            <div id="addModal" class="modal" tabindex="-1" role="dialog">
                  <div class="modal-dialog" role="document">
                    <div class="modal-content">
                      <div class="modal-header">
                        <h5 class="modal-title">Modal title</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                          <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                        <asp:UpdatePanel ID="upAdd" runat="server">
                            <ContentTemplate>
                                          <div class="modal-body">
                                                <table class="table table-bordered table-hover">
                                                    <tr>
                                                        <td>DNI : 
                                                    <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Nombre : 
                                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Apellido Paterno:
                                                    <asp:TextBox ID="txtApePat" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Apellido Materno:
                                                    <asp:TextBox ID="txtApeMat" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Edad:
                                                        <asp:TextBox ID="txtEdad" runat="server"></asp:TextBox>
                                                        <asp:Label ID="Label2" runat="server" Text="Type Integer Value!" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Equipo:
                                                           <asp:DropDownList ID="ddlEquipos" runat="server" AppendDataBoundItems="true" ></asp:DropDownList> 
                                                        </td>
                                                    </tr>
                                                </table>
                                          </div>
                       <div class="modal-footer">
                            <asp:Button ID="btnAgregarInfo" runat="server" Text="Add" CssClass="btn btn-info" OnClick="btnAgregarInfo_Click" />
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                      </div>
                            </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAgregarInfo" EventName="Click" />
                    </Triggers>
                        </asp:UpdatePanel>
                    </div>
                  </div>
            </div>
            <!--Add Record Modal Ends here-->

            <!--Edit Record Modal -->

           <div id="editModal" class="modal" tabindex="-1" role="dialog">
                  <div class="modal-dialog" role="document">
                    <div class="modal-content">
                      <div class="modal-header">
                        <h5 class="modal-title">Modal title</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                          <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                        <asp:UpdatePanel ID="upEdit" runat="server">
                            <ContentTemplate>
                                          <div class="modal-body">
                                                <table class="table table-bordered table-hover">
                                                    <tr>
                                                        <td>DNI : 
                                                    <asp:TextBox ID="txtDni_U" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Nombre : 
                                                    <asp:TextBox ID="txtNombre_U" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Apellido Paterno:
                                                    <asp:TextBox ID="txtApePat_U" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Apellido Materno:
                                                    <asp:TextBox ID="txtApeMat_U" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Edad:
                                                        <asp:TextBox ID="txtEdad_U" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Equipo:
                                                           <asp:DropDownList ID="ddlEquipos_U" runat="server" AppendDataBoundItems="true" ></asp:DropDownList> 
                                                        </td>
                                                    </tr>
                                                </table>
                                          </div>
                       <div class="modal-footer">
                            <asp:Button ID="btnEditarInfo" runat="server" Text="Edit" CssClass="btn btn-info" OnClick="btnEditarInfo_Click" />
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                      </div>
                            </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnEditarInfo" EventName="Click" />
                    </Triggers>
                        </asp:UpdatePanel>
                    </div>
                  </div>
            </div>


    </form>

    <script type ="text/javascript" >                
        $(document).ready(function () {  
            $("#form1").validate({  
                rules: {  
                    //This section we need to place our custom rule   
//for the control.  
                    <%=txtDni.UniqueID %>:{  
                        required:true  
                    },   
                },  
                messages: {  
                    //This section we need to place our custom   
//validation message for each control.  
                      <%=txtDni.UniqueID %>:{  
                          required: "Dni obligatorio"  
                      },  
                },  
            });  
        });         
    </script>  


</body>
</html>
