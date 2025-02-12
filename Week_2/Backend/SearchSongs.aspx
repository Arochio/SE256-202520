<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchSongs.aspx.cs" Inherits="Week_2.Backend.SearchSongs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="latestAlbum" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td><asp:Label ID="lblFeedback" runat="server" /></td>
        </tr>
        <tr>
            <td><asp:Button ID="btnSearchSong" runat="server" Text="Search" OnClick="btnSearchSong_Click" /></td>
            <td><asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTitleBox" runat="server">Title: </asp:Label></td>
            <td colspan="3"><asp:TextBox ID="txtbxTitle" runat="server" Columns="30"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblArtistBox" runat="server">Artist: </asp:Label></td>
            <td colspan="3"><asp:TextBox ID="txtbxArtist" runat="server" Columns="30"></asp:TextBox></td>
        </tr>
        <tr>            
            <asp:DataGrid ID="dgResults" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundColumn DataField="ID" HeaderText="Record ID" />
                    <asp:BoundColumn DataField="Title" HeaderText="Title" />
                    <asp:BoundColumn DataField="Artist" HeaderText="Artist" />
                    <asp:BoundColumn DataField="Album" HeaderText="Album" />
                    <asp:BoundColumn DataField="Release" HeaderText="Release" />
                    <asp:BoundColumn DataField="PlayTime" HeaderText="Run time (s)" />
                    <asp:BoundColumn DataField="FirstWeekSales" HeaderText="FirstWeekSales" />
                    <asp:BoundColumn DataField="NumberHosts" HeaderText="# of hosts" />
                    <asp:BoundColumn DataField="EpisodeNumber" HeaderText="Episode #" />
                    <asp:BoundColumn DataField="Feedback" HeaderText="Feedback" />
                </Columns>
            </asp:DataGrid>
        </tr>
        <tr>
            <asp:Repeater ID="rptSearch" runat="server">
                <HeaderTemplate>
                    <asp:Label ID="lblHeader" runat="server" Text="Results..." />
                </HeaderTemplate>
                <ItemTemplate>
                    <br />
                    <asp:Label ID="lvlID" runat="server" Text='<%# Eval("ID") %>' />
                    <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>' />
                    <asp:Label ID="lblArtist" runat="server" Text='<%# Eval("Artist") %>' />
                    <asp:Label ID="lblAlbum" runat="server" Text='<%# Eval("Album") %>' />
                    <asp:Label ID="lblRelease" runat="server" Text='<%# Eval("Release") %>' />
                    <asp:Label ID="lblPlayTime" runat="server" Text='<%# Eval("PlayTime") %>' />
                    <asp:Label ID="lblFirstWeekSales" runat="server" Text='<%# Eval("FirstWeekSales") %>' />
                    <asp:Label ID="lblNumberHosts" runat="server" Text='<%# Eval("NumberHosts") %>' />
                    <asp:Label ID="lblEpisodeNumber" runat="server" Text='<%# Eval("EpisodeNumber") %>' />
                    <asp:Label ID="lblFeedbackRPT" runat="server" Text='<%# Eval("Feedback") %>' />
                    <asp:HyperLink ID="hypEditSongs" runat="server" Text="Edit" NavigateUrl='<%# Eval("ID", "~/Backend/AddSongs.aspx?ID={0}") %>' />
                    <asp:HyperLink ID="hypDelSongs" runat="server" Text="Delete" NavigateUrl='<%# Eval("ID", "~/Backend/SearchSongs.aspx?ID={0}") %>' />
                    <br />
                </ItemTemplate>
            </asp:Repeater>
        </tr>
        <tr>
            <td><asp:Button ID="btnControlPanel" runat="server" OnClick="btnControlPanel_Click" Text="Return to Control Panel"/></td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomContent" runat="server">
</asp:Content>
