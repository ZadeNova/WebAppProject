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


public partial class AnimeProducts : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dataanimeproducts = GetAnimeProducts();


        //DataSource is used to pull the data from the database and populate them
        //step 8: pull data using DataSource
        Repeater1.DataSource = dataanimeproducts;


        //step 9: bind the data to the repeater
        Repeater1.DataBind();
    }

    private DataTable GetAnimeProducts()
    {
        string SunnyCS = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(SunnyCS))
        {
            //step 4: create a command to retrieve data from a table in your database
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM Products WHERE Type = 'Anime'", conn);

            //step 5: create a new DataSet
            DataTable dataanimeproduct = new DataTable();

            //step 6: pass the retrieved data into the newly created Dataset
            cmd.Fill(dataanimeproduct);
            

            //step 7: return
            return dataanimeproduct;
        }
    }



}