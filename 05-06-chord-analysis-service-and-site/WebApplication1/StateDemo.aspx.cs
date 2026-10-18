using System;
using System.Web;
using System.Web.UI;

namespace WebApplication1
{
    public partial class StateDemo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblSessionInfo.Text = "";
                lblCookieInfo.Text = "";

                // Show cookie info if it already exists
                HttpCookie c = Request.Cookies["UserProfile"];
                if (c != null && !string.IsNullOrEmpty(c["Name"]))
                {
                    string name = c["Name"];
                    string email = c["Email"];
                    string lastPage = c["LastVisitedPage"];

                    lblCookieInfo.Text = "Cookie found for " + name +
                                         " (" + email + "), last page: " +
                                         lastPage + ".";
                }
            }
        }

        protected void btnSaveSession_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string lastPage = txtLastPage.Text;

            // Use separate demo session keys so we don't touch login values
            Session["DemoName"] = name;
            Session["DemoEmail"] = email;
            Session["DemoLastPage"] = lastPage;

            lblSessionInfo.Text = "Saved in Session (demo): " + name +
                                  " (" + email + "), last page: " +
                                  lastPage + ".";
        }

        protected void btnSaveCookie_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string lastPage = txtLastPage.Text;

            HttpCookie c = new HttpCookie("UserProfile");
            c["Name"] = name;
            c["Email"] = email;
            c["LastVisitedPage"] = lastPage;
            c.Expires = DateTime.Now.AddMonths(6);

            Response.Cookies.Add(c);

            lblCookieInfo.Text = "Cookie saved.";
        }

        protected void btnLoadState_Click(object sender, EventArgs e)
        {
            // Read demo session values
            string name = Session["DemoName"] as string;
            string email = Session["DemoEmail"] as string;
            string lastPage = Session["DemoLastPage"] as string;

            if (!string.IsNullOrEmpty(name))
            {
                lblSessionInfo.Text = "From Session (demo): " + name +
                                      " (" + email + "), last page: " +
                                      lastPage + ".";
            }
            else
            {
                lblSessionInfo.Text = "No demo session data.";
            }

            // Read cookie values
            HttpCookie c = Request.Cookies["UserProfile"];
            if (c != null && !string.IsNullOrEmpty(c["Name"]))
            {
                string cookieName = c["Name"];
                string cookieEmail = c["Email"];
                string cookieLastPage = c["LastVisitedPage"];

                lblCookieInfo.Text = "From Cookie: " + cookieName +
                                     " (" + cookieEmail + "), last page: " +
                                     cookieLastPage + ".";
            }
            else
            {
                lblCookieInfo.Text = "No cookie data.";
            }
        }
    }
}
