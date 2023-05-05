using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BalcoHRA.Business_Layer;
using BalcoHRA.Business_Layer.UserMgt;

namespace BalcoHRA.Business_Layer
{
    public class BL_Report
    {

        FPManager cn = new FPManager();

        //public string Bind_Report(string fromDate, string toDate)
        //{
            
        //    string dt = "";
        //    dt = cn.ExecuteQuerySP_Retrun_String("SP_REPORT_DAYWISE"
        //        , new string[] { "@fromDate", "@toDate" }
        //        , new string[] { fromDate, toDate });
        //    return dt;

        //}

        public DataTable Bind_Report(string fromDate, string toDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from [TRANSACTION_JOB] J right join [TRANSACTION_AUDIT] A on J.TransID = A.TransactionID where J.JobDateTime >= '"+fromDate+"' and J.JobDateTime <= '"+toDate+"' order by J.TransID desc");
            return dt;

        }

       
        public DataTable Bind_Compliance_Report(string fromDate, string toDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_REPORT_COMPLIANCE_SUMMARY"
                , new string[] { "@sdate", "@edate" }
                , new string[] { fromDate, toDate });
            return dt;
        }


    }
}
