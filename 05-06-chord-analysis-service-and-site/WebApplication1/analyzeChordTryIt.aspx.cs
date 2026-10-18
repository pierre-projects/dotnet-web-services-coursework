using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.MusicKeyRef;

namespace WebApplication1
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAnalyze_Click(object sender, EventArgs e)
        {
            string notes = txtNotes.Text.Trim();

            if (string.IsNullOrWhiteSpace(notes))
            {
                lblResult.Text = "Please enter one or more note names.";
                return;
            }

            try
            {
                var client = new MusicKeyServiceSoapClient();
                string output = client.AnalyzeChord(notes);


                lblResult.Text = output.Replace("\n", "<br/>");
            }
            catch (Exception ex)
            {
                lblResult.Text = "Error calling service: " + ex.Message;
            }
        }
    }
}