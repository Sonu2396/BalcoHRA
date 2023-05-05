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
    public partial class ActiveUserList : System.Web.UI.Page
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

               
                Load_Grid_Data();
            }
        }

        public void Load_Grid_Data()
        {
            DataTable dt = cn.Get_ACtive_UserList();
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

      

        protected void btnview_Click(object sender, EventArgs e)
        {
           
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("lbllogiid");
            Response.Redirect("UserProfile1.aspx?Loginid=" + lbl.Text);
         
        }
    }
}