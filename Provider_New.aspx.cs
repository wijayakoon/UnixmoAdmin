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
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (!IsPostBack)
              
            {
                if (Request.QueryString["ProviderID"] == null)
                {
                    PopulateDllNew();
                    Session["ServiceTypeList"] = null;
                    Session["ProviderTypeList"] = null;
                    Session["MakeList"] = null;
                }
                else
                {
                    PopulateDllModify();
                    PopulateProvider();
                }
            }

            if (Session["ProviderTypeList"] == null && Session["ServiceTypeList"] == null && Session["MakeList"] == null)
            {
                initProviderTypeList();
                initServiceTypeList();
                initMakeList();
            }
            else
            {
                if (!IsPostBack)
                {
                    BindDataServiceTypes();
                    BindDataProviderTypes();
                    BindDataMakes();

                }
            }
        }

        private void PopulateProvider()
        {

            provider.ProviderID = Convert.ToInt32(Request.QueryString["ProviderID"]);
            if (provider.Load())
            {
                txt_ProviderName.Text =provider.ProviderName ;
                txt_Description.Text =provider.Description ;
                txt_Keyword.Text = provider.Keyword ;
                txt_FirstName.Text = provider.FirstName; 
                txt_LastName.Text = provider.LastName ;
                var script = "document.getElementById('levelno').value = '" + provider.LevelNo + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter", script, true);
                var script1 = "document.getElementById('unitno').value = '" + provider.UnitNo + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter1", script1, true);
                var script2 = "document.getElementById('street_number').value = '" + provider.StreetNo + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter2", script2, true);
                var script3 = "document.getElementById('route').value = '" + provider.Street + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter3", script3, true);
                var script4 = "document.getElementById('locality').value = '" + provider.City + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter4", script4, true);
                var script5 = "document.getElementById('administrative_area_level_1').value = '" + provider.State + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter5", script5, true);
                var script6 = "document.getElementById('postal_code').value = '" + provider.PostCode + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter6", script6, true);
                var script7 = "document.getElementById('country').value = '" + provider.Country + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter7", script7, true);
                var script8 = "document.getElementById('latitude').value = '" + provider.Longitude + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter8", script8, true);
                var script9 = "document.getElementById('longitude').value = '" + provider.Latitude + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter9", script9, true);

                HiddenField1.Value = provider.LevelNo;
                HiddenField2.Value = provider.UnitNo;
                HiddenField3.Value = provider.StreetNo;
                HiddenField4.Value = provider.Street;
                HiddenField5.Value = provider.City;
                HiddenField6.Value = provider.State;
                HiddenField7.Value = provider.PostCode;
                HiddenField8.Value = provider.Country;
                HiddenField9.Value = provider.Longitude;
                HiddenField10.Value = provider.Latitude;

                 txt_Mobile.Text = provider.Mobile;
                 txt_Phone.Text = provider.Phone;
                 txt_Fax.Text = provider.Fax;
                 txt_EmailAddress.Text = provider.EmailAddress;
                 txt_URL.Text = provider.URL;
                 //txt_Rating.Text = provider.Rating;
                 txt_ContactUsURL.Text = provider.ContactUsURL;
                 //drp_DisplayOrderID.Text = provider.DisplayOrderID;
                 Image_Icon.ImageUrl = ConfigurationManager.AppSettings["LookupIcons_Display"].ToString() + ((provider.Image == null) ? "" : provider.Image);
                 chk_Active.Checked = provider.Active;
                 chk_DisplayOnHomePage.Checked = provider.DisplayonHomePage;
            
            }

        }


        protected void btn_Upload_Click(object sender, EventArgs e)
        {
                       
            PhotoUpload pupl = new PhotoUpload();
            Random rnd = new Random();
            Image_Icon = pupl.UploadNewImages(FileUpload_Image, Image_Icon, ConfigurationManager.AppSettings["LookupIcons"].ToString(), rnd.ToString());


            var script = "document.getElementById('levelno').value = '" + HiddenField1.Value + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter", script, true);
            var script1 = "document.getElementById('unitno').value = '" + HiddenField2.Value + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter1", script1, true);
            var script2 = "document.getElementById('street_number').value = '" + HiddenField3.Value + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter2", script2, true);
            var script3 = "document.getElementById('route').value = '" + HiddenField4.Value + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter3", script3, true);
            var script4 = "document.getElementById('locality').value = '" + HiddenField5.Value + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter4", script4, true);
            var script5 = "document.getElementById('administrative_area_level_1').value = '" + HiddenField6.Value + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter5", script5, true);
            var script6 = "document.getElementById('postal_code').value = '" + HiddenField7.Value + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter6", script6, true);
            var script7 = "document.getElementById('country').value = '" + HiddenField8.Value + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter7", script7, true);
            var script8 = "document.getElementById('latitude').value = '" + HiddenField9.Value + "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter8", script8, true);
            var script9 = "document.getElementById('longitude').value = '" + HiddenField10.Value+ "';"; ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter9", script9, true);


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
                
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add();
                if (Session["ServiceTypeList"] != null){dt = Session["ServiceTypeList"] as DataTable;}
                if (dt.Rows.Count == 0){lbl_NoServiceType.Visible = true;return;}
                else{lbl_NoServiceType.Visible = false;}
                
                if (Session["ProviderTypeList"] != null){dt = Session["ProviderTypeList"] as DataTable;}
                if (dt.Rows.Count == 0){lbl_NoProviderType.Visible = true;return;}
                else{lbl_NoProviderType.Visible = false;}
                
                saverec();
                Session["ServiceTypeList"] = null;
                Session["ProviderTypeList"] = null;
                Session["MakeList"] = null;
                
            }
        }
        private void saverec()
        {
            DbHandle clsDBHandle = new DbHandle();
            clsDBHandle.OpenConn();          
            try
            {
                RegistrationDetails rd = (RegistrationDetails)Session["RegistrationDetails"];
                SqlParameter StoredProcParamArray = new SqlParameter();
                SqlCommand sqlCmd = new SqlCommand();

                //Save Product 

                PhotoUpload pupl = new PhotoUpload();
                if (Request.QueryString["providerID"] != null)
                {
                    provider.ProviderID = Convert.ToInt32(Request.QueryString["ProviderID"].ToString());
                }
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
                provider.ContactUsURL=txt_ContactUsURL.Text;
                provider.DisplayOrderID=0;
                provider.Image=Path.GetFileName(Image_Icon.ImageUrl);
                provider.Active = chk_Active.Checked;
                provider.DisplayonHomePage = chk_DisplayOnHomePage.Checked;
                provider.CreatedByUser=rd.UserName;
                provider.LastModifiedByUser=rd.UserName;
                provider.LastModifiedDateTime = DateTime.Now;
                provider.CreatedDateTime= DateTime.Now;

              
                
                
                //sqlCmd.ExecuteScalar(); ScriptManager.RegisterStartupScript(this, this.GetType(), "Completed", "javascript:Display('Record Saved')", true);

                if (provider.Save())
                {

                    DataSet ds = new DataSet();
                    DataTable dt = ds.Tables.Add();                    
                    if (Session["ServiceTypeList"] != null)
                    {
                        dt = Session["ServiceTypeList"] as DataTable;
                  
                        SqlCommand sqlCmd3 = new SqlCommand();                        
                        
                        sqlCmd3.Parameters.AddWithValue("@ProviderID", provider.ProviderID);                        
                        sqlCmd3.Parameters.AddWithValue("@CreatedbyUser", rd.UserName);
                        
                        sqlCmd3.Connection = clsDBHandle.cn;
                        sqlCmd3.CommandType = CommandType.StoredProcedure;
                        sqlCmd3.CommandTimeout = 360;
                        sqlCmd3.CommandText = "ProviderServiceType_Delete";
                        sqlCmd3.ExecuteNonQuery();

                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        // get the data
                        SqlCommand sqlCmd2 = new SqlCommand();

                        int _ServiceTypeID = (int)row["ServiceTypeID"];

                        //double _total = (double)row["total"];

                        sqlCmd2.Parameters.AddWithValue("@ProviderID", provider.ProviderID);
                        sqlCmd2.Parameters.AddWithValue("@ServiceTypeID", _ServiceTypeID);
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
                        SqlCommand sqlCmd4 = new SqlCommand();                        
                        sqlCmd4.Parameters.AddWithValue("@ProviderID", provider.ProviderID);
                        sqlCmd4.Parameters.AddWithValue("@CreatedbyUser", rd.UserName);

                        sqlCmd4.Connection = clsDBHandle.cn;
                        sqlCmd4.CommandType = CommandType.StoredProcedure;
                        sqlCmd4.CommandTimeout = 360;
                        sqlCmd4.CommandText = "ProviderProviderType_Delete";
                        sqlCmd4.ExecuteNonQuery();

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

                    ds = new DataSet();
                    dt = ds.Tables.Add();
                    if (Session["MakeList"] != null)
                    {
                        dt = Session["MakeList"] as DataTable;

                        SqlCommand sqlCmd5 = new SqlCommand();
                        
                        sqlCmd5.Parameters.AddWithValue("@ProviderID", provider.ProviderID);
                        sqlCmd5.Parameters.AddWithValue("@CreatedbyUser", rd.UserName);

                        sqlCmd5.Connection = clsDBHandle.cn;
                        sqlCmd5.CommandType = CommandType.StoredProcedure;
                        sqlCmd5.CommandTimeout = 360;
                        sqlCmd5.CommandText = "ProviderMake_Delete";
                        sqlCmd5.ExecuteNonQuery();

                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        // get the data
                        SqlCommand sqlCmd4 = new SqlCommand();

                        int _Make = (int)row["MakeID"];

                        //double _total = (double)row["total"];

                        sqlCmd4.Parameters.AddWithValue("@ProviderID", provider.ProviderID);
                        sqlCmd4.Parameters.AddWithValue("@MakeID", _Make);
                        sqlCmd4.Parameters.AddWithValue("@CreatedbyUser", rd.UserName);
                        sqlCmd4.Parameters.AddWithValue("@Active", true);

                        sqlCmd4.Connection = clsDBHandle.cn;
                        sqlCmd4.CommandType = CommandType.StoredProcedure;
                        sqlCmd4.CommandTimeout = 360;
                        sqlCmd4.CommandText = "ProviderMake_Insert";
                        sqlCmd4.ExecuteNonQuery();


                    }

                    Session["MakeList"] = null;
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

        protected void btn_MakeAdd_Click(object sender, EventArgs e)
        {
            AddMake();
        }

        protected void btn_ProviderTypeAdd_Click(object sender, EventArgs e)
        {
            AddProviderType();
        }

        private void initServiceTypeList()
        {
            try
            {
                //-- Instantiate the data set and table            
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add();
                //-- Add columns to the data table            
                dt.Columns.Add("ServiceTypeID", typeof(int));
                dt.Columns.Add("ServiceType", typeof(string));
                dt.Columns.Add("active", typeof(bool));


                ServiceTypes st = new ServiceTypes();
                st.ProviderID =Convert.ToInt16( Request.QueryString["ProviderID"]);
                if (st.ProviderID > 0) { dt = st.FindDetails().Tables[0]; }
                Session["ServiceTypeList"] = dt;
                grv_ServiceTypes.DataSource = Session["ServiceTypeList"];
                grv_ServiceTypes.DataBind();
                lbl_Sucess.Visible = false;


            }
            catch (Exception e)
            {

                Session["Error"] = e.StackTrace.ToString(); Response.Redirect("/Error.aspx");
            }

        }

        private void initProviderTypeList()
        {
            try
            {
                //-- Instantiate the data set and table            
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add();
                //-- Add columns to the data table            
                dt.Columns.Add("ProviderTypeID", typeof(int));
                dt.Columns.Add("ProviderType", typeof(string));
                dt.Columns.Add("active", typeof(bool));

                ProviderTypes pt = new ProviderTypes();
                pt.ProviderID = Convert.ToInt16(Request.QueryString["ProviderID"]);
               if (pt.ProviderID > 0 ){ dt = pt.FindDetails().Tables[0];}
                Session["ProviderTypeList"] = dt;
                grv_ProviderTypeList.DataSource = Session["ProviderTypeList"];
                grv_ProviderTypeList.DataBind();
                lbl_Sucess.Visible = false;


            }
            catch (Exception e)
            {

                Session["Error"] = e.StackTrace.ToString(); Response.Redirect("/Error.aspx");
            }

        }

        private void initMakeList()
        {
            try
            {
                //-- Instantiate the data set and table            
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add();
                //-- Add columns to the data table            
                dt.Columns.Add("MakeID", typeof(int));
                dt.Columns.Add("Make", typeof(string));
                dt.Columns.Add("active", typeof(bool));


                Makes mk = new Makes();
                mk.ProviderID = Convert.ToInt16(Request.QueryString["ProviderID"]);
                if (mk.ProviderID > 0) { dt = mk.FindDetails().Tables[0]; }
                Session["MakeList"] = dt;
                grv_Make.DataSource = Session["MakeList"];
                grv_Make.DataBind();
                lbl_Sucess.Visible = false;


            }
            catch (Exception e)
            {

                Session["Error"] = e.StackTrace.ToString(); Response.Redirect("/Error.aspx");
            }

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



            //double total = double.Parse(dt1.Rows[e.RowIndex]["total"].ToString());

            dt.Rows[e.RowIndex].Delete();
            dt.AcceptChanges();
            ds.Tables.Add(dt.Copy());
            ds.Tables[0].AcceptChanges();
            Session["ServiceypeList"] = dt;
            BindDataServiceTypes();

        }

        protected void grv_Makes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["MakeList"] as DataTable;



            //double total = double.Parse(dt1.Rows[e.RowIndex]["total"].ToString());

            dt.Rows[e.RowIndex].Delete();
            dt.AcceptChanges();
            ds.Tables.Add(dt.Copy());
            ds.Tables[0].AcceptChanges();
            Session["ServiceypeList"] = dt;
            BindDataMakes();

        }

        protected void grv_ProviderTypeList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["ProviderTypeList"] as DataTable;


            //double total = double.Parse(dt1.Rows[e.RowIndex]["total"].ToString());

            dt.Rows[e.RowIndex].Delete();
            dt.AcceptChanges();
            ds.Tables.Add(dt.Copy());
            ds.Tables[0].AcceptChanges();
            Session["ProviderTypeList"] = dt;
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
        
        private void BindDataMakes()
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["MakeList"] as DataTable;
            grv_Make.DataSource = dt;
            grv_Make.DataBind();
            lbl_Sucess.Visible = false;
        }


        public void AddProviderType()
        {
            //if (e.CommandName == "Edit")
            {
                int ProviderTypeID = Convert.ToInt16(drp_ProviderTypes.SelectedItem.Value);
                string ProviderType = drp_ProviderTypes.SelectedItem.Text;

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
                        dt.Rows.Add(ProviderTypeID, ProviderType, true);
                        lbl_ProviderTypeExists.Visible = false;
                    }
                    else
                    {
                        lbl_ProviderTypeExists.Visible = true;
                    }
                }
                else
                {
                    dt.Rows.Add(ProviderTypeID, ProviderType, true);
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
                string ServiceType = drp_ServiceTypes.SelectedItem.Text;

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
                        dt.Rows.Add(ServiceTypeID, ServiceType, true);
                        lbl_ServiceTypeExists.Visible = false;
                    }
                    else
                    {
                        lbl_ServiceTypeExists.Visible = true;
                    }
                }
                else
                {
                    dt.Rows.Add(ServiceTypeID, ServiceType, true);
                    lbl_ServiceTypeExists.Visible = false;

                }


                Session["ServiceTypeList"] = dt;
                BindDataServiceTypes();

            }
        }

        public void AddMake()
        {
            //if (e.CommandName == "Edit")
            {
                int MakeID = Convert.ToInt16(drp_Makes.SelectedItem.Value);
                string Make = drp_Makes.SelectedItem.Text;

                //-- Instantiate the data set and table            
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add();
                //-- Add columns to the data table            
                if (Session["MakeList"] == null)
                {
                    initMakeList();
                }
                dt = Session["MakeList"] as DataTable;

                if (dt.Rows.Count > 0)
                {
                    DataRow[] foundRow;
                    foundRow = dt.Select("MakeID=" + drp_Makes.SelectedItem.Value);

                    //DataRow foundRow = ds.Tables["Table1"].Rows.Find(Convert.ToInt16(txt_Qty.Text));
                    if (foundRow.Count() == 0)
                    {
                        dt.Rows.Add(MakeID, Make, true);
                        lbl_MakeExists.Visible = false;
                    }
                    else
                    {
                        lbl_MakeExists.Visible = true;
                    }
                }
                else
                {
                    dt.Rows.Add(MakeID, Make, true);
                    lbl_MakeExists.Visible = false;

                }


                Session["MakeList"] = dt;
                BindDataMakes();

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


        protected void PopulateDllNew()
        {
            //Categories categories = new Categories(); categories.PopulateDllAll(drp_Category);
            ProviderTypes ProviderTypes = new ProviderTypes(); ProviderTypes.PopulateDllAll(drp_ProviderTypes);
            ServiceTypes ServiceTypes = new ServiceTypes(); ServiceTypes.PopulateDllAll(drp_ServiceTypes);
            Makes Makes = new Makes(); Makes.PopulateDllAll(drp_Makes);            
        }


        protected void PopulateDllModify()
        {
            //Categories categories = new Categories(); categories.PopulateDllAll(drp_Category);
            ProviderTypes ProviderTypes = new ProviderTypes(); ProviderTypes.PopulateDllAll(drp_ProviderTypes);
            ServiceTypes ServiceTypes = new ServiceTypes(); ServiceTypes.PopulateDllAll(drp_ServiceTypes);
            Makes Makes = new Makes(); Makes.PopulateDllAll(drp_Makes);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //TextBox txt =  (TextBox)this.Parent.FindControl("postal_code");
            string inputValue = String.Format("{0}", Request.Form["postal_code"]);           
            
        }

        protected void btn_ProviderTypeView_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btn_ServiceTypeView_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btn_MakeView_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

       
    }



}