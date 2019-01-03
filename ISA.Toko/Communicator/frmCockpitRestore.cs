using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ISA.Toko.Class;
using ISA.DAL;

namespace ISA.Toko.Communicator
{
    public partial class frmCockpitRestore : ISA.Toko.BaseForm
    {
        public frmCockpitRestore()
        {
            InitializeComponent();
        }
        string fileZipName = GlobalVar.DbfUpload + "\\dbfmatch.zip";
        int jumlahTable = 34;
        int restoreFinish = 0;
        protected DataTable
       HtransjDt,
       HhtransjDt,
       DtransjDt,
       HreturjDt,
       DreturjDt,
       DhtransjDt,
       HosheetDt,
       DoSheetDt,
       HtransbDt,
       DtransbDt,
       HreturbDt,
       DreturbDt,
       HpinjamDt,
       DpinjamDt,
       HkembaliDt,
       DkembaliDt,
       HxpdcDt,
       DxpdcDt,
       CxpdcDt,
       HmutstokDt,
       DmutstokDt,
       OpnameDt,
       KompensasiDt,
       StokopnmDt,
       ExpedisiDt,
       SalesDt,
       TokoDt,
       StatusTokoDt,
       SasStokDt,
       HkrmagudDt,
       DkrmagudDt,
       HpotJDt,
       PemasokDt,
       KoreksiPembelianDt,
       KoreksiPenjualanDt,
       KoreksiReturPembelianDt,
       KoreksiReturPenjualanDt,
       SelisihDt,
       DSelisihDt;


        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (File.Exists(fileZipName))
            {
                Zip.UnZipFiles(fileZipName, GlobalVar.DbfDownload + "\\CockpitTmp\\", false);
            }
            else
            {
                MessageBox.Show("File : " + fileZipName + " tidak ditemukan !");
                return;
            }
            cmdYes.Enabled = false;
            cmdCancel.Enabled = false;
            //if (CockpitChecker() >= 1)
            //{
                DownloadAntarGudang(); RestoreCount();
                DownloadAntarGudangDetail(); RestoreCount();
                DownloadExpedisi(); RestoreCount();
                DownloadKompensasi(); RestoreCount();
                DownloadToko(); RestoreCount();
                DownloadSales(); RestoreCount();
                DownloadStok(); RestoreCount();
                DownloadPemasok(); RestoreCount();
                DownloadOpname(); RestoreCount();
                DownloadOrderPembelian(); RestoreCount();
                DownloadOrderPembelianDetail(); RestoreCount();
                DownloadRekapKoli(); RestoreCount();
                DownloadRekapKoliDetail(); RestoreCount();
                DownloadRekapKoliSubDetail(); RestoreCount();
                DownloadMutasi(); RestoreCount();
                DownloadMutasiDetail(); RestoreCount();
                DownloadPeminjaman(); RestoreCount();
                DownloadPeminjamanDetail(); RestoreCount();
                DownloadPengembalian(); RestoreCount();
                DownloadPengembalianDetail(); RestoreCount();
                DownloadSelisih(); RestoreCount();
                DownloadSelisihDetail(); RestoreCount();
                DownloadReturPembelian(); RestoreCount();
                DownloadReturPembelianDetail(); RestoreCount();
                DownloadPenjualanPotongan(); RestoreCount();
                //DownloadPenjualanPotonganDetail(); --> ISA tidak punya potongan Detail
                DownloadNotaPembelian(); RestoreCount();
                DownloadNotaPembelianDetail(); RestoreCount();
                DownloadNotaPenjualan(); RestoreCount();
                DownloadNotaPenjualanDetail(); RestoreCount();
                DownloadReturPenjualan(); RestoreCount();
                DownloadReturPenjualanDetail(); RestoreCount();
                DownloadOrderPenjualan(); RestoreCount();
                DownloadOrderPenjualanDetail(); RestoreCount();
                //DownloadBarangBonus(); --> ISA tidak punya Barang Bonus
                //DownloadBarangBonusDetail(); --> ISA tidak punya Barang Bonus Detail
                DownloadStatusToko(); RestoreCount();

                MessageBox.Show("Confirmation upload cockpit selesai !");
                //DeleteCockpitRecord();
                cmdYes.Enabled = true;
                cmdCancel.Enabled = true;
            //}
            //else
            //{
            //    MessageBox.Show("Confirmation upload failed !");
            //}
        }

        private void DeleteCockpitRecord()
        {
            using (Database db = new Database())
            {
                    db.Commands.Add(db.CreateCommand("psp_COCKPIT_DELETE"));
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@TGLUPLOAD", SqlDbType.DateTime, new FileInfo(fileZipName).CreationTime));
                    db.Commands[0].ExecuteNonQuery();
                
            }
        }

        private int CockpitChecker()
        {
            string temp = new FileInfo(fileZipName).LastWriteTime.ToString("yyyy-MM-dd hh:mm:ss");
            DateTime createFile = DateTime.Parse(temp);

            DataTable ReturnTable = null;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_COCKPIT_RETRIEVE"));
                db.Commands[0].Parameters.Clear();
                db.Commands[0].Parameters.Add(new Parameter("@TGLUPLOAD", SqlDbType.DateTime, createFile));
                ReturnTable = db.Commands[0].ExecuteDataTable();
            }
            return ReturnTable != null ? ReturnTable.Rows.Count : 0;
        }

        public void DownloadOrderPenjualan()
        {
            string fileName = "CockpitTmp\\HHjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Order Penjualan";
            DataTable result = ValidateFile(fileName, HhtransjDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_OrderPenjualan"));
                foreach (DataRow dr in result.Rows)
                {                    
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(dr["idhtr"], "")));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }

            }
        }

        public void DownloadOrderPenjualanDetail()
        {
            string fileName = "CockpitTmp\\DHjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Order Penjualan Detail";
            DataTable result = ValidateFile(fileName, DhtransjDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_OrderPenjualanDetail"));
                foreach (DataRow dr in result.Rows)
                {                    
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();

                }
            }

            DataTable dt = Foxpro.ReadDeletedFile(fileName);
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_DeletedHistory_UPDATE"));
                foreach (DataRow dr in dt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, "OrderPenjualanDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].ExecuteNonQuery();
                    this.refreshForm();
                }
            }
        }

        public void DownloadReturPenjualan()
        {
            string fileName = "CockpitTmp\\HrjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Penjualan";
            DataTable result = ValidateFile(fileName, HreturjDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_ReturPenjualan"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@ReturID", SqlDbType.VarChar, Tools.isNull(dr["idretur"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadReturPenjualanDetail()
        {
            string fileName = "CockpitTmp\\DrjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Retur Penjualan Detail";
            DataTable result = ValidateFile(fileName, DreturjDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_ReturPenjualanDetail"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadOrderPembelian()
        {
            string fileName = "CockpitTmp\\HShTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Order Pembelian";
            DataTable result = ValidateFile(fileName, HosheetDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_OrderPembelian"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadOrderPembelianDetail()
        {
            string fileName = "CockpitTmp\\Dshtmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Order Pembelian Detail";
            DataTable result = ValidateFile(fileName, DoSheetDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_OrderPembelianDetail"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadNotaPembelian()
        {
            string fileName = "CockpitTmp\\HtbTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Nota Pembelian";
            DataTable result = ValidateFile(fileName, HtransbDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_NotaPembelian"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadNotaPembelianDetail()
        {
            string fileName = "CockpitTmp\\DtbTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Nota Pembelian Detail";
            DataTable result = ValidateFile(fileName, DtransbDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_NotaPembelianDetail"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadReturPembelian()
        {
            string fileName = "CockpitTmp\\HrbTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Retur Pembelian";
            DataTable result = ValidateFile(fileName, HreturbDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_ReturPembelian"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@ReturID", SqlDbType.VarChar, Tools.isNull(dr["idretur"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadReturPembelianDetail()
        {
            string fileName = "CockpitTmp\\DrbTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Retur Pembelian Detail";
            DataTable result = ValidateFile(fileName, DreturbDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_ReturPembelianDetail"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadPengembalian()
        {
            string fileName = "CockpitTmp\\HkbTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Pengembalian";
            DataTable result = ValidateFile(fileName, HkembaliDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_Pengembalian"));
                foreach (DataRow dr in result.Rows)
                {

                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadPengembalianDetail()
        {
            string fileName = "CockpitTmp\\DkbTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Pengembalian Detail";
            DataTable result = ValidateFile(fileName, DkembaliDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_PengembalianDetail"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadPeminjaman()
        {
            string fileName = "CockpitTmp\\HpjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Peminjaman";
            DataTable result = ValidateFile(fileName, HpinjamDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_Peminjaman"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadPeminjamanDetail()
        {
            string fileName = "CockpitTmp\\DpjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Peminjaman Detail";
            DataTable result = ValidateFile(fileName, DpinjamDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_PeminjamanDetail"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadRekapKoli()
        {
            string fileName = "CockpitTmp\\HxpTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Rekap Koli";
            DataTable result = ValidateFile(fileName, HxpdcDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_RekapKoli"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }

        }

        public void DownloadRekapKoliDetail()
        {
            string fileName = "CockpitTmp\\DxpTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Rekap Koli Detail";
            DataTable result = ValidateFile(fileName, DxpdcDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_RekapKoliDetail"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }

        }

        public void DownloadRekapKoliSubDetail()
        {
            string fileName = "CockpitTmp\\CxpTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Rekap Koli Sub Detail";
            DataTable result = ValidateFile(fileName, CxpdcDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_RekapKoliSubDetail"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));

                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }

        }

        public void DownloadMutasi()
        {
            string fileName = "CockpitTmp\\HmtTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Mutasi";
            DataTable result = ValidateFile(fileName, HmutstokDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_Mutasi"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@MutasiID", SqlDbType.VarChar, Tools.isNull(dr["id_mts"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadMutasiDetail()
        {
            string fileName = "CockpitTmp\\DmtTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Mutasi Detail";
            DataTable result = ValidateFile(fileName, DmutstokDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_MutasiDetail"));
                foreach (DataRow dr in result.Rows)
                {

                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadAntarGudang()
        {
            string fileName = "CockpitTmp\\HAGTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Antar Gudang";
            DataTable result = ValidateFile(fileName, HkrmagudDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_AntarGudang"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idhkrmagud"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
            
        }

        public void DownloadAntarGudangDetail()
        {
            string fileName = "CockpitTmp\\DAGTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Antar Gudang Detail";
            DataTable result = ValidateFile(fileName, DkrmagudDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_AntarGudangDetail"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["iddkrmagud"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadPenjualanPotongan()
        {
            string fileName = "CockpitTmp\\HptTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Penjualan Potongan";
            DataTable result = ValidateFile(fileName, HpotJDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_PenjualanPotongan"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@PotID", SqlDbType.VarChar, Tools.isNull(dr["Idpot"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }



        public void DownloadSales()
        {
            string fileName = "CockpitTmp\\SlsTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Sales";
            DataTable result = ValidateFile(fileName, SalesDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_Sales"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadToko()
        {
            string fileName = "CockpitTmp\\TokTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Toko";
            DataTable result = ValidateFile(fileName, TokoDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_Toko"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@TokoID", SqlDbType.VarChar, Tools.isNull(dr["idtoko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }
        public void DownloadStatusToko()
        {
            string fileName = "CockpitTmp\\Stotmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Status Toko";
            DataTable result = ValidateFile(fileName, StatusTokoDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_StatusToko"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }
        public void DownloadStok()
        {
            string fileName = "CockpitTmp\\StkTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Stok";
            DataTable result = ValidateFile(fileName, SasStokDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_Stok"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadPemasok()
        {
            string fileName = "CockpitTmp\\PmsTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Pemasok";
            DataTable result = ValidateFile(fileName, PemasokDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_Pemasok"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@PemasokID", SqlDbType.VarChar, Tools.isNull(dr["idp"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadExpedisi()
        {
            string fileName = "CockpitTmp\\ExpTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Expedisi";
            DataTable result = ValidateFile(fileName, ExpedisiDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_Expedisi"));
                foreach (DataRow dr in result.Rows)
                {

                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@KodeExpedisi", SqlDbType.VarChar, Tools.isNull(dr["kode"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadKompensasi()
        {
            string fileName = "CockpitTmp\\KmpTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Kompensasi";
            DataTable result = ValidateFile(fileName, KompensasiDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_Kompensasi"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadOpname()
        {
            string fileName = "CockpitTmp\\SopTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Opname";
            DataTable result = ValidateFile(fileName, OpnameDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_Opname"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadSelisih()
        {
            string fileName = "CockpitTmp\\HslTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Selisih";
            DataTable result = ValidateFile(fileName, SelisihDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_Selisih"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idhselisih"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadSelisihDetail()
        {
            string fileName = "CockpitTmp\\DslTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Selisih Detail";
            DataTable result = ValidateFile(fileName, DSelisihDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_SelisihDetail"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadNotaPenjualan()
        {
            string fileName = "CockpitTmp\\HtjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Nota Penjualan";
            DataTable result = ValidateFile(fileName, HtransjDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_NotaPenjualan"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadNotaPenjualanDetail()
        {
            string fileName = "CockpitTmp\\DtjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Nota Penjualan Detail";
            DataTable result = ValidateFile(fileName, DtransjDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_NotaPenjualanDetail"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }

            DataTable dt = Foxpro.ReadDeletedFile(fileName);
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_DeletedHistory_UPDATE"));
                foreach (DataRow dr in dt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, "NotaPenjualanDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].ExecuteNonQuery();
                    this.refreshForm();
                }
            }
        }

        public void DownloadKoreksiPembelian()
        {
            string fileName = "CockpitTmp\\KorTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Koreksi Pembelian";
            DataTable result = ValidateFile(fileName, KoreksiPembelianDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_KoreksiPembelian"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["id_koreksi"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }

        }

        public void DownloadKoreksiPenjualan()
        {
            string fileName = "CockpitTmp\\KorTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Koreksi Penjualan";
            DataTable result = ValidateFile(fileName, KoreksiPenjualanDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_KoreksiPenjualan"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }

        }

        public void DownloadKoreksiReturPembelian()
        {
            string fileName = "CockpitTmp\\KorTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Retur Pembelian";
            DataTable result = ValidateFile(fileName, KoreksiReturPembelianDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_KoreksiReturPembelian"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
                }
            }
        }

        public void DownloadKoreksiReturPenjualan()
        {
            string fileName = "CockpitTmp\\KorTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Koreksi Retur Penjualan";
            DataTable result = ValidateFile(fileName, KoreksiReturPenjualanDt);
            this.refreshForm();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_CONFIRMATION_KoreksiReturPenjualan"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Confirm", SqlDbType.Int, 0));
                    db.Commands[0].ExecuteNonQuery();
                    pbSyncDownload.Increment(1);
                    this.refreshForm();
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
                    pbSyncDownload.Value = 0;
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = table.Rows.Count;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ditemukan !");

            return table;
        }

        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
            lblCount.Text = pbSyncDownload.Value.ToString("#,##0") + "/" + pbSyncDownload.Maximum.ToString("#,##0");
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RestoreCount()
        {
            restoreFinish++;
            lblJumlahTable.Text = restoreFinish.ToString() + "/" + jumlahTable.ToString();
        }
    }
}
