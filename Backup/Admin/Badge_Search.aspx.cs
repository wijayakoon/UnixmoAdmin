using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Neemo.Admin
{
    public partial class Badge_Search : System.Web.UI.Page
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
        }

        public void GridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {            
            if (e.CommandName == "Select")
            {                
                int index = Convert.ToInt32(e.CommandArgument);                
                GridViewRow row =  GridView1.Rows[index];                
                ListItem item = new ListItem();
                Response.Redirect("Badge_Edit.aspx?BadgeID=" + Server.HtmlDecode(row.Cells[1].Text));
               
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
          SqlDataSource1.SelectCommand= string.Format("SELECT BadgeID,Badge,Active,Image,EffectiveDateFrom,EffectiveDateTo,CreatedDateTime,DeletedDateTime FROM Badge Where Badge Like '%{0}%'  ORDER BY [Badge]",TextBox_Search.Text);
          SqlDataSource1.DataBind();
          GridView1.DataBind();

        }

        protected void btn_New_Click(object sender, EventArgs e)
        {
            Response.Redirect("Badge_New.aspx");
        }
  
    }
}