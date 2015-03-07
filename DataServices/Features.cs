using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace NeemoAdmin.DataServices
{
    public class Features : LookupCommon
    {
        private int _FeatureID;
        private string _Feature;

        public int FeatureID { get { return _FeatureID; } set { _FeatureID = value; } }
        public string Feature { get { return _Feature; } set { _Feature = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@FeatureID", 0);
            sqlCmd.Parameters.AddWithValue("@Feature", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "Feature_Get", "Feature", "FeatureID", drp);
        }

        public void PopulateByName(DropDownList drp, string searchstring)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@FeatureID", 0);
            sqlCmd.Parameters.AddWithValue("@Feature", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "Feature_Get", "Feature", "FeatureID", drp);

        }
    }
}