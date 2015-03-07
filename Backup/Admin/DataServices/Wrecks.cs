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
    public class Wrecks : LookupCommon
    {
        static string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnection);

        int _WreckID = 0;
        string _WreckNo = string.Empty;
        string _KeyWord = string.Empty;
        Makes _Makes =new Makes();
        Models _Models = new Models();
        Chassiss _Chassiss =new Chassiss();
        Engines _Engines = new Engines();
        CCRatings _CCRatings = new CCRatings();
        EngineSizes _EngineSizes = new EngineSizes();
        FuelTypes _FuelTypes = new FuelTypes();
        BodyTypes _BodyTypes = new BodyTypes();
        WheelBases _WheelBases = new WheelBases();
        Years _Years = new Years();


        public int WreckID { get { return _WreckID; } set { _WreckID = value; } }
        public string WreckNo { get { return _WreckNo; } set { _WreckNo = value; } }
        public string KeyWord { get { return _KeyWord; } set { _KeyWord = value; } }
        public int MakeID { get { return _Makes.MakeID; } set { _Makes.MakeID = value; } }
        public int ModelID { get { return _Models.ModelID; } set { _Models.ModelID = value; } }
        public int ChassisID { get { return _Chassiss.ChassisID; } set { _Chassiss.ChassisID = value; } }
        public int EngineID { get { return _Engines.EngineID; } set { _Engines.EngineID = value; } }
        public int CCRatingID { get { return _CCRatings.CCRatingID; } set { _CCRatings.CCRatingID = value; } }
        public int EngineSizeID { get { return _EngineSizes.EngineSizeID; } set { _EngineSizes.EngineSizeID = value; } }
        public int FuelTypeID { get { return _FuelTypes.FuelTypeID; } set { _FuelTypes.FuelTypeID = value; } }
        public int BodyTypeID { get { return _BodyTypes.BodyTypeID; } set { _BodyTypes.BodyTypeID = value; } }
        public int WheelBaseID { get { return _WheelBases.WheelBaseID; } set { _WheelBases.WheelBaseID = value; } }
        public int YearID { get { return _Years.YearID; } set { _Years.YearID = value; } }

        public string Make { get { return _Makes.Make; } set { _Makes.Make = value; } }
        public string Model { get { return _Models.Model; } set { _Models.Model = value; } }
        public string ChassisNo { get { return _Chassiss.ChassisNo; } set { _Chassiss.ChassisNo = value; } }
        public string EngineNo { get { return _Engines.EngineNo; } set { _Engines.EngineNo = value; } }
        public string EngineSize { get { return _EngineSizes.EngineSize; } set { _EngineSizes.EngineSize = value; } }
        public string FuelType { get { return _FuelTypes.FuelType; } set { _FuelTypes.FuelType = value; } }
        public string BodyType { get { return _BodyTypes.BodyType; } set { _BodyTypes.BodyType = value; } }
        public string WheelBase { get { return _WheelBases.WheelBase; } set { _WheelBases.WheelBase = value; } }
        public string Year { get { return _Years.Year; } set { _Years.Year = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@WreckID", 0);
            sqlCmd.Parameters.AddWithValue("@WreckNo", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "Wreck_Get", "WreckNo", "WreckID", drp);
        }

        public void PopulateByName(DropDownList drp, string searchstring)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@WreckID", 0);
            sqlCmd.Parameters.AddWithValue("@WreckNo", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "Wreck_Get", "WreckNo", "WreckID", drp);

        }

        public Wrecks() 
        {
            
        }

                public bool Save()
        {
            SqlParameter[] SProcParamArray = new SqlParameter[25];
            bool DidSucceed = false;

            try
            {
                SProcParamArray[0] = new SqlParameter("@WreckNo", WreckNo);
                SProcParamArray[1] = new SqlParameter("@KeyWord", KeyWord);
                SProcParamArray[2] = new SqlParameter("@MakeID", MakeID);
                SProcParamArray[3] = new SqlParameter("@ModelID", ModelID);
                SProcParamArray[4] = new SqlParameter("@ChassisID", ChassisID);
                SProcParamArray[5] = new SqlParameter("@EngineID", EngineID);
                SProcParamArray[6] = new SqlParameter("@EngineSizeID", EngineSizeID);
                SProcParamArray[7] = new SqlParameter("@CCRatingID", CCRatingID);
                SProcParamArray[8] = new SqlParameter("@FuelTypeID", FuelTypeID);
                SProcParamArray[9] = new SqlParameter("@BodyTypeID", BodyTypeID);
                SProcParamArray[10]= new SqlParameter("@WheelBaseID", WheelBaseID);
                SProcParamArray[11] = new SqlParameter("@YearID", YearID);
                SProcParamArray[12] = new SqlParameter("@Image", Image);
                SProcParamArray[13] = new SqlParameter("@Active", Active);
                SProcParamArray[14] = new SqlParameter("@LastModifiedDateTime", LastModifiedDateTime);
                SProcParamArray[15] = new SqlParameter("@LastModifiedByUser", LastModifiedByUser);

                if (_WreckID > 0)
                {
                    //Update
                    SProcParamArray[16] = new SqlParameter("@WreckID", _WreckID);                    
                    SProcParamArray[17] = new SqlParameter("@DeletedByUser", DeletedByUser);
                    SProcParamArray[18] = new SqlParameter("@DeletedDateTime", DBNull.Value);                    
                    SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "wreck_update", SProcParamArray);

                }
                else
                {
                    //Add New
                    SProcParamArray[16] = new SqlParameter("@CreatedDateTime", CreatedDateTime);
                    SProcParamArray[17] = new SqlParameter("@CreatedByUser", CreatedByUser);
                    _WreckID = Convert.ToInt32(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "Wreck_insert", SProcParamArray));
                }
                DidSucceed = true;
            }
            catch (Exception ex)
            {
                DidSucceed = false;
            }

            return DidSucceed;
        }



        public DataSet Find()
        {
            SqlParameter[] SProcParamArray = new SqlParameter[5];
            SProcParamArray[0] = new SqlParameter("@WreckNo", WreckNo);
            SProcParamArray[1] = new SqlParameter("@Status", Status);
            SProcParamArray[2] = new SqlParameter("@WreckID", WreckID);
            SProcParamArray[3] = new SqlParameter("@Usage", Usage);        
            
            DataSet SqlHelperDataset = default(DataSet);
            SqlHelperDataset = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Wreck_Get", SProcParamArray);
            return SqlHelperDataset;
        }


        public bool Load()
        {
            bool result;
            try
            {
                DataSet ds = new DataSet();
                ds = Find();
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    WreckNo = (dr["WreckNo"].ToString()) == null ? "" : dr["WreckNo"].ToString();                                        
                    KeyWord= (dr["KeyWord"]) == null ?"" :dr["KeyWord"].ToString() ;
                    MakeID =  (dr["MakeID"]) == null ?0 : Convert.ToInt16(dr["MakeID"].ToString()) ;
                    ModelID = (dr["ModelID"]) == null ?0: Convert.ToInt16(dr["ModelID"].ToString()) ;
                    ChassisID =   (dr["ChassisID"])   == null ?0 : Convert.ToInt16(dr["ChassisID"].ToString())  ;
                    EngineID = (dr["EngineID"]) == null ? 0 : Convert.ToInt16(dr["EngineID"].ToString());
                    CCRatingID = (dr["CCRatingID"]) == null ? 0 : Convert.ToInt16(dr["CCRatingID"].ToString());
                    EngineSizeID= (dr["EngineSizeID"]) == null ?0 : Convert.ToInt16(dr["EngineSizeID"].ToString());     
                    FuelTypeID = (dr["FuelTypeID"]) == null ?0 : Convert.ToInt16(dr["FuelTypeID"].ToString()) ;
                    BodyTypeID = (dr["BodyTypeID"]) == null ?0 : Convert.ToInt16(dr["BodyTypeID"].ToString()) ;
                    WheelBaseID = (dr["WheelBaseID"]) == null ?0 : Convert.ToInt16(dr["WheelBaseID"].ToString()) ;
                    YearID = (dr["YearID"]) == null ? 0 : Convert.ToInt16(dr["YearID"].ToString());

                    Make = (dr["Make"]) == null ? "": (dr["Make"].ToString());
                    Model = (dr["Model"]) == null ? "" : (dr["Model"].ToString());
                    ChassisNo = (dr["ChassisNo"]) == null ? "" : (dr["ChassisNo"].ToString());
                    EngineNo = (dr["EngineNo"]) == null ? "" : (dr["EngineNo"].ToString());
                    EngineSize = (dr["EngineSize"]) == null ? "" : (dr["EngineSize"].ToString());
                    FuelType = (dr["FuelType"]) == null ? "" : (dr["FuelType"].ToString());
                    BodyType = (dr["BodyType"]) == null ? "" : (dr["BodyType"].ToString());
                    WheelBase = (dr["WheelBase"]) == null ? "" : (dr["WheelBase"].ToString());
                    Year = (dr["Year"]) == null ? "" : (dr["Year"].ToString());             

                    CreatedDateTime = (dr["CreatedDateTime"]) == null ? Convert.ToDateTime(ApplicationConstants.DEFAULT_DATES.MIN) : Convert.ToDateTime(dr["CreatedDateTime"].ToString());
                    LastModifiedDateTime = (dr["LastModifiedDateTime"]) == null ? Convert.ToDateTime(ApplicationConstants.DEFAULT_DATES.MIN) : Convert.ToDateTime(dr["LastModifiedDateTime"].ToString());
                    //DeletedDateTime = (dr["DeletedDateTime"]) == null ? Convert.ToDateTime(ApplicationConstants.DEFAULT_DATES.MIN) : Convert.ToDateTime(dr["DeletedDateTime"].ToString());
                    CreatedByUser = (dr["CreatedByUser"]) == null ?"" :dr["CreatedByUser"].ToString();
                    LastModifiedByUser = (dr["LastModifiedByUser"]) == null ?"" :dr["LastModifiedByUser"].ToString() ;
                    DeletedByUser = (dr["DeletedByUser"]) == null ? "":dr["DeletedByUser"].ToString() ;
                    Image = (dr["Image"].ToString()) == null ? "" : dr["Image"].ToString();
                    Active = (dr["Active"]) == null ? false : Convert.ToBoolean(dr["Active"].ToString());
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