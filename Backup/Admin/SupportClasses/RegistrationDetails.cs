using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neemo.SupportClasses
{
    public class RegistrationDetails
    {
        private string _firstName = string.Empty;
        private string _shipping_firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _shipping_lastName = string.Empty;
        private string _companyName = string.Empty;
        private string _shipping_companyName = string.Empty;

        private string _address = string.Empty;
        private string _shipping_address = string.Empty;
        private string _city = string.Empty;
        private string _shipping_city = string.Empty;
        private string _state = string.Empty;
        private string _shipping_state = string.Empty;
        private string _postCode = string.Empty;
        private string _shipping_postCode = string.Empty;
        private string _countryCode = string.Empty;
        private string _shipping_countryCode = string.Empty;

        private string _mobile = string.Empty;
        private string _shipping_mobile = string.Empty;
        private string _tel = string.Empty;
        private string _shipping_tel = string.Empty;
        private string _fax = string.Empty;
        private string _shipping_fax = string.Empty;
        private string _email = string.Empty;
        private string _shipping_email = string.Empty;
        private string _url = string.Empty;
        private bool _termsAccepted = false;
        private bool _admiUser = false;
        private string _userName = string.Empty;
        
      
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string Shipping_FirstName { get { return _shipping_firstName; } set { _shipping_firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string Shipping_LastName { get { return _shipping_lastName; } set { _shipping_lastName = value; } }
        public string CompanyName { get { return _companyName; } set { _companyName = value; } }
        public string Shipping_CompanyName { get { return _shipping_companyName; } set { _shipping_companyName = value; } }

        public string Address { get { return _address; } set { _address = value; } }
        public string Shipping_Address { get { return _shipping_address; } set { _shipping_address = value; } }
        public string City { get { return _city; } set { _city = value; } }
        public string Shipping_City { get { return _shipping_city; } set { _shipping_city = value; } }
        public string State { get { return _state; } set { _state = value; } }
        public string Shipping_State { get { return _shipping_state; } set { _shipping_state = value; } }
        public string PostCode { get { return _postCode; } set { _postCode = value; } }
        public string Shipping_PostCode { get { return _shipping_postCode; } set { _shipping_postCode = value; } }
        public string CountryCode { get { return _countryCode; } set { _countryCode = value; } }
        public string Shipping_CountryCode { get { return _shipping_countryCode; } set { _shipping_countryCode = value; } }

        public string Mobile { get { return _mobile; } set { _mobile = value; } }
        public string Shipping_Mobile { get { return _shipping_mobile; } set { _shipping_mobile = value; } }
        public string Tel { get { return _tel; } set { _tel = value; } }
        public string Shipping_Tel { get { return _shipping_tel; } set { _shipping_tel = value; } }
        public string Fax { get { return _fax; } set { _fax = value; } }
        public string Shipping_Fax { get { return _shipping_fax; } set { _shipping_fax = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Shipping_Email { get { return _shipping_email; } set { _shipping_email = value; } }

        public string URL { get { return _url; } set { _url = value; } }
        public bool TermsAccepted { get { return _termsAccepted; } set { _termsAccepted = value; } }
        public bool AdminUser { get { return _admiUser; } set { _admiUser = value; } }
        public string UserName { get { return _userName; } set { _userName = value; } }
       

    }

}