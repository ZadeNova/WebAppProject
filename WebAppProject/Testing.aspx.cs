using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class Testing : System.Web.UI.Page
{
    public string img,img2,img3;
    public List<string> imglist = new List<string>();
    

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


        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("UserAccounts", con))
            {

                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "CHECK");
                cmd.Parameters.AddWithValue("@Email", Session["Email"].ToString());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    img = reader[0].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Error with profile page');</script>");
                }
                con.Close();


            }
        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        
        //string strConnectionString = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(strConnectionString))
        //{

        //    con.Open();

        //    string checkPasswordQuery = "SELECT Image FROM Products WHERE ID=@ProdID";

        //    SqlCommand pwcomm = new SqlCommand(checkPasswordQuery, con);
        //    pwcomm.Parameters.AddWithValue("@ProdID",1);

        //    SqlDataReader reader = pwcomm.ExecuteReader();
        //    reader.Read();
        //    img = reader["Image"].ToString();

        //    reader.Close();
        //getimgname();
        
        
        Page.DataBind();









            //    using (SqlCommand cmd = new SqlCommand("SELECT First_Name FROM User_Accounts WHERE Email = @Email", con))
            //    {


            //        con.Open();
            //        cmd.CommandType = CommandType.Text;
            //            //cmd.Parameters.AddWithValue("@Action", "ImageName");
            //        cmd.Parameters.AddWithValue("@Email", "Zadediangelo@gmail.com");
            //        SqlDataReader reader = cmd.ExecuteReader();
            //        reader.Read();
            //        img = (reader["First_Name"].ToString());

            //            //    con.Open();
            //            //    cmd.CommandType = CommandType.StoredProcedure;
            //            //    cmd.Parameters.AddWithValue("@Action", "ImageName");
            //            //    cmd.Parameters.AddWithValue("@ProductID", intlist[i]);
            //            //    SqlDataReader reader = cmd.ExecuteReader();
            //            //    imagelist.Add(reader["Image"].ToString());

            //         con.Close();


            //        //con.Open();
            //        //cmd.CommandType = CommandType.Text;
            //        //cmd.Parameters.AddWithValue("@Action", "ImageName");
            //        //cmd.Parameters.AddWithValue("@ProductID", intlist[0]);
            //        //SqlDataReader reader = cmd.ExecuteReader();
            //        //imagelist.Add(reader["Image"].ToString());


            //    }
            //}



        }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write($"<script language=javascript>alert('{img}')</script>");
    }
}