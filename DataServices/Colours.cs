using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace NeemoAdmin.DataServices
{
    public class Colours : LookupCommon
    {        
        private int _ColourID;        
        private string _Colour;

        public int ColourID { get { return _ColourID; } set { _ColourID = value; } }
        public string Colour { get { return _Colour; } set { _Colour = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@ColourID", 0);
            sqlCmd.Parameters.AddWithValue("@Colour", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "Colour_Get", "Colour", "ColourID", drp);
        
        }


         public void PopulateByName(DropDownList drp,string searchstring )
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@ColourID", 0);
            sqlCmd.Parameters.AddWithValue("@Colour", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "Colour_Get", "Colour", "ColourID", drp);

        }

         public void PopulateByID(DropDownList drp)
         {
             SqlCommand sqlCmd = new SqlCommand();
             sqlCmd.Parameters.AddWithValue("@ColourID", ColourID);
             sqlCmd.Parameters.AddWithValue("@Colour", DBNull.Value);
             sqlCmd.Parameters.AddWithValue("@Status", "Active");
             sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
             PopulateDll(sqlCmd, "Colour_Get", "Colour", "ColourID", drp);

         }
    }
}