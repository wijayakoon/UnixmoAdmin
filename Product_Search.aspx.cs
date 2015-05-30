using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NeemoAdmin.DataServices;
using System.Data.SqlClient;

namespace NeemoAdmin
{
    public partial class Product_Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Loggedin"] == null)
            {
                Response.Redirect("Login.aspx"); 
            }
            if (Session["Loggedin"].ToString() != "1")
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindDataGrid();
            }
        }

        private void BindDataGrid()
        { 
            Products product = new Products();
            product.Part.Part = TextBox_Search.Text;
            product.Usage = "SearchByName";
            gv_Products.DataSource = product.Find();
            gv_Products.DataBind();

        }

        public void GridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {            
            if (e.CommandName == "Select")
            {                
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gv_Products.Rows[index];                
                ListItem item = new ListItem();
                Response.Redirect("Product_Update.aspx?ProductID=" + Server.HtmlDecode(row.Cells[1].Text));
               
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            BindDataGrid();
        }

        protected void btn_New_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product_New.aspx");
        }
  
    }
}