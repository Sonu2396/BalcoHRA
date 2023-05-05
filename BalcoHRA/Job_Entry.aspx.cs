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

namespace BalcoHRA
{
    public partial class Job_Entry : System.Web.UI.Page
    {
        BL_JOB cn = new BL_JOB();
        BL_Common_Controls Cc = new BL_Common_Controls();
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

        public void bind_SBU()
        {
            DataTable dt = new DataTable();

            dt = cn.DropDownlist_SBU();

            try
            {
                ddlSBU.DataSource = dt;
                ddlSBU.DataBind();
                ddlSBU.DataTextField = "SBUName";
                ddlSBU.DataValueField = "SBUId";
                ddlSBU.DataBind();
                ddlSBU.Items.Insert(0, "Select");
            }
            catch
            {
                ddlSBU.Items.Insert(0, "Select");
            }
        }

        public void bind_Area(string SBUName)
        {
            DataTable dt = new DataTable();

            dt = cn.DropDownlist_AREA(SBUName);

            try
            {
                ddlArea.DataSource = dt;
                ddlArea.DataBind();
                ddlArea.DataTextField = "DepartmentName";
                ddlArea.DataValueField = "DepartmentId";
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, "Select");
            }
            catch
            {
                ddlArea.Items.Insert(0, "Select");
            }
        }

        public void bind_SUBArea()
        {
            DataTable dt = new DataTable();

            dt = cn.DropDownlist_SUBArea();

            try
            {
                ddlSUBArea.DataSource = dt;
                ddlSUBArea.DataBind();
                ddlSUBArea.DataTextField = "AreaName";
                ddlSUBArea.DataValueField = "AreaId";
                ddlSUBArea.DataBind();
                ddlSUBArea.Items.Insert(0, "Select");
            }
            catch
            {
                ddlSUBArea.Items.Insert(0, "Select");
            }
        }

        public void bind_Auditor()
        {
            DataTable dt = new DataTable();

            dt = cn.DropDownlist_Auditor();

            try
            {
                ddlAuditor.DataSource = dt;
                ddlAuditor.DataBind();
                ddlAuditor.DataTextField = "USERNAME";
                ddlAuditor.DataValueField = "LOGINID";
                ddlAuditor.DataBind();
                ddlAuditor.Items.Insert(0, "Select");
            }
            catch
            {
                ddlAuditor.Items.Insert(0, "Select");
            }
        }


        //public void bind_Executor()
        //{
        //    DataTable dt = new DataTable();

        //    dt = cn.DropDownlist_Executor();

        //    try
        //    {
        //        ddlExecutor.DataValueField = "LOGINID";
        //        ddlExecutor.DataTextField = "USERNAME";
        //        ddlExecutor.DataBind();
        //        ddlExecutor.DataSource = dt;
        //        ddlExecutor.Items.Insert(0, "Select");
        //        ddlExecutor.DataBind();
        //    }
        //    catch
        //    {
        //        ddlExecutor.Items.Insert(0, "Select");
        //    }
        //}
        public void ClearData()
        {

            lbltransid.Text = "";

            TextBoxExecPhone.Text = "";
            TextBoxJobDes.Text = "";
            TextBoxRemarks.Text = "";
            TextBoxRescuer.Text = "";
            chkjobtype.ClearSelection();

            bind_SBU();
            bind_Area(ddlSBU.SelectedItem.Text);
            //bind_Executor();
            bind_SUBArea();
            bind_Auditor();
        }

        protected void btnsave_Click(object sender, EventArgs e)
            {

            string Jobtype = "";

          


            for(int i =0;i<=chkjobtype.Items.Count-1;i++)
             {
               if( chkjobtype.Items[i].Selected==true)
                {
                    if(Jobtype=="")
                        Jobtype = chkjobtype.Items[i].Text;
                    else
                    Jobtype = Jobtype + ";" + chkjobtype.Items[i].Text;
                    
                }

            }

            if (Jobtype == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Check Job Type ','warning');", true);
                chkjobtype.Focus();
            }
            else if(TextBoxTime.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter Date and Time of Job ','warning');", true);
                TextBoxTime.Focus();
            }
            else if (TextBoxJobDes.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter Job Description ','warning');", true);
                TextBoxJobDes.Focus();
            }
            else if (TextBoxExecutor.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter Executor ','warning');", true);
                TextBoxJobDes.Focus();
            }
            else
            {

                Label lblUserid = (Label)Page.Master.FindControl("lbluserid");

                String JobDateTime = DateTime.Parse(TextBoxTime.Text).ToString();

                String Result = cn.Data_Save(ddlSBU.SelectedItem.Text, ddlArea.SelectedItem.Text, Jobtype, TextBoxExecutor.Text, TextBoxExecPhone.Text, ddlSUBArea.SelectedItem.Text, JobDateTime, TextBoxJobDes.Text, ddlAuditor.SelectedItem.Text, ddlAuditor.SelectedValue, TextBoxRescuer.Text, TextBoxRemarks.Text, lblUserid.Text, "0", "Save");

                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Result + "','success');", true);
                ClearData();
            }
        }

            protected void btnupdate_Click(object sender, EventArgs e)
            {

            }

            protected void btnreset_Click(object sender, EventArgs e)
            {
            ClearData();
            }

          
        


            protected void ddlSBU_SelectedIndexChanged(object sender, EventArgs e)
            {
            bind_Area(ddlSBU.SelectedItem.Text);

          
            ddlArea.Focus();
        }

    }
 }
