using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neemo.Admin.DataServices
{
    public class LookupCommon : GetCommonMethods
    {
        private string _Image;
        private bool _Active;
        private DateTime _CreatedDateTime;
        private string _CreatedByUser;
        private DateTime _LastModifiedDateTime;
        private string _LastModifiedByUser;
        private DateTime _DeletedDateTime;
        private string _DeletedByUser;
        private DateTime _EffectiveDateFrom;
        private DateTime _EffectiveDateTo;
        private string _Status ;
        private string _Usage;

        public string Image { get { return _Image; } set { _Image = value; } }
        public bool Active { get { return _Active; } set { _Active = value; } }
        public DateTime CreatedDateTime { get { return _CreatedDateTime; } set { _CreatedDateTime = value; } }
        public string CreatedByUser { get { return _CreatedByUser; } set { _CreatedByUser = value; } }
        public DateTime LastModifiedDateTime { get { return _LastModifiedDateTime; } set { _LastModifiedDateTime = value; } }
        public string LastModifiedByUser { get { return _LastModifiedByUser; } set { _LastModifiedByUser = value; } }
        public DateTime DeletedDateTime { get { return _DeletedDateTime; } set { _DeletedDateTime = value; } }
        public string DeletedByUser { get { return _DeletedByUser; } set { _DeletedByUser = value; } }
        public DateTime EffectiveDateFrom { get { return _EffectiveDateFrom; } set { _EffectiveDateFrom = value; } }
        public DateTime EffectiveDateTo { get { return _EffectiveDateTo; } set { _EffectiveDateTo = value; } }
        public string Status { get { return _Status; } set { _Status = value; } }
        public string Usage { get { return _Usage; } set { _Usage = value; } }
        

    }
}