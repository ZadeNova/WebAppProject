<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Admin-BestSeller.aspx.cs" Inherits="BestSeller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!DOCTYPE html>
    <html>
    <head>
        <title>Best Sellers</title>
        <link rel="stylesheet" type="text/css" href="assets/css/BestSeller.css" />
        <style>
            .dropdownlist {

            color:Snow;
            background-color:#005c99;
            font-family:Comic Sans MS;
            font-size:large;
            font-style:italic;
            display:inline;
            width:20%;
            border-radius:5px;
            border-style:double;

            }
        </style>
    </head>
    <body>
        <br />
        <div class="pagetitle">Edit Products</div>
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
                <span>Create/Update a new product</span>
                <asp:Button 
                    ID="btnAddItem"
                    Style="font-size: 14px; padding: 8px; margin-bottom: 10px; margin-left: 10px; border: 0.5px solid" 
                    runat="server" 
                    Text="INSERT" OnClick="btnAddItem_Click" />
                <asp:DropDownList ID="ZadeProdType" runat="server" CssClass="dropdownlist" OnSelectedIndexChanged="ZadeProdType_SelectedIndexChanged">
                            <asp:ListItem Value="">Please Select</asp:ListItem>  
                            <asp:ListItem Text="DC" Value="DC"></asp:ListItem>  
                            <asp:ListItem Text="Marvel" Value="Marvel"></asp:ListItem>  
                            <asp:ListItem Text="Anime" Value="Anime"></asp:ListItem>  
                            <asp:ListItem Text="StarWars" Value="StarWars"></asp:ListItem>  
                            <asp:ListItem Text="Keychain" Value="Keychain"></asp:ListItem>  
                        </asp:DropDownList>
            </div>
            <div class="bookshelf">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div style="width: 146px;">
                            <asp:ImageButton ID="imgProduct" CssClass="bookimage" ImageUrl='<%#Eval("Image") %>' PostBackUrl='<%# ResolveClientUrl("ProductDetails2.aspx?ProdID=" + Eval("Id"))%>' runat="server" />
                            <asp:TextBox ID="txtImage" Text='<%#Eval("Image")%>' runat="server" Visible="False"></asp:TextBox>
                            <br />

                            <asp:Label CssClass="booktitle" ID="lblProduct" runat="server" Text='<%#Eval("Product_Name")%>'></asp:Label>
                            <asp:TextBox ID="txtProductName" Text='<%#Eval("Product_Name")%>' runat="server" Visible="False"></asp:TextBox>
                            <br />

                            <asp:Label CssClass="bookauthor" ID="lblProductType" runat="server" Text='<%#Eval("Type") %>' Style="color: #48C9B0"></asp:Label>
                            <asp:TextBox ID="txtProductType" Text='<%#Eval("Type") %>' runat="server" Visible="False"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="ProductPrice" Text='<%#Eval("Price") %>' runat="server" Visible="False"></asp:TextBox>
                            <br />
                            
                            <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("Id") %>' Visible="False"></asp:Label>
                            <br />

                            <asp:LinkButton ID="lnkEdit" Text="Edit |" runat="server" OnClick="OnEdit" Font-Size="Small" />
                            <asp:LinkButton ID="lnkUpdate" Text="Update |" runat="server" Visible="false" OnClick="OnUpdate" Font-Size="Small" />
                            <asp:LinkButton ID="lnkCancel" Text="Cancel |" runat="server" Visible="false" OnClick="OnCancel" Font-Size="Small" />
                            <asp:LinkButton
                                ID="lnkDelete"
                                Text="Delete"
                                runat="server"
                                OnClick="OnDelete"
                                OnClientClick="return confirm('Are you sure you want to delete this?');"
                                Font-Size="Small" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </body>
    </html>
</asp:Content>
