﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_InsertThriller : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnInsertItems_Click(object sender, EventArgs e)
    {

        //int result = 0;
        //int result2 = 0;
        //string image = "";

        //if (FileUpload1.HasFile == true)
        //{
        //    image = "images/" + FileUpload1.FileName;
        //}

        ////Product prod = new Product(txtThrillerID.Text, txtThrillerName.Text,
        ////    txtThrillerDesc.Text, decimal.Parse(txtThrillerPrice.Text),
        ////    image, txtThrillerAuthor.Text,txtThrillerGenre.Text);
        ////Thriller item = new Thriller(txtThrillerID.Text, image, 
        ////    txtThrillerName.Text, txtThrillerAuthor.Text);
        ////result = prod.ProductInsert();
        ////result2 = item.ThrillerInsert();

        //if (result > 0)
        //{
        //    string saveimg = Server.MapPath(" ") + "\\" + image;
        //    FileUpload1.SaveAs(saveimg);
        //    //loadProductInfo();
        //    //loadProduct();
        //    //clear1();
        //}

        //if (result2 > 0)
        //{
        //    string saveimg = Server.MapPath(" ") + "\\" + image;
        //    FileUpload1.SaveAs(saveimg);
        //    //loadProductInfo();
        //    //loadProduct();
        //    //clear1();
        //    Response.Write("<script>alert('Insert Successful');</script>");
        //}

        //else { Response.Write("<script>alert('Failed to Insert');</script>"); }

       
        int result = 0;
        int result2 = 0;
        string image = "";

        if (FileUpload1.HasFile == true)
        {
            image = "images/" + FileUpload1.FileName;
        }

        Decimal prodprice = Convert.ToDecimal(ZadeProdPrice.Text); // Add validator to text box in the future 
        ZadeProduct prod = new ZadeProduct(ZadeProdName.Text, ZadeProdDesc.Text, prodprice, image, ZadeProdType.Text);
        result = prod.ZadeProdInsert();



        if (result > 0)
        {
            string saveimg = Server.MapPath(" ") + "\\" + image;
            FileUpload1.SaveAs(saveimg);
            //loadProductInfo();
            //loadProduct();
            //clear1();
        }
        else
        {
            Response.Write("<script>alert('Failed to Insert');</script>");
        }

        ZadeProdName.Text = "";
        ZadeProdDesc.Text = "";
        ZadeProdPrice.Text = "";
        ZadeProdType.SelectedValue = "";
        



    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin-BestSeller.aspx");
    }
}