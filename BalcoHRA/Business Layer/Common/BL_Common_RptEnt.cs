using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BalcoHRA.Business_Layer;
namespace BalcoHRA.Business_Layer.Common
{
    public class BL_Common_RptEnt
    {
        FPManager cn = new FPManager();
       
        public DataSet Get_TappingSlip_Status_Report(string Tapslipno)
        {
            DataSet ds = new DataSet();
            ds = cn.GetDataSet("SP_POTLINE_REPORT_TAPSLIP_STATUS"
              , new string[] { "@Tapslipno" }
              , new string[] { Tapslipno });
            return ds;
        }
        public DataTable Purity_Slip_List(string Tapdate, string TapShift, string Potline, string Section, string DataSort)
        {

            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_REPORT_TAPPING_SLIPNO_PURITY"
                , new string[] { "@DATE", "@SHIFT", "@POTLINE", "@SECTION", "@SORTORDER" }
                   , new string[] { Tapdate, TapShift, Potline, Section, DataSort });

            return dt;
        }
        public DataTable Hotmetal_Report(string SDATE,string EDATE,string SHIFT,string POTLINE,string  SECTION,string LOCATION,string GRADE)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_COMMON_REPORT_HOTMETAL"
              , new string[] { "@SDATE", "@EDATE", "@SHIFT", "@POTLINE", "@SECTION", "@LOCATION", "@GRADE" }
              , new string[] { SDATE, EDATE, SHIFT, POTLINE, SECTION, LOCATION, GRADE });
            return dt;
        }
        public DataTable Hotmetal_Report_InBase(string SDATE, string EDATE, string SHIFT, string POTLINE, string SECTION, string LOCATION)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_COMMON_REPORT_HOTMETAL_INBASE"
              , new string[] { "@SDATE", "@EDATE", "@SHIFT", "@POTLINE", "@SECTION", "@LOCATION" }
              , new string[] { SDATE, EDATE, SHIFT, POTLINE, SECTION, LOCATION });
            return dt;
        }
        public DataTable PFA_Exception_Report(string SDATE, string EDATE)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_COMMON_REPORT_PFA_EXCEPTION"
              , new string[] { "@SDATE", "@EDATE" }
              , new string[] { SDATE, EDATE });
            return dt;
        }


    }
}