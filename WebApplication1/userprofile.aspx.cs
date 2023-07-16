using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getUserBookData();

                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        // update button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                updateUserPersonalDetails();

            }
        }



        // user defined function


        void updateUserPersonalDetails()
        {
            string password = "";
            if (TextBox10.Text.Trim() == "")
            {
                password = TextBox9.Text.Trim();
            }
            else
            {
                password = TextBox10.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                string fullName = TextBox1.Text.Trim();
                string dob = TextBox2.Text.Trim();
                string contactNo = TextBox3.Text.Trim();
                string email = TextBox4.Text.Trim();
                string state = DropDownList1.SelectedItem.Value;
                string city = TextBox6.Text.Trim();
                string pincode = TextBox7.Text.Trim();
                string fullAddress = TextBox5.Text.Trim();
                string pass = TextBox9.Text.Trim();



                // Validate input values
                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(dob) || string.IsNullOrEmpty(contactNo) ||
                    string.IsNullOrEmpty(email) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(city) ||
                    string.IsNullOrEmpty(pincode) || string.IsNullOrEmpty(fullAddress) ||
                    string.IsNullOrEmpty(pass))
                {
                    // Show alert message if any required field is empty
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please fill in all the required fields.');", true);
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

                if (pass.Length <= 6)
                {
                    // Show alert message if password length is not greater than 6
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Password must be greater than 6 characters.');", true);
                    return;
                }

                if (!Regex.IsMatch(fullName, @"^[A-Za-z ]+$"))
                {
                    // Show alert message if full name format is incorrect
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter a valid full name.');", true);
                    return;
                }


                if (!Regex.IsMatch(email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
                {
                    // Show alert message if email format is incorrect
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter a valid email address.');", true);
                    return;
                }

                // Check if the contact number already exists in the database
                SqlCommand checkContactNoCmd = new SqlCommand("SELECT COUNT(*) FROM member_master_tbl WHERE contact_no = @contact_no AND member_id <> @member_id", con);
                checkContactNoCmd.Parameters.AddWithValue("@contact_no", contactNo);
                checkContactNoCmd.Parameters.AddWithValue("@member_id", Session["username"].ToString().Trim());
                int contactNoCount = (int)checkContactNoCmd.ExecuteScalar();

                if (contactNoCount > 0)
                {
                    // Show alert message if the contact number already exists
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('The contact number is already registered.');", true);
                    return;
                }

                // Check if the email already exists in the database
                SqlCommand checkEmailCmd = new SqlCommand("SELECT COUNT(*) FROM member_master_tbl WHERE email = @email AND member_id <> @member_id", con);
                checkEmailCmd.Parameters.AddWithValue("@email", email);
                checkEmailCmd.Parameters.AddWithValue("@member_id", Session["username"].ToString().Trim());
                int emailCount = (int)checkEmailCmd.ExecuteScalar();

                if (emailCount > 0)
                {
                    // Show alert message if the email already exists
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('The email address is already registered.');", true);
                    return;
                }

                SqlCommand cmd = new SqlCommand("update member_master_tbl set full_name=@full_name, dob=@dob, contact_no=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_address=@full_address, password=@password, account_status=@account_status WHERE member_id='" + Session["username"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", contactNo);
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", pincode);
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");
                cmd.Parameters.AddWithValue("@member_id", Session["username"].ToString().Trim());

                int result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                {

                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    getUserPersonalDetails();
                    getUserBookData();
                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                TextBox2.Text = dt.Rows[0]["dob"].ToString();
                TextBox3.Text = dt.Rows[0]["contact_no"].ToString();
                TextBox4.Text = dt.Rows[0]["email"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                TextBox6.Text = dt.Rows[0]["city"].ToString();
                TextBox7.Text = dt.Rows[0]["pincode"].ToString();
                TextBox5.Text = dt.Rows[0]["full_address"].ToString();
                TextBox8.Text = dt.Rows[0]["member_id"].ToString();
                TextBox9.Text = dt.Rows[0]["password"].ToString();

                Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void getUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_issue_tbl where member_id='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}