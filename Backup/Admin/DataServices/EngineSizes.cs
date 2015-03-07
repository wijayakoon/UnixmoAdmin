using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Neemo.Admin.DataServices
{
    public class EngineSizes : LookupCommon
    {        
        private int _EngineSizeID;        
        private string _EngineSize;

        public int EngineSizeID { get { return _EngineSizeID; } set { _EngineSizeID = value; } }
        public string EngineSize { get { return _EngineSize; } set { _EngineSize = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@EngineSizeID", 0);
            sqlCmd.Parameters.AddWithValue("@EngineSize", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "EngineSize_Get", "EngineSize", "EngineSizeID", drp);
        
        }

        public void PopulateByName(DropDownList drp, string searchstring)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@EngineSizeID", 0);
            sqlCmd.Parameters.AddWithValue("@EngineSize", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "EngineSize_Get", "EngineSize", "EngineSizeID", drp);

        }
        
        
    }
}