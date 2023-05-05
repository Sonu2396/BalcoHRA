using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.DirectoryServices;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using BalcoHRA.Business_Layer.Login_Menu;
using BalcoHRA.Business_Layer;


namespace BalcoHRA
{
    public partial class Default : System.Web.UI.Page
    {
        private string _path;
        private string _filterAttribute;
        public char MyDomain { get; private set; }
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);

        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        BL_Login cn = new BL_Login();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtuserid.Attributes.Add("autocomplete", "off");
                                
                ClearData();
               
            }


        }


        public void ClearData()
        {

            txtpwd.Text = "";
            txtuserid.Text = "";
            txtuserid.Focus();
            formlogin.DefaultButton = btnlogin.UniqueID;
            
        }
        private DirectoryEntry GetDirectoryObject()
        {
            DirectoryEntry oDE;
            oDE = new DirectoryEntry("LDAP://balco1.vedantaresource.local", txtuserid.Text.Trim(), txtpwd.Text.Trim(), AuthenticationTypes.Secure);
            return oDE;
        }
        private DirectoryEntry GetUser(string UserName)
        {
            DirectoryEntry de = GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;
            deSearch.Filter = "(&(objectClass=user)(SAMAccountName=" + UserName + "))";
            deSearch.SearchScope = System.DirectoryServices.SearchScope.Subtree;
            SearchResult results = deSearch.FindOne();
            if (!(results == null))
            {
                de = new DirectoryEntry(results.Path, "administrator", "password", AuthenticationTypes.Secure);
                return de;
            }
            else
            {
                return null;
            }
        }
        void logon(string domain, string username, string password)
        {
            string domainAndUsername = "LDAP://balco1.vedantaresource.local" + @"\" + username;


            LdapAuthentication adAuth = new LdapAuthentication(domainAndUsername);
            try
            {
                if (true == adAuth.IsAuthenticated(domain, username, password))
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

       



       

        public bool IsAuthenticated(string domain,String username, String pwd)
        {
            
            _path = "LDAP://" + domain;
            String domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);

            try
            {
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();

                if (null == result)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {

         

            CheckLogin();
        }

        public void CheckLogin()
        {
            DirectoryEntry oDE;
            oDE = new DirectoryEntry("LDAP://balco1.vedantaresource.local", txtuserid.Text.Trim(), txtpwd.Text.Trim(), AuthenticationTypes.Secure);
            bool exists = false;
            try
            {
                var tmp = oDE.Guid;
                exists = true;
            }
            catch (Exception ex)
            {
                exists = false;
            }


            if (exists)
            {
                try
                {

                    DataTable dt = cn.Check_AppPermission(txtuserid.Text,"");
                    if (dt.Rows.Count > 0)
                    {

                        Session["Userid"] = dt.Rows[0]["LOGINID"].ToString();
                        Session["Username"] = dt.Rows[0]["USERNAME"].ToString();
                        Session["Location"] = dt.Rows[0]["USERLOCATION"].ToString();
                        Response.Redirect("Home.aspx");


                    }
                    else
                    {


                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Sorry, U R not Authorised to Access','warning');", true);
                    }


                }
                catch (Exception ex)
                {


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Error On LogIn','warning');", true);
                }
            }
            else
            {
                try
                {

                    DataTable dt = cn.Validate_Login(txtuserid.Text, txtpwd.Text, "");
                    if (dt.Rows.Count > 0)
                    {


                        DataTable dt1 = cn.Check_AppPermission(txtuserid.Text, "");

                        if (dt1.Rows.Count > 0)
                        {
                            Session["Userid"] = dt1.Rows[0]["LOGINID"].ToString();
                            Session["Username"] = dt1.Rows[0]["USERNAME"].ToString();
                            Session["Location"] = dt1.Rows[0]["USERLOCATION"].ToString();

                            Response.Redirect("Home.aspx");


                        }
                        else
                        {


                            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Sorry, U R not Authorised to Access','warning');", true);
                        }


                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Invalid Login','warning');", true);
                    }


                }
                catch (Exception ex)
                {


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "successalert('Message','Erro on Login','error');", true);


                }
            }

        }


    }

    internal class LdapAuthentication
    {
        private string domainAndUsername;

        public LdapAuthentication(string domainAndUsername)
        {
            this.domainAndUsername = domainAndUsername;
        }

        internal bool IsAuthenticated(string domain, string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}