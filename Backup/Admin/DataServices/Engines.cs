using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Neemo.Admin.DataServices
{
    public class Engines : LookupCommon
    {
        private int _EngineID;
        private string _EngineNo;

        public int EngineID { get { return _EngineID; } set { _EngineID = value; } }
        public string EngineNo { get { return _EngineNo; } set { _EngineNo = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@EngineID", 0);
            sqlCmd.Parameters.AddWithValue("@EngineNo", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "Engine_Get", "EngineNo", "EngineID", drp);
        }

        public void PopulateByName(DropDownList drp, string searchstring)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@EngineID", 0);
            sqlCmd.Parameters.AddWithValue("@EngineNo", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "Engine_Get", "Engine", "EngineID", drp);

        }
    }
}