<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Principal.aspx.cs" Inherits="Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />
    <title></title>
</head>
<body style="margin-top:280px;">
    <form id="form1" runat="server">
        <div>
            <table border="0" style="margin:0 auto;">
                <tr>
                    <td colspan="2" style="text-align:center;" ><h2>Equipos</h2></td>
                </tr>
                <tr>
                    <td><asp:LinkButton CssClass="btn btn-danger" ID="LinkButton1" PostBackUrl="~/Barcelona.aspx" runat="server">Barcelona</asp:LinkButton></td>
                    <td><asp:LinkButton CssClass="btn btn-light" ID="LinkButton2" PostBackUrl="~/RealMadrid.aspx" runat="server">Real Madrid</asp:LinkButton></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
