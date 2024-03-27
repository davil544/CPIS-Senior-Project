<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseTickets.aspx.cs" Inherits="CPIS_Senior_Project.PurchaseTickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <main aria-labelledby="title">
      <h2 id="title"><%: Title %></h2> 
      <h4> Enter Credit Card # and cc nuumber and expiration date to purchase movie tickets:</h4>
         <asp:Panel runat="server" ID="PurchaseInfo">
             <asp:Label runat="server" ID="CustomerName">Customer Name:</asp:Label>
              <br />
             <asp:Label runat="server" ID ="MovieName">Movie Name:</asp:Label>
         </asp:Panel>
        <tr>
         <asp:Panel runat="server" ID="Creditcard_Info">
             <td>
               <asp:Label runat="server">Credit Card #:</asp:Label>
                 </td>
                  <td>
                <asp:TextBox ID="cc_number" runat="server"></asp:TextBox>
                </td>
                </tr>
         <tr>
             <td>
                  <br />
                <asp:Label runat="server">CVV:</asp:Label>
                  
             </td>
             <td>
                  <asp:TextBox ID="cc_cvv" runat="server"></asp:TextBox>
                 </td>
             </tr>
          <tr>
              <td>
                   <br />
                <asp:Label runat="server">Expiration Date:</asp:Label>
                </td>
              <td>
                 <asp:TextBox ID="cc_expiration" runat="server"></asp:TextBox>
                  </td>
              </tr>
            </asp:Panel>
         </main>
</asp:Content>
