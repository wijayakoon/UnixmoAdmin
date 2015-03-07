using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Neemo.SupportClasses;
using System.Data;
using Neemo.Admin.SupportClasses;

namespace Neemo.Admin.DataServices
{
    public class Parts : LookupCommon
    {
        static string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnection);

        int _PartID = 0;
        string _Part = string.Empty;        
        string _PartNo = string.Empty;        
        decimal _Height = 0;
        decimal _Widht = 0;
        decimal _Length= 0;
        decimal _Weight= 0;
        int _DefaultPartPhotoID = 0;        
        PartFeatures _PartFeature =new PartFeatures();
        ImageListHeader _PartPhoto =new ImageListHeader ();
        string _ShortDescription = string.Empty;
        string _Description = string.Empty;

        public int PartID { get { return _PartID; } set { _PartID = value; } }
        public string Part { get { return _Part; } set { _Part = value; } }
        public string PartNo { get { return _PartNo; } set { _PartNo = value; } }
        public decimal Height { get { return _Height; } set { _Height = value; } }
        public decimal Widht { get { return _Widht; } set { _Widht = value; } }
        public decimal Length { get { return _Length; } set { _Length = value; } }
        public decimal Weight { get { return _Weight; } set { _Weight = value; } }
        public string ShortDescription { get { return _ShortDescription; } set { _ShortDescription = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        public int DefaultPartPhotoID { get { return _DefaultPartPhotoID; } set { _DefaultPartPhotoID = value; } }
        public PartFeatures PartFeature { get { return _PartFeature; } set { _PartFeature = value; } }
        public ImageListHeader PartPhoto { get { return _PartPhoto; } set { _PartPhoto = value; } }
        
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



        public DataSet Find()
        {
            SqlParameter[] SProcParamArray = new SqlParameter[5];
            SProcParamArray[0] = new SqlParameter("@Part", Part);
            SProcParamArray[1] = new SqlParameter("@Status", Status);
            SProcParamArray[2] = new SqlParameter("@PartID", PartID);
            SProcParamArray[3] = new SqlParameter("@Usage", Usage);        
            
            DataSet SqlHelperDataset = default(DataSet);
            SqlHelperDataset = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "part_get", SProcParamArray);
            return SqlHelperDataset;
        }


        //public bool Load()
        //{
        //    bool result;
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        ds = Find();
        //        DataTable dt = ds.Tables[0];
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            WreckNo = (dr["WreckNo"].ToString()) == null ? "" : dr["WreckNo"].ToString();                                        
        //            KeyWord= (dr["KeyWord"]) == null ?"" :dr["KeyWord"].ToString() ;
        //            MakeID =  (dr["MakeID"]) == null ?0 : Convert.ToInt16(dr["MakeID"].ToString()) ;
        //            ModelID = (dr["ModelID"]) == null ?0: Convert.ToInt16(dr["ModelID"].ToString()) ;
        //            ChassisID =   (dr["ChassisID"])   == null ?0 : Convert.ToInt16(dr["ChassisID"].ToString())  ;
        //            EngineID =  (dr["EngineID"])    == null ?0: Convert.ToInt16(dr["EngineID"].ToString())   ;
        //            EngineSizeID= (dr["EngineSizeID"]) == null ?0 : Convert.ToInt16(dr["EngineSizeID"].ToString());     
        //            FuelTypeID = (dr["FuelTypeID"]) == null ?0 : Convert.ToInt16(dr["FuelTypeID"].ToString()) ;
        //            BodyTypeID = (dr["BodyTypeID"]) == null ?0 : Convert.ToInt16(dr["BodyTypeID"].ToString()) ;
        //            WheelBaseID = (dr["WheelBaseID"]) == null ?0 : Convert.ToInt16(dr["WheelBaseID"].ToString()) ;
        //            YearID = (dr["YearID"]) == null ? 0 : Convert.ToInt16(dr["YearID"].ToString());

        //            Make = (dr["Make"]) == null ? "": (dr["Make"].ToString());
        //            Model = (dr["Model"]) == null ? "" : (dr["Model"].ToString());
        //            ChassisNo = (dr["ChassisNo"]) == null ? "" : (dr["ChassisNo"].ToString());
        //            EngineNo = (dr["EngineNo"]) == null ? "" : (dr["EngineNo"].ToString());
        //            EngineSize = (dr["EngineSize"]) == null ? "" : (dr["EngineSize"].ToString());
        //            FuelType = (dr["FuelType"]) == null ? "" : (dr["FuelType"].ToString());
        //            BodyType = (dr["BodyType"]) == null ? "" : (dr["BodyType"].ToString());
        //            WheelBase = (dr["WheelBase"]) == null ? "" : (dr["WheelBase"].ToString());
        //            Year = (dr["Year"]) == null ? "" : (dr["Year"].ToString());             

        //            CreatedDateTime = (dr["CreatedDateTime"]) == null ? Convert.ToDateTime(ApplicationConstants.DEFAULT_DATES.MIN) : Convert.ToDateTime(dr["CreatedDateTime"].ToString());
        //            LastModifiedDateTime = (dr["LastModifiedDateTime"]) == null ? Convert.ToDateTime(ApplicationConstants.DEFAULT_DATES.MIN) : Convert.ToDateTime(dr["LastModifiedDateTime"].ToString());
        //            //DeletedDateTime = (dr["DeletedDateTime"]) == null ? Convert.ToDateTime(ApplicationConstants.DEFAULT_DATES.MIN) : Convert.ToDateTime(dr["DeletedDateTime"].ToString());
        //            CreatedByUser = (dr["CreatedByUser"]) == null ?"" :dr["CreatedByUser"].ToString();
        //            LastModifiedByUser = (dr["LastModifiedByUser"]) == null ?"" :dr["LastModifiedByUser"].ToString() ;
        //            DeletedByUser = (dr["DeletedByUser"]) == null ? "":dr["DeletedByUser"].ToString() ;
        //            Image = (dr["Image"].ToString()) == null ? "" : dr["Image"].ToString();
        //            Active = (dr["Active"]) == null ? false : Convert.ToBoolean(dr["Active"].ToString());
        //        }                
        //        result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        result = false;
        //    }
        //    return result;
           
        //}
    }
}