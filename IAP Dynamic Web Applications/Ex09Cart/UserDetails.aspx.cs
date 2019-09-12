using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //Redirect Non-Admin User
            if (Session["Username"] == null)
            {
                Response.Redirect("login.aspx");
                

            }
            this.Master.PageH1Text = "Your Profile";

        }



    }
        
}