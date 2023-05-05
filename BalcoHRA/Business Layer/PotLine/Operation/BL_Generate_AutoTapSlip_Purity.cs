using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BalcoHRA.Business_Layer.PotLine.Operation
{
    public class BL_Generate_AutoTapSlip_Purity
    {
        FPManager cn = new FPManager();

        #region Generate Purity Slip Start

        public DataTable Generate_Tapping_Slip_Purity()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_GENERATE_PURITY_SLIP_STEP0");
            return dt;
        }

        public DataTable Fetch_Purity_Line_Section(string Date, string Shift)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_GENERATE_PURITY_SLIP_STEP1"
             , new string[] { "@TAPDATE", "@TAPSHIFT" }
                , new string[] { Date, Shift });
            return dt;
        }
        public DataTable Fetch_Blend_Pot(string Position, string LineSec, string Date, string Shift, string Fe, string Si, string Purity, string SortOrder)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_GENERATE_PURITY_SLIP_STEP3"
             , new string[] { "@POSITION", "@LINESEC", "@TAPDATE", "@TAPSHIFT", "@FE", "@SI", "@Purity", "@SORTORDER" }
                , new string[] { Position, LineSec, Date, Shift, Fe, Si, Purity, SortOrder });
            return dt;

        }
        public DataTable Fetch_Blend_Mix_Pot(string Position, string LineSec, string Date, string Shift, string Fe, string Si, string Purity, string SortOrder)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_GENERATE_PURITY_SLIP_MERGE_POT"
             , new string[] { "@POSITION", "@LINESEC", "@TAPDATE", "@TAPSHIFT", "@FE", "@SI", "@Purity", "@SORTORDER" }
                , new string[] { Position, LineSec, Date, Shift, Fe, Si, Purity, SortOrder });
            return dt;

        }
        public DataTable Fetch_Step4_MixPot(double fe, double si, double purity)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_GENERATE_PURITY_SLIP_STEP4"
             , new string[] { "@fe", "@si", "@purity" }
                , new string[] { fe.ToString(), si.ToString(), purity.ToString() });
            return dt;


        }
        public DataTable Fetch_Step5_FinalPot(string TAPDATE, string TAPSHIFT, string POTID, string FID, string SLIPNO, string FFE, string FSI, string FPURITY, string FGRADE, string FTOTWT, string ISSUEWT)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_GENERATE_PURITY_SLIP_STEP5"
             , new string[] { "@TAPDATE", "@TAPSHIFT", "@POTID", "@FID", "@SLIPNO", "@FFE", "@FSI", "@FPURITY", "@FGRADE", "@FTOTWT", "@ISSUEWT" }
                , new string[] { TAPDATE, TAPSHIFT, POTID, FID, SLIPNO, FFE, FSI, FPURITY, FGRADE, FTOTWT, ISSUEWT });
            return dt;

        }
        public DataTable Blending_Potsamegrade_Purity_PotLine1(DataTable dvpotdsc, DataTable dvpotdscMIX, int SLNo, int PotLine)
        {



            int CompareQty = 0;
            if (PotLine == 1)
            {
                CompareQty = 5000;
            }
            else
            {
                CompareQty = 9000;
            }


            DataSet ds = new DataSet();
            DataTable dtfinal = new DataTable();
            dtfinal.Columns.Add("POT");
            dtfinal.Columns.Add("RECWT");
            dtfinal.Columns.Add("FE");
            dtfinal.Columns.Add("SI");
            dtfinal.Columns.Add("PURITY");
            dtfinal.Columns.Add("GRADE");
            dtfinal.Columns.Add("FFE");
            dtfinal.Columns.Add("FSI");
            dtfinal.Columns.Add("FPURITY");
            dtfinal.Columns.Add("FGRADE");
            dtfinal.Columns.Add("FTOTWT");
            dtfinal.Columns.Add("POTID");
            dtfinal.Columns.Add("ISSUEWT");
            dtfinal.Columns.Add("SLIPNO");
            dtfinal.Columns.Add("ISBLEND");
            dtfinal.Columns.Add("BALWT");
            dtfinal.Columns.Add("LADLE");
            int i = dvpotdsc.Rows.Count;
            int j = dvpotdsc.Rows.Count;
            int actrow = 0;
            int mixrow = 0;
            int m = 0;
            int sum = 0;
            int ladle = 0;


            double sumfe = 0;
            double sumsi = 0;
            double sumpurirty = 0;
            int max = 0;
            int min = 0;
            int rowstatus = 1;
            int norowsadd = 0;
            for (int a = 0; a < i; a++)
            {

                if (Convert.ToInt32(dvpotdsc.Rows[a]["BALWT"].ToString()) > 500)
                {
                    if (rowstatus == 1)
                    {
                        try
                        {
                            max = Convert.ToInt32(dvpotdsc.Rows[a]["POT"].ToString()) + 3;
                        }
                        catch
                        {
                            max = Convert.ToInt32(dvpotdsc.Rows[a]["POT"].ToString());
                        }



                        try
                        {
                            min = Convert.ToInt32(dvpotdsc.Rows[a]["POT"].ToString()) - 3;
                        }
                        catch
                        {
                            min = Convert.ToInt32(dvpotdsc.Rows[a]["POT"].ToString());
                        }


                        sum = 0;
                        sum = sum + Convert.ToInt32(dvpotdsc.Rows[a]["BALWT"].ToString());




                        sumfe = (Convert.ToDouble(dvpotdsc.Rows[a]["FE"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[a]["BALWT"].ToString()));
                        sumsi = (Convert.ToDouble(dvpotdsc.Rows[a]["SI"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[a]["BALWT"].ToString()));
                        sumpurirty = (Convert.ToDouble(dvpotdsc.Rows[a]["PURITY"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[a]["BALWT"].ToString()));

                        DataView dvfg = new DataView();
                        DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                        dvfg = DSPot.DefaultView;
                        if (DSPot.Rows[0]["GRADE"].ToString() == "P1020")
                        {
                            SLNo = SLNo + 1;
                            ladle = ladle + 1;

                            DataRow drfinal1 = dtfinal.NewRow();
                            drfinal1["POT"] = dvpotdsc.Rows[a]["POT"].ToString();
                            drfinal1["POTID"] = dvpotdsc.Rows[a]["ID"].ToString();
                            drfinal1["RECWT"] = dvpotdsc.Rows[a]["RECWT"].ToString();
                            drfinal1["FE"] = dvpotdsc.Rows[a]["FE"].ToString();
                            drfinal1["SI"] = dvpotdsc.Rows[a]["SI"].ToString();
                            drfinal1["PURITY"] = dvpotdsc.Rows[a]["PURITY"].ToString();
                            drfinal1["GRADE"] = dvpotdsc.Rows[a]["GRADE"].ToString();
                            drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                            drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                            drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                            drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                            drfinal1["FTOTWT"] = Convert.ToString(sum);
                            drfinal1["ISSUEWT"] = dvpotdsc.Rows[a]["BALWT"].ToString();
                            drfinal1["SLIPNO"] = SLNo;
                            drfinal1["SLIPNO"] = SLNo;
                            drfinal1["LADLE"] = ladle;
                            drfinal1["BALWT"] = 0;
                            drfinal1["ISBLEND"] = 0;

                            dtfinal.Rows.Add(drfinal1);

                            rowstatus = 2;
                            norowsadd = 1;
                        }
                        else
                        {
                            sumfe = 0;
                            sumsi = 0;
                            sumpurirty = 0;


                        }


                    }
                    else
                    {

                        int bfrow = dtfinal.Rows.Count - 1;

                        for (m = 0; m <= dvpotdscMIX.Rows.Count - 1; m++)
                        {

                            if (Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()) > 500)
                            {

                                if (Convert.ToInt32(dvpotdscMIX.Rows[m]["POT"].ToString()) >= min && Convert.ToInt32(dvpotdscMIX.Rows[m]["POT"].ToString()) <= max)
                                {


                                    sum = sum + Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());


                                    //  int actsum = CompareQty - sum;
                                    if (sum <= CompareQty)
                                    {
                                        sumfe = sumfe + (Convert.ToDouble(dvpotdscMIX.Rows[m]["FE"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                                        sumsi = sumsi + (Convert.ToDouble(dvpotdscMIX.Rows[m]["SI"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                                        sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdscMIX.Rows[m]["PURITY"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));


                                        DataView dvfg = new DataView();
                                        DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                                        dvfg = DSPot.DefaultView;

                                        if (DSPot.Rows[0]["GRADE"].ToString() == "P1020")
                                        {
                                            DataRow drfinal1 = dtfinal.NewRow();
                                            drfinal1["POT"] = dvpotdscMIX.Rows[m]["POT"].ToString();
                                            drfinal1["POTID"] = dvpotdscMIX.Rows[m]["ID"].ToString();
                                            drfinal1["RECWT"] = dvpotdscMIX.Rows[m]["RECWT"].ToString();
                                            drfinal1["FE"] = dvpotdscMIX.Rows[m]["FE"].ToString();
                                            drfinal1["SI"] = dvpotdscMIX.Rows[m]["SI"].ToString();
                                            drfinal1["PURITY"] = dvpotdscMIX.Rows[m]["PURITY"].ToString();
                                            drfinal1["GRADE"] = dvpotdscMIX.Rows[m]["GRADE"].ToString();
                                            drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                                            drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                                            drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                                            drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                                            drfinal1["FTOTWT"] = Convert.ToString(sum);
                                            drfinal1["ISSUEWT"] = Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());
                                            drfinal1["ISBLEND"] = 0;
                                            drfinal1["SLIPNO"] = SLNo;
                                            drfinal1["LADLE"] = ladle;
                                            drfinal1["BALWT"] = 0;
                                            drfinal1["ISBLEND"] = 0;
                                            dtfinal.Rows.Add(drfinal1);


                                            dvpotdscMIX.Rows[m]["BALWT"] = 0;


                                            for (int u = 0; u <= dtfinal.Rows.Count - 1; u++)
                                            {
                                                dtfinal.Rows[u]["ISBLEND"] = 1;
                                            }

                                            m = m;
                                            //a = a - 1;
                                            rowstatus = 1;
                                            norowsadd = 2;
                                            break;

                                        }
                                        else
                                        {
                                            sumfe = sumfe - (Convert.ToDouble(dvpotdscMIX.Rows[m]["FE"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                                            sumsi = sumsi - (Convert.ToDouble(dvpotdscMIX.Rows[m]["SI"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                                            sumpurirty = sumpurirty - (Convert.ToDouble(dvpotdscMIX.Rows[m]["PURITY"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                                            sum = sum - Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());
                                        }


                                    }
                                    else
                                    {
                                        sum = sum - Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());
                                        int achdiff = CompareQty - sum;

                                        sum = sum + achdiff;
                                        sumfe = sumfe + (Convert.ToDouble(dvpotdscMIX.Rows[m]["FE"].ToString()) * (Convert.ToInt32(achdiff)));
                                        sumsi = sumsi + (Convert.ToDouble(dvpotdscMIX.Rows[m]["SI"].ToString()) * (Convert.ToInt32(achdiff)));
                                        sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdsc.Rows[m]["PURITY"].ToString()) * (Convert.ToInt32(achdiff)));

                                        DataView dvfg = new DataView();
                                        DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                                        dvfg = DSPot.DefaultView;

                                        if (DSPot.Rows[0]["GRADE"].ToString() == "P1020")
                                        {
                                            dvpotdscMIX.Rows[m]["BALWT"] = Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()) - (Convert.ToInt32(achdiff));

                                            DataRow drfinal1 = dtfinal.NewRow();
                                            drfinal1["POT"] = dvpotdscMIX.Rows[m]["POT"].ToString();
                                            drfinal1["POTID"] = dvpotdscMIX.Rows[m]["ID"].ToString();
                                            drfinal1["RECWT"] = dvpotdscMIX.Rows[m]["RECWT"].ToString();
                                            drfinal1["FE"] = dvpotdscMIX.Rows[m]["FE"].ToString();
                                            drfinal1["SI"] = dvpotdscMIX.Rows[m]["SI"].ToString();
                                            drfinal1["PURITY"] = dvpotdscMIX.Rows[m]["PURITY"].ToString();
                                            drfinal1["GRADE"] = dvpotdscMIX.Rows[m]["GRADE"].ToString();
                                            drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                                            drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                                            drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                                            drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                                            drfinal1["FTOTWT"] = Convert.ToString(sum);
                                            drfinal1["ISSUEWT"] = Convert.ToInt32(achdiff);
                                            drfinal1["ISBLEND"] = 0;
                                            drfinal1["SLIPNO"] = SLNo;
                                            drfinal1["LADLE"] = ladle;
                                            drfinal1["ISBLEND"] = 0;
                                            drfinal1["BALWT"] = Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());
                                            dtfinal.Rows.Add(drfinal1);

                                            //fOR uPDATE ISBLEND TO 1
                                            for (int u = 0; u <= dtfinal.Rows.Count - 1; u++)
                                            {
                                                dtfinal.Rows[u]["ISBLEND"] = 1;
                                            }

                                            m = m;
                                            //a = a - 1;
                                            rowstatus = 1;

                                            break;
                                        }

                                        else
                                        {
                                            sumfe = sumfe - (Convert.ToDouble(dvpotdscMIX.Rows[m]["FE"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                                            sumsi = sumsi - (Convert.ToDouble(dvpotdscMIX.Rows[m]["SI"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                                            sumpurirty = sumpurirty - (Convert.ToDouble(dvpotdscMIX.Rows[m]["PURITY"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                                            sum = sum - Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()); ;
                                        }


                                    }
                                }

                            }


                        }

                        int afrow = dtfinal.Rows.Count - 1;

                        if (bfrow == afrow)


                        {
                            for (int x = a; x < i; x++)
                            {


                                if (Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()) > 500)
                                {

                                    if (Convert.ToInt32(dvpotdsc.Rows[x]["POT"].ToString()) >= min && Convert.ToInt32(dvpotdsc.Rows[x]["POT"].ToString()) <= max)
                                    {


                                        sum = sum + Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString());


                                        if (sum <= CompareQty)
                                        {
                                            sumfe = sumfe + (Convert.ToDouble(dvpotdsc.Rows[x]["FE"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()));
                                            sumsi = sumsi + (Convert.ToDouble(dvpotdsc.Rows[x]["SI"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()));
                                            sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdsc.Rows[x]["PURITY"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()));

                                            DataView dvfg = new DataView();
                                            DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                                            dvfg = DSPot.DefaultView;


                                            if (DSPot.Rows[0]["GRADE"].ToString() == "P1020")
                                            {
                                                DataRow drfinal1 = dtfinal.NewRow();
                                                drfinal1["POT"] = dvpotdsc.Rows[x]["POT"].ToString();
                                                drfinal1["POTID"] = dvpotdsc.Rows[x]["ID"].ToString();
                                                drfinal1["RECWT"] = dvpotdsc.Rows[x]["RECWT"].ToString();
                                                drfinal1["FE"] = dvpotdsc.Rows[x]["FE"].ToString();
                                                drfinal1["SI"] = dvpotdsc.Rows[x]["SI"].ToString();
                                                drfinal1["PURITY"] = dvpotdsc.Rows[x]["PURITY"].ToString();
                                                drfinal1["GRADE"] = dvpotdsc.Rows[x]["GRADE"].ToString();
                                                drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                                                drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                                                drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                                                drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                                                drfinal1["FTOTWT"] = Convert.ToString(sum);
                                                drfinal1["ISSUEWT"] = Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString());
                                                drfinal1["ISBLEND"] = 0;
                                                drfinal1["SLIPNO"] = SLNo;
                                                drfinal1["LADLE"] = ladle;
                                                drfinal1["BALWT"] = 0;
                                                drfinal1["ISBLEND"] = 0;
                                                dtfinal.Rows.Add(drfinal1);



                                                dvpotdsc.Rows[x]["BALWT"] = 0;

                                                for (int u = 0; u <= dtfinal.Rows.Count - 1; u++)
                                                {
                                                    dtfinal.Rows[u]["ISBLEND"] = 1;
                                                }

                                                m = m;
                                                rowstatus = 1;
                                                a = x - 1;
                                                break;

                                            }
                                            else
                                            {
                                                sumfe = sumfe - (Convert.ToDouble(dvpotdsc.Rows[x]["FE"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()));
                                                sumsi = sumsi - (Convert.ToDouble(dvpotdsc.Rows[x]["SI"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()));
                                                sumpurirty = sumpurirty - (Convert.ToDouble(dvpotdsc.Rows[x]["PURITY"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()));
                                                sum = sum - Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString());
                                            }


                                        }
                                        else
                                        {

                                            sum = sum - Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString());
                                            int achdiff = CompareQty - sum;

                                            sum = sum + achdiff;
                                            sumfe = sumfe + (Convert.ToDouble(dvpotdsc.Rows[x]["FE"].ToString()) * (Convert.ToInt32(achdiff)));
                                            sumsi = sumsi + (Convert.ToDouble(dvpotdsc.Rows[x]["SI"].ToString()) * (Convert.ToInt32(achdiff)));
                                            sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdsc.Rows[x]["PURITY"].ToString()) * (Convert.ToInt32(achdiff)));

                                            DataView dvfg = new DataView();
                                            DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                                            dvfg = DSPot.DefaultView;


                                            if (DSPot.Rows[0]["GRADE"].ToString() == "P1020")
                                            {
                                                dvpotdsc.Rows[x]["BALWT"] = Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()) - (Convert.ToInt32(achdiff));

                                                DataRow drfinal1 = dtfinal.NewRow();
                                                drfinal1["POT"] = dvpotdsc.Rows[x]["POT"].ToString();
                                                drfinal1["POTID"] = dvpotdsc.Rows[x]["ID"].ToString();
                                                drfinal1["RECWT"] = dvpotdsc.Rows[x]["RECWT"].ToString();
                                                drfinal1["FE"] = dvpotdsc.Rows[x]["FE"].ToString();
                                                drfinal1["SI"] = dvpotdsc.Rows[x]["SI"].ToString();
                                                drfinal1["PURITY"] = dvpotdsc.Rows[x]["PURITY"].ToString();
                                                drfinal1["GRADE"] = dvpotdsc.Rows[x]["GRADE"].ToString();
                                                drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                                                drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                                                drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                                                drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                                                drfinal1["FTOTWT"] = Convert.ToString(sum);
                                                drfinal1["ISSUEWT"] = (Convert.ToInt32(achdiff));
                                                drfinal1["ISBLEND"] = 0;
                                                drfinal1["SLIPNO"] = SLNo;
                                                drfinal1["LADLE"] = ladle;
                                                drfinal1["ISBLEND"] = 0;
                                                drfinal1["BALWT"] = Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString());
                                                dtfinal.Rows.Add(drfinal1);

                                                //fOR uPDATE ISBLEND TO 1
                                                for (int u = 0; u <= dtfinal.Rows.Count - 1; u++)
                                                {
                                                    dtfinal.Rows[u]["ISBLEND"] = 1;
                                                }

                                                m = m;
                                                rowstatus = 1;
                                                a = x - 1;
                                                break;

                                            }
                                            else
                                            {
                                                sumfe = sumfe - (Convert.ToDouble(dvpotdsc.Rows[x]["FE"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()));
                                                sumsi = sumsi - (Convert.ToDouble(dvpotdsc.Rows[x]["SI"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()));
                                                sumpurirty = sumpurirty - (Convert.ToDouble(dvpotdsc.Rows[x]["PURITY"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()));
                                                sum = sum - Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString());
                                            }



                                        }
                                    }

                                }



                                // End of Loop for Add new Manage Pot
                            }

                            int afrow1 = dtfinal.Rows.Count - 1;
                            if (afrow == afrow1)
                            {
                                rowstatus = 1;
                                a = a - 1;
                            }


                        }
                        else
                        {
                            a = a - 1;
                        }

                    }
                }






            }



            return dtfinal;
        }
        public DataTable Blending_Potsamegrade_Purity_PotLine2(DataTable dvpotdsc, DataTable dvpotdscMIX, int SLNo, int PotLine)
        {


            int CompareQty = 0;
            if (PotLine == 1)
            {
                CompareQty = 5000;
            }
            else
            {
                CompareQty = 9000;
            }


            DataSet ds = new DataSet();
            DataTable dtfinal = new DataTable();
            dtfinal.Columns.Add("POT");
            dtfinal.Columns.Add("RECWT");
            dtfinal.Columns.Add("FE");
            dtfinal.Columns.Add("SI");
            dtfinal.Columns.Add("PURITY");
            dtfinal.Columns.Add("GRADE");
            dtfinal.Columns.Add("FFE");
            dtfinal.Columns.Add("FSI");
            dtfinal.Columns.Add("FPURITY");
            dtfinal.Columns.Add("FGRADE");
            dtfinal.Columns.Add("FTOTWT");
            dtfinal.Columns.Add("POTID");
            dtfinal.Columns.Add("ISSUEWT");
            dtfinal.Columns.Add("SLIPNO");
            dtfinal.Columns.Add("ISBLEND");
            dtfinal.Columns.Add("BALWT");
            dtfinal.Columns.Add("LADLE");
            int i = dvpotdsc.Rows.Count;
            int j = dvpotdsc.Rows.Count;
            int actrow = 0;
            int mixrow = 0;
            int m = 0;
            int sum = 0;
            int ladle = 0;


            double sumfe = 0;
            double sumsi = 0;
            double sumpurirty = 0;
            int max = 0;
            int min = 0;
            int rowstatus = 1;
            for (int a = 0; a < i; a++)
            {

                if (rowstatus == 1)
                {
                    try
                    {
                        max = Convert.ToInt32(dvpotdsc.Rows[a]["POT"].ToString()) + 3;
                    }
                    catch
                    {
                        max = Convert.ToInt32(dvpotdsc.Rows[a]["POT"].ToString());
                    }



                    try
                    {
                        min = Convert.ToInt32(dvpotdsc.Rows[a]["POT"].ToString()) - 3;
                    }
                    catch
                    {
                        min = Convert.ToInt32(dvpotdsc.Rows[a]["POT"].ToString());
                    }


                    sum = 0;
                    sum = sum + Convert.ToInt32(dvpotdsc.Rows[a]["BALWT"].ToString());

                    SLNo = SLNo + 1;
                    ladle = ladle + 1;


                    sumfe = (Convert.ToDouble(dvpotdsc.Rows[a]["FE"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[a]["BALWT"].ToString()));
                    sumsi = (Convert.ToDouble(dvpotdsc.Rows[a]["SI"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[a]["BALWT"].ToString()));
                    sumpurirty = (Convert.ToDouble(dvpotdsc.Rows[a]["PURITY"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[a]["BALWT"].ToString()));

                    DataView dvfg = new DataView();
                    DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                    dvfg = DSPot.DefaultView;

                    DataRow drfinal1 = dtfinal.NewRow();
                    drfinal1["POT"] = dvpotdsc.Rows[a]["POT"].ToString();
                    drfinal1["POTID"] = dvpotdsc.Rows[a]["ID"].ToString();
                    drfinal1["RECWT"] = dvpotdsc.Rows[a]["RECWT"].ToString();
                    drfinal1["FE"] = dvpotdsc.Rows[a]["FE"].ToString();
                    drfinal1["SI"] = dvpotdsc.Rows[a]["SI"].ToString();
                    drfinal1["PURITY"] = dvpotdsc.Rows[a]["PURITY"].ToString();
                    drfinal1["GRADE"] = dvpotdsc.Rows[a]["GRADE"].ToString();
                    drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                    drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                    drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                    drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                    drfinal1["FTOTWT"] = Convert.ToString(sum);
                    drfinal1["ISSUEWT"] = dvpotdsc.Rows[a]["BALWT"].ToString();
                    drfinal1["SLIPNO"] = SLNo;
                    drfinal1["SLIPNO"] = SLNo;
                    drfinal1["LADLE"] = ladle;
                    drfinal1["BALWT"] = 0;
                    drfinal1["ISBLEND"] = 0;

                    dtfinal.Rows.Add(drfinal1);

                    rowstatus = 2;
                }
                else
                {
                    sum = sum + Convert.ToInt32(dvpotdsc.Rows[a]["BALWT"].ToString());


                    if (sum <= CompareQty)
                    {




                        sumfe = sumfe + (Convert.ToDouble(dvpotdsc.Rows[a]["FE"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[a]["BALWT"].ToString()));
                        sumsi = sumsi + (Convert.ToDouble(dvpotdsc.Rows[a]["SI"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[a]["BALWT"].ToString()));
                        sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdsc.Rows[a]["PURITY"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[a]["BALWT"].ToString()));

                        actrow = actrow + 1;

                        DataView dvfg = new DataView();
                        DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                        dvfg = DSPot.DefaultView;


                        DataRow drfinal1 = dtfinal.NewRow();
                        drfinal1["POT"] = dvpotdsc.Rows[a]["POT"].ToString();
                        drfinal1["POTID"] = dvpotdsc.Rows[a]["ID"].ToString();
                        drfinal1["RECWT"] = dvpotdsc.Rows[a]["RECWT"].ToString();
                        drfinal1["FE"] = dvpotdsc.Rows[a]["FE"].ToString();
                        drfinal1["SI"] = dvpotdsc.Rows[a]["SI"].ToString();
                        drfinal1["PURITY"] = dvpotdsc.Rows[a]["PURITY"].ToString();
                        drfinal1["GRADE"] = dvpotdsc.Rows[a]["GRADE"].ToString();
                        drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                        drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                        drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                        drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                        drfinal1["FTOTWT"] = Convert.ToString(sum);
                        drfinal1["ISBLEND"] = 0;
                        drfinal1["ISSUEWT"] = dvpotdsc.Rows[a]["BALWT"].ToString();
                        drfinal1["SLIPNO"] = SLNo;
                        drfinal1["LADLE"] = ladle;
                        drfinal1["BALWT"] = 0;
                        drfinal1["ISBLEND"] = 0;
                        dtfinal.Rows.Add(drfinal1);


                    }
                    //Incase of value more than CompareQty
                    else
                    {

                        int bfrow = dtfinal.Rows.Count - 1;

                        sum = sum - Convert.ToInt32(dvpotdsc.Rows[a]["BALWT"].ToString());
                        int acutaldiff = CompareQty - sum;

                        if (acutaldiff == 0)
                        {
                            rowstatus = 1;
                            a = a - 1;
                        }
                        else
                        {


                            for (m = 0; m <= dvpotdscMIX.Rows.Count - 1; m++)
                            {

                                if (Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()) != 0)
                                {

                                    if (Convert.ToInt32(dvpotdscMIX.Rows[m]["POT"].ToString()) >= min && Convert.ToInt32(dvpotdscMIX.Rows[m]["POT"].ToString()) <= max)
                                    {


                                        sum = sum + Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());


                                        int actsum = CompareQty - sum;
                                        if (actsum >= 0)
                                        {
                                            sumfe = sumfe + (Convert.ToDouble(dvpotdscMIX.Rows[m]["FE"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                                            sumsi = sumsi + (Convert.ToDouble(dvpotdscMIX.Rows[m]["SI"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                                            sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdscMIX.Rows[m]["PURITY"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));

                                            DataView dvfg = new DataView();
                                            DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                                            dvfg = DSPot.DefaultView;

                                            DataRow drfinal1 = dtfinal.NewRow();
                                            drfinal1["POT"] = dvpotdscMIX.Rows[m]["POT"].ToString();
                                            drfinal1["POTID"] = dvpotdscMIX.Rows[m]["ID"].ToString();
                                            drfinal1["RECWT"] = dvpotdscMIX.Rows[m]["RECWT"].ToString();
                                            drfinal1["FE"] = dvpotdscMIX.Rows[m]["FE"].ToString();
                                            drfinal1["SI"] = dvpotdscMIX.Rows[m]["SI"].ToString();
                                            drfinal1["PURITY"] = dvpotdscMIX.Rows[m]["PURITY"].ToString();
                                            drfinal1["GRADE"] = dvpotdscMIX.Rows[m]["GRADE"].ToString();
                                            drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                                            drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                                            drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                                            drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                                            drfinal1["FTOTWT"] = Convert.ToString(sum);
                                            drfinal1["ISSUEWT"] = Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());
                                            drfinal1["ISBLEND"] = 0;
                                            drfinal1["SLIPNO"] = SLNo;
                                            drfinal1["LADLE"] = ladle;
                                            drfinal1["BALWT"] = 0;
                                            drfinal1["ISBLEND"] = 0;
                                            dtfinal.Rows.Add(drfinal1);

                                            acutaldiff = acutaldiff - Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"]);
                                            dvpotdscMIX.Rows[m]["BALWT"] = 0;




                                        }
                                        else
                                        {

                                            sum = sum + actsum;
                                            sumfe = sumfe + (Convert.ToDouble(dvpotdscMIX.Rows[m]["FE"].ToString()) * Convert.ToInt32(acutaldiff));
                                            sumsi = sumsi + (Convert.ToDouble(dvpotdscMIX.Rows[m]["SI"].ToString()) * Convert.ToInt32(acutaldiff));
                                            sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdsc.Rows[m]["PURITY"].ToString()) * Convert.ToInt32(acutaldiff));

                                            DataView dvfg = new DataView();
                                            DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                                            dvfg = DSPot.DefaultView;


                                            dvpotdscMIX.Rows[m]["BALWT"] = Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()) - acutaldiff;

                                            DataRow drfinal1 = dtfinal.NewRow();
                                            drfinal1["POT"] = dvpotdscMIX.Rows[m]["POT"].ToString();
                                            drfinal1["POTID"] = dvpotdscMIX.Rows[m]["ID"].ToString();
                                            drfinal1["RECWT"] = dvpotdscMIX.Rows[m]["RECWT"].ToString();
                                            drfinal1["FE"] = dvpotdscMIX.Rows[m]["FE"].ToString();
                                            drfinal1["SI"] = dvpotdscMIX.Rows[m]["SI"].ToString();
                                            drfinal1["PURITY"] = dvpotdscMIX.Rows[m]["PURITY"].ToString();
                                            drfinal1["GRADE"] = dvpotdscMIX.Rows[m]["GRADE"].ToString();
                                            drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                                            drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                                            drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                                            drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                                            drfinal1["FTOTWT"] = Convert.ToString(sum);
                                            drfinal1["ISSUEWT"] = acutaldiff;
                                            drfinal1["ISBLEND"] = 0;
                                            drfinal1["SLIPNO"] = SLNo;
                                            drfinal1["LADLE"] = ladle;
                                            drfinal1["ISBLEND"] = 0;
                                            drfinal1["BALWT"] = Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());
                                            dtfinal.Rows.Add(drfinal1);
                                            acutaldiff = 0;
                                            //fOR uPDATE ISBLEND TO 1
                                            for (int u = 0; u <= dtfinal.Rows.Count - 1; u++)
                                            {
                                                dtfinal.Rows[u]["ISBLEND"] = 1;
                                            }

                                            m = m;
                                            //a = a - 1;
                                            rowstatus = 1;
                                            break;


                                        }
                                    }

                                }


                            }

                            int afrow = dtfinal.Rows.Count - 1;

                            if (bfrow == afrow)


                            {
                                for (int x = a; x < i; x++)
                                {


                                    if (Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()) != 0)
                                    {

                                        if (Convert.ToInt32(dvpotdsc.Rows[x]["POT"].ToString()) >= min && Convert.ToInt32(dvpotdsc.Rows[x]["POT"].ToString()) <= max)
                                        {


                                            sum = sum + Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString());

                                            int actsum = CompareQty - sum;
                                            if (actsum >= 0)
                                            {
                                                sumfe = sumfe + (Convert.ToDouble(dvpotdsc.Rows[x]["FE"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()));
                                                sumsi = sumsi + (Convert.ToDouble(dvpotdsc.Rows[x]["SI"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()));
                                                sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdsc.Rows[x]["PURITY"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()));

                                                DataView dvfg = new DataView();
                                                DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                                                dvfg = DSPot.DefaultView;

                                                DataRow drfinal1 = dtfinal.NewRow();
                                                drfinal1["POT"] = dvpotdsc.Rows[x]["POT"].ToString();
                                                drfinal1["POTID"] = dvpotdsc.Rows[x]["ID"].ToString();
                                                drfinal1["RECWT"] = dvpotdsc.Rows[x]["RECWT"].ToString();
                                                drfinal1["FE"] = dvpotdsc.Rows[x]["FE"].ToString();
                                                drfinal1["SI"] = dvpotdsc.Rows[x]["SI"].ToString();
                                                drfinal1["PURITY"] = dvpotdsc.Rows[x]["PURITY"].ToString();
                                                drfinal1["GRADE"] = dvpotdsc.Rows[x]["GRADE"].ToString();
                                                drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                                                drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                                                drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                                                drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                                                drfinal1["FTOTWT"] = Convert.ToString(sum);
                                                drfinal1["ISSUEWT"] = Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString());
                                                drfinal1["ISBLEND"] = 0;
                                                drfinal1["SLIPNO"] = SLNo;
                                                drfinal1["LADLE"] = ladle;
                                                drfinal1["BALWT"] = 0;
                                                drfinal1["ISBLEND"] = 0;
                                                dtfinal.Rows.Add(drfinal1);


                                                acutaldiff = acutaldiff - Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"]);
                                                dvpotdsc.Rows[x]["BALWT"] = 0;



                                            }
                                            else
                                            {

                                                sum = sum + actsum;
                                                sumfe = sumfe + (Convert.ToDouble(dvpotdsc.Rows[x]["FE"].ToString()) * Convert.ToInt32(acutaldiff));
                                                sumsi = sumsi + (Convert.ToDouble(dvpotdsc.Rows[x]["SI"].ToString()) * Convert.ToInt32(acutaldiff));
                                                sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdsc.Rows[m]["PURITY"].ToString()) * Convert.ToInt32(acutaldiff));

                                                DataView dvfg = new DataView();
                                                DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                                                dvfg = DSPot.DefaultView;

                                                dvpotdsc.Rows[x]["BALWT"] = Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString()) - acutaldiff;

                                                DataRow drfinal1 = dtfinal.NewRow();
                                                drfinal1["POT"] = dvpotdsc.Rows[x]["POT"].ToString();
                                                drfinal1["POTID"] = dvpotdsc.Rows[x]["ID"].ToString();
                                                drfinal1["RECWT"] = dvpotdsc.Rows[x]["RECWT"].ToString();
                                                drfinal1["FE"] = dvpotdsc.Rows[x]["FE"].ToString();
                                                drfinal1["SI"] = dvpotdsc.Rows[x]["SI"].ToString();
                                                drfinal1["PURITY"] = dvpotdsc.Rows[x]["PURITY"].ToString();
                                                drfinal1["GRADE"] = dvpotdsc.Rows[x]["GRADE"].ToString();
                                                drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                                                drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                                                drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                                                drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                                                drfinal1["FTOTWT"] = Convert.ToString(sum);
                                                drfinal1["ISSUEWT"] = acutaldiff;
                                                drfinal1["ISBLEND"] = 0;
                                                drfinal1["SLIPNO"] = SLNo;
                                                drfinal1["LADLE"] = ladle;
                                                drfinal1["ISBLEND"] = 0;
                                                drfinal1["BALWT"] = Convert.ToInt32(dvpotdsc.Rows[x]["BALWT"].ToString());
                                                dtfinal.Rows.Add(drfinal1);

                                                //fOR uPDATE ISBLEND TO 1
                                                for (int u = 0; u <= dtfinal.Rows.Count - 1; u++)
                                                {
                                                    dtfinal.Rows[u]["ISBLEND"] = 1;
                                                }

                                                m = m;
                                                rowstatus = 1;
                                                a = x - 1;
                                                break;


                                            }
                                        }

                                    }



                                    // End of Loop for Add new Manage Pot
                                }

                                int afrow1 = dtfinal.Rows.Count - 1;
                                if (afrow == afrow1)
                                {
                                    rowstatus = 1;
                                    a = a - 1;
                                }


                            }
                            else
                            {
                                a = a - 1;
                            }
                        }
                    }
                }




            }



            return dtfinal;
        }
        public DataTable Final_Blending2Potsamegrade_Purity(DataTable dvpotdsc, int SLNo, int PotLine)

        {

            int CompareQty = 0;
            if (PotLine == 1)
            {
                CompareQty = 5000;
            }
            else
            {
                CompareQty = 9000;
            }
            DataSet ds = new DataSet();
            DataTable dtfinal = new DataTable();
            dtfinal.Columns.Add("POT");
            dtfinal.Columns.Add("RECWT");
            dtfinal.Columns.Add("FE");
            dtfinal.Columns.Add("SI");
            dtfinal.Columns.Add("PURITY");
            dtfinal.Columns.Add("GRADE");
            dtfinal.Columns.Add("FFE");
            dtfinal.Columns.Add("FSI");
            dtfinal.Columns.Add("FPURITY");
            dtfinal.Columns.Add("FGRADE");
            dtfinal.Columns.Add("FTOTWT");
            dtfinal.Columns.Add("POTID");
            dtfinal.Columns.Add("ISSUEWT");
            dtfinal.Columns.Add("BALWT");
            dtfinal.Columns.Add("SLIPNO");
            dtfinal.Columns.Add("ISBLEND");
            dtfinal.Columns.Add("LADLE");
            int i = dvpotdsc.Rows.Count;
            int j = dvpotdsc.Rows.Count;
            int actrow = 0;
            int mixrow = 0;
            int m = 0;
            int sum = 0;

            double sumfe = 0;
            double sumsi = 0;
            double sumpurirty = 0;
            int ladle = 0;

            for (m = 0; m <= dvpotdsc.Rows.Count - 1; m++)
            {

                if (Convert.ToInt32(dvpotdsc.Rows[m]["ISBLEND"].ToString()) == 1)
                {

                    DataRow drfinal1 = dtfinal.NewRow();
                    drfinal1["POT"] = dvpotdsc.Rows[m]["POT"].ToString();
                    drfinal1["POTID"] = dvpotdsc.Rows[m]["POTID"].ToString();
                    drfinal1["RECWT"] = dvpotdsc.Rows[m]["RECWT"].ToString();
                    drfinal1["FE"] = dvpotdsc.Rows[m]["FE"].ToString();
                    drfinal1["SI"] = dvpotdsc.Rows[m]["SI"].ToString();
                    drfinal1["PURITY"] = dvpotdsc.Rows[m]["PURITY"].ToString();
                    drfinal1["GRADE"] = dvpotdsc.Rows[m]["GRADE"].ToString();
                    drfinal1["FFE"] = dvpotdsc.Rows[m]["FFE"].ToString();
                    drfinal1["FSI"] = dvpotdsc.Rows[m]["FSI"].ToString();
                    drfinal1["FPURITY"] = dvpotdsc.Rows[m]["FPURITY"].ToString();
                    drfinal1["FGRADE"] = dvpotdsc.Rows[m]["FGRADE"].ToString();
                    drfinal1["FTOTWT"] = dvpotdsc.Rows[m]["FTOTWT"].ToString();
                    drfinal1["ISSUEWT"] = Convert.ToInt32(dvpotdsc.Rows[m]["ISSUEWT"].ToString());
                    drfinal1["SLIPNO"] = dvpotdsc.Rows[m]["SLIPNO"].ToString();
                    drfinal1["ISBLEND"] = 0;
                    drfinal1["LADLE"] = dvpotdsc.Rows[m]["LADLE"].ToString();

                    dtfinal.Rows.Add(drfinal1);
                    SLNo = Convert.ToInt32(dvpotdsc.Rows[m]["SLIPNO"].ToString());
                    ladle = Convert.ToInt32(dvpotdsc.Rows[m]["LADLE"].ToString());
                }
                else
                {
                    dvpotdsc.Rows[m]["BALWT"] = Convert.ToInt32(dvpotdsc.Rows[m]["ISSUEWT"].ToString());
                }


            }


            SLNo = SLNo + 1;
            ladle = ladle + 1;

            for (m = 0; m <= dvpotdsc.Rows.Count - 1; m++)
            {

                if (Convert.ToInt32(dvpotdsc.Rows[m]["ISBLEND"].ToString()) == 0)
                {



                    int acutaldiff = CompareQty - sum;
                    sum = sum + Convert.ToInt32(dvpotdsc.Rows[m]["ISSUEWT"].ToString());

                    if (acutaldiff == 0)
                    {
                        //dvpotdsc.Rows[m]["ISBLEND"] = 0;
                        m = m - 1;
                        sum = 0;
                        sumfe = 0;
                        sumsi = 0;
                        sumpurirty = 0;
                        SLNo = SLNo + 1;
                        ladle = ladle + 1;

                    }
                    else
                    {


                        int actsum = CompareQty - sum;
                        if (actsum >= 0)
                        {
                            sumfe = sumfe + (Convert.ToDouble(dvpotdsc.Rows[m]["FE"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[m]["ISSUEWT"].ToString()));
                            sumsi = sumsi + (Convert.ToDouble(dvpotdsc.Rows[m]["SI"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[m]["ISSUEWT"].ToString()));
                            sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdsc.Rows[m]["PURITY"].ToString()) * Convert.ToInt32(dvpotdsc.Rows[m]["ISSUEWT"].ToString()));

                            DataView dvfg = new DataView();
                            DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                            dvfg = DSPot.DefaultView;

                            DataRow drfinal1 = dtfinal.NewRow();
                            drfinal1["POT"] = dvpotdsc.Rows[m]["POT"].ToString();
                            drfinal1["POTID"] = dvpotdsc.Rows[m]["POTID"].ToString();
                            drfinal1["RECWT"] = dvpotdsc.Rows[m]["RECWT"].ToString();
                            drfinal1["FE"] = dvpotdsc.Rows[m]["FE"].ToString();
                            drfinal1["SI"] = dvpotdsc.Rows[m]["SI"].ToString();
                            drfinal1["PURITY"] = dvpotdsc.Rows[m]["PURITY"].ToString();
                            drfinal1["GRADE"] = dvpotdsc.Rows[m]["GRADE"].ToString();
                            drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                            drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                            drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                            drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                            drfinal1["FTOTWT"] = Convert.ToString(sum);
                            drfinal1["ISSUEWT"] = Convert.ToInt32(dvpotdsc.Rows[m]["ISSUEWT"].ToString());
                            drfinal1["SLIPNO"] = SLNo;
                            drfinal1["LADLE"] = ladle;
                            drfinal1["ISBLEND"] = 0;
                            dtfinal.Rows.Add(drfinal1);


                            dvpotdsc.Rows[m]["BALWT"] = Convert.ToInt32(dvpotdsc.Rows[m]["BALWT"].ToString()) - Convert.ToInt32(dvpotdsc.Rows[m]["ISSUEWT"].ToString());
                            dvpotdsc.Rows[m]["ISBLEND"] = 1;

                        }
                        else
                        {

                            sum = sum + actsum;
                            sumfe = sumfe + (Convert.ToDouble(dvpotdsc.Rows[m]["FE"].ToString()) * Convert.ToInt32(acutaldiff));
                            sumsi = sumsi + (Convert.ToDouble(dvpotdsc.Rows[m]["SI"].ToString()) * Convert.ToInt32(acutaldiff));
                            sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdsc.Rows[m]["PURITY"].ToString()) * Convert.ToInt32(acutaldiff));


                            DataView dvfg = new DataView();
                            DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                            dvfg = DSPot.DefaultView;

                            dvpotdsc.Rows[m]["BALWT"] = Convert.ToInt32(dvpotdsc.Rows[m]["BALWT"].ToString()) - acutaldiff;
                            dvpotdsc.Rows[m]["ISSUEWT"] = Convert.ToInt32(dvpotdsc.Rows[m]["ISSUEWT"].ToString()) - acutaldiff;

                            DataRow drfinal1 = dtfinal.NewRow();
                            drfinal1["POT"] = dvpotdsc.Rows[m]["POT"].ToString();
                            drfinal1["POTID"] = dvpotdsc.Rows[m]["POTID"].ToString();
                            drfinal1["RECWT"] = dvpotdsc.Rows[m]["RECWT"].ToString();
                            drfinal1["FE"] = dvpotdsc.Rows[m]["FE"].ToString();
                            drfinal1["SI"] = dvpotdsc.Rows[m]["SI"].ToString();
                            drfinal1["PURITY"] = dvpotdsc.Rows[m]["PURITY"].ToString();
                            drfinal1["GRADE"] = dvpotdsc.Rows[m]["GRADE"].ToString();
                            drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                            drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                            drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                            drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                            drfinal1["FTOTWT"] = Convert.ToString(sum);
                            drfinal1["ISSUEWT"] = acutaldiff;
                            drfinal1["SLIPNO"] = SLNo;
                            drfinal1["LADLE"] = ladle;
                            drfinal1["ISBLEND"] = 0;
                            dtfinal.Rows.Add(drfinal1);

                            SLNo = SLNo + 1;
                            ladle = ladle + 1;
                            for (int u = 0; u <= dtfinal.Rows.Count - 1; u++)
                            {
                                dtfinal.Rows[u]["ISBLEND"] = 1;
                            }
                            if (dvpotdsc.Rows[m]["BALWT"].ToString() == "0")
                            {
                                //fOR uPDATE ISBLEND TO 1


                                dvpotdsc.Rows[m]["ISBLEND"] = 1;

                            }
                            else
                            {
                                dvpotdsc.Rows[m]["ISBLEND"] = 0;
                                m = m - 1;
                                sum = 0;
                                sumfe = 0;
                                sumsi = 0;
                                sumpurirty = 0;

                            }




                        }
                    }
                }



            }



            return dtfinal;
        }


        public void FurnacePlanAssignBack_Purity(string shiftdate, string shift, string SortOrder)
        {
            DataTable Tapfinal = new DataTable();
            Tapfinal.Columns.Add("POT");
            Tapfinal.Columns.Add("RECWT");
            Tapfinal.Columns.Add("FE");
            Tapfinal.Columns.Add("SI");
            Tapfinal.Columns.Add("PURITY");
            Tapfinal.Columns.Add("GRADE");
            Tapfinal.Columns.Add("FFE");
            Tapfinal.Columns.Add("FSI");
            Tapfinal.Columns.Add("FPURITY");
            Tapfinal.Columns.Add("FGRADE");
            Tapfinal.Columns.Add("FTOTWT");
            Tapfinal.Columns.Add("SLIPNO");
            Tapfinal.Columns.Add("FID");
            Tapfinal.Columns.Add("POTID");
            Tapfinal.Columns.Add("ISSUEWT");

            Tapfinal.Rows.Clear();





            DataTable DTFurnace = cn.GetDataTable("SP_POTLINE_OPERATION_GENERATE_PURITY_SLIP_STEP2");
            DataView DVFurnace = new DataView();
            DVFurnace = DTFurnace.DefaultView;

            int SLNO = 0;
            string PotLine = "";
            // Furnace Loop
            for (int i = 0; i < DTFurnace.Rows.Count; i++)
            {

                double PFE = Convert.ToDouble(DTFurnace.Rows[i]["FE"].ToString());
                double PSI = Convert.ToDouble(DTFurnace.Rows[i]["SI"].ToString());

                double PPurity = Convert.ToDouble(DTFurnace.Rows[i]["Purity"].ToString());


                DataTable DTLineSec = Fetch_Purity_Line_Section(shiftdate, shift);
                DataView DVlinesec = new DataView();
                DVlinesec = DTLineSec.DefaultView;
                DVlinesec.Sort = "COUNTNO ASC";
                //Line Section wise Loop
                for (int j = 0; j < DTLineSec.Rows.Count; j++)
                {
                    PotLine = DTLineSec.Rows[j]["TAPLINE"].ToString();
                    Tapfinal.Rows.Clear();

                    //Blend Pot List
                    DataTable DTPot = Fetch_Blend_Pot("BACK", DTLineSec.Rows[j]["LINESECTIONSIDE"].ToString(), shiftdate, shift, PFE.ToString(), PSI.ToString(), PPurity.ToString(), SortOrder);
                    DataView DVPot = new DataView();
                    DVPot = DTPot.DefaultView;



                    // Mix Pot List
                    DataTable DTMIXPot = Fetch_Blend_Pot("BACK", DTLineSec.Rows[j]["LINESECTIONSIDE"].ToString(), shiftdate, shift, PFE.ToString(), PSI.ToString(), PPurity.ToString(), SortOrder);
                    DataView DVMIXPot = new DataView();
                    DVMIXPot = DTMIXPot.DefaultView;


                    if (DTPot.Rows.Count > 0)
                    {
                        SLNO = Convert.ToInt32(DTPot.Rows[0]["SLIPNO"].ToString());
                    }
                    if (DTLineSec.Rows[j]["LINESECTIONSIDE"].ToString() == "32")
                    {
                        int g = 0;
                    }

                    int linesec = 0;

                    int secladdle = 0;
                    DataTable Dt4 = new DataTable();

                    if (SLNO > 0)
                    {
                        SLNO = SLNO - 1;
                    }
                    // Blend Start
                    DataTable DTBlend = new DataTable();

                    if (int.Parse(PotLine) == 1)
                    {
                        DTBlend = Blending_Potsamegrade_Purity_PotLine1(DVPot.Table, DVMIXPot.Table, SLNO, int.Parse(PotLine));
                    }
                    else if (int.Parse(PotLine) == 2)
                    {
                        DTBlend = Blending_Potsamegrade_Purity_PotLine2(DVPot.Table, DVMIXPot.Table, SLNO, int.Parse(PotLine));
                    }

                    //Blend End


                    //FInal Slip Data
                    DVPot = DTBlend.DefaultView;
                    Dt4 = Final_Blending2Potsamegrade_Purity(DVPot.Table, SLNO, int.Parse(PotLine));
                    if (Dt4.Rows.Count > 0)
                    {

                        Tapfinal.Rows.Clear();
                        //   SLNO = SLNO + 1;



                        secladdle = secladdle + 1;

                        for (int k = 0; k < Dt4.Rows.Count; k++)
                        {


                            DataRow drTapfinal = Tapfinal.NewRow();
                            drTapfinal["POT"] = Dt4.Rows[k][0].ToString();
                            drTapfinal["RECWT"] = Dt4.Rows[k][1].ToString();
                            drTapfinal["FE"] = Dt4.Rows[k][2].ToString();
                            drTapfinal["SI"] = Dt4.Rows[k][3].ToString();
                            drTapfinal["PURITY"] = Dt4.Rows[k][4].ToString();
                            drTapfinal["GRADE"] = Dt4.Rows[k][5].ToString();
                            drTapfinal["FFE"] = Dt4.Rows[k][6].ToString();
                            drTapfinal["FSI"] = Dt4.Rows[k][7].ToString();
                            drTapfinal["FPURITY"] = Dt4.Rows[k][8].ToString();
                            drTapfinal["FGRADE"] = Dt4.Rows[k][9].ToString();
                            drTapfinal["FTOTWT"] = Dt4.Rows[k][10].ToString();
                            drTapfinal["SLIPNO"] = Dt4.Rows[k]["SLIPNO"].ToString();
                            drTapfinal["FID"] = 0;
                            drTapfinal["POTID"] = Dt4.Rows[k]["POTID"].ToString();
                            drTapfinal["ISSUEWT"] = Dt4.Rows[k]["ISSUEWT"].ToString();
                            Tapfinal.Rows.Add(drTapfinal);






                        }
                    }


                    if (Tapfinal.Rows.Count > 0)
                    {
                        for (int f = 0; f < Tapfinal.Rows.Count; f++)
                        {
                            DataTable DSFinalPot = Fetch_Step5_FinalPot(shiftdate, shift, Tapfinal.Rows[f]["POTID"].ToString(), Tapfinal.Rows[f]["FID"].ToString(),
                                                                        Tapfinal.Rows[f]["SLIPNO"].ToString(), Tapfinal.Rows[f]["FFE"].ToString(), Tapfinal.Rows[f]["FSI"].ToString(),
                                                                        Tapfinal.Rows[f]["FPURITY"].ToString(), Tapfinal.Rows[f]["FGRADE"].ToString(), Tapfinal.Rows[f]["FTOTWT"].ToString(), Tapfinal.Rows[f]["ISSUEWT"].ToString());

                        }

                    }


                }


            }

        }


        public void FurnacePlanAssignBack_Purity_Balanced(string ShiftDate, string Shift, string SortOrder)
        {

            string PotLine = "";

            DataTable Tapfinal = new DataTable();
            Tapfinal.Columns.Add("POT");
            Tapfinal.Columns.Add("RECWT");
            Tapfinal.Columns.Add("FE");
            Tapfinal.Columns.Add("SI");
            Tapfinal.Columns.Add("PURITY");
            Tapfinal.Columns.Add("GRADE");
            Tapfinal.Columns.Add("FFE");
            Tapfinal.Columns.Add("FSI");
            Tapfinal.Columns.Add("FPURITY");
            Tapfinal.Columns.Add("FGRADE");
            Tapfinal.Columns.Add("FTOTWT");
            Tapfinal.Columns.Add("SLIPNO");
            Tapfinal.Columns.Add("FID");
            Tapfinal.Columns.Add("POTID");
            Tapfinal.Columns.Add("ISSUEWT");

            Tapfinal.Rows.Clear();

            //  ******Get List of Available LINESEC******



            //  ******Get List of Available Furnace******

            DataTable DTFurnace = cn.GetDataTable("SP_POTLINE_OPERATION_GENERATE_PURITY_SLIP_STEP2");
            DataView DVFurnace = new DataView();
            DVFurnace = DTFurnace.DefaultView;

            int SLNO = 0;

            for (int i = 0; i < DTFurnace.Rows.Count; i++)
            {



                double PFE = Convert.ToDouble(DTFurnace.Rows[i]["FE"].ToString());
                double PSI = Convert.ToDouble(DTFurnace.Rows[i]["SI"].ToString());

                double PPurity = Convert.ToDouble(DTFurnace.Rows[i]["Purity"].ToString());




                DataTable DTLineSec = Fetch_Purity_Line_Section(ShiftDate, Shift);
                DataView DVlinesec = new DataView();
                DVlinesec = DTLineSec.DefaultView;
                DVlinesec.Sort = "COUNTNO ASC";

                for (int j = 0; j < DTLineSec.Rows.Count; j++)
                {

                    PotLine = DTLineSec.Rows[j]["TAPLINE"].ToString();

                    Tapfinal.Rows.Clear();





                    DataTable DTMIXPot = Fetch_Blend_Mix_Pot("BACK", DTLineSec.Rows[j]["LINESECTIONSIDE"].ToString(), ShiftDate, Shift, PFE.ToString(), PSI.ToString(), PPurity.ToString(), SortOrder);
                    DataView DVMIXPot = new DataView();
                    DVMIXPot = DTMIXPot.DefaultView;




                    if (DTMIXPot.Rows.Count > 0)
                    {
                        SLNO = Convert.ToInt32(DTMIXPot.Rows[0]["SLIPNO"].ToString());
                    }
                    if (DTLineSec.Rows[j]["LINESECTIONSIDE"].ToString() == "32")
                    {
                        int g = 0;
                    }

                    int linesec = 0;

                    int secladdle = 0;
                    DataTable Dt4 = new DataTable();


                    if (SLNO > 0)
                    {
                        SLNO = SLNO - 1;
                    }

                    DataTable DTBlend = new DataTable();


                    if (int.Parse(PotLine) == 1)
                    {
                        DTBlend = Blending_Potsamegrade_Purity_Balanced_Potline1(DVMIXPot.Table, DVMIXPot.Table, SLNO, int.Parse(PotLine));
                    }
                    else if (int.Parse(PotLine) == 2)
                    {
                        DTBlend = Blending_Potsamegrade_Purity_Balanced_Potline2(DVMIXPot.Table, DVMIXPot.Table, SLNO, int.Parse(PotLine));
                    }






                    DVMIXPot = DTBlend.DefaultView;

                    Dt4 = Final_Blending2Potsamegrade_Purity(DVMIXPot.Table, SLNO, int.Parse(PotLine));
                    if (Dt4.Rows.Count > 0)
                    {

                        Tapfinal.Rows.Clear();
                        //   SLNO = SLNO + 1;

                        secladdle = secladdle + 1;

                        for (int k = 0; k < Dt4.Rows.Count; k++)
                        {


                            DataRow drTapfinal = Tapfinal.NewRow();
                            drTapfinal["POT"] = Dt4.Rows[k][0].ToString();
                            drTapfinal["RECWT"] = Dt4.Rows[k][1].ToString();
                            drTapfinal["FE"] = Dt4.Rows[k][2].ToString();
                            drTapfinal["SI"] = Dt4.Rows[k][3].ToString();
                            drTapfinal["PURITY"] = Dt4.Rows[k][4].ToString();
                            drTapfinal["GRADE"] = Dt4.Rows[k][5].ToString();
                            drTapfinal["FFE"] = Dt4.Rows[k][6].ToString();
                            drTapfinal["FSI"] = Dt4.Rows[k][7].ToString();
                            drTapfinal["FPURITY"] = Dt4.Rows[k][8].ToString();
                            drTapfinal["FGRADE"] = Dt4.Rows[k][9].ToString();
                            drTapfinal["FTOTWT"] = Dt4.Rows[k][10].ToString();
                            drTapfinal["SLIPNO"] = Dt4.Rows[k]["SLIPNO"].ToString();
                            drTapfinal["FID"] = 0;
                            drTapfinal["POTID"] = Dt4.Rows[k]["POTID"].ToString();
                            drTapfinal["ISSUEWT"] = Dt4.Rows[k]["ISSUEWT"].ToString();
                            Tapfinal.Rows.Add(drTapfinal);






                        }
                    }
                    //}


                    if (Tapfinal.Rows.Count > 0)
                    {
                        for (int f = 0; f < Tapfinal.Rows.Count; f++)
                        {
                            DataTable DSFinalPot = Fetch_Step5_FinalPot(ShiftDate, Shift, Tapfinal.Rows[f]["POTID"].ToString(), Tapfinal.Rows[f]["FID"].ToString(),
                                                                        Tapfinal.Rows[f]["SLIPNO"].ToString(), Tapfinal.Rows[f]["FFE"].ToString(), Tapfinal.Rows[f]["FSI"].ToString(),
                                                                        Tapfinal.Rows[f]["FPURITY"].ToString(), Tapfinal.Rows[f]["FGRADE"].ToString(), Tapfinal.Rows[f]["FTOTWT"].ToString(), Tapfinal.Rows[f]["ISSUEWT"].ToString());

                        }

                    }

                }


            }



        }

        public DataTable Blending_Potsamegrade_Purity_Balanced_Potline1(DataTable dvpotdsc, DataTable dvpotdscMIX, int SLNo, int PotLine)
        {



            int CompareQty = 0;
            if (PotLine == 1)
            {
                CompareQty = 5000;
            }
            else
            {
                CompareQty = 9000;
            }


            DataSet ds = new DataSet();
            DataTable dtfinal = new DataTable();
            dtfinal.Columns.Add("POT");
            dtfinal.Columns.Add("RECWT");
            dtfinal.Columns.Add("FE");
            dtfinal.Columns.Add("SI");
            dtfinal.Columns.Add("PURITY");
            dtfinal.Columns.Add("GRADE");
            dtfinal.Columns.Add("FFE");
            dtfinal.Columns.Add("FSI");
            dtfinal.Columns.Add("FPURITY");
            dtfinal.Columns.Add("FGRADE");
            dtfinal.Columns.Add("FTOTWT");
            dtfinal.Columns.Add("POTID");
            dtfinal.Columns.Add("ISSUEWT");
            dtfinal.Columns.Add("SLIPNO");
            dtfinal.Columns.Add("ISBLEND");
            dtfinal.Columns.Add("BALWT");
            dtfinal.Columns.Add("LADLE");
            int i = dvpotdsc.Rows.Count;
            int j = dvpotdsc.Rows.Count;
            int actrow = 0;
            int mixrow = 0;
            int m = 0;
            int sum = 0;
            int ladle = 0;


            double sumfe = 0;
            double sumsi = 0;
            double sumpurirty = 0;
            int max = 0;
            int min = 0;
            int rowstatus = 1;




            int bfrow = dtfinal.Rows.Count - 1;



            for (m = 0; m <= dvpotdscMIX.Rows.Count - 1; m++)
            {

                if (Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()) != 0)
                {

                    sum = sum + Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());
                    if (rowstatus == 1)
                    {
                        SLNo = SLNo + 1;
                        sumfe = sumfe + (Convert.ToDouble(dvpotdscMIX.Rows[m]["FE"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                        sumsi = sumsi + (Convert.ToDouble(dvpotdscMIX.Rows[m]["SI"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                        sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdscMIX.Rows[m]["PURITY"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));

                        DataView dvfg = new DataView();
                        DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                        dvfg = DSPot.DefaultView;

                        if (DSPot.Rows[0]["GRADE"].ToString() == "P1020")
                        {
                            DataRow drfinal1 = dtfinal.NewRow();
                            drfinal1["POT"] = dvpotdscMIX.Rows[m]["POT"].ToString();
                            drfinal1["POTID"] = dvpotdscMIX.Rows[m]["ID"].ToString();
                            drfinal1["RECWT"] = dvpotdscMIX.Rows[m]["RECWT"].ToString();
                            drfinal1["FE"] = dvpotdscMIX.Rows[m]["FE"].ToString();
                            drfinal1["SI"] = dvpotdscMIX.Rows[m]["SI"].ToString();
                            drfinal1["PURITY"] = dvpotdscMIX.Rows[m]["PURITY"].ToString();
                            drfinal1["GRADE"] = dvpotdscMIX.Rows[m]["GRADE"].ToString();
                            drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                            drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                            drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                            drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                            drfinal1["FTOTWT"] = Convert.ToString(sum);
                            drfinal1["ISSUEWT"] = Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());
                            drfinal1["ISBLEND"] = 0;
                            drfinal1["SLIPNO"] = SLNo;
                            drfinal1["LADLE"] = ladle;
                            drfinal1["BALWT"] = 0;
                            drfinal1["ISBLEND"] = 0;
                            dtfinal.Rows.Add(drfinal1);


                            dvpotdscMIX.Rows[m]["BALWT"] = 0;

                            rowstatus = 2;
                        }


                    }
                    else
                    {
                        int actsum = CompareQty - sum;
                        int acutaldiff = CompareQty - sum;

                        if (acutaldiff == 0)
                        {
                            m = m - 1;
                            sum = 0;
                            rowstatus = 1;
                        }
                        else
                        {
                            if (actsum >= 0)
                            {
                                sumfe = sumfe + (Convert.ToDouble(dvpotdscMIX.Rows[m]["FE"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                                sumsi = sumsi + (Convert.ToDouble(dvpotdscMIX.Rows[m]["SI"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                                sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdscMIX.Rows[m]["PURITY"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));

                                DataView dvfg = new DataView();
                                DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                                dvfg = DSPot.DefaultView;

                                if (DSPot.Rows[0]["GRADE"].ToString() == "P1020")
                                {
                                    DataRow drfinal1 = dtfinal.NewRow();
                                    drfinal1["POT"] = dvpotdscMIX.Rows[m]["POT"].ToString();
                                    drfinal1["POTID"] = dvpotdscMIX.Rows[m]["ID"].ToString();
                                    drfinal1["RECWT"] = dvpotdscMIX.Rows[m]["RECWT"].ToString();
                                    drfinal1["FE"] = dvpotdscMIX.Rows[m]["FE"].ToString();
                                    drfinal1["SI"] = dvpotdscMIX.Rows[m]["SI"].ToString();
                                    drfinal1["PURITY"] = dvpotdscMIX.Rows[m]["PURITY"].ToString();
                                    drfinal1["GRADE"] = dvpotdscMIX.Rows[m]["GRADE"].ToString();
                                    drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                                    drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                                    drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                                    drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                                    drfinal1["FTOTWT"] = Convert.ToString(sum);
                                    drfinal1["ISSUEWT"] = Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());
                                    drfinal1["ISBLEND"] = 0;
                                    drfinal1["SLIPNO"] = SLNo;
                                    drfinal1["LADLE"] = ladle;
                                    drfinal1["BALWT"] = 0;
                                    drfinal1["ISBLEND"] = 0;
                                    dtfinal.Rows.Add(drfinal1);


                                    dvpotdscMIX.Rows[m]["BALWT"] = 0;


                                    for (int u = 0; u <= dtfinal.Rows.Count - 1; u++)
                                    {
                                        dtfinal.Rows[u]["ISBLEND"] = 1;
                                    }

                                    m = m - 1;
                                    //a = a - 1;
                                    sum = 0;
                                    rowstatus = 1;
                                }

                            }
                            else
                            {

                                sum = sum + actsum;
                                sumfe = sumfe + (Convert.ToDouble(dvpotdscMIX.Rows[m]["FE"].ToString()) * Convert.ToInt32(acutaldiff));
                                sumsi = sumsi + (Convert.ToDouble(dvpotdscMIX.Rows[m]["SI"].ToString()) * Convert.ToInt32(acutaldiff));
                                sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdscMIX.Rows[m]["PURITY"].ToString()) * Convert.ToInt32(acutaldiff));

                                DataView dvfg = new DataView();
                                DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                                dvfg = DSPot.DefaultView;

                                if (DSPot.Rows[0]["GRADE"].ToString() == "P1020")
                                {
                                    dvpotdscMIX.Rows[m]["BALWT"] = Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()) + actsum;

                                    DataRow drfinal1 = dtfinal.NewRow();
                                    drfinal1["POT"] = dvpotdscMIX.Rows[m]["POT"].ToString();
                                    drfinal1["POTID"] = dvpotdscMIX.Rows[m]["ID"].ToString();
                                    drfinal1["RECWT"] = dvpotdscMIX.Rows[m]["RECWT"].ToString();
                                    drfinal1["FE"] = dvpotdscMIX.Rows[m]["FE"].ToString();
                                    drfinal1["SI"] = dvpotdscMIX.Rows[m]["SI"].ToString();
                                    drfinal1["PURITY"] = dvpotdscMIX.Rows[m]["PURITY"].ToString();
                                    drfinal1["GRADE"] = dvpotdscMIX.Rows[m]["GRADE"].ToString();
                                    drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                                    drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                                    drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                                    drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                                    drfinal1["FTOTWT"] = Convert.ToString(sum);
                                    drfinal1["ISSUEWT"] = Math.Abs(actsum);
                                    drfinal1["ISBLEND"] = 0;
                                    drfinal1["SLIPNO"] = SLNo;
                                    drfinal1["LADLE"] = ladle;
                                    drfinal1["ISBLEND"] = 0;
                                    drfinal1["BALWT"] = Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());
                                    dtfinal.Rows.Add(drfinal1);
                                    acutaldiff = 0;
                                    //fOR uPDATE ISBLEND TO 1
                                    for (int u = 0; u <= dtfinal.Rows.Count - 1; u++)
                                    {
                                        dtfinal.Rows[u]["ISBLEND"] = 1;
                                    }

                                    m = m - 1;
                                    //a = a - 1;
                                    sum = 0;
                                    rowstatus = 1;

                                }

                            }
                        }

                    }



                }


            }







            return dtfinal;
        }
        public DataTable Blending_Potsamegrade_Purity_Balanced_Potline2(DataTable dvpotdsc, DataTable dvpotdscMIX, int SLNo, int PotLine)
        {


            int CompareQty = 0;
            if (PotLine == 1)
            {
                CompareQty = 5000;
            }
            else
            {
                CompareQty = 9000;
            }


            DataSet ds = new DataSet();
            DataTable dtfinal = new DataTable();
            dtfinal.Columns.Add("POT");
            dtfinal.Columns.Add("RECWT");
            dtfinal.Columns.Add("FE");
            dtfinal.Columns.Add("SI");
            dtfinal.Columns.Add("PURITY");
            dtfinal.Columns.Add("GRADE");
            dtfinal.Columns.Add("FFE");
            dtfinal.Columns.Add("FSI");
            dtfinal.Columns.Add("FPURITY");
            dtfinal.Columns.Add("FGRADE");
            dtfinal.Columns.Add("FTOTWT");
            dtfinal.Columns.Add("POTID");
            dtfinal.Columns.Add("ISSUEWT");
            dtfinal.Columns.Add("SLIPNO");
            dtfinal.Columns.Add("ISBLEND");
            dtfinal.Columns.Add("BALWT");
            dtfinal.Columns.Add("LADLE");
            int i = dvpotdsc.Rows.Count;
            int j = dvpotdsc.Rows.Count;
            int actrow = 0;
            int mixrow = 0;
            int m = 0;
            int sum = 0;
            int ladle = 0;


            double sumfe = 0;
            double sumsi = 0;
            double sumpurirty = 0;
            int max = 0;
            int min = 0;
            int rowstatus = 1;




            int bfrow = dtfinal.Rows.Count - 1;



            for (m = 0; m <= dvpotdscMIX.Rows.Count - 1; m++)
            {

                if (Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()) != 0)
                {

                    sum = sum + Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());
                    if (rowstatus == 1)
                    {
                        SLNo = SLNo + 1;
                        sumfe = sumfe + (Convert.ToDouble(dvpotdscMIX.Rows[m]["FE"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                        sumsi = sumsi + (Convert.ToDouble(dvpotdscMIX.Rows[m]["SI"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                        sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdscMIX.Rows[m]["PURITY"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));

                        DataView dvfg = new DataView();
                        DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                        dvfg = DSPot.DefaultView;

                        if (DSPot.Rows[0]["GRADE"].ToString() == "P1020")
                        {
                            DataRow drfinal1 = dtfinal.NewRow();
                            drfinal1["POT"] = dvpotdscMIX.Rows[m]["POT"].ToString();
                            drfinal1["POTID"] = dvpotdscMIX.Rows[m]["ID"].ToString();
                            drfinal1["RECWT"] = dvpotdscMIX.Rows[m]["RECWT"].ToString();
                            drfinal1["FE"] = dvpotdscMIX.Rows[m]["FE"].ToString();
                            drfinal1["SI"] = dvpotdscMIX.Rows[m]["SI"].ToString();
                            drfinal1["PURITY"] = dvpotdscMIX.Rows[m]["PURITY"].ToString();
                            drfinal1["GRADE"] = dvpotdscMIX.Rows[m]["GRADE"].ToString();
                            drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                            drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                            drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                            drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                            drfinal1["FTOTWT"] = Convert.ToString(sum);
                            drfinal1["ISSUEWT"] = Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());
                            drfinal1["ISBLEND"] = 0;
                            drfinal1["SLIPNO"] = SLNo;
                            drfinal1["LADLE"] = ladle;
                            drfinal1["BALWT"] = 0;
                            drfinal1["ISBLEND"] = 0;
                            dtfinal.Rows.Add(drfinal1);


                            dvpotdscMIX.Rows[m]["BALWT"] = 0;

                            rowstatus = 2;
                        }


                    }
                    else
                    {
                        int actsum = CompareQty - sum;
                        int acutaldiff = CompareQty - sum;

                        if (acutaldiff == 0)
                        {
                            m = m - 1;
                            sum = 0;
                            rowstatus = 1;
                        }
                        else
                        {
                            if (actsum >= 0)
                            {
                                sumfe = sumfe + (Convert.ToDouble(dvpotdscMIX.Rows[m]["FE"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                                sumsi = sumsi + (Convert.ToDouble(dvpotdscMIX.Rows[m]["SI"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));
                                sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdscMIX.Rows[m]["PURITY"].ToString()) * Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()));

                                DataView dvfg = new DataView();
                                DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                                dvfg = DSPot.DefaultView;

                                if (DSPot.Rows[0]["GRADE"].ToString() == "P1020")
                                {


                                    DataRow drfinal1 = dtfinal.NewRow();
                                    drfinal1["POT"] = dvpotdscMIX.Rows[m]["POT"].ToString();
                                    drfinal1["POTID"] = dvpotdscMIX.Rows[m]["ID"].ToString();
                                    drfinal1["RECWT"] = dvpotdscMIX.Rows[m]["RECWT"].ToString();
                                    drfinal1["FE"] = dvpotdscMIX.Rows[m]["FE"].ToString();
                                    drfinal1["SI"] = dvpotdscMIX.Rows[m]["SI"].ToString();
                                    drfinal1["PURITY"] = dvpotdscMIX.Rows[m]["PURITY"].ToString();
                                    drfinal1["GRADE"] = dvpotdscMIX.Rows[m]["GRADE"].ToString();
                                    drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                                    drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                                    drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                                    drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                                    drfinal1["FTOTWT"] = Convert.ToString(sum);
                                    drfinal1["ISSUEWT"] = Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());
                                    drfinal1["ISBLEND"] = 0;
                                    drfinal1["SLIPNO"] = SLNo;
                                    drfinal1["LADLE"] = ladle;
                                    drfinal1["BALWT"] = 0;
                                    drfinal1["ISBLEND"] = 0;
                                    dtfinal.Rows.Add(drfinal1);


                                    dvpotdscMIX.Rows[m]["BALWT"] = 0;
                                }





                            }
                            else
                            {

                                sum = sum + actsum;
                                sumfe = sumfe + (Convert.ToDouble(dvpotdscMIX.Rows[m]["FE"].ToString()) * Convert.ToInt32(acutaldiff));
                                sumsi = sumsi + (Convert.ToDouble(dvpotdscMIX.Rows[m]["SI"].ToString()) * Convert.ToInt32(acutaldiff));
                                sumpurirty = sumpurirty + (Convert.ToDouble(dvpotdscMIX.Rows[m]["PURITY"].ToString()) * Convert.ToInt32(acutaldiff));

                                DataView dvfg = new DataView();
                                DataTable DSPot = Fetch_Step4_MixPot((sumfe / sum), (sumsi / sum), (sumpurirty / sum));
                                dvfg = DSPot.DefaultView;

                                if (DSPot.Rows[0]["GRADE"].ToString() == "P1020")
                                {

                                    dvpotdscMIX.Rows[m]["BALWT"] = Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString()) + actsum;

                                    DataRow drfinal1 = dtfinal.NewRow();
                                    drfinal1["POT"] = dvpotdscMIX.Rows[m]["POT"].ToString();
                                    drfinal1["POTID"] = dvpotdscMIX.Rows[m]["ID"].ToString();
                                    drfinal1["RECWT"] = dvpotdscMIX.Rows[m]["RECWT"].ToString();
                                    drfinal1["FE"] = dvpotdscMIX.Rows[m]["FE"].ToString();
                                    drfinal1["SI"] = dvpotdscMIX.Rows[m]["SI"].ToString();
                                    drfinal1["PURITY"] = dvpotdscMIX.Rows[m]["PURITY"].ToString();
                                    drfinal1["GRADE"] = dvpotdscMIX.Rows[m]["GRADE"].ToString();
                                    drfinal1["FFE"] = dvfg.Table.Rows[0][0].ToString();
                                    drfinal1["FSI"] = dvfg.Table.Rows[0][1].ToString();
                                    drfinal1["FPURITY"] = dvfg.Table.Rows[0][2].ToString();
                                    drfinal1["FGRADE"] = dvfg.Table.Rows[0][3].ToString();
                                    drfinal1["FTOTWT"] = Convert.ToString(sum);
                                    drfinal1["ISSUEWT"] = Math.Abs(actsum);
                                    drfinal1["ISBLEND"] = 0;
                                    drfinal1["SLIPNO"] = SLNo;
                                    drfinal1["LADLE"] = ladle;
                                    drfinal1["ISBLEND"] = 0;
                                    drfinal1["BALWT"] = Convert.ToInt32(dvpotdscMIX.Rows[m]["BALWT"].ToString());
                                    dtfinal.Rows.Add(drfinal1);
                                    acutaldiff = 0;
                                    //fOR uPDATE ISBLEND TO 1
                                    for (int u = 0; u <= dtfinal.Rows.Count - 1; u++)
                                    {
                                        dtfinal.Rows[u]["ISBLEND"] = 1;
                                    }

                                    m = m - 1;
                                    //a = a - 1;
                                    sum = 0;
                                    rowstatus = 1;

                                }



                            }
                        }

                    }



                }


            }







            return dtfinal;
        }


        public void FurnacePlanAssignBack_Purity_Balanced_MergePotWith_Slipno(string shiftdate, string shift)
        {

            DataSet DSPot = new DataSet();
            DataView DVPot = new DataView();
            DataTable DTPot = new DataTable();


            DataView DVMIXPot = new DataView();
            DataTable DTMIXPot = cn.GetDataTable("SP_POTLINE_OPERATION_GENERATE_PURITY_SLIP_BALANCE_MERGE_POT"
             , new string[] { "@TAPDATE", "@TAPSHIFT" }
                , new string[] { shiftdate, shift });






            for (int m = 0; m <= DTMIXPot.Rows.Count - 1; m++)
            {
                string POT = DTMIXPot.Rows[m]["POT"].ToString();
                DataTable dt = new DataTable();
                cn.ExecuteQuerySP("SP_POTLINE_OPERATION_GENERATE_PURITY_SLIP_UPDATE_BALANCE_MERGE_POT"
                 , new string[] { "@TAPDATE", "@TAPSHIFT", "@POT" }
                    , new string[] { shiftdate, shift, POT });



            }




        }

        public DataTable Slip_Info(string Tapdate, string TapShift)
        {

            cn.ExecuteQuerySP("SP_POTLINE_OPERATION_GENERATE_PURITY_SLIP_STEP7"
                , new string[] { "@TAPDATE", "@TAPSHIFT" }
                   , new string[] { Tapdate, TapShift });







            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_POTLINE_OPERATION_GENERATE_PURITY_SLIP_LIST"
                , new string[] { "@TAPDATE", "@TAPSHIFT" }
                   , new string[] { Tapdate, TapShift });

            return dt;
        }
       


        #endregion  Generate Purity Slip End
    }
}