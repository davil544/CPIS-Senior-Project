<%@ Page Title="Theater Owner Management Portal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CPIS_Senior_Project.Management.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <main>
       <h1><asp:Label ID="greeting" runat="server"></asp:Label></h1>
       Number of movies in database: <asp:Label ID ="lblMovieCount" runat="server"></asp:Label><br />
       <asp:Button runat="server" Text="Add Movie Listing" OnClick="AddMovie_Click"/>&nbsp;
       <asp:Button runat="server" Text="Edit Theater Profile Information" OnClick="EditProfile_Click"/>
       <asp:Panel ID="movieCatalog" runat="server"></asp:Panel>
       <!--  TODO:  Create Master file for the backend to cater navbar to theater owners -->
       <!-- This page will likely be a variant of the home page with management features -->
   </main>
</asp:Content>