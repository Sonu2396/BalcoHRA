using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BalcoHRA.Business_Layer;
namespace BalcoHRA.Business_Layer.UserMgt
{
    public class BL_JOB
    {
        FPManager cn = new FPManager();

        //public DataTable Get_DepartmentList()
        //{
        //    DataTable dt = new DataTable();
        //    dt = cn.GetDataTable("SP_TRANSACTION_JOB"
        //      , new string[] { "@ENTRYSTATUS" }
        //      , new string[] { "List" });
        //    return dt;
        //}

        public DataTable DropDownlist_SBU()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select *from MST_SBU");
            return dt;

        }
        public DataTable DropDownlist_AREA(string SBUName)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT DepartmentID, DepartmentName FROM  MST_AREA where SBUName='"+SBUName+"'  ORDER BY DepartmentID");
            return dt;

        }


        public DataTable DropDownlist_SUBArea()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select *from MST_SUB_AREA");
            return dt;

        }

        //public DataTable DropDownlist_Executor()
        //{
        //    DataTable dt = new DataTable();
        //    dt = cn.GetDataTable("select LOGINID, USERNAME from MST_USERS where ROLEID LIKE '%6%'  ");
        //    return dt;

        //}

        public DataTable DropDownlist_Auditor()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select LOGINID, USERNAME from MST_USERS where ROLEID LIKE '%4%'  ");
            return dt;

        }

        public DataTable Bind_JOB()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select TransID, SBU, Area, SubArea, JobType, JobExecutor, JobDateTime, JobDescription, Auditor from TRANSACTION_JOB where ApprovalStatus =0");
            return dt;

        }

        public string Data_Save(string SBU, string Area, string JobType, string JobExecutor, string ExecutorPhone, string SubArea, string JobDateTime, string JobDescription, string Auditor, string AuditorID, string Rescuer, string Remarks, string userid, string ApprovalStatus, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_TRANSACTION_JOB"
                , new string[] { "@SBU", "@Area", "@JobType", "@JobExecutor", "@ExecutorPhone", "@SubArea", "@JobDateTime", "@JobDescription", "@Auditor", "@AuditorID", "@Rescuer", "@Remarks", "@EntryBy", "@ApprovalStatus","@ENTRYSTATUS" }
                , new string[] { SBU, Area, JobType, JobExecutor, ExecutorPhone, SubArea, JobDateTime, JobDescription, Auditor, AuditorID, Rescuer, Remarks, userid, ApprovalStatus, Entrystatus });
            return Result;
        }
        public string Data_Update(string ID, string SBU, string Area, string JobType, string JobExecutor, string ExecutorPhone, string SubArea, string JobDateTime, string JobDescription, string Auditor, string AuditorID, string Rescuer, string Remarks, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_TRANSACTION_JOB"
                , new string[] { "@TransID", "@SBU", "@Area", "@JobType", "@JobExecutor", "@ExecutorPhone", "@SubArea", "@JobDateTime", "@JobDescription", "@Auditor", "@AuditorID", "@Rescuer", "@Remarks", "@UpdatedBy", "@ENTRYSTATUS" }
                , new string[] { ID, SBU, Area, JobType, JobExecutor, ExecutorPhone, SubArea, JobDateTime, JobDescription, Auditor, AuditorID, Rescuer, Remarks, userid, Entrystatus });
            return Result;
        }
        public string Data_Delete(string ID, string SBU, string Area, string JobType, string JobExecutor, string ExecutorPhone, string SubArea, string JobDateTime, string JobDescription, string Auditor, string AuditorID, string Rescuer, string Remarks, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_TRANSACTION_JOB"
                , new string[] { "@TransID", "@SBU", "@Area", "@JobType", "@JobExecutor", "@ExecutorPhone", "@SubArea", "@JobDateTime", "@JobDescription", "@Auditor", "@AuditorID", "@Rescuer", "@Remarks", "@EntryBy", "@ENTRYSTATUS" }
                , new string[] { ID, SBU, Area, JobType, JobExecutor, ExecutorPhone, SubArea, JobDateTime, JobDescription, Auditor, AuditorID, Rescuer, Remarks, userid, Entrystatus });
            return Result;
        }

        public string Data_Approve(String TransID, string NewAuditor, string userid, string ApprovalStatus, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_TRANSACTION_JOB"
                , new string[] { "@TransID","@JobExecutor", "@ApprovedBy", "@ApprovalStatus", "@ApprovalTime", "@ENTRYSTATUS" }
                , new string[] { TransID, NewAuditor, userid, ApprovalStatus, DateTime.Now.ToString(), Entrystatus });
            return Result;
        }

    }
}