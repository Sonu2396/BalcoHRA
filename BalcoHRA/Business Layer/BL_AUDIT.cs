using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BalcoHRA.Business_Layer;
using BalcoHRA.Business_Layer.UserMgt;

namespace BalcoHRA.Business_Layer
{
    public class BL_AUDIT
        {

        FPManager cn = new FPManager();

        public DataTable Bind_Plan(string USERID)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_BIND_CHEKCLIST_PENDING_ENTRY"
                , new string[] { "@USERID" }
                , new string[] { USERID });
            return dt;

        }

        public DataTable DropDownlist_Checklist(string TransID)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_BIND_ACTIVITY_LIST"
                , new string[] { "@TID" }
                , new string[] { TransID });
            return dt; 
        }
        
        public DataTable Bind_Checklist(string chk)
        {
            DataTable dt = new DataTable();
            string SqlQuery = "";
            if(chk== "Work At Height")
            {
                SqlQuery=" select * from MST_WAH ";
            }
            else if (chk == "Confined Space")
            {
                SqlQuery = " select * from MST_CONFINED_SPACE ";
            }
            else if (chk == "Critical Lift")
            {
                SqlQuery = " select * from MST_CRITICAL_LIFT ";
            }
            else if (chk == "Excavation")
            {
                SqlQuery = " select * from MST_EXCAVATION ";
            }
            else if (chk == "Isolation")
            {
                SqlQuery = " select * from MST_ISO ";
            }
            else
            {
                SqlQuery = "select * from MST_VPI";
            }
            dt = cn.GetDataTable(SqlQuery);
            return dt;

        }

        public bool Data_Save(string TransactionID, string Checklist, string CriticalControl, string Objective, string Points, string Score, string Remarks, string userid, string Entrystatus)
        {
            bool Result =false;
            Result = cn.ExecuteQuerySP("SP_TRANSACTION_AUDIT"
                , new string[] { "@TransactionID", "@Checklist", "@CriticalControl", "@Objective", "@Points", "@Score", "@Remarks", "@EntryBy", "@ENTRYSTATUS" }
                , new string[] { TransactionID, Checklist, CriticalControl, Objective, Points, Score, Remarks, userid, Entrystatus });
            return Result;
        }

        public string Job_Submit_Forcedclose(String TransID, string userid, string Forcedclose, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_TRANSACTION_JOB"
                , new string[] { "@TransID", "@ApprovedBy", "@Forcedclose", "@ApprovalTime", "@ENTRYSTATUS" }
                , new string[] { TransID, userid, Forcedclose, DateTime.Now.ToString(), Entrystatus });
            return Result;
        }

        //public string Chk_mark(String TransID, string userid, string mark, string Entrystatus)
        //{
        //    string Result = "";
        //    Result = cn.ExecuteQuerySP_Retrun_String("SP_TRANSACTION_AUDIT"
        //        , new string[] { "@TransID", "@ModifiedBy", "@WAH", "@ModificationDateTime", "@ENTRYSTATUS" }
        //        , new string[] { TransID, userid, mark, DateTime.Now.ToString(), Entrystatus });
        //    return Result;
        //}

        //public string Chk_mark2(String ActivityID, string userid, string check, string Entrystatus)
        //{
        //    string Result = "";
        //    Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_ACTIVITY"
        //        , new string[] { "@ActivityID", "@ModifiedBy", "@isChecked", "@ModificationDate", "@ENTRYSTATUS" }
        //        , new string[] { ActivityID, userid, check, DateTime.Now.ToString(), Entrystatus });
        //    return Result;
        //}


    }

}