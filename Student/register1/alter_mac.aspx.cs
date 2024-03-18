using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace register
{
    public partial class alter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TextBox1.Text.ToString());
            string mac = TextBox2.Text;

            string sql = "update students set mac = '" + mac + "' where id = " + id + ";";
            string str = " server=127.0.0.1;User ID=connect;Password=131;Database=DATABASE1.MDF";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);
            int success=com.ExecuteNonQuery();
            if (success>0)
            { Response.Redirect("alter_success.aspx");}
            con.Close();
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage.aspx");
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}