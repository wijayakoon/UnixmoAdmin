using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace NeemoAdmin.DataServices
{
    public class ProviderTypes : LookupCommon
    {        
        private int _ProviderTypeID;        
        private string _ProviderType;

        public int ProviderTypeID { get { return _ProviderTypeID; } set { _ProviderTypeID = value; } }
        public string ProviderType { get { return _ProviderType; } set { _ProviderType = value; } }

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
    }
}