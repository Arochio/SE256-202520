<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="Week_2.Backend.ControlPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNews" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Control Panel</h1>

    <table>

        <tr>

            <td><a href="manager.aspx" runat="server">Example</a></td>

        </tr>
        <tr>

            <td><asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout"/></td>

        </tr>

    </table>

</asp:Content>
