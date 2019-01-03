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
using System.Data.SqlClient;

namespace ISA.Finance.Kasir
{
    public partial class frmUploadDownload : ISA.Finance.BaseForm
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        int _count1 = 0;
        int _count2 = 0;
        int _count3 = 0;
        int _count4 = 0;
        int _count5 = 0;
        int _count6 = 0;
        int _count7 = 0;
        int _count8 = 0;
        int _count9 = 0;
        int _count10 = 0;
        int _count11 = 0;
        int _count12 = 0;
        int _count13 = 0;
        int _count14 = 0;
        int _count15 = 0;
        int _count16 = 0;
        int _count17 = 0;
        int _count18 = 0;
        int _count19 = 0;
        int _count20 = 0;
        int _count21 = 0;
        int _count22 = 0;
        int _count23 = 0;
        int _count24 = 0;
        int _count25 = 0;
        int _count26= 0;
        int _count27 = 0;
        
        List<string> files = new List<string>();
        string fileZipName = GlobalVar.DbfDownload + "\\KAS" + GlobalVar.Gudang + ".zip";
        string _tempPath;

        protected DataTable
        dtGiroTolak,
        dtGiroTolakDetail,
        dtKartuPiutang,
        dtKartuPiutangDetail,
        dtTagihan,
        dtTagihanDetail,
        dtTagihanSubDetail,
        dtInden,
        dtIndenDetail,
        dtIndenSubDetail,
        dtIndenSuperDetail,
        dtBukti,
        dtBuktiDetail,
        dtVoucherJournal,
        dtVoucherJournalDetail,
        dtTransferBank,
        dtTransferBankDetail,
        dtBBK,
        dtBBM,
        dtGiro,
        dtGiroInternal,
        dtKasbon,
        dtPinjamanPegawai,
        dtStaff,
        dtBank,
        dtBankDetail,
        dtTokoToSales;        
       
        public frmUploadDownload()
        {
            InitializeComponent();
        }

        private void frmUploadDownload_Load(object sender, EventArgs e)
        {            
            LoadData();
            rangeDateBox1.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            rangeDateBox1.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
        }

        

        private void LoadData()
        {
            
            dt.Columns.Add(new DataColumn("Nomor", typeof(System.Int32)));
            dt.Columns.Add(new DataColumn("Nama", typeof(System.String)));
            dt.Columns.Add(new DataColumn("Count", typeof(System.Int32)));

            AddRow(1, "GiroTolak", 0);
            AddRow(2, "GiroTolakDetail", 0);
            AddRow(3, "KartuPiutang", 0);
            AddRow(4, "KartuPiutangDetail", 0);
            AddRow(5, "Tagihan", 0);
            AddRow(6, "TagihanDetail", 0);
            AddRow(7, "TagihanSubDetail", 0);
            AddRow(8, "Inden", 0);
            AddRow(9, "IndenDetail", 0);
            AddRow(10, "IndenSubDetail", 0);
            AddRow(11, "IndenSuperDetail", 0);
            AddRow(12, "Bukti", 0);
            AddRow(13, "BuktiDetail", 0);
            AddRow(14, "VoucherJournal", 0);
            AddRow(15, "VoucherJournalDetail", 0);
            AddRow(16, "TransferBank", 0);
            AddRow(17, "TransferBankDetail", 0);
            AddRow(18, "BBK", 0);
            AddRow(19, "BBM", 0);
            AddRow(20, "Giro", 0);
            AddRow(21, "GiroInternal", 0);
            AddRow(22, "Kasbon", 0);
            AddRow(23, "PinjamanPegawai", 0);
            AddRow(24, "Staff", 0);
            AddRow(25, "Bank", 0);
            AddRow(26, "BankDetail", 0);
            AddRow(27, "TokoToSales", 0);

            //AddRow(1, "GiroTolak", 0);
            //AddRow(2, "GiroTolakDetail", 0);
            //AddRow(3, "KartuPiutang", 0);
            //AddRow(4, "KartuPiutangDetail", 0);
            //AddRow(5, "TokoToSales", 0);
            //AddRow(6, "Inden", 0);
            //AddRow(7, "IndenDetail", 0);
            //AddRow(8, "IndenSubDetail", 0);
            //AddRow(9, "IndenSuperDetail", 0);
            //AddRow(10, "Bukti", 0);
            //AddRow(11, "BuktiDetail", 0);
            //AddRow(12, "VoucherJournal", 0);
            //AddRow(13, "VoucherJournalDetail", 0);
            //AddRow(14, "TransferBank", 0);
            //AddRow(15, "TransferBankDetail", 0);
            //AddRow(16, "BBK", 0);
            //AddRow(17, "BBM", 0);
            //AddRow(18, "Giro", 0);
            //AddRow(19, "GiroInternal", 0);
            //AddRow(20, "Kasbon", 0);
            //AddRow(21, "PinjamanPegawai", 0);
            //AddRow(22, "Staff", 0);
            //AddRow(23, "Bank", 0);
            //AddRow(24, "BankDetail", 0);


            gridUpload.DataSource = dt;



        }

 

        private void AddRow(int no,string name,int count)
        {
            
            DataRow dr = dt.NewRow();            
            dr["Nomor"] = no;
            dr["Nama"] = name ;
            dr["Count"] = count ;
            dt.Rows.Add(dr);
            
        }

        private void RefreshCounter()
        {
            _count1 = 0;
            _count2 = 0;
            _count3 = 0;
            _count4 = 0;
            _count5 = 0;
            _count6 = 0;
            _count7 = 0;
            _count8 = 0;
            _count9 = 0;
            _count10 = 0;
            _count11 = 0;
            _count12 = 0;
            _count13 = 0;
            _count14 = 0;
            _count15 = 0;
            _count16 = 0;
            _count17 = 0;
            _count18 = 0;
            _count19 = 0;
            _count20 = 0;
            _count21 = 0;
            _count22 = 0;
            _count23 = 0;
            _count24 = 0;
            _count25 = 0;
            _count26 = 0;
            _count27 = 0;

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadGiroTolak()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "HbgTmp.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_GiroTolak"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[0].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count1 = _count1 + 1;

                dt.Rows[0]["Count"] = _count1;
                gridUpload.Refresh();
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
            fields.Add(new Foxpro.DataStruct("ket_tagih", "ket_tagih", Foxpro.enFoxproTypes.Char, 15));
            //fields.Add(new Foxpro.DataStruct("luby", "luby", Foxpro.enFoxproTypes.Char, 250));
            //fields.Add(new Foxpro.DataStruct("lutime", "lutime", Foxpro.enFoxproTypes.DateTime, 8));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "HbgTmp", fields, dt2, progressBar1);

            
        }

        private void UploadGiroTolakDetail()
        {
            string Physical = GlobalVar.DbfUpload + "\\" + "DbgTmp.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_GiroTolakDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[1].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count2 = _count2 + 1;

                dt.Rows[1]["Count"] = _count2;
                gridUpload.Refresh();
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
            //fields.Add(new Foxpro.DataStruct("luby", "luby", Foxpro.enFoxproTypes.Char, 250));
            //fields.Add(new Foxpro.DataStruct("lutime", "lutime", Foxpro.enFoxproTypes.DateTime, 8));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "DbgTmp", fields, dt2, progressBar1);

            
                                
        }

        private void UploadKartuPiutang()
        {
            string Physical = GlobalVar.DbfUpload + "\\" + "KpiTmp.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_KartuPiutang"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[2].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count3 = _count3 + 1;

                dt.Rows[2]["Count"] = _count3;
                gridUpload.Refresh();
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
            fields.Add(new Foxpro.DataStruct("subnota", "subnota", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("ket_tagih", "ket_tagih", Foxpro.enFoxproTypes.Char, 15));
            //fields.Add(new Foxpro.DataStruct("luby", "luby", Foxpro.enFoxproTypes.Char, 250));
            //fields.Add(new Foxpro.DataStruct("lutime", "lutime", Foxpro.enFoxproTypes.DateTime, 8));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "KpiTmp", fields, dt2, progressBar1);

               
        }


        private void UploadKartuPiutangDetail()
        {
            string Physical = GlobalVar.DbfUpload + "\\" + "DpiTmp.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_KartuPiutangDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[3].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count4 = _count4 + 1;

                dt.Rows[3]["Count"] = _count4;
                gridUpload.Refresh();
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
            fields.Add(new Foxpro.DataStruct("no_bkm", "no_bkm", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("no_bg", "no_bg", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("bank", "bank", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("no_acc", "no_acc", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("laudit", "laudit", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("tgl_cair", "tgl_cair", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("subnota", "subnota", Foxpro.enFoxproTypes.Char, 3));
            //fields.Add(new Foxpro.DataStruct("luby", "luby", Foxpro.enFoxproTypes.Char, 3));
            //fields.Add(new Foxpro.DataStruct("lutime", "lutime", Foxpro.enFoxproTypes.DateTime, 8));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "DpiTmp", fields, dt2, progressBar1);

             

        }


        private void UploadTokoToSales()
        {
            string Physical = GlobalVar.DbfUpload + "\\" + "Tk2Tmp.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_TokoToSales"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[26].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count27 = _count27 + 1;

                dt.Rows[26]["Count"] = _count27;
                gridUpload.Refresh();
            }     


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("kd_sales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("piutang_b", "piutang_b", Foxpro.enFoxproTypes.Numeric, 13));
            fields.Add(new Foxpro.DataStruct("piutang_j", "piutang_j", Foxpro.enFoxproTypes.Numeric, 13));    
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
 
            Foxpro.WriteFile(GlobalVar.DbfUpload, "Tk2Tmp", fields, dt2, progressBar1);
           

        }

        private void UploadInden()
        {
            string Physical = GlobalVar.DbfUpload + "\\" + "TmpHin.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_Inden"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[7].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count8 = _count8 + 1;

                dt.Rows[7]["Count"] = _count8;
                gridUpload.Refresh();
            }     

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
            fields.Add(new Foxpro.DataStruct("rp_crd", "rp_crd", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_dbt", "rp_dbt", Foxpro.enFoxproTypes.Numeric, 14));
            //fields.Add(new Foxpro.DataStruct("luby", "luby", Foxpro.enFoxproTypes.Char, 250));
            //fields.Add(new Foxpro.DataStruct("lutime", "lutime", Foxpro.enFoxproTypes.DateTime, 8));


            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpHin", fields, dt2, progressBar1);
           
        }

        private void UploadIndenDetail()
        {
            string Physical = GlobalVar.DbfUpload + "\\" + "TmpDin.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_IndenDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[8].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count9 = _count9 + 1;

                dt.Rows[8]["Count"] = _count9;
                gridUpload.Refresh();
            }     

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idtr", "idtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("rp_cash", "rp_cash", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_giro", "rp_giro", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_trf", "rp_trf", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("cash", "cash", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("giro", "giro", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("trf", "trf", Foxpro.enFoxproTypes.Numeric, 14));
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
            fields.Add(new Foxpro.DataStruct("rp_crd", "rp_crd", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_dbt", "rp_dbt", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("crd", "crd", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("dbt", "dbt", Foxpro.enFoxproTypes.Numeric, 14));
            //fields.Add(new Foxpro.DataStruct("luby", "luby", Foxpro.enFoxproTypes.Char, 250));
            //fields.Add(new Foxpro.DataStruct("lutime", "lutime", Foxpro.enFoxproTypes.DateTime, 8));


            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpDin", fields, dt2, progressBar1);           

        }

        private void UploadIndenSubDetail()
        {
            string Physical = GlobalVar.DbfUpload + "\\" + "TmpTgh.DBF";
            string Fpt = GlobalVar.DbfUpload + "\\" + "TmpTgh.fpt";
            files.Add(Physical);
            files.Add(Fpt);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }
            else if (File.Exists(Fpt))
            {
                File.Delete(Fpt);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_IndenSubDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[9].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count10 = _count10 + 1;

                dt.Rows[9]["Count"] = _count10;
                gridUpload.Refresh();
            }     

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
            //fields.Add(new Foxpro.DataStruct("luby", "luby", Foxpro.enFoxproTypes.Char, 250));
            //fields.Add(new Foxpro.DataStruct("lutime", "lutime", Foxpro.enFoxproTypes.DateTime, 8));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpTgh", fields, dt2, progressBar1);
            

        }

        private void UploadIndenSuperDetail()
        {
           
            string Physical = GlobalVar.DbfUpload + "\\" + "TmpDdi.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_IndenSuperDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[10].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count11 = _count11 + 1;

                dt.Rows[10]["Count"] = _count11;
                gridUpload.Refresh();
            }     

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("iddrec", "iddrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("id_coltoko", "id_coltoko", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("id_kp", "id_kp", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("namatoko", "namatoko", Foxpro.enFoxproTypes.Char, 31));
            fields.Add(new Foxpro.DataStruct("tgl_bpp", "tgl_bpp", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_reg", "no_reg", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("ref", "ref", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("no_bukti", "no_bukti", Foxpro.enFoxproTypes.Char, 14));
            fields.Add(new Foxpro.DataStruct("tgl_ind", "tgl_ind", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("rp_ind", "rp_ind", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("tgl_jt", "tgl_jt", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_nota", "no_nota", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("rp_nota", "rp_nota", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_tagih", "rp_tagih", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("kode", "kode", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("sub", "sub", Foxpro.enFoxproTypes.Char, 11));            
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 12));
            //fields.Add(new Foxpro.DataStruct("luby", "luby", Foxpro.enFoxproTypes.Char, 12));
            //fields.Add(new Foxpro.DataStruct("lutime", "lutime", Foxpro.enFoxproTypes.DateTime, 8));
           
                      
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpDdi", fields, dt2, progressBar1);
            

        }

        private void UploadBukti()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpHbk.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_Bukti"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[11].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count12 = _count12 + 1;

                dt.Rows[11]["Count"] = _count12;
                gridUpload.Refresh();
            }     

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idtr", "idtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("mk", "mk", Foxpro.enFoxproTypes.Char,1));
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
            //fields.Add(new Foxpro.DataStruct("luby", "luby", Foxpro.enFoxproTypes.Char, 250));
            //fields.Add(new Foxpro.DataStruct("lutime", "lutime", Foxpro.enFoxproTypes.DateTime, 8));

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpHbk", fields, dt2, progressBar1);
            

        }


        private void UploadBuktiDetail()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpDbk.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_BuktiDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[12].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count13 = _count13 + 1;

                dt.Rows[12]["Count"] = _count13;
                gridUpload.Refresh();
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
            fields.Add(new Foxpro.DataStruct("rp_iden", "rp_iden", Foxpro.enFoxproTypes.Numeric, 14));
            //fields.Add(new Foxpro.DataStruct("luby", "luby", Foxpro.enFoxproTypes.Char, 250));
            //fields.Add(new Foxpro.DataStruct("lutime", "lutime", Foxpro.enFoxproTypes.DateTime, 8));
            
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpDbk", fields, dt2, progressBar1);
            

        }

        private void UploadVoucherJurnal()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpHvc.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_VoucherJournal"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[13].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count14 = _count14 + 1;

                dt.Rows[13]["Count"] = _count14;
                gridUpload.Refresh();
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

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpHvc", fields, dt2, progressBar1);           

        }

        private void UploadVoucherJurnalDetail()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpDvc.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_VoucherJournalDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[14].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count15 = _count15 + 1;

                dt.Rows[14]["Count"] = _count15;
                gridUpload.Refresh();
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
            fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 12));            

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpDvc", fields, dt2, progressBar1);           
        }


        private void UploadTransferBank()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpHtr.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_TransferBank"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[15].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count16 = _count16 + 1;

                dt.Rows[15]["Count"] = _count16;
                gridUpload.Refresh();
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
            fields.Add(new Foxpro.DataStruct("penyetor", "penyetor", Foxpro.enFoxproTypes.Char,15));
            fields.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpHtr", fields, dt2, progressBar1);           

        }

        private void UploadTransferBankDetail()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpDtr.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_TransferBankDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[16].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count17 = _count17 + 1;

                dt.Rows[16]["Count"] = _count17;
                gridUpload.Refresh();
            }     


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idtrm", "idtrm", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idbbm", "idbbm", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("asaltrf", "asaltrf", Foxpro.enFoxproTypes.Char, 70));
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
            fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("titiperk", "titiperk", Foxpro.enFoxproTypes.Char, 12));          
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpDtr", fields, dt2, progressBar1);
            
        }


        private void UploadBBK()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpBbk.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_BBK"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[17].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count18 = _count18 + 1;

                dt.Rows[17]["Count"] = _count18;
                gridUpload.Refresh();
            }     


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idbbk", "idbbk", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("tgl_bbk", "tgl_bbk", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_bbk", "no_bbk", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("id_bank", "id_bank", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("nm_bank", "nm_bank", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("rp_giro", "rp_giro", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_cair", "rp_cair", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_tolak", "rp_tolak", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("dibukuan", "dibukuan", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("diketahui", "diketahui", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("kasir", "kasir", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("penerima", "penerima", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpBbk", fields, dt2, progressBar1);
           
        }

        private void UploadBBM()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpBbm.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_BBM"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[18].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count19 = _count19 + 1;

                dt.Rows[18]["Count"] = _count19;
                gridUpload.Refresh();
            }     

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idbbm", "idbbm", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("tgl_bbm", "tgl_bbm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_bbm", "no_bbm", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("id_bank", "id_bank", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("nm_bank", "nm_bank", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("rp_giro", "rp_giro", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_cair", "rp_cair", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_tolak", "rp_tolak", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("dibukuan", "dibukuan", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("diketahui", "diketahui", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("kasir", "kasir", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("penyetor", "penyetor", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpBbm", fields, dt2, progressBar1);            
        }

        private void UploadGiro()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpGro.DBF";
            string Indexing = GlobalVar.DbfUpload + "\\" + "TmpGro.cdx";
            files.Add(Indexing);
            files.Add(Physical);

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
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_Giro"));                
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[19].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count20 = _count20 + 1;

                dt.Rows[19]["Count"] = _count20;
                gridUpload.Refresh();
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
            fields.Add(new Foxpro.DataStruct("mainperk", "mainperk", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("titiperk", "titiperk", Foxpro.enFoxproTypes.Char, 10));

            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("idgiro", "IDGIRO"));

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpGro", fields, dt2, progressBar1,index);
           
        }


        private void UploadGiroInternal()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpGin.DBF";        
            files.Add(Physical);

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_GiroInternal"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[20].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count21 = _count21 + 1;

                dt.Rows[20]["Count"] = _count21;
                gridUpload.Refresh();
            }   

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idbbk", "idbbk", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idgiro", "idgiro", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idbank", "idbank", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idind", "idind", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("kode", "kode", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("sub", "sub", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("gc", "gc", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("bank", "bank", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("no_giro", "no_giro", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("tgl_giro", "tgl_giro", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_jt", "tgl_jt", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("cairtolak", "cairtolak", Foxpro.enFoxproTypes.Char, 1));            
            fields.Add(new Foxpro.DataStruct("tgl_cair", "tgl_cair", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("vta", "vta", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("nominal", "nominal", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("kepada", "kepada", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("keperluan", "keperluan", Foxpro.enFoxproTypes.Char, 70));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("rp_iden", "rp_iden", Foxpro.enFoxproTypes.Numeric, 14));

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpGin", fields, dt2, progressBar1);            
        }

        private void UploadKasbon()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpKas.DBF";
            files.Add(Physical);

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_Kasbon"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[21].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count22 = _count22 + 1;

                dt.Rows[21]["Count"] = _count22;
                gridUpload.Refresh();
            }   

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idkasbon", "idkasbon", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("nip", "nip", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("nama", "nama", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("unitkerja", "unitkerja", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("no", "no", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("tgl", "tgl", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("keperluan", "keperluan", Foxpro.enFoxproTypes.Char, 70));
            fields.Add(new Foxpro.DataStruct("bkkno1", "bkkno1", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("trkno1", "trkno1", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("bbkno1", "bbkno1", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("bkkrp1", "bkkrp1", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("trkrp1", "trkrp1", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("bbkrp1", "bbkrp1", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("total1", "total1", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("jv_no1", "jv_no1", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("jv_no2", "jv_no2", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("jv_no3", "jv_no3", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("jv_rp1", "jv_rp1", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("jv_rp2", "jv_rp2", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("jv_rp3", "jv_rp3", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("total2", "total2", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("bkkno3", "bkkno3", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("trkno3", "trkno3", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("bbkno3", "bbkno3", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("bkmno3", "bkmno3", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("trnno3", "trnno3", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("bbmno3", "bbmno3", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("bkkrp3", "bkkrp3", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("trkrp3", "trkrp3", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("bbkrp3", "bbkrp3", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("totku3", "totku3", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("bkmrp3", "bkmrp3", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("trnrp3", "trnrp3", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("bbmrp3", "bbmrp3", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("totle3", "totle3", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("kode", "kode", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("sub", "sub", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("hari", "hari", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 12));

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpKas", fields, dt2, progressBar1);            
        }

        private void UploadPinjamanPegawai()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpPgw.DBF";
            files.Add(Physical);

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_PinjamanPegawai"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[22].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count23 = _count23 + 1;

                dt.Rows[22]["Count"] = _count23;
                gridUpload.Refresh();
            }   

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("iddpinj", "iddpinj", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("nip", "nip", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("tgl", "tgl", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("uraian", "uraian", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("ref", "ref", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("no_ref", "no_ref", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("debet", "debet", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("kredit", "kredit", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("ket_lain2", "ket_lain2", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));            
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpPgw", fields, dt2, progressBar1);           

        }

        private void UploadStaff()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpSas.DBF";
            files.Add(Physical);

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_Staff"));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[23].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count24 = _count24 + 1;

                dt.Rows[23]["Count"] = _count24;
                gridUpload.Refresh();
            }


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("nip", "nip", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("nama", "nama", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("jabatan", "jabatan", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("unitkerja", "unitkerja", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("lp", "lp", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("alamat", "alamat", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("no_telp", "no_telp", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("tgl_lahir", "tgl_lahir", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_masuk", "tgl_masuk", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_keluar", "tgl_keluar", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("keterangan", "keterangan", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("gaji", "gaji", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("um", "um", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("perkoli", "perkoli", Foxpro.enFoxproTypes.Numeric, 4));
            fields.Add(new Foxpro.DataStruct("bonus", "bonus", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("hutang", "hutang", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("agama", "agama", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("j_telat", "j_telat", Foxpro.enFoxproTypes.Char, 8));
            fields.Add(new Foxpro.DataStruct("j_maxum", "j_maxum", Foxpro.enFoxproTypes.Char, 8));
            fields.Add(new Foxpro.DataStruct("stk", "stk", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("no_bkm", "no_bkm", Foxpro.enFoxproTypes.Char, 12));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpSas", fields, dt2, progressBar1);

        }

        private void UploadBank()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpBnk.DBF";
            files.Add(Physical);

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_Bank"));
                dt2 = db.Commands[0].ExecuteDataTable();

            }

            gridUpload.CurrentCell = gridUpload.Rows[24].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count25 = _count25 + 1;

                dt.Rows[24]["Count"] = _count25;
                gridUpload.Refresh();
            }
            
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idbank", "idbank", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("j_rek", "j_rek", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("nama_bank", "nama_bank", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("nama_acc", "nama_acc", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("no_acc", "no_acc", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("alm1", "alm1", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("alm2", "alm2", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("kota", "kota", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("telp", "telp", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("cservis", "cservis", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("no_giro", "no_giro", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("no_ch", "no_ch", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("no_bbk", "no_bbk", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("vta", "vta", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("saldo", "saldo", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("limit", "limit", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("tgl_rk", "tgl_rk", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("saldo_aw", "saldo_aw", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("saldo_ak", "saldo_ak", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("kode", "kode", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("sub", "sub", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("maintitip", "maintitip", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("subtitip", "subtitip", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("mainperk", "mainperk", Foxpro.enFoxproTypes.Char, 12));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpBnk", fields, dt2, progressBar1);
            
        }

        private void UploadBankDetail()
        {

            string Physical = GlobalVar.DbfUpload + "\\" + "TmpDnk.DBF";
            files.Add(Physical);

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_BankDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt2 = db.Commands[0].ExecuteDataTable();

            }



            gridUpload.CurrentCell = gridUpload.Rows[25].Cells[0];
            foreach (DataRow dr in dt2.Rows)
            {
                _count26 = _count26 + 1;

                dt.Rows[25]["Count"] = _count26;
                gridUpload.Refresh();
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
            fields.Add(new Foxpro.DataStruct("catatan", "catatan", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("rp_iden", "rp_iden", Foxpro.enFoxproTypes.Numeric, 14));

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpDnk", fields, dt2, progressBar1);


        }

        private void UploadTagihan()
        {
            DataSet ds = new DataSet();
            string Physical = GlobalVar.DbfUpload + "\\" + "TmpHTag.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            string Physical2 = GlobalVar.DbfUpload + "\\" + "TmpDTag.DBF";
            files.Add(Physical2);
            if (File.Exists(Physical2))
            {
                File.Delete(Physical2);
            }

            string Physical3 = GlobalVar.DbfUpload + "\\" + "TmpDKun.DBF";
            files.Add(Physical3);
            if (File.Exists(Physical3))
            {
                File.Delete(Physical3);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_Tagihan"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                ds = db.Commands[0].ExecuteDataSet();

            }

            gridUpload.CurrentCell = gridUpload.Rows[4].Cells[0];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                _count5 = _count5 + 1;

                dt.Rows[4]["Count"] = _count5;
                gridUpload.Refresh();
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("id_reg", "id_reg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("no_reg", "no_reg", Foxpro.enFoxproTypes.Char, 7));
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
            fields.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric,3));

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpHTag", fields, ds.Tables[0], progressBar1);

            //TAGIHAN DETAIL
            gridUpload.CurrentCell = gridUpload.Rows[5].Cells[0];
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                _count6 = _count6 + 1;

                dt.Rows[5]["Count"] = _count6;
                gridUpload.Refresh();
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

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpDTag", fields2, ds.Tables[1], progressBar1);

            //TAGIHAN SUB DETAIL
            gridUpload.CurrentCell = gridUpload.Rows[6].Cells[0];
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                _count7 = _count7 + 1;

                dt.Rows[6]["Count"] = _count7;
                gridUpload.Refresh();
            }

            List<Foxpro.DataStruct> fields3 = new List<Foxpro.DataStruct>();
            fields3.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields3.Add(new Foxpro.DataStruct("iddrec", "iddrec", Foxpro.enFoxproTypes.Char, 23));
            fields3.Add(new Foxpro.DataStruct("tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
            fields3.Add(new Foxpro.DataStruct("ket", "ket", Foxpro.enFoxproTypes.Char, 60));
            fields3.Add(new Foxpro.DataStruct("rp_ind", "rp_ind", Foxpro.enFoxproTypes.Numeric, 14));
            fields3.Add(new Foxpro.DataStruct("idmatch", "idmatch", Foxpro.enFoxproTypes.Char, 1));

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpDKun", fields3, ds.Tables[2], progressBar1);


        }

        private void DownloadTagihan()
        {

            string fileName = _tempPath + "TmpHTag.DBF";

            DataTable result = ValidateFile(fileName, dtGiroTolak);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[4].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_Tagihan"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count5 = _count5 + 1;

                        dt.Rows[4]["Count"] = _count5;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["id_reg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, Tools.isNull(dr["no_reg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglReg", SqlDbType.DateTime, Tools.isNull(dr["tgl_reg"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKembali", SqlDbType.DateTime, Tools.isNull(dr["tgl_kbl"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, Tools.isNull(dr["colector"], "")));
                        db.Commands[0].Parameters.Add(new Parameter("@Wilayah", SqlDbType.VarChar, (Tools.isNull(dr["wilayah"],""))));
                        db.Commands[0].Parameters.Add(new Parameter("@Periode1", SqlDbType.DateTime, (Tools.isNull(dr["periode_1"], DBNull.Value))));
                        db.Commands[0].Parameters.Add(new Parameter("@Periode2", SqlDbType.DateTime, (Tools.isNull(dr["periode_2"], DBNull.Value))));
                        db.Commands[0].Parameters.Add(new Parameter("@TLama", SqlDbType.Money, Tools.isNull(dr["t_lama"], "0").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, Tools.isNullOrEmpty(dr["nm_kasir"].ToString().Trim(), "")));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));               
                        db.Commands[0].ExecuteNonQuery();

                    }

                }
            }
        }

        private void DownloadTagihanDetail()
        {

            string fileName = _tempPath + "TmpDTag.DBF";

            DataTable result = ValidateFile(fileName, dtGiroTolak);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[5].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_TagihanDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count6 = _count6 + 1;

                        dt.Rows[5]["Count"] = _count6;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["id_reg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KPRecID", SqlDbType.VarChar, Tools.isNull(dr["idkp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Flag", SqlDbType.Bit, Tools.isNull(dr["flag"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglInden", SqlDbType.DateTime, Tools.isNull(dr["tgl_tagih"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@RpNota", SqlDbType.Money, int.Parse(Tools.isNull(dr["rp_nota"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@RpBayar", SqlDbType.Money, int.Parse(Tools.isNull(dr["rp_bayar"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@RpTagih", SqlDbType.Money, int.Parse(Tools.isNull(dr["rp_tagih"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["ket"], "0").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                       

                    }

                }
            }
        }

        private void DownloadTagihanSubDetail()
        {

            string fileName = _tempPath + "TmpDKun.DBF";

            DataTable result = ValidateFile(fileName, dtGiroTolak);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[6].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_TagihanSubDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count7 = _count7 + 1;

                        dt.Rows[6]["Count"] = _count7;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["iddrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalKunjung", SqlDbType.DateTime, Tools.isNull(dr["tanggal"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["ket"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RpInd", SqlDbType.Money, int.Parse(Tools.isNull(dr["rp_ind"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["idmatch"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                }
            }
        }

        private void DownloadGiroTolak()
        {

            string fileName = _tempPath + "HbgTmp.DBF";
            string laudit;

            DataTable result = ValidateFile(fileName, dtGiroTolak);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[0].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_GiroTolak"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count1 = _count1 + 1;

                        dt.Rows[0]["Count"] = _count1;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, Tools.isNull(dr["idkp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Alasan", SqlDbType.VarChar, Tools.isNull(dr["Alasan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglGiro", SqlDbType.DateTime, Tools.isNull(dr["Tgl_Giro"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@CbgJt", SqlDbType.DateTime, (Tools.isNull(dr["Cbg_jt"], DBNull.Value))));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, (Tools.isNull(dr["Uraian"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, (Tools.isNull(dr["Debet"], "0").ToString())));                        
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["KD_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBKM", SqlDbType.VarChar, Tools.isNull(dr["no_bkm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, Tools.isNull(dr["no_bg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, (Tools.isNull(dr["Bank"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, (Tools.isNull(dr["no_acc"], "").ToString().Trim())));
                        laudit = (Tools.isNull(dr["laudit"], "0").ToString());

                        if (laudit == "False")
                        {
                            laudit = "0";
                        }
                        else if (laudit == "True")
                        {
                            laudit = "1";
                        }

                        db.Commands[0].Parameters.Add(new Parameter("@Audit", SqlDbType.Bit, int.Parse(laudit)));
                        db.Commands[0].Parameters.Add(new Parameter("@KetTagih", SqlDbType.VarChar, Tools.isNull(dr["ket_tagih"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();


                    }

                }
            }
        }

        private void DownloadGiroTolakDetail()
        {
            string fileName = _tempPath + "DbgTmp.DBF";


            DataTable result = ValidateFile(fileName, dtGiroTolakDetail);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[1].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_GiroTolakDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count2 = _count2 + 1;

                        dt.Rows[1]["Count"] = _count2;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglBayar", SqlDbType.DateTime, Tools.isNull(dr["tgl_byr"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBayar", SqlDbType.VarChar, Tools.isNull(dr["kd_bayar"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(dr["kredit"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@CbgJt", SqlDbType.DateTime, Tools.isNull(dr["cbg_jt"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, (Tools.isNull(dr["uraian"],"").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, (Tools.isNull(dr["dstamp"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBKM", SqlDbType.VarChar, (Tools.isNull(dr["no_bkm"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, Tools.isNull(dr["no_bg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, Tools.isNull(dr["Bank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().TrimEnd()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        private void DownloadKartuPiutang()
        {
            string fileName = _tempPath + "KpiTmp.DBF";


            DataTable result = ValidateFile(fileName, dtKartuPiutang);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[2].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_KartuPiutang"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count3 = _count3 + 1;

                        dt.Rows[2]["Count"] = _count3;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, Tools.isNull(dr["id_kp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, Tools.isNull(dr["tgl_tr"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoTransaksi", SqlDbType.VarChar, Tools.isNull(dr["no_tr"],"").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@JangkaWaktu", SqlDbType.Int, int.Parse((Tools.isNull(dr["jk_waktu"], "0").ToString()))));
                        db.Commands[0].Parameters.Add(new Parameter("@TglJatuhTempo", SqlDbType.DateTime, (Tools.isNull(dr["tgl_jt"],DBNull.Value))));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, (Tools.isNull(dr["uraian"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, Tools.isNull(dr["id_tr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_krm"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_sls"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KeteranganTagih", SqlDbType.VarChar, Tools.isNull(dr["ket_tagih"], "").ToString().TrimEnd()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        private void DownloadKartuPiutangDetail()
        {
            string fileName = _tempPath + "DpiTmp.DBF";
            string laudit;

            DataTable result = ValidateFile(fileName, dtKartuPiutangDetail);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[3].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_KartuPiutangDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count4 = _count4 + 1;

                        dt.Rows[3]["Count"] = _count4;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, Tools.isNull(dr["id_kp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, Tools.isNull(dr["tgl_tr"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, Tools.isNull(dr["kd_trans"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(dr["debet"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(dr["kredit"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglJTGiro", SqlDbType.DateTime, Tools.isNull(dr["cbg_jt"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBuktiKasMasuk", SqlDbType.VarChar, Tools.isNull(dr["no_bkm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, Tools.isNull(dr["no_bg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, Tools.isNull(dr["bank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
                        laudit = Tools.isNull(dr["laudit"], "0").ToString();

                        if (laudit == "False")
                        {
                            laudit = "0";
                        }
                        else if (laudit == "True")
                        {
                            laudit = "1";
                        }

                        db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, int.Parse(laudit)));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        private void DownloadTokoToSales()
        {
            string fileName = _tempPath + "Tk2Tmp.DBF";
            

            DataTable result = ValidateFile(fileName, dtTokoToSales);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[26].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_TokoToSales"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count27 = _count27 + 1;

                        dt.Rows[26]["Count"] = _count27;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@PiutangBerjalan", SqlDbType.Money, Tools.isNull(dr["piutang_b"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@PiutangJatuhTempo", SqlDbType.Money, Tools.isNull(dr["piutang_j"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        private void DownloadInden()
        {
            string fileName = _tempPath + "TmpHin.DBF";
           

            DataTable result = ValidateFile(fileName, dtInden);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[7].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_Inden"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count8 = _count8 + 1;

                        dt.Rows[7]["Count"] = _count8;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, Tools.isNull(dr["no_bukti"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaCollector", SqlDbType.VarChar, Tools.isNull(dr["collector"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, Tools.isNull(dr["nm_coll"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, Tools.isNull(dr["tgl_kasir"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, Tools.isNull(dr["kasir"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Acc", SqlDbType.VarChar, Tools.isNull(dr["acc"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        private void DownloadIndenDetail()
        {
            string fileName = _tempPath + "TmpDin.DBF";


            DataTable result = ValidateFile(fileName, dtIndenDetail);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[8].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_IndenDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count9 = _count9 + 1;

                        dt.Rows[8]["Count"] = _count9;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RpCash", SqlDbType.Money, Tools.isNull(dr["rp_cash"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RpGiro", SqlDbType.Money, Tools.isNull(dr["rp_giro"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RpTrf", SqlDbType.Money, Tools.isNull(dr["rp_trf"],"0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTrf", SqlDbType.DateTime, Tools.isNull(dr["tgl_trf"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, Tools.isNull(dr["idbank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, Tools.isNull(dr["namabank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, Tools.isNull(dr["lokasi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@CHBG", SqlDbType.Char, Tools.isNull(dr["chbg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Nomor", SqlDbType.VarChar, Tools.isNull(dr["nomor"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglGiro", SqlDbType.DateTime, Tools.isNull(dr["tgl_giro"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglJt", SqlDbType.DateTime, Tools.isNull(dr["tgl_jt"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Ket", SqlDbType.VarChar, Tools.isNull(dr["ket"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RpCrd", SqlDbType.Money, Tools.isNull(dr["rp_crd"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RpDbt", SqlDbType.Money, Tools.isNull(dr["rp_dbt"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        private void DownloadIndenSubDetail()
        {
            string fileName = _tempPath + "TmpTgh.DBF";


            DataTable result = ValidateFile(fileName, dtIndenSubDetail);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[9].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_IndenSubDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count10 = _count10 + 1;

                        dt.Rows[9]["Count"] = _count10;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["id_coltoko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, Tools.isNull(dr["namatoko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, Tools.isNull(dr["no_reg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBPP", SqlDbType.VarChar, Tools.isNull(dr["no_bpp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglBPP", SqlDbType.DateTime, Tools.isNull(dr["tgl_bpp"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, Tools.isNull(dr["tgl_kasir"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@RpNominal", SqlDbType.Money, Tools.isNull(dr["rp_nominal"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        private void DownloadIndenSuperDetail()
        {
            string fileName = _tempPath + "TmpDdi.DBF";


            DataTable result = ValidateFile(fileName, dtIndenSuperDetail);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[10].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_IndenSuperDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count11 = _count11 + 1;

                        dt.Rows[10]["Count"] = _count11;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["iddrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TagihDetailRecID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["id_coltoko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KPrecID", SqlDbType.VarChar, Tools.isNull(dr["id_kp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglBPP", SqlDbType.DateTime, Tools.isNull(dr["tgl_bpp"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, Tools.isNull(dr["no_reg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, Tools.isNull(dr["ref"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, Tools.isNull(dr["no_bukti"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglInden", SqlDbType.DateTime, Tools.isNull(dr["tgl_ind"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@RpInden", SqlDbType.Money, Tools.isNull(dr["rp_ind"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglJatuhTempo", SqlDbType.DateTime, Tools.isNull(dr["tgl_jt"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@RpNota", SqlDbType.Money, Tools.isNull(dr["rp_nota"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RpTagih", SqlDbType.Money, Tools.isNull(dr["rp_tagih"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Tools.isNull(dr["kode"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, Tools.isNull(dr["sub"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerk", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        
                    }
                }
            }
        }

        private void DownloadBukti()
        {
            string fileName = _tempPath + "TmpHbk.DBF";


            DataTable result = ValidateFile(fileName, dtBukti);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[11].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_Bukti"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count12 = _count12 + 1;

                        dt.Rows[11]["Count"] = _count12;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@MK", SqlDbType.VarChar, Tools.isNull(dr["mk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@JenisBukti", SqlDbType.VarChar, Tools.isNull(dr["jns_bukti"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, Tools.isNull(dr["no_bukti"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglBukti", SqlDbType.DateTime, Tools.isNull(dr["tgl_bukti"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Kepada", SqlDbType.VarChar, Tools.isNull(dr["kepada"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Pembukuan", SqlDbType.VarChar, Tools.isNull(dr["pembukuan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, Tools.isNull(dr["acc"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, Tools.isNull(dr["kasir"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, Tools.isNull(dr["penerima"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        private void DownloadBuktiDetail()
        {
            string fileName = _tempPath + "TmpDbk.DBF";


            DataTable result = ValidateFile(fileName, dtBuktiDetail);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[12].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_BuktiDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count13 = _count13 + 1;

                        dt.Rows[12]["Count"] = _count13;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BSRecordID", SqlDbType.VarChar, Tools.isNull(dr["idbs"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Tools.isNull(dr["kode"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, Tools.isNull(dr["sub"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Jumlah", SqlDbType.Money, Tools.isNull(dr["jumlah"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        private void DownloadVoucherJurnal()
        {
            string fileName = _tempPath + "TmpHvc.DBF";


            DataTable result = ValidateFile(fileName, dtVoucherJournal);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[13].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_VoucherJournal"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count14 = _count14 + 1;

                        dt.Rows[13]["Count"] = _count14;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idvoucher"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Tipe", SqlDbType.VarChar, Tools.isNull(dr["tipe"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglVoucher", SqlDbType.DateTime, Tools.isNull(dr["tgl_vch"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoVoucher", SqlDbType.VarChar, Tools.isNull(dr["no_vch"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian1", SqlDbType.VarChar, Tools.isNull(dr["uraian1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian2", SqlDbType.VarChar, Tools.isNull(dr["uraian2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian3", SqlDbType.VarChar, Tools.isNull(dr["uraian3"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Dibuat", SqlDbType.VarChar, Tools.isNull(dr["dibuat"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Dibukukan", SqlDbType.VarChar, Tools.isNull(dr["dibukukan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Mengetahui", SqlDbType.VarChar, Tools.isNull(dr["mengetahui"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, Tools.isNull(dr["idbank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, Tools.isNull(dr["nama_bank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        private void DownloadVoucherJournalDetail()
        {
            string fileName = _tempPath + "TmpDvc.DBF";


            DataTable result = ValidateFile(fileName, dtVoucherJournalDetail);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[14].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_VoucherJournalDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count15 = _count15 + 1;

                        dt.Rows[14]["Count"] = _count15;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["idhvoucher"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["iddvoucher"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Tools.isNull(dr["kode"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, Tools.isNull(dr["sub"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@VoucherType", SqlDbType.VarChar, Tools.isNull(dr["voutype"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@VoucherNo", SqlDbType.VarChar, Tools.isNull(dr["vouno"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(dr["debet"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(dr["kredit"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["desc1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            } 
        }

        private void DownloadTransferBank()
        {
            string fileName = _tempPath + "TmpHtr.DBF";


            DataTable result = ValidateFile(fileName, dtTransferBank);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[15].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_TransferBank"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count16 = _count16 + 1;

                        dt.Rows[15]["Count"] = _count16;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idbbm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglBBM", SqlDbType.DateTime, Tools.isNull(dr["tgl_bbm"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBBM", SqlDbType.VarChar, Tools.isNull(dr["no_bbm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@MK", SqlDbType.VarChar, Tools.isNull(dr["mk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Dibukukan", SqlDbType.VarChar, Tools.isNull(dr["dibukuan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Diketahui", SqlDbType.VarChar, Tools.isNull(dr["diketahui"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, Tools.isNull(dr["kasir"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Penyetor", SqlDbType.VarChar, Tools.isNull(dr["penyetor"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            } 
        }

        private void DownloadTransferBankDetail()
        {
            string fileName = _tempPath + "TmpDtr.DBF";


            DataTable result = ValidateFile(fileName, dtTransferBankDetail);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[16].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_TransferBankDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count17 = _count17 + 1;

                        dt.Rows[16]["Count"] = _count17;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtrm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["idbbm"],"").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@AsalTransfer", SqlDbType.VarChar, Tools.isNull(dr["asaltrf"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, Tools.isNull(dr["namabank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, Tools.isNull(dr["lokasi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Nomor", SqlDbType.VarChar, Tools.isNull(dr["nomor"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTransfer", SqlDbType.DateTime, Tools.isNull(dr["tgl_trf"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Tools.isNull(dr["nominal"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@MainTitip", SqlDbType.VarChar, Tools.isNull(dr["maintitip"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SubTitip", SqlDbType.VarChar, Tools.isNull(dr["subtitip"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@MainPiut", SqlDbType.VarChar, Tools.isNull(dr["mainpiut"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SubPiut", SqlDbType.VarChar, Tools.isNull(dr["subpiut"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, Tools.isNull(dr["idbank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TitiPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["titiperk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            } 
        }

        private void DownloadBBK()
        {
            string fileName = _tempPath + "TmpBbk.DBF";


            DataTable result = ValidateFile(fileName, dtBBK);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[17].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_BBK"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count18 = _count18 + 1;

                        dt.Rows[17]["Count"] = _count18;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idbbk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglBBK", SqlDbType.DateTime, Tools.isNull(dr["tgl_bbk"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBBK", SqlDbType.VarChar, Tools.isNull(dr["no_bbk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, Tools.isNull(dr["id_bank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RpGiro", SqlDbType.Money, Tools.isNull(dr["rp_giro"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RpCair", SqlDbType.Money, Tools.isNull(dr["rp_cair"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RpTolak", SqlDbType.Money, Tools.isNull(dr["rp_tolak"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Dibukukan", SqlDbType.VarChar, Tools.isNull(dr["dibukuan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Diketahui", SqlDbType.VarChar, Tools.isNull(dr["diketahui"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, Tools.isNull(dr["kasir"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, Tools.isNull(dr["penerima"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            } 
        }

        private void DownloadBBM()
        {
            string fileName = _tempPath + "TmpBbm.DBF";


            DataTable result = ValidateFile(fileName, dtBBM);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[18].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_BBM"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count19 = _count19 + 1;

                        dt.Rows[18]["Count"] = _count19;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idbbm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglBBM", SqlDbType.DateTime, Tools.isNull(dr["tgl_bbm"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBBM", SqlDbType.VarChar, Tools.isNull(dr["no_bbm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, Tools.isNull(dr["id_bank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RpGiro", SqlDbType.Money, Tools.isNull(dr["rp_giro"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RpCair", SqlDbType.Money, Tools.isNull(dr["rp_cair"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RpTolak", SqlDbType.Money, Tools.isNull(dr["rp_tolak"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Dibukukan", SqlDbType.VarChar, Tools.isNull(dr["dibukuan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Diketahui", SqlDbType.VarChar, Tools.isNull(dr["diketahui"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, Tools.isNull(dr["kasir"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Penyetor", SqlDbType.VarChar, Tools.isNull(dr["penyetor"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            } 
        }

        private void DownloadGiro()
        {
            string fileName = _tempPath + "TmpGro.DBF";


            DataTable result = ValidateFile(fileName, dtGiro);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[19].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_Giro"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count20 = _count20 + 1;

                        dt.Rows[19]["Count"] = _count20;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@VoucherRecID", SqlDbType.VarChar, Tools.isNull(dr["idvoucher"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BBMRecID", SqlDbType.VarChar, Tools.isNull(dr["idbbm"],"").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TitipRecID", SqlDbType.VarChar, Tools.isNull(dr["idtitip"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@GiroRecID", SqlDbType.VarChar, Tools.isNull(dr["idgiro"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, Tools.isNull(dr["namabank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, Tools.isNull(dr["lokasi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@CHBG", SqlDbType.VarChar, Tools.isNull(dr["chbg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Nomor", SqlDbType.VarChar, Tools.isNull(dr["nomor"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglGiro", SqlDbType.DateTime, Tools.isNull(dr["tgl_giro"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglJth", SqlDbType.DateTime, Tools.isNull(dr["tgl_jt"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Tools.isNull(dr["nominal"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@CairTolak", SqlDbType.VarChar, Tools.isNull(dr["cairtolak"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglCair", SqlDbType.DateTime, Tools.isNull(dr["tgl_cair"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@MainTitip", SqlDbType.VarChar, Tools.isNull(dr["maintitip"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SubTitip", SqlDbType.VarChar, Tools.isNull(dr["subtitip"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@MainPiutang", SqlDbType.VarChar, Tools.isNull(dr["mainpiut"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SubPiutang", SqlDbType.VarChar, Tools.isNull(dr["subpiut"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, Tools.isNull(dr["idbank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBanki", SqlDbType.VarChar, Tools.isNull(dr["nm_banki"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTitip", SqlDbType.DateTime, Tools.isNull(dr["tgl_titip"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@MainPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["mainperk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            } 
        }

        private void DownloadGiroInternal()
        {
            string fileName = _tempPath + "TmpGin.DBF";


            DataTable result = ValidateFile(fileName, dtGiroInternal);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[20].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_GiroInternal"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count21 = _count21 + 1;

                        dt.Rows[20]["Count"] = _count21;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@BBKRecID", SqlDbType.VarChar, Tools.isNull(dr["idbbk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@GiroRecID", SqlDbType.VarChar, Tools.isNull(dr["idgiro"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, Tools.isNull(dr["idbank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@IndRecID", SqlDbType.VarChar, Tools.isNull(dr["idind"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Tools.isNull(dr["kode"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, Tools.isNull(dr["sub"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@GC", SqlDbType.VarChar, Tools.isNull(dr["gc"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, Tools.isNull(dr["bank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, Tools.isNull(dr["no_giro"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglGiro", SqlDbType.DateTime, Tools.isNull(dr["tgl_giro"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglJth", SqlDbType.DateTime, Tools.isNull(dr["tgl_jt"], DBNull.Value)));                        
                        db.Commands[0].Parameters.Add(new Parameter("@CairTolak", SqlDbType.VarChar, Tools.isNull(dr["cairtolak"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglCair", SqlDbType.DateTime, Tools.isNull(dr["tgl_cair"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@VTA", SqlDbType.VarChar, Tools.isNull(dr["vta"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Tools.isNull(dr["nominal"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kepada", SqlDbType.VarChar, Tools.isNull(dr["kepada"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Keperluan", SqlDbType.VarChar, Tools.isNull(dr["keperluan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            } 
        }

        private void DownloadKasbon()
        {
            string fileName = _tempPath + "TmpKas.DBF";


            DataTable result = ValidateFile(fileName, dtKasbon);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[21].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_Kasbon"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count22 = _count22 + 1;

                        dt.Rows[21]["Count"] = _count22;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idkasbon"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, Tools.isNull(dr["nip"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, Tools.isNull(dr["nama"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@UnitKerja", SqlDbType.VarChar, Tools.isNull(dr["unitkerja"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, Tools.isNull(dr["no"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Tgl", SqlDbType.DateTime, Tools.isNull(dr["tgl"],DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Keperluan", SqlDbType.VarChar, Tools.isNull(dr["keperluan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BKKNo1", SqlDbType.VarChar, Tools.isNull(dr["bkkno1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TRKNo1", SqlDbType.VarChar, Tools.isNull(dr["trkno1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BBKNo1", SqlDbType.VarChar, Tools.isNull(dr["bbkno1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BKKRp1", SqlDbType.Money, Tools.isNull(dr["bkkrp1"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TRKRp1", SqlDbType.Money, Tools.isNull(dr["trkrp1"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@BBKRp1", SqlDbType.Money, Tools.isNull(dr["bbkrp1"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Total1", SqlDbType.Money, Tools.isNull(dr["total1"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@JVNo1", SqlDbType.VarChar, Tools.isNull(dr["jv_no1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@JVNo2", SqlDbType.VarChar, Tools.isNull(dr["jv_no2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@JVNo3", SqlDbType.VarChar, Tools.isNull(dr["jv_no3"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@JVRp1", SqlDbType.Money, Tools.isNull(dr["jv_rp1"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@JVRp2", SqlDbType.Money, Tools.isNull(dr["jv_rp2"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@JVRp3", SqlDbType.Money, Tools.isNull(dr["jv_rp3"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Total2", SqlDbType.Money, Tools.isNull(dr["total2"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@BKKNo3", SqlDbType.VarChar, Tools.isNull(dr["bkkno3"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TRKNo3", SqlDbType.VarChar, Tools.isNull(dr["trkno3"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BBKNo3", SqlDbType.VarChar, Tools.isNull(dr["bbkno3"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BKMNo3", SqlDbType.VarChar, Tools.isNull(dr["bkmno3"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TRNNo3", SqlDbType.VarChar, Tools.isNull(dr["trnno3"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BBMNo3", SqlDbType.VarChar, Tools.isNull(dr["bbmno3"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BKKRp3", SqlDbType.Money, Tools.isNull(dr["bkkrp3"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TRKRp3", SqlDbType.Money, Tools.isNull(dr["trkrp3"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@BBKRp3", SqlDbType.Money, Tools.isNull(dr["bbkrp3"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Totku3", SqlDbType.Money, Tools.isNull(dr["totku3"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@BKMRp3", SqlDbType.Money, Tools.isNull(dr["bkmrp3"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TRNRp3", SqlDbType.Money, Tools.isNull(dr["trnrp3"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@BBMRp3", SqlDbType.Money, Tools.isNull(dr["bbmrp3"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Totle3", SqlDbType.Money, Tools.isNull(dr["totle3"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Tools.isNull(dr["kode"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, Tools.isNull(dr["sub"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Hari", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari"], "").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            } 
        }

        private void DownloadPinjamanPegawai()
        {
            string fileName = _tempPath + "TmpPgw.DBF";


            DataTable result = ValidateFile(fileName, dtPinjamanPegawai);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[22].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_PinjamanPegawai"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count23 = _count23 + 1;

                        dt.Rows[22]["Count"] = _count23;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["iddpinj"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, Tools.isNull(dr["nip"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglPinjam", SqlDbType.DateTime, Tools.isNull(dr["tgl"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, Tools.isNull(dr["ref"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoRef", SqlDbType.VarChar, Tools.isNull(dr["no_ref"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(dr["debet"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(dr["kredit"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@KeteranganLain", SqlDbType.VarChar, Tools.isNull(dr["ket_lain2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            } 
        }

        private void DownloadStaff()
        {
            string fileName = _tempPath + "TmpSas.DBF";


            DataTable result = ValidateFile(fileName, dtStaff);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[23].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_Staff"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count24 = _count24 + 1;

                        dt.Rows[23]["Count"] = _count24;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, Tools.isNull(dr["nip"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, Tools.isNull(dr["nama"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Jabatan", SqlDbType.VarChar, Tools.isNull(dr["jabatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@UnitKerja", SqlDbType.VarChar, Tools.isNull(dr["unitkerja"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LP", SqlDbType.VarChar, Tools.isNull(dr["lp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, Tools.isNull(dr["alamat"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoTelp", SqlDbType.VarChar, Tools.isNull(dr["no_telp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.DateTime, Tools.isNull(dr["tgl_lahir"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglMasuk", SqlDbType.DateTime, Tools.isNull(dr["tgl_masuk"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, Tools.isNull(dr["tgl_keluar"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["keterangan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Gaji", SqlDbType.Money, Tools.isNull(dr["gaji"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@UM", SqlDbType.Money, Tools.isNull(dr["um"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@PerKoli", SqlDbType.Money, Tools.isNull(dr["perkoli"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Bonus", SqlDbType.Money, Tools.isNull(dr["bonus"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Hutang", SqlDbType.Money, Tools.isNull(dr["hutang"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Agama", SqlDbType.VarChar, Tools.isNull(dr["agama"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@JTelat", SqlDbType.VarChar, Tools.isNull(dr["j_telat"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@JMaxum", SqlDbType.VarChar, Tools.isNull(dr["j_maxum"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Stk", SqlDbType.VarChar, Tools.isNull(dr["stk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            } 
        }

        private void DownloadBank()
        {
            string fileName = _tempPath + "TmpBnk.DBF";


            DataTable result = ValidateFile(fileName, dtBank);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[24].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_Bank"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count25 = _count25 + 1;

                        dt.Rows[24]["Count"] = _count25;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, Tools.isNull(dr["idbank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@JRek", SqlDbType.VarChar, Tools.isNull(dr["j_rek"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, Tools.isNull(dr["nama_bank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaAccount", SqlDbType.VarChar, Tools.isNull(dr["nama_acc"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoAccount", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Alamat1", SqlDbType.VarChar, Tools.isNull(dr["alm1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Alamat2", SqlDbType.VarChar, Tools.isNull(dr["alm2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, Tools.isNull(dr["kota"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Telp", SqlDbType.VarChar, Tools.isNull(dr["telp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@CService", SqlDbType.VarChar, Tools.isNull(dr["cservis"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, Tools.isNull(dr["no_giro"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoCheck", SqlDbType.VarChar, Tools.isNull(dr["no_ch"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBBK", SqlDbType.VarChar, Tools.isNull(dr["no_bbk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@VTA", SqlDbType.VarChar, Tools.isNull(dr["vta"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Saldo", SqlDbType.Money, Tools.isNull(dr["saldo"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Limit", SqlDbType.Money, Tools.isNull(dr["limit"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglRek", SqlDbType.DateTime, Tools.isNull(dr["tgl_rk"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@SaldoAwal", SqlDbType.Money, Tools.isNull(dr["saldo_aw"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@SaldoAkhir", SqlDbType.Money, Tools.isNull(dr["saldo_ak"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Tools.isNull(dr["kode"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, Tools.isNull(dr["sub"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@MainTitip", SqlDbType.VarChar, Tools.isNull(dr["maintitip"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SubTitip", SqlDbType.VarChar, Tools.isNull(dr["subtitip"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@MainPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["mainperk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            } 
        }

        private void DownloadBankDetail()
        {
            string fileName = _tempPath + "TmpDnk.DBF";


            DataTable result = ValidateFile(fileName, dtBankDetail);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    gridUpload.CurrentCell = gridUpload.Rows[25].Cells[0];
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_BankDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        _count26 = _count26 + 1;

                        dt.Rows[25]["Count"] = _count26;
                        gridUpload.Refresh();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["idbank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["iddbank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RegID", SqlDbType.VarChar, Tools.isNull(dr["id_reg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTran", SqlDbType.DateTime, Tools.isNull(dr["tgl_tran"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBBK", SqlDbType.VarChar, Tools.isNull(dr["no_bbk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsTran", SqlDbType.VarChar, Tools.isNull(dr["jns_tran"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBGCH", SqlDbType.VarChar, Tools.isNull(dr["nobgch"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["keterangan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@VTA", SqlDbType.VarChar, Tools.isNull(dr["vta"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(dr["debet"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(dr["kredit"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglBank", SqlDbType.DateTime, Tools.isNull(dr["tgl_bank"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglRK", SqlDbType.DateTime, Tools.isNull(dr["tgl_rk"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Saldo", SqlDbType.Money, Tools.isNull(dr["saldo"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LinkRK", SqlDbType.VarChar, Tools.isNull(dr["link_rk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Tools.isNull(dr["kode"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, Tools.isNull(dr["sub"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            } 
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (rdoUpload.Checked)
            {
                UploadProcess();
            }  
            else if (rdoDownload.Checked)
            {
                DownloadProcess();
            }
            else
            {
                MessageBox.Show("Tentukan Pilihan !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Cursor = Cursors.Default;
            
        }

        private void UploadProcess()
        {
            try
            {
                RefreshCounter();
                this.Cursor = Cursors.WaitCursor;
                UploadGiroTolak();
                UploadGiroTolakDetail();
                UploadKartuPiutang();
                UploadKartuPiutangDetail();
                UploadTokoToSales();
                UploadInden();
                UploadIndenDetail();
                UploadIndenSubDetail();
                UploadIndenSuperDetail();
                UploadBukti();
                UploadBuktiDetail();
                UploadVoucherJurnal();
                UploadVoucherJurnalDetail();
                UploadTransferBank();
                UploadTransferBankDetail();
                UploadBBK();
                UploadBBM();
                UploadGiro();
                UploadGiroInternal();
                UploadKasbon();
                UploadPinjamanPegawai();
                UploadStaff();
                UploadBank();
                UploadBankDetail();
                UploadTagihan();
                ZipFile(files);
                this.Cursor = Cursors.Default;
                MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "KAS" + GlobalVar.Gudang + ".ZIP");

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

        private void DownloadProcess()
        {
            _tempPath = GlobalVar.DbfDownload + "\\KAS"+GlobalVar.Gudang+"\\";

            if (!Directory.Exists(_tempPath))
            {
                Directory.CreateDirectory(_tempPath);
            }
            else
            {
                string[] files = Directory.GetFiles(_tempPath);

                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }

            if (File.Exists(fileZipName))
            {
                Zip.UnZipFiles(fileZipName, _tempPath, false);
            }
            else
            {
                MessageBox.Show("File : " + fileZipName + " tidak ditemukan !");
                return;
            }

            try
            {
                RefreshCounter();
                DownloadTokoToSales();
                DownloadStaff();
                DownloadBank();
                DownloadKasbon(); // Field Status Diisi Apa ????
                DownloadInden();
                DownloadVoucherJurnal();
                DownloadKartuPiutang();
                DownloadTransferBank();
                DownloadIndenDetail();
                DownloadVoucherJournalDetail();
                DownloadBBM();
                DownloadGiro();
                DownloadTransferBankDetail();
                DownloadBankDetail();
                DownloadBukti();
                DownloadBuktiDetail();
                DownloadPinjamanPegawai();
                DownloadIndenSubDetail();
                DownloadGiroTolak();
                DownloadTagihan();
                DownloadTagihanDetail();
                DownloadIndenSuperDetail();
                DownloadKartuPiutangDetail();
                DownloadGiroTolakDetail();
                DownloadTagihanSubDetail();
                DownloadBBK();
                DownloadGiroInternal();

                //Deleted Record
                ExecDelete();
                MessageBox.Show(Messages.Confirm.ProcessFinished);
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void ZipFile(List<string> files)
        {
             

            string fileZipName = GlobalVar.DbfUpload + "\\KAS"+ GlobalVar.Gudang +".zip";

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

        private DataTable ValidateFile(string fileName, DataTable table)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    table = Foxpro.ReadFile(fileName);

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File: " + fileName + " tidak ditemukan !");
                table = null;
            }
            return table;
        }

        private void rdoDownload_CheckedChanged(object sender, EventArgs e)
        {
           
                rangeDateBox1.Enabled = false;
            
             
            
        }

        private void rdoUpload_CheckedChanged(object sender, EventArgs e)
        {
            rangeDateBox1.Enabled = true;
        }

        #region "Deleted Record"

        private void ExecDelete()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string fileName_ = "";

                fileName_= _tempPath + "TmpDdi.DBF"; 
                TableDelete(fileName_, "IndenSuperDetail", "RecordID", "iddrec");

                fileName_ = _tempPath + "DbgTmp.DBF";
                TableDelete(fileName_, "GiroTolakDetail", "RecordID", "dstamp");


                fileName_ = _tempPath + "DpiTmp.DBF";
                TableDelete(fileName_, "KartuPiutangDetail", "RecordID", "idrec");

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            	
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void TableDelete(string fileName, string tableName, string isaColName, string foxproColName)
        {
            DataTable dt = Foxpro.ReadDeletedFile(fileName);
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("[psp_DownloadKasir_DELETE_TABLE]"));
                foreach (DataRow dr in dt.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, tableName));
                    db.Commands[0].Parameters.Add(new Parameter("@columnKeyName", SqlDbType.VarChar, isaColName));
                    db.Commands[0].Parameters.Add(new Parameter("@columnKeyValue", SqlDbType.VarChar, Tools.isNull(dr[foxproColName], "").ToString().Trim()));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
        }


        #endregion  




    }
}
