using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BalcoHRA.Business_Layer;
namespace BalcoHRA.Business_Layer.HMEdit
{
    public class BL_HMEdit
    {
        FPManager cn = new FPManager();
        public DataSet Get_Tapslip_Details(string TAPSLIPNO)
        {
            DataSet ds = new DataSet();
            ds = cn.GetDataSet("SP_HMEDIT_TAPSLIP_DETAILS_DATA"
              , new string[] { "@TAPSLIPNO" }
              , new string[] { TAPSLIPNO });
            return ds;
        }
        public DataTable Get_Tapslipno_Edit()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_HMEDIT_TAPSLIP_GROSS_TARE_NOTDONE");
            return dt;
        }
       
        public DataTable Get_CastNo(string Date, string Location,string Furnace)
        {

            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select distinct convert(nvarchar, CASTNO) as CASTNO,1 as id from TBL_FURNACE_PLANING_DATA  where FORMAT(date, 'yyyy-MM-dd') = '" + Date + "' and LOCATION = '" + Location + "' and FURNACE = '" + Furnace + "' order by CASTNO");
            return dt;

            
        }
        public string Save_HmEdit_New_Edit_WBData(string TAPSLIPNO,  string LADLENO, string GRVECHNO, string GROSSWT, string GROSSWTTIME, string TRVECHNO, string TAREWT, string TAREWTDATETIME,
                                                     string CALIBRATIONMODE,string RECEIPTBY,string SOURCE,string LOCATION,string POTNO,string REQUESTBY,string REQUESTMODE,string REQUESTTYPE)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_HMEDIT_SAVE_NEW_EDIT_REQUEST_LADDLE"
                , new string[] { "@TAPSLIPNO",  "@LADLENO", "@GRVECHNO", "@GROSSWT", "@GROSSWTTIME", "@TRVECHNO", "@TAREWT", "@TAREWTDATETIME" ,
                                 "@CALIBRATIONMODE","@RECEIPTBY","@SOURCE","@LOCATION","@POTNO","@REQUESTBY","@REQUESTMODE","@REQUESTTYPE"}
                , new string[] { TAPSLIPNO,  LADLENO, GRVECHNO, GROSSWT, GROSSWTTIME, TRVECHNO, TAREWT, TAREWTDATETIME,
                                  CALIBRATIONMODE,RECEIPTBY,SOURCE,LOCATION,POTNO,REQUESTBY,REQUESTMODE,REQUESTTYPE});
            return Result;
        }
        public bool Save_HmEdit_New_Edit_Plan_Data(string SLIPNO, string TAPSLIPNO, string TRANSID, string DATE, string SHIFT, string LOCATION, string LINE, string POT_NO, string FE, string SI,string TI,string V,string FTI_V,string PURITY,
                                                     string FFE, string FSI, string FTI, string FV,string FPURITY, string FINAL_GRADE, string ALLOCATEDWT,string FTOTWT,
                                                     string SLIPBY, string LADDLENO, string FURNACE, string TAP_START_TIME, string TAP_END_TIME, string FLAG, string POTID,string REQUESTBY,string VEHICLENO,string CASTNO, string REQUESTMODE, string REQUESTTYPE)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_HMEDIT_SAVE_NEW_EDIT_REQUEST_PLAN"
                , new string[] { "@SLIPNO", "@TAPSLIPNO","@TRANSID",  "@DATE", "@SHIFT", "@LOCATION", "@LINE", "@POT_NO", "@FE", "@SI" ,"@TI","@V","@FTI_V","@PURITY",
                                 "@FFE","@FSI","@FTI","@FV","@FPURITY","@FINAL_GRADE","@ALLOCATEDWT","@FTOTWT",
                                 "@SLIPBY","@LADDLENO","@FURNACE","@TAP_START_TIME","@TAP_END_TIME","@FLAG","@POTID","@REQUESTBY","@VEHICLENO","@CASTNO","@REQUESTMODE","@REQUESTTYPE"}
                , new string[] { SLIPNO,TAPSLIPNO,TRANSID,  DATE, SHIFT, LOCATION, LINE, POT_NO, FE, SI,TI,V,FTI_V,PURITY,
                                  FFE,FSI,FTI,FV,FPURITY,FINAL_GRADE,ALLOCATEDWT,FTOTWT,
                                  SLIPBY,LADDLENO,FURNACE,TAP_START_TIME,TAP_END_TIME,FLAG,POTID,REQUESTBY,VEHICLENO,CASTNO,REQUESTMODE,REQUESTTYPE});
            return Result;
        }

        public bool Delete_HmEdit_Withoutslip_Transid(string TRANSID)
        {
            bool Result = false;
            Result = cn.ExecuteQuery("DELETE FROM TBL_HOTMETAL_EDIT_VEHICLE_LADLE WHERE TRANSID='" + TRANSID + "';DELETE FROM TBL_HOTMETAL_EDIT_FURNANCE_PRE_PLAN WHERE TRANSID='" + TRANSID + "'");
            return Result;
        }

        public bool Save_HmEdit_Calibration_WBData(string TAPSLIPNO, string LADLENO, string GRVECHNO, string GROSSWT, string GROSSWTTIME, string TRVECHNO, string TAREWT, string TAREWTDATETIME,
                                                     string CALIBRATIONMODE, string RECEIPTBY, string SOURCE, string LOCATION, string POTNO, string REQUESTBY)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_HMEDIT_SAVE_CALIBRATION_REQUEST_LADDLE"
                , new string[] { "@TAPSLIPNO",  "@LADLENO", "@GRVECHNO", "@GROSSWT", "@GROSSWTTIME", "@TRVECHNO", "@TAREWT", "@TAREWTDATETIME" ,
                                 "@CALIBRATIONMODE","@RECEIPTBY","@SOURCE","@LOCATION","@POTNO","@REQUESTBY"}
                , new string[] { TAPSLIPNO,  LADLENO, GRVECHNO, GROSSWT, GROSSWTTIME, TRVECHNO, TAREWT, TAREWTDATETIME,
                                  CALIBRATIONMODE,RECEIPTBY,SOURCE,LOCATION,POTNO,REQUESTBY});
            return Result;
        }
        public bool Save_HmEdit_Calibration_Plan_Data(string TRID, string SLIPNO, string TAPSLIPNO, string DATE, string SHIFT, string LOCATION, string LINE, string POT_NO, string FE, string SI, string TI, string V, string FTI_V, string PURITY,
                                                     string FFE, string FSI, string FTI, string FV, string FPURITY, string FINAL_GRADE, string ALLOCATEDWT, string FTOTWT,
                                                     string SLIPBY, string LADDLENO, string FURNACE, string TAP_START_TIME, string TAP_END_TIME, string FLAG, string POTID, string REQUESTBY, string VEHICLENO, string CASTNO)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_HMEDIT_SAVE_CALIBRATION_REQUEST_PLAN"
                , new string[] {"@TRANSID", "@SLIPNO", "@TAPSLIPNO",  "@DATE", "@SHIFT", "@LOCATION", "@LINE", "@POT_NO", "@FE", "@SI" ,"@TI","@V","@FTI_V","@PURITY",
                                 "@FFE","@FSI","@FTI","@FV","@FPURITY","@FINAL_GRADE","@ALLOCATEDWT","@FTOTWT",
                                 "@SLIPBY","@LADDLENO","@FURNACE","@TAP_START_TIME","@TAP_END_TIME","@FLAG","@POTID","@REQUESTBY","@VEHICLENO","@CASTNO"}
                , new string[] { TRID,SLIPNO,TAPSLIPNO,  DATE, SHIFT, LOCATION, LINE, POT_NO, FE, SI,TI,V,FTI_V,PURITY,
                                  FFE,FSI,FTI,FV,FPURITY,FINAL_GRADE,ALLOCATEDWT,FTOTWT,
                                  SLIPBY,LADDLENO,FURNACE,TAP_START_TIME,TAP_END_TIME,FLAG,POTID,REQUESTBY,VEHICLENO,CASTNO});
            return Result;
        }


        public bool Delete_HmEdit_Calibration_Transid(string POTNO,string TAPSLIPNO)
        {
            bool Result = false;
            Result = cn.ExecuteQuery("DELETE FROM TBL_FURNACE_PRE_PLAN_MASTER WHERE POT_NO='"+POTNO+"' AND SLIPNO='"+ TAPSLIPNO + "' ");
            return Result;
        }






        #region Pending Approve List
        public DataTable Pending_Approval_List(string REQUESTBY)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_HMEDIT_REPORT_REQUEST_APPROVE_PENDING"
              , new string[] { "@REQUESTBY" }
              , new string[] { REQUESTBY });
            return dt;
        }
        public DataTable Pending_Approval_Slip_Details(string ID)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_HMEDIT_REPORT_PENDING_SLIPDETAILS"
              , new string[] { "@ID" }
              , new string[] { ID });
            return dt;
        }
        public string Save_HmEdit_Approve(string ID, string USERID)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_HMEDIT_SAVE_REQUEST_AUTHORIZATION_APPROVE"
                , new string[] { "@ID", "@USERID" }
                , new string[] { ID, USERID });
            return Result;
        }
        public bool Save_HmEdit_Reject(string ID, string USERID)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_HMEDIT_SAVE_REQUEST_AUTHORIZATION_REJECT"
                , new string[] { "@ID", "@USERID" }
                , new string[] { ID, USERID });
            return Result;
        }
        public bool Save_HmEdit_Delete_247Hotmtal(string TAPSLIPNO)
        {
            bool Result = false;
            Result = cn.ExecuteQuery("delete from [HOTMETAL].[hotmetal].[dbo].[tbl_WeightDetails] where cardno='" + TAPSLIPNO + "';delete from [HOTMETAL].[hotmetal-ii].[dbo].[tbl_WeightDetails] where cardnumber='" + TAPSLIPNO + "'");
            return Result;
        }
        #endregion




        public DataTable Report_HMEdit_New_Edit_Delete_List(string SDATE,string EDATE,string POTLINE, string LOCATION, string REPORTTYPE, string AUTHSTATUS)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_HOTMETAL_EDIT_DELETE_NEW_REQUEST_LIST"
              , new string[] { "@SDATE", "@EDATE", "@POTLINE", "@LOCATION", "@REPORTTYPE", "@AUTHSTATUS" }
              , new string[] { SDATE, EDATE, POTLINE, LOCATION, REPORTTYPE, AUTHSTATUS});
            return dt;
        }



        #region HM Edit request
        public DataTable Check_Request_Pedning(string TAPSLIPNO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT * FROM TBL_HOTMETAL_EDIT_VEHICLE_LADLE WHERE TAPSLIPNO='"+ TAPSLIPNO + "' AND APPROVESTATUS1 IS NULL");
            return dt;
        }
        #endregion

    }
}