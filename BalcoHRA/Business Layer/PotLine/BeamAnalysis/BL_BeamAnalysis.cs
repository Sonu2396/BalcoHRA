using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BalcoHRA.Business_Layer.PotLine.BeamAnalysis
{
    public class BL_BeamAnalysis
    {

        FPManager cn = new FPManager();
        PLANTIIManager cnP = new PLANTIIManager();
        KioskManager Ksk = new KioskManager();
        #region BEAM TO BEAM
        public bool Beam_Beam_Save(string TRDATE, string TRSHIFT, string POTLINE, string SECTION, string POTNO, string TE, string DE, string REMARKS, string USERID)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_POTLINE_BEAM_BEAM_SAVE"
                , new string[] { "@TRDATE", "@TRSHIFT", "@POTLINE", "@SECTION", "@POTNO", "@TE", "@DE", "@REMARKS",  "@USERID" }
                , new string[] { TRDATE, TRSHIFT, POTLINE, SECTION, POTNO, TE, DE, REMARKS, USERID});
            return Result;
        }
        public DataTable Beam_Beam_Report_Date(string TRDATE, string POTLINE, string SECTION)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_BEAM_BEAM_UPDATE_LIST"
                , new string[] { "@TRDATE", "@POTLINE", "@SECTION" }
                , new string[] { TRDATE, POTLINE, SECTION });
            return dt;
        }
        public DataTable Beam_Beam_Report_Daywise(string SDATE, string EDATE, string POTLINE, string SECTION)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_BEAM_BEAM_REPORT_DAYWISE"
                , new string[] { "@SDATE","@EDATE", "@POTLINE", "@SECTION" }
                , new string[] { SDATE,EDATE, POTLINE, SECTION });
            return dt;
        }

        #endregion





    }
}