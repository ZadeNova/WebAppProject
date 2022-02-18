using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

public partial class Testing : System.Web.UI.Page
{
    public string img,img2,img3;
    public List<string> imglist = new List<string>();
    protected string googleplus_client_id = "798122882448-5rcd832ksd2kjamq8h5qa1tl5hfof1hi.apps.googleusercontent.com";
    protected string googleplus_client_secret = "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";
    protected string googleplus_redirect_url = "http://localhost:10068/Testing.aspx";
    protected string Parameters;
    
    public List<int> intlist = new List<int>();
    protected void getimgname()
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(strConnectionString))
        //{
        //    using (SqlCommand cmd = new SqlCommand("SELECT Id FROM User_Accounts", con))
        //    {

        //        con.Open();
        //        cmd.CommandType = CommandType.Text;
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            imglist.Add(reader[0].ToString());
        //        }
        //        //img = reader["Image"].ToString();
        //        //img2 = reader.GetString(1);
        //        //img3 = reader.GetString(2);
        //        con.Close();


        //    }
        //}




        //}
    }
    


    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        intlist.Add(1);
        intlist.Add(2);
        intlist.Add(3);
        intlist.Add(4);
        intlist.Add(5);
        intlist.Add(6);
        img = "fuckgsf";
        //HiddenField1.Value = Newtonsoft.Json.JsonConvert.SerializeObject(intlist);
        //Label1.Text = Newtonsoft.Json.JsonConvert.SerializeObject(intlist);

        getCategoricalSpending();
        Page.DataBind();
     }



    public static string[] getstuff()
    {
        string[] cat = { "Volvo", "BMW", "Ford", "Mazda" };
        int[] values = { 10, 20, 30, 40 };
        JavaScriptSerializer ser = new JavaScriptSerializer();
        string name = ser.Serialize(cat);
        string ok = ser.Serialize(values);
        string[] arty = { name, ok };
        return arty;

    }


    public static string[] getchartdata()

    {

        List<string> dtlist = new List<string>();
        dtlist.Add("DC");
        dtlist.Add("Anime");
        dtlist.Add("Marvel");
        dtlist.Add("StarWars");
        List<int> nolist = new List<int>();
        using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Sum(DC) AS DC, Sum(Anime) AS Anime, Sum(Marvel) AS Marvel,Sum(StarWars) AS StarWars FROM OrderProducts", con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                nolist.Add(Convert.ToInt32(reader["DC"]));
                nolist.Add(Convert.ToInt32(reader["Anime"]));
                nolist.Add(Convert.ToInt32(reader["Marvel"]));
                nolist.Add(Convert.ToInt32(reader["StarWars"]));
            }
            con.Close();
        }

        JavaScriptSerializer ser = new JavaScriptSerializer();
        string date = ser.Serialize(dtlist);
        string number = ser.Serialize(nolist);
        string[] datas = { date , number };
        return datas;
    }



    public static string[] getCategoricalSpending()
    {
        List<string> dtlist = new List<string>();
        dtlist.Add("DC");
        dtlist.Add("Anime");
        dtlist.Add("Marvel");
        dtlist.Add("StarWars");
        List<decimal> nolist = new List<decimal>();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Sum(DCPrice) AS DC, Sum(AnimePrice) AS Anime, Sum(MarvelPrice) AS Marvel,Sum(StarWarsPrice) AS StarWars FROM CategorySpending", con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                nolist.Add(Convert.ToInt32(reader["DC"]));
                nolist.Add(Convert.ToInt32(reader["Anime"]));
                nolist.Add(Convert.ToInt32(reader["Marvel"]));
                nolist.Add(Convert.ToInt32(reader["StarWars"]));
            }
            con.Close();
        }

        JavaScriptSerializer ser = new JavaScriptSerializer();
        string xaxis = ser.Serialize(dtlist);
        string numbers = ser.Serialize(nolist);
        string[] datas = { xaxis, numbers };
        return datas;

    }



    public static string[] getLineChart()
    {

        List<DateTime> dtlist = new List<DateTime>();
        //dtlist.Add("DC");
        //dtlist.Add("Anime");
        //dtlist.Add("Marvel");
        //dtlist.Add("StarWars");
        List<decimal> nolist = new List<decimal>();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT DATETIME , SUM(Price) AS TotalPrice FROM (SELECT CAST(DateTime AS DATE) AS DATETIME , Price AS Price FROM OrderProducts) a GROUP BY DATETIME", con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    dtlist.Add(Convert.ToDateTime(reader["DATETIME"]));
                    nolist.Add(Convert.ToDecimal(reader["TotalPrice"]));
                }

            }
            con.Close();
        }
        //dtlist.Add(DateTime.Now);
        //dtlist.Add(DateTime.Now.AddDays(-1));
        //dtlist.Add(DateTime.Now.AddDays(-2));
        //dtlist.Add(DateTime.Now.AddDays(-3));
        //dtlist.Add(DateTime.Now.AddDays(-4));
        //dtlist.Add(DateTime.Now.AddDays(-5));
        foreach (var i in dtlist)
        {
            System.Diagnostics.Debug.WriteLine(i);
            System.Diagnostics.Debug.WriteLine("dada");
        }

        //nolist.Add(1);
        //nolist.Add(24);
        //nolist.Add(35);
        //nolist.Add(12);
        //nolist.Add(2);
        JavaScriptSerializer ser = new JavaScriptSerializer();
        string xaxis = ser.Serialize(dtlist);
        string numbers = ser.Serialize(nolist);
        string[] datas = { xaxis, numbers };
        return datas;

    }




    [WebMethod]
    public static List<object> GetChart()
    {
        List<object> chartData = new List<object>();
        string query = "SELECT DateTime FROM OrderProducts";
        DataTable dtYears = GetData(query);
        List<DateTime> labels = new List<DateTime>();
        foreach (DataRow row in dtYears.Rows)
        {
            labels.Add(Convert.ToDateTime(row["DateTime"]));
        }
        chartData.Add(labels);

        query = "SELECT Price FROM OrderProducts";
        DataTable dtCountry1 = GetData(query);

        List<int> series1 = new List<int>();
        foreach (DataRow row in dtCountry1.Rows)
        {
            series1.Add(Convert.ToInt32(row["Price"]));
        }
        chartData.Add(series1);

       

        return chartData;
    }

    private static DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }


}