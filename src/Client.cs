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
    }
}
