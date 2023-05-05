using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BalcoHRA.Business_Layer.PotLine.PotMaintainance
{
    public class BL_Potmaintainance
    {
        PotMaintainanceManager cn = new PotMaintainanceManager();

        #region Master Breaker Feeder Problem
        public DataTable Master_Get_Breaker_Feeder_Problem_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_BREAKER_FEEDER_PROBLEM"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Master_Get_Breaker_Feeder_Problem_Save(string Problem,string BreakerORFeeder, string isactive)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_BREAKER_FEEDER_PROBLEM"
                , new string[] { "@Problem","@BreakerORFeeder", "@ActiveStatus", "@ENTRYSTATUS" }
                , new string[] { Problem, BreakerORFeeder, isactive,"Save" });
            return Result;
        }
        public string Master_Get_Breaker_Feeder_Problem_Update(string Id,string Problem, string BreakerORFeeder, string isactive)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_BREAKER_FEEDER_PROBLEM"
                , new string[] { "@ID","@Problem", "@BreakerORFeeder", "@ActiveStatus", "@ENTRYSTATUS" }
                , new string[] { Id,Problem, BreakerORFeeder, isactive, "Update" });
            return Result;
        }
        public string Master_Get_Breaker_Feeder_Problem_Delete(string ID,  string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_BREAKER_FEEDER_PROBLEM"
                , new string[] { "@ID",  "@ENTRYSTATUS" }
                , new string[] { ID,  Entrystatus });
            return Result;
        }
        #endregion

        #region Master Breaker Feeder Type
        public DataTable Master_Get_Breaker_Feeder_Causes_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MASTER_BREAKER_FEEDER_CAUSE"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Master_Get_Breaker_Feeder_Causes_Save(string Causes, string BreakerORFeeder, string isactive)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_BREAKER_FEEDER_CAUSE"
                , new string[] { "@Causes", "@BreakerORFeeder", "@ActiveStatus", "@ENTRYSTATUS" }
                , new string[] { Causes, BreakerORFeeder, isactive, "Save" });
            return Result;
        }
        public string Master_Get_Breaker_Feeder_Causes_Update(string Id, string Causes, string BreakerORFeeder, string isactive)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_BREAKER_FEEDER_CAUSE"
                , new string[] { "@ID", "@Causes", "@BreakerORFeeder", "@ActiveStatus", "@ENTRYSTATUS" }
                , new string[] { Id, Causes, BreakerORFeeder, isactive, "Update" });
            return Result;
        }
        public string Master_Get_Breaker_Feeder_Causes_Delete(string ID, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_MASTER_BREAKER_FEEDER_CAUSE"
                , new string[] { "@ID", "@ENTRYSTATUS" }
                , new string[] { ID, Entrystatus });
            return Result;
        }
        #endregion


        #region Breaker Change Entry
        public DataTable Breakerchange_Bind_PotNo(string potline,string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_BreakerChange_Bind_Potno"
              , new string[] { "@potline","@section" }
              , new string[] { potline,section });
            return dt;
        }
        public DataTable Breakerchange_Bind_PotNo_CurrentDay(string potline, string section,string Date)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_BreakerChange_Bind_CurrentDayData"
              , new string[] { "@potline", "@section","@SHIFTDATE" }
              , new string[] { potline, section,Date });
            return dt;
        }
        public DataTable Breakerchange_Bind_PotNo_PendingJobs(string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_BreakerChange_Bind_Pending_Jobs"
              , new string[] { "@potline", "@section" }
              , new string[] { potline, section });
            return dt;
        }
        public string Breakerchange_Save_Pending_status(string ID, string STATUS, string username)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_BreakerChange_Save_Pending_Jobs"
                , new string[] { "@ID", "@STATUS", "@username" }
                , new string[] { ID, STATUS,  username });
            return Result;
        }
        public string Breakerchange_Save(string BREAKERNO,  string problem,string remarks,string username
                                        , string potno, string status,  string causes,string potline, string section)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_BreakerChange_Save"
                , new string[] { "@BREAKERNO", "@problem","@remarks","@username",
                                 "@potno", "@status", "@causes","@Potline","@Section","@EntryStatus"}
                , new string[] { BREAKERNO,  problem, remarks, username,
                                potno,  status,  causes,potline,section,"Save"});
            return Result;
        }
        public DataTable Breakerchange_TimesOf_Entry(string ID)
        {
            
            DataTable dt = cn.GetDataTable("Sp_BreakerChange_Timeof_Entry"
                , new string[] { "@ID"}
                , new string[] { ID});
            return dt;
        }
        public string Breakerchange_Update(string Id,string Causes, string remarks, string username,string status, string considerLife)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_BreakerChange_Save"
                , new string[] { "@ID","@Causes","@remarks","@username","@status","@considerLife","@EntryStatus"}
                , new string[] { Id, Causes, remarks, username, status,  considerLife,"Update"});
            return Result;
        }
        public string Breakerchange_Delete(string Id)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_BreakerChange_Save"
                , new string[] { "@ID","@EntryStatus"}
                , new string[] { Id,"Delete"});
            return Result;
        }
        public DataTable Breakerchange_View(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_BreakerChange_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "View" });
            return dt;
        }
        #endregion


        #region Breaker Problem Entry
        public DataTable BreakerProblem_TimesOf_Entry(string ID)
        {

            DataTable dt = cn.GetDataTable("Sp_BreakerProblem_Timeof_Entry"
                , new string[] { "@ID" }
                , new string[] { ID });
            return dt;
        }
        public DataTable BreakerProblem_Bind_PotNo(string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_BreakerProblem_Bind_Potno"
              , new string[] { "@potline", "@section" }
              , new string[] { potline, section });
            return dt;
        }
        public DataTable BreakerProblem_Bind_PotNo_CurrentDay(string potline, string section, string Date)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_BreakerProblem_Bind_CurrentDayData"
              , new string[] { "@potline", "@section", "@SHIFTDATE" }
              , new string[] { potline, section, Date });
            return dt;
        }
        public DataTable Breakerproblem_Bind_PotNo_PendingJobs(string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_BreakerProblem_Bind_Pending_Jobs"
              , new string[] { "@potline", "@section" }
              , new string[] { potline, section });
            return dt;
        }
        public string BreakerProblem_Save_Pending_status(string ID, string STATUS, string username)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_BreakerProblem_Save_Pending_Jobs"
                , new string[] { "@ID", "@STATUS", "@username" }
                , new string[] { ID, STATUS, username });
            return Result;
        }
        public string BreakerProblem_Save(string BREAKERNO,   string problem, string remarks, string username
                                        , string potno, string status,  string causes, string potline, string section)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_BreakerProblem_Save"
                , new string[] { "@BREAKERNO",  "@problem","@remarks","@username",
                                 "@potno", "@status", "@causes","@Potline","@Section","@EntryStatus"}
                , new string[] { BREAKERNO,   problem, remarks, username,
                                potno,  status, causes,potline,section,"Save"});
            return Result;
        }
        public string BreakerProblem_Update(string Id,string Causes,  string remarks, string status, string username)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_BreakerProblem_Save"
                , new string[] { "@ID","@Causes","@remarks","@username", "@status", "@EntryStatus"}
                , new string[] { Id, Causes, remarks, username, status, "Update"});
            return Result;
        }
        public string BreakerProblem_Delete(string Id)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_BreakerProblem_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "Delete" });
            return Result;
        }
        public DataTable BreakerProblem_View(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_BreakerProblem_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "View" });
            return dt;
        }
        #endregion



        #region Feeder Change Entry
        public DataTable Feederchange_Bind_PotNo(string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_FeederChange_Bind_Potno"
              , new string[] { "@potline", "@section" }
              , new string[] { potline, section });
            return dt;
        }
        public DataTable Feederchange_Bind_PotNo_CurrentDay(string potline, string section, string Date)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_FeederChange_Bind_CurrentDayData"
              , new string[] { "@potline", "@section", "@SHIFTDATE" }
              , new string[] { potline, section, Date });
            return dt;
        }
        public DataTable Feederchange_Bind_PotNo_PendingJobs(string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_FeederChange_Bind_Pending_Jobs"
              , new string[] { "@potline", "@section" }
              , new string[] { potline, section });
            return dt;
        }
        public string Feederchange_Save_Pending_status(string ID, string STATUS, string username)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_FeederChange_Save_Pending_Jobs"
                , new string[] { "@ID", "@STATUS", "@username" }
                , new string[] { ID, STATUS, username });
            return Result;
        }
        public string Feederchange_Save(string Feederno,  string problem, string remarks, string username, string potno, string status,  string causes,string potline,string section)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_FeederChange_Save"
                , new string[] { "@Feederno", "@problem","@remarks","@username",
                                 "@potno", "@status", "@causes","@Potline","@Section","@EntryStatus"}
                , new string[] { Feederno,  problem, remarks, username,
                                potno,  status,  causes,potline,section,"Save"});
            return Result;
        }
        public DataTable Feederchange_TimesOf_Entry(string ID)
        {

            DataTable dt = cn.GetDataTable("Sp_FeederChange_Timeof_Entry"
                , new string[] { "@ID" }
                , new string[] { ID });
            return dt;
        }
        public string Feederchange_Update(string Id,string Causes, string remarks, string username,string status, string CONSIDERLIFE)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_FeederChange_Save"
                , new string[] { "@ID","@Causes","@remarks","@username", "@status", "@CONSIDERLIFE","@EntryStatus"}
                , new string[] { Id, Causes, remarks, username,status,  CONSIDERLIFE,"Update"});
            return Result;
        }
        public string Feederchange_Delete(string Id)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_FeederChange_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "Delete" });
            return Result;
        }
        public DataTable Feederchange_View(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_FeederChange_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "View" });
            return dt;
        }
        #endregion

        #region Feeder problem Entry
        public DataTable FeederProblem_Bind_PotNo(string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_FeederChange_Bind_Potno"
              , new string[] { "@potline", "@section" }
              , new string[] { potline, section });
            return dt;
        }
        public DataTable FeederProblem_Bind_PotNo_CurrentDay(string potline, string section, string Date)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_FeederChange_Bind_CurrentDayData"
              , new string[] { "@potline", "@section", "@SHIFTDATE" }
              , new string[] { potline, section, Date });
            return dt;
        }
        public DataTable FeederProblem_Bind_PotNo_PendingJobs(string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_FeederProblem_Bind_Pending_Jobs"
              , new string[] { "@potline", "@section" }
              , new string[] { potline, section });
            return dt;
        }
        public string FeederProblem_Save_Pending_status(string ID, string STATUS, string username)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_FeederProblem_Save_Pending_Jobs"
                , new string[] { "@ID", "@STATUS", "@username" }
                , new string[] { ID, STATUS, username });
            return Result;
        }
        public string FeederProblem_Save(string Feederno,   string problem, string remarks, string username
                                        , string potno, string status,  string causes, string potline, string section)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_FeederProblem_Save"
                , new string[] { "@Feederno", "@problem","@remarks","@username",
                                 "@potno", "@status","@causes","@Potline","@Section","@EntryStatus"}
                , new string[] { Feederno,   problem, remarks, username,
                                potno,  status,  causes,potline,section,"Save"});
            return Result;
        }
        public DataTable FeederProblem_TimesOf_Entry(string ID)
        {

            DataTable dt = cn.GetDataTable("Sp_FeederProblem_Timeof_Entry"
                , new string[] { "@ID" }
                , new string[] { ID });
            return dt;
        }
        public string FeederProblem_Update(string Id,string Causes,  string remarks,string status, string username  )
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_FeederProblem_Save"
                , new string[] { "@ID","@Causes","@remarks", "@status","@username","@EntryStatus"}
                , new string[] { Id, Causes, remarks,status, username,"Update"});
            return Result;
        }
        public string FeederProblem_Delete(string Id)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_FeederProblem_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "Delete" });
            return Result;
        }
        public DataTable FeederProblem_View(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_FeederProblem_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "View" });
            return dt;
        }
        #endregion



        #region Report Breaker 
        public DataTable Breakerchange_Report(string Sdate, string Edate, string potline, string section, string potno, string Make,string problem,string Causes,string status)
        {
            DataTable dt = new DataTable("BreakerChange");
            dt = cn.GetDataTable("Sp_BreakerChange_Report"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@Make","@problem","@Causes","@status" }
              , new string[] { Sdate, Edate, potline, section, potno, Make, problem, Causes, status });
            return dt;
        }
        public DataTable Breakerchange_Report_Summary(string Sdate, string Edate, string potline, string section, string potno, string Make, string problem, string Causes, string status)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_BreakerChange_Report_Summary"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@Make", "@problem", "@Causes", "@status" }
              , new string[] { Sdate, Edate, potline, section, potno, Make, problem, Causes, status });
            return dt;
        }
       
        public DataTable Breakerproblem_Report(string Sdate, string Edate, string potline, string section, string potno, string Make, string problem, string Causes, string status,string Shift)
        {
            DataTable dt = new DataTable("BreakerProblem");
            dt = cn.GetDataTable("Sp_BreakerProblem_Report"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@Make", "@problem", "@Causes", "@status","@shift" }
              , new string[] { Sdate, Edate, potline, section, potno, Make, problem, Causes, status,Shift });
            return dt;
        }
        public DataTable Breakerproblem_Report_Summary(string Sdate, string Edate, string potline, string section, string potno, string Make, string problem, string Causes, string status, string Shift)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_BreakerProblem_Report_Summary"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@Make", "@problem", "@Causes", "@status","@shift" }
              , new string[] { Sdate, Edate, potline, section, potno, Make, problem, Causes, status,Shift });
            return dt;
        }
        public DataTable BreakerLife_Report( string potline, string section, string potno, string Make)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_BreakerLife_Report"
              , new string[] {  "@potline", "@section", "@potno", "@Make" }
              , new string[] { potline, section, potno, Make});
            return dt;
        }
        public DataTable BreakerMake_Report(string potline, string section, string potno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_BreakerMake_Report"
              , new string[] { "@potline", "@section", "@potno" }
              , new string[] { potline, section, potno });
            return dt;
        }

        public DataTable BreakerLife_Details_Report(string Sdate, string Edate, string potline, string section, string potno, string Make, string problem, string Causes)
        {
            DataTable dt = new DataTable("Breakerlfdtls");
            dt = cn.GetDataTable("Sp_BreakerLife_Details_Report"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@Make", "@problem", "@Causes"}
              , new string[] { Sdate, Edate, potline, section, potno, Make, problem, Causes });
            return dt;
        }
        public DataTable BreakerLife_History_Report(string Sdate, string Edate, string potline, string section, string potno, string Make, string problem, string Causes)
        {
            DataTable dt = new DataTable("Breakerlfdtls");
            dt = cn.GetDataTable("Sp_BreakerLife_History_Report"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@Make", "@problem", "@Causes" }
              , new string[] { Sdate, Edate, potline, section, potno, Make, problem, Causes });
            return dt;
        }
        public DataTable BreakerLife_AvgLife_Report(string Sdate, string Edate, string potline, string section, string potno, string Make, string problem, string Causes,string status)
        {
            DataTable dt = new DataTable("Breakerlfavgdtls");
            dt = cn.GetDataTable("Sp_Breake_Average_Life_Report"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@Make", "@problem", "@Causes","@Status" }
              , new string[] { Sdate, Edate, potline, section, potno, Make, problem, Causes, status });
            return dt;
        }
        public DataSet BreakerLife_AvgLife_Make_Report(string Sdate, string Edate, string potline, string section, string potno, string Make, string problem, string Causes, string status)
        {
            DataSet ds = new DataSet("Breakerlfavgdtls");
            ds = cn.GetDataSet("Sp_Breake_Average_Life_Makewise_Report"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@Make", "@problem", "@Causes", "@Status" }
              , new string[] { Sdate, Edate, potline, section, potno, Make, problem, Causes, status });
            return ds;
        }

        #endregion 




        #region Report Feeder 
        public DataTable Feederchange_Report(string Sdate, string Edate, string potline, string section, string potno, string Make, string problem, string Causes, string status)
        {
            DataTable dt = new DataTable("FeederChange");
            dt = cn.GetDataTable("Sp_FeederChange_Report"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@Make", "@problem", "@Causes", "@status" }
              , new string[] { Sdate, Edate, potline, section, potno, Make, problem, Causes, status });
            return dt;
        }
        public DataTable Feederchange_Report_Summary(string Sdate, string Edate, string potline, string section, string potno, string Make, string problem, string Causes, string status)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_FeederChange_Report_Summary"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@Make", "@problem", "@Causes", "@status" }
              , new string[] { Sdate, Edate, potline, section, potno, Make, problem, Causes, status });
            return dt;
        }

        public DataTable Feederproblem_Report(string Sdate, string Edate, string potline, string section, string potno, string Make, string problem, string Causes, string status, string Shift)
        {
            DataTable dt = new DataTable("FeederProblem");
            dt = cn.GetDataTable("Sp_FeederProblem_Report"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@Make", "@problem", "@Causes", "@status", "@shift" }
              , new string[] { Sdate, Edate, potline, section, potno, Make, problem, Causes, status, Shift });
            return dt;
        }
       

        public DataTable FeederMake_Report(string potline, string section, string potno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_FeederMake_Report"
              , new string[] { "@potline", "@section", "@potno"}
              , new string[] { potline, section, potno });
            return dt;
        }
        #endregion 



        #region Breaker Make Master
        public DataTable Breaker_Make_Master_Load(string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_BREAKER_MAKE_MASTER"
              , new string[] { "@potline", "@section","@EntryStatus" }
              , new string[] { potline, section,"View" });
            return dt;
        }
        public DataTable Breaker_Make_Master_Dropdown()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from breaker_make_master");
            return dt;
        }

        public bool Breaker_Make_Master_Save(string potno, string B1,string B2,string B3,string B4,string B5,string TB)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_BREAKER_MAKE_MASTER"
                , new string[] { "@potno", "@B1", "@B2","@B3","@B4","@B5" ,"@TB","@EntryStatus"}
                , new string[] { potno, B1, B2 , B3, B4, B5, TB , "Update" });
            return Result;
        }

        #endregion


        #region Feeder Make Master
        public DataTable Feeder_Make_Master_Load(string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_FEEDER_MAKE_MASTER"
              , new string[] { "@potline", "@section", "@EntryStatus" }
              , new string[] { potline, section, "View" });
            return dt;
        }
        public DataTable Feeder_Make_Master_Dropdown()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select * from feeder_make_master");
            return dt;
        }

        public bool Feeder_Make_Master_Save(string potno, string F1,string F2,string F3,string F4,string F5,string AF)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_FEEDER_MAKE_MASTER"
                , new string[] { "@potno", "@F1", "@F2", "@F3", "@F4", "@F5", "@AF", "@EntryStatus" }
                , new string[] { potno, F1, F2, F3, F4, F5, AF, "Update" });
            return Result;
        }

        #endregion






        #region Air Leakages
        
       
        public string AirLeakages_Save(string EquipmentNo, string problem, string remarks, string username
                                        , string potno, string status, string causes, string potline, string section)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_AirLeakages_Save"
                , new string[] { "@equipmentNo", "@problem","@remarks","@username",
                                 "@potno", "@status", "@causes","@Potline","@Section","@EntryStatus"}
                , new string[] { EquipmentNo,  problem, remarks, username,
                                potno,  status,  causes,potline,section,"Save"});
            return Result;
        }
        public DataTable AirLeakages_TimesOf_Entry(string ID)
        {

            DataTable dt = cn.GetDataTable("Sp_AirLeakages_Timeof_Entry"
                , new string[] { "@ID" }
                , new string[] { ID });
            return dt;
        }
        public DataTable AirLeakages_Bind_PotNo_PendingJobs(string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_AirLeakage_Bind_Pending_Jobs"
              , new string[] { "@potline", "@section" }
              , new string[] { potline, section });
            return dt;
        }
        public string AirLeakages_Delete(string Id)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_AirLeakages_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "Delete" });
            return Result;
        }
        public DataTable AirLeakages_View(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_AirLeakages_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "View" });
            return dt;
        }
        public string AirLeakages_Update(string Id,string Causes, string remarks, string username, string status)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_AirLeakages_Save"
                , new string[] { "@ID","@Causes", "@remarks", "@username", "@status",  "@EntryStatus" }
                , new string[] { Id, Causes, remarks, username, status,  "Update" });
            return Result;
        }
        public DataTable AirLeakages_Report(string Sdate, string Edate, string potline, string section, string potno,  string problem, string Causes, string status)
        {
            DataTable dt = new DataTable("AirLeakages");
            dt = cn.GetDataTable("Sp_AirLeakages_Report"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno",  "@problem", "@Causes", "@status" }
              , new string[] { Sdate, Edate, potline, section, potno,  problem, Causes, status });
            return dt;
        }
        #endregion


        #region FRL Problem


        public string FRLProblem_Save(string problem, string remarks, string username
                                        , string potno, string status, string causes, string potline, string section)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_FRLProblem_Save"
                , new string[] { "@problem","@remarks","@username",
                                 "@potno", "@status", "@causes","@Potline","@Section","@EntryStatus"}
                , new string[] {  problem, remarks, username,
                                potno,  status,  causes,potline,section,"Save"});
            return Result;
        }
        public DataTable FRLProblem_TimesOf_Entry(string ID)
        {

            DataTable dt = cn.GetDataTable("Sp_FRLProblem_Timeof_Entry"
                , new string[] { "@ID" }
                , new string[] { ID });
            return dt;
        }
        public DataTable FRLProblem_Bind_PotNo_PendingJobs(string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_FRLProblem_Bind_Pending_Jobs"
              , new string[] { "@potline", "@section" }
              , new string[] { potline, section });
            return dt;
        }
        public string FRLProblem_Delete(string Id)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_FRLProblem_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "Delete" });
            return Result;
        }
        public DataTable FRLProblem_View(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_FRLProblem_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "View" });
            return dt;
        }
        public string FRLProblem_Update(string Id,string Causes, string remarks, string username, string status)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_FRLProblem_Save"
                , new string[] { "@ID","@Causes", "@remarks", "@username", "@status", "@EntryStatus" }
                , new string[] { Id, Causes, remarks, username, status, "Update" });
            return Result;
        }
        public DataTable FRLProblem_Report(string Sdate, string Edate, string potline, string section, string potno, string problem, string Causes, string status)
        {
            DataTable dt = new DataTable("FRLProblem");
            dt = cn.GetDataTable("Sp_FRLProblem_Report"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@problem", "@Causes", "@status" }
              , new string[] { Sdate, Edate, potline, section, potno, problem, Causes, status });
            return dt;
        }
        #endregion



        #region SolenoidValves


        public string SolenoidValves_Save(string groupname, string problem, string remarks, string username
                                        , string potno, string status, string causes, string potline, string section)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_SolenoidValves_Save"
                , new string[] { "@groupname", "@problem","@remarks","@username",
                                 "@potno", "@status", "@causes","@Potline","@Section","@EntryStatus"}
                , new string[] { groupname,  problem, remarks, username,
                                potno,  status,  causes,potline,section,"Save"});
            return Result;
        }
        public DataTable SolenoidValvesProblem_TimesOf_Entry(string ID)
        {

            DataTable dt = cn.GetDataTable("Sp_SolenoidValvesProblem_Timeof_Entry"
                , new string[] { "@ID" }
                , new string[] { ID });
            return dt;
        }
        public DataTable SolenoidValves_Bind_PotNo_PendingJobs(string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_SolenoidValves_Bind_Pending_Jobs"
              , new string[] { "@potline", "@section" }
              , new string[] { potline, section });
            return dt;
        }
        public string SolenoidValves_Delete(string Id)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_SolenoidValves_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "Delete" });
            return Result;
        }
        public DataTable SolenoidValves_View(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_SolenoidValves_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "View" });
            return dt;
        }
        public string SolenoidValves_Update(string Id,string Causes, string remarks, string username, string status)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_SolenoidValves_Save"
                , new string[] { "@ID","@Causes", "@remarks", "@username", "@status", "@EntryStatus" }
                , new string[] { Id, Causes, remarks, username, status, "Update" });
            return Result;
        }
        public DataTable SolenoidValves_Report(string Sdate, string Edate, string potline, string section, string potno, string problem, string Causes, string status)
        {
            DataTable dt = new DataTable("SolenoidValves");
            dt = cn.GetDataTable("Sp_SolenoidValves_Report"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@problem", "@Causes", "@status" }
              , new string[] { Sdate, Edate, potline, section, potno, problem, Causes, status });
            return dt;
        }
        #endregion


        #region JHook


        public string JHook_Save(string EquipmentNo, string problem, string remarks, string username
                                        , string potno, string status, string causes, string potline, string section)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_JHook_Save"
                , new string[] { "@equipmentNo", "@problem","@remarks","@username",
                                 "@potno", "@status", "@causes","@Potline","@Section","@EntryStatus"}
                , new string[] { EquipmentNo,  problem, remarks, username,
                                potno,  status,  causes,potline,section,"Save"});
            return Result;
        }
        public DataTable JHookProblem_TimesOf_Entry(string ID)
        {

            DataTable dt = cn.GetDataTable("Sp_JHook_Timeof_Entry"
                , new string[] { "@ID" }
                , new string[] { ID });
            return dt;
        }
        public DataTable JHook_Bind_PotNo_PendingJobs(string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_JHook_Bind_Pending_Jobs"
              , new string[] { "@potline", "@section" }
              , new string[] { potline, section });
            return dt;
        }
        public string JHook_Delete(string Id)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_JHook_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "Delete" });
            return Result;
        }
        public DataTable JHook_View(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_JHook_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "View" });
            return dt;
        }
        public string JHook_Update(string Id,string Causes, string remarks, string username, string status)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_JHook_Save"
                , new string[] { "@ID", "@Causes", "@remarks", "@username", "@status", "@EntryStatus" }
                , new string[] { Id, Causes, remarks, username, status, "Update" });
            return Result;
        }
        public DataTable JHook_Report(string Sdate, string Edate, string potline, string section, string potno, string problem, string Causes, string status)
        {
            DataTable dt = new DataTable("JHook");
            dt = cn.GetDataTable("Sp_JHook_Report"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@problem", "@Causes", "@status" }
              , new string[] { Sdate, Edate, potline, section, potno, problem, Causes, status });
            return dt;
        }
        #endregion


        #region Pipe Below Change


        public string PipeBelow_Save( string problem, string remarks, string username
                                        , string potno, string status, string causes, string potline, string section)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_PipeBelow_Save"
                , new string[] { "@problem","@remarks","@username",
                                 "@potno", "@status", "@causes","@Potline","@Section","@EntryStatus"}
                , new string[] {  problem, remarks, username,
                                potno,  status,  causes,potline,section,"Save"});
            return Result;
        }
        public DataTable PipeBelowProblem_TimesOf_Entry(string ID)
        {

            DataTable dt = cn.GetDataTable("Sp_PipeBelowProblem_Timeof_Entry"
                , new string[] { "@ID" }
                , new string[] { ID });
            return dt;
        }
        public DataTable PipeBelow_Bind_PotNo_PendingJobs(string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_PipeBelow_Bind_Pending_Jobs"
              , new string[] { "@potline", "@section" }
              , new string[] { potline, section });
            return dt;
        }
        public string PipeBelow_Delete(string Id)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_PipeBelow_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "Delete" });
            return Result;
        }
        public DataTable PipeBelow_View(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_PipeBelow_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "View" });
            return dt;
        }
        public string PipeBelow_Update(string Id,string Causes, string remarks, string username, string status,string considerLife)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_PipeBelow_Save"
                , new string[] { "@ID","@Causes", "@remarks", "@username", "@status","@considerLife", "@EntryStatus" }
                , new string[] { Id, Causes, remarks, username, status, considerLife, "Update" });
            return Result;
        }
        public DataTable PipeBelow_Report(string Sdate, string Edate, string potline, string section, string potno, string problem, string Causes, string status)
        {
            DataTable dt = new DataTable("PipeBelow");
            dt = cn.GetDataTable("Sp_PipeBelow_Report"
              , new string[] { "@Sdate", "@Edate", "@potline", "@section", "@potno", "@problem", "@Causes", "@status" }
              , new string[] { Sdate, Edate, potline, section, potno, problem, Causes, status });
            return dt;
        }
        #endregion



        #region Misc Entry


        public string MiscEntry_Save( string remarks, string username, string status)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_Misc_Save"
                , new string[] { "@remarks","@username", "@status","@EntryStatus"}
                , new string[] {   remarks, username,status,  "Save"});
            return Result;
        }
        public DataTable MiscellaneousProblem_TimesOf_Entry(string ID)
        {

            DataTable dt = cn.GetDataTable("Sp_MiscellaneousProblem_Timeof_Entry"
                , new string[] { "@ID" }
                , new string[] { ID });
            return dt;
        }
        public DataTable MiscEntry_Bind_PotNo_PendingJobs()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_Misc_Bind_Pending_Jobs");
            return dt;
        }
        public string MiscEntry_Delete(string Id)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_Misc_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "Delete" });
            return Result;
        }
        public DataTable MiscEntry_View(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_Misc_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "View" });
            return dt;
        }
        public string MiscEntry_Update(string Id, string remarks, string username, string status)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_Misc_Save"
                , new string[] { "@ID", "@remarks", "@username", "@status",  "@EntryStatus" }
                , new string[] { Id, remarks, username, status,  "Update" });
            return Result;
        }
        public DataTable MiscEntry_Report(string Sdate, string Edate)
        {
            DataTable dt = new DataTable("MiscEntry");
            dt = cn.GetDataTable("Sp_Misc_Report"
              , new string[] { "@Sdate", "@Edate" }
              , new string[] { Sdate, Edate});
            return dt;
        }
        #endregion


      

        #region Feedback
        public DataTable Feedback_pending_Jobs(string date, string shift, string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_Feedback_pending_Jobs"
              , new string[] { "@Date", "@Shift", "@potline", "@section" }
              , new string[] { date, shift, potline, section });
            return dt;
        }
        public bool Feedback_pending_Jobs_Save(string id, string Ptype, string Feedbacktype, string FeedbackRemarks, string FeedbackBy)
        {
            bool Result;
            Result = cn.ExecuteQuerySP("Sp_Feedback_pending_Jobs_Save"
              , new string[] { "@id","@Ptype", "@Feedbacktype", "@FeedbackRemarks", "@FeedbackBy" }
              , new string[] { id,Ptype, Feedbacktype, FeedbackRemarks, FeedbackBy });
            return Result;
        }


        public string Complaint_Delete(string id, string Ptype,string Userid)
        {
            string Result="";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_Complaint_Delete"
              , new string[] { "@id", "@Ptype","@userid" }
              , new string[] { id, Ptype,Userid });
            return Result;
        }
        #endregion



        #region AJF Problem


        public string AJFProblem_Save(string AJF,string WorkType,string ProblemType,string ProbelmRect,string PermitNo,string Remarks,string Techname,string UserId)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_AJFProblem_Save"
                , new string[] { "@AJF","@WorkType","@ProblemType","@ProbelmRect","@PermitNo","@Remarks","@Techname", "@username", "@EntryStatus"}
                , new string[] {  AJF,  WorkType,    ProblemType,  ProbelmRect,  PermitNo,  Remarks,  Techname,  UserId, "Save"});
            return Result;
        }
        public DataTable AJFProblem_TimesOf_Entry(string ID)
        {

            DataTable dt = cn.GetDataTable("Sp_AJF_Timeof_Entry"
                , new string[] { "@ID" }
                , new string[] { ID });
            return dt;
        }
        public DataTable AJFProblem_Bind_PotNo_PendingJobs()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_AJFProblem_Bind_Pending_Jobs");
            return dt;
        }
        public string AJFProblem_Delete(string Id)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_AJFProblem_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "Delete" });
            return Result;
        }
        public DataTable AJFProblem_View(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_AJFProblem_Save"
                , new string[] { "@ID", "@EntryStatus" }
                , new string[] { Id, "View" });
            return dt;
        }
        public string AJFProblem_Update(string Id,  string username, string status)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("Sp_AJFProblem_Save"
                , new string[] { "@ID",  "@username", "@status", "@EntryStatus" }
                , new string[] { Id,  username, status, "Update" });
            return Result;
        }
        public DataTable AJFProblem_Report(string Sdate, string Edate,  string status)
        {
            DataTable dt = new DataTable("AJFProblem");
            dt = cn.GetDataTable("Sp_AJFProblem_Report"
              , new string[] { "@Sdate", "@Edate", "@status" }
              , new string[] { Sdate, Edate,  status });
            return dt;
        }
        #endregion




        #region Dashboard

        public DataTable Dashboard_Pending_Jobs()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_Dashboard_Pending_Jobs");
            return dt;
        }
        public DataTable Dashboard_Job_Status(string date, string shift, string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_Dashboard_Complaint_Tracking"
              , new string[] { "@Date", "@Shift", "@potline", "@section" }
              , new string[] { date, shift, potline, section });
            return dt;
        }
        public DataTable Dashboard_Job_Status_Details(string date, string shift, string PType, string potline, string section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_Dashboard_Complaint_Tracking_Details"
              , new string[] { "@Date", "@Shift", "@Ptype", "@potline", "@section" }
              , new string[] { date, shift, PType, potline, section });
            return dt;
        }
        public DataTable Dashboard_Job_Status_Details_All(string date, string shift, string potline, string section, string Ptype)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_Dashboard_Complaint_Tracking_Details_All"
              , new string[] { "@Date", "@Shift", "@potline", "@section", "@Ptype" }
              , new string[] { date, shift, potline, section, Ptype });
            return dt;
        }


        public DataSet Dashboard_BreakerChange_Monthwise(string sdate, string edate, string potline, string section, string problem,string Equipmentno)
        {
            DataSet ds = new DataSet();
            ds = cn.GetDataSet("SP_Dashboard_Breakerchange_MonthWise"
              , new string[] { "@sdate", "@edate", "@potline", "@section", "@problem","@Equipmentno" }
              , new string[] { sdate, edate, potline, section, problem, Equipmentno });
            return ds;
        }
        public DataSet Dashboard_BreakerProblem_Monthwise(string sdate, string edate, string potline, string section, string problem, string Equipmentno,string status)
        {
            DataSet ds = new DataSet();
            ds = cn.GetDataSet("SP_Dashboard_BreakerProblem_MonthWise"
              , new string[] { "@sdate", "@edate", "@potline", "@section", "@problem", "@Equipmentno","@status" }
              , new string[] { sdate, edate, potline, section, problem, Equipmentno , status });
            return ds;
        }

        public DataSet Dashboard_FeederChange_Monthwise(string sdate, string edate, string potline, string section, string problem, string Equipmentno)
        {
            DataSet ds = new DataSet();
            ds = cn.GetDataSet("SP_Dashboard_Feederchange_MonthWise"
              , new string[] { "@sdate", "@edate", "@potline", "@section", "@problem", "@Equipmentno" }
              , new string[] { sdate, edate, potline, section, problem, Equipmentno });
            return ds;
        }
        public DataSet Dashboard_FeederProblem_Monthwise(string sdate, string edate, string potline, string section, string problem, string Equipmentno,string status)
        {
            DataSet ds = new DataSet();
            ds = cn.GetDataSet("SP_Dashboard_Feederproblem_MonthWise"
              , new string[] { "@sdate", "@edate", "@potline", "@section", "@problem", "@Equipmentno" ,"@status"}
              , new string[] { sdate, edate, potline, section, problem, Equipmentno, status });
            return ds;
        }
        public DataSet Dashboard_AirLeakage_Monthwise(string sdate, string edate, string potline, string section, string problem, string Equipmentno,string status)
        {
            DataSet ds = new DataSet();
            ds = cn.GetDataSet("SP_Dashboard_AirLeakage_MonthWise"
              , new string[] { "@sdate", "@edate", "@potline", "@section", "@problem", "@Equipmentno" ,"@status"}
              , new string[] { sdate, edate, potline, section, problem, Equipmentno , status });
            return ds;
        }
        public DataSet Dashboard_DateWise_Tracking(string sdate, string edate, string potline,  string ReportType)
        {
            DataSet ds = new DataSet();
            ds = cn.GetDataSet("SP_Dashboard_DayWise"
              , new string[] { "@sdate", "@edate", "@potline", "@ReportType" }
              , new string[] { sdate, edate, potline,  ReportType });
            return ds;
        }
        #endregion

    }
}