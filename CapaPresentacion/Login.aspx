<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" class="form-control">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label" for="txtEmail" >Email</asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

            <asp:Label ID="Label2" runat="server" Text="Label" for="txtContra" >Contraseña</asp:Label>
            <asp:TextBox ID="txtContra" runat="server" TextMode="Password"></asp:TextBox>

            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
            <asp:Label ID="lblAlerta" runat="server" Text="" class="hide"></asp:Label>
        </div>
    </form>
</body>
</html>
