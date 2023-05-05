using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalcoHRA.Business_Layer.Checklist;
using BalcoHRA.Business_Layer;
using System.IO;

namespace BalcoHRA.ChecklistMaster
{
    public partial class MasterVPI : System.Web.UI.Page
    {
        BL_VPI cn = new BL_VPI();

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

                pnlEntry.Visible = false;
                PnlView.Visible = true;
                Load_Grid_Data();
            }
        }
        public void Load_Grid_Data()
        {
            DataTable dt = cn.Get_List();
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
        public void ClearData()
        {


            txtCriticalControl.Text = "";
            txtObjective.Text = "";
            txtPoints.Text = "";

            lbltransid.Text = "";

            txtCriticalControl.Focus();
            btnsave.Visible = true;
            btnupdate.Visible = false;

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            ClearData();
            pnlEntry.Visible = true;
            PnlView.Visible = false;
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Load_Grid_Data();
            System.Threading.Thread.Sleep(100);
            PnlView.Visible = true;
            pnlEntry.Visible = false;

        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (txtCriticalControl.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter  Critical Control ','warning');", true);
                txtCriticalControl.Focus();
            }
            else if (txtObjective.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter  Objective ','warning');", true);
                txtObjective.Focus();
            }
            else if (txtPoints.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter Points ','warning');", true);
                txtPoints.Focus();
            }
            else
            {

                Label lblUserid = (Label)Page.Master.FindControl("lbluserid");


                String Result = cn.Data_Save( txtCriticalControl.Text, txtObjective.Text, txtPoints.Text, lblUserid.Text, "Save");

                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Result + "','success');", true);
                ClearData();

            }
        }

        protected void lnkbtnedit_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            lbltransid.Text = (item.FindControl("lblID") as Label).Text;
            txtCriticalControl.Text = (item.FindControl("lblCriticalControl") as Label).Text;
            txtObjective.Text = (item.FindControl("lblObjective") as Label).Text;
            txtPoints.Text = (item.FindControl("lblPoints") as Label).Text;

            pnlEntry.Visible = true;
            PnlView.Visible = false;
            txtCriticalControl.Focus();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }

        protected void lnkbtndelete_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string ID = (item.FindControl("lblID") as Label).Text;
            Label lblUserid = (Label)Page.Master.FindControl("lbluserid");

            String Result = cn.Data_Delete(ID, lblUserid.Text, "Delete");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Result + "','success');", true);
            Load_Grid_Data();

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtCriticalControl.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter  Critical Control ','warning');", true);
                txtCriticalControl.Focus();
            }
            else if (txtObjective.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter  Objective ','warning');", true);
                txtObjective.Focus();
            }
            else if (txtPoints.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter Points ','warning');", true);
                txtPoints.Focus();
            }
            else
            {
                Label lblUserid = (Label)Page.Master.FindControl("lbluserid");

                String Result = cn.Data_Update(lbltransid.Text, txtCriticalControl.Text, txtObjective.Text, txtPoints.Text, lblUserid.Text, "Update");


                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Result + "','success');", true);

                ClearData();
                Load_Grid_Data();
                PnlView.Visible = true;
                pnlEntry.Visible = false;
            }
        }

    }
}