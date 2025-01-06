<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="W1D1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top:20px;">
        <table>
            <tr>
                <td colspan="3">
                    <asp:TextBox ID="txtLCD" runat="server" Columns="20" />
                </td>
                <td>
                    <asp:TextBox ID="mem1LCD" runat="server" Columns="2" />
                </td>
                <td>
                    <asp:TextBox ID="mem2LCD" runat="server" Columns="2" />
                </td>
                
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn1" Text="1" runat="server" OnClick="number_Click" />
                </td>
                <td>
                    <asp:Button ID="btn2" Text="2" runat="server" OnClick="number_Click" />
                </td>
                <td>
                    <asp:Button ID="btn3" Text="3" runat="server" OnClick="number_Click" />
                </td>
                <td>
                    <asp:Button ID="btnEquals" Text="=" runat="server" OnClick="btnEquals_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn4" Text="4" runat="server" OnClick="number_Click" />
                </td>
                <td>
                    <asp:Button ID="btn5" Text="5" runat="server" OnClick="number_Click" />
                </td>
                <td>
                    <asp:Button ID="btn6" Text="6" runat="server" OnClick="number_Click" />
                </td>
                <td>
                    <asp:Button ID="btnPlus" Text="+" runat="server" OnClick="btnOperand_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn7" Text="7" runat="server" OnClick="number_Click" />
                </td>
                <td>
                    <asp:Button ID="btn8" Text="8" runat="server" OnClick="number_Click" />
                </td>
                <td>
                    <asp:Button ID="btn9" Text="9" runat="server" OnClick="number_Click" />
                </td>
                <td>
                    <asp:Button ID="btnSubtract" Text="-" runat="server" OnClick="btnOperand_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn0" Text="0" runat="server" OnClick="number_Click" />
                </td>
                <td>
                    <asp:Button ID="btnMultiply" Text="*" runat="server" OnClick="btnOperand_Click" />
                </td>
                <td>
                    <asp:Button ID="btnDivide" Text="/" runat="server" OnClick="btnOperand_Click" />
                </td>
                <td>
                    <asp:Button ID="btnClear" Text="CE" runat="server" OnClick="btnClearEverything_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnMemStore" Text="MS" runat="server" OnClick="memStore_Click" />
                </td>
                <td>
                    <asp:Button ID="btmMemRestore" Text="MR" runat="server" OnClick="memRestore_Click" />
                </td>
                <td>
                    <asp:Button ID="ntmMemClear" Text="MC" runat="server" OnClick="memClear_Click" />
                </td>
                <td>
                    <asp:TextBox ID="mem3LCD" runat="server" Columns="4" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
