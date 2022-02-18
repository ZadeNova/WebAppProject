using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        Product prod = new Product();
        string categoryID = gvUsers.DataKeys[e.RowIndex].Value.ToString();
        result = prod.UserDelete(categoryID);

        using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM TwoFactorAuthenticationTable WHERE UserID=@ID",con))
            {
                cmd.Parameters.AddWithValue("@ID", categoryID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }



        if (result > 0)
        {
            Response.Write("<script>alert('User Removed successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('User Removal NOT successful');</script>");
        }

        Response.Redirect("ManageUsers");
    }
}