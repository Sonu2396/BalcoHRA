using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BalcoHRA.Business_Layer;
namespace BalcoHRA.Business_Layer
{
    public class BL_Activity
    {
        FPManager cn = new FPManager();

        public DataTable Get_ActivityList()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_ACTIVITY"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Activity_Save(string Activity, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_ACTIVITY"
                , new string[] { "@ActivityName", "@CreatedBy", "@ENTRYSTATUS" }
                , new string[] { Activity, userid, Entrystatus });
            return Result;
        }
        public string Activity_Update(string ID, string Activity, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_ACTIVITY"
                , new string[] { "@ActivityID", "@ActivityName", "@ModifiedBy", "@ENTRYSTATUS" }
                , new string[] { ID, Activity, userid, Entrystatus });
            return Result;
        }
        public string Activity_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_ACTIVITY"
                , new string[] { "@ActivityID", "@CreatedBy", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }

    }
}