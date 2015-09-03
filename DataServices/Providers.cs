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
    public class Providers : LookupCommon
    {
        static string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnection);

        int _ProviderID;
        string _ProviderName="";
        string _Description = "";
        string _Keyword = "";
        string _FirstName = "";
        string _LastName = "";
        string _LevelNo = "";
        string _UnitNo = "";
        string _StreetNo = "";
        string _Street="";
        string _City = "";
        string _State = "";
        string _PostCode = "";
        string _Country = "";
        string _Longitude = "";
        string _Latitude = "";
        string _Mobile = "";
        string _Phone = "";
        string _Fax = "";
        string _EmailAddress = "";
        string _URL = "";
        
        string _ContactUsURL = "";
        int _DisplayOrderID = 0;
        string _Image = "";
        bool _Active = false;
        bool _DisplayonHomePage = false;
        DateTime _CreatedDateTime;
        string _CreatedByUser = "";
        DateTime _LastModifiedDateTime;
        string _LastModifiedByUser = "";
        ProviderTypes _ProviderType = new ProviderTypes();
        ServiceTypes _ServiceType = new ServiceTypes();
        
        //ImageListHeader _ProviderPhoto =new ImageListHeader ();

        public int ProviderID { get { return _ProviderID; } set { _ProviderID = value; } }
        public string ProviderName { get { return _ProviderName; } set { _ProviderName = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        public string Keyword { get { return _Keyword; } set { _Keyword = value; } }
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        public string LevelNo { get { return _LevelNo; } set { _LevelNo = value; } }
        public string UnitNo { get { return _UnitNo; } set { _UnitNo = value; } }
        public string StreetNo { get { return _StreetNo; } set { _StreetNo = value; } }
        public string Street { get { return _Street; } set { _Street = value; } }
        public string City { get { return _City; } set { _City = value; } }
        public string State { get { return _State; } set { _State = value; } }
        public string PostCode { get { return _PostCode; } set { _PostCode = value; } }
        public string Country { get { return _Country; } set { _Country = value; } }
        public string Longitude { get { return _Longitude; } set { _Longitude = value; } }
        public string Latitude { get { return _Latitude; } set { _Latitude = value; } }
        public string Mobile { get { return _Mobile; } set { _Mobile = value; } }
        public string Phone { get { return _Phone; } set { _Phone = value; } }
        public string Fax { get { return _Fax; } set { _Fax = value; } }
        public string EmailAddress { get { return _EmailAddress; } set { _EmailAddress = value; } }
        public string URL { get { return _URL; } set { _URL = value; } }
        
        public string ContactUsURL { get { return _ContactUsURL; } set { _ContactUsURL = value; } }
        public int DisplayOrderID { get { return _DisplayOrderID; } set { _DisplayOrderID = value; } }
        public string Image { get { return _Image; } set { _Image = value; } }
        public bool Active { get { return _Active; } set { _Active = value; } }
        public bool DisplayonHomePage { get { return _DisplayonHomePage; } set { _DisplayonHomePage = value; } }
        public DateTime CreatedDateTime { get { return _CreatedDateTime; } set { _CreatedDateTime = value; } }
        public string CratedByUser { get { return _CreatedByUser; } set { _CreatedByUser = value; } }
        public DateTime LastModifiedDateTime { get { return _LastModifiedDateTime; } set { _LastModifiedDateTime = value; } }
        public string LastModifiedByUser { get { return _LastModifiedByUser; } set { _LastModifiedByUser = value; } }
        public ProviderTypes ProviderType { get { return _ProviderType; } set { _ProviderType = value; } }
        public ServiceTypes ServiceType { get { return _ServiceType; } set { _ServiceType = value; } }

       
        
        
        
        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@ProviderID", 0);
            sqlCmd.Parameters.AddWithValue("@Provider", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "Provider_Get", "Provider", "ProviderID", drp);
        }

        public void PopulateByName(DropDownList drp, string searchstring)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@ProviderID", 0);
            sqlCmd.Parameters.AddWithValue("@Provider", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "Provider_Get", "Provider", "ProviderID", drp);

        }

        public Providers() 
        {
            
        }

        public bool Save()
        {
            SqlParameter[] SProcParamArray = new SqlParameter[30];
            bool DidSucceed = false;

            try
            {
                SProcParamArray[0] = new SqlParameter("@ProviderName", _ProviderName);
                SProcParamArray[1] = new SqlParameter("@Description", _Description);
                SProcParamArray[2] = new SqlParameter("@Keyword", _Description);
                SProcParamArray[3] = new SqlParameter("@FirstName", _FirstName);
                SProcParamArray[4] = new SqlParameter("@LastName", _LastName);
                SProcParamArray[5] = new SqlParameter("@LevelNo",_LevelNo);
                SProcParamArray[6] = new SqlParameter("@UnitNo", _UnitNo);
                SProcParamArray[7] = new SqlParameter("@StreetNo", StreetNo);
                SProcParamArray[8] = new SqlParameter("@Street", _Street);
                SProcParamArray[9] = new SqlParameter("@City", _City);
                SProcParamArray[10] = new SqlParameter("@State", _State);
                SProcParamArray[11] = new SqlParameter("@PostCode", _PostCode);
                SProcParamArray[12] = new SqlParameter("@Country", _Country);
                SProcParamArray[13] = new SqlParameter("@Longitude", _Latitude);
                SProcParamArray[14] = new SqlParameter("@Latitude", _Longitude);
                SProcParamArray[15] = new SqlParameter("@Mobile", _Mobile);
                SProcParamArray[16] = new SqlParameter("@Phone", Phone);
                SProcParamArray[17] = new SqlParameter("@Fax", _Fax);
                SProcParamArray[18] = new SqlParameter("@EmailAddress", _EmailAddress);
                SProcParamArray[19] = new SqlParameter("@URL", _URL);
                SProcParamArray[20] = new SqlParameter("@Rating", 0);
                SProcParamArray[21] = new SqlParameter("@ContactUsURL", _ContactUsURL);
                SProcParamArray[22] = new SqlParameter("@DisplayOrderID", 0);
                SProcParamArray[23] = new SqlParameter("@Image", _Image);
                SProcParamArray[24] = new SqlParameter("@Active", _Active);
                SProcParamArray[25] = new SqlParameter("@DisplayonHomePage", _DisplayonHomePage);


                if (_ProviderID > 0)
                {
                    //Update
                    SProcParamArray[26] = new SqlParameter("@ProviderID", _ProviderID);
                    SProcParamArray[27] = new SqlParameter("@LastModifiedByUser", LastModifiedByUser);
                    SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Provider_update", SProcParamArray);

                }
                else
                {
                    //Add New                    
                    SProcParamArray[26] = new SqlParameter("@CreatedByUser", CreatedByUser);
                    _ProviderID = Convert.ToInt32(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "Provider_insert", SProcParamArray));
                }
                DidSucceed = true;
            }
            catch (Exception ex)
            {
                DidSucceed = false;
            }

            return DidSucceed;
        }



        public DataSet FindDetails()
        {
            SqlParameter[] SProcParamArray = new SqlParameter[10];
            SProcParamArray[0] = new SqlParameter("@ProviderID", _ProviderID);
            SProcParamArray[1] = new SqlParameter("@ProviderTypeID", _ProviderType.ProviderTypeID);
            SProcParamArray[2] = new SqlParameter("@ServiceTypeID", _ServiceType.ServiceTypeID);
            SProcParamArray[3] = new SqlParameter("@ProviderName", _ProviderName);
            SProcParamArray[4] = new SqlParameter("@Street", _Street);
            SProcParamArray[5] = new SqlParameter("@City", _City);
            SProcParamArray[6] = new SqlParameter("@State", _State);
            //SProcParamArray[1] = new SqlParameter("@Status", Status);
            //SProcParamArray[2] = new SqlParameter("@ProviderID", ProviderID);
            //SProcParamArray[3] = new SqlParameter("@Usage", Usage);        
            
            DataSet SqlHelperDataset = default(DataSet);
            SqlHelperDataset = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_searchProvider_All", SProcParamArray);
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
                    ProviderName = (dr["ProviderName"].ToString()) == null ? "" : dr["ProviderName"].ToString();
                    Description = (dr["Description"].ToString()) == null ? "" : dr["Description"].ToString();
                    Keyword = (dr["Keyword"].ToString()) == null ? "" : dr["Keyword"].ToString();
                    FirstName = (dr["FirstName"].ToString()) == null ? "" : dr["FirstName"].ToString();
                    LastName = (dr["LastName"].ToString()) == null ? "" : dr["LastName"].ToString();
                    LevelNo = (dr["LevelNo"].ToString()) == null ? "" : dr["LevelNo"].ToString();
                    UnitNo = (dr["UnitNo"].ToString()) == null ? "" : dr["UnitNo"].ToString();
                    StreetNo = (dr["StreetNo"].ToString()) == null ? "" : dr["StreetNo"].ToString();
                    Street = (dr["Street"].ToString()) == null ? "" : dr["Street"].ToString();
                    City = (dr["City"].ToString()) == null ? "" : dr["City"].ToString();
                    State = (dr["State"].ToString()) == null ? "" : dr["State"].ToString();
                    PostCode = (dr["PostCode"].ToString()) == null ? "" : dr["PostCode"].ToString();
                    Country = (dr["Country"].ToString()) == null ? "" : dr["Country"].ToString();
                    Longitude = (dr["Longitude"].ToString()) == null ? "" : dr["Longitude"].ToString();
                    Latitude = (dr["Latitude"].ToString()) == null ? "" : dr["Latitude"].ToString();
                    Mobile = (dr["Mobile"].ToString()) == null ? "" : dr["Mobile"].ToString();
                    Phone = (dr["Phone"].ToString()) == null ? "" : dr["Phone"].ToString();
                    Fax = (dr["Fax"].ToString()) == null ? "" : dr["Fax"].ToString();
                    EmailAddress = (dr["EmailAddress"].ToString()) == null ? "" : dr["EmailAddress"].ToString();
                    URL = (dr["URL"].ToString()) == null ? "" : dr["URL"].ToString();
                    //Rating = Convert.ToInt16(dr["_Rating"].ToString() == null ? "0" : dr["_Rating"].ToString());
                    ContactUsURL = (dr["ContactUsURL"].ToString()) == null ? "" : dr["ContactUsURL"].ToString();
                    //DisplayOrderID= Convert.ToInt16(dr["DisplayOrderID"].ToString() == null ? "0" : dr["DisplayOrderID"].ToString());
                    Image = (dr["Image"].ToString()) == null ? "" : dr["Image"].ToString();
                    Active = Convert.ToBoolean(dr["Active"].ToString() == null ? "false" : dr["Active"].ToString());
                    DisplayonHomePage = Convert.ToBoolean(dr["DisplayonHomePage"].ToString() == null ? "false" : dr["DisplayonHomePage"].ToString());
                    
                   

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