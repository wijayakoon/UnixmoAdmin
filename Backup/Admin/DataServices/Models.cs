using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Neemo.Admin.DataServices
{
    public class Models : LookupCommon
    {        
        private int _ModelID;        
        private string _Model;

        public int ModelID { get { return _ModelID; } set { _ModelID = value; } }
        public string Model { get { return _Model; } set { _Model = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@ModelID", 0);
            sqlCmd.Parameters.AddWithValue("@Model", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "Model_Get", "Model", "ModelID", drp);
        
        }

        public void PopulateByName(DropDownList drp, string searchstring)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@ModelID", 0);
            sqlCmd.Parameters.AddWithValue("@Model", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "Model_Get", "Model", "ModelID", drp);

        }
    }
}