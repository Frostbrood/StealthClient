using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace StealthClient
{
    public partial class Authenticate : Form
    {
        public Authenticate()
        {
            InitializeComponent();
        }

        static string uUser;
        static string uPass;

        bool AuthenticateUser()
        {
            uUser = tbUser.Text;
            uPass = tbPass.Text;

            if (Session.AuthenticateUser(uUser, uPass))
                return true;
            else return false;
        }

        void GetList()
        {
            // TODO: Get and add sessions to listbox
        }

        private void btnGetList_Click(object sender, EventArgs e)
        {
            if (AuthenticateUser())
                GetList();
            else
            {
                uUser = null;
                uPass = null;
                tbUser.Text = "";
                tbPass.Text = "";
                MessageBox.Show("Access denied");
            }
        }
        private void btnSelectSession_Click(object sender, EventArgs e)
        {
            if (lbSessions.SelectedIndex != -1 && Session.GetSession(lbSessions.SelectedItem.ToString()))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Session unavailable.");
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUser.Text) && !string.IsNullOrEmpty(tbPass.Text))
                btnGetList.Enabled = true;
            else
                btnGetList.Enabled = false;
        }
        private void lbSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSessions.SelectedIndex != -1)
                btnSelectSession.Enabled = true;
            else
                btnSelectSession.Enabled = false;
        }
    }
}
