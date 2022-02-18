<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!DOCTYPE html>
    <html>
    <head>
        <title>Sunny V2</title>
        <link rel="stylesheet" type="text/css" href="assets/css/index.css" />
    </head>
    <body>
           <div class="slideshow-container">
            <div class="mySlides fade">
                <div class="numbertext">1 / 3</div>
                <img src="<%#img1 %>" style="width: 100%" class="dbimg" >
            </div>

            <div class="mySlides fade">
                <div class="numbertext">2 / 3</div>
                <img src="<%#img2 %>" style="width: 100%" class="dbimg" >
            </div>

            <div class="mySlides fade">
                <div class="numbertext">3 / 3</div>
                <img src="<%#img3 %>" style="width: 100%" class="dbimg">
            </div>
             <%-- Add the prev and next buttons for the suer to click -- %>
             <%-- when clicked it calls on plusSlides()--%>
            <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
            <a class="next" onclick="plusSlides(1)">&#10095;</a>
        </div>

       
        <br />
        <br />
        
        <br />
      
        <script>
            var slideIndex = 1;
            showSlides(slideIndex);

            function plusSlides(n) {
                showSlides(slideIndex += n);
            }

            function currentSlide(n) {
                showSlides(slideIndex = n);
            }
            function showSlides(n) {
                var i;
                var slides = document.getElementsByClassName("mySlides");
                var dots = document.getElementsByClassName("dot");
                if (n > slides.length) { slideIndex = 1 }
                if (n < 1) { slideIndex = slides.length }
                for (i = 0; i < slides.length; i++) {
                    slides[i].style.display = "none";
                }
                for (i = 0; i < dots.length; i++) {
                    dots[i].className = dots[i].className.replace(" active", "");
                }
                slides[slideIndex - 1].style.display = "block";
                dots[slideIndex - 1].className += " active";
            }
        </script>


    </body>
    </html>
</asp:Content>