<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="analyzeChordTryIt.aspx.cs" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Music Key Analyzer - TryIt Page</h2>
    <p>
        Enter a set of note names (ex: <strong>C E G</strong> or <strong>A C# E</strong>).
    </p>

    <p>
        <asp:TextBox ID="txtNotes" runat="server" Width="300px" />
    </p>

    <p>
        <asp:Button ID="btnAnalyze" runat="server"
                    Text="Analyze Chord"
                    OnClick="btnAnalyze_Click" />
    </p>

    <h3>Result:</h3>
    <asp:Label ID="lblResult" runat="server" Text="" />

</asp:Content>