<%@ Page Title="Theater Owner Management Portal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CPIS_Senior_Project.Management.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <main>
       <h1><asp:Label ID="greeting" runat="server"></asp:Label></h1>
       <p>More features coming soon...</p>
       <asp:Label ID ="lblMovieCount" runat="server">Number of movies in database: </asp:Label>
        <!-- TODO:  Create Master file for the backend to cater navbar to theater owners -->
       <!-- ALSO TODO:  Make backend system for theater owners to add or remove movies to / from the SQL server or something -->
       <!-- Will likely be a variant of the home page with management features -->
       <div id="movieCatalog">
           <asp:Button runat="server" Text="Add Movie Listing" OnClick="AddMovie_Click"/>
           <div class="row" style="padding-top: 50px;">
                <div class="col-sm-6 col-md-4">
                    <div class="thumbnail">
                    <!-- <img src="/Assets/Inventory/poster.jpg" alt="Movie Poster"> -->
                    <asp:Image ID="imgMovie1" runat="server" alt="Movie Poster Goes Here"/>
                        <div class="caption">
                            <h3><asp:Label ID="lblMovieTitle" runat="server" Text="">Title</asp:Label></h3>
                            <p><asp:Label ID="lblMovieSummary" runat="server" Text="">Summary</asp:Label></p>
                            <p><asp:Label ID="lblMoviePrice" runat="server" Text="">$Price.99</asp:Label></p>
                            <p><asp:Button ID="btnAddMovie" runat="server" BackColor="#337AB7" ForeColor="White" Height="30px" Text="Modify" /> <!-- Will say Add to Cart on home page -->
                            &nbsp;<asp:Button ID="btnDetailsMovie" runat="server" Height="30px" Text="Details"  /></p>
                        </div>
                   </div>
                </div>
               <div class="col-sm-6 col-md-4">
                    <div class="thumbnail">
                        <!-- <img src="/Assets/Inventory/poster.jpg" alt="Movie Poster"> -->
                        <asp:Image ID="Image1" runat="server" alt="Movie Poster Goes Here"/>
                        <div class="caption">
                            <h3><asp:Label ID="Label1" runat="server" Text="">Title</asp:Label></h3>
                            <p><asp:Label ID="Label2" runat="server" Text="">Summary</asp:Label></p>
                            <p><asp:Label ID="Label3" runat="server" Text="">$Price.99</asp:Label></p>
                            <p><asp:Button ID="Button1" runat="server" BackColor="#337AB7" ForeColor="White" Height="30px" Text="Modify" /> <!-- Will say Add to Cart on home page -->
                            &nbsp;<asp:Button ID="Button2" runat="server" Height="30px" Text="Details"  /></p>
                        </div>
                   </div>
               </div>
               <div class="col-sm-6 col-md-4">
                   <div class="thumbnail">
                        <!-- <img src="/Assets/Inventory/poster.jpg" alt="Movie Poster"> -->
                        <asp:Image ID="Image2" runat="server" alt="Movie Poster Goes Here"/>
                        <div class="caption">
                            <h3><asp:Label ID="Label4" runat="server" Text="">Title</asp:Label></h3>
                            <p><asp:Label ID="Label5" runat="server" Text="">Summary</asp:Label></p>
                            <p><asp:Label ID="Label6" runat="server" Text="">$Price.99</asp:Label></p>
                            <p><asp:Button ID="Button3" runat="server" BackColor="#337AB7" ForeColor="White" Height="30px" Text="Modify" /> <!-- Will say Add to Cart on home page -->
                            &nbsp;<asp:Button ID="Button4" runat="server" Height="30px" Text="Details"  /></p>
                        </div>
                   </div>
               </div>
           </div>
       </div>
   </main>
</asp:Content>