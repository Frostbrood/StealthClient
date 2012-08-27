using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StealthClient
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            //Sample URLs for proof of concept --Remove
            Session.sesAllowedUrls.Add("http://www.ac-web.org/");
            Session.sesAllowedUrls.Add("http://ac-web.org/");
            Session.sesBlockedUrls.Add("http://www.ac-web.org/forums/usercp.php/");

            this.Hide();
            Authenticate auth = new Authenticate();
            DialogResult authDr = new DialogResult();

            authDr = auth.ShowDialog();
            if (authDr == DialogResult.OK)
            {

            }
            else
            {
                MessageBox.Show("The client would close now, but that's disabled for the sake of testing.");
            }

            this.mainBrowser.Navigating += new WebBrowserNavigatingEventHandler(this.mainBrowser_Navigating);
            mainBrowser.Navigate(@"http://www.ac-web.org/");
        }

        bool UrlCheck(string url)
        {
            foreach (string blockedUrl in Session.sesBlockedUrls)
                if (url == blockedUrl)
                    return false;
            foreach (string allowedUrl in Session.sesAllowedUrls)
                if (url == allowedUrl)
                    return true;
            return false;
        }

        private void mainBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!UrlCheck(e.Url.ToString()))
                e.Cancel = true;
        }
    }
}
