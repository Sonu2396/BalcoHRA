using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BalcoHRA.Business_Layer.PotLine.PotRelining
{
    public class BL_PotRelining
    {
        FPManager cn = new FPManager();

        public DataTable Get_PotNo_Delay(string Potline, string Section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_RELINING_DELAY_POTNO"
             , new string[] { "@POTLINE", "@SECTION" }
                , new string[] { Potline, Section });
            return dt;
        }
        public DataTable Get_PotNo_Entry_Details(string Potline, string Section,string POTNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_RELINING_DELAY_PENDING_POT_DETAILS"
             , new string[] { "@POTLINE", "@SECTION", "@POTNO" }
                , new string[] { Potline, Section, POTNO });
            return dt;

        }
        public DataTable Get_Pending_Delay_Activity(string Transcode)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_RELINING_DELAY_PENDING_ACTIVITY"
             , new string[] { "@Transcode" }
                , new string[] { Transcode });
            return dt;

        }
        public DataTable Get_Activity_Status_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from MST_DELAY_OP_STATUS");
            return dt;
        }

        public DataTable Get_Shift_Incharge_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_RELINING_EMPLOYEE_SHIFTINCHARGE_LIST");
            return dt;

        }
        public DataTable Get_Supervisor_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_RELINING_EMPLOYEE_SUPERVISOR_LIST");
            return dt;

        }
        public DataTable Get_Employee_List(string EmployeeIds)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_RELINING_GET_EMPLOYEES"
             , new string[] { "@Empid" }
                , new string[] { EmployeeIds });
            return dt;

        }

        #region Generate Paln
        public DataTable Generate_Plan(string POTLINE,string SECTION ,string POTNO,string GENERATION ,string USERID ,string STARTDTIME )
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_RELINING_GENERATE_PLAN"
              , new string[] { "@POTLINE","@SECTION" ,"@POTNO","@GENERATION","@USERID","@STARTDTIME"}
              , new string[] { POTLINE,SECTION,POTNO, GENERATION, USERID , STARTDTIME });
            return dt;
        }

        #endregion

        #region Delay Enrty
        public DataTable Get_Authority_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from MST_EMPLOYEE_TYPE");
            return dt;
        }
        public DataTable Get_Department_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from MST_DELAY_DEPARTMENT");
            return dt;
        }
        public DataTable Get_Delay_Reason_List(string Deptid)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from MST_DELAY_REASON WHERE DELADYDEPTID='" + Deptid + "'");
            return dt;
        }
        public DataTable Get_Responsible_Person_List(string ID)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_GET_RESPONSIBLE_PERSON"
                 , new string[] { "@ID" }
                 , new string[] { ID });
            return dt;
        }
        public string SAVE_Delay_Progress(string TRANSCODE, string TRDATE, string TRSHIFT, string TRSTATUSTYPE, string SHIFTINCHARGE, string ACTIVITYID, 
                                          string MANPOWERIDS,  string REMARKS, string SUPERVISORID, string USERID)
        {
            string Rslt = "";
            Rslt = cn.ExecuteQuerySP_Retrun_String("SP_POT_SAVE_RELINING_DELAY_ACTIVITY_PROGRESS"
                 , new string[] { "@TRANSCODE","@TRDATE","@TRSHIFT","@TRSTATUSTYPE","@SHIFTINCHARGE","@ACTIVITYID",
                               "@MANPOWERIDS","@REMARKS","@SUPERVISORID","@USERID" }
                 , new string[] { TRANSCODE,TRDATE,TRSHIFT,TRSTATUSTYPE,SHIFTINCHARGE,ACTIVITYID,
                                  MANPOWERIDS,REMARKS,SUPERVISORID,USERID});
            return Rslt;
        }
        
        public string SAVE_Delay_Delay(string TRANSCODE, string TRDATE, string TRSHIFT, string TRSTATUSTYPE, string SHIFTINCHARGE, string ACTIVITYID, string AUTHORITY, string DEPTID, string DELAYREASONID, string SUPERITENDENTID,
                                               string CRANEOPID,  string DELAYINHOUR, string REMARKS,  string USERID)
        {
            string Rslt = "";
            Rslt = cn.ExecuteQuerySP_Retrun_String("SP_POT_SAVE_RELINING_DELAY_ACTIVITY_DELAY"
                 , new string[] { "@TRANSCODE","@TRDATE","@TRSHIFT","@TRSTATUSTYPE","@SHIFTINCHARGE","@ACTIVITYID",
                                "@AUTHORITY","@DEPTID","@DELAYREASONID","@SUPERITENDENTID","@CRANEOPID",
                                "@DELAYINHOUR","@REMARKS","@USERID" }
                 , new string[] { TRANSCODE,TRDATE,TRSHIFT,TRSTATUSTYPE,SHIFTINCHARGE,ACTIVITYID,
                     AUTHORITY,DEPTID,DELAYREASONID,SUPERITENDENTID,CRANEOPID
                                ,DELAYINHOUR,REMARKS,USERID});
            return Rslt;
        }

        public DataTable Get_SAVE_Delay_Vs_Complete(string TRANSCODE, string TRDATE, string ACTIVITYID)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_SAVE_RELINING_DELAY_CHECK_ACTIVITY_ENTRY"
                 , new string[] { "@TRANSCODE", "@TRDATE", "@ACTIVITYID" }
                 , new string[] { TRANSCODE, TRDATE, ACTIVITYID });
            return dt;
        }
        public DataTable Get_SAVE_Parameter_Vs_Complete(string TRANSCODE)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_SAVE_RELINING_COMPLETED_CHECK_ACTIVITY_ENTRY"
                 , new string[] { "@TRANSCODE" }
                 , new string[] { TRANSCODE });
            return dt;
        }
        public string SAVE_Delay_Completed(string TRANSCODE, string TRDATE, string TRSHIFT, string TRSTATUSTYPE, string SHIFTINCHARGE, string ACTIVITYID,
                                         string MANPOWERIDS, string REMARKS, string SUPERVISORID,string COMPLETEDTIME, string USERID)
        {
            string Rslt = "";
            Rslt = cn.ExecuteQuerySP_Retrun_String("SP_POT_SAVE_RELINING_DELAY_ACTIVITY_COMPLETED"
                 , new string[] { "@TRANSCODE","@TRDATE","@TRSHIFT","@TRSTATUSTYPE","@SHIFTINCHARGE","@ACTIVITYID",
                               "@MANPOWERIDS","@REMARKS","@SUPERVISORID","@COMPLETEDTIME","@USERID" }
                 , new string[] { TRANSCODE,TRDATE,TRSHIFT,TRSTATUSTYPE,SHIFTINCHARGE,ACTIVITYID,
                                  MANPOWERIDS,REMARKS,SUPERVISORID,COMPLETEDTIME,USERID});
            return Rslt;
        }
        #endregion



        #region Reports POT TAT
        public DataTable Report_Pot_TAT(string POTNO,string GENERATION)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_POTTAT"
                 , new string[] { "@POTNO","@GENERATION" }
                 , new string[] { POTNO, GENERATION });
            return dt;
        }
        public DataTable Report_Pot_TAT_Parameter(string POTNO, string GENERATION)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_POTTAT_PARAMETER"
                 , new string[] { "@POTNO", "@GENERATION" }
                 , new string[] { POTNO, GENERATION });
            return dt;
        }
        public DataTable Report_Pot_TAT_Delay_Parameter(string POTNO, string GENERATION)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_POTTAT_DELAY_PARAMETER"
                 , new string[] { "@POTNO", "@GENERATION" }
                 , new string[] { POTNO, GENERATION });
            return dt;
        }

        public DataTable Report_Pot_TAT_Activity_Details(string ACTIVITYID, string POTNO, string GENERATION)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_POTTAT_ACTIVITY_DETAILS"
                 , new string[] { "@ACTIVITYID","@POTNO", "@GENERATION" }
                 , new string[] { ACTIVITYID, POTNO, GENERATION });
            return dt;
        }
        public DataTable Report_Pot_TAT_Delay_Details(string DELAYID, string POTNO, string GENERATION)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_POTTAT_DELAY_DETAILS"
                 , new string[] { "@DELAYID", "@POTNO", "@GENERATION" }
                 , new string[] { DELAYID, POTNO, GENERATION });
            return dt;
        }
        #endregion


        #region Report Summary
        public DataTable Get_TAT_Summary_Report(string MonthName)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_POT_TAT_SUMMARY"
                 , new string[] { "@MONTH" }
                 , new string[] { MonthName });
            return dt;
        }
        public DataTable Get_Chart_Deviation_potline_Report(string MonthName)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_POT_TAT_DEVIATION"
                 , new string[] { "@MONTH" }
                 , new string[] { MonthName });
            return dt;
        }
        public DataTable Get_Chart_Delay_Report(string MonthName)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_POT_TAT_DELAY_SUMMARY"
                 , new string[] { "@MONTH" }
                 , new string[] { MonthName });
            return dt;
        }
        public DataTable Get_Chart_Delay_Vs_Potno_TAT_Report(string MonthName)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_POT_TAT_DELAY_SUMMARY_VS_POTNO"
                 , new string[] { "@MONTH" }
                 , new string[] { MonthName });
            return dt;
        }


        public DataTable Get_TAT_Summary_Report_PowerOnOff(string MonthName, string PotLine, string Onoff)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_POT_TAT_SUMMARY_POWERONOFF"
                 , new string[] { "@MONTH", "@POTLINE", "@ONOFF" }
                 , new string[] { MonthName, PotLine, Onoff });
            return dt;
        }

        public DataTable Get_Chart_TAT_Vs_PotNo_Report(string MonthName, string Potline, string potno, string Generation)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_POT_TAT_PARAMETER_VS_POTNO"
                 , new string[] { "@MONTH", "@POTLINE", "@POTNO", "@GENERATION" }
                 , new string[] { MonthName, Potline, potno, Generation });
            return dt;
        }
        public DataTable Get_TAT_Summary_Report_Delay(string MonthName, string PotLine)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_POT_TAT_DELAY_SUMMARY_1"
                 , new string[] { "@MONTH", "@POTLINE" }
                 , new string[] { MonthName, PotLine });
            return dt;
        }
        public DataTable Get_Chart_Delay_Vs_PotNo_Report(string MonthName, string Potline, string potno, string Generation)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_POT_TAT_DELAY_PARAMETER_VS_POTNO"
                 , new string[] { "@MONTH", "@POTLINE", "@POTNO", "@GENERATION" }
                 , new string[] { MonthName, Potline, potno, Generation });
            return dt;
        }

        #endregion


        #region Delay Compeleted Entry Edit
        public DataTable Delay_Trans_List(string Transcode)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_DELAY_ENTRY_LIST"
                 , new string[] { "@Transcode" }
                 , new string[] { Transcode });
            return dt;
        }
        public String Get_Delay_Delete_By_ID(string ID)
        {
            string Rslt = "";
            Rslt = cn.ExecuteQuerySP_Retrun_String("SP_POT_RELINING_DELAY_DELETE_BY_ID"
                 , new string[] { "@ID" }
                 , new string[] { ID });
            return Rslt;
        }
        public DataTable Get_Delay_Details_By_ID(string ID)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_REPORT_RELINING_DELAY_BY_ID"
                 , new string[] { "@ID" }
                 , new string[] { ID });
            return dt;
        }
        public DataTable Get_Employe_List_All(string Empname)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_GET_EMPLOYEE_LIST_ALL"
                 , new string[] { "@EMPNAME" }
                 , new string[] { Empname });
            return dt;
        }
        public bool SAVE_Delay_Update(string ID, string SUPERITENDENTID,  string DELAYINHOUR, 
                                        string MANPOWERIDS, string REMARKS, string SUPERVISORID, string COMPLETEDTIME, string USERID,string ENTRYSTATUS)
        {
            bool Rslt = false;
            Rslt = cn.ExecuteQuerySP("SP_POT_SAVE_RELINING_DELAY_ACTIVITY_UPDATE"
                 , new string[] { "@ID","@SUPERITENDENTID","@DELAYINHOUR",
                               "@MANPOWERIDS","@REMARKS","@SUPERVISORID","@COMPLETEDTIME","@USERID","@ENTRYSTATUS" }
                 , new string[] { ID,SUPERITENDENTID,DELAYINHOUR,
                                  MANPOWERIDS,REMARKS,SUPERVISORID,COMPLETEDTIME,USERID,ENTRYSTATUS});
            return Rslt;
        }
        #endregion
    }
}