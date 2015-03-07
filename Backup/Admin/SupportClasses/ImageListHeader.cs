using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
//using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using Neemo.Admin.DataServices;

namespace Neemo.Admin
{
    public class ImageListHeader : LookupCommon
    {
        public int ListingHeaderID { get; set; }
        public int DefaultImageListID { get; set; }
        public int CategoryID { get; set; }
        public int ColourID { get; set; }
        public int SideID{ get; set; }
        public int TypeID	  { get; set; }
        public int ServiceID  { get; set; }
        public int FeatureID { get; set; }
        public int ProjectID { get; set; }
        public int ProductID { get; set; }
        public int PartID { get; set; }        
        public bool Active { get; set; }
        public DateTime DateActive { get; set; }
        public int ImageListID { get; set; }
        public int ImageListHeaderID { get; set; }
        public string ImageName { get; set; }
        public string ThumbNailImageName { get; set; }
        public DateTime CreatedDatetime { get; set; }

        public  int InsertListingHeader()
        {
            using (SqlConnection con = DBConnection.connection())
            {
                con.Open();
                ImageListHeaderID = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "Insert_ListingHeader", DefaultImageListID, ProductID,CategoryID, TypeID, ServiceID, FeatureID, ProjectID));
                //SqlHelper.ExecuteNonQuery(con, "Insert_ListingHeader", DefaultImageListID);
            }
            return ImageListHeaderID;
        }

        public int InsertProductImageList()
        {
            try
            {
                using (SqlConnection con = DBConnection.connection())
                {
                    con.Open();
                    ImageListID = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "ProductPhoto_Insert", ProductID, ImageName));
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
            }
            return ImageListID;
        }

        public void UpdateProductImageList()
        {
            using (SqlConnection con = DBConnection.connection())
            {
                con.Open();
                SqlHelper.ExecuteNonQuery(con, "ProductPhoto_Update", ImageListID, ImageName, ThumbNailImageName, ListingHeaderID);
            }
        }

        public int InsertImageList()
        {
            try
            {
                using (SqlConnection con = DBConnection.connection())
                {
                    con.Open();
                    ImageListID = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "PartPhoto_Insert", PartID, ImageName));
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
            }
            return ImageListID;
        }
       
        public void UpdateImageList()
        {
            using (SqlConnection con = DBConnection.connection())
            {
                con.Open();
                SqlHelper.ExecuteNonQuery(con, "Update_ImageList", ImageListID,ImageName,ThumbNailImageName,ListingHeaderID);
            }
        }
        public void UpdateListingHeader()
        {
            using (SqlConnection con = DBConnection.connection())
            {
                con.Open();
                SqlHelper.ExecuteNonQuery(con, "Update_ListingHeader", ListingHeaderID, DefaultImageListID);
            }
        }
        public void UpdateActiveImageList()
        {
            using (SqlConnection con = DBConnection.connection())
            {
                con.Open();
                SqlHelper.ExecuteNonQuery(con, "UpdateActive_ImageList", ListingHeaderID, Active);
            }
        }
        public void UpdateActiveListingHeader()
        {
            using (SqlConnection con = DBConnection.connection())
            {
                con.Open();
                SqlHelper.ExecuteNonQuery(con, "UpdateActive_ListingHeader", ListingHeaderID, Active);
            }
        }
        public DataTable GetImageListbyid()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.connection())
            {
                con.Open();
                dt = SqlHelper.ExecuteDataset(con, "Get_ById_ImageList", ImageListID).Tables[0];
            }
            return dt;
        }
        public DataTable GetListingHeaderbyid()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.connection())
            {
                con.Open();
                dt = SqlHelper.ExecuteDataset(con, "Get_ById_ListingHeader", ListingHeaderID).Tables[0];
            }
            return dt;
        }
        public DataTable GetallListingHeader()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.connection())
            {
                con.Open();
                dt = SqlHelper.ExecuteDataset(con, "GetALL_ListingHeader").Tables[0];
            }
            return dt;
        }
        public DataTable GetImageListingHeaderByPart()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.connection())
            {
                con.Open();
                dt = SqlHelper.ExecuteDataset(con, "Get_ImageList_ByPartID", PartID).Tables[0];
            }
            return dt;
        }
        public int GetMaxHeaderListingID()
        {
            int id = 0;
            using (SqlConnection con = DBConnection.connection())
            {
                con.Open();
                id = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "Get_MaxListingHeader"));
            }
            return id;
        }

        public DataTable GetImageListingHeaderByProduct()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.connection())
            {
                con.Open();
                dt = SqlHelper.ExecuteDataset(con, "Get_ImageList_ByProductID", ProductID).Tables[0];
            }
            return dt;
        }
        
    }
}