<%@ Page Title="" Language="C#" MasterPageFile="~/Afterlogin.master" AutoEventWireup="true" CodeFile="ViewCart2.aspx.cs" Inherits="ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!DOCTYPE html>
    <html>
    <head>
        <title>Shopping Cart</title>
        <style>
            .topbanner {
                width: 100%;
                height: 100px;
                background-color: #F6DDCC;
                margin-top: 40px;
                text-align: center;
                font-family: 'Poppins', sans-serif;
                font-size: 18px;
                color: black;
                padding: 37px;
            }

            .leftcontainer {
                width: 60%;
                height: auto;
                float: left;
                margin-top: 30px;
            }

            .ordersummary {
                width: 35%;
                height: 500px;
                float: right;
                border: 0.7px solid gray;
                margin-top: 43px;
                margin-bottom: 40px;
                padding: 20px;
            }

            .checkoutbtn {
                width: 100%;
                height: 55px;
                border: none;
                background-color: #138D75;
                font-family: 'Poppins', sans-serif;
                font-size: 22px;
                text-align: center;
                color: white;
            }

                .checkoutbtn:hover {
                    background-color: #48C9B0;
                }

            .altpayment {
                width: 100%;
                height: 140px;
                padding: 20px;
                float: left
            }

            .paypalbtn {
                width: 100%;
                height: 50px;
                border: none;
                background-color: #F1C40F;
            }

                .paypalbtn:hover {
                    background-color: #EB984E;
                }

            .masterpass:hover {
                background-color: #B2BABB;
            }

            .masterpass {
                width: 100%;
                height: 50px;
                border: none;
                background-color: gray;
                margin-top: 10px;
            }

            @media only screen and (max-width: 600px) {
                .topbanner, .ordersummary, .leftcontainer {
                    height: auto;
                    width: auto;
                }
            }
        </style>
    </head>
    <body>
        <div class="topbanner">
            <asp:Label ID="Label1" runat="server" Text="ADD"></asp:Label>
            <asp:Label ID="lbl_AmtLeft" runat="server" Text="nil"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="OF ELIGIBLE ITEMS TO QUALIFY FOR FREE SHIPPING"></asp:Label>
            <asp:Label ID="lblQualify" runat="server" Text="CONGRATULATIONS! YOU QUALIFY FOR FREE SHIPPING" Visible="False"></asp:Label>
        </div>

        <div class="leftcontainer">
            <div style="text-align: center; font-family: 'Playfair Display', serif; font-size: 25px;">My Shopping Cart</div>
            <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemID" GridLines="None" ShowHeader="False" OnRowCommand="gv_CartView_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table style="border: 0.9px solid gray;">
                                <tr style="border: none;">
                                    <td style="border: none; width: 130px; padding: 20px">
                                        <asp:Image ID="imgPoster" ImageUrl='<%#Eval("Product_Image") %>' runat="server" Style="height: 220px; width: 140px;" />
                                    </td>

                                    <td style="border: none">
                                        <table>
                                            <tr style="border: none">
                                                <td style="border: none">
                                                    <asp:Label
                                                        Style="font-family: 'Poppins', sans-serif; font-size: 23px;"
                                                        ID="lblTitle"
                                                        runat="server"
                                                        Text='<%#Eval("Product_Name") %>'>
                                                    </asp:Label>
                                                    <br></br>
                                                    by
                                                    <asp:Label
                                                        Style="font-family: 'Poppins', sans-serif; font-size: 10px; color: #138D75"
                                                        ID="lblAuthor"
                                                        runat="server"
                                                        Text='<%#Eval ("Product_Author") %>'>
                                                    </asp:Label>
                                                </td>
                                            </tr>

                                            <tr style="border: none">
                                                <td>$
                                                    <asp:Label
                                                        Style="font-family: 'Poppins', sans-serif; font-size: 15px; font-weight: bold;"
                                                        ID="lblPrice"
                                                        runat="server"
                                                        Text='<%#Eval("Product_Price") %>'>
                                                    </asp:Label>
                                                    <asp:Label Style="font-size: 12px;" ID="Label3" runat="server" Text="per item"></asp:Label>
                                                </td>
                                            </tr>

                                            <tr style="border: none">
                                                <td style="border: none">
                                                    <asp:TextBox
                                                        Style="width: 15px; height: 20px; border: 0.6px solid black; padding: 5px 5px 5px 10px"
                                                        ID="tb_Quantity"
                                                        runat="server"
                                                        Text='<%# Eval("Quantity") %>'
                                                        Width="50px"
                                                        ReadOnly="False">
                                                    </asp:TextBox>
                                                    <asp:Button
                                                        Style="font-family: 'Poppins', sans-serif; border: none; width: 48px; height: 20px; font-size: 10px; margin-left: 5px;"
                                                        ID="btnUpdate"
                                                        runat="server"
                                                        Text="Update"
                                                        OnClick="btnUpdate_Click" />
                                                </td>
                                            </tr>

                                            <tr style="border: none;">
                                                <td style="font-size: 12px;">
                                                    <asp:LinkButton
                                                        Style="color: #48C9B0;"
                                                        ID="linkRemove"
                                                        runat="server"
                                                        Text="Remove"
                                                        CommandArgument='<%# Eval("ItemID") %>'
                                                        CommandName="Remove">
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>

                                            <tr style="border: none;">
                                                <td>
                                                    <p style="font-size: 10px; float: left">Choose Expedited Shipping at checkout for guaranteed delivery within 2-3 days</p>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="ordersummary">
            <div class="title" style="text-align: center; font-family: 'Playfair Display', serif; font-size: 25px;">
                Order Summary                                                                
            </div>

            <div class="detailscript" style="font-family: 'Poppins', sans-serif; font-size: 13px; float: left;">
                <p>Subtotal</p>
                <p>Estimated Shipping</p>
                <p>Estimated Tax</p>
            </div>

            <div class="pricescript" style="font-family: 'Poppins', sans-serif; font-size: 13px; float: right;">
                <p>
                    <asp:Label ID="lbl_TotalPrice" runat="server" Text="$0.00"></asp:Label>
                </p>
                <p>
                    <asp:Label ID="lbl_ShippingPrice" runat="server" Text="$0.00"></asp:Label>
                </p>
                <p>$0.00</p>
            </div>

            <div class="checkout" style="width: 100%; float: left; border-top: 0.5px solid black; border-bottom: 0.5px solid black;">
                <div class="ordertotal" style="font-size: 20px; font-weight: bold;">
                    <p style="float: left;">Order Total:</p>
                    <p style="float: right">
                        <asp:Label ID="lbl_TotalPrice2" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>

                <asp:Button ID="btnCheckOut" type="button" runat="server" Text="CHECKOUT" class="checkoutbtn" OnClick="btnCheckOut_Click" />
                <p style="font-size: 12px; text-align: center; font-weight: bold;">Or Checkout With</p>
            </div>

            <div class="altpayment">
                <div class="paypalbtn">
                    <asp:Image ID="imgPaypal" ImageUrl="images/paypal.png" runat="server" Style="width: 95px; height: 30px; float: left; margin: 11px 5px 5px 86px" />
                </div>
                <div class="masterpass">
                    <asp:Image ID="imgMasterPass" ImageUrl="images/masterpass.png" runat="server" Style="width: 105px; height: 55px; float: left; margin: 0px 5px 5px 81px" />
                </div>
            </div>
        </div>
    </body>
    </html>
</asp:Content>





<%--<div class="topbanner">
    <asp:Label ID="Label4" runat="server" Text="ADD"></asp:Label>
    <asp:Label ID="Label5" runat="server" Text="nil"></asp:Label>
    <asp:Label ID="Label6" runat="server" Text="OF ELIGIBLE ITEMS TO QUALIFY FOR FREE SHIPPING"></asp:Label>
    <asp:Label ID="Label7" runat="server" Text="CONGRATULATIONS! YOU QUALIFY FOR FREE SHIPPING" Visible="False"></asp:Label>
</div>

<div class="leftcontainer">
    <div style="text-align: center; font-family: 'Playfair Display', serif; font-size: 25px;">My Shopping Cart</div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemID" OnRowCommand="gv_CartView_RowCommand" GridLines="None" ShowHeader="false">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table style="border: 0.9px solid gray;">
                        <tr style="border: none;">
                            <td style="border: none; width: 130px; padding: 20px">
                                <asp:Image ID="imgPoster" ImageUrl='<%#Eval("Product_Image") %>' runat="server" Style="height: 220px; width: 140px;" />
                            </td>

                            <td style="border: none">
                                <table>
                                    <tr style="border: none">
                                        <td style="border: none">
                                            <asp:Label Style="font-family: 'Poppins', sans-serif; font-size: 23px;" ID="lblTitle" runat="server" Text='<%#Eval("Product_Name") %>'></asp:Label>
                                            <br></br>
                                            by
                                            <asp:Label Style="font-family: 'Poppins', sans-serif; font-size: 10px; color: #138D75" ID="lblAuthor" runat="server" Text='<%#Eval ("Product_Author") %>'></asp:Label>
                                        </td>
                                    </tr>

                                    <tr style="border: none">
                                        <td>$<asp:Label Style="font-family: 'Poppins', sans-serif; font-size: 15px; font-weight: bold;" ID="lblPrice" runat="server" Text='<%#Eval("Product_Price") %>'></asp:Label>
                                            <asp:Label Style="font-size: 12px;" ID="Label3" runat="server" Text="per item"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr style="border: none">
                                        <td style="border: none">
                                            <asp:TextBox Style="width: 15px; height: 20px; border: 0.6px solid black; padding: 5px 5px 5px 10px" ID="tb_Quantity" runat="server" Text='<%# Eval("Quantity") %>' Width="50px" ReadOnly="False"></asp:TextBox>
                                            <asp:Button Style="font-family: 'Poppins', sans-serif; border: none; width: 48px; height: 20px; font-size: 10px; margin-left: 5px;" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                        </td>
                                    </tr>

                                    <tr style="border: none;">
                                        <td style="font-size: 12px;">
                                            <asp:LinkButton Style="color: #48C9B0;" ID="linkRemove" runat="server" CommandArgument='<%# Eval("ItemID") %>' CommandName="Remove" Text="Remove"></asp:LinkButton>
                                        </td>
                                    </tr>

                                    <tr style="border: none;">
                                        <td>
                                            <p style="font-size: 10px; float: left">Choose Expedited Shipping at checkout for guaranteed delivery within 2-3 days</p>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

<div class="ordersummary">
    <div class="title" style="text-align: center; font-family: 'Playfair Display', serif; font-size: 25px;">
        Order Summary                                                                
    </div>

    <div class="detailscript" style="font-family: 'Poppins', sans-serif; font-size: 13px; float: left;">
        <p>Subtotal</p>
        <p>Estimated Shipping</p>
        <p>Estimated Tax</p>
    </div>

    <div class="pricescript" style="font-family: 'Poppins', sans-serif; font-size: 13px; float: right;">
        <p>
            <asp:Label ID="Label8" runat="server" Text="$0.00"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label9" runat="server" Text="$0.00"></asp:Label>
        </p>
        <p>$0.00</p>
    </div>

    <div class="checkout" style="width: 100%; float: left; border-top: 0.5px solid black; border-bottom: 0.5px solid black;">
        <div class="ordertotal" style="font-size: 20px; font-weight: bold;">
            <p style="float: left;">Order Total:</p>
            <p style="float: right">
                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
            </p>
        </div>

        <asp:Button ID="Button1" type="button" runat="server" Text="CHECKOUT" class="checkoutbtn" OnClick="btnCheckOut_Click" />
        <p style="font-size: 12px; text-align: center; font-weight: bold;">Or Checkout With</p>
    </div>

    <div class="altpayment">
        <div class="paypalbtn">
            <asp:Image ID="Image1" ImageUrl="images/paypal.png" runat="server" Style="width: 95px; height: 30px; float: left; margin: 11px 5px 5px 86px" />
        </div>
        <div class="masterpass">
            <asp:Image ID="Image2" ImageUrl="images/masterpass.png" runat="server" Style="width: 105px; height: 55px; float: left; margin: 0px 5px 5px 81px" />
        </div>
    </div>
</div>--%>