using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;

namespace NeemoAdmin.DataServices
{
    public class ServiceTypes : LookupCommon
    {
        static string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnection); 
        
        private int _ServiceTypeID=0;        
        private string _ServiceType="";
        private int  _ProviderID =0;
        
        public int ServiceTypeID { get { return _ServiceTypeID; } set { _ServiceTypeID = value; } }
        public string ServiceType { get { return _ServiceType; } set { _ServiceType = value; } }
        public int ProviderID { get { return _ProviderID; } set { _ProviderID = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@ServiceTypeID", 0);
            sqlCmd.Parameters.AddWithValue("@ServiceType", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "ServiceType_Get", "ServiceType", "ServiceTypeID", drp);
        
        }


         public void PopulateByName(DropDownList drp,string searchstring )
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@ServiceTypeID", 0);
            sqlCmd.Parameters.AddWithValue("@ServiceType", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "ServiceType_Get", "ServiceType", "ServiceTypeID", drp);

        }

         public void PopulateByID(DropDownList drp)
         {
             SqlCommand sqlCmd = new SqlCommand();
             sqlCmd.Parameters.AddWithValue("@ServiceTypeID", ServiceTypeID);
             sqlCmd.Parameters.AddWithValue("@ServiceType", DBNull.Value);
             sqlCmd.Parameters.AddWithValue("@Status", "Active");
             sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
             PopulateDll(sqlCmd, "ServiceType_Get", "ServiceType", "ServiceTypeID", drp);

         }

         public DataSet FindDetails()
         {
             SqlParameter[] SProcParamArray = new SqlParameter[10];
             SProcParamArray[0] = new SqlParameter("@ServiceTypeID", ServiceTypeID);
             SProcParamArray[1] = new SqlParameter("@ServiceType", ServiceType);
             SProcParamArray[2] = new SqlParameter("@ProviderID", ProviderID);

             DataSet SqlHelperDataset = default(DataSet);
             SqlHelperDataset = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_getProviderServiceTypes", SProcParamArray);
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
                     
                     ServiceTypeID = Convert.ToInt16(dr["ServiceTypeID"].ToString() == null ? "0" : dr["ServiceTypeID"].ToString());
                     ServiceType = (dr["ServiceType"].ToString()) == null ? "" : dr["ServiceType"].ToString();
                     ProviderID = Convert.ToInt16((dr["ProviderID"].ToString()) == null ? "" : dr["ProviderID"].ToString());

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