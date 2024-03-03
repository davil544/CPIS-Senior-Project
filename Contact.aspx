<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CPIS_Senior_Project.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <h3>Any Questions? Comments? Concerns? Contact us!</h3>
        <address>
            790 Fifth Avenue<br />
            New York, NY 10065<br />
            <abbr title="Phone">P:</abbr>
            800.592.3565
        </address>

        <address>
            <strong>Support:</strong>   <a href="mailto:Support@thewebsitewonders.com">Support@thewebsitewonders.com</a><br />
            <strong>Marketing:</strong> <a href="mailto:Marketing@thewebsitewonders.com">Marketing@thewebsitewonders.com</a>
        </address>
    </main>
</asp:Content>
