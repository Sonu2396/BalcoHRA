using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BalcoHRA.Business_Layer.PotLine.Operation
{
    public class BL_Operation
    {
        FPManager cn = new FPManager();
        #region TAPPING PLANNING
        public bool Planning_Save(string fromdate, string todate, string potline)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_POTLINE_TAPPING_PLANNING_TRANS_SCHEDULE"
                 , new string[] { "@fromdate", "@todate", "@line" }
                 , new string[] { fromdate, todate, potline });
            return Result;
        }
        public DataTable Planning_Get(string fromdate, string todate, string potline)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_TAPPING_PLANNING_RPT_SCHEDULE"
             , new string[] { "@fromdate", "@todate", "@line" }
                , new string[] { fromdate, todate, potline });
            return dt;
        }
        #endregion

        #region Upload Recommendation Weight 
        public DataTable Check_EnableforEntry_Data(string Date, string Potline, string Section, string Shift, string Schedule)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_CHECK_SCHEDULE"
             , new string[] { "@DATE", "@POTLINE", "@SECTION", "@SHIFT", "@SCHEDULETYPE" }
                , new string[] { Date, Potline, Section, Shift, Schedule });
            return dt;
        }
        public DataTable Upload_PotData_Load(string Date, string Potline, string Section, string Shift, string ScheduleType)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_LOAD_UPLOAD_RECOM_WEIGHT"
             , new string[] { "@TAPDATE", "@TAPLINE", "@TAPSECTION", "@TAPSHIFT", "@SCHEDULETYPE" }
                , new string[] { Date, Potline, Section, Shift, ScheduleType });
            return dt;
        }
        public bool Upload_PotData_Save(string Date, string Shift, string Potline, string Section, string Potno, string Recwt, string Userid, string ScheduleType)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_POTLINE_OPERATION_UPLOAD_RECOMENDATION_WEIGHT"
             , new string[] { "@TAPDATE", "@TAPSHIFT", "@TAPLINE", "@TAPSECTION", "@POTNO", "@RECWT", "@USERID", "@EntryType" }
                , new string[] { Date, Shift, Potline, Section, Potno, Recwt, Userid, ScheduleType });
            return Result;
        }
        public bool Upload_PotData_PotLine1_OnsesingleClick_Save(string Userid)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_POTLINE_OPERATION_SAVE_RECOMWEIGHT"
             , new string[] { "@USERID" }
                , new string[] { Userid });
            return Result;
        }

        #endregion


        #region Tapping mannual
        public DataTable Get_No_Of_Tapping_Laddle(string LADDLENO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_NOOF_TAPPING_BY_LADDLENO"
             , new string[] { "@LADDLENO" }
                , new string[] { LADDLENO });
            return dt;
        }
        public DataTable Fetch_Ladle_Details(string LadleId)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_MASTER_LADLE"
             , new string[] { "@ID", "@ENTRYSTATUS" }
                , new string[] { LadleId, "View" });
            return dt;
        }
        public DataTable Fetch_Available_Pot_Tapping(string Section, string Tapline)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_TAPPING_POT_AVAILABLE"
             , new string[] { "@Section", "@Tapline" }
                , new string[] { Section, Tapline });
            return dt;
        }
        public DataTable Fetch_Available_Pot_InternalpotPouring(string Section, string Tapline)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_INTERNALPOURING_POT_AVAILABLE"
             , new string[] { "@Section", "@Tapline" }
                , new string[] { Section, Tapline });
            return dt;
        }
        public DataTable Fetch_Available_Pot_Details(string potId)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from TBL_POT_PLANNING_BLENDINGDETAILS where id = '" + potId + "'");
            return dt;
        }

        public DataTable Get_Product_Details(string fe, string si, string Purity)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_GET_PRODUCT"
             , new string[] { "@fe", "@si", "@purity" }
                , new string[] { fe, si, Purity });
            return dt;
        }
        public string Save_Mannual_Slip(string CHLOCATION, string TAPLINE, string POTNO, string TAPSLIPNO, string POTID, string TAPWT, string FE, string SI, string TI, string V, string FFE, string FSI, string FTI, string FV,
                                        string PURITY, string FPURITY, string GRADE, string FGRADE, string TAPPEDLADDLENO, string TAPPEDSTARTTIME, string TAPPEDENDTIME, string LCSCHECKLIST, string FTOTWT, string LadleWt, string USERID)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_OPERATION_CREATE_MANNUAL_TAPPING_SLIP"
                 , new string[] { "@CHLOCATION","@TAPLINE","@POTNO","@TAPSLIPNO","@POTID","@TAPWT","@FE","@SI","@TI","@V","@FFE","@FSI","@FTI","@FV",
                                    "@PURITY","@FPURITY","@GRADE","@FGRADE","@TAPPEDLADDLENO","@TAPPEDSTARTTIME","@TAPPEDENDTIME","@LCSCHECKLIST","@FTOTWT","@LADLEWT","@USERID"
                                }
                 , new string[] { CHLOCATION,TAPLINE,POTNO,TAPSLIPNO,POTID,TAPWT,FE,SI,TI,V,FFE,FSI,FTI,FV,
                                    PURITY,FPURITY,GRADE,FGRADE,TAPPEDLADDLENO,TAPPEDSTARTTIME,TAPPEDENDTIME,LCSCHECKLIST,FTOTWT,LadleWt,USERID
                                });
            return Result;
        }


        #endregion



        #region Manage Pot
        public DataTable Get_TapSlip_List(string Potline, string Section, string Date, string Shift)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_LOAD_MANAGEPOT_SLIPNO"
             , new string[] { "@TAPDATE", "@TAPLINE", "@TAPSECTION", "@TAPSHIFT" }
                , new string[] { Date, Potline, Section, Shift });
            return dt;
        }
        public string Delete_TapSlip(string Slipno, string Userid)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_OPERATION_DELETE_MANAGEPOT_SLIPNO"
             , new string[] { "@TAPSLIPNO", "@USERID" }
                , new string[] { Slipno, Userid });
            return Result;
        }
        #endregion




        #region Empty Vehicle
        public DataTable Get_Vehicle_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_EMPTY_WEIGHMENT_SAVE"
             , new string[] { "@ENTRYSTATUS" }
                , new string[] { "BindVehicle" });
            return dt;
        }
        public string Save_Assign_TapSlip(string Vehicleno, string Userid)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_OPERATION_EMPTY_WEIGHMENT_SAVE"
             , new string[] { "@VECHNO", "@USERID", "@ENTRYSTATUS" }
                , new string[] { Vehicleno, Userid, "Assign" });
            return Result;
        }
        public string Save_Weighment_Details(string SLIPNO, string VEHICLEWT, string WEIGHMENTWB, string WEIGHMENTID, string WEIGHMENTMAC,
                                        string WEIGHMENTRFID, string WEIGHMENTTIME, string ISAUTOENTRY)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_OPERATION_EMPTY_WEIGHMENT_SAVE"
             , new string[] { "@SLIPNO","@VEHICLEWT","@WEIGHMENTWB","@WEIGHMENTID","@WEIGHMENTMAC",
                            "@WEIGHMENTRFID","@WEIGHMENTTIME","@ISAUTOENTRY", "@ENTRYSTATUS" }
                , new string[] { SLIPNO,VEHICLEWT,WEIGHMENTWB,WEIGHMENTID,WEIGHMENTMAC,
                                WEIGHMENTRFID,WEIGHMENTTIME,ISAUTOENTRY,"Weighment" });
            return Result;
        }
        public DataTable Report_Empty_Weighment_Details(string SDate, string EDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_EMPTY_WEIGHMENT_SAVE"
             , new string[] { "@SDATE", "@EDATE", "@ENTRYSTATUS" }
                , new string[] { SDate, EDate, "Report" });
            return dt;
        }
        #endregion




        #region Vehicle Ladle Assignment 
        public DataTable Get_Laddle_List_Assignment()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_VEHICLE_LADLE_ASSIGNMENT");
            return dt;
        }

        public string Save_Ladle_Vehicle_Assignment(string TAPSLIPNO, string LADLENO, string DRIVERID, string VECHNO, string LOCATION, string USERID, string ENTRYTYPE, string TRIPTYPE)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_OPERATION_VEHICLE_LADLE_ASSIGNMENT_SAVE"
             , new string[] { "@TAPSLIPNO", "@LADLENO", "@DRIVERID", "@VECHNO", "@LOCATION", "@USERID", "@ENTRYTYPE", "@TRIPTYPE" }
                , new string[] { TAPSLIPNO, LADLENO, DRIVERID, VECHNO, LOCATION, USERID, ENTRYTYPE, TRIPTYPE });
            return Result;
        }

        #endregion



        #region REPORT SECTION

        public DataTable Rpt_Tapping_Pending_Pot(string SDATE,string SHIFT,string POTLINE,string SECTION)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_TAPPING_PENDING_POT"
             , new string[] { "@SDATE","@SHIFT","@POTLINE","@SECTION" }
                , new string[] { SDATE,SHIFT,  POTLINE, SECTION });
            return dt;
        }

        public DataTable Rpt_Poroduction_Consumption(string TAPDATE, string TAPLINE)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_POT_PRODUCTION_CONSUMPTION"
             , new string[] { "@TAPDATE", "@TAPLINE"}
                , new string[] { TAPDATE, TAPLINE });
            return dt;
        }
        public DataTable Rpt_Poroduction_Consumption_6Month_Summary( string TAPLINE)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_POT_PRODUCTION_CONSUMPTION_6MONTH_AVG"
             , new string[] {  "@TAPLINE" }
                , new string[] {  TAPLINE });
            return dt;
        }


        public DataTable Rpt_Tapping_Pending_Sheet(string SDATE, string SHIFT, string POTLINE, string SECTION)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_TAPPING_PENDING_POT"
             , new string[] { "@SDATE", "@SHIFT", "@POTLINE", "@SECTION" }
                , new string[] { SDATE, SHIFT, POTLINE, SECTION });
            return dt;
        }

        #endregion



    }
}