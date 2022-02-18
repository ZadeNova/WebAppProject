using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ProductDetails : System.Web.UI.Page
{
    ZadeProduct prod = null;
    DataTable dt = new DataTable();
    string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        ZadeProduct aProd = new ZadeProduct();

        //Get Product ID from querystring
        string prodID = Request.QueryString["ProdID"].ToString();
        prod = aProd.getProduct(prodID);

        lblTitle.Text = prod.ProductName;
        
        lblPrice.Text = prod.getProductPrice.ToString("C");
        
        imgProductDetails.ImageUrl = prod.getImage;
        lblAuthor.Text = prod.getProductType;
        

        if (!IsPostBack)
        {
            lblDescription.Text = prod.getDescription;
            //DataTable dt = this.GetData("SELECT ISNULL(AVG(Rating), 0) AverageRating, COUNT(Rating) " +
            //    "RatingCount FROM [RATINGS] WHERE Title = @booktitle");

            ////display rating
            //Rating1.CurrentRating = Convert.ToInt32(dt.Rows[0]["AverageRating"]);
            //lblresult.Text = string.Format("{0} Ratings ", dt.Rows[0]["RatingCount"]);
            //lblavgrating.Text = string.Format("{1}", dt.Rows[0]["RatingCount"], dt.Rows[0]["AverageRating"]);
        }
    }

    //extract table data
    private DataTable GetData(string query)
    {
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(query);
        cmd.Parameters.AddWithValue("@booktitle", lblTitle.Text);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        sda.SelectCommand = cmd;
        sda.Fill(dt);
        return dt;
    }





    protected void UpdateDescription_Click(object sender, EventArgs e)
    {
        
        
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("ZadeProducts",con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UPDATEDESC");
                cmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(Request.QueryString["ProdID"]));
                cmd.Parameters.AddWithValue("@Description", UpdateDescriptionTXT.Text);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                System.Diagnostics.Debug.WriteLine(UpdateDescriptionTXT.Text);
                
            }
        }
    }
}