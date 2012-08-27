using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace StealthClient
{
    class Patch
    {
        const string exeUpdater = "Stealth Client Updater.exe";
        const string versionRemoteUrl = @"http://www.adresstotxtfilewithversionnumber.com/version.txt"; // Url to version file
        static string versionLocal = Application.ProductVersion;

        public static bool CheckForUpdates()
        {
            string versionRemote = CheckRemoteVersion(versionRemoteUrl);
            if (string.IsNullOrEmpty(versionRemote))
            {
                MessageBox.Show("Stealth Client couldn't obtain version information.\r\nMake sure that you are connected to the internet.");
                Application.Exit();
            }
            else if (versionRemote != versionLocal)
            {
                MessageBox.Show("Update available! (" + versionRemote + ", current: " + versionLocal + ")");
                Update();
            }

            return true;
        }

        static string CheckRemoteVersion(string url)
        {
            try
            {
                string rv = "";

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();

                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                rv = readStream.ReadToEnd();
                response.Close();

                return rv;
            }
            catch
            {
                return null;
            }
        }

        static void Update()
        {
            Process prUpdater = new Process();
            prUpdater.StartInfo.FileName = exeUpdater;
            prUpdater.StartInfo.Arguments = "ProcessStart.cs";
            prUpdater.Start();
            Application.Exit();
        }
    }
}
