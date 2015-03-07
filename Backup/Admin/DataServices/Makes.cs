using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Neemo.Admin.DataServices
{
    public class Makes : LookupCommon
    {        
        private int _MakeID;        
        private string _Make;

        public int MakeID { get { return _MakeID; } set { _MakeID = value; } }
        public string Make { get { return _Make; } set { _Make = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@MakeID", 0);
            sqlCmd.Parameters.AddWithValue("@Make", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "Make_Get", "Make", "MakeID", drp);
        
        }


         public void PopulateByName(DropDownList drp,string searchstring )
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@MakeID", 0);
            sqlCmd.Parameters.AddWithValue("@Make", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "Make_Get", "Make", "MakeID", drp);

        }
        
    }
}