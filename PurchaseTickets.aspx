<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseTickets.aspx.cs" Inherits="CPIS_Senior_Project.PurchaseTickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <main aria-labelledby="title">
      <h2 id="title"><%: Title %></h2> 
      <h4> purchase movie tickets here:</h4>
         <asp:Panel runat="server" ID="PurchaseInfo">
             <asp:Label runat="server" ID="CustomerName">Customer Name:</asp:Label>
              <br />
             <asp:Label runat="server" ID ="MovieName">Movie Name:</asp:Label>
             <br />
             <asp:Label runat="server" ID="CreditNum">Credit Card Number:</asp:Label>
            <asp:DropDownList ID="lstCreditCards" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ListCC_Change"  >
                <asp:ListItem Selected="True" Text="No Card Selected" ></asp:ListItem>
       
            </asp:DropDownList>
             
         </asp:Panel>
                    <br />
                    <asp:Label runat="server" ID ="lblPrice">Price:</asp:Label>
                      <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    <br />
                    
                      <br />
                    <asp:Button ID="BtnPurchaseButton" runat="server" OnClick="BtnPurchase_Click" Text="Purchase Tickets" />
                      <asp:Button ID="BtnCancelButton" runat="server" OnClick="BtnCancel_Click" Text="Cancel Order"/>
                       <br />
         


    </main>
</asp:Content>