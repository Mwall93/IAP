using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //Redirect Non-Admin User
            if (Session["Admin"] == null)
            {
                Response.Redirect("Order.aspx");

            }
            this.Master.PageH1Text = "Admin Pages:";

        }



    }

    //public void EditOrders_Click()
    //{
    //    Response.Redirect("EditOrders.aspx");
    //}
    //public void EditMenu_Click()
    //{
    //    Response.Redirect("EditMenu.aspx");
    //}
    //public void EditUsers_Click()
    //{
    //    Response.Redirect("EditUsers.aspx");
    //}


}