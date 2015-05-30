using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Neemo.SupportClasses;
using System.Data;
using NeemoAdmin.SupportClasses;

namespace NeemoAdmin.DataServices
{
    public class Parts : LookupCommon
    {
        static string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnection);

        string _Part;
        int _CategoryID;
        bool _Active;
        string _Category;
        string _PartNo;
        int _PartID;
        int _DefaultPartPhotoID;
        int _PartPhotoID;
        int _Quantity;
        double _Price;
        string _PhotoName;
        string _ShortDescription;
        string _KeyWords;
        string _Description;
        int _Height;
        int _Width;
        int _Length;
        int _Weight;
        string _Colour;
        string _Side;
        bool _isDefault;
        PartFeatures _PartFeature = new PartFeatures();
        PartPhotos _PartPhotos = new PartPhotos();
        //ImageListHeader _PartPhoto =new ImageListHeader ();

        public string Part { get { return _Part; } set { _Part = value; } }
        public int CategoryID { get { return _CategoryID; } set { _CategoryID = value; } }
        public string Category { get { return _Category; } set { _Category = value; } }
        public string PartNo { get { return _PartNo; } set { _PartNo = value; } }
        public int PartID { get { return _PartID; } set { _PartID = value; } }
        public int DefaultPartPhotoID { get { return _DefaultPartPhotoID; } set { _DefaultPartPhotoID = value; } }
        public int PartPhotoID { get { return _PartPhotoID; } set { _PartPhotoID = value; } }
        public int Quantity { get { return _Quantity; } set { _Quantity = value; } }
        public double Price { get { return _Price; } set { _Price = value; } }
        public string PhotoName { get { return _PhotoName; } set { _PhotoName = value; } }

        public string ShortDescription { get { return _ShortDescription; } set { _ShortDescription = value; } }
        public string KeyWords { get { return _KeyWords; } set { _KeyWords = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        public int Height { get { return _Height; } set { _Height = value; } }
        public int Width { get { return _Width; } set { _Width = value; } }
        public int Length { get { return _Length; } set { _Length = value; } }
        public int Weight { get { return _Weight; } set { _Weight = value; } }
        public string Colour { get { return _Colour; } set { _Colour = value; } }
        public string Side { get { return _Side; } set { _Side = value; } }
        public bool isDefault { get { return _isDefault; } set { _isDefault = value; } }
        public PartFeatures PartFeature { get { return _PartFeature; } set { _PartFeature = value; } }
        public PartPhotos PartPhotos { get { return _PartPhotos; } set { _PartPhotos = value; } }
        
        
        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@PartID", 0);
            sqlCmd.Parameters.AddWithValue("@Part", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "Part_Get", "Part", "PartID", drp);
        }

        public void PopulateByName(DropDownList drp, string searchstring)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@PartID", 0);
            sqlCmd.Parameters.AddWithValue("@Part", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "Part_Get", "Part", "PartID", drp);

        }

        public Parts() 
        {
            
        }

        //        public bool Save()
        //{
        //    SqlParameter[] SProcParamArray = new SqlParameter[25];
        //    bool DidSucceed = false;

        //    try
        //    {
        //        SProcParamArray[0] = new SqlParameter("@WreckNo", WreckNo);
        //        SProcParamArray[1] = new SqlParameter("@KeyWord", KeyWord);
        //        SProcParamArray[2] = new SqlParameter("@MakeID", MakeID);
        //        SProcParamArray[3] = new SqlParameter("@ModelID", ModelID);
        //        SProcParamArray[4] = new SqlParameter("@ChassisID", ChassisID);
        //        SProcParamArray[5] = new SqlParameter("@EngineID", EngineID);
        //        SProcParamArray[6] = new SqlParameter("@EngineSizeID", EngineSizeID);
        //        SProcParamArray[7] = new SqlParameter("@FuelTypeID", FuelTypeID);
        //        SProcParamArray[8] = new SqlParameter("@BodyTypeID", BodyTypeID);
        //        SProcParamArray[9] = new SqlParameter("@WheelBaseID", WheelBaseID);
        //        SProcParamArray[10] = new SqlParameter("@YearID", YearID);
        //        SProcParamArray[11] = new SqlParameter("@Image", Image);
        //        SProcParamArray[14] = new SqlParameter("@Active", Active);
        //        SProcParamArray[12] = new SqlParameter("@LastModifiedDateTime", LastModifiedDateTime);
        //        SProcParamArray[13] = new SqlParameter("@LastModifiedByUser", LastModifiedByUser);

        //        if (_PartID > 0)
        //        {
        //            //Update
        //            SProcParamArray[15] = new SqlParameter("@WreckID", _PartID);                    
        //            SProcParamArray[16] = new SqlParameter("@DeletedByUser", DeletedByUser);
        //            SProcParamArray[17] = new SqlParameter("@DeletedDateTime", DBNull.Value);                    
        //            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "wreck_update", SProcParamArray);

        //        }
        //        else
        //        {
        //            //Add New
        //            SProcParamArray[15] = new SqlParameter("@CreatedDateTime", CreatedDateTime);
        //            SProcParamArray[16] = new SqlParameter("@CreatedByUser", CreatedByUser);
        //            _PartID = Convert.ToInt32(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "Wreck_insert", SProcParamArray));
        //        }
        //        DidSucceed = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        DidSucceed = false;
        //    }

        //    return DidSucceed;
        //}



        public DataSet FindDetails()
        {
            SqlParameter[] SProcParamArray = new SqlParameter[5];
            SProcParamArray[0] = new SqlParameter("@PartID", PartID);
            //SProcParamArray[1] = new SqlParameter("@Status", Status);
            //SProcParamArray[2] = new SqlParameter("@PartID", PartID);
            //SProcParamArray[3] = new SqlParameter("@Usage", Usage);        
            
            DataSet SqlHelperDataset = default(DataSet);
            SqlHelperDataset = SqlHelper.ExecuteDataset(con, CommandType.Text, "Select * From vw_PartDetails_All where PartID = @PartID", SProcParamArray);
            return SqlHelperDataset;
        }


        public bool Load()
        {
            bool result;
            try
            {
                DataSet ds = new DataSet();
                ds = FindDetails();
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {

                    Part= (dr["Part"].ToString()) == null ? "" : dr["Part"].ToString();
                    CategoryID= Convert.ToInt16(dr["CategoryID"].ToString() == null ? "0" : dr["CategoryID"].ToString());
                    Active = Convert.ToBoolean(dr["Active"].ToString() == null ? "false" : dr["Active"].ToString());
                    Category= dr["Category"].ToString() == null ? "" : dr["Category"].ToString();
                    PartNo= dr["PartNo"].ToString() == null ? "" : dr["PartNo"].ToString();
                    PartID= Convert.ToInt16(dr["PartID"].ToString() == null ? "" : dr["PartID"].ToString());
                    DefaultPartPhotoID = Convert.ToInt16(dr["DefaultPartPhotoID"].ToString() == null ? "0" : dr["DefaultPartPhotoID"].ToString());
                    PartPhotoID=  Convert.ToInt16(dr["PartPhotoID"].ToString() == null ? "0" : dr["PartPhotoID"].ToString());
                    Quantity= Convert.ToInt16(dr["Quantity"].ToString() == null ? "0" : dr["Quantity"].ToString());
                    Price= Convert.ToDouble(dr["Price"].ToString() == null ?"0.00" : dr["Price"].ToString());
                    PhotoName= dr["PhotoName"].ToString() == null ? "" : dr["PhotoName"].ToString();
                    CreatedDateTime= Convert.ToDateTime(dr["CreatedDateTime"].ToString() == null ? "" : dr["CreatedDateTime"].ToString());
                    ShortDescription = (dr["ShortDescription"].ToString()) == null ? "" : dr["ShortDescription"].ToString();
                    KeyWords = (dr["KeyWords"].ToString()) == null ? "" : dr["KeyWords"].ToString();
                    Description= (dr["Description"].ToString()) == null ? "" : dr["Description"].ToString();
                    Height= Convert.ToInt16(dr["Height"].ToString() == null ? "0" : dr["Height"].ToString());
                    Width= Convert.ToInt16(dr["Width"].ToString() == null ? "0" : dr["Width"].ToString());
                    Length= Convert.ToInt16(dr["Length"].ToString() == null ? "0" : dr["Length"].ToString());
                    Weight= Convert.ToInt16(dr["Weight"].ToString() == null ? "0" : dr["Weight"].ToString());
                    Colour= (dr["Colour"].ToString()) == null ? "" : dr["Colour"].ToString();
                    Side= (dr["Side"].ToString()) == null ? "" : dr["Side"].ToString();
                    isDefault= Convert.ToBoolean( dr["isDefault"].ToString() == null ? "false" : dr["isDefault"].ToString());

                }
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;

        }
    }
}