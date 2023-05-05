using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BalcoHRA.Business_Layer.LCS
{
    public class BL_LCS
    {
        FPManager cn = new FPManager();
        BL_Common_Controls BL = new BL_Common_Controls();

        #region LCS RECEIPT
        public string LCS_Save(string recdate, string recshift, string ladleno, string ladlewt, string roomname, string userid, string Entrystatus,string TapDiff)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_LCS_TRANSACTION"
                , new string[] { "@RECDATE", "@RECSHIFT", "@LADDLENO", "@LADLELCSWT", "@ROOMNAME", "@ENTRYBY", "@ENTRYTYPE","@TAPDIFF" }
                , new string[] { recdate, recshift, ladleno, ladlewt, roomname, userid, Entrystatus,TapDiff });
            return Result;
        }
        public string LCS_Delete(string Sno, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_LCS_TRANSACTION"
                , new string[] { "@Id", "@ENTRYTYPE" }
                , new string[] { Sno, Entrystatus });
            return Result;
        }
        public DataTable Get_LCS_TareWt(string LadleNo)
        {


            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_LADLE_CURRENT_TAREWT"
                , new string[] { "@LADLENO" }
                , new string[] { LadleNo });
            return dt;
        }
        public DataTable Get_LCS_Authorization_for_Delete(string Userid)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_AUTHENTICATION_FORM"
              , new string[] { "@USERID", "@ENTRYSTATUS" }
              , new string[] { Userid, "LCSAuthorization" });
            return dt;
        }
        public DataTable Get_LCS_LastWeight(string LaddleNo)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_GET_LAST_WEIGHT"
              , new string[] { "@LADDLENO" }
              , new string[] { LaddleNo });
            return dt;
        }


        public string LCS_STATUS_STAGE_UPDATE(string ID, string CurrentStatus, string LastStage, string Userid)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_LCS_TRANSACTION_UPDATE_STATUS"
                , new string[] { "@CURRENTSTATUS", "@ID", "@LASTSTAGE", "@USERID" }
                , new string[] { CurrentStatus, ID, LastStage, Userid });
            return Result;
        }
        public string LCS_STATUS_READY_UPDATE(string CurrentStatus, string ID, string LastStage, string Cleanper, string IsLCM, string CHKID1,
                                            string CHKID2, string CHKID3, string CHKID4, string CHKID5, string CHKID6, string CHKID7, string CHKID8, string CHKID9, string CHKID10,
                                            string CHKID11, string CHKID12, string CHKID13, string CHKID14, string CHKID15, string CHKID16, string CHKID17, string CHKID18,
                                            string CHKID19, string CHKID20, string CHKID21, string CHKID22, string Readydate, string Readyshift, string Readytpe, string Userid)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_LCS_TRANSACTION_UPDATE_STATUS"
                , new string[] { "@CURRENTSTATUS", "@ID", "@LASTSTAGE", "@CLEANPER", "@ISLCM","@CHKID1",
                                  "@CHKID2","@CHKID3","@CHKID4","@CHKID5","@CHKID6","@CHKID7","@CHKID8","@CHKID9","@CHKID10",
                                  "@CHKID11","@CHKID12","@CHKID13","@CHKID14","@CHKID15","@CHKID16","@CHKID17","@CHKID18","@CHKID19","@CHKID20",
                                  "@CHKID21","@CHKID22","@USERID","@READYDATE","@READYSHIFT","@READYTYPE",
                                   }
                , new string[] { CurrentStatus, ID, LastStage, Cleanper, IsLCM,CHKID1,
                                    CHKID2,CHKID3,CHKID4,CHKID5,CHKID6,CHKID7,CHKID8,CHKID9,CHKID10,
                                    CHKID11,CHKID12,CHKID13,CHKID14,CHKID15,CHKID16,CHKID17,CHKID18,CHKID19,CHKID20,
                                    CHKID21,CHKID22,Userid,Readydate,Readyshift,Readytpe, });
            return Result;
        }
        public string LCS_STATUS_SEND_TO_POTLINE_UPDATE(string CurrentStatus, string ID, string LastStage, string Readytype, string Roomname, string senddate, string sendshift,string Ladletype, string userid)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_LCS_TRANSACTION_UPDATE_STATUS"
                , new string[] { "@CURRENTSTATUS", "@ID", "@LASTSTAGE", "@READYTYPE", "@SENTROOM", "@USERID", "@SENTDATE", "@SENTSHIFT", "@SENTLADLETYPE" }
                , new string[] { CurrentStatus, ID, LastStage, Readytype, Roomname, userid, senddate, sendshift,Ladletype });
            return Result;
        }
        public string LCS_STATUS_RELINING_UPDATE(string Ladleno, string CurrentStatus, string ID, string LastStage, string RELININGDATE, string RELININGOPERATOR, string RELININGREMARKS, string userid)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_LCS_TRANSACTION_UPDATE_STATUS"
                , new string[] { "@LADLENO", "@CURRENTSTATUS", "@ID", "@LASTSTAGE", "@RELININGDATE", "@RELININGOPERATOR", "@USERID", "@RELININGREMARKS" }
                , new string[] { Ladleno, CurrentStatus, ID, LastStage, RELININGDATE, RELININGOPERATOR, userid, RELININGREMARKS });
            return Result;
        }
        public string LCS_STATUS_MAINTAINANCE_UPDATE(string CurrentStatus, string ID, string LastStage, string MAINTAINANCEOPERATOR, string MAINTAINANCEREMARKS, string userid)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_LCS_TRANSACTION_UPDATE_STATUS"
                , new string[] { "@CURRENTSTATUS", "@ID", "@LASTSTAGE", "@MAINTAINANCEOPERATOR", "@USERID", "@MAINTAINANCEREMARKS" }
                , new string[] { CurrentStatus, ID, LastStage, MAINTAINANCEOPERATOR, userid, MAINTAINANCEREMARKS });
            return Result;
        }
        public DataTable Get_LCS_Pending_List(string PendingType)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_STATUS_LIST"
              , new string[] { "@REPORTTYPE" }
              , new string[] { PendingType });
            return dt;
        }

        #endregion


        #region EMTPTY LCS WEIGHMENT
        public string LCS_EMPTYWEIGHT_Save(string LaddleNo, string VehicleNo,  string userid)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_LCS_TRANSACTION_EMPTY_WEIGHT"
                , new string[] { "@LaddleNo", "@VehicleNo", "@Createdby" }
                , new string[] { LaddleNo, VehicleNo, userid });
            return Result;
        }
        public DataTable LCS_EMPTYWEIGHT_REPORT(string sdate, string edate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_RPT_EMPTY_WEIGHMENT"
                , new string[] { "@SDATE", "@EDATE"}
                , new string[] { sdate, edate });
            return dt;
        }
        #endregion

       


        #region SHIFT END ENTRY
        public string LCS_Save_ShiftEnd(string CLEANINGPER,string RDYLDL6MT,string RDYLDL12MT,string RDYLDLWS6MT1,string RDYLDLWS12MT1,string CLNLDL6MT,string CLNLDL12MT,string UNDCLNLDL,
                                        string BTHCHKDLDL,string UNDMNTCLDL,string RUNNINGLDL,string CRANEPM,string LCMPM,string REMARKS,string LCSDATE,string LCSSHIFT,string SIPHONCHNGPOT,
                                        string SIPHONCLEAN,string SIPHONREADY,string SUCTIONLADLE,string LCMBD,string CRANEBD,string BATHSENT,string METALSENT,string METALCHOKED,string UNDERRELIENING,string DAMGE,string ENTRYBY)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_LCS_TRANSACTION_SUB"
                , new string[] {"@CLEANINGPER","@RDYLDL6MT","@RDYLDL12MT","@RDYLDLWS6MT1","@RDYLDLWS12MT1","@CLNLDL6MT", "@CLNLDL12MT","@UNDCLNLDL","@BTHCHKDLDL","@UNDMNTCLDL","@RUNNINGLDL","@CRANEPM","@LCMPM","@REMARKS","@LCSDATE","@LCSSHIFT","@SIPHONCHNGPOT",
                                    "@SIPHONCLEAN","@SIPHONREADY","@SUCTIONLADLE","@LCMBD","@CRANEBD","@BATHSENT","@METALSENT","@METALCHOKED",
                                    "@UNDERRELIENING","@DAMGE","@ENTRYBY" }
                , new string[] { CLEANINGPER,RDYLDL6MT,RDYLDL12MT,RDYLDLWS6MT1,RDYLDLWS12MT1,CLNLDL6MT,CLNLDL12MT,UNDCLNLDL,BTHCHKDLDL,UNDMNTCLDL,
                                RUNNINGLDL,CRANEPM,LCMPM,REMARKS,LCSDATE,LCSSHIFT,SIPHONCHNGPOT,SIPHONCLEAN,SIPHONREADY,SUCTIONLADLE,LCMBD,CRANEBD,
                                BATHSENT,METALSENT,METALCHOKED,UNDERRELIENING,DAMGE,ENTRYBY });
            return Result;
        }

       
        public DataTable Get_LCS_ShiftEnd_Entry()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_TRANS_SHIFTEND_ENRTY");
            return dt;
        }
        public DataTable Get_LCS_ShiftEnd_Entry1(string date,string shift)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from TBL_TRANSACTION_LCS_SUB where LCSDATE='" + date + "' and LCSSHIFT='" + shift + "'");
            return dt;
        }
        #endregion


        #region SHIPHON CHANGE 
        public DataTable LCS_SIPHON_BIND_LADLE_LIST(string LadleType)
        {


            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_TRANSACTION_SIPHON_LADLE_BIND_NEW"
                , new string[] { "@LADLETYPE" }
                , new string[] { LadleType});
            return dt;
        }
        public DataTable LCS_SIPHON_LIST(string SearchText)
        {


            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_TRANSACTION_SIPHON_NEW"
                , new string[] { "@SEARCHTEXT","@ENTRYTYPE" }
                , new string[] { SearchText,"List" });
            return dt;
        }
        public string LCS_SIPHON_DELETE(string Sno)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_LCS_TRANSACTION_SIPHON_NEW"
                , new string[] { "@ID", "@ENTRYTYPE" }
                , new string[] { Sno, "Delete" });
            return Result;
        }
        public string LCS_SIPHON_SAVE(string SIPHONTYPE,string LADLETYPE,string LALDENAME,string ENRTYDATE,string ENTRYSHIFT,string ROOMNAME,string CREATEDBY,string NOSDAMAGE,string NOSDAMAGEQTY)
        {

            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_LCS_TRANSACTION_SIPHON_NEW"
                , new string[] { "@SIPHONTYPE","@LADLETYPE","@LALDENAME","@ENRTYDATE","@ENTRYSHIFT","@ROOMNAME","@CREATEDBY", "@ENTRYTYPE","@NOSDAMAGE","@NOSDAMAGEQTY" }
                , new string[] { SIPHONTYPE, LADLETYPE, LALDENAME, ENRTYDATE, ENTRYSHIFT, ROOMNAME, CREATEDBY, "Save", NOSDAMAGE, NOSDAMAGEQTY });
            return Result;
        }
        public string LCS_SIPHON_UPDATE(string ID, string SIPHONTYPE, string LADLETYPE, string LALDENAME, string ENRTYDATE, string ENTRYSHIFT, string ROOMNAME, string MODIFICATIONBY,string NOSDAMAGE,string NOSDAMAGEQTY)
        {

            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_LCS_TRANSACTION_SIPHON_NEW"
                , new string[] { "@ID","@SIPHONTYPE", "@LADLETYPE", "@LALDENAME", "@ENRTYDATE", "@ENTRYSHIFT", "@ROOMNAME", "@MODIFICATIONBY", "@ENTRYTYPE","@NOSDAMAGE","@NOSDAMAGEQTY" }
                , new string[] { ID, SIPHONTYPE, LADLETYPE, LALDENAME, ENRTYDATE, ENTRYSHIFT, ROOMNAME, MODIFICATIONBY, "Update", NOSDAMAGE , NOSDAMAGEQTY });
            return Result;
        }
        #endregion


        #region LCS REPORTS
        public DataTable LCS_CHECKLIST_REPORT(string sdate, string shift)
        {


            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_RPT_CHECKLIST"
                , new string[] { "@DATE", "@SHIFT" }
                , new string[] { sdate, shift });
            return dt;
        }
        public DataTable LCS_LOGBOOK_REPORT(string sdate, string Reporttype)
        {

            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_LOGBOOK"
                , new string[] { "@SDATE", "@ReportType" }
                , new string[] { sdate, Reporttype });
            return dt;
        }

        public DataTable LCS_CHECKLIST_LADLE_DETAILS_REPORT(string sdate, string shift, string ladleno)
        {


            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_RPT_CHECKLIST_LADLE_INFO"
                , new string[] { "@DATE", "@SHIFT", "@LADLENO" }
                , new string[] { sdate, shift, ladleno });
            return dt;
        }



        public DataTable Report_LCS_TareWt(string LADLENO)
        {


            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_CURRENT_WEIGHT_NEW"
                , new string[] { "@LADLENO" }
                , new string[] { LADLENO });
            return dt;
        }
        public DataTable Report_LCS_TareWt_SlipInfo(string sdate, string edate, string Ladle)
        {
            
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_TAT_LADLEWISE_DETAILS"
                , new string[] { "@Sdate","Ladleno" }
                , new string[] { sdate,Ladle });
            return dt;
        }


        public DataTable Report_LCS_Daily_Report(string sdate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_DAILYREPORT"
                , new string[] { "@Todate" }
                , new string[] { sdate });
            return dt;
        }
        public DataTable Report_LCS_Daily_Report_Summary(string sdate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_DAILYREPORT_SUMMARY"
                , new string[] { "@Todate" }
                , new string[] { sdate });
            return dt;
        }

        public DataTable Report_LCS_Weight_Difference_Report(string sdate,string edate,string ladleno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_LADDLE_WEIGHT_RECEIPT"
                , new string[] { "@SDATE","@EDATE","@LADLENO" }
                , new string[] { sdate,edate,ladleno });
            return dt;
        }
        public DataTable Report_LCS_Send_To_Potline_Report(string sdate, string edate, string ReportType)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_LADLE_SEND_POTLINE"
                , new string[] { "@SDATE", "@EDATE", "@ReportType" }
                , new string[] { sdate, edate, ReportType });
            return dt;
        }
        public DataTable Report_LCS_Send_To_Potline_Details_Report(string Date, string RoomName,string LadleType, string ReportType)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_LADLE_SEND_POTLINE_DETAILS"
                , new string[] { "@Date", "@RoomName","@LadleType", "@ReportType" }
                , new string[] { Date, RoomName, LadleType, ReportType });
            return dt;
        }

        public DataTable Report_LCS_Siphon_Change_Delete_Report(string sdate, string edate, string ReportType,string SiphonType)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_LADLE_SIPHON_CHANGE_DAMAGE"
                , new string[] { "@SDATE", "@EDATE", "@ReportType","@SiphonType" }
                , new string[] { sdate, edate, ReportType, SiphonType });
            return dt;
        }
        public DataTable Report_LCS_Siphon_Change_Delete_Details_Report(string Date, string RoomName, string LadleType, string ReportType,string SiphonType)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_LADLE_SIPHON_CHANGE_DAMAGE_DETAILS"
                , new string[] { "@Date", "@RoomName", "@LadleType", "@ReportType","@SiphonType" }
                , new string[] { Date, RoomName, LadleType, ReportType, SiphonType });
            return dt;
        }


        public DataTable Report_LCS_TAT_Report(string sdate, string edate, string Ladleno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_TAT_LADLEWISE"
                , new string[] { "@SDATE", "@EDATE", "@LADLENO" }
                , new string[] { sdate, edate, Ladleno });
            return dt;
        }
        public DataTable Report_LCS_TAT_Details_Report(string sdate, string edate, string Ladleno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_TAT_LADLEWISE_DETAILS"
                 , new string[] { "@SDATE", "@EDATE", "@Ladleno" }
                 , new string[] { sdate, edate, Ladleno });
            return dt;
        }
        public DataTable Report_LCS_TAT_Consolidated_Report(string sdate, string edate, string Ladleno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_TAT_CONSOLIDATED_LADLEWISE"
                , new string[] { "@SDATE", "@EDATE", "@LADLENO" }
                , new string[] { sdate, edate, Ladleno });
            return dt;
        }
        public DataTable Report_LCS_TAT_Consolidated_Details_Report(string sdate, string edate, string Ladleno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_TAT_LADLEWISE_DETAILS"
                 , new string[] { "@SDATE", "@EDATE", "@Ladleno" }
                 , new string[] { sdate, edate, Ladleno });
            return dt;
        }

        #endregion


        #region Dashboard Data
        public DataTable LCS_DASHBOARD_LADLE_TAT_REPORT()
        {

            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_DASHBOARD_LADDLE_TAPPING");
            return dt;
        }
        public DataTable LCS_DASHBOARD_LADLE_STATUS_REPORT()
        {

            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_DASHBOARD_LADLE_STAUS");
            return dt;
        }

        public DataTable LCS_DASHBOARD_LADDLE_TAREWT(string ReportType)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_DASHBOARD_LADDLE_TAREWT"
              , new string[] { "@REPORTTYPE" }
              , new string[] { ReportType });
            return dt;
        }
        public DataTable LCS_DASHBOARD_LADDLE_TAREWT_CHART(string ReportType)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_DASHBOARD_LADDLE_TAREWT_ROOMWISE"
              , new string[] { "@REPORTTYPE" }
              , new string[] { ReportType });
            return dt;
        }
        public DataTable LCS_DASHBOARD_LADDLE_RUNNING_LADLE()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_DASHBOARD_LADDLE_TAP_WEIGHT");
            return dt;
        }

        #endregion Dashboard Data



        public DataTable Get_LCS_List_Pending_Potline(string Room)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LCS_REPORT_STATUS_LIST"
              , new string[] { "@REPORTTYPE", "@RoomName" }
              , new string[] { "PotLineReceipt", Room });
            return dt;
        }

        public DataTable Get_LCS_Transwt_Last(string Laddleno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select top 1 TRANSWT from TBL_LCS_LADDLE_TRANS as L  where L.LADDLENO='" + Laddleno + "' and TRANSTYPE='TAPPED' and id>(select top 1  id from TBL_LCS_LADDLE_TRANS where LADDLENO='" + Laddleno + "' and TRANSTYPE='LCS'  order by id desc) order by id");
            return dt;
        }
        public DataTable Get_LCS_Trans_Id(string ID)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from TBL_TRANSACTION_LCS where id='" + ID + "'");
            return dt;
        }
        public bool LCS_potline_Receive_Save(string ID, string LCSSTATUS, string SENTTAREWT, string CHECKEDBY, string CHECKEDREMARKS, string CHECKEDSUCTION)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_LCS_TRANSACTION"
                , new string[] { "@ID", "@LCSSTATUS", "@SENTTAREWT", "@CHECKEDBY", "@CHECKEDREMARKS", "@CHECKEDSUCTION", "@ENTRYTYPE" }
                , new string[] { ID, LCSSTATUS, SENTTAREWT, CHECKEDBY, CHECKEDREMARKS, CHECKEDSUCTION,"PotLineReceipt" });
            return Result;
        }
    }
}