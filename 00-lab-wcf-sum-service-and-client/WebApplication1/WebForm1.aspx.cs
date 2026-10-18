using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client sum_client = new ServiceReference1.Service1Client();
            lblResult.Text = sum_client.GetSum(Double.Parse(tb_a.Text), Double.Parse(tb_b.Text)).ToString();
        }
    }
}