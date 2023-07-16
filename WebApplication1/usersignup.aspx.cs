using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
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
            //Response.Write("<script>alert('testing');</script>");// just checking 
            try
            {
                // ( step 1 ) --> first, check the connectivity

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // (step 2 ) --> sql query to check if any record with user's entered id exist or not

                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id = '" + TextBox8.Text.Trim()
                    + "';", con);

                // sql adapter to extract the result of the above sql
                // 
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();  // passing the record into c# datatable to store it temporarily store in order to measure the count of record
                da.Fill(dt); // filling the datatable with the record

                // checking if the record count is > or = 1 ( means, member exists already )

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else { return false; }



            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

        } 



        // Custom Function

        void signUpNewMember()
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

                string fullName = TextBox3.Text.Trim();
                string dob = TextBox2.Text.Trim();
                string contactNo = TextBox1.Text.Trim();
                string email = TextBox4.Text.Trim();
                string state = DropDownList1.SelectedItem.Value;
                string city = TextBox6.Text.Trim();
                string pincode = TextBox7.Text.Trim();
                string fullAddress = TextBox5.Text.Trim();
                string memberId = TextBox8.Text.Trim();
                string password = TextBox9.Text.Trim();
                string accountStatus = "pending";

                // Validate input values
                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(dob) || string.IsNullOrEmpty(contactNo) ||
                    string.IsNullOrEmpty(email) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(city) ||
                    string.IsNullOrEmpty(pincode) || string.IsNullOrEmpty(fullAddress) || string.IsNullOrEmpty(memberId) ||
                    string.IsNullOrEmpty(password))
                {
                    // Show alert message if any required field is empty
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please fill in all the required fields.');", true);
                    return;
                }

                if (!Regex.IsMatch(fullName, @"^[A-Za-z ]+$"))
                {
                    // Show alert message if full name format is incorrect
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter a valid full name.');", true);
                    return;
                }

                if (password.Length <= 6)
                {
                    // Show alert message if password length is not greater than 6
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Password must be greater than 6 characters.');", true);
                    return;
                }

                // Validate input values
                if (!Regex.IsMatch(contactNo, @"^\d{4}-\d{7}$"))
                {
                    // Show alert message if contact number is not in Pakistani format
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter the contact number in Pakistani format (e.g., 0000-0000000).');", true);
                    return;
                }

                if (!Regex.IsMatch(pincode, @"^\d{5}$"))
                {
                    // Show alert message if pincode is not in Pakistani format
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter the pincode in Pakistani format (e.g., 00000).');", true);
                    return;
                }

                // Check if the contact number already exists
                SqlCommand checkContactNoCmd = new SqlCommand("SELECT COUNT(*) FROM member_master_tbl WHERE contact_no = @contact_no", con);
                checkContactNoCmd.Parameters.AddWithValue("@contact_no", contactNo);
                int contactNoCount = (int)checkContactNoCmd.ExecuteScalar();

                // Check if the email already exists
                SqlCommand checkEmailCmd = new SqlCommand("SELECT COUNT(*) FROM member_master_tbl WHERE email = @email", con);
                checkEmailCmd.Parameters.AddWithValue("@email", email);
                int emailCount = (int)checkEmailCmd.ExecuteScalar();

                // Validate input values
                if (contactNoCount > 0)
                {
                    // Show alert message if the contact number already exists
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('The provided contact number is already registered. Please use a different contact number.');", true);
                    return;
                }

                if (emailCount > 0)
                {
                    // Show alert message if the email already exists
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('The provided email is already registered. Please use a different email.');", true);
                    return;
                }




                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name, dob, contact_no, email, state, city, pincode, full_address, member_id, password, account_status) " +
                        "VALUES (@full_name, @dob, @contact_no, @email, @state, @city, @pincode, @full_address, @member_id, @password, @account_status)",
                    con);

                cmd.Parameters.AddWithValue("@full_name", fullName);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@contact_no", contactNo);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@pincode", pincode);
                cmd.Parameters.AddWithValue("@full_address", fullAddress);
                cmd.Parameters.AddWithValue("@member_id", memberId);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", accountStatus);

                cmd.ExecuteNonQuery();
                con.Close(); // Close the Connection

                // Javascript pop-up
                Response.Write("<script>alert('Sign Up successful. Go to User Login to login');</script>");

            }
            catch (Exception ex) // where, ex --> Exception's class obj
            {
                // If any exception caught, pop it up its message using javascript
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}