<%@ Page Title="" Language="C#" MasterPageFile="~/Others.master" AutoEventWireup="true" CodeFile="EmailOTP.aspx.cs" Inherits="EmailOTP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Enter your Email OTP that you have received"></asp:Label>
    <br />
    <asp:TextBox ID="OTPtxtBox" runat="server"></asp:TextBox>
    <br />
    <div>
        <asp:Button ID="SubmitOTP" runat="server" Text="Submit OTP" OnClick="SubmitOTP_Click"/>
         <asp:Button ID="GenerateOTP" runat="server" Text="Generate OTP" OnClick="GenerateOTP_Click"/>


    </div>
    

</asp:Content>


