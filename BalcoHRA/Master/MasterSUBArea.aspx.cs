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
namespace BalcoHRA.Master
{
    public partial class MasterArea : System.Web.UI.Page
    {
        BL_SUBArea cn = new BL_SUBArea();
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
            DataTable dt = cn.Get_AreaList();
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
        public void ClearData()
        {


            txtname.Text = "";

            lbltransid.Text = "";

            txtname.Focus();
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
            if (txtname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter  Name ','warning');", true);
                txtname.Focus();
            }
            else
            {

                Label lblUserid = (Label)Page.Master.FindControl("lbluserid");


                String Result = cn.Area_Save(txtname.Text, lblUserid.Text, "Save");

                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Result + "','success');", true);
                ClearData();

            }
        }

        protected void lnkbtnedit_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            lbltransid.Text = (item.FindControl("lblID") as Label).Text;
            txtname.Text = (item.FindControl("lblname") as Label).Text;

            pnlEntry.Visible = true;
            PnlView.Visible = false;
            txtname.Focus();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }

        protected void lnkbtndelete_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string ID = (item.FindControl("lblID") as Label).Text;
            Label lblUserid = (Label)Page.Master.FindControl("lbluserid");

            String Result = cn.Area_Delete(ID, lblUserid.Text, "Delete");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Result + "','success');", true);
            Load_Grid_Data();

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter  Name ','warning');", true);
                txtname.Focus();
            }
            else
            {
                Label lblUserid = (Label)Page.Master.FindControl("lbluserid");

                String Result = cn.Area_Update(lbltransid.Text, txtname.Text, lblUserid.Text, "Update");


                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Result + "','success');", true);

                ClearData();
                Load_Grid_Data();
                PnlView.Visible = true;
                pnlEntry.Visible = false;
            }
        }

    }
}