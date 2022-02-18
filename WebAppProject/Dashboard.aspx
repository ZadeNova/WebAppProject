<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Testing" MasterPageFile="~/AdminMaster.master" Async="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!DOCTYPE html>
    <html>
    <head>
        <title>Sunny V2</title>
        <link rel="stylesheet" type="text/css" href="assets/css/index.css" />
        <style>
                    .flex-container {
            display: flex;
            width:35%;
        }

        .flex-child {
            flex: 1;
            
        }  

        .flex-child:first-child {
            margin-right: 20px;
        } 

        #BarChart{
            width:300px;
            height:300px;
            margin-top:10%;
        }
        #PieChart{
            width:300px;
            height:300px;

        }
        </style>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

<!-- jQuery library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

<!-- Latest compiled JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

        
    </head>
    <body>

        <%--  
        <div style="width:40%">
          
            <canvas id="BarChart"></canvas>
          
        </div>--%>
                <%--<div class="flex-container">

          <div class="flex-child magenta">
            <canvas id="PieChart"></canvas>

          </div>
          <div class="flex-child magenta">
                    <canvas id="BarChart"></canvas>

                  </div>
          
         
  
        </div>--%>

        <div class="row">
          <div class="col-sm-4"><canvas id="BarChart"></canvas></div>
          <div class="col-sm-4"><canvas id="PieChart"></canvas></div>
          <div class="col-sm-4"><canvas id="LineChart" width="800" height="450"></canvas></div>
        </div>

        </body>
        
        <script>

            var arr =  <%#getchartdata()[0]%>;
            var arr_data = <%#getchartdata()[1]%>;
            var category = <%#getCategoricalSpending()[0]%>;
            var categoryspending = <%#getCategoricalSpending()[1]%>;
            var datetimechart = <%#getLineChart()[0]%>
            var pricespending = <%#getLineChart()[1]%>
            


            const data = {
                labels: arr,
                datasets: [{
                    label: 'Number of products bought',
                    backgroundColor: ['rgb(255, 99, 132)', 'rgb(54, 162, 235)', 'rgb(255, 205, 86)', 'rgb(102, 82, 255)'],

                    data: arr_data,
                }]
            };

            const config = {
                type: 'pie',
                data: data,
                options: {
                    maintainAspectRatio: false,
                    plugins: {
                        title: {
                            display: true,
                            text: 'Number of items bought for each category'
                        }
                    }

                }
            };
            const myChart = new Chart(
                document.getElementById('PieChart'),
                config
            );




        </script>
        <script>
            new Chart(document.getElementById("BarChart"), {
                type: 'bar',
                data: {
                    labels: category,
                    datasets: [
                        {
                            label: "$ (In dollars)", // in dollars
                            backgroundColor: ["#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                            data: categoryspending
                        }
                    ]
                },
                options: {
                    legend: { display: true },
                    plugins: {
                        title: {
                            display: true,
                            text: 'Total spending on each category'
                        }
                    }
                   
                }
            });
            new Chart(document.getElementById("line-chart"), {
                type: 'line',
                data: {
                    labels: [1500, 1600, 1700, 1750, 1800, 1850, 1900, 1950, 1999, 2050],
                    datasets: [{
                        data: [86, 114, 106, 106, 107, 111, 133, 221, 783, 2478],
                        label: "Africa",
                        borderColor: "#3e95cd",
                        fill: false
                    }, {
                        data: [282, 350, 411, 502, 635, 809, 947, 1402, 3700, 5267],
                        label: "Asia",
                        borderColor: "#8e5ea2",
                        fill: false
                    }, {
                        data: [168, 170, 178, 190, 203, 276, 408, 547, 675, 734],
                        label: "Europe",
                        borderColor: "#3cba9f",
                        fill: false
                    }, {
                        data: [40, 20, 10, 16, 24, 38, 74, 167, 508, 784],
                        label: "Latin America",
                        borderColor: "#e8c3b9",
                        fill: false
                    }, {
                        data: [6, 3, 2, 2, 7, 26, 82, 172, 312, 433],
                        label: "North America",
                        borderColor: "#c45850",
                        fill: false
                    }
                    ]
                },
                options: {
                    title: {
                        display: true,
                        text: 'World population per region (in millions)'
                    }
                }
            });

            for (let index = 0; index < datetimechart.length; index++) {
                var myDate = new Date(parseInt(datetimechart[index].replace(/[^0-9 +]/g, '')));

                datetimechart[index] = myDate.getFullYear() + '-' + ('0' + (myDate.getMonth() + 1)).slice(-2) + '-' + ('0' + myDate.getDate()).slice(-2);
                datetimechart[index] = datetimechart[index];
            }

           

            const linedata = {
                labels: datetimechart,
                datasets: [{
                    label: 'Spending Over Time',
                    backgroundColor: 'rgb(255, 99, 132)',
                    borderColor: 'rgb(255, 99, 132)',
                    data: pricespending,
                }]
            };

            const lineconfig = {
                type: 'line',
                data: linedata,
                options: {
                    title: {
                        display: true,
                        text: "Total spending per day ( in dollars )"
                    }
                }
            };
            const mylineChart = new Chart(
                document.getElementById('LineChart'),
                lineconfig
            );

        </script>
        </html>


    </asp:Content>
    



    



    


