using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewCart : System.Web.UI.Page
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
        //bind the Items inside the Session/ShoppingCart Instance with the Datagrid
        gv_CartView.DataSource = ShoppingCart.Instance.Items;
        gv_CartView.DataBind();

        decimal shipping = 0.0m;
        decimal subtotal = 0.0m;
        decimal total = 0.0m;
        decimal amountleft = 0.0m;

        foreach (ShoppingCartItem item in ShoppingCart.Instance.Items)
        {
            subtotal = subtotal + item.TotalPrice;
        }
        if (subtotal < 30 && subtotal > 0)
        {
            shipping = 5.0m;
            total = subtotal + shipping;
            amountleft = 30 - subtotal;
            lblQualify.Visible = false;
            lbl_AmtLeft.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
        }

        if (subtotal == 0)
        {
            shipping = 0.0m;
            amountleft = 30 - subtotal;
            lblQualify.Visible = false;
            lbl_AmtLeft.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
        }

        if (subtotal > 30)
        {
            shipping = 0.0m;
            total = subtotal + shipping;
            lblQualify.Visible = true;
            lbl_AmtLeft.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
        }

        lbl_TotalPrice.Text = subtotal.ToString("C");
        lbl_TotalPrice2.Text = total.ToString("C");
        lbl_ShippingPrice.Text = shipping.ToString("C");
        lbl_AmtLeft.Text = amountleft.ToString("C");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gv_CartView.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                string productId = gv_CartView.DataKeys[row.RowIndex].Value.ToString();

                //row.Cells[2] means that the quantity textbox must be in column 3.

                int quantity = int.Parse(((TextBox)row.Cells[0].FindControl("tb_Quantity")).Text);
                ShoppingCart.Instance.SetItemQuantity(productId, quantity);
            }
        }
        LoadCart();
    }

    protected void gv_CartView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            string productId = e.CommandArgument.ToString();
            ShoppingCart.Instance.RemoveItem(productId);
            LoadCart();
        }
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payment2.aspx");
    }
}