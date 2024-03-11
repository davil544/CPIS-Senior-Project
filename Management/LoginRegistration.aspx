<%@ Page Title="Theater Owner Management Portal - User Registration" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="LoginRegistration.aspx.cs" Inherits="CPIS_Senior_Project.Management.LoginRegistration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>

        <h4>Enter your Username and Password to sign up:</h4>
        <br />
        <asp:Panel runat="server" ID="signup_form">
        <table>
            <tr>
                <td>
                    <asp:Label runat="server">User Name:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="mgmt_Username" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server">Password: </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="mgmt_Password" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            

            <tr>
                <td>
                  Account type: &nbsp&nbsp
                </td>
                <td>
                    <asp:RadioButton ID="customerRole" runat="server" Text="Customer&nbsp&nbsp&nbsp" GroupName="accountRole" AutoPostBack="true" OnCheckedChanged="btnRole_Click" Checked="true"/>
                    <asp:RadioButton ID="theaterRole" runat="server" Text="Theater Employee" GroupName="accountRole" AutoPostBack="true" OnCheckedChanged="btnRole_Click"/>
                  <!--  <asp:RadioButtonList ID="accountRole" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" OnDataBound="btnRole_Click" AutoPostBack="true">
                        <asp:ListItem Text="Theater Employee&nbsp&nbsp&nbsp" Value="theater" />
                        <asp:ListItem Text="Customer" Value ="customer" />
                    </asp:RadioButtonList>  -->
                    <!-- Delete comment above and commit this to git once forms are done -->
                </td>
            </tr>
        </table>
        </asp:Panel>
        <br />
        <asp:Panel runat="server" ID="theaterForm" Visible="false">
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
                        <asp:Label runat="server">Country: </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Country" runat="server"></asp:TextBox>
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
            </table>
        </asp:Panel>

        <asp:Panel runat="server" ID="customerForm">
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server">Name:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="customerName" runat="server"></asp:TextBox>
                        </td>
                        </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server">Credit Card #:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="cc_number" runat="server"></asp:TextBox>
                         <!-- <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="cc_number" ErrorMessage="Card # must be only numbers" />  Not working properly, may remove in a future update  -->
                        </td>
                        </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server">Expiration Date:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="cc_expiration" runat="server"></asp:TextBox>
                        </td>
                        </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server">CVV:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="cc_cvv" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
        </asp:Panel>
        
        <!-- TODO:  Maybe make panes to combine theater and customer registration into 1 form -->
        <br />
        <asp:Button ID="mgmt_login" runat="server" OnClick="btnRegister_Click" Text="Sign Up"/>
        <br /> <br />
        <asp:Label ID="mgmt_status_message" runat="server"></asp:Label>
        <br />
    </main>
    <!-- TODO: Make better IDs for these text boxes -->
</asp:Content>