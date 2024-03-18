using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace register
{
    public partial class manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("alter_mac.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("alter_password.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("register_mac.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}