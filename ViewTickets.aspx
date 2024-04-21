<%@ Page Title="Movie Tickets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTickets.aspx.cs" Inherits="CPIS_Senior_Project.ViewTickets" %>
<asp:Content ID="Head" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="debug" runat="server" Visible="false"></asp:Label>
    <asp:Panel ID="pnlTickets" runat="server">
        <asp:Label runat="server">Movie Name:</asp:Label>
        <asp:Label ID="movName" runat="server">Movie Name Goes Here</asp:Label><br />
        <asp:Label runat="server">Amount of Tickets:</asp:Label>
        <asp:Label ID="txtAmt" runat="server">Amount of Tickets Go Here</asp:Label><br />
        <asp:Label runat="server">Customer Name:</asp:Label>
        <asp:Label ID="cusName" runat="server">Customer Name Goes Here</asp:Label><br />
    </asp:Panel>
</asp:Content>
