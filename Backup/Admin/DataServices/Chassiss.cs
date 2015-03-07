using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Neemo.Admin.DataServices
{
    public class Chassiss : LookupCommon
    {
        private int _ChassisID;        
        private string _ChassisNo;

        public int ChassisID { get { return _ChassisID; } set { _ChassisID = value; } }
        public string ChassisNo { get { return _ChassisNo; } set { _ChassisNo = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@ChassisID", 0);
            sqlCmd.Parameters.AddWithValue("@ChassisNo", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "Chassis_Get", "ChassisNo", "ChassisID", drp);        
        }

        public void PopulateByName(DropDownList drp, string searchstring)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@ChassisID", 0);
            sqlCmd.Parameters.AddWithValue("@ChassisNo", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "Chassis_Get", "Chassis", "ChassisID", drp);
        }
        
    }
}