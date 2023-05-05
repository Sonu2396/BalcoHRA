using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BalcoHRA.Business_Layer.PotLine.Operation
{
    public class BL_Surveysheet
    {
        FPManager cn = new FPManager();

        #region Survey sheet Load,Save Etc....

        //Surveysheet Entry Load

        public DataTable SurveySheetEntry_Check_EnableforEntry_Data(string Date,string Potline,string Section,string Shift,string Schedule)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_CHECK_SCHEDULE"
             , new string[] { "@DATE", "@POTLINE", "@SECTION","@SHIFT","@SCHEDULETYPE" }
                , new string[] { Date, Potline, Section,Shift,Schedule });
            return dt;
        }

        public bool Planning_Save(string fromdate, string todate, string potline)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_POTLINE_PLANNING_TRANS_SCHEDULE"
                 , new string[] { "@fromdate", "@todate", "@line" }
                 , new string[] { fromdate, todate, potline });
            return Result;
        }
        public DataTable SurveySheetEntry_LoadData_Data(string Date, string Potline, string Section, string Shift, string UesrId,string Tappingtype,string ScheduleType)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_LOAD_SURVEYSHEET_ENTRYDATA"
             , new string[] { "@DATE", "@POTLINE", "@SECTION", "@SHIFT", "@USERID", "@TappingType" , "@SCHEDULETYPE" }
                , new string[] { Date, Potline, Section, Shift, UesrId,Tappingtype, ScheduleType });
            return dt;
        }
        public DataSet SurveySheetEntry_LoadAgeCathodtype_Data(string Potno, string Potline)
        {
            DataSet ds = new DataSet();
            //ds = cn.GetdataSet_PMIS("SP_GET_FP_SURVEYSHEET_DATA"
            // , new string[] { "@POTNO", "@POTLINE" }
            //    , new string[] { Potno, Potline });
            return ds;
        }
        public DataTable SurveySheetEntry_LoadBath_Data(string Potno)
        {
            DataTable dt = new DataTable();
            //dt = cn.GetDataTable_PLANTII("SP_REPORT_SURVEYSHEET_BATH"
            // , new string[] { "@POTNO"}
            //    , new string[] { Potno });
            return dt;
        }

        public DataTable Last3months_CE_Data()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SELECT * FROM TBL_POT_SURVEYSHEET_LAST3MONTHSDATA ORDER BY POTNO");
            return dt;
        }
        public string UploadLast3Months_Save(string Potline, string Section, string Potno,string LastCe,string Userid)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_OPERATION_TRANS_UPLOAD_LAST3MONTHS"
                 , new string[] { "@POTLINE", "@SECTION", "@POTNO", "@LASTCE", "@LASTUPDATEDBY" }
                 , new string[] { Potline, Section, Potno,LastCe,Userid });
            return Result;
        }
        public string SurveySheet_Save(string DDATE,string TAPLINE,string TAPSECTION,string TAPSHIFT,string POTNO,string STARTUPDATE,string AGE,string BLOCK,string CATHODTYPE,
            string LAST3MONTH,string DECCE,string CVD,string PREVBATH,string BATHTEMP,string ALF3,string CATEGORY,string LASTML,string ML,string BL,string PENDINGREC,string ACTREC,string BATHTAP,
            string BATHPOUR,string FE,string SI,string GRADE,string ALF3SETTING,string VCVD,string BASESETV,string SETV,string NB,string AFTERTAP,string COKE,string USERID,
            string FINALSUBMIT,string ISSTOPPOT,string LASTALF3,string ALUMINA,string WTDAVG,string Graphatise,string OldPot,string KaCurrent,string TappingType,string EntryType)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_OPERATION_SAVE_SURVEYSHEET"
                 , new string[] { "@DDATE","@TAPLINE","@TAPSECTION","@TAPSHIFT","@POTNO","@STARTUPDATE","@AGE","@BLOCK","@CATHODTYPE","@LAST3MONTH","@DECCE","@CVD","@PREVBATH",
                                    "@BATHTEMP","@ALF3","@CATEGORY","@LASTML","@ML","@BL","@PENDINGREC","@ACTREC","@BATHTAP","@BATHPOUR","@FE","@SI","@GRADE","@ALF3SETTING","@VCVD","@BASESETV","@SETV",
                                    "@NB","@AFTERTAP","@COKE","@USERID","@FINALSUBMIT","@ISSTOPPOT","@LASTALF3","@ALUMINA","@WTDAVG","@Graphatise","@OldPot","@KaCurrent","@TappingType","@EntryType" }
                 , new string[] { DDATE,TAPLINE,TAPSECTION,TAPSHIFT,POTNO,STARTUPDATE,AGE,BLOCK,CATHODTYPE,LAST3MONTH,DECCE,CVD,PREVBATH,BATHTEMP,ALF3,CATEGORY,LASTML,ML,BL,PENDINGREC,
                                    ACTREC,BATHTAP,BATHPOUR,FE,SI,GRADE,ALF3SETTING,VCVD,BASESETV,SETV,NB,AFTERTAP,COKE,USERID,FINALSUBMIT,ISSTOPPOT,LASTALF3,ALUMINA,WTDAVG,Graphatise,
                                    OldPot,KaCurrent,TappingType,EntryType});
            return Result;
        }

        #endregion



        #region Report Load Survey Sheet Data

        public DataTable LodSurveysheet(string Date, string Potline, string Section, string Shift, string TappingType)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_REPORT_SURVEYSHEET"
             , new string[] { "@DATE", "@POTLINE", "@SECTION", "@SHIFT", "@TAPPINGTYPE" }
                , new string[] { Date, Potline, Section, Shift, TappingType });
            return dt;
        }
        public DataTable EmailSurveysheet(string MailType)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_MAIL_DETAILS"
             , new string[] { "@MAILTYPE" }
                , new string[] { MailType });
            return dt;
        }
        public bool SurveySheet_Data_Delete(string DDATE, string TAPLINE, string TAPSECTION, string TappingType, string UserId)
        {
            bool Result = false;
            Result = cn.ExecuteQuerySP("SP_POTLINE_OPERATION_DELETE_SURVEYSHEET"
                 , new string[] { "@DDATE", "@TAPLINE", "@TAPSECTION", "@TappingType", "@USERID" }
                 , new string[] { DDATE, TAPLINE, TAPSECTION, TappingType, UserId });
            return Result;
        }

        #endregion

        #region Report Load potline Survey Sheet Data

        public DataTable LodPotLineSurveysheet(string Date, string Potline, string Section)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_REPORT_POTLINE_SURVEYSHEET"
             , new string[] { "@DATE", "@POTLINE", "@SECTION"}
                , new string[] { Date, Potline, Section });
            return dt;
        }


        #endregion

        #region Internal PotPouring
        public string Internal_Potpouring_Save(string TRANSKEYCODE, string POURTYPE, string POURDATE, string POURSHIFT, string POURLINE, string POTNO, string POURQTY, string INTERPOT, string CREATIONBY)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_POTLINE_OPERATION_SURVEYSHEET_POT_INTERAL_POURING"
                 , new string[] { "@TRANSKEYCODE","@POURTYPE","@POURDATE","@POURSHIFT","@POURLINE","@POTNO","@POURQTY","@INTERPOT", "@CREATIONBY" , "@TRANSTYPE" }
                 , new string[] { TRANSKEYCODE,POURTYPE,POURDATE,POURSHIFT,POURLINE,POTNO,POURQTY,INTERPOT, CREATIONBY, "Save"});
            return Result;
        }
        #endregion
    }
}