using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace NeemoAdmin.DataServices
{
    public class Sides : LookupCommon
    {        
        private int _SideID;        
        private string _Side;

        public int SideID { get { return _SideID; } set { _SideID = value; } }
        public string Side { get { return _Side; } set { _Side = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@SideID", 0);
            sqlCmd.Parameters.AddWithValue("@Side", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "Side_Get", "Side", "SideID", drp);
        
        }


         public void PopulateByName(DropDownList drp,string searchstring )
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@SideID", 0);
            sqlCmd.Parameters.AddWithValue("@Side", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "Side_Get", "Side", "SideID", drp);

        }

         public void PopulateByID(DropDownList drp)
         {
             SqlCommand sqlCmd = new SqlCommand();
             sqlCmd.Parameters.AddWithValue("@SideID", SideID);
             sqlCmd.Parameters.AddWithValue("@Side", DBNull.Value);
             sqlCmd.Parameters.AddWithValue("@Status", "Active");
             sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
             PopulateDll(sqlCmd, "Side_Get", "Side", "SideID", drp);

         }
        
    }
}