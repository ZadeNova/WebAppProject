using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
           using( SqlCommand cmd = new SqlCommand("UserAccounts",con))
            {
                
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "CHECK");
                cmd.Parameters.AddWithValue("@Email", EmailTxtBox.Text);
                SqlDataReader reader = cmd.ExecuteReader();
               
                if (reader.Read())
                {
                    SendPasswordResetEmail(EmailTxtBox.Text);
                }
                else
                {
                    Response.Write("<script>alert('The address is either invalid , wrong or does not exist in the database');</script>");
                }
                con.Close();


            }
                
        }
        

        SendPasswordResetEmail(EmailTxtBox.Text.ToString());
    }

    protected void SendPasswordResetEmail(string Email)
    {
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.Credentials = new System.Net.NetworkCredential("OzymandiasNovaLux@gmail.com", "GamestoptotheMoon42069");
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = true;
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("OzymandiasNovaLux@gmail.com", "Zade's Action Figures");
        mail.To.Add(new MailAddress(Email));

        mail.Subject = "Password Reset Email";
        mail.Body = "<a href = " + Request.Url.AbsoluteUri.Replace("ForgotPassword.aspx", "ResetPassword.aspx") +">Click here to reset password<a/a>";
        mail.IsBodyHtml = true;
        smtpClient.Send(mail);
        Session["EmailResetPassword"] = Email;
    }


}