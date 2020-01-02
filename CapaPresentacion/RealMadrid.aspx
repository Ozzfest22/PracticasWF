<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RealMadrid.aspx.cs" Inherits="RealMadrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="nomUsuario" runat="server" Text="Label"></asp:Label>
            <table>
                <tr>
                    <td><h2>Real Madrid FC</h2></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtBusqueda" runat="server" placeholder="Buscar por DNI o Nombre" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </td>
                </tr>
                <tr>
                    <asp:GridView ID="gvRealMadrid" runat="server" AutoGenerateColumns="false" CellPading="4"
                        AllowPaging="true" PageSize="5">
                        <Columns>
                            <asp:BoundField DataField="DniJugador" HeaderText="DNI" />
                            <asp:BoundField DataField="NomJugador" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                            <asp:BoundField DataField="EdadJugador" HeaderText="Edad" />
                            <asp:BoundField DataField="NomEquipo" HeaderText="Equipo" />
                        </Columns>
                        <EmptyDataTemplate>
                            <h2>No se hallaron registros!</h2>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </tr>
            </table>
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
        </div>
    </form>
</body>
</html>
