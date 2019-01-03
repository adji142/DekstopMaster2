using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using ISA.Trading.Class;

namespace ISA.Trading.Communicator
{
    public partial class frmPenjualanDOUpload00 : ISA.Trading.BaseForm
    {
        DataSet dsResult = new DataSet();

        string FileName1 = "Htjtmp";
        string FileName2 = "Dtjtmp";

        public frmPenjualanDOUpload00()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (dsResult.Tables.Count == 0)
            {
                cmdSearch.PerformClick();    
            }

            if (dsResult.Tables[0].Rows.Count > 0 && dsResult.Tables[1].Rows.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    Upload();
                    ZipFile();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang + lookupGudang.GudangID + ".zip");
                    DisplayReport();
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
            else
            {
                MessageBox.Show(Messages.Error.NotFound);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {

            if (rangeDO.FromDate != null && rangeDO.ToDate != null && !String.IsNullOrEmpty(lookupGudang.GudangID))
            {
                RefreshData();
            }
            else
            {
                MessageBox.Show("Tanggal DO atau Kode gudang tidak boleh kosong", "Upload Transaksi Penjualan DO ke 00", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenjualanDOTransaksiKe00_UPLOAD"));
                    db.Commands[0].Parameters.Add(new Parameter("@dateFrom", SqlDbType.DateTime, rangeDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@dateTo", SqlDbType.DateTime, rangeDO.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.Char, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.Char, lookupGudang.GudangID));
                    dsResult = db.Commands[0].ExecuteDataSet();
                    
                    gvUpload1.DataSource = dsResult.Tables[0];
                    gvUpload2.DataSource = dsResult.Tables[1];
                    
                    pbUpload1.Value = 0;
                    pbUpload2.Value = 0;
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

        private void Upload()
        {
            string Physical1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            string Physical2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".dbf";

            if (File.Exists(Physical1))
            {
                File.Delete(Physical1);
            }

            if (File.Exists(Physical2))
            {
                File.Delete(Physical2);
            }
            
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("HtrID", "Idhtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Cabang1", "Cab1", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("Cabang2", "Cab2", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("Cabang3", "Cab3", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("NoRequest", "No_rq", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglRequest", "Tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoDO", "No_do", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglDO", "Tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoACCPiutang", "No_nota", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglACCPiutang", "Tgl_nota", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("StatusBatal", "No_sj", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglSuratJalan", "Tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglTerima", "Tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("HariKredit", "Hr_krdt", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("TokoId", "Kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("KodeSales", "Kd_sales", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("NamaToko", "Nm_toko", Foxpro.enFoxproTypes.Char, 31));
            fields.Add(new Foxpro.DataStruct("AlamatKirim", "Al_kirim", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("Kota", "Kota", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("RpJual", "Rp_jual", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpJual2", "Rp_jual2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpJual3", "Rp_jual3", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpNet", "Rp_net", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpNet2", "Rp_net2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpNet3", "Rp_net3", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Disc1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Disc2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Disc3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("RpPot", "Pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("Plafon", "Pot_rp2", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("SaldoPiutang", "Pot_rp3", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("QtyTolak", "Rp_fee1", Foxpro.enFoxproTypes.Numeric, 11));
            fields.Add(new Foxpro.DataStruct("Overdue", "Rp_fee2", Foxpro.enFoxproTypes.Numeric, 11));
            fields.Add(new Foxpro.DataStruct("Expedisi", "Expedisi", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("isClosed", "Laudit", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("DiscFormula", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Memo, 4));
            fields.Add(new Foxpro.DataStruct("Catatan1", "Catatan1", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan2", "Catatan2", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan3", "Catatan3", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan4", "Catatan4", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan5", "Catatan5", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("NoDOBO", "No_dobo", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglReorder", "Tgl_reord", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("StatusBO", "Lbo", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("LinkID", "Id_link", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("TransactionType", "Id_tr", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("HariKirim", "Hari_krm", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("HariSales", "Hari_sls", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("NPrint", "Nprint", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("NoACCPusat", "No_acc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Shift", "Shift", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("ACCPiutangID", "Checker_1", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("Checker2", "Checker_2", Foxpro.enFoxproTypes.Char, 11));

            fields.Add(new Foxpro.DataStruct("Cicil", "Cicil", Foxpro.enFoxproTypes.Numeric, 2));

            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("idhtr", "IDHTR"));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName1, fields, dsResult.Tables[0], pbUpload1, index);

            
            List<Foxpro.DataStruct> fields2 = new List<Foxpro.DataStruct>();

            fields2.Add(new Foxpro.DataStruct("RecordID", "Idrec", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("HtrID", "Idhtr", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("NamaStok", "Nama_stok", Foxpro.enFoxproTypes.Char, 73));
            fields2.Add(new Foxpro.DataStruct("KodeSolo", "Klp", Foxpro.enFoxproTypes.Char, 3));
            fields2.Add(new Foxpro.DataStruct("QtyRequest", "J_rq", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("QtyDO", "J_do", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("QtySuratJalan", "J_sj", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("QtyNota", "J_nota", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("QtyRetur", "J_retur", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("QtyKoli", "J_koli", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("KoliAwal", "Koli_awal", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("KoliAkhir", "Koli_akhir", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("NoKoli", "No_koli", Foxpro.enFoxproTypes.Char, 15));
            fields2.Add(new Foxpro.DataStruct("Satuan", "Satuan", Foxpro.enFoxproTypes.Char, 3));
            fields2.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("TglSuratJalan", "Tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
            fields2.Add(new Foxpro.DataStruct("HrgJual", "H_jual", Foxpro.enFoxproTypes.Numeric, 7));
            fields2.Add(new Foxpro.DataStruct("HargaPokok", "H_pokok", Foxpro.enFoxproTypes.Numeric, 7));
            fields2.Add(new Foxpro.DataStruct("HPPSolo", "Hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
            fields2.Add(new Foxpro.DataStruct("Disc1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("Disc2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("Disc3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("Pot", "Pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
            fields2.Add(new Foxpro.DataStruct("DiscFormula", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields2.Add(new Foxpro.DataStruct("KoreksiID", "Id_koreksi", Foxpro.enFoxproTypes.Char, 19));
            fields2.Add(new Foxpro.DataStruct("KodeToko", "Kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields2.Add(new Foxpro.DataStruct("NoDOBO", "No_bodo", Foxpro.enFoxproTypes.Char, 7));
            fields2.Add(new Foxpro.DataStruct("SyncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
            fields2.Add(new Foxpro.DataStruct("NBOPrint", "Nprint", Foxpro.enFoxproTypes.Numeric, 1));
            fields2.Add(new Foxpro.DataStruct("NoACC", "No_acc", Foxpro.enFoxproTypes.Char, 7));
            fields2.Add(new Foxpro.DataStruct("KetKoli", "Ket_koli", Foxpro.enFoxproTypes.Char, 20));
            fields2.Add(new Foxpro.DataStruct("BarangID", "Id_brg", Foxpro.enFoxproTypes.Char, 23));

            List<Foxpro.IndexStruct> index2 = new List<Foxpro.IndexStruct>();
            index2.Add(new Foxpro.IndexStruct("idhtr", "IDHTR"));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName2, fields2, dsResult.Tables[1], pbUpload2, index2);
            
        }

        private void ZipFile()
        {            
            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            string fileName1FPT = GlobalVar.DbfUpload + "\\" + FileName1 + ".fpt";
            string fileName2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".dbf";
            string fileIndex1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".cdx";
            string fileIndex2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".cdx";
            string fileZipName = GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang + lookupGudang.GudangID + ".zip";

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            List<string> files = new List<string>();
            files.Add(fileName1);
            files.Add(fileName2);
            files.Add(fileIndex1);
            files.Add(fileIndex2);
            files.Add(fileName1FPT);

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(fileName1))
            {
                File.Delete(fileName1);
            }

            if (File.Exists(fileName2))
            {
                File.Delete(fileName2);
            }

            if (File.Exists(fileIndex1))
            {
                File.Delete(fileIndex1);
            }

            if (File.Exists(fileIndex2))
            {
                File.Delete(fileIndex2);
            }

            if (File.Exists(fileName1FPT))
            {
                File.Delete(fileName1FPT);
            }
        }

        private void frmPenjualanDOUpload00_Load(object sender, EventArgs e)
        {
            rangeDO.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDO.ToDate = DateTime.Now;
        }

        private void lookupGudang_Load(object sender, EventArgs e)
        {

        }

        private void DisplayReport()
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDO.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDO.ToDate).ToString("dd/MM/yyyy"));
            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            List<DataTable> pTable = new List<DataTable>();
            List<string> pDatasetName = new List<string>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            pTable.Add(dsResult.Tables[2]);
            pTable.Add(dsResult.Tables[3]);
            pTable.Add(dsResult.Tables[0]);
           

            pDatasetName.Add("dsOrderPenjualan_Data1");
            pDatasetName.Add("dsOrderPenjualan_Data2");
            pDatasetName.Add("dsOrderPenjualan_Data");
            

            frmReportViewer ifrmReport = new frmReportViewer("Communicator.rptPenjualanDOUpload00.rdlc", rptParams, pTable, pDatasetName);

            ifrmReport.Show();

        }
    }
}
