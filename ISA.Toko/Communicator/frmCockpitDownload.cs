using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Toko.Class;
using System.IO;
using ISA.DAL;
using System.Data.OleDb;

namespace ISA.Toko.Communicator
{
    public partial class frmCockpitDownload : ISA.Toko.BaseForm
    {
        string fileZipName = GlobalVar.DbfDownload + "\\dbfmatch.zip";
        int jumlahTable = 38;
        int ctr=0;

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
        StsTokoDt,
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
        public frmCockpitDownload()
        {
            InitializeComponent();
        }

        public void DownloadCount()
        {
            ctr++;
            lblDownload.Text = ctr.ToString() + "/" + jumlahTable.ToString();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdStartDownload_Click(object sender, EventArgs e)
        {
            string tempPath = GlobalVar.DbfDownload + "\\CockpitTmp\\";

            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }
            else
            {
                string[] files = Directory.GetFiles(tempPath);

                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }

            if (File.Exists(fileZipName))
            {
                Zip.UnZipFiles(fileZipName, tempPath, false);
            }
            else
            {
                MessageBox.Show("File : " + fileZipName + " tidak ditemukan !");
                return;
            }
            if (CockpitChecker() == 0)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                DownloadSales(); 
                DownloadToko();
                DownloadStatusToko();
                DownloadStok();
                DownloadPemasok();
                DownloadExpedisi();
                DownloadKompensasi();
                DownloadOpname();
                DownloadSelisih();
                DownloadSelisihDetail();
                //9

                DownloadOrderPenjualan(); 
                DownloadOrderPenjualanDetail();
                DownloadNotaPenjualan(); 
                DownloadNotaPenjualanDetail(); 
                DownloadReturPenjualan(); 
                DownloadReturPenjualanDetail(); 
                DownloadKoreksiPenjualan(); 
                DownloadKoreksiReturPenjualan(); 
                DownloadPenjualanPotongan(); 
                DownloadRekapKoli(); 
                DownloadRekapKoliDetail(); 
                DownloadRekapKoliSubDetail(); 
                //12

                DownloadOrderPembelian(); 
                DownloadOrderPembelianDetail(); 
                DownloadNotaPembelian(); 
                DownloadNotaPembelianDetail(); 
                DownloadReturPembelian(); 
                DownloadReturPembelianDetail(); 
                DownloadKoreksiPembelian(); 
                DownloadKoreksiReturPembelian(); 
                //7


                DownloadPeminjaman();
                DownloadPeminjamanDetail(); 
                DownloadPengembalian(); 
                DownloadPengembalianDetail(); 
                
                //4

                DownloadMutasi(); 
                DownloadMutasiDetail(); 
                DownloadAntarGudang(); 
                DownloadAntarGudangDetail(); 
                //4

                ExecDelete();

                this.Cursor = Cursors.Default;
                
                if (Directory.Exists(tempPath))
                {
                    string[] files = Directory.GetFiles(tempPath);

                    foreach (string file in files)
                    {
                        File.Delete(file);
                    }
                }

                MessageBox.Show("Download cockpit selesai !");
                this.Enabled = true;
            }
            else
                MessageBox.Show("Belum ada data yang diupload/belum dikonfirm");
            }

        private void frmCockpitDownload_Load(object sender, EventArgs e)
        {
        }

        private int CockpitChecker()
        {
            DataTable ReturnTable = null;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_COCKPIT_RETRIEVE"));
                db.Commands[0].Parameters.Clear();
                db.Commands[0].Parameters.Add(new Parameter("@TGLUPLOAD",SqlDbType.DateTime,new FileInfo(fileZipName).CreationTime));
                ReturnTable = db.Commands[0].ExecuteDataTable();
            }
            return ReturnTable != null ? ReturnTable.Rows.Count : 0;
        }

        public void DownloadOrderPenjualan()
        {
            try
            {
                string _connStrTemplate = "Provider = VFPOLEDB;Data Source={0}";
                string fileName = "CockpitTmp\\HHjTmp" + GlobalVar.CabangID + ".DBF";
                fileName = GlobalVar.DbfDownload + "\\" + fileName;
                label1.Text = "Download Order Penjualan";
                refreshForm();

                //DataTable result = ValidateFile(fileName, HhtransjDt);

                if (File.Exists(fileName))
                {
                    FileInfo info = new FileInfo(fileName);
                    string tableName = info.Name;
                    string connStr = String.Format(_connStrTemplate, info.DirectoryName);
                    string sqlQuery = "SELECT idhtr, cab1, cab2, cab3, no_rq, DTOC(tgl_rq) as tgl_rq, no_do, DTOC(tgl_do) as tgl_do, no_acc, no_nota, DTOC(tgl_nota) as tgl_nota, no_sj, DTOC(tgl_sj) as tgl_sj, DTOC(tgl_trm) as tgl_trm, hr_krdt, kd_toko,   nm_toko, kd_sales, al_kirim, kota, STR(rp_jual) as rp_jual, STR(rp_jual2) as rp_jual2, STR(rp_jual3) as rp_jual3, STR(rp_net) as rp_net, STR(rp_net2) as rp_net2, STR(rp_net3) as rp_net3, STR(disc_1) as disc_1, STR(disc_2) as disc_2, STR(disc_3) as disc_3, STR(pot_rp) as pot_rp, STR(pot_rp2) as pot_rp2, STR(pot_rp3) as pot_rp3, STR(rp_fee1) as rp_fee1, STR(rp_fee2) as rp_fee2, expedisi, laudit, id_disc, catatan1, catatan2, catatan3, catatan4, catatan5, no_dobo, DTOC(tgl_reord) as tgl_reord, lbo, id_match, id_link, id_tr, hari_krm, hari_sls, nprint, no_acc, shift, checker_1, checker_2  FROM HHjTmp" + GlobalVar.CabangID;

                    using (OleDbConnection conn = new OleDbConnection(connStr))
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = sqlQuery;
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        OleDbDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            object tglNota, tglReoder;

                            if (dr["tgl_nota"].ToString().Replace(" ", "") == "//")
                            {
                                tglNota = DBNull.Value;
                            }
                            else
                            {
                                tglNota = dr["tgl_nota"];
                            }

                            if (dr["tgl_reord"].ToString().Replace(" ", "") == "//")
                            {
                                tglReoder = DBNull.Value;
                            }
                            else
                            {
                                tglReoder = dr["tgl_reord"];
                            }

                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_OrderPenjualan"));
                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(dr["idhtr"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["cab2"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, Tools.isNull(dr["cab3"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, Tools.isNull(dr["no_rq"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, Tools.isNull(dr["tgl_rq"], DBNull.Value)));
                                db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, Tools.isNull(dr["no_do"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, Tools.isNull(dr["tgl_do"], DBNull.Value)));
                                db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, Tools.isNull(dr["checker_1"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, Tools.isNull(dr["no_nota"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, tglNota)); //Tools.isNull(dr["tgl_nota"], DBNull.Value)));
                                db.Commands[0].Parameters.Add(new Parameter("@RpACCPiutang", SqlDbType.Money, Tools.isNull(dr["rp_net3"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@RpPlafonToko", SqlDbType.Money, Tools.isNull(dr["pot_rp2"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@RpPiutangTerakhir", SqlDbType.Money, Tools.isNull(dr["pot_rp3"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@RpGiroTolakTerakhir", SqlDbType.Money, Tools.isNull(dr["rp_fee1"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@RpOverdue", SqlDbType.Money, Tools.isNull(dr["rp_fee2"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, Tools.isNull(dr["no_sj"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, Tools.isNull(dr["al_kirim"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, Tools.isNull(dr["kota"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(dr["id_disc"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Decimal, Tools.isNull(dr["disc_1"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Decimal, Tools.isNull(dr["disc_2"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Decimal, Tools.isNull(dr["disc_3"], "")));
/*
//                                 db.Commands[0].Parameters.Add(new Parameter("@Plafon", SqlDbType.Money, Tools.isNull(dr["pot_rp2"], "")));
//                                 db.Commands[0].Parameters.Add(new Parameter("@SaldoPiutang", SqlDbType.Money, Tools.isNull(dr["pot_rp3"], "")));
//                                 db.Commands[0].Parameters.Add(new Parameter("@QtyTolak", SqlDbType.Int, Tools.isNull(dr["rp_fee1"], "")));
//                                 db.Commands[0].Parameters.Add(new Parameter("@Overdue", SqlDbType.Money, Tools.isNull(dr["rp_fee2"], "")));
*/
                                db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dr["laudit"].ToString().Trim().Equals("False") ? 0 : 1));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, Tools.isNull(dr["catatan1"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, Tools.isNull(dr["catatan2"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, Tools.isNull(dr["catatan3"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, Tools.isNull(dr["catatan4"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, Tools.isNull(dr["catatan5"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, Tools.isNull(dr["no_dobo"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@TglReorder", SqlDbType.DateTime, tglReoder)); //Tools.isNull(dr["tgl_reord"], DBNull.Value)));
                                db.Commands[0].Parameters.Add(new Parameter("@StatusBO", SqlDbType.Bit, dr["lbo"].ToString().Trim().Equals("False") ? 0 : 1));
                                //db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["id_link"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, Tools.isNull(dr["id_tr"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, Tools.isNull(dr["expedisi"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Shift", SqlDbType.VarChar, Tools.isNull(dr["shift"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, Tools.isNull(dr["hr_krdt"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, Tools.isNull(dr["hari_krm"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, Tools.isNull(dr["hari_sls"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, Tools.isNull(dr["nprint"], "")));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                db.Commands[0].ExecuteNonQuery();
                                pbSyncDownload.Increment(1);
                                this.refreshForm();
                            }
                        }

                        dr.Close();
                        conn.Close();
                        label1.Text = "";
                        DownloadCount();
                    }
                }
            }
            catch (Exception ex)
            {
                Exception ex1 = new Exception("Download Order Penjualan \n" + ex.Message);
                Error.LogError(ex1);
            }
        }
        /*0000
        //public void DownloadOrderPenjualan()
        //{
        //    try
        //    {
        //        string fileName = "CockpitTmp\\HHjTmp" + GlobalVar.CabangID + ".DBF";
        //        fileName = GlobalVar.DbfDownload + "\\" + fileName;
        //        label1.Text = "Download Order Penjualan";
        //        refreshForm();
        //        DataTable result = ValidateFile(fileName, HhtransjDt);

        //        if(result != null)
        //        {
        //            using (Database db = new Database())
        //            {
        //                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_OrderPenjualan"));
        //                foreach (DataRow dr in result.Rows)
        //                {

        //                    db.Commands[0].Parameters.Clear();
        //                    db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(dr["idhtr"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["cab2"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, Tools.isNull(dr["cab3"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, Tools.isNull(dr["no_rq"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, Tools.isNull(dr["tgl_rq"], DBNull.Value)));
        //                    db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, Tools.isNull(dr["no_do"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, Tools.isNull(dr["tgl_do"], DBNull.Value)));
        //                    db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, Tools.isNull(dr["checker_1"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, Tools.isNull(dr["no_nota"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, Tools.isNull(dr["tgl_nota"], DBNull.Value)));
        //                    db.Commands[0].Parameters.Add(new Parameter("@RpACCPiutang", SqlDbType.Money, Tools.isNull(dr["rp_net3"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@RpPlafonToko", SqlDbType.Money, Tools.isNull(dr["pot_rp2"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@RpPiutangTerakhir", SqlDbType.Money, Tools.isNull(dr["pot_rp3"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@RpGiroTolakTerakhir", SqlDbType.Money, Tools.isNull(dr["rp_fee1"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@RpOverdue", SqlDbType.Money, Tools.isNull(dr["rp_fee2"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, Tools.isNull(dr["no_sj"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, Tools.isNull(dr["al_kirim"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, Tools.isNull(dr["kota"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(dr["id_disc"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Decimal, Tools.isNull(dr["disc_1"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Decimal, Tools.isNull(dr["disc_2"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Decimal, Tools.isNull(dr["disc_3"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Plafon", SqlDbType.Money, Tools.isNull(dr["pot_rp2"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@SaldoPiutang", SqlDbType.Money, Tools.isNull(dr["pot_rp3"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@QtyTolak", SqlDbType.Int, Tools.isNull(dr["rp_fee1"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Overdue", SqlDbType.Money, Tools.isNull(dr["rp_fee2"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit,dr["laudit"].ToString().Trim().Equals("False") ? 0 : 1));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, Tools.isNull(dr["catatan1"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, Tools.isNull(dr["catatan2"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, Tools.isNull(dr["catatan3"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, Tools.isNull(dr["catatan4"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, Tools.isNull(dr["catatan5"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, Tools.isNull(dr["no_dobo"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@TglReorder", SqlDbType.DateTime, Tools.isNull(dr["tgl_reord"], DBNull.Value)));
        //                    db.Commands[0].Parameters.Add(new Parameter("@StatusBO", SqlDbType.Bit, dr["lbo"].ToString().Trim().Equals("False") ? 0 : 1));
        //                    //db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
        //                    db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["id_link"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, Tools.isNull(dr["id_tr"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, Tools.isNull(dr["expedisi"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@Shift", SqlDbType.VarChar, Tools.isNull(dr["shift"], "").ToString().Trim()));
        //                    db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, Tools.isNull(dr["hr_krdt"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, Tools.isNull(dr["hari_krm"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, Tools.isNull(dr["hari_sls"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, Tools.isNull(dr["nprint"], "")));
        //                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

        //                    db.Commands[0].ExecuteNonQuery();
        //                    pbSyncDownload.Increment(1);
        //                    this.refreshForm();

        //                }
        //                label1.Text = "";
        //                DownloadCount();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Exception ex1 = new Exception("Download Order Penjualan \n" + ex.Message);
        //        Error.LogError(ex1);
        //    }
        //}
        */
        public void DownloadOrderPenjualanDetail()
        {
            try
            {
                string fileName = "CockpitTmp\\DHjTmp" + GlobalVar.CabangID + ".DBF";
                fileName = GlobalVar.DbfDownload + "\\" + fileName;
                label1.Text = "Download Order Penjualan Detail";
                refreshForm();
                DataTable result = ValidateFile(fileName, DhtransjDt);
                if (result != null)
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_OrderPenjualanDetail"));
                        foreach (DataRow dr in result.Rows)
                        {

                            db.Commands[0].Parameters.Clear();
                            // * 
                            //db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(dr["idhtr"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyRequest", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_rq"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, Tools.isNull(dr["j_do"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@HrgJual", SqlDbType.Money, Tools.isNull(dr["h_jual"], "").ToString().Trim()));
                           // db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));

                            //db.Commands[0].Parameters.Add(new Parameter("@TglSuratJalan", SqlDbType.DateTime, Tools.isNull(dr["tgl_sj"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Money, double.Parse(Tools.isNull(dr["disc_1"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Money, double.Parse(Tools.isNull(dr["disc_2"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Money, double.Parse(Tools.isNull(dr["disc_3"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@Pot", SqlDbType.Money, double.Parse(Tools.isNull(dr["pot_rp"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(dr["id_disc"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, Tools.isNull(dr["no_bodo"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));


                            db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NBOPrint", SqlDbType.Int, Tools.isNull(dr["nprint"], "").ToString().Trim()));
                            //db.Commands[0].Parameters.Add(new Parameter("@DOBeliDetailID", SqlDbType.VarChar, null));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            pbSyncDownload.Increment(1);
                            this.refreshForm();

                        }
                        DownloadCount();
                    }
                }
            }
            catch (Exception ex)
            {
                Exception ex1 = new Exception("Download Order Penjualan Detail \n" + ex.Message);
                Error.LogError(ex1);
            }
        }

        public void DownloadReturPenjualan()
        {
            try
            {
                string fileName = "CockpitTmp\\HrjTmp" + GlobalVar.CabangID + ".DBF";
                fileName = GlobalVar.DbfDownload + "\\" + fileName;
                label1.Text = "Download Retur Penjualan";
                refreshForm();
                DataTable result = ValidateFile(fileName, HreturjDt);

                if (result != null)
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ReturPenjualan"));
                        foreach (DataRow dr in result.Rows)
                        {

                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["cab2"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@ReturID", SqlDbType.VarChar, Tools.isNull(dr["idretur"], "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoMPR", SqlDbType.VarChar, Tools.isNull(dr["no_memo"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoNotaRetur", SqlDbType.VarChar, Tools.isNull(dr["no_ret"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoTolak", SqlDbType.VarChar, Tools.isNull(dr["no_tolak"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglMPR", SqlDbType.DateTime, Tools.isNull(dr["tgl_memo"], DBNull.Value)));

                            db.Commands[0].Parameters.Add(new Parameter("@TglNotaRetur", SqlDbType.DateTime, Tools.isNull(dr["tgl_ret"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglTolak", SqlDbType.DateTime, Tools.isNull(dr["tgl_tolak"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@Pengambilan", SqlDbType.VarChar, Tools.isNull(dr["pngmbln"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglPengambilan", SqlDbType.DateTime, Tools.isNull(dr["tgl_pngmb"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglGudang", SqlDbType.DateTime, Tools.isNull(dr["tgl_gudang"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@BagPenjualan", SqlDbType.VarChar, Tools.isNull(dr["bag_penj"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, Tools.isNull(dr["penerima"], "").ToString().Trim()));

                            db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["dt_link"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dr["laudit"].ToString().Trim().Equals("False") ? 0 : 1));
                            db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@TglRQRetur", SqlDbType.DateTime, Tools.isNull(dr["tgl_rqret"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
                            db.Commands[0].ExecuteNonQuery();
                            pbSyncDownload.Increment(1);
                            this.refreshForm();
                        }
                        DownloadCount();
                    }
                }
            }
            catch (Exception ex)
            {
                Exception ex1 = new Exception("Download Retur Penjualan \n" + ex.Message);
                Error.LogError(ex1);
            }
        }

        public void DownloadReturPenjualanDetail()
        {
            try
            {
                string fileName = "CockpitTmp\\DrjTmp" + GlobalVar.CabangID + ".DBF";
                fileName = GlobalVar.DbfDownload + "\\" + fileName;
                label1.Text = "Download Retur Penjualan Detail";
                DataTable result = ValidateFile(fileName, DreturjDt);

                if (result != null)
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ReturPenjualanDetail"));
                        foreach (DataRow dr in result.Rows)
                        {

                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@ReturID", SqlDbType.VarChar, Tools.isNull(dr["idretur"], "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@NotaJualDetailRecID", SqlDbType.VarChar, Tools.isNull(dr["iddtr"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeRetur", SqlDbType.VarChar, Tools.isNull(dr["kdretur"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyGudang", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_gudang"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyTerima", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_terima"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyTarik", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_tarik"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyMemo", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_memo"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyTolak", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_tolak"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, Tools.isNull(dr["catatan1"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Kategori", SqlDbType.VarChar, Tools.isNull(dr["kategori"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            
                            db.Commands[0].Parameters.Add(new Parameter("@NotaAsal", SqlDbType.VarChar, Tools.isNull(dr["asalnota"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@HrgJual", SqlDbType.VarChar, double.Parse(Tools.isNull(dr["h_jual"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@Pot", SqlDbType.VarChar, double.Parse(Tools.isNull(dr["pot_rp"], "0").ToString().Trim())));
                            db.Commands[0].ExecuteNonQuery();
                            pbSyncDownload.Increment(1);
                            this.refreshForm();

                        }
                        DownloadCount();
                    }
                }
            }
            catch (Exception ex)
            {
                Exception ex1 = new Exception("Download Retur Penjualan Detail \n" + ex.Message);
                Error.LogError(ex1);
            }
        }

        public void DownloadOrderPembelian()
        {
            try
            {
                string fileName = "CockpitTmp\\HShTmp" + GlobalVar.CabangID + ".DBF";
                fileName = GlobalVar.DbfDownload + "\\" + fileName;
                label1.Text = "Download Order Pembelian";
                refreshForm();
                DataTable result = ValidateFile(fileName, HosheetDt);

                if(result != null)
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_OrderPembelian"));
                        foreach (DataRow dr in result.Rows)
                        {

                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, Tools.isNull(dr["no_rq"], "").ToString().Trim()));

                            db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, Tools.isNull(dr["tgl_rq"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@Pemasok", SqlDbType.VarChar, Tools.isNull(dr["pemasok"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, Tools.isNull(dr["c1"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["c2"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@EstHrgJual", SqlDbType.Money, double.Parse(Tools.isNull(dr["est_rpjual"], "0").ToString())));

                            db.Commands[0].Parameters.Add(new Parameter("@EstHPP", SqlDbType.Money, double.Parse(Tools.isNull(dr["est_rphpp"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.VarChar, Tools.isNull(dr["id_match"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            pbSyncDownload.Increment(1);
                            this.refreshForm();
                        }
                        DownloadCount();
                    }
                }
            }
            catch (Exception ex)
            {
                Exception ex1 = new Exception("Download Order Pembelian \n" + ex.Message);
                Error.LogError(ex1);
            }
        }

        public void DownloadOrderPembelianDetail()
        {
            try
            {
                string fileName = "CockpitTmp\\DShTmp" + GlobalVar.CabangID + ".DBF";
                fileName = GlobalVar.DbfDownload + "\\" + fileName;
                label1.Text = "Download Order Pembelian Detail";
                refreshForm();
                DataTable result = ValidateFile(fileName, DoSheetDt);

                if (result != null)
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_OrderPembelianDetail"));
                        foreach (DataRow dr in result.Rows)
                        {

                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@HeaderRecID", SqlDbType.VarChar, Tools.isNull(dr["idheader"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_do"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyBO", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_bo"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyJual", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_jual"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyAkhir", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_akhir"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyTambahan", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_plus"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["ket"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            pbSyncDownload.Increment(1);
                            this.refreshForm();
                        }
                        DownloadCount();
                    }
                }
            }
            catch (Exception ex)
            {
                Exception ex1 = new Exception("Download Order Pembelian \n" + ex.Message);
                Error.LogError(ex1);
            }
        }

        public void DownloadNotaPembelian()
        {
            string fileName = "CockpitTmp\\HtbTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Nota Pembelian";
            refreshForm();
            DataTable result = ValidateFile(fileName, HtransbDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_NotaPembelian"));
                    foreach (DataRow dr in result.Rows)
                    {

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, Tools.isNull(dr["no_rq"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, Tools.isNull(dr["tgl_rq"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, Tools.isNull(dr["no_do"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, Tools.isNull(dr["tgl_trans"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, Tools.isNull(dr["no_nota"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglNota", SqlDbType.DateTime, Tools.isNull(dr["tgl_nota"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoSuratJalan", SqlDbType.VarChar, (Tools.isNull(dr["no_sj"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSuratJalan", SqlDbType.DateTime, Tools.isNull(dr["tgl_sj"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, Tools.isNull(dr["tgl_trm"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_1"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_2"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_3"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(dr["id_disc"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, int.Parse(Tools.isNull(dr["hr_krdt"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@PPN", SqlDbType.Decimal, double.Parse(Tools.isNull(dr["ppn"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Pemasok", SqlDbType.VarChar, (Tools.isNull(dr["pemasok"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, Tools.isNull(dr["expedisi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, Tools.isNull(dr["cab"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dr["laudit"].ToString().Trim().Equals("False") ? 0 : 1));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadNotaPembelianDetail()
        {
            string fileName = "CockpitTmp\\DtbTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Nota Pembelian Detail";
            refreshForm();
            DataTable result = ValidateFile(fileName, DtransbDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_NotaPembelianDetail"));
                    foreach (DataRow dr in result.Rows)
                    {

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderRecID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyRequest", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_rq"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_do"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtySuratJalan", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_sj"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNota", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_nota"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, Tools.isNull(dr["tgl_trm"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgBeli", SqlDbType.Money, decimal.Parse(Tools.isNull(dr["h_beli"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgPokok", SqlDbType.Money, decimal.Parse(Tools.isNull(dr["h_pokok"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HPPSolo", SqlDbType.Money, decimal.Parse(Tools.isNull(dr["hpp_solo"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Pot", SqlDbType.Money, decimal.Parse(Tools.isNull(dr["pot_rp"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_1"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_2"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_3"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(dr["id_disc"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@PPN", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["ppn"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KoreksiID", SqlDbType.VarChar, Tools.isNull(dr["id_koreksi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadReturPembelian()
        {
            string fileName = "CockpitTmp\\HrbTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Retur Pembelian";
            refreshForm();
            DataTable result = ValidateFile(fileName, HreturbDt);

            if(result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ReturPembelian"));
                    foreach (DataRow dr in result.Rows)
                    {

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@ReturID", SqlDbType.VarChar, Tools.isNull(dr["idretur"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoRetur", SqlDbType.VarChar, Tools.isNull(dr["no_retur"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglRetur", SqlDbType.DateTime, Tools.isNull(dr["tgl_retur"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Pemasok", SqlDbType.VarChar, Tools.isNull(dr["pemasok"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, Tools.isNull(dr["penerima"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoMPR", SqlDbType.VarChar, Tools.isNull(dr["no_mpr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, Tools.isNull(dr["tgl_keluar"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Pengirim", SqlDbType.VarChar, Tools.isNull(dr["pengirim"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKirim", SqlDbType.DateTime, Tools.isNull(dr["tgl_kirim"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dr["laudit"].ToString().Trim().Equals("False") ? 0 : 1));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.VarChar, Tools.isNull(dr["nprint"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadReturPembelianDetail()
        {
            string fileName = "CockpitTmp\\DrbTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Retur Pembelian Detail";
            refreshForm();
            DataTable result = ValidateFile(fileName, DreturbDt);

            if(result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ReturPembelianDetail"));
                    foreach (DataRow dr in result.Rows)
                    {

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@ReturID", SqlDbType.VarChar, Tools.isNull(dr["idretur"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NotaBeliDetailRecID", SqlDbType.VarChar, Tools.isNull(dr["iddtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeRetur", SqlDbType.VarChar, Tools.isNull(dr["kdretur"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyGudang", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_gudang"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyTerima", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_terima"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgBeli", SqlDbType.Money, Double.Parse(Tools.isNull(dr["h_beli"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgNet", SqlDbType.Money, Double.Parse(Tools.isNull(dr["h_net"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgPokok", SqlDbType.Money, Double.Parse(Tools.isNull(dr["h_pokok"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HPPSolo", SqlDbType.Money, Double.Parse(Tools.isNull(dr["hpp_solo"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, Tools.isNull(dr["tgl_keluar"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadPengembalian()
        {
            string fileName = "CockpitTmp\\HkbTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Pengembalian";
            refreshForm();
            DataTable result = ValidateFile(fileName, HkembaliDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Pengembalian"));
                    foreach (DataRow dr in result.Rows)
                    {

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, Tools.isNull(dr["nobukti"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKembaliPj", SqlDbType.DateTime, Tools.isNull(dr["tgl_kmbpj"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKembaliGdg", SqlDbType.DateTime, Tools.isNull(dr["tgl_kmbgd"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["print"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.VarChar, Tools.isNull(dr["id_match"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadPengembalianDetail()
        {
            string fileName = "CockpitTmp\\DkbTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Pengembalian Detail";
            refreshForm();
            DataTable result = ValidateFile(fileName, DkembaliDt);

            if(result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_PengembalianDetail"));
                    foreach (DataRow dr in result.Rows)
                    {

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TransactionID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@IDPinjam", SqlDbType.VarChar, Tools.isNull(dr["iddpinjam"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPinjam", SqlDbType.VarChar, Tools.isNull(dr["nopjm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyKembali", SqlDbType.Int, int.Parse(Tools.isNull(dr["qty_kmb"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.VarChar, Tools.isNull(dr["id_match"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadPeminjaman()
        {
            string fileName = "CockpitTmp\\HpjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Peminjaman";
            refreshForm();
            DataTable result = ValidateFile(fileName, HpinjamDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Peminjaman"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, Tools.isNull(dr["nobukti"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, Tools.isNull(dr["tgl_kelpj"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglBatas", SqlDbType.DateTime, Tools.isNull(dr["tgl_btspj"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@StaffPenjualan", SqlDbType.VarChar, Tools.isNull(dr["penjstaff"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["print"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, (Tools.isNull(dr["kd_sales"], "").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadPeminjamanDetail()
        {
            string fileName = "CockpitTmp\\DpjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Peminjaman Detail";
            refreshForm();
            DataTable result = ValidateFile(fileName, DpinjamDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_PeminjamanDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@TransactionID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyMemo", SqlDbType.Int, int.Parse(Tools.isNull(dr["qty_kelpj"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyKeluarGudang", SqlDbType.Int, int.Parse(Tools.isNull(dr["qty_kelgd"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadRekapKoli()
        {
            string fileName = "CockpitTmp\\HxpTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Rekap Koli";
            refreshForm();
            DataTable result = ValidateFile(fileName, HxpdcDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_RekapKoli"));
                    foreach (DataRow dr in result.Rows)
                    {

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSuratJalan", SqlDbType.DateTime, Tools.isNull(dr["tgl_sj"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoSuratJalan", SqlDbType.VarChar, Tools.isNull(dr["no_sj"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, Tools.isNull(dr["tgl_klr"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeExp1", SqlDbType.VarChar, Tools.isNull(dr["nm_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeExp2", SqlDbType.VarChar, Tools.isNull(dr["kd_exp2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeExp3", SqlDbType.VarChar, Tools.isNull(dr["kd_exp3"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Shift", SqlDbType.Int, int.Parse(Tools.isNull(dr["shift"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@BiayaExp1", SqlDbType.Money, double.Parse(Tools.isNull(dr["by_exp"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@BiayaExp2", SqlDbType.Money, double.Parse(Tools.isNull(dr["by_exp2"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@BiayaExp3", SqlDbType.Money, double.Parse(Tools.isNull(dr["by_exp3"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@KP", SqlDbType.VarChar, (Tools.isNull(dr["kp"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadRekapKoliDetail()
        {
            string fileName = "CockpitTmp\\DxpTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Rekap Koli Detail";
            refreshForm();
            DataTable result = ValidateFile(fileName, DxpdcDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_RekapKoliDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NotaJualRecID", SqlDbType.VarChar, Tools.isNull(dr["idhtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, Tools.isNull(dr["no_nota"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TunaiKredit", SqlDbType.VarChar, Tools.isNull(dr["tk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(Tools.isNull(dr["nominal"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, (Tools.isNull(dr["ket"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoResi", SqlDbType.VarChar, Tools.isNull(dr["no_resi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadRekapKoliSubDetail()
        {
            string fileName = "CockpitTmp\\CxpTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Rekap Koli Sub Detail";
            refreshForm();
            DataTable result = ValidateFile(fileName, CxpdcDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_RekapKoliSubDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Jumlah", SqlDbType.Int, int.Parse(Tools.isNull(dr["jumlah"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Satuan", SqlDbType.VarChar, Tools.isNull(dr["satuan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, (Tools.isNull(dr["ket"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadMutasi()
        {
            string fileName = "CockpitTmp\\HmtTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Mutasi";
            refreshForm();
            DataTable result = ValidateFile(fileName, HmutstokDt);

            if(result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Mutasi"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@MutasiID", SqlDbType.VarChar, Tools.isNull(dr["id_mts"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglMutasi", SqlDbType.DateTime, Tools.isNull(dr["tgl_mts"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NomorMutasi", SqlDbType.VarChar, (Tools.isNull(dr["no_mts"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@KeteranganMutasi", SqlDbType.VarChar, Tools.isNull(dr["ket_mts"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LAudit", SqlDbType.Bit, (Tools.isNull(dr["laudit"], "").ToString().Trim() == "False" ? 0 : 1)));
                        db.Commands[0].Parameters.Add(new Parameter("@TipeMutasi", SqlDbType.VarChar, (Tools.isNull(dr["type"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadMutasiDetail()
        {
            string fileName = "CockpitTmp\\DmtTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Mutasi Detail";
            refreshForm();
            DataTable result = ValidateFile(fileName, DmutstokDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_MutasiDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@MutasiID", SqlDbType.VarChar, Tools.isNull(dr["id_mts"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyMutasi", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_mts"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim() == "False" ? 0 : 1));
                        db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadAntarGudang()
        {
            string fileName = "CockpitTmp\\HAGTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Antar Gudang";
            refreshForm();
            DataTable result = ValidateFile(fileName, HkrmagudDt);

            if(result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_AntarGudang"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idhkrmagud"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@DrGudang", SqlDbType.VarChar, Tools.isNull(dr["dr_gud"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KeGudang", SqlDbType.VarChar, Tools.isNull(dr["ke_gud"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKirim", SqlDbType.DateTime, Tools.isNull(dr["tgl_krm"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, Tools.isNull(dr["tgl_trm"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoAG", SqlDbType.VarChar, (Tools.isNull(dr["no_ag"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Pengirim", SqlDbType.VarChar, (Tools.isNull(dr["pengirim"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, (Tools.isNull(dr["penerima"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@DrCheck1", SqlDbType.VarChar, Tools.isNull(dr["drcheck1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@DrCheck2", SqlDbType.VarChar, Tools.isNull(dr["drcheck2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KeCheck1", SqlDbType.VarChar, Tools.isNull(dr["kecheck1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KeCheck2", SqlDbType.VarChar, Tools.isNull(dr["kecheck2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@expedisi", SqlDbType.VarChar, (Tools.isNull(dr["exp"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoKendaraan", SqlDbType.VarChar, (Tools.isNull(dr["no_kend"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaSopir", SqlDbType.VarChar, (Tools.isNull(dr["nm_sopir"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@KirimTerimaID", SqlDbType.VarChar, Tools.isNull(dr["id_krmtrm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadAntarGudangDetail()
        {
            string fileName = "CockpitTmp\\DAGTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Rekap Antar Gudang Detail";
            refreshForm();
            DataTable result = ValidateFile(fileName, DkrmagudDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_AntarGudangDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["iddkrmagud"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TransactionID", SqlDbType.VarChar, Tools.isNull(dr["idhkrmagud"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyKirim", SqlDbType.Int, int.Parse(Tools.isNull(dr["qty_krm"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyTerima", SqlDbType.Int, int.Parse(Tools.isNull(dr["qty_trm"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Ongkos", SqlDbType.Int, int.Parse(Tools.isNull(dr["ongkos"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, int.Parse(Tools.isNull(dr["qty_do"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadPenjualanPotongan()
        {
            string fileName = "CockpitTmp\\HptTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Penjualan Potongan";
            refreshForm();
            DataTable result = ValidateFile(fileName, HpotJDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_PenjualanPotongan"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@TrID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@PotID", SqlDbType.VarChar, Tools.isNull(dr["Idpot"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPot", SqlDbType.VarChar, (Tools.isNull(dr["Nopot"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@TglPot", SqlDbType.DateTime, Tools.isNull(dr["Tgl_pot"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Dil", SqlDbType.Money, double.Parse(Tools.isNull(dr["Dil"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc", SqlDbType.Decimal, Decimal.Parse(Tools.isNull(dr["Disc"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@RpNet", SqlDbType.Money, double.Parse(Tools.isNull(dr["Rp_net"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["Catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglACC", SqlDbType.DateTime, Tools.isNull(dr["Tgl_acc"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@DilACC", SqlDbType.Money, double.Parse(Tools.isNull(dr["Dil_acc"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@CatACC", SqlDbType.VarChar, Tools.isNull(dr["Cat_acc"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@DiscACC", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["Disc_acc"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@IdLink", SqlDbType.VarChar, (Tools.isNull(dr["id_link"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusACC", SqlDbType.Bit, dr["acc"].Equals("1") ? 1 : 0));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadSales()
        {
            string fileName = "CockpitTmp\\SlsTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Sales";
            refreshForm();
            DataTable result = ValidateFile(fileName, SalesDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Sales"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaSales", SqlDbType.VarChar, Tools.isNull(dr["nm_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.DateTime, Tools.isNull(dr["tgl_lahir"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, Tools.isNull(dr["alamat"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Target", SqlDbType.Decimal, Decimal.Parse(Tools.isNull(dr["target"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@BatasOD", SqlDbType.Decimal, Decimal.Parse(Tools.isNull(dr["batas_od"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@TglMasuk", SqlDbType.DateTime, Tools.isNull(dr["tgl_masuk"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, Tools.isNull(dr["tgl_keluar"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadToko()
        {
            string fileName = "CockpitTmp\\TokTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Toko";
            refreshForm();
            DataTable result = ValidateFile(fileName, TokoDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Toko"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@TokoID", SqlDbType.VarChar, Tools.isNull(dr["idtoko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, Tools.isNull(dr["namatoko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, Tools.isNull(dr["alamat"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, (Tools.isNull(dr["kota"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Telp", SqlDbType.VarChar, (Tools.isNull(dr["notelp"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, (Tools.isNull(dr["idwil"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@PenanggungJawab", SqlDbType.VarChar, Tools.isNull(dr["pngjwb"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@PiutangB", SqlDbType.Money, double.Parse(Tools.isNull(dr["piutang_b"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@PiutangJ", SqlDbType.Money, double.Parse(Tools.isNull(dr["piutang_j"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Plafon", SqlDbType.Money, double.Parse(Tools.isNull(dr["plafon"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@ToJual", SqlDbType.Money, double.Parse(Tools.isNull(dr["to_jual"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@ToRetPot", SqlDbType.Money, double.Parse(Tools.isNull(dr["to_retpot"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@JangkaWaktuKredit", SqlDbType.Int, int.Parse(Tools.isNull(dr["jkw_kredit"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["cab2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Tgl1st", SqlDbType.DateTime, Tools.isNull(dr["tgl1st"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Exist", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["exist"], "false").ToString().Trim())));


                        db.Commands[0].Parameters.Add(new Parameter("@ClassID", SqlDbType.VarChar, Tools.isNull(dr["idclass"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_krm"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KodePos", SqlDbType.VarChar, Tools.isNull(dr["kd_pos"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Grade", SqlDbType.VarChar, Tools.isNull(dr["Grade"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Plafon1st", SqlDbType.Money, double.Parse(Tools.isNull(dr["plafon_1st"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Flag", SqlDbType.VarChar, (Tools.isNull(dr["flag"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Bentrok", SqlDbType.VarChar, (Tools.isNull(dr["bentrok"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["lpasif"], "false").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_sls"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Daerah", SqlDbType.VarChar, Tools.isNull(dr["daerah"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Propinsi", SqlDbType.VarChar, Tools.isNull(dr["propinsi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@AlamatRumah", SqlDbType.VarChar, Tools.isNull(dr["alm_rumah"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Pengelola", SqlDbType.VarChar, Tools.isNull(dr["pengelola"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.DateTime, Tools.isNull(dr["tgl_lahir"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@HP", SqlDbType.VarChar, Tools.isNull(dr["hp"], "").ToString().Trim()));

                        db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, Tools.isNull(dr["status"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@ThnBerdiri", SqlDbType.VarChar, Tools.isNull(dr["th_berdiri"], "").ToString().Trim()));

                        db.Commands[0].Parameters.Add(new Parameter("@StatusRuko", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["lruko"], "false").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@JmlCabang", SqlDbType.Int, int.Parse(Tools.isNull(dr["jml_cabang"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@JmlSales", SqlDbType.Int, int.Parse(Tools.isNull(dr["jml_sales"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Kinerja", SqlDbType.VarChar, Tools.isNull(dr["kinerja"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BidangUsaha", SqlDbType.VarChar, Tools.isNull(dr["pengelola"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RefSales", SqlDbType.VarChar, Tools.isNull(dr["reff_sls"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RefCollector", SqlDbType.VarChar, Tools.isNull(dr["reff_col"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RefSupervisor", SqlDbType.VarChar, Tools.isNull(dr["reff_spv"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@PlafonSurvey", SqlDbType.Money, double.Parse(Tools.isNull(dr["plf_survey"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadStatusToko()
        {
            string fileName = "CockpitTmp\\StoTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Status Toko";
            refreshForm();
            DataTable result = ValidateFile(fileName, StsTokoDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_StatusToko"));
                    foreach (DataRow dr in result.Rows)
                    {

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, Tools.isNull(dr["c1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.DateTime, Tools.isNull(dr["tmt"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, (Tools.isNull(dr["sts"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, (Tools.isNull(dr["idrec"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, (Tools.isNull(dr["ket"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KStatus", SqlDbType.VarChar, Tools.isNull(dr["ksts"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Roda", SqlDbType.VarChar, Tools.isNull(dr["rd"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, Tools.isNull(dr["idwil"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglPasif", SqlDbType.DateTime, Tools.isNull(dr["tmt_pasif"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                        pbSyncDownload.Increment(1);
                        refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadStok()
        {
            string fileName = "CockpitTmp\\StkTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Stok";
            refreshForm();
            DataTable result = ValidateFile(fileName, SasStokDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Stok"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Bundle", SqlDbType.VarChar, Tools.isNull(dr["bundel"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaStok", SqlDbType.VarChar, Tools.isNull(dr["nama_stok"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSolo", SqlDbType.VarChar, Tools.isNull(dr["kodesolo"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kendaraan", SqlDbType.VarChar, Tools.isNull(dr["kendaraan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaTertera", SqlDbType.VarChar, Tools.isNull(dr["nm_tertera"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@PartNo", SqlDbType.VarChar, Tools.isNull(dr["partno"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Merek", SqlDbType.VarChar, Tools.isNull(dr["merek"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Dibungkus", SqlDbType.VarChar, Tools.isNull(dr["dibungkus"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SumberDr", SqlDbType.VarChar, Tools.isNull(dr["sumber_dr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@ProsesID", SqlDbType.VarChar, Tools.isNull(dr["idproses"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SatSolo", SqlDbType.VarChar, Tools.isNull(dr["sat_solo"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Material", SqlDbType.VarChar, Tools.isNull(dr["material"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SatJual", SqlDbType.VarChar, Tools.isNull(dr["sat_jual"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeRak", SqlDbType.VarChar, Tools.isNull(dr["kd_rak"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeRak1", SqlDbType.VarChar, Tools.isNull(dr["kd_rak1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeRak2", SqlDbType.VarChar, Tools.isNull(dr["kd_rak2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@JB", SqlDbType.VarChar, Tools.isNull(dr["jb"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusPasif", SqlDbType.Bit, dr["lpasif"].ToString().Trim().Equals("False") ? 0 : 1));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@PrediksiLamaKirim", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_ordb"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HariRataRata", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_opnm"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@StokMin", SqlDbType.Int, int.Parse(Tools.isNull(dr["stokmin"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@StokMax", SqlDbType.Int, int.Parse(Tools.isNull(dr["stokmax"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@IsiKoli", SqlDbType.Int, int.Parse(Tools.isNull(dr["isi_koli"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));

                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadPemasok()
        {
            string fileName = "CockpitTmp\\PmsTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Pemasok";
            refreshForm();
            DataTable result = ValidateFile(fileName, PemasokDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Pemasok"));
                    foreach (DataRow dr in result.Rows)
                    {

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@PemasokID", SqlDbType.VarChar, Tools.isNull(dr["idp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, Tools.isNull(dr["nama"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Lengkap", SqlDbType.VarChar, Tools.isNull(dr["lengkap"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, Tools.isNull(dr["alamat"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, Tools.isNull(dr["kota"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Telp", SqlDbType.VarChar, Tools.isNull(dr["telp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Fax", SqlDbType.VarChar, (Tools.isNull(dr["fax"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Kontak", SqlDbType.VarChar, (Tools.isNull(dr["kontak"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, (Tools.isNull(dr["keterangan"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadExpedisi()
        {
            string fileName = "CockpitTmp\\ExpTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Expedisi";
            refreshForm();
            DataTable result = ValidateFile(fileName, ExpedisiDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Expedisi"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@KodeExpedisi", SqlDbType.VarChar, Tools.isNull(dr["kode"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaExpedisi", SqlDbType.VarChar, Tools.isNull(dr["nm_exp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, Tools.isNull(dr["alamat"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Telp", SqlDbType.VarChar, Tools.isNull(dr["telepon"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KotaTujuan", SqlDbType.VarChar, Tools.isNull(dr["kota_tj"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadKompensasi()
        {
            string fileName = "CockpitTmp\\KmpTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Kompensasi";
            refreshForm();
            DataTable result = ValidateFile(fileName, KompensasiDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Expedisi"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@DiscKompensasi", SqlDbType.Decimal, Tools.isNull(dr["disc_komp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadOpname()
        {
            string fileName = "CockpitTmp\\SopTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Opname";
            refreshForm();
            DataTable result = ValidateFile(fileName, OpnameDt);
            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Opname"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, Tools.isNull(dr["tgl_opnm"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyOpname", SqlDbType.Int, int.Parse(Tools.isNull(dr["qty_opnm"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["ket_opnm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], 0).ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadSelisih()
        {
            string fileName = "CockpitTmp\\HslTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Selisih";
            refreshForm();
            DataTable result = ValidateFile(fileName, SelisihDt);
            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Selisih"));
                    foreach (DataRow dr in result.Rows)
                    {

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idhselisih"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSelisih", SqlDbType.DateTime, Tools.isNull(dr["tgl"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoSelisih", SqlDbType.VarChar, Tools.isNull(dr["no_slsh"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, Tools.isNull(dr["cab"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["ket"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Pemeriksa1", SqlDbType.VarChar, Tools.isNull(dr["pmrks1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Pemeriksa2", SqlDbType.VarChar, Tools.isNull(dr["pmrks2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        //db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadSelisihDetail()
        {
            string fileName = "CockpitTmp\\DslTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Selisih Detail";
            refreshForm();
            DataTable result = ValidateFile(fileName, DSelisihDt);

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_SelisihDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TransactionID", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, Tools.isNull(dr["tgl"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyComp", SqlDbType.Int, int.Parse(Tools.isNull(dr["no_slsh"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyOpname", SqlDbType.Int, int.Parse(Tools.isNull(dr["cab"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["ket"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadNotaPenjualan()
        {
            string fileName = "CockpitTmp\\HtjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Nota Penjualan";
            refreshForm();
            DataTable result = ValidateFile(fileName, HtransjDt);
            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_NotaPenjualan"));
                    //DateTime tglTerima;
                    foreach (DataRow dr in result.Rows)
                    {

                        //if (Tools.isNull(dr["tgl_trm"], "").ToString().Trim() != "12/30/1899 12:00:00 AM")
                        //{
                        //    tglTerima = DateTime.Parse(Tools.isNull(dr["tgl_trm"], "").ToString().Trim());
                        //}
                        //else
                        //{
                        //    tglTerima = null;
                        //}
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(dr["idhtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, Tools.isNull(dr["no_nota"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglNota", SqlDbType.DateTime, Tools.isNull(dr["tgl_nota"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoSuratJalan", SqlDbType.VarChar, (Tools.isNull(dr["no_sj"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSuratJalan", SqlDbType.DateTime, Tools.isNull(dr["tgl_sj"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, Tools.isNull(dr["tgl_trm"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSerahTerimaChecker", SqlDbType.DateTime, Tools.isNull(dr["tgl_strm"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglExpedisi", SqlDbType.DateTime, Tools.isNull(dr["tgl_do"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, Tools.isNull(dr["al_kirim"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, Tools.isNull(dr["kota"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dr["laudit"].ToString().Trim().Equals("False") ? 0 : 1));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, Tools.isNull(dr["catatan1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, Tools.isNull(dr["catatan2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, Tools.isNull(dr["catatan3"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, Tools.isNull(dr["catatan4"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, Tools.isNull(dr["catatan5"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["id_link"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, (Tools.isNull(dr["id_tr"], "").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, int.Parse(Tools.isNull(dr["hr_krdt"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Checker1", SqlDbType.VarChar, Tools.isNull(dr["checker_1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Checker2", SqlDbType.VarChar, Tools.isNull(dr["checker_2"], "").ToString().Trim()));
                        /*Tamabahan*/
                        db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_krm"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_sls"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["cab2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, Tools.isNull(dr["cab3"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                        /**/
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadNotaPenjualanDetail()
        {
            string fileName = "CockpitTmp\\DtjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Nota Penjualan Detail";
            refreshForm();
            DataTable result = ValidateFile(fileName, DtransjDt);
            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_NotaPenjualanDetail"));
                    foreach (DataRow dr in result.Rows)
                    {

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@QtySuratJalan", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_sj"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNota", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_nota"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyKoli", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_koli"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KoliAwal", SqlDbType.Int, int.Parse(Tools.isNull(dr["koli_awal"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KoliAkhir", SqlDbType.Int, int.Parse(Tools.isNull(dr["koli_akhir"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoKoli", SqlDbType.VarChar, Tools.isNull(dr["no_koli"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KetKoli", SqlDbType.VarChar, Tools.isNull(dr["ket_koli"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NPackingListPrint", SqlDbType.VarChar, Tools.isNull(dr["nprint"], "").ToString().Trim()));
                        /*Tambahan*/
                        db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgJual", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_jual"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Money, double.Parse(Tools.isNull(dr["disc_1"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Money, double.Parse(Tools.isNull(dr["disc_2"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Money, double.Parse(Tools.isNull(dr["disc_3"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Pot", SqlDbType.Money, double.Parse(Tools.isNull(dr["pot_rp"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(dr["id_disc"], "").ToString().Trim()));
                        /**/
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadKoreksiPembelian()
        {
            string fileName = "CockpitTmp\\KorTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Koreksi Pembelian";
            refreshForm();
            DataTable result = ValidateFile(fileName, KoreksiPembelianDt);
            DataRow[] results = result.Select("sumber='NPB'");
            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_KoreksiPembelian"));
                    foreach (DataRow dr in results)
                    {

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["id_koreksi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NotaBeliDetailRecID", SqlDbType.VarChar, Tools.isNull(dr["id_detail"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKoreksi", SqlDbType.DateTime, Tools.isNull(dr["tglkoreksi"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoKoreksi", SqlDbType.VarChar, (Tools.isNull(dr["no_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, (Tools.isNull(dr["id_brg"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNotaBaru", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_nota"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgBeliBaru", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_jual"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Pemasok", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Sumber", SqlDbType.VarChar, Tools.isNull(dr["sumber"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["dt_link"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgBeliKoreksi", SqlDbType.Money, (Tools.isNull(dr["h_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNotaKoreksi", SqlDbType.Int, (Tools.isNull(dr["n_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadKoreksiPenjualan()
        {
            string fileName = "CockpitTmp\\KorTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Koreksi Penjualan";
            refreshForm();
            DataTable result = ValidateFile(fileName, KoreksiPenjualanDt);
            DataRow[] results = result.Select("sumber='NPJ'");
            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_KoreksiPenjualan"));
                    foreach (DataRow dr in results)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["id_koreksi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKoreksi", SqlDbType.DateTime, Tools.isNull(dr["tglkoreksi"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NotaJualDetailRecID", SqlDbType.VarChar, (Tools.isNull(dr["id_detail"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoKoreksi", SqlDbType.VarChar, (Tools.isNull(dr["no_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, (Tools.isNull(dr["id_brg"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNotaBaru", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_nota"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgJualBaru", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_jual"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Sumber", SqlDbType.VarChar, Tools.isNull(dr["sumber"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["dt_link"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgJualKoreksi", SqlDbType.Money, (Tools.isNull(dr["h_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNotaKoreksi", SqlDbType.Int, (Tools.isNull(dr["n_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadKoreksiReturPembelian()
        {
            string fileName = "CockpitTmp\\KorTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Koreksi Retur Pembelian";
            refreshForm();
            DataTable result = ValidateFile(fileName, KoreksiReturPembelianDt);
            DataRow[] results = result.Select("sumber='NRB'");
            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_KoreksiReturPembelian"));
                    foreach (DataRow dr in results)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["id_koreksi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@ReturBeliDetailRecID", SqlDbType.VarChar, (Tools.isNull(dr["id_detail"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKoreksi", SqlDbType.DateTime, Tools.isNull(dr["tglkoreksi"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoKoreksi", SqlDbType.VarChar, (Tools.isNull(dr["no_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, (Tools.isNull(dr["id_brg"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNotaBaru", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_nota"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgBeliBaru", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_jual"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Pemasok", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Sumber", SqlDbType.VarChar, Tools.isNull(dr["sumber"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["dt_link"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgBeliKoreksi", SqlDbType.Money, (Tools.isNull(dr["h_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNotaKoreksi", SqlDbType.Int, (Tools.isNull(dr["n_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        public void DownloadKoreksiReturPenjualan()
        {
            string fileName = "CockpitTmp\\KorTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            label1.Text = "Download Retur Penjualan";
            refreshForm();
            DataTable result = ValidateFile(fileName, KoreksiReturPenjualanDt);
            DataRow[] results = result.Select("sumber='NRJ'");
            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_KoreksiReturPenjualan"));
                    foreach (DataRow dr in results)
                    {

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["id_koreksi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKoreksi", SqlDbType.DateTime, Tools.isNull(dr["tglkoreksi"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@ReturJualDetailRecID", SqlDbType.VarChar, (Tools.isNull(dr["id_detail"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoKoreksi", SqlDbType.VarChar, (Tools.isNull(dr["no_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, (Tools.isNull(dr["id_brg"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNotaBaru", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_nota"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgJualBaru", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_jual"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        //db.Commands[0].Parameters.Add(new Parameter("@Pemasok", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Sumber", SqlDbType.VarChar, Tools.isNull(dr["sumber"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["dt_link"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgJualKoreksi", SqlDbType.Money, (Tools.isNull(dr["h_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNotaKoreksi", SqlDbType.Int, (Tools.isNull(dr["n_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbSyncDownload.Increment(1);
                        this.refreshForm();
                    }
                    DownloadCount();
                }
            }
        }

        private void TableDelete(string fileName, string tableName, string isaColName, string foxproColName)
        {
            DataTable dt = Foxpro.ReadDeletedFile(fileName);
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DELETE_TABLE"));
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

        private void TableDeleteKor(string fileName, string isaColName, string foxproColName)
        {
            string tableName = "";
            DataTable dt = Foxpro.ReadDeletedFile(fileName);
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DELETE_TABLE"));
                foreach (DataRow dr in dt.Rows)
                {
                    if (Tools.isNull(dr["Sumber"], "").ToString().Trim() == "NPJ")
                        tableName = "KoreksiPenjualan";
                    if (Tools.isNull(dr["Sumber"], "").ToString().Trim() == "NRJ")
                        tableName = "KoreksiReturPenjualan";
                    if (Tools.isNull(dr["Sumber"], "").ToString().Trim() == "NPB")
                        tableName = "KoreksiPembelian";
                    if (Tools.isNull(dr["Sumber"], "").ToString().Trim() == "NRB")
                        tableName = "KoreksiReturPembelian";

                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, tableName));
                    db.Commands[0].Parameters.Add(new Parameter("@columnKeyName", SqlDbType.VarChar, isaColName));
                    db.Commands[0].Parameters.Add(new Parameter("@columnKeyValue", SqlDbType.VarChar, Tools.isNull(dr[foxproColName], "").ToString().Trim()));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
        }

        private void TableDeleteReturBeliDetail(string fileName, string isaColName, string foxproColName)
        {
            string tableName = "";
            DataTable dt = Foxpro.ReadDeletedFile(fileName);
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DELETE_TABLE"));
                foreach (DataRow dr in dt.Rows)
                {
                    if (Tools.isNull(dr["kdretur"], "").ToString().Trim() == "1")
                        tableName = "ReturPembelianDetail";
                    else
                        tableName = "ReturPembelianManualDetail";

                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, tableName));
                    db.Commands[0].Parameters.Add(new Parameter("@columnKeyName", SqlDbType.VarChar, isaColName));
                    db.Commands[0].Parameters.Add(new Parameter("@columnKeyValue", SqlDbType.VarChar, Tools.isNull(dr[foxproColName], "").ToString().Trim()));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
        }

        private void TableDeleteReturJualDetail(string fileName, string isaColName, string foxproColName)
        {
            string tableName = "";
            DataTable dt = Foxpro.ReadDeletedFile(fileName);
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DELETE_TABLE"));
                foreach (DataRow dr in dt.Rows)
                {
                    if (Tools.isNull(dr["kdretur"], "").ToString().Trim() == "1")
                        tableName = "ReturPenjualanDetail";
                    else
                        tableName = "ReturPenjualanTarikanDetail";

                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, tableName));
                    db.Commands[0].Parameters.Add(new Parameter("@columnKeyName", SqlDbType.VarChar, isaColName));
                    db.Commands[0].Parameters.Add(new Parameter("@columnKeyValue", SqlDbType.VarChar, Tools.isNull(dr[foxproColName], "").ToString().Trim()));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
        }

        private void ExecDelete()
        {
            string depan = GlobalVar.DbfDownload + "\\CockpitTmp\\";
            string belakang = "Tmp" + GlobalVar.CabangID + ".DBF";
            string fileName;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                fileName = depan + "Cxp" + belakang; TableDelete(fileName, "RekapKoliSubDetail", "RecordID", "idtr");
                fileName = depan + "Dxp" + belakang; TableDelete(fileName, "RekapKoliDetail", "RecordID", "idrec");
                fileName = depan + "Hxp" + belakang; TableDelete(fileName, "RekapKoli", "RecordID", "idtr");
                fileName = depan + "DAG" + belakang; TableDelete(fileName, "AntarGudangDetail", "RecordID", "iddkrmagud");
                fileName = depan + "HAG" + belakang; TableDelete(fileName, "AntarGudang", "RecordID", "idhkrmagud");
                fileName = depan + "Hpt" + belakang; TableDelete(fileName, "PenjualanPotongan", "PotID", "idpot");
                fileName = depan + "Dkb" + belakang; TableDelete(fileName, "PengembalianDetail", "RecordID", "idrec");
                fileName = depan + "Hkb" + belakang; TableDelete(fileName, "Pengembalian", "RecordID", "idtr");
                fileName = depan + "Dpj" + belakang; TableDelete(fileName, "PeminjamanDetail", "RecordID", "idrec");
                fileName = depan + "Hpj" + belakang; TableDelete(fileName, "Peminjaman", "RecordID", "idtr");
                fileName = depan + "Dmt" + belakang; TableDelete(fileName, "MutasiDetail", "RecordID", "idrec");
                fileName = depan + "Hmt" + belakang; TableDelete(fileName, "Mutasi", "MutasiID", "id_mts");
                fileName = depan + "Sls" + belakang; TableDelete(fileName, "Sales", "SalesID", "kd_sales");
                fileName = depan + "Sto" + belakang; TableDelete(fileName, "Stok", "BarangID", "id_brg");
                fileName = depan + "Tok" + belakang; TableDelete(fileName, "Toko", "KodeToko", "kd_toko");
                fileName = depan + "Pms" + belakang; TableDelete(fileName, "Pemasok", "PemasokID", "idp");
                fileName = depan + "Exp" + belakang; TableDelete(fileName, "Expedisi", "KodeExpedisi", "kode");
                fileName = depan + "Kor" + belakang; TableDeleteKor(fileName, "RecordID", "id_koreksi");
                fileName = depan + "Drb" + belakang; TableDeleteReturBeliDetail(fileName, "RecordID", "idrec");
                fileName = depan + "Hrb" + belakang; TableDelete(fileName, "ReturPembelian", "ReturID", "idretur");
                fileName = depan + "Dtb" + belakang; TableDelete(fileName, "NotaPembelianDetail", "RecordID", "idrec");
                fileName = depan + "Htb" + belakang; TableDelete(fileName, "NotaPembelian", "RecordID", "idtr");
                fileName = depan + "Dsh" + belakang; TableDelete(fileName, "OrderPembelianDetail", "RecordID", "idrec");
                fileName = depan + "Hsh" + belakang; TableDelete(fileName, "OrderPembelian", "RecordID", "idrec");
                fileName = depan + "Drj" + belakang; TableDeleteReturJualDetail(fileName, "RecordID", "idrec");
                fileName = depan + "Hrj" + belakang; TableDelete(fileName, "ReturPenjualan", "ReturID", "idretur");
                fileName = depan + "Dtj" + belakang; TableDelete(fileName, "NotaPenjualanDetail", "RecordID", "idrec");
                fileName = depan + "Htj" + belakang; TableDelete(fileName, "NotaPenjualan", "RecordID", "idtr");
                fileName = depan + "DHj" + belakang; TableDelete(fileName, "OrderPenjualanDetail", "RecordID", "idrec");
                fileName = depan + "HHj" + belakang; TableDelete(fileName, "OrderPenjualan", "HtrID", "idhtr");
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
            {
                MessageBox.Show("File: " + fileName + " tidak ditemukan !");
                table = null;
            }
            return table;
        }

        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
            lblCount.Text = pbSyncDownload.Value.ToString("#,##0") + "/" + pbSyncDownload.Maximum.ToString("#,##0"); 
        }
    }
}
