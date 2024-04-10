<%@ Page Title="Movie Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieDetails.aspx.cs" Inherits="CPIS_Senior_Project.Management.MovieDetails" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="debug" runat="server">No Movie Found!</asp:Label> 
    <asp:Button ID="mgmt_Edit" runat="server" Text="Edit Movie Info" OnClick="EditMovie_Click" Visible="false"></asp:Button><br />
    <asp:Panel ID="pnlMovieInfo" runat="server" Visible="false">
    <table>
        <tr>
            <td>
                <img id="moviePoster" runat="server" alt="Movie Poster Goes Here" width="400" height="550" />
            </td>
            <td style="padding: 50px;">
                <h1> <asp:Label ID="movieTitle" runat="server">Movie Name Here</asp:Label> </h1>
                <h4> <asp:Label ID="movieSummary" runat="server">Movie Summary Here</asp:Label> </h4>
                <p> <br /> Select a theater to view ticket price:&nbsp
                    <asp:DropDownList ID="lstMovieTheaters" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ChooseTheater_Change">
                        <asp:ListItem Selected="True" Text="No theater selected" ></asp:ListItem>
                    </asp:DropDownList>
                </p> <br />
                <h4> $<asp:Label ID="lblTicketPrice" runat="server">0</asp:Label> </h4>

                <!-- This is to be enabled once a theater is selected -->
                <br />Number of Tickets:&nbsp&nbsp<asp:TextBox ID="txtTicketCount" runat="server" Width="40px" type="number" min="1" value="1"></asp:TextBox>
                <asp:RegularExpressionValidator ID="TicketCountValidator"
                    ControlToValidate="txtTicketCount" runat="server"
                    ErrorMessage="Only Numbers allowed here!"
                    ValidationExpression="\d+">
                </asp:RegularExpressionValidator>

                <br /><br /><asp:Button ID="btnPurchase" runat="server" Text="Purchase" Enabled="false" OnClick="BtnPurchase_Click" />
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>