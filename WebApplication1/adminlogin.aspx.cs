﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class adminlogin : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString; // Added database connectivity ( Step 1 )

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        // login Button Event
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from admin_login_tbl where username='"+TextBox1.Text.Trim()+"' AND password='"+TextBox2.Text.Trim()+"'; ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Login Successful !');</script>");
                        // Creating session variables ---> global throughout the session 
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["fullname"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";  // Hardcoded as only links which are permissible for user will be shown 


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