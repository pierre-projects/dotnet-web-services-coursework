<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Staff.aspx.cs"
    Inherits="WebApplication1.Staff_Staff" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Staff Area</title>
</head>

<body>
<form id="form1" runat="server">

    <h2>Staff Area</h2>

    <asp:Label ID="lblWelcome" runat="server" Font-Bold="true"></asp:Label>
    <br /><br />

    <h3>Application Statistics</h3>
    <asp:Label ID="lblStats" runat="server"></asp:Label>
    <br /><br />

    <h3>Registered Members</h3>
    <asp:GridView ID="gvMembers" runat="server" AutoGenerateColumns="true"></asp:GridView>
    <br />

    <asp:Button ID="btnReload" runat="server"
        Text="Reload Members"
        OnClick="btnReload_Click" />
    <br /><br />

    <asp:Button ID="btnLogout" runat="server"
        Text="Logout"
        OnClick="btnLogout_Click" />

</form>
</body>
</html>
