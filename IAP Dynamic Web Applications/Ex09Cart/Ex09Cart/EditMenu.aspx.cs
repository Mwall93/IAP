using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditMenu : System.Web.UI.Page
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
            this.Master.PageH1Text = "Edit Menu";
            newItem.Visible = false;
        }



    }


    protected void btnNewItem_Click(object sender, EventArgs e)
    {
        newItem.Visible = true;
    }

    protected void btnAddItem_Click(object sender, EventArgs e)
    {

        if (txtCalories.Text != "" && txtCost.Text != "" && txtImage.Text != "" && txtLongDescription.Text != "" && txtShortDescription.Text != "" && txtName.Text != "")
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;" +
                    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="C:\Users\Kevin lee\Desktop\Lab 5 Activity 1 Using Master Pages Solution\Ex09Cart\App_Data\Halloween.mdf";Integrated Security=True
                    //Uni file path
                    //"AttachDbFilename = C:\\Users\\N0677885\\Desktop\\Ex09Cart\\App_Data\\Halloween.mdf;" +
                    "AttachDbFilename = C:\\Users\\Matte\\Downloads\\Ex09Cart\\Ex09Cart\\App_Data\\MyRestaurant.mdf;" +
                    "Integrated Security = True";
            conn.Open();
            
            SqlCommand command = new SqlCommand("Insert into [Product](name, cost, Category, image, ShortDescription, LongDescription, Calories) values(@name, @cost, @category, @image, @shortDescription, @LongDescription, @Calories);");
            command.Connection = conn;
            //@name, @cost, @category, @Id, @image, @shortDescription, @LongDescription, @Calories
            command.Parameters.AddWithValue("@name", txtName.Text);
            command.Parameters.AddWithValue("@cost", txtCost.Text);
            command.Parameters.AddWithValue("@category", txtCategory.Text);
            command.Parameters.AddWithValue("@Calories", txtCalories.Text);

            command.Parameters.AddWithValue("@image", txtImage.Text);
            command.Parameters.AddWithValue("@shortDescription", txtShortDescription.Text);
            command.Parameters.AddWithValue("@LongDescription", txtLongDescription.Text);

            command.ExecuteScalar();
            conn.Close();
            Response.Redirect("EditMenu.aspx");

        }
    }
}