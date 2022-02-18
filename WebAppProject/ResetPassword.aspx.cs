using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Salt_Password_Sample;

public partial class ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ResetPassword_Click(object sender, EventArgs e)
    {
        if (NewPass.Text.Equals(CfmNewPass.Text))
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE User_Accounts SET Password = @NewPassword WHERE Email = @Email", conn);
            string NewHashPass = Hash.ComputeHash(NewPass.Text, "SHA512", null);
            cmd.Parameters.AddWithValue("@Email", Session["EmailResetPassword"].ToString());
            cmd.Parameters.AddWithValue("@NewPassword", NewHashPass);
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Your Password has been successfully updated');</script>");
            Response.Redirect("Home");
        }
        else
        {
            Notthesame.Visible = true;
        }
    }



}