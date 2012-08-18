using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace StealthClient
{
    public partial class Authenticate : Form
    {
        static string uGUID;
        static string uUser;
        static string uPass;

        public Authenticate()
        {
            InitializeComponent();
        }

        void GetGUID()
        {
            RegistryKey GUIDKey = Registry.CurrentUser.CreateSubKey("Stealth Client");
            string uGUID = (string)GUIDKey.GetValue("GUID");
            if (uGUID == null)
            {
                uGUID = Guid.NewGuid().ToString();
                GUIDKey.SetValue("GUID", uGUID);
            }
        }

        bool AuthenticateUser()
        {
            GetGUID();
            uUser = tbUser.Text;
            uPass = tbPass.Text;

            // Todo: auth user with user, pass and GUID
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (AuthenticateUser())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
