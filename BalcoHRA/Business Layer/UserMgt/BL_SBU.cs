using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BalcoHRA.Business_Layer;
namespace BalcoHRA.Business_Layer.UserMgt
{
    public class BL_SBU
    {
        FPManager cn = new FPManager();

        public DataTable Get_SBUList()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_SBU"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string SBU_Save(string SBU, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_SBU"
                , new string[] { "@SBUName", "@CreatedBy", "@ENTRYSTATUS" }
                , new string[] { SBU, userid, Entrystatus });
            return Result;
        }
        public string SBU_Update(string ID, string SBU, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_SBU"
                , new string[] { "@SBUID", "@SBUName", "@ModifiedBy", "@ENTRYSTATUS" }
                , new string[] { ID, SBU, userid, Entrystatus });
            return Result;
        }
        public string SBU_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_SBU"
                , new string[] { "@SBUID", "@CreatedBy", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }

    }
}