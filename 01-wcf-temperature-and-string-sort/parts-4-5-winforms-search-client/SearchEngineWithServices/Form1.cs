using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchEngineWithServices.encryptdecryptservice;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace SearchEngineWithServices
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true; //avoid errors
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {

                //catch trailing white space for ease of debugging
                string url = searchBox.Text.Trim();
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "https://" + url;
                }

                webBrowser1.Navigate(new Uri(url));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            searchBox.Text = webBrowser1.Url.ToString();
        }





        //encryptiondycrption
        private void encryptInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void DecryptionResult_Click(object sender, EventArgs e)
        {

        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            // client
            //  var bob = new SearchEngineWithServices.encryptdecryptservice.ServiceClient();
            var bob = new SearchEngineWithServices.encryptdecryptservice.ServiceClient("BasicHttpsBinding_Encryption");

            string pt = encryptInput.Text;

            string enc = bob.Encrypt(pt);

            EncryptResult.Text = "Encrypted: " + enc;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void decryptInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {

            //client
            var james = new SearchEngineWithServices.encryptdecryptservice.ServiceClient();

            string ct = decryptInput.Text;

            string pt = james.Decrypt(ct);

            DecryptionResult.Text = "Decrypted: " + pt;
        }


        //stock qoute service

        private void stockQouteResult_Click(object sender, EventArgs e)
        {

        }

        private void stockQouteInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void stockQouteButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                var c = new SearchEngineWithServices.stockQuoteService.ServiceClient("BasicHttpsBinding_Stockquote");
             
                string sq = stockQouteInput.Text.Trim();
                string result = c.getStockquote(sq);

                stockQouteResult.Text = "Result: " + result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}





