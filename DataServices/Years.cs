using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace NeemoAdmin.DataServices
{
    public class Years : LookupCommon
    {        
        private int _YearID;        
        private string _Year;

        public int YearID { get { return _YearID; } set { _YearID = value; } }
        public string Year { get { return _Year; } set { _Year = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@YearID", 0);
            sqlCmd.Parameters.AddWithValue("@Year", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "Year_Get", "Year", "YearID", drp);
        
        }

        public void PopulateByName(DropDownList drp, string searchstring)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@YearID", 0);
            sqlCmd.Parameters.AddWithValue("@Year", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "Year_Get", "Year", "YearID", drp);

        }
        
    }
}