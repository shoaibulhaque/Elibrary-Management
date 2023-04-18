﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString; // database connectivity ( Step 1 ) 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // add button event
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                Response.Write("<script>alert('Author with this ID already exists.');</script>");
            }
            else
            {
                addNewAuthor();

            }





        }

        // update button event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                updateAuthor();
                
            }
            else
            {
                Response.Write("<script>alert('Author does not exist !');</script>");
            }
           

        }

        // delete button event
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                deleteAuthor();

            }
            else
            {
                Response.Write("<script>alert('Author does not exist !');</script>");
            }



        }


        // go button event
        protected void Button21_Click(object sender, EventArgs e)
        {
            getAuthorById();
        }


        void getAuthorById() 
        
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // creating a query command
                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id='" + TextBox3.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); // disconnected architecture 
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();   /// Rows[0][1] where [0]  --> first row and [1] --> 2nd column

                }
                else
                {
                    Response.Write("<script>alert('Invalid author Id');</script>");
                    
                }



            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");
                
            }



        }



        // custom function to update author
        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name=@author_name WHERE author_id='"+TextBox3.Text.Trim()+"';", con);

                // filling placeholders defined in the SQL query in order to make it dynamic
        
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Updated !');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }


        }




        // function to add author in table
        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl (author_id, author_name) values (@author_id, @author_name)", con);

                // filling placeholders defined in the SQL query in order to make it dynamic
                cmd.Parameters.AddWithValue("@author_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author added !');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('"+ex.Message+"');</script>");

            }


        }




        // user defined function

        bool checkIfAuthorExists() // function to check if author exists or not
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // creating a query command
                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id='"+ TextBox3.Text.Trim() +"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); // disconnected architecture 
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

        // delete author func

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed) { con.Open(); }

                SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl WHERE author_id='"+TextBox3.Text.Trim()+"' ", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author deleted !');</script>");
                clearForm();
                GridView1.DataBind();



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");

            }



        }

        // clear form
        void clearForm()
        {
            TextBox3.Text = "";
            TextBox2.Text = "";

        }


    }
}