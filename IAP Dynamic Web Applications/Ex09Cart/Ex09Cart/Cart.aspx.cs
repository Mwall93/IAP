using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Cart : System.Web.UI.Page
{
    private CartItemList cart;
    private decimal orderTotal;

    protected void Page_Load(object sender, EventArgs e)
    {
        //retrieve cart object from session on every post back
        cart = CartItemList.GetCart();


        orderTotal = GetCartTotal(cart);

        //on initial page load, add cart items to list control
        //and set master page logo image tool tip
        if (!IsPostBack)
        {
            this.DisplayCart();
           // this.Master.PageH1Text = "Your Shopping Cart";
        }
    }

    private decimal GetCartTotal(CartItemList cart)
    {
        decimal orderTotal = 0;
        if (cart.Count > 0)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                orderTotal += cart[i].totalCost;
            }
            lblTotal.Text = "Total Cost: £" + orderTotal.ToString("#.##");
        }
        else
        {
            lblMessage.Text = "Your Cart Is Empty!";
            lblTotal.Text = "";
        }

        return orderTotal;
    }

    private void DisplayCart()
    {
        //remove all current items from list control
        lstCart.Items.Clear();

        //loop cart and add each item's Display value to the control
        for (int i = 0; i < cart.Count; i++)
        {
            lstCart.Items.Add(this.cart[i].Display());
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        //if cart contains items and user has selected an item...
        if (cart.Count > 0)
        {
            if (lstCart.SelectedIndex > -1)
            {

                //remove selected item from cart and re-add cart items 
                cart.RemoveAt(lstCart.SelectedIndex);
                this.DisplayCart();
                this.orderTotal = GetCartTotal(cart);
            }
            else
            { //if no item is selected, notify user 
                lblMessage.Text = "Please select an item to remove.";
            }
        }
    }
    protected void btnEmpty_Click(object sender, EventArgs e)
    {
        //if cart has items, clear both cart and list control
        if (cart.Count > 0)
        {
            cart.Clear();
            lstCart.Items.Clear();
        }
        lblTotal.Text = "Your Cart Is Empty";

    }


    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        createOrder();
        if (cart.Count < 1)
        {
            lblMessage.Text = "Your cart is empty!";
        }
        else
        {
            if (Session["Id"] != null)
            {
                lblMessage.Text = "Thank you for your order!";
                lstCart.Items.Clear();
                //Response.Redirect("OrderConfirmation.aspx");

            }
            else
            {
                lblMessage.Text = "You need to login before continuing to checkout!";
            }
        }
    }

    private void createOrder()
    {
        if (cart.Count > 0)
        {
            if (Session["Username"] != null) {
               
            
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;" +
                        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="C:\Users\Kevin lee\Desktop\Lab 5 Activity 1 Using Master Pages Solution\Ex09Cart\App_Data\Halloween.mdf";Integrated Security=True
                        //Uni file path
                        //"AttachDbFilename = C:\\Users\\N0677885\\Desktop\\Ex09Cart\\App_Data\\Halloween.mdf;" +
                        "AttachDbFilename = C:\\Users\\Matte\\Downloads\\Ex09Cart\\Ex09Cart\\App_Data\\MyRestaurant.mdf;" +
                        "Integrated Security = True";

            
                //SqlCommand command = new SqlCommand();



                SqlCommand orderInsert = new SqlCommand("insert into [Order](userId, totalCost) output Inserted.Id values (@userId, @totalCost)", conn);

                orderInsert.Parameters.AddWithValue("@userId", Session["Id"]);
                orderInsert.Parameters.AddWithValue("@totalCost", this.orderTotal);
                conn.Open();
                    
                //Return value of Order Id (Auto-incremented in table)

                int orderId = (int)orderInsert.ExecuteScalar();

                conn.Close();

                for (int i = 0; i < cart.Count; i++)
                {
                    //Add to db each order item, fk as the new order
                    conn.Open();
                    SqlCommand itemInsert = new SqlCommand("insert into [OrderItems](orderId, productId, quantity) values (@orderId, @productId, @quantity)", conn);
                    itemInsert.Parameters.AddWithValue("@orderId", orderId);
                    itemInsert.Parameters.AddWithValue("@productId", cart[i].Product.ProductID);
                    itemInsert.Parameters.AddWithValue("@quantity", cart[i].Quantity);
                    itemInsert.ExecuteScalar();

                    conn.Close();

                }


                }



        }
    }
}