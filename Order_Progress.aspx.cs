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
    public partial class Order_Progress : System.Web.UI.Page
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
                Session["OrderList"] = null;
            }
        }

      
       

        protected void OnPagingProduct(object sender, GridViewPageEventArgs e)
        {
            grv_PriceList.PageIndex = e.NewPageIndex;

        }



        protected void btn_UpdateOrder_Click(object sender, EventArgs e)
        {

            DbHandle clsDBHandle = new DbHandle();
            clsDBHandle.OpenConn();
            SqlParameter StoredProcParamArray = new SqlParameter();
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = clsDBHandle.cn;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandTimeout = 360;
            sqlCmd.CommandText = string.Format("Update OrderHeader set OrderStatusID ={0} where Guid ='{1}'", drp_OrderStatus_Edit.SelectedValue, lbl_OrderID.Text);
            sqlCmd.ExecuteNonQuery();
            grv_PriceList.DataBind();
            pnl_EditOrder.Visible = false;

        }

        protected void grv_PriceList_SelectedIndexChanging(object sender, EventArgs e)
        {
        }

        protected void GridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            string RootDomain = Request.Url.GetLeftPart(UriPartial.Authority);

            //Check if it's the right CommandName... 
            if (e.CommandName == "Select")
            {
                //Get the Row Index
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row
                GridViewRow row = grv_PriceList.Rows[index];

                // Here you can access the Row Cells 
                //string xx = row.Cells[1].Text;
                string orderHeaderID = row.Cells[4].Text;
                string orderstatusid = row.Cells[5].Text;
                lbl_OrderID.Text = orderHeaderID;

                ListItem selectedListItem = drp_OrderStatus_Edit.Items.FindByValue(orderstatusid);
                if (selectedListItem != null) selectedListItem.Selected = true;
                pnl_EditOrder.Visible = true;
                return;
            }

            if (e.CommandName == "ViewInvoice")
            {
                //Get the Row Index
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row
                GridViewRow row = grv_PriceList.Rows[index];

                // Here you can access the Row Cells 
                //string xx = row.Cells[1].Text;
                string orderHeaderID = row.Cells[2].Text;
                string orderstatusid = row.Cells[3].Text;
                lbl_OrderID.Text = orderHeaderID;

                ListItem selectedListItem = drp_OrderStatus_Edit.Items.FindByValue(orderstatusid);
                if (selectedListItem != null) selectedListItem.Selected = true;
                pnl_EditOrder.Visible = true;
                Session["OrderID"] = orderHeaderID;
                Response.Redirect(ConfigurationManager.AppSettings["InvoiceURL"].ToString() + orderHeaderID);
                //Response.Redirect(String.Format(@"\Admin\Reports\ReportViewer.aspx?InvoiceID={0}&ReportID={1}", orderHeaderID, "SalesInvoice"));
                return;
            }

            if (e.CommandName == "ProductKey")
            {
                //Get the Row Index
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row
                GridViewRow row = grv_PriceList.Rows[index];

                // Here you can access the Row Cells 
                //string xx = row.Cells[1].Text;
                string orderHeaderID = row.Cells[2].Text;
                string orderstatusid = row.Cells[3].Text;
                lbl_OrderID.Text = orderHeaderID;

                ListItem selectedListItem = drp_OrderStatus_Edit.Items.FindByValue(orderstatusid);
                if (selectedListItem != null) selectedListItem.Selected = true;
                pnl_EditOrder.Visible = true;
                Session["OrderID"] = orderHeaderID;
                Response.Redirect(RootDomain + "/OrderVerification.aspx?invoicerefernce=" + orderHeaderID);
                //Response.Redirect("/Admin/Reports/AdminReportViewer.aspx");
                //Response.Redirect(String.Format(@"\Admin\Reports\ReportViewer.aspx?InvoiceID={0}&ReportID={1}", orderHeaderID, "SalesInvoice"));
                return;
            }

            if (e.CommandName == "IssueProductKeys")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row
                GridViewRow row = grv_PriceList.Rows[index];
                string orderHeaderID = row.Cells[2].Text;
                string orderstatusid = row.Cells[3].Text;
                int TotalQty = 1;
                int returnCount = 0;

                //Save order Header

                //totalorder = _orderTotal;
                using (SqlConnection con = DBConnection.connection())
                {
                    con.Open();

                    returnCount = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "Get_RegistrationKeysBy_InvoiceGUID", orderHeaderID, returnCount));
                    if (returnCount == 0)
                    {
                        TotalQty = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "Get_OrderQuantity_Count", orderHeaderID, returnCount));
                        SqlHelper.ExecuteNonQuery(con, "RegistrationKey_InvoiceGUID_Update", orderHeaderID, TotalQty);
                    }
                }
                
                ListItem selectedListItem = drp_OrderStatus_Edit.Items.FindByValue(orderstatusid);
                if (selectedListItem != null) selectedListItem.Selected = true;
                pnl_EditOrder.Visible = true;
                Session["OrderID"] = orderHeaderID;
                Response.Redirect(RootDomain + "/OrderVerification.aspx?invoicerefernce=" + orderHeaderID);
                return;
            }

            
        }
    }
}