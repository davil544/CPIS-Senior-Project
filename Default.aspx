<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CPIS_Senior_Project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="MoviesTitle">
            <div class="p-4 mb-4 bg-light rounded-3">
                <h1>Welcome to the best place to buy movie tickets!</h1>
                <div style="text-align: center;"><asp:Label ID="debug" runat="server" Visible="false"></asp:Label></div>
                <asp:Panel ID="pnlMovies" runat="server">
                    <h4>&nbsp&nbsp Movies currently being shown:</h4>
                    <div class="container-fluid py-5">
                        <div id="movieCarouselControls" class="carousel carousel-dark slide" data-bs-ride="carousel">
                            <div class="carousel-inner" runat="server" id="carouselItems"></div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#movieCarouselControls" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#movieCarouselControls" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>
                    </div>
                </asp:Panel>
           </div>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="OwnersTitle">
                <h2 id="OwnersTitle">Owners</h2>
                <p>
                 Movies.net allows movie owners to view ticket sales, as well as list or delist movies that came out to make sure that popular titles are shown and unpopular ones are delisted. 
                </p>
                <p>
                    <a class="btn btn-outline-dark" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="EmployeesTitle">
                <h2 id="EmployeesTitle">Employees</h2>
                <p>
                   Allows employees to check hours of work and available hours to work, so that they can book hours to work at their convience 
                </p>
                <p>
                    <a class="btn btn-outline-dark" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="CustimersTitle">
                <h2 id="CustimersTitle">Customers</h2>
                <p>
                    Customers can buy review movies, write reviews for movies they watched, and buy tickets for movies they want to watch.
                </p>
                <p>
                    <a class="btn btn-outline-dark" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
