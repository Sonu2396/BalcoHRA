using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace BalcoHRA.Business_Layer.BakeOven.LogBook
{
    public class BL_Bakeoven_LogBook
    {
        FPManager cn = new FPManager();

        #region FTA CRANE LOGNOOK
        public DataTable BakeOven_Crane_Master()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT * FROM MST_BAKEOVEN_LOGBOOK_CRANE_CHKLST  ORDER BY ID");
            return dt;
        }
        public bool BakeOven_Crane_Save(string CRANENO,string SHIFTDATE,string SHIFTNAME,string OPERATORID,string OPPERATORNAME,string CHKLIST_ID,string CRNSTATUS,
                                        string REMARKS,string OTHEROBSERVATION,string USERID,string LOGSTARTTIME,string LOGENDTIME,string ENTRYMODE)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_BAKEOVEN_CRANE_CHECKLIST_SAVE"
                , new string[] { "@CRANENO","@SHIFTDATE","@SHIFTNAME","@OPERATORID","@OPPERATORNAME","@CHKLIST_ID","@CRNSTATUS",
                                "@REMARKS","@OTHEROBSERVATION","@USERID","@LOGSTARTTIME","@LOGENDTIME","@ENTRYMODE", "@ENTRYSTATUS"}
                , new string[] { CRANENO,SHIFTDATE,SHIFTNAME,OPERATORID,OPPERATORNAME,CHKLIST_ID,CRNSTATUS,
                                REMARKS,OTHEROBSERVATION,USERID,LOGSTARTTIME,LOGENDTIME,ENTRYMODE, "Save"});
            return Result;
        }

        public DataTable BakeOven_Crane_Report(string SHIFTDATE, string SHIFTNAME, string CRANENO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_BAKEOVEN_CRANE_CHECKLIST_REPORT"
                , new string[] { "@SHIFTDATE", "@SHIFTNAME", "@CRANENO" }
                , new string[] { SHIFTDATE, SHIFTNAME, CRANENO });
            return dt;
        }
        public DataTable BakeOven_Crane_FTA_Status_Report(string SDATE, string EDATE,string STATUS)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_BAKEOVEN_CRANE_CHECKLIST_STATUS_REPORT"
                , new string[] { "@SDATE", "@EDATE","@STATUS" }
                , new string[] { SDATE, EDATE, STATUS });
            return dt;
        }
        public DataTable BakeOven_Crane_Verify_Pening_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_BAKEOVEN_CRANE_VERIFY_PENDING_LIST");
            return dt;
        }
        public DataTable BakeOven_Crane_Verify_Pening_List_Details(string SHIFTDATE, string SHIFTNAME, string CRANENO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_BAKEOVEN_CRANE_VERIFY_PENDING_LIST_DETAILS"
                , new string[] { "@SHIFTDATE", "@SHIFTNAME", "@CRANENO" }
                , new string[] { SHIFTDATE, SHIFTNAME, CRANENO });
            return dt;
        }

        public bool BakeOven_Crane_Verify_Save(string ID,  string USERID, string VERIFYSTATUS)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_BAKEOVEN_CRANE_VERIFY_PENDING_LIST_SAVE"
                , new string[] { "@ID","@USERID","@VERIFYSTATUS"}
                , new string[] { ID,USERID,VERIFYSTATUS,VERIFYSTATUS});
            return Result;
        }

        #endregion


        #region WRM 
        #region WRM PRE STARTUP
        public DataTable WRM_PreStartUp_Master(string MILLNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT * FROM MST_CH_LOGBOOK_CHECKLIST_WRM_PRESTARTUP WHERE ISACTIVE=1 AND  MILLNO='" + MILLNO + "' ORDER BY ID");
            return dt;
        }
        public bool WRM_PreStartUp_Save(string TRDATE, string TRSHIFT, string ENTRYSTART, string ENTRYEND, string MILLNO,
                                     string ACTIVITIESID, string ACTVITYSTATUS, string REMARKS, string USERID)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_CH_TRANS_LOGBOOK_WRM_PRESTARTUP"
                , new string[] { "@TRDATE", "@TRSHIFT", "@ENTRYSTART", "@ENTRYEND", "@MILLNO",
                                "@ACTIVITIESID", "@ACTVITYSTATUS", "@REMARKS", "@USERID", "@ENTRYSTATUS"}
                , new string[] { TRDATE, TRSHIFT, ENTRYSTART, ENTRYEND, MILLNO,
                                 ACTIVITIESID, ACTVITYSTATUS, REMARKS, USERID, "Save"});
            return Result;
        }
        public DataTable WRM_PreStartUp_Master_Report(string TRDATE, string MILLNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TRANS_LOGBOOK_WRM_PRESTARTUP"
                , new string[] { "@TRDATE",  "@MILLNO", "@ENTRYSTATUS"}
                , new string[] { TRDATE,  MILLNO, "Report"});
            return dt;
        }
        public DataTable WRM_PreStartUp_Master_UpdateList(string TRDATE, string TRSHIFT, string MILLNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT T.*,S.ACTIVITIES FROM TR_CH_LOGBOOK_WRM_PRESTARTUP AS T LEFT OUTER JOIN MST_CH_LOGBOOK_CHECKLIST_WRM_PRESTARTUP AS S ON T.ACTIVITIESID=S.ID and T.MILLNO=S.MILLNO  WHERE  TRDATE = '" + TRDATE+ "'  AND TRSHIFT = '" + TRSHIFT + "' AND T.MILLNO='" + MILLNO + "' ORDER BY T.ID");
            return dt;
        }

        #endregion

       

        #region WRM ELECTRICAL STARTUP
        public DataTable WRM_Electrical_Startup_Master(string MILLNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT * FROM MST_CH_LOGBOOK_CHECKLIST_WRM_STARTUP_ELECTRICAL WHERE ISACTIVE=1 AND  MILLNO='" + MILLNO + "' ORDER BY ID");
            return dt;
        }
        public bool WRM_Electrical_Startup_Save(string TRDATE, string TRSHIFT, string ENTRYSTART, string ENTRYEND, string MILLNO,
                                     string ACTIVITIESID, string REMARKS, string USERID,string ACTVITYSTATUS)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_CH_TRANS_LOGBOOK_WRM_ELECTICAL_STARTUP"
                , new string[] { "@TRDATE", "@TRSHIFT", "@ENTRYSTART", "@ENTRYEND", "@MILLNO",
                                "@ACTIVITIESID",  "@REMARKS", "@USERID", "@ENTRYSTATUS","@ACTVITYSTATUS"}
                , new string[] { TRDATE, TRSHIFT, ENTRYSTART, ENTRYEND, MILLNO,
                                 ACTIVITIESID,  REMARKS, USERID, "Save",ACTVITYSTATUS});
            return Result;
        }
        public DataTable WRM_Electrical_Startup_Master_Report(string TRDATE, string MILLNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TRANS_LOGBOOK_WRM_ELECTICAL_STARTUP"
                , new string[] { "@TRDATE", "@MILLNO", "@ENTRYSTATUS" }
                , new string[] { TRDATE, MILLNO, "Report" });
            return dt;
        }
        public DataTable WRM_Electrical_Startup_Master_UpdateList(string TRDATE, string TRSHIFT, string MILLNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT T.*,S.ACTIVITIES,HOWTOCHECK,IDLECONDITION FROM TR_CH_LOGBOOK_WRM_STARTUP_ELECTRICAL AS T LEFT OUTER JOIN MST_CH_LOGBOOK_CHECKLIST_WRM_STARTUP_ELECTRICAL AS S ON T.ACTIVITIESID=S.ID and T.MILLNO=S.MILLNO  WHERE  TRDATE = '" + TRDATE + "'  AND TRSHIFT = '" + TRSHIFT + "' AND T.MILLNO='" + MILLNO + "' ORDER BY T.ID");
            return dt;
        }

        #endregion

        #region  WRM - WIREROD MILL
        public DataTable CLTI_Mill_Master(string MILLNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT * FROM MST_CH_LOGBOOK_CHECKLIST_WRM_WIREROD_MILL WHERE ISACTIVE=1 AND  MILLNO='" + MILLNO + "' ORDER BY ID");
            return dt;
        }
        public bool CLTI_Mill_Save(string TRDATE, string TRSHIFT, string ENTRYSTART, string ENTRYEND, string MILLNO,
                                     string ACTIVITIESID, string REMARKS, string USERID,string ACTVITYSTATUS)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_CH_TRANS_LOGBOOK_WRM_WIREROD_MILL"
                , new string[] { "@TRDATE", "@TRSHIFT", "@ENTRYSTART", "@ENTRYEND", "@MILLNO",
                                "@ACTIVITIESID","@ACTVITYSTATUS",  "@REMARKS", "@USERID", "@ENTRYSTATUS"}
                , new string[] { TRDATE, TRSHIFT, ENTRYSTART, ENTRYEND, MILLNO,
                                 ACTIVITIESID,ACTVITYSTATUS,  REMARKS, USERID, "Save"});
            return Result;
        }
        public DataTable CLTI_Mill_Master_Report(string TRDATE, string MILLNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TRANS_LOGBOOK_WRM_WIREROD_MILL"
                , new string[] { "@TRDATE", "@MILLNO", "@ENTRYSTATUS" }
                , new string[] { TRDATE, MILLNO, "Report" });
            return dt;
        }
        public DataTable CLTI_Mill_Master_UpdateList(string TRDATE, string TRSHIFT, string MILLNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT T.*,S.ACTIVITIES,OPERATORTYPE,HOWTOCHECK,IDLECONDITION FROM TR_CH_LOGBOOK_WRM_WIREROD_MILL AS T LEFT OUTER JOIN MST_CH_LOGBOOK_CHECKLIST_WRM_WIREROD_MILL AS S ON T.ACTIVITIESID=S.ID and T.MILLNO=S.MILLNO  WHERE  TRDATE = '" + TRDATE + "'  AND TRSHIFT = '" + TRSHIFT + "' AND T.MILLNO='" + MILLNO + "' ORDER BY T.ID");
            return dt;
        }

        #endregion

        #endregion


       


    }
}