using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BalcoHRA.Business_Layer;
namespace BalcoHRA.Business_Layer.Checklist
{
    public class BL_ISO
    {
        FPManager cn = new FPManager();

        public DataTable Get_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MST_ISO"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Data_Save(string CriticalControl, string Objective, string Points, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MST_ISO"
                , new string[] { "@CriticalControl", "@Objective", "@Points", "@CreatedBy", "@ENTRYSTATUS" }
                , new string[] { CriticalControl, Objective, Points, userid, Entrystatus });
            return Result;
        }
        public string Data_Update(string ID, string CriticalControl, string Objective, string Points, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MST_ISO"
                , new string[] { "@CID", "@CriticalControl", "@Objective", "@Points", "@ModifiedBy", "@ENTRYSTATUS" }
                , new string[] { ID, CriticalControl, Objective, Points, userid, Entrystatus });
            return Result;
        }
        public string Data_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MST_ISO"
                , new string[] { "@CID", "@CreatedBy", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }

    }
}