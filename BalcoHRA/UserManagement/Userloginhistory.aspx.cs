using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalcoHRA.Business_Layer.Login_Menu;
using BalcoHRA.Business_Layer;
using System.IO;

namespace BalcoHRA.UserManagement
{
    public partial class Userloginhistory : System.Web.UI.Page
    {
        BL_Login cn = new BL_Login();
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
                DataTable dt = CCM.Get_Page_Authentication(lblUserid, Path.GetFileName(Request.Path));
                if (dt.Rows.Count < 1)
                {
                    Response.Redirect("~/Error401Page.aspx");
                    return;
                }

                txtdate.Text = System.DateTime.Today.ToString("yyyy-MM-dd");
                Load_Grid_Data();
            }
        }

        public void Load_Grid_Data()
        {
            DataTable dt = cn.Get_User_Timesof_Login(txtdate.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void txtdate_TextChanged(object sender, EventArgs e)
        {
            Load_Grid_Data();
        }
    }
}