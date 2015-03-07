using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Neemo.Admin.DataServices;
using System.Data.SqlClient;

namespace Neemo.Admin
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
            //SqlParameter[] SProcParamArray = new SqlParameter[5];
            //SProcParamArray[0] = new SqlParameter("@ProductID", ProductID);
            //SProcParamArray[1] = new SqlParameter("@WreckID", WreckID);
            //SProcParamArray[2] = new SqlParameter("@PartID", PartID);
            //SProcParamArray[3] = new SqlParameter("@WreckNo", Wreck.WreckNo);
            //SProcParamArray[4] = new SqlParameter("@Part", Part.Part);
            //SProcParamArray[5] = new SqlParameter("@Status", Status);
            //SProcParamArray[6] = new SqlParameter("@WreckNo", Wreck.WreckNo);
            //SProcParamArray[7] = new SqlParameter("@Usage", Usage); 
            

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
                Response.Redirect("Product_New.aspx?ProductID=" + Server.HtmlDecode(row.Cells[1].Text));
               
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
          SqlDataSource1.SelectCommand= string.Format("SELECT ProductID,Product,Active,Image,EffectiveDateFrom,EffectiveDateTo,CreatedDateTime,DeletedDateTime FROM Product Where Product Like '%{0}%'  ORDER BY [Product]",TextBox_Search.Text);
          SqlDataSource1.DataBind();
          gv_Products.DataBind();

        }

        protected void btn_New_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product_New.aspx");
        }
  
    }
}