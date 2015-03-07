using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Neemo.Admin
{
    public partial class Part_Search : System.Web.UI.Page
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
            SqlDataSourceParts.DataBind();
            GridView1.DataBind();
            
        }

        public void GridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {            
            if (e.CommandName == "Select")
            {                
                int index = Convert.ToInt32(e.CommandArgument);                
                GridViewRow row =  GridView1.Rows[index];                
                ListItem item = new ListItem();                
                Response.Redirect("Part_Edit.aspx?PartID=" + Server.HtmlDecode(row.Cells[1].Text));               
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            SqlDataSourceParts = new SqlDataSource();
            SqlDataSourceParts.SelectCommand = "sp_searchPart_All";
            SqlDataSourceParts.SelectParameters.Add("@CategoryID", drp_Category.SelectedValue);
            SqlDataSourceParts.SelectParameters.Add("@Part", txt_Search.Text);
            SqlDataSourceParts.DataBind();
            GridView1.DataBind();
        }
        protected void btn_New_Click(object sender, EventArgs e)
        {
            Response.Redirect("Part_New.aspx");
        }
  
    }
}