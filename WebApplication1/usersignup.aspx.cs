using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

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
            if (checkMemberExist()) // checking if checkmemberexist() returns true of false 
            {
                Response.Write("<script>alert('member already exist with this member id, try again with a different one !');</script>");
            }
            else // if false, then signup only 
            {
                signUpNewMember();
            }


        }

        // Custom func to check if member already exists or not
        bool checkMemberExist() // returns a boolean value
        {
            Response.Write("<script>alert('Testing');</script>");
            return true;// just checking 
            //try
            //{   
            //    // ( Step 1 ) --> first, check the connectivity

            //    SqlConnection con = new SqlConnection(strcon);
            //    if (con.State == ConnectionState.Closed)
            //    {
            //        con.Open();
            //    }

            //    // (Step 2 ) --> SQL query to check if any record with user's entered id exist or not

            //    SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tb1 where member_id = '"+TextBox8.Text.Trim()
            //        +"';", con);

            //    // Sql adapter to extract the result of the above SQL
            //    // 
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();  // passing the record into C# Datatable to store it temporarily store in order to measure the count of record
            //    da.Fill(dt); // filling the datatable with the record

            //    // checking if the record count is > or = 1 ( means, member exists already )

            //    if (dt.Rows.Count >= 1)
            //    {
            //        return true;
            //    }
            //    else { return false; }



            //}

            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('" + ex.Message + "');</script>");
            //    return false;
            //}

        } 



        // Custom Function

        void signUpNewMember()
        {
            Response.Write("<script>alert('Testing');</script>"); // just checking 

            // Good practice to enclose server and database related things in try-catch block

            //try
            //{
            //    SqlConnection con = new SqlConnection(strcon); // ( Step 1 of Sign up Event ) -- we created an object of SqlConnection class and passed in our varible "strcon" which contains the database connection string. syntax ( Object instantiation C# ) --> <ClassName> object_name = new <ClassName>(any_param)

            //    // ( Step 2 checking connectivity with database )
            //    if (con.State == ConnectionState.Closed) // Check if connection is closed
            //    {
            //        con.Open(); // Open the connection, if closed
            //    }

            //    // Creating and executing SQL query to save all the data in its relevant database table

            //    SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tb1(member_id,full_name,dob,contact_no,email,state,city,pincode,full_address,password,account_status) values(@member_id,@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@password,@account_status)", con); // To keep it dynamic, we have used @ with placeholder names in values.

            //    // Ectracting data from the textboxes and putting them into the placeholders defined in the sql 'INSERT' command
            //    cmd.Parameters.AddWithValue("@full_name", TextBox3.Text.Trim());
            //    cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
            //    cmd.Parameters.AddWithValue("@Contact_no", TextBox1.Text.Trim());
            //    cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
            //    cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
            //    cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
            //    cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
            //    cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
            //    cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
            //    cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
            //    cmd.Parameters.AddWithValue("@account_status", "pending");

            //    cmd.ExecuteNonQuery(); // Fire ( Execute ) the query 
            //    con.Close(); // Close the Connection

            //    // Javascript pop-up
            //    Response.Write("<script>alert('Sign Up successful. Go to User Login to login');</script>");

            //}
            //catch (Exception ex) // where, ex --> Exception's class obj
            //{
            //    // If any exception caught, pop it up its message using javascript
            //    Response.Write("<script>alert('" + ex.Message + "');</script>");
            //}
        }
    }
}