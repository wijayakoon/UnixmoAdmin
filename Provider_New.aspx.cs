using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Net;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using Neemo.SupportClasses;
using System.Data.SqlClient;
using NeemoAdmin.SupportClasses;
using System.Configuration;
using NeemoAdmin.DataServices;

namespace NeemoAdmin
{
    public partial class Provider_New : System.Web.UI.Page
    {
        Providers provider = new Providers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDll();
                Session["ServiceTypeList"] = null;
                Session["ProviderTypeList"] = null;
                

            }

            if ((Session["ProviderTypeList"] == null) && (Session["ServiceTypeList"] == null))
            {
                initServiceTypeList();
                initProviderTypeList();
            }
            else
            {
                if (!IsPostBack) { BindDataProviderTypes(); BindDataServiceTypes(); }

            }

           
            
            
        }

        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            PhotoUpload pupl = new PhotoUpload();
            Random rnd = new Random();
            Image_Icon = pupl.UploadNewImages(FileUpload_Image, Image_Icon, ConfigurationManager.AppSettings["LookupIcons"].ToString(), rnd.ToString());
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {            
            
            btncancel_Click(sender, e);
        }

       
        
       
        protected void btncancel_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("DisplayhandlingList.aspx");
          
        }
        protected void Button_Save_Click(object sender, EventArgs e)
        {
            //bool bln = ValidateserviceExist();


            //if (!bln)
            {
                saverec();
                Session["ServiceTypeList"] = null;
                Session["ProviderTypeList"] = null;
                
            }
        }
        private void saverec()
        {
            DbHandle clsDBHandle = new DbHandle();
            int _partID;
            clsDBHandle.OpenConn();
            _partID = 0;
            try
            {
                RegistrationDetails rd = (RegistrationDetails)Session["RegistrationDetails"];
                SqlParameter StoredProcParamArray = new SqlParameter();
                SqlCommand sqlCmd = new SqlCommand();

                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add();
                if (Session["ServiceTypeList"] != null)
                {
                    dt = Session["ServiceTypeList"] as DataTable;

                }

                if (dt.Rows.Count == 0)
                {
                    lbl_NoPriceWarning.Visible = true;
                    return;
                }
                else
                {
                    lbl_NoPriceWarning.Visible = false;
                }

              
                //Save Product 

                PhotoUpload pupl = new PhotoUpload();
                provider.ProviderName = txt_ProviderName.Text;
                provider.Description= txt_Description.Text;
                provider.Keyword=txt_Description.Text;
                provider.FirstName=txt_FirstName.Text;
                provider.LastName=txt_LastName.Text;
                provider.LevelNo=Request.Form["levelno"];
                provider.UnitNo=Request.Form["unitno"];
                provider.StreetNo=Request.Form["street_number"];
                provider.Street=Request.Form["route"];
                provider.City=Request.Form["locality"];
                provider.State=Request.Form["administrative_area_level_1"];
                provider.PostCode=Request.Form["postal_code"];
                provider.Country=Request.Form["country"];
                provider.Longitude=Request.Form["latitude"];
                provider.Latitude=Request.Form["longitude"];
                provider.Mobile=txt_Mobile.Text;
                provider.Phone=txt_Phone.Text;
                provider.Fax=txt_Fax.Text;
                provider.EmailAddress=txt_EmailAddress.Text;
                provider.URL=txt_URL.Text;
                provider.Rating=Convert.ToInt16(txt_Rating.Text);
                provider.ContactUsURL=txt_ContactUsURL.Text;
                provider.DisplayOrderID=0;
                provider.Image=Path.GetFileName(Image_Icon.ImageUrl);                 
                provider.Active=chk_Active.Checked;
                provider.CreatedByUser=rd.UserName;
                provider.LastModifiedByUser=rd.UserName;
                provider.LastModifiedDateTime = DateTime.Now;
                provider.CreatedDateTime= DateTime.Now;
                
                //sqlCmd.ExecuteScalar(); ScriptManager.RegisterStartupScript(this, this.GetType(), "Completed", "javascript:Display('Record Saved')", true);

                if (provider.Save())
                {

                    //save Product Price List


                    ds = new DataSet();
                    dt = ds.Tables.Add();
                    if (Session["ServiceTypeList"] != null)
                    {
                        dt = Session["ServiceTypeList"] as DataTable;

                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        // get the data
                        SqlCommand sqlCmd2 = new SqlCommand();

                        int _ServiceType = (int)row["ServiceTypeID"];

                        //double _total = (double)row["total"];

                        sqlCmd2.Parameters.AddWithValue("@ProviderID", provider.ProviderID);
                        sqlCmd2.Parameters.AddWithValue("@ServiceTypeID", _ServiceType);
                        sqlCmd2.Parameters.AddWithValue("@CreatedbyUser", rd.UserName);
                        sqlCmd2.Parameters.AddWithValue("@Active", true);

                        sqlCmd2.Connection = clsDBHandle.cn;
                        sqlCmd2.CommandType = CommandType.StoredProcedure;
                        sqlCmd2.CommandTimeout = 360;
                        sqlCmd2.CommandText = "ProviderServiceType_Insert";
                        sqlCmd2.ExecuteNonQuery();


                    }


                    ds = new DataSet();
                    dt = ds.Tables.Add();
                    if (Session["ProviderTypeList"] != null)
                    {
                        dt = Session["ProviderTypeList"] as DataTable;

                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        // get the data
                        SqlCommand sqlCmd2 = new SqlCommand();

                        int _ProviderType = (int)row["ProviderTypeID"];

                        //double _total = (double)row["total"];

                        sqlCmd2.Parameters.AddWithValue("@ProviderID", provider.ProviderID);
                        sqlCmd2.Parameters.AddWithValue("@ProviderTypeID", _ProviderType);
                        sqlCmd2.Parameters.AddWithValue("@CreatedbyUser", rd.UserName);
                        sqlCmd2.Parameters.AddWithValue("@Active", true);

                        sqlCmd2.Connection = clsDBHandle.cn;
                        sqlCmd2.CommandType = CommandType.StoredProcedure;
                        sqlCmd2.CommandTimeout = 360;
                        sqlCmd2.CommandText = "ProviderProviderType_Insert";
                        sqlCmd2.ExecuteNonQuery();


                    }

                    Session["ServiceTypeList"] = null;
                    Session["ProviderTypeList"] = null;

                    lbl_Sucess.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Completed", "javascript:Display('Record Saved')", true);
                }
            }
            catch (Exception e)
            {

                Session["Error"] = e.StackTrace.ToString(); Response.Redirect("/Error.aspx");
            }
            //Response.Redirect("Product_New.aspx");
        }
        protected void Button_Reset_Click(object sender, EventArgs e)
        {
            Session["ServiceTypeList"] = null;
            Response.Redirect("Provider_New.aspx");

        }



        protected void btn_ServiceTypeAdd_Click(object sender, EventArgs e)
        {
            AddServiceType();
        }


        protected void btn_ProviderTypeAdd_Click(object sender, EventArgs e)
        {
            AddProviderType();
        }

        private void initServiceTypeList()
        {
            //-- Instantiate the data set and table            
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            //-- Add columns to the data table            
            dt.Columns.Add("ServiceTypeID", typeof(int));
            dt.Columns.Add("ServiceTypeName", typeof(string));
            dt.Columns.Add("active", typeof(bool));
            Session["ServiceTypeList"] = dt;
            grv_ServiceTypes.DataSource = Session["ServiceTypeList"];
            grv_ServiceTypes.DataBind();
            lbl_Sucess.Visible = false;


        }
        private void initProviderTypeList()
        {
            //-- Instantiate the data set and table            
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            //-- Add columns to the data table            
            dt.Columns.Add("ProviderTypeID", typeof(int));
            dt.Columns.Add("ProviderTypeName", typeof(string));
            dt.Columns.Add("active", typeof(bool));
            Session["ProviderTypeList"] = dt;
            grv_ServiceTypes.DataSource = Session["ProviderTypeList"];
            grv_ServiceTypes.DataBind();
            lbl_Sucess.Visible = false;
        }



        protected void OnPagingProduct(object sender, GridViewPageEventArgs e)
        {
            grv_ServiceTypes.PageIndex = e.NewPageIndex;
            BindDataServiceTypes();
        }

        protected void grv_ServiceTypes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["ServiceTypeList"] as DataTable;

            DataSet ds1 = new DataSet();
            DataTable dt1 = dt;


            //double total = double.Parse(dt1.Rows[e.RowIndex]["total"].ToString());

            dt1.Rows[e.RowIndex].Delete();
            dt1.AcceptChanges();
            ds1.Tables.Add(dt1.Copy());
            ds1.Tables[0].AcceptChanges();
            Session["ServiceTypeList"] = dt1;
            BindDataServiceTypes();

        }


        protected void grv_ProviderTypeList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["ProviderTypeList"] as DataTable;

            DataSet ds1 = new DataSet();
            DataTable dt1 = dt;

            //double total = double.Parse(dt1.Rows[e.RowIndex]["total"].ToString());

            dt1.Rows[e.RowIndex].Delete();
            dt1.AcceptChanges();
            ds1.Tables.Add(dt1.Copy());
            ds1.Tables[0].AcceptChanges();
            Session["ProviderTypeList"] = dt1;
            BindDataProviderTypes();

        }

        protected void UpdateProduct(object sender, GridViewUpdateEventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["ServiceTypeList"] as DataTable;
            TextBox txtitems = (TextBox)grv_ServiceTypes.Rows[e.RowIndex].FindControl("txt_Qty");
            int qty = Int32.Parse(txtitems.Text);
            dt.Rows[e.RowIndex]["qty"] = qty;
            Session["ServiceTypeList"] = dt;
            grv_ServiceTypes.EditIndex = -1;
            //BindDataPrice();
        }



        private void BindDataProviderTypes()
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["ProviderTypeList"] as DataTable;
            grv_ProviderTypeList.DataSource = dt;
            grv_ProviderTypeList.DataBind();
            lbl_Sucess.Visible = false;
        }

        private void BindDataServiceTypes()
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["ServiceTypeList"] as DataTable;
            grv_ServiceTypes.DataSource = dt;
            grv_ServiceTypes.DataBind();
            lbl_Sucess.Visible = false;
        }





        public void AddProviderType()
        {
            //if (e.CommandName == "Edit")
            {
                int ProviderTypeID = Convert.ToInt16(drp_ProviderTypes.SelectedItem.Value);
                string ProviderTypeName = drp_ProviderTypes.SelectedItem.Text;

                //-- Instantiate the data set and table            
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add();
                //-- Add columns to the data table            
                if (Session["ProviderTypeList"] == null)
                {
                    initProviderTypeList();
                }
                dt = Session["ProviderTypeList"] as DataTable;

                if (dt.Rows.Count > 0)
                {
                    DataRow[] foundRow;
                    foundRow = dt.Select("ProviderTypeID=" + drp_ProviderTypes.SelectedItem.Value);

                    //DataRow foundRow = ds.Tables["Table1"].Rows.Find(Convert.ToInt16(txt_Qty.Text));
                    if (foundRow.Count() == 0)
                    {
                        dt.Rows.Add(ProviderTypeID, ProviderTypeName, true);
                        lbl_ProviderTypeExists.Visible = false;
                    }
                    else
                    {
                        lbl_ProviderTypeExists.Visible = true;
                    }
                }
                else
                {
                    dt.Rows.Add(ProviderTypeID, ProviderTypeName, true);
                    lbl_ProviderTypeExists.Visible = false;

                }


                Session["ProviderTypeList"] = dt;
                BindDataProviderTypes();

            }
        }

        public void AddServiceType()
        {
            //if (e.CommandName == "Edit")
            {
                int ServiceTypeID = Convert.ToInt16(drp_ServiceTypes.SelectedItem.Value);
                string ServiceTypeName = drp_ServiceTypes.SelectedItem.Text;

                //-- Instantiate the data set and table            
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add();
                //-- Add columns to the data table            
                if (Session["ServiceTypeList"] == null)
                {
                    initServiceTypeList();
                }
                dt = Session["ServiceTypeList"] as DataTable;

                if (dt.Rows.Count > 0)
                {
                    DataRow[] foundRow;
                    foundRow = dt.Select("ServiceTypeID=" + drp_ServiceTypes.SelectedItem.Value);

                    //DataRow foundRow = ds.Tables["Table1"].Rows.Find(Convert.ToInt16(txt_Qty.Text));
                    if (foundRow.Count() == 0)
                    {
                        dt.Rows.Add(ServiceTypeID, ServiceTypeName, true);
                        lbl_ServiceTypeExists.Visible = false;
                    }
                    else
                    {
                        lbl_ServiceTypeExists.Visible = true;
                    }
                }
                else
                {
                    dt.Rows.Add(ServiceTypeID, ServiceTypeName, true);
                    lbl_ServiceTypeExists.Visible = false;

                }


                Session["ServiceTypeList"] = dt;
                BindDataServiceTypes();

            }
        }

        //protected void Button_Upload_Click(object sender, EventArgs e)
        //{
        //    PhotoUpload pupl = new PhotoUpload();
        //    Image1 = pupl.UploadNewImages(FileUpload1, Image1, FileUpload1.ToString(), TextBox_ItemCode.Text, ConfigurationManager.AppSettings["ServiceImages"].ToString());
        //    HiddenField1.Value = Path.GetFileName(Image1.ImageUrl).Replace(" ", "_");
        //    chk_Special.Focus();
        //}

        //protected void Button_UploadThumbNail_Click(object sender, EventArgs e)
        //{
        //    PhotoUpload pupl = new PhotoUpload();
        //    Image2 = pupl.UploadNewImages(FileUpload2, Image2, FileUpload2.ToString(), TextBox_ItemCode.Text, ConfigurationManager.AppSettings["ServiceImages_Thumbnails"].ToString());
        //    HiddenField2.Value = Path.GetFileName(Image2.ImageUrl).Replace(" ", "_");
        //    txt_Price.Focus();
        //}


        protected void PopulateDll()
        {
            //Categories categories = new Categories(); categories.PopulateDllAll(drp_Category);
            ProviderTypes ProviderTypes = new ProviderTypes(); ProviderTypes.PopulateDllAll(drp_ProviderTypes);
            ServiceTypes ServiceTypes = new ServiceTypes(); ServiceTypes.PopulateDllAll(drp_ServiceTypes);
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //TextBox txt =  (TextBox)this.Parent.FindControl("postal_code");
            string inputValue = String.Format("{0}", Request.Form["postal_code"]);
            
            
        }
    }



}