using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Security.Cryptography;

public partial class _2FASettings : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("TwoFactorTable"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SELECTUSER");
                cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["EmailOTP"].ToString().Equals("False"))
                    {
                        EmailOTP.Text = "Enable";
                    }
                    else
                    {
                        EmailOTP.Text = "Disable";
                    }
                    //if (reader["BackupCode"].ToString().Equals("False"))
                    //{
                    //    BackupCodes.Text = "Enable";
                    //}
                    //else
                    //{
                    //    BackupCodes.Text = "Disable";
                    //}
                    

                }
                con.Close();
                
            }
        }


    }

    protected void EmailOTP_Click(object sender, EventArgs e)
    {

        if (EmailOTP.Text.Equals("Enable"))
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("TwoFactorTable"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "UPDATEOTP");
                    cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                    cmd.Parameters.AddWithValue("@EmailOTP", "True");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    EmailOTP.Text = "Disable";
                }
            }
        }
        else
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("TwoFactorTable"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "UPDATEOTP");
                    cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                    cmd.Parameters.AddWithValue("@EmailOTP", "False");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    EmailOTP.Text = "Enable";
                }
            }
        }


    }





    //private void SendActivationEmail(string Email)
    //{
    //    string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
    //    string ActivationCode = Guid.NewGuid().ToString();
    //    using (SqlConnection con = new SqlConnection(constr))
    //    {
    //        using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES (@Email,@ActivationCode)"))
    //        {
    //            using (SqlDataAdapter sda = new SqlDataAdapter())
    //            {
    //                cmd.CommandType = CommandType.Text;
    //                cmd.Parameters.AddWithValue("@Email", txt_RegEmail.Text);
    //                cmd.Parameters.AddWithValue("@ActivationCode", ActivationCode);
    //                cmd.Connection = con;
    //                con.Open();
    //                cmd.ExecuteNonQuery();
    //                con.Close();
    //            }
    //        }
    //    }



    //    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
    //    smtpClient.Credentials = new System.Net.NetworkCredential("OzymandiasNovaLux@gmail.com", "GamestoptotheMoon42069");
    //    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
    //    smtpClient.EnableSsl = true;
    //    MailMessage mail = new MailMessage();
    //    mail.From = new MailAddress("OzymandiasNovaLux@gmail.com", "Zade's Action Figures");
    //    mail.To.Add(new MailAddress(Email));

    //    mail.Subject = "Account Activation Email";
    //    mail.Body = "<a href = " + Request.Url.AbsoluteUri.Replace("index.aspx", "AccountActivation.aspx?ActivationCode=" + ActivationCode) + "'>Click here to activate your account.<a/a>";
    //    mail.IsBodyHtml = true;
    //    smtpClient.Send(mail);
    //    Session["EmailActivation"] = Email;



    //}



    //protected void BackupCodes_Click(object sender, EventArgs e)
    //{

    //    if (BackupCodes.Text.Equals("Enable"))
    //    {
    //        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
    //        {
    //            using (SqlCommand cmd = new SqlCommand("TwoFactorTable"))
    //            {
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.Parameters.AddWithValue("@Action", "UPDATECODE");
    //                cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
    //                cmd.Parameters.AddWithValue("@BackUpCode", "True");
    //                cmd.Connection = con;
    //                con.Open();
    //                cmd.ExecuteNonQuery();
    //                con.Close();
    //                BackupCodes.Text = "Disable";
    //            }
    //        }
    //    }
    //    else
    //    {
    //        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
    //        {
    //            using (SqlCommand cmd = new SqlCommand("TwoFactorTable"))
    //            {
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.Parameters.AddWithValue("@Action", "UPDATECODE");
    //                cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
    //                cmd.Parameters.AddWithValue("@BackUpCode", "False");
    //                cmd.Connection = con;
    //                con.Open();
    //                cmd.ExecuteNonQuery();
    //                con.Close();
    //                BackupCodes.Text = "Enable";
    //            }
    //        }
    //    }

    //}
}