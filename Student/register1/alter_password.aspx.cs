using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace register
{
    public partial class alter_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(SqlDataSource1.ConnectionString);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TextBox3.Text.ToString());
            int old_password= int.Parse(TextBox1.Text.ToString());
            int new_passsword = int.Parse(TextBox2.Text.ToString());

            string find = "select name from students where id=" + id + " and password =" + old_password + ";";
            string sql = "update students set password = " + new_passsword + " where id = " + id + ";";
            string str = " server=192.168.1.111;User ID=connect;Password=131;Database=DATABASE1.MDF";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            Response.Write(SqlDataSource1.ConnectionString);
            SqlCommand com1 = new SqlCommand(find, con);
            SqlDataReader read = com1.ExecuteReader();
            if (read.HasRows)
            {
                read.Close();
                SqlCommand com2 = new SqlCommand(sql, con);
                int success = com2.ExecuteNonQuery();
                if (success > 0)
                { Response.Redirect("alter_success.aspx"); }
                
            }
            con.Close();

        }
    }
}