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
        if (Session["Role"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else if (Session["Role"].ToString().Equals("User"))
        {
            Response.Redirect("index.aspx");
        }
    }



    protected void SignOut_Click(object sender, EventArgs e)
    {
        Session["AdminMasterPage"] = null;
        Session["UserMasterPage"] = null;
        Session.Clear();
        Response.Redirect("index.aspx");
    }
}