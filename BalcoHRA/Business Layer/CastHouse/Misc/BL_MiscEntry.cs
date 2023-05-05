using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

namespace BalcoHRA.Business_Layer.CastHouse.Misc
{
    public class BL_MiscEntry
    {
        
        FPManager cn = new FPManager();

        #region Change Location Start..........
        public DataTable ChangeLocation_Get_Ladle()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_BIND_LADLE_CHANGE_LOCATION");
            return dt;
        }
        public DataTable ChangeLocation_Get_Location()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_BIND_LOCATION_BY_DEMAND");
            return dt;
        }
        public DataTable ChangeLocation_Get_SlipDetails (string Tapslipno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select  distinct location,ACTUAL_FE,LADDLENO from TBL_FURNACE_PRE_PLAN_MASTER where SLIPNO='" + Tapslipno  + "'");
            return dt;
        }
        public string ChangeLocation_Save(string TAPSLIPNO, string CHANGELOCATION, string Userid)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_TRANS_CHANGE_LOCATION"
                , new string[] { "@TAPSLIPNO", "@CHANGELOCATION", "@Userid" }
                , new string[] { TAPSLIPNO, CHANGELOCATION, Userid });
            return Result;
        }

        #endregion Change Location End******


        #region Push Tapslip to Hotmetal
        public string PushslipToHotmetal_Save(string TAPSLIPNO)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_WB_TRANS_INSERT_ON_HOTMETAL_SLIPNO"
                , new string[] { "@TAPSLIPNO" }
                , new string[] { TAPSLIPNO });
            return Result;
        }
        #endregion



    }
}