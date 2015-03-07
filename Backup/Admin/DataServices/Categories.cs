using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Neemo.Admin.DataServices
{
    public class Categories : LookupCommon
    {        
        private int _CategoryID;        
        private string _Category;

        public int CategoryID { get { return _CategoryID; } set { _CategoryID = value; } }
        public string Category { get { return _Category; } set { _Category = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@CategoryID", 0);
            sqlCmd.Parameters.AddWithValue("@Category", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "Category_Get", "Category", "CategoryID", drp);
        
        }


         public void PopulateByName(DropDownList drp,string searchstring )
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@CategoryID", 0);
            sqlCmd.Parameters.AddWithValue("@Category", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "Category_Get", "Category", "CategoryID", drp);

        }
        
    }
}