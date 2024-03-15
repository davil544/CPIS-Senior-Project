<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMovie.aspx.cs" Inherits="CPIS_Senior_Project.Management.AddMovie" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Please fill out the form below to add your movie to the database:</h2>

<table>
    <tr>
        <td> <asp:Label ID ="lblMovieTitle" runat="server">Movie Title:&nbsp;&nbsp;</asp:Label> </td>
        <td> <asp:TextBox ID="movieTitle" runat="server"></asp:TextBox> </td>
    </tr>
    <tr>
        <td> <asp:Label ID="lblMovieSummary" runat="server">Summary:</asp:Label> </td>
        <td> <asp:TextBox ID="movieSummary" runat="server"></asp:TextBox> </td>
    </tr>
    <tr>
        <td> <asp:Label ID="lblYear" runat="server">Release Year:</asp:Label> </td>
        <td> <asp:TextBox ID="releaseYear" runat="server"></asp:TextBox> </td>
    </tr>
    <tr>
        <td> <asp:Label ID="lblGenre" runat="server">Genre:</asp:Label> </td>
        <td> <asp:TextBox ID="movieGenre" runat="server"></asp:TextBox> </td>
    </tr>
    <tr>
        <td> <asp:Label ID="lblRating" runat="server">MPA Rating:</asp:Label> </td>
        <td> <asp:TextBox ID="movieRating" runat="server"></asp:TextBox> </td>
    </tr>
    <tr>
        <td> <asp:Label ID="lblTimeSlot" runat="server">Times Movie is Playing:</asp:Label> </td>
        <td> <asp:TextBox ID="timeSlot" runat="server">10:00am - 11:45am</asp:TextBox> </td>
    </tr>
    <tr>
        <td> <asp:Label ID="lblPrice" runat="server">Ticket Price:</asp:Label> </td>
        <td> <asp:TextBox ID="ticketPrice" runat="server"></asp:TextBox> </td>
    </tr>
    <tr>
        <td> <asp:Label ID="lblPoster" runat="server">Upload a Poster:</asp:Label> </td>
        <td> <asp:FileUpload ID="posterUpload" runat="server" /> Please keep poster sizes under 1MB to avoid DB fees </td>
    </tr>
</table>
    <br />
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br /><br /> <asp:Button ID="submitMovie" runat="server" OnClick="BtnAddMovie_Click" Text="Add Movie" />&nbsp;
    <asp:Button ID="cancel" runat="server" OnClick="BtnReturn_Click" Text="Return to Management Screen" />
</asp:Content>
