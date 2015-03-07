using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace NeemoAdmin.DataServices
{
    public class FuelTypes : LookupCommon
    {        
        private int _FuelTypeID;        
        private string _FuelType;

        public int FuelTypeID { get { return _FuelTypeID; } set { _FuelTypeID = value; } }
        public string FuelType { get { return _FuelType; } set { _FuelType = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@FuelTypeID", 0);
            sqlCmd.Parameters.AddWithValue("@FuelType", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "FuelType_Get", "FuelType", "FuelTypeID", drp);
        
        }

        public void PopulateByName(DropDownList drp, string searchstring)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@FuelTypeID", 0);
            sqlCmd.Parameters.AddWithValue("@FuelType", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "FuelType_Get", "FuelType", "FuelTypeID", drp);

        }
        
    }
}