using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

namespace BalcoHRA.Business_Layer.CastHouse.ManageLadle
{
    public class BL_ManageLadle
    {
        
        FPManager cn = new FPManager();




        #region Release Ladle
        public DataTable Fetch_ReleaseLade_User_Aunthenticate(string USERID)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TR_FETCH_RELEASE_LADLE_AUNTHENTIC_USER"
                , new string[] { "@USERID" }
                , new string[] { USERID});
            return dt;
        }
        public DataTable Bind_Dropdown_ReleaseLade_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TR_RELEASE_LADLE_LIST");
            return dt;
        }
        public DataTable Bind_Dropdown_ReleaseVehicle_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TR_RELEASE_VEHICLE_LIST");
            return dt;
        }

        public DataTable Report_ReleaseVehicle_List(string SDATE,string EDATE,string REPORTTYPE,string FILTERTEXT)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_REPORT_RELEASE_LADLE_VEHICLE"
                , new string[] { "@SDATE", "@EDATE", "@REPORTTYPE", "@FILTERTEXT" }
                , new string[] { SDATE, EDATE, REPORTTYPE, FILTERTEXT });
            return dt;
        }
        public string Save_Release_Ladle(string ENTRYMODE,string SLIPNO, string VEHICLENO, string LADLENO,string ENRTYBY)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_TR_SAVE_RELEASE_LADLE"
                , new string[] {"@ENTRYMODE", "@SLIPNO", "@VEHICLENO", "@LADLENO","@ENRTYBY" }
                , new string[] { ENTRYMODE,SLIPNO, VEHICLENO, LADLENO, ENRTYBY });
            return Result;
        }
        #endregion

        #region Weighment Approval
        
        public DataTable Bind_Dropdown_Weighment_Approval_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TR_LADLE_WEIGHMENT_APPROVAL_LIST");
            return dt;
        }

        public string Save_Weighment_Approval_Ladle(string SLIPNO, string LADLENO, string ALLOWBY)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_TR_SAVE_LADLE_WEIGHMENT_APPROVAL_LIST"
                , new string[] {  "@SLIPNO", "@LADLENO", "@ALLOWBY" }
                , new string[] {  SLIPNO,  LADLENO, ALLOWBY });
            return Result;
        }
        #endregion


        #region Ladle Re-pouring 

        public DataTable Bind_Dropdown_Ladle_Repouring_Ladle_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TR_LADLE_REPOURING_LIST");
            return dt;
        }
        public DataTable Bind_Dropdown_Ladle_Repouring_Vehicle_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TR_VEHICLE_REPOURING_LIST");
            return dt;
        }
        public DataTable Bind_Ladle_Repouring_List(string LADLENO)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TR_LADLE_FOR_REPOURING_LIST"
                , new string[] { "@LADLENO" }
                , new string[] { LADLENO});
            return dt;
        }

        public string Save_Ladle_Repouring(string SLIPNO,string VEHICLENO, string LADLENO, string USERID)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_TR_SAVE_LADLE_REPOURING"
                , new string[] { "@SLIPNO","@VEHICLENO", "@LADLENO", "@USERID" }
                , new string[] { SLIPNO, VEHICLENO, LADLENO, USERID });
            return Result;
        }
        #endregion



        #region Ladle pouring 

       
        public DataTable Bind_Ladle_Pouring_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TR_LADLE_FOR_REPOURING_LIST");
            return dt;
        }

        public string Save_Ladle_Pouring(string SLIPNO, string VEHICLENO, string LADLENO, string USERID)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_TR_SAVE_LADLE_REPOURING"
                , new string[] { "@SLIPNO", "@VEHICLENO", "@LADLENO", "@USERID" }
                , new string[] { SLIPNO, VEHICLENO, LADLENO, USERID });
            return Result;
        }
        #endregion


        #region Slip Assignment
        public DataTable Bind_DropdownList_CastHouse()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TR_SLIP_ASSIGN_FURNACE_LOCATION_NEW"
                , new string[] { "@Type" }
                , new string[] { "Location" });
            return dt;
        }
        public DataTable Bind_DropdownList_Furnace(string Location)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TR_SLIP_ASSIGN_FURNACE_LOCATION_NEW"
                , new string[] { "@Type","@LOCATION" }
                , new string[] { "Furnace",Location });
            return dt;
        }
        public DataTable Bind_DropdownList_CastNo(string Location,string Furnace)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TR_SLIP_ASSIGN_FURNACE_LOCATION_NEW"
                , new string[] { "@Type", "@LOCATION","@Furnace" }
                , new string[] { "CastNo", Location, Furnace });
            return dt;
        }
        public DataTable Bind_Pending_Ladle(string Location)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TR_SLIP_ASSIGN_FURNACE_LOCATION_NEW"
                , new string[] { "@Type", "@LOCATION"}
                , new string[] { "PendingLalde", Location });
            return dt;
        }

        public DataTable Bind_Assing_Ladle_Furnace_List(string Location, string Furnace,string CastNo)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_TR_SLIP_ASSIGN_FURNACE_LOCATION_NEW"
                , new string[] { "@Type", "@LOCATION","@FURNACE","@CASTNO" }
                , new string[] { "AssignLalde", Location,Furnace,CastNo });
            return dt;
        }
        public DataTable Fetch_Product(string fe, string si, string purity)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_GET_PRODUCT"
                , new string[] { "@fe", "@si","@purity" }
                , new string[] { fe,si,purity });
            return dt;
        }
        public DataTable Fetch_Suitable_Product(string fe, string si, string ti,string v)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_GET_SUITABLE_PRODUCT"
                , new string[] { "@FFE", "@FSI", "@FTI","@FV" }
                , new string[] { fe, si, ti,v });
            return dt;
        }
        public bool Save_Ladle_Assignment(string Slipno,string TOTALQTY,string LOCATION,string FURNACE,string CASTNO,string CASTCLOSE,string TAPSLIPNO,string FINALFE,string FINALSI,string FINALTI,string FINALV,
         string FINALTIV,string FINALMN,string FINALZN,string FINALCU,string FINALCR,string FINALZR,string FINALB,string FINALGA,string FINALNA,string FINALNI,
         string FINALMG,string FINALSR,string FINALAI,string FINALPB,string FINALSN,string FINALBE,string FINALCO,string FINALP1,string FINALLI,string TOTALTAPWT,
         string TOTALNETWT,string FINALPURITY,string FINALPRODUCT,string SUITABLEPRODUCT,string USERID)
        {
            bool Result =false;
            Result = cn.ExecuteQuerySP("SP_CH_TR_SAVE_SLIPASSIGNMENT"
                , new string[] { "@Slipno", "@TOTALQTY", "@LOCATION", "@FURNACE", "@CASTNO", "@CASTCLOSE", "@TAPSLIPNO", "@FINALFE", "@FINALSI","@FINALTI", "@FINALV",
                                "@FINALTIV", "@FINALMN", "@FINALZN", "@FINALCU", "@FINALCR", "@FINALZR", "@FINALB", "@FINALGA", "@FINALNA", "@FINALNI",
                                "@FINALMG", "@FINALSR", "@FINALAI", "@FINALPB", "@FINALSN", "@FINALBE", "@FINALCO", "@FINALP1", "@FINALLI", "@TOTALTAPWT",
                                "@TOTALNETWT", "@FINALPURITY", "@FINALPRODUCT", "@SUITABLEPRODUCT", "@USERID" }
                , new string[] { Slipno, TOTALQTY, LOCATION, FURNACE, CASTNO, CASTCLOSE, TAPSLIPNO, FINALFE, FINALSI,FINALTI, FINALV,
                                FINALTIV, FINALMN, FINALZN, FINALCU, FINALCR, FINALZR, FINALB, FINALGA, FINALNA, FINALNI,
                                FINALMG, FINALSR, FINALAI, FINALPB, FINALSN, FINALBE, FINALCO, FINALP1, FINALLI, TOTALTAPWT,
                                TOTALNETWT, FINALPURITY, FINALPRODUCT, SUITABLEPRODUCT, USERID });
            return Result;
        }


        public bool Save_Ladle_Assignment_Alloy_Add(string Slipno, string CUSTID, string LOCATION, string FURNACENO, string CASTNO, 
            string FINALFE, string FINALSI, string FINALTI, string FINALV,string FINALTIV, 
            string FEREQUIRED, string BORONREQUIRED, string SIREQUIRED, string MGREQUIRED, string TIREQUIRED, string SRREQUIRED, 
            string ACTFEREQUIRED, string ACTBORONREQUIRED, string ACTSIREQUIRED,
       string ACTMGREQUIRED, string ACTTIREQUIRED, string ACTSRREQUIRED,  string USERID)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_CH_TR_SAVE_FURNACE_CAST_ALLOY_ADD"
                , new string[] { "@TAPSLIPNOLIST", "@CUSTID", "@LOCATION", "@FURNACENO", "@CASTNO",
                                 "@FINALFE", "@FINALSI","@FINALTI", "@FINALV","@FINALTIV",
                                 "@FEREQUIRED", "@BORONREQUIRED", "@SIREQUIRED", "@MGREQUIRED", "@TIREQUIRED", "@SRREQUIRED",
                                "@ACTFEREQUIRED", "@ACTBORONREQUIRED", "@ACTSIREQUIRED",
                                "@ACTMGREQUIRED", "@ACTTIREQUIRED", "@ACTSRREQUIRED", "@CREATEDBY" }
                , new string[] { Slipno, CUSTID, LOCATION, FURNACENO, CASTNO,
                                 FINALFE, FINALSI,FINALTI, FINALV,FINALTIV,
                                 FEREQUIRED, BORONREQUIRED, SIREQUIRED, MGREQUIRED, TIREQUIRED, SRREQUIRED,
                                 ACTFEREQUIRED, ACTBORONREQUIRED, ACTSIREQUIRED,
                                ACTMGREQUIRED, ACTTIREQUIRED, ACTSRREQUIRED, USERID,"Save" });
            return Result;
        }

        #endregion

        #region Verify Tapslip
        public DataTable Get_Customer_Details(string CustId)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select* from MST_CH_CUSTOMER where id=" + CustId + "");
            return dt;
        }
        public DataTable Get_Customer_Product_Details(string product)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from MST_CH_CUSTOMER where product='"+ product + "' order by custname");
            return dt;
        }
      
        public DataTable VerifyTapslip_load_Data(string SDATE,string EDATE,string SHIFT, string POTLINE,string SECTION,string LOCATION)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_VERIFY_WEIGHT_POTLINE_CASTHOUSE"
                , new string[] { "@SDATE","@EDATE","@SHIFT","@POTLINE","@SECTION","@LOCATION","@ENTRYSTATUS","@ENTRYTYPE"}
                , new string[] { SDATE, EDATE, SHIFT, POTLINE , SECTION, LOCATION , "CastHouse" , "List" });
            return dt;
        }
        public bool VerifyTapslip_Save(string SLIPNO, string APPROVEID)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_VERIFY_WEIGHT_POTLINE_CASTHOUSE"
                , new string[] { "@SLIPNO", "@APPROVEID", "@ENTRYSTATUS", "@ENTRYTYPE" }
                , new string[] { SLIPNO, APPROVEID, "CastHouse", "Approve" });
            return Result;
        }
        #endregion
    }
}