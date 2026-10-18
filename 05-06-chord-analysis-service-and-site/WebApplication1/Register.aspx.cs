using System;
using System.IO;
using System.Web.UI;
using System.Xml;

namespace WebApplication1
{
    public partial class Member_Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";

                // Do not allow already authenticated users to register again
                if (Context.User != null && Context.User.Identity.IsAuthenticated)
                {
                    string role = Session["UserRole"] as string;

                    if (role != null)
                    {
                        string r = role.ToLower();

                        if (r == "member")
                        {
                            Response.Redirect("~/Member/Member.aspx");
                            return;
                        }
                        else if (r == "staff")
                        {
                            Response.Redirect("~/Staff/Staff.aspx");
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
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "";

            string username = txtUser.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirm.Text;
            string email = txtEmail.Text.Trim();

            if (username == "" || password == "")
            {
                lblMessage.Text = "Username and password are required.";
                return;
            }

            if (password != confirm)
            {
                lblMessage.Text = "Passwords do not match.";
                return;
            }

            // Hashing goes through PassBroker
            string hashed = PassBroker.HashPassword(password);

            string filePath = Server.MapPath("~/App_Data/Members.xml");
            XmlDocument doc = new XmlDocument();

            // Create Members.xml if missing
            if (!File.Exists(filePath))
            {
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(dec);

                XmlElement root = doc.CreateElement("members");
                doc.AppendChild(root);

                doc.Save(filePath);
            }

            doc.Load(filePath);
            XmlElement rootElement = doc.DocumentElement;

            if (rootElement == null || rootElement.Name.ToLower() != "members")
            {
                lblMessage.Text = "Members.xml structure is invalid.";
                return;
            }

            // Check for duplicate username
            foreach (XmlNode node in rootElement.ChildNodes)
            {
                XmlNode nameNode = node["name"];
                if (nameNode != null && nameNode.InnerText.ToLower() == username.ToLower())
                {
                    lblMessage.Text = "That username already exists. Try another.";
                    return;
                }
            }

            // Create new member entry
            XmlElement memberElem = doc.CreateElement("member");

            XmlElement nameElem = doc.CreateElement("name");
            nameElem.InnerText = username;
            memberElem.AppendChild(nameElem);

            XmlElement pwdElem = doc.CreateElement("pwd");
            pwdElem.InnerText = hashed;
            memberElem.AppendChild(pwdElem);

            if (email != "")
            {
                XmlElement emailElem = doc.CreateElement("email");
                emailElem.InnerText = email;
                memberElem.AppendChild(emailElem);
            }

            rootElement.AppendChild(memberElem);
            doc.Save(filePath);

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Member Created! You can now log in.";

            // Clear some fields
            txtPassword.Text = "";
            txtConfirm.Text = "";
        }

        protected void btnGoToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}
