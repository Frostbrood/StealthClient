using Ionic.Zip;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Timers;
using System.Windows.Forms;

namespace Updater
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();
        }

        const string url = @"http://www.urltozipfile.directdownload/client.zip"; // Url to .zip
        const string zipTarget = "Stealth Client.zip";
        const string exeTarget = "Stealth Client.exe";

        // Download speed
        System.Timers.Timer dlElapsedTimer; // Elapsed timer
        Int64 iRunningByteTotal = 0; // Total bytes for calculating speed
        int dlSpeed, dlTotalDSecs; // Speed and total deciseconds
        bool dlOverKbs;

        private void bgWorker_Work(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (File.Exists(zipTarget))
                    File.Delete(zipTarget);

                Uri zipUri = new Uri(url);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(zipUri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Int64 iFullSize = response.ContentLength;
                response.Close();

                using (WebClient client = new WebClient())
                using (Stream streamRemote = client.OpenRead(zipUri))
                using (Stream streamLocal = new FileStream(zipTarget, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    byte[] data = new byte[iFullSize];
                    int iByteSize = 0;

                    // Initializing timer
                    dlOverKbs = false;
                    dlElapsedTimer = new System.Timers.Timer();
                    dlElapsedTimer.Elapsed += new ElapsedEventHandler(DLSpeed);
                    dlElapsedTimer.Interval = 100;
                    dlElapsedTimer.Enabled = true;
                    dlElapsedTimer.Start();

                    while ((iByteSize = streamRemote.Read(data, 0, data.Length)) > 0)
                    {
                        streamLocal.Write(data, 0, iByteSize);
                        iRunningByteTotal += iByteSize;

                        double dIndex = (double)(iRunningByteTotal);
                        double dTotal = (double)data.Length;
                        double dProgressPercentage = (dIndex / dTotal);
                        int iProgressPercentage = (int)(dProgressPercentage * 100);

                        bgWorker.ReportProgress(iProgressPercentage);
                    }

                    streamLocal.Close();
                    streamRemote.Close();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    if (File.Exists(zipTarget))
                        File.Delete(zipTarget);
                }
                catch { }
                MessageBox.Show("There was an error with the updater. Check your connection and try running as an administrator.\r\n\r\n" + ex.Message);
                Application.Exit();
            }
        }

        private void bgWorker_Progress(object sender, ProgressChangedEventArgs e)
        {
            if (dlOverKbs)
                this.Text = "Updating Stealth Client.. " + dlSpeed / 1000 + " kb/s)";
            else
                this.Text = "Updating Stealth Client.. " + dlSpeed + " b/s)";
            progressBar.Value = e.ProgressPercentage;
        }

        private void bgWorker_Finish(object sender, RunWorkerCompletedEventArgs e)
        {
            dlElapsedTimer.Stop();
            try
            {
                if (File.Exists(zipTarget))
                {
                    using (ZipFile zip = new ZipFile(zipTarget))
                    {
                        zip.ExtractAll(Directory.GetCurrentDirectory(), ExtractExistingFileAction.OverwriteSilently);
                        zip.Dispose();
                    }

                    File.Delete(zipTarget);
                    Process start = new Process();
                    start.StartInfo.FileName = exeTarget;
                    start.StartInfo.Arguments = "ProcessStart.cs";
                    start.Start();
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error with the updater. Check your connection and try running as an administrator.\r\n\r\n" + ex.Message);
                Application.Exit();
            }
        }

        // Calculate download speed (timer tick eventhandler)
        void DLSpeed(object source, ElapsedEventArgs e)
        {
            ++dlTotalDSecs;
            dlSpeed = (int)iRunningByteTotal / (dlTotalDSecs / 10);
            dlOverKbs = dlSpeed > 1000 ? true : false;
        }

        private void Updater_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            bgWorker.RunWorkerAsync();
        }
    }
}
