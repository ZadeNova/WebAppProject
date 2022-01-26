using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

public partial class index : BasePage
{


    public string Hello = "";
    public string img1, img2, img3, img4;
    public List<int> intlist = new List<int>();
    public List<string> imagelist = new List<string>();
    Random random = new Random();

    protected int RandomNumGen(int TotalNoProduct)
    {

        int num = random.Next(1, TotalNoProduct);
        return num;
    }


    protected int GetTotalNumProducts()
    {
        int TotalProductNum;
        string strConnectionString = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Products", con))
            {
                con.Open();
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@Action", "COUNT");
                //SqlDataReader reader = cmd.ExecuteReader();
                //TotalProductNum = Convert.ToInt32(reader["TOTAL"]);
                TotalProductNum = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                con.Close();



            }
        }
        
        return TotalProductNum;
    }
    
    protected void GetImageNames()

    {
        
        
        string strConnectionString = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Image FROM Products WHERE ID=@ProdID", con))
            {
                for (int i = 0; i < intlist.Count; i++)
                {
                    cmd.Parameters.Clear();

                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("@Action", "ImageName");
                    cmd.Parameters.AddWithValue("@ProdID", intlist[i]);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    imagelist.Add(reader["Image"].ToString());
                    reader.Close();
                   

                    con.Close();
                }

               


            }
        }

        
    }


    protected void getimgname()
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 3 Image FROM Products ORDER BY newid()", con))
            {

                con.Open();
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    imagelist.Add(reader[0].ToString());
                }

                con.Close();
                //for (int i = 0; i < intlist.Count; i++)
                //{
                //    cmd.Parameters.Clear();

                //    con.Open();
                //    cmd.CommandType = CommandType.Text;
                //    //cmd.Parameters.AddWithValue("@Action", "ImageName");
                //    cmd.Parameters.AddWithValue("@ProdID", intlist[i]);
                //    SqlDataReader reader = cmd.ExecuteReader();
                //    reader.Read();
                //    imagelist.Add(reader["Image"].ToString());
                //    reader.Close();

                //    con.Close();
                //}

            }
        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {

        //int TotalNo = GetTotalNumProducts();


        //for (int i = 0; i < 3; i++)
        //{
        //    int num = RandomNumGen(TotalNo);
        //    if (!intlist.Contains(num))
        //    {
        //        intlist.Add(RandomNumGen(num));
        //    }
            
            
            

        //}
        getimgname();
        img1 = imagelist[0];
        img2 = imagelist[1];
        img3 = imagelist[2];
        //img4 = imagelist[3];
        Hello = "";
        

        Page.DataBind();
    }
}