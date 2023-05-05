using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace BalcoHRA.Business_Layer.CastHouse.Planning
{
    public class BL_CH_Planning
    {
        FPManager cn = new FPManager();

        #region GENERATE PLAN
        public DataTable Fetch_Metal_Available(string Date,string Shift)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_QTY_AVAILABLE"
              , new string[] { "@DATE","@SHIFT" }
              , new string[] { Date,Shift });
            return dt;
        }
        public DataTable Fetch_Furnace_Details(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_MASTER_FURNACE"
              , new string[] { "@ENTRYSTATUS", "@ID" }
              , new string[] { "View", Id });
            return dt;
        }
        public DataTable Fetch_Product_Details(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_MASTER_PRODUCT"
              , new string[] { "@ENTRYSTATUS", "@ID" }
              , new string[] { "View", Id });
            return dt;
        }
        public bool Save_Temp_CastNo(string FURNAME, string CastNo)
        {
            bool Result ;
            Result = cn.ExecuteQuerySP("SP_CH_MASTER_FURNACE"
                , new string[] { "@FURNAME", "@TEMPCASTNO", "@ENTRYSTATUS" }
                , new string[] { FURNAME, CastNo, "UpdateTempCast" });
            return Result;
        }
        public bool Save_Demand(string Date, string Shift,string Location,string Furnace,string Product,string TotalQty,string Castno,string PlanTime,string Fe,string Si,string Potline,string UserId)
        {
            bool Result;
            Result = cn.ExecuteQuerySP("SP_CH_TRANS_PLANNING_GENERATE_DEMAND"
                , new string[] { "@DATE", "@SHIFT", "@LOCATION","@FURNACE","@PRODUCT","@TOTALQTY","@CASTNO","@PLAN_TIME","@REQUESTED_FE","@REQUESTED_SI","@POTLINE","@ENTRY_BY_ID" }
                , new string[] { Date,  Shift,  Location,Furnace,  Product,  TotalQty,  Castno,  PlanTime,  Fe,  Si,  Potline,  UserId });
            return Result;
        }

        public string Delete_Demand(string ID, string UserId)
        {
            string Result="";

            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_TRANS_PLANNING_DELETE_DEMAND"
                , new string[] { "@ID", "@USERID"}
                , new string[] { ID, UserId});

            return Result;
        }
        public bool Active_Inactive_Demand(string ID, string STATUS)
        {
            bool Result = false;

            Result = cn.ExecuteQuerySP("SP_CH_TRANS_PLANNING_ACTIVE_INACTIVE_DEMAND"
                , new string[] { "@ID", "@STATUS" }
                , new string[] { ID, STATUS });

            return Result;
        }

        public string Save_Demand_Datatable(DataTable dt, string StoreprocedureName, string[] dtParam, string[] SrvParam)
        {
            string Result;
            Result = cn.Excute_DataTable(dt, StoreprocedureName, dtParam, SrvParam);
               
            return Result;
        }

        #endregion


        #region Furnace planning Report
        public DataTable Fetch_Planning_List(string Date,string Shift,string Location)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_REPORT_PLANNING_FURNACE"
              , new string[] { "@DATE", "@SHIFT","@LOCATION" }
              , new string[] { Date,Shift,Location });
            return dt;
        }
        public DataTable Fetch_Planning_Details( string ID)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_REPORT_PLANNING_FURNACE"
              , new string[] { "@ID" }
              , new string[] { ID });
            return dt;
        }
        public DataTable Fetch_Planning_Slip_Mapping(string ID)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_REPORT_PLANNING_FURNACE_TAPSLIP_MAPPING"
              , new string[] { "@TID" }
              , new string[] { ID });
            return dt;
        }
        #endregion
    }
}