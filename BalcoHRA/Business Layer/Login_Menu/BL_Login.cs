using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BalcoHRA.Business_Layer;

namespace BalcoHRA.Business_Layer.Login_Menu
{
    public class BL_Login
    {

        FPManager FP = new FPManager();
        KioskManager Kiosk = new KioskManager();

        public DataTable Validate_Login(string userid, string password, string MachineIp)
        {
            DataTable dt = new DataTable();
            dt = FP.GetDataTable("SP_USER_REGISTRATION"
              , new string[] { "@LOGINID", "@LOGINPWD", "@ENTRYSTATUS", "@LOGINIP" }
              , new string[] { userid, password, "ValidateLogin", MachineIp });
            return dt;
        }
        public DataTable Check_AppPermission(string userid, string MachineIp)
        {
            DataTable dt = new DataTable();
            dt = FP.GetDataTable("SP_USER_REGISTRATION"
              , new string[] { "@LOGINID", "@ENTRYSTATUS", "@LOGINIP" }
              , new string[] { userid, "ValidateUser", MachineIp });
            return dt;
        }
        public DataTable Get_User_Information(string userid)
        {
            DataTable dt = new DataTable();
            dt = FP.GetDataTable("SP_USER_REGISTRATION"
              , new string[] { "@LOGINID", "@ENTRYSTATUS" }
              , new string[] { userid, "GetUser" });
            return dt;
        }
        public DataTable Get_User_Login_History(string userid)
        {
            DataTable dt = new DataTable();
            dt = FP.GetDataTable("SP_USER_LOGIN_HISTORY", new string[] { "@USERID" }, new string[] { userid });
            return dt;
        }
        public DataTable Get_User_Login_10_Record(string userid)
        {
            DataTable dt = new DataTable();
            dt = FP.GetDataTable("SP_USER_LOGIN_RECORD_TOP10", new string[] { "@USERID" }, new string[] { userid });
            return dt;
        }
        public DataTable Get_User_Login_All_Record(string userid)
        {
            DataTable dt = new DataTable();
            dt = FP.GetDataTable("SP_USER_LOGIN_RECORD_ALL", new string[] { "@USERID" }, new string[] { userid });
            return dt;
        }


        public string User_ChangePassword(string userid, string password)
        {
            string Result = "";
            Result = FP.ExecuteQuerySP_Retrun_String("SP_USER_REGISTRATION"
                , new string[] { "@LOGINID", "@LOGINPWD", "@ENTRYSTATUS" }
                , new string[] { userid, password, "ChangePassword" });
            return Result;
        }

        public DataTable User_Get_Kiosk_Details(string userid)
        {
            DataTable dt = new DataTable();
            dt = Kiosk.GetDataTable("select * from tbl_Employee where Employee_ID='" + userid + "'");
            return dt;
        }



        public DataTable Get_ACtive_UserList()
        {
            DataTable dt = new DataTable();
            dt = FP.GetDataTable("SP_USER_REGISTRATION", new string[] { "@ENTRYSTATUS" }, new string[] { "ActiveUser" });
            return dt;
        }
        public DataTable Get_User_Timesof_Login(string DATE)
        {
            DataTable dt = new DataTable();
            dt = FP.GetDataTable("SP_USER_TIMESOF_LOGIN", new string[] { "@DATE" }, new string[] { DATE });
            return dt;
        }

        public DataTable Get_User_UserList()
        {
            DataTable dt = new DataTable();
            dt = FP.GetDataTable("SP_USER_REGISTRATION", new string[] { "@ENTRYSTATUS" }, new string[] { "List" });
            return dt;
        }
        public string User_Regd_Save(string EMPID, string USERNAME, string MOBILENO, string EMAILID, string LOGINID, string LOGINPWD, string ROLEID, string USERLOCATION, string USERTYPE, string CREATEDBY)
        {
            string Result = "";
            Result = FP.ExecuteQuerySP_Retrun_String("SP_USER_REGISTRATION"
                , new string[] { "@EMPID", "@USERNAME", "@MOBILENO", "@EMAILID", "@LOGINID", "@LOGINPWD", "@ROLEID", "@USERLOCATION", "@USERTYPE", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { EMPID, USERNAME, MOBILENO, EMAILID, LOGINID, LOGINPWD, ROLEID, USERLOCATION, USERTYPE, CREATEDBY, "Save" });
            return Result;
        }
        public string User_Regd_Update(string ID, string EMPID, string USERNAME, string MOBILENO, string EMAILID, string LOGINID, string LOGINPWD, string ROLEID, string USERLOCATION, string USERTYPE, string CREATEDBY)
        {
            string Result = "";
            Result = FP.ExecuteQuerySP_Retrun_String("SP_USER_REGISTRATION"
                , new string[] { "@ID", "@EMPID", "@USERNAME", "@MOBILENO", "@EMAILID", "@LOGINID", "@LOGINPWD", "@ROLEID", "@USERLOCATION", "@USERTYPE", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, EMPID, USERNAME, MOBILENO, EMAILID, LOGINID, LOGINPWD, ROLEID, USERLOCATION, USERTYPE, CREATEDBY, "Update" });
            return Result;
        }
        public string User_Regd_Delete(string ID)
        {
            string Result = "";
            Result = FP.ExecuteQuerySP_Retrun_String("SP_USER_REGISTRATION"
                , new string[] { "@ID", "@ENTRYSTATUS" }
                , new string[] { ID, "Delete" });
            return Result;
        }

        public DataTable User_Regd_View(string ID)
        {
            DataTable dt = new DataTable();
            dt = FP.GetDataTable("SP_USER_REGISTRATION"
                , new string[] { "@ID", "@ENTRYSTATUS" }
                , new string[] { ID, "View" });
            return dt;
        }
        public bool User_Regd_Signout(string LOGINID)
        {
            bool Result = false;
            Result = FP.ExecuteQuerySP("SP_USER_REGISTRATION"
                , new string[] { "@LOGINID", "@ENTRYSTATUS" }
                , new string[] { LOGINID, "LogOut" });
            return Result;
        }

    }
}