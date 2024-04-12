<%@ Page Title="Edit Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="CPIS_Senior_Project.Management.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>

        <asp:Panel runat="server" ID="editTheater_form">
            <h4>Edit your Theater Information here:</h4>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server">Theater Name:</asp:Label>
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
                        <asp:Label runat="server">City:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server">State:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server">Zip Code:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server">Country:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server">Operating Hours:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHours" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server">Ticket Price (In USD):&nbsp</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTicketPrice" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <asp:Panel ID="editCustomer_form" runat="server" Visible="false">
            <h4>Edit your Customer Profile here:</h4>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server">Full Name:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td> <!-- TODO:  Add drop down here to select a credit card, in case more than 1 is on file -->
                        <asp:Label Text="Edit Credit Card Info:&nbsp" runat="server"></asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="lstCreditCards" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ListCC_Change"  >
                            <asp:ListItem Text="Add New Card" Value="newcard" ></asp:ListItem>
                            <asp:ListItem Selected="True" Text="No Card Selected" ></asp:ListItem>
                        </asp:DropDownList>
                        
                        
                    </td>
                </tr>
            </table>
            <br />
            <asp:Panel ID="formCCHTML" runat="server" Visible="false">
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server">Credit Card #:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCC_number" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                <tr>
                    <td>
                        <asp:Label runat="server">Expiration Date:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtExpDate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server">CVV:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCVV" runat="server"></asp:TextBox>
                    </td>
                </tr>
                </table>
            </asp:Panel>
        </asp:Panel> <br />

        <asp:Button ID="btnSubchanges" runat="server" OnClick="BtnSubmit_Click" Text="Submit Changes"/>
        <asp:Button ID="btnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel"/>
        <br /> <br /> <asp:Label ID="debug" runat="server"></asp:Label>
    </main>
</asp:Content>