using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO; 
using ISA.Trading.Class;
using System.Diagnostics;
namespace ISA.Trading.Controls
{
    public partial class UploadFotoKtp : UserControl
    {
        public event EventHandler FinishUploaded;

        public event EventHandler FinishDownloaded;
        private string sourcePic;
        private bool uploaded = false;

        public UploadFotoKtp()
        {
            InitializeComponent();
        }

        public static string DefaultDestFolderLocal
        {
            get { return @"C:\Temp\Cookies\ISAPalurTrading"; }
        }

        public bool Uploaded
        {
            get {
                bool cek = uploaded;
                uploaded = false;
                return uploaded;
            }
            set { uploaded = value; }
        }

        public string NomorKtp
        {
            get
            {
                return textBox1.Text;
            }
            set 
            { 
                SetPicture(value); 
            }
        }

        public string SourcePicture 
        {
            get
            {
                return sourcePic; 
            }
            set 
            {
                if (value != "") setpicture(value);
            }
        }

        public void Upload()
        {
            if (textBox1.Text != string.Empty)
            {
                string fileName = textBox1.Text + ".jpg";
                string sourceFile = txtPath.Text;
                BwUpload.RunWorkerAsync();
                pnlProgress.Visible = true;
            }
        }

        public bool CekAndUpload()
        {
            try
            {
                if (textBox1.Text != string.Empty)
                {
                    string fileName = textBox1.Text + ".jpg";
                    string sourceFile = txtPath.Text;
                    pnlProgress.Visible = true;
                    ftpmanagementfile.Upload(sourceFile, fileName);

                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        private void setpicture(string pathPic)
        {
            try
            {
                if (System.IO.File.Exists(pathPic))
                {
                    sourcePic = pathPic;
                    txtPath.Text = pathPic;
                    using (FileStream fs = new FileStream(pathPic, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, (int)fs.Length);
                        using (MemoryStream ms = new MemoryStream(buffer))
                            this.pictureBox1.Image = Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Foto KTP Tidak Ada\n");
            }
        }

        public void resetpicture()
        {
                sourcePic = "";
                txtPath.Text = "";
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                setpicture(openFileDialog1.FileName);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void SetPicture(string fileName) 
        {
            if (fileName != "")
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                textBox1.Text = fileName;
                fileName = fileName + ".jpg";

                if (!System.IO.File.Exists(Path.Combine(DefaultDestFolderLocal, fileName)))
                {
                    Download();
                }
                else
                {
                    if (!CheckfileUpdated(fileName))
                    {
                        Download();
                    }
                    else
                    {
                        setpicture(Path.Combine(DefaultDestFolderLocal, fileName));
                    }
                    
                }
            }
            else { SetDefaultPicture(); }

        }

        public void Download() 
        {
            pnlProgress.Visible = true;
            if (!BwDownload.IsBusy) { BwDownload.RunWorkerAsync(); } else { lblProgress.Text = "System sibuk"; }
        }

        public bool CheckfileUpdated(string FileName)
        {
            bool Updated = true;
            var filePathLocal = Path.Combine(DefaultDestFolderLocal, FileName);
            if (System.IO.File.GetLastWriteTime(filePathLocal) < ftpmanagementfile.filemodified(FileName))
                Updated = false;
            return Updated;
        }

        private void SetDefaultPicture() 
        {
                string fileName = "default.png";
                if (!System.IO.File.Exists(Path.Combine(DefaultDestFolderLocal, fileName)))
                {
                    Download();
                }
                else 
                { 
                    setpicture(Path.Combine(DefaultDestFolderLocal, fileName)); 
                }
                textBox1.Text = "";
            
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                setpicture(openFileDialog1.FileName);
            }
        }

        private void UploadFotoKtp_Load(object sender, EventArgs e)
        {
            if(textBox1.Text =="")this.pictureBox1.Image = global::ISA.Trading.Properties.Resources._default;
        }

        private void BwUpload_DoWork(object sender, DoWorkEventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                string fileName="";
                string sourceFile = "";
                this.Invoke((MethodInvoker)delegate()
               {
                   fileName = textBox1.Text + ".jpg";
                   sourceFile = txtPath.Text;
               });
                ftpmanagementfile.Upload(sourceFile, fileName, sender);
            }
        }

        private void BwUpload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgress.Text = e.UserState.ToString();	// the message will be something like: 45 Kb / 102.12 Mb
            progressBar1.Value = Math.Min(this.progressBar1.Maximum, e.ProgressPercentage);	

        }

        private void BwUpload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.ToString(), "FTP error");
            else if (e.Cancelled)
                this.lblProgress.Text = "Upload Cancelled";
            else
                this.lblProgress.Text = "Upload Complete";
            this.lblProgress.Text = "Upload";
            progressBar1.Value = 0;
            uploaded = true;
            pnlProgress.Visible = false;
            if (this.FinishUploaded != null)
            {
                this.FinishUploaded(this, new EventArgs());
            }
        }

        private void BwDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            string fileName = "";
            string Folderpath = "";
            if (!this.IsHandleCreated)
                this.CreateControl();
            this.Invoke((MethodInvoker)delegate()
            {
                fileName = textBox1.Text == String.Empty ? "default.png" : textBox1.Text + ".jpg";
                Folderpath = DefaultDestFolderLocal;
            });
            ftpmanagementfile.Download(Folderpath, fileName, sender);
            
        }

        private void BwDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.ToString(), "FTP error");
            else if (e.Cancelled)
                this.lblProgress.Text = "Download Cancelled";
            else
                this.lblProgress.Text = "Download Complete";
            this.lblProgress.Text = "Download";
            progressBar1.Value = 0;
            uploaded = true;
            pnlProgress.Visible = false;
            String fileName = textBox1.Text == String.Empty ? "default.png" : textBox1.Text + ".jpg";
            setpicture(Path.Combine(DefaultDestFolderLocal, fileName));
            if (this.FinishDownloaded != null)
            {
                this.FinishDownloaded(this, new EventArgs());
            }
        }

        private void BwDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgress.Text = e.UserState.ToString();	// the message will be something like: 45 Kb / 102.12 Mb
            progressBar1.Value = Math.Min(this.progressBar1.Maximum, e.ProgressPercentage);
        }
    }
}
