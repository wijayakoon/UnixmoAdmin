using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NeemoAdmin.SupportClasses;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Neemo.SupportClasses;
using System.Configuration;
using System.Globalization;

namespace NeemoAdmin
{
    public partial class DisplayOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataView dv = (DataView)sql_OrderHeader.Select(DataSourceSelectArguments.Empty);
                foreach (DataRowView rowView in dv)
                {
                    DataRow row = rowView.Row;
                    //DateTime dt1 = DateTime.ParseExact(row["EffectiveDateFrom"].ToString(), "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                    //DateTime dt2 = DateTime.ParseExact(row["EffectiveDateTo"].ToString(), "dd/mm/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                    lbl_InvoiceNo.Text = row["OrderHeaderID"].ToString();
                    lbl_InvoiceDate.Text = row["DateCreated"].ToString();

                    lbl_BillingCompanyName.Text = row["Billing_CompanyName"].ToString();
                    lbl_BillingFirstName.Text = row["Billing_FirstName"].ToString();
                    lbl_BillingLastName.Text = row["Billing_LastName"].ToString();
                    lbl_BillingAddress.Text = row["Billing_Address"].ToString();
                    lbl_BillingCity.Text = row["Billing_City"].ToString();
                    lbl_BillingState.Text = row["Billing_State"].ToString();
                    lbl_BillingPostCode.Text = row["Billing_PostCode"].ToString();
                    lbl_InvoiceDate.Text = row["DateCreated"].ToString();

                    lbl_ShippingCharges.Text = string.Format("{0:#.00}", Convert.ToDecimal(row["ShippingCharges"].ToString()));
                    lbl_Tax.Text = string.Format("{0:#.00}", Convert.ToDecimal(row["TaxTotal"].ToString()));
                    lbl_Total.Text = string.Format("{0:#.00}", Convert.ToDecimal(row["TotalAmount"].ToString()));

                    lblNetTotal.Text = (Convert.ToDouble(lbl_Total.Text) - Convert.ToDouble(lbl_Tax.Text) - (Convert.ToDouble(lbl_ShippingCharges.Text))).ToString();
                    lblNetTotal.Text = string.Format("{0:#.00}", Convert.ToDecimal(lblNetTotal.Text));

                    //lbl_ShippingCharges.Text = Convert.ToDecimal(row["ShippingCharges"]).ToString ("#.##");
                    //lbl_Tax.Text =Convert.ToDecimal(row["TaxTotal"]).ToString ("#.##");
                    //lbl_Total.Text = Convert.ToDecimal(row["TotalAmount"]).ToString("#.##");
                    //lblNetTotal.Text = (Convert.ToDouble(lbl_Total.Text) - Convert.ToDouble(lbl_Tax.Text) - (Convert.ToDouble(lbl_ShippingCharges.Text))).ToString();
                    //lblNetTotal.Text = Convert.ToDecimal(lblNetTotal.Text).ToString ("#.##");
                }

            }
        }

        protected void Button_Reset_Click(object sender, EventArgs e)
        {
        }

      

        protected void Button_Save_Click(object sender, EventArgs e)
        {
        }

          }


}