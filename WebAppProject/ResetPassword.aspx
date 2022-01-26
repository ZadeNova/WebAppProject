<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" MasterPageFile="~/Others.master" %>


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

            <asp:Label ID="Label1" runat="server" Text="Reset your password"></asp:Label>
            <asp:Label ID="Notthesame" runat="server" Text="Passwords are not the same.Please try again" Visible="false"></asp:Label>
            <asp:TextBox ID="NewPass" runat="server"></asp:TextBox>
            <asp:TextBox ID="CfmNewPass" runat="server"></asp:TextBox>
            <asp:Button ID="ResetPasswordBtn" runat="server" Text="Reset Password" OnClick="ResetPassword_Click"/>



        </div>
    
</body>
</html>

</asp:Content>

