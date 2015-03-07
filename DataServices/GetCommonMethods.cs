using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Neemo.SupportClasses;
using System.Data;
using System.Web.UI.WebControls;

namespace NeemoAdmin.DataServices
{
    public class GetCommonMethods
    {

        public void PopulateDll(SqlCommand sqlCmd, string commandText, string textField, string valueField, DropDownList drp)
        {
            DbHandle clsDBHandle = new DbHandle();
            clsDBHandle.OpenConn();
            sqlCmd.Connection = clsDBHandle.cn;
            sqlCmd.CommandText = commandText;                        
            sqlCmd.CommandType = CommandType.StoredProcedure;            
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            try
            {                
                da.Fill(ds);
                drp.DataTextField = textField;
                drp.DataValueField = valueField;
                drp.DataSource = ds.Tables[0];
                drp.DataBind();
                clsDBHandle.cn.Close();                
                
            }
            catch (Exception ex)
            {
                string error = ex.ToString();                
            }           

        }

    }
}