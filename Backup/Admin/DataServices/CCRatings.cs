using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Neemo.Admin.DataServices
{
    public class CCRatings : LookupCommon
    {        
        private int _CCRatingID;        
        private string _CCRating;

        public int CCRatingID { get { return _CCRatingID; } set { _CCRatingID = value; } }
        public string CCRating { get { return _CCRating; } set { _CCRating = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@CCRatingID", 0);
            sqlCmd.Parameters.AddWithValue("@CCRating", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "CCRating_Get", "CCRating", "CCRatingID", drp);
        
        }

        public void PopulateByName(DropDownList drp, string searchstring)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@CCRatingID", 0);
            sqlCmd.Parameters.AddWithValue("@CCRating", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "CCRating_Get", "CCRating", "CCRatingID", drp);

        }
    }
}