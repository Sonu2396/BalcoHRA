using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BalcoHRA.Business_Layer
{
    public class FlagStatusClass
    {
        public static int WAHFlag {get;set;}

        public static int StaticTransID { get; set; }
        public static int StaticAuditorID { get; set; }
        public static string CurrentWorkingTable { get; set; }
        public static int CSFlag { get; set; }
        public static int CLFlag { get; set; }
        public static int EXFlag { get; set; }
        public static int ISOFlag { get; set; }
        public static int VPIFlag { get; set; }

    }
}