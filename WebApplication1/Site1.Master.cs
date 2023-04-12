using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try  // checking whether the session variable is set or not
            {
                if (Session["role"] == null) // means ---> fresh load
                {
                    // making certain links visible according to the fresh load of website

                    LinkButton1.Visible  = true; // User login link button
                    LinkButton2.Visible  = true; // Sign up link button

                    LinkButton3.Visible  = false; // Logout link button
                    LinkButton7.Visible  = false; // Hello User link button

                    // Admin role links 

                    LinkButton6.Visible  = true; // Admin login link button

                    LinkButton11.Visible = false; // author management link button
                    LinkButton12.Visible = false; // oublisher management link button
                    LinkButton8.Visible  = false; // book inventory link button
                    LinkButton9.Visible  = false; // book issuing link button
                    LinkButton10.Visible = false; // member management link button


                }
                else if (Session["role"].Equals("user"))
                {

                    // User role links

                    LinkButton1.Visible = false; // User login link button
                    LinkButton2.Visible = false; // Sign up link button

                    LinkButton3.Visible = true; // Logout link button
                    LinkButton7.Visible = true; // Hello User link button
                    LinkButton7.Text = "Hello " + Session["username"].ToString();


                    // Admin role links 

                    LinkButton6.Visible = true; // Admin login link button
                    LinkButton11.Visible = false; // author management link button
                    LinkButton12.Visible = false; // oublisher management link button
                    LinkButton8.Visible = false; // book inventory link button
                    LinkButton9.Visible = false; // book issuing link button
                    LinkButton10.Visible = false; // member management link button


                }
                else if (Session["role"].Equals("admin"))
                {

                    // User role links

                    LinkButton1.Visible = false; // User login link button
                    LinkButton2.Visible = false; // Sign up link button

                    LinkButton3.Visible = true; // Logout link button
                    LinkButton7.Visible = true; // Hello User link button
                    LinkButton7.Text = "Hello Admin";


                    // Admin role links 

                    LinkButton6.Visible = false; // Admin login link button
                    LinkButton11.Visible = true; // author management link button
                    LinkButton12.Visible = true; // oublisher management link button
                    LinkButton8.Visible = true; // book inventory link button
                    LinkButton9.Visible = true; // book issuing link button
                    LinkButton10.Visible = true; // member management link button


                }



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }




        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }


        // Logout button link
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            // Making all the session variables blank
            Session["username"] = null;
            Session["fullname"] = null;
            Session["role"]     = null;
            Session["status"]   = null;

            LinkButton1.Visible = true; // User login link button
            LinkButton2.Visible = true; // Sign up link button

            LinkButton3.Visible = false; // Logout link button
            LinkButton7.Visible = false; // Hello User link button

            // Admin role links 

            LinkButton6.Visible = true; // Admin login link button

            LinkButton11.Visible = false; // author management link button
            LinkButton12.Visible = false; // oublisher management link button
            LinkButton8.Visible = false; // book inventory link button
            LinkButton9.Visible = false; // book issuing link button
            LinkButton10.Visible = false; // member management link button

            Response.Redirect("homepage.aspx");

        }
    }
}