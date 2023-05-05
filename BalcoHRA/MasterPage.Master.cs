using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BalcoHRA.Business_Layer.Login_Menu;
using BalcoHRA.Business_Layer;
using System.ComponentModel;
using BalcoHRA.Business_Layer.PotLine.PotMaintainance;
using System.Timers;
using System.Threading;

namespace BalcoHRA
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        BL_Login cn = new BL_Login();
        BL_Common_Controls cnn = new BL_Common_Controls();
        
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
                string userid = Session["UserId"].ToString();
                
                DataTable dt = cn.Get_User_Information(userid);
                try
                {
                    if (dt.Rows.Count > 0)
                    {

                        lblusername.Text = dt.Rows[0]["username"].ToString();
                        lbluserid.Text = dt.Rows[0]["loginid"].ToString();
                        lblrole.Text = dt.Rows[0]["ROLENAME"].ToString();

                        if (dt.Rows[0]["USERTYPE"].ToString() != "Employee")
                        {
                            btnchangepassword.Visible = true;
                        }
                        btnchangepassword.Visible = true;


                        Image1.ImageUrl = "~/img/No_Image_Available.jpg";
                        BINDMENU(lblrole.Text);

                    }

                }
                catch
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Response.Redirect("~/Default.aspx");
                }
            }         

        }

       public void BINDMENU(string lblrole)
        {
            
            if (lblrole.Contains("User") == true)
            {
                limenuUserMgt.Visible = false;
                limenuMaster.Visible = false;
                liChecklist.Visible = false;
                liPlan.Visible = true;
                liPending.Visible = false;
                PendingAdmin.Visible = false;
                PendingAuditor.Visible = false;
                liReports.Visible = true;
            }
            if (lblrole.Contains("Auditor") == true)
            {
                limenuUserMgt.Visible = false;
                limenuMaster.Visible = false;
                liChecklist.Visible = true;
                liPlan.Visible = false;
                liPending.Visible = true;
                PendingAdmin.Visible = false;
                PendingAuditor.Visible = true;
                liReports.Visible = true;
            }
            if (lblrole.Contains("Balco Admin") == true)
            {
                limenuUserMgt.Visible = false;
                limenuMaster.Visible = false;
                liChecklist.Visible = true;
                liPlan.Visible = true;
                liPending.Visible = true;
                PendingAdmin.Visible = true;
                PendingAuditor.Visible = false;
                liReports.Visible = true;
            }
            if (lblrole.Contains("Admin") == true)
            {
                limenuUserMgt.Visible = true;
                limenuMaster.Visible = true;
                liChecklist.Visible = true;
                liPlan.Visible = true;
                liPending.Visible = true;
                PendingAdmin.Visible = true;
                PendingAuditor.Visible = true;
                liReports.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Not authorized','warning');", true);
            }
        }



      

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            bool rslt = cn.User_Regd_Signout(lbluserid.Text);

            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("~/Default.aspx");
        }

    

       
    }
}