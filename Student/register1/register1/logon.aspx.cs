using System;
using System.Data;
using System.Data.SqlClient;

using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace register
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TextBox1.Text.ToString());
            int password= int.Parse(TextBox2.Text.ToString());
            string str = " server=127.0.0.1;User ID=connect;Password=131;Database=DATABASE1.MDF";
            string sql = "select name from students where id=" + id +  " and password =" + password + ";";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader read = com.ExecuteReader();
            if(read.HasRows)
            {
                Response.Redirect("manage.aspx");
                read.Close();
            }
            con.Close();
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}