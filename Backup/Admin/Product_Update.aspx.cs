using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Neemo.Admin.SupportClasses;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;
using Neemo.Admin.DataServices;
using Neemo.SupportClasses;


namespace Neemo.Admin
{
    public partial class Product_Update : System.Web.UI.Page
    {
            public ApplicationConstants apc = new ApplicationConstants();
            Wrecks wreck = new Wrecks();
            Parts part = new Parts();
            Products product = new Products();
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


                if (!IsPostBack)
                {
                    Session.Remove(FileControlsId + "selectedpicture");
                    Session.Remove(FileControlsId + "uploadedfiles");                   
                    DataView dv = (DataView)SqlDataSourceProduct.Select(DataSourceSelectArguments.Empty);
                    foreach (DataRowView row in dv)
                    {
                        bool special = false;
                        bool soldout = false;
                        bool discount = false;
                        bool displayonHomePage = false;                        
                        bool featured = false;
                        bool New = false;
                        bool topSeller = false;
                        bool deffects = false;
                        bool active = false;
                        
                        //bool homepage = false;

                        if (row["onSpecial"] != DBNull.Value) { special = ((bool)row["onSpecial"] == true ? true : false); }
                        if (row["Soldout"] != DBNull.Value) { soldout = ((bool)row["Soldout"] == true ? true : false); }
                        if (row["Discount"] != DBNull.Value) { discount = ((bool)row["Discount"] == true ? true : false); }
                        if (row["DisplayonHomePage"] != DBNull.Value) { displayonHomePage = ((bool)row["DisplayonHomePage"] == true ? true : false); }
                        if (row["New"] != DBNull.Value) { New = ((bool)row["New"] == true ? true : false); }
                        if (row["TopSeller"] != DBNull.Value) { topSeller = ((bool)row["TopSeller"] == true ? true : false); }
                        if (row["Featured"] != DBNull.Value) { featured = ((bool)row["Featured"] == true ? true : false); }
                        if (row["Deffects"] != DBNull.Value) { deffects = ((bool)row["Deffects"] == true ? true : false); }
                        if (row["Active"] != DBNull.Value) { active = ((bool)row["Active"] == true ? true : false); }

                        chk_Special.Checked = special;
                        chk_Soldout.Checked = soldout;
                        chk_Discount.Checked = New;
                        chk_DisplayonHomePage.Checked = displayonHomePage; 
                        chk_Featured.Checked = featured;
                        chk_TopSeller.Checked = topSeller;
                        chk_Deffects.Checked = deffects;
                        chk_Active.Checked = active;

                        if (Request.QueryString["imageListID"] != null)
                        {
                            ImageListHeader objImageListHeader = new ImageListHeader();
                            objImageListHeader.ListingHeaderID = Convert.ToInt32(Request.QueryString["imageListID"]);
                            DataTable dtimagelist = objImageListHeader.GetImageListingHeaderByProduct();
                            List<ImageList> lstimage = new List<ImageList>();
                            System.Collections.Generic.List<Neemo.Handler.ViewsessionUploadFilesResult> objlist;
                            objlist = new List<Handler.ViewsessionUploadFilesResult>();
                            foreach (DataRow drimagelist in dtimagelist.Rows)
                            {
                                ImageList objImageList = new ImageList();
                                Neemo.Handler.ViewsessionUploadFilesResult objFilesResult = new Handler.ViewsessionUploadFilesResult();
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


                        SetControlStatus(chk_Active.Checked);
                    }

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
            public static List<ImageList> startupload(List<Neemo.Handler.ViewsessionUploadFilesResult> files)
            {
                int i = 0;
                List<ImageList> lstimage = new List<ImageList>();
                foreach (Neemo.Handler.ViewsessionUploadFilesResult lstupload in files)
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
                System.Collections.Generic.List<Neemo.Handler.ViewsessionUploadFilesResult> obj = (System.Collections.Generic.List<Neemo.Handler.ViewsessionUploadFilesResult>)(HttpContext.Current.Session[FileControlsId + "uploadedfiles"]);
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
                List<Neemo.Handler.ViewsessionUploadFilesResult> fileuplodeResult = (List<Neemo.Handler.ViewsessionUploadFilesResult>)HttpContext.Current.Session[FileControlsId + "uploadedfiles"];
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
            public static string Binddtlajax(List<Neemo.Handler.ViewsessionUploadFilesResult> obj)
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

            private void SaveImages(int productID)
            {
                if (Request.QueryString["imageListID"] == null)
                {
                    List<ImageList> lstimage = (List<ImageList>)Session[FileControlsId + "selectedpicture"];
                    bool chkvalid = false;
                    bool chkdefaultvalid = false;
                    int defaultimglistid = 0;
                    int imageListHeadeID = 0;
                    foreach (ImageList objImageList in lstimage.Where(i => i.IsDefault == true && i.Haveimage == true))
                    {
                        chkdefaultvalid = true;
                        chkvalid = true;
                        ImageListHeader objImageListHeader = new ImageListHeader();

                        objImageList.ImageListID = objImageList.ImageListID;
                        objImageListHeader.DefaultImageListID = defaultimglistid;
                        objImageListHeader.CategoryID = 0;
                        objImageListHeader.FeatureID = 0;
                        objImageListHeader.ProjectID = 0;
                        objImageListHeader.ProductID = productID;
                        objImageListHeader.ServiceID = 0;
                        objImageListHeader.TypeID = 0;
                        imageListHeadeID = objImageListHeader.InsertListingHeader();

                        objImageListHeader.ImageName = objImageList.ImageName;
                        objImageListHeader.ThumbNailImageName = objImageList.ThumbNailImageName;
                        objImageListHeader.ListingHeaderID = imageListHeadeID;
                        defaultimglistid = objImageListHeader.InsertImageList();
                    }
                    foreach (ImageList objImageList in lstimage.Where(i => i.Haveimage == true && i.IsDefault == false))
                    {
                        ImageListHeader objImageListHeader = new ImageListHeader();
                        objImageListHeader.ImageName = objImageList.ImageName;
                        objImageListHeader.ThumbNailImageName = objImageList.ThumbNailImageName;
                        objImageListHeader.ListingHeaderID = imageListHeadeID;
                        objImageListHeader.InsertImageList();
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
                    objImageListHeader.ListingHeaderID = Convert.ToInt32(Request.QueryString["imageListID"]);
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
                        objImageListHeader.ListingHeaderID = Convert.ToInt32(Request.QueryString["imageListID"]);
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
                    Session["PriceList"] = null;
                    Session["FeatureList"] = null;
                    Response.Redirect("Product_Search.aspx");
                }
            }

            protected string HideEditButton(string dateto)
            {
                //If count>1 then show text in HyperLink

                if (dateto == "")
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
                DbHandle clsDBHandle = new DbHandle();
                clsDBHandle.OpenConn();
                SqlParameter StoredProcParamArray = new SqlParameter();
                SqlCommand sqlCmd = new SqlCommand();
                int _productid = Convert.ToInt16(Request.QueryString["ProductID"]);
                try
                {

                    product.WreckID = Convert.ToInt16(drp_Wreck.SelectedValue);
                    product.PartID = Convert.ToInt16(drp_Part.SelectedValue);
                    product.Qty = Convert.ToInt16(txt_Qty.Text);
                    product.Price = Convert.ToDouble(txt_Price.Text);
                    product.Comment = txt_Coments.Text;
                    product.onSpecial = chk_Special.Checked;
                    product.Soldout = chk_Soldout.Checked;
                    product.Discount = chk_Discount.Checked;
                    product.SpecialsNote = txt_SpecialsNote.Text;
                    product.DisplayonHomePage = chk_DisplayonHomePage.Checked;
                    product.Featured = chk_Featured.Checked;
                    product.New = chk_New.Checked;
                    product.TopSeller = chk_TopSeller.Checked;
                    product.Deffects = chk_Deffects.Checked;
                    product.CreatedDateTime = DateTime.Now;


                    sqlCmd.Connection = clsDBHandle.cn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = 360;
                    sqlCmd.CommandText = "[Product_Update]";
                    sqlCmd.ExecuteScalar();


                    DataSet ds = new DataSet();
                    DataTable dt = ds.Tables.Add();
                    if (Session["PriceList"] != null)
                    {
                        dt = Session["PriceList"] as DataTable;
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        // get the data                  
                        double _price = (double)row["price"];
                        int _priceid = (int)row["ProductPriceID"];
                        int _qty = (int)row["quantity"];
                        bool _deleted = (bool)row["deleted"];
                        string _dateto = row["dateto"].ToString();
                        SqlHelper.ExecuteNonQuery(clsDBHandle.cn, "ProductPrice_Update", _priceid, _productid, _qty, _price, _deleted);
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
                        int _featureid = (int)row["FeatureID"];
                        bool _active = (bool)row["Active"];
                        SqlHelper.ExecuteNonQuery(clsDBHandle.cn, "ProductFeature_Update", _productid, _featureid, _active);
                    }





                    SaveImages(_productid);
                    Session["FeatureList"] = null;
                    Session["PriceList"] = null;
                    lbl_Sucess.Visible = true;

                }
                catch (Exception e)
                {

                    Response.Redirect("/Error.aspx");
                }
            }
            protected void Button_Reset_Click(object sender, EventArgs e)
            {
                Session["PriceList"] = null;
                Response.Redirect("Product_Search.aspx");

            }

            protected void drp_ServiceItem_SelectedIndexChanged(object sender, EventArgs e)
            {
                //bool bln = ValidateserviceExist();

            }

          

            private void SetControlStatus(bool status)
            {
                txt_Qty.Enabled = status;
                txt_Price.Enabled = status;
            }

            protected void chk_ProductStatus_CheckedChanged1(object sender, EventArgs e)
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





        
    }
}