<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Admin-CreateProduct.aspx.cs" Inherits="Admin_InsertThriller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!DOCTYPE html>
    <html>
    <head>
        <style>
            .insertcontainer {
                margin: 20px auto;
                padding: 20px;
                height: 100%;
                width: 50%;
                border: 0.5px solid;
            }

            .textboxes {
                width: 100% !important;
                height: 30px !important;
                border: 0.5px solid !important;
            }

            .labels {
                font-size: 12px;
                font-family: 'Poppins', sans-serif;
            }

            .btns {
                width: 46%;
                height: 30px;
                padding: 5px;
                border: 0.5px solid;
                background-color: yellow;
            }

            tr {
                border: none;
            }

            .pgdesc {
                text-align: center;
                font-size: 28px;
                font-family: 'Playfair Display', serif;
                color: black;
                margin-top: 30px;
            }

            .pgdesc2 {
                text-align: center;
                font-size: 12px;
                font-family: 'Poppins', sans-serif;
                color: black;
                margin-top: 5px;
            }

            .dropdownlist {

            color:Snow;
            background-color:#005c99;
            font-family:Comic Sans MS;
            font-size:large;
            font-style:italic;
            display:inline;
            width:45%;
            border-radius:5px;
            border-style:double;

            }

            .ValidatorMsg {
                font-family:Comic Sans MS;
                font-size:medium;
                font-style:italic;
                color:darkred;
            }

        </style>
    </head>

    <body>
        <div class="pgdesc">
            Create Product
        </div>
        <div class="pgdesc2">
            
        </div>
        <div class="insertcontainer">
            <table>
               
                <tr>
                    <td>
                        <asp:Label CssClass="labels" ID="Label1" runat="server" Text="Product Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox CssClass="textboxes" ID="ZadeProdName" runat="server"></asp:TextBox>
                    </td>
                </tr>
              
                <tr>
                    <td>
                        <asp:Label CssClass="labels" ID="Label3" runat="server" Text="Unit Price"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Style="width: 30%; height: 30px; border: 0.5px solid" ID="ZadeProdPrice" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label CssClass="labels" ID="Label4" runat="server" Text="Type of Product"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ZadeProdType" runat="server" CssClass="dropdownlist">
                            <asp:ListItem Value="">Please Select</asp:ListItem>  
                            <asp:ListItem Text="DC" Value="DC"></asp:ListItem>  
                            <asp:ListItem Text="Marvel" Value="Marvel"></asp:ListItem>  
                            <asp:ListItem Text="Anime" Value="Anime"></asp:ListItem>  
                            <asp:ListItem Text="StarWars" Value="StarWars"></asp:ListItem>  
                            <asp:ListItem Text="Keychain" Value="Keychain"></asp:ListItem>  
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="ValidatorMsg" runat="server" ControlToValidate="ZadeProdType" ErrorMessage="Please choose the type of product"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label CssClass="labels" ID="Label5" runat="server" Text="Image"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label CssClass="labels" ID="Label6" runat="server" Text="Description"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Style="width: 100%; height: 80px; border: 0.5px solid" ID="ZadeProdDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button CssClass="btns" ID="btnInsertItems" runat="server" Text="Insert" OnClick="btnInsertItems_Click" />
                        <asp:Button CssClass="btns" ID="btnBack" runat="server" Text="Back" BackColor="#66FFFF" OnClick="btnBack_Click" CausesValidation="false" />
                    </td>
                </tr>
            </table>
        </div>
    </body>
    </html>
</asp:Content>