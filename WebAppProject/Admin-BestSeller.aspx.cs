using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class BestSeller : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            ZadeProdType.AutoPostBack = true;
            this.BindRepeater();
            
        }
    }
    
    private void BindRepeater()
    {
        string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        

        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("ZadeProducts"))
            {
                cmd.Parameters.AddWithValue("@Action", "SELECT");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                }
            }
        }


    }


    private void FilterRepeater(string filter)
    {
        string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("ZadeProducts"))
            {
                cmd.Parameters.AddWithValue("@Action", "SELECTTYPE");
                cmd.Parameters.AddWithValue("@Type", filter);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                }
            }
        }
    }



    protected void OnEdit(object sender, EventArgs e)
    {
        //Find the reference of the Repeater Item.
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        this.ToggleElements(item, true);
    }

    private void ToggleElements(RepeaterItem item, bool isEdit)
    {
        //Toggle Buttons.
        item.FindControl("lnkEdit").Visible = !isEdit;
        item.FindControl("lnkUpdate").Visible = isEdit;
        item.FindControl("lnkCancel").Visible = isEdit;


        //Toggle Labels.
        item.FindControl("lblProduct").Visible = !isEdit;
        item.FindControl("lblProductType").Visible = !isEdit;
        item.FindControl("imgProduct").Visible = !isEdit;

        //Toggle TextBoxes.
        item.FindControl("txtProductName").Visible = isEdit;
        item.FindControl("txtImage").Visible = isEdit;
        item.FindControl("txtProductType").Visible = isEdit;
        item.FindControl("ProductPrice").Visible = isEdit;
        
    }

    protected void OnUpdate(object sender, EventArgs e)
    {
        //Find the reference of the Repeater Item.
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;

        //Finds the matching BS_ID in the row of data
        int ProdID = int.Parse((item.FindControl("lblProductId") as Label).Text);
        //Trim() allows data to be modified
        string name = (item.FindControl("txtProductName") as TextBox).Text.Trim();
        string prodtype = (item.FindControl("txtProductType") as TextBox).Text.Trim();
        string image = (item.FindControl("txtImage") as TextBox).Text.Trim();
        
        int Price = Convert.ToInt32((item.FindControl("ProductPrice") as TextBox).Text);

        string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            //using stored procedure
            using (SqlCommand cmd = new SqlCommand("ZadeProducts"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //call the action UPDATE
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                //pass in new values
                cmd.Parameters.AddWithValue("@ProductID", ProdID);
                cmd.Parameters.AddWithValue("@Product_Name", name);
                
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@Type", prodtype);
                cmd.Parameters.AddWithValue("@Image", image);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //display
        this.BindRepeater();
    }

    protected void OnCancel(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        this.ToggleElements(item, false);
    }

    protected void OnDelete(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        int Id = int.Parse((item.FindControl("lblProductId") as Label).Text);

        string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("ZadeProducts"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@ProductID", Id);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        this.BindRepeater();
    }

    protected void btnAddItem_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateProduct");
    }

    protected void ZadeProdType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["SunnyCS"].ConnectionString;
        //FilterRepeater(ZadeProdType.Text);
        switch (ZadeProdType.Text)
        {
            case "DC":
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("ZadeProducts"))
                    {
                        cmd.Parameters.AddWithValue("@Action", "SELECTTYPE");
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@Type", ZadeProdType.Text);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                Repeater1.DataSource = dt;
                                Repeater1.DataBind();
                            }
                        }
                    }
                }
                
                break;
            case "Marvel":
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("ZadeProducts"))
                    {
                        cmd.Parameters.AddWithValue("@Action", "SELECTTYPE");
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@Type", ZadeProdType.Text);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                Repeater1.DataSource = dt;
                                Repeater1.DataBind();
                            }
                        }
                    }
                }
                break;
            case "Anime":
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("ZadeProducts"))
                    {
                        cmd.Parameters.AddWithValue("@Action", "SELECTTYPE");
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@Type", ZadeProdType.Text);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                Repeater1.DataSource = dt;
                                Repeater1.DataBind();
                            }
                        }
                    }
                }
                break;
            case "StarWars":
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("ZadeProducts"))
                    {
                        cmd.Parameters.AddWithValue("@Action", "SELECTTYPE");
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@Type", ZadeProdType.Text);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                Repeater1.DataSource = dt;
                                Repeater1.DataBind();
                            }
                        }
                    }
                }
                break;
            default:
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("ZadeProducts"))
                    {
                        cmd.Parameters.AddWithValue("@Action", "SELECT");
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                Repeater1.DataSource = dt;
                                Repeater1.DataBind();
                            }
                        }
                    }
                }
                break;
        }
    }





}