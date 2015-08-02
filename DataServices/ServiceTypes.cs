using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace NeemoAdmin.DataServices
{
    public class ServiceTypes : LookupCommon
    {        
        private int _ServiceTypeID;        
        private string _ServiceType;

        public int ServiceTypeID { get { return _ServiceTypeID; } set { _ServiceTypeID = value; } }
        public string ServiceType { get { return _ServiceType; } set { _ServiceType = value; } }

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
    }
}