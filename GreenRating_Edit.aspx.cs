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

namespace NeemoAdmin
{
    public partial class GreenRating_Edit : System.Web.UI.Page
    {
        public ApplicationConstants apc = new ApplicationConstants();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataView dv = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
                foreach (DataRowView rowView in dv)
                {
                    DataRow row = rowView.Row;
                    //DateTime dt1 = DateTime.ParseExact(row["EffectiveDateFrom"].ToString(), "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                    //DateTime dt2 = DateTime.ParseExact(row["EffectiveDateTo"].ToString(), "dd/mm/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                    TextBox_Name.Text = (string)row.ItemArray[1];
                    TextBox_EffectiveDateFrom.Text = row["EffectiveDateFrom"].ToString();
                    TextBox_EffectiveDateTo.Text = row["EffectiveDateTo"].ToString() ;
                    Image_Icon.ImageUrl = ConfigurationManager.AppSettings["LookupIcons_Display"].ToString() + ((row["Image"] == null) ? "" : row["Image"]);
                    CheckBox_Active.Checked = (bool)row["Active"];
                }

            }
        }

        protected void Button_Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("GreenRating_New.aspx");
            
        }

        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            PhotoUpload pupl = new PhotoUpload();
            Image_Icon = pupl.UploadNewImages(FileUpload_Image, Image_Icon, ConfigurationManager.AppSettings["LookupIcons"].ToString(), TextBox_Name.Text);
        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            saverec();
        }
        private void saverec()
        {

            try
            {

                SqlParameter StoredProcParamArray = new SqlParameter();
                SqlCommand sqlCmd = new SqlCommand();
                DbHandle clsDBHandle = new DbHandle();

                //Save order Header
                
                sqlCmd.Parameters.AddWithValue("@GreenRatingID", Convert.ToInt16(Request.QueryString["GreenRatingID"].ToString()));
                sqlCmd.Parameters.AddWithValue("@GreenRating", TextBox_Name.Text);
                if (TextBox_EffectiveDateFrom.Text != string.Empty)
                {
                    //DateTime dt1 = DateTime.ParseExact(TextBox_EffectiveDateFrom.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    sqlCmd.Parameters.AddWithValue("@EffectiveDateFrom", Convert.ToDateTime(TextBox_EffectiveDateFrom.Text));
                }
                else
                {
                    sqlCmd.Parameters.AddWithValue("@EffectiveDateFrom", DBNull.Value);
                }

                if (TextBox_EffectiveDateTo.Text != string.Empty)
                {
                    //DateTime dt2 = DateTime.ParseExact(TextBox_EffectiveDateTo.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    sqlCmd.Parameters.AddWithValue("@EffectiveDateTo", Convert.ToDateTime(TextBox_EffectiveDateTo.Text));
                }
                else
                {
                    sqlCmd.Parameters.AddWithValue("@EffectiveDateTo", DBNull.Value);
                }
                
                sqlCmd.Parameters.AddWithValue("@Image", Path.GetFileName(Image_Icon.ImageUrl));
                sqlCmd.Parameters.AddWithValue("@Active", CheckBox_Active.Checked);
                clsDBHandle.OpenConn();
                sqlCmd.Connection = clsDBHandle.cn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = 360;
                sqlCmd.CommandText = "[GreenRating_Update]";
                sqlCmd.ExecuteScalar(); ScriptManager.RegisterStartupScript(this, this.GetType(), "Completed", "javascript:Display('Record Saved')", true);


            }
            catch (Exception e)
            {
                Response.Redirect("Error.aspx");
            }
        }

    }
}