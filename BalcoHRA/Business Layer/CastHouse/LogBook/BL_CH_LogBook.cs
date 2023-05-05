using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace BalcoHRA.Business_Layer.CastHouse.LogBook
{
    public class BL_CH_LogBook
    {
        FPManager cn = new FPManager();




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


        #region CRANE CHECK LIST

        #region FURNACE AREA
        public DataTable CRN_Furance_Dropdownlist_Craneno(string Area)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT distinct CRANENAME  FROM MST_CH_LOGBOOK_CHECKLIST_CRANE WHERE   CRANEAREA='" + Area + "' ORDER BY CRANENAME");
            return dt;
        }
        public DataTable CRN_Furance_Master(string Area,string CraneName)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT * FROM MST_CH_LOGBOOK_CHECKLIST_CRANE WHERE   CRANEAREA='" + Area + "' AND CRANENAME='" + CraneName + "' ORDER BY ID");
            return dt;
        }
        public bool CRN_Save(string TRDATE, string TRSHIFT, string ENTRYSTART, string ENTRYEND, string AREA,
                                     string ACTIVITIESID, string ACTVITYSTATUS, string REMARKS, string USERID)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_CH_TRANS_LOGBOOK_CRANE"
                , new string[] { "@TRDATE", "@TRSHIFT", "@ENTRYSTART", "@ENTRYEND", "@AREA",
                                "@ACTIVITIESID", "@ACTVITYSTATUS", "@REMARKS", "@USERID", "@ENTRYSTATUS"}
                , new string[] { TRDATE, TRSHIFT, ENTRYSTART, ENTRYEND, AREA,
                                 ACTIVITIESID, ACTVITYSTATUS, REMARKS, USERID, "Save"});
            return Result;
         }
        public DataTable CRN_Report(string TRDATE, string AREA)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TRANS_LOGBOOK_CRANE"
                , new string[] { "@TRDATE", "@AREA", "@ENTRYSTATUS" }
                , new string[] { TRDATE, AREA, "Report" });
            return dt;
        }
        public DataTable CRN_Master_UpdateList(string TRDATE, string TRSHIFT, string CRANEAREA,string CRANENAME)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT T.*,S.ACTIVITIES FROM TR_CH_LOGBOOK_CRANE AS T "+
                " LEFT OUTER JOIN MST_CH_LOGBOOK_CHECKLIST_CRANE AS S ON T.ACTIVITIESID = S.ID AND S.CRANEAREA = '" + CRANEAREA + "' " +
                " WHERE  TRDATE = '" + TRDATE + "'  AND TRSHIFT = '" + TRSHIFT + "' and CRANENAME='" + CRANENAME + "' ORDER BY T.ID");
            return dt;
        }

        #endregion

        #endregion




        #region ICM
        #region  ICM-MECHANICAL
        public DataTable ICM_Mech_Master(string ICMNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT * FROM MST_CH_LOGBOOK_CHECKLIST_MECHANICAL_ICM WHERE ISACTIVE=1 AND  ICMNO='" + ICMNO + "' ORDER BY ID");
            return dt;
        }
        public bool ICM_Mech_Save(string TRDATE, string TRSHIFT, string ENTRYSTART, string ENTRYEND, string ICMNO,
                                     string ACTIVITIESID, string REMARKS, string USERID, string ACTVITYSTATUS)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_CH_TRANS_LOGBOOK_MECHANICAL_ICM"
                , new string[] { "@TRDATE", "@TRSHIFT", "@ENTRYSTART", "@ENTRYEND", "@ICMNO",
                                "@ACTIVITIESID","@ACTVITYSTATUS",  "@REMARKS", "@USERID", "@ENTRYSTATUS"}
                , new string[] { TRDATE, TRSHIFT, ENTRYSTART, ENTRYEND, ICMNO,
                                 ACTIVITIESID,ACTVITYSTATUS,  REMARKS, USERID, "Save"});
            return Result;
        }
        public DataTable ICM_Mech_Master_Report(string TRDATE, string ICMNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TRANS_LOGBOOK_MECHANICAL_ICM"
                , new string[] { "@TRDATE", "@ICMNO", "@ENTRYSTATUS" }
                , new string[] { TRDATE, ICMNO, "Report" });
            return dt;
        }
        public DataTable ICM_Mech_Master_UpdateList(string TRDATE, string TRSHIFT, string ICMNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT T.*, AREA,OPERATORTYPE,S.ACTIVITIES,HOWTOCHECK,IDLECONDITION FROM TR_CH_LOGBOOK_MECHANICAL_ICM AS T LEFT OUTER JOIN MST_CH_LOGBOOK_CHECKLIST_MECHANICAL_ICM AS S ON T.ACTIVITIESID=S.ID and T.ICMNO=S.ICMNO  WHERE  TRDATE = '" + TRDATE + "'  AND TRSHIFT = '" + TRSHIFT + "' AND T.ICMNO='" + ICMNO + "' ORDER BY T.ID");
            return dt;
        }

        #endregion
        #region  MILL-MECHANICAL
        public DataTable MILL_Mech_Master(string MILLNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT * FROM MST_CH_LOGBOOK_CHECKLIST_MECHANICAL_MILL WHERE ISACTIVE=1 AND  MILLNO='" + MILLNO + "' ORDER BY ID");
            return dt;
        }
        public bool MILL_Mech_Save(string TRDATE, string TRSHIFT, string ENTRYSTART, string ENTRYEND, string MILLNO,
                                     string ACTIVITIESID, string REMARKS, string USERID, string ACTVITYSTATUS)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_CH_TRANS_LOGBOOK_MECHANICAL_MILL"
                , new string[] { "@TRDATE", "@TRSHIFT", "@ENTRYSTART", "@ENTRYEND", "@MILLNO",
                                "@ACTIVITIESID","@ACTVITYSTATUS",  "@REMARKS", "@USERID", "@ENTRYSTATUS"}
                , new string[] { TRDATE, TRSHIFT, ENTRYSTART, ENTRYEND, MILLNO,
                                 ACTIVITIESID,ACTVITYSTATUS,  REMARKS, USERID, "Save"});
            return Result;
        }
        public DataTable MILL_Mech_Master_Report(string TRDATE, string MILLNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TRANS_LOGBOOK_MECHANICAL_MILL"
                , new string[] { "@TRDATE", "@MILLNO", "@ENTRYSTATUS" }
                , new string[] { TRDATE, MILLNO, "Report" });
            return dt;
        }
        public DataTable MILL_Mech_Master_UpdateList(string TRDATE, string TRSHIFT, string MILLNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT T.*, OPERATORTYPE,S.ACTIVITIES,HOWTOCHECK,IDLECONDITION FROM TR_CH_LOGBOOK_MECHANICAL_MILL AS T LEFT OUTER JOIN MST_CH_LOGBOOK_CHECKLIST_MECHANICAL_MILL AS S ON T.ACTIVITIESID=S.ID and T.MILLNO=S.MILLNO  WHERE  TRDATE = '" + TRDATE + "'  AND TRSHIFT = '" + TRSHIFT + "' AND T.MILLNO='" + MILLNO + "' ORDER BY T.ID");
            return dt;
        }

        #endregion
        #endregion


    }
}