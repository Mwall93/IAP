using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditOrders : System.Web.UI.Page
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
            this.Master.PageH1Text = "Edit Orders";

        }
        DisplayOrders();



    }

    private void DisplayOrders()
    {

        SqlConnection conn = new SqlConnection();

        conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;" +

         "AttachDbFilename = C:\\Users\\Matte\\Downloads\\Ex09Cart\\Ex09Cart\\App_Data\\MyRestaurant.mdf;" +
         "Integrated Security = True";

        SqlCommand command = new SqlCommand("SELECT* FROM [Order]");


        command.Connection = conn;  
        conn.Open();

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(command);
        da.Fill(ds);

        int totalOrders = ds.Tables[0].Rows.Count;

        for (int i = 0; i < totalOrders; i++)
        {
            TableRow newRow = new TableRow();
            TableCell OrderId = new TableCell();
            TableCell CustomerId = new TableCell();
            TableCell Date = new TableCell();
            TableCell Cost = new TableCell();

            TableCell Delete = new TableCell();

            string orderId = ds.Tables[0].Rows[i].Field<int>("Id").ToString();
            OrderId.Text = orderId;

            CustomerId.Text = ds.Tables[0].Rows[i].Field<int>("userId").ToString();

            Cost.Text = ds.Tables[0].Rows[i].Field<decimal>("totalCost").ToString();

            Date.Text = ds.Tables[0].Rows[i].Field<DateTime>("date").ToString("dd/MM/yyyy");

            LinkButton btnDeleteOrder = new LinkButton();
            btnDeleteOrder.ID = "btnAddToBasket" + i;
            btnDeleteOrder.Text = "Delete This Order";
            btnDeleteOrder.CommandArgument = orderId;
            btnDeleteOrder.Click += btnDelete_Click;
            Delete.Controls.Add(btnDeleteOrder);

            newRow.Controls.Add(OrderId);
            newRow.Controls.Add(CustomerId);
            newRow.Controls.Add(Cost);
            newRow.Controls.Add(Date);
            newRow.Controls.Add(Delete);


            tblOrders.Rows.Add(newRow);
        }


        //name.Text = ds.Tables[0].Rows[i].Field<string>("name") +"<br/>";

        //shortDescription.Text = ds.Tables[0].Rows[i].Field<string>("shortDescription");

        //Table information to fill


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