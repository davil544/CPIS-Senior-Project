<%@ Page Title="Ticket Order History" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="CPIS_Senior_Project.Management.OrderHistory" %>
<asp:Content ID="Head" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .msgBreak{
            border: 1px dotted black;
        }
        img {
            max-height: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Ticket Order History:</h2>
    <asp:Literal ID="litTicketOrders" runat="server"></asp:Literal>
</asp:Content>
