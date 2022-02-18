<%@ Page Title="" Language="C#" MasterPageFile="~/Afterlogin.master" AutoEventWireup="true" CodeFile="2FASettings.aspx.cs" Inherits="_2FASettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!DOCTYPE html>
    <html>
    <head>
        <title>2FA Settings</title>
        <style>
            

        </style>
   
        </head>
        <body>
            <div style="text-align:center">
                <asp:Label ID="Label1" class="labelcenter" runat="server" Text="Enable email 2FA"></asp:Label>
            <br />
    <asp:Button ID="EmailOTP" CssClass="btn" runat="server" Text="Enable" OnClick="EmailOTP_Click"/>

            </div>
            
        </body>

        </html>
    

    
    





</asp:Content>

