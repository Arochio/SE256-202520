<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="Week_3.Backend.ControlPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="latestAlbum" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Control Panel</h1>

    <table>

        <tr>
            
            <td><asp:Button ID="btnAddSong" runat="server" OnClick="btnAddSong_Click" Text="Add Song"/></td>
            <td><asp:Button ID="btnAddPodcast" runat="server" OnClick="btnAddPodcast_Click" Text="Add Podcast"/></td>

        </tr>
        <tr>

            <td><asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout"/></td>

        </tr>

    </table>

</asp:Content>
