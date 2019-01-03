using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using ISA.DAL;
using System.Windows.Forms;
using ISA.FTP;
using System.Net;
using ISA.Common;
using System.IO.Compression;
using System.Data.SqlClient;
using System.Xml;
using Microsoft.Win32;
using System.Net.Mail;
using System.Configuration;
using ISA.AutoSynch.ServiceReference1;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;


namespace ISA.AutoSynch
{
    public partial class frmautosynch : Form
    {
        int hitung, hitungdownload, hitungJadwalEx, hitungmonitoring, hitungnotapenjualan, hitungHPPA, hitungJournal, hitungCheckFile;
        int waktuminimize = 8;
        Guid RowID = new Guid();
        Guid activeSynchLogRowIDINPMAN;
        Guid activeSynchLogRowIDPB00;
        Guid activeSynchLogRowIDKorPJ;
        Guid activeSynchLogRowIDJadwalEx;
        Guid activeSynchLogRowIDNotaPenjualan;
        Guid activeSynchLogRowIDHPPA;
        Guid activeSynchLogRowIDJournal;
        int counter = 0;
         
        DataSet dsResult = new DataSet();

        ErrorProvider err = new ErrorProvider();


        DataTable dtCustomer = new DataTable();
        DataTable dtApi = new DataTable();
        DataTable dtBGC = new DataTable();
        DataTable dtApiLink = new DataTable();

        DateTime Setorans;
        string DBName = "ISADBDepoFinance";
        string Gudang="";

        int rencana = 0, realisasi = 0, email=0, checkserver=0;
        //usp_kodeperusahaan_LIST
       

       ////untuk mendisable menu exit
       // private const int CP_NOCLOSE_BUTTON = 0x200;
       // protected override CreateParams CreateParams
       // {
       //     get
       //     {
       //         CreateParams myCp = base.CreateParams;
       //         myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
       //         return myCp;
       //     }
       // } 

        public frmautosynch()
        {
            InitializeComponent();
           

        }

        private void frmautosynch_Load(object sender, EventArgs e)
        {
            rencana = 0;
            realisasi = 0;
            email = 0;
            txtRencanaSetoran.Text = "Rencana Setoran is Enable";
            txtRealisasiSetoran.Text = "Realisasi Setoran is Enable";
            int th = DateTime.Now.Year;
            int bln = DateTime.Now.Month;

            monthYearBox.Month = bln;
            monthYearBox.Year = th;

            DateTime blnh = Convert.ToDateTime(th + "-" + bln + "-1");
            Setorans = blnh.AddMonths(1).AddDays(-1);
            radioRencana.Checked = true;
            radioRealisasi.Checked = false;

            DateTime awalbln = Convert.ToDateTime(th + "-" + bln + "-1");
            DateTime akhirbln = awalbln.AddMonths(1).AddDays(-1);
            String nama = System.Environment.MachineName;
            lblkomputer.Text = nama;
            DateTime jamku = DateTime.Now;

            DateTime tglawal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime tglakhir = DateTime.Now;
            if ((tglakhir.Hour * 100) + tglakhir.Minute  >= 825)
            {
                try
                {
                    DataTable dt = new DataTable();

                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_kodegudang_LIST"));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    txttarget.Text = Tools.isNull(dt.Rows[0]["InitGudang"], "").ToString();
                    Gudang = Tools.isNull(dt.Rows[0]["InitGudang"], "").ToString();
                    DataTable dtjam = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_GetServerDate"));
                        dtjam = db.Commands[0].ExecuteDataTable();
                    }

                    jamku = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));

                    tglawal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    tglakhir = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));
                    checkserver = 1;
                }
                catch
                {
                    checkserver = 0;
                }
            }
            String tglawa = tglawal.ToString("dd-MMM-yyyy");
            String tglformat = tglakhir.ToString("dd-MMM-yyyy");
            lbltanggal.Text = tglformat;

            DateTime tjamku = DateTime.Now;
            lbljam.Text = tjamku.Hour.ToString();
            lblmenit.Text = tjamku.Minute.ToString();
            lbldetik.Text = tjamku.Second.ToString();
            
            hitung = 900; // 15menit
            timer1.Enabled = false;
            hitungdownload = 3600; //1 jam
            RowID = Guid.NewGuid();
            timer2.Enabled = false;
            timerJadwalEx.Enabled = false;
            hitungJadwalEx = 1000; //15 menitan
            hitungmonitoring = 900; //15menit
            timermonitoring.Enabled = false;
            hitungnotapenjualan = 1500;
            timerNotaPenjualan.Enabled = false;
            hitungHPPA = 2500;
            timerHPPA.Enabled = false;
            hitungJournal = 10;//2250;
            timerJournal.Enabled = false;
            timerSetoran.Enabled = true;
            hitungCheckFile = 1000;

            bwRealisasi.WorkerReportsProgress = true;
            bwRealisasi.WorkerSupportsCancellation = true;

            bwRencana.WorkerReportsProgress = true;
            bwRencana.WorkerSupportsCancellation = true;
     
        }

        private void chekDepo()
        {
                DateTime tglawal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime tglakhir = DateTime.Now;
                try
                {
                    DataTable dt = new DataTable();

                    using (Database db = new Database())
                    {

                        db.Commands.Add(db.CreateCommand("usp_kodegudang_LIST"));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    txttarget.Text = Tools.isNull(dt.Rows[0]["InitGudang"], "").ToString();
                    Gudang = Tools.isNull(dt.Rows[0]["InitGudang"], "").ToString();
                    DataTable dtjam = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_GetServerDate"));
                        dtjam = db.Commands[0].ExecuteDataTable();
                    }

                    tglawal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    tglakhir = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));
                    checkserver = 1;
                }
                catch
                {
                    checkserver = 0;
                }
                String tglawa = tglawal.ToString("dd-MMM-yyyy");
                String tglformat = tglakhir.ToString("dd-MMM-yyyy");
                lbltanggal.Text = tglformat;
            
        }


        private void ZipFileINPMAN(List<string> files)
        {

            string fileZipName = FtpEngine.UploadDirectory + "\\INPMANFTP.zip"; 
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            foreach (string str in files)
            {
                if (File.Exists(str))
                {
                    File.Delete(str);
                }
            }
        }

        private void ZipFilePB00(List<string> filesPB00)
        {
            string fileZipName = FtpEngine.UploadDirectory + "\\PB00FTP.zip";
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(filesPB00, fileZipName);

            foreach (string str in filesPB00)
            {
                if (File.Exists(str))
                {
                    File.Delete(str);
                }
            }
        }

        private void ZipFileNotaPenjualan(List<string> filesNotaPenjualan)
        {


            string fileZipName = FtpEngine.UploadDirectory + "\\NOTAPENJUALANFTP.zip";
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(filesNotaPenjualan, fileZipName);

            foreach (string str in filesNotaPenjualan)
            {
                if (File.Exists(str))
                {
                    File.Delete(str);
                }
            }
        }

        private void ZipFileJournal(List<string> filesJournal)
        {


            string fileZipName = FtpEngine.UploadDirectory + "\\JOURNALFTP.zip";
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(filesJournal, fileZipName);

            foreach (string str in filesJournal)
            {
                if (File.Exists(str))
                {
                    File.Delete(str);
                }
            }
        }

        private void ZipFileHPPA(List<string> filesHPPA)
        {

            string fileZipName = FtpEngine.UploadDirectory + "\\HPPAFTP.zip";
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(filesHPPA, fileZipName);

            foreach (string str in filesHPPA)
            {
                if (File.Exists(str))
                {
                    File.Delete(str);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime jamku = DateTime.Now;
            lbljam.Text = jamku.Hour.ToString();
            lblmenit.Text = jamku.Minute.ToString();
            lbldetik.Text = jamku.Second.ToString();
            
            hitung--;
            cekupload.Text = "Cek Upload INPMAN Berjalan Dalam Hitungan Mundur :  " + hitung + " detik";
            DateTime tgl = DateTime.Now;
           
            if (hitung == 0)
            {

                pictureBox3.Visible = true;
                DataTable dtmaster = new DataTable();
                DataTable dtlog = new DataTable();
                DataTable dtjam = new DataTable();

                DataTable dtgudang = new DataTable();

                using (Database db = new Database())
                {
               
                    db.Commands.Add(db.CreateCommand("usp_kodeperusahaan_LIST"));
                    dtgudang = db.Commands[0].ExecuteDataTable();
                }
                String Gudang = Tools.isNull(dtgudang.Rows[0]["initgudang"], 0).ToString();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_MasterAutoSynch_LIST"));
                    dtmaster = db.Commands[0].ExecuteDataTable();
                }

                Guid pModuleRowID = (Guid)(dtmaster.Rows[0]["RowID"]);


                if (dtmaster.Rows.Count == 0)
                {
                    MessageBox.Show("Terjadi Kesalahan, Data Master tidak ditemukan");
                }
                else
                {

                    int i;
                    for (i = 0; i <= dtmaster.Rows.Count-1 ; i++)
                    {
                        String ModuleName = Tools.isNull(dtmaster.Rows[i]["ModuleName"], 0).ToString();
                        int Frequency = Convert.ToInt32(Tools.isNull(dtmaster.Rows[i]["Frequency"], 0).ToString());
                   //   DateTime TmpDate = DateTime.Now;


                        using (Database db = new Database())
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_GetServerDate"));
                            dtjam = db.Commands[0].ExecuteDataTable();
                        }
                      
                        DateTime TmpDate = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));
                        
                            using (Database db = new Database())
                            {

                                db.Commands.Clear();
                                db.Commands.Add(db.CreateCommand("usp_AutoSynchLog_filter"));
                                db.Commands[0].Parameters.Add(new Parameter("@Module", SqlDbType.UniqueIdentifier, new Guid(dtmaster.Rows[i]["RowID"].ToString())));
                                dtlog = db.Commands[0].ExecuteDataTable();

                            }


                            if (dtlog.Rows.Count != 0)
                            {
                                if ((ModuleName == "Rekapstock") && (Convert.ToDateTime(Tools.isNull(dtlog.Rows[0]["Tgl_terakhir"], DateTime.MinValue)).AddMinutes(Frequency) < TmpDate))
                                {
                                    try
                                    {
                                        List<string> files = new List<string>();

                                        insertAutoSynchLog(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang);

                                        DataSet dsINPMAN = GetSyncDataINPMAN();
                                        string Target = txttarget.Text;
                                        string fileOuput = FtpEngine.UploadDirectory + "\\" + "INPMANFTP" + ".xml";
                                        dsINPMAN.WriteXml(fileOuput);

                                        files.Add(fileOuput);
                                        ZipFileINPMAN(files);


                                        string FTPName = "ftp://117.20.56.212/" + Gudang + "/outbox/";
                                        string FilePath = @"C:\Temp\FTP\UPLOAD\" + "INPMANFTP.zip";

                                        string Username = "isadev";
                                        string Pass = "isadev";

                                        uploadFile(FTPName, FilePath, Username, Pass);
                                        updateStatusFTPINPMAN();

                                        File.Delete(FilePath);

                                     
                                        lblprogress.Text = "";
                                    }
                                    catch (System.Exception ex)
                                    {
                                        try
                                        {
                                            MailMessage mail = new MailMessage();
                                            SmtpClient SmtpServer = new SmtpClient(ISA.AutoSynch.Properties.Settings.Default.smtp);


                                            mail.From = new MailAddress(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                            mail.To.Add(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                            mail.Subject = "Error AutoSynch Cabang " + Gudang;
                                            StringBuilder sbErrorMessage = new StringBuilder();

                                            mail.Body = "Error dalam upload INPMAN  Cabang : " + Gudang + " Pada Tanggal :" + DateTime.Now;
                                            mail.Body = mail.Body + " === EX Message : " + ex.Message;


                                            SmtpServer.Port = 26;
                                            SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.AutoSynch.Properties.Settings.Default.smtplogin, ISA.AutoSynch.Properties.Settings.Default.smtppassword);
                                            SmtpServer.EnableSsl = false;

                                            SmtpServer.Send(mail);
                                            // MessageBox.Show("Error dalam download INPMAN Cabang : " + Gudang + "Sudah Dikirim Ke Email", "Informasi");
                                        }
                                        catch
                                        {
                                            Error.LogError(ex);
                                            MessageBox.Show("Error dalam kirim pesan errorlog ke email pada proses upload INPMAN Cabang : " + Gudang);
                                        }

                                    }

                                }
                                else if ((ModuleName == "PB00") && (Convert.ToDateTime(Tools.isNull(dtlog.Rows[0]["Tgl_terakhir"], DateTime.MinValue)).AddMinutes(Frequency) < TmpDate))
                                {
                                    DataSet ds = new DataSet();
                                    DataTable dtdetail = new DataTable();
                                    DataTable dtheader = new DataTable();
                                    using (Database db = new Database())
                                    {
                                        refreshForm();

                                        db.Commands.Clear();
                                        db.Commands.Add(db.CreateCommand("usp_PB00_DETAIL_UPLOAD"));
                                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, txttarget.Text));
                                        db.Commands[0].Parameters.Add(new Parameter("@Module", SqlDbType.UniqueIdentifier, new Guid(dtmaster.Rows[i]["RowID"].ToString())));
                                        dtdetail = db.Commands[0].ExecuteDataTable();
                                        dtdetail.TableName = "PB00DETAIL";

                                    }
                                    if (dtdetail.Rows.Count > 0)
                                    {
                                        try
                                        {
                                            List<string> filesPB00 = new List<string>();

                                            insertAutoSynchLog(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang);

                                            DataSet dsPB00 = GetSyncDataPB00(new Guid(dtmaster.Rows[i]["RowID"].ToString()));

                                            string Target = txttarget.Text;
                                            string fileOuput = FtpEngine.UploadDirectory + "\\" + "PB00FTP" + ".xml";
                                            dsPB00.WriteXml(fileOuput);

                                            filesPB00.Add(fileOuput);
                                            ZipFilePB00(filesPB00);

                                            string FTPName = "ftp://117.20.56.212/" + Gudang + "/outbox/";
                                            string FilePath = @"C:\Temp\FTP\UPLOAD\" + "PB00FTP.zip";
                                            string Username = "isadev";
                                            string Pass = "isadev";

                                            uploadFile(FTPName, FilePath, Username, Pass);
                                            updateStatusFTPPB00();

                                            File.Delete(FilePath);

                                          
                                            lblprogress.Text = "";
                                        }
                                        catch (System.Exception ex)
                                        {
                                            try
                                            {
                                                MailMessage mail = new MailMessage();
                                                SmtpClient SmtpServer = new SmtpClient(ISA.AutoSynch.Properties.Settings.Default.smtp);


                                                mail.From = new MailAddress(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                                mail.To.Add(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                                mail.Subject = "Error AutoSynch Cabang " + Gudang;
                                                StringBuilder sbErrorMessage = new StringBuilder();

                                                mail.Body = "Error dalam upload PB00  Cabang : " + Gudang + " Pada Tanggal :" + DateTime.Now;
                                                mail.Body = mail.Body + " === EX Message : " + ex.Message;


                                                SmtpServer.Port = 26;
                                                SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.AutoSynch.Properties.Settings.Default.smtplogin, ISA.AutoSynch.Properties.Settings.Default.smtppassword);
                                                SmtpServer.EnableSsl = false;

                                                SmtpServer.Send(mail);
                                                // MessageBox.Show("Error dalam download INPMAN Cabang : " + Gudang + "Sudah Dikirim Ke Email", "Informasi");
                                            }
                                            catch
                                            {
                                                Error.LogError(ex);
                                                MessageBox.Show("Error dalam kirim pesan errorlog ke email pada proses upload PB00 Cabang : " + Gudang);
                                            }

                                        }
                                    }

                                    else { insertAutoSynchLogKosong(new Guid(dtmaster.Rows[i]["RowID"].ToString()),Gudang); }

                                }
                            }

                            else
                            {
                                  if (ModuleName == "Rekapstock")
                                {
                                    DataSet ds = new DataSet();
                                    DataTable dt = new DataTable();
                                    DateTime tglawal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                                    DateTime tglakhir = DateTime.Now;

                                    using (Database db = new Database())
                                    {
                                        refreshForm();

                                        db.Commands.Clear();
                                        db.Commands.Add(db.CreateCommand("usp_StokGudang_Upload_INPMAN_ISA"));
                                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, tglawal));
                                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, tglakhir));
                                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, txttarget.Text));
                                        dt = db.Commands[0].ExecuteDataTable();
                                        dt.TableName = "INPMAN";
                                        if (dt.Rows.Count > 0)
                                        {

                                            try
                                            {

                                                List<string> files = new List<string>();

                                                insertAutoSynchLog(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang);
                                                
                                                DataSet dsINPMAN = GetSyncDataINPMAN();
                                                string Target = txttarget.Text;
                                                string fileOuput = FtpEngine.UploadDirectory + "\\" + "INPMANFTP" + ".xml";
                                                dsINPMAN.WriteXml(fileOuput);

                                                files.Add(fileOuput);
                                                ZipFileINPMAN(files);


                                                string FTPName = "ftp://117.20.56.212/" + Gudang + "/outbox/";
                                                string FilePath = @"C:\Temp\FTP\UPLOAD\" + "INPMANFTP.zip";
                                                string Username = "isadev";
                                                string Pass = "isadev";


                                                uploadFile(FTPName, FilePath, Username, Pass);
                                                updateStatusFTPINPMAN();


                                                File.Delete(FilePath);

                                               
                                                lblprogress.Text = "";
                                            }
                                            catch (System.Exception ex)
                                            {
                                                try
                                                {
                                                    MailMessage mail = new MailMessage();
                                                    SmtpClient SmtpServer = new SmtpClient(ISA.AutoSynch.Properties.Settings.Default.smtp);


                                                    mail.From = new MailAddress(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                                    mail.To.Add(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                                    mail.Subject = "Error AutoSynch Cabang " + Gudang;
                                                    StringBuilder sbErrorMessage = new StringBuilder();

                                                    mail.Body = "Error dalam upload INPMAN  Cabang : " + Gudang + " Pada Tanggal :" + DateTime.Now;
                                                    mail.Body = mail.Body + " === EX Message : " + ex.Message;


                                                    SmtpServer.Port = 26;
                                                    SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.AutoSynch.Properties.Settings.Default.smtplogin, ISA.AutoSynch.Properties.Settings.Default.smtppassword);
                                                    SmtpServer.EnableSsl = false;

                                                    SmtpServer.Send(mail);
                                                    // MessageBox.Show("Error dalam download INPMAN Cabang : " + Gudang + "Sudah Dikirim Ke Email", "Informasi");
                                                }
                                                catch
                                                {
                                                    Error.LogError(ex);
                                                    MessageBox.Show("Error dalam kirim pesan errorlog ke email pada proses upload INPMAN Cabang : " + Gudang);
                                                }

                                            }
                                        }
                                        else { insertAutoSynchLogKosong(new Guid(dtmaster.Rows[i]["RowID"].ToString()),Gudang); }
                                    }


                                }
                                else if (ModuleName == "PB00")
                                {

                                    DataSet ds = new DataSet();
                                    DataTable dtdetail = new DataTable();
                                    DataTable dtheader = new DataTable();
                                    using (Database db = new Database())
                                    {
                                        refreshForm();

                                        db.Commands.Clear();
                                        db.Commands.Add(db.CreateCommand("usp_PB00_DETAIL_UPLOAD"));
                                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, txttarget.Text));
                                        db.Commands[0].Parameters.Add(new Parameter("@Module", SqlDbType.UniqueIdentifier, new Guid(dtmaster.Rows[i]["RowID"].ToString())));
                                        dtdetail = db.Commands[0].ExecuteDataTable();
                                        dtdetail.TableName = "PB00DETAIL";

                                    }
                                    if (dtdetail.Rows.Count > 0)
                                    {
                                        try
                                        {
                                            List<string> filesPB00 = new List<string>();

                                            insertAutoSynchLog(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang);

                                            DataSet dsPB00 = GetSyncDataPB00(new Guid(dtmaster.Rows[i]["RowID"].ToString()));

                                            string Target = txttarget.Text;
                                            string fileOuput = FtpEngine.UploadDirectory + "\\" + "PB00FTP" + ".xml";
                                            dsPB00.WriteXml(fileOuput);

                                            filesPB00.Add(fileOuput);
                                            ZipFilePB00(filesPB00);


                                            string FTPName = "ftp://117.20.56.212/" + Gudang + "/outbox/";
                                            string FilePath = @"C:\Temp\FTP\UPLOAD\" + "PB00FTP.zip";
                                            string Username = "isadev";
                                            string Pass = "isadev";

                                            uploadFile(FTPName, FilePath, Username, Pass);
                                            updateStatusFTPPB00();

                                            File.Delete(FilePath);

                                            
                                            lblprogress.Text = "";
                                        }
                                        catch (System.Exception ex)
                                        {
                                            try
                                            {
                                                MailMessage mail = new MailMessage();
                                                SmtpClient SmtpServer = new SmtpClient(ISA.AutoSynch.Properties.Settings.Default.smtp);


                                                mail.From = new MailAddress(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                                mail.To.Add(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                                mail.Subject = "Error AutoSynch Cabang " + Gudang;
                                                StringBuilder sbErrorMessage = new StringBuilder();

                                                mail.Body = "Error dalam upload PB00  Cabang : " + Gudang + " Pada Tanggal :" + DateTime.Now;
                                                mail.Body = mail.Body + " === EX Message : " + ex.Message;


                                                SmtpServer.Port = 26;
                                                SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.AutoSynch.Properties.Settings.Default.smtplogin, ISA.AutoSynch.Properties.Settings.Default.smtppassword);
                                                SmtpServer.EnableSsl = false;

                                                SmtpServer.Send(mail);
                                                // MessageBox.Show("Error dalam download INPMAN Cabang : " + Gudang + "Sudah Dikirim Ke Email", "Informasi");
                                            }
                                            catch
                                            {
                                                Error.LogError(ex);
                                                MessageBox.Show("Error dalam kirim pesan errorlog ke email pada proses upload PB00 Cabang : " + Gudang);
                                            }

                                        }
                                    }
                                    else { insertAutoSynchLogKosong(new Guid(dtmaster.Rows[i]["RowID"].ToString()),Gudang); }
                                }
                            }
                        }
                    }
                hitung = 900; // 15menit
                pictureBox3.Visible = false;
           }
            
        }

        private void insertAutoSynchLog(Guid pModuleRowID, string gudangid)
        {    
           
                using (Database db = new Database())
            {

                db.BeginTransaction();
               

                db.Commands.Add(db.CreateCommand("usp_AutoSynchLog_INSERT"));
                db.Commands[0].Parameters.Add(new Parameter("@Module", SqlDbType.UniqueIdentifier, pModuleRowID));
                db.Commands[0].Parameters.Add(new Parameter("@DownUpload", SqlDbType.VarChar, "Upload"));
                db.Commands[0].Parameters.Add(new Parameter("@StatusFTP", SqlDbType.Int, 1));
                db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, "AutoSynch"));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "AutoSynch"));
                db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, gudangid));
                db.Commands[0].ExecuteNonQuery();

                db.CommitTransaction();

            }
        }


        private void insertAutoSynchLogKosong(Guid pModuleRowID, string gudangid)
        {
            
            using (Database db = new Database())
            {

                db.BeginTransaction();


                db.Commands.Add(db.CreateCommand("usp_AutoSynchLog_INSERT"));
                db.Commands[0].Parameters.Add(new Parameter("@Module", SqlDbType.UniqueIdentifier, pModuleRowID));
                db.Commands[0].Parameters.Add(new Parameter("@DownUpload", SqlDbType.VarChar, "Upload"));
                db.Commands[0].Parameters.Add(new Parameter("@StatusFTP", SqlDbType.Int, 5));
                db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, "AutoSynch"));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "AutoSynch"));
                db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, gudangid));
                db.Commands[0].ExecuteNonQuery();

                db.CommitTransaction();

            }
        }

       

        private void updateStatusFTPINPMAN()
        {
            using (Database db = new Database())
            {

                db.BeginTransaction();

                db.Commands.Add(db.CreateCommand("usp_AutoSynchLog_StatusUpdate"));
                db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.Int, 2));
                db.Commands[0].ExecuteNonQuery();

                db.CommitTransaction();
            }
        }


        private void updateStatusFTPPB00()
        {
            using (Database db = new Database())
            {

                db.BeginTransaction();

                db.Commands.Add(db.CreateCommand("usp_AutoSynchLog_StatusUpdate"));
                db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.Int, 2));
                db.Commands[0].ExecuteNonQuery();

                db.CommitTransaction();
            }
        }

        private void updateStatusFTP()
        {
            using (Database db = new Database())
            {

                db.BeginTransaction();

                db.Commands.Add(db.CreateCommand("usp_AutoSynchLog_StatusUpdate"));
                db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.Int, 2));
                db.Commands[0].ExecuteNonQuery();
                db.CommitTransaction();
            }
        }


        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }

        private DataSet GetSyncDataINPMAN()
        {
            DataTable dtjam = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_GetServerDate"));
                dtjam = db.Commands[0].ExecuteDataTable();
            }

            DateTime jamku = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));

            DateTime tglawal = new DateTime(jamku.Year, jamku.Month, 1);
            DateTime tglakhir = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));

            DataSet dsINPMAN = new DataSet();
            DataTable dt = new DataTable();
            DataTable auto = new DataTable();


            using (Database db = new Database())
            {
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_StokGudang_Upload_INPMAN_ISA"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, tglawal));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, tglakhir));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, txttarget.Text));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "INPMAN";
                if (dt.Rows.Count > 0)
                {
                    dsINPMAN.Tables.Add(dt);
                }
                

                
            }
            
                using (Database db = new Database())
            {
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_AutoSynchLog"));
                auto = db.Commands[0].ExecuteDataTable();
                auto.TableName = "AUTOSYNCHLOG";
                if (auto.Rows.Count > 0)
                {
                    dsINPMAN.Tables.Add(auto);
                    activeSynchLogRowIDINPMAN = new Guid(dsINPMAN.Tables["AUTOSYNCHLOG"].Rows[0]["RowID"].ToString()); 
                }
               
                

            }
            return dsINPMAN;
        }


        private DataSet GetSyncDataJournal()
        {
            DataSet dsJournal = new DataSet();
            DataTable dtdetail = new DataTable();
            DataTable dtheader = new DataTable();
            DataTable auto = new DataTable();

            DataTable dtjam = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_GetServerDate"));
                dtjam = db.Commands[0].ExecuteDataTable();
            }

            DateTime tglakhir = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));
            DateTime tglawal = tglakhir.AddDays(-5);


            using (Database db = new Database("ISAFinance"))
            {
                db.Commands.Add(db.CreateCommand("psp_GL_UPLOAD_Journal"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, tglawal));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, tglakhir));
                //db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, new DateTime(2010, 10, 01)));
                //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, new DateTime(2010, 10, 15)));
                dtheader = db.Commands[0].ExecuteDataTable();
                dtheader.TableName = "JURNALHEADER";

                if (dtheader.Rows.Count > 0)
                {
                    dsJournal.Tables.Add(dtheader);
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("psp_GL_UPLOAD_JournalDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, tglawal));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, tglakhir));
                    //db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, new DateTime(2010, 10, 01)));
                    //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, new DateTime(2010, 10, 15)));
                    dtdetail = db.Commands[0].ExecuteDataTable();
                    dtdetail.TableName = "JOURNALDETAIL";
                    if (dtdetail.Rows.Count > 0)
                    {
                        dsJournal.Tables.Add(dtdetail);
                    }

                }


            }
          
            using (Database db = new Database())
            {
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_AutoSynchLog"));
                auto = db.Commands[0].ExecuteDataTable();
                auto.TableName = "AUTOSYNCHLOG";
                if (auto.Rows.Count > 0)
                {
                    dsJournal.Tables.Add(auto);
                    activeSynchLogRowIDPB00 = new Guid(dsJournal.Tables["AUTOSYNCHLOG"].Rows[0]["RowID"].ToString());
                }

            }


            return dsJournal;
        }


        private DataSet GetSyncDataHPPA()
        {
            DataTable dtjam = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_GetServerDate"));
                dtjam = db.Commands[0].ExecuteDataTable();
            }

            DateTime tglakhir = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));

            DataSet dsHPPA = new DataSet();
            DataTable dt = new DataTable();
            DataTable auto = new DataTable();


            using (Database db = new Database())
            {
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_HistoryHPPA_AutoSynch"));
                //db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.DateTime, new DateTime(2010, 10, 01)));
                db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, txttarget.Text));
                db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.DateTime, tglakhir));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "HPPA";
                if (dt.Rows.Count > 0)
                {
                    dsHPPA.Tables.Add(dt);
                }
                
            }

            using (Database db = new Database())
            {
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_AutoSynchLog"));
                auto = db.Commands[0].ExecuteDataTable();
                auto.TableName = "AUTOSYNCHLOG";
                if (auto.Rows.Count > 0)
                {
                    dsHPPA.Tables.Add(auto);
                    activeSynchLogRowIDHPPA = new Guid(dsHPPA.Tables["AUTOSYNCHLOG"].Rows[0]["RowID"].ToString());
                }



            }
            return dsHPPA;
        }


        private DataSet GetSyncDataPB00(Guid Module)
        {
            DataSet dsPB00 = new DataSet();
            DataTable dtdetail = new DataTable();
            DataTable dtheader = new DataTable();
            DataTable auto = new DataTable();

            using (Database db = new Database())
            {
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_PB00_DETAIL_UPLOAD"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, txttarget.Text));
                db.Commands[0].Parameters.Add(new Parameter("@Module", SqlDbType.UniqueIdentifier,Module));
                dtdetail = db.Commands[0].ExecuteDataTable();
                dtdetail.TableName = "PB00DETAIL";
                if (dtdetail.Rows.Count > 0)
                {
                    dsPB00.Tables.Add(dtdetail);
                    Guid Header = (Guid)(dtdetail.Rows[0]["RowID"]);
                    refreshForm();
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_PB00_HEADER_UPLOAD"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, txttarget.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Module", SqlDbType.UniqueIdentifier, Module));
                    dtheader = db.Commands[0].ExecuteDataTable();
                    dtheader.TableName = "PB00HEADER";
                    if (dtheader.Rows.Count > 0)
                    {
                        dsPB00.Tables.Add(dtheader);
                    }
                   
                }
             
            }
            using (Database db = new Database())
            {
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_AutoSynchLog"));
                auto = db.Commands[0].ExecuteDataTable();
                auto.TableName = "AUTOSYNCHLOG";
                if (auto.Rows.Count > 0)
                {
                    dsPB00.Tables.Add(auto);
                    activeSynchLogRowIDPB00 = new Guid(dsPB00.Tables["AUTOSYNCHLOG"].Rows[0]["RowID"].ToString());
                }

            }


            return dsPB00;
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


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void frmautosynch_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "APP Hidden";
                notifyIcon1.BalloonTipText = "Your application has been minimized to the taskbar.";
                notifyIcon1.ShowBalloonTip(1000, "Auto Synch Cabang", "Ini adalah program AutoSynch!", ToolTipIcon.Info);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime jamKorPJ = DateTime.Now;

            DataTable dtgudang = new DataTable();

            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("usp_kodeperusahaan_LIST"));
                dtgudang = db.Commands[0].ExecuteDataTable();
            }
            String Gudang = Tools.isNull(dtgudang.Rows[0]["initgudang"], 0).ToString();

            hitungdownload--;
            cekdownload.Text = "Cek Download Koreksi Penjualan Akan Berjalan Dalam Hitungan Mundur :  " + hitungdownload + " detik";

            if (hitungdownload == 0)
            {
                pictureBox3.Visible = true;
                bool fDwnKorPJSuccess = DownloadKorPJ(Gudang);
                if (fDwnKorPJSuccess == true)
                {
                    try
                    {
                        String FileZip = @"C:\Temp\FTP\DOWNLOAD\" + "KoreksiJual" + Gudang + ".zip";
                        String FileXml = @"C:\Temp\FTP\DOWNLOAD\" + "KoreksiJual.XML";

                        UnzipKorPJ(Gudang);
                        INSERTKORPJ(Gudang);
                        InsertSynchLogKorPJ(Gudang);

                        updateStatusKorPJ();
                        DeleteKorPJ(Gudang);
                        File.Delete(FileZip);
                        File.Delete(FileXml);
                    }
                    catch (System.Exception ex)
                    {
                        try
                        {
                            MailMessage mail = new MailMessage();
                            SmtpClient SmtpServer = new SmtpClient(ISA.AutoSynch.Properties.Settings.Default.smtp);


                            mail.From = new MailAddress(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                            mail.To.Add(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                            mail.Subject = "Error AutoSynch Cabang " + Gudang;
                            StringBuilder sbErrorMessage = new StringBuilder();

                            mail.Body = "Error dalam download  Koreksi Pembelian  Cabang : " + Gudang + " Pada Tanggal :" + DateTime.Now;
                            mail.Body = mail.Body + " === EX Message : " + ex.Message;


                            SmtpServer.Port = 26;
                            SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.AutoSynch.Properties.Settings.Default.smtplogin, ISA.AutoSynch.Properties.Settings.Default.smtppassword);
                            SmtpServer.EnableSsl = false;

                            SmtpServer.Send(mail);
                            // MessageBox.Show("Error dalam download INPMAN Cabang : " + Gudang + "Sudah Dikirim Ke Email", "Informasi");
                        }
                        catch
                        {
                            Error.LogError(ex);
                            MessageBox.Show("Error dalam kirim pesan errorlog ke email pada proses download Koreksi Pembelian Cabang : " + Gudang);
                        }
                    }
                }
                
                
                hitungdownload = 3600;
                pictureBox3.Visible = false;
            }


        }

        private void INSERTKORPJ(String gudangid)
        {


            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            String myStream = @"C:\Temp\FTP\DOWNLOAD\" +"KoreksiJual.XML";
            ds.ReadXml(myStream);
            dt = ds.Tables["KOREKSIJUAL"];

            using (Database db = new Database())
            {
               
                foreach (DataRow dr in dt.Rows)
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_KoreksiPembelian_DOWNLOAD"));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["id_koreksi"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@NotaBeliDetailRecID", SqlDbType.VarChar, Tools.isNull(dr["id_detail"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglKoreksi", SqlDbType.DateTime, Tools.isNull(dr["tglkoreksi"], DBNull.Value)));
                    db.Commands[0].Parameters.Add(new Parameter("@NoKoreksi", SqlDbType.VarChar, (Tools.isNull(dr["no_koreksi"], "").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, (Tools.isNull(dr["kode_brg"], "").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@QtyNotaBaru", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_nota"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@HrgBeliBaru", SqlDbType.Money, double.Parse(Tools.isNull(dr["H_jual"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Pemasok", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Sumber", SqlDbType.VarChar, "NPB"));//(Tools.isNull(dr["sumber"], "NPB").ToString().Trim())    ));
                    db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, ""));//Tools.isNull(dr["dt_link"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@HrgBeliKoreksi", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_koreksi"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@QtyNotaKoreksi", SqlDbType.Int, 0));//int.Parse(Tools.isNull(dr["n_koreksi"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "AUTOSYNCH"));
                    db.Commands[0].ExecuteNonQuery();

                }

            }
        }



        private void InsertJadwalEx(String gudangid)
        {


            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            String myStream = @"C:\Temp\FTP\DOWNLOAD\" + "JadwalExpedisi.XML";
            ds.ReadXml(myStream);
            dt = ds.Tables["JadwalExpedisi"];

            using (Database db = new Database())
            {

                foreach (DataRow dr in dt.Rows)
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("psp_JadwalExpedisi_AutoDownload"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, new Guid(dr["RowID"].ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, dr["CabangID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, dr["Periode"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NoPeriode", SqlDbType.SmallInt, dr["NoPeriode"]));
                    db.Commands[0].Parameters.Add(new Parameter("@DateFromOrder", SqlDbType.Date, dr["DateFromOrder"]));
                    db.Commands[0].Parameters.Add(new Parameter("@DateToOrder", SqlDbType.Date, dr["DateToOrder"]));
                    db.Commands[0].Parameters.Add(new Parameter("@DateFromExpedisi", SqlDbType.Date, dr["DateFromExpedisi"]));
                    db.Commands[0].Parameters.Add(new Parameter("@DateToExpedisi", SqlDbType.Date, dr["DateToExpedisi"]));
                    db.Commands[0].Parameters.Add(new Parameter("@SynchFlag", SqlDbType.Bit, dr["SynchFlag"]));
                   
                    db.Commands[0].ExecuteNonQuery();

                }

            }
        }



        private void updateStatusKorPJ()
        {
            using (Database db = new Database())
            {

                db.BeginTransaction();

                db.Commands.Add(db.CreateCommand("usp_AutoSynchLogDownload_StatusUpdate"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, activeSynchLogRowIDKorPJ));
                db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.Int, 3));
                db.Commands[0].Parameters.Add(new Parameter("@UploadDownload", SqlDbType.VarChar, "Download"));

                db.Commands[0].ExecuteNonQuery();

                db.CommitTransaction();
            }
        }

        private void updateStatusJadwalEx()
        {
            using (Database db = new Database())
            {

                db.BeginTransaction();

                db.Commands.Add(db.CreateCommand("usp_AutoSynchLogDownload_StatusUpdate"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, activeSynchLogRowIDJadwalEx));
                db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.Int, 3));
                db.Commands[0].Parameters.Add(new Parameter("@UploadDownload", SqlDbType.VarChar, "Download"));

                db.Commands[0].ExecuteNonQuery();

                db.CommitTransaction();
            }
        }

        private void DeleteKorPJ(String gudangid)
        {
            string fileName = "KoreksiJual" + gudangid + ".zip";

            FtpWebRequest requestFileDelete = (FtpWebRequest)WebRequest.Create("ftp://117.20.56.212/" + gudangid + "/inbox/" + fileName);
            requestFileDelete.Credentials = new NetworkCredential("isadev", "isadev");
            requestFileDelete.Method = WebRequestMethods.Ftp.DeleteFile;

            FtpWebResponse responseFileDelete = (FtpWebResponse)requestFileDelete.GetResponse();
        }

        private void DeleteJadwalEx(String gudangid)
        {
            string fileName = "JadwalExpedisi" + gudangid + ".zip";

            FtpWebRequest requestFileDelete = (FtpWebRequest)WebRequest.Create("ftp://117.20.56.212/" + gudangid + "/inbox/" + fileName);
            requestFileDelete.Credentials = new NetworkCredential("isadev", "isadev");
            requestFileDelete.Method = WebRequestMethods.Ftp.DeleteFile;

            FtpWebResponse responseFileDelete = (FtpWebResponse)requestFileDelete.GetResponse();
        }


        private void UnzipKorPJ(String gudangid)
        {
            string FilePath = @"C:\Temp\FTP\DOWNLOAD\" +  "KoreksiJual" + gudangid + ".zip";
            string FileTarget = @"C:\Temp\FTP\DOWNLOAD\";
            // Opens existing zip file
            ZipStorer zip = ZipStorer.Open(FilePath, FileAccess.Read);
            
            // Read all directory contents
            List<ZipStorer.ZipFileEntry> dir = zip.ReadCentralDir();

            // Extract all files in target directory
            string path;
            bool result;
            foreach (ZipStorer.ZipFileEntry entry in dir)
            {
                path = Path.Combine(FileTarget, Path.GetFileName(entry.FilenameInZip));
                result = zip.ExtractFile(entry, path);
            }
            zip.Close();

        }

        private void UnzipJadwalEx(String gudangid)
        {
            string FilePath = @"C:\Temp\FTP\DOWNLOAD\" + "JadwalExpedisi" + gudangid + ".zip";
            string FileTarget = @"C:\Temp\FTP\DOWNLOAD\";
            // Opens existing zip file
            ZipStorer zip = ZipStorer.Open(FilePath, FileAccess.Read);

            // Read all directory contents
            List<ZipStorer.ZipFileEntry> dir = zip.ReadCentralDir();

            // Extract all files in target directory
            string path;
            bool result;
            foreach (ZipStorer.ZipFileEntry entry in dir)
            {
                path = Path.Combine(FileTarget, Path.GetFileName(entry.FilenameInZip));
                result = zip.ExtractFile(entry, path);
            }
            zip.Close();

        }


        private void InsertSynchLogKorPJ(String gudangid)
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            String myStream = @"C:\Temp\FTP\DOWNLOAD\" + "\\" + "KoreksiJual.XML";

            ds.ReadXml(myStream);
            dt = ds.Tables["AUTOSYNCHLOG"];
            using (Database db = new Database())
            {

                foreach (DataRow dr in dt.Rows)
                {

                    db.Commands.Add(db.CreateCommand("usp_AutoSynchLogDownload_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, new Guid(dr["RowID"].ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@Module", SqlDbType.UniqueIdentifier, new Guid(dr["Module"].ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@Down_Upload", SqlDbType.VarChar, dr["Down_Upload"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglTerakhir", SqlDbType.DateTime, dr["Tglterakhir"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusFileFTP", SqlDbType.Int, dr["StatusFileFTP"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, dr["CreatedBy"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@CreatedOn", SqlDbType.DateTime, dr["CreatedOn"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, dr["LastUpdatedBy"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, dr["LastUpdatedTime"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, dr["Cabang"].ToString()));
                    db.Commands[0].ExecuteNonQuery();

                    activeSynchLogRowIDKorPJ = new Guid(ds.Tables["AUTOSYNCHLOG"].Rows[0]["RowID"].ToString());
                }
            }
        }

        private void InsertSynchLogJadwalEx(String gudangid)
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            String myStream = @"C:\Temp\FTP\DOWNLOAD\" + "\\" + "JadwalExpedisi.XML";

            ds.ReadXml(myStream);
            dt = ds.Tables["AUTOSYNCHLOG"];
            using (Database db = new Database())
            {

                foreach (DataRow dr in dt.Rows)
                {

                    db.Commands.Add(db.CreateCommand("usp_AutoSynchLogDownload_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, new Guid(dr["RowID"].ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@Module", SqlDbType.UniqueIdentifier, new Guid(dr["Module"].ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@Down_Upload", SqlDbType.VarChar, dr["Down_Upload"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglTerakhir", SqlDbType.DateTime, dr["Tglterakhir"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusFileFTP", SqlDbType.Int, dr["StatusFileFTP"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, dr["CreatedBy"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@CreatedOn", SqlDbType.DateTime, dr["CreatedOn"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, dr["LastUpdatedBy"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, dr["LastUpdatedTime"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, dr["Cabang"].ToString()));

                    db.Commands[0].ExecuteNonQuery();

                    activeSynchLogRowIDJadwalEx = new Guid(ds.Tables["AUTOSYNCHLOG"].Rows[0]["RowID"].ToString());
                }
            }
        }



        private bool DownloadKorPJ(String gudangid)
        {

            string inputfilepath = @"C:\Temp\FTP\DOWNLOAD\" + "KoreksiJual" + gudangid + ".zip";

            string ftpfullpath = "ftp://117.20.56.212/" + gudangid + "/inbox/" + "KoreksiJual" + gudangid + ".zip";
            WebClient request = new WebClient();
            request.Credentials = new NetworkCredential("isadev", "isadev");


            try
            {
                byte[] fileData = request.DownloadData(ftpfullpath);
                FileStream file = File.Create(inputfilepath);
                file.Write(fileData, 0, fileData.Length);
                file.Close();
                return true;
            }
            catch
            {
                return false;
            }
 
        }

        private bool DownloadJadwalEx(String gudangid)
        {

            string inputfilepath = @"C:\Temp\FTP\DOWNLOAD\" + "JadwalExpedisi" + gudangid + ".zip";

            string ftpfullpath = "ftp://117.20.56.212/" + gudangid + "/inbox/" + "JadwalExpedisi" + gudangid + ".zip";
            WebClient request = new WebClient();
            request.Credentials = new NetworkCredential("isadev", "isadev");


            try
            {
                byte[] fileData = request.DownloadData(ftpfullpath);
                FileStream file = File.Create(inputfilepath);
                file.Write(fileData, 0, fileData.Length);
                file.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }


        private void cekdownload_Click(object sender, EventArgs e)
        {

        }

        private void timerJadwalEx_Tick(object sender, EventArgs e)
        {
            DateTime jamJadwalEx = DateTime.Now;

            DataTable dtgudang = new DataTable();



                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_kodeperusahaan_LIST"));
                    dtgudang = db.Commands[0].ExecuteDataTable();
                }
                String Gudang = Tools.isNull(dtgudang.Rows[0]["initgudang"], 0).ToString();

                hitungJadwalEx--;
                lblJadwalEx.Text = "Cek Download Jadwal Expedisi Berjalan Dalam Hitungan Mundur : " + hitungJadwalEx + " detik";

                if (hitungJadwalEx == 0)
                {
                    pictureBox3.Visible = true;
                    bool fDwnJadwalExSuccess = DownloadJadwalEx(Gudang);
                    if (fDwnJadwalExSuccess == true)
                    {
                        try
                        {
                            String FileZip = @"C:\Temp\FTP\DOWNLOAD\" + "JadwalExpedisi" + Gudang + ".zip";
                            String FileXml = @"C:\Temp\FTP\DOWNLOAD\" + "JadwalExpedisi.XML";

                            UnzipJadwalEx(Gudang);
                            InsertJadwalEx(Gudang);
                            InsertSynchLogJadwalEx(Gudang);

                            updateStatusJadwalEx();
                            DeleteJadwalEx(Gudang);
                            File.Delete(FileZip);
                            File.Delete(FileXml);
                        }
                        catch (System.Exception ex)
                        {
                            try
                            {
                                MailMessage mail = new MailMessage();
                                SmtpClient SmtpServer = new SmtpClient(ISA.AutoSynch.Properties.Settings.Default.smtp);


                                mail.From = new MailAddress(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                mail.To.Add(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                mail.Subject = "Error AutoSynch Cabang " + Gudang;
                                StringBuilder sbErrorMessage = new StringBuilder();

                                mail.Body = "Error dalam download  Jadwal Expedisi  Cabang : " + Gudang + " Pada Tanggal :" + DateTime.Now;
                                mail.Body = mail.Body + " === EX Message : " + ex.Message;


                                SmtpServer.Port = 26;
                                SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.AutoSynch.Properties.Settings.Default.smtplogin, ISA.AutoSynch.Properties.Settings.Default.smtppassword);
                                SmtpServer.EnableSsl = false;

                                SmtpServer.Send(mail);
                                // MessageBox.Show("Error dalam download INPMAN Cabang : " + Gudang + "Sudah Dikirim Ke Email", "Informasi");
                            }
                            catch
                            {
                                Error.LogError(ex);
                                MessageBox.Show("Error dalam kirim pesan errorlog ke email pada proses download Jadwal Expedisi Cabang : " + Gudang);
                            }

                        }

                    }
                    

                    hitungJadwalEx = 1000;
                    pictureBox3.Visible = false;
                }
            }

        private void timermonitoring_Tick(object sender, EventArgs e)
        {
            
            hitungmonitoring--;
           
            if (hitungmonitoring ==0)
                {
                    try
                    {
                        String kode = txttarget.Text;
                        String nama = System.Environment.MachineName;
                        String user = "dotnet11";
                        String pass = "kikakikuk";


                        Service1SoapClient Insert = new Service1SoapClient();

                        Insert.InsertMonitoring(kode, nama, user, pass);
                    }
                    catch (System.Exception ex)
                    {
                        try
                        {
                            MailMessage mail = new MailMessage();
                            SmtpClient SmtpServer = new SmtpClient(ISA.AutoSynch.Properties.Settings.Default.smtp);


                            mail.From = new MailAddress(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                            mail.To.Add(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                            mail.Subject = "Error AutoSynch Cabang " + txttarget.Text;
                            StringBuilder sbErrorMessage = new StringBuilder();

                            mail.Body = "Error dalam Send Monitoring Program: " + txttarget.Text + " Pada Tanggal :" + DateTime.Now;
                            mail.Body = mail.Body + " === EX Message : " + ex.Message;


                            SmtpServer.Port = 26;
                            SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.AutoSynch.Properties.Settings.Default.smtplogin, ISA.AutoSynch.Properties.Settings.Default.smtppassword);
                            SmtpServer.EnableSsl = false;

                            SmtpServer.Send(mail);

                        }
                        catch
                        {
                            Error.LogError(ex);
                            MessageBox.Show("Error dalam kirim pesan errorlog ke email pada proses Send Monitoring Program : " + txttarget.Text);
                        }
                    }

                   hitungmonitoring = 900; //15 menit
            }
        }

        private void timerautoclose_Tick(object sender, EventArgs e)
        {

            waktuminimize--;
            if (waktuminimize == 0)
            {
                this.WindowState = FormWindowState.Minimized;
                timerautoclose.Enabled = false;
            }
        }

        private DataSet GetSyncDataNotaPenjualan()
        {
            DataTable dtjam = new DataTable();
            DataTable dtdetail = new DataTable();
            DataTable dtheader = new DataTable();

            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_GetServerDate"));
                dtjam = db.Commands[0].ExecuteDataTable();
            }

            DateTime jamku = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));        
            DateTime tglawal = jamku.AddDays(-7);
           
            DateTime tglakhir = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));

            
            DataSet dsNotaPenjualan = new DataSet();
            DataTable dt = new DataTable();
            DataTable auto = new DataTable();
            DataSet ds = new DataSet();

            using (Database db = new Database())
            {
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_NotaPenjualanAutosynch_UPLOAD"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, tglawal));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, tglakhir));
                //db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, new DateTime(2012, 08, 01)));
                //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, new DateTime(2012, 08, 07)));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, txttarget.Text.Substring(0, 2)));
                dsNotaPenjualan = db.Commands[0].ExecuteDataSet();
                dsNotaPenjualan.Tables[0].TableName = "NotaPenjualanHeader";
                dsNotaPenjualan.Tables[1].TableName = "NotaPenjualanDetail";

            }


            using (Database db = new Database())
            {
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_AutoSynchLog"));
                auto = db.Commands[0].ExecuteDataTable();
                auto.TableName = "AUTOSYNCHLOG";
                if (auto.Rows.Count > 0)
                {
                    dsNotaPenjualan.Tables.Add(auto);
                    activeSynchLogRowIDNotaPenjualan = new Guid(dsNotaPenjualan.Tables["AUTOSYNCHLOG"].Rows[0]["RowID"].ToString());
                }



            }
            return dsNotaPenjualan;
        }
      


        private void timerNotaPenjualan_Tick(object sender, EventArgs e)
        {
            DateTime jamku = DateTime.Now;
            lbljam.Text = jamku.Hour.ToString();
            lblmenit.Text = jamku.Minute.ToString();
            lbldetik.Text = jamku.Second.ToString();


            hitungnotapenjualan--;
            lblnotapenjualan.Text = "Cek Upload NotaPenjualan Berjalan Dalam Hitungan Mundur :  " + hitungnotapenjualan + " detik";

            
            DateTime tgl = DateTime.Now;
 
            if (hitungnotapenjualan == 0)
            {

                pictureBox3.Visible = true;
                DataTable dtmaster = new DataTable();
                DataTable dtlog = new DataTable();
                DataTable dtjam = new DataTable();

                DataTable dtgudang = new DataTable();

                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_kodeperusahaan_LIST"));
                    dtgudang = db.Commands[0].ExecuteDataTable();
                }
                String Gudang = Tools.isNull(dtgudang.Rows[0]["initgudang"], 0).ToString();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_MasterAutoSynch_LIST"));
                    dtmaster = db.Commands[0].ExecuteDataTable();
                }

                Guid pModuleRowID = (Guid)(dtmaster.Rows[0]["RowID"]);


                if (dtmaster.Rows.Count == 0)
                {
                    MessageBox.Show("Terjadi Kesalahan, Data Master tidak ditemukan");
                }
                else
                {

                    int i;
                    for (i = 0; i <= dtmaster.Rows.Count - 1; i++)
                    {
                        String ModuleName = Tools.isNull(dtmaster.Rows[i]["ModuleName"], 0).ToString();
                        int Frequency = Convert.ToInt32(Tools.isNull(dtmaster.Rows[i]["Frequency"], 0).ToString());

                        using (Database db = new Database())
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_GetServerDate"));
                            dtjam = db.Commands[0].ExecuteDataTable();
                        }

                        DateTime TmpDate = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));
                        using (Database db = new Database())
                        {

                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_AutoSynchLog_filter"));
                            db.Commands[0].Parameters.Add(new Parameter("@Module", SqlDbType.UniqueIdentifier, new Guid(dtmaster.Rows[i]["RowID"].ToString())));
                            dtlog = db.Commands[0].ExecuteDataTable();

                        }

                        
                        DateTime tglawal = TmpDate.AddDays(-7);
                        DateTime tglakhir = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));


                        if (dtlog.Rows.Count != 0)
                        {
                            if ((ModuleName == "NotaPenjualan") && (Convert.ToDateTime(Tools.isNull(dtlog.Rows[0]["Tgl_terakhir"], DateTime.MinValue)).AddMinutes(Frequency) < TmpDate))
                            {
                                DataSet ds = new DataSet();
                                DataTable dtdetail = new DataTable();
                                DataTable dtheader = new DataTable();
                                using (Database db = new Database())
                                {
                                    refreshForm();

                                    db.Commands.Clear();
                                    db.Commands.Add(db.CreateCommand("psp_NotaPenjualanAutosynch_UPLOAD"));
                                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, tglawal));
                                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, tglakhir));
                                    //db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, new DateTime(2012, 08, 01)));
                                    //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, new DateTime(2012, 08, 07)));
                                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, txttarget.Text.Substring(0,2)));
                                    ds = db.Commands[0].ExecuteDataSet();
                                    dtheader = ds.Tables[0];
                                }
                                if (dtheader.Rows.Count > 0)
                                {
                                    try
                                    {
                                        List<string> filesNotaPenjualan = new List<string>();

                                        insertAutoSynchLog(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang);

                                        DataSet dsNotaPenjualan = GetSyncDataNotaPenjualan();

                                        string Target = txttarget.Text;
                                        string fileOuput = FtpEngine.UploadDirectory + "\\" + "NOTAPENJUALANFTP" + ".xml";
                                        dsNotaPenjualan.WriteXml(fileOuput);

                                        filesNotaPenjualan.Add(fileOuput);
                                        ZipFileNotaPenjualan(filesNotaPenjualan);

                                        string FTPName = "ftp://117.20.56.212/" + Gudang + "/outbox/";
                                        string FilePath = @"C:\Temp\FTP\UPLOAD\" + "NOTAPENJUALANFTP.zip";
                                        string Username = "isadev";
                                        string Pass = "isadev";

                                        uploadFile(FTPName, FilePath, Username, Pass);
                                        updateStatusFTP();

                                        File.Delete(FilePath);


                                        lblprogress.Text = "";
                                    }
                                    catch (System.Exception ex)
                                    {
                                        try
                                        {
                                            MailMessage mail = new MailMessage();
                                            SmtpClient SmtpServer = new SmtpClient(ISA.AutoSynch.Properties.Settings.Default.smtp);


                                            mail.From = new MailAddress(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                            mail.To.Add(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                            mail.Subject = "Error AutoSynch Cabang " + Gudang;
                                            StringBuilder sbErrorMessage = new StringBuilder();

                                            mail.Body = "Error dalam upload NotaPenjualan Cabang : " + Gudang + " Pada Tanggal :" + DateTime.Now;
                                            mail.Body = mail.Body + " === EX Message : " + ex.Message;


                                            SmtpServer.Port = 26;
                                            SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.AutoSynch.Properties.Settings.Default.smtplogin, ISA.AutoSynch.Properties.Settings.Default.smtppassword);
                                            SmtpServer.EnableSsl = false;

                                            SmtpServer.Send(mail);
                                            // MessageBox.Show("Error dalam download INPMAN Cabang : " + Gudang + "Sudah Dikirim Ke Email", "Informasi");
                                        }
                                        catch
                                        {
                                            Error.LogError(ex);
                                            MessageBox.Show("Error dalam kirim pesan errorlog ke email pada proses upload Nota Penjualan Cabang : " + Gudang);
                                        }

                                    }
                                }

                                else { insertAutoSynchLogKosong(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang); }


                            }
                        }

                        else
                        {
                          if (ModuleName == "NotaPenjualan")
                            {
                                DataSet ds = new DataSet();
                                DataTable dtdetail = new DataTable();
                                DataTable dtheader = new DataTable();
                                using (Database db = new Database())
                                {
                                    refreshForm();

                                    db.Commands.Clear();
                                    db.Commands.Add(db.CreateCommand("psp_NotaPenjualanAutosynch_UPLOAD"));
                                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, tglawal));
                                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, tglakhir));
                                    //db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, new DateTime(2012, 08, 01)));
                                    //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, new DateTime(2012, 08, 07)));
                                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, txttarget.Text.Substring(0, 2)));
                                    ds = db.Commands[0].ExecuteDataSet();
                                    dtheader = ds.Tables[0];
                                }
                                if (dtheader.Rows.Count > 0)
                                {
                                    try
                                    {
                                        List<string> filesNotaPenjualan = new List<string>();

                                        insertAutoSynchLog(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang);

                                        DataSet dsNotaPenjualan = GetSyncDataNotaPenjualan();

                                        string Target = txttarget.Text;
                                        string fileOuput = FtpEngine.UploadDirectory + "\\" + "NOTAPENJUALANFTP" + ".xml";
                                        dsNotaPenjualan.WriteXml(fileOuput);

                                        filesNotaPenjualan.Add(fileOuput);
                                        ZipFileNotaPenjualan(filesNotaPenjualan);

                                        string FTPName = "ftp://117.20.56.212/" + Gudang + "/outbox/";
                                        string FilePath = @"C:\Temp\FTP\UPLOAD\" + "NOTAPENJUALANFTP.zip";
                                        string Username = "isadev";
                                        string Pass = "isadev";

                                        uploadFile(FTPName, FilePath, Username, Pass);
                                        updateStatusFTP();

                                        File.Delete(FilePath);


                                        lblprogress.Text = "";
                                    }
                                    catch (System.Exception ex)
                                    {
                                        try
                                        {
                                            MailMessage mail = new MailMessage();
                                            SmtpClient SmtpServer = new SmtpClient(ISA.AutoSynch.Properties.Settings.Default.smtp);


                                            mail.From = new MailAddress(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                            mail.To.Add(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                            mail.Subject = "Error AutoSynch Cabang " + Gudang;
                                            StringBuilder sbErrorMessage = new StringBuilder();

                                            mail.Body = "Error dalam upload NotaPenjualan Cabang : " + Gudang + " Pada Tanggal :" + DateTime.Now;
                                            mail.Body = mail.Body + " === EX Message : " + ex.Message;


                                            SmtpServer.Port = 26;
                                            SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.AutoSynch.Properties.Settings.Default.smtplogin, ISA.AutoSynch.Properties.Settings.Default.smtppassword);
                                            SmtpServer.EnableSsl = false;

                                            SmtpServer.Send(mail);
                                            // MessageBox.Show("Error dalam download INPMAN Cabang : " + Gudang + "Sudah Dikirim Ke Email", "Informasi");
                                        }
                                        catch
                                        {
                                            Error.LogError(ex);
                                            MessageBox.Show("Error dalam kirim pesan errorlog ke email pada proses upload Nota Penjualan Cabang : " + Gudang);
                                        }

                                    }
                                }

                                else { insertAutoSynchLogKosong(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang); }


                            }




                        }
                    }
                }
                hitungnotapenjualan = 1500; // 15menit
                pictureBox3.Visible = false;
            }


        }

        private void timerHPPA_Tick(object sender, EventArgs e)
        {
            DateTime jamku = DateTime.Now;
            lbljam.Text = jamku.Hour.ToString();
            lblmenit.Text = jamku.Minute.ToString();
            lbldetik.Text = jamku.Second.ToString();


            hitungHPPA--;
            lblHPPA.Text = "Cek Upload HPPA Berjalan Dalam Hitungan Mundur :  " + hitungHPPA + " detik";


            DateTime tgl = DateTime.Now;

            if (hitungHPPA == 0)
            {

                pictureBox3.Visible = true;
                DataTable dtmaster = new DataTable();
                DataTable dtlog = new DataTable();
                DataTable dtjam = new DataTable();

                DataTable dtgudang = new DataTable();

                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_kodeperusahaan_LIST"));
                    dtgudang = db.Commands[0].ExecuteDataTable();
                }
                String Gudang = Tools.isNull(dtgudang.Rows[0]["initgudang"], 0).ToString();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_MasterAutoSynch_LIST"));
                    dtmaster = db.Commands[0].ExecuteDataTable();
                }

                Guid pModuleRowID = (Guid)(dtmaster.Rows[0]["RowID"]);


                if (dtmaster.Rows.Count == 0)
                {
                    MessageBox.Show("Terjadi Kesalahan, Data Master tidak ditemukan");
                }
                else
                {

                    int i;
                    for (i = 0; i <= dtmaster.Rows.Count - 1; i++)
                    {
                        String ModuleName = Tools.isNull(dtmaster.Rows[i]["ModuleName"], 0).ToString();
                        int Frequency = Convert.ToInt32(Tools.isNull(dtmaster.Rows[i]["Frequency"], 0).ToString());

                        using (Database db = new Database())
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_GetServerDate"));
                            dtjam = db.Commands[0].ExecuteDataTable();
                        }

                        DateTime TmpDate = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));
                        using (Database db = new Database())
                        {

                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_AutoSynchLog_filter"));
                            db.Commands[0].Parameters.Add(new Parameter("@Module", SqlDbType.UniqueIdentifier, new Guid(dtmaster.Rows[i]["RowID"].ToString())));
                            dtlog = db.Commands[0].ExecuteDataTable();

                        }

                        DateTime tglakhir = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));


                        if (dtlog.Rows.Count != 0)
                        {
                            if ((ModuleName == "HPPA") && (Convert.ToDateTime(Tools.isNull(dtlog.Rows[0]["Tgl_terakhir"], DateTime.MinValue)).AddMinutes(Frequency) < TmpDate))
                            {
                                DataSet ds = new DataSet();
                                DataTable dthppa = new DataTable();
                                
                                using (Database db = new Database())
                                {
                                    refreshForm();

                                    db.Commands.Clear();
                                    db.Commands.Add(db.CreateCommand("psp_UPLOAD_HistoryHPPA_AutoSynch"));
                                    db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.DateTime, tglakhir));
                                    // db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.DateTime, new DateTime(2010,10,01)));
                                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, txttarget.Text));
                                    ds = db.Commands[0].ExecuteDataSet();
                                    dthppa = ds.Tables[0];
                                }
                                if (dthppa.Rows.Count > 0)
                                {
                                    try
                                    {
                                        List<string> filesHPPA = new List<string>();

                                        insertAutoSynchLog(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang);

                                        DataSet dsHPPA = GetSyncDataHPPA();

                                        string Target = txttarget.Text;
                                        string fileOuput = FtpEngine.UploadDirectory + "\\" + "HPPAFTP" + ".xml";
                                        dsHPPA.WriteXml(fileOuput);

                                        filesHPPA.Add(fileOuput);
                                        ZipFileHPPA(filesHPPA);

                                        string FTPName = "ftp://117.20.56.212/" + Gudang + "/outbox/";
                                        string FilePath = @"C:\Temp\FTP\UPLOAD\" + "HPPAFTP.zip";
                                        string Username = "isadev";
                                        string Pass = "isadev";

                                        uploadFile(FTPName, FilePath, Username, Pass);
                                        updateStatusFTP();

                                        File.Delete(FilePath);
                                        lblprogress.Text = "";
                                    }
                                    catch (System.Exception ex)
                                    {
                                        try
                                        {
                                            MailMessage mail = new MailMessage();
                                            SmtpClient SmtpServer = new SmtpClient(ISA.AutoSynch.Properties.Settings.Default.smtp);


                                            mail.From = new MailAddress(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                            mail.To.Add(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                            mail.Subject = "Error AutoSynch Cabang " + Gudang;
                                            StringBuilder sbErrorMessage = new StringBuilder();

                                            mail.Body = "Error dalam upload HPPA Cabang : " + Gudang + " Pada Tanggal :" + DateTime.Now;
                                            mail.Body = mail.Body + " === EX Message : " + ex.Message;


                                            SmtpServer.Port = 26;
                                            SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.AutoSynch.Properties.Settings.Default.smtplogin, ISA.AutoSynch.Properties.Settings.Default.smtppassword);
                                            SmtpServer.EnableSsl = false;

                                            SmtpServer.Send(mail);
                                            
                                        }
                                        catch
                                        {
                                            Error.LogError(ex);
                                            MessageBox.Show("Error dalam kirim pesan errorlog ke email pada proses upload HPPA Cabang : " + Gudang);
                                        }

                                    }
                                }

                                else { insertAutoSynchLogKosong(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang); }


                            }
                        }

                        else
                        {
                            {
                                DataSet ds = new DataSet();
                                DataTable dthppa = new DataTable();

                                using (Database db = new Database())
                                {
                                    refreshForm();

                                    db.Commands.Clear();
                                    db.Commands.Add(db.CreateCommand("[psp_UPLOAD_HistoryHPPA_AutoSynch]"));
                                    db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.DateTime, tglakhir));
                               //     db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.DateTime, new DateTime(2010, 10, 01)));
                                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, txttarget.Text));
                                    ds = db.Commands[0].ExecuteDataSet();
                                    dthppa = ds.Tables[0];
                                }
                                if (dthppa.Rows.Count > 0)
                                {
                                    try
                                    {
                                        List<string> filesHPPA = new List<string>();

                                        insertAutoSynchLog(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang);

                                        DataSet dsHPPA = GetSyncDataHPPA();

                                        string Target = txttarget.Text;
                                        string fileOuput = FtpEngine.UploadDirectory + "\\" + "HPPAFTP" + ".xml";
                                        dsHPPA.WriteXml(fileOuput);

                                        filesHPPA.Add(fileOuput);
                                        ZipFileHPPA(filesHPPA);

                                        string FTPName = "ftp://117.20.56.212/" + Gudang + "/outbox/";
                                        string FilePath = @"C:\Temp\FTP\UPLOAD\" + "HPPAFTP.zip";
                                        string Username = "isadev";
                                        string Pass = "isadev";

                                        uploadFile(FTPName, FilePath, Username, Pass);
                                        updateStatusFTP();

                                        File.Delete(FilePath);


                                        lblprogress.Text = "";
                                    }
                                    catch (System.Exception ex)
                                    {
                                        try
                                        {
                                            MailMessage mail = new MailMessage();
                                            SmtpClient SmtpServer = new SmtpClient(ISA.AutoSynch.Properties.Settings.Default.smtp);


                                            mail.From = new MailAddress(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                            mail.To.Add(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                            mail.Subject = "Error AutoSynch Cabang " + Gudang;
                                            StringBuilder sbErrorMessage = new StringBuilder();

                                            mail.Body = "Error dalam upload HPPA Cabang : " + Gudang + " Pada Tanggal :" + DateTime.Now;
                                            mail.Body = mail.Body + " === EX Message : " + ex.Message;


                                            SmtpServer.Port = 26;
                                            SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.AutoSynch.Properties.Settings.Default.smtplogin, ISA.AutoSynch.Properties.Settings.Default.smtppassword);
                                            SmtpServer.EnableSsl = false;

                                            SmtpServer.Send(mail);

                                        }
                                        catch
                                        {
                                            Error.LogError(ex);
                                            MessageBox.Show("Error dalam kirim pesan errorlog ke email pada proses upload HPPA Cabang : " + Gudang);
                                        }

                                    }
                                }

                                else { insertAutoSynchLogKosong(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang); }


                            }

                        }
                    }
                }
                hitungHPPA = 2500; // 15menit
                pictureBox3.Visible = false;
            }
        }

        private void cekupload_Click(object sender, EventArgs e)
        {

        }

        private void timerJournal_Tick(object sender, EventArgs e)
        {
            {
                DateTime jamku = DateTime.Now;
                lbljam.Text = jamku.Hour.ToString();
                lblmenit.Text = jamku.Minute.ToString();
                lbldetik.Text = jamku.Second.ToString();

                hitungJournal--;
                journal.Text = "Cek Upload Journal Berjalan Dalam Hitungan Mundur :  " + hitungJournal + " detik";

                DateTime tgl = DateTime.Now;

                if (hitungJournal == 0)
                {

                    pictureBox3.Visible = true;
                    DataTable dtmaster = new DataTable();
                    DataTable dtlog = new DataTable();
                    DataTable dtjam = new DataTable();

                    DataTable dtgudang = new DataTable();

                    using (Database db = new Database())
                    {

                        db.Commands.Add(db.CreateCommand("usp_kodeperusahaan_LIST"));
                        dtgudang = db.Commands[0].ExecuteDataTable();
                    }
                    String Gudang = Tools.isNull(dtgudang.Rows[0]["initgudang"], 0).ToString();

                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_MasterAutoSynch_LIST"));
                        dtmaster = db.Commands[0].ExecuteDataTable();
                    }

                    Guid pModuleRowID = (Guid)(dtmaster.Rows[0]["RowID"]);


                    if (dtmaster.Rows.Count == 0)
                    {
                        MessageBox.Show("Terjadi Kesalahan, Data Master tidak ditemukan");
                    }
                    else
                    {

                        int i;
                        for (i = 0; i <= dtmaster.Rows.Count - 1; i++)
                        {
                            String ModuleName = Tools.isNull(dtmaster.Rows[i]["ModuleName"], 0).ToString();
                            int Frequency = Convert.ToInt32(Tools.isNull(dtmaster.Rows[i]["Frequency"], 0).ToString());

                            using (Database db = new Database())
                            {
                                db.Commands.Clear();
                                db.Commands.Add(db.CreateCommand("usp_GetServerDate"));
                                dtjam = db.Commands[0].ExecuteDataTable();
                            }

                            DateTime TmpDate = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));
                            using (Database db = new Database())
                            {

                                db.Commands.Clear();
                                db.Commands.Add(db.CreateCommand("usp_AutoSynchLog_filter"));
                                db.Commands[0].Parameters.Add(new Parameter("@Module", SqlDbType.UniqueIdentifier, new Guid(dtmaster.Rows[i]["RowID"].ToString())));
                                dtlog = db.Commands[0].ExecuteDataTable();

                            }

                            DateTime tglakhir = Convert.ToDateTime(Tools.isNull(dtjam.Rows[0]["Tanggal"], DateTime.MinValue));
                            DateTime tglawal = tglakhir.AddDays(-5);

                            if (dtlog.Rows.Count != 0)
                            {
                                if ((ModuleName == "Journal") && (Convert.ToDateTime(Tools.isNull(dtlog.Rows[0]["Tgl_terakhir"], DateTime.MinValue)).AddMinutes(Frequency) < TmpDate))
                                {
                                    DataSet ds = new DataSet();
                                    DataTable dtdetail = new DataTable();
                                    DataTable dtheader = new DataTable();
                                    using (Database db = new Database("ISAFinance"))
                                    {
                                        refreshForm();

                                        db.Commands.Clear();
                                        db.Commands.Add(db.CreateCommand("psp_GL_UPLOAD_Journal"));
                                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, tglawal));
                                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, tglakhir));
                                        //db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, new DateTime(2010, 10, 01)));
                                        //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, new DateTime(2010, 10, 15)));
                                        ds = db.Commands[0].ExecuteDataSet(); 
                                        dtheader = ds.Tables[0];
                                    }
                                    if (dtheader.Rows.Count > 0)
                                    {
                                        try
                                        {
                                            List<string> filesJournal = new List<string>();

                                            insertAutoSynchLog(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang);

                                            DataSet dsJournal = GetSyncDataJournal();

                                            string Target = txttarget.Text;
                                            string fileOuput = FtpEngine.UploadDirectory + "\\" + "JOURNALFTP" + ".xml";
                                            dsJournal.WriteXml(fileOuput);

                                            filesJournal.Add(fileOuput);
                                            ZipFileJournal(filesJournal);

                                            string FTPName = "ftp://117.20.56.212/" + Gudang + "/outbox/";
                                            string FilePath = @"C:\Temp\FTP\UPLOAD\" + "JOURNALFTP.zip";
                                            string Username = "isadev";
                                            string Pass = "isadev";

                                            uploadFile(FTPName, FilePath, Username, Pass);
                                            updateStatusFTP();

                                            File.Delete(FilePath);


                                            lblprogress.Text = "";
                                        }
                                        catch (System.Exception ex)
                                        {
                                            try
                                            {
                                                MailMessage mail = new MailMessage();
                                                SmtpClient SmtpServer = new SmtpClient(ISA.AutoSynch.Properties.Settings.Default.smtp);


                                                mail.From = new MailAddress(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                                mail.To.Add(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                                mail.Subject = "Error AutoSynch Cabang " + Gudang;
                                                StringBuilder sbErrorMessage = new StringBuilder();

                                                mail.Body = "Error dalam upload Journal Cabang : " + Gudang + " Pada Tanggal :" + DateTime.Now;
                                                mail.Body = mail.Body + " === EX Message : " + ex.Message;


                                                SmtpServer.Port = 26;
                                                SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.AutoSynch.Properties.Settings.Default.smtplogin, ISA.AutoSynch.Properties.Settings.Default.smtppassword);
                                                SmtpServer.EnableSsl = false;

                                                SmtpServer.Send(mail);
                                                // MessageBox.Show("Error dalam download INPMAN Cabang : " + Gudang + "Sudah Dikirim Ke Email", "Informasi");
                                            }
                                            catch
                                            {
                                                Error.LogError(ex);
                                                MessageBox.Show("Error dalam kirim pesan errorlog ke email pada proses upload Nota Penjualan Cabang : " + Gudang);
                                            }

                                        }
                                    }

                                    else { insertAutoSynchLogKosong(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang); }


                                }
                            }

                            else
                            {
                                if (ModuleName == "Journal")
                                {
                                    DataSet ds = new DataSet();
                                    DataTable dtdetail = new DataTable();
                                    DataTable dtheader = new DataTable();
                                    using (Database db = new Database("ISAFinance"))
                                    {
                                        refreshForm();

                                        db.Commands.Clear();
                                        db.Commands.Add(db.CreateCommand("psp_GL_UPLOAD_Journal"));
                                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, tglawal));
                                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, tglakhir));
                                        //db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, new DateTime(2010, 10, 01)));
                                        //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, new DateTime(2010, 10, 15)));
                                        ds = db.Commands[0].ExecuteDataSet();
                                        dtheader = ds.Tables[0];
                                    }
                                    if (dtheader.Rows.Count > 0)
                                    {
                                        try
                                        {
                                            List<string> filesJournal = new List<string>();

                                            insertAutoSynchLog(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang);

                                            DataSet dsJournal = GetSyncDataJournal();

                                            string Target = txttarget.Text;
                                            string fileOuput = FtpEngine.UploadDirectory + "\\" + "JOURNALFTP" + ".xml";
                                            dsJournal.WriteXml(fileOuput);

                                            filesJournal.Add(fileOuput);
                                            ZipFileJournal(filesJournal);

                                            string FTPName = "ftp://117.20.56.212/" + Gudang + "/outbox/";
                                            string FilePath = @"C:\Temp\FTP\UPLOAD\" + "JOURNALFTP.zip";
                                            string Username = "isadev";
                                            string Pass = "isadev";

                                            uploadFile(FTPName, FilePath, Username, Pass);
                                            updateStatusFTP();

                                            File.Delete(FilePath);


                                            lblprogress.Text = "";
                                        }
                                        catch (System.Exception ex)
                                        {
                                            try
                                            {
                                                MailMessage mail = new MailMessage();
                                                SmtpClient SmtpServer = new SmtpClient(ISA.AutoSynch.Properties.Settings.Default.smtp);


                                                mail.From = new MailAddress(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                                mail.To.Add(ISA.AutoSynch.Properties.Settings.Default.smtplogin);
                                                mail.Subject = "Error AutoSynch Cabang " + Gudang;
                                                StringBuilder sbErrorMessage = new StringBuilder();

                                                mail.Body = "Error dalam upload Journal Cabang : " + Gudang + " Pada Tanggal :" + DateTime.Now;
                                                mail.Body = mail.Body + " === EX Message : " + ex.Message;


                                                SmtpServer.Port = 26;
                                                SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.AutoSynch.Properties.Settings.Default.smtplogin, ISA.AutoSynch.Properties.Settings.Default.smtppassword);
                                                SmtpServer.EnableSsl = false;

                                                SmtpServer.Send(mail);
                                                // MessageBox.Show("Error dalam download INPMAN Cabang : " + Gudang + "Sudah Dikirim Ke Email", "Informasi");
                                            }
                                            catch
                                            {
                                                Error.LogError(ex);
                                                MessageBox.Show("Error dalam kirim pesan errorlog ke email pada proses upload Nota Penjualan Cabang : " + Gudang);
                                            }

                                        }
                                    }

                                    else { insertAutoSynchLogKosong(new Guid(dtmaster.Rows[i]["RowID"].ToString()), Gudang); }


                                }




                            }
                        }
                    }
                    hitungJournal = 2250; // 15menit
                    pictureBox3.Visible = false;
                }


            }
        }

        //upload SetoranFmApl
        private void Upload1(String FileName, DataTable dt)
        {
            //DataView dv = dt.DefaultView;

            string Physical = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName + ".dbf";
            Console.WriteLine(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("RowID", "rowid", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("KPID", "kpid", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("KodeToko", "kodetoko", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("WilID", "wilid", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("NoTransaksi", "notr", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglTransaksi", "tgltr", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglJthTempo", "tgljtempo", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglRealGiro", "tglreal", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglPrediksiCair", "tglpcair", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglRealCair", "tglrcair", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglPotongan", "tglpot", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglHitung", "tglhit", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("QtyNota2Giro", "qtynogiro", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("QtyGiro2Cair", "qtyg2cair", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("RpGiro", "rpgiro", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("RpRealGiro", "rprgiro", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("RpCair", "rpcair", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("RpRealCair", "rprcair", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("RpPotongan", "rppot", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("KasGiro", "kasgiro", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("NoAcc", "noacc", Foxpro.enFoxproTypes.Char, 8));
            fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Cabang", "cabang", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("TglUpload", "tglupl", Foxpro.enFoxproTypes.DateTime, 8));

            Foxpro.WriteFile(FtpEngine.UploadDirectory + "\\" + Gudang, FileName, fields, dt);
            //Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[1], HeaderprogressBar);
        }

        //upload SetoranFmABank
        private void Upload2(String FileName, DataTable dt)
        {
           

            string Physical = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("RowID", "rowid", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("RecordID", "recid", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("BankID", "bankid", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("TglTerima", "tglterima", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NamaBank", "namabank", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("Kota", "kota", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("NoGiro", "nogiro", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("TglJthGiro", "tgljgiro", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglTolak", "tgltolak", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglSetor", "tglsetor", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglPrediksiCair", "tglpcair", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglInden", "tglinden", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglRealCair", "tglrcair", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglHitung", "tglhit", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("QtyGiro2Cair", "qtyg2cair", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("RpJumlah", "rpjumlah", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("RpBayar", "rpbayar", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("Keterangan1", "ket1", Foxpro.enFoxproTypes.Char, 31));
            fields.Add(new Foxpro.DataStruct("Keterangan2", "ket2", Foxpro.enFoxproTypes.Char, 31));
            fields.Add(new Foxpro.DataStruct("KasGiro", "kasgiro", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Cabang", "cabang", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("TglUpload", "tglupl", Foxpro.enFoxproTypes.DateTime, 8));

            Foxpro.WriteFile(FtpEngine.UploadDirectory + "\\" + Gudang, FileName, fields, dt);
            //Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[1], HeaderprogressBar);
        }

        //upload KartuPiutang
        private void Upload3(String FileName, DataTable dt)
        {
            DataView dv = dt.DefaultView;

            string Physical = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("RowID", "rowid", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("KPID", "kpid", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("KodeToko", "kodetoko", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("KodeSales", "kodesales", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("TglTransaksi", "tgltr", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglLink", "tgllink", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoTransaksi", "notr", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Status", "status", Foxpro.enFoxproTypes.Char, 8));
            fields.Add(new Foxpro.DataStruct("JangkaWaktu", "jwaktu", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("TglJatuhTempo", "tgljtempo", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Uraian", "uraian", Foxpro.enFoxproTypes.Char, 43));
            fields.Add(new Foxpro.DataStruct("Cicil", "cicil", Foxpro.enFoxproTypes.Numeric, 1));
            fields.Add(new Foxpro.DataStruct("TransactionType", "trtype", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "sync", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("HariKirim", "harikirim", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("HariSales", "harisales", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("KeteranganTagih", "kettagih", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("LastUpdatedBy", "lastupby", Foxpro.enFoxproTypes.Char, 250));
            fields.Add(new Foxpro.DataStruct("LastUpdatedTime", "lastuptime", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Cabang", "cabang", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("TglUpload", "tglupl", Foxpro.enFoxproTypes.DateTime, 8));

            Foxpro.WriteFile(FtpEngine.UploadDirectory + "\\" + Gudang, FileName, fields, dt);
            //Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[1], HeaderprogressBar);
        }

        //upload KartuPiutangDetail
        private void Upload4(String FileName, DataTable dt)
        {
            DataView dv = dt.DefaultView;

            string Physical = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("RowID", "rowid", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("HeaderID", "headerid", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("RecordID", "recid", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("KPID", "kpid", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("TglTransaksi", "tgltr", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("KodeTransaksi", "kodetr", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("Debet", "debet", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("Kredit", "kredit", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("TglJTGiro", "tgljgiro", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Uraian", "uraian", Foxpro.enFoxproTypes.Char, 43));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "sync", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("NoBuktiKasMasuk", "nokasmasuk", Foxpro.enFoxproTypes.Char, 5));
            fields.Add(new Foxpro.DataStruct("NoGiro", "nogiro", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("Bank", "bank", Foxpro.enFoxproTypes.Char, 32));
            fields.Add(new Foxpro.DataStruct("NoACC", "noacc", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("isClosed", "isclosed", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("LastUpdatedBy", "lastupby", Foxpro.enFoxproTypes.Char, 250));
            fields.Add(new Foxpro.DataStruct("LastUpdatedTime", "lastuptime", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Cabang", "cabang", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("TglUpload", "tglupl", Foxpro.enFoxproTypes.DateTime, 8));

            Foxpro.WriteFile(FtpEngine.UploadDirectory + "\\" + Gudang, FileName, fields, dt);
            //Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[1], HeaderprogressBar);
        }

        //upload InOut
        private void Upload5(String FileName, DataTable dt)
        {
            DataView dv = dt.DefaultView;

            string Physical = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("RowID", "rowid", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("ID", "id", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("TahunBulan", "thbln", Foxpro.enFoxproTypes.Char, 6));
            fields.Add(new Foxpro.DataStruct("Urut", "urut", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("rr", "rr", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("Keterangan", "ket", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "sync", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("T01", "t01", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T02", "t02", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T03", "t03", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T04", "t04", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T05", "t05", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T06", "t06", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T07", "t07", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T08", "t08", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T09", "t09", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T10", "t10", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T11", "t11", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T12", "t12", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T13", "t13", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T14", "t14", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T15", "t15", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T16", "t16", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T17", "t17", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T18", "t18", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T19", "t19", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T20", "t20", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T21", "t21", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T22", "t22", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T23", "t23", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T24", "t24", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T25", "t25", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T26", "t26", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T27", "t27", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T28", "t28", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T29", "t29", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T30", "t30", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("T31", "t31", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("Cabang", "cabang", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("TglUpload", "tglupl", Foxpro.enFoxproTypes.DateTime, 8));

            Foxpro.WriteFile(FtpEngine.UploadDirectory + "\\" + Gudang, FileName, fields, dt);
            //Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[1], HeaderprogressBar);
        }

        //upload SetoranFmAplBayar
        private void Upload6(String FileName, DataTable dt)
        {
            DataView dv = dt.DefaultView;

            string Physical = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("RowID", "rowid", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("KPID", "kpid", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("RowIDDetail", "rowidd", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("RecordIDDetail", "recidd", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("KodeToko", "kodetoko", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("WilID", "wilid", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("NoTransaksi", "notr", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("TglTransaksi", "tgltr", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglJthTempo", "tgljtempo", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglRealGiro", "tglrgiro", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglPrediksiCair", "tglpcair", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglRealCair", "tglrcair", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglPotongan", "tglpot", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglInden", "tglinden", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("QtyNota2Giro", "qtyn2giro", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("QtyGiro2Cair", "qtyg2cair", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("RpGiro", "rpgiro", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("RpRealGiro", "rprgiro", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("RpCair", "rpcair", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("RpRealCair]", "rprcair", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("RpPotongan", "rppot", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("KasGiro", "kasgiro", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Cabang", "cabang", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("TglUpload", "tglupl", Foxpro.enFoxproTypes.DateTime, 8));

            Foxpro.WriteFile(FtpEngine.UploadDirectory + "\\" + Gudang, FileName, fields, dt);
            //Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[1], HeaderprogressBar);
        }

        private void ZipFile(string FileName1, string FileName2, string FileName3, string FileName4, string FileName5, string FileName)
        {
            List<string> files = new List<string>();

            string fileName1 = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName1 + ".dbf";
            string fileName2 = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName2 + ".dbf";
            string fileName3 = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName3 + ".dbf";
            string fileName4 = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName4 + ".dbf";
            string fileInde5 = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName5 + ".CDX";

            string fileZipName = FtpEngine.UploadDirectory + "\\" + Gudang + "\\"+FileName+".zip";
            files.Add(fileName1);
            files.Add(fileName2);
            files.Add(fileName3);
            files.Add(fileName4);
            files.Add(fileInde5);

            //Delete File Yg lama jika Ada
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

        }

        private void ZipFile(string FileName1, string FileName2, string FileName3, string FileName4, string FileName5, string FileName6, string FileName)
        {
            List<string> files = new List<string>();

            string fileName1 = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName1 + ".dbf";
            string fileName2 = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName2 + ".dbf";
            string fileName3 = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName3 + ".dbf";
            string fileName4 = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName4 + ".dbf";
            string fileInde5 = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName5 + ".CDX";
            string fileInde6 = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName6 + ".CDX";

            string fileZipName = FtpEngine.UploadDirectory + "\\" + Gudang + "\\" + FileName + ".zip";
            files.Add(fileName1);
            files.Add(fileName2);
            files.Add(fileName3);
            files.Add(fileName4);
            files.Add(fileInde5);
            files.Add(fileInde6);

            //Delete File Yg lama jika Ada
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

        }

        private void bwRencana_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //prosesRencana();
                createdfileRencana();
                insertLog("Rancana Setoran " + Setorans.ToString("MMMM yyyy"), "Sukses", "Rancana Setoran berhasil dikirim");
            }
            catch (System.Exception ex)
            {
                insertLog("Rancana Setoran " + Setorans.ToString("MMMM yyyy"), "Gagal", ex.ToString());
            }
        }

        private void bwRealisasi_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
            //prosesRealisasi();
            createfileRealisasi();
            insertLog("Realisasi Setoran " + Setorans.ToString("MMMM yyyy"), "Sukses", "Ralisasi Setoran Berhasil dikirim");
            }
            catch (System.Exception ex)
            {
                insertLog("Realisasi Setoran " + Setorans.ToString("MMMM yyyy"), "Gagal", ex.ToString());
            }
        }

        public void prosesRencana()
        {

                Reset();
                InitHoliday();
                if (Gudang != "2808")
                {
                    initDataCustomer();
                    ProsesDataCustomer();
                }
                initDataPiutang();
                ProsesDataApi();

                InitBGC();
                ProsesDataBGC();

                InitInden();
                ProsesDataInden();
                AddDataCustomer();
            
        }

        public void createdfileRencana()
        {
            string thbln=Setorans.ToString("yyyyMM");
            int th = Setorans.Year;
            int bln = Setorans.Month;

            DateTime awalbln = Convert.ToDateTime(th + "-" + bln + "-1");
            DateTime akhirbln = awalbln.AddMonths(1).AddDays(-1);
            string fileName = "RencanaSetoran" + thbln;

            DataSet ds;
            using (Database db = new Database(DBName))
            {
                db.Commands.Add(db.CreateCommand("[usp_RencanaSetotan_Sinc]"));
                db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, akhirbln));
                db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, Gudang));
                db.Commands[0].Parameters.Add(new Parameter("@tglUpload", SqlDbType.DateTime, DateTime.Now.Date));
                ds= db.Commands[0].ExecuteDataSet();
            }

            List<string> files = new List<string>();

            string fileOuput = FtpEngine.UploadDirectory +  "\\" + fileName + ".xml";
            ds.WriteXml(fileOuput);

            //string fileOuputb = FtpEngine.UploadDirectory + "\\" + "BackUp" + ".xml";
            //checkFileBackup();

            files.Add(fileOuput);
            //files.Add(fileOuputb);

            string fileZipName = FtpEngine.UploadDirectory + "\\" + fileName + ".zip";
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            File.Delete(fileOuput);

            //string judul = "Auto Sync Rencana Setoran " + Gudang + " bulan " + Setorans.ToString("MMMM yyyy");

            //string isi = "Auto Sync Rencana Setoran " + Gudang + " bulan " + Setorans.ToString("MMMM yyyy");

            uploadfile(fileName);
        }

        public void uploadfile(string fileName)
        {
            string fileOuput = FtpEngine.UploadDirectory + "\\" + fileName + ".zip";

            string FTPName = ISA.AutoSynch.Properties.Settings.Default.FTPName + Gudang + "/outbox/";
            string FilePath = FtpEngine.UploadDirectory + "\\" + fileName + ".zip";

            string Username = ISA.AutoSynch.Properties.Settings.Default.UserNameFTP;
            string Pass = ISA.AutoSynch.Properties.Settings.Default.PassFTP;

            uploadFile(FTPName, FilePath, Username, Pass);
            
            //File.Delete(FilePath);
        }

        public void prosesRealisasi()
        {
                Reset2();

                initDataPiutang2();
                ProsesDataApi2();

                InitBGC2();
                ProsesDataBGC2();

                InitInden2();
                ProsesDataInden2();

        }

        public void createfileRealisasi()
        {
            string thblntgl = Setorans.ToString("yyyyMMdd");
            int th = Setorans.Year;
            int bln = Setorans.Month;

            DateTime awalbln = Convert.ToDateTime(th + "-" + bln + "-1");
            DateTime akhirbln = awalbln.AddMonths(1).AddDays(-1);
            string fileName = "RealisasiSetoran" + thblntgl;

            DataSet ds;
            using (Database db = new Database(DBName))
            {
                db.Commands.Add(db.CreateCommand("[usp_RealisasiSetotan_Sinc]"));
                db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, akhirbln));
                db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, Gudang));
                db.Commands[0].Parameters.Add(new Parameter("@tglUpload", SqlDbType.DateTime, DateTime.Now.Date));
                ds = db.Commands[0].ExecuteDataSet();
            }

            List<string> files = new List<string>();

            string fileOuput = FtpEngine.UploadDirectory + "\\" + fileName + ".xml";
            ds.WriteXml(fileOuput);

            files.Add(fileOuput);

            bool autoSetoran = AutoSynch.Properties.Settings.Default.DataBackup;
            if (autoSetoran)
            {
                string fileOuputb = FtpEngine.UploadDirectory + "\\" + "BackUp" + ".xml";
                checkFileBackup();
                files.Add(fileOuputb);
            }
            

            string fileZipName = FtpEngine.UploadDirectory + "\\" + fileName + ".zip";
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            File.Delete(fileOuput);

            uploadfile(fileName);
        }

        private void Reset()
        {
            dtCustomer = new DataTable();
            dtApi = new DataTable();
            dtBGC = new DataTable();
            dtApiLink = new DataTable();

        }
        private void InitHoliday()
        {
            DataTable dtH = new DataTable();

            using (Database db = new Database(DBName))
            {
                db.Commands.Add(db.CreateCommand("[usp_Libur_List]"));
                db.Commands[0].Parameters.Add(new Parameter("@Year", SqlDbType.Int, Setorans.Year));
                dtH = db.Commands[0].ExecuteDataTable();

            }

            if (dtH.Rows.Count == 0)
            {
                DateTime date1 = new DateTime(Setorans.Year, 1, 1);
                DateTime date2 = new DateTime(Setorans.Year + 1, 1, 1);
                TimeSpan ts;
                ts = date2.Subtract(date1);

                DateTime date3 = new DateTime(Setorans.Year, 1, 1);
                for (double i = 0; i < ts.Days; i++)
                {
                    date3 = date1.AddDays(+i);

                    if (date3.DayOfWeek == DayOfWeek.Sunday || date3.DayOfWeek == DayOfWeek.Saturday)
                    {
                        dtH.Rows.Add(Guid.NewGuid(), date3.Day, date3.Month, date3.Year);
                    }
                }
               
                    foreach (DataRow dr in dtH.Rows)
                    {
                        using (Database db = new Database(DBName))
                        {
                            db.Commands.Add(db.CreateCommand("[usp_Libur_Insert]"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@Year", SqlDbType.Int, Convert.ToInt32(dr["Tahun"])));
                            db.Commands[0].Parameters.Add(new Parameter("@Month", SqlDbType.Int, Convert.ToInt32(dr["Bulan"])));
                            db.Commands[0].Parameters.Add(new Parameter("@day", SqlDbType.Int, Convert.ToInt32(dr["Tanggal"])));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
            }

        }

        private void initDataCustomer()
        {
                using (Database db = new Database(DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_DataCustomer_Init]"));
                    db.Commands[0].ExecuteNonQuery();
                }

                using (Database db = new Database(DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_DataCustomer_List]"));
                    dtCustomer = db.Commands[0].ExecuteDataTable();
                }

        }
        private void ProsesDataCustomer()
        {
            int i = 0;
            int k = dtCustomer.Rows.Count;
            foreach (DataRow dr in dtCustomer.Rows)
            {
                i++;
                using (Database db = new Database(DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_DataCustomer_Proses]"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, dr["KodeToko"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    db.Commands[0].ExecuteNonQuery();
                }
                Application.DoEvents();
                this.Invalidate();

                if (bwRencana.WorkerReportsProgress)
                {
                    bwRencana.ReportProgress(i * 100 / k);
                }
            }
        }

        private void initDataPiutang()
        {
                using (Database db = new Database(DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_KPiutang_Init]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    dtApi = db.Commands[0].ExecuteDataTable();
                }
        }

        private void ProsesDataApi()
        {
            int i = 0;
            int k = dtApi.Rows.Count;
            foreach (DataRow dr in dtApi.Rows)
            {
                i++;
                using (Database db = new Database(DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Setoran_KPiutang_Proses"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    db.Commands[0].Parameters.Add(new Parameter("@ntagih", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["ntagih"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@RpJual", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["RpJual"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, Tools.isNull(dr["KPID"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["KodeToko"], "").ToString()));
                    db.Commands[0].ExecuteNonQuery();
                }
                Application.DoEvents();
                this.Invalidate();

                if (bwRencana.WorkerReportsProgress)
                {
                    bwRencana.ReportProgress(i * 100 / k);
                }
            }
        }

        private void InitBGC()
        {
                using (Database db = new Database(DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_BGC_Init]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    dtBGC = db.Commands[0].ExecuteDataTable();
                }

        }

        private void ProsesDataBGC()
        {
            int i = 0;
            int k = dtBGC.Rows.Count;
                foreach (DataRow dr in dtBGC.Rows)
                {
                    i++;
                    using (Database db = new Database(DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_Setoran_BGC_Proses]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@RowIDGiro", SqlDbType.UniqueIdentifier, (Guid)dr["RowIDGiro"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTolak", SqlDbType.DateTime, Tools.isNull(dr["TglTolak"], "").ToString() == "" ? SqlDateTime.Null : (DateTime)dr["TglTolak"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    Application.DoEvents();
                    this.Invalidate();

                    if (bwRencana.WorkerReportsProgress)
                    {
                        bwRencana.ReportProgress(i * 100 / k);
                    }
                }
           
        }

        private void InitInden()
        {
                using (Database db = new Database(DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_Inden_Init]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    dtApiLink = db.Commands[0].ExecuteDataTable();
                }
        }

        private void ProsesDataInden()
        {
            int i = 0;
            int k = dtApiLink.Rows.Count;
                foreach (DataRow dr in dtApiLink.Rows)
                {
                    i++;
                    using (Database db = new Database(DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Setoran_Inden_Proses"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, dr["NoBukti"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, dr["CollectorID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, (DateTime)dr["Tglkasir"]));
                        db.Commands[0].Parameters.Add(new Parameter("@RpInden", SqlDbType.Money, Convert.ToDouble(dr["RpInden"])));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    Application.DoEvents();
                    this.Invalidate();

                    if (bwRencana.WorkerReportsProgress)
                    {
                        bwRencana.ReportProgress(i * 100 / k);
                    }
                   
                }
           
        }

        private void AddDataCustomer()
        {
                using (Database db = new Database(DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_DataCustomer_Add"));
                    db.Commands[0].ExecuteNonQuery();
                }

                Application.DoEvents();
                this.Invalidate();
        }

        private void Reset2()
        {
            dtApi = new DataTable();
            dtBGC = new DataTable();
            dtApiLink = new DataTable();
        }

        private void initDataPiutang2()
        {
                using (Database db = new Database(DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_GetRealisasi_init]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, Setorans));
                    dtApi = db.Commands[0].ExecuteDataTable();
                }
        }

        private void ProsesDataApi2()
        {
            int i = 0;
            int k = dtApi.Rows.Count;
                foreach (DataRow dr in dtApi.Rows)
                {
                    i++;
                    using (Database db = new Database(DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Setoran_GetRealisasi_Proses"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowIDDetail", SqlDbType.UniqueIdentifier, (Guid)dr["RowIDDetail"]));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowIDHeader"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, Setorans));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    Application.DoEvents();
                    this.Invalidate();

                    if (bwRealisasi.WorkerReportsProgress)
                    {
                        bwRealisasi.ReportProgress(i * 100 / k);
                    }
                }
           
        }

        private void InitBGC2()
        {
                using (Database db = new Database(DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_RealisasiBGC_Init]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, Setorans));
                    dtBGC = db.Commands[0].ExecuteDataTable();
                }
        }

        private void ProsesDataBGC2()
        {
            int i = 0;
            int k = dtBGC.Rows.Count;
                foreach (DataRow dr in dtBGC.Rows)
                {
                    i++;
                    using (Database db = new Database(DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Setoran_RealisasiBGC_Proses"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@RowIDDDInden", SqlDbType.UniqueIdentifier, (Guid)dr["RowIDDDInden"]));
                        db.Commands[0].Parameters.Add(new Parameter("@IndenSubDetailID", SqlDbType.UniqueIdentifier, (Guid)dr["IndenSubDetailID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglCair", SqlDbType.DateTime, Tools.isNull(dr["TglCair"], "").ToString() == "" ? SqlDateTime.Null : (DateTime)dr["TglTolak"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, Setorans));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    Application.DoEvents();
                    this.Invalidate();

                    if (bwRealisasi.WorkerReportsProgress)
                    {
                        bwRealisasi.ReportProgress(i * 100 / k);
                    }
                }
        }

        private void InitInden2()
        {
                using (Database db = new Database(DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_SetoranRealisasi_Inden_Init"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, Setorans));
                    dtApiLink = db.Commands[0].ExecuteDataTable();
                }

        }

        private void ProsesDataInden2()
        {
            int i = 0;
            int k = dtApiLink.Rows.Count;
                foreach (DataRow dr in dtApiLink.Rows)
                {
                    i++;
                    using (Database db = new Database(DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_SetoranRealisasi_Inden_Proses"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, dr["NoBukti"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, dr["CollectorID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, (DateTime)dr["Tglkasir"]));
                        db.Commands[0].Parameters.Add(new Parameter("@RpInden", SqlDbType.Money, Convert.ToDouble(dr["RpInden"])));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, Setorans));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    Application.DoEvents();
                    this.Invalidate();

                    if (bwRealisasi.WorkerReportsProgress)
                    {
                        bwRealisasi.ReportProgress(i * 100 / k);
                    }
               }
           
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            //Gudang="2802";
            commandButton1.Enabled = false;
            monthYearBox.Enabled = false;
            int bln = monthYearBox.Month;
            int th = monthYearBox.Year;

            DateTime blnh = Convert.ToDateTime(th + "-" + bln + "-1");
            Setorans = blnh.AddMonths(1).AddDays(-1);

            progressBar.Value = 0;
            pictureBox3.Visible = true;
            progressBar.Visible = true;
            if (radioRencana.Checked == true)
            {
                txtRencanaSetoran.Text = "Rencana Setoran is Process";
                bwRencana.RunWorkerAsync();
            }
            else
            {
                txtRealisasiSetoran.Text = "Realisasi Setoran is Process";
                bwRealisasi.RunWorkerAsync();
            }
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            DateTime jamku = DateTime.Now;
            lbljam.Text = jamku.Hour.ToString();
            lblmenit.Text = jamku.Minute.ToString();
            lbldetik.Text = jamku.Second.ToString();

            hitungCheckFile--;
            int j=jamku.Hour;
            int m=jamku.Minute;
            int d=jamku.Second;

            int tgl = DateTime.Now.Day;

            if (checkserver == 1)
            {
                if (Gudang == "")
                {
                    DataTable dt = new DataTable();

                    using (Database db = new Database())
                    {

                        db.Commands.Add(db.CreateCommand("usp_kodegudang_LIST"));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    txttarget.Text = Tools.isNull(dt.Rows[0]["InitGudang"], "").ToString();
                    Gudang = Tools.isNull(dt.Rows[0]["InitGudang"], "").ToString();
                }

                if (j == 0 && m == 0 && d == 1)
                {
                    lbltanggal.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                    rencana = 0;
                    realisasi = 0;
                    email = 0;
                }


                if (tgl <= 4 && j == 8 && m == 30 && d == 0)
                {
                    bool autoSetoran = AutoSynch.Properties.Settings.Default.AutoSetoran;
                    if (autoSetoran)
                    {
                        rencana = 1;
                        txtRencanaSetoran.Text = "Rencana Setoran is Process";
                        pictureBox3.Visible = true;
                        progressBar.Visible = true;
                        progressBar.Value = 0;
                        commandButton1.Enabled = false;
                        monthYearBox.Enabled = false;
                        refreshTglSetoran();
                        bwRencana.RunWorkerAsync();
                    }
                }

                if (j == 9 && m == 0 && d == 0)
                {
                    bool autoSetoran = AutoSynch.Properties.Settings.Default.AutoSetoran;
                    if (autoSetoran)
                    {
                        realisasi = 1;
                        txtRealisasiSetoran.Text = "Realisasi Setoran is Process";
                        pictureBox3.Visible = true;
                        progressBar.Visible = true;
                        progressBar.Value = 0;
                        commandButton1.Enabled = false;
                        monthYearBox.Enabled = false;
                        refreshTglSetoran();
                        bwRealisasi.RunWorkerAsync();
                    }

                }

                if (j == 9 && m == 30 && d == 0)
                {
                    pictureBox3.Visible = true;
                    bwINPMAN.RunWorkerAsync();
                }

                if (j == 10 && m == 0 && d == 0)
                {
                    pictureBox3.Visible = true;
                    bwMatchingan.RunWorkerAsync();
                }

                if (tgl <= 4 && j == 10 && m == 30 && d == 0 && rencana == 0)
                {
                    bool autoSetoran = AutoSynch.Properties.Settings.Default.AutoSetoran;
                    if (autoSetoran)
                    {
                        txtRencanaSetoran.Text = "Rencana Setoran is Process";
                        pictureBox3.Visible = true;
                        progressBar.Visible = true;
                        progressBar.Value = 0;
                        commandButton1.Enabled = false;
                        monthYearBox.Enabled = false;
                        refreshTglSetoran();
                        bwRencana.RunWorkerAsync();
                    }
                }

                if (j == 11 && m == 0 && d == 0 && realisasi == 0)
                {
                    bool autoSetoran = AutoSynch.Properties.Settings.Default.AutoSetoran;
                    if (autoSetoran)
                    {
                        txtRealisasiSetoran.Text = "Realisasi Setoran is Process";
                        pictureBox3.Visible = true;
                        progressBar.Visible = true;
                        progressBar.Value = 0;
                        commandButton1.Enabled = false;
                        monthYearBox.Enabled = false;
                        refreshTglSetoran();
                        bwRealisasi.RunWorkerAsync();
                    }
                }

                if (j == 14 && m == 0 && d == 0)
                {
                    bool autoSetoran = AutoSynch.Properties.Settings.Default.AutoSetoran;
                    if (autoSetoran)
                    {
                        realisasi = 1;
                        txtRealisasiSetoran.Text = "Realisasi Setoran is Process";
                        pictureBox3.Visible = true;
                        progressBar.Visible = true;
                        progressBar.Value = 0;
                        commandButton1.Enabled = false;
                        monthYearBox.Enabled = false;
                        refreshTglSetoran();
                        bwRealisasi.RunWorkerAsync();
                    }

                }

                if (j == 12 && m == 0 && d == 0)
                {
                    bool sent = AutoSynch.Properties.Settings.Default.email;
                    if (sent)
                    {
                        bwSentEmail.RunWorkerAsync();
                    }
                }

                if (j == 15 && m == 0 && d == 0 && email == 0)
                {
                    bool sent = AutoSynch.Properties.Settings.Default.email;
                    if (sent)
                    {
                        bwSentEmail.RunWorkerAsync();
                    }
                }
            }

            if (hitungCheckFile == 0 && checkserver==0)
            {
                chekDepo();
            }

            if (hitungCheckFile == 0)
            {
                hitungCheckFile = 1000;
                bool release = AutoSynch.Properties.Settings.Default.AutoRelease;
                if (release)
                {
                    checkDelFile();
                    bwCheckFile.RunWorkerAsync();
                }

            }
            
        }

        public void refreshTglSetoran()
        {
            int th = DateTime.Now.Year;
            int bln = DateTime.Now.Month;

            monthYearBox.Month = bln;
            monthYearBox.Year = th;

            DateTime blnh = Convert.ToDateTime(th + "-" + bln + "-1");
            Setorans = blnh.AddMonths(1).AddDays(-1);
        }

        private void bwRencana_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void bwRencana_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtRencanaSetoran.Text = "Rencana Setoran is Enable";
            commandButton1.Enabled = true;
            monthYearBox.Enabled = true;
            pictureBox3.Visible = false;
            progressBar.Value = 100;
            checkfile("Rencana");
        }

        private void bwRealisasi_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void bwRealisasi_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtRealisasiSetoran.Text = "Realisasi Setoran is Enable";
            commandButton1.Enabled = true;
            monthYearBox.Enabled = true;
            pictureBox3.Visible = false;
            progressBar.Value = 100;
            checkfile("Realisasi");
        }

        public void insertLog(string type, string status, string keterangan)
        {
            using (Database db = new Database(DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_LogSyncSetoran"));
                db.Commands[0].Parameters.Add(new Parameter("@type", SqlDbType.VarChar, type));
                db.Commands[0].Parameters.Add(new Parameter("@tgl", SqlDbType.DateTime, Setorans));
                db.Commands[0].Parameters.Add(new Parameter("@status", SqlDbType.VarChar, status));
                db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, keterangan));
                db.Commands[0].ExecuteNonQuery();
            }
        }
        
        public void checkfile(string type)
        {
            if (type == "Rencana")
            {
                if (bwRencana.IsBusy)
                {
                    bwRencana.CancelAsync();
                }
                string thbln = Setorans.ToString("yyyyMM");
               
                string fileName = "RencanaSetoran" + thbln;

                string file1 = FtpEngine.UploadDirectory + "\\" + fileName + ".zip";
                string file2 = ISA.AutoSynch.Properties.Settings.Default.FTPName + Gudang + "/outbox/" + fileName + ".zip"; ;


                if (File.Exists(file1))
                {
                    WebClient request = new WebClient();
                    request.Credentials = new NetworkCredential(AutoSynch.Properties.Settings.Default.UserNameFTP, AutoSynch.Properties.Settings.Default.PassFTP);
                    int h = 0;
                    try
                    {
                        byte[] f2 = request.DownloadData(file2);
                        h = 1;
                    }
                    catch
                    {
                        h = 0;
                    }
                    
                    if (h==1)
                    {
                        FileInfo f1 = new FileInfo(file1);
                        byte[] f2 = request.DownloadData(file2);

                        if (f1.Length == f2.Length)
                        {
                            return;
                        }

                    }
                    
                    uploadfile(fileName);
                }
                else
                {
                    if (!bwRencana.IsBusy)
                    {
                        bwRencana.RunWorkerAsync();
                    }
                }
            }
            else
            {
                if (bwRealisasi.IsBusy)
                {
                    bwRealisasi.CancelAsync();
                }
                string thbln = Setorans.ToString("yyyyMMdd");

                string fileName = "RealisasiSetoran" + thbln;

                string file1 = FtpEngine.UploadDirectory + "\\" + fileName + ".zip";
                string file2 = ISA.AutoSynch.Properties.Settings.Default.FTPName + Gudang + "/outbox/" + fileName + ".zip"; ;


                if (File.Exists(file1))
                {
                    WebClient request = new WebClient();
                    request.Credentials = new NetworkCredential(AutoSynch.Properties.Settings.Default.UserNameFTP, AutoSynch.Properties.Settings.Default.PassFTP);

                    int h = 0;
                    try
                    {
                        byte[] f2 = request.DownloadData(file2);
                        h = 1;
                    }
                    catch
                    {
                        h = 0;
                    }

                    if (h==1)
                    {
                        FileInfo f1 = new FileInfo(file1);
                        byte[] f2 = request.DownloadData(file2);
                        //FileInfo f2 = new FileInfo(request.g);

                       if(f1.Length==f2.Length){
                           return;
                       }
                    }
                        uploadfile(fileName);
                }
                else
                {
                    if (!bwRealisasi.IsBusy)
                    {
                        bwRealisasi.RunWorkerAsync();
                    }
                }
            }
        }

        private void bwSentEmail_DoWork(object sender, DoWorkEventArgs e)
        {
            sentEmail();
        }

        private void bwCheckFile_DoWork(object sender, DoWorkEventArgs e)
        {
            checkFileGoogleDrive();
        }

        private void checkFileGoogleDrive()
        {
            string dirGDrive =AutoSynch.Properties.Settings.Default.GoogleDrive;
            string filetxt = AutoSynch.Properties.Settings.Default.GoogleDrive+"\\file.txt";
            string line;
            if(Directory.Exists(dirGDrive)){
                if (File.Exists(filetxt))
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(filetxt);
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] s = line.Split('|');
                        if (s.Length >= 2)
                        {
                            checkVersion(s[0], s[1]);
                        }
                    }
                    file.Close();
                }
            }
        }

        private void checkVersion(string filename, string ukuran)
        {
            string dirGDrive = AutoSynch.Properties.Settings.Default.GoogleDrive;
            string file = AutoSynch.Properties.Settings.Default.GoogleDrive + "\\"+filename+".ZIP";

            string dirTemp = AutoSynch.Properties.Settings.Default.DirTemp;
            string filetemp = AutoSynch.Properties.Settings.Default.DirTemp + "\\" + filename + ".ZIP";


            if (File.Exists(file))
            {
                FileInfo f1 = new FileInfo(file);
                if (f1.Length.ToString() == ukuran)
                {
                    if (!Directory.Exists(dirTemp))
                    {
                        Directory.CreateDirectory(dirTemp);
                    }

                    if (File.Exists(filetemp))
                    {
                        FileInfo f2 = new FileInfo(filetemp);
                        if (f2.Length >= f1.Length)
                        {
                            return;
                        }
                        if (checkFileTerbaru(filename))
                        {
                            return;
                        }
                    }
                    prosesfile(filename);
                }
            }

        }

        private bool checkFileTerbaru(string filename)
        {
            string prefix = filename.Substring(0, filename.Length - 4);
            string version = filename.Substring(filename.Length - 4, 4);
            string f, v;
            string file;
            bool hasil = false;

            int no = Convert.ToInt32(version);

            for (int i = 0; i < 5; i++)
            {
                no++;
                f = "000" + no;
                v = f.Substring(f.Length - 4, 4);
                file = AutoSynch.Properties.Settings.Default.DirTemp + "\\" + prefix + v +".ZIP";
                if (File.Exists(file))
                {
                    hasil = true;
                }
            }
            return hasil;
        }

        private void prosesfile(string filename)
        {
            try
            {
                string file = AutoSynch.Properties.Settings.Default.GoogleDrive + "\\" + filename + ".ZIP";
                string dirTemp = AutoSynch.Properties.Settings.Default.DirTemp;
                string filetemp = AutoSynch.Properties.Settings.Default.DirTemp + "\\" + filename + ".ZIP";

                if (File.Exists(filetemp))
                {
                    File.Delete(filetemp);
                }
                File.Copy(file, filetemp, true);

                ZipStorer zip = ZipStorer.Open(filetemp, FileAccess.Read);
                List<ZipStorer.ZipFileEntry> dir = zip.ReadCentralDir();
                string path;
                bool result;
                foreach (ZipStorer.ZipFileEntry entry in dir)
                {
                    path = Path.Combine(dirTemp, entry.FilenameInZip);
                    result = zip.ExtractFile(entry, path);
                }
                zip.Close();
                if (Directory.Exists(dirTemp+"\\SP"))
                {
                    eksekusiSP(filename);
                    Directory.Delete(dirTemp + "\\SP", true);
                }
                if (Directory.Exists(dirTemp + "\\Program"))
                {
                    eksekusiProgram(filename);
                    Directory.Delete(dirTemp + "\\Program", true);
                }

            }
            catch
            {
                return;
            }
            
        }

        private void eksekusiSP(string filename)
        {
            string dirTemp = AutoSynch.Properties.Settings.Default.DirTemp+"\\SP";
            string namafile, strcmd, strdel;
            string IP=AutoSynch.Properties.Settings.Default.IPSQL;
            string user =AutoSynch.Properties.Settings.Default.UserSQL;
            string pass=AutoSynch.Properties.Settings.Default.PassSQL;

            int jml = 0;
                string[] files = Directory.GetFiles(dirTemp);
                foreach (string file in files)
                {
                    if (!checkKata(file))
                    {
                        jml++;
                        strcmd = "sqlcmd -S " + IP + " -U " + user + " -P " + pass + " -t 0 -i " + file;
                        strdel = "DEL '" + file+"'";

                        Process cmd = new Process();
                        cmd.StartInfo.FileName = "cmd.exe";
                        cmd.StartInfo.RedirectStandardInput = true;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.CreateNoWindow = true;
                        cmd.StartInfo.UseShellExecute = false;
                        cmd.Start();

                        cmd.StandardInput.WriteLine(strcmd);
                        cmd.StandardInput.Flush();
                        cmd.StandardInput.Close();
                        cmd.WaitForExit();
                        cmd.StandardOutput.ReadToEnd();
                    }
                    if(File.Exists(file)){
                        File.Delete(file);
                    }
                }
                if (jml > 0)
                {
                    insertLog("Tabel dan SP "+filename, "Sukses", "Tabel dan SP Berhasil di Release");
                }
        }

        private bool checkKata(string filename)
        {
            bool hasil = false;
            string line;
            System.IO.StreamReader file =
                   new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                if (line.ToUpper().Contains("DROP TABLE"))
                {
                    hasil = true;
                }

                if (line.ToUpper().Contains("ALTER TABLE"))
                {
                    hasil = true;
                }
            }
            file.Close();
            return hasil;
        }

        private void eksekusiProgram(string filename)
        {
            string dirTemp = AutoSynch.Properties.Settings.Default.DirTemp + "\\Program";
            string app = filename.Substring(0, filename.Length - 4);

            string dirBat = "";
            string dirExe = "";

            if(app=="Trading")
            {
                dirBat = AutoSynch.Properties.Settings.Default.DirMtrading;
            }
            else if (app == "Finance")
            {
                dirBat = AutoSynch.Properties.Settings.Default.DirMFinance;
            }
            else if (app == "Bengkel")
            {
                dirBat = AutoSynch.Properties.Settings.Default.DirPBengkel;
            }

            if (dirBat != "")
            {
                dirExe = dirBat+"\\exec";
                if (!Directory.Exists(dirBat))
                {
                    Directory.CreateDirectory(dirBat);
                }
                if (!Directory.Exists(dirExe))
                {
                    Directory.CreateDirectory(dirExe);
                }
                string namafile;
                int jml = 0;
                string[] files = Directory.GetFiles(dirTemp);
                foreach (string file in files)
                {
                    jml++;
                    namafile = dirBat + "\\" + Path.GetFileName(file);
                    //Console.WriteLine(Path.GetFileName(file) + " : " + namafile.Length);
                    if ((namafile.Substring(namafile.Length - 3, 3)) == "_xe")
                    {
                        namafile = dirExe + "\\" + Path.GetFileName(file);
                    }                    
                    if (File.Exists(namafile))
                    {
                        File.Delete(namafile);
                    }
                    File.Copy(file, namafile, true);
                    File.Delete(file);
                }
                if (jml > 0)
                {
                    insertLog("Program "+filename, "Sukses", "Program Berhasil di Release");
                }
                
            }
            
        }

        private void sentEmail()
        {
                DataTable dt;
                using (Database db = new Database(DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_getEmail"));
                    db.Commands[0].Parameters.Add(new Parameter("@group", SqlDbType.VarChar, "AutoSync"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        string dirUpload = FtpEngine.UploadDirectory + "\\";
                        DataSet log;
                        using (Database db = new Database(DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_reportLog"));
                            log = db.Commands[0].ExecuteDataSet();
                        }


                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient(ISA.AutoSynch.Properties.Settings.Default.smtp);

                        mail.From = new MailAddress(ISA.AutoSynch.Properties.Settings.Default.smtplogin);

                        foreach (DataRow dr in dt.Rows)
                        {
                            mail.To.Add(dr["EmailAddress"].ToString());
                        }

                        mail.Subject = "Laporan Harian Depo "+Gudang;
                        mail.Body = isiPesan(log);
                        mail.IsBodyHtml = true;

                        if (!Directory.Exists(dirUpload))
                        {
                            Directory.CreateDirectory(dirUpload);
                        }

                        string[] files = Directory.GetFiles(dirUpload);
                        foreach (string file in files)
                        {
                            FileInfo f1 = new FileInfo(file);
                            if (f1.CreationTime.Date == DateTime.Now.Date || f1.LastWriteTime.Date == DateTime.Now.Date)
                            {
                                Attachment attachment = new Attachment(file);
                                mail.Attachments.Add(attachment);
                            }
                        }
                        
                        SmtpServer.Port = ISA.AutoSynch.Properties.Settings.Default.port;
                        SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.AutoSynch.Properties.Settings.Default.smtplogin, ISA.AutoSynch.Properties.Settings.Default.smtppassword);
                        SmtpServer.EnableSsl = ISA.AutoSynch.Properties.Settings.Default.enableSSL;

                        SmtpServer.Send(mail);

                        using (Database db = new Database(DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_getEmail"));
                            db.Commands[0].Parameters.Add(new Parameter("@group", SqlDbType.VarChar, "AutoSync"));
                            db.Commands[0].Parameters.Add(new Parameter("@update", SqlDbType.Int, 1));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        insertLog("Report Email Harian", "Sukses", "Email Harian Berhasil Dikirim");
                        email = 1;
                    }
                    catch
                    {
                        insertLog("Report Email Harian", "Gagal", "Email Harian Gagal Dikirim");
                    }
                }
        }

        public string isiPesan(DataSet ds)
        {
            int j = 0;
            string Trading = AutoSynch.Properties.Settings.Default.DirPTrading;
            string Finance = AutoSynch.Properties.Settings.Default.DirPFinance;
            string Bengkel = AutoSynch.Properties.Settings.Default.DirPBengkel;
            string Trading2 = AutoSynch.Properties.Settings.Default.DirMtrading + "\\exec\\ISA.Trading._xe";
            string Finance2 = AutoSynch.Properties.Settings.Default.DirMFinance + "\\exec\\ISA.Finance._xe";
            string Bengkel2 = AutoSynch.Properties.Settings.Default.DirMBengkel + "\\exec\\ISA.Bengkel._xe";

            string s = "<html>";
            s += "<body><b>Laporan Harian Depo "+Gudang+"</b><br><br>";
            s += "<b>Log Auto Sync : </b><br>";
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    s += dr["Type"].ToString() + " " + dr["Status"].ToString() + " pada " + dr["CreatedOn"].ToString()+"<br>";
                }
                s += "<br>";
            }
            else
            {
                s += "..... <br><br>";
            }

            s += "<b>Perubahan Tabel dan SP : </b><br>";

            if (ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)
            {
                j++;
                s += "<b>ISADBDepoFinance</b><br>";
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    s += "- "+dr["name"].ToString() + "<br>";
                }
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    s += "- " + dr["name"].ToString() + "<br>";
                }
                s += "<br>";
            }

            if (ds.Tables[3].Rows.Count > 0 || ds.Tables[4].Rows.Count > 0)
            {
                j++;
                s += "<b>ISADBDepoNonRetail</b><br>";
                foreach (DataRow dr in ds.Tables[3].Rows)
                {
                    s += "- " + dr["name"].ToString() + "<br>";
                }
                foreach (DataRow dr in ds.Tables[4].Rows)
                {
                    s += "- " + dr["name"].ToString() + "<br>";
                }
                s += "<br>";
            }

            if (ds.Tables[5].Rows.Count > 0 || ds.Tables[6].Rows.Count > 0)
            {
                j++;
                s += "<b>ISADBDepoRetail</b><br>";
                foreach (DataRow dr in ds.Tables[5].Rows)
                {
                    s += "- " + dr["name"].ToString() + "<br>";
                }
                foreach (DataRow dr in ds.Tables[6].Rows)
                {
                    s += "- " + dr["name"].ToString() + "<br>";
                }
                s += "<br>";
            }

            if (j == 0)
            {
                s += "..... <br><br>";
            }

            s += "<b>Program Version : (C:\\Temp)</b><br>";

            if (File.Exists(Trading))
            {
                var versInfo = FileVersionInfo.GetVersionInfo(Trading);
                s += "- ISA.Trading\t: " + versInfo.FileVersion + "<br>";
            }

            if (File.Exists(Finance))
            {
                var versInfo = FileVersionInfo.GetVersionInfo(Finance);
                s += "- ISA.Finance\t: " + versInfo.FileVersion + "<br>";
            }

            if (File.Exists(Bengkel))
            {
                var versInfo = FileVersionInfo.GetVersionInfo(Bengkel);
                s += "- ISA.Bengkel\t: " + versInfo.FileVersion + "<br>";
            }

            s += "<b>Program Version : (File Master)</b><br>";

            if (File.Exists(Trading2))
            {
                var versInfo = FileVersionInfo.GetVersionInfo(Trading2);
                s += "- ISA.Trading\t: " + versInfo.FileVersion + "<br>";
            }

            if (File.Exists(Finance2))
            {
                var versInfo = FileVersionInfo.GetVersionInfo(Finance2);
                s += "- ISA.Finance\t: " + versInfo.FileVersion + "<br>";
            }

            if (File.Exists(Bengkel2))
            {
                var versInfo = FileVersionInfo.GetVersionInfo(Bengkel2);
                s += "- ISA.Bengkel\t: " + versInfo.FileVersion + "<br>";
            }

            string _IP = cekIP();
            s += "<b>IP Public : " + _IP + "</b><br>";

            s += "<br><br><i>Email ini merupakan email otomatis yang dikirim oleh program ISA.AutoSynch "+Gudang;
            s += "<br>Mohon untuk tidak mereply email ini, karena account email ini tidak dimonitor";
            s += "<body></html>";
            return s;
        }

        private void checkDelFile()
        {
            string dirProgram = AutoSynch.Properties.Settings.Default.DirTemp + "\\Program";
            string dirSP = AutoSynch.Properties.Settings.Default.DirTemp + "\\SP";

            if (Directory.Exists(dirProgram))
            {
                string[] files = Directory.GetFiles(dirProgram);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
                Directory.Delete(dirProgram, true);
            }

            if (Directory.Exists(dirSP))
            {
                string[] files = Directory.GetFiles(dirProgram);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
                Directory.Delete(dirSP, true);
            }
        }

        private void checkFileBackup()
        {
            string dirTemp = AutoSynch.Properties.Settings.Default.DirBackUp;

            string fileOuputb = FtpEngine.UploadDirectory + "\\" + "BackUp" + ".xml";

            if (File.Exists(fileOuputb))
            {
                File.Delete(fileOuputb);
            }

            DateTime tglserver = DateTime.Now;
            DateTime tglUpl = tglserver.AddDays(-5);
            string[] files = Directory.GetFiles(dirTemp);

            DataSet ds = new DataSet();
            DataTable dtb= new DataTable("DataBackup");
            dtb.Columns.Add("Nama", typeof(string));
            dtb.Columns.Add("Ukuran", typeof(string));
            dtb.Columns.Add("Tanggal", typeof(DateTime));
            dtb.Columns.Add("Cabang", typeof(string));
            foreach (string file in files)
            {
                FileInfo f2 = new FileInfo(file);

                DataRow dr = null;

                DateTime tglfile = DateTime.Parse(f2.LastWriteTime.ToString());
                if (tglfile.Date > tglUpl.Date)
                {
                    DataTable dt = dtb;
                    dr = dt.Rows.Add();
                    dr["nama"] = (f2.Name);
                    dr["Ukuran"] = (f2.Length);
                    dr["Tanggal"] = (f2.LastWriteTime);
                    dr["Cabang"] = Gudang;
                }
            }

            ds.Tables.Add(dtb);
            ds.WriteXml(fileOuputb);
        }

        private string cekIP()
        {
            //HTTPGet req = new HTTPGet();
            //req.Request("http://checkip.dyndns.org");
            //string[] a = req.ResponseBody.Split(':');
            //string a2 = a[1].Substring(1);
            //string[] a3 = a2.Split('<');
            //string a4 = a3[0];
            //Console.WriteLine(a4);
            //Console.ReadLine();

            string _IP = "";
            try
            {
                //WebRequest myRequest = WebRequest.Create("http://network-tools.com");

                WebRequest myRequest = WebRequest.Create("http://checkip.dyndns.org");

                // Send request, get response, and parse out the IP address on the page. 
                using (WebResponse res = myRequest.GetResponse())
                {
                    using (Stream s = res.GetResponseStream())
                    using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
                    {
                        string html = sr.ReadToEnd();
                        Regex regex = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                        string ipString = regex.Match(html).Value;
                        _IP = ipString;
                        //Console.WriteLine("Public IP: " + ipString);
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error getting IP Address:\n" + ex.Message);
            }
            return _IP;
        }

        private void bwMatchingan_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                uploadFinance();
                uploadTrading();
                string fileOuput = FtpEngine.UploadDirectory + "\\DataMatchingan" + Gudang + ".zip";
                ZipFile(fileOuput);
                uploadfile("DataMatchingan");
                insertLog("DataMatchingan", "Sukses", "DataMatchingan dikirim lewat FTP");
            }
            catch
            {

            }
        }

        private void bwMatchingan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox3.Visible = false;
        }

        private void uploadFinance()
        {
            try
            {
                DataSet ds;
                DateTime tglawal = DateTime.Now.AddDays(-7);
                DateTime tglakhir = DateTime.Now;
                DateTime dt1 = tglawal;
                //if(dt1.Day <= 5)
                //{
                //    dt1=tglawal.AddMonths(-1);
                //}
                DateTime dt2 = tglakhir;
                using (Database db = new Database(DBName))
                {
                    db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_Matchingan"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dt1));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dt2));
                    ds = db.Commands[0].ExecuteDataSet();
                }
                string fileOuput = FtpEngine.UploadDirectory + "\\" + "DataFinance" + ".xml";

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
                DateTime tglawal = DateTime.Now.AddDays(-7);
                DateTime tglakhir = DateTime.Now;
                DateTime dt1 = tglawal;
                //if (dt1.Day <= 5)
                //{
                //    dt1 = tglawal.AddMonths(-1);
                //}
                DateTime dt2 = tglakhir;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_Matchingan"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dt1));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dt2));
                    ds = db.Commands[0].ExecuteDataSet();
                }
                string fileOuput = FtpEngine.UploadDirectory + "\\" + "DataTrading" + ".xml";

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
            string file1 = FtpEngine.UploadDirectory + "\\" + "DataFinance" + ".xml";
            string file2 = FtpEngine.UploadDirectory + "\\" + "DataTrading" + ".xml";

            files.Add(file1);
            files.Add(file2);

            Zip.ZipFiles(files, fileOuput);
        }

        private void bwINPMAN_DoWork(object sender, DoWorkEventArgs e)
        {
            
            try
            {
                uploadINPMAN_XML();
            }
            catch
            {

            }
        }

        private void bwINPMAN_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox3.Visible = false;
        }

        private void uploadINPMAN()
        {
            DateTime tglawal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime tglakhir = DateTime.Now;

            DataTable dtResult;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_StokGudang_Upload_INPMAN"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, tglawal));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, tglakhir));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Gudang));
                dtResult = db.Commands[0].ExecuteDataTable();
            }

            if (dtResult.Rows.Count > 0)
            {
                createfileINPMAN(dtResult);
                uploadfile("INPMANPS");
                insertLog("INPMAN", "Sukses", "INPMAN berhasil diupload");
            }
        }

        private void uploadINPMAN_XML()
        {
            DateTime tglawal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime tglakhir = DateTime.Now;

            DataTable dtResult;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_RekapStock_LIST_Upload"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, tglawal));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, tglakhir));
                db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, Gudang));
                dtResult = db.Commands[0].ExecuteDataTable();
            }

            if (dtResult.Rows.Count > 0)
            {
                createXmlINPMAN(dtResult);
                uploadfile("INPMANPS");
                insertLog("INPMAN", "Sukses", "INPMAN berhasil diupload");
            }
        }

        private void createXmlINPMAN(DataTable dtINPMAN) 
        {
            List<string> files = new List<string>();
            string FileName = "DATAMAN";
            string ZipName = "INPMANPS";

            string Physical = FtpEngine.UploadDirectory + "\\" + FileName + ".xml";

            files.Add(Physical);

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            dtINPMAN.WriteXml(Physical, XmlWriteMode.IgnoreSchema, true);

            string fileZipName = FtpEngine.UploadDirectory + "\\" + ZipName + ".zip";

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }
        }

        private void createfileINPMAN(DataTable dtResult)
        {
            List<string> files = new List<string>();
            string FileName = "DATAMAN";
            string ZipName = "INPMANPS";
            
            string Physical = FtpEngine.UploadDirectory + "\\" + FileName + ".dbf";
            string Indexing = FtpEngine.UploadDirectory + "\\" + FileName + ".cdx";

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

            Foxpro.WriteFile(FtpEngine.UploadDirectory, FileName, fields, dtResult);
            
            string fileZipName = FtpEngine.UploadDirectory + "\\" + ZipName + ".zip";

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

        private void frmautosynch_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }  
    }
}
