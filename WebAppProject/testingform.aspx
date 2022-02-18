<%@ Page Title="" Language="C#" MasterPageFile="~/Others.master" AutoEventWireup="true" CodeFile="testingform.aspx.cs" Inherits="testingform" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <!DOCTYPE html>
    <html>
        <head>
            <title>

            </title>
            
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
            

<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
            <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
            <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
            <style>
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
            </style>
            

        </head>
        <body>
                           
           <div style="width:50%">

  <canvas id="myChart"></canvas>
               <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdownlist">
                   <asp:ListItem Value="">Please Select</asp:ListItem>  
                   <asp:ListItem Text="DC" Value="DC"></asp:ListItem>  
                     

               </asp:DropDownList>
              
</div>
			
        </body>
        <script>

            $(document).ready(function () {
                $('#tbDate').datepicker({
                    dateFormat: 'dd/mm/yy'
                });
            });

            const thedates = <%=testingform_aspx.getchartdate()[0]%>;
            const numba = <%=getchartdate()[1]%>;
            

            for (let index = 0; index < thedates.length; index++) {
                var myDate = new Date(parseInt(thedates[index].replace(/[^0-9 +]/g, '')));
                
                /*thedates[index] = ('0' + myDate.getDate()).slice(-2) + '-' + ('0' + (myDate.getMonth() + 1)).slice(-2) + '-' + myDate.getFullYear();*/
                thedates[index] = myDate.getFullYear() + '/' + ('0' + (myDate.getMonth() + 1)).slice(-2) + '/' + ('0' + myDate.getDate()).slice(-2);
                thedates[index] = thedates[index];
                
            }

            



            const labels = [
                'January',
                'February',
                'March',
                'April',
                'May',
                'June',
            ];

            const data = {
                labels: thedates,
                datasets: [{
                    label: 'Spending Over Time',
                    backgroundColor: 'rgb(255, 99, 132)',
                    borderColor: 'rgb(255, 99, 132)',
                    data: numba,
                }]
            };

            const config = {
                type: 'line',
                data: data,
                options: {}
            };
            
            
            
        </script>
        <script>
            const myChart = new Chart(
                document.getElementById('myChart'),
                config
            );
        </script>
    </html>
</asp:Content>
