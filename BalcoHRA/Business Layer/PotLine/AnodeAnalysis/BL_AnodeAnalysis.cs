using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BalcoHRA.Business_Layer.PotLine.CEAnalysis
{
    public class BL_AnodeAnalysis
    {

        FPManager cn = new FPManager();
        PLANTIIManager cnP = new PLANTIIManager();
        KioskManager Ksk = new KioskManager();
        #region PROCESS AUDIT
        public DataTable Get_Process_AUdit_List(string JOBTYPE)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT * FROM MST_POT_ANODE_PROCESS_AUDIT WHERE JOBTYPE='"+ JOBTYPE + "'");
            return dt;
        }

        public DataTable Get_Kiok_Employee_List(string EmployeeType,string EmployeeIds)
        {
            DataTable dt = new DataTable();
            if(EmployeeType=="Balco")
            dt = Ksk.GetDataTable("select Employee_ID as EMPID,Employee_Name as EMPNAME from tbl_Employee where Employee_ID in (select * from dbo.[fnSplitString]('" + EmployeeIds+"',',')) order by Employee_Name");
            else
                dt = Ksk.GetDataTable("select  Unique_ID as  EMPID, Name as  EMPNAME from tbL_Contractor_Details where Unique_ID in (select * from dbo.[fnSplitString]('" + EmployeeIds + "',',')) order by Name");
            return dt;
        }
        public bool Process_AUdit_Save(string TRDATE, string TRSHIFT,string POTLINE,string SECTION,string POTNO, string JOBSTYPE, string JOBSNAME,string ANODENO, string OPERATORS, string LABOURS, string USERID,string REMARKS)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_POT_ANODE_TRNS_PROCESS_AUDIT"
                , new string[] { "@TRDATE", "@TRSHIFT", "@POTLINE", "@SECTION", "@POTNO", "@JOBSTYPE", "@JOBSNAME","@ANODENO", "@OPERATORS", "@LABOURS", "@USERID", "@REMARKS", "@ENTRYSTATUS" }
                , new string[] { TRDATE, TRSHIFT, POTLINE, SECTION, POTNO, JOBSTYPE, JOBSNAME, ANODENO, OPERATORS, LABOURS, USERID, REMARKS, "Save"});
            return Result;
        }


        public DataTable Process_Audit_Report_AC(string TRDATE,string TRSHIFT,string JOBSTYPE)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_ANODE_PROCESS_AUDIT_REPORT"
                , new string[] { "@TRDATE","@TRSHIFT","@JOBSTYPE"}
                , new string[] { TRDATE,TRSHIFT, JOBSTYPE });
            return dt;
        }


        #endregion




        #region DAILY CHECK LIST
        public bool Dailychecklist_Save(string TRDATE,string TRSHIFT,string JOBSTYPE,string POTLINE,string SECTION,string POTNO,string ANODENO,
                                        string PTMOPERATOR,string GROUNOPERATOR,string REDRESSINGREMARKS,string REMARKS,string USERID,string OPERATORSNAME)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_POT_ANODE_TRNS_DAILY_CHECK_LIST"
                , new string[] { "@TRDATE","@TRSHIFT","@JOBSTYPE","@POTLINE","@SECTION","@POTNO","@ANODENO",
                                 "@PTMOPERATOR","@GROUNOPERATOR","@REDRESSINGREMARKS","@REMARKS","@USERID","@ENTRYSTATUS" ,"@OPERATORSNAME"}
                , new string[] {  TRDATE,TRSHIFT,JOBSTYPE,POTLINE,SECTION,POTNO,ANODENO,
                                 PTMOPERATOR,GROUNOPERATOR,REDRESSINGREMARKS,REMARKS,USERID, "Save",OPERATORSNAME });
            return Result;
        }
        public DataTable Dailychecklist_Report(string TRDATE,  string POTLINE,string SECTION)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_ANODE_DAILY_CHECK_LIST_REPORT"
                , new string[] { "@DATE",  "@POTLINE","@SECTION" }
                , new string[] { TRDATE,  POTLINE,SECTION });
            return dt;
        }
        #endregion


        public DataTable Dropwonlist_shiftIcharge_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select DISTINCT CONCAT(USERNAME,'-',LOGINID) AS USERNAME,LOGINID from TR_POT_ANODE_PROCESS_AUDIT AS A LEFT OUTER JOIN MST_USERS  AS U ON A.CREATEDBY=U.LOGINID order by USERNAME");
            return dt;
        }

        public DataTable ShiftIncharge_Report(string SDATE, string EDATE, string USERID)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_ANODE_SHIFTINCHARGE_REPORT"
                , new string[] { "@SDATE", "@EDATE", "@USERID"}
                , new string[] { SDATE, EDATE, USERID });
            return dt;
        }
        public DataTable ReDresser_Report(string SDATE, string EDATE, string SPOT,string EPOT)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_ANODE_REDRESSER_REPORT"
                , new string[] { "@SDATE", "@EDATE", "@SPOT" ,"@EPOT"}
                , new string[] { SDATE, EDATE, SPOT,EPOT });
            return dt;
        }
        public DataTable Corner_Report(string SDATE, string EDATE, string SPOT, string EPOT)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_ANODE_CORNER_REPORT"
                , new string[] { "@SDATE", "@EDATE", "@SPOT", "@EPOT" }
                , new string[] { SDATE, EDATE, SPOT, EPOT });
            return dt;
        }

        public DataTable Operator_Wise_Report(string SDATE, string EDATE, string USERID)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POT_ANODE_REPORT_OPERATOR_WISE"
                , new string[] { "@SDATE", "@EDATE","@USERID"  }
                , new string[] { SDATE, EDATE, USERID });
            return dt;
        }

    }
}