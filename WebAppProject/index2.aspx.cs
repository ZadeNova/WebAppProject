using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

public partial class index : System.Web.UI.Page
{
    public string img1, img2, img3, img4;
    public List<string> imagelist = new List<string>();
    protected string googleplus_client_id = "798122882448-5rcd832ksd2kjamq8h5qa1tl5hfof1hi.apps.googleusercontent.com";
    protected string googleplus_client_secret = "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";
    protected string googleplus_redirect_url = "http://localhost:10068/index2.aspx";
    protected string Parameters;
    protected string Email, User;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["loginWith"].ToString() == "google" && Session["loginWith"] != null)
        //{
        //    System.Diagnostics.Debug.WriteLine("Hello te3123213131213");
        //    try
        //    {
        //        var url = Request.Url.Query;
        //        if (url != "")
        //        {
        //            string queryString = url.ToString();
        //            char[] delimiterChars = { '=' };
        //            string[] words = queryString.Split(delimiterChars);
        //            string code = words[1];

        //            if (code != null)
        //            {
        //                //get the access token 
        //                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
        //                webRequest.Method = "POST";
        //                Parameters = "code=" + code + "&client_id=" + googleplus_client_id + "&client_secret=" + googleplus_client_secret + "&redirect_uri=" + googleplus_redirect_url + "&grant_type=authorization_code";
        //                byte[] byteArray = Encoding.UTF8.GetBytes(Parameters);
        //                webRequest.ContentType = "application/x-www-form-urlencoded";
        //                webRequest.ContentLength = byteArray.Length;
        //                Stream postStream = webRequest.GetRequestStream();
        //                // Add the post data to the web request
        //                postStream.Write(byteArray, 0, byteArray.Length);
        //                postStream.Close();

        //                WebResponse response = webRequest.GetResponse();
        //                postStream = response.GetResponseStream();
        //                StreamReader reader = new StreamReader(postStream);
        //                string responseFromServer = reader.ReadToEnd();

        //                GooglePlusAccessToken serStatus = JsonConvert.DeserializeObject<GooglePlusAccessToken>(responseFromServer);

        //                if (serStatus != null)
        //                {
        //                    string accessToken = string.Empty;
        //                    accessToken = serStatus.access_token;

        //                    if (!string.IsNullOrEmpty(accessToken))
        //                    {
        //                        System.Diagnostics.Debug.WriteLine("Hello te");
        //                        // This is where you want to add the code if login is successful.
        //                        response.Close(); // new one
        //                        var Task = getgoogleplusupdatedataser(accessToken);
        //                        // getgoogleplusupdatedataser(accessToken);

        //                        Response.Redirect("Home");
        //                    }
        //                }

        //            }
        //        }
        //        //LoginLogic();
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw new Exception(ex.Message, ex);
        //        System.Diagnostics.Debug.WriteLine("errror with top");
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //        Response.Redirect("DC.aspx");
        //    }
        //}
        if (Session["loginWith"].ToString() == "google" && Session["loginWith"] != null)
        {
            
            var url = Request.Url.Query;
            if (url != "")
            {
                string queryString = url.ToString();
                char[] delimiterChars = { '=' };
                string[] words = queryString.Split(delimiterChars);
                string code = words[1];

                if (code != null)
                {
                    //get the access token 
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
                    webRequest.Method = "POST";
                    Parameters = "code=" + code + "&client_id=" + googleplus_client_id + "&client_secret=" + googleplus_client_secret + "&redirect_uri=" + googleplus_redirect_url + "&grant_type=authorization_code";
                    byte[] byteArray = Encoding.UTF8.GetBytes(Parameters);
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    webRequest.ContentLength = byteArray.Length;
                    Stream postStream = webRequest.GetRequestStream();
                    // Add the post data to the web request
                    postStream.Write(byteArray, 0, byteArray.Length);
                    postStream.Close();

                    WebResponse response = webRequest.GetResponse();
                    postStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(postStream);
                    string responseFromServer = reader.ReadToEnd();

                    GooglePlusAccessToken serStatus = JsonConvert.DeserializeObject<GooglePlusAccessToken>(responseFromServer);

                    if (serStatus != null)
                    {
                        string accessToken = string.Empty;
                        accessToken = serStatus.access_token;

                        if (!string.IsNullOrEmpty(accessToken))
                        {

                            System.Diagnostics.Debug.WriteLine("Hello te");
                            // This is where you want to add the code if login is successful.
                            response.Close(); // new one
                            var Task = getgoogleplusupdatedataser(accessToken);

                            // getgoogleplusupdatedataser(accessToken);

                            Task.Run(() => getgoogleplusupdatedataser(accessToken));
                            System.Threading.Thread.Sleep(5000);
                            System.Diagnostics.Debug.WriteLine(User);
                            System.Diagnostics.Debug.WriteLine(Email);
                            System.Diagnostics.Debug.WriteLine(Session["Email"]);
                            System.Diagnostics.Debug.WriteLine(Session["Username"]);
                            LoginLogic();
                            Response.Redirect("Home");
                        }
                    }

                }
            }
            //LoginLogic();




        }

        getimgname();
        img1 = imagelist[0];
        img2 = imagelist[1];
        img3 = imagelist[2];

        //LoginLogic();
        //if (Session["loginWith"] != null)
        //{
        //    System.Diagnostics.Debug.WriteLine("awdawdawdwadda");
        //    LoginLogic();
        //}


    }

    protected void getimgname()
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 3 Image FROM Products ORDER BY newid()", con))
            {

                con.Open();
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    imagelist.Add(reader[0].ToString());
                }

                con.Close();


            }
        }

    }

    public class GooglePlusAccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string id_token { get; set; }
        public string refresh_token { get; set; }
    }

    public class GoogleUserOutputData
    {
        public string id { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string email { get; set; }
        public string picture { get; set; }
    }

    private async Task getgoogleplusupdatedataser(string access_token)
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

                    
                    Email = serStatus.email;
                    User = serStatus.given_name;
                    
                    
                    Session["Email"] = serStatus.email;
                    Session["Username"] = serStatus.given_name;
                    



                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("LOLWON");
        }
        
    }



    private void LoginLogic()

    {

        string UserID = "";
        string Email = "";
        string Role = "";
        string ActivationStatus = "";
        string Password = "";
        bool flags = false;
        string EmailOTP = "";
        string BackupCode = "";


        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM User_Accounts WHERE Email = @Email", con))
            {
                bool exists;


                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", Session["Email"].ToString());
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read()) //If account exists in database sign in with session
                {

                    Response.Write($"<script language=javascript>alert('Login through gmail')</script>");

                    //Response.Write($"<script language=javascript>alert('{reader["ActivationStatus"].ToString()}')</script>");
                    if (reader["ActivationStatus"].ToString().Equals("True"))
                    {
                        Session["USERID"] = reader["Id"].ToString();
                        Session["Email"] = reader["Email"].ToString();
                        Session["Role"] = reader["Role"].ToString();
                        UserID = reader["Id"].ToString();
                        
                        // CHECK IF Account IS ADMIN OR USER
                        var a = (string)Session["Role"];
                        con.Close();

                        using (SqlCommand twofa = new SqlCommand("TwoFactorTable"))
                        {
                            con.Open();
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

                                System.Diagnostics.Debug.WriteLine(EmailOTP, BackupCode);
                                con.Close();
                            }
                        }
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
                            Session["TwoFAStatus"] = "No2FA";
                            if (Session["Role"].ToString().Equals("User"))
                            {
                                Response.Write($"<script language=javascript>alert('{Session["USERID"].ToString()}')</script>");
                                Session["UserMasterPage"] = "~/Afterlogin.master";
                                Session["AdminMasterPage"] = null;
                                System.Diagnostics.Debug.WriteLine("sdawdawdadada");
                                Response.Redirect("Home");
                            }
                            else
                            {

                                Session["AdminMasterPage"] = "~/AdminMaster.master";
                                Session["UserMasterPage"] = null;
                                Response.Redirect(Request.Url.AbsoluteUri);
                                Response.Write($"<script language=javascript>alert('Hello there Admin!')</script>");

                            }
                        }

                        
                       
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Account is not activated')</script>");
                        //Session.Clear();
                    }




                    
                }
                else
                {

                    Guid newGUID = Guid.NewGuid();
                    using (SqlCommand cmd2 = new SqlCommand("UserAccounts"))
                    {
                        con.Close();

                        cmd2.CommandType = CommandType.StoredProcedure;
                        
                        //string ePass = Hash.ComputeHash(txt_RegPassword.Text, "SHA512", null);
                        cmd2.Parameters.AddWithValue("@Action", "INSERTEVERY");
                        //cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@UserID", newGUID.ToString());
                        cmd2.Parameters.AddWithValue("@First_Name", User);
                        cmd2.Parameters.AddWithValue("@Last_Name", DBNull.Value);
                        cmd2.Parameters.AddWithValue("@Email", Session["Email"].ToString());
                        cmd2.Parameters.AddWithValue("@Password", DBNull.Value);
                        cmd2.Parameters.AddWithValue("@Role", "User");
                        cmd2.Parameters.AddWithValue("@ActivationStatus", "True");

                        cmd2.Connection = con;
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        //SendActivationEmail(Session["Email"].ToString());
                        
                        





                    }

                    using (SqlCommand cmd2 = new SqlCommand("TwoFactorTable"))
                    {
                        cmd2.Parameters.AddWithValue("@Action", "INSERT");
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@UserID", newGUID.ToString());
                        cmd2.Parameters.AddWithValue("@Email", Session["Email"].ToString());
                        cmd2.Parameters.AddWithValue("@EmailOTP", "False");
                        cmd2.Parameters.AddWithValue("@BackUpCode", "False");
                        cmd2.Connection = con;
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();


                    }
                    Response.Write("<script>alert('Successfully created account! Please activate your account through email. ');</script>");
                    Response.Redirect("Home");

                }

            }



        }
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
                    cmd.Parameters.AddWithValue("@Email", Email);
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
        mail.Body = "<a href = " + Request.Url.AbsoluteUri.Replace("index2.aspx", "AccountActivation?ActivationCode=" + ActivationCode) + "'>Click here to activate your account.<a/a>";
        //mail.Body = $"<a href = "{}"'>Click here to activate your account.<a/a>";
        mail.IsBodyHtml = true;
        smtpClient.Send(mail);
        Session["EmailActivation"] = Email;



    }

}