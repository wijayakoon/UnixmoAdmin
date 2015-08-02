using NeemoAdmin.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeemoAdmin
{
    public partial class Provider_Search : System.Web.UI.Page
    {
        Providers provider = new Providers();
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
            if (!Page.IsPostBack)
            {
                //DataBind();
                PopulateDll();


            }

        }
        protected void PopulateDll()
        {
            //Categories categories = new Categories(); categories.PopulateDllAll(drp_Category);
            ProviderTypes providerTypes = new ProviderTypes(); providerTypes.PopulateDllAll(drp_ProviderTypes);
            ServiceTypes serviceTypes = new ServiceTypes(); serviceTypes.PopulateDllAll(drp_ServiceTypes);
        }

        public void GridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {            
            if (e.CommandName == "Select")
            {                
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gv_Provider.Rows[index];                
                ListItem item = new ListItem();                
                Response.Redirect("Provider_Edit.aspx?ProviderID=" + Server.HtmlDecode(row.Cells[1].Text));               
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            DataBind();
           
        }
        protected void btn_New_Click(object sender, EventArgs e)
        {
            Response.Redirect("Provider_New.aspx");
        }

        protected void DataBind()
        { 
            provider.ProviderID = Convert.ToInt32(txt_ProviderID.Text);
            provider.ProviderType.ProviderTypeID = Convert.ToInt32(drp_ProviderTypes.SelectedValue);
            provider.ServiceType.ServiceTypeID= Convert.ToInt32(drp_ServiceTypes.SelectedValue);
            provider.ProviderName= (txt_ProviderName.Text);
            provider.Street = (txt_Street.Text);
            provider.City= (txt_City.Text);
            provider.State= (txt_State.Text);
            gv_Provider.DataSource = provider.FindDetails();
            gv_Provider.DataBind();
        }
    }
}