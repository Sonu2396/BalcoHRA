using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using BalcoHRA.Business_Layer.Login_Menu;


namespace BalcoHRA.UserManagement
{
    public partial class UserProfile1 : System.Web.UI.Page
    {
      
        public string[] Labels { get; set; }

        public double[] Data1 { get; set; }

        BL_Login cn = new BL_Login();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {



                string userid = Request.QueryString["Loginid"];
                lbluserid.Text = userid;
                DataTable dt = cn.Get_User_Information(lbluserid.Text);
                try
                {

                    if (dt.Rows.Count > 0)
                    {

                        lblusername.Text = dt.Rows[0]["username"].ToString();
                        lbluserid.Text = dt.Rows[0]["loginid"].ToString();
                        lblrole.Text = dt.Rows[0]["ROLENAME"].ToString();
                        lblemail.Text = dt.Rows[0]["EMAILID"].ToString();
                        lblmobile.Text = dt.Rows[0]["MOBILENO"].ToString();

                        

                        imageprofile.ImageUrl = "~/img/No_Image_Available.jpg";


                    }


                    DataTable dt1 = cn.Get_User_Login_10_Record(lbluserid.Text);

                    try
                    {
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                    }
                    catch { }



                }
                catch
                {

                }

              ShowData_Chart(lbluserid.Text);



            }
        }

        protected void btnshowmore_Click(object sender, EventArgs e)
        {
            DataTable dt1 = cn.Get_User_Login_All_Record(lbluserid.Text);

            try
            {
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            }
            catch { }
            btnshowmore.Visible = false;
           bntshowless.Visible = true;
            ShowData_Chart(lbluserid.Text);
        }

        protected void bntshowless_Click(object sender, EventArgs e)
        {
            DataTable dt1 = cn.Get_User_Login_10_Record(lbluserid.Text);

            try
            {
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            }
            catch { }
            btnshowmore.Visible = true;
            bntshowless.Visible = false;
            ShowData_Chart(lbluserid.Text);
        }

        private void ShowData_Chart(string Userid)
        {

            DataTable dt = cn.Get_User_Login_History(Userid);
            StringBuilder strLabel = new StringBuilder();
            List<string> listLabel = new List<string>();

            StringBuilder strTapping = new StringBuilder();
            List<double> listTapping = new List<double>();
           

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listLabel.Add(dt.Rows[i]["LogIndate"].ToString());
                listTapping.Add(double.Parse(dt.Rows[i]["NoofLogin"].ToString()));
               

            }


            Labels = listLabel.ToArray();
            Data1 = listTapping.ToArray();
           

        }







    }
}