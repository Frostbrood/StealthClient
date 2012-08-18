using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using System.Timers;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Updater
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();
        }

        const string url = @"http://www.urltozipfile.directdownload/client.zip";
        const string target = "Stealth Client.zip";
        const string clientExe = "Stealth Client.exe"; // For launching it afterwards

        // Download speed
        System.Timers.Timer timer;
        int dlSpeed;
        bool dlOverKbs;
        int cSecs;
        byte[] byteBuffer;

        private void bgWorker_Work(object sender, DoWorkEventArgs e)
        {
            try
            {
                Uri uri = new Uri(url);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();

                if (File.Exists(target))
                    File.Delete(target);

                Int64 iSize = response.ContentLength;
                Int64 iRunningByteTotal = 0;

                using (WebClient client = new WebClient())
                {
                    using (Stream streamRemote = client.OpenRead(new Uri(url)))
                    {
                        using (Stream streamLocal = new FileStream(target, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            int iByteSize = 0;
                            byteBuffer = new byte[iSize];
                            dlOverKbs = false;
                            timer = new System.Timers.Timer();
                            timer.Elapsed += new ElapsedEventHandler(DLSpeed);
                            timer.Interval = 100;
                            timer.Enabled = true;
                            timer.Start();

                            while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                            {
                                streamLocal.Write(byteBuffer, 0, iByteSize);
                                iRunningByteTotal += iByteSize;

                                double dIndex = (double)(iRunningByteTotal);
                                double dTotal = (double)byteBuffer.Length;
                                double dProgressPercentage = (dIndex / dTotal);
                                int iProgressPercentage = (int)(dProgressPercentage * 100);

                                bgWorker.ReportProgress(iProgressPercentage);
                            }
                            streamLocal.Close();
                        }
                        streamRemote.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error with the updater. Check your connection and try running as an administrator.\r\n\r\n" + ex.Message);
                Application.Exit();
            }
        }

        private void bgWorker_Progress(object sender, ProgressChangedEventArgs e)
        {
            if (dlOverKbs)
                this.Text = "Updating Stealth Client.. " + e.ProgressPercentage + "% - (" + dlSpeed / 1000 + " kb/s)";
            else
                this.Text = "Updating Stealth Client.. " + e.ProgressPercentage + "& - (" + dlSpeed + " b/s)";
            progressBar.Value = e.ProgressPercentage;
        }

        private void bgWorker_Finish(object sender, RunWorkerCompletedEventArgs e)
        {
            timer.Stop();
            try
            {
                if (File.Exists(target))
                {
                    using (ZipFile zip = new ZipFile(target))
                    {
                        zip.ExtractAll(Directory.GetCurrentDirectory(), ExtractExistingFileAction.OverwriteSilently);
                        zip.Dispose();
                    }

                    File.Delete(target);
                    Process start = new Process();
                    start.StartInfo.FileName = clientExe;
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
            ++cSecs;
            dlSpeed = byteBuffer.Length * 8 / (cSecs * 10);
            if (dlSpeed > 1000)
                dlOverKbs = true;
            else
                dlOverKbs = false;
        }

        private void Updater_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            bgWorker.RunWorkerAsync();
        }
    }
}
