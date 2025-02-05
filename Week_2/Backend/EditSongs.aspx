<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditSongs.aspx.cs" Inherits="Week_2.Backend.EditSongs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="latestAlbum" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td><asp:Label ID="lblID" runat="server">ID:</asp:Label></td>
            <td><asp:TextBox ID="txtID" runat="server" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTitle" runat="server">Title:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblArtist" runat="server">Artist:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtArtist" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAlbum" runat="server">Album:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAlbum" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblReleaseDate" runat="server">Release Date:</asp:Label>
            </td>
            <td>
                <asp:Calendar ID="calReleaseDate" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPlaytimeMin" runat="server">Playtime: (Minutes)</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPlaytimeMin" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPlaytimeSec" runat="server">Playtime: (Seconds)</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPlaytimeSec" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFirstWeekSales" runat="server">First Week Sales:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFirstWeekSales" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNumberHosts" runat="server">Number of Hosts:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNumberHosts" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEpisodeNumber" runat="server">Episode Number:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEpisodeNumber" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnRecordSubmit" runat="server" OnClick="btnRecordSubmit_Click" Text="Submit" />
            </td>
            <td>
                <asp:Label ID="lblFeedback" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomContent" runat="server">
</asp:Content>
