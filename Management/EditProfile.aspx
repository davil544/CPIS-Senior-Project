﻿<%@ Page Title="Edit Theater Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="CPIS_Senior_Project.Management.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <main aria-labelledby="title">
       <h2 id="title"><%: Title %></h2>

       <h4>Edit your Theater Information here:</h4>
       <br />
       <asp:Panel runat="server" ID="edittheater_form">
           <table>
               <tr>
                   <td>
                       <asp:Label runat="server">Theater Name: &nbsp</asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="theaterName" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label runat="server">Address: </asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="Address1" runat="server"></asp:TextBox>
                       <asp:TextBox ID="Address2" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label runat="server">City: </asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="City" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label runat="server">State: </asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="State" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label runat="server">Operating Hours: </asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="hours" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td />
                   <td>
                       <asp:Button ID="mgmt_subchanges" runat="server" OnClick="mgmt_subchanges_Click" Text="Submit Changes"/>
                   </td>
               </tr>
               <tr>
                   <td />
                   <td>
                       <asp:Button ID="mgmt_clear" runat="server" OnClick="mgmt_clear_Click" Text="Clear"/>
                   </td>
               </tr>
           </table>
       </asp:Panel>
   </main>
</asp:Content>