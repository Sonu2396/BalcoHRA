using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BalcoHRA.Business_Layer.PotLine.FeAnalysis
{
    public class BL_FeReason
    {

        MESVEDANTAManager cn = new MESVEDANTAManager();
        PLANTIIManager cnP = new PLANTIIManager();

        #region Crtitacla Fe/Si Details Start..........
        public DataTable Critical_Fe_Si_Trend_List(string potline, string section, string pot, string Trndname, string shift, string Date, string ReportType, string AgeVAl)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_Fe_Si_Critical_Pot_Trend_ShiftWise"
              , new string[] { "@potline", "@section", "@pot", "@Trndname", "@shift", "@Date", "@ReportType", "@AgeVAl" }
              , new string[] { potline, section, pot, Trndname, shift, Date, ReportType, AgeVAl });
            return dt;
        }
        #endregion
        #region  Fe/Si Details Start..........


        public DataTable Fe_Si_Trend_List(string potline, string section, string pot, string Trndname, string ReportType, string potAgeval, string potAgevalto, string FeVal, string PotAgeSymbleval)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_FeSi_Trend_DayWise"
              , new string[] { "@potline", "@section", "@pot", "@Trndname", "@ReportType", "@potAgeval", "@potAgevalto", "@FeVal", "@PotAgeSymbleval" }
              , new string[] { potline, section, pot, Trndname, ReportType, potAgeval, potAgevalto, FeVal, PotAgeSymbleval });
            return dt;
        }
        public DataTable Low_Fe_Si_MetalCalculation_List(string potline, string group, string pot, string Date, string ReportType, string ReportVal)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_Report_LowFe_MetalCalculation"
              , new string[] { "@potline", "@group", "@pot", "@Date", "@ReportType", "@ReportVal" }
              , new string[] { potline, group, pot, Date, ReportType, ReportVal });
            return dt;
        }
        #endregion



        #region Fe Reason add Start..........
        public DataTable Fe_Reason_Recently_Add_List()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT TOP 25 [POTLINE], [ROOM], [SECTION], [POT], [ANODEGROUP], [MAINREASON], [SUBREASON1], [SUBREASON2], [SUBREASON3], [COMMENT], [DATE],PHOTOPATH, [CREATEDBY], [ID] FROM [TBL_POTLINE_BALCO_TRANSACTION_MASTER] ORDER BY id DESC");
            return dt;
        }
        public bool Fe_Reason_Recently_Delete(string ID)
        {
            bool Result;
            Result = cn.ExecuteQuery("DELETE FROM  TBL_POTLINE_BALCO_TRANSACTION_MASTER WHERE ID='" + ID + "'");
            return Result;


        }

        public bool Fe_Reason_Save(string POTLINE, string ROOM, string Date, string SECTION, string POT,
        string MAINREASON, string ANODEGROUP,
        string SUBREASON1, string SUBREASON2, string SUBREASON3, string COMMENT,
        string CREATEDBY, string PHOTOPATH)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_TBL_POTLINE_BALCO_TRANSACTION_MASTER_INSERT"
              , new string[] {  "@POTLINE","@ROOM","@Date","@SECTION","@POT","@MAINREASON","@ANODEGROUP",
                                 "@SUBREASON1","@SUBREASON2","@SUBREASON3","@COMMENT",
                                    "@CREATEDBY","@PHOTOPATH"}
              , new string[] {  POTLINE,  ROOM,  Date,  SECTION,  POT, MAINREASON,  ANODEGROUP,
                                SUBREASON1,  SUBREASON2,  SUBREASON3,  COMMENT,
                                CREATEDBY,  PHOTOPATH });
            return Result;
        }




        #endregion


        #region Pot Analysis

        public DataTable PotAnalysis_Gen_info(string potno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("sp_potline_pot_gen_info_fe_reason"
              , new string[] { "@potno" }
              , new string[] { potno });
            return dt;
        }
        public DataTable PotAnalysis_CBT_info(string potno)
        {
            DataTable dt = new DataTable();
            dt = cnP.GetDataTable("SP_REPORT_CBT_FE_ANALYSIS"
              , new string[] { "@potno" }
              , new string[] { potno });
            return dt;
        }
        public DataTable PotAnalysis_CBT_info_TOP10(string potno, string sdate)
        {
            DataTable dt = new DataTable();
            dt = cnP.GetDataTable("SP_REPORT_CBT_FE_ANALYSIS_TOP10"
              , new string[] { "@potno", "@sdate" }
              , new string[] { potno, sdate });
            return dt;
        }
        public DataTable PotAnalysis_CCD_info(string potno)
        {
            DataTable dt = new DataTable();
            dt = cnP.GetDataTable("SP_REPORT_CCD_FE_ANALYSIS"
              , new string[] { "@potno" }
              , new string[] { potno });
            return dt;
        }
        public DataTable PotAnalysis_PBST_info(string potno)
        {
            DataTable dt = new DataTable();
            dt = cnP.GetDataTable("SP_REPORT_PBST_FE_ANALYSIS"
              , new string[] { "@potno" }
              , new string[] { potno });
            return dt;
        }
        public DataTable PotAnalysis_PBST_info_TOP10(string potno, string sdate)
        {
            DataTable dt = new DataTable();
            dt = cnP.GetDataTable("SP_REPORT_PBST_FE_ANALYSIS_TOP10"
              , new string[] { "@potno", "@sdate" }
              , new string[] { potno, sdate });
            return dt;
        }
        public DataTable PotAnalysis_top5_info(string potno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("sp_top_5_Fe_Reason"
              , new string[] { "@pot" }
              , new string[] { potno });
            return dt;
        }
        public DataTable PotAnalysis_top5_Image(string potno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("select top 5 convert(nvarchar(max), PHOTOPATH) as photopath, createdby   ,SUBREASON1 ,SUBREASON2 ,SUBREASON3,COMMENT, convert(varchar(7),Date,6) as [Date] FROM [MESVEDANTA].[dbo].[TBL_POTLINE_BALCO_TRANSACTION_MASTER] where Photopath is not NULL and  PHOTOPATH!=''and pot='" + Convert.ToString(potno) + "' order by  Date desc ");
            return dt;
        }
        public DataTable PotAnalysis_top30_FeTrend_info(string potno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("sp_last_30_days_Fe_Trend"
              , new string[] { "@pot" }
              , new string[] { potno });
            return dt;
        }
        public DataTable PotAnalysis_Fe_SiAnalysis_info(string potno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("Sp_Bath_Temp_Fe_Si_Cr_Pot_Analysis"
              , new string[] { "@potno" }
              , new string[] { potno });
            return dt;
        }

        #endregion

        #region  Delete EntryList
        public DataTable Fe_Delete_list(string potno)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("sp_delete_Fe_Reason"
              , new string[] { "@pot" }
              , new string[] { potno });
            return dt;
        }
        #endregion

        #region Summary Report
        public DataTable Fe_Summary_Report(string potline, string section, string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_REPORT_FE_SUMMARY"
              , new string[] { "@potline", "@section", "@SDate", "@EDate" }
              , new string[] { potline, section, FromDate, ToDate });
            return dt;
        }
        #endregion
        #region Summary Report
        public DataTable Grade_Vs_Section_Summary_Report(string potline, string section, string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_DASHBOARD_METAL_GRADE_VS_SECTION"
              , new string[] { "@potline", "@section", "@SDate", "@EDate" }
              , new string[] { potline, section, FromDate, ToDate });
            return dt;
        }
        public DataTable Grade_Vs_Room_Summary_Report(string potline, string section, string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_DASHBOARD_METAL_GRADE_VS_ROOM"
              , new string[] { "@potline", "@section", "@SDate", "@EDate" }
              , new string[] { potline, section, FromDate, ToDate });
            return dt;
        }
        public DataTable Grade_Vs_Potline_Summary_Report(string potline, string section, string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_DASHBOARD_METAL_GRADE_VS_POTLINE"
              , new string[] { "@potline", "@section", "@SDate", "@EDate" }
              , new string[] { potline, section, FromDate, ToDate });
            return dt;
        }
        public DataTable Grade_Vs_Potline_Metal_Qty_Summary_Report(string potline, string section, string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_DASHBOARD_METAL_GRADE_VS_POTLINE_METAL_QTY"
              , new string[] { "@potline", "@section", "@SDate", "@EDate" }
              , new string[] { potline, section, FromDate, ToDate });
            return dt;
        }

        public DataTable Grade_Vs_section_DateWise_Summary_Report(string potline, string section, string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_DASHBOARD_METAL_GRADE_VS_SECTION_DATEWISE"
              , new string[] { "@potline", "@section", "@SDate", "@EDate" }
              , new string[] { potline, section, FromDate, ToDate });
            return dt;
        }
        public DataTable Grade_Vs_potno_DateWise_Summary_Report(string potline, string section, string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_DASHBOARD_METAL_GRADE_VS_POTNO_DATEWISE"
              , new string[] { "@potline", "@section", "@SDate", "@EDate" }
              , new string[] { potline, section, FromDate, ToDate });
            return dt;
        }
        #endregion





        #region Reason Summary Report

        public DataTable Reason_Summary_Report_PotWise(string potline, string section, string room, string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_DASHBOARD_REASON_SUMMARY_POT"
              , new string[] { "@potline", "@section", "@room", "@SDate", "@EDate" }
              , new string[] { potline, section, room, FromDate, ToDate });
            return dt;
        }


        public DataTable Reason_Summary_Report_MonthWise(string potline, string section, string room, string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_DASHBOARD_REASON_SUMMARY_MONTHWISE"
              , new string[] { "@potline", "@section", "@room", "@SDate", "@EDate" }
              , new string[] { potline, section, room, FromDate, ToDate });
            return dt;
        }
        public DataTable Reason_Vs_Potline_Summary_Report(string potline, string section, string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_DASHBOARD_REASON_SUMMARY_POTLINE"
              , new string[] { "@potline", "@section", "@SDate", "@EDate" }
              , new string[] { potline, section, FromDate, ToDate });
            return dt;
        }

        public DataTable Reason_Vs_Section_Summary_Report(string potline, string section, string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_DASHBOARD_REASON_SUMMARY_SECTION"
              , new string[] { "@potline", "@section", "@SDate", "@EDate" }
              , new string[] { potline, section, FromDate, ToDate });
            return dt;
        }
        public DataTable Reason_Vs_Room_Summary_Report(string potline, string section, string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_DASHBOARD_REASON_SUMMARY_ROOM"
              , new string[] { "@potline", "@section", "@SDate", "@EDate" }
              , new string[] { potline, section, FromDate, ToDate });
            return dt;
        }

        #endregion

    }
}