using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeemoAdmin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUser"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if (Session["AdminUser"].ToString() == "true")
            {    
                Response.Redirect("~/default.aspx");
            }


        }
    }
}
