using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NeemoAdmin.SupportClasses;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using Neemo.SupportClasses;
using System.Globalization;
using NeemoAdmin.DataServices;

namespace NeemoAdmin
{


    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           ReportViewer2.LocalReport.EnableHyperlinks = true;
        }

        protected void btnAddTocart_Click(object sender, EventArgs e)
        {
            
        }
    }
}