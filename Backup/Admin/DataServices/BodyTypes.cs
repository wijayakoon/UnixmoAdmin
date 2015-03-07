using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Neemo.Admin.DataServices
{
    public class BodyTypes : LookupCommon
    {        
        private int _BodyTypeID;        
        private string _BodyType;

        public int BodyTypeID { get { return _BodyTypeID; } set { _BodyTypeID = value; } }
        public string BodyType { get { return _BodyType; } set { _BodyType = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@BodyTypeID", 0);
            sqlCmd.Parameters.AddWithValue("@BodyType", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "BodyType_Get", "BodyType", "BodyTypeID", drp);
        
        }

        public void PopulateByName(DropDownList drp, string searchstring)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@BodyTypeID", 0);
            sqlCmd.Parameters.AddWithValue("@BodyType", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "BodyType_Get", "BodyType", "BodyTypeID", drp);

        }
    }
}