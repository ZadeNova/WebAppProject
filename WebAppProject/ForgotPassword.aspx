<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" MasterPageFile="~/Others.master" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <!DOCTYPE html>

<html>
<head>
    <title></title>
</head>
<body>
    
        <div>
            <asp:Label ID="Label1" runat="server" Text="Forgot your password?"></asp:Label>
            <p>Please enter your email below and your will receive instructions in your email</p>
            <asp:TextBox ID="EmailTxtBox" runat="server"></asp:TextBox>
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
            



        </div>
    
</body>
</html>

</asp:Content>

