<%@ Page Title="Messages" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inbox.aspx.cs" Inherits="CPIS_Senior_Project.Management.Inbox" %>
<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        table, tr, td {
            border: 1px solid black;
        }
        .tblHeader {
            border: 1px solid grey;
            border-bottom: 1px solid black;
        }
        .tblNone {
            border-left: none;
            border-right: none;
        }
    </style>

</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="debug" runat="server" Visible="false"></asp:Label>
    <asp:Panel ID="pnlMessages" runat="server">
        <h1>My Messages:</h1><br />
        <asp:Button ID="BtnCompose" runat="server" Text="Compose New Message" OnClick="BtnCompose_Click" />
        <asp:Button ID="BtnInOut" runat="server" Text="View Sent Messages" OnClick="BtnInOutbox_Click" /> <br /><br />
        &nbsp<asp:Label ID="lblInOut" runat="server" Text="Inbox:"></asp:Label><h6></h6>
        <table cellpadding = "10px">
            <tr class="tblHeader">
                <td class="tblHeader">
                    Message Sender:&nbsp
                </td>
                <td class="tblHeader">
                    Message:
                </td>
                <td class="tblHeader">
                    Time Recieved:
                </td>
            </tr>

            <!-- Load Messages Here -->
            <asp:Literal ID="litMessages" runat="server"></asp:Literal>
           <!--
            <tr onclick="location.href='ViewMessage.aspx?ID='">
                <td>SenderNameHere</td>
                <td>MessageHere</td>
                <td>Time Sent</td>
            </tr> -->
        </table>
    </asp:Panel>
</asp:Content>
