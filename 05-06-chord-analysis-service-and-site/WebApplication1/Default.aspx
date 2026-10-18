<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Assignment6</title>
    <style>
        table {
            border-collapse: collapse;
            margin-top: 15px;
        }
        th, td {
            border: 1px solid #444;
            padding: 6px 10px;
        }
        th {
            background-color: #efefef;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <h1>Hello</h1>

        <asp:Label ID="lblLoginStatus" runat="server" Font-Bold="true" /><br /><br />

        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        &nbsp;
        <asp:Button ID="btnRegister" runat="server" Text="Register (Members)" OnClick="btnRegister_Click" />
        &nbsp;
        <asp:Button ID="btnMember" runat="server" Text="Member Area" OnClick="btnMember_Click" />
        &nbsp;
        <asp:Button ID="btnStaff" runat="server" Text="Staff Area" OnClick="btnStaff_Click" />

        <br /><br />

<h2>Application Overview</h2>
<p>
    This site allows user's to  register, log in, and access pages based on their role.
    Member information is saved in XML files, and staff can view the list of
    registered users along with some basic site statistics. Local encrypting
    componenst and captcha for  verification control are also used during registration. There are pages that show 
    examples of modifying session and cookie values.Two webservices made by the group are linked and displayed. 
</p>



        <h2>Application & Component Summary</h2>
  <table>
    <tr>
        <th>Component</th>
        <th>Provider</th>
        <th>Description</th>
        <th>Try It / Location</th>
    </tr>

    <tr>
        <td>Default Page</td>
        <td>Author &amp; Teammate</td>
        <td>Landing page with application overview, navigation, summary table, and global counters.</td>
        <td>Default.aspx</td>
    </tr>

    <tr>
        <td>Global.asax Event Handler</td>
        <td>Author</td>
        <td>Tracks total sessions and requests using Application state.</td>
        <td>Global.asax</td>
    </tr>

    <tr>
        <td>State Component (Session + Cookies)</td>
        <td>Author</td>
        <td>Demonstrates session and cookie state management.</td>
        <td><a href="StateDemo.aspx">StateDemo.aspx</a></td>
    </tr>

   <tr>
    <td>Remote Service: MusicKeyService</td>
    <td>Author</td>
    <td>     </td>
    <td><a href="http://webstrar39.fulton.asu.edu/page10/MusicKeyService.asmx"
           target="_blank">View Service</a></td>
    </tr>

        <tr>
            <td>Service Demo Page</td>
            <td>Author</td>
            <td>WebForm that calls the remote MusicKeyService using the Service Reference.</td>
            <td><a href="AnalyzeChordTryIt.aspx">Try It</a></td>
        </tr>

    <tr>
        <td>Login System</td>
        <td>Author</td>
        <td>Authenticates Staff and Members using XML credentials and Forms Authentication.</td>
        <td>Login.aspx</td>
    </tr>

    <tr>
        <td>Member Registration</td>
        <td>Author</td>
        <td>Allows users to self-subscribe. Stores credentials in Members.xml.</td>
        <td>Register.aspx</td>
    </tr>

    <tr>
        <td>Protected Member Area</td>
        <td>Author</td>
        <td>Displays user profile and state information. Accessible only to authenticated members.</td>
        <td>/Member/Member.aspx</td>
    </tr>

    <tr>
        <td>Password  DLL</td>
        <td>Teammate</td>
        <td>Local DLL implementing  ... used by PassBroker before storing credentials in XML.</td>
        <td>   </td>
    </tr>

    <tr>
        <td>Captcha User Control</td>
        <td>Teammate</td>
        <td>Image verifier used on the registration page </td>
        <td>   </td>
    </tr>

    <tr>
        <td>Protected Staff Area</td>
        <td>Teammate</td>
        <td>Administrative tools showing registered members and application statistics.</td>
        <td>/Staff/Staff.aspx</td>
    </tr>

    <tr>
        <td>XML Credential Storage</td>
        <td>Author &amp; Teammate</td>
        <td>Stores Member and Staff credentials in Members.xml and Staff.xml with hashed passwords.</td>
        <td>/App_Data/Members.xml, /App_Data/Staff.xml</td>
    </tr>
</table>


        <br /><br />

        <h2>Application Counters</h2>
        <asp:Label ID="lblGlobalInfo" runat="server" />
    </form>
</body>
</html>
