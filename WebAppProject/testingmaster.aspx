<%@ Page Title="" Language="C#" MasterPageFile="~/Afterlogin.master" AutoEventWireup="true" CodeFile="testingmaster.aspx.cs" Inherits="testingmaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />

    <div id="google_translate_element"></div>

   <script type="text/javascript">
       function googleTranslateElementInit() {
           new google.translate.TranslateElement({ pageLanguage: 'en' }, 'google_translate_element');
       }
   </script>

<script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>

</asp:Content>

