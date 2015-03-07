using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Neemo.SupportClasses
{
    public class DbHandle
    {
        public SqlConnection cn = new SqlConnection();

        public void OpenConn()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            if (cn.State != ConnectionState.Open)
            {
                cn.ConnectionString = strConnString;
                
                    if (cn.State == ConnectionState.Closed)
                    {
                        { cn.Open(); }
                    }
                   
            }
        }
    }
}
