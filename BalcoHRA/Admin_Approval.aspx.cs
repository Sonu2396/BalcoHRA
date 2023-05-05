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
    public partial class Admin_Approval : System.Web.UI.Page
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

                ClearData();
 
            }
        }

       

        public void ClearData()
        {

            lbltransid.Text = "";
            DataTable dt = cn.Bind_JOB();

            GridView1.DataSource = dt;
            GridView1.DataBind();

            //lblAudname.Text = dt.Rows[0]["Auditor"].ToString();


        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Button btnApprove = sender as Button;
            GridViewRow gvrow = (GridViewRow)btnApprove.NamingContainer;
            String trid = gvrow.Cells[0].Text;

            Label lblUserid = (Label)Page.Master.FindControl("lbluserid");

            DropDownList ddList = (DropDownList)gvrow.FindControl("ddlAuditor");

            String Result = cn.Data_Approve(trid, ddList.SelectedItem.Text,  lblUserid.Text, "1", "Approval");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Result + "','success');", true);
            ClearData();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            Button btnApprove = sender as Button;
            GridViewRow gvrow = (GridViewRow)btnApprove.NamingContainer;
            String trid = gvrow.Cells[0].Text;

            Label lblUserid = (Label)Page.Master.FindControl("lbluserid");

            DropDownList ddList = (DropDownList)gvrow.FindControl("ddlAuditor");

            String Result = cn.Data_Approve(trid, ddList.SelectedItem.Text, lblUserid.Text, "2", "Approval");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Result + "','success');", true);
            ClearData();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                //{
                    DropDownList ddList = (DropDownList)e.Row.FindControl("ddlAuditor");
                    Label lblAudname = (Label)e.Row.FindControl("lblAudname");
                    //------------------------------
                    DataTable dt = new DataTable();
                    dt = cn.DropDownlist_Auditor();
                    try
                    {
                        ddList.DataSource = dt;
                        ddList.DataBind();
                        ddList.DataTextField = "USERNAME";
                        ddList.DataValueField = "LOGINID";
                        ddList.DataBind();
                        ddList.Items.Insert(0, "Select");
                    ddList.SelectedValue = ddList.Items.FindByText(lblAudname.Text).Value;
                    
                    }
                    catch
                    {
                        ddList.Items.Insert(0, "Select");
                    

                    }
                
                }
            //}
        }
    }
}