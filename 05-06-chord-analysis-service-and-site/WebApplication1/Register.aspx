<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Member_Register" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Register</title>
</head>

<body>
<form id="form1" runat="server">

    <h2>Member Registration</h2>

    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br /><br />

    <table>
        <tr>
            <td>Username:</td>
            <td><asp:TextBox ID="txtUser" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Password:</td>
            <td><asp:TextBox ID="txtPassword" runat="server"
                             TextMode="Password"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Confirm:</td>
            <td><asp:TextBox ID="txtConfirm" runat="server"
                             TextMode="Password"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Email (optional):</td>
            <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        </tr>

        <!-- Placeholder for CAPTCHA control -->
<tr>
    <td>Verification:</td>
    <td>
        <!-- Placeholder until the teammate.s Captcha control is integrated -->
        <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
    </td>
</tr>


        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnRegister" runat="server"
                    Text="Register"
                    OnClick="btnRegister_Click" />
                &nbsp;
                <asp:Button ID="btnGoToLogin" runat="server"
                    Text="Go to Login"
                    OnClick="btnGoToLogin_Click" />
            </td>
        </tr>
    </table>
</form>
</body>
</html>
