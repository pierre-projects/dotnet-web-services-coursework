using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Xml;

namespace WebApplication1
{
    public partial class Staff_Staff : Page
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

                // Must be staff
                string role = Session["UserRole"] as string;
                if (role == null || role.ToLower() != "staff")
                {
                    Response.Redirect("~/Default.aspx");
                    return;
                }

                string userName = Context.User.Identity.Name;
                if (Session["UserName"] != null)
                {
                    userName = Session["UserName"].ToString();
                }

                lblWelcome.Text = "Hello " + userName + ", this is the staff area.";

                // Show application counters from Global.asax
                object totalSessions = Application["TotalSessionCount"];
                object totalRequests = Application["TotalRequestCount"];

                string sessionText = totalSessions != null ? totalSessions.ToString() : "0";
                string requestText = totalRequests != null ? totalRequests.ToString() : "0";

                lblStats.Text =
                    "Total Sessions Started: " + sessionText +
                    "<br />Total Requests Served: " + requestText;

                LoadMembersIntoGrid();
            }
        }

        private void LoadMembersIntoGrid()
        {
            string filePath = Server.MapPath("~/App_Data/Members.xml");
            if (!File.Exists(filePath))
            {
                gvMembers.DataSource = null;
                gvMembers.DataBind();
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Email");

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlElement root = doc.DocumentElement;
            if (root == null || root.Name.ToLower() != "members")
            {
                gvMembers.DataSource = null;
                gvMembers.DataBind();
                return;
            }

            foreach (XmlNode node in root.ChildNodes)
            {
                XmlNode nameNode = node["name"];
                XmlNode emailNode = node["email"];

                if (nameNode == null)
                {
                    continue;
                }

                DataRow row = table.NewRow();
                row["Name"] = nameNode.InnerText;
                row["Email"] = emailNode != null ? emailNode.InnerText : "";
                table.Rows.Add(row);
            }

            gvMembers.DataSource = table;
            gvMembers.DataBind();
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            LoadMembersIntoGrid();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
}
