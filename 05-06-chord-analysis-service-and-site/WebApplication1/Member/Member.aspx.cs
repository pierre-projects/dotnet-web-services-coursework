using System;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Xml;

namespace WebApplication1
{
    public partial class Member_Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Must be logged in
                if (Context.User == null || !Context.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Login.aspx");
                    return;
                }

                // Must be a member
                string role = Session["UserRole"] as string;
                if (role == null || role.ToLower() != "member")
                {
                    Response.Redirect("~/Default.aspx");
                    return;
                }

                string userName = Session["UserName"] as string;
                if (string.IsNullOrEmpty(userName))
                {
                    userName = Context.User.Identity.Name;
                }

                lblWelcome.Text = "Welcome, " + userName + " (Member).";
            }
        }

        protected void btnLoadProfile_Click(object sender, EventArgs e)
        {
            string userName = Session["UserName"] as string;
            if (string.IsNullOrEmpty(userName))
            {
                userName = Context.User.Identity.Name;
            }

            string filePath = Server.MapPath("~/App_Data/Members.xml");
            if (!File.Exists(filePath))
            {
                lblProfile.Text = "Members.xml not found.";
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlElement root = doc.DocumentElement;
            if (root == null || root.Name.ToLower() != "members")
            {
                lblProfile.Text = "Members.xml structure is invalid.";
                return;
            }

            XmlNode found = null;

            foreach (XmlNode node in root.ChildNodes)
            {
                XmlNode nameNode = node["name"];
                if (nameNode != null && nameNode.InnerText.ToLower() == userName.ToLower())
                {
                    found = node;
                    break;
                }
            }

            if (found == null)
            {
                lblProfile.Text = "Your profile could not be found.";
                return;
            }

            // Optional fields
            string email = "";
            XmlNode emailNode = found["email"];
            if (emailNode != null)
            {
                email = emailNode.InnerText;
            }

            string text = "Profile Info:<br />User: " + userName;
            if (email != "")
            {
                text += "<br />Email: " + email;
            }

            lblProfile.Text = text;
        }

        protected void btnShowState_Click(object sender, EventArgs e)
        {
            // Session info
            string sessionName = Session["UserName"] as string;
            string sessionRole = Session["UserRole"] as string;

            if (!string.IsNullOrEmpty(sessionName))
            {
                lblSessionInfo.Text = "Session: UserName = " + sessionName +", Role = " + (sessionRole ?? "(none)");
            }
            else
            {
                lblSessionInfo.Text = "Session: no user session data.";
            }

            // Cookie info
            HttpCookie cookie = Request.Cookies["UserProfile"];
            if (cookie != null && !string.IsNullOrEmpty(cookie["Name"]))
            {
                string cookieName = cookie["Name"];
                string cookieEmail = cookie["Email"];
                string lastPage = cookie["LastVisitedPage"];

                lblCookieInfo.Text = "Cookie: " + cookieName +" (" + cookieEmail + "), Last Visited Page = " +lastPage;
            }
            else
            {
                lblCookieInfo.Text = "Cookie: no UserProfile cookie found.";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
}
