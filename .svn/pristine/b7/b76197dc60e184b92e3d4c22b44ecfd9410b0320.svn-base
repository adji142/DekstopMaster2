using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using System.IO;


namespace ISA.Finance.UploadIND
{
    public partial class frmUploadIND : ISA.Finance.BaseForm
    {
        DataTable dt = new DataTable();
        List<string> files = new List<string>();
        int _countTable = 0;
        int _countRow = 0;

        public frmUploadIND()
        {
            InitializeComponent();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (InputIsValid())
            {
                try
                {
                    files.Clear();
                    CopyTemplate();
                    UploadProcess();
                    MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "UPLKASIR.ZIP");
                    lblTableName.Visible = false;
                    lblCountRow.Visible = false;
                    _countTable = 0;
                    lblCountTable.Text = _countTable.ToString();
                    RefreshCounter();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUploadIND_Shown(object sender, EventArgs e)
        {
            SetControl();
        }

        private void SetControl()
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
            txtInitCabang.Text = GlobalVar.PerusahaanID;                        
        }

        private void UploadProcess()
        {
            lblTableName.Visible = true;
            lblCountRow.Visible = true;
            UploadInden(); RefreshCounter();
            UploadIndenDetail(); RefreshCounter();
            UploadIndenSubDetail(); RefreshCounter();            
            UploadBukti(); RefreshCounter();
            UploadBuktiDetail(); RefreshCounter();
            UploadTransferBank(); RefreshCounter();
            UploadTransferBankDetail(); RefreshCounter();
            UploadBankDetail(); RefreshCounter();
            UploadVoucherJournal(); RefreshCounter();
            UploadVoucherJournalDetail(); RefreshCounter();
            UploadGiro(); RefreshCounter();
            ZipFile(files);
        }

        private void ZipFile(List<string> files)
        {


            string fileZipName = GlobalVar.DbfUpload + "\\UPLKASIR.zip";

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


        private void RefreshCounter()
        {

            _countRow = 0;
            lblCountRow.Text = _countRow.ToString();
        }

        private bool InputIsValid()
        {
            bool valid = true;
            if (lookupBank1.BankID == "[CODE]" || lookupBank1.BankID == "")
            {
                valid = false;
                MessageBox.Show("No Account Bank wajib diisi");
            }
            return valid;

        }

        
        #region "Inden  --> TMPHIND.dbf"
        private void UploadInden()
        {
            SqlDataReader dr;
            lblTableName.Text = "Inden Is Uploading";
            string TableName = "Inden";
            string FileName = "TMPHIND";
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
            string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
            
            files.Add(Physical);
            files.Add(Indexing);

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idtr", "idtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("no_bukti", "no_bukti", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("collector", "collector", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("nm_coll", "nm_coll", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("rp_cash", "rp_cash", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_giro", "rp_giro", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_trf", "rp_trf", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("lbr_giro", "lbr_giro", Foxpro.enFoxproTypes.Numeric, 4));
            fields.Add(new Foxpro.DataStruct("tgl_kasir", "tgl_kasir", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("kasir", "kasir", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("acc", "acc", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            //fields.Add(new Foxpro.DataStruct("rp_crd", "rp_crd", Foxpro.enFoxproTypes.Numeric, 14));
            //fields.Add(new Foxpro.DataStruct("rp_dbt", "rp_dbt", Foxpro.enFoxproTypes.Numeric, 14));

            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("idtr", "IDTR"));


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_UPLIND_Inden"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, txtInitCabang.Text));
                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, lookupBank1.BankID));
                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, txtWilID.Text));
                db.Open();
                dr = db.Commands[0].ExecuteReader();
                Foxpro.WriteData(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, progressBar1, lblCountRow, true);
                
                db.Close();
                lblTableName.Text = "";
            }

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_DeletedHistory_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, TableName));
                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Int, 0));
                DataTable dt = db.Commands[0].ExecuteDataTable();
                Foxpro.InsertDeletedRecord(GlobalVar.DbfUpload + "\\", FileName, fields, dt, "idtr");
            }
        }
        #endregion

        #region "IndenDetail --> TMPDIND.dbf"
        private void UploadIndenDetail()
        {
            SqlDataReader dr;
            lblTableName.Text = "IndenDetail Is Uploading";
            string TableName = "IndenDetail";
            string FileName = "TMPDIND";
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
            string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";

            files.Add(Physical);
            files.Add(Indexing);


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idtr", "idtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("rp_cash", "rp_cash", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_giro", "rp_giro", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_trf", "rp_trf", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("cash", "cash", Foxpro.enFoxproTypes.Numeric, 14));            
            fields.Add(new Foxpro.DataStruct("trf", "trf", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("giro", "giro", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("tgl_trf", "tgl_trf", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("idbank", "idbank", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("namabank", "namabank", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("lokasi", "lokasi", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("chbg", "chbg", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("nomor", "nomor", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("tgl_giro", "tgl_giro", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_jt", "tgl_jt", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("ket", "ket", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("no_acc", "no_acc", Foxpro.enFoxproTypes.Char, 15));
            //fields.Add(new Foxpro.DataStruct("rp_crd", "rp_crd", Foxpro.enFoxproTypes.Numeric, 14));
            //fields.Add(new Foxpro.DataStruct("rp_dbt", "rp_dbt", Foxpro.enFoxproTypes.Numeric, 14));
            //fields.Add(new Foxpro.DataStruct("crd", "crd", Foxpro.enFoxproTypes.Numeric, 14));
            //fields.Add(new Foxpro.DataStruct("dbt", "dbt", Foxpro.enFoxproTypes.Numeric, 14));


            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("idrec", "IDREC"));


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_UPLIND_IndenDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, txtInitCabang.Text));
                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, lookupBank1.BankID));
                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, txtWilID.Text));
                db.Open();
                dr = db.Commands[0].ExecuteReader();
                Foxpro.WriteData(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, progressBar1, lblCountRow, true);
                db.Close();
                lblTableName.Text = "";
            }

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_DeletedHistory_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, TableName));
                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Int, 0));
                DataTable dt = db.Commands[0].ExecuteDataTable();
                Foxpro.InsertDeletedRecord(GlobalVar.DbfUpload + "\\", FileName, fields, dt, "idrec");
            }
        }
        #endregion        

        #region "IndenSubDetail --> TMPTAGIH.dbf"
        private void UploadIndenSubDetail()
        {
            SqlDataReader dr;
            lblTableName.Text = "IndenSubDetail Is Uploading";
            string TableName = "IndenSubDetail";
            string FileName = "TMPTAGIH";
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
            string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
            string Fpt = GlobalVar.DbfUpload + "\\" + FileName + ".fpt";
            files.Add(Physical);
            files.Add(Indexing);
            files.Add(Fpt);


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("id_coltoko", "id_coltoko", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idwil", "idwil", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("Namatoko", "Namatoko", Foxpro.enFoxproTypes.Char, 31));
            fields.Add(new Foxpro.DataStruct("no_reg", "no_reg", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("no_bpp", "no_bpp", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("tgl_bpp", "tgl_bpp", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_kasir", "tgl_kasir", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("rp_nota", "rp_nota", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_bayar", "rp_bayar", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_tagih", "rp_tagih", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_nominal", "rp_nominal", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("nota", "nota", Foxpro.enFoxproTypes.Memo, 4));


            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("idrec", "IDREC"));


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_UPLIND_IndenSubDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, txtInitCabang.Text));
                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, lookupBank1.BankID));
                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, txtWilID.Text));
                db.Open();
                dr = db.Commands[0].ExecuteReader();
                Foxpro.WriteData(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, progressBar1, lblCountRow,true);
                db.Close();
                lblTableName.Text = "";
            }

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_DeletedHistory_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, TableName));
                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Int, 0));
                DataTable dt = db.Commands[0].ExecuteDataTable();
                Foxpro.InsertDeletedRecord(GlobalVar.DbfUpload + "\\", FileName, fields, dt, "idrec");
            }
        }
        #endregion

        #region "BankDetail --> TMPDBANK.dbf"
        private void UploadBankDetail()
        {
            lblTableName.Text = "BankDetail Is Uploading";

            string Physical = GlobalVar.DbfUpload + "\\" + "TMPDBANK.DBF";
            files.Add(Physical);

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_UPLIND_BankDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, txtInitCabang.Text));
                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, lookupBank1.BankID));
                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, txtWilID.Text));
                dt = db.Commands[0].ExecuteDataTable();

            }


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idbank", "idbank", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("iddbank", "iddbank", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("id_reg", "id_reg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("tgl_tran", "tgl_tran", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_bbk", "no_bbk", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("jns_tran", "jns_tran", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("nobgch", "nobgch", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("keterangan", "keterangan", Foxpro.enFoxproTypes.Char, 70));
            fields.Add(new Foxpro.DataStruct("vta", "vta", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("debet", "debet", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("kredit", "kredit", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("tgl_bank", "tgl_bank", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_rk", "tgl_rk", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("saldo", "saldo", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("link_rk", "link_rk", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("kode", "kode", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("sub", "sub", Foxpro.enFoxproTypes.Char, 11));
            //fields.Add(new Foxpro.DataStruct("catatan", "catatan", Foxpro.enFoxproTypes.Char, 20));
            //fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 12));

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            _countTable = _countTable + 1;
            lblCountTable.Text = _countTable.ToString() + " of 11";

            foreach (DataRow dr in dt.Rows)
            {
                _countRow++;
                progressBar1.Increment(1);
                lblCountRow.Text = _countRow.ToString();
                this.RefreshForm();
            }
            Foxpro.WriteData(GlobalVar.DbfUpload, "TMPDBANK", fields, dt, progressBar1);
        }
        #endregion

        #region "Bukti --> TMPHBUK.dbf"
        private void UploadBukti()
        {
            lblTableName.Text = "Bukti Is Uploading";

            string Physical = GlobalVar.DbfUpload + "\\" + "TMPHBUK.DBF";
            files.Add(Physical);

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_UPLIND_Bukti"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, txtInitCabang.Text));
                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, lookupBank1.BankID));
                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, txtWilID.Text));
                dt = db.Commands[0].ExecuteDataTable();

            }


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idtr", "idtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("mk", "mk", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("jns_bukti", "jns_bukti", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("no_bukti", "no_bukti", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("tgl_bukti", "tgl_bukti", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("kepada", "kepada", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("lampiran", "lampiran", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("pembukuan", "pembukuan", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("acc", "acc", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("kasir", "kasir", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("penerima", "penerima", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("jml_kas", "jml_kas", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("jml_bg", "jml_bg", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("lbr_bg", "lbr_bg", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("jml_bs", "jml_bs", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));            

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            _countTable = _countTable + 1;
            lblCountTable.Text = _countTable.ToString() + " of 11";

            foreach (DataRow dr in dt.Rows)
            {
                _countRow++;
                progressBar1.Increment(1);
                lblCountRow.Text = _countRow.ToString();
                this.RefreshForm();
            }
            Foxpro.WriteData(GlobalVar.DbfUpload, "TMPHBUK", fields, dt,progressBar1);
        }

        #endregion

        #region "BuktiDetail --> TMPDBUK.dbf"
        private void UploadBuktiDetail()
        {
            lblTableName.Text = "BuktiDetail Is Uploading";

            string Physical = GlobalVar.DbfUpload + "\\" + "TMPDBUK.DBF";
            files.Add(Physical);
 

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_UPLIND_BuktiDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, txtInitCabang.Text));
                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, lookupBank1.BankID));
                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, txtWilID.Text));
                dt = db.Commands[0].ExecuteDataTable();

            }


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idtr", "idtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idbs", "idbs", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("kode", "kode", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("sub", "sub", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("uraian", "uraian", Foxpro.enFoxproTypes.Char, 73));
            fields.Add(new Foxpro.DataStruct("jumlah", "jumlah", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("ch_gb_no", "ch_gb_no", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("bank", "bank", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("tgl_jt", "tgl_jt", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
         
            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            _countTable = _countTable + 1;
            lblCountTable.Text = _countTable.ToString() + " of 11";

            foreach (DataRow dr in dt.Rows)
            {
                _countRow++;
                progressBar1.Increment(1);
                lblCountRow.Text = _countRow.ToString();
                this.RefreshForm();
            }
            Foxpro.WriteData(GlobalVar.DbfUpload, "TMPDBUK", fields, dt,progressBar1);
        }

        #endregion

        #region "VoucherJournal --> TMPHVOUC.dbf"
        private void UploadVoucherJournal()
        {
            lblTableName.Text = "VoucherJournal Is Uploading";

            string Physical = GlobalVar.DbfUpload + "\\" + "TMPHVOUC.DBF";
            files.Add(Physical);

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_UPLIND_VoucherJournal"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, txtInitCabang.Text));
                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, lookupBank1.BankID));
                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, txtWilID.Text));
                dt = db.Commands[0].ExecuteDataTable();
            }


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idvoucher", "idvoucher", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("tipe", "tipe", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("tgl_vch", "tgl_vch", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_vch", "no_vch", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("uraian1", "uraian1", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("uraian2", "uraian2", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("uraian3", "uraian3", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("nilai", "nilai", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("dibuat", "dibuat", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("dibukukan", "dibukukan", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("mengetahui", "mengetahui", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("idbank", "idbank", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("nama_bank", "nama_bank", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            _countTable = _countTable + 1;
            lblCountTable.Text = _countTable.ToString() + " of 11";

            foreach (DataRow dr in dt.Rows)
            {
                _countRow++;
                progressBar1.Increment(1);
                lblCountRow.Text = _countRow.ToString();
                this.RefreshForm();
            }
            Foxpro.WriteData(GlobalVar.DbfUpload, "TMPHVOUC", fields, dt, progressBar1);
        }
        #endregion

        #region "VoucherJournalDetail --> TMPDVOUC.dbf"
        private void UploadVoucherJournalDetail()
        {
            lblTableName.Text = "VoucherJournalDetail Is Uploading";

            string Physical = GlobalVar.DbfUpload + "\\" + "TMPDVOUC.DBF";
            files.Add(Physical);

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_UPLIND_VoucherJournalDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, txtInitCabang.Text));
                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, lookupBank1.BankID));
                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, txtWilID.Text));
                dt = db.Commands[0].ExecuteDataTable();

            }


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idhvoucher", "idhvoucher", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("iddvoucher", "iddvoucher", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("kode", "kode", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("sub", "sub", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("vodate", "vodate", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("voutype", "voutype", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("vouno", "vouno", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("trdate", "trdate", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("debet", "debet", Foxpro.enFoxproTypes.Numeric, 17));
            fields.Add(new Foxpro.DataStruct("kredit", "kredit", Foxpro.enFoxproTypes.Numeric, 17));
            fields.Add(new Foxpro.DataStruct("desc1", "desc1", Foxpro.enFoxproTypes.Char, 73));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            //fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 12)); 

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            _countTable = _countTable + 1;
            lblCountTable.Text = _countTable.ToString() + " of 11";

            foreach (DataRow dr in dt.Rows)
            {
                _countRow++;
                progressBar1.Increment(1);
                lblCountRow.Text = _countRow.ToString();
                this.RefreshForm();
            }
            Foxpro.WriteData(GlobalVar.DbfUpload, "TMPDVOUC", fields, dt, progressBar1);
        }
        #endregion

        #region "TransferBank --> TMPHTRF.dbf"
        private void UploadTransferBank()
        {
            lblTableName.Text = "TransferBank Is Uploading";

            string Physical = GlobalVar.DbfUpload + "\\" + "TMPHTRF.DBF";
            files.Add(Physical);


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_UPLIND_TransferBank"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, txtInitCabang.Text));
                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, lookupBank1.BankID));
                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, txtWilID.Text));
                dt = db.Commands[0].ExecuteDataTable();

            }


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idbbm", "idbbm", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("tgl_bbm", "tgl_bbm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_bbm", "no_bbm", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("mk", "mk", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("id_bank", "id_bank", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("nm_bank", "nm_bank", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("rp_trf", "rp_trf", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("dibukuan", "dibukuan", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("diketahui", "diketahui", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("kasir", "kasir", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("penyetor", "penyetor", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            _countTable = _countTable + 1;
            lblCountTable.Text = _countTable.ToString() + " of 11";

            foreach (DataRow dr in dt.Rows)
            {
                _countRow++;
                progressBar1.Increment(1);
                lblCountRow.Text = _countRow.ToString();
                this.RefreshForm();
            }
            Foxpro.WriteData(GlobalVar.DbfUpload, "TMPHTRF", fields, dt, progressBar1);
        }
        #endregion

        #region "TransferBankDetail -->TMPTRMT.dbf"
        private void UploadTransferBankDetail()
        {
            lblTableName.Text = "TransferBankDetail Is Uploading";

            string Physical = GlobalVar.DbfUpload + "\\" + "TMPTRMT.DBF";
            files.Add(Physical);


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_UPLIND_TransferBankDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, txtInitCabang.Text));
                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, lookupBank1.BankID));
                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, txtWilID.Text));
                dt = db.Commands[0].ExecuteDataTable();

            }


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idtrm", "idtrm", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idbbm", "idbbm", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("asaltrf", "asaltrf", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("namabank", "namabank", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("lokasi", "lokasi", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("nomor", "nomor", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("tgl_trf", "tgl_trf", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_bank", "tgl_bank", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("nominal", "nominal", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("maintitip", "maintitip", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("subtitip", "subtitip", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("mainpiut", "mainpiut", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("subpiut", "subpiut", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("idbank", "idbank", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("nm_banki", "nm_banki", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 6));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            //fields.Add(new Foxpro.DataStruct("titiperk", "titiperk", Foxpro.enFoxproTypes.Char, 12));  

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            _countTable = _countTable + 1;
            lblCountTable.Text = _countTable.ToString() + " of 11";

            foreach (DataRow dr in dt.Rows)
            {
                _countRow++;
                progressBar1.Increment(1);
                lblCountRow.Text = _countRow.ToString();
                this.RefreshForm();
            }
            Foxpro.WriteData(GlobalVar.DbfUpload, "TMPTRMT", fields, dt, progressBar1);
        }
        #endregion

        #region "Giro --> TMPGIRO.dbf"
        private void UploadGiro()
        {
            lblTableName.Text = "Giro Is Uploading";

            string Physical = GlobalVar.DbfUpload + "\\" + "TMPGIRO.DBF";
            files.Add(Physical);


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_UPLIND_Giro"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, txtInitCabang.Text));
                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, lookupBank1.BankID));
                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, txtWilID.Text));
                dt = db.Commands[0].ExecuteDataTable();

            }


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idvoucher", "idvoucher", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idbbm", "idbbm", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idtitip", "idtitip", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idgiro", "idgiro", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("asalgiro", "asalgiro", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("namabank", "namabank", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("lokasi", "lokasi", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("chbg", "chbg", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("nomor", "nomor", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("tgl_giro", "tgl_giro", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_jt", "tgl_jt", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("nominal", "nominal", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("cairtolak", "cairtolak", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("tgl_cair", "tgl_cair", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("maintitip", "maintitip", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("subtitip", "subtitip", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("mainpiut", "mainpiut", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("subpiut", "subpiut", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("idbank", "idbank", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("nm_banki", "nm_banki", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 6));
            fields.Add(new Foxpro.DataStruct("tgl_titip", "tgl_titip", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("no_acc", "no_acc", Foxpro.enFoxproTypes.Char, 15));
            //fields.Add(new Foxpro.DataStruct("mainperk", "mainperk", Foxpro.enFoxproTypes.Char, 12));

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            _countTable = _countTable + 1;
            lblCountTable.Text = _countTable.ToString() + " of 11";

            foreach (DataRow dr in dt.Rows)
            {
                _countRow++;
                progressBar1.Increment(1);
                lblCountRow.Text = _countRow.ToString();
                this.RefreshForm();
            }
            Foxpro.WriteData(GlobalVar.DbfUpload, "TMPGIRO", fields, dt, progressBar1);
        }
        #endregion

        private void chkInclude_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInclude.Checked)
                txtInitCabang.Text = "";
            else
                txtInitCabang.Text = GlobalVar.PerusahaanID;
        }


        private void CopyTemplate()
        {
            string[] fileList = Directory.GetFiles(Application.StartupPath + "\\UPLIND");
            if (fileList.Length > 0)
            {
                foreach (string file in fileList)
                {
                    FileInfo finfo = new FileInfo(file);
                    File.Copy(file, GlobalVar.DbfUpload + "\\" + finfo.Name, true);
                }
            }
        }


    }
}
