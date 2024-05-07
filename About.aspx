<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CPIS_Senior_Project.About" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContent" runat="server">
<style>
    * {
        box-sizing: border-box;
    }

    .heading {
        font-size: 25px;
        margin-right: 25px;
    }

    .rate {
        float: left;
        height: 46px;                       /*Style sheet for the Rating stars*/
        padding: 0 10px;
    }

    .rate:not(:checked) > input {
        position:absolute;
        top:-9999px;
    }

    .rate:not(:checked) > label {
        float:right;
        width:1em;
        overflow:hidden;
        white-space:nowrap;
        cursor:pointer;
        font-size:30px;
        color:#ccc;
    }

    .rate > label:before {
        content: '★ ';
    }

    .rate > input:checked ~ label {
        color: #ffc700;    
    }

    .rate:not(:checked) > label:hover,
    .rate:not(:checked) > label:hover ~ label {
        color: #deb217;  
    }

    .rate > input:checked + label:hover,
    .rate > input:checked + label:hover ~ label,
    .rate > input:checked ~ label:hover,
    .rate > input:checked ~ label:hover ~ label,
    .rate > label:hover ~ input:checked ~ label {
        color: #c59b08;
    }

    /* Three column layout */
    .side {
        float: left;
        width: 15%;
        margin-top: 10px;
    }

    .middle {
        float: left;
        width: 70%;
        margin-top: 10px;
    }

    /* Place text to the right */
    .right {
        text-align: right;
    }

    /* Clear floats after the columns */
    .row:after {
        content: "";
        display: table;
        clear: both;
    }

    /* The bar container */
    .bar-container {
        width: 100%;
        background-color: #f1f1f1;
        text-align: center;
        color: white;
    }

    /* Individual bars */
    .bar-5 {
        width: 60%;
        height: 18px;
        background-color: #04AA6D;
    }

    .bar-4 {
        width: 30%;
        height: 18px;
        background-color: #2196F3;
    }

    .bar-3 {
        width: 10%;
        height: 18px;
        background-color: #00bcd4;
    }

    .bar-2 {
        width: 4%;
        height: 18px;
        background-color: #ff9800;
    }

    .bar-1 {
        width: 15%;
        height: 18px;
        background-color: #f44336;
    }

    /* Responsive layout - make the columns stack on top of each other instead of next to each other */
    @media (max-width: 400px) {
        .side, .middle {
            width: 100%;
        }
        /* Hide the right column on small screens */
        .right {
            display: none; 
        }
    }
</style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/font-awesome.min.css" rel="stylesheet" />
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <h3>Find some information about our business below!</h3>
        <p>The mission of the Movie Ticket Sales Site is to help out local movie theater businesses around the U.S. to provide the latest technology that major entertainment companies (AMC, Regal, etc.) use to create easier ways to watching movies! We invite several local businesses to provide their locations and list of movies, as well as providing employee information to provide management services for our website. We allow our customers to create their own accounts for FREE and browse a ton of movies that local movie theater businesses provide, as well as providing feedback on how well each movie theater provider handles their customers. We, at the Movie Ticket Sales Site, want to help out local movie theater businesses by creating easier ways to enhance the experience of going out to the movies.</p>
        <br />

        <span class="heading">Theater Rating</span>
        
        <div class="rate">
            <input type="radio" id="star5" name="rate" value="5" />    <%-- This is the code for the stars --%> 
            <label for="star5" title="text">5 stars</label>
            <input type="radio" id="star4" name="rate" value="4" />
            <label for="star4" title="text">4 stars</label>
            <input type="radio" id="star3" name="rate" value="3" />
            <label for="star3" title="text">3 stars</label>
            <input type="radio" id="star2" name="rate" value="2" />
            <label for="star2" title="text">2 stars</label>
            <input type="radio" id="star1" name="rate" value="1" />
            <label for="star1" title="text">1 star</label>
        </div>

        <p>4.1 average based on 254 reviews.</p>
        <hr style="border:3px solid #f1f1f1">

        <div class="row">
            <div class="side">
                <div>5 star</div>
            </div>
            <div class="middle">
                <div class="bar-container">
                    <div class="bar-5"></div>
                </div>
            </div>
            <div class="side right">
                <div>150</div>
            </div>
            <div class="side">
                <div>4 star</div>
            </div>
            <div class="middle">
                <div class="bar-container">
                    <div class="bar-4"></div>
                </div>
            </div>
            <div class="side right">
                <div>63</div>
            </div>
            <div class="side">
                <div>3 star</div>
            </div>
            <div class="middle">
                <div class="bar-container">
                    <div class="bar-3"></div>
                </div>
            </div>
            <div class="side right">
                <div>15</div>
            </div>
            <div class="side">
                <div>2 star</div>
            </div>
            <div class="middle">
                <div class="bar-container">
                    <div class="bar-2"></div>
                </div>
            </div>
            <div class="side right">
                <div>6</div>
            </div>
            <div class="side">
                <div>1 star</div>
            </div>
            <div class="middle">
                <div class="bar-container">
                    <div class="bar-1"></div>
                </div>
            </div>
            <div class="side right">
                <div>20</div>
            </div>
        </div>
    </main>
</asp:Content>