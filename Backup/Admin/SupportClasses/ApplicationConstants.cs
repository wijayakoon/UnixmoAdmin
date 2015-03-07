using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;



namespace Neemo.Admin.SupportClasses
{
    public class ApplicationConstants
    {

        public class CURRENTTOKEN_WORKFLOW_STATUS
        {
            public const int REQUESTED = 1;
            public const int APPROVED = 2;
            public const int PROCCESSED = 3;
            public const int REJECTED = 4;
        }

        public class DEFAULT_DATES
        {
            //public const string  MIN = "1900-01-01 00:00:00";
            //public const string MAX = "2100-01-01  00:00:00";

            public const string MIN = "01-01-1900 00:00:00";
            public const string MAX = "01-01-2100  00:00:00";
            
        }
    }
}