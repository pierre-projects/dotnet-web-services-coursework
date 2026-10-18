using System;
using System.Web;
using System.Web.UI;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Read application counters set in Global.asax
                object totalSessions = Application["TotalSessionCount"];
                object totalRequests = Application["TotalRequestCount"];

                string sessionCountText = totalSessions != null ? totalSessions.ToString() : "0";
                string requestCountText = totalRequests != null ? totalRequests.ToString() : "0";

                lblGlobalInfo.Text =
                    "Total Sessions Started: " + sessionCountText +
                    "<br />Total Requests Served: " + requestCountText;

                // Show login status at the top of the page
                if (Context.User != null && Context.User.Identity.IsAuthenticated)
                {
                    string role = "(unknown)";
                    string userName = Context.User.Identity.Name;

                    if (Session["UserRole"] != null)
                    {
                        role = Session["UserRole"].ToString();
                    }

                    if (Session["UserName"] != null)
                    {
                        userName = Session["UserName"].ToString();
                    }

                    lblLoginStatus.Text = "Logged in as: " + userName + " (" + role + ")";
                }
                else
                {
                    lblLoginStatus.Text = "You are not logged in.";
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }

        protected void btnMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Member/Member.aspx");
        }

        protected void btnStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Staff/Staff.aspx");
        }
    }
}
