using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;

namespace NeemoAdmin.DataServices
{
    public class Makes : LookupCommon
    {
        static string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnection);
        
        private int _ProviderID;
        private int _MakeID;        
        private string _Make;

        public int ProviderID { get { return _ProviderID; } set { _ProviderID = value; } }
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

         public DataSet FindDetails()
         {
             SqlParameter[] SProcParamArray = new SqlParameter[10];
             SProcParamArray[0] = new SqlParameter("@MakeID", MakeID);
             SProcParamArray[1] = new SqlParameter("@Make", Make);
             SProcParamArray[2] = new SqlParameter("@ProviderID", ProviderID);

             DataSet SqlHelperDataset = default(DataSet);
             SqlHelperDataset = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_getProviderMakes", SProcParamArray);
             return SqlHelperDataset;
         }
        
    }
}