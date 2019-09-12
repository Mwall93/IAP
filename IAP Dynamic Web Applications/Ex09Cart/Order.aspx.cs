using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Order : System.Web.UI.Page
{
    private Product selectedProduct;

    protected void Page_Load(object sender, EventArgs e)
    {
      //bind dropdown on first load; get and show product data on every load        
        if (!IsPostBack) //ddlProducts.DataBind();
        //selectedProduct = this.GetSelectedProduct();
        //lblName.Text = selectedProduct.Name;
        if(Session["Username"] != null)
        {
                this.Master.PageH1Text = "Welcome back, " + Session["Username"] + "!";
        }
        else
        {
            this.Master.PageH1Text = "Our Menu!";
        }
        //if (CartItemList.GetCart() == null)
        //{
        //    CartItemList cart = new CartItemList();
        //}

        DisplayProducts();

        //lblShortDescription.Text = selectedProduct.ShortDescription;
        //lblLongDescription.Text = selectedProduct.LongDescription;
        //lblUnitPrice.Text = selectedProduct.UnitPrice.ToString("c") + " each";
       // imgProduct.ImageUrl = "Images/Products/" + selectedProduct.ImageFile;

        //On initial page load, add cart items to list control
        //and set master page logo image tool tip
        
    }

    //private Product GetSelectedProduct()
    //{
    //    //get row from SqlDataSource based on value in dropdownlist
    //    DataView productsTable = (DataView)
    //        SqlDataSource.Select(DataSourceSelectArguments.Empty);
    //   // productsTable.RowFilter = string.Format("Id = '{0}'",
    //        //ddlProducts.SelectedValue);
    //    //DataRowView row = (DataRowView)productsTable[0];

    //    //create a new product object and load with data from row
    //    //Product p = new Product();

    //    //p.ProductID = row["Id"].ToString();
    //    //p.Name = row["name"].ToString();

    //    //p.UnitPrice = (decimal)row["cost"];
    //    //p.ImageFile = row["image"].ToString();
    //    //return p;
    //}

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //get cart from session and selected item from cart
            CartItemList cart = CartItemList.GetCart();
            CartItem cartItem = cart[selectedProduct.ProductID];

            //if item isn’t in cart, add it; otherwise, increase its quantity
            if (cartItem == null)
            {
                //cart.AddItem(selectedProduct,
                            // Convert.ToInt32(txtQuantity.Text));
            }
            else
            {
                //cartItem.AddQuantity(Convert.ToInt32(txtQuantity.Text));
            }
            Response.Redirect("Cart.aspx");
        }
    }




    private bool IsFavouriteItem(int productId)
    {

        SqlConnection conn = new SqlConnection();

        conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;" +

         "AttachDbFilename = C:\\Users\\Matte\\Downloads\\Ex09Cart\\Ex09Cart\\App_Data\\MyRestaurant.mdf;" +
         "Integrated Security = True";

        SqlCommand command = new SqlCommand("SELECT* FROM [UserFavourite] where UserId =@userId and productId =@product");
        command.Parameters.AddWithValue("@userId", Session["Id"]);
        command.Parameters.AddWithValue("@product", productId.ToString());

        command.Connection = conn;
        conn.Open();
            
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(command);
        da.Fill(ds);


        //Check for data in returned rows

        bool isFavourite = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

        return isFavourite;
    }

    private void AddToFavourites(int productId)
    {
        SqlConnection conn = new SqlConnection();

        conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;" +

         "AttachDbFilename = C:\\Users\\Matte\\Downloads\\Ex09Cart\\Ex09Cart\\App_Data\\MyRestaurant.mdf;" +
         "Integrated Security = True";

        SqlCommand command = new SqlCommand("INSERT INTO [UserFavourite] (userId, productId) values (@user, @product)");
        command.Parameters.AddWithValue("@user", Session["Id"]);
        command.Parameters.AddWithValue("@product", productId);

        command.Connection = conn;
        conn.Open();

        command.ExecuteScalar();
        conn.Close();
    }

    private void DisplayProducts()
    {

        SqlConnection conn = new SqlConnection();

        conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;" +

         "AttachDbFilename = C:\\Users\\Matte\\Downloads\\Ex09Cart\\Ex09Cart\\App_Data\\MyRestaurant.mdf;" +
         "Integrated Security = True";

        SqlCommand command = new SqlCommand("SELECT* FROM [Product]");


        command.Connection = conn;
        conn.Open();

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(command);
        da.Fill(ds);

        int totalItems = ds.Tables[0].Rows.Count;


        //Table information to fill

       Panel newRow = new Panel();
            newRow.CssClass = "row";

        for (int i = 0; i < totalItems; i++)
        {

            //Panel newRow = new Panel();
            //newRow.CssClass = "row";
            //Item in new Row
            Panel newItem = new Panel();
            newItem.CssClass = "col-lg-4 col-md-4 col-sm-6";
            //Item image in Item panel
            Panel item = new Panel();
            item.CssClass = "thumbnail";
            //Caption in image panel
            Panel caption = new Panel();
            caption.CssClass = "caption";

            Image productImg = new Image();
            productImg.ImageUrl = "Images/Products/" + ds.Tables[0].Rows[i].Field<string>("image");
            //productImg.Height = ; //Auto sets from width
            productImg.Height = 180;

            string cost = "£" + ds.Tables[0].Rows[i].Field<decimal>("cost").ToString();

            Label productCaption = new Label();
            productCaption.Text = "<br/>" + ds.Tables[0].Rows[i].Field<string>("shortDescription") + "<br/>" + cost + "<br/>";

            int prodId = ds.Tables[0].Rows[i].Field<int>("Id");

            //Add controls before favourite button
            caption.Controls.Add(productImg);
            caption.Controls.Add(productCaption);

            LinkButton btnAdd = new LinkButton();
            btnAdd.ID = "btnAddToBasket" + i;
            btnAdd.CommandArgument = prodId.ToString();
            btnAdd.Click += btnAddClicked;
            btnAdd.Text = "Add To Order <br/>";
            caption.Controls.Add(btnAdd);

            if (Session["Id"] != null)
            {
                LinkButton btnAddToFavourites = new LinkButton();
                btnAddToFavourites.ID = "btnAddToFavourites" + i;
                btnAddToFavourites.CommandArgument = prodId.ToString();

                if (IsFavouriteItem(prodId) == false)
                {
                    btnAddToFavourites.Text = "Add To Favourites";
                    btnAddToFavourites.Click += btnAddToFavourites_Click;
                }
                else
                {
                    btnAddToFavourites.Text = "Remove From Favourites";

                    btnAddToFavourites.Click += btnRemoveFromFavourites_Click;
                }
                caption.Controls.Add(btnAddToFavourites);
            }


            


            item.Controls.Add(caption);
            newItem.Controls.Add(item);
            newRow.Controls.Add(newItem);
            panelMenuContainer.Controls.Add(newRow);



            //TableRow newRow = new TableRow();
            //TableCell image = new TableCell();
            //TableCell name = new TableCell();
            //TableCell shortDescription = new TableCell();
            //TableCell favourite = new TableCell();

            //name.Text = ds.Tables[0].Rows[i].Field<string>("name") +"<br/>";

            //shortDescription.Text = ds.Tables[0].Rows[i].Field<string>("shortDescription");


            //image.Text =  string.Format("<img src='Images/Products/" + ds.Tables[0].Rows[i].Field<string>("image") + "' height='150' width='150' />");

            ////Display favourite option for logged in users
            //if (Session["Username"] != null)
            //{
            //    if (IsFavouriteItem(ds.Tables[0].Rows[i].Field<int>("Id")) == false)
            //    {
            //        favourite.Text = string.Format("<a class='nonFavourite' href = '#'  runat = 'server' onServerClick = 'AddToFavourites(ds.Tables[0].Rows[i].Field<int>('Id'))' />&star;</a>");

            //    }
            //    else
            //    {
            //        favourite.Text = string.Format("<a class='favourite' href = '#'  runat = 'server' onServerClick = 'RemoveFromFavourites(ds.Tables[0].Rows[i].Field<int>('Id'))' />&starf;</a>");
            //    }
            //}

            //newRow.Cells.Add(name);
            //newRow.Cells.Add(shortDescription);
            //newRow.Cells.Add(image);
            //newRow.Cells.Add(favourite);

            //tblProducts.Rows.Add(newRow);

        }

        conn.Close();
    }

    private void btnAddToFavourites_Click(object sender, EventArgs e)
    {

        LinkButton button = (LinkButton)sender;
        string productId = button.CommandArgument;

        AddToFavourites(Int32.Parse(productId));

    }
    private void btnRemoveFromFavourites_Click(object sender, EventArgs e)
    {

        LinkButton button = (LinkButton)sender;
        string productId = button.CommandArgument;

        RemoveFromFavourites(Int32.Parse(productId));

    }

    private void RemoveFromFavourites(int productId)
    {
        SqlConnection conn = new SqlConnection();

        conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;" +

         "AttachDbFilename = C:\\Users\\Matte\\Downloads\\Ex09Cart\\Ex09Cart\\App_Data\\MyRestaurant.mdf;" +
         "Integrated Security = True";

        SqlCommand command = new SqlCommand("Delete from [UserFavourite] where userId = @userId and productId = @productId" );
        command.Parameters.AddWithValue("@userId", Session["Id"]);
        command.Parameters.AddWithValue("@productId", productId);

        command.Connection = conn;
        conn.Open();

        command.ExecuteScalar();
        conn.Close();
    }

    private void btnAddClicked(object sender, EventArgs e)
    {

        LinkButton button = (LinkButton)sender;
        string id = button.CommandArgument;

        AddToBasket(Int32.Parse(id));


        throw new NotImplementedException();
    }

    private void btnAdd_Click(int ProductId)
    {

        AddToBasket(ProductId);
        
    }

    private void AddToBasket(int ProductId)
    {
        CartItemList cart = CartItemList.GetCart();
        //Create Product From Id
        // create a new product object and load with data from row
        Product p = new Product();
        Session["Basket"] = true;

        //Read Info From DB For Product

        SqlConnection conn = new SqlConnection();

        conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;" +

         "AttachDbFilename = C:\\Users\\Matte\\Downloads\\Ex09Cart\\Ex09Cart\\App_Data\\MyRestaurant.mdf;" +
         "Integrated Security = True";

        SqlCommand command = new SqlCommand("SELECT* FROM [Product] Where Id = @Id");
        command.Parameters.AddWithValue("@Id", ProductId);


        command.Connection = conn;
        conn.Open();

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(command);
        da.Fill(ds);
        conn.Close();
        if (ds.Tables.Count > 0)
        {
           

            p.ProductID = ds.Tables[0].Rows[0].Field<int>("Id").ToString();

            p.Name = ds.Tables[0].Rows[0].Field<string>("name");
            p.UnitPrice = ds.Tables[0].Rows[0].Field<decimal>("cost");
            p.ImageFile = "Images/Products/" + ds.Tables[0].Rows[0].Field<string>("image");

            //if item isn’t in cart, add it; otherwise, increase its quantity
            cart = CartItemList.GetCart();
            CartItem cartItem = cart[p.ProductID];
            if(cartItem == null)
            {
                cart.AddItem(p, 1);
            }
            else
            {
                cartItem.AddQuantity(1);
            }
            
            Response.Redirect("Cart.aspx");

        }
        //Response.Redirect("login.aspx");

    }
}   