<%@ Page Title="Theater Owner Management Portal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CPIS_Senior_Project.Management.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <main>
       <asp:Label ID="portalStatus" runat="server"></asp:Label>
        <!-- TODO:  Create Master file for the backend to cater navbar to theater owners and change Login button to Logout -->
       <!-- ALSO TODO:  Make backend system for theater owners to add or remove movies to / from the SQL server or something -->
   </main>
</asp:Content>