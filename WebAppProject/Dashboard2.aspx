<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Dashboard2.aspx.cs" Inherits="Dashboard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!DOCTYPE html>
    <html>
    <head>
        <title>Dashboard</title>
        <link rel="stylesheet" type="text/css" href="assets/css/index.css" />
       
    </head>
    <body>
        <div class="container">
            <canvas id="BarChart"></canvas>
        </div>
          
        






        <script>
           
          
            var arr = "";
            var arr_data = "";
           const labels = [
               'January',
               'February',
               'March',
               'April',
               'May',
               'June',
           ];
           

           const data = {
               labels: arr,
               datasets: [{
                   label: 'My First dataset',
                   backgroundColor: 'rgb(255, 99, 132)',
                   borderColor: 'rgb(255, 99, 132)',
                   data: arr_data,
               }]
           };

           const config = {
               type: 'bar',
               data: data,
               options: {}
           };
           const myChart = new Chart(
               document.getElementById('BarChart'),
               config
           );
        </script>









    </body>
    </html>
    








</asp:Content>

