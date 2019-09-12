using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

           

        }
    }


    protected void btnRegister_Click(object sender, EventArgs e)
    {
        String user = txtUsername.Text;
        String password = txtPassword.Text;
        String confirmPassword = txtConfirmPassword.Text;

        if (user != "" && password != "" && password == confirmPassword)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;" +
                    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="C:\Users\Kevin lee\Desktop\Lab 5 Activity 1 Using Master Pages Solution\Ex09Cart\App_Data\Halloween.mdf";Integrated Security=True
                    //Uni file path
                    //"AttachDbFilename = C:\\Users\\N0677885\\Desktop\\Ex09Cart\\App_Data\\Halloween.mdf;" +
                    "AttachDbFilename = C:\\Users\\Matte\\Downloads\\Ex09Cart\\Ex09Cart\\App_Data\\MyRestaurant.mdf;" +
                    "Integrated Security = True";
    

            //[User] <- Square brackets because user is a keyword
            SqlCommand command = new SqlCommand("SELECT* FROM [User] where username =@user;");
            command.Parameters.AddWithValue("@user", user);

            command.Connection = conn;
            conn.Open();

            System.Data.DataSet ds = new System.Data.DataSet();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);

            //Check for data in returned rowsm if 1 username exists

            bool userExists = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

            //int rows = Convert.ToInt32(command.ExecuteScalar());
            conn.Close();

            if (userExists != true)
            {
                // Create User
                SqlCommand createUser = new SqlCommand("Insert into [User](username, password) values(@user, @password);");
                createUser.Connection = conn;
                createUser.Parameters.AddWithValue("@user", user);
                createUser.Parameters.AddWithValue("@password", password);
                //No value for admin on user creation = Not an admin account.

                //open connection and execute command
                conn.Open();
                createUser.ExecuteScalar();
                conn.Close();
                //Successful creation redirects to order page 
                Session["Username"] = user;
                Response.Redirect("Order.aspx");

            }

            //Not a user
            else
            {
                lblError.Text = "Sorry, that username is already taken. Please enter a new one and try again.";
            }

        }
        else
        {
            //Non matching passwords
            if (user != "" && confirmPassword != password)
            {
                lblError.Text = "Passwords do not match";

            }
            else
            {
                lblError.Text = "Please Enter a Username and Password";
            }
        }
    }
}