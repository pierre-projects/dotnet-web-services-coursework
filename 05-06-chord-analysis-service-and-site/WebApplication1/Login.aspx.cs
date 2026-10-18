using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Xml;
using System.IO;

namespace WebApplication1
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = "";

                // If the user is already logged in, send them to the right area
                if (Context.User != null && Context.User.Identity.IsAuthenticated)
                {
                    string role = null;
                    if (Session["UserRole"] != null)
                    {
                        role = Session["UserRole"].ToString();
                    }

                    if (role != null && role.ToLower() == "staff")
                    {
                        Response.Redirect("~/Staff/Staff.aspx");
                        return;
                    }
                    else if (role != null && role.ToLower() == "member")
                    {
                        Response.Redirect("~/Member/Member.aspx");
                        return;
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
                        return;
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string username = txtUser.Text.Trim();
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                lblError.Text = "Please enter both username and password.";
                return;
            }

            // Use PassBroker so this matches how passwords are stored
            string hashed = PassBroker.HashPassword(password);

            // try Staff.xml
            bool isStaff = AuthenticateFromXml(
                "~/App_Data/Staff.xml",
                "staffList",
                "staff",
                username,
                hashed
            );

            if (isStaff)
            {
                SignInUser(username, "Staff", chkRemember.Checked);
                return;
            }

            // Then try Members.xml
            bool isMember = AuthenticateFromXml(
                "~/App_Data/Members.xml",
                "members",
                "member",
                username,
                hashed
            );

            if (isMember)
            {
                SignInUser(username, "Member", chkRemember.Checked);
                return;
            }

            // If we reach here, login failed
            lblError.Text = "Invalid username or password.";
        }

        private void SignInUser(string username, string role, bool rememberMe)
        {
            Session["UserRole"] = role;
            Session["UserName"] = username;

            // Forms authentication ticket (ReturnUrl handled automatically)
            FormsAuthentication.RedirectFromLoginPage(username, rememberMe);
        }

        private bool AuthenticateFromXml(
            string relativePath,
            string rootElementName,
            string entryElementName,
            string username,
            string hashedPassword)
        {
            string filePath = Server.MapPath(relativePath);
            if (!File.Exists(filePath))
            {
                return false;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlElement root = doc.DocumentElement;

            if (root == null || root.Name != rootElementName)
            {
                return false;
            }

            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name != entryElementName)
                {
                    continue;
                }

                XmlNode nameNode = node["name"];
                XmlNode pwdNode = node["pwd"];

                if (nameNode == null || pwdNode == null)
                {
                    continue;
                }

                string xmlUser = nameNode.InnerText;
                string xmlPwd = pwdNode.InnerText;

                // Username is case-insensitive, password (hash) is case-sensitive
                if (xmlUser != null &&
                    xmlUser.ToLower() == username.ToLower() &&
                    xmlPwd == hashedPassword)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
