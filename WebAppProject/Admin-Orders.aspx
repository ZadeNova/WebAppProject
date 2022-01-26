<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Admin-Orders.aspx.cs" Inherits="Admin_Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!DOCTYPE html>
    <html>
    <head>
        <title>Admin - Orders</title>
        <style>
            .GVcontainer {
                height: auto;
                width: 100%;
                border: 0.6px solid;
                margin-top: 40px;
                margin-bottom: 40px;
            }
        </style>
    </head>
    <body>
        <div class="GVcontainer">
            <asp:GridView ID="gvOrders" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="OrderID" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" SortExpression="OrderID" />
                    <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="ZipCode" HeaderText="ZipCode" SortExpression="ZipCode" />
                    <asp:BoundField DataField="DateTime" HeaderText="DateTime" SortExpression="DateTime" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />

                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SunnyCS %>" SelectCommand="SELECT * FROM [OrderProducts]"></asp:SqlDataSource>
        </div>
    </body>
    </html>
</asp:Content>