<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Week_2.Contact" %>

<asp:Content ID="AlbumContent" ContentPlaceHolderID="latestAlbum" runat="server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="BottomContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <address>
            1 New England Tech Boulevard<br />
            East Greenwich, RI 02818<br />
            <abbr title="Phone">P:</abbr>
            000.123.4567
        </address>

        <address>
            <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
            <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
        </address>
    </main>
</asp:Content>
