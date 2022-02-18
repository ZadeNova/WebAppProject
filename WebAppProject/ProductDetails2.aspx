<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="ProductDetails2.aspx.cs" Inherits="ProductDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!DOCTYPE html>
    <html>
    <head>
        <title>Product Details</title>
        <link rel="stylesheet" type="text/css" href="assets/css/ProductDetails.css" />
        <style>
            .Star {
                background-image: url(images/Star.gif);
                height: 17px;
                width: 17px;
            }

            .WaitingStar {
                background-image: url(images/WaitingStar.gif);
                height: 17px;
                width: 17px;
            }

            .FilledStar {
                background-image: url(images/FilledStar.gif);
                height: 17px;
                width: 17px;
            }
        </style>
    </head>
    <body>
        <div class="leftcontainer">
            <div class="imgcontainer">
                <asp:Image ID="imgProductDetails" runat="server" Style="width: 280px; height: 400px; padding: 12px 10px 1px" />
            </div>
        </div>

        <div class="rightcontainer">
            <div class="booktitle">
                <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
            </div>

            <div class="bookauthor">
                From
                <asp:Label ID="lblAuthor" runat="server" Text="Label" Style="color: #48C9B0"></asp:Label>
            </div>

            <div style="height: 10px; font-size: 13px; padding-top: 6px; margin-bottom: 8px; margin-top: 5px; font-weight: bold">
                
            </div>

            <div class="bookprice">
                <asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label>
            </div>

           

        

            <div class="bookpurchase">
                <asp:Button ID="UpdateDescription" runat="server" Text="Update Descriptions" class="cartbutton" OnClick="UpdateDescription_Click"/>
                
            </div>

<%--            <div class="footnote">
                Choose Expedited Shipping at checkout for guaranteed delivery within 
            </div>--%>

          <%--  <div class="footnote" style="font-weight: bold">
                &nbsp 2-3 days
            </div>--%>
        </div>

        <div class="bookdescription">
            <p style="text-align: center; font-family: 'Noticia Text', serif; font-weight: bold; font-size: 25px;">Edit Description</p>
            <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
            <%--<asp:TextBox ID="ProductDescription" runat="server"></asp:TextBox>--%>
            <asp:TextBox ID="UpdateDescriptionTXT" runat="server" placeholder="Enter Updated Description Here"></asp:TextBox>
        </div>

        
    </body>
    </html>
</asp:Content>

