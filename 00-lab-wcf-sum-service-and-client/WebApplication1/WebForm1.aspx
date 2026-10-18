<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <asp:TextBox ID="tb_a" runat="server" Width="60"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text=" + "></asp:Label>
            <asp:TextBox ID="tb_b" runat="server" Width="60"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text=" = "></asp:Label>
            <asp:Button ID="btnSubmit" runat="server" Text="submit" OnClick="btnSubmit_Click" />

            <asp:Label ID="lblResult" runat="server" Text="0"></asp:Label>
        </div>
    </form>
</body>
</html>
