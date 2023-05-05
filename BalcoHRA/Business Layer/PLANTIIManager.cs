using System;
using System.IO;
using System.Net;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;

namespace BalcoHRA.Business_Layer
{
    public class PLANTIIManager
    {
        public static DataSet dsglob;
        public string gstrDuplicate = "Record Already Exist !";
        public string gstrNotFound = "Data Not Found ?";
        public string gstrInvailDate = " Invaild Date Format Only [DD/MM/YYYY]! ";
        public string gstrRecordUpdate = " Record Sucssefully Updated ! ";
        public string gstrRecordDelete = " Record Sucssefully Deleted ! ";
        public string gstrUpdateError = " Updation Error ! ";
        public string gstrInvaildUser = " Invaild User ! ";
        public string strClassErr;
        public string CurrrentDate = DateTime.Today.ToShortDateString();
        public string insertFieldValue;
        public string Err;
        public SqlCommand myCommand;
        public string strExSql;


        static string strSessionYR = string.Empty;
        static string strStudentTable = string.Empty;

        private int encodeMax = 20;

        public int MaxChars
        {
            get
            {
                return encodeMax;
            }
            set
            {
                encodeMax = value;
            }
        }

        public PLANTIIManager()
        {
            //
        }

        public string strConn
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["PLANTII"].ConnectionString.ToString();
            }
        }




        #region FP Connections

        #endregion





        //------------------------------------------New Try With Stored Procedure----------------------------------------------



        //------------------------------------------New Try With Stored Procedure----------------------------------------------




        public void SendErroMail(string ErrorDetails)
        {
            FPManager cn = new FPManager();
            cn.SendErroMail("SP_SEND_ERROR_MAIL", ErrorDetails, cn.strConn);

        }


        public SqlDataReader GetDataReaderSP(string SPName, string[] ParamArr, string[] ValArr)
        {
            SqlConnection cnSql = new SqlConnection(strConn);

            cnSql.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(SPName, cnSql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                for (int i = 0; i <= ParamArr.Length - 1; i++)
                {
                    cmd.Parameters.AddWithValue(ParamArr[i], ValArr[i]);
                }
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            finally
            {



            }


        }

        public string GetReturnValue(string SPName, string[] ParamArr, string[] ValArr)
        {
            string retVal = "";
            SqlConnection cnSql = new SqlConnection(strConn);
            cnSql.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(SPName, cnSql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                for (int i = 0; i <= ParamArr.Length - 1; i++)
                {
                    cmd.Parameters.AddWithValue(ParamArr[i], ValArr[i]);
                }
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read())
                {
                    retVal = dr.GetValue(0).ToString();
                }

            }
            catch (Exception Err)
            {

                SendErroMail(Err.ToString());
            }

            return retVal;
        }

        public DataTable GetDataTable(string sqlStr)
        {
            SqlConnection cnSql = new SqlConnection(strConn);
            DataTable dt = new DataTable();
            cnSql.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sqlStr, cnSql);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                cmd.CommandTimeout = 0;
                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                SendErroMail(Err.ToString());
            }
            return dt;
        }


        public DataTable GetDataTable(string SPName, string[] ParamArr, string[] ValArr)
        {
            SqlConnection cnSql = new SqlConnection(strConn);
            DataTable dt = new DataTable();
            cnSql.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(SPName, cnSql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                for (int i = 0; i <= ParamArr.Length - 1; i++)
                {

                    if (ValArr[i] == null || ValArr[i].ToString() == "" || ValArr[i].ToString() == "All")
                        cmd.Parameters.AddWithValue(ParamArr[i], DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue(ParamArr[i], ValArr[i]);
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                SendErroMail(Err.ToString());
            }
            finally
            {
                //cnSql.Close();
            }
            return dt;
        }
        public DataTable GetDataTableAll(string SPName, string[] ParamArr, string[] ValArr)
        {
            SqlConnection cnSql = new SqlConnection(strConn);
            DataTable dt = new DataTable();
            cnSql.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(SPName, cnSql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                for (int i = 0; i <= ParamArr.Length - 1; i++)
                {
                    if (ValArr[i] == null || ValArr[i].ToString() == "" || ValArr[i].ToString() == "All")
                        cmd.Parameters.AddWithValue(ParamArr[i], DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue(ParamArr[i], ValArr[i]);
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                SendErroMail(Err.ToString());
            }
            finally
            {
                //cnSql.Close();
            }
            return dt;

        }

        public DataTable GetDataTableEProfile(string SPName, string[] ParamArr, string[] ValArr)
        {
            SqlConnection cnSql = new SqlConnection(strConn);
            DataTable dt = new DataTable();
            cnSql.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(SPName, cnSql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                for (int i = 0; i <= ParamArr.Length - 1; i++)
                {
                    cmd.Parameters.AddWithValue(ParamArr[i], ValArr[i]);
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                SendErroMail(Err.ToString());
            }
            finally
            {
                //cnSql.Close();
            }
            return dt;

        }

        public void CloseConn()
        {
            SqlConnection cnSqlE = new SqlConnection(strConn);
            cnSqlE.Close();
        }

        public void BindControls(string SPName, string[] ParamArr, string[] ValArr, Control aspCTL)
        {
            SqlConnection cnLoad = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(SPName, cnLoad);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            for (int i = 0; i <= ParamArr.Length - 1; i++)
            {
                cmd.Parameters.AddWithValue(ParamArr[i], ValArr[i]);
            }
            cnLoad.Close();
            cnLoad.Open();
            try
            {
                if (aspCTL is DropDownList)
                {
                    SqlDataReader rsFillddlList = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    (aspCTL as DropDownList).Items.Clear();
                    while (rsFillddlList.Read())
                    {
                        //cboBox.Items.Add(rsFillCombo.GetValue(1).ToString());
                        (aspCTL as DropDownList).Items.Add(new ListItem(rsFillddlList.GetValue(1).ToString(), rsFillddlList.GetValue(0).ToString()));
                        (aspCTL as DropDownList).Items.Remove("Windows System");
                    }
                    (aspCTL as DropDownList).Items.Insert(0, new ListItem("--Select--", ""));
                }
                else if (aspCTL is CheckBoxList)
                {
                    SqlDataReader rsFillddlList = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    (aspCTL as CheckBoxList).Items.Clear();
                    while (rsFillddlList.Read())
                    {

                        //cboBox.Items.Add(rsFillCombo.GetValue(1).ToString());
                        (aspCTL as CheckBoxList).Items.Add(new ListItem(rsFillddlList.GetValue(1).ToString(), rsFillddlList.GetValue(0).ToString()));
                        (aspCTL as CheckBoxList).Items.Remove("Windows System");
                    }
                }
                else if (aspCTL is ListBox)
                {
                    SqlDataReader rsFillddlList = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    (aspCTL as ListBox).Items.Clear();
                    while (rsFillddlList.Read())
                    {
                        //cboBox.Items.Add(rsFillCombo.GetValue(1).ToString());
                        (aspCTL as ListBox).Items.Add(new ListItem(rsFillddlList.GetValue(1).ToString(), rsFillddlList.GetValue(0).ToString()));
                        (aspCTL as ListBox).Items.Remove("Windows System");
                    }
                }
                else if (aspCTL is GridView)
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    (aspCTL as GridView).DataSource = dt;
                    (aspCTL as GridView).DataBind();
                }
                else if (aspCTL is Repeater)
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    (aspCTL as Repeater).DataSource = dt;
                    (aspCTL as Repeater).DataBind();
                }
            }
            catch (Exception ex)
            {
                SendErroMail(Err.ToString());
            }
            finally
            {
                cnLoad.Close();
            }

        }

        public void BindControls(string srQry, Control aspCTL)
        {
            SqlConnection cnLoad = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(srQry, cnLoad);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandTimeout = 0;
            cnLoad.Close();
            cnLoad.Open();
            try
            {
                if (aspCTL is DropDownList)
                {
                    SqlDataReader rsFillddlList = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    (aspCTL as DropDownList).Items.Clear();
                    while (rsFillddlList.Read())
                    {
                        //cboBox.Items.Add(rsFillCombo.GetValue(1).ToString());
                        (aspCTL as DropDownList).Items.Add(new ListItem(rsFillddlList.GetValue(1).ToString(), rsFillddlList.GetValue(0).ToString()));
                        (aspCTL as DropDownList).Items.Remove("Windows System");
                    }
                    (aspCTL as DropDownList).Items.Insert(0, new ListItem("--Select--", ""));
                }
                else if (aspCTL is CheckBoxList)
                {
                    SqlDataReader rsFillddlList = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    (aspCTL as CheckBoxList).Items.Clear();
                    while (rsFillddlList.Read())
                    {

                        //cboBox.Items.Add(rsFillCombo.GetValue(1).ToString());
                        (aspCTL as CheckBoxList).Items.Add(new ListItem(rsFillddlList.GetValue(1).ToString(), rsFillddlList.GetValue(0).ToString()));
                        (aspCTL as CheckBoxList).Items.Remove("Windows System");
                    }
                }
                else if (aspCTL is ListBox)
                {
                    SqlDataReader rsFillddlList = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    (aspCTL as ListBox).Items.Clear();
                    while (rsFillddlList.Read())
                    {
                        //cboBox.Items.Add(rsFillCombo.GetValue(1).ToString());
                        (aspCTL as ListBox).Items.Add(new ListItem(rsFillddlList.GetValue(1).ToString(), rsFillddlList.GetValue(0).ToString()));
                        (aspCTL as ListBox).Items.Remove("Windows System");
                    }
                }
                else if (aspCTL is GridView)
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    (aspCTL as GridView).DataSource = dt;
                    (aspCTL as GridView).DataBind();
                }
                else if (aspCTL is Repeater)
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    (aspCTL as Repeater).DataSource = dt;
                    (aspCTL as Repeater).DataBind();
                }
            }
            catch (Exception ex)
            {
                SendErroMail(Err.ToString());
            }
            finally
            {
                cnLoad.Close();
            }
        }

        public string GetCodeStrE(string SPName, string[] ParamArr, string[] ValArr)
        {
            string strCode = "";
            SqlConnection cnSql = new SqlConnection(strConn);
            cnSql.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(SPName, cnSql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                for (int i = 0; i <= ParamArr.Length - 1; i++)
                {
                    cmd.Parameters.AddWithValue(ParamArr[i], ValArr[i]);
                }
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read())
                {
                    if (dr.GetValue(0).ToString() == "")
                    {
                        strCode = "";
                    }
                    else
                    {
                        strCode = dr.GetValue(0).ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                SendErroMail(Err.ToString());
                strCode = ex.ToString();
            }
            return strCode;
        }

        public bool ExecuteQuerySP(string SPName, string[] ParamArr, string[] ValArr)
        {
            bool result = false;

            SqlConnection Conn = new SqlConnection(strConn);
            Conn.Open();
            SqlTransaction myTrans = Conn.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand(SPName, Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                for (int i = 0; i <= ParamArr.Length - 1; i++)
                {
                    if (ValArr[i] == null || ValArr[i].ToString() == "")
                        cmd.Parameters.AddWithValue(ParamArr[i], DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue(ParamArr[i], ValArr[i]);
                }
                cmd.Transaction = myTrans;
                cmd.CommandTimeout = 0;
                int res = cmd.ExecuteNonQuery();
                myTrans.Commit();
                myTrans.Dispose();
                if (res == 0)
                    result = false;
                else
                    result = true;
                Conn.Close();
            }
            catch (Exception Err)
            {
                myTrans.Rollback();
                myTrans.Dispose();
                Conn.Close();
                strClassErr = Err.Message.ToString();
                //ErroLog(Err.Message.ToString(), "DateFormat", "ConnClass", DateTime.Now.ToString(), "Ashu", "SSPL");
                result = false;
                myTrans.Rollback();

                SendErroMail(Err.ToString());
                result = false;
            }
            return result;
        }
        public string ExecuteQuerySP_Retrun_String(string SPName, string[] ParamArr, string[] ValArr)
        {
            string result = "";

            SqlConnection Conn = new SqlConnection(strConn);
            Conn.Open();
            SqlTransaction myTrans = Conn.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand(SPName, Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                for (int i = 0; i <= ParamArr.Length - 1; i++)
                {
                    if (ValArr[i] == null || ValArr[i].ToString() == "")
                        cmd.Parameters.AddWithValue(ParamArr[i], DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue(ParamArr[i], ValArr[i]);
                }
                cmd.Transaction = myTrans;
                result = cmd.ExecuteScalar().ToString();
                myTrans.Commit();
                myTrans.Dispose();
                Conn.Close();
            }
            catch (Exception Err)
            {
                myTrans.Rollback();
                myTrans.Dispose();
                Conn.Close();

                strClassErr = Err.Message.ToString();
                //ErroLog(Err.Message.ToString(), "DateFormat", "ConnClass", DateTime.Now.ToString(), "Ashu", "SSPL");
                result = strClassErr;

                SendErroMail(Err.ToString());


                throw Err;
            }
            return result;
        }


        public string Excute_DataTable(DataTable dt, string SPName, string[] dtParamArr, string[] SrvParamArr)
        {
            string result = "";

            SqlConnection Conn = new SqlConnection(strConn);
            Conn.Open();
            SqlTransaction myTrans = Conn.BeginTransaction();

            try
            {
                for (int k = 0; k <= dt.Rows.Count - 1; k++)
                {
                    SqlCommand cmd = new SqlCommand(SPName, Conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    for (int i = 0; i <= dtParamArr.Length - 1; i++)
                    {
                        string val = dt.Rows[k][dtParamArr[i]].ToString();
                        if (dt.Rows[k][dtParamArr[i]].ToString() == null || dt.Rows[k][dtParamArr[i]].ToString() == "")
                            cmd.Parameters.AddWithValue(SrvParamArr[i], DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue(SrvParamArr[i], dt.Rows[k][dtParamArr[i]].ToString());
                    }


                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                }



                myTrans.Commit();
                myTrans.Dispose();
                Conn.Close();
                result = "Data Saved Successfully";
            }
            catch (Exception Err)
            {
                myTrans.Rollback();
                myTrans.Dispose();
                Conn.Close();

                strClassErr = Err.Message.ToString();
                //ErroLog(Err.Message.ToString(), "DateFormat", "ConnClass", DateTime.Now.ToString(), "Ashu", "SSPL");
                result = strClassErr;

                SendErroMail(Err.ToString());


                throw Err;
            }
            return result;
        }


        public string BulkInsertTable(string TableName, DataTable dt, string[] dtParamArr, string[] SrvParamArr)
        {

            string result = "";

            try
            {

                using (SqlConnection con = new SqlConnection(strConn))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = TableName;

                        //[OPTIONAL]: Map the DataTable columns with that of the database table

                        for (int i = 0; i <= dtParamArr.Length - 1; i++)
                        {
                            if (dtParamArr[i] == null || dtParamArr[i].ToString() == "")
                                sqlBulkCopy.ColumnMappings.Add(dtParamArr[i], SrvParamArr[i]);
                            else
                                sqlBulkCopy.ColumnMappings.Add(dtParamArr[i], SrvParamArr[i]);
                        }

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }


                result = "Saved Data";
            }
            catch (Exception Err)
            {
                strClassErr = Err.Message.ToString();

                result = strClassErr;

                SendErroMail(Err.ToString());


                throw Err;
            }
            return result;
        }


        //--------------------------------------------End With Stored Procedure-------------------------------------------------------------

        public void FillHTMLDDList(string strSql, System.Web.UI.HtmlControls.HtmlSelect ddList)
        {
            SqlConnection cnLoad = new SqlConnection(strConn);
            cnLoad.Open();
            SqlCommand myCommandFillCombo = new SqlCommand(strSql);
            myCommandFillCombo.Connection = cnLoad;
            myCommandFillCombo.CommandType = CommandType.Text;
            myCommandFillCombo.CommandTimeout = 0;
            SqlDataReader rsFillCombo = myCommandFillCombo.ExecuteReader(CommandBehavior.CloseConnection);
            ddList.Items.Clear();
            try
            {
                while (rsFillCombo.Read())
                {
                    //cboBox.Items.Add(rsFillCombo.GetValue(1).ToString());
                    ddList.Items.Add(new ListItem(rsFillCombo.GetValue(1).ToString(), rsFillCombo.GetValue(0).ToString()));
                    ddList.Items.Remove("Windows System");
                }
                ddList.Items.Insert(0, new ListItem("--Select--", ""));
                ddList.Multiple = true;
            }
            catch (Exception Err)
            {
                SendErroMail(Err.ToString());
                throw Err;
            }
            finally
            {
                cnLoad.Close();
            }
        }

        public void SelectComboValue(string strValue, System.Web.UI.WebControls.DropDownList ddList)
        {
            bool result = false;
            for (int j = 0; j <= ddList.Items.Count - 1; j++)
            {
                if (ddList.Items[j].Value == strValue && !(ddList.Items[j].Value).Equals(""))
                {
                    //ddList.SelectedItem.Text = ddList.Items[j].Text;
                    ddList.SelectedIndex = j;
                    result = true;
                    break;
                }
            }
            if (result == false)
                ddList.SelectedIndex = 0;
        }

        public void SelectComboText(string strValue, System.Web.UI.WebControls.DropDownList ddList)
        {
            bool result = false;
            for (int j = 0; j <= ddList.Items.Count - 1; j++)
            {
                if (ddList.Items[j].Text == strValue && !(ddList.Items[j].Text).Equals(""))
                {
                    //ddList.SelectedItem.Text = ddList.Items[j].Text;
                    ddList.SelectedIndex = j;
                    result = true;
                    break;
                }
            }
            if (result == false)
                ddList.SelectedIndex = 0;
        }

        public bool ExecuteQuery(String strQuery)
        {
            bool result = false;

            SqlConnection Conn = new SqlConnection(strConn);
            Conn.Open();
            SqlTransaction myTrans = Conn.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand(strQuery, Conn);
                cmd.Transaction = myTrans;
                cmd.CommandTimeout = 0;
                int res = cmd.ExecuteNonQuery();
                myTrans.Commit();
                myTrans.Dispose();
                if (res == 0)
                    result = false;

                else
                    result = true;

                Conn.Close();
            }
            catch (Exception Err)
            {
                myTrans.Rollback();
                myTrans.Dispose();
                Conn.Close();
                strClassErr = Err.Message.ToString();
                //ErroLog(Err.Message.ToString(), "DateFormat", "ConnClass", DateTime.Now.ToString(), "Ashu", "SSPL");
                result = false;
                myTrans.Rollback();
                SendErroMail(Err.ToString());
                result = false;
            }
            return result;
        }

        public string GetCode(string strRtfName, string strTableName, string strCmpField, string strCmpText, string strSchID)
        {
            string strRCode = "";
            string strSql = " Select " + strRtfName + " From " + strTableName + " Where " + strCmpField + "='" + strCmpText + "'" + " And SCHOOL_ID ='" + strSchID + "'";
            SqlConnection cnGenCode = new SqlConnection(strConn);
            cnGenCode.Open();
            SqlCommand cmoCode = new SqlCommand(strSql);
            cmoCode.Connection = cnGenCode;
            cmoCode.CommandType = CommandType.Text;
            cmoCode.CommandTimeout = 0;
            SqlDataReader rsCode = cmoCode.ExecuteReader(CommandBehavior.CloseConnection);

            if (rsCode.Read())
            {
                if (rsCode.GetValue(0).ToString() == "")
                {
                    strRCode = "";
                }
                else
                {
                    strRCode = rsCode.GetValue(0).ToString();
                }
            }
            return strRCode;
        }

        public string GetCode(string strRtfName, string strTableName, string strCmpField, string strCmpText)
        {
            string strRCode = "";
            string strSql = " Select " + strRtfName + " From " + strTableName + " Where Upper(" + strCmpField + ")='" + strCmpText.ToUpper() + "'";
            SqlConnection cnGenCode = new SqlConnection(strConn);
            cnGenCode.Open();
            SqlCommand cmoCode = new SqlCommand(strSql);
            cmoCode.Connection = cnGenCode;
            cmoCode.CommandType = CommandType.Text;
            cmoCode.CommandTimeout = 0;
            SqlDataReader rsCode = cmoCode.ExecuteReader(CommandBehavior.CloseConnection);

            if (rsCode.Read())
            {
                if (rsCode.GetValue(0).ToString() == "")
                {
                    strRCode = "";
                }
                else
                {
                    strRCode = rsCode.GetValue(0).ToString();
                }
            }
            return strRCode;
        }

        public string GetCodeStr(string strSql)
        {
            string strCode = "";
            SqlDataReader rsCode = GetDataReader(strSql);
            if (rsCode.Read())
            {
                if (rsCode.GetValue(0).ToString() == "")
                {
                    strCode = "";
                }
                else
                {
                    strCode = rsCode.GetValue(0).ToString();
                }
            }
            return strCode;

        }

        public void ClearControl(System.Web.UI.WebControls.Panel pnlName)
        {
            foreach (Control ctl in pnlName.Controls)
            {
                if (ctl is TextBox && ((TextBox)ctl).ToolTip == "")
                    ((TextBox)ctl).Text = "";
                if (ctl is CheckBox)
                    ((CheckBox)ctl).Checked = false;
                if (ctl is RadioButtonList)
                    for (int i = 0; ((RadioButtonList)ctl).Items.Count <= i; i++)
                    {
                        ((RadioButtonList)ctl).Items[0].Selected = false;
                    }
                if (ctl is DropDownList)
                {
                    if (((DropDownList)ctl).Items[((DropDownList)ctl).SelectedIndex].Text != "--Select--")
                    {
                        ((DropDownList)ctl).Items.Insert(0, new ListItem("--Select--", ""));
                        ((DropDownList)ctl).Text = ((DropDownList)ctl).Items[0].Value;
                    }
                }

            }
        }

        public void ClearControl(Control pnlName)
        {
            foreach (Control ctl in pnlName.Controls)
            {
                if (ctl is TextBox && ((TextBox)ctl).ToolTip == "")
                    ((TextBox)ctl).Text = "";
                if (ctl is CheckBox)
                    ((CheckBox)ctl).Checked = false;
                if (ctl is RadioButtonList)
                    for (int i = 0; ((RadioButtonList)ctl).Items.Count <= i; i++)
                    {
                        ((RadioButtonList)ctl).Items[0].Selected = false;
                    }
                if (ctl is DropDownList)
                {
                    if (((DropDownList)ctl).Items[0].Text != "--Select--")
                    {
                        ((DropDownList)ctl).Items.Insert(0, new ListItem("--Select--", ""));
                        ((DropDownList)ctl).Text = ((DropDownList)ctl).Items[0].Value;
                    }
                }

            }
        }

        public void FillDataGrid(string StrSql, System.Web.UI.WebControls.GridView dgdGrid)
        {
            try
            {
                DataSet dso = new DataSet();
                DataTable dto = new DataTable();
                DataView dvo = new DataView();

                SqlDataAdapter ada = new SqlDataAdapter(StrSql, strConn);
                ada.Fill(dso, "FillGrid");
                dto = dso.Tables["FillGrid"];
                dvo = new DataView(dto);
                dgdGrid.DataSource = dvo;
                dgdGrid.DataBind();

            }
            catch (Exception ex)
            {
                SendErroMail(Err.ToString());
            }
        }

        public DataSet GetDataSet(string StrSql)
        {
            DataSet dso = new DataSet();
            try
            {
                SqlDataAdapter sdao = new SqlDataAdapter(StrSql, strConn);
                sdao.Fill(dso);
            }
            catch (Exception Err)
            {
                strClassErr = Err.ToString();
                SendErroMail(Err.ToString());

            }
            return dso;
        }

        public DataSet GetDataSet(string SPName, string[] ParamArr, string[] ValArr)
        {
            DataSet dso = new DataSet();
            SqlConnection cnSql = new SqlConnection(strConn);
            cnSql.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(SPName, cnSql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                for (int i = 0; i <= ParamArr.Length - 1; i++)
                {
                    cmd.Parameters.AddWithValue(ParamArr[i], ValArr[i]);
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dso);
            }
            catch (Exception Err)
            {
                strClassErr = Err.ToString();
                SendErroMail(Err.ToString());
            }
            return dso;
        }


        public bool CreateDataSet(string strFldName, string strFldType)
        {
            int Count = calcOccurance(strFldName, ",");
            string strFn = "";
            string strFt = "";
            bool blnResult = false;

            try
            {
                DataSet dso = new DataSet("MyDataSet");
                DataTable dto = new DataTable("DtTable");
                for (int i = 1; i <= Count + 1; i++)
                {
                    strFn = getItemByPos(strFldName, i, ",");
                    strFt = getItemByPos(strFldType, i, ",");

                    if (strFt.ToUpper() == "STR")
                    {
                        dto.Columns.Add(strFn, Type.GetType("System.String"));
                    }
                    else if (strFt.ToUpper() == "INT")
                    {
                        dto.Columns.Add(strFn, Type.GetType("System.Int64"));
                    }
                    else if (strFt.ToUpper() == "DBL")
                    {
                        dto.Columns.Add(strFn, Type.GetType("System.Double"));
                    }
                    else if (strFt.ToUpper() == "DAT")
                    {
                        dto.Columns.Add(strFn, Type.GetType("System.DateTime"));
                    }
                    else if (strFt.ToUpper() == "BL")
                    {
                        dto.Columns.Add(strFn, Type.GetType("System.Boolean"));
                    }
                    else if (strFt.ToUpper() == "Chr")
                    {
                        dto.Columns.Add(strFn, Type.GetType(" System.Char"));
                    }
                }
                blnResult = true;
            }

            catch
            {
                blnResult = false;
            }

            return blnResult;

            //DataRow dtDataRow = dt.NewRow();
            //dt.Rows.Add(new Object[] {10000, "1 Shrewsbury Road", "500 Sq. Yards" });
            //dt.Rows.Add(new Object[] {30000, "2 Shrewsbury Road", "550 Sq. Yards" });
            //dt.Rows.Add(new Object[] {50000, "3 Shrewsbury Road", "30 Sq. Yards" });

            //ds.Tables.Add(dt);
            //ds.WriteXml("Test.xml");
        }

        public SqlDataReader GetDataReader(string StrSql)
        {
            SqlConnection cnSql = new SqlConnection(strConn);

            cnSql.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(StrSql, cnSql);

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }

            finally
            {
                //cnSql.Close();
            }

        }

        public enum BaseType
        {
            varString = 0,
            varDataTime = 1,
            varDouble = 2,
            varBool = 3
        };

        public bool CopyFile(string strSourceFileName, string strDestinationFileName, bool blnOverwrite)
        {
            bool blnResult = false;

            string strSpath = strSourceFileName;
            string strDpath = strDestinationFileName;

            if (File.Exists(strSpath))
            {
                File.Copy(strSpath, strDpath, blnOverwrite);
                blnResult = true;
            }
            else
            {
                blnResult = false;
            }

            return blnResult;
        }

        public bool MoveFile(string strSourceFileName, string strDestinationFileName)
        {
            bool blnResult = false;

            string strSpath = strSourceFileName;
            string strDpath = strDestinationFileName;

            if (File.Exists(strSpath))
            {
                // Ensure that the target does not exist.
                if (File.Exists(strDpath))
                    File.Delete(strDpath);

                // Move the file.
                File.Move(strSpath, strDpath);
                blnResult = true;
            }
            else
            {
                blnResult = false;
            }
            return blnResult;
        }

        public bool DeleteFile(string strDelFileName)
        {
            bool blnResult = false;

            string strPath = strDelFileName;

            if (File.Exists(strPath))
            {
                // Ensure that the target does not exist.
                if (File.Exists(strPath))
                    File.Delete(strPath);
                blnResult = true;
            }
            else
            {
                blnResult = false;
            }
            return blnResult;
        }

        public bool RenameFile(string strSourceFileName, string strDestinationFileName)
        {
            bool blnResult = false;

            string strSpath = strSourceFileName;
            string strDpath = strDestinationFileName;

            if (File.Exists(strSpath))
            {
                // Ensure that the target does not exist.
                if (File.Exists(strDpath))
                    File.Delete(strDpath);

                // Move the file.
                File.Move(strSpath, strDpath);
                blnResult = true;
            }
            else
            {
                blnResult = false;
            }
            return blnResult;
        }

        public bool ExitstFile(string strFileName)
        {
            bool blnResult = false;
            string strpath = strFileName;

            if (File.Exists(strpath))
            {
                // Ensure that the target does not exist.
                if (File.Exists(strpath))
                    blnResult = true;
            }
            else
            {
                blnResult = false;
            }

            return blnResult;
        }

        public bool CreateFile(string strFileName)
        {
            bool blnResult = false;
            string strPath = strFileName;
            if (File.Exists(strPath))
            {
                if (!File.Exists(strPath))

                    // This statement ensures that the file is created,
                    // but the handle is not kept.
                    using (FileStream fs = File.Create(strPath)) { }
                blnResult = true;
            }
            else
            {
                blnResult = false;
            }
            return blnResult;
        }

        //Directories Releted Method

        public bool ExitstFolder(string strFolderName)
        {
            bool blnResult = false;
            string path = @strFolderName;

            // Determine whether the directory exists.
            if (Directory.Exists(path))
            {
                blnResult = true;
            }
            else
            {
                blnResult = false;
            }

            return blnResult;
        }

        public bool CreateFolder(string strFolderName)
        {
            bool blnResult = false;
            string strPath = @strFolderName;

            // Determine whether the directory exists.
            if (Directory.Exists(strPath))
            {
                blnResult = false;
            }
            else
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(strPath);
                blnResult = true;
            }

            return blnResult;
        }

        public bool DeleteFolder(string strFolderName)
        {
            bool blnResult = false;
            string path = @strFolderName;

            // Determine whether the directory exists.
            if (Directory.Exists(path))
            {
                // Try to Delete the directory.
                Directory.Delete(path);
                blnResult = true;
            }
            else
            {

                blnResult = false;
            }

            return blnResult;
        }

        public void MoveFolder(string strSourceDir, string strDestDir, bool blnDelSource)
        {
            if (Directory.Exists(strSourceDir))
            {
                if (Directory.GetDirectoryRoot(strSourceDir) == Directory.GetDirectoryRoot(strDestDir))
                {
                    Directory.Move(strSourceDir, strDestDir);
                }
                else
                {
                    try
                    {
                        CopyFolder(new DirectoryInfo(strSourceDir), new DirectoryInfo(strDestDir));
                        if (blnDelSource)
                            Directory.Delete(strSourceDir, true);
                    }
                    catch (Exception subEx)
                    {
                        throw subEx;
                    }
                }
            }
        }


        // Way To Call CopyFolder Function 
        //CopyFolder(new DirectoryInfo("C:\\Ashu"), new DirectoryInfo("D:\\Ashu")) 

        public void CopyFolder(DirectoryInfo dirSource, DirectoryInfo dirDestination)
        {
            if (!dirDestination.Exists)
                dirDestination.Create();

            FileInfo[] fiSrcFiles = dirSource.GetFiles();

            foreach (FileInfo fiSrcFile in fiSrcFiles)
                fiSrcFile.CopyTo(Path.Combine(dirDestination.FullName, fiSrcFile.Name));

            DirectoryInfo[] diSrcDirectories = dirSource.GetDirectories();

            foreach (DirectoryInfo diSrcDirectory in diSrcDirectories)
                CopyFolder(diSrcDirectory, new DirectoryInfo(Path.Combine(dirDestination.FullName, diSrcDirectory.Name)));
        }

        //***********************************************************************************************

        public int calcOccurance(string strString, string strDelimeter)
        {
            int intCount = 0;
            string strSt = "";
            if (strString.ToString().Length > 0)
            {
                for (int i = 0; i < strString.Length; i++)
                {
                    strSt = strString.Substring(i, 1);
                    if (strSt.Contains(strDelimeter))
                        intCount = intCount + 1;
                }
            }
            return intCount;
        }

        public string getItemByPos(string strString, int intPosition, string strDelimeter)
        {
            int intCount = 0;
            int intPos = 0;
            string strSt1 = "";
            string strSt;

            int intOccuCount = calcOccurance(strString, strDelimeter);
            if (strString.ToString().Length > 0)
            {
                for (int i = 0; i < strString.Length; i++)
                {
                    strSt = strString.Substring(i, 1);

                    //if caloccurance is less than or equal to its delimeter

                    if (intOccuCount >= intPosition)
                    {
                        if (strSt.Contains(strDelimeter))
                        {
                            intCount = intCount + 1;
                            if (intCount == intPosition - 1)
                            {
                                intPos = i + 1;
                            }
                            if (intCount == intPosition)
                                strSt1 = strString.Substring(intPos, i - intPos);
                        }
                    }
                    // end of calOccurance PRocedure.
                    else if (intOccuCount < intPosition)
                    {
                        if (strSt.Contains(strDelimeter))
                        {
                            intCount = intCount + 1;
                            if (intCount == intPosition - 1)
                            {
                                intPos = i + 1;
                                strSt1 = strString.Substring(intPos, strString.Length - intPos);
                            }
                        }
                    }
                }
            }
            return strSt1;
        }

        public bool BasicType(string strFldType, string strFldValue, string strFldLen)
        {
            bool blnResult = false;
            //insertFieldName = "";
            insertFieldValue = "";
            if ((strFldType == "smallint") || (strFldType == "float") || (strFldType == "real") || (strFldType == "int") || (strFldType == "money") || (strFldType == "numeric") || (strFldType == "Decimal"))
            {
                if (IsNumeric(strFldValue) == true)
                {
                    insertFieldValue = strFldValue;
                    blnResult = true;
                }
                else
                    blnResult = false;
                //Result = "numeric";
            }
            else if ((strFldType == "bit"))
                if (IsBoolean(strFldValue) == true)
                {
                    if ((strFldValue == "0") || (strFldValue == "false") || (strFldValue == "No") || (strFldValue == "N"))
                        insertFieldValue = "0";
                    else if ((strFldValue == "1") || (strFldValue == "true") || (strFldValue == "Yes") || (strFldValue == "Y"))
                        insertFieldValue = "1";
                    blnResult = true;
                }
                else
                    blnResult = false;
            else
                if (strFldValue.ToString().Length <= int.Parse(strFldLen))
            {
                insertFieldValue = "'" + strFldValue + "'";
                blnResult = true;
            }
            else
                blnResult = false;

            return blnResult;
        }

        public bool IsBoolean(string strFldValue)
        {
            bool blnResult = false;
            if ((strFldValue == "0") || (strFldValue == "false") || (strFldValue == "No") || (strFldValue == "N"))
                blnResult = true;
            else if ((strFldValue == "1") || (strFldValue == "true") || (strFldValue == "Yes") || (strFldValue == "Y"))
                blnResult = true;
            else
                blnResult = false;
            return blnResult;
        }

        public bool IsNumeric(string strFldValue)
        {
            double bdlNum;
            bool blnResult;

            bool blnYN = double.TryParse(strFldValue, out bdlNum);
            if (blnYN)
                blnResult = true;
            else
                blnResult = false;
            return blnResult;
        }


        //**** Check Duplicate


        public bool DeleteRecord(string strSql)
        {
            bool blnResult = false;
            if (strSql.Trim() != "")
            {
                if (ExecuteQuery(strSql) == true)
                    blnResult = true;
                else
                    blnResult = false;
            }
            else
            {
                blnResult = false;
            }
            return blnResult;
        }

        public string GetCurrentPageName()
        {
            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
        }

        //public string Encode(string text)
        //{
        //    string SifreEncoded = "";
        //    string strchar;
        //    int charvalue1;
        //    text = text.Trim();
        //    text = Microsoft.VisualBasic.Strings.StrReverse(text);
        //    text = text + Microsoft.VisualBasic.Strings.Space(encodeMax - text.Length);
        //    for (int i = 0; i < encodeMax; i++)
        //    {
        //        charvalue1 = Microsoft.VisualBasic.Strings.Asc(text.Substring(i, 1));
        //        charvalue1 = charvalue1 * (i + 1) + (i + 1) % 2;
        //        strchar = Microsoft.VisualBasic.Strings.Space(4 - charvalue1.ToString().Length) + charvalue1.ToString();
        //        strchar = strchar.Replace(" ", "0");
        //        SifreEncoded = SifreEncoded + strchar;
        //        System.Diagnostics.Debug.WriteLine(strchar);
        //        if ((i + 1) != encodeMax)
        //        {
        //            SifreEncoded = SifreEncoded + "-";
        //        }

        //    }

        //    SifreEncoded = "{" + SifreEncoded + "}";
        //    return SifreEncoded;
        //}

        //public object Decode(string TextEncoded)
        //{
        //    string SifreDecoded = "";
        //    string strchar;
        //    string charvalue;
        //    int charvalue1;
        //    TextEncoded = TextEncoded.Replace("{", " ");
        //    TextEncoded = TextEncoded.Replace("}", " ");
        //    TextEncoded = TextEncoded.Trim();
        //    for (int i = 0; i < encodeMax; i++)
        //    {
        //        charvalue = TextEncoded.Substring(((i + 1) - 1) * 5, 4);
        //        charvalue1 = Convert.ToInt32(charvalue) - (i + 1) % 2;
        //        charvalue1 = charvalue1 / (i + 1);

        //        strchar = new string(Microsoft.VisualBasic.Strings.Chr(charvalue1), 1);
        //        SifreDecoded = SifreDecoded + strchar;
        //    }
        //    SifreDecoded = Microsoft.VisualBasic.Strings.StrReverse(SifreDecoded);
        //    SifreDecoded = SifreDecoded.Trim();
        //    return SifreDecoded;
        //}

        public void AddMergedCells(GridViewRow objgridviewrow, TableCell objtablecell, int colspan, string celltext)
        {
            objtablecell = new TableCell();
            objtablecell.Text = celltext;
            objtablecell.ColumnSpan = colspan;
            objgridviewrow.Cells.Add(objtablecell);
        }

        public string MyDateFormat(string txtDate)
        {
            string MDate = txtDate;

            if (!txtDate.Equals("") && !(System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern.ToString().Equals("dd/MM/yyyy")))
            {
                string mssage = MDate;
                string MM = string.Empty;
                string DD = string.Empty;

                char[] separator = new char[] { '/' };
                string[] colorList = mssage.Split(separator);

                if (colorList[0].Length == 1)
                    MM = "0" + colorList[0];
                else
                    MM = colorList[0];

                if (colorList[1].Length == 1)
                    DD = "0" + colorList[1];
                else
                    DD = colorList[1];

                MDate = DD + "/" + MM + "/" + colorList[2].Substring(0, 4);

            }

            return MDate;
        }

        public void Redirect(string url, string target, string windowFeatures)
        {
            HttpContext context = HttpContext.Current;

            if ((String.IsNullOrEmpty(target) ||
                target.Equals("_self", StringComparison.OrdinalIgnoreCase)) &&
                String.IsNullOrEmpty(windowFeatures))
            {

                context.Response.Redirect(url);
            }
            else
            {
                Page page = (Page)context.Handler;
                if (page == null)
                {
                    throw new InvalidOperationException(
                        "Cannot redirect to new window outside Page context.");
                }
                url = page.ResolveClientUrl(url);

                string script;
                if (!String.IsNullOrEmpty(windowFeatures))
                {
                    script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
                }
                else
                {
                    script = @"window.open(""{0}"", ""{1}"");";
                }

                script = String.Format(script, url, target, windowFeatures);
                ScriptManager.RegisterStartupScript(page,
                    typeof(Page),
                    "Redirect",
                    script,
                    true);
            }
        }


        //public enum DateOperationN { Dmy, Mdy, Ymd, Querydate, Custom }



        public string SendSMS(string Mobile, string sMsg)
        {
            string urlText = string.Empty;

            if (!Mobile.Equals("0") || Mobile.ToString().Equals(""))
            {
                WebRequest request = HttpWebRequest.Create("http://sms.sahuinfotech.com/api/sendmsg.php?user=PCEMRAIPUR&pass=Mech111&sender=PCEMRA&phone=" + Mobile + " &text= " + sMsg + "&priority=ndnd&stype=normal");
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                urlText = reader.ReadToEnd(); // it takes the response from your url. now you can use as your need 
                //Response.Write(urlText.ToString());
            }

            return urlText;
        }

        ///************************************ New Try **********************************************************************************
        public class Friend
        {
            public Guid ID { get; set; }
            public string StudentName { get; set; }
            public string Category { get; set; }
        }

        public void NewFillDDList(string strSql, System.Web.UI.WebControls.DropDownList ddList)
        {
            SqlConnection cnLoad = new SqlConnection(strConn);
            cnLoad.Open();
            string text = string.Empty;

            SqlCommand myCommandFillCombo = new SqlCommand(strSql);
            myCommandFillCombo.Connection = cnLoad;
            myCommandFillCombo.CommandType = CommandType.Text;
            SqlDataReader rsFillCombo = myCommandFillCombo.ExecuteReader(CommandBehavior.CloseConnection);
            ddList.Items.Clear();
            try
            {
                while (rsFillCombo.Read())
                {

                    text = string.Format("{0} | {1} | {2} ", rsFillCombo[1].ToString().PadRight(27, '\u00A0'), rsFillCombo[2].ToString().PadRight(10, '\u00A0'), rsFillCombo[3].ToString().PadRight(10, '\u00A0'));
                    ddList.Items.Add(new ListItem(text, rsFillCombo.GetValue(0).ToString()));
                    ddList.Items.Remove("Windows System");
                }
                ddList.Items.Insert(0, new ListItem("--Select--", ""));
            }
            catch (Exception Err)
            {
                throw Err;
            }
            finally
            {
                cnLoad.Close();
            }
        }

        //public void SendMail(string RecipientEmailID,string EmailSubject,string EmailBody)
        //{
        //    string Email_Body = HWR(EmailBody);
        //    if (!string.IsNullOrEmpty(RecipientEmailID) && RecipientEmailID != "NULL")
        //    {
        //        using (MailMessage mm = new MailMessage("itask.sarvang@gmail.com", RecipientEmailID.ToString()))
        //        {

        //            mm.Subject = EmailSubject.ToString();
        //            mm.Body = Email_Body;
        //            mm.IsBodyHtml = true;

        //            SmtpClient smtp = new SmtpClient();
        //            smtp.Host = "smtp.gmail.com";
        //            smtp.EnableSsl = true;
        //            NetworkCredential NetworkCred = new NetworkCredential("itask.sarvang@gmail.com", "Korba@123");
        //            smtp.UseDefaultCredentials = true;
        //            smtp.Credentials = NetworkCred;
        //            smtp.Port = 587;
        //            smtp.Send(mm);
        //        }
        //    }
        //}

        public void SendMail(string RecipientEmailID, string EmailSubject, string EmailBody)
        {
            try
            {
                using (MailMessage mm = new MailMessage("itadmin@vedanta.co.in", RecipientEmailID))
                {
                    mm.Subject = EmailSubject;
                    mm.Body = HWR(EmailBody);
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "10.101.71.205";
                    smtp.EnableSsl = false;
                    NetworkCredential NetworkCred = new NetworkCredential("itadmin", "B@lcO1234");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 25;
                    smtp.Send(mm);
                }
            }
            catch (Exception err)
            {

            }
        }

        public string HWR(string url_address)
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url_address);
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();

            return responseString;
        }
    }
}