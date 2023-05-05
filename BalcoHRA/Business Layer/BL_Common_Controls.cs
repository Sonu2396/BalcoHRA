using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BalcoHRA.Business_Layer
{
    public class BL_Common_Controls
    {
        PotMaintainanceManager PMcn = new PotMaintainanceManager();
        FPManager cn = new FPManager();
        MESVEDANTAManager cnVdt = new MESVEDANTAManager();
        KioskManager Ksk = new KioskManager();
        public DataTable Get_Kiosk_Employee_List(string prefixText)
        {
            string Sql = "select top 5 * from (select CONCAT(Employee_Name,'-',Employee_ID)as EmpName from tbl_Employee where  Employee_ID like '"+ prefixText + "%' or Employee_Name like '" + prefixText + "%' " +
                " union select CONCAT(Name, '-', Unique_ID) as EmpName from tbL_Contractor_Details where Unique_ID like '" + prefixText + "%' or Name like '" + prefixText + "%') as DV order by Empname";
            DataTable dt = new DataTable();
            dt = Ksk.GetDataTable(Sql);
            return dt;
        }

        public DataTable GenerateTransposedTable(DataTable inputTable)
        {
            DataTable outputTable = new DataTable();

            // Add columns by looping rows

            // Header row's first column is same as in inputTable
            outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

            // Header row's second column onwards, 'inputTable's first column taken
            foreach (DataRow inRow in inputTable.Rows)
            {
                string newColName = inRow[0].ToString();
                outputTable.Columns.Add(newColName);
            }

            // Add rows by looping columns        
            for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
            {
                DataRow newRow = outputTable.NewRow();

                // First column is inputTable's Header row's second column
                newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
                for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                {
                    string colValue = inputTable.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }
                outputTable.Rows.Add(newRow);
            }

            return outputTable;
        }



        public DataTable Get_Delete_Authentication(string UserName,string ParName)
        {
            DataTable dt = new DataTable();
            dt = PMcn.GetDataTable("SP_Delete_Authentication_User"
                , new string[] { "@UserName", "@ParName" }
                , new string[] { UserName, ParName });
            return dt;
        }
        public DataTable Get_LogBook_Authentication(string LOGBOOKDEPT, string LOGBOOKTYPE, string USERID, string LOGTYPE)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_LOGBOOK_AUTHENTICATION_CHECK"
              , new string[] { "@LOGBOOKDEPT", "@LOGBOOKTYPE","@USERID","@LOGTYPE" }
              , new string[] { LOGBOOKDEPT, LOGBOOKTYPE, USERID, LOGTYPE });
            return dt;
        }
        public DataTable Get_Page_Authentication(string UserId,string PageName)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_USER_PAGE_AUTHENTICATION_VERIFY"
              , new string[] { "@USERID","@PAGENAME" }
              , new string[] { UserId,PageName });
            return dt;
        }
        public DataTable Get_Application_Version()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_VERSION_INFO");
            return dt;
        }
        public DataTable Get_Menu_Name(string userid)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_GET_MENU_HEADER"
              , new string[] { "@USERID" }
              , new string[] { userid});
            return dt;
        }
        public DataTable Get_Under_Header_Menu_Name(string userid)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_GET_MENU_UNDER_HEADER"
              , new string[] { "@USERID" }
              , new string[] { userid });
            return dt;
        }
        public DataTable Get_Under_SubMenu_Name(string userid)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_GET_MENU_UNDERSUB_UNDER"
              , new string[] { "@USERID" }
              , new string[] { userid });
            return dt;
        }
        public DataTable Get_Under_SubMenu_Name_Child(string userid)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_GET_MENU_CHILD"
              , new string[] { "@USERID" }
              , new string[] { userid });
            return dt;
        }
        public DataTable Get_CurrentDateShift()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_GET_CURRENT_SHIFT_DATE");
            return dt;
        }

        public DataTable DropDownlist_Shift(string EntryType)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT ID,SHIFTNAME FROM MST_SHIFT_INFO WHERE VIEWTYPE='"+ EntryType +"' ORDER BY ID");
            return dt;
        }


        public DataTable DropDownlist_Menu()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from MST_MENU_HEADER where IsActive=1 order by id ");
            return dt;
        }
        public DataTable DropDownlist_Under_Header_Menu(string Menuid)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from MST_MENU_UNDER_HEADER where menuid='" + Menuid+ "' and  IsActive=1 order by id ");
            return dt;
        }
        public DataTable DropDownlist_UnderSubMenu(string Menuid,string Submenuid)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from MST_MENU_UNDER_SUBMENU where menuid='" + Menuid + "' and SubMenuId='" + Submenuid + "' and  IsActive=1 order by id ");
            return dt;
        }
        public DataTable DropDownlist_Child_Menu(string Menuid, string Submenuid,string UnderSubmenuid)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from MST_MENU_CHILD_MENU where HeaderId='" + Menuid + "' and UnderHeaderId='" + Submenuid + "' and UnderSubMenuId='"+ UnderSubmenuid +"' and  IsActive=1 order by id ");
            return dt;
        }
        public DataTable DropDownlist_UserRole()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_ROLE", new string[] { "@ENTRYSTATUS" }, new string[] { "DropDown" });
            return dt;
        }
        public DataTable DropDownlist_User()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_USER_REGISTRATION", new string[] { "@ENTRYSTATUS" }, new string[] { "DropDown" });
            return dt;
        }
        public DataTable DropDownlist_PotLine()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_MASTER_TAPPINGLOCATION", new string[] { "@ENTRYSTATUS" }, new string[] { "DropDown" });
            return dt;
        }
       
        public DataTable DropDownlist_PotSection(string Tapline)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_MASTER_TAPPINGSECTION", new string[] { "@ENTRYSTATUS","@TAPLINE" }, new string[] { "DropDown" ,Tapline});
            return dt;
        }
        public DataTable DropDownlist_PotNo(string Tapline,string Tapsection)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_MASTER_TAPPINGPOTNO", new string[] { "@ENTRYSTATUS", "@TAPLINE","@TAPSECTION" }, new string[] { "DropDown", Tapline,Tapsection });
            return dt;
        }

        public DataTable DropDownlist_Vehicle()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_MASTER_VEHICLE", new string[] { "@ENTRYSTATUS" }, new string[] { "DropDown" });
            return dt;
        }

        public DataTable DropDownlist_Ladle()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_MASTER_LADLE", new string[] { "@ENTRYSTATUS" }, new string[] { "DropDown" });
            return dt;
        }

        public DataTable DropDownlist_CastHouse()
        { 
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_MASTER_CASTHOUSELOCATION", new string[] { "@ENTRYSTATUS" }, new string[] { "DropDown" });
            return dt;
        }
        public DataTable DropDownlist_CastHouse_Furnace()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_MASTER_FURNACE", new string[] { "@ENTRYSTATUS" }, new string[] { "DropDown" });
            return dt;
        }
        public DataTable DropDownlist_Product()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_MASTER_PRODUCT", new string[] { "@ENTRYSTATUS" }, new string[] { "DropDown" });
            return dt;
        }
        
        public DataTable DropDownlist_Room()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select distinct ROOMNAME,ROOMSHORTNAME from MST_ROOM order by ROOMNAME");
            return dt;
        }

        public DataTable DropDownlist_Alloy()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from MST_ALLOY_INFORMATION ");
            return dt;
        }


        public DataTable Fetch_Ladle_CheckList()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from MST_LCS_LADLE_CHECKLIST");
            return dt;
        }

        public DataTable Gridiview_SubMenu(string Menuid)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from MST_MENU_SUBMENU where menuid in ("+Menuid+") and  IsActive=1 order by id ");
            return dt;
        }



        #region PotMaintainance
        public DataTable DropDownlist_Breaker_Type()
        {
            DataTable dt = new DataTable();
            dt = PMcn.GetDataTable("select * from MST_BREKER_FEEDER_TYPE");
            return dt;
        }
        public DataTable DropDownlist_Breaker_Feeder_Problem(string FeederType)
        {
            DataTable dt = new DataTable();
            dt = PMcn.GetDataTable("SP_MASTER_BREAKER_FEEDER_PROBLEM"
                , new string[] { "@BreakerORFeeder","@ENTRYSTATUS" }
                , new string[] { FeederType,"DropDown" });
            return dt;
        }
        public DataTable DropDownlist_Breaker_Feeder_Causes(string FeederType)
        {
            DataTable dt = new DataTable();
            dt = PMcn.GetDataTable("SP_MASTER_BREAKER_FEEDER_CAUSE"
                , new string[] { "@BreakerORFeeder", "@ENTRYSTATUS" }
                , new string[] { FeederType, "DropDown" });
            return dt;
        }
        public DataTable DropDownlist_Breaker_Make()
        {
            DataTable dt = new DataTable();
            dt = PMcn.GetDataTable("SELECT make FROM breaker_make_master ORDER BY make");
            return dt;
        }
        #endregion



        #region Notification
        public bool Save_Popup_Message(string ProjectName, string PMatter,string TblName, string PSubject,string TID,string Empid)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_TRANS_POPUP"
                , new string[] { "@ProjectName", "@PMatter","@TblName", "@PSubject","@TID","@Empid" }
                , new string[] { ProjectName, PMatter, TblName, PSubject,TID, Empid });
            return Result;
        }
        public bool Save_Popup_Message_Read(string id)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_TRANS_POPUP_UPDATE_READSTATUS"
                , new string[] { "@id" }
                , new string[] { id });
            return Result;
        }
        public DataTable Count_Popupunread_Count(string Empid)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select count(*) as Nos from TRANS_POPUP where Empid='" + Empid + "' and readstatus=0");
            return dt;
        }
        public DataTable Count_Popupunread(string Empid)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select *,datediff(minute,PDate,getdate())as SendMinutes  from TRANS_POPUP where Empid='" + Empid + "' and readstatus=0  order by id desc");
            return dt;
        }
        public DataTable Get_Popup_Msg(string Empid)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select *,datediff(minute,PDate,getdate())as SendMinutes  from TRANS_POPUP where Empid='" + Empid + "' order by id desc ");
            return dt;
        }
        #endregion

        #region Fe Analysis
        public DataTable DropDownlist_Fe_Reason_FeedBack()
        {
            DataTable dt = new DataTable();
            dt = cnVdt.GetDataTable("SELECT id,[REASON]  FROM TBL_POTLINE_BALCO_MAIN_REASON_MASTER");
            return dt;
        }
        public DataTable DropDownlist_Fe_subReason(string Fkid)
        {
            DataTable dt = new DataTable();
            dt = cnVdt.GetDataTable("SELECT  id,[REASON]  FROM TBL_POTLINE_BALCO_SUB_REASON_1_MASTER where FKID='" + Fkid + "'");
            return dt;
        }
        public DataTable DropDownlist_Fe_subReason_1(string Fkid)
        {
            DataTable dt = new DataTable();
            dt = cnVdt.GetDataTable("SELECT [REASON]  FROM [TBL_POTLINE_BALCO_SUB_REASON_2_MASTER] where FKID='" + Fkid + "' order by id desc");
            return dt;
        }
        public DataTable DropDownlist_Anode()
        {
            DataTable dt = new DataTable();
            dt = cnVdt.GetDataTable("SELECT [ANODENO]  FROM [TBL_POTLINE_BALCO_ANODE_GROUP_MATER]");
            return dt;
        }

        #endregion
    }
}