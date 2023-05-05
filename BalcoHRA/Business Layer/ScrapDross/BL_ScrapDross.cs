using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BalcoHRA.Business_Layer.ScrapDross
{
    public class BL_ScrapDross
    {
        FPManager cn = new FPManager();
        HotmetalManager Hmt = new HotmetalManager();

        #region Product Details Start..........
        public DataTable Get_ProductList()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_SCRAP_MASTER_PRODUCT"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Product_Save(string Name,  string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_SCRAP_MASTER_PRODUCT"
                , new string[] { "@PRODNAME",  "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { Name, isactive, userid, Entrystatus });
            return Result;
        }
        public string Product_Update(string ID, string Name,   string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_SCRAP_MASTER_PRODUCT"
                , new string[] { "@ID", "@PRODNAME", "@IsActive", "@MODIFIEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, Name, isactive, userid, Entrystatus });
            return Result;
        }
        public string Product_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_SCRAP_MASTER_PRODUCT"
                , new string[] { "@ID", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }

        #endregion  Product Details End******


        #region Location Details Start..........
        public DataTable Get_LocationList()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_SCRAP_MASTER_LOCATION"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Location_Save(string Name, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_SCRAP_MASTER_LOCATION"
                , new string[] { "@SCRAPLOCATION", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { Name, isactive, userid, Entrystatus });
            return Result;
        }
        public string Location_Update(string ID, string Name, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_SCRAP_MASTER_LOCATION"
                , new string[] { "@ID", "@SCRAPLOCATION", "@IsActive", "@MODIFIEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, Name, isactive, userid, Entrystatus });
            return Result;
        }
        public string Location_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_SCRAP_MASTER_LOCATION"
                , new string[] { "@ID", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }

        #endregion lOCATION Details End******

        public DataTable DropDownlist_Vehicle()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_MASTER_VEHICLE", new string[] { "@ENTRYSTATUS" }, new string[] { "DropDown" });
            return dt;
        }
        public DataTable DropDownlist_Product()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_SCRAP_MASTER_PRODUCT", new string[] { "@ENTRYSTATUS" }, new string[] { "DropDown" });
            return dt;
        }
        public DataTable DropDownlist_Location()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_SCRAP_MASTER_LOCATION", new string[] { "@ENTRYSTATUS" }, new string[] { "DropDown" });
            return dt;
        }
        public DataTable DropDownlist_LotNo()
        {
            DataTable dt = new DataTable();
            dt = Hmt.GetDataTable("SP_DROSS_CHALLAN");
            return dt;
        }
        public string ScrapDross_Save(string vehicleno, string product, string fromarea, string toarea, string remarks, string challanno, string recovery, string isdross, string userid)
        {
            
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_SCRAP_DROSS_TRANSACTION"
                , new string[] { "@VehicleNo", "@Product", "@From", "@To", "@Remarks", "@ChallanNo", "@recovery",  "@IsDross", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { vehicleno, product, fromarea, toarea, remarks, challanno, recovery, isdross, userid, "Save" });
            return Result;
        }
        public string ScrapDross_Update(string Slipno, string vehicleno, string product, string fromarea, string toarea, string remarks, string challanno, string recovery, string isdross, string userid)
        {

            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_SCRAP_DROSS_TRANSACTION"
                , new string[] { "@ScrapSlipno","@VehicleNo", "@Product", "@From", "@To", "@Remarks", "@ChallanNo", "@recovery", "@IsDross", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { Slipno,vehicleno, product, fromarea, toarea, remarks, challanno, recovery, isdross, userid, "Update" });
            return Result;
        }
        public string ScrapDross_Delete(string ScrapSlipno,string Userid)
        {

            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_SCRAP_DROSS_TRANSACTION"
                , new string[] { "@ScrapSlipno","@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ScrapSlipno,Userid, "Delete" });
            return Result;
        }

        public DataTable Report_ScrapDross(string sdate,string edate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_SCRAP_REPORT"
                , new string[] { "@SDATE", "@EDATE" }
                , new string[] { sdate,edate});
            return dt;
        }
        public DataTable Report_ScrapDross_SlipDtails(string Scrapslipno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_SCRAP_REPORT_SLIPDETAILS"
                , new string[] { "@SLIPNO"}
                , new string[] { Scrapslipno });
            return dt;
        }

        #region Dashboard
        public DataTable Dashboard_Scrap_Dross_DMY(string ReportType)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_DASHBOARD_SCRAP_TOTAL_SEND_DMY"
                , new string[] { "@REPORTTYPE" }
                , new string[] { ReportType });
            return dt;
        }
        public DataTable Dashboard_Scrap_Dross_DayWise_Month()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_DASHBOARD_SCRAP_TOTAL_SEND_DATEWISE");
            return dt;
        }
        #endregion
    }
}