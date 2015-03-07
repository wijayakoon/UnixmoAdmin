using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Neemo;

using Neemo.SupportClasses;

namespace NeemoAdmin
{
    public partial class Login : System.Web.UI.Page
    {
        private String strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

          if (!IsPostBack)
              Session["Loggedin"] = "0";

            if (Session["Loggedin"] == null)
                Session["Loggedin"] = "0";
                Session["AdminUser"] = false;
        }


   
      
    }
}