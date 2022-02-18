using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;
using Salt_Password_Sample;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        lblAftLogin.Text = Session["Email"].ToString();
       if (Session["TwoFAStatus"].ToString().Equals("No2FA"))
       {
            
            
            
       }
       else if (Convert.ToBoolean(Session["TwoFAStatus"]) == false)
       {
            Response.Redirect("EmailOTP");
       }

        
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["Search"] = txtSearch.Text;
        Response.Redirect("Search");
    }

    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        Session["AdminMasterPage"] = null;
        Session["UserMasterPage"] = null;
        Session.Clear();
        Response.Redirect("Home");
    }
}