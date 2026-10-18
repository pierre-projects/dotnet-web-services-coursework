<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs"Inherits="WebApplication1.Member_Member" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Member Area</title>
</head>

<body>
<form id="form1" runat="server">

    <h2>Member Area</h2>

    <asp:Label ID="lblWelcome" runat="server" Font-Bold="true"></asp:Label>
    <br /><br />

    <asp:Label ID="lblProfile" runat="server"></asp:Label>
    <br /><br />

    <asp:Button ID="btnLoadProfile" runat="server"
        Text="Load My Profile"
        OnClick="btnLoadProfile_Click" />
    <br /><br />

    <h3>Session & Cookie State</h3>

    <asp:Button ID="btnShowState" runat="server"
        Text="Show My State Info"
        OnClick="btnShowState_Click" />
    <br /><br />

    <asp:Label ID="lblSessionInfo" runat="server"></asp:Label><br />
    <asp:Label ID="lblCookieInfo" runat="server"></asp:Label>
    <br /><br />

    <asp:Button ID="btnLogout" runat="server"
        Text="Logout"
        OnClick="btnLogout_Click" />

</form>
</body>
</html>
