<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CPIS_Senior_Project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="MoviesTitle">
            <div class="p-4 mb-4 bg-light rounded-3">
                <div class="container-fluid py-5">
                    <h1 id="aspnetTitle" class="display-5 fw-bold">ASP.NET</h1>
                    <p class="col-md-8 fs-4">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
                    <a href="http://www.asp.net" class="btn btn-primary btn-md" type="button">Learn More &raquo;</a>
                </div>
           </div>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="OwnersTitle">
                <h2 id="OwnersTitle">Owners</h2>
                <p>
                 Movies.net allows movie owners to view ticket sales. As well as list or delist movies that came out to make sure that popular titles are shown and nonpopular ones are delisted. 
                </p>
                <p>
                    <a class="btn btn-outline-dark" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="EmployeesTitle">
                <h2 id="EmployeesTitle">Employees</h2>
                <p>
                   Allows employees to check hours of work and avliable hours to work. So that they can book hours to work at there convience 
                </p>
                <p>
                    <a class="btn btn-outline-dark" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="CustimersTitle">
                <h2 id="CustimersTitle">Customers</h2>
                <p>
                    Customers can buy review movies, write reviewsa for movies they watched, and buy tickets for movies they want to watch.
                </p>
                <p>
                    <a class="btn btn-outline-dark" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
