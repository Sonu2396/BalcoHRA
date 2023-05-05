using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BalcoHRA.Business_Layer;
namespace BalcoHRA.Business_Layer.UserMgt
{
    public class BL_Role
    {
        FPManager cn = new FPManager();
       
        public DataTable Get_RoleList()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_ROLE"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Role_Save(string Role,  string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_ROLE"
                , new string[] { "@ROLENAME",  "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { Role,  userid, Entrystatus });
            return Result;
        }
        public string Role_Update(string ID, string Role,  string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_ROLE"
                , new string[] { "@ROLEID", "@ROLENAME",  "@MODIFIEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, Role,  userid, Entrystatus });
            return Result;
        }
        public string Role_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_ROLE"
                , new string[] { "@ROLEID", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }
        
    }
}