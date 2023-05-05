using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace BalcoHRA.Business_Layer.PotLine.Master
{
   
    public class BL_Master_Potline
    {

        FPManager cn = new FPManager();

        #region Tapping Location Details Start..........
        
        public DataTable Get_TappingLocation()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_MASTER_TAPPINGLOCATION"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string TappingLocation_Save(string Location, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_TAPPINGLOCATION"
                , new string[] { "@TAPPINGLOCATION", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { Location, isactive, userid, Entrystatus });
            return Result;
        }
        public string TappingLocation_Update(string ID, string Location, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_TAPPINGLOCATION"
                , new string[] { "@ID", "@TAPPINGLOCATION", "@IsActive", "@MODIFIEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, Location, isactive, userid, Entrystatus });
            return Result;
        }
        public string TappingLocation_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_TAPPINGLOCATION"
                , new string[] { "@ID", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }
        #endregion Tapping Location Details End.......... 

        #region Tapping Section Details Start..........
       
        public DataTable Get_TappingSection()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_MASTER_TAPPINGSECTION"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string TappingSection_Save(string Taping, string TapingSection, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_TAPPINGSECTION"
                , new string[] { "@TAPLINE", "@TAPSECTION", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { Taping, TapingSection, isactive, userid, Entrystatus });
            return Result;
        }
        public string TappingSection_Update(string ID, string Taping, string TapingSection, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_TAPPINGSECTION"
                , new string[] { "@ID", "@TAPLINE", "@TAPSECTION", "@IsActive", "@MODIFIEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, Taping, TapingSection, isactive, userid, Entrystatus });
            return Result;
        }
        public string TappingSection_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_TAPPINGSECTION"
                , new string[] { "@ID", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }

        #endregion Tapping  Section Details End..........


        #region pot no Details Start.......... 
        public DataTable Get_TappingPot()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_MASTER_TAPPINGPOTNO"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Potnumber_Save(string Taping, string TapingSection, string potno, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_TAPPINGPOTNO"
                , new string[] { "@TAPLINE", "@TAPSECTION", "@POTNO", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { Taping, TapingSection, potno, isactive, userid, Entrystatus });
            return Result;
        }
        public string Potnumber_Update(string ID, string Taping, string TapingSection, string potno, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_TAPPINGPOTNO"
                , new string[] { "@ID", "@TAPLINE", "@TAPSECTION", "@POTNO", "@IsActive", "@MODIFIEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, Taping, TapingSection, potno, isactive, userid, Entrystatus });
            return Result;
        }
        public string Potnumber_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_TAPPINGPOTNO"
                , new string[] { "@ID", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }

        #endregion Potno Details End..........


        #region Vehicle Master Details Start.......... 
        public DataTable Get_Vehicle()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_MASTER_VEHICLE"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Vehicle_Save(string Vechno, string Vechwt, string Rfidtagno, string Tapslipno, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_VEHICLE"
                , new string[] { "@VECHNO", "@VECHWT", "@RFIDTAGNO", "@TAPSLIPNO", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { Vechno, Vechwt, Rfidtagno, Tapslipno, isactive, userid, Entrystatus });
            return Result;
        }
        public string Vehicle_Update(string ID, string Vechno, string Vechwt, string Rfidtagno, string Tapslipno, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_VEHICLE"
                , new string[] { "@ID", "@VECHNO", "@VECHWT", "@RFIDTAGNO", "@TAPSLIPNO", "@IsActive", "@MODIFIEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, Vechno, Vechwt, Rfidtagno, Tapslipno, isactive, userid, Entrystatus });
            return Result;
        }
        public string Vehicle_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_VEHICLE"
                , new string[] { "@ID", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }

        #endregion Vehicle Master Details End.......... 

        #region Ladle Master Details Start.......... 
        public DataTable Get_Ladle()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_MASTER_LADLE"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Ladle_Save(string tapline, string ladlename, string capacity, string emptywt, string maxtarewt, string Tapslipno, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_LADLE"
                , new string[] { "@TAPLINE", "@LADLENAME", "@CAPACITY", "@EMPTYYMINCAPACITY", "@ALLOWEDMAXTAREWT", "@LADLESTATUS", "@TAPSLIPNO", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { tapline, ladlename, capacity, emptywt, maxtarewt, "0", Tapslipno, isactive, userid, Entrystatus });
            return Result;
        }
        public string Ladle_Update(string ID, string tapline, string ladlename, string capacity, string emptywt, string maxtarewt, string Tapslipno, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_LADLE"
                , new string[] { "@ID", "@TAPLINE", "@LADLENAME", "@CAPACITY", "@EMPTYYMINCAPACITY", "@ALLOWEDMAXTAREWT", "@LADLESTATUS", "@TAPSLIPNO", "@IsActive", "@MODIFIEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, tapline, ladlename, capacity, emptywt, maxtarewt, "0", Tapslipno, isactive, userid, Entrystatus });
            return Result;
        }
        public string Ladle_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_LADLE"
                , new string[] { "@ID", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }

        #endregion Ladle Master Details End.......... 





        #region Room no Details Start.......... 
        public DataTable Get_Room()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_MASTER_ROOMNO"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Room_Save(string POTLINE, string TAPSECTION, string ROOMNAME, string ROOMSHORTNAME, string SMSMobileNo, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_ROOMNO"
                , new string[] { "@POTLINE", "@TAPSECTION", "@ROOMNAME", "@ROOMSHORTNAME", "@SMSMobileNo", "@ENTRYSTATUS" }
                , new string[] { POTLINE, TAPSECTION, ROOMNAME, ROOMSHORTNAME, SMSMobileNo, Entrystatus });
            return Result;
        }
        public string Room_Update(string ID,string POTLINE, string TAPSECTION, string ROOMNAME, string ROOMSHORTNAME, string SMSMobileNo, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_MASTER_ROOMNO"
                , new string[] { "@ID","@POTLINE", "@TAPSECTION", "@ROOMNAME", "@ROOMSHORTNAME", "@SMSMobileNo", "@ENTRYSTATUS" }
                , new string[] { ID,POTLINE, TAPSECTION, ROOMNAME, ROOMSHORTNAME, SMSMobileNo, Entrystatus });
            return Result;
        }


        #endregion Room Details End..........

    }
}