using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyOrders : System.Web.UI.Page
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
            tblOrderItems.Visible = false;
            this.Master.PageH1Text = "Your Profile";
           
        }



    }


    private void UpdateOrderProducts()
    {

        SqlConnection conn = new SqlConnection();

        conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;" +

         "AttachDbFilename = C:\\Users\\Matte\\Downloads\\Ex09Cart\\Ex09Cart\\App_Data\\MyRestaurant.mdf;" +
         "Integrated Security = True";

        SqlCommand command = new SqlCommand("SELECT* FROM [OrderItems] where orderId = @id");

        GridViewRow row = GridView1.SelectedRow;

        int orderId = Convert.ToInt32(row.Cells[1].Text);

        command.Parameters.AddWithValue("@id", orderId); 

        command.Connection = conn;
        conn.Open();

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(command);
        da.Fill(ds);

        int totalItems = ds.Tables[0].Rows.Count;

        int itemCount = 0;
       


        for (int i = 0; i < totalItems; i++) {

            //Table information to fill
           
            TableRow newRow = new TableRow();
            TableCell item = new TableCell();
            TableCell quantity = new TableCell();
            TableCell cost = new TableCell();
           
            itemCount += ds.Tables[0].Rows[i].Field<int>("quantity");

            quantity.Text = ds.Tables[0].Rows[i].Field<int>("quantity").ToString();
            
            int productId = ds.Tables[0].Rows[i].Field<int>("productId");
            SqlCommand GetProductInfo = new SqlCommand("SELECT* FROM [Product] where Id = @productId", conn);


            GetProductInfo.Parameters.AddWithValue("@productId", productId );


            DataSet dsProduct = new DataSet();
            SqlDataAdapter daProduct = new SqlDataAdapter(GetProductInfo);
            daProduct.Fill(dsProduct);

            item.Text = dsProduct.Tables[0].Rows[0].Field<string>("name").ToString();

            cost.Text = "£" + dsProduct.Tables[0].Rows[0].Field<decimal>("cost").ToString();



            newRow.Cells.Add(item);
            newRow.Cells.Add(quantity);
            newRow.Cells.Add(cost);

            tblOrderItems.Rows.Add(newRow);
            

        }

       conn.Close();

    }



    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateOrderProducts();
    }


    private void btnDelete_Click(object sender, EventArgs e)
    {

        LinkButton button = (LinkButton)sender;
        string OrderId = button.CommandArgument;

        DeleteOrder(Int32.Parse(OrderId));

    }

    private void DeleteOrder(int orderId)
    {
        SqlConnection conn = new SqlConnection();

        conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;" +

         "AttachDbFilename = C:\\Users\\Matte\\Downloads\\Ex09Cart\\Ex09Cart\\App_Data\\MyRestaurant.mdf;" +
         "Integrated Security = True";

        SqlCommand command = new SqlCommand("DELETE FROM [OrderItems] WHERE orderId = @orderId");
        command.Parameters.AddWithValue("@orderId", orderId);


        command.Connection = conn;
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
        conn.Open();
        command = new SqlCommand("Delete from [Order] where id = @id");
        command.Connection = conn;
        command.Parameters.AddWithValue("@id", orderId);

        command.ExecuteNonQuery();
        conn.Close();


    }
}