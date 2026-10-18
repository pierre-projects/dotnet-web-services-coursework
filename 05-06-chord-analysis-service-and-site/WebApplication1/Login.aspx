<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>
</head>
<body>
<form id="form1" runat="server">

    <h2>Login</h2>
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <br /><br />
    <table>
        <tr>
            <td>Username:</td>
            <td>
                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Password:</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server"
                             TextMode="Password"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:CheckBox ID="chkRemember" runat="server"
                    Text="Keep me signed in" />
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnLogin" runat="server"
                    Text="Login"
                    OnClick="btnLogin_Click" />
            </td>
        </tr>
    </table>

</form>
</body>
</html>
