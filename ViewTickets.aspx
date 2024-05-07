<%@ Page Title="Movie Tickets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTickets.aspx.cs" Inherits="CPIS_Senior_Project.ViewTickets" %>
<asp:Content ID="Head" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        img {
            max-height: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="debug" runat="server" Visible="false"></asp:Label>
    <asp:Panel ID="pnlTickets" runat="server">
        <h1>Ticket Purchase Successfull!</h1><br />
        <h3>Here is your ticket purchase summary:</h3><br /><br />
        <h5><asp:Label runat="server">Theater Selected:</asp:Label></h5>
        <asp:Label ID="lblThtrName" runat="server">Theater Name Goes Here</asp:Label><br /><br />
        <h5><asp:Label runat="server">Movie Picked:</asp:Label></h5>
        <asp:Label ID="lblMovName" runat="server">Movie Name Goes Here</asp:Label><br /><br />
        <h5><asp:Label runat="server">Amount of Tickets:</asp:Label></h5>
        <asp:Label ID="lblTxtAmt" runat="server">Amount of Tickets Go Here</asp:Label><br /><br />
        <h5><asp:Label runat="server">Total Cost of Tickets:</asp:Label></h5>
        <asp:Label ID="lblTotal" runat="server">Cost of Tickets Go Here</asp:Label><br /><br />
        <h5><asp:Label runat="server">Your Name:</asp:Label></h5>
        <asp:Label ID="lblCusName" runat="server">Customer Name Goes Here</asp:Label><br /><br />
        <h5><asp:Label runat="server">Purchase Date:</asp:Label></h5>
        <asp:Label ID="lblDoP" runat="server">Date of Purchase Goes Here</asp:Label><br /><br />
        <img src="/Content/img/movieTicketQRcode.png" />
    </asp:Panel>
</asp:Content>
