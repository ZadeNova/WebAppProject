using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.Web.Script.Serialization;

public partial class index : BasePage
{


    public string Hello = "";
    public string img1, img2, img3, img4;
    public List<int> intlist = new List<int>();
    public List<string> imagelist = new List<string>();
    //protected string googleplus_client_id = "798122882448-5rcd832ksd2kjamq8h5qa1tl5hfof1hi.apps.googleusercontent.com";
    //protected string googleplus_client_secret = "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";
    //protected string googleplus_redirect_url = "http://localhost:10068/index.aspx";
    //protected string Parameters;
    protected string Email, User;
    bool loginthrugoogle;
    Random random = new Random();

    protected int RandomNumGen(int TotalNoProduct)
    {

        int num = random.Next(1, TotalNoProduct);
        return num;
    }


    protected int GetTotalNumProducts()
    {
        int TotalProductNum;
        string strConnectionString = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Products", con))
            {
                con.Open();
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@Action", "COUNT");
                //SqlDataReader reader = cmd.ExecuteReader();
                //TotalProductNum = Convert.ToInt32(reader["TOTAL"]);
                TotalProductNum = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                con.Close();



            }
        }
        
        return TotalProductNum;
    }
    
    protected void GetImageNames()

    {
        
        
        string strConnectionString = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Image FROM Products WHERE ID=@ProdID", con))
            {
                for (int i = 0; i < intlist.Count; i++)
                {
                    cmd.Parameters.Clear();

                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("@Action", "ImageName");
                    cmd.Parameters.AddWithValue("@ProdID", intlist[i]);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    imagelist.Add(reader["Image"].ToString());
                    reader.Close();
                   

                    con.Close();
                }

               


            }
        }

        
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


    protected void Page_Load(object sender, EventArgs e)
    {

        
        
        
        //try
        //{
        //    var url = Request.Url.Query;
        //    if (url != "")
        //    {
        //        string queryString = url.ToString();
        //        char[] delimiterChars = { '=' };
        //        string[] words = queryString.Split(delimiterChars);
        //        string code = words[1];

        //        if (code != null)
        //        {
        //            //get the access token 
        //            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
        //            webRequest.Method = "POST";
        //            Parameters = "code=" + code + "&client_id=" + googleplus_client_id + "&client_secret=" + googleplus_client_secret + "&redirect_uri=" + googleplus_redirect_url + "&grant_type=authorization_code";
        //            byte[] byteArray = Encoding.UTF8.GetBytes(Parameters);
        //            webRequest.ContentType = "application/x-www-form-urlencoded";
        //            webRequest.ContentLength = byteArray.Length;
        //            Stream postStream = webRequest.GetRequestStream();
        //            // Add the post data to the web request
        //            postStream.Write(byteArray, 0, byteArray.Length);
        //            postStream.Close();

        //            WebResponse response = webRequest.GetResponse();
        //            postStream = response.GetResponseStream();
        //            StreamReader reader = new StreamReader(postStream);
        //            string responseFromServer = reader.ReadToEnd();

        //            GooglePlusAccessToken serStatus = JsonConvert.DeserializeObject<GooglePlusAccessToken>(responseFromServer);

        //            if (serStatus != null)
        //            {
        //                string accessToken = string.Empty;
        //                accessToken = serStatus.access_token;

        //                if (!string.IsNullOrEmpty(accessToken))
        //                {
        //                    System.Diagnostics.Debug.WriteLine("Hello te");
        //                    // This is where you want to add the code if login is successful.
        //                    response.Close(); // new one
        //                    getgoogleplusupdatedataser(accessToken);
                            
        //                }
        //            }

        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    //throw new Exception(ex.Message, ex);
        //    System.Diagnostics.Debug.WriteLine("errror with top");
        //    System.Diagnostics.Debug.WriteLine(ex.Message);
        //    Response.Redirect("index.aspx");
        //}

        //}
        getimgname();
        img1 = imagelist[0];
        img2 = imagelist[1];
        img3 = imagelist[2];
        //img4 = imagelist[3];
        Hello = "";
        
        //if (loginthrugoogle == true)
        //{
        //    LoginLogic();
        //    System.Diagnostics.Debug.WriteLine("loginnn");
        //}
        


        Page.DataBind();
    }



    public class Tokenclass
    {
        public string access_token
        {
            get;
            set;
        }
        public string token_type
        {
            get;
            set;
        }
        public int expires_in
        {
            get;
            set;
        }
        public string refresh_token
        {
            get;
            set;
        }
    }
    public class Userclass
    {
        public string id
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public string given_name
        {
            get;
            set;
        }
        public string family_name
        {
            get;
            set;
        }
        public string link
        {
            get;
            set;
        }
        public string picture
        {
            get;
            set;
        }
        public string gender
        {
            get;
            set;
        }
        public string locale
        {
            get;
            set;
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

                    System.Diagnostics.Debug.WriteLine("HELELOOQFSDASD");
                    Email = serStatus.email;
                    User = serStatus.given_name;
                    loginthrugoogle = true;
                    System.Diagnostics.Debug.WriteLine(Email);
                    
                    System.Diagnostics.Debug.WriteLine(User);
                    
                    // check if user exist in database login thru google login
                    //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
                    //{
                    //    con.Open();
                    //    using (SqlCommand cmd = new SqlCommand("SELECT * FROM User_Accounts WHERE Email = @Email", con))
                    //    {
                    //        bool exists;


                    //        cmd.CommandType = CommandType.Text;
                    //        cmd.Parameters.AddWithValue("@Email", serStatus.email);
                    //        SqlDataReader reader = cmd.ExecuteReader();


                    //        if (reader.Read()) //If account exists in database sign in with session
                    //        {

                    //            Response.Write($"<script language=javascript>alert('Login through gmail')</script>");

                    //            //Response.Write($"<script language=javascript>alert('{reader["ActivationStatus"].ToString()}')</script>");
                    //            if (reader["ActivationStatus"].ToString().Equals("True"))
                    //            {
                    //                Session["USERID"] = reader["Id"].ToString();
                    //                Session["Email"] = reader["Email"].ToString();
                    //                Session["Role"] = reader["Role"].ToString();
                    //                // CHECK IF Account IS ADMIN OR USER
                    //                var a = (string)Session["Role"];
                    //                if (Session["Role"].ToString().Equals("User"))
                    //                {
                    //                    Response.Write($"<script language=javascript>alert('{Session["USERID"].ToString()}')</script>");
                    //                    Session["UserMasterPage"] = "~/Afterlogin.master";
                    //                    Session["AdminMasterPage"] = null;

                    //                    Response.Redirect(Request.Url.AbsoluteUri);
                    //                }
                    //                else
                    //                {

                    //                    Session["AdminMasterPage"] = "~/AdminMaster.master";
                    //                    Session["UserMasterPage"] = null;
                    //                    Response.Redirect(Request.Url.AbsoluteUri);
                    //                    Response.Write($"<script language=javascript>alert('Hello there Admin!')</script>");

                    //                }
                    //                Response.Write($"<script language=javascript>alert('{Session["Role"].ToString()}')</script>");






                    //            }
                    //            else
                    //            {
                    //                Response.Write("<script language=javascript>alert('Account is not activated')</script>");
                    //                //Session.Clear();
                    //            }




                    //            con.Close();
                    //        }
                    //        else
                    //        {
                    //            using (SqlCommand cmd2 = new SqlCommand("UserAccounts"))
                    //            {
                    //                con.Close();

                    //                cmd2.CommandType = CommandType.StoredProcedure;
                    //                Guid newGUID = Guid.NewGuid();
                    //                //string ePass = Hash.ComputeHash(txt_RegPassword.Text, "SHA512", null);
                    //                cmd2.Parameters.AddWithValue("@Action", "INSERT");
                    //                //cmd2.CommandType = CommandType.StoredProcedure;
                    //                cmd2.Parameters.AddWithValue("@UserID", newGUID.ToString());
                    //                cmd2.Parameters.AddWithValue("@First_Name", serStatus.given_name);
                    //                cmd2.Parameters.AddWithValue("@Last_Name", DBNull.Value);
                    //                cmd2.Parameters.AddWithValue("@Email", serStatus.email);
                    //                cmd2.Parameters.AddWithValue("@Password", DBNull.Value);
                    //                cmd2.Parameters.AddWithValue("@Role", "User");

                    //                cmd2.Connection = con;
                    //                con.Open();
                    //                cmd2.ExecuteNonQuery();
                    //                con.Close();
                    //                //SendActivationEmail(serStatus.email);
                    //                Response.Write("<script>alert('Successfully created account! Please activate your account through email. ');</script>");





                    //            }
                    //        }



                    //    }
                    //}



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
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM User_Accounts WHERE Email = @Email", con))
            {
                bool exists;


                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", Email);
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
                        // CHECK IF Account IS ADMIN OR USER
                        var a = (string)Session["Role"];
                        if (Session["Role"].ToString().Equals("User"))
                        {
                            Response.Write($"<script language=javascript>alert('{Session["USERID"].ToString()}')</script>");
                            Session["UserMasterPage"] = "~/Afterlogin.master";
                            Session["AdminMasterPage"] = null;

                            Response.Redirect(Request.Url.AbsoluteUri);
                        }
                        else
                        {

                            Session["AdminMasterPage"] = "~/AdminMaster.master";
                            Session["UserMasterPage"] = null;
                            Response.Redirect(Request.Url.AbsoluteUri);
                            Response.Write($"<script language=javascript>alert('Hello there Admin!')</script>");

                        }
                        Response.Write($"<script language=javascript>alert('{Session["Role"].ToString()}')</script>");






                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Account is not activated')</script>");
                        //Session.Clear();
                    }




                    con.Close();
                }
                else
                {
                    using (SqlCommand cmd2 = new SqlCommand("UserAccounts"))
                    {
                        con.Close();

                        cmd2.CommandType = CommandType.StoredProcedure;
                        Guid newGUID = Guid.NewGuid();
                        //string ePass = Hash.ComputeHash(txt_RegPassword.Text, "SHA512", null);
                        cmd2.Parameters.AddWithValue("@Action", "INSERT");
                        //cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@UserID", newGUID.ToString());
                        cmd2.Parameters.AddWithValue("@First_Name", User);
                        cmd2.Parameters.AddWithValue("@Last_Name", DBNull.Value);
                        cmd2.Parameters.AddWithValue("@Email", Email);
                        cmd2.Parameters.AddWithValue("@Password", DBNull.Value);
                        cmd2.Parameters.AddWithValue("@Role", "User");

                        cmd2.Connection = con;
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        //SendActivationEmail(serStatus.email);
                        Response.Write("<script>alert('Successfully created account! Please activate your account through email. ');</script>");





                    }
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
                    cmd.Parameters.AddWithValue("@Email",Email);
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
        mail.Body = "<a href = " + Request.Url.AbsoluteUri.Replace("index.aspx", "AccountActivation?ActivationCode=" + ActivationCode) + "'>Click here to activate your account.<a/a>";
        mail.IsBodyHtml = true;
        smtpClient.Send(mail);
        Session["EmailActivation"] = Email;



    }



}