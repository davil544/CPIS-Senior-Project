<%@ Page Title="Edit Theater Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="CPIS_Senior_Project.Management.EditProfile" %>
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
                       <asp:TextBox ID="txtTheaterName" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label runat="server">Address: </asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
                       <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label runat="server">City: </asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label runat="server">State: </asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label runat="server">Operating Hours: </asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtHours" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label runat="server">Zip Code: </asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label runat="server">Country: </asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td />
                   <td>
                       <asp:Button ID="btnSubchanges" runat="server" OnClick="mgmt_subchanges_Click" Text="Submit Changes"/>
                   </td>
               </tr>
               <tr>
                   <td />
                   <td>
                       <asp:Button ID="btnCancel" runat="server" OnClick="mgmt_cancel_Click" Text="Cancel"/>
                   </td>
               </tr>
           </table>
       </asp:Panel>
       <asp:Label ID="debug" runat="server"></asp:Label>
   </main>
</asp:Content>