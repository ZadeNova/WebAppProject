<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StarWarsProducts.aspx.cs" Inherits="StarWarsProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!DOCTYPE html>
    <html>
    <head>
        <title>Star Wars Figures</title>
        <link rel="stylesheet" type="text/css" href="assets/css/BestSeller.css" />
        <style>
            .StarWarsDiv 
            {
                display:flex;
                justify-content:center;
                align-items:center;
                width:220px;
            }


        </style>




    </head>
    <body>
        <br />
        <div class="pagetitle">Star Wars Figures</div>
        <br />

        <div class="sidecontainer">
            <div style="width: auto; height: auto; float: right">
                <a style="font-family: 'Oswald', sans-serif;">CUSTOMER FAVOURITES</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Summer Reading</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Winter's Special</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">SB's Top 100</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">New Releases</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Coming Soon</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Straight Time's Bestsellers</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">SB Podcast</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">SB Top Reviews</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Book Charts</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Teen's Favourite</a>
                <a style="font-family: 'Oswald', sans-serif;"></a>
                <a style="font-family: 'Oswald', sans-serif;">BEST VALUE</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Sci-Fi Week: Buy 2, Get 1 FREE</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Summer Reading Deals</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">SB Classics: $6 Each</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">SB Collectibles Edition</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">New Releases 15% Off</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Thriller Special: Spend $50, Get Extra $10 Off</a>
                <a style="font-family: 'Oswald', sans-serif;"></a>
                <a style="font-family: 'Oswald', sans-serif;">CATEGORIES</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Art, Architecture & Photography</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Bibles & Christianity</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Biography</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Business</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Cookbooks, Food & Wine</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Fiction</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Graphic Novels & Comics</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Diet, Health, Fitness</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">History</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Mystery & Crime</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Religion</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Romance</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Science Fiction & Fantasy</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Self-Help & Relationships</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Sports</a>
                <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">See All Categories</a>
            </div>
        </div>

        <div class="bookcontainer">
            <div class="containertitle">
                Star Wars Products
            </div>
            <div class="bookshelf">
                <asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>
                        <div CssClass="StarWarsDiv">
                            <asp:ImageButton PostBackUrl='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("Id"))%>' ID="imgBooks" CssClass="bookimage" ImageUrl='<%#Eval("Image") %>' runat="server" />
                            <asp:Label CssClass="StarWarsfigureName" ID="lblTitle" runat="server" Text='<%#Eval("Product_Name")%>'></asp:Label>
                            
                            <asp:Label CssClass="bookauthor" ID="lblAuthor" runat="server" Text='<%#Eval("Type") %>' Style="color: #48C9B0"></asp:Label>
                        </div>
                    </ItemTemplate>

                </asp:Repeater>

            </div>
            
         
        </div>
    </body>
    </html>








</asp:Content>

