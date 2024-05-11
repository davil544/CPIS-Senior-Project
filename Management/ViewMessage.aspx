<%@ Page Title="Message Contents" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMessage.aspx.cs" Inherits="CPIS_Senior_Project.Management.ViewMessage" %>
<asp:Content ID="Head" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="debug" runat="server"></asp:Label>
    <asp:Panel ID="pnlMessage" runat="server">
        <h2>Message Details:</h2><hr style="border-top: 1px dashed" /><br />
        <table>
            <tr>
                <td>
                     From:
                </td>
                <td>
                    <asp:Label ID="lblSender" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    To:
                </td>
                <td>
                    <asp:Label ID="lblRecipient" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                     Subject:
                </td>
                <td>
                    <asp:Label ID="lblSubject" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Time:
                </td>
                <td>
                    <asp:Label ID="lblTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr><td><br /></td></tr>
            <tr>
                <td>
                    Message:&nbsp&nbsp&nbsp
                </td>
                <td>
                    <asp:Literal ID="litMessage" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>

       <br /> <br />
        
        <!-- Text in reply function is still a bit buggy when displaying -->
        <asp:Button ID="btnReply" runat="server" Text="Reply" OnClick="BtnReply_Click" />&nbsp;
        <asp:Button ID="btnReturn" runat="server" Text="Return to Inbox" OnClick="BtnReturn_Click" />
        
        <br /> <br />
    </asp:Panel>
</asp:Content>
