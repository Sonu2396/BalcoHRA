using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace BalcoHRA.Business_Layer.CastHouse.Reports
{
    public class BL_CH_Report
    {
        FPManager cn = new FPManager();

      


        #region Furnace  Report
        public DataTable Rpt_Get_CH_Tapslip(string Date,string Shift,string Potline,string Section,string Location,string SortOrder)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_REPORT_TAPPING_SLIPNO"
              , new string[] { "@DATE", "@SHIFT","@LOCATION", "@POTLINE", "@SECTION","@SORTORDER"}
              , new string[] { Date,Shift,Location,Potline,Section,SortOrder });
            return dt;
        }
        public DataTable Rpt_Get_CH_Tapslip_Purity(string Date, string Shift, string Potline, string Section, string Location, string SortOrder)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_REPORT_TAPPING_SLIPNO_PURITY"
              , new string[] { "@DATE", "@SHIFT", "@LOCATION", "@POTLINE", "@SECTION", "@SORTORDER" }
              , new string[] { Date, Shift, Location, Potline, Section, SortOrder });
            return dt;
        }

        #endregion
    }
}