using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using ISA.Trading.Class;

namespace ISA.Trading.Communicator
{
    public partial class frmDumpUpload : ISA.Trading.BaseForm
    {
        List<string> files = new List<string>();
        int jumlahTable = 38;
        int ctr = 0;
        string dbPath;
        public frmDumpUpload()
        {
            InitializeComponent();
            dbPath = LookupInfo.GetValue("FOXPRO_ENGINE", "FOXPRO_PATH");
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadCount()
        {
            ctr++;
            lblUploadCount.Text = ctr.ToString() + "/" + jumlahTable.ToString();
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }
        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(GlobalVar.DbfUpload + "\\DumpUPLOAD\\"))
            {
                Directory.CreateDirectory(GlobalVar.DbfUpload + "\\DumpUPLOAD\\");
            }

            UploadAntarGudang();
            UploadAntarGudangDetail();
            UploadExpedisi();
            UploadKompensasi();
            UploadKoreksi();
            UploadToko();
            UploadSales();
            UploadStok();
            UploadPemasok();
            UploadOpname();
            UploadOrderPembelian();
            UploadOrderPembelianDetail();
            UploadRekapKoli();
            UploadRekapKoliDetail();
            UploadRekapKoliSubDetail();
            UploadMutasi();
            UploadMutasiDetail();
            UploadPeminjaman();
            UploadPeminjamanDetail();
            UploadPengembalian();
            UploadPengembalianDetail();
            UploadSelisih();
            UploadSelisihDetail();
            UploadReturPembelian();
            UploadReturPembelianDetail();
            UploadPenjualanPotongan();
            UploadPenjualanPotonganDetail();
            UploadNotaPembelian();
            UploadNotaPembelianDetail();
            UploadNotaPenjualan();
            UploadNotaPenjualanDetail(); //*
            UploadReturPenjualan();
            UploadReturPenjualanDetail();
            UploadOrderPenjualan();
            UploadOrderPenjualanDetail();//*
            UploadBarangBonus();
            UploadBarangBonusDetail();
            UploadStatusToko();
            ZipFile(files);
            MessageBox.Show("Dump Upload Selesai. Lokasi file: " + GlobalVar.DbfUpload + "\\DumpUPLOAD\\dbfmatch.zip");
        }


        #region Antar Gudang
        private void UploadAntarGudang()
        {
            SqlDataReader dr;
            string FileName = "hkrmagud";
            string TableName = "Antar Gudang";
            label1.Text = TableName;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                pbSyncUpload.Value = 0;
                lblProgress.Text = String.Format( "Data {0} is Uploading...",TableName);
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idhkrmagud", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("DrGudang", "dr_gud", Foxpro.enFoxproTypes.Char, 4));
                fields.Add(new Foxpro.DataStruct("KeGudang", "ke_gud", Foxpro.enFoxproTypes.Char, 4));
                fields.Add(new Foxpro.DataStruct("TglKirim", "tgl_krm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglTerima", "tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoAG", "no_ag", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("Pengirim", "pengirim", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("Penerima", "penerima", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("DrCheck1", "drcheck1", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("DrCheck2", "drcheck2", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("KeCheck1", "kecheck1", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("KeCheck2", "kecheck2", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 43));
                fields.Add(new Foxpro.DataStruct("Expedisi", "exp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("NoKendaraan", "no_kend", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("NamaSopir", "nm_sopir", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("KirimTerimaID", "id_krmtrm", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_AntarGudang"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr,dbPath,this, pbSyncUpload, lblUploadCount );
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
            string FileName = "dkrmagud";
            string TableName = "Antar Gudang Detail";
            label1.Text = TableName;
         
            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = String.Format("Data {0} is Uploading...", TableName);
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("HeaderID", "iddkrmagud", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("RecordID", "idhkrmagud", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("KodeBarang", "id_brg", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("QtyKirim", "qty_krm", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("QtyTerima", "qty_trm", Foxpro.enFoxproTypes.Numeric, 20));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("Hpp", "hpp", Foxpro.enFoxproTypes.Numeric, 10));
                fields.Add(new Foxpro.DataStruct("Ongkos", "ongkos", Foxpro.enFoxproTypes.Numeric, 4));
                fields.Add(new Foxpro.DataStruct("DrGudang", "drgud", Foxpro.enFoxproTypes.Char, 4));
                fields.Add(new Foxpro.DataStruct("KeGudang", "kegud", Foxpro.enFoxproTypes.Char, 8));
                fields.Add(new Foxpro.DataStruct("TglKirim", "tgl_krm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglTerima", "tgl_trm", Foxpro.enFoxproTypes.DateTime, 1));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("QtyDO", "qty_do", Foxpro.enFoxproTypes.Numeric, 5));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_AntarGudangDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        //Still Problem
        #region Expedisi
        private void UploadExpedisi()
        {
            SqlDataReader dr;
            string FileName = "expedisi";
            string TableName = "Expedisi";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = String.Format("Data {0} is Uploading...", TableName);
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
                fields.Add(new Foxpro.DataStruct("No","No", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("KodeExpedisi", "kode", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("NamaExpedisi", "Nm_exp", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Alamat", "alamat", Foxpro.enFoxproTypes.Char, 60));
                fields.Add(new Foxpro.DataStruct("Telp", "telepon", Foxpro.enFoxproTypes.Char, 32));
                fields.Add(new Foxpro.DataStruct("KotaTujuan", "kota_tj", Foxpro.enFoxproTypes.Char, 80));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_Expedisi"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Kompensasi
        private void UploadKompensasi()
        {
            SqlDataReader dr;
            string FileName = "kompen";
            string TableName = "Kompensasi";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = String.Format("Data {0} is Uploading...", TableName);
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("DiscKompensasi", "disc_komp", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));


                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_Kompensasi"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Koreksi
        private void UploadKoreksi()
        {
            SqlDataReader dr;
            string FileName = "kortrans";
            string TableName = "Koreksi";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = String.Format("Data {0} is Uploading...", TableName);
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "id_koreksi", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("IdTr", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("DetailID", "id_detail", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("TglKoreksi", "tglkoreksi", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoKoreksi", "no_koreksi", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("KelompokBarang", "klp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("QtyNotaBaru", "j_nota", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("HrgBeliBaru", "h_jual", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("HrgPokok", "h_pokok", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Disc1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc2", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("IDDisc", "id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Potongan", "pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("Pemasok", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("KodeSales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("Sumber", "sumber", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("HrgBeliKoreksi", "h_koreksi", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("LinkID", "dt_link", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("KodeGudang", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));
                fields.Add(new Foxpro.DataStruct("QtyNotaKoreksi", "n_koreksi", Foxpro.enFoxproTypes.Numeric, 6));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_Koreksi"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Toko
        private void UploadToko()
        {
            SqlDataReader dr;
            string FileName = "toko";
            string TableName = "Toko";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = String.Format("Data {0} is Uploading...", TableName);
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
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

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_Toko"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Sales
        private void UploadSales()
        {
            SqlDataReader dr;
            string FileName = "sales";
            string TableName = "Sales";
            label1.Text = TableName;
            

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = String.Format("Data {0} is Uploading...", TableName);
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
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

                fields.Add(new Foxpro.DataStruct("NamaToko","Namatoko", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("KodeToko","Kd_toko", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_Sales"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Stok
        private void UploadStok()
        {
            SqlDataReader dr;
            string FileName = "sasstok";
            string TableName = "Stok";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = String.Format("Data {0} is Uploading...", TableName);
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Bundle", "Bundel", Foxpro.enFoxproTypes.Char, 3));
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

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_Stok"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region OrderPembelian
        private void UploadOrderPembelian()
        {
            SqlDataReader dr;
            string FileName = "hosheet";
            string TableName = "Order Pembelian";
            label1.Text = TableName;


            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = String.Format("Data {0} is Uploading...", TableName);
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NoRequest", "no_rq", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglRequest", "tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("Pemasok", "pemasok", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("Cabang1", "c1", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang2", "c2", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("EstHrgJual", "est_rpjual", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("EstHPP", "est_rphpp", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("NItem", "nitem", Foxpro.enFoxproTypes.Numeric, 4));
                fields.Add(new Foxpro.DataStruct("EstRptm", "est_rptrm", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("NoACC", "no_acc", Foxpro.enFoxproTypes.Char, 5));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 10));


                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_OrderPembelian"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

       
        private void UploadOrderPembelianDetail()
        {
            SqlDataReader dr;
            string FileName = "dosheet";
            string TableName = "Order Pembelian Detail";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = String.Format("Data {0} is Uploading...", TableName);
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("HeaderID", "idheader", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("QtyBO", "j_bo", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyTambahan", "j_plus", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyRq", "j_rq", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyDO", "j_do", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyTrm", "j_trm", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("IDTr", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("HrgJual", "h_jual", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("HPPSolo", "hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 90));
                fields.Add(new Foxpro.DataStruct("TglRequest", "tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("QtyJual", "q_jual", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("QtyAkhir", "q_akhir", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Keterangan", "ket", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("KodeGudang", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_OrderPembelianDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region RekapKoli
        private void UploadRekapKoli()
        {
            SqlDataReader dr;
            string FileName = "hxpdc";
            string TableName = "Rekap Koli";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'RekapKoli' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("TglSuratJalan", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoSuratJalan", "no_sj", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("WilID", "idwil", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("NamaToko", "nm_toko", Foxpro.enFoxproTypes.Char, 31));
                fields.Add(new Foxpro.DataStruct("Alamat", "alamat", Foxpro.enFoxproTypes.Char, 60));
                fields.Add(new Foxpro.DataStruct("Kota", "kota", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("TglKeluar", "tgl_klr", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("KodeExp1", "kd_exp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("Shift", "shift", Foxpro.enFoxproTypes.Numeric, 1));
                fields.Add(new Foxpro.DataStruct("Jumlah", "jumlah", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("BiayaExp1", "by_exp", Foxpro.enFoxproTypes.Numeric, 10));
                fields.Add(new Foxpro.DataStruct("KodeExp2", "kd_exp2", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("KodeExp3", "kd_exp3", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("BiayaExp2", "by_exp2", Foxpro.enFoxproTypes.Numeric, 10));
                fields.Add(new Foxpro.DataStruct("BiayaExp3", "by_exp3", Foxpro.enFoxproTypes.Numeric, 10));
                fields.Add(new Foxpro.DataStruct("NPrint", "nprint", Foxpro.enFoxproTypes.Numeric, 1));
                fields.Add(new Foxpro.DataStruct("KP", "kp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));


                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_RekapKoli"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        private void UploadRekapKoliSubDetail()
        {
            SqlDataReader dr;
            string FileName = "cxpdc";
            string TableName = "Rekap Koli Sub Detail";
            label1.Text = TableName;          

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'RekapKoliSubDetail' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("HtrID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NoNota", "no_nota", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Uraian", "uraian", Foxpro.enFoxproTypes.Char, 12));
                fields.Add(new Foxpro.DataStruct("Jumlah", "jumlah", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Satuan", "satuan", Foxpro.enFoxproTypes.Char, 5));
                fields.Add(new Foxpro.DataStruct("Keterangan", "ket", Foxpro.enFoxproTypes.Char, 30));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("Flag", "Flag", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_RekapKoliSubDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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


        private void UploadRekapKoliDetail()
        {
            SqlDataReader dr;
            string FileName = "dxpdc";
            string TableName = "Rekap Koli Detail";
            label1.Text = TableName;   
           
            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'RekapKoliDetail' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("HtrID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NotaJualRecID", "idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NoDO", "no_do", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("NoNota", "no_nota", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TunaiKredit", "tk", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("Nominal", "nominal", Foxpro.enFoxproTypes.Numeric, 10));
                fields.Add(new Foxpro.DataStruct("Uraian", "uraian", Foxpro.enFoxproTypes.Char, 12));
                fields.Add(new Foxpro.DataStruct("Jumlah", "jumlah", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Satuan", "satuan", Foxpro.enFoxproTypes.Char, 5));
                fields.Add(new Foxpro.DataStruct("KodeSales", "sales", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("Keterangan", "ket", Foxpro.enFoxproTypes.Char, 30));
                fields.Add(new Foxpro.DataStruct("NoResi", "no_resi", Foxpro.enFoxproTypes.Char, 15));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_RekapKoliDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Pemasok
        private void UploadPemasok()
        {
            SqlDataReader dr;
            string FileName = "pemasok";
            string TableName = "Pemasok";
            label1.Text = TableName;   

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'Pemasok' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("PemasokID", "idp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("Nama", "nama", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("Lengkap", "lengkap", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Alamat", "alamat", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Kota", "kota", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Telp", "telp", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("Fax", "fax", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("Kontak", "kontak", Foxpro.enFoxproTypes.Char, 21));
                fields.Add(new Foxpro.DataStruct("Keterangan", "keterangan", Foxpro.enFoxproTypes.Char, 43));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_Pemasok"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Opname
        private void UploadOpname()
        {
            SqlDataReader dr;
            string FileName = "stokopnm";
            string TableName = "Stok Opname";
            label1.Text = TableName;
            

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'Opname' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("TglOpname", "tgl_opnm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("QtyOpname", "qty_opnm", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("SatJual", "sat", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("Keterangan", "ket_opnm", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("KodeGudang", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_OpnameHistory"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Mutasi
        private void UploadMutasi()
        {
            SqlDataReader dr;
            string FileName = "hmutstok";
            string TableName = "Mutasi Stok";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'Mutasi' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("MutasiID", "id_mts", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("TglMutasi", "tgl_mts", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NomorMutasi", "no_mts", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("KeteranganMutasi", "ket_mts", Foxpro.enFoxproTypes.Char, 63));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("LAudit", "laudit", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("TipeMutasi", "type", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("MutasiPlus", "mts_plus", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("MutasiMinus", "mts_minus", Foxpro.enFoxproTypes.Numeric, 9));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_Mutasi"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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
       

        private void UploadMutasiDetail()
        {
            SqlDataReader dr;
            string FileName = "dmutstok";
            string TableName = "Mutasi Stok Detail";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'MutasiDetail' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("MutasiID", "id_mts", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("QtyMutasi", "j_mts", Foxpro.enFoxproTypes.Numeric, 6));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("SatJual", "sat", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("Kelompok", "klp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("HrgPokok", "h_pokok", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("HppSolo", "hpp_solo", Foxpro.enFoxproTypes.Numeric, 8));
                fields.Add(new Foxpro.DataStruct("Keterangan", "catatan", Foxpro.enFoxproTypes.Char, 43));
                fields.Add(new Foxpro.DataStruct("TglMutasi", "tgl_mts", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("Syncflag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("KodeBarang", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("TipeMutasi", "type", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Gudang", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_MutasiDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Peminjaman
        private void UploadPeminjaman()
        {
            SqlDataReader dr;
            string FileName = "hpinjam";
            string TableName = "Peminjaman";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'Peminjaman' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NoBukti", "nobukti", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("TglKeluar", "tgl_kelpj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglBatas", "tgl_btspj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("StaffPenjualan", "penjstaff", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 25));
                fields.Add(new Foxpro.DataStruct("NPrint", "print", Foxpro.enFoxproTypes.Numeric, 1));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("KodeSales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_Peminjaman"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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


        private void UploadPeminjamanDetail()
        {
            SqlDataReader dr;
            string FileName = "dpinjam";
            string TableName = "Peminjaman Detail";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'PeminjamanDetail' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("TransactionID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("KodeBarang", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("KodeSales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("Satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("QtyMemo", "qty_kelpj", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyKeluarGudang", "qty_kelgd", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyKembali", "qty_kmb", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("catatan", "catatan", Foxpro.enFoxproTypes.Char, 25));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_PeminjamanDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Pengembalian
        private void UploadPengembalian()
        {
            SqlDataReader dr;
            string FileName = "hkembali";
            string TableName = "Pengembalian";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'Pengembalian' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NoBukti", "nobukti", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("TglKembaliPJ", "tgl_kmbpj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglKembaliGdg", "tgl_kmbgd", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 25));
                fields.Add(new Foxpro.DataStruct("NPrint", "print", Foxpro.enFoxproTypes.Numeric, 1));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("KodeSales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_Pengembalian"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        private void UploadPengembalianDetail()
        {
            SqlDataReader dr;
            string FileName = "dkembali";
            string TableName = "Pengembalian Detail";
            label1.Text = TableName;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'PengembalianDetail' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("TransactionID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("IDPinjam", "iddpinjam", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("Satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("NoPinjam", "nopjm", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("QtyKembali", "qty_kmb", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 25));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_PengembalianDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Selisih
        private void UploadSelisih()
        {
            SqlDataReader dr;
            string FileName = "hselisih";
            string TableName = "Selisih";
            label1.Text = TableName;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'Selisih' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idhselisih", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("KodeGudang", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));
                fields.Add(new Foxpro.DataStruct("TglSelisih", "tgl", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("Cabang", "cab", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("NoSelisih", "no_slsh", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("Keterangan", "ket", Foxpro.enFoxproTypes.Char, 30));
                fields.Add(new Foxpro.DataStruct("Pemeriksa1", "pmrks1", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("Pemeriksa2", "pmrks2", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_Selisih"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        private void UploadSelisihDetail()
        {
            SqlDataReader dr;
            string FileName = "dselisih";
            string TableName = "Selisih Detail";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'SelisihDetail' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("HeaderId", "idhselisih", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("RecordID", "iddselisih", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("TglSelisih", "tgl", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("Cabang", "cab", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("KodeGudang", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));
                fields.Add(new Foxpro.DataStruct("KodeBarang", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("QtyComp", "q_comp", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("QtyOpname", "q_opn", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("QtySelisih", "q_slsh", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 30));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_SelisihDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Retur Pembelian
        private void UploadReturPembelian()
        {
            SqlDataReader dr;
            string FileName = "hreturb";
            string TableName = "Retur Pembelian";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'ReturPembelian' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("ReturID", "idretur", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NoRetur", "no_retur", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglRetur", "tgl_retur", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("Pemasok", "pemasok", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("Penerima", "penerima", Foxpro.enFoxproTypes.Char, 17));
                fields.Add(new Foxpro.DataStruct("TglKeluar", "tgl_keluar", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NilaiRetur", "rp_nilai", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("Pengirim", "pengirim", Foxpro.enFoxproTypes.Char, 17));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("IsClosed", "laudit", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("NPrint", "nprint", Foxpro.enFoxproTypes.Numeric, 1));
                fields.Add(new Foxpro.DataStruct("NoMPR", "no_mpr", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglKirim", "tgl_kirim", Foxpro.enFoxproTypes.DateTime, 8));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_ReturPembelian"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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


        private void UploadReturPembelianDetail()
        {
            SqlDataReader dr;
            string FileName = "dreturb";
            string TableName = "Retur Pembelian Detail";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'ReturPembelianDetail' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("ReturID", "idretur", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("IdHtr", "idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NotaBeliDetailRecID", "iddtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("KodeRetur", "kdretur", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("Pemasok", "pemasok", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("QtyGudang", "q_gudang", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyTerima", "q_terima", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("Kelompok", "klp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("HrgBeli", "h_beli", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("HrgNet", "h_net", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("HrgPokok", "h_pokok", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("HPPSolo", "hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Potongan", "pot_rp", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("DiscFormula", "id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Disc1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("RecordId", "id_koreksi", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("TglKeluar", "tgl_keluar", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglNota", "tgl_beli", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("KodeGudang", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));
                //fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_ReturPembelianDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Potongan
        private void UploadPenjualanPotongan()
        {
            SqlDataReader dr;
            string FileName = "hpotj";
            string TableName = "Penjualan Potongan";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'PenjualanPotongan' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("TrID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("PotID", "idpot", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NoPot", "Nopot", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("TglPot", "Tgl_pot", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("Dil", "Dil", Foxpro.enFoxproTypes.Numeric, 8));
                fields.Add(new Foxpro.DataStruct("Disc", "Disc", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("RpNet", "Rp_net", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 17));
                fields.Add(new Foxpro.DataStruct("TglACC", "Tgl_acc", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("DilACC", "Dil_acc", Foxpro.enFoxproTypes.Numeric, 11));
                fields.Add(new Foxpro.DataStruct("CatACC", "Cat_acc", Foxpro.enFoxproTypes.Char, 17));
                fields.Add(new Foxpro.DataStruct("DiscACC", "Disc_acc", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Dib", "Dib", Foxpro.enFoxproTypes.Numeric, 8));
                fields.Add(new Foxpro.DataStruct("DibAcc", "Dib_acc", Foxpro.enFoxproTypes.Numeric, 10));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("IdLink", "Id_link", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("KodeToko", "Kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("StatusACC", "acc", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_PenjualanPotongan"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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


        private void UploadPenjualanPotonganDetail()
        {
            SqlDataReader dr;
            string FileName = "dpotj";
            string TableName = "Penjualan Potongan Detail";
            label1.Text = TableName;
         
            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'PenjualanPotonganDetail' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("TrID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("ID", "id", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("TglPot", "tgl_pot", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("Disc", "Disc", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("Dib", "Dib", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 17));
                fields.Add(new Foxpro.DataStruct("ACC", "acc", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("TglACC", "tgl_acc", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("DiscACC", "disc_acc", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("DibAcc", "dib_acc", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("CatACC", "cat_acc", Foxpro.enFoxproTypes.Char, 17));
                fields.Add(new Foxpro.DataStruct("QtyRetur", "j_retur", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("DtLink", "dt_link", Foxpro.enFoxproTypes.Char, 23));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_PenjualanPotonganDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Nota Pembelian
        private void UploadNotaPembelian()
        {
            SqlDataReader dr;
            string FileName = "htransb";
            string TableName = "Nota Pembelian";
            label1.Text = TableName;
           
            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'NotaPembelian' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NoRequest", "no_rq", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglRequest", "tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoDO", "no_do", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglTransaksi", "tgl_trans", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoNota", "no_nota", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("TglNota", "tgl_nota", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoSuratJalan", "no_sj", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("TglSuratJalan", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglTerima", "tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("HariKredit", "hr_krdt", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("Pemasok", "pemasok", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("HargaBeli", "rp_beli", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("HargaNet", "rp_net", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("Disc1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Expedisi", "Expedisi", Foxpro.enFoxproTypes.Char, 9));
                fields.Add(new Foxpro.DataStruct("IsClosed", "Laudit", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("DiscFormula", "id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("PPN", "ppn", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Memo, 4000));//Error syntax if open
                fields.Add(new Foxpro.DataStruct("Cabang", "cab", Foxpro.enFoxproTypes.Char, 2));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_NotaPembelian"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        private void UploadNotaPembelianDetail()
        {
            SqlDataReader dr;
            string FileName = "dtransb";
            string TableName = "Nota Pembelian Detail";
            label1.Text = TableName;
          
            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'NotaPembelianDetail' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("HeaderRecID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("Kelompok", "klp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("QtyRequest", "j_rq", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyDO", "j_do", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtySuratJalan", "j_sj", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyNota", "j_nota", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyRetur", "j_retur", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("TglTerima", "tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("HrgBeli", "h_beli", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("HrgPokok", "h_pokok", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("HPPSolo", "hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Disc1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("DiscFormula", "id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Pot", "pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("KoreksiID", "id_koreksi", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("PPN", "Ppn", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("Pemasok", "Pemasok", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("KodeGudang", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_NotaPembelianDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Nota Penjualan
        private void UploadNotaPenjualan()
        {
            SqlDataReader dr;
            string FileName = "htransj";
            string TableName = "Nota Penjualan";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'NotaPenjualan' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("HtrID", "idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("RecordID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Cabang1", "cab1", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang2", "cab2", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang3", "cab3", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("NoRequest", "no_rq", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglRequest", "tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoDO", "no_do", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglDO", "tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoNota", "no_nota", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglNota", "tgl_nota", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoSuratJalan", "no_sj", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglSuratJalan", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglTerima", "tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("HariKredit", "hr_krdt", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("NamaSales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("NamaToko", "nm_toko", Foxpro.enFoxproTypes.Char, 31));
                fields.Add(new Foxpro.DataStruct("AlamatKirim", "al_kirim", Foxpro.enFoxproTypes.Char, 60));
                fields.Add(new Foxpro.DataStruct("Kota", "kota", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("Jual1", "rp_jual", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("Jual2", "rp_jual2", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("Jual3", "rp_jual3", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("Net1", "rp_net", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("Net2", "rp_net2", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("Net3", "rp_net3", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("Disc1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Potongan1", "pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("Potongan2", "pot_rp2", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("Potongan3", "pot_rp3", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("Fee1", "rp_fee1", Foxpro.enFoxproTypes.Numeric, 11));
                fields.Add(new Foxpro.DataStruct("Fee2", "rp_fee2", Foxpro.enFoxproTypes.Numeric, 11));
                fields.Add(new Foxpro.DataStruct("Expedisi", "Expedisi", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("isClosed", "Laudit", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("DiscID", "id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Memo, 4000));
                fields.Add(new Foxpro.DataStruct("Catatan1", "catatan1", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan2", "catatan2", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan3", "catatan3", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan4", "catatan4", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan5", "catatan5", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("TglStrm", "tgl_strm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglReorder", "tgl_reord", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("Lbo", "lbo", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("LinkID", "id_link", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("TransactionType", "id_tr", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("HariKirim", "hari_krm", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("HariSelesai", "hari_sls", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("NPrint", "nprint", Foxpro.enFoxproTypes.Numeric, 2));
                fields.Add(new Foxpro.DataStruct("NoAcc", "no_acc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Shift", "shift", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("Checker1", "checker_1", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("Checker2", "checker_2", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("Cab0", "cab0", Foxpro.enFoxproTypes.Char, 2));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_NotaPenjualan"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        private void UploadNotaPenjualanDetail()
        {
            SqlDataReader dr;
            string FileName = "dtransj";
            string TableName = "Nota Penjualan Detail";
            label1.Text = TableName;
           
            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'NotaPenjualanDetail' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("HtrID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("Kelompok", "Klp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("QtyRequest", "j_rq", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyDO", "j_do", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtySuratJalan", "j_sj", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyNota", "j_nota", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyKoli", "j_koli", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyRetur", "j_retur", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("KoliAwal", "koli_awal", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("KoliAkhir", "koli_akhir", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("NoKoli", "no_koli", Foxpro.enFoxproTypes.Char, 15));
                fields.Add(new Foxpro.DataStruct("Satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("TglSuratJalan", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("HrgJual", "h_jual", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("HrgPokok", "h_pokok", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("HrgSolo", "hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Disc1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Pot", "pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("DiscFormula", "id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("RecordID", "id_koreksi", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("NoDOBO", "no_bodo", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("NPackingListPrint", "nprint", Foxpro.enFoxproTypes.Numeric, 1));
                fields.Add(new Foxpro.DataStruct("NoACC", "no_acc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("KetKoli", "ket_koli", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("KodeGudang", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_NotaPenjualanDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Retur Penjualan
        private void UploadReturPenjualan()
        {
            SqlDataReader dr;
            string FileName = "hreturj";
            string TableName = "Retur Penjualan";
            label1.Text = TableName;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'ReturPenjualan' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("Cabang1", "cab1", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang2", "cab2", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("ReturID", "idretur", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NoMPR", "no_memo", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("NoNotaRetur", "no_ret", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("NoTolak", "no_tolak", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglMPR", "tgl_memo", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglNotaRetur", "tgl_ret", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglTolak", "tgl_tolak", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("NamaToko", "nm_toko", Foxpro.enFoxproTypes.Char, 31));
                fields.Add(new Foxpro.DataStruct("AlamatKirim", "al_kirim", Foxpro.enFoxproTypes.Char, 60));
                fields.Add(new Foxpro.DataStruct("Kota", "kota", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("Pengambilan", "pngmbln", Foxpro.enFoxproTypes.Char, 17));
                fields.Add(new Foxpro.DataStruct("TglPengambilan", "tgl_pngmb", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglGudang", "tgl_gudang", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("RpNilai1", "rp_nilai1", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNilai2", "rp_nilai2", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNilai3", "rp_nilai3", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNilai", "rp_nilai", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("BagPenjualan", "bag_penj", Foxpro.enFoxproTypes.Char, 17));
                fields.Add(new Foxpro.DataStruct("Penerima", "penerima", Foxpro.enFoxproTypes.Char, 17));
                fields.Add(new Foxpro.DataStruct("LinkID", "dt_link", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("isClosed", "laudit", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("NPrint", "nprint", Foxpro.enFoxproTypes.Numeric, 1));
                fields.Add(new Foxpro.DataStruct("TglRQRetur", "tgl_rqret", Foxpro.enFoxproTypes.DateTime, 8));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_ReturPenjualan"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        private void UploadReturPenjualanDetail()
        {
            SqlDataReader dr;
            string FileName = "dreturj";
            string TableName = "Retur Penjualan Detail";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'ReturPenjualanDetail' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("ReturID", "idretur", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("HtrID", "idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NotaJualDetailRecID", "iddtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("KodeRetur", "kdretur", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("KodeSales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("NoNota", "asalnota", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Kelompok", "klp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("QtyMemo", "q_memo", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyTarik", "q_tarik", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyTerima", "q_terima", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyGudang", "q_gudang", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyTolak", "q_tolak", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("HrgJual", "h_jual", Foxpro.enFoxproTypes.Numeric, 8));
                fields.Add(new Foxpro.DataStruct("HrgNetto1", "h_net1", Foxpro.enFoxproTypes.Numeric, 8));
                fields.Add(new Foxpro.DataStruct("HrgNetto2", "h_net2", Foxpro.enFoxproTypes.Numeric, 8));
                fields.Add(new Foxpro.DataStruct("HrgNetto3", "h_net3", Foxpro.enFoxproTypes.Numeric, 8));
                fields.Add(new Foxpro.DataStruct("HrgNetto", "h_net", Foxpro.enFoxproTypes.Numeric, 8));
                fields.Add(new Foxpro.DataStruct("HrgPokok", "h_pokok", Foxpro.enFoxproTypes.Numeric, 8));
                fields.Add(new Foxpro.DataStruct("HppSolo", "hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Potongan", "pot_rp", Foxpro.enFoxproTypes.Numeric, 8));
                fields.Add(new Foxpro.DataStruct("DiscFormula", "id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Disc1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("RecordID", "id_koreksi", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("Catatan1", "catatan", Foxpro.enFoxproTypes.Char, 30));
                fields.Add(new Foxpro.DataStruct("Catatan2", "catatan1", Foxpro.enFoxproTypes.Char, 30));
                fields.Add(new Foxpro.DataStruct("TglGudang", "tgl_gudang", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Kategori", "kategori", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("KodeGudang", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));
                fields.Add(new Foxpro.DataStruct("NoACC", "no_acc", Foxpro.enFoxproTypes.Char, 6));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_ReturPenjualanDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Order Penjualan
        private void UploadOrderPenjualan()
        {
            SqlDataReader dr;
            string FileName = "hhtransj";
            string TableName = "Order Penjualan";
            label1.Text = TableName;
          
            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'OrderPenjualan' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("HtrID", "idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Cabang1", "cab1", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang2", "cab2", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang3", "cab3", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("NoRequest", "no_rq", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglRequest", "tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoDO", "no_do", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglDO", "tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoACCPiutang", "no_nota", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglACCPiutang", "tgl_nota", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("StatusBatal", "no_sj", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglSuratJalan", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglTerima", "tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("HariKredit", "hr_krdt", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("KodeSales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("NamaToko", "nm_toko", Foxpro.enFoxproTypes.Char, 31));
                fields.Add(new Foxpro.DataStruct("AlamatKirim", "al_kirim", Foxpro.enFoxproTypes.Char, 60));
                fields.Add(new Foxpro.DataStruct("Kota", "kota", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("HargaJual", "rp_jual", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("HargaJual2", "rp_jual2", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("HargaJual3", "rp_jual3", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("HargaNet", "rp_net", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("HargaNet2", "rp_net2", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("HargaNet3", "rp_net3", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("Disc1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Potongan", "pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("Plafon", "pot_rp2", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("SaldoPiutang", "pot_rp3", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("QtyTolak", "rp_fee1", Foxpro.enFoxproTypes.Numeric, 11));
                fields.Add(new Foxpro.DataStruct("Overdue", "rp_fee2", Foxpro.enFoxproTypes.Numeric, 11));
                fields.Add(new Foxpro.DataStruct("Expedisi", "expedisi", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("IsClosed", "laudit", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("DiscFormula", "id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Memo, 4));
                fields.Add(new Foxpro.DataStruct("Catatan1", "catatan1", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan2", "catatan2", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan3", "catatan3", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan4", "catatan4", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan5", "catatan5", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("NoDOBO", "no_dobo", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglReorder", "tgl_reord", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("StatusBO", "lbo", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("LinkID", "id_link", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("TransactionType", "id_tr", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("HariKirim", "hari_krm", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("HariSales", "hari_sls", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("NPrint", "nprint", Foxpro.enFoxproTypes.Numeric, 2));
                fields.Add(new Foxpro.DataStruct("NoACCPusat", "no_acc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Shift", "shift", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("ACCPiutangID", "checker_1", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("Checker2", "checker_2", Foxpro.enFoxproTypes.Char, 11));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_OrderPenjualan"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        private void UploadOrderPenjualanDetail()
        {
            SqlDataReader dr;
            string FileName = "dhtransj";
            string TableName = "Order Penjualan Detail";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'OrderPenjualanDetail' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("HtrID", "idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("Kelompok", "klp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("QtyRequest", "j_rq", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyDO", "j_do", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtySuratJalan", "j_sj", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyNota", "j_nota", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyRetur", "j_retur", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyKoli", "j_koli", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("KoliAwal", "koli_awal", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("KoliAkhir", "koli_akhir", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("NoKoli", "no_koli", Foxpro.enFoxproTypes.Char, 15));
                fields.Add(new Foxpro.DataStruct("Satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("TglSuratJalan", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("HrgJual", "h_jual", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("HRgPokok", "h_pokok", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("HrgSolo", "hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Disc1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Pot", "pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("DiscFormula", "id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("RecordID", "id_koreksi", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("NoDOBO", "no_bodo", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("NBOPrint", "nprint", Foxpro.enFoxproTypes.Numeric, 1));
                fields.Add(new Foxpro.DataStruct("NoACC", "no_acc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("KetKoli", "ket_koli", Foxpro.enFoxproTypes.Char, 20));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_OrderPenjualanDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Barang Bonus
        private void UploadBarangBonus()
        {
            SqlDataReader dr;
            string FileName = "HBABON";
            string TableName = "Barang Bonus";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'Barang Bonus' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("TrID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("TrIDhtj", "idtrhtj", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("KodeToko1", "kd_toko1", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_BarangBonus"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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


        private void UploadBarangBonusDetail()
        {
            SqlDataReader dr;
            string FileName = "DBABON";
            string TableName = "Barang Bonus";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'Barang Bonus Detail' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("TrID", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Qty", "qty", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_BarangBonusDetail"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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

        #region Status Toko
        private void UploadStatusToko()
        {
            SqlDataReader dr;
            string FileName = "ststoko";
            string TableName = "Status Toko";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'StatusToko' is Uploading...";
                string Physical = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\DumpUPLOAD\\" + FileName + ".cdx";
                files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("CabangID", "c1", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("TglAktif", "tmt", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("Status", "sts", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Keterangan", "ket", Foxpro.enFoxproTypes.Char, 30));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("KStatus", "ksts", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("Roda", "rd", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("WilID", "idwil", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglPasif", "tmt_pasif", Foxpro.enFoxproTypes.DateTime, 8));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_DUMP_StatusToko"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();

                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\DumpUPLOAD\\", FileName, fields, dr, dbPath, this, pbSyncUpload, lblUploadCount);
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
            string fileZipName = GlobalVar.DbfUpload + "\\DumpUPLOAD\\dbfmatch.zip";
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }
            Zip.ZipFiles(files, fileZipName);
        }

        private void frmDumpUpload_Load(object sender, EventArgs e)
        {
            pbSyncUpload.Minimum = 0;
            pbSyncUpload.Maximum = 100;
        }
    }
}
