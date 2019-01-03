using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Trading.Class;
using ISA.DAL;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ISA.Trading.Communicator
{
    public partial class frmUploadDataMatchingan : ISA.Trading.BaseForm
    {
        public frmUploadDataMatchingan()
        {
            InitializeComponent();
        }

        private void frmUploadDataMatchingan_Load(object sender, EventArgs e)
        {
            rgbTanggal.FromDate = DateTime.Now.AddDays(-7);
            rgbTanggal.ToDate = DateTime.Now;
            pictureBox3.Visible = false;
            cboInpMan.Checked = true;
            cbMatchingan.Checked = true;
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            string dir = @"C:\Temp\Upload\DataMatchingan";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            pictureBox3.Visible = true;
            if (cboInpMan.Checked && cbMatchingan.Checked)
            {
                bwUpload.RunWorkerAsync();
            }
            if (cboInpMan.Checked)
            {
                bwINPMAN.RunWorkerAsync();
            }
            else
            {
                bwMatchingan.RunWorkerAsync();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bwUpload_DoWork(object sender, DoWorkEventArgs e)
        {

            uploadFinance();
            uploadTrading();
            string fileOuput = GlobalVar.DbfUpload + "\\DataMatchingan" + GlobalVar.Gudang + ".zip";
            ZipFile(fileOuput);
            uploadINPMAN();
            uploadfile(fileOuput);
        }

        private void bwUpload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox3.Visible = false;
        }

        private void uploadFinance()
        {
            try
            {
                DataSet ds;
                DateTime dt1 = rgbTanggal.FromDate.Value;
                DateTime dt2 = rgbTanggal.ToDate.Value;
                using (Database db = new Database("ISADBDepoFinance"))
                {
                    db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_Matchingan"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dt1));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dt2));
                    ds = db.Commands[0].ExecuteDataSet();
                }
                string fileOuput = @"C:\Temp\Upload\DataMatchingan" + "\\" + "DataFinance" + ".xml";

                if (File.Exists(fileOuput))
                {
                    File.Delete(fileOuput);
                }

                ds.WriteXml(fileOuput);

            }
            catch (Exception ex)
            {
                
            }
        }

        private void uploadTrading()
        {
            try
            {
                DataSet ds;
                DateTime dt1 = rgbTanggal.FromDate.Value;
                DateTime dt2 = rgbTanggal.ToDate.Value;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_Matchingan"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dt1));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dt2));
                    ds = db.Commands[0].ExecuteDataSet();
                }
                string fileOuput = @"C:\Temp\Upload\DataMatchingan" + "\\" + "DataTrading" + ".xml";

                if (File.Exists(fileOuput))
                {
                    File.Delete(fileOuput);
                }

                ds.WriteXml(fileOuput);

            }
            catch (Exception ex)
            {

            }
        }

        private void ZipFile(string filename)
        {

            List<string> files = new List<string>();

            string fileOuput = filename;
            string file1 = @"C:\Temp\Upload\DataMatchingan" + "\\" + "DataFinance" + ".xml";
            string file2 = @"C:\Temp\Upload\DataMatchingan" + "\\" + "DataTrading" + ".xml";

            files.Add(file1);
            files.Add(file2);

            Zip.ZipFiles(files, fileOuput);
        }

        public void uploadfile(string fileName)
        {
            try
            {
                string FilePath = fileName;
                string FTPName = "ftp://fileserver.sas-autoparts.com/" + GlobalVar.Gudang + "/outbox/";
                string Username = "isalive";
                string Pass = "isalive12345";
                uploadFile(FTPName, FilePath, Username, Pass);
                insertLog("DataMatchingan", "Sukses", "DataMatchingan dikirim lewat FTP");
                MessageBox.Show("Data Matchingan berhasil di upload ke FTP");
            }
            catch
            {
                sentEmail(fileName);
            }

            //File.Delete(FilePath);
        }

        private void uploadFile(string FTPAddress, string filePath, string username, string password)
        {
            //Buat FTP request
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(FTPAddress + "/" + Path.GetFileName(filePath));

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            //Load the file
            FileStream stream = File.OpenRead(filePath);
            byte[] buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);
            stream.Close();

            //Upload file
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();

        }

        private void sentEmail(string fileName)
        {
            DataTable dt;
            using (Database db = new Database("ISADBDepoFinance"))
            {
                db.Commands.Add(db.CreateCommand("usp_getEmail"));
                db.Commands[0].Parameters.Add(new Parameter("@group", SqlDbType.VarChar, "AutoSync"));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                try
                {
                    string dirUpload = GlobalVar.DbfUpload + "\\";
                    DataSet log;



                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("tss.palur.sas@gmail.com");

                    foreach (DataRow dr in dt.Rows)
                    {
                        mail.To.Add(dr["EmailAddress"].ToString());
                    }

                    mail.Subject = "Laporan Data Mathingan " + GlobalVar.Gudang;
                    mail.Body = "Data Matchingan Finance dan Trading";
                    mail.IsBodyHtml = true;

                    if (!Directory.Exists(dirUpload))
                    {
                        Directory.CreateDirectory(dirUpload);
                    }

                    Attachment attachment = new Attachment(fileName);
                    mail.Attachments.Add(attachment);

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("tss.palur.sas@gmail.com", "tss.palur");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);

                    insertLog("DataMatchingan", "Sukses", "DataMatchingan dikirim lewat Email");
                    MessageBox.Show("Data Matchingan berhasil di upload via Email");
                }
                catch
                {
                    MessageBox.Show("Upload Otomatis Gagal. Silahkan Upload Manual file di "+fileName); 
                }
            }
        }

        public void insertLog(string type, string status, string keterangan)
        {
            using (Database db = new Database("ISADBDepoFinance"))
            {
                db.Commands.Add(db.CreateCommand("usp_LogSyncSetoran"));
                db.Commands[0].Parameters.Add(new Parameter("@type", SqlDbType.VarChar, type));
                db.Commands[0].Parameters.Add(new Parameter("@tgl", SqlDbType.DateTime, GlobalVar.DateTimeOfServer));
                db.Commands[0].Parameters.Add(new Parameter("@status", SqlDbType.VarChar, status));
                db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, keterangan));
                db.Commands[0].ExecuteNonQuery();
            }
        }

        private void uploadINPMAN()
        {
            try
            {
                DateTime tglawal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime tglakhir = DateTime.Now;

                DataTable dtResult;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_StokGudang_Upload_INPMAN"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, tglawal));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, tglakhir));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dtResult = db.Commands[0].ExecuteDataTable();
                }

                if (dtResult.Rows.Count > 0)
                {
                    createfileINPMAN(dtResult);
                    uploadfileINPMAN(GlobalVar.DbfUpload + "\\INPMANPS.zip");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void createfileINPMAN(DataTable dtResult)
        {
            List<string> files = new List<string>();
            string FileName = "DATAMAN";
            string ZipName = "INPMANPS";

            string _dirupload = GlobalVar.DbfUpload;
            string Physical = _dirupload + "\\" + FileName + ".dbf";
            string Indexing = _dirupload + "\\" + FileName + ".cdx";
            //files.Add(Indexing);
            files.Add(Physical);

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("BarangID", "idmain", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("FromDate", "Tmt", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("ToDate", "Tmt1", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("QtyAwal", "Awal", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyBeli", "Beli", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyReturBeli", "Rbeli", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyKoreksiBeli", "Kbeli", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyJual", "Jual", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyReturJual", "Rjual", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyJualAntarCab", "Jualcab", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyReturJualAntarCab", "Rjualcab", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyKoreksiJual", "Kjual", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtySelisih", "Selisih", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyMutasi", "Mutasi", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyAkhir", "Akhir", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("KodeGudang", "Kd_toko", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Syncflag", "Id_match", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Hpp", "Hpp", Foxpro.enFoxproTypes.Numeric, 15));
            fields.Add(new Foxpro.DataStruct("NKorJual", "Korpj", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("NKorRetJual", "Korrj", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("NKorBeli", "Korpb", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("NKorRetBeli", "Korrb", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("NAG", "Ag", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyADJOpname", "Adjopnm", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyAdjClosing", "Adjstok", Foxpro.enFoxproTypes.Numeric, 10));
            //Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dtResult);
            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("idmain", "IDMAIN"));

            Foxpro.WriteFile(_dirupload, FileName, fields, dtResult);

            string fileZipName = _dirupload + "\\" + ZipName + ".zip";

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            if (File.Exists(Indexing))
            {
                File.Delete(Indexing);
            }

        }

        public void uploadfileINPMAN(string fileName)
        {
            try
            {
                string FilePath = fileName;
                string FTPName = "ftp://fileserver.sas-autoparts.com/" + GlobalVar.Gudang + "/outbox/";
                string Username = "isalive";
                string Pass = "isalive12345";
                uploadFile(FTPName, FilePath, Username, Pass);
                insertLog("INPMAN", "Sukses", "INPMAN dikirim lewat FTP");
                if (cboInpMan.Checked && !cbMatchingan.Checked)
                {
                    MessageBox.Show("Data INPMAN berhasil di upload ke FTP");
                }
            }
            catch
            {
                sentEmailINPMAN(fileName);
            }

            //File.Delete(FilePath);
        }

        private void sentEmailINPMAN(string fileName)
        {
            DataTable dt;
            using (Database db = new Database("ISADBDepoFinance"))
            {
                db.Commands.Add(db.CreateCommand("usp_getEmail"));
                db.Commands[0].Parameters.Add(new Parameter("@group", SqlDbType.VarChar, "AutoSync"));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                try
                {
                    string dirUpload = GlobalVar.DbfUpload + "\\";

                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("tss.palur.sas@gmail.com");

                    foreach (DataRow dr in dt.Rows)
                    {
                        mail.To.Add(dr["EmailAddress"].ToString());
                    }

                    mail.Subject = "INPMAN " + GlobalVar.Gudang;
                    mail.Body = "INPMAN";
                    mail.IsBodyHtml = true;

                    if (!Directory.Exists(dirUpload))
                    {
                        Directory.CreateDirectory(dirUpload);
                    }

                    Attachment attachment = new Attachment(fileName);
                    mail.Attachments.Add(attachment);

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("tss.palur.sas@gmail.com", "tss.palur");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);

                    insertLog("INPMAN", "Sukses", "INPMAN dikirim lewat Email");
                    if (cboInpMan.Checked && !cbMatchingan.Checked)
                    {
                        MessageBox.Show("Data INPMAN berhasil di upload via Email"); 
                    }
                }
                catch
                {
                    if (cboInpMan.Checked && !cbMatchingan.Checked)
                    {
                        MessageBox.Show("Upload Otomatis Gagal. Silahkan Upload Manual file di "+fileName); 
                    }
                }
            }
        }

        private void bwINPMAN_DoWork(object sender, DoWorkEventArgs e)
        {
            uploadINPMAN();
        }

        private void bwINPMAN_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox3.Visible = false;
        }

        private void bwMatchingan_DoWork(object sender, DoWorkEventArgs e)
        {
            uploadFinance();
            uploadTrading();
            string fileOuput = GlobalVar.DbfUpload + "\\DataMatchingan" + GlobalVar.Gudang + ".zip";
            ZipFile(fileOuput);
            uploadfile(fileOuput);
        }

        private void bwMatchingan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox3.Visible = false;
        }

    }
}
