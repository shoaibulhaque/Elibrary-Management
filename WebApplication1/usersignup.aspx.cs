using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class usersignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString; // Added database connectivity ( Step 1 )
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       // Sign up button click event
        protected void Button1_Click1(object sender, EventArgs e)
        {
           //Response.Write("<script>alert('Testing');</script>"); // just checking 

           // Good practice to enclose server and database related things in try-catch block

           try
            {
               SqlConnection con = new SqlConnection(strcon); // ( Step 1 of Sign up Event ) -- we created an object of SqlConnection class and passed in our varible "strcon" which contains the database connection string. syntax ( Object instantiation C# ) --> <ClassName> object_name = new <ClassName>(any_param)

               // ( Step 2 checking connectivity with database )
               if (con.State == ConnectionState.Closed) // Check if connection is closed
               {
                   con.Open(); // Open the connection, if closed
               }

               // Creating and executing SQL query to save all the data in its relevant database table

               SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) values(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", con); // To keep it dynamic, we have used @ with placeholder names in values.

               // Ectracting data from the textboxes and putting them into the placeholders defined in the sql 'INSERT' command
               cmd.Parameters.AddWithValue("@full_name", TextBox3.Text.Trim());
               cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
               cmd.Parameters.AddWithValue("@Contact_no", TextBox1.Text.Trim());
               cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
               cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
               cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
               cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
               cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
               cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
               cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
               cmd.Parameters.AddWithValue("@account_status", "pending");

               cmd.ExecuteNonQuery(); // Fire ( Execute ) the query 
               con.Close(); // Close the Connection

               // Javascript pop-up
               Response.Write("<script>alert('Sign Up successful. Go to User Login to login');</script>");
                
           }
           catch (Exception ex)
           {
                // If any exception caught, pop it up its message
               Response.Write("<script>alert('" + ex.Message + "');</script>");
           }

        }
    }
}