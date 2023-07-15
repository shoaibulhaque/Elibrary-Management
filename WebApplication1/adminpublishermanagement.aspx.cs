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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;  // Database  connection string
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView2.DataBind();

        }


        // Add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                Response.Write("<script>alert('Publisher  with this ID already exists !');</script>");
            }
            else
            {
                addNewPublisher();
                Response.Write("<script>alert('Publisher added successfully');</script>");

                
            }


        }
        

        // Update  button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                updatePublisher();

            }
            else
            {

                Response.Write("<script>alert('Publisher does not exist !');</script>");

            }




        }

        // Delete button
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                deletePublisher();

            }
            else
            {
                Response.Write("<script>alert('Publisher does not exist !');</script>");
            }

        }


        // Go button
        protected void Button21_Click(object sender, EventArgs e)
        {
            getPublisherById();
        }



        // User defined functions
        bool checkPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // Creating  a query command to execute
                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id='"+ TextBox3.Text.Trim() +"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }




            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
                return false;
            }


        }

        //function to add publisher

        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl (publisher_id, publisher_name) values (@publisher_id, @publisher_name)", con);

                // filling placeholders defined in the SQL query in order to make it dynamic
                cmd.Parameters.AddWithValue("@publisher_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                clearForm();
                GridView2.DataBind();

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }


        }

        void clearForm()
        {
            TextBox2.Text = "";
            TextBox3.Text = "";
        }

        // update publisher function
        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed )
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name=@publisher_name WHERE publisher_id='" + TextBox3.Text.Trim() + "';", con);

                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher updated');</script>");
                clearForm();
                GridView2.DataBind();




            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }


        }

        // Delete author function
        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl WHERE publisher_id ='" + TextBox3.Text.Trim() + "' ", con);

                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Deleted !');</script>");
                clearForm();
                GridView2.DataBind();




            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }





        }

        // get publisher by ID function
        void getPublisherById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // creating a query command
                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id ='" + TextBox3.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); // disconnected architecture 
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();   /// Rows[0][1] where [0]  --> first row and [1] --> 2nd column

                }
                else
                {
                    Response.Write("<script>alert('Invalid publisher Id');</script>");

                }



            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }


        }

    }
}