<%@ Page Title="Movie Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieDetails.aspx.cs" Inherits="CPIS_Senior_Project.Management.MovieDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="debug" runat="server" Visible="false"><br /></asp:Label> 
    <asp:Button ID="mgmt_Edit" runat="server" Text="Edit Movie Info" OnClick="EditMovie_Click" Visible="false"></asp:Button><br /> <br />
    <asp:Image ID="moviePoster" alt="Movie Poster Goes Here" runat="server" /> <!-- TODO:  Add auto resizing parameters here to keep posters the same size -->
    <h1> <asp:Label ID="movieTitle" runat="server">Movie Name Here</asp:Label> </h1>
    <h3> <asp:Label ID="movieSummary" runat="server">Movie Summary Here</asp:Label> </h3>
    <h4> Choose theater here to show ticket price <br /> </h4> <!-- Maybe use drop down menu here? -->
    <h4> $<asp:Label ID="ticketPrice" runat="server">0</asp:Label> </h4>
</asp:Content>