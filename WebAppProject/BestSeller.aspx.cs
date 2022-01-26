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

public partial class BestSeller : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //DataSet is an in-memory cache of data retrieved from a data source
        //step 1: create Dataset with a GET method
        DataSet datathriller = GetDataThriller();
        DataSet datafiction = GetDataFiction();
        DataSet datapaperbacks = GetDataPaperbacks();
        DataSet datayoungreaders = GetDataYoungReaders();
        DataSet datateens = GetDataTeens();

        //DataSource is used to pull the data from the database and populate them
        //step 8: pull data using DataSource
        Repeater1.DataSource = datathriller;
        Repeater2.DataSource = datafiction;
        Repeater3.DataSource = datapaperbacks;
        Repeater4.DataSource = datayoungreaders;
        Repeater5.DataSource = datateens;

        //step 9: bind the data to the repeater
        Repeater1.DataBind();
        Repeater2.DataBind();
        Repeater3.DataBind();
        Repeater4.DataBind();
        Repeater5.DataBind();
    }

    private DataSet GetDataThriller()
    {
        //step 2: retrieve connection info from web.config
        string SunnyCS = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;

        //step 3: define a connection to the database
        using (SqlConnection conn = new SqlConnection(SunnyCS))
        {
            //step 4: create a command to retrieve data from a table in your database
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM BS_Thriller", conn);

            //step 5: create a new DataSet
            DataSet datathriller = new DataSet();

            //step 6: pass the retrieved data into the newly created Dataset
            cmd.Fill(datathriller);

            //step 7: return
            return datathriller;
        }
    }

    private DataSet GetDataFiction()
    {
        string SunnyCS = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(SunnyCS))
        {
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM BS_Fiction", conn);
            DataSet datafiction = new DataSet();
            cmd.Fill(datafiction);
            return datafiction;
        }
    }

    private DataSet GetDataPaperbacks()
    {
        string SunnyCS = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(SunnyCS))
        {
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM BS_Paperbacks", conn);
            DataSet datapaperbacks = new DataSet();
            cmd.Fill(datapaperbacks);
            return datapaperbacks;
        }
    }

    private DataSet GetDataYoungReaders()
    {
        string SunnyCS = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(SunnyCS))
        {
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM BS_YoungReaders", conn);
            DataSet datayoungreaders = new DataSet();
            cmd.Fill(datayoungreaders);
            return datayoungreaders;
        }
    }

    private DataSet GetDataTeens()
    {
        string SunnyCS = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(SunnyCS))
        {
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM BS_Teens", conn);
            DataSet datateens = new DataSet();
            cmd.Fill(datateens);
            return datateens;
        }
    }
}







