using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BalcoHRA.Business_Layer;
namespace BalcoHRA.Business_Layer.UserMgt
{
    public class BL_SUBArea
    {
        FPManager cn = new FPManager();

        public DataTable Get_AreaList()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_SUB_AREA"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Area_Save(string Area, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_SUB_AREA"
                , new string[] { "@AreaName", "@CreatedBy", "@ENTRYSTATUS" }
                , new string[] { Area, userid, Entrystatus });
            return Result;
        }
        public string Area_Update(string ID, string Area, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_SUB_AREA"
                , new string[] { "@AreaID", "@AreaName", "@ModifiedBy", "@ENTRYSTATUS" }
                , new string[] { ID, Area, userid, Entrystatus });
            return Result;
        }
        public string Area_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_SUB_AREA"
                , new string[] { "@AreaID", "@CreatedBy", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }

    }
}