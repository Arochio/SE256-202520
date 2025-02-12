<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="Week_2.Backend.ControlPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="latestAlbum" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Control Panel</h1>

    <table>

        <tr>
            
            <td><asp:Button ID="btnAddSong" runat="server" OnClick="btnAddSong_Click" Text="Add Songs"/></td>
            <td><asp:Button ID="btnSearchSong" runat="server" OnClick="btnSearchSong_Click" Text="Search Songs"/></td>

        </tr>
        <tr>

            <td><asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout"/></td>

        </tr>

    </table>

</asp:Content>
