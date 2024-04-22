<%@ Page Title="Movie Slider" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="CPIS_Senior_Project.Default2" %>
<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .carousel-control-prev-icon,
        .carousel-control-next-icon {
            background-color: black;
        }
        .carousel-control-prev,
        .carousel-control-next {
            filter: invert(100%);
        }
        .carousel-inner img {
            width: 100%;
            height: auto;
            max-height: 240px; 
        }
        .carousel-item {
            text-align: center;
        }
        .btn-movie-title {
            margin-top: 10px;
        }
    </style>

    <!-- Do not use this page anymore!  Code tweaked and merged with main homepage! -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
            <div id="movieCarousel" class="carousel slide" data-ride="carousel">
                <div class="carousel-inner" runat="server" id="carouselItems">
                    <!-- Carousel items will be added here from code-behind, maybe disable auto scroll? -->
                </div>
                <a class="carousel-control-prev" href="#movieCarousel" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#movieCarousel" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>

<!-- <link href="Content/Ty.css" rel="stylesheet" />
<div id="home-body">
    <div class="rectangle">Group 1 Project</div>
    <div class="red-rectangle red-1"></div>
    <div class="red-rectangle red-2"></div>
    <div class="red-rectangle red-3"></div>
    <div class="red-rectangle red-4"></div>
    <div class="red-rectangle red-5"></div>
    <div class="red-rectangle red-6"></div>
    <div class="circle circle-1"></div>
    <div class="circle circle-2"></div>
    <div class="red-rectangle-center"></div>
    <div class="red-rectangle-center"></div>
    <div class="red-rectangle-center-2"></div>
    <div class="red-rectangle-center-3"></div>
    <div class="white-rectangle-curved">For You</div>
<!-- Corrected Image Slider
<div class="image-slider">
    <img src="image1.jpg" alt="Image 1" class="slider-image"> <!-- Corrected Image Tag 
    <img src="image2.jpg" alt="Image 2" class="slider-image"> <!-- Assuming different images should be used 
    <img src="image3.jpg" alt="Image 3" class="slider-image"> <!-- Corrected Image Tag 
    <img src="image4.jpg" alt="Image 4" class="slider-image">
    <img src="image5.jpg" alt="Image 5" class="slider-image">
    <img src="image6.jpg" alt="Image 6" class="slider-image"> <!-- Corrected Image Tag 
    <img src="image7.jpg" alt="Image 7" class="slider-image">
    <!-- Controls 
    <div class="slider-control control-left">&#10094;</div>
    <div class="slider-control control-right">&#10095;</div>
</div>

</div> -->
</asp:Content>
