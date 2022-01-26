using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class AccountActivation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!this.IsPostBack)
        {
            bool flag = false;
            string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
            string ActivationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"]) ? Request.QueryString["ActivationCode"] : Guid.Empty.ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM UserActivation WHERE ActivationCode = @ActivationCode"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ActivationCode", ActivationCode);
                        cmd.Connection = con;
                        con.Open();
                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                        if (rowsAffected == 1)
                        {
                            ActivationMessage.Text = "Activation Successful";
                            flag = true;
                            using (SqlConnection con2 = new SqlConnection(constr))
                            {
                                using (SqlCommand cmd2 = new SqlCommand("UPDATE User_Accounts SET ActivationStatus = 'True' WHERE Email = @Email"))
                                {
                                    using (SqlDataAdapter sda2 = new SqlDataAdapter())
                                    {
                                        cmd2.CommandType = CommandType.Text;
                                        cmd2.Parameters.AddWithValue("@Email", Session["EmailActivation"].ToString());
                                        cmd2.Connection = con2;
                                        con2.Open();
                                        cmd2.ExecuteNonQuery();
                                        con2.Close();
                                        Session.Clear();
                                    }
                                }
                            }
                        }
                        else
                        {
                            ActivationMessage.Text = "Invalid Activation code";
                        }
                    }
                }
            }

            //if (flag == true)
            //{
            //    using (SqlConnection con2 = new SqlConnection(constr))
            //    {
            //        using (SqlCommand cmd2 = new SqlCommand("UPDATE UserAccounts SET ActivationStatus = 'True' WHERE Email = @Email"))
            //        {
            //            using (SqlDataAdapter sda2 = new SqlDataAdapter())
            //            {
            //                cmd2.CommandType = CommandType.Text;
            //                cmd2.Parameters.AddWithValue("@Email", Session["EmailActivation"].ToString());
            //                cmd2.Connection = con;
            //                con2.Open();
            //                cmd2.ExecuteNonQuery();
            //                con2.Close();
            //            }
            //        }
            //    }
            //}





        }


    }
}