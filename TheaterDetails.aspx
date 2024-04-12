<%@ Page Title="Theater Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TheaterDetails.aspx.cs" Inherits="CPIS_Senior_Project.TheaterDetails" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="debug" runat="server" Visible="false"></asp:Label>
    <asp:Button ID="btnEdit" runat="server" Text="Edit Theater Info" OnClick="EditTheater_Click" Enabled="false"></asp:Button><br />

    <asp:Label ID="lblThtrInfo" runat="server">Theater Information Goes Here</asp:Label>
    <asp:Label ID="lblThtrName" runat="server">Theater Name Goes Here</asp:Label>
    <asp:Label ID="lblThtrLoc" runat="server">Theater Location Goes Here</asp:Label>



</asp:Content>
