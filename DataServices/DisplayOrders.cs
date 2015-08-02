using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace NeemoAdmin.DataServices
{
    public class DisplayOrders : LookupCommon
    {        
        private int _DisplayOrderID;        
        private string _DisplayOrder;

        public int DisplayOrderID { get { return _DisplayOrderID; } set { _DisplayOrderID = value; } }
        public string DisplayOrder { get { return _DisplayOrder; } set { _DisplayOrder = value; } }

        public void PopulateDllAll(DropDownList drp)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@DisplayOrderID", 0);
            sqlCmd.Parameters.AddWithValue("@DisplayOrder", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
            PopulateDll(sqlCmd, "DisplayOrder_Get", "DisplayOrder", "DisplayOrderID", drp);
        
        }


         public void PopulateByName(DropDownList drp,string searchstring )
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.AddWithValue("@DisplayOrderID", 0);
            sqlCmd.Parameters.AddWithValue("@DisplayOrder", searchstring);
            sqlCmd.Parameters.AddWithValue("@Status", "Active");
            sqlCmd.Parameters.AddWithValue("@Usage", "SearchByName");
            PopulateDll(sqlCmd, "DisplayOrder_Get", "DisplayOrder", "DisplayOrderID", drp);

        }

         public void PopulateByID(DropDownList drp)
         {
             SqlCommand sqlCmd = new SqlCommand();
             sqlCmd.Parameters.AddWithValue("@DisplayOrderID", DisplayOrderID);
             sqlCmd.Parameters.AddWithValue("@DisplayOrder", DBNull.Value);
             sqlCmd.Parameters.AddWithValue("@Status", "Active");
             sqlCmd.Parameters.AddWithValue("@Usage", "PopulateDDL");
             PopulateDll(sqlCmd, "DisplayOrder_Get", "DisplayOrder", "DisplayOrderID", drp);

         }
    }
}