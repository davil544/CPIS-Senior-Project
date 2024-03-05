<%@ Page Title="Theater Owner Management Portal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CPIS_Senior_Project.Management.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <main>
       <asp:Label ID="portalStatus" runat="server"></asp:Label> <br />
       <h1><asp:Label ID="greeting" runat="server">Welcome, </asp:Label></h1>
        <!-- TODO:  Create Master file for the backend to cater navbar to theater owners -->
       <!-- ALSO TODO:  Make backend system for theater owners to add or remove movies to / from the SQL server or something -->
       <!-- Will likely be a variant of the home page with management features -->
       <div id="movieCatalog">

       </div>

   </main>
</asp:Content>