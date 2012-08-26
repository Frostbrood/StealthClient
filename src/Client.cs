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
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            //Sample URLs for proof of concept --Remove
            Session.sesAllowedUrls.Add("http://www.ac-web.org/");
            Session.sesAllowedUrls.Add("http://ac-web.org/");
            Session.sesBlockedUrls.Add("http://www.ac-web.org/forums/usercp.php");

            foreach (string lstring in Session.sesAllowedUrls)
                if (e.Url.ToString().StartsWith(lstring))
                    e.Cancel = false;

            foreach (string lstring in Session.sesBlockedUrls)
                if (e.Url.ToString().StartsWith(lstring))
                    e.Cancel = true;
        }
    }
}
