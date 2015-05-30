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
    public partial class Part_New : System.Web.UI.Page
    {
        public string _FileControlsId {get{return file.ClientID;}}
        public static string FileControlsId { get; set; }
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDll();
                Session["PriceList"] = null;
                Session["FeatureList"] = null;
                Session.Remove(FileControlsId + "selectedpicture");
                Session.Remove(FileControlsId + "uploadedfiles");

            }

            if ((Session["PriceList"] == null) && (Session["FeatureList"] == null))
            {
                initpriceList();
                initFeatureList();
            }
            else
            {
                if (!IsPostBack) { BindDataPrice(); BindDataFetures(); }

            }

           
            
            FileControlsId = _FileControlsId;
            if (!IsPostBack)
            {
                if (Request.QueryString["PartID"] != null)
                {
                    ImageListHeader objImageListHeader = new ImageListHeader();
                    objImageListHeader.ListingHeaderID = Convert.ToInt32(Request.QueryString["PartID"]);
                    objImageListHeader.PartID = Convert.ToInt32(Request.QueryString["PartID"]);
                    DataTable dtimagelist = objImageListHeader.GetImageListingHeaderByPart();
                    List<ImageList> lstimage = new List<ImageList>();
                    System.Collections.Generic.List<NeemoAdmin.Handler.ViewsessionUploadFilesResult> objlist;
                    if (Session[FileControlsId + "uploadedfiles"] != null)
                    {
                        objlist = (List<Handler.ViewsessionUploadFilesResult>)Session[FileControlsId + "uploadedfiles"];
                         startupload(objlist);
                         lstimage = (List<ImageList>)Session[FileControlsId + "selectedpicture"];
                         binddtl(lstimage);
                    }
                    else
                    {
                        objlist = new List<Handler.ViewsessionUploadFilesResult>();
                        foreach (DataRow drimagelist in dtimagelist.Rows)
                        {
                            ImageList objImageList = new ImageList();
                            NeemoAdmin.Handler.ViewsessionUploadFilesResult objFilesResult = new Handler.ViewsessionUploadFilesResult();
                            objImageList.ImageListID = Convert.ToInt32(drimagelist["ImageListID"]);
                            objImageList.ImageName = drimagelist["ImageName"].ToString();

                            objFilesResult.Name = drimagelist["ImageName"].ToString();
                            objFilesResult.Thumbnail_url = drimagelist["ImageName"].ToString();
                            objFilesResult.ImgListID = Convert.ToInt32(drimagelist["ImageListID"]);
                            objFilesResult.IsDefault = Convert.ToBoolean(drimagelist["Isdefault"]);
                            objFilesResult.IsHaveImg = true;
                            objlist.Add(objFilesResult);

                            objImageList.ThumbNailImageName = drimagelist["ThumbNailImageName"].ToString();
                            objImageList.Haveimage = true;
                            objImageList.IsDefault = Convert.ToBoolean(drimagelist["Isdefault"]);
                            lstimage.Add(objImageList);
                        }
                        if (dtimagelist.Rows.Count < Common.MaximumPhotos)
                        {
                            for (int i = 0; i < (Common.MaximumPhotos - dtimagelist.Rows.Count); i++)
                            {
                                ImageList objImageList = new ImageList();
                                objImageList.ThumbNailImageName = "default.jpeg";
                                objImageList.IsDefault = false;
                                objImageList.ImageListID = i;
                                objImageList.Haveimage = false;
                                lstimage.Add(objImageList);
                            }
                        }
                        Session[FileControlsId + "uploadedfiles"] = objlist;
                    }




                    Session[FileControlsId + "selectedpicture"] = lstimage;
                    binddtl(lstimage);                                   
                }

                if (Session[FileControlsId + "uploadedfiles"] == null && Session[FileControlsId + "selectedpicture"] == null)
                {
                    InitPictureBox();
                }
                else
                {
                    List<ImageList> lstimage = (List<ImageList>)Session[FileControlsId + "selectedpicture"];
                    binddtl(lstimage);
                }
              
            }
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
        public ImageList SelectedPictureBox(string tumbname, bool isdefault, ImageList objImageList,bool haveImage)
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
            List<ImageList> lstimage = (List<ImageList>)HttpContext.Current.Session[FileControlsId +"selectedpicture"];
            foreach (ImageList imglist in lstimage)
            {
                imglist.IsDefault = false;
            }
            IEnumerable<ImageList> selectedlstimage = lstimage.Where(i => i.ImageListID == imagelistid);            
            selectedlstimage.First().IsDefault = true;            
            HttpContext.Current.Session[FileControlsId+"selectedpicture"] = lstimage;
        }
        protected static void lnkbtndelete(int id)
        {
            List<ImageList> lstimage = (List<ImageList>)HttpContext.Current.Session[FileControlsId+"selectedpicture"];
            List<NeemoAdmin.Handler.ViewsessionUploadFilesResult> fileuplodeResult = (List<NeemoAdmin.Handler.ViewsessionUploadFilesResult>)HttpContext.Current.Session[FileControlsId+"uploadedfiles"];
            IEnumerable<ImageList> selectedlstimage = lstimage.Where(i => i.ImageListID == id);
            foreach (ImageList imglist in selectedlstimage)
            {
                imglist.ThumbNailImageName = "Default.jpeg";
                imglist.ImageName = "";
                imglist.IsDefault = false;
                imglist.Haveimage = false;
            }
            fileuplodeResult.Remove((fileuplodeResult.Where(i => i.ImgListID == id)).First());
            HttpContext.Current.Session[FileControlsId+"uploadedfiles"] = fileuplodeResult;
            HttpContext.Current.Session[FileControlsId+"selectedpicture"] = lstimage;
        }
        public static string Binddtlajax(List<NeemoAdmin.Handler.ViewsessionUploadFilesResult> obj)
        {            
            string str = "";
            if (obj != null)
            {
                startupload(obj);
            }
             List<ImageList> lstimage = (List<ImageList>)HttpContext.Current.Session[FileControlsId+"selectedpicture"];
                int i = 0;                
                foreach (ImageList img in  lstimage.OrderByDescending(j => j.Haveimage))
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
            if (Request.QueryString["PartID"] == null)
            {
                List<ImageList> lstimage = (List<ImageList>)Session[FileControlsId+"selectedpicture"];
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
                
                    List<ImageList> lstimage = (List<ImageList>)Session[FileControlsId+"selectedpicture"];
                    bool chkvalid = false;
                    bool chkdefaultvalid = false;
                    ImageListHeader objImageListHeader = new ImageListHeader();
                    objImageListHeader.ListingHeaderID = Convert.ToInt32(Request.QueryString["PartID"]);
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
                        objImageListHeader.ListingHeaderID = Convert.ToInt32(Request.QueryString["PartID"]);
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

        private void SaveImages(int partID)
        {
            try
            {
                DbHandle clsDBHandle = new DbHandle();

                if (Request.QueryString["Partid"] == null)
                {
                    RegistrationDetails rd = (RegistrationDetails)Session["RegistrationDetails"];
                    List<ImageList> lstimage = (List<ImageList>)Session[FileControlsId + "selectedpicture"];
                    bool chkvalid = false;
                    bool chkdefaultvalid = false;
                    int defaultimglistid = 0;
                    int imageListHeadeID = 0;
                    foreach (ImageList objImageList in lstimage.Where(i => i.Haveimage == true && i.IsDefault == false))
                    {
                        ImageListHeader objImageListHeader = new ImageListHeader();
                        objImageListHeader.PartID = partID;
                        objImageListHeader.ImageName = objImageList.ImageName;
                        objImageListHeader.CreatedByUser = rd.UserName;
                        objImageListHeader.EffectiveDateFrom = DateTime.Now;
                        objImageListHeader.ThumbNailImageName = objImageList.ThumbNailImageName;
                        //objImageListHeader.ListingHeaderID = objImageListHeader.GetMaxHeaderListingID();
                        objImageListHeader.InsertImageList();
                    }
                    foreach (ImageList objImageList in lstimage.Where(i => i.IsDefault == true && i.Haveimage == true))
                    {
                        chkdefaultvalid = true;
                        chkvalid = true;
                        ImageListHeader objImageListHeader = new ImageListHeader();

                        objImageListHeader.PartID = partID;
                        objImageListHeader.CreatedByUser = rd.UserName;
                        objImageListHeader.EffectiveDateFrom = DateTime.Now;
                        objImageListHeader.ImageName = objImageList.ImageName;
                        objImageListHeader.ThumbNailImageName = objImageList.ThumbNailImageName;
                        //objImageListHeader.ListingHeaderID = objImageListHeader.GetMaxHeaderListingID();
                        defaultimglistid = objImageListHeader.InsertImageList();

                        clsDBHandle.OpenConn();
                        SqlParameter StoredProcParamArray = new SqlParameter();
                        SqlCommand sqlCmd = new SqlCommand();
                        DataSet ds = new DataSet();
                        DataTable dt = ds.Tables.Add();
                        sqlCmd.Connection = clsDBHandle.cn;
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandTimeout = 360;
                        sqlCmd.CommandText = string.Format("Update Part Set DefaultPartPhotoID={0} Where PartID = {1}", defaultimglistid, partID);
                        //sqlCmd.ExecuteScalar(); ScriptManager.RegisterStartupScript(this, this.GetType(), "Completed", "javascript:Display('Record Saved')", true);
                        sqlCmd.ExecuteNonQuery();
                    }

                    //foreach (ImageList objImageList in lstimage.Where(i => i.IsDefault == true && i.Haveimage == true))
                    //{
                    //    chkdefaultvalid = true;
                    //    chkvalid = true;
                    //    ImageListHeader objImageListHeader = new ImageListHeader();

                    //    objImageListHeader.ImageName = objImageList.ImageName;
                    //    objImageListHeader.ThumbNailImageName = objImageList.ThumbNailImageName;
                    //    //objImageListHeader.ListingHeaderID = objImageListHeader.GetMaxHeaderListingID();
                    //    defaultimglistid = objImageListHeader.InsertImageList();

                    //    objImageList.ImageListID = objImageList.ImageListID;
                    //    objImageListHeader.DefaultImageListID = defaultimglistid;
                    //    objImageListHeader.CategoryID = 0;
                    //    objImageListHeader.FeatureID = 0;
                    //    objImageListHeader.ProjectID = 0;
                    //    objImageListHeader.ProductID = productID;
                    //    objImageListHeader.ServiceID = 0;
                    //    objImageListHeader.TypeID = 0;
                    //    imageListHeadeID = objImageListHeader.InsertListingHeader();
                    //}

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
                    objImageListHeader.ListingHeaderID = Convert.ToInt32(Request.QueryString["PartId"]);
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
                        objImageListHeader.ListingHeaderID = Convert.ToInt32(Request.QueryString["PartID"]);
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
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
            }
        
        }
        
       
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Session.Remove(FileControlsId+"uploadedfiles");
            Session.Remove(FileControlsId+"selectedpicture");
            Response.Redirect("DisplayhandlingList.aspx");
          
        }
        protected void Button_Save_Click(object sender, EventArgs e)
        {
            //bool bln = ValidateserviceExist();


            //if (!bln)
            {
                saverec();
                Session["PriceList"] = null;
                Session["FeatureList"] = null;
                
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
                if (Session["PriceList"] != null)
                {
                    dt = Session["PriceList"] as DataTable;

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
                //sqlCmd.Parameters.AddWithValue("@TypeID", Convert.ToInt16(drp_Type.SelectedValue.ToString()));
                sqlCmd.Parameters.AddWithValue("@CategoryID", Convert.ToInt16(drp_Category.SelectedValue.ToString()));
                sqlCmd.Parameters.AddWithValue("@ColourID", Convert.ToInt16(drp_Colour.SelectedValue.ToString()));
                sqlCmd.Parameters.AddWithValue("@SideId", Convert.ToInt16(drp_Side.SelectedValue.ToString()));
                sqlCmd.Parameters.AddWithValue("@ShortDescription", TextBox_ShortDescription.Text);
                sqlCmd.Parameters.AddWithValue("@Keywords", TextBox_Keywords.Text);
                sqlCmd.Parameters.AddWithValue("@Description", TextBox_Description.Text);
                sqlCmd.Parameters.AddWithValue("@Part", TextBox_Name.Text);
                sqlCmd.Parameters.AddWithValue("@PartNo", txt_PartNo.Text);
                sqlCmd.Parameters.AddWithValue("@Height", Convert.ToInt16(txt_Height.Text));
                sqlCmd.Parameters.AddWithValue("@Width", Convert.ToDecimal(txt_Width.Text));
                sqlCmd.Parameters.AddWithValue("@Length", Convert.ToDecimal(txt_Length.Text));
                sqlCmd.Parameters.AddWithValue("@Weight", Convert.ToDecimal(txt_Weight.Text));
                //sqlCmd.Parameters.AddWithValue("@Image", TextBox_ItemCode.Text);
                //sqlCmd.Parameters.AddWithValue("@ThumbNailPath", TextBox_ItemCode.Text);
                //sqlCmd.Parameters.AddWithValue("@ProductpecPath", TextBox_ItemCode.Text);
                sqlCmd.Parameters.AddWithValue("@Active", chk_Active.Checked);
                sqlCmd.Parameters.AddWithValue("@CreatedDateTime", DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@CreatedByUser", rd.UserName);
                sqlCmd.Parameters.AddWithValue("@LastModifiedDateTime", DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@LastModifiedByUser", rd.UserName);

                
              

                sqlCmd.Connection = clsDBHandle.cn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = 360;
                sqlCmd.CommandText = "Part_Insert";
                //sqlCmd.ExecuteScalar(); ScriptManager.RegisterStartupScript(this, this.GetType(), "Completed", "javascript:Display('Record Saved')", true);

                _partID = (int)sqlCmd.ExecuteScalar(); 


                //save Product Price List


                clsDBHandle.OpenConn();
                foreach (DataRow row in dt.Rows)
                {
                    // get the data
                    SqlCommand sqlCmd2 = new SqlCommand();

                    double _retailprice = (double)row["price"];
                    int _qty = (int)row["quantity"];
                    //double _total = (double)row["total"];

                    sqlCmd2.Parameters.AddWithValue("@PartID", _partID);
                    sqlCmd2.Parameters.AddWithValue("@Quantity", _qty);
                    sqlCmd2.Parameters.AddWithValue("@Price", _retailprice);


                    sqlCmd2.Connection = clsDBHandle.cn;
                    sqlCmd2.CommandType = CommandType.StoredProcedure;
                    sqlCmd2.CommandTimeout = 360;
                    sqlCmd2.CommandText = "PartPrice_Insert";
                    sqlCmd2.ExecuteNonQuery();


                }

                ds = new DataSet();
                dt = ds.Tables.Add();
                if (Session["FeatureList"] != null)
                {
                    dt = Session["FeatureList"] as DataTable;

                }
                foreach (DataRow row in dt.Rows)
                {
                    // get the data
                    SqlCommand sqlCmd2 = new SqlCommand();

                    int _feature = (int)row["FeatureID"];

                    //double _total = (double)row["total"];

                    sqlCmd2.Parameters.AddWithValue("@PartID", _partID);
                    sqlCmd2.Parameters.AddWithValue("@FeatureID", _feature);
                    sqlCmd2.Parameters.AddWithValue("@Active", true);

                    sqlCmd2.Connection = clsDBHandle.cn;
                    sqlCmd2.CommandType = CommandType.StoredProcedure;
                    sqlCmd2.CommandTimeout = 360;
                    sqlCmd2.CommandText = "PartFeature_Insert";
                    sqlCmd2.ExecuteNonQuery();


                }

                Session["PriceList"] = null;
                Session["FeatureList"] = null;
                SaveImages(_partID);
                lbl_Sucess.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Completed", "javascript:Display('Record Saved')", true);
            }
            catch (Exception e)
            {

                Response.Redirect("/Error.aspx");
            }
            //Response.Redirect("Product_New.aspx");
        }
        protected void Button_Reset_Click(object sender, EventArgs e)
        {
            Session["PriceList"] = null;
            Response.Redirect("Part_New.aspx");

        }



        protected void btn_PriceAdd_Click(object sender, EventArgs e)
        {
            
            AddPrice();
        }


        protected void btn_FeatureAdd_Click(object sender, EventArgs e)
        {
            AddFeature();
        }

        private void initpriceList()
        {
            //-- Instantiate the data set and table            
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            //-- Add columns to the data table            
            dt.Columns.Add("productid", typeof(int));
            dt.Columns.Add("quantity", typeof(int));
            dt.Columns.Add("price", typeof(double));
            dt.Columns.Add("datefrom", typeof(DateTime));
            dt.Columns.Add("dateto", typeof(DateTime));
            dt.Columns.Add("active", typeof(bool));
            //dt.Columns.Add("total", typeof(double));
            Session["PriceList"] = dt;
            grv_PriceList.DataSource = Session["PriceList"];
            grv_PriceList.DataBind();
            lbl_Sucess.Visible = false;


        }
        private void initFeatureList()
        {
            //-- Instantiate the data set and table            
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            //-- Add columns to the data table            
            dt.Columns.Add("FeatureID", typeof(int));
            dt.Columns.Add("FeatureName", typeof(string));
            dt.Columns.Add("active", typeof(bool));
            Session["FeatureList"] = dt;
            grv_PriceList.DataSource = Session["FeatureList"];
            grv_PriceList.DataBind();
            lbl_Sucess.Visible = false;
        }



        protected void OnPagingProduct(object sender, GridViewPageEventArgs e)
        {
            grv_PriceList.PageIndex = e.NewPageIndex;
            BindDataPrice();
        }

        protected void grv_PriceList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["PriceList"] as DataTable;

            DataSet ds1 = new DataSet();
            DataTable dt1 = dt;


            //double total = double.Parse(dt1.Rows[e.RowIndex]["total"].ToString());

            dt1.Rows[e.RowIndex].Delete();
            dt1.AcceptChanges();
            ds1.Tables.Add(dt1.Copy());
            ds1.Tables[0].AcceptChanges();
            Session["PriceList"] = dt1;
            BindDataPrice();

        }


        protected void grv_FeatureList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["FeatureList"] as DataTable;

            DataSet ds1 = new DataSet();
            DataTable dt1 = dt;

            //double total = double.Parse(dt1.Rows[e.RowIndex]["total"].ToString());

            dt1.Rows[e.RowIndex].Delete();
            dt1.AcceptChanges();
            ds1.Tables.Add(dt1.Copy());
            ds1.Tables[0].AcceptChanges();
            Session["FeatureList"] = dt1;
            BindDataFetures();

        }

        protected void UpdateProduct(object sender, GridViewUpdateEventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["PriceList"] as DataTable;
            TextBox txtitems = (TextBox)grv_PriceList.Rows[e.RowIndex].FindControl("txt_Qty");
            int qty = Int32.Parse(txtitems.Text);
            dt.Rows[e.RowIndex]["qty"] = qty;
            Session["PriceList"] = dt;
            grv_PriceList.EditIndex = -1;
            BindDataPrice();
        }



        private void BindDataFetures()
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["FeatureList"] as DataTable;
            grv_FeatureList.DataSource = dt;
            grv_FeatureList.DataBind();
            lbl_Sucess.Visible = false;
        }

        private void BindDataPrice()
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            dt = Session["PriceList"] as DataTable;
            grv_PriceList.DataSource = dt;
            grv_PriceList.DataBind();
            lbl_Sucess.Visible = false;

        }



        public void AddPrice()
        {
            //if (e.CommandName == "Edit")
            {
                int qty = Convert.ToInt16(txt_Qty.Text);
                double price = Convert.ToDouble(txt_Price.Text);
                //double price = double.Parse(lblprice.Value);

                //-- Instantiate the data set and table            
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add();
                //-- Add columns to the data table            
                if (Session["PriceList"] == null)
                {
                    initpriceList();
                }
                dt = Session["PriceList"] as DataTable;

                bool qtyExist = false;
                if (dt.Rows.Count > 0)
                {
                    DataRow[] foundRow;
                    foundRow = dt.Select("quantity=" + txt_Qty.Text);

                    //DataRow foundRow = ds.Tables["Table1"].Rows.Find(Convert.ToInt16(txt_Qty.Text));
                    if (foundRow.Count() == 0)
                    {
                        dt.Rows.Add(0, qty, price, DateTime.Now, null, true);
                        lbl_qantityExists.Visible = false;
                    }
                    else
                    {
                        lbl_qantityExists.Visible = true;
                    }
                }
                else
                {
                    dt.Rows.Add(0, qty, price, DateTime.Now, null, true);
                    lbl_qantityExists.Visible = false;

                }


                Session["PriceList"] = dt;
                BindDataPrice();
                txt_Qty.Text = (qty + 1).ToString();
                txt_Price.Text = "0.00";
                //dt.Columns.Add("productid", typeof(int));
                //dt.Columns.Add("quantity", typeof(int));
                //dt.Columns.Add("price", typeof(double));
                //dt.Columns.Add("datefrom", typeof(DateTime));
                //dt.Columns.Add("dateto", typeof(DateTime));
                //dt.Columns.Add("active", typeof(bool));
            }
        }

        public void AddFeature()
        {
            //if (e.CommandName == "Edit")
            {
                int FeatureID = Convert.ToInt16(drp_Features.SelectedItem.Value);
                string FeatureName = drp_Features.SelectedItem.Text;

                //-- Instantiate the data set and table            
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add();
                //-- Add columns to the data table            
                if (Session["FeatureList"] == null)
                {
                    initFeatureList();
                }
                dt = Session["FeatureList"] as DataTable;

                if (dt.Rows.Count > 0)
                {
                    DataRow[] foundRow;
                    foundRow = dt.Select("FeatureID=" + drp_Features.SelectedItem.Value);

                    //DataRow foundRow = ds.Tables["Table1"].Rows.Find(Convert.ToInt16(txt_Qty.Text));
                    if (foundRow.Count() == 0)
                    {
                        dt.Rows.Add(FeatureID, FeatureName, true);
                        lbl_FeatureExists.Visible = false;
                    }
                    else
                    {
                        lbl_FeatureExists.Visible = true;
                    }
                }
                else
                {
                    dt.Rows.Add(FeatureID, FeatureName, true);
                    lbl_FeatureExists.Visible = false;

                }


                Session["FeatureList"] = dt;
                BindDataFetures();

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
            Categories categories = new Categories(); categories.PopulateDllAll(drp_Category);
            Features features = new Features(); features.PopulateDllAll(drp_Features);
            Colours colours = new Colours(); colours.PopulateDllAll(drp_Colour);
            Sides sides = new Sides(); sides.PopulateDllAll(drp_Side);
            
        }
    }



}