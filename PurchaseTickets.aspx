<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseTickets.aspx.cs" Inherits="CPIS_Senior_Project.PurchaseTickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <main aria-labelledby="title">
      <h2 id="title"><%: Title %></h2> 
      <h4> Enter Credit Card # and cc nuumber and expiration date to purchase movie tickets:</h4>
          <asp:Panel runat="server" ID="Creditcard_Info">
               <asp:Label runat="server">Credit Card #:</asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>                
               <asp:TextBox ID="cc_expiration" runat="server"></asp:TextBox>
     
     <asp:Panel runat="server" ID="Creditcard_signup">
       <asp:Label runat="server">Credit Card #:</asp:Label>
       <asp:TextBox ID="cc_number" runat="server"></asp:TextBox>
       <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
</asp:Content>
