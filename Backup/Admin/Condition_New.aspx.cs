using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Neemo.Admin.SupportClasses;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Neemo.SupportClasses;
using System.Configuration;
using System.Globalization;

namespace Neemo.Admin
{
    public partial class Condition_New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox_EffectiveDateFrom.Text = DateTime.Now.ToShortDateString();
        }

        protected void Button_Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Condition_New.aspx");
        }

      

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            saverec(); Response.Redirect("/admin/Condition_New.aspx");
        }

        private void saverec()
        {

            try
            {

                SqlParameter StoredProcParamArray = new SqlParameter();
                SqlCommand sqlCmd = new SqlCommand();
                DbHandle clsDBHandle = new DbHandle();

                //Save order Header    
                //DateTime dt = DateTime.ParseExact(TextBox_EffectiveDateFrom.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                sqlCmd.Parameters.AddWithValue("@Condition", TextBox_Name.Text);
                sqlCmd.Parameters.AddWithValue("@EffectiveDateFrom", Convert.ToDateTime(TextBox_EffectiveDateFrom.Text));                
                sqlCmd.Parameters.AddWithValue("@Image", Path.GetFileName(Image_Icon.ImageUrl));
                clsDBHandle.OpenConn();
                sqlCmd.Connection = clsDBHandle.cn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = 360;
                sqlCmd.CommandText = "[Condition_Insert]";
                sqlCmd.ExecuteScalar(); ScriptManager.RegisterStartupScript(this, this.GetType(), "Completed", "javascript:Display('Record Saved')", true);
            }
            catch (Exception e)
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            PhotoUpload pupl = new PhotoUpload();
            
            Image_Icon = pupl.UploadNewImages(FileUpload_Image, Image_Icon,ConfigurationManager.AppSettings["LookupIcons"].ToString(), TextBox_Name.Text);
        }
    }


}