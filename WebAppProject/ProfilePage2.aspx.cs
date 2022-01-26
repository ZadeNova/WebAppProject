using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class ProfilePage2 : System.Web.UI.Page
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
                    UserID = reader["Id"].ToString();
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
        Response.Write($"<script>alert('{UserID}');</script>");
    }
}