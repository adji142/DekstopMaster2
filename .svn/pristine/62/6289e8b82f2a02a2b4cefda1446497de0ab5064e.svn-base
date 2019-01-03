using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using ISA.DAL;
using ISA.Common;

namespace ISA.Trading.Master
{
    public partial class frmTokoAttachmentView : ISA.Controls.BaseForm
    {
        String _FileName = "";
        String _KodeToko = "";
        String _NamaToko = "";
        String FTPPath = "";
        String UsernameFTP = "";
        String PasswordFTP = "";


        static string ftpServerIP = "ktptoko.sas-autoparts.com";
        static string ftpUserID = "administrator";
        static string ftpPassword = "password11";
        static string Foldername = "ISAPalurTrading";

        public frmTokoAttachmentView()
        {
            InitializeComponent();
        }

        public frmTokoAttachmentView(Form Caller, String FileName, String KodeToko, String NamaTokog)
        {
            InitializeComponent();
            this.Caller = Caller;
            _FileName = FileName;
            _KodeToko = KodeToko;
            _NamaToko = NamaTokog;
        }

        private void frmTokoAttachmentView_Load(object sender, EventArgs e)
        {
            // ambil dari FTP file dengan FileName yg sudah dipilih
            try
            {
                FTPPath = "ftp://" + ftpServerIP + "/" + Foldername;
                UsernameFTP = ftpUserID;
                PasswordFTP = ftpPassword;
                LoadAttachedPicture();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Error : " + ex.Message);
                this.Close();
            }
        }

        private void LoadAttachedPicture()
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPPath + "/" + _FileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(UsernameFTP, PasswordFTP);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                Image img = Image.FromStream(responseStream, false, false);

                pbxAttachment.Image = img;

                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
