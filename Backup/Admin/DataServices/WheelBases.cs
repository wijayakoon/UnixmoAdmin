using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Neemo.Admin.DataServices
{
    public class WheelBases : LookupCommon
    {        
        private int _WheelBaseID;        
        private string _WheelBase;

        public int WheelBaseID { get { return _WheelBaseID; } set { _WheelBaseID = value; } }
        public string WheelBase { get { return _WheelBase; } set { _WheelBase = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@WheelBaseID", 0);
            sqlCmd.Parameters.AddWithValue("@WheelBase", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "WheelBase_Get", "WheelBase", "WheelBaseID", drp);
        
        }

        public void PopulateByName(DropDownList drp, string searchstring)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@WheelBaseID", 0);
            sqlCmd.Parameters.AddWithValue("@WheelBase", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "WheelBase_Get", "WheelBase", "WheelBaseID", drp);

        }
        
    }
}