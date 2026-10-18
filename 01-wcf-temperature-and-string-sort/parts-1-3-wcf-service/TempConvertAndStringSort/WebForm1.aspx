<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TempConvertAndStringSort.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>A123</title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
            <h3>°C to °F</h3>
            <asp:TextBox ID="txtC" runat="server" Width="60"></asp:TextBox>
            <asp:Label ID="lblC" runat="server" Text=" °C "></asp:Label>
            <asp:Button ID="btnC2F" runat="server" Text="Convert" OnClick="btnC2F_Click" />
            
            <asp:Label ID="fserver" runat="server" Text="0"></asp:Label>
            <asp:Label ID="lblF" runat="server" Text=" °F"></asp:Label>
        </div>


        <div>
              <h3>°F to °C</h3>
             <asp:TextBox ID="txtF" runat="server" Width="60"></asp:TextBox>
             <asp:Label ID="lblFInput" runat="server" Text=" °F "></asp:Label>
             <asp:Button ID="btnF2C" runat="server" Text="Convert" OnClick="btnF2C_Click" />

            <asp:Label ID="cserver" runat="server" Text="0"></asp:Label>
            <asp:Label ID="lblCU" runat="server" Text=" °C"></asp:Label>
    </div>



        <div>
            <h3>Sort Numbers</h3>
            <asp:TextBox ID="txtNums" runat="server" Width="250"
                         Placeholder="Enter numbers separated by commas"></asp:TextBox>
            <asp:Button ID="btnSort" runat="server" Text="Sort" OnClick="btnSort_Click" />
            <br /><br />
            <asp:Label ID="lblSort" runat="server" Text=" "></asp:Label>
        </div>
    </form>
</body>
</html>
