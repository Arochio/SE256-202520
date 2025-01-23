<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Week_2.Backend.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="latestAlbum" runat="server">
    <h1>Backend</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        USERNAME: <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        <br />

        PASSWORD: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log in"/>
        <br />
        <br />

        <asp:Label ID="lblFeedback" runat="server"></asp:Label>
    </div>

</asp:Content>
