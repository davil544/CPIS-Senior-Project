<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CPIS_Senior_Project.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <h3>Any Questions? Comments? Concerns? </h3>
        <h5>Contact Us Either Through Phone OR Contact Form Below!</h5>
        <address>
            790 Fifth Avenue<br />
            New York, NY 10065<br />
            <abbr title="Phone">P:</abbr>
            800.592.3565
        </address>
        <form id ="form1">
        <div style="font-family:Arial">
            <fieldset style="width:350px">
                
                <table>
                    <tr>
                        <td>
                            <b>Name:</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" Width="200px" runat="server" OnTextChanged="txtName_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                runat="server" 
                                ErrorMessage="Name Is Required"
                                ControlToValidate ="txtName"
                                Text="*"
                                ForeColor="DarkRed"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
    <td>
        <b>Email:</b>
    </td>
    <td>
        <asp:TextBox ID="txtEmail" Width="200px" runat="server" OnTextChanged="txtName_TextChanged"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
            runat="server" 
            ErrorMessage="Email Is Required"
            ControlToValidate ="txtEmail"
            Display ="Dynamic"
            Text="*"
            ForeColor="DarkRed"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
            ErrorMessage="Please enter a valid email"
            ForeColor="Red"
            ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
    </td>
</tr>
                     <tr>
     <td>
         <b>Subject:</b>
     </td>
     <td>
         <asp:TextBox ID="txtSubject" Width="200px" runat="server" OnTextChanged="txtName_TextChanged"></asp:TextBox>
     </td>
     <td>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
             runat="server" 
             ErrorMessage="Subject Is Required"
             ControlToValidate ="txtSubject"
             Text="*"
             ForeColor="DarkRed"></asp:RequiredFieldValidator>
     </td>
 </tr>
                                        <tr>
    <td style ="vertical-align:top">
        <b>Comments:</b>
    </td>
    <td style ="vertical-align:top">
        <asp:TextBox ID="txtComments" Width="200px" runat="server" OnTextChanged="txtName_TextChanged" TextMode="MultiLine" Rows="5"></asp:TextBox>
    </td>
    <td style ="vertical-align:top">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
            runat="server" 
            ErrorMessage="Comments Are Required"
            ControlToValidate ="txtComments"
            Text="*"
            ForeColor="DarkRed"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator runat="server" ForeColor="Red" ControlToValidate="txtComments"></asp:RegularExpressionValidator>
    </td>
</tr>
                    <tr>
                        <td colspan ="3">
                            <asp:ValidationSummary HeaderText ="Please Fix The Following Errors" ForeColor ="Red" ID="ValidationSummary1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="3">
                            <asp:Label ID="Label1" runat="server" Font-Bold ="true" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="3">
                            <asp:Button ID="Button1" runat="server" Text="Send" OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>




        </div>
        </form>
        
    </main>
</asp:Content>
