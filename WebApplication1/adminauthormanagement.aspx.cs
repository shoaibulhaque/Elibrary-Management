using System;
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

        }

        // add button event
        protected void Button2_Click(object sender, EventArgs e)
        {





        }

        // update button event
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        // delete button event
        protected void Button5_Click(object sender, EventArgs e)
        {

        }


        // go button event
        protected void Button21_Click(object sender, EventArgs e)
        {

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

                SqlCommand cmd = new SqlCommand("SELECT * from author_master_table where author_id='"+ TextBox3.Text.Trim() +"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
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


    }
}