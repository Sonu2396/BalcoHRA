using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BalcoHRA.Business_Layer;
namespace BalcoHRA.Business_Layer.UserMgt
{
    public class BL_Area
    {
        FPManager cn = new FPManager();

        public DataTable Get_DepartmentList()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_AREA"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Department_Save(string Department, string SBU, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_AREA"
                , new string[] { "@DepartmentName", "@SBUName","@CreatedBy", "@ENTRYSTATUS" }
                , new string[] { Department, SBU, userid, Entrystatus });
            return Result;
        }
        public string Department_Update(string ID, string Department, string SBU, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_AREA"
                , new string[] { "@DepartmentID", "@DepartmentName", "@SBUName", "@ModifiedBy", "@ENTRYSTATUS" }
                , new string[] { ID, Department, SBU, userid, Entrystatus });
            return Result;
        }
        public string Department_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_AREA"
                , new string[] { "@DepartmentID", "@CreatedBy", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }

    }
}