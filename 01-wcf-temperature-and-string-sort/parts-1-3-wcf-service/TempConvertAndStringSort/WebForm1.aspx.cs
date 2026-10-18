using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TempConvertAndStringSort
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnC2F_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            int celsius = int.Parse(txtC.Text);
            int result = client.c2f(celsius);
            fserver.Text = result.ToString();   
        }

        protected void btnF2C_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            int fahrenheit = int.Parse(txtF.Text);
            int result = client.f2c(fahrenheit);
            cserver.Text = result.ToString();   
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            string numbers = txtNums.Text;         
            string sorted = client.sort(numbers);
            lblSort.Text = sorted;                 
        }

    }
}