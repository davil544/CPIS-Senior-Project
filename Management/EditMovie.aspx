<%@ Page Title="Edit Movie Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditMovie.aspx.cs" Inherits="CPIS_Senior_Project.Management.EditMovie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="debug" runat="server"></asp:Label> <br /><br />
    <table>
        <tr>
            <td> <asp:Label ID="lblMovieName" runat="server">Movie Name:</asp:Label> </td>
            <td> <asp:TextBox ID="txtMovieName" runat="server"></asp:TextBox> </td>
        </tr>
        <tr>
            <td> <asp:Label ID="lblMovieDesc" runat="server">Description:</asp:Label> </td>
            <td> <asp:TextBox ID="txtMovieDesc" runat="server"></asp:TextBox> </td>
        </tr>
        <tr>
            <td> <asp:Label ID="lblYear" runat="server">Release Year:</asp:Label> </td>
            <td> <asp:TextBox ID="txtReleaseYear" runat="server"></asp:TextBox> </td>
        </tr>
        <tr>
            <td> <asp:Label ID="lblGenre" runat="server">Genre:</asp:Label> </td>
            <td> <asp:TextBox ID="txtMovieGenre" runat="server"></asp:TextBox> </td>
        </tr>
        <tr>
            <td> <asp:Label ID="lblRating" runat="server">MPA Rating:</asp:Label> </td>
            <td> <asp:TextBox ID="txtMovieRating" runat="server"></asp:TextBox> </td>
        </tr>
        <tr>
            <td> <asp:Label ID="lblTimeSlot" runat="server">Times Movie is Playing:</asp:Label> </td>
            <td> <asp:TextBox ID="txtTimeSlot" runat="server"></asp:TextBox> </td>
        </tr>
        <!--<tr>
            <td> <asp:Label ID="lblPrice" runat="server">Ticket Price:</asp:Label> </td>
            <td> <asp:TextBox ID="txtTicketPrice" runat="server"></asp:TextBox> </td>
        </tr> This is implemented on a per theater basis atm, may change in the future -->
        <tr>
            <td> <asp:Label ID="lblPoster" runat="server">Movie Poster:</asp:Label> </td>
            <td> <asp:FileUpload ID="posterUpload" runat="server" /> Please keep poster sizes under 1MB to avoid DB fees, Maybe put poster above here? </td>
        </tr>
    </table>

     <br /><br />

    <asp:Button ID="btnSave" runat="server" Text="Save Information" OnClick="BtnSave_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />

</asp:Content>