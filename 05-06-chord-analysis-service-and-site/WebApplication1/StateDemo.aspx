<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StateDemo.aspx.cs" Inherits="WebApplication1.StateDemo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>State Storage Demo (Session & Cookies)</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h2>State Storage  (Session and Cookies) demo</h2>
            <p>
                This page demonstrates storing user profile and temporary state information using Session state and Cookies.
            </p>

            <hr />

            <!-- input -->
            <p>
                <asp:Label ID="lblName" runat="server" Text="Name:" AssociatedControlID="txtName" />
                <br />
                <asp:TextBox ID="txtName" runat="server" Width="250px" />
            </p>

            <p>
                <asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail" />
                <br />
                <asp:TextBox ID="txtEmail" runat="server" Width="250px" />
            </p>

            <p>
                <asp:Label ID="lblLastPage" runat="server" Text="Last Visited Page:" AssociatedControlID="txtLastPage" />
                <br />
                <asp:TextBox ID="txtLastPage" runat="server" Width="250px"
                             placeholder="e.g., Default.aspx, Member.aspx" />
            </p>

            <!-- buttons-->
            <p>
                <asp:Button ID="btnSaveSession" runat="server"
                    Text="Save to Session"
                    OnClick="btnSaveSession_Click" />

                &nbsp;

                <asp:Button ID="btnSaveCookie" runat="server"
                    Text="Save to Cookie"
                    OnClick="btnSaveCookie_Click" />

                &nbsp;

                <asp:Button ID="btnLoadState" runat="server"
                    Text="Load State"
                    OnClick="btnLoadState_Click" />
            </p>

            <hr />

            <!-- outputs -->
            <h3>Session State Result</h3>
            <asp:Label ID="lblSessionInfo" runat="server" />

            <br /><br />

            <h3>Cookie Result</h3>
            <asp:Label ID="lblCookieInfo" runat="server" />

        </div>
    </form>
</body>
</html>
