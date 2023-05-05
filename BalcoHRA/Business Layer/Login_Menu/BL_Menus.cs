using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BalcoHRA.Business_Layer
{
    public class BL_Menus
    {

        FPManager cn = new FPManager();

        #region Header Menu

       
        public DataTable Header_Menu_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_MENU_HEADER"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "View" });
            return dt;
        }
        public string Header_Menu_Save(string menuname,string Menuurl, string Submenu, string isactive,string userid,string Entrystatus)
        {
            string Result="";
           Result= cn.ExecuteQuerySP_Retrun_String("SP_MASTER_MENU_HEADER"
               , new string[] { "@MenuName","@Menuurl","@Submenu",  "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
               , new string[] { menuname, Menuurl, Submenu,  isactive, userid, Entrystatus });
            return Result;
        }
        public string Header_Menu_Update(string ID,string menuname,string Menuurl, string Submenu,  string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_MENU_HEADER"
                , new string[] { "@ID","@MenuName", "@Menuurl", "@Submenu", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID,menuname, Menuurl, Submenu, isactive, userid, Entrystatus });
            return Result;
        }
        public string Header_Menu_Delete(string ID,  string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_MENU_HEADER"
                , new string[] { "@ID", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID,  userid, Entrystatus });
            return Result;
        }
        #endregion

        #region Under Header Menu

        
        public DataTable UnderHeaderMenu_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_MENU_UNDER_HEADER"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "View" });
            return dt;
        }
        public string UnderHeaderMenu_Save(string menuname,string submenuname, string menuurl, string issubmenu, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_MENU_UNDER_HEADER"
               , new string[] { "@MenuId", "@MenuName", "@MenuUrl", "@Submenu", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
               , new string[] { menuname, submenuname, menuurl, issubmenu, isactive, userid, Entrystatus });
            return Result;
        }
        public string UnderHeaderMenu_Update(string ID, string menuname,string submenuname, string menuurl, string issubmenu, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_MENU_UNDER_HEADER"
             , new string[] { "@ID", "@MenuId", "@MenuName", "@MenuUrl", "@Submenu", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
             , new string[] { ID, menuname, submenuname, menuurl, issubmenu, isactive, userid, Entrystatus});
            return Result;
        }
        public string UnderHeaderMenu_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_MENU_UNDER_HEADER"
               , new string[] { "@ID", "@MODIFIEDBY", "@ENTRYSTATUS" }
               , new string[] { ID, userid, Entrystatus });
            return Result;
        }

        #endregion

        #region Under Sub menu

       
        public DataTable UnderSubMenu_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_MENU_UNDER_SUBMENU"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "View" });
            return dt;
        }
        public string UnderSubMenu_Save(string Headerid, string UnderHeaderId,string MenuName, string menuurl, string issubmenu, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_MENU_UNDER_SUBMENU"
               , new string[] { "@MenuId","@SubMenuId",  "@MenuName", "@MenuUrl", "@Submenu", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
               , new string[] { Headerid, UnderHeaderId,MenuName, menuurl, issubmenu, isactive, userid, Entrystatus });
            return Result;
        }
        public string UnderSubMenu_Update(string ID,string Headerid, string UnderHeaderId, string MenuName, string menuurl, string issubmenu, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_MENU_UNDER_SUBMENU"
               , new string[] { "@ID","@MenuId", "@SubMenuId", "@MenuName", "@MenuUrl", "@Submenu", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
               , new string[] { ID,Headerid, UnderHeaderId, MenuName, menuurl, issubmenu, isactive, userid, Entrystatus });
            return Result;
        }
        public string UnderSubMenu_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_MENU_UNDER_SUBMENU"
               , new string[] { "@ID", "@MODIFIEDBY", "@ENTRYSTATUS" }
               , new string[] { ID, userid, Entrystatus });
            return Result;
        }


        #endregion


        #region Child Submenu
        public DataTable Child_SubMenu_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_MENU_CHILD_MENU"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "View" });
            return dt;
        }
        public string Child_SubMenu_Save(string HeaderId, string UnderHeaderId, string UnderSubMenuId,string MenuName, string MenuUrl, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_MENU_CHILD_MENU"
               , new string[] { "@HeaderId", "@UnderHeaderId","@UnderSubMenuId","@MenuName", "@MenuUrl",  "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
               , new string[] { HeaderId, UnderHeaderId, UnderSubMenuId, MenuName, MenuUrl,  isactive, userid, Entrystatus });
            return Result;
        }
        public string Child_SubMenu_Update(string ID,string HeaderId, string UnderHeaderId, string UnderSubMenuId, string MenuName, string MenuUrl, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_MENU_CHILD_MENU"
               , new string[] { "@ID","@HeaderId", "@UnderHeaderId", "@UnderSubMenuId", "@MenuName", "@MenuUrl", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
               , new string[] { ID,HeaderId, UnderHeaderId, UnderSubMenuId, MenuName, MenuUrl, isactive, userid, Entrystatus });
            return Result;
        }
        public string Child_SubMenu_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_MENU_CHILD_MENU"
               , new string[] { "@ID", "@MODIFIEDBY", "@ENTRYSTATUS" }
               , new string[] { ID, userid, Entrystatus });
            return Result;
        }

        #endregion
    }
}