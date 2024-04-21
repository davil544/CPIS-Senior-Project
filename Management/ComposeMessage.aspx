﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComposeMessage.aspx.cs" Inherits="CPIS_Senior_Project.Management.ComposeMessage" %>
<asp:Content ID="Head" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="debug" runat="server"></asp:Label>
    <asp:Panel ID="pnlMessage" runat="server">
        <h2>Compose Message:</h2><hr style="border-top: 1px dashed" /><br />
        <table>
            <tr>
                <td>
                     To:
                </td>
                <td>
                    <asp:TextBox ID="txtSender" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Subject:
                </td>
                <td>
                    <asp:TextBox ID="txtRecipient" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr><td><br /></td></tr>
            <tr>
                <td>
                    Message:&nbsp&nbsp&nbsp
                </td>
                <td>
                    <asp:Textbox ID="txtMessage" runat="server"></asp:Textbox>
                </td>
            </tr>
        </table>

       <br /> <br />
        
        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="BtnSend_Click" />
        
        <br /> <br />
        </asp:Panel>
</asp:Content>
