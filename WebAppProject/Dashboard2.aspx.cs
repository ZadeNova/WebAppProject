using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    public static string[] getchartdata()

    {

        List<string> dtlist = new List<string>();
        dtlist.Add("DC");
        dtlist.Add("Anime");
        dtlist.Add("Marvel");
        dtlist.Add("StarWars");
        List<int> nolist = new List<int>();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
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
        string[] datas = { date, number };
        return datas;
    }


}