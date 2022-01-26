using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Data;

public partial class Payment : BasePage
{
    string strConnectionString = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;

    int DC = 0;
    int Marvel = 0;
    int StarWars = 0;
    int Anime = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCart();
            FillTextBoxesUserinfo();
        }
    }

    protected void FillTextBoxesUserinfo()
    {
        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("UserAccounts", con))
            {

                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "CHECK");
                cmd.Parameters.AddWithValue("@Email", Session["Email"].ToString());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    txtFirstName.Text = reader["First_Name"].ToString();
                    txtLastName.Text = reader["Last_Name"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                    txtZipCode.Text = reader["ZipCode"].ToString();
                    



                }
                else
                {
                    Response.Write("<script>alert('Error with payment page');</script>");
                }
                con.Close();


            }
        }

    }




    protected void LoadCart()
    {
        //bind the Items inside the Session/ ShoppingCart Instance with the Datagrid

        decimal shipping = 0.0m;
        decimal subtotal = 0.0m;
        decimal total = 0.0m;

        foreach (ShoppingCartItem item in ShoppingCart.Instance.Items)
        {
            subtotal = subtotal + item.TotalPrice;
        }
        if (subtotal < 30 && subtotal > 0)
        {
            shipping = 5.0m;
            total = subtotal + shipping;
        }

        if (subtotal == 0)
        {
            shipping = 0.0m;
        }

        if (subtotal > 30)
        {
            shipping = 0.0m;
            total = subtotal + shipping;
        }

        if (subtotal == 30)
        {
            shipping = 0.0m;
            total = subtotal + shipping;
        }

        lbl_TotalPrice.Text = subtotal.ToString("C");
        lbl_TotalPrice2.Text = total.ToString("C");
        lbl_ShippingPrice.Text = shipping.ToString("C");
        lblSS.Text = shipping.ToString("C");
        
    }

    protected void rbSS_CheckedChanged(object sender, EventArgs e)
    {
        decimal shipping = 0.0m;
        decimal subtotal = 0.0m;
        decimal total = 0.0m;

        foreach (ShoppingCartItem item in ShoppingCart.Instance.Items)
        {
            subtotal = subtotal + item.TotalPrice;
        }
        if (subtotal < 30 && subtotal > 0)
        {
            shipping = 5.0m;
            total = subtotal + shipping;
        }

        if (subtotal == 0)
        {
            shipping = 0.0m;
        }

        if (subtotal > 30)
        {
            shipping = 0.0m;
            total = subtotal + shipping;
        }

        lbl_TotalPrice.Text = subtotal.ToString("C");
        lbl_TotalPrice2.Text = total.ToString("C");
        lbl_ShippingPrice.Text = shipping.ToString("C");
        lblSS.Text = shipping.ToString("C");
    }

    protected void rbES_CheckedChanged(object sender, EventArgs e)
    {
        decimal shipping = 0.0m;
        decimal subtotal = 0.0m;
        decimal total = 0.0m;

        foreach (ShoppingCartItem item in ShoppingCart.Instance.Items)
        {
            subtotal = subtotal + item.TotalPrice;
        }
        if (subtotal < 30 && subtotal > 0 && rbES.Checked == false)
        {
            shipping = 5.0m;
            total = subtotal + shipping;
        }

        if (subtotal == 0 && rbES.Checked == true)
        {
            shipping = 0.0m;
        }

        if (subtotal > 30 && rbES.Checked == false)
        {
            shipping = 0.0m;
            total = subtotal + shipping;
        }

        if (subtotal > 0 && rbES.Checked == true)
        {
            shipping = 9.99m;
            total = subtotal + 9.99m;
        }

        lbl_TotalPrice.Text = subtotal.ToString("C");
        lbl_TotalPrice2.Text = total.ToString("C");
        lbl_ShippingPrice.Text = shipping.ToString("C");

    }



    protected void CountItemsPurchased()
    {
       
        foreach (ShoppingCartItem item in ShoppingCart.Instance.Items)

        {
            if (item.Product_Type.Equals("DC"))
            {
                DC = item.Quantity;
            }
            if (item.Product_Type.Equals("Marvel"))
            {
                Marvel = item.Quantity;
            }
            if (item.Product_Type.Equals("StarWars"))
            {
                StarWars = item.Quantity;
            }
            if (item.Product_Type.Equals("Anime"))
            {
                Anime = item.Quantity;
            }



        }
    }
    
    protected decimal GetTotalPrice()
    {
        decimal Total = 0;
        foreach (ShoppingCartItem item in ShoppingCart.Instance.Items)
        {
            Total = Total + item.Product_Price;
        }
        return Total;
    }








    protected void btnSubmitOrder_Click(object sender, EventArgs e)
    {
        CountItemsPurchased();
        Guid newGUID = Guid.NewGuid();
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString);
        DateTime currentdate = DateTime.Now;
        decimal TotalPrice = GetTotalPrice();

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("Order_Products"))
            {
                cmd.Parameters.AddWithValue("@Action", "INSERT");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", newGUID);
                cmd.Parameters.AddWithValue("@UserID", Session["USERID"].ToString());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@ZipCode", txtZipCode.Text);
                cmd.Parameters.AddWithValue("@DATETIME", currentdate);
                cmd.Parameters.AddWithValue("@Price", TotalPrice);
                cmd.Parameters.AddWithValue("@DC", DC);
                cmd.Parameters.AddWithValue("@Anime", Anime);
                cmd.Parameters.AddWithValue("@StarWars", StarWars);
                cmd.Parameters.AddWithValue("@Marvel", Marvel);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

            //string insertQuery = "INSERT INTO ORDERS (OrderID, FirstName, LastName, Address, ZipCode, PhoneNo) " +
            //    "VALUES (@ID, @first, @last, @address, @zip, @phone)";

            //SqlCommand com = new SqlCommand(insertQuery, conn);

            //com.Parameters.AddWithValue("@ID", newGUID.ToString());
            //com.Parameters.AddWithValue("@first", txtFirstName.Text);
            //com.Parameters.AddWithValue("@last", txtLastName.Text);
            //com.Parameters.AddWithValue("@address", txtAddress.Text);
            //com.Parameters.AddWithValue("@zip", txtZipCode.Text);



            //com.ExecuteNonQuery();

            //Response.Redirect("index.aspx");
            
        //conn.Close();
      

        ShoppingCart.Instance.ClearCartAfterPayment();

        Response.Redirect("index.aspx");



        //Response.Write($"<script language=javascript>alert('{Session["CSharpShoppingCart"].ToString()}')</script>");
    }
}