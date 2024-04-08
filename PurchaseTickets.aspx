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
            <asp:DropDownList ID="lstCreditCards" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ListCC_Change"  >
                <asp:ListItem Selected="True" Text="No Card Selected" ></asp:ListItem>
            </asp:DropDownList>
         </asp:Panel>
                               
                    <asp:Label runat="server" ID ="lblTheaterSelection">Theater Selection:</asp:Label>
                     <asp:DropDownList ID="lstTheaterSelection" runat="server"></asp:DropDownList>

                    <asp:Label runat="server" ID ="lblPrice">Price:</asp:Label>
                      <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                      
                    <asp:Label runat="server" ID ="lblCreditCard_Selection">Credit Card Selection:</asp:Label>
                        <asp:DropDownList ID="lstCreditCard_Selection" runat="server"></asp:DropDownList>

                     <asp:Label runat="server" ID ="lblPurchaseButton">Purchase Button:</asp:Label>
                    <asp:RadioButton ID="btnPurchaseButton" runat="server" Text="Customer&nbsp&nbsp&nbsp" GroupName="PurchaseRole" AutoPostBack="true" OnCheckedChanged="BtnPurchase_Click" Checked="true"/>
                     <asp:Label runat="server" ID ="lblCancelButton">Cancel Button:</asp:Label>
                        <asp:RadioButton ID="btnCancelButton" runat="server" Text="Customer&nbsp&nbsp&nbsp" GroupName="CancelRole" AutoPostBack="true" OnCheckedChanged="BtnCancel_Click" Checked="true"/>
              
         


    </main>
</asp:Content>