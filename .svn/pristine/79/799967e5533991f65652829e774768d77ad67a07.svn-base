using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlClient;
using System.IO;
using ISA.Trading.Class;

namespace ISA.Trading.Communicator
{
    public partial class frmExportDataPenunjang : ISA.Trading.BaseForm
    {
        List<string> files = new List<string>();
        int jumlahTable = 6;
        int uploadTable = 1;

        public frmExportDataPenunjang()
        {
            InitializeComponent();
        }



        private void frmExportDataPenunjang_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            rangeDateBox1.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void UploadCount()
        {
            uploadTable++;
            lblUpload.Text = uploadTable.ToString() + "/" + jumlahTable.ToString();
        }

        

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            UploadToko(); UploadCount();
            UploadSales(); UploadCount();            
            UploadCollector(); UploadCount();
            UploadStok(); UploadCount();
            UploadTagihanHeader(); UploadCount();
            UploadTagihanDetail(); UploadCount();            
            ZipFile(files);
            //SetFileInformation();
            MessageBox.Show("Upload Data Penunjang Selesai. Lokasi file: " + GlobalVar.DbfUpload + "\\DBExport.zip");

        }


        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }
        
        private void ZipFile(List<string> files)
        {
            string fileZipName = GlobalVar.DbfUpload + "\\DBExport.zip";

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

        private void UploadToko()
        {
            SqlDataReader dr;
            string FileName = "Toko";

            string TableName = "Toko";
            label2.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                //lblProgress.Text = "Data 'Toko' is Uploading...";
                refreshForm();
                string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("TokoID", "idtoko", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("NamaToko", "namatoko", Foxpro.enFoxproTypes.Char, 31));
                fields.Add(new Foxpro.DataStruct("Alamat", "alamat", Foxpro.enFoxproTypes.Char, 60));
                fields.Add(new Foxpro.DataStruct("Kota", "kota", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("Telp", "notelp", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("WilID", "idwil", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("PenanggungJawab", "pngjwb", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("PiutangB", "piutang_b", Foxpro.enFoxproTypes.Numeric, 13));
                fields.Add(new Foxpro.DataStruct("PiutangJ", "piutang_j", Foxpro.enFoxproTypes.Numeric, 13));
                fields.Add(new Foxpro.DataStruct("Plafon", "plafon", Foxpro.enFoxproTypes.Numeric, 13));
                fields.Add(new Foxpro.DataStruct("ToJual", "to_jual", Foxpro.enFoxproTypes.Numeric, 13));
                fields.Add(new Foxpro.DataStruct("ToRetPot", "to_retpot", Foxpro.enFoxproTypes.Numeric, 13));
                fields.Add(new Foxpro.DataStruct("JangkaWaktuKredit", "jkw_kredit", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("Cab", "Cab", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cab1", "Cab1", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang2", "cab2", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Tgl1st", "tgl1st", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("Exist", "exist", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("ClassID", "idclass", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("HariKirim", "hari_krm", Foxpro.enFoxproTypes.Numeric, 2));
                fields.Add(new Foxpro.DataStruct("KodePos", "kd_pos", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("Grade", "grade", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Plafon1st", "plafon_1st", Foxpro.enFoxproTypes.Numeric, 10));
                fields.Add(new Foxpro.DataStruct("Flag", "flag", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Bentrok", "bentrok", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("StatusAktif", "lpasif", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("HariSales", "hari_sls", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Daerah", "daerah", Foxpro.enFoxproTypes.Char, 25));
                fields.Add(new Foxpro.DataStruct("Propinsi", "propinsi", Foxpro.enFoxproTypes.Char, 30));
                fields.Add(new Foxpro.DataStruct("AlamatRumah", "alm_rumah", Foxpro.enFoxproTypes.Char, 60));
                fields.Add(new Foxpro.DataStruct("Pengelola", "pengelola", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("TglLahir", "tgl_lahir", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("HP", "hp", Foxpro.enFoxproTypes.Char, 30));
                fields.Add(new Foxpro.DataStruct("Status", "status", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("ThnBerdiri", "th_berdiri", Foxpro.enFoxproTypes.Char, 4));
                fields.Add(new Foxpro.DataStruct("StatusRuko", "lruko", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("JmlCabang", "jml_cabang", Foxpro.enFoxproTypes.Numeric, 2));
                fields.Add(new Foxpro.DataStruct("JmlSales", "jml_sales", Foxpro.enFoxproTypes.Numeric, 2));
                fields.Add(new Foxpro.DataStruct("Kinerja", "kinerja", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("BidangUsaha", "bdg_usaha", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("RefSales", "reff_sls", Foxpro.enFoxproTypes.Char, 35));
                fields.Add(new Foxpro.DataStruct("RefCollector", "reff_col", Foxpro.enFoxproTypes.Char, 35));
                fields.Add(new Foxpro.DataStruct("RefSupervisor", "reff_spv", Foxpro.enFoxproTypes.Char, 35));
                fields.Add(new Foxpro.DataStruct("PlafonSurvey", "plf_survey", Foxpro.enFoxproTypes.Numeric, 13));

                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                index.Add(new Foxpro.IndexStruct("kd_toko", "KD_TOKO"));
                index.Add(new Foxpro.IndexStruct("namatoko", "NAMATOKO"));
                index.Add(new Foxpro.IndexStruct("id_match", "ID_MATCH"));
                index.Add(new Foxpro.IndexStruct("idtoko", "IDTOKO"));
                index.Add(new Foxpro.IndexStruct("idwil", "IDWIL"));
                index.Add(new Foxpro.IndexStruct("kota", "KOTA"));
                index.Add(new Foxpro.IndexStruct("namatoko FOR .NOT.Toko.lpasif.AND..NOT.EMPTY(Toko.idwil)", "NAMATOKO0"));
                index.Add(new Foxpro.IndexStruct("namatoko FOR .NOT.Toko.lpasif", "NAMATOKO1"));
                

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DATAPENUNJANG_UPLOAD_Toko"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();
                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, pbSyncUpload, lblUploadCount);
                    db.Close();
                    //lblProgress.Text = "";
                }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_DeletedHistory_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, "Toko"));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Int, 0));
                    DataTable dt = db.Commands[0].ExecuteDataTable();
                    Foxpro.InsertDeletedRecord(GlobalVar.DbfUpload + "\\", FileName, fields, dt, "kd_toko");
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


        private void UploadSales()
        {
            SqlDataReader dr;
            string FileName = "sales";

            string TableName = "Sales";
            label2.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                //lblProgress.Text = "Data 'Sales' is Uploading...";
                refreshForm();
                string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("SalesID", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("NamaSales", "nm_sales", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("RecID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("TglLahir", "tgl_lahir", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("Alamat", "alamat", Foxpro.enFoxproTypes.Char, 30));
                fields.Add(new Foxpro.DataStruct("Target", "target", Foxpro.enFoxproTypes.Numeric, 16));
                fields.Add(new Foxpro.DataStruct("BatasOD", "batas_od", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("TglMasuk", "tgl_masuk", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglKeluar", "tgl_keluar", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("SalesID", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("NamaSales", "namatoko", Foxpro.enFoxproTypes.Char, 31));

                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                index.Add(new Foxpro.IndexStruct("kd_sales", "KD_SALES"));
                index.Add(new Foxpro.IndexStruct("id_match", "ID_MATCH"));
                index.Add(new Foxpro.IndexStruct("nm_sales", "NM_SALES"));
                index.Add(new Foxpro.IndexStruct("idrec", "IDREC"));
                index.Add(new Foxpro.IndexStruct("kd_sales FOR EMPTY(Sales.tgl_keluar)", "KD_SALES1"));
                

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DATAPENUNJANG_UPLOAD_Sales"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();
                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, pbSyncUpload, lblUploadCount);
                    db.Close();
                    //lblProgress.Text = "";
                }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_DeletedHistory_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, "Sales"));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Int, 0));
                    DataTable dt = db.Commands[0].ExecuteDataTable();
                    Foxpro.InsertDeletedRecord(GlobalVar.DbfUpload + "\\", FileName, fields, dt, "kd_sales");
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
        

        private void UploadCollector()
        {
            SqlDataReader dr;
            string FileName = "colector";
            string TableName = "Collector";
            label2.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                //lblProgress.Text = "Data 'NotaPenjualanDetail' is Uploading...";
                refreshForm();
                string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("id_colect", "id_colect", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("kd_colec", "kd_colec", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("nm_colec", "nm_colec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("tgl_lahir", "tgl_lahir", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("alamat", "alamat", Foxpro.enFoxproTypes.Char, 30));
                fields.Add(new Foxpro.DataStruct("target", "target", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("batas_od", "batas_od", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("tgl_masuk", "tgl_masuk", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("tgl_keluar", "tgl_keluar", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("barang_a", "barang_a", Foxpro.enFoxproTypes.Numeric, 10));
                fields.Add(new Foxpro.DataStruct("barang_b", "barang_b", Foxpro.enFoxproTypes.Numeric, 10));
                fields.Add(new Foxpro.DataStruct("barang_c", "barang_c", Foxpro.enFoxproTypes.Numeric, 10));
                fields.Add(new Foxpro.DataStruct("barang_e", "barang_e", Foxpro.enFoxproTypes.Numeric, 10));
                

                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                index.Add(new Foxpro.IndexStruct("id_colect", "ID_COLECT"));
                index.Add(new Foxpro.IndexStruct("kd_colec", "KD_COLEC"));
                index.Add(new Foxpro.IndexStruct("nm_colec + kd_colec", "NM_COLEC"));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DATAPENUNJANG_UPLOAD_Collector"));                    
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();
                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, pbSyncUpload, lblUploadCount);
                    db.Close();
                    //lblProgress.Text = "";
                }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_DeletedHistory_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, "Collector"));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Int, 0));
                    DataTable dt = db.Commands[0].ExecuteDataTable();
                    Foxpro.InsertDeletedRecord(GlobalVar.DbfUpload + "\\", FileName, fields, dt, "id_colect");
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

        private void UploadStok()
        {
            SqlDataReader dr;
            string FileName = "sasstok";

            string TableName = "Stok";
            label2.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                //lblProgress.Text = "Data 'Stok' is Uploading...";
                refreshForm();
                string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Bundle", "bundel", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("KodeSolo", "kodesolo", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("HrgJual", "hjual", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Hpp", "hpp", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Kendaraan", "kendaraan", Foxpro.enFoxproTypes.Char, 43));
                fields.Add(new Foxpro.DataStruct("NamaTertera", "nm_tertera", Foxpro.enFoxproTypes.Char, 43));
                fields.Add(new Foxpro.DataStruct("PartNo", "partno", Foxpro.enFoxproTypes.Char, 21));
                fields.Add(new Foxpro.DataStruct("Merek", "merek", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Dibungkus", "dibungkus", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("SumberDr", "sumber_dr", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("ProsesID", "idproses", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("SatSolo", "sat_solo", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("Material", "material", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("SatJual", "sat_jual", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("HPPSolo", "hpp_solo", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("HPPSas", "hpp_sas", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("HPPSolo", "hppsolo", Foxpro.enFoxproTypes.Numeric, 8));
                fields.Add(new Foxpro.DataStruct("KodeRak", "kd_rak", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("KodeRak1", "kd_rak1", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("KodeRak2", "kd_rak2", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("JB", "jb", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("StatusPasif", "lpasif", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("Flag1", "flag1", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("TglOpname", "tgl_opnm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglAwal", "tgl_awal", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("QAwal", "q_awal", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("HariRataRata", "q_opnm", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("RppAwal", "rpp_awal", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("QJual", "q_jual", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QBeli", "q_beli", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QReturJual", "q_retj", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QReturBeli", "q_retb", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QOrderJual", "q_ordj", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("PrediksiLamaKirim", "q_ordb", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QMutasi", "q_mutasi", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QKrsi", "q_krsi", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QAngd", "q_angd", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QSelisih", "q_slsh", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QAkhir", "q_akhir", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("StokMin", "stokmin", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("StokMax", "stokmax", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("IsiKoli", "isi_koli", Foxpro.enFoxproTypes.Numeric, 4));

                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                index.Add(new Foxpro.IndexStruct("id_match", "ID_MATCH"));
                index.Add(new Foxpro.IndexStruct("idrec", "ID_REC"));
                index.Add(new Foxpro.IndexStruct("kodesolo", "KODESOLO"));
                index.Add(new Foxpro.IndexStruct("id_brg", "ID_BRG"));
                index.Add(new Foxpro.IndexStruct("nama_stok", "NAMA_STOK"));
                index.Add(new Foxpro.IndexStruct("kd_rak", "KD_RAK"));
                index.Add(new Foxpro.IndexStruct("kd_rak1", "KD_RAK1"));
                index.Add(new Foxpro.IndexStruct("kd_rak2", "KD_RAK2"));
                


                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DATAPENUNJANG_UPLOAD_Stok"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();
                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, pbSyncUpload, lblUploadCount);
                    db.Close();
                    //lblProgress.Text = "";
                }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_DeletedHistory_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, "Stok"));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Int, 0));
                    DataTable dt = db.Commands[0].ExecuteDataTable();
                    Foxpro.InsertDeletedRecord(GlobalVar.DbfUpload + "\\", FileName, fields, dt, "id_brg");
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


        private void UploadTagihanHeader()
        {
                                    
            SqlDataReader dr;
            string FileName = "htagihan";

            string TableName = "TagihanHeader";
            label2.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                //lblProgress.Text = "Data 'Stok' is Uploading...";
                refreshForm();
                string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }


                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
                fields.Add(new Foxpro.DataStruct("id_reg", "id_reg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("no_reg", "no_reg", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("spasi", "spasi", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("tgl_reg", "tgl_reg", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("colector", "colector", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("nm_coll", "nm_coll", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("n_nota", "n_nota", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("n_bayar", "n_bayar", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("n_tagih", "n_tagih", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("wilayah", "wilayah", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("periode_1", "periode_1", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("periode_2", "periode_2", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("t_lama", "t_lama", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("nm_kasir", "nm_kasir", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("rp_giro", "rp_giro", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("rp_trf", "rp_trf", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("rp_tunai", "rp_tunai", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("lbr_giro", "lbr_giro", Foxpro.enFoxproTypes.Numeric, 4));
                fields.Add(new Foxpro.DataStruct("ntoko1", "ntoko1", Foxpro.enFoxproTypes.Numeric, 4));
                fields.Add(new Foxpro.DataStruct("ntoko2", "ntoko2", Foxpro.enFoxproTypes.Numeric, 4));
                fields.Add(new Foxpro.DataStruct("lbr_nota", "lbr_nota", Foxpro.enFoxproTypes.Numeric, 4));
                fields.Add(new Foxpro.DataStruct("rp_only", "rp_only", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("tgl_kbl", "tgl_kbl", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric, 3));

                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                index.Add(new Foxpro.IndexStruct("id_reg", "ID_REG"));
                index.Add(new Foxpro.IndexStruct("no_reg", "NO_REG"));
                index.Add(new Foxpro.IndexStruct("spasi + DTOS(tgl_reg)", "TGL_REG"));
                index.Add(new Foxpro.IndexStruct("id_match", "ID_MATCH"));


                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DATAPENUNJANG_UPLOAD_Tagihan_Header"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();
                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, pbSyncUpload, lblUploadCount);
                    db.Close();
                    //lblProgress.Text = "";
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

        private void UploadTagihanDetail()
        {
            SqlDataReader dr;
            string FileName = "Dtagihan";

            string TableName = "TagihanDetail";
            label2.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                //lblProgress.Text = "Data 'Stok' is Uploading...";
                refreshForm();
                string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }
                

                List<Foxpro.DataStruct> fields2 = new List<Foxpro.DataStruct>();
                fields2.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("id_reg", "id_reg", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("idkp", "idkp", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("idwil", "idwil", Foxpro.enFoxproTypes.Char, 7));
                fields2.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields2.Add(new Foxpro.DataStruct("nama_toko", "nama_toko", Foxpro.enFoxproTypes.Char, 31));
                fields2.Add(new Foxpro.DataStruct("kd_sales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
                fields2.Add(new Foxpro.DataStruct("tgl_tr", "tgl_tr", Foxpro.enFoxproTypes.DateTime, 8));
                fields2.Add(new Foxpro.DataStruct("no_tr", "no_tr", Foxpro.enFoxproTypes.Char, 7));
                fields2.Add(new Foxpro.DataStruct("tgl_jt", "tgl_jt", Foxpro.enFoxproTypes.DateTime, 8));
                fields2.Add(new Foxpro.DataStruct("rp_nota", "rp_nota", Foxpro.enFoxproTypes.Numeric, 14));
                fields2.Add(new Foxpro.DataStruct("rp_bayar", "rp_bayar", Foxpro.enFoxproTypes.Numeric, 14));
                fields2.Add(new Foxpro.DataStruct("rp_tagih", "rp_tagih", Foxpro.enFoxproTypes.Numeric, 14));
                fields2.Add(new Foxpro.DataStruct("p_lama", "p_lama", Foxpro.enFoxproTypes.Numeric, 14));
                fields2.Add(new Foxpro.DataStruct("rp_giro", "rp_giro", Foxpro.enFoxproTypes.Numeric, 14));
                fields2.Add(new Foxpro.DataStruct("rp_cash", "rp_cash", Foxpro.enFoxproTypes.Numeric, 14));
                fields2.Add(new Foxpro.DataStruct("rp_trf", "rp_trf", Foxpro.enFoxproTypes.Numeric, 14));
                fields2.Add(new Foxpro.DataStruct("rp_mutasi", "rp_mutasi", Foxpro.enFoxproTypes.Numeric, 14));
                fields2.Add(new Foxpro.DataStruct("rp_pot", "rp_pot", Foxpro.enFoxproTypes.Numeric, 10));
                fields2.Add(new Foxpro.DataStruct("rp_disc", "rp_disc", Foxpro.enFoxproTypes.Numeric, 10));
                fields2.Add(new Foxpro.DataStruct("rp_retur", "rp_retur", Foxpro.enFoxproTypes.Numeric, 14));
                fields2.Add(new Foxpro.DataStruct("no_bpp", "no_bpp", Foxpro.enFoxproTypes.Char, 10));
                fields2.Add(new Foxpro.DataStruct("rp_only", "rp_only", Foxpro.enFoxproTypes.Numeric, 14));
                fields2.Add(new Foxpro.DataStruct("rp_exp", "rp_exp", Foxpro.enFoxproTypes.Numeric, 12));
                fields2.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields2.Add(new Foxpro.DataStruct("tgl_tagih", "tgl_tagih", Foxpro.enFoxproTypes.DateTime, 8));
                fields2.Add(new Foxpro.DataStruct("flag", "flag", Foxpro.enFoxproTypes.Logical, 1));
                fields2.Add(new Foxpro.DataStruct("ket", "ket", Foxpro.enFoxproTypes.Char, 30));
                fields2.Add(new Foxpro.DataStruct("idtagih", "idtagih", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("nm_coll", "nm_coll", Foxpro.enFoxproTypes.Numeric, 10));

                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                index.Add(new Foxpro.IndexStruct("id_reg", "ID_REG"));
                index.Add(new Foxpro.IndexStruct("kd_sales", "KD_SALES"));
                index.Add(new Foxpro.IndexStruct("idrec", "IDREC"));
                index.Add(new Foxpro.IndexStruct("idkp", "IDKP"));
                index.Add(new Foxpro.IndexStruct("kd_toko+id_reg", "KD_TOKO"));
                index.Add(new Foxpro.IndexStruct("id_match", "ID_MATCH"));
                index.Add(new Foxpro.IndexStruct("idkp+id_reg", "IDKPREG"));
                index.Add(new Foxpro.IndexStruct("idwil", "IDWIL"));
                index.Add(new Foxpro.IndexStruct("idtagih", "IDTAGIH"));



                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DATAPENUNJANG_UPLOAD_TagihanDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();
                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields2, dr, index, this, pbSyncUpload, lblUploadCount);
                    db.Close();
                    //lblProgress.Text = "";
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

                               

    }
}
