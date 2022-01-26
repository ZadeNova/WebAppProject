using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;
using Salt_Password_Sample;
using System.Data;
using System.IO;
using System.Net;
using System.Web.Services;
using System.Net.Mail;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected static string ReCaptcha_Key = "6LcRAzQeAAAAAFdzy0SeKx01y3qevwqhp2V4F9rg";
    protected static string ReCaptcha_Secret = "6LcRAzQeAAAAAInuhck8OoyiaTWuMcB67dzcHdS1";
    bool isCaptchaValid;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            
            var encodedResponse = Request.Form["g-Recaptcha-Response"];
            isCaptchaValid = ReCaptcha.Validate(encodedResponse);
            Console.WriteLine(isCaptchaValid);

        }
    }

    public class ReCaptcha
    {
        public bool Success { get; set; }
        public List<string> ErrorCodes { get; set; }
        public static bool Validate(string encodedResponse)
        {
            if (string.IsNullOrEmpty(encodedResponse)) return false;

            var client = new System.Net.WebClient();
            var secret = "6LcRAzQeAAAAAInuhck8OoyiaTWuMcB67dzcHdS1";
            var googleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, encodedResponse));
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var reCaptcha = serializer.Deserialize<ReCaptcha>(googleReply);
            return reCaptcha.Success;
        }
    }




    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["Search"] = txtSearch.Text;
        Response.Redirect("Search.aspx");
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Guid newGUID = Guid.NewGuid();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString);
        
        conn.Open();

        bool exists = false;

        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [User_Accounts] WHERE Email = @email", conn))
        {
            //checks if the email that the user has entered exists in the database table
            cmd.Parameters.AddWithValue("Email", txt_RegEmail.Text);
            exists = (int)cmd.ExecuteScalar() > 0;
        }
        
        //if the email exists, send an alert
        if (exists)
        {
            Response.Write("<script>alert('Sorry, Email is already taken!');</script>");
        }

        //else, insert 
        else
        {
            
            string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UserAccounts"))
                {
                    string ePass = Hash.ComputeHash(txt_RegPassword.Text, "SHA512", null);
                    cmd.Parameters.AddWithValue("@Action", "INSERT");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", newGUID.ToString());
                    cmd.Parameters.AddWithValue("@First_Name", txt_FirstName.Text);
                    cmd.Parameters.AddWithValue("@Last_Name", txt_LastName.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_RegEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", ePass);
                    cmd.Parameters.AddWithValue("@Role", "User");
                    
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    SendActivationEmail(txt_RegEmail.Text);
                    Response.Write("<script>alert('Successfully created account! Welcome! ');</script>");
                }


            }





        }

        conn.Close();

        txt_FirstName.Text = "";
        txt_LastName.Text = "";
        txt_RegEmail.Text = "";
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        



        string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("UserAccounts"))
            {
                
                cmd.Parameters.AddWithValue("@Action", "LOGIN");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", txt_Email.Text);
                
                cmd.Connection = con;
                con.Open();
                
                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    bool flag = Hash.VerifyHash(txt_Password.Text, "SHA512", reader["Password"].ToString());//verifies password through hash function
                    
                    if (flag == true)
                    {

                        if (reader["ActivationStatus"].ToString().Equals("True"))
                        {


                            if (!isCaptchaValid) 
                            {
                                Response.Write("<script language=javascript>alert('Please click on the recaptcha.')</script>");
                            
                            }
                            else
                            {
                                Session["USERID"] = reader["Id"].ToString(); 
                                Session["Email"] = reader["Email"].ToString();
                                Session["Role"] = reader["Role"].ToString();
                                // CHECK IF Account IS ADMIN OR USER
                                var a = (string)Session["Role"];
                                if (Session["Role"].ToString().Equals("User"))
                                {
                                    //Response.Write($"<script language=javascript>alert('{Session["USERID"].ToString()}')</script>");
                                    Session["UserMasterPage"] = "~/Afterlogin.master";
                                    Session["AdminMasterPage"] = null;
                                    txt_Email.Text = "";
                                    txt_Password.Text = "";
                                    Response.Redirect(Request.Url.AbsoluteUri);
                                }
                                else
                                {

                                    Session["AdminMasterPage"] = "~/AdminMaster.master";
                                    Session["UserMasterPage"] = null;
                                    Response.Redirect(Request.Url.AbsoluteUri);
                                    //Response.Write($"<script language=javascript>alert('Hello there Admin!')</script>");
                                    txt_Email.Text = "";
                                    txt_Password.Text = "";
                                }
                            }


                            
                        }
                        else
                        {
                            Response.Write("<script language=javascript>alert('Account is not activated')</script>");
                        }

                        
                        

                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Password or UserName is not correct')</script>");
                        txt_Email.Text = "";
                        txt_Password.Text = "";
                    }

                    
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Account does not exist!')</script>");
                }
                reader.Close();
                
                con.Close();

                //Response.Write("<script>alert('Successfully created account! Welcome! ');</script>");

                txt_Email.Text = "";
                txt_Password.Text = "";
            }
        }















    }

    protected void btnAdminSignIn_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString);

        conn.Open();

        string checkuser = "SELECT COUNT(*) FROM [ADMIN] WHERE Email = @email";

        SqlCommand com = new SqlCommand(checkuser, conn);
        com.Parameters.AddWithValue("@email", txt_AdminEmail.Text);

        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());

        conn.Close();

        if (temp == 1)
        {
            conn.Open();

            string checkPasswordQuery = "SELECT AdminID, Password FROM [ADMIN] WHERE Email = @email2";

            SqlCommand pwcomm = new SqlCommand(checkPasswordQuery, conn);
            pwcomm.Parameters.AddWithValue("@email2", txt_AdminEmail.Text);

            SqlDataReader reader = pwcomm.ExecuteReader();
            reader.Read();
            string password = reader["Password"].ToString();
            string UserId = reader["AdminID"].ToString();
            reader.Close();

            if (password == txt_AdminPassword.Text)
            {
                Session["Email"] = UserId.ToString();
                Response.Redirect("Admin-index.aspx");
                
            }
            else
            {
                reader.Close();
                Response.Write("<script language=javascript>alert('Password or Username is not correct')</script>");
            }
        }
        else
        {
            Response.Write("<script language=javascript>alert('Password or UserName is not correct')</script>");
        }

        txt_AdminEmail.Text = "";
    }

    private void SendActivationEmail(string Email)
    {
        string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        string ActivationCode = Guid.NewGuid().ToString();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES (@Email,@ActivationCode)"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Email", txt_RegEmail.Text);
                    cmd.Parameters.AddWithValue("@ActivationCode", ActivationCode);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
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
        mail.Body = "<a href = " + Request.Url.AbsoluteUri.Replace("index.aspx", "AccountActivation.aspx?ActivationCode=" + ActivationCode) + "'>Click here to activate your account.<a/a>";
        mail.IsBodyHtml = true;
        smtpClient.Send(mail);
        Session["EmailActivation"] = Email; 
        
    
    
    }




    protected void Unnamed_ServerClick(object sender, EventArgs e) // This is shopping cart tag.
    {
        //check if user login into site
        if (Session["Email"] == null)
        {
            Response.Write("<script language=javascript>alert('Log in to view the shopping cart')</script>");
        }

    }
}