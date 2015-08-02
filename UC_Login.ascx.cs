using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Neemo.SupportClasses;
using System.Configuration;

namespace NeemoAdmin
{
    public partial class UC_Login : System.Web.UI.UserControl
    {
        private String strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Loggedin"] = "0";
            }

        }


        protected void IsValidatedUser(string email, string password)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GetRegistrationID";

                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = email;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 20).Value = password;

                        int _registrationID = 0;
                        //_registrationID = (int)cmd.ExecuteScalar();


                        SqlDataReader reader = cmd.ExecuteReader();
                        DataSet ds = new DataSet();
                        DataTable dt = ds.Tables.Add();
                        int _registrationid = 0;
                        while (reader.Read())
                        {
                            RegistrationDetails rd = new RegistrationDetails();

                            _registrationid = int.Parse(reader["registrationid"].ToString());
                            rd.LastName = reader["lastname"].ToString();
                            rd.Shipping_LastName = reader["lastname"].ToString();
                            rd.FirstName = reader["firstname"].ToString();
                            rd.Shipping_FirstName = reader["firstname"].ToString();
                            rd.CompanyName = reader["companyname"].ToString();
                            rd.Shipping_CompanyName = reader["companyname"].ToString();
                            rd.Tel = reader["phone"].ToString();
                            rd.Shipping_Tel = reader["phone"].ToString();
                            rd.Mobile = reader["mobile"].ToString();
                            rd.Shipping_Mobile = reader["mobile"].ToString();
                            rd.Fax = reader["fax"].ToString();
                            rd.Shipping_Fax = reader["fax"].ToString();
                            rd.Email = reader["emailaddress"].ToString();
                            rd.Shipping_Email = reader["emailaddress"].ToString();

                            rd.Address = reader["Address"].ToString();
                            rd.Shipping_Address = reader["Address"].ToString();
                            rd.City = reader["City"].ToString();
                            rd.Shipping_City = reader["City"].ToString();
                            rd.State = reader["State"].ToString();
                            rd.Shipping_State = reader["State"].ToString();
                            rd.PostCode = reader["PostCode"].ToString();
                            rd.Shipping_PostCode = reader["PostCode"].ToString();
                            rd.CountryCode = (reader["CountryCode"].ToString());
                            rd.Shipping_CountryCode = (reader["Shipping_CountryCode"].ToString());
                            rd.URL = reader["Url"].ToString();
                            rd.AdminUser = (bool)(reader["AdminUser"]);
                            rd.UserName = (reader["UserName"].ToString());
                            Session["RegistrationDetails"] = rd;

                            Session["RegistrationDetails"] = rd;
                            Session["_registrationid"] = (reader["registrationid"].ToString());
                            Session["lastname"] = reader["lastname"].ToString();
                            Session["firstname"] = reader["firstname"].ToString();
                            Session["phone"] = reader["phone"].ToString();
                            Session["mobile"] = reader["mobile"].ToString();
                            Session["emailAddress"] = reader["emailaddress"].ToString();
                            Session["postcode"] = reader["postcode"].ToString();
                            Session["Loggedin"] = "1";
                            Session["AdminUser"] = false;
                            if (rd.AdminUser == true)
                            {
                                Session["AdminUser"] = true;                                
                            }
                            else
                            {
                                Session["AdminUser"] = false;                            
                            }
                            
                        }
                        reader.Close();
                        con.Close();

                        if (_registrationid == 0)
                        {
                            lbl_Warning.Text = "Invalid Login attempt";
                        }
                        else
                        {
                            lbl_Warning.Text = "";
                            if (Session["LastPage"] == null)
                            {
                                Response.Redirect("~/Default.aspx");
                            }


                            Session["_registrationid"] = _registrationid.ToString();
                            Response.Redirect(Session["LastPage"].ToString());
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                // Log errors
                lbl_Warning.Visible = true;
            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            IsValidatedUser(txt_Email.Text, txt_Password.Text);
        }
    }
}