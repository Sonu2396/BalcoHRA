using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalcoHRA.Business_Layer.Login_Menu;

namespace BalcoHRA.UserManagement
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        BL_Login cn = new BL_Login();
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
                txtuserid.Text = userid;
                ClearData();

            }

        }
        public void ClearData()
        {
            txtpassword.Text = "";
            txtconfirmpwd.Text = "";
            txtpassword.Focus();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter Password ','warning');", true);
                txtpassword.Focus();
                return;
            }
            else if (txtconfirmpwd.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter Confirm Password ','warning');", true);
                txtconfirmpwd.Focus();
                return;
            }
            else if (txtconfirmpwd.Text != txtpassword.Text)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Password Missmatch ','warning');", true);
                txtconfirmpwd.Focus();
                return;
            }
            SaveData();
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        public void SaveData()
        {
            String Result = cn.User_ChangePassword( txtuserid.Text, txtconfirmpwd.Text);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Result + "','success');", true);
            ClearData();
        }
    }
}