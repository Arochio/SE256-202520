<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Week_3.About" %>

<asp:Content ID="AlbumContent" ContentPlaceHolderID="latestAlbum" runat="server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="BottomContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>From music lovers for music lovers</h3>
        <p>GraveSongs, founded by Cooper Graves, strives to maintain an <br />
            unbias environment to host opinions on music, ratings from listeners, <br />
            and release information about songs and albums.</p>
    </main>
</asp:Content>
