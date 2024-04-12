<%@ Page Title="Theater Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TheaterDetails.aspx.cs" Inherits="CPIS_Senior_Project.TheaterDetails" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="debug" runat="server" Visible="false"></asp:Label>
    <asp:Button ID="btnEdit" runat="server" Text="Edit Theater Info" OnClick="EditTheater_Click" Enabled="false"></asp:Button><br />

    <h4>Theater Information Goes Here</h4>
    <asp:Label ID="lblThtrName" runat="server">Theater Name Goes Here</asp:Label><br />
    <asp:Label ID="lblThtrLoc" runat="server">Theater Location Goes Here</asp:Label><br />
    <asp:Label ID="lblThtrOH" runat="server">Theater Operating Hours Go Here</asp:Label><br />






</asp:Content>
