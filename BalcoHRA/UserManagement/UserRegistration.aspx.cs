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
    public partial class UserRegistration : System.Web.UI.Page
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
               
                pnlEntry.Visible = false;
                PnlView.Visible = true;
                Load_Grid_Data();
            }
        }

        public void Load_Grid_Data()
        {
            DataTable dt = cn.Get_User_UserList();
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
      
        public void Bind_Role()
        {
            DataTable dt = new DataTable();

            dt = Cc.DropDownlist_UserRole();

            try
            {
                chklistrole.DataSource = dt;
                chklistrole.DataBind();
                chklistrole.DataTextField = "ROLENAME";
                chklistrole.DataValueField = "ROLEID";
                chklistrole.DataBind();
             
            }
            catch
            {
            }
        }



        protected void ddlusertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlusertype.SelectedIndex==1)
            {
                txtpassword.Text = "";
                txtpassword.ReadOnly = true;
               
            }
            else
            {
                txtpassword.ReadOnly = false;
                txtpassword.Text = "";
                
            }



            ddlusertype.Focus();

        }

        protected void txtempid_TextChanged(object sender, EventArgs e)
        {
            if (txtempid.Text == "")
            {
                txtempname.Text = "";
                txtemail.Text = "";
                txtmob.Text = "";

            }
            GetEmployeeDetails_ADID();
            if (txtempname.Text == "")
            {
                GetEmployeeDetails_Kiosk();
            }
            txtempid.Focus();

        }

        public void GetEmployeeDetails_ADID()
        {
            try
            {
                txtempname.Text = "";
                txtemail.Text = "";
                txtmob.Text = "";

                string connection = ConfigurationManager.ConnectionStrings["ADConnection"].ToString();
                DirectorySearcher dssearch = new DirectorySearcher(connection);
                dssearch.Filter = "(sAMAccountName=" + txtempid.Text + ")";
                SearchResult sresult = dssearch.FindOne();
                DirectoryEntry dsresult = sresult.GetDirectoryEntry();
                txtempname.Text = dsresult.Properties["displayName"][0].ToString();
                txtemail.Text = dsresult.Properties["mail"][0].ToString();
                txtmob.Text = dsresult.Properties["telephoneNumber"][0].ToString();
            }
            catch (Exception ex)
            {
                return;
            }
        }


        public void GetEmployeeDetails_Kiosk()
        {

            DataTable dt =  cn.User_Get_Kiosk_Details(txtempid.Text);
            if(dt.Rows.Count-1>=0)
            {
                txtempname.Text = "";
                txtemail.Text = "";
                txtmob.Text = "";

                txtempname.Text = dt.Rows[0]["Employee_Name"].ToString();
                txtemail.Text = dt.Rows[0]["Email_ID_Official"].ToString();
                txtmob.Text = dt.Rows[0]["Mobile_Number_Personnel"].ToString();
            }
            else
            {
                txtempname.Text = "";
                txtemail.Text = "";
                txtmob.Text = "";
            }
        }
        public void ClearData()
        {


            txtempid.Text = "";
            txtempname.Text = "";
            txtemail.Text = "";
            txtmob.Text = "";
            ddlusertype.SelectedIndex = 0;
            ddlusertype.Focus();

            lbltransid.Text = "";

            Bind_Role();
          
            btnsave.Visible = true;
            btnupdate.Visible = false;

        }
        protected void lnkbtnaddnew_Click(object sender, EventArgs e)
        {
            ClearData();
           
            
           
            pnlEntry.Visible = true;
            PnlView.Visible = false;
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Load_Grid_Data();
            
            PnlView.Visible = true;
            pnlEntry.Visible = false;
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (ddlusertype.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Select User Type ','warning');", true);
                ddlusertype.Focus();
            }
            else if (txtempid.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter Employee Id ','warning');", true);
                txtempid.Focus();
            }
            else if (txtempname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter Employee Name','warning');", true);
                txtempname.Focus();
            }
            
            else if (ddlusertype.SelectedIndex==2 && txtpassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter Password ','warning');", true);
                txtpassword.Focus();
            }

            

            else
            {

                String Roleid = "";
                String DeptId = "";
                for (int i = 0; i <= chklistrole.Items.Count - 1; i++)
                {
                    if (chklistrole.Items[i].Selected==true)
                    {
                        if (Roleid == "")
                        {
                            Roleid = chklistrole.Items[i].Value.ToString();
                        }
                        else
                        {
                            Roleid += "," + chklistrole.Items[i].Value.ToString();
                        }
                    }
                }

                if(Roleid=="")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Select Role ','warning');", true);
                    chklistrole.Focus();
                    return;
                }


                //for (int i = 0; i <= chklistdept.Items.Count - 1; i++)
                //{
                //    if (chklistdept.Items[i].Selected == true)
                //    {
                //        if (DeptId == "")
                //        {
                //            DeptId = chklistdept.Items[i].Text.ToString();
                //        }
                //        else
                //        {
                //            DeptId += "," + chklistdept.Items[i].Text.ToString();
                //        }
                //    }
                //}

                //if (DeptId == "")
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Select Department ','warning');", true);
                //    chklistdept.Focus();
                //    return;
                //}

                Label lblUserid = (Label)Page.Master.FindControl("lbluserid");

                String Result = cn.User_Regd_Save(txtempid.Text,txtempname.Text,txtmob.Text,txtemail.Text,txtempid.Text,txtpassword.Text, Roleid, DeptId, ddlusertype.SelectedItem.Text,lblUserid.Text);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Result + "','success');", true);
                ClearData();
                
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (ddlusertype.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Select User Type ','warning');", true);
                ddlusertype.Focus();
            }
            else if (txtempid.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter Employee Id ','warning');", true);
                txtempid.Focus();
            }
            else if (txtempname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter Employee Name','warning');", true);
                txtempname.Focus();
            }

            else if (ddlusertype.SelectedIndex == 2 && txtpassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Enter Password ','warning');", true);
                txtpassword.Focus();
            }
            
            else
            {
                String Roleid = "";
                string DeptId = "";
                for (int i = 0; i <= chklistrole.Items.Count - 1; i++)
                {
                    if (chklistrole.Items[i].Selected==true)
                    {
                        if (Roleid == "")
                        {
                            Roleid = chklistrole.Items[i].Value.ToString();
                        }
                        else
                        {
                            Roleid += "," + chklistrole.Items[i].Value.ToString();
                        }
                    }
                }

                if (Roleid == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Select Role ','warning');", true);
                    chklistrole.Focus();
                    return;
                }




                //for (int i = 0; i <= chklistdept.Items.Count - 1; i++)
                //{
                //    if (chklistdept.Items[i].Selected == true)
                //    {
                //        if (DeptId == "")
                //        {
                //            DeptId = chklistdept.Items[i].Text.ToString();
                //        }
                //        else
                //        {
                //            DeptId += "," + chklistdept.Items[i].Text.ToString();
                //        }
                //    }
                //}

                //if (DeptId == "")
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Please Select Department ','warning');", true);
                //    chklistdept.Focus();
                //    return;
                //}


                Label lblUserid = (Label)Page.Master.FindControl("lbluserid");

                String Result = cn.User_Regd_Update(lbltransid.Text,txtempid.Text, txtempname.Text, txtmob.Text, txtemail.Text, txtempid.Text, txtpassword.Text, Roleid, DeptId, ddlusertype.SelectedItem.Text,lblUserid.Text);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Result + "','success');", true);
                ClearData();

            }
        }

        protected void lnkbtnedit_Click(object sender, EventArgs e)
        {
            ClearData();
            Bind_Role();
           
          

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            lbltransid.Text = (item.FindControl("lblID") as Label).Text;
            DataTable dt = cn.User_Regd_View(lbltransid.Text);

            ddlusertype.SelectedValue = ddlusertype.Items.FindByText(dt.Rows[0]["USERTYPE"].ToString()).Value;
           
            txtempid.Text = dt.Rows[0]["EMPID"].ToString();
            txtempname.Text = dt.Rows[0]["USERNAME"].ToString();
            txtmob.Text = dt.Rows[0]["MOBILENO"].ToString();
            txtemail.Text = dt.Rows[0]["EMAILID"].ToString();
            

            string str_split = dt.Rows[0]["ROLEID"].ToString();
            string[] qual = str_split.Split(',');
            foreach (string sub_str in qual)
            {
                for (int i = 0; i <= chklistrole.Items.Count - 1; i++)
                {
                    if (sub_str == chklistrole.Items[i].Value)
                    {
                        chklistrole.Items[i].Selected = true;
                    }
                }
            }


            //string str_splitdept = dt.Rows[0]["USERLOCATION"].ToString();
            //string[] qualdept = str_splitdept.Split(',');
            //foreach (string sub_str in qualdept)
            //{
            //    for (int i = 0; i <= chklistdept.Items.Count - 1; i++)
            //    {
            //        if (sub_str == chklistdept.Items[i].Text)
            //        {
            //            chklistdept.Items[i].Selected = true;
            //        }
            //    }
            //}


            pnlEntry.Visible = true;
            PnlView.Visible = false;
            ddlusertype.Focus();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }

        protected void lnkbtndelete_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string ID = (item.FindControl("lblID") as Label).Text;

            String Result = cn.User_Regd_Delete(ID);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','" + Result + "','success');", true);
            Load_Grid_Data();
        }

       
       
    }
}