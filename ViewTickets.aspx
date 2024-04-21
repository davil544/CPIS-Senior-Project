<%@ Page Title="Movie Tickets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTickets.aspx.cs" Inherits="CPIS_Senior_Project.ViewTickets" %>
<asp:Content ID="Head" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="debug" runat="server" Visible="false"></asp:Label>
    <asp:Panel ID="pnlTickets" runat="server">
        <asp:Label runat="server">Theater Name:</asp:Label>
        <asp:Label ID="lblThtrName" runat="server">Theater Name Goes Here</asp:Label><br />
        <asp:Label runat="server">Movie Name:</asp:Label>
        <asp:Label ID="lblMovName" runat="server">Movie Name Goes Here</asp:Label><br />
        <asp:Label runat="server">Amount of Tickets:</asp:Label>
        <asp:Label ID="lblTxtAmt" runat="server">Amount of Tickets Go Here</asp:Label><br />
        <asp:Label runat="server">Total Cost of Tickets:</asp:Label>
        <asp:Label ID="lblTotal" runat="server">Cost of Tickets Go Here</asp:Label><br />
        <asp:Label runat="server">Customer Name:</asp:Label>
        <asp:Label ID="lblCusName" runat="server">Customer Name Goes Here</asp:Label><br />
        <asp:Label runat="server">Date of Purchase:</asp:Label>
        <asp:Label ID="lblDoP" runat="server">Date of Purchase Goes Here</asp:Label><br />
    </asp:Panel>
</asp:Content>
