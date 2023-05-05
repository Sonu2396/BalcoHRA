using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalcoHRA.Business_Layer.UserMgt;
using BalcoHRA.Business_Layer;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace BalcoHRA
{
    public partial class Auditor_Entry : System.Web.UI.Page
    {

        BL_AUDIT cn = new BL_AUDIT();
        BL_JOB ccn = new BL_JOB();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Session["UserId"] == null)
            {
                Session.Clear();
                Session.RemoveAll();
                Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                BL_Common_Controls CCM = new BL_Common_Controls();
                string lblUserid = Session["UserId"].ToString();

                pnlEntry.Visible = true;

                ClearData();



            }
        }


        public string strConn
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["HRADBConnectionString"].ConnectionString.ToString();
            }
        }

        public void ClearData()
        {
            BL_Common_Controls CCM = new BL_Common_Controls();
            string lblUserid = Session["UserId"].ToString();

            
            DataTable dt = cn.Bind_Plan(lblUserid);

            lbltransid.Text = "";

            GridView1.DataSource = dt;
            GridView1.DataBind();

            GridView2.Visible = false;


        }


        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
                 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                    DropDownList ddlChecklist = (e.Row.FindControl("ddlChecklist") as DropDownList);
                
                    string jobid = e.Row.Cells[0].Text;
                    DataTable dt = new DataTable();
                    dt = cn.DropDownlist_Checklist(jobid);

                    try
                    {
                        ddlChecklist.DataSource = dt;
                        ddlChecklist.DataBind();
                        ddlChecklist.DataTextField = "ActivityName";
                        ddlChecklist.DataValueField = "ActivityId";
                        ddlChecklist.DataBind();
                        ddlChecklist.Items.Insert(0, "Select");
                    }
                    catch
                    {
                    ddlChecklist.Items.Insert(0, "Select");
                    }

                
            }
        }



        protected void ddlChecklist_SelectedIndexChanged(object sender, EventArgs e)
        {


            DropDownList ddlChecklist = sender as DropDownList;
            GridViewRow gvrow = (GridViewRow)ddlChecklist.NamingContainer;

            string check = ddlChecklist.SelectedItem.Text;
            lblchcklistname.Text = check;

            string chkID = ddlChecklist.SelectedItem.Value;

            FlagStatusClass.CurrentWorkingTable = chkID;

            lblchkid.Text = chkID;

            lbljobid.Text = gvrow.Cells[0].Text;

            FlagStatusClass.StaticTransID = Convert.ToInt32(gvrow.Cells[0].Text);

            string lblUserid = Session["UserId"].ToString();

            DataTable dt2 = new DataTable();
            dt2 = cn.Bind_Checklist(check);

            GridView2.DataSource = null;
            GridView2.DataSource = dt2;
            GridView2.DataBind();
            GridView2.Visible = true;

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            Button btnsubmit = sender as Button;
            GridViewRow gvrow = (GridViewRow)btnsubmit.NamingContainer;
            String trid = gvrow.Cells[0].Text;

            Label lblUserid = (Label)Page.Master.FindControl("lbluserid");
            String Result = cn.Job_Submit_Forcedclose(trid, lblUserid.Text, "1", "Forceclosed");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Result + "','success');", true);
            ClearData();

        }
        

        protected void btnscore_Click(object sender, EventArgs e)
        {

            if(FlagStatusClass.CurrentWorkingTable == "1")
            {

                string check = lblchcklistname.Text;
                string lblUserid = Session["UserId"].ToString();
                string chkid = lblchkid.Text;

                for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                {
                    DropDownList ddlScore = ((DropDownList)GridView2.Rows[i].FindControl("ddlScore"));
                    if (ddlScore.SelectedIndex == 0)
                    {
                        string Emsg = "Please Enter Score of Row no : " + (i + 1).ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Emsg + "','warning');", true);
                        ddlScore.Focus();
                        return;
                    }
                }
                int ToalRecSave = 0;
                String lblTransactionID = lbljobid.Text;
                for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                {

                    DropDownList ddlScore = (DropDownList)GridView2.Rows[i].FindControl("ddlscore");
                    string Scoreval = ddlScore.SelectedItem.Text;
                    String CriticalControl = GridView2.Rows[i].Cells[0].Text;
                    String Objective = GridView2.Rows[i].Cells[1].Text; ;
                    String Points = GridView2.Rows[i].Cells[2].Text;
                    TextBox txtremarks = ((TextBox)GridView2.Rows[i].FindControl("txtremarks"));

                    bool Rslt = cn.Data_Save(lblTransactionID, check, CriticalControl, Objective, Points, Scoreval, txtremarks.Text, lblUserid, "Save");
                    if (Rslt == true)
                        ToalRecSave++;
                }
                if (GridView2.Rows.Count == ToalRecSave)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Data Saved');", true);
                    ClearData();
                }



                SqlConnection cnSql = new SqlConnection(strConn);
                DataTable dt = new DataTable();
                string sqlStr = "update TRANSACTION_JOB set StatusWAH=1 where TransID= '"+FlagStatusClass.StaticTransID+"'";
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
                    //SendErroMail(sqlStr, ex.ToString(), strConn);
                }

            }

            else if (FlagStatusClass.CurrentWorkingTable == "2")
            {
                string check = lblchcklistname.Text;
                string lblUserid = Session["UserId"].ToString();
                string chkid = lblchkid.Text;

                for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                {
                    DropDownList ddlScore = ((DropDownList)GridView2.Rows[i].FindControl("ddlScore"));
                    if (ddlScore.SelectedIndex == 0)
                    {
                        string Emsg = "Please Enter Score of Row no : " + (i + 1).ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Emsg + "','warning');", true);
                        ddlScore.Focus();
                        return;
                    }
                }
                int ToalRecSave = 0;
                String lblTransactionID = lbljobid.Text;
                for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                {

                    DropDownList ddlScore = (DropDownList)GridView2.Rows[i].FindControl("ddlscore");
                    string Scoreval = ddlScore.SelectedItem.Text;
                    String CriticalControl = GridView2.Rows[i].Cells[0].Text;
                    String Objective = GridView2.Rows[i].Cells[1].Text; ;
                    String Points = GridView2.Rows[i].Cells[2].Text;
                    TextBox txtremarks = ((TextBox)GridView2.Rows[i].FindControl("txtremarks"));

                    bool Rslt = cn.Data_Save(lblTransactionID, check, CriticalControl, Objective, Points, Scoreval, txtremarks.Text, lblUserid, "Save");
                    if (Rslt == true)
                        ToalRecSave++;
                }
                if (GridView2.Rows.Count == ToalRecSave)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Data Saved');", true);
                    ClearData();
                }


                SqlConnection cnSql = new SqlConnection(strConn);
                DataTable dt = new DataTable();
                string sqlStr = "update TRANSACTION_JOB set StatusCS =1 where TransID= '" + FlagStatusClass.StaticTransID + "'";
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
                    //SendErroMail(sqlStr, ex.ToString(), strConn);
                }

            }

            else if (FlagStatusClass.CurrentWorkingTable == "3")
            {
                string check = lblchcklistname.Text;
                string lblUserid = Session["UserId"].ToString();
                string chkid = lblchkid.Text;

                for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                {
                    DropDownList ddlScore = ((DropDownList)GridView2.Rows[i].FindControl("ddlScore"));
                    if (ddlScore.SelectedIndex == 0)
                    {
                        string Emsg = "Please Enter Score of Row no : " + (i + 1).ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Emsg + "','warning');", true);
                        ddlScore.Focus();
                        return;
                    }
                }
                int ToalRecSave = 0;
                String lblTransactionID = lbljobid.Text;
                for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                {

                    DropDownList ddlScore = (DropDownList)GridView2.Rows[i].FindControl("ddlscore");
                    string Scoreval = ddlScore.SelectedItem.Text;
                    String CriticalControl = GridView2.Rows[i].Cells[0].Text;
                    String Objective = GridView2.Rows[i].Cells[1].Text; ;
                    String Points = GridView2.Rows[i].Cells[2].Text;
                    TextBox txtremarks = ((TextBox)GridView2.Rows[i].FindControl("txtremarks"));

                    bool Rslt = cn.Data_Save(lblTransactionID, check, CriticalControl, Objective, Points, Scoreval, txtremarks.Text, lblUserid, "Save");
                    if (Rslt == true)
                        ToalRecSave++;
                }
                if (GridView2.Rows.Count == ToalRecSave)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Data Saved');", true);
                    GridView2.Visible = false;
                    ClearData();
                }


                SqlConnection cnSql = new SqlConnection(strConn);
                DataTable dt = new DataTable();
                string sqlStr = "update TRANSACTION_JOB set StatusCL=1 where TransID= '" + FlagStatusClass.StaticTransID + "'";
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
                    //SendErroMail(sqlStr, ex.ToString(), strConn);
                }

            }

            else if (FlagStatusClass.CurrentWorkingTable == "4")
            {
                string check = lblchcklistname.Text;
                string lblUserid = Session["UserId"].ToString();
                string chkid = lblchkid.Text;

                for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                {
                    DropDownList ddlScore = ((DropDownList)GridView2.Rows[i].FindControl("ddlScore"));
                    if (ddlScore.SelectedIndex == 0)
                    {
                        string Emsg = "Please Enter Score of Row no : " + (i + 1).ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Emsg + "','warning');", true);
                        ddlScore.Focus();
                        return;
                    }
                }
                int ToalRecSave = 0;
                String lblTransactionID = lbljobid.Text;
                for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                {

                    DropDownList ddlScore = (DropDownList)GridView2.Rows[i].FindControl("ddlscore");
                    string Scoreval = ddlScore.SelectedItem.Text;
                    String CriticalControl = GridView2.Rows[i].Cells[0].Text;
                    String Objective = GridView2.Rows[i].Cells[1].Text; ;
                    String Points = GridView2.Rows[i].Cells[2].Text;
                    TextBox txtremarks = ((TextBox)GridView2.Rows[i].FindControl("txtremarks"));

                    bool Rslt = cn.Data_Save(lblTransactionID, check, CriticalControl, Objective, Points, Scoreval, txtremarks.Text, lblUserid, "Save");
                    if (Rslt == true)
                        ToalRecSave++;
                }
                if (GridView2.Rows.Count == ToalRecSave)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Data Saved');", true);
                    ClearData();
                }


                SqlConnection cnSql = new SqlConnection(strConn);
                DataTable dt = new DataTable();
                string sqlStr = "update TRANSACTION_JOB set StatusEX=1 where TransID= '" + FlagStatusClass.StaticTransID + "'";
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
                    //SendErroMail(sqlStr, ex.ToString(), strConn);
                }

            }

            else if (FlagStatusClass.CurrentWorkingTable == "5")
            {
                string check = lblchcklistname.Text;
                string lblUserid = Session["UserId"].ToString();
                string chkid = lblchkid.Text;

                for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                {
                    DropDownList ddlScore = ((DropDownList)GridView2.Rows[i].FindControl("ddlScore"));
                    if (ddlScore.SelectedIndex == 0)
                    {
                        string Emsg = "Please Enter Score of Row no : " + (i + 1).ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Emsg + "','warning');", true);
                        ddlScore.Focus();
                        return;
                    }
                }
                int ToalRecSave = 0;
                String lblTransactionID = lbljobid.Text;
                for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                {

                    DropDownList ddlScore = (DropDownList)GridView2.Rows[i].FindControl("ddlscore");
                    string Scoreval = ddlScore.SelectedItem.Text;
                    String CriticalControl = GridView2.Rows[i].Cells[0].Text;
                    String Objective = GridView2.Rows[i].Cells[1].Text; ;
                    String Points = GridView2.Rows[i].Cells[2].Text;
                    TextBox txtremarks = ((TextBox)GridView2.Rows[i].FindControl("txtremarks"));

                    bool Rslt = cn.Data_Save(lblTransactionID, check, CriticalControl, Objective, Points, Scoreval, txtremarks.Text, lblUserid, "Save");
                    if (Rslt == true)
                        ToalRecSave++;
                }
                if (GridView2.Rows.Count == ToalRecSave)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Data Saved');", true);
                    ClearData();
                }


                SqlConnection cnSql = new SqlConnection(strConn);
                DataTable dt = new DataTable();
                string sqlStr = "update TRANSACTION_JOB set StatusISO=1 where TransID= '" + FlagStatusClass.StaticTransID + "'";
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
                    //SendErroMail(sqlStr, ex.ToString(), strConn);
                }

            }

            else if (FlagStatusClass.CurrentWorkingTable == "6")
            {
                string check = lblchcklistname.Text;
                string lblUserid = Session["UserId"].ToString();
                string chkid = lblchkid.Text;

                for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                {
                    DropDownList ddlScore = ((DropDownList)GridView2.Rows[i].FindControl("ddlScore"));
                    if (ddlScore.SelectedIndex == 0)
                    {
                        string Emsg = "Please Enter Score of Row no : " + (i + 1).ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Emsg + "','warning');", true);
                        ddlScore.Focus();
                        return;
                    }
                }
                int ToalRecSave = 0;
                String lblTransactionID = lbljobid.Text;
                for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                {

                    DropDownList ddlScore = (DropDownList)GridView2.Rows[i].FindControl("ddlscore");
                    string Scoreval = ddlScore.SelectedItem.Text;
                    String CriticalControl = GridView2.Rows[i].Cells[0].Text;
                    String Objective = GridView2.Rows[i].Cells[1].Text; ;
                    String Points = GridView2.Rows[i].Cells[2].Text;
                    TextBox txtremarks = ((TextBox)GridView2.Rows[i].FindControl("txtremarks"));

                    bool Rslt = cn.Data_Save(lblTransactionID, check, CriticalControl, Objective, Points, Scoreval, txtremarks.Text, lblUserid, "Save");
                    if (Rslt == true)
                        ToalRecSave++;
                }
                if (GridView2.Rows.Count == ToalRecSave)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Data Saved');", true);
                    ClearData();
                }


                SqlConnection cnSql = new SqlConnection(strConn);
                DataTable dt = new DataTable();
                string sqlStr = "update TRANSACTION_JOB set StatusVPI=1 where TransID= '" + FlagStatusClass.StaticTransID + "'";
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
                    //SendErroMail(sqlStr, ex.ToString(), strConn);
                }

            }

        }

    }
}