<%@ Page Title="Theater Owner Management Portal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CPIS_Senior_Project.Management.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <main>
       <h1><asp:Label ID="greeting" runat="server"></asp:Label></h1>
       <p>More features coming soon...</p>
        <!-- TODO:  Create Master file for the backend to cater navbar to theater owners -->
       <!-- ALSO TODO:  Make backend system for theater owners to add or remove movies to / from the SQL server or something -->
       <!-- Will likely be a variant of the home page with management features -->
       <div id="movieCatalog">
           <div class="row" style="padding-top: 50px;">
                <div class="col-sm-6 col-md-4">
                    <div class="thumbnail">
                    <!-- <img src="/Assets/Inventory/poster.jpg" alt="Movie Poster"> -->
                    <asp:Image ID="imgMovie1" runat="server" alt="Movie Poster Goes Here"/>
                        <div class="caption">
                            <h3><asp:Label ID="lblMovieTitle" runat="server" Text="">Title</asp:Label></h3>
                            <p><asp:Label ID="lblMovieSummary" runat="server" Text="">Summary</asp:Label></p>
                            <p><asp:Label ID="lblMoviePrice" runat="server" Text="">$Price.99</asp:Label></p>
                            <p><asp:Button ID="btnAddMovie" runat="server" BackColor="#337AB7" ForeColor="White" Height="30px" Text="Add to Cart" />
                            &nbsp;<asp:Button ID="btnDetailsMovie" runat="server" Height="30px" Text="Details"  /></p>
                        </div>
                   </div>
                </div>
           </div>
       </div>
   </main>
</asp:Content>