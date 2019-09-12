using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            // this.Master.PageH1Text = "Please Enter Your Login Details";

        }
    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        String user = txtUsername.Text;
        String password = txtPassword.Text;

        if (user != "" && password != "")
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;" +
                   
             "AttachDbFilename = C:\\Users\\Matte\\Downloads\\Ex09Cart\\Ex09Cart\\App_Data\\MyRestaurant.mdf;" +
             "Integrated Security = True";
            
            //[User] <- Square brackets because user is a keyword

            SqlCommand command = new SqlCommand("SELECT* FROM [User] where username =@user AND password =@password;");
            command.Parameters.AddWithValue("@user", user);
            command.Parameters.AddWithValue("@password", password);


            
            command.Connection = conn;
            conn.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);

            
            //Check for data in returned rows

            bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

            
            conn.Close();
            //CHANGE  && Session["Username"] != null
            if (loginSuccessful == true)
            {

                // Login User & create session
                //Logs out any current user. Possibly change to check for logged in users
                
                Session["Username"] = user;
                Session["Id"] = ds.Tables[0].Rows[0].Field<int>("Id");

                //Set session to contain admin. 
                //Admin pages auto redirect if not set (i.e regular user)

                bool Admin = ds.Tables[0].Rows[0].Field<bool>("Admin");
                if (Admin == true)
                {

                    Session["Admin"] = true;
                    Response.Redirect("AdminHome.aspx");

                }

                //Redirect to order page
                Response.Redirect("Order.aspx");

            }
            //CHANGE Implement this.
            

            else if (Session["Username"] != null) {

                //User is already logged in 
                if(Session["Username"].ToString() == user)
                {
                    lblError.Text = "You're already logged in!";
                }
                else
                {
                    lblError.Text = "You're already logged in as " + Session["Username"].ToString() + ". Not you? " + "<a href='logout.aspx'>Logout<a/>";
                }
                    
            }
            else
            {
                //User doesn't exist
                lblError.Text = "Username and Password Combination Not Recognised<br/>";


            }


            //SqlDataAdapter adapter = new SqlDataAdapter();
            //adapter.SelectCommand = new SqlCommand(sql);



            //adapter.InsertCommand = new SqlCommand(sql, conn);
            //adapter.InsertCommand.ExecuteNonQuery();

        }
        //Not a user
        else
        {
            lblError.Text = "Please Enter a Username & Password";
        }



    }
}