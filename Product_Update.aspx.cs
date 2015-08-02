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
using System.Web.Services;
using NeemoAdmin.DataServices;
using Neemo.SupportClasses;


namespace NeemoAdmin
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
                    PopulateDll(); 
                    Session.Remove(FileControlsId + "selectedpicture");
                    Session.Remove(FileControlsId + "uploadedfiles");                   
                    DataView dv = (DataView)SqlDataSourceProduct.Select(DataSourceSelectArguments.Empty);
                    foreach (DataRowView row in dv)
                    {
                        bool special = false;
                        bool soldout = false;
                        //bool discount = false;
                        bool displayonHomePage = false;                        
                        bool featured = false;
                        bool New = false;
                        bool topSeller = false;
                        bool deffects = false;
                        bool active = false;
                        
                        //bool homepage = false;

                        if (row["onSpecial"] != DBNull.Value) { special = ((bool)row["onSpecial"] == true ? true : false); }
                        if (row["Soldout"] != DBNull.Value) { soldout = ((bool)row["Soldout"] == true ? true : false); }
                        //if (row["Discount"] != DBNull.Value) { discount = ((bool)row["Discount"] == true ? true : false); }
                        if (row["DisplayonHomePage"] != DBNull.Value) { displayonHomePage = ((bool)row["DisplayonHomePage"] == true ? true : false); }
                        if (row["New"] != DBNull.Value) { New = ((bool)row["New"] == true ? true : false); }
                        if (row["TopSeller"] != DBNull.Value) { topSeller = ((bool)row["TopSeller"] == true ? true : false); }
                        if (row["Featured"] != DBNull.Value) { featured = ((bool)row["Featured"] == true ? true : false); }
                        if (row["Deffects"] != DBNull.Value) { deffects = ((bool)row["Deffects"] == true ? true : false); }
                        if (row["Active"] != DBNull.Value) { active = ((bool)row["Active"] == true ? true : false); }

                        chk_Special.Checked = special;
                        chk_Soldout.Checked = soldout;
                        //chk_Discount.Checked = New;
                        chk_DisplayonHomePage.Checked = displayonHomePage; 
                        chk_Featured.Checked = featured;
                        chk_TopSeller.Checked = topSeller;
                        chk_Deffects.Checked = deffects;
                        chk_Active.Checked = active;
                        chk_New.Checked = New;


                        drp_Wreck.SelectedValue = row["WreckID"].ToString();
                        drp_Part.SelectedValue = row["PartID"].ToString();
                        txt_Price.Text = row["Price"].ToString();
                        txt_Qty.Text = row["Qty"].ToString();
                        txt_DeffectNotes.Enabled = chk_Deffects.Checked;
                        txt_DeffectNotes.Text = row["DeffectNotes"].ToString();
                        txt_Coments.Text = row["Comment"].ToString();
                        txt_SpecialsNote.Text = row["SpecialsNote"].ToString();
                        PopulateWreck();
                        PopulatePartDetails();

                        if (Request.QueryString["ProductID"] != null)
                        {
                            ImageListHeader objImageListHeader = new ImageListHeader();
                            objImageListHeader.ProductID = Convert.ToInt32(Request.QueryString["ProductID"]);
                            DataTable dtimagelist = objImageListHeader.GetImageListingHeaderByProduct();
                            List<ImageList> lstimage = new List<ImageList>();
                            System.Collections.Generic.List<NeemoAdmin.Handler.ViewsessionUploadFilesResult> objlist;
                            objlist = new List<Handler.ViewsessionUploadFilesResult>();
                            foreach (DataRow drimagelist in dtimagelist.Rows)
                            {
                                ImageList objImageList = new ImageList();
                                NeemoAdmin.Handler.ViewsessionUploadFilesResult objFilesResult = new Handler.ViewsessionUploadFilesResult();
                                objImageList.ImageListID = Convert.ToInt32(drimagelist["ProductPhotoID"]);
                                objImageList.ImageName = drimagelist["PhotoName"].ToString();

                                objFilesResult.Name = drimagelist["PhotoName"].ToString();
                                objFilesResult.Thumbnail_url = drimagelist["PhotoName"].ToString();
                                objFilesResult.ImgListID = Convert.ToInt32(drimagelist["ProductPhotoID"]);
                                objFilesResult.IsDefault = Convert.ToBoolean(drimagelist["Isdefault"]);
                                objFilesResult.IsHaveImg = true;
                                objlist.Add(objFilesResult);

                                objImageList.ThumbNailImageName = drimagelist["PhotoName"].ToString();
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


                        SetControlStatus(true);
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

            private void SaveImages(int productID)
            {
                try
                {
                    DbHandle clsDBHandle = new DbHandle();



                    List<ImageList> lstimage = (List<ImageList>)Session[FileControlsId + "selectedpicture"];
                    bool chkvalid = false;
                    bool chkdefaultvalid = false;
                    ImageListHeader objImageListHeader = new ImageListHeader();
                    objImageListHeader.ProductID = Convert.ToInt32(Request.QueryString["ProductID"]);
                    objImageListHeader.UpdateActiveProductImageList();
                    foreach (ImageList objImageList in lstimage.Where(i => i.Haveimage == true && i.IsDefault == false))
                    {
                        objImageListHeader.Active = false;
                        objImageListHeader.ImageName = objImageList.ImageName;
                        objImageListHeader.ThumbNailImageName = objImageList.ThumbNailImageName;
                        objImageListHeader.InsertProductImageList();
                    }
                    foreach (ImageList objImageList in lstimage.Where(i => i.IsDefault == true && i.Haveimage == true))
                    {
                        chkdefaultvalid = true;
                        chkvalid = true;
                        objImageListHeader = new ImageListHeader();
                        objImageListHeader.ProductID = Convert.ToInt32(Request.QueryString["ProductID"]);
                        objImageListHeader.ImageName = objImageList.ImageName;
                        objImageListHeader.ThumbNailImageName = objImageList.ThumbNailImageName;
                        int defaultimglistid = objImageListHeader.InsertProductImageList();

                        //objImageListHeader.DefaultImageListID = defaultimglistid;
                        //objImageListHeader.UpdateListingHeader();
                        clsDBHandle.OpenConn();
                        SqlParameter StoredProcParamArray = new SqlParameter();
                        SqlCommand sqlCmd = new SqlCommand();
                        DataSet ds = new DataSet();
                        DataTable dt = ds.Tables.Add();
                        sqlCmd.Connection = clsDBHandle.cn;
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandTimeout = 360;
                        sqlCmd.CommandText = string.Format("Update Product Set DefaultProductPhotoID={0} Where ProductID = {1}", defaultimglistid, productID);
                        //sqlCmd.ExecuteScalar(); ScriptManager.RegisterStartupScript(this, this.GetType(), "Completed", "javascript:Display('Record Saved')", true);
                        sqlCmd.ExecuteNonQuery();

                    }
                    if (chkvalid == false || chkdefaultvalid == false)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Validation", "alert('Upload Images or Select Default Image')", true);
                        binddtl(lstimage);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Redirect("Error.aspx");
                }

            }



            protected void btncancel_Click(object sender, EventArgs e)
            {
                Session.Remove(FileControlsId + "uploadedfiles");
                Session.Remove(FileControlsId + "selectedpicture");
                Response.Redirect("DisplayhandlingList.aspx");

            }
            protected void btn_Save_Click(object sender, EventArgs e)
            {
                {

                    try
                    {

                        product.ProductID = Convert.ToInt32(Request.QueryString["ProductID"].ToString());
                        product.WreckID = Convert.ToInt16(drp_Wreck.SelectedValue);
                        product.PartID = Convert.ToInt16(drp_Part.SelectedValue);
                        product.Qty = Convert.ToInt16(txt_Qty.Text);
                        product.Price = Convert.ToDouble(txt_Price.Text);
                        product.Comment = txt_Coments.Text;
                        product.onSpecial = chk_Special.Checked;
                        product.Soldout = chk_Soldout.Checked;
                        product.Discount = 1;// chk_Discount.Checked;
                        product.SpecialsNote = txt_SpecialsNote.Text;
                        product.DisplayonHomePage = chk_DisplayonHomePage.Checked;
                        product.Featured = chk_Featured.Checked;
                        product.New = chk_New.Checked;
                        product.TopSeller = chk_TopSeller.Checked;
                        product.Deffects = chk_Deffects.Checked;
                        product.DeffectNotes = txt_DeffectNotes.Text;
                        product.Active = chk_Active.Checked;
                        if (product.Save())
                        {

                            SaveImages(product.ProductID);
                            //List<ImageList> lstimage = (List<ImageList>)Session[FileControlsId + "selectedpicture"];
                            //if (lstimage[0].Haveimage)
                            //{
                            //    SaveImages(product.ProductID);
                            //}
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Completed", "javascript:Display('Record Saved')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "javascript:Display('Operation Failed')", true);
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                }
                
            }

            protected void btn_reset_Click(object sender, EventArgs e)
            {

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



            //private void saverec()
            //{
            //    DbHandle clsDBHandle = new DbHandle();
            //    clsDBHandle.OpenConn();
            //    SqlParameter StoredProcParamArray = new SqlParameter();
            //    SqlCommand sqlCmd = new SqlCommand();
            //    int _productid = Convert.ToInt16(Request.QueryString["ProductID"]);
            //    try
            //    {

            //        product.WreckID = Convert.ToInt16(drp_Wreck.SelectedValue);
            //        product.PartID = Convert.ToInt16(drp_Part.SelectedValue);
            //        product.Qty = Convert.ToInt16(txt_Qty.Text);
            //        product.Price = Convert.ToDouble(txt_Price.Text);
            //        product.Comment = txt_Coments.Text;
            //        product.onSpecial = chk_Special.Checked;
            //        product.Soldout = chk_Soldout.Checked;
            //        product.Discount = chk_Discount.Checked;
            //        product.SpecialsNote = txt_SpecialsNote.Text;
            //        product.DisplayonHomePage = chk_DisplayonHomePage.Checked;
            //        product.Featured = chk_Featured.Checked;
            //        product.New = chk_New.Checked;
            //        product.TopSeller = chk_TopSeller.Checked;
            //        product.Deffects = chk_Deffects.Checked;
            //        product.CreatedDateTime = DateTime.Now;


            //        sqlCmd.Connection = clsDBHandle.cn;
            //        sqlCmd.CommandType = CommandType.StoredProcedure;
            //        sqlCmd.CommandTimeout = 360;
            //        sqlCmd.CommandText = "[Product_Update]";
            //        sqlCmd.ExecuteScalar();


            //        DataSet ds = new DataSet();
            //        DataTable dt = ds.Tables.Add();
            //        if (Session["PriceList"] != null)
            //        {
            //            dt = Session["PriceList"] as DataTable;
            //        }
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            // get the data                  
            //            double _price = (double)row["price"];
            //            int _priceid = (int)row["ProductPriceID"];
            //            int _qty = (int)row["quantity"];
            //            bool _deleted = (bool)row["deleted"];
            //            string _dateto = row["dateto"].ToString();
            //            SqlHelper.ExecuteNonQuery(clsDBHandle.cn, "ProductPrice_Update", _priceid, _productid, _qty, _price, _deleted);
            //        }

            //        ds = new DataSet();
            //        dt = ds.Tables.Add();
            //        if (Session["FeatureList"] != null)
            //        {
            //            dt = Session["FeatureList"] as DataTable;
            //        }

            //        foreach (DataRow row in dt.Rows)
            //        {
            //            // get the data                                      
            //            int _featureid = (int)row["FeatureID"];
            //            bool _active = (bool)row["Active"];
            //            SqlHelper.ExecuteNonQuery(clsDBHandle.cn, "ProductFeature_Update", _productid, _featureid, _active);
            //        }





            //        SaveImages(_productid);
            //        Session["FeatureList"] = null;
            //        Session["PriceList"] = null;
            //        lbl_Sucess.Visible = true;

            //    }
            //    catch (Exception e)
            //    {

            //        Session["Error"] = e.StackTrace.ToString(); Response.Redirect("/Error.aspx");
            //    }
            //}
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
                    SetControlStatus(true);
                }
                else
                {
                    SetControlStatus(true);
                }
            }


            protected void drp_Part_SelectedIndexChanged(object sender, EventArgs e)
            {
                part.PartID = Convert.ToInt16(drp_Part.SelectedValue);               
                btn_partDetails_Click(btn_partDetails, e);
                initFeatureList();
                initpriceList();
                initPhotoList();
            }

            protected void btn_wreckDetails_Click(object sender, EventArgs e)
            {
                mvw_Parts.ActiveViewIndex = 0;

            }
            protected void btn_partDetails_Click(object sender, EventArgs e)
            {
                mvw_Parts.ActiveViewIndex = 1;
            }

            protected void btn_partFeatures_Click(object sender, EventArgs e)
            {
                mvw_Parts.ActiveViewIndex = 2;

            }

            protected void btn_PartPrice_Click(object sender, EventArgs e)
            {
                mvw_Parts.ActiveViewIndex = 3;

            }

            protected void btn_PartImages_Click(object sender, EventArgs e)
            {
                mvw_Parts.ActiveViewIndex = 4;

            }



            protected void chk_Deffects_CheckedChanged(object sender, EventArgs e)
            {
                if (chk_Deffects.Checked)
                {
                    txt_DeffectNotes.Enabled = true;
                }
                else
                {
                    txt_DeffectNotes.Enabled = false;
                }
            }

            protected void drp_Wreck_SelectedIndexChanged(object sender, EventArgs e)
            {
                wreck.WreckID = Convert.ToInt16(drp_Wreck.SelectedValue);
                wreck.Usage = "SearchByID";
                wreck.Load();
                txt_Make.Text = wreck.Make;
                txt_Model.Text = wreck.Model;
                txt_ChassisNo.Text = wreck.ChassisNo;
                txt_EngineNo.Text = wreck.EngineNo;
                txt_EngineSize.Text = wreck.EngineSize;
                txt_FuelType.Text = wreck.FuelType;
                txt_BodyType.Text = wreck.BodyType;
                txt_WheelBase.Text = wreck.WheelBase;
                txt_Year.Text = wreck.Year;
                btn_wreckDetails_Click(btn_wreckDetails, e);
            }



            protected void btn_SearchWreck_Click(object sender, EventArgs e)
            {
                wreck.PopulateByName(drp_Wreck, txt_WreckSearch.Text);
                drp_Wreck_SelectedIndexChanged(drp_Wreck, e);
            }

            protected void btn_PartSearch_Click(object sender, EventArgs e)
            {
                part.PopulateByName(drp_Part, txt_PartSearch.Text);
                drp_Part_SelectedIndexChanged(drp_Part, e);

            }



        

            private void initpriceList()
            {
                //-- Instantiate the data set and table            
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add("PriceList");
                //-- Add columns to the data table            
                dt.Columns.Add("Partpriceid", typeof(int));
                dt.Columns.Add("Partid", typeof(int));
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
                    sqlCmd.CommandText = string.Format("Select * from PartPrice where Partid={0}", drp_Part.SelectedValue);

                    dr = sqlCmd.ExecuteReader();

                    // Fill the list box with the values retrieved                
                    while (dr.Read())
                    {
                        //dt.Rows.Add((int)dr["priceid"], (int)dr["Partid"], (int)dr["quantity"], (double)dr["price"], (DateTime)dr["EffectiveFrom"], (DateTime)dr["EffectiveDateTo"], (bool)dr["active"]);
                        dt.Rows.Add(dr["Partpriceid"], dr["Partid"], dr["quantity"], dr["price"], dr["EffectiveDateFrom"], dr["EffectiveDateTo"], dr["Active"]);
                        if (Convert.ToInt16(dr["quantity"].ToString()) == 1)
                        {

                            txt_Price.Text = (dr["price"] == null ? "0.00" : dr["price"].ToString());
                        }

                    }
                    grv_PriceList.DataSource = dt;
                    grv_PriceList.DataBind();
                    dr.Close();
                    Session["PriceList"] = dt;
                    grv_PriceList.DataSource = dt;
                    grv_PriceList.DataBind();



                }
                catch (Exception e)
                {

                    Session["Error"] = e.StackTrace.ToString(); Response.Redirect("/Error.aspx");
                }

            }

            private void initFeatureList()
            {
                //-- Instantiate the data set and table            
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add("FeatureList");
                //-- Add columns to the data table            
                dt.Columns.Add("Partfeatureid", typeof(int));
                dt.Columns.Add("PartID", typeof(int));
                dt.Columns.Add("FeatureID", typeof(int));
                dt.Columns.Add("Feature", typeof(string));
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
                    sqlCmd.CommandText = string.Format("Select isnull(P.ColourID,0)ColourID, isnull(P.SideID,0)SideID,PF.Partfeatureid,PF.PartID,PF.FeatureID,F.Feature,PF.EffectiveDateTo,PF.CreatedDateTime,PF.active from PartFeature PF inner join Feature F on PF.FeatureID=F.FeatureID Inner join Part P on PF.PartID = P.PartID where PF.Partid={0}", drp_Part.SelectedValue);

                    dr = sqlCmd.ExecuteReader();
                    Colours colours = new Colours();
                    Sides sides = new Sides();
                    // Fill the list box with the values retrieved                
                    while (dr.Read())
                    {
                        //dt.Rows.Add((int)dr["priceid"], (int)dr["Partid"], (int)dr["quantity"], (double)dr["price"], (DateTime)dr["EffectiveFrom"], (DateTime)dr["EffectiveDateTo"], (bool)dr["active"]);
                        dt.Rows.Add(dr["Partfeatureid"], dr["PartID"], dr["FeatureID"], dr["Feature"], dr["EffectiveDateTo"], dr["CreatedDateTime"], dr["active"]);
                        colours.ColourID = Convert.ToInt16((dr["ColourID"] == null) ? "0" : dr["ColourID"]);
                        sides.SideID = Convert.ToInt16((dr["SideID"] == null) ? "0" : dr["SideID"]);
                    }
                    grv_FeatureList.DataSource = dt;
                    grv_FeatureList.DataBind();
                    dr.Close();
                    Session["FeatureList"] = dt;
                    grv_FeatureList.DataSource = dt;
                    grv_FeatureList.DataBind();

                }
                catch (Exception e)
                {

                    Session["Error"] = e.StackTrace.ToString(); Response.Redirect("/Error.aspx");
                }

            }


            private void initPhotoList()
            {
                //-- Instantiate the data set and table            
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add("PhotoList");
                //-- Add columns to the data table            
                dt.Columns.Add("PartPhotoID", typeof(int));
                dt.Columns.Add("PartID", typeof(int));
                dt.Columns.Add("Photoname", typeof(string));
                dt.Columns.Add("isDefault", typeof(bool));
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
                    sqlCmd.CommandText = string.Format("select distinct Photoname,PartID,PartPhotoID,isDefault  from Vw_PartPhotos_All where Active = 1 and PartID ={0}", drp_Part.SelectedValue);

                    dr = sqlCmd.ExecuteReader();

                    // Fill the list box with the values retrieved                
                    while (dr.Read())
                    {
                        //dt.Rows.Add((int)dr["priceid"], (int)dr["Partid"], (int)dr["quantity"], (double)dr["price"], (DateTime)dr["EffectiveFrom"], (DateTime)dr["EffectiveDateTo"], (bool)dr["active"]);
                        dt.Rows.Add(dr["PartID"], dr["PartPhotoID"], dr["Photoname"], dr["isDefault"]);
                    }
                    dtlPartPhotos.DataSource = dt;
                    dtlPartPhotos.DataBind();
                    dr.Close();
                    Session["PhotoList"] = dt;
                    dtlPartPhotos.DataSource = dt;
                    dtlPartPhotos.DataBind();

                }
                catch (Exception e)
                {

                    Session["Error"] = e.StackTrace.ToString(); Response.Redirect("/Error.aspx");
                }

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
                //lbl_Sucess.Visible = false;
            }

            private void BindDataPrice()
            {
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add();
                dt = Session["PriceList"] as DataTable;
                grv_PriceList.DataSource = dt;
                grv_PriceList.DataBind();
                //lbl_Sucess.Visible = false;

            }

            protected void PopulateDll()
            {
                wreck.PopulateDllAll(drp_Wreck);
                part.PopulateDllAll(drp_Part);

            }


            protected void PopulateWreck()
            {
                wreck.WreckID = Convert.ToInt16(drp_Wreck.SelectedValue);
                wreck.Usage = "SearchByID";
                wreck.Load();
                txt_Make.Text = wreck.Make;
                txt_Model.Text = wreck.Model;
                txt_ChassisNo.Text = wreck.ChassisNo;
                txt_EngineNo.Text = wreck.EngineNo;
                txt_EngineSize.Text = wreck.EngineSize;
                txt_FuelType.Text = wreck.FuelType;
                txt_BodyType.Text = wreck.BodyType;
                txt_WheelBase.Text = wreck.WheelBase;
                txt_Year.Text = wreck.Year;                
            }

            protected void PopulatePartDetails()
            {
                part.PartID = Convert.ToInt16(drp_Part.SelectedValue);
                part.Load();
                txt_Category.Text = part.Category;
                txt_Part.Text = part.Part;
                txt_PartNo.Text = part.PartNo;
                txt_Height.Text = part.Height.ToString();
                txt_Weight.Text = part.Weight.ToString();
                txt_Length.Text = part.Length.ToString();
                txt_Width.Text = part.Width.ToString();
                txt_Colour.Text = part.Colour;
                txt_Side.Text = part.Side;
                txt_PartShortDescription.Text = part.ShortDescription;
                txt_PartDescription.Text = part.Description;
                chk_PartActive.Checked = part.Active;

                
                initFeatureList();
                initpriceList();
                initPhotoList();
            }

    }
}