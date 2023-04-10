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
    public partial class userlogin : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString; // Added database connectivity ( Step 1 )

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Login button Event
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Response.Write("<script>alert('Button clicked');</script>"); // checking 
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // we are using connected architecture here, using Data reader
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl where member_id='"+TextBox1.Text.Trim()+"' AND password='"+TextBox2.Text.Trim()+"';", con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows) // Gives true of false, depending whether some record exists or not. ( In case of incorrect or pass or id, we will not get any matching row as record )
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Login Successful !');</script>");

                        // Creating session variables ---> global throughout the session 
                        Session["username"] = dr.GetValue(8).ToString();  
                        Session["fullname"] = dr.GetValue(0).ToString();  
                        Session["role"] = "user";  // Hardcoded as only links which are permissible for user will be shown 
                        Session["status"] = dr.GetValue(10).ToString(); // GetValue() --> find by index


                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials');</script>");
                }



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }



        }
    }
}