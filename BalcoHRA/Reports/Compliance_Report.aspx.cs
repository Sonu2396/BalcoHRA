using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalcoHRA.Business_Layer.UserMgt;
using BalcoHRA.Business_Layer;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace BalcoHRA.Reports
{
    public partial class Compliance_Report : System.Web.UI.Page
    {
        BL_Report cn = new BL_Report();
        BL_AUDIT cnn = new BL_AUDIT();
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

                ClearData();

            }
        }

        public void ClearData()
        {
            txtFromDate.Focus();

            pnlreport.Visible = false;

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {


            //string fromDate = txtFromDate.ToString();
            //string toDate = txtToDate.ToString();

            string fromDate = Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd");
            string toDate = Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

            DataTable dt = cn.Bind_Compliance_Report(fromDate, toDate);

            GridView1.DataSource = dt;
            GridView1.DataBind();

            pnlreport.Visible = true;

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=HRA_Daywise Report " + txtFromDate.Text + "to " + txtToDate.Text + ".xls");
            Response.ContentType = "application/excel";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            pnlreport.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

    }
    }