<%@ Page Title="Theater Owner Management Portal - Theater Registration" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="LoginRegistration.aspx.cs" Inherits="CPIS_Senior_Project.Management.LoginRegistration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>

        <h4>Enter your Username and Password to sign up:</h4>
        <br />
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
                <td />
                <td>
                    <asp:Button ID="mgmt_login" runat="server" OnClick="btnRegister_Click" Text="Log In"/>
                </td>
            </tr>
        </table>
        
        <!-- TODO:  Maybe make panes to combine theater and customer registration into 1 form -->
        
        <br />
        <asp:Label ID="mgmt_status_message" runat="server"></asp:Label>
        <br />
    </main>
</asp:Content>

