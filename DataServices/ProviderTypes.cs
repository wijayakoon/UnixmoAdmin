using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;

namespace NeemoAdmin.DataServices
{
    public class ProviderTypes : LookupCommon
    {
        static string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnection);
        
        private int _ProviderTypeID=0;        
        private string _ProviderType="";
        private int _ProviderID=0;        

        public int ProviderTypeID { get { return _ProviderTypeID; } set { _ProviderTypeID = value; } }
        public string ProviderType { get { return _ProviderType; } set { _ProviderType = value; } }
        public int ProviderID { get { return _ProviderID; } set { _ProviderID = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@ProviderTypeID", 0);
            sqlCmd.Parameters.AddWithValue("@ProviderType", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "ProviderType_Get", "ProviderType", "ProviderTypeID", drp);
        
        }


         public void PopulateByName(DropDownList drp,string searchstring )
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@ProviderTypeID", 0);
            sqlCmd.Parameters.AddWithValue("@ProviderType", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "ProviderType_Get", "ProviderType", "ProviderTypeID", drp);

        }

         public void PopulateByID(DropDownList drp)
         {
             SqlCommand sqlCmd = new SqlCommand();
             sqlCmd.Parameters.AddWithValue("@ProviderTypeID", ProviderTypeID);
             sqlCmd.Parameters.AddWithValue("@ProviderType", DBNull.Value);
             sqlCmd.Parameters.AddWithValue("@Status", "Active");
             sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
             PopulateDll(sqlCmd, "ProviderType_Get", "ProviderType", "ProviderTypeID", drp);

         }

         public DataSet FindDetails()
         {
             SqlParameter[] SProcParamArray = new SqlParameter[10];
             SProcParamArray[0] = new SqlParameter("@ProviderTypeID", ProviderTypeID);
             SProcParamArray[1] = new SqlParameter("@ProviderType", ProviderType);
             SProcParamArray[2] = new SqlParameter("@ProviderID", ProviderID);

             DataSet SqlHelperDataset = default(DataSet);
             SqlHelperDataset = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_getProviderProviderTypes", SProcParamArray);
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
                     
                     ProviderTypeID = Convert.ToInt16(dr["ProviderTypeID"].ToString() == null ? "0" : dr["ProviderTypeID"].ToString());
                     ProviderType = (dr["ProviderType"].ToString()) == null ? "" : dr["ProviderType"].ToString();
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