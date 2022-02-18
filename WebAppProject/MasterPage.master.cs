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


using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Text;

public partial class MasterPage : System.Web.UI.MasterPage
{
    
    protected static string ReCaptcha_Key = "6LcRAzQeAAAAAFdzy0SeKx01y3qevwqhp2V4F9rg";
    protected static string ReCaptcha_Secret = "6LcRAzQeAAAAAInuhck8OoyiaTWuMcB67dzcHdS1";
    protected string googleplus_client_id = "798122882448-5rcd832ksd2kjamq8h5qa1tl5hfof1hi.apps.googleusercontent.com";
    protected string googleplus_client_secret = "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";
    protected string googleplus_redirect_url = "http://localhost:10068/index2.aspx";
    protected string Parameters;
    bool isCaptchaValid;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        
        //var url = Request.Url.Query;
        //if (url != "")
        //{
        //    string queryString = url.ToString();
        //    char[] delimiterChars = { '=' };
        //    string[] words = queryString.Split(delimiterChars);
        //    string code = words[1];
        //    if (code != null)
        //    {
        //        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
        //        webRequest.Method = "POST";
        //        Parameters = "code=" + code + "&client_id=" + googleplus_client_id + "&client_secret=" + googleplus_client_secret + "&redirect_uri=" + googleplus_redirect_url + "&grant_type=authorization_code";
        //        byte[] byteArray = Encoding.UTF8.GetBytes(Parameters);
        //        webRequest.ContentType = "application/x-www-form-urlencoded";
        //        webRequest.ContentLength = byteArray.Length;
        //        Stream postStream = webRequest.GetRequestStream();
        //        // Add the post data to the web request
        //        postStream.Write(byteArray, 0, byteArray.Length);
        //        postStream.Close();

        //        WebResponse response = webRequest.GetResponse();
        //        postStream = response.GetResponseStream();
        //        StreamReader reader = new StreamReader(postStream);
        //        string responseFromServer = reader.ReadToEnd();
        //        GooglePlusAccessToken serStatus = JsonConvert.DeserializeObject<GooglePlusAccessToken>(responseFromServer);
        //        if (serStatus != null)
        //        {
        //            string accessToken = string.Empty;
        //            accessToken = serStatus.access_token;

        //            if (!string.IsNullOrEmpty(accessToken))
        //            {
        //                // This is where you want to add the code if login is successful.
        //                // getgoogleplususerdataSer(accessToken);
        //                Response.Write("");
        //                getgoogleplusupdatedataser(accessToken);
        //            }
        //        }
        //    }
        //}



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
        Response.Redirect("Search");
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
                using (SqlCommand cmd2 = new SqlCommand("TwoFactorTable")) 
                {
                    cmd2.Parameters.AddWithValue("@Action", "INSERT");
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@UserID", newGUID.ToString());
                    cmd2.Parameters.AddWithValue("@Email",txt_RegEmail.Text);
                    cmd2.Parameters.AddWithValue("@EmailOTP", "False");
                    cmd2.Parameters.AddWithValue("@BackUpCode", "False");
                    cmd2.Connection = con;
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();


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

        string UserID = "";
        string Email = "";
        string Role = "";
        string ActivationStatus = "";
        string Password = "";
        bool flags = false;
        string EmailOTP = "";
        string BackupCode = "";


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
                    
                    UserID = reader["Id"].ToString();
                    Email = reader["Email"].ToString();
                    Role = reader["Role"].ToString();
                    Password = reader["Password"].ToString();
                    ActivationStatus = reader["ActivationStatus"].ToString();
                    bool flag = Hash.VerifyHash(txt_Password.Text, "SHA512", reader["Password"].ToString());//verifies password through hash function
                    flags = flag;
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Account does not exist!')</script>");
                }
                reader.Close();
                
                

                //Response.Write("<script>alert('Successfully created account! Welcome! ');</script>");

                txt_Email.Text = "";
                txt_Password.Text = "";
            }
            
            
            System.Diagnostics.Debug.WriteLine(flags);
            if (flags == true)
            {
                
                if (!isCaptchaValid)
                {
                    Response.Write("<script language=javascript>alert('Please click on the recaptcha.')</script>");
                }
                else
                {
                    if (ActivationStatus.Equals("True"))
                    {

                        // Write an if statement for 2fa
                        using (SqlCommand twofa = new SqlCommand("TwoFactorTable"))
                        {
                            twofa.Parameters.AddWithValue("@Action", "SELECTUSER");
                            twofa.CommandType = CommandType.StoredProcedure;
                            twofa.Parameters.AddWithValue("@UserID", UserID);
                            twofa.Connection = con;

                            SqlDataReader readertwofa = twofa.ExecuteReader();

                            if (readertwofa.Read())
                            {
                                System.Diagnostics.Debug.WriteLine("Hello there========================");
                                EmailOTP = readertwofa["EmailOTP"].ToString();
                                BackupCode = readertwofa["BackupCode"].ToString();

                                System.Diagnostics.Debug.WriteLine(EmailOTP,BackupCode);

                            }
                        }
                        System.Diagnostics.Debug.WriteLine(EmailOTP);
                        if (EmailOTP.Equals("True"))
                        {
                            Session["USERID"] = UserID;
                            Session["Email"] = Email;
                            Session["Role"] = Role;
                            Session["TwoFAStatus"] = false;
                            Response.Redirect("EmailOTP");
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("dawjddkzsdfkxjdfsjHfhsd");
                            Session["TwoFAStatus"] = "No2FA";
                        }
                        // add else 
                        Session["USERID"] = UserID;
                        Session["Email"] = Email;
                        Session["Role"] = Role;
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
                    else
                    {
                        Response.Write("<script language=javascript>alert('Account is not activated')</script>");
                    }





                }
                
                




            }
            else
            {
                Response.Write("<script language=javascript>alert('Password or UserName is not correct')</script>");
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
        System.Diagnostics.Debug.WriteLine("Executed!");
        mail.Subject = "Account Activation Email";
        mail.Body = "<a href = " + Request.Url.AbsoluteUri.Replace("Home", "AccountActivation.aspx?ActivationCode=" + ActivationCode) + "'>Click here to activate your account.<a/a>";
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

    protected void SignInWithGoogle_Click(object sender, EventArgs e)
    {
        var Googleurl = "https://accounts.google.com/o/oauth2/auth?response_type=code&redirect_uri=" + googleplus_redirect_url + "&scope=https://www.googleapis.com/auth/userinfo.email%20https://www.googleapis.com/auth/userinfo.profile&client_id=" + googleplus_client_id;
        Session["loginWith"] = "google";
        Response.Redirect(Googleurl);
    }


    public class GooglePlusAccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string id_token { get; set; }
        public string refresh_token { get; set; }
    }


    private async void getgoogleplusupdatedataser(string access_token)
    {
        try
        {
            HttpClient client = new HttpClient();
            var urlProfile = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + access_token;
            client.CancelPendingRequests();
            HttpResponseMessage output = await client.GetAsync(urlProfile);
            if (output.IsSuccessStatusCode)
            {
                string outputData = await output.Content.ReadAsStringAsync();
                GoogleUserOutputData serStatus = JsonConvert.DeserializeObject<GoogleUserOutputData>(outputData);

                if (serStatus != null)
                {
                    

                    // check if user exist in database login thru google login
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM User_Accounts WHERE Email = @Email", con))
                        {
                            bool exists;
                            con.Open();
                            
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Email", serStatus.email);
                            SqlDataReader reader = cmd.ExecuteReader();

                            
                            if (reader.Read()) //If account exists in database sign in with session
                            {
                                con.Close();
                                Session["USERID"] = reader["Id"].ToString();
                                Session["Email"] = reader["Email"].ToString();
                                Session["Role"] = reader["Role"].ToString();
                            }
                            else
                            {
                                using (SqlCommand cmd2 = new SqlCommand("UserAccounts"))
                                {
                                    con.Close();
                                    Guid newGUID = Guid.NewGuid();
                                    string ePass = Hash.ComputeHash(txt_RegPassword.Text, "SHA512", null);
                                    cmd2.Parameters.AddWithValue("@Action", "INSERT");
                                    cmd2.CommandType = CommandType.StoredProcedure;
                                    cmd2.Parameters.AddWithValue("@UserID", newGUID.ToString());
                                    cmd2.Parameters.AddWithValue("@First_Name", serStatus.name);
                                    cmd2.Parameters.AddWithValue("@Last_Name", "");
                                    cmd2.Parameters.AddWithValue("@Email", serStatus.email);
                                    cmd2.Parameters.AddWithValue("@Password", "");
                                    cmd2.Parameters.AddWithValue("@Role", "User");

                                    cmd2.Connection = con;
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    SendActivationEmail(serStatus.email);
                                    Response.Write("<script>alert('Successfully created account! Please activate your account through email. ');</script>");





                                }
                            }
                            


                        }
                    }



                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    public class GoogleUserOutputData
    {
        public string id { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string email { get; set; }
        public string picture { get; set; }
    }

}