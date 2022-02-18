using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using System.Web.Script.Serialization;
public partial class testingform : System.Web.UI.Page
{

    public DateTime dat = DateTime.Now;
    JavaScriptSerializer ser = new JavaScriptSerializer();
    public string date1, date2;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        var datas = getchartdate();
        Session.Clear();
        
        
    }


    public static string[] getchartdate()
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
        string[] datas = { xaxis , numbers};
        return datas;

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
}