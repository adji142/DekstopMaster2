using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using ISA.Toko.Class;

namespace ISA.Toko.Communicator
{
    public partial class frmDOUpload11 : ISA.Toko.BaseForm
    {
        DataSet DsResult = new DataSet();
        
        string hFileName = "Htjtmp";
        string dFileName = "Dtjtmp";

        public frmDOUpload11()
        {
            InitializeComponent();
        }

        private void frmDOUpload11_Load(object sender, EventArgs e)
        {
            //rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.FromDate = DateTime.Now;
            rangeDateBox1.ToDate = DateTime.Now;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView2.AutoGenerateColumns = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (rangeDateBox1.FromDate != null && rangeDateBox1.ToDate != null)
            {
                RefreshData();
            }
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (DsResult.Tables.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    Upload();
                    ZipFile();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\DBFMATCH.ZIP");
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

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_UPLOAD_11"));
                    db.Commands.Add(db.CreateCommand("usp_StatusToko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeCabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@perusahaanID", SqlDbType.VarChar, GlobalVar.PerusahaanID));
                    DsResult = db.Commands[0].ExecuteDataSet();
                    dataGridView1.DataSource = DsResult.Tables[1];
                    dataGridView2.DataSource = DsResult.Tables[2];
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
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (DsResult.Tables.Count == 0)
                {
                    return;
                }
                string hPhysical = GlobalVar.DbfUpload + "\\" + hFileName + ".dbf";
                string dPhysical = GlobalVar.DbfUpload + "\\" + dFileName + ".dbf";
                if (File.Exists(hPhysical))
                {
                    File.Delete(hPhysical);
                }

                if (File.Exists(dPhysical))
                {
                    File.Delete(dPhysical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("HtrID", "idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Cabang1", "Cab1", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang2", "Cab2", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang3", "Cab3", Foxpro.enFoxproTypes.Char, 2));
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
                fields.Add(new Foxpro.DataStruct("RpJual", "rp_jual", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpJual2", "rp_jual2", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpJual3", "rp_jual3", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNet", "rp_net", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNet2", "rp_net2", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNet3", "rp_net3", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("Disc1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc1", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc1", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("RpPot", "pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("Plafon", "pot_rp2", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("SaldoPiutang", "pot_rp3", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("QtyTolak", "rp_fee1", Foxpro.enFoxproTypes.Numeric, 11));
                fields.Add(new Foxpro.DataStruct("Overdue", "rp_fee2", Foxpro.enFoxproTypes.Numeric, 11));
                fields.Add(new Foxpro.DataStruct("Expedisi", "expedisi", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("isClosed", "laudit", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("DiscFormula", "id_disc", Foxpro.enFoxproTypes.Char, 7));
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

                List<Foxpro.IndexStruct> indexH = new List<Foxpro.IndexStruct>();
                indexH.Add(new Foxpro.IndexStruct("idhtr", "IDHTR"));

                Foxpro.WriteFile(GlobalVar.DbfUpload, hFileName, fields, DsResult.Tables[1], pbUpload,indexH);


                fields.Clear();
                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("HtrID", "idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("Klp", "klp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("QtyRequest", "j_rq", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyDO", "j_do", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtySJ", "j_sj", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyNota", "j_nota", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyRetur", "j_retur", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("QtyKoli", "j_koli", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("KoliAwal", "koli_awal", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("KoliAkhir", "koli_akhir", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("NoKoli", "no_koli", Foxpro.enFoxproTypes.Char, 15));
                fields.Add(new Foxpro.DataStruct("SatSolo", "satuan", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("TglSuratJalan", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("HrgJual", "h_jual", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("HrgBMK", "h_pokok", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("HPPSolo", "hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Disc1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Pot", "pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("DiscFormula", "id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("KoreksiID", "id_koreksi", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("NoDOBO", "no_bodo", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("NBOPrint", "nprint", Foxpro.enFoxproTypes.Numeric, 1));
                fields.Add(new Foxpro.DataStruct("NoACC", "no_acc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("KetKoli", "ket_koli", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));

                List<Foxpro.IndexStruct> indexD = new List<Foxpro.IndexStruct>();
                indexD.Add(new Foxpro.IndexStruct("idhtr", "IDHTR"));

                Foxpro.WriteFile(GlobalVar.DbfUpload, dFileName, fields, DsResult.Tables[2], pbUpload2, indexD);



                using (Database db = new Database())
                {
                    foreach (DataRow dr in DsResult.Tables[1].Rows)
                    {
                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_UPLOAD_11_CONFIRM"));
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@DOID", SqlDbType.UniqueIdentifier, new Guid (dr["RowID"].ToString())));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void DisplayReport()
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            List<DataTable> pTable = new List<DataTable>();
            List<string> pDatasetName = new List<string>();
            pTable.Add(DsResult.Tables[0]);
            pTable.Add(DsResult.Tables[1]);
            pDatasetName.Add("dsOrderPenjualan_Data");
            pDatasetName.Add("dsOrderPenjualan_Data1");
            frmReportViewer ifrmReport = new frmReportViewer("Communicator.rptDOUpload11.rdlc", rptParams, pTable,pDatasetName );
            
            ifrmReport.Show();

        }

        private void ZipFile()
        {
            string fileName1 = GlobalVar.DbfUpload + "\\" + hFileName + ".dbf";
            string fileName2 = GlobalVar.DbfUpload + "\\" + dFileName + ".dbf";
            string fileName3 = GlobalVar.DbfUpload + "\\" + hFileName + ".cdx";
            string fileName4 = GlobalVar.DbfUpload + "\\" + dFileName + ".cdx";

            string fileZipName = GlobalVar.DbfUpload + "\\DBFMATCH.ZIP";

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            List<string> files = new List<string>();
            files.Add(fileName1);
            files.Add(fileName2);
            files.Add(fileName3);
            files.Add(fileName4);
           
            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(fileName1))
            {
                File.Delete(fileName1);
            }

            if (File.Exists(fileName2))
            {
                File.Delete(fileName2);
            }

            if (File.Exists(fileName3))
            {
                File.Delete(fileName3);
            }

            if (File.Exists(fileName4))
            {
                File.Delete(fileName4);
            }
        }
    }
}
