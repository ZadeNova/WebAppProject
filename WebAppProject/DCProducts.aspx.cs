using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class DCProducts : BasePage
{
    

    protected void Page_Load(object sender, EventArgs e)
    {

        //Response.Write(Session["Email"].ToString());

        //DataSet is an in-memory cache of data retrieved from a data source
        //step 1: create Dataset with a GET method
        DataTable datadcproducts = GetDCProducts();


        //DataSource is used to pull the data from the database and populate them
        //step 8: pull data using DataSource
        Repeater1.DataSource = datadcproducts;
        

        //step 9: bind the data to the repeater
        Repeater1.DataBind();
        //Response.Write($"<script language=javascript>alert('{Session["Role"]}')</script>");
        //Response.Write($"<script language=javascript>alert('{Session["AdminMasterPage"]}')</script>");
        //Response.Write($"<script language=javascript>alert('{Session["UserMasterPage"]}')</script>");

    }


    private DataTable GetDCProducts()
    {
        string SunnyCS = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(SunnyCS))
        {
            //step 4: create a command to retrieve data from a table in your database
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM Products WHERE Type = 'DC'", conn);

            //step 5: create a new DataSet
            DataTable datadcproduct = new DataTable();

            //step 6: pass the retrieved data into the newly created Dataset
            cmd.Fill(datadcproduct);
            //datadcproduct.Select("Type = 'DC'");

            //step 7: return
            return datadcproduct;
        }
    }

    







}