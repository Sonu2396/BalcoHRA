using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BalcoHRA.Business_Layer
{
    public class BL_ROLEMAPPING
    {
        FPManager cn = new FPManager();

        public DataTable GridView_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_ADMIN_ROLE_MAPPING"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "View" });
            return dt;
        }
        public DataTable GridView_List_Asper_Role(string Roleid)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_ADMIN_ROLE_MAPPING"
              , new string[] { "@ENTRYSTATUS","@ROLEID" }
              , new string[] { "Role", Roleid });
            return dt;
        }
        public string RoleMapping_Save(string Roleid,string Menuid, string SubmenuId, string UnderSubmenuid,string childmnenid,  string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_ADMIN_ROLE_MAPPING"
               , new string[] {"ROLEID", "@MenuId", "@SUBMENUID", "@UNDERSUBMENUID","@CHILDMENUID", "@ENTRYSTATUS" }
               , new string[] {Roleid,Menuid, SubmenuId, UnderSubmenuid,childmnenid,  Entrystatus });
            return Result;
        }
        public string RoleMapping_Update(string Id,string Roleid, string Menuid, string SubmenuId, string UnderSubmenuid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_ADMIN_ROLE_MAPPING"
               , new string[] { "@ID","ROLEID", "@MenuId", "@SUBMENUID", "@UNDERSUBMENUID", "@ENTRYSTATUS" }
               , new string[] {Id, Roleid, Menuid, SubmenuId, UnderSubmenuid, Entrystatus });
            return Result;
        }
        public string RoleMapping_Delete(string ID,  string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_ADMIN_ROLE_MAPPING"
               , new string[] { "@ID",  "@ENTRYSTATUS" }
               , new string[] { ID,  Entrystatus });
            return Result;
        }
    }
}