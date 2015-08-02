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
    public partial class Provider_Edit : System.Web.UI.Page
    {
        public ApplicationConstants apc = new ApplicationConstants();
        public string _FileControlsId
        {
            get
            {
                return file.ClientID;
            }
        }
        public static string FileControlsId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            //Label2.Text = HttpContext.Current.Server.MapPath(Common.ThumbnailFileLocation + "/");
            //Label3.Text = HttpContext.Current.Server.MapPath(Common.FileLocation + "/");
            if (!IsPostBack)
            {
                PopulateDll();
                Session.Remove(FileControlsId + "selectedpicture");
                Session.Remove(FileControlsId + "uploadedfiles");
                Session["ServiceTypes"] = null;
                Session["ProviderTypeList"] = null;
                DataView dv = (DataView)SqlDataSource5.Select(DataSourceSelectArguments.Empty);
                foreach (DataRowView rowView in dv)
                {

                    drp_Category.DataBind();
                    DataRow row = rowView.Row;
                    drp_Category.SelectedValue = row["CategoryID"].ToString();
                    drp_Colour.SelectedValue = row["ColourID"].ToString();
                    drp_Side.SelectedValue = row["SideID"].ToString();
                    txt_ProviderNo.Text = ((string)row["ProviderNo"].ToString());
                    TextBox_Description.Text = ((string)row["Description"].ToString());
                    TextBox_ShortDescription.Text = ((string)row["ShortDescription"].ToString());
                    TextBox_Keywords.Text = ((string)row["Keywords"].ToString());
                    txt_ProviderNo.Text = ((string)row["ProviderNo"].ToString());
                    TextBox_Name.Text = ((string)row["Provider"].ToString());
                    //TextBox_Details.Text = ((string)row["Provider"].ToString());
                    txt_Height.Text = ((string)row["Height"].ToString());
                    txt_Width.Text = ((string)row["Width"].ToString());
                    txt_Length.Text = ((string)row["Length"].ToString());
                    txt_Weight.Text = ((string)row["Weight"].ToString());
                    chk_Active.Checked = (bool)row["Active"];
                                     

                   

                    SetControlStatus(chk_Active.Checked);
                }

            }


            if (!IsPostBack)
            //if ((Session["ServiceTypes"] == null) && (Session["ProviderTypeList"] == null))
            {
                initServiceTypes();
                initProviderTypeList();
            }
            else
            {
                //BindDataPrice(); BindDataFetures(); 

            }
            FileControlsId = _FileControlsId;

        }
        public void InitPictureBox()
        {
            List<ImageList> lstimage = new List<ImageList>();
            ImageList objImageList = new ImageList();
            objImageList.ThumbNailImageName = "default.jpeg";
            objImageList.IsDefault = true;
            objImageList.ImageListID = 0;
            objImageList.Haveimage = false;
            lstimage.Add(objImageList);

            for (int i = 1; i < Common.MaximumPhotos; i++)
            {
                objImageList = new ImageList();
                objImageList.ThumbNailImageName = "default.jpeg";
                objImageList.IsDefault = false;
                objImageList.ImageListID = i;
                objImageList.Haveimage = false;
                lstimage.Add(objImageList);
            }
            Session.Remove(FileControlsId + "selectedpicture");
            Session.Remove(FileControlsId + "uploadedfiles");
            Session[FileControlsId + "selectedpicture"] = lstimage;
            binddtl(lstimage);
        }
        public ImageList SelectedPictureBox(string tumbname, bool isdefault, ImageList objImageList, bool haveImage)
        {
            if (isdefault == true)
            {
                objImageList.ImageName = tumbname;
                objImageList.ThumbNailImageName = tumbname;
                objImageList.IsDefault = true;
                objImageList.Haveimage = haveImage;

            }
            else
            {
                objImageList.ImageName = tumbname;
                objImageList.ThumbNailImageName = tumbname;
                objImageList.IsDefault = false;
                objImageList.Haveimage = haveImage;
            }

            return objImageList;
        }
        public static List<ImageList> startupload(List<NeemoAdmin.Handler.ViewsessionUploadFilesResult> files)
        {
            int i = 0;
            List<ImageList> lstimage = new List<ImageList>();
            foreach (NeemoAdmin.Handler.ViewsessionUploadFilesResult lstupload in files)
            {

                ImageList objImageList = new ImageList();
                objImageList.ImageName = lstupload.Name;
                objImageList.ImageListID = i;
                objImageList.IsDefault = lstupload.IsDefault;
                objImageList.ThumbNailImageName = lstupload.Thumbnail_url;
                objImageList.Haveimage = true;
                i++;
                lstimage.Add(objImageList);

            }
            for (int j = 0; j < (Common.MaximumPhotos - files.Count); j++)
            {
                ImageList objImageList = new ImageList();
                objImageList.ImageName = "";
                objImageList.ImageListID = 0;
                objImageList.IsDefault = false;
                objImageList.ThumbNailImageName = "Default.jpeg";
                objImageList.Haveimage = false;
                lstimage.Add(objImageList);
            }
            HttpContext.Current.Session[FileControlsId + "selectedpicture"] = lstimage;
            return lstimage;
        }
        [WebMethod]
        public static string setfile(string file)
        {
            System.Collections.Generic.List<NeemoAdmin.Handler.ViewsessionUploadFilesResult> obj = (System.Collections.Generic.List<NeemoAdmin.Handler.ViewsessionUploadFilesResult>)(HttpContext.Current.Session[FileControlsId + "uploadedfiles"]);
            string str = Binddtlajax(obj);
            return str;
        }

        [WebMethod]
        public static string Delete(int imagelistid)
        {
            lnkbtndelete(imagelistid);
            string str = Binddtlajax(null);
            return str;
        }
        [WebMethod]
        public static string Isdefault(int imagelistid)
        {
            chkdefault(imagelistid);
            string str = Binddtlajax(null);
            return str;
        }
        public static void chkdefault(int imagelistid)
        {
            List<ImageList> lstimage = (List<ImageList>)HttpContext.Current.Session[FileControlsId + "selectedpicture"];
            foreach (ImageList imglist in lstimage)
            {
                imglist.IsDefault = false;
            }
            IEnumerable<ImageList> selectedlstimage = lstimage.Where(i => i.ImageListID == imagelistid);
            selectedlstimage.First().IsDefault = true;
            HttpContext.Current.Session[FileControlsId + "selectedpicture"] = lstimage;
        }
        protected static void lnkbtndelete(int id)
        {
            List<ImageList> lstimage = (List<ImageList>)HttpContext.Current.Session[FileControlsId + "selectedpicture"];
            List<NeemoAdmin.Handler.ViewsessionUploadFilesResult> fileuplodeResult = (List<NeemoAdmin.Handler.ViewsessionUploadFilesResult>)HttpContext.Current.Session[FileControlsId + "uploadedfiles"];
            IEnumerable<ImageList> selectedlstimage = lstimage.Where(i => i.ImageListID == id);
            foreach (ImageList imglist in selectedlstimage)
            {
                imglist.ThumbNailImageName = "Default.jpeg";
                imglist.ImageName = "";
                imglist.IsDefault = false;
                imglist.Haveimage = false;
            }
            fileuplodeResult.Remove((fileuplodeResult.Where(i => i.ImgListID == id)).First());
            HttpContext.Current.Session[FileControlsId + "uploadedfiles"] = fileuplodeResult;
            HttpContext.Current.Session[FileControlsId + "selectedpicture"] = lstimage;
        }
        public static string Binddtlajax(List<NeemoAdmin.Handler.ViewsessionUploadFilesResult> obj)
        {
            string str = "";
            if (obj != null)
            {
                startupload(obj);
            }
            List<ImageList> lstimage = (List<ImageList>)HttpContext.Current.Session[FileControlsId + "selectedpicture"];
            int i = 0;
            foreach (ImageList img in lstimage.OrderByDescending(j => j.Haveimage))
            {
                if (i == 0)
                {
                    str += "<tr>";
                }
                str += "<td>" +
                   "<div style='padding: 3px'>" +
                       "<div>" +
                       "<input type='checkbox' name='dtlPhotos$ctl00$chkdefault' onclick='ChangeDefault(" + img.ImageListID + ")' id='dtlPhotos_chkdefault_0'" + (img.IsDefault == true ? "checked" : "") + " " + (img.Haveimage == true ? "" : "style=visibility:hidden") + "></input><label for='dtlPhotos_chkdefault_0' " + (img.Haveimage == true ? "" : "style=visibility:hidden") + " >IsDefault</label>" +
                       "</div>" +
                       "<div>" +
                           "<img style='height:100px;width:100px;' src='" + Common.ThumbnailFileLocation + "/" + img.ThumbNailImageName + "' class='img' id='dtlPhotos_imgphotos_0' />" +
                       "</div>" +
                       "<div>" +
                           "<a href='' class='lnkbtndelete' onClick='deleteimg(" + img.ImageListID + "); return false;' id='dtlPhotos_lnkbtndelete_0'" + (img.Haveimage == true ? "" : "style=visibility:hidden") + " >Delete</a>" +
                       "</div>" +
                   "</div>" +
               "</td>";
                if (i == 3)
                {
                    str += "</tr>";
                    i = 0;
                }
                else
                {
                    i++;
                }


            }
            return str;
        }
        protected void dtlPhotos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnhaveimage = (HiddenField)e.Item.FindControl("hdnhaveimage");
                CheckBox chkdefault = (CheckBox)e.Item.FindControl("chkdefault");
                LinkButton lnbuttondelete = (LinkButton)e.Item.FindControl("lnkbtndelete");
                if (Convert.ToBoolean(hdnhaveimage.Value) == true)
                {
                    lnbuttondelete.Attributes.Remove("style");
                    chkdefault.Attributes.Remove("style");
                }
                else
                {
                    lnbuttondelete.Attributes.Add("style", "visibility:hidden");
                    chkdefault.Attributes.Add("style", "visibility:hidden");
                }
            }
        }




        public void binddtl(List<ImageList> lstimage)
        {
            dtlPhotos.DataSource = lstimage.OrderByDescending(i => i.Haveimage);
            dtlPhotos.DataBind();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                List<ImageList> lstimage = (List<ImageList>)Session[FileControlsId + "selectedpicture"];
                bool chkvalid = false;
                bool chkdefaultvalid = false;
                int defaultimglistid = 0;
                foreach (ImageList objImageList in lstimage.Where(i => i.Haveimage == true && i.IsDefault == false))
                {
                    ImageListHeader objImageListHeader = new ImageListHeader();
                    objImageListHeader.ImageName = objImageList.ImageName;
                    objImageListHeader.ThumbNailImageName = objImageList.ThumbNailImageName;
                    //objImageListHeader.ListingHeaderID = objImageListHeader.GetMaxHeaderListingID() + 1;
                    objImageListHeader.InsertImageList();
                }
                foreach (ImageList objImageList in lstimage.Where(i => i.IsDefault == true && i.Haveimage == true))
                {
                    chkdefaultvalid = true;
                    chkvalid = true;
                    ImageListHeader objImageListHeader = new ImageListHeader();
                    objImageListHeader.ImageName = objImageList.ImageName;
                    objImageListHeader.ThumbNailImageName = objImageList.ThumbNailImageName;
                    //objImageListHeader.ListingHeaderID = objImageListHeader.GetMaxHeaderListingID() + 1;
                    defaultimglistid = objImageListHeader.InsertImageList();

                    objImageList.ImageListID = objImageList.ImageListID;
                    objImageListHeader.DefaultImageListID = defaultimglistid;
                    objImageListHeader.InsertListingHeader();
                }
                if (chkvalid == false || chkdefaultvalid == false)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Validation", "alert('Upload Images or Select Default Image')", true);
                    binddtl(lstimage);
                    return;
                }

            }
            else
            {

                List<ImageList> lstimage = (List<ImageList>)Session[FileControlsId + "selectedpicture"];
                bool chkvalid = false;
                bool chkdefaultvalid = false;
                ImageListHeader objImageListHeader = new ImageListHeader();
                objImageListHeader.ListingHeaderID = Convert.ToInt32(Request.QueryString["id"]);
                objImageListHeader.UpdateActiveImageList();
                foreach (ImageList objImageList in lstimage.Where(i => i.Haveimage == true && i.IsDefault == false))
                {
                    objImageListHeader.Active = false;
                    objImageListHeader.ImageName = objImageList.ImageName;
                    objImageListHeader.ThumbNailImageName = objImageList.ThumbNailImageName;
                    objImageListHeader.InsertImageList();
                }
                foreach (ImageList objImageList in lstimage.Where(i => i.IsDefault == true && i.Haveimage == true))
                {
                    chkdefaultvalid = true;
                    chkvalid = true;
                    objImageListHeader = new ImageListHeader();
                    objImageListHeader.ListingHeaderID = Convert.ToInt32(Request.QueryString["id"]);
                    objImageListHeader.ImageName = objImageList.ImageName;
                    objImageListHeader.ThumbNailImageName = objImageList.ThumbNailImageName;
                    int defaultimglistid = objImageListHeader.InsertImageList();

                    objImageListHeader.DefaultImageListID = defaultimglistid;
                    objImageListHeader.UpdateListingHeader();
                }
                if (chkvalid == false || chkdefaultvalid == false)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Validation", "alert('Upload Images or Select Default Image')", true);
                    binddtl(lstimage);
                    return;
                }

            }
            btncancel_Click(sender, e);
        }

       


        protected void btncancel_Click(object sender, EventArgs e)
        {
            Session.Remove(FileControlsId + "uploadedfiles");
            Session.Remove(FileControlsId + "selectedpicture");
            Response.Redirect("DisplayhandlingList.aspx");

        }
        protected void Button_Save_Click(object sender, EventArgs e)
        {
            //bool bln = ValidateserviceExist();


            //if (!bln)
            {
                saverec();
                Session["ServiceTypes"] = null;
                Session["ProviderTypeList"] = null;
                Response.Redirect("Provider_New.aspx");
            }
        }

        protected string HideEditButton(string EffectiveDateTo)
        {
            //If count>1 then show text in HyperLink

            if (EffectiveDateTo == "")
            {
                return "visibility:visible;";
            }
            else
            {
                return "visibility::hidden;";
            }
        }



        private void saverec()
        {
            RegistrationDetails rd = (RegistrationDetails)Session["RegistrationDetails"]; 
            DbHandle clsDBHandle = new DbHandle();
            clsDBHandle.OpenConn();
            SqlParameter StoredProcParamArray = new SqlParameter();
            SqlCommand sqlCmd = new SqlCommand();
            int _Providerid = Convert.ToInt16(Request.QueryString["ProviderID"]);
            try
            {

                sqlCmd.Parameters.AddWithValue("@ProviderID", _Providerid);
                sqlCmd.Parameters.AddWithValue("@CategoryID", Convert.ToInt16(drp_Category.SelectedValue.ToString()));
                sqlCmd.Parameters.AddWithValue("@ColourID", Convert.ToInt16(drp_Colour.SelectedValue.ToString()));
                sqlCmd.Parameters.AddWithValue("@SideID", Convert.ToInt16(drp_Side.SelectedValue.ToString()));
                sqlCmd.Parameters.AddWithValue("@ShortDescription", TextBox_ShortDescription.Text);
                sqlCmd.Parameters.AddWithValue("@Keywords", TextBox_Keywords.Text);
                sqlCmd.Parameters.AddWithValue("@Description", TextBox_Description.Text);
                sqlCmd.Parameters.AddWithValue("@Provider", TextBox_Name.Text);
                sqlCmd.Parameters.AddWithValue("@ProviderNo", txt_ProviderNo.Text);
                sqlCmd.Parameters.AddWithValue("@Height", Convert.ToInt16(txt_Height.Text));
                sqlCmd.Parameters.AddWithValue("@Width", Convert.ToDecimal(txt_Width.Text));
                sqlCmd.Parameters.AddWithValue("@Length", Convert.ToDecimal(txt_Length.Text));
                sqlCmd.Parameters.AddWithValue("@Weight", Convert.ToDecimal(txt_Weight.Text));
                //sqlCmd.Parameters.AddWithValue("@Image", TextBox_ItemCode.Text);
                //sqlCmd.Parameters.AddWithValue("@ThumbNailPath", TextBox_ItemCode.Text);
                //sqlCmd.Parameters.AddWithValue("@ProviderpecPath", TextBox_ItemCode.Text);
                sqlCmd.Parameters.AddWithValue("@Active", chk_Active.Checked);
                sqlCmd.Parameters.AddWithValue("@LastModifiedDateTime", DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@LastModifiedByUser", rd.UserName);




                sqlCmd.Connection = clsDBHandle.cn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = 360;
                sqlCmd.CommandText = "Provider_update";
                sqlCmd.ExecuteScalar(); 
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Completed", "javascript:Display('Record Saved')", true);



                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add();
                if (Session["ServiceTypes"] != null)
                {
                    dt = Session["ServiceTypes"] as DataTable;
                }
                foreach (DataRow row in dt.Rows)
                {
                    // get the data                  
                    double _price = (double)row["price"];
                    int _priceid = (int)row["ProviderPriceID"];
                    int _qty = (int)row["quantity"];
                    bool _Active = (bool)row["Active"];
                    string _EffectiveDateTo = row["EffectiveDateTo"].ToString();
                    SqlHelper.ExecuteNonQuery(clsDBHandle.cn, "ProviderPrice_Update", _priceid, _Providerid, _qty, _price, _Active);
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
                    int _ProviderTypeid = (int)row["ProviderTypeID"];
                    bool _active = (bool)row["Active"];
                    SqlHelper.ExecuteNonQuery(clsDBHandle.cn, "ProviderProviderType_Update", _Providerid, _ProviderTypeid, _active);
                }


                Session["ProviderTypeList"] = null;
                Session["ServiceTypes"] = null;
                lbl_Sucess.Visible = true;

            }
            catch (Exception e)
            {
                
             Session["Error"] = e.StackTrace.ToString(); Response.Redirect("/Error.aspx");
            }
        }
        protected void Button_Reset_Click(object sender, EventArgs e)
        {
            Session["ServiceTypes"] = null;
            Response.Redirect("Provider_New.aspx");

        }

        protected void drp_ServiceItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bool bln = ValidateserviceExist();

        }

        protected void grv_ServiceTypes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["ServiceTypes"] as DataTable;

            DataSet ds1 = new DataSet();
            DataTable dt1 = dt;


            //double total = double.Parse(dt1.Rows[e.RowIndex]["total"].ToString());

            dt1.Rows[e.RowIndex].Delete();
            dt1.AcceptChanges();
            ds1.Tables.Add(dt1.Copy());
            ds1.Tables[0].AcceptChanges();
            Session["ServiceTypes"] = dt1;
            BindDataPrice();

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
            BindDataFetures();

        }

        protected void btn_ProviderTypeAdd_Click(object sender, EventArgs e)
        {
            AddProviderType();
        }

        protected void btn_PriceAdd_Click(object sender, EventArgs e)
        {
            AddPrice();
        }

        private void initServiceTypes()
        {
            //-- Instantiate the data set and table            
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add("ServiceTypes");
            //-- Add columns to the data table            
            dt.Columns.Add("Providerpriceid", typeof(int));
            dt.Columns.Add("Providerid", typeof(int));
            dt.Columns.Add("quantity", typeof(int));
            dt.Columns.Add("price", typeof(double));
            dt.Columns.Add("EffectiveDateFrom", typeof(DateTime));
            dt.Columns.Add("EffectiveDateTo", typeof(DateTime));
            dt.Columns.Add("Active", typeof(bool));

            DbHandle clsDBHandle = new DbHandle();
            clsDBHandle.OpenConn();
            SqlDataReader dr = null;
            try
            {
                SqlParameter StoredProcParamArray = new SqlParameter();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = clsDBHandle.cn;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandTimeout = 360;
                sqlCmd.CommandText = string.Format("Select * from ProviderPrice where Providerid={0}", Request.QueryString["ProviderID"]);

                dr = sqlCmd.ExecuteReader();

                // Fill the list box with the values retrieved                
                while (dr.Read())
                {
                    //dt.Rows.Add((int)dr["priceid"], (int)dr["Providerid"], (int)dr["quantity"], (double)dr["price"], (DateTime)dr["EffectiveFrom"], (DateTime)dr["EffectiveDateTo"], (bool)dr["active"]);
                    dt.Rows.Add(dr["Providerpriceid"], dr["Providerid"], dr["quantity"], dr["price"], dr["EffectiveDateFrom"], dr["EffectiveDateTo"], dr["Active"]);
                }
                grv_ServiceTypes.DataSource = dt;
                grv_ServiceTypes.DataBind();
                dr.Close();
                Session["ServiceTypes"] = dt;
                grv_ServiceTypes.DataSource = dt;
                grv_ServiceTypes.DataBind();

            }
            catch (Exception e)
            {

                Session["Error"] = e.StackTrace.ToString(); Response.Redirect("/Error.aspx");
            }

        }

        private void initProviderTypeList()
        {
            //-- Instantiate the data set and table            
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add("ProviderTypeList");
            //-- Add columns to the data table            
            dt.Columns.Add("ProviderProviderTypeid", typeof(int));
            dt.Columns.Add("ProviderID", typeof(int));
            dt.Columns.Add("ProviderTypeID", typeof(int));
            dt.Columns.Add("ProviderType", typeof(string));
            dt.Columns.Add("EffectiveDateTo", typeof(DateTime));
            dt.Columns.Add("EffectiveFrom", typeof(DateTime));
            dt.Columns.Add("active", typeof(bool));

            DbHandle clsDBHandle = new DbHandle();
            clsDBHandle.OpenConn();
            SqlDataReader dr = null;
            try
            {
                SqlParameter StoredProcParamArray = new SqlParameter();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = clsDBHandle.cn;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandTimeout = 360;
                sqlCmd.CommandText = string.Format("Select PF.ProviderProviderTypeid,PF.ProviderID,PF.ProviderTypeID,F.ProviderType,PF.EffectiveDateTo,PF.CreatedDateTime,PF.active from ProviderProviderType PF inner join ProviderType F on PF.ProviderTypeID=F.ProviderTypeID where Providerid={0}", Request.QueryString["ProviderID"]);

                dr = sqlCmd.ExecuteReader();

                // Fill the list box with the values retrieved                
                while (dr.Read())
                {
                    //dt.Rows.Add((int)dr["priceid"], (int)dr["Providerid"], (int)dr["quantity"], (double)dr["price"], (DateTime)dr["EffectiveFrom"], (DateTime)dr["EffectiveDateTo"], (bool)dr["active"]);
                    dt.Rows.Add(dr["ProviderProviderTypeid"], dr["ProviderID"], dr["ProviderTypeID"], dr["ProviderType"], dr["EffectiveDateTo"], dr["CreatedDateTime"], dr["active"]);
                }
                grv_ProviderTypeList.DataSource = dt;
                grv_ProviderTypeList.DataBind();
                dr.Close();
                Session["ProviderTypeList"] = dt;
                grv_ProviderTypeList.DataSource = dt;
                grv_ProviderTypeList.DataBind();

            }
            catch (Exception e)
            {

                Session["Error"] = e.StackTrace.ToString(); Response.Redirect("/Error.aspx");
            }

        }

        protected void OnPagingProvider(object sender, GridViewPageEventArgs e)
        {
            grv_ServiceTypes.PageIndex = e.NewPageIndex;
            BindDataPrice();
        }

        protected void EditProvider(object sender, GridViewEditEventArgs e)
        {
            lbl_Sucess.Visible = false;
            btn_PriceAdd.Enabled = false;
            Button_Save.Enabled = false;
            grv_ServiceTypes.EditIndex = e.NewEditIndex;

        }

        protected void CancelEditProvider(object sender, GridViewCancelEditEventArgs e)
        {
            grv_ServiceTypes.EditIndex = -1;
            btn_PriceAdd.Enabled = true;
            Button_Save.Enabled = true;
            BindDataPrice();
        }


        protected void UpdateProvider(object sender, GridViewUpdateEventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["ServiceTypes"] as DataTable;
            CheckBox chkActive = (CheckBox)grv_ServiceTypes.Rows[e.RowIndex].FindControl("chkActive_ProviderPriceEdit");
            TextBox txtPrice = (TextBox)grv_ServiceTypes.Rows[e.RowIndex].FindControl("txt_EditRetailPriceEdit");
            double price = double.Parse(txtPrice.Text);
            bool active = chkActive.Checked;
            dt.Rows[e.RowIndex]["Active"] = active;
            dt.Rows[e.RowIndex]["price"] = price;
            Session["ServiceTypes"] = dt;
            grv_ServiceTypes.EditIndex = -1;
            Button_Save.Enabled = true;
            btn_PriceAdd.Enabled = true;
            BindDataPrice();
        }

        protected void OnPagingProviderProviderType(object sender, GridViewPageEventArgs e)
        {
            grv_ProviderTypeList.PageIndex = e.NewPageIndex;
            BindDataFetures();
        }

        protected void EditProviderProviderType(object sender, GridViewEditEventArgs e)
        {
            //lbl_ProviderTypeSucess.Visible = false;
            btn_ProviderTypeAdd.Enabled = false;
            Button_Save.Enabled = false;
            grv_ProviderTypeList.EditIndex = e.NewEditIndex;
        }

        protected void UpdateProviderProviderType(object sender, GridViewUpdateEventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["ProviderTypeList"] as DataTable;
            CheckBox chkActive = (CheckBox)grv_ProviderTypeList.Rows[e.RowIndex].FindControl("chkActive_ProviderTypeEdit");
            bool active = chkActive.Checked;
            dt.Rows[e.RowIndex]["active"] = active;
            Session["ProviderTypeList"] = dt;
            grv_ProviderTypeList.EditIndex = -1;
            Button_Save.Enabled = true;
            btn_ProviderTypeAdd.Enabled = true;
            BindDataFetures();
        }

        protected void CancelEditProviderProviderType(object sender, GridViewCancelEditEventArgs e)
        {
            grv_ProviderTypeList.EditIndex = -1;
            btn_ProviderTypeAdd.Enabled = true;
            Button_Save.Enabled = true;
            BindDataFetures();
        }

        private void BindDataPrice()
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["ServiceTypes"] as DataTable;
            grv_ServiceTypes.DataSource = dt;
            grv_ServiceTypes.DataBind();
            lbl_Sucess.Visible = false;
        }

        private void BindDataFetures()
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["ProviderTypeList"] as DataTable;
            grv_ProviderTypeList.DataSource = dt;
            grv_ProviderTypeList.DataBind();
            lbl_Sucess.Visible = false;
        }

        public void AddPrice()
        {
            {
                int qty = Convert.ToInt16(txt_Qty.Text);
                double price = Convert.ToDouble(txt_Price.Text);
                string EffectiveFrom = DateTime.Now.ToString();
                int priceid = 0;
                int Providerid = Convert.ToInt16(Request.QueryString["ProviderID"].ToString());
                //-- Instantiate the data set and table            
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add();
                //-- Add columns to the data table            
                if (Session["ServiceTypes"] == null)
                {
                    initServiceTypes();
                }
                dt = Session["ServiceTypes"] as DataTable;
                DataRow[] foundRow;
                foundRow = dt.Select("quantity=" + txt_Qty.Text);
                if (foundRow.Count() == 0)
                {
                    dt.Rows.Add(priceid, Providerid, qty, price, DateTime.Now, null, false);
                    Session["ServiceTypes"] = dt;
                    BindDataPrice();
                    txt_Qty.Text = (qty + 1).ToString();
                    txt_Price.Text = "0.00";
                    lbl_qantityExists.Visible = false;
                }
                else
                {
                    lbl_qantityExists.Visible = true;
                }
            }
        }

        public void AddProviderType()
        {
            {
                int _Providerid = Convert.ToInt16(Request.QueryString["ProviderID"]);
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
                        dt.Rows.Add(null, _Providerid, ProviderTypeID, ProviderType, null, DateTime.Now, true);
                        lbl_ProviderTypeExists.Visible = false;
                    }
                    else
                    {
                        lbl_ProviderTypeExists.Visible = true;
                    }
                }
                else
                {
                    dt.Rows.Add(null, _Providerid, ProviderTypeID, ProviderType, null, DateTime.Now, true);
                    lbl_ProviderTypeExists.Visible = false;

                }
                Session["ProviderTypeList"] = dt;
                BindDataFetures();
            }
        }

        protected void chk_ProviderStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Active.Checked == false)
            {
                SetControlStatus(false);
            }
            else
            {
                SetControlStatus(true);
            }
        }

        private void SetControlStatus(bool status)
        {
            grv_ServiceTypes.Enabled = status;
            btn_PriceAdd.Enabled = status;
            txt_Qty.Enabled = status;
            txt_Price.Enabled = status;
        }

        protected void chk_ProviderStatus_CheckedChanged1(object sender, EventArgs e)
        {
            if (chk_Active.Checked == false)
            {
                SetControlStatus(false);
            }
            else
            {
                SetControlStatus(true);
            }
        }

        protected void PopulateDll()
        {
            Categories categories = new Categories(); categories.PopulateDllAll(drp_Category);
            ProviderTypes ProviderTypes = new ProviderTypes(); ProviderTypes.PopulateDllAll(drp_ProviderTypes);
            Colours colours = new Colours(); colours.PopulateDllAll(drp_Colour);
            Sides sides = new Sides(); sides.PopulateDllAll(drp_Side);

        }
    }
}