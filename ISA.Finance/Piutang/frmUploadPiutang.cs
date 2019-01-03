using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using System.IO;

namespace ISA.Finance.Piutang
{
    public partial class frmUploadPiutang : ISA.Finance.BaseForm
    {
        DataTable dt = new DataTable();
        List<string> files = new List<string>();
        int _countTable = 0;
        int _countRow = 0;

        public frmUploadPiutang()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUploadPiutang_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            rangeDateBox1.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
        }

        private void UploadTokoToSales()
        {

            lblTableName.Text = "TokoToSales Is Uploading";
            string Physical = GlobalVar.DbfUpload + "\\" + "TmpTk2.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }
            


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_PIUTANG_UPLOAD_TokoToSales"));
                dt = db.Commands[0].ExecuteDataTable();

            }

            _countTable = _countTable + 1;
            lblCountTable.Text = _countTable.ToString() + " of 5"; 

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("kd_sales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("piutang_b", "piutang_b", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("piutang_j", "piutang_j", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            foreach (DataRow dr in dt.Rows)
            {
                _countRow++;
                lblCountRow.Text = _countRow.ToString();
                progressBar1.Increment(1);
                this.Validate();
                this.RefreshForm();
            }

          

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpTk2", fields, dt);
        }

        private void UploadKartuPiutangDetail()
        {
            lblTableName.Text = "KartuPiutangDetail is Uploading";

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpDpi.DBF";
            string Indexing = GlobalVar.DbfUpload + "\\" + "TmpDpi.cdx";
            files.Add(Physical);
            files.Add(Indexing);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }
            else if (File.Exists(Indexing))
            {
                File.Delete(Indexing);
            }

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_PIUTANG_UPLOAD_KartuPiutangDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt = db.Commands[0].ExecuteDataTable();

            }

           

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("id_kp", "id_kp", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("tgl_tr", "tgl_tr", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("kd_trans", "kd_trans", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("debet", "debet", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("kredit", "kredit", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("cbg_jt", "cbg_jt", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("uraian", "uraian", Foxpro.enFoxproTypes.Char, 43));
            fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("idwil", "idwil", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("no_bkm", "no_bkm", Foxpro.enFoxproTypes.Char, 5));
            fields.Add(new Foxpro.DataStruct("no_bg", "no_bg", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("bank", "bank", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("no_acc", "no_acc", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("laudit", "laudit", Foxpro.enFoxproTypes.Logical, 1));

            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("id_kp", "ID_KP"));

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            _countTable = _countTable + 1;
            lblCountTable.Text = _countTable.ToString() + " of 5";

            foreach (DataRow dr in dt.Rows)
            {
                _countRow++;
                progressBar1.Increment(1);
                lblCountRow.Text = _countRow.ToString();                
                this.RefreshForm();
            }

           

            ProgressBar pb = new ProgressBar();

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpDpi", fields, dt,pb,index);

        }

        private void UploadKartuPiutang()
        {
            lblTableName.Text = "KartuPiutang Is Uploading";

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpKpi.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_PIUTANG_UPLOAD_KartuPiutang"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt = db.Commands[0].ExecuteDataTable();

            }
           


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("id_kp", "id_kp", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("kd_sales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("tgl_tr", "tgl_tr", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_tr", "no_tr", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("jk_waktu", "jk_waktu", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("tgl_jt", "tgl_jt", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("uraian", "uraian", Foxpro.enFoxproTypes.Char, 43));
            fields.Add(new Foxpro.DataStruct("Rp_jual", "Rp_jual", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("Rp_kredit", "Rp_kredit", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("Rp_sisa", "Rp_sisa", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("id_tr", "id_tr", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("hari_krm", "hari_krm", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("hari_sls", "hari_sls", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("ket_tagih", "ket_tagih", Foxpro.enFoxproTypes.Char, 15));

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            _countTable = _countTable + 1;
            lblCountTable.Text = _countTable.ToString() + " of 5"; 

            foreach (DataRow dr in dt.Rows)
            {
                _countRow++;
                progressBar1.Increment(1);
                lblCountRow.Text = _countRow.ToString();
                this.RefreshForm();
            }

          
            
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpKpi", fields, dt);


        }

        private void UploadGiroTolakDetail()
        {
            lblTableName.Text = "GiroTolakDetail Is Uploading";

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpDbg.DBF";
            string Indexing = GlobalVar.DbfUpload + "\\" + "TmpDbg.cdx";
            files.Add(Physical);
            files.Add(Indexing);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }
            else if (File.Exists(Indexing))
            {
                File.Delete(Indexing);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_PIUTANG_UPLOAD_GiroTolakDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt = db.Commands[0].ExecuteDataTable();

            }
            
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("tgl_byr", "tgl_byr", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("kd_bayar", "kd_bayar", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("kredit", "kredit", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("cbg_jt", "cbg_jt", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("uraian", "uraian", Foxpro.enFoxproTypes.Char, 43));
            fields.Add(new Foxpro.DataStruct("dstamp", "dstamp", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("no_bkm", "no_bkm", Foxpro.enFoxproTypes.Char, 5));
            fields.Add(new Foxpro.DataStruct("no_bg", "no_bg", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("Bank", "Bank", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("no_acc", "no_acc", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));

            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("idrec", "IDREC"));

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            _countTable = _countTable + 1;
            lblCountTable.Text = _countTable.ToString() + " of 5";

            foreach (DataRow dr in dt.Rows)
            {
                _countRow++;
                progressBar1.Increment(1);
                lblCountRow.Text = _countRow.ToString();
                this.RefreshForm();
            }

          

            ProgressBar pb = new ProgressBar();
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpDbg", fields, dt, pb,index);
        }

        private void UploadGiroTolak()
        {

            lblTableName.Text = "GiroTolak is Uploading";

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpHbg.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_PIUTANG_UPLOAD_GiroTolak"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt = db.Commands[0].ExecuteDataTable();

            }

            

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("idkp", "idkp", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Alasan", "Alasan", Foxpro.enFoxproTypes.Char, 43));
            fields.Add(new Foxpro.DataStruct("Tgl_Giro", "Tgl_Giro", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Cbg_jt", "Cbg_jt", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_tolak", "tgl_tolak", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Uraian", "Uraian", Foxpro.enFoxproTypes.Char, 43));
            fields.Add(new Foxpro.DataStruct("Debet", "Debet", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("Dibayar", "Dibayar", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("KD_sales", "KD_sales", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("no_bkm", "no_bkm", Foxpro.enFoxproTypes.Char, 5));
            fields.Add(new Foxpro.DataStruct("no_bg", "no_bg", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("Bank", "Bank", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("no_acc", "no_acc", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("laudit", "laudit", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("ket_tagih", "ket_tagih", Foxpro.enFoxproTypes.Char, 10));


            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            _countTable = _countTable + 1;
            lblCountTable.Text = _countTable.ToString() + " of 5";

            foreach (DataRow dr in dt.Rows)
            {
                _countRow++;
                progressBar1.Increment(1);
                lblCountRow.Text = _countRow.ToString();
                this.RefreshForm();
            }

           
            
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpHbg", fields, dt);

        }

        private void UploadTmpTok()
        {

            lblTableName.Text = "TmpTok is Uploading";

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpTok.DBF";
            string Indexing = GlobalVar.DbfUpload + "\\" + "TmpTok.cdx";
            files.Add(Physical);
            files.Add(Indexing);

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }
            else if (File.Exists(Indexing))
            {
                File.Delete(Indexing);
            }
            DataTable dt = new DataTable();
            
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idtoko", "idtoko", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("namatoko", "namatoko", Foxpro.enFoxproTypes.Char, 31));
            fields.Add(new Foxpro.DataStruct("alamat", "alamat", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("kota", "kota", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("notelp", "notelp", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("idwil", "idwil", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("pngjwb", "pngjwb", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("piutang_b", "piutang_b", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("piutang_j", "piutang_j", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("plafon", "plafon", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("to_jual", "to_jual", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("to_retpot", "to_retpot", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("jkw_kredit", "jkw_kredit", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("cab2", "cab2", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("tgl1st", "tgl1st", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("exist", "exist", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("idclass", "idclass", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("catatan", "catatan", Foxpro.enFoxproTypes.Char, 73));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("hr_krm", "hr_krm", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("kd_pos", "kd_pos", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("grade", "grade", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("plafon_1st", "plafon_1st", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("flag", "flag", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("bentrok", "bentrok", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("lpasif", "lpasif", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("hari_sls", "hari_sls", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("daerah", "daerah", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("propinsi", "propinsi", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("alm_rumah", "alm_rumah", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("pengelola", "pengelola", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("tgl_lahir", "tgl_lahir", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("hp", "hp", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("status", "status", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("th_berdiri", "th_berdiri", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("lruko", "lruko", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("jml_cabang", "jml_cabang", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("jml_sales", "jml_sales", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("kinerja", "kinerja", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("bdg_usaha", "bdg_usaha", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("reff_sls", "reff_sls", Foxpro.enFoxproTypes.Char, 35));
            fields.Add(new Foxpro.DataStruct("reff_col", "reff_col", Foxpro.enFoxproTypes.Char, 35));
            fields.Add(new Foxpro.DataStruct("reff_spv", "reff_spv", Foxpro.enFoxproTypes.Char, 35));
            fields.Add(new Foxpro.DataStruct("plf_survey", "plf_survey", Foxpro.enFoxproTypes.Numeric, 13));

            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("kd_toko", "KD_TOKO"));

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            _countTable = _countTable + 1;
            lblCountTable.Text = _countTable.ToString() + " of 6";

            foreach (DataRow dr in dt.Rows)
            {
                _countRow++;
                progressBar1.Increment(1);
                lblCountRow.Text = _countRow.ToString();
                this.RefreshForm();
            }

            ProgressBar pb = new ProgressBar();
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpTok", fields, dt, pb, index);

        }

        private void UploadProcess()
        {
            lblTableName.Visible = true;
            lblCountRow.Visible = true;
            UploadTokoToSales(); RefreshCounter();
            UploadKartuPiutangDetail(); RefreshCounter();
            UploadKartuPiutang(); RefreshCounter();
            UploadGiroTolakDetail(); RefreshCounter();           
            UploadGiroTolak();
            UploadTmpTok();
            ZipFile(files);
        }

        private void RefreshCounter()
        {
            
            _countRow = 0;
            lblCountRow.Text = _countRow.ToString();
        }
        

        private void ZipFile(List<string> files)
        {


            string fileZipName = GlobalVar.DbfUpload + "\\APIMATCH.zip";

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

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            try
            {
                UploadProcess();
                MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "APIMATCH.ZIP");
                lblTableName.Visible = false;
                lblCountRow.Visible = false;
                _countTable = 0;                
                lblCountTable.Text = _countTable.ToString() + " of 5";
                RefreshCounter();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }
    }
}
