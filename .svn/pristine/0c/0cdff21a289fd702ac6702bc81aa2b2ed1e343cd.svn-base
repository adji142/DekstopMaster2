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

namespace ISA.Trading.ArusStock
{
    public partial class frmUploadMatchingAG : ISA.Trading.BaseForm
    {
        List<string> files = new List<string>();
        int jumlahTable = 2;
        int uploadTable = 0;
        DateTime dt1;
        DateTime dt2; 

        public frmUploadMatchingAG()
        {
            InitializeComponent();
        }

        private void frmUploadMatchingAG_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            if (SecurityManager.IsManager() || SecurityManager.IsAdministrator())
                cmdStartUpload.Enabled = true;
            else
                cmdStartUpload.Enabled = false;
            rgbTanggal.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTanggal.ToDate = DateTime.Now;
            DateTime dt1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime dt2 = DateTime.Now;
        }

        private void cmdStartUpload_Click(object sender, EventArgs e)
        {
            if (rgbTanggal.FromDate.ToString() == "" || rgbTanggal.ToDate.ToString() == "")
            {
                MessageBox.Show("Range tanggal belum diisi!", "Perhatian");
                return;
            }

            dt1 = rgbTanggal.FromDate.Value;
            dt2 = rgbTanggal.ToDate.Value;
            UploadAntarGudang(); DownloadCount();
            UploadAntarGudangDetail(); DownloadCount();
            ZipFile(files);
            MessageBox.Show("POS Upload Selesai. Lokasi file: " + GlobalVar.DbfUpload + "\\AG" + GlobalVar.Gudang + ".zip");
        }

        #region Antar Gudang
        private void UploadAntarGudang()
        {
            SqlDataReader dr;
            string FileName = "Hagtmp";

            string TableName = "Antar Gudang";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'Antar Gudang' is Uploading...";
                refreshForm();
                string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                //string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
                //files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("idhkrmagud", "idhkrmagud", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("dr_gud", "dr_gud", Foxpro.enFoxproTypes.Char, 4));
                fields.Add(new Foxpro.DataStruct("ke_gud", "ke_gud", Foxpro.enFoxproTypes.Char, 4));
                fields.Add(new Foxpro.DataStruct("tgl_krm", "tgl_krm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("tgl_trm", "tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("no_ag", "no_ag", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("pengirim", "pengirim", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("penerima", "penerima", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("drcheck1", "drcheck1", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("drcheck2", "drcheck2", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("kecheck1", "kecheck1", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("kecheck2", "kecheck2", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("catatan", "catatan", Foxpro.enFoxproTypes.Char, 43));
                fields.Add(new Foxpro.DataStruct("exp", "exp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("no_kend", "no_kend", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("nm_sopir", "nm_sopir", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("id_krmtrm", "id_krmtrm", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("no_bodo", "no_dobo", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("lbo", "lbo", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric, 1));
                fields.Add(new Foxpro.DataStruct("no_rq", "no_rq", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("tgl_rq", "tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("no_do", "no_do", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("tgl_do", "tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("tgl_sj", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));


                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                //index.Add(new Foxpro.IndexStruct("idhkrmagud", "IDHKRMAGUD"));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_AntarGudang"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dt1));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dt2));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();
                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, pbSyncUpload, lblUploadCount);
                    db.Close();
                    lblProgress.Text = "";
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void UploadAntarGudangDetail()
        {
            SqlDataReader dr;
            string FileName = "Dagtmp";

            string TableName = "Antar Gudang Detail";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'Antar Gudang Detail' is Uploading...";
                refreshForm();
                string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                //string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
                //files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("iddkrmagud", "iddkrmagud", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("idhkrmagud", "idhkrmagud", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("id_brg", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("nama_stok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("qty_krm", "qty_krm", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("qty_trm", "qty_trm", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("catatan", "catatan", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("hpp", "hpp", Foxpro.enFoxproTypes.Numeric, 10));
                fields.Add(new Foxpro.DataStruct("ongkos", "ongkos", Foxpro.enFoxproTypes.Numeric, 10));
                fields.Add(new Foxpro.DataStruct("drgud", "drgud", Foxpro.enFoxproTypes.Char, 4));
                fields.Add(new Foxpro.DataStruct("kegud", "kegud", Foxpro.enFoxproTypes.Char, 4));
                fields.Add(new Foxpro.DataStruct("tgl_krm", "tgl_krm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("tgl_trm", "tgl_trm", Foxpro.enFoxproTypes.DateTime, 1));
                fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("qty_do", "qty_do", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("no_bodo", "no_bodo", Foxpro.enFoxproTypes.Char, 7));

                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                //index.Add(new Foxpro.IndexStruct("iddkrmagud", "IDDKRMAGUD"));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_AntarGudangDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dt1));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dt2));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();
                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, pbSyncUpload, lblUploadCount);
                    db.Close();
                    lblProgress.Text = "";
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion


        private void ZipFile(List<string> files)
        {
            string fileZipName = GlobalVar.DbfUpload + "\\AG" + GlobalVar.Gudang + ".zip";

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

        private void DownloadCount()
        {
            uploadTable++;
            lblUpload.Text = uploadTable.ToString() + "/" + jumlahTable.ToString();
        }
        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
