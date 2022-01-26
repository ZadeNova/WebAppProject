using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ProductDetails : BasePage
{
    ZadeProduct prod = null;
    DataTable dt = new DataTable();
    string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        ZadeProduct TheProd = new ZadeProduct();
        //Get Product ID from querystring
        string prodID = Request.QueryString["ProdID"].ToString();
        

        prod = TheProd.getProduct(prodID);

        lblProdName.Text = prod.ProductName;
        lblProdType.Text = prod.getProductType;
        lblDescription.Text = prod.getDescription;
        lblPrice.Text = prod.getProductPrice.ToString("C");
        lblPrice2.Text = prod.getProductPrice.ToString("C");

        imgProductDetails.ImageUrl = prod.getImage;
        

        //if (!IsPostBack)
        //{
        //    DataTable dt = this.GetData("SELECT ISNULL(AVG(Rating), 0) AverageRating, COUNT(Rating) " +
        //        "RatingCount FROM [RATINGS] WHERE Title = @booktitle");

        //    //display rating
        //    Rating1.CurrentRating = Convert.ToInt32(dt.Rows[0]["AverageRating"]);
        //    lblresult.Text = string.Format("{0} Ratings ", dt.Rows[0]["RatingCount"]);
        //    lblavgrating.Text = string.Format("{1}", dt.Rows[0]["RatingCount"], dt.Rows[0]["AverageRating"]);
        //}
    }

    //extract table data
    private DataTable GetData(string query)
    {
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(query);
        cmd.Parameters.AddWithValue("@Product_Name", lblProdName.Text);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        sda.SelectCommand = cmd;
        sda.Fill(dt);
        return dt;
    }

    public void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(constr);

        //insert rating into database
        SqlCommand cmd = new SqlCommand("INSERT INTO [RATINGS] VALUES (@ratingvalue,@review,@title)");
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ratingvalue", Rating1.CurrentRating.ToString());
        cmd.Parameters.AddWithValue("@review", txtreview.Text);
        cmd.Parameters.AddWithValue("@title", lblProdName.Text);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect(Request.Url.AbsoluteUri);
    }

    protected void btnAddCart_Click(object sender, EventArgs e)
    {
        
        string iProductID = Request.QueryString["ProdID"].ToString();
        ShoppingCart.Instance.AddItem(iProductID, prod);

    }
}
