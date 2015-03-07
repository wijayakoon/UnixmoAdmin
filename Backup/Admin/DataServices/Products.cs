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
    public class Products : LookupCommon
    {
        static string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnection);

        int _ProductID= 0;        
        int _PartID = 0;        
        int _WreckID = 0;
        int _Qty = 0;
        double _Price = 0.00;        
        string _Comment = string.Empty;                
        bool _onSpecial= false;
        bool _Soldout= false;
        bool _Discount= false;
        string _SpecialsNote= string.Empty;
        bool _DisplayonHomePage= false;
        bool _Featured= false;
        bool _New= false;
        bool _TopSeller = false;
        bool _Deffects = false;
        string _DeffectNotes = string.Empty;
        ImageListHeader _PartPhoto =new ImageListHeader();
        Parts _Part = new Parts();
        Wrecks  _Wreck=new Wrecks();
        


        public int ProductID { get { return _ProductID; } set { _ProductID = value; } }
        public int PartID { get { return _PartID; } set { _PartID = value; } }
        public int WreckID { get { return _WreckID; } set { _WreckID = value; } }
        public int Qty { get { return _Qty; } set { _Qty = value; } }
        public double Price { get { return _Price; } set { _Price = value; } }
        public string Comment { get { return _Comment; } set { _Comment = value; } }
        public bool onSpecial { get { return _onSpecial; } set { _onSpecial = value; } }
        public bool Soldout { get { return _Soldout; } set { _Soldout = value; } }
        public bool Discount { get { return _Discount; } set { _Discount = value; } }
        public string SpecialsNote { get { return _SpecialsNote; } set { _SpecialsNote = value; } }
        public bool DisplayonHomePage { get { return _DisplayonHomePage; } set { _DisplayonHomePage = value; } }
        public bool Featured { get { return _Featured; } set { _Featured = value; } }
        public bool New { get { return _New; } set { _New = value; } }
        public bool TopSeller { get { return _TopSeller; } set { _TopSeller = value; } }
        public bool Deffects { get { return _Deffects; } set { _Deffects = value; } }
        public string DeffectNotes { get { return _DeffectNotes; } set { _DeffectNotes = value; } }
        public ImageListHeader PartPhoto { get { return _PartPhoto; } set { _PartPhoto = value; } }
        public Parts Part { get { return _Part; } set { _Part= value; } }
        public Wrecks Wreck { get { return _Wreck; } set { _Wreck= value; } }
        

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@ProductID", 0);
            sqlCmd.Parameters.AddWithValue("@Part", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "Product_Get", "WreckNo", "WreckID", drp);
        }

        public void PopulateByName(DropDownList drp, string searchstring)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@ProductID", 0);
            sqlCmd.Parameters.AddWithValue("@Part", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "Product_Get", "Part", "ProductID", drp);

        }

        public Products() 
        {
            
        }

        public bool Save()
        {
            SqlParameter[] SProcParamArray = new SqlParameter[25];
            bool DidSucceed = false;

            try
            {


                SProcParamArray[0] = new SqlParameter("@WreckID", WreckID);
                SProcParamArray[1] = new SqlParameter("@PartID", PartID);
                SProcParamArray[2] = new SqlParameter("@Qty", Qty);
                SProcParamArray[3] = new SqlParameter("@Comment", Comment);
                SProcParamArray[4] = new SqlParameter("@onSpecial", onSpecial);
                SProcParamArray[5] = new SqlParameter("@Soldout", Soldout);
                SProcParamArray[6] = new SqlParameter("@Discount", Discount);
                SProcParamArray[7] = new SqlParameter("@SpecialsNote", SpecialsNote);
                SProcParamArray[8] = new SqlParameter("@DisplayonHomePage", DisplayonHomePage);
                SProcParamArray[9] = new SqlParameter("@Featured ", Featured);
                SProcParamArray[10] = new SqlParameter("@New", New);
                SProcParamArray[11] = new SqlParameter("@TopSeller", TopSeller);
                SProcParamArray[12] = new SqlParameter("@Deffects", Deffects);
                SProcParamArray[13] = new SqlParameter("@DeffectNotes", DeffectNotes);
                SProcParamArray[14] = new SqlParameter("@Active", Active);
                SProcParamArray[15] = new SqlParameter("@Price", Price);

                if (ProductID > 0)
                {
                    //Update
                    SProcParamArray[16] = new SqlParameter("@ProductID", ProductID);
                    SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "product_update", SProcParamArray);
                }
                else
                {
                    //Add New
                    SProcParamArray[16] = new SqlParameter("@CreatedDateTime", CreatedDateTime);
                    ProductID = Convert.ToInt32(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "Product_insert", SProcParamArray));
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
            SqlParameter[] SProcParamArray = new SqlParameter[7];
            SProcParamArray[0] = new SqlParameter("@ProductID", ProductID);
            SProcParamArray[1] = new SqlParameter("@WreckID", WreckID);
            SProcParamArray[2] = new SqlParameter("@PartID", PartID);
            SProcParamArray[3] = new SqlParameter("@WreckNo", Wreck.WreckNo);
            SProcParamArray[4] = new SqlParameter("@Part", Part.Part);
            SProcParamArray[5] = new SqlParameter("@Status", Status);            
            SProcParamArray[6] = new SqlParameter("@Usage", Usage);        
            
            DataSet SqlHelperDataset = default(DataSet);
            SqlHelperDataset = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Product_Get", SProcParamArray);
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