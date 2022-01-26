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

public partial class Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCart();
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

    protected void btnSubmitOrder_Click(object sender, EventArgs e)
    {
        Guid newGUID = Guid.NewGuid();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString);

        conn.Open();

        string insertQuery = "INSERT INTO ORDERS (OrderID, FirstName, LastName, Address, ZipCode, PhoneNo) " +
            "VALUES (@ID, @first, @last, @address, @zip, @phone)";

        SqlCommand com = new SqlCommand(insertQuery, conn);

        com.Parameters.AddWithValue("@ID", newGUID.ToString());
        com.Parameters.AddWithValue("@first", txtFirstName.Text);
        com.Parameters.AddWithValue("@last", txtLastName.Text);
        com.Parameters.AddWithValue("@address", txtAddress.Text);
        com.Parameters.AddWithValue("@zip", txtZipCode.Text);
        com.Parameters.AddWithValue("@phone", txtPhoneNumber.Text);


        com.ExecuteNonQuery();

        Response.Redirect("index2.aspx");

        conn.Close();
    }
}