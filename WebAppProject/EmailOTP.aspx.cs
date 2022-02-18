using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public partial class EmailOTP : System.Web.UI.Page
{
    public string SavedOTP;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //Session["Email"] = "lunasolprimenova@gmail.com";
       
    }




    private void SendEmailOTP(string Email)
    {
        string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        string OTPCode = OTPGenerator();   
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("TwoFactorTable"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "INSERTOTP");
                cmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                cmd.Parameters.AddWithValue("@EmailOTPCode", OTPCode);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();



            }
        }

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.Credentials = new System.Net.NetworkCredential("OzymandiasNovaLux@gmail.com", "GamestoptotheMoon42069");
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = true;
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("OzymandiasNovaLux@gmail.com", "Zade's Action Figures");
        mail.To.Add(new MailAddress(Email));
        
        mail.Subject = "Account Activation Email";
        
        mail.Body = $"Your Email OTP is {OTPCode}";
        mail.IsBodyHtml = true;
        smtpClient.Send(mail);
        



    }

    private string OTPGenerator()
    {

        

        string characterpool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
        Random rand = new Random();
        Console.WriteLine(rand.Next(0, 8));

        string OTP = "";
        for (int i = 0; i < 7; i++)
        {
            OTP = OTP + characterpool[rand.Next(0, 52)];
        }
        OTP = OTP + characterpool[rand.Next(52, 72)];


        SavedOTP = OTP;

        return OTP;

    }






    protected void SubmitOTP_Click(object sender, EventArgs e)
    {
        string OTPcodes = "";

        string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("TwoFactorTable"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SELECTOTP");
                cmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                OTPcodes = reader["EmailOTPCode"].ToString();
                System.Diagnostics.Debug.WriteLine(reader["EmailOTPCode"].ToString());
                System.Diagnostics.Debug.WriteLine(OTPtxtBox.Text);
                con.Close();
            }

            if (OTPtxtBox.Text.Equals(OTPcodes))
            {
                
                
                System.Diagnostics.Debug.WriteLine(Session["Role"].ToString());
                System.Diagnostics.Debug.WriteLine(Session["Role"].ToString().Equals("User"));
                System.Diagnostics.Debug.WriteLine("djdadadad");
                bool userflag = Session["Role"].ToString().Equals("User");
                bool adminflag = Session["Role"].ToString().Equals("Admin");
                System.Diagnostics.Debug.WriteLine(userflag);
                System.Diagnostics.Debug.WriteLine(adminflag);
                System.Diagnostics.Debug.WriteLine("below flag");
                
                using (SqlCommand cmd2 = new SqlCommand("UPDATE TwoFactorAuthenticationTable SET EmailOTPCode = @NULLVAL WHERE UserID = @UserIDD ", con))
                {
                    con.Open();
                    cmd2.Parameters.AddWithValue("@NULLVAL", DBNull.Value);
                    cmd2.Parameters.AddWithValue("@UserIDD", Session["UserID"].ToString());
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }

                if (Session["Role"].ToString().Equals("User"))
                {
                    //Response.Write($"<script language=javascript>alert('{Session["USERID"].ToString()}')</script>");
                    Session["UserMasterPage"] = "~/Afterlogin.master";
                    Session["AdminMasterPage"] = null;
                    Session["TwoFAStatus"] = true;
                    Response.Redirect("Home");
                    
                }
                else if (Session["Role"].ToString().Equals("Admin"))
                {

                    Session["AdminMasterPage"] = "~/AdminMaster.master";
                    Session["UserMasterPage"] = null;
                    Session["TwoFAStatus"] = true;
                    Response.Redirect("Home");
                    Response.Write($"<script language=javascript>alert('Hello there Admin!')</script>");
                    
                }


            }
            else
            {
                System.Diagnostics.Debug.WriteLine("no");
                Response.Write($"<script language=javascript>alert('Email OTP is not correct')</script>");
            }


        }



        

       
    }

    protected void GenerateOTP_Click(object sender, EventArgs e)
    {
        SendEmailOTP(Session["Email"].ToString());
        Response.Write($"<script language=javascript>alert('Email OTP has been sent')</script>");

    }
}