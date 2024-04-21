<%@ Page Title="Search Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="CPIS_Senior_Project.SearchResults" %>
<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <h2 id="heading2" runat="server">Movie Title Search Results for:&nbsp<asp:Literal ID="litSearchQuery" runat="server"></asp:Literal></h2>
    <asp:Literal ID="litResults" runat="server"></asp:Literal>
</asp:Content>