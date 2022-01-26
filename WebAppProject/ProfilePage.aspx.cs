using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class ProfilePage : BasePage
{
    string strConnectionString = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
    public string UserID;
    
    protected void GetUserinfo()
    {
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
                    
                    FirstNameTxt.Text = reader["First_Name"].ToString();
                    LastNameTxt.Text = reader["Last_Name"].ToString();
                    AddressTxt.Text = reader["Address"].ToString();
                    ZipcodeTxt.Text = reader["ZipCode"].ToString();
                    EmailTxtBox.Text = reader["Email"].ToString();
                    


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
        
        if (!IsPostBack)
        {
            GetUserinfo();
            
        }
        




    }

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("UserAccounts", con))
            {

                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.Parameters.AddWithValue("@First_Name", FirstNameTxt.Text);
                cmd.Parameters.AddWithValue("@Last_Name", LastNameTxt.Text);
                cmd.Parameters.AddWithValue("@Address", AddressTxt.Text);
                cmd.Parameters.AddWithValue("@ZipCode", ZipcodeTxt.Text);
                cmd.Parameters.AddWithValue("@Email", EmailTxtBox.Text);
                cmd.Parameters.AddWithValue("@UserID", Session["USERID"].ToString());

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                

                con.Close();


            }
        }

        Session["Email"] = EmailTxtBox.Text;
        Response.Write($"<script language=javascript>alert('{Session["USERID"].ToString()}')</script>");

    }
}