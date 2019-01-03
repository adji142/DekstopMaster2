using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using ISA.Trading.Class;
using System.Data.OleDb;
using System.Data.SqlTypes;

namespace ISA.Trading.Communicator
{
    public partial class frmPOSDownload : ISA.Trading.BaseForm
    {
        string fileZIPName = string.Empty;
        int ctr = 0;
        protected DataTable
        CxpdcDt,
        DxpdcDt,
        DtransjDt,
        DhtransjDt,
        DkrmagudDt,
        HtransjDt,
        HhtransjDt,
        HreturjDt,
        HosheetDt,
        DosheetDt,
        HtransbDt,
        HreturbDt,
        DrjtmpDt,
        HpinjamDt,
        DpinjamDt,
        HkembaliDt,
        HxpdcDt,
        HmutstokDt,
        DmutstokDt,
        OpnameDt,
        KompensasiDt,
        StokopnmDt,
        DreturbDt,
        ExpedisiDt,
        SalesDt,
        TokoDt,
        SasStokDt,
        HkrmagudDt,
        HpotJDt,
        PemasokDt,
        KoreksiPembelianDt,
        KoreksiPenjualanDt,
        KoreksiReturPembelianDt,
        KoreksiReturPenjualanDt,
        NotaPembelianDetail;

        private void frmPOSDownload_Load(object sender, EventArgs e)
        {
            
        }
        public frmPOSDownload()
        {
            InitializeComponent();
        }

        public void RefreshStatus(string status)
        {
            LabelStatus.Text = status;
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }

        private void cmdStartUpload_Click(object sender, EventArgs e)
        {
            fileZIPName = "dbfmatch.zip";
            if (MessageBox.Show(Messages.Question.AskDownload, "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;
                try
                {
                    fileZIPName = GlobalVar.DbfDownload + "\\" + fileZIPName;
                    UnzipFile();
                    SalesDownload_Load();
                    TokoDownload_Load();
                    StokDownload_Load();
                    PemasokDownload_Load();
                    ExpedisiDownload_Load();
                    KompensasiDownload_Load();
                    OpnameDownload_Load();

                    OrderPenjualanDownload_Load();
                    OrderPenjualanDetailDownload_Load();
                    NotaPenjualanDownload_Load();
                    NotaPenjualanDetailDownload_Load();
                    ReturPenjualanDownload_Load();
                    ReturPenjualanDetailDownload_Load();
                    KoreksiPenjualanDownload_Load();
                    KoreksiReturPenjualanDownload_Load();
                    PenjualanPotonganDownload_Load();
                    RekapKoliDownload_Load();
                    RekapKoliDetailDownload_Load();
                    RekapKoliSubDetailDownload_Load();

                    OrderPembelianDownload_Load();
                    OrderPembelianDetailDownload_Load();

                    NotaPembelianDownload_Load();
                    NotaPembelianDetailDownload_Load();
                    ReturPembelianDownload_Load();
                    ReturPembelianDetailDownload_Load();
                    KoreksiPembelianDownload_Load();
                    KoreksiReturPembelianDownload_Load();
                    PeminjamanDownload_Load();
                    PeminjamanDetailDownload_Load();
                    PengembalianDownload_Load();

                    MutasiDownload_Load();
                    MutasiDetailDownload_Load();
                    //////////////////////////////////////////////////////////////////////////
                    // Di komentari biar tidak bentrok dengan Download AG
                    AntargudangDownload_Load();
                    AntargudangDetailDownload_Load();	
                    //////////////////////////////////////////////////////////////////////////

	
                 
                    ExecDelete();

                    if (Directory.Exists(GlobalVar.DbfDownload + "\\PosDownloadtmp"))
                    {
                        string[] files = Directory.GetFiles(GlobalVar.DbfDownload + "\\PosDownloadtmp");

                        foreach (string file in files)
                        {
                            File.Delete(file);
                        }
                    }

                    MessageBox.Show("POS Download Selesai");
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Enabled = true;
                    this.Cursor = Cursors.Default;
                    LabelStatus.Text = "";
                }
            }
        }
        #region Load Database File Physic
        private void OrderPenjualanDownload_Load()
        {
            // string fileName = "PosDownloadtmp\\HHtransj.DBF";
            string fileName = "PosDownloadtmp\\Hhjtmp" + GlobalVar.CabangID + ".DBF";
            RefreshStatus("Downloading Order Penjualan..");
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            
            if (File.Exists(fileName))
            {
                try
                {  
                    DownloadOrderPenjualan();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download HPP rata-rata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void OrderPenjualanDetailDownload_Load()
        {
            string fileName = "PosDownloadtmp\\DHjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Order Penjualan Detail..");
            if (File.Exists(fileName))
            {
                try
                {
                    DhtransjDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = DhtransjDt.Rows.Count;
                    DownloadOrderPenjualanDetail();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    DhtransjDt.Dispose();
                }
                DhtransjDt.Dispose();
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Order Penjualan Detail", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void NotaPenjualanDownload_Load()
        {
            string fileName = "PosDownloadtmp\\Htjtmp" + GlobalVar.CabangID + ".DBF";
            RefreshStatus("Downloading Nota Penjualan..");
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            
            if (File.Exists(fileName))
            {
                try
                {
                    HtransjDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = HtransjDt.Rows.Count;
                    DownloadNotaPenjualan();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    HtransjDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download HPP rata-rata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void NotaPenjualanDetailDownload_Load()
        {
            string fileName = "PosDownloadtmp\\DtjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Nota Penjualan Detail..");
            if (File.Exists(fileName))
            {
                try
                {
                    DtransjDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = DtransjDt.Rows.Count;
                    DownloadNotaPenjualanDetail();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    DtransjDt.Dispose();
                }
                DtransjDt.Dispose();
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Order Penjualan Detail", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void ReturPenjualanDownload_Load()
        {
            string fileName = "PosDownloadtmp\\HrjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Retur Penjualan..");
          
            if (File.Exists(fileName))
            {
                try
                {
                    HreturjDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = HreturjDt.Rows.Count;
                    DownloadReturPenjualan();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    HreturjDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Retur Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void ReturPenjualanDetailDownload_Load()
        {
            string fileName = "PosDownloadtmp\\Drjtmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Retur Penjualan Detail..");

            if (File.Exists(fileName))
            {
                try
                {
                    DrjtmpDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = DrjtmpDt.Rows.Count;
                    DownloadReturPenjualanDetail();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    DrjtmpDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Retur Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void OrderPembelianDownload_Load()
        {
            string fileName = "PosDownloadtmp\\HShTmp" + GlobalVar.CabangID + ".DBF";
            RefreshStatus("Downloading Order Pembelian..");
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            if (File.Exists(fileName))
            {
                try
                {
                    HosheetDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = HosheetDt.Rows.Count;
                    DownloadOrderPembelian();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    HosheetDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Order Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void OrderPembelianDetailDownload_Load()
        {
            string fileName = "PosDownloadtmp\\DShTmp" + GlobalVar.CabangID + ".DBF";
            RefreshStatus("Downloading Order PembelianDetail..");
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            if (File.Exists(fileName))
            {
                try
                {
                    DosheetDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = DosheetDt.Rows.Count;
                    DownloadOrderPembelianDetail();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    DosheetDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Order Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void NotaPembelianDownload_Load()
        {
            string fileName = "PosDownloadtmp\\HtbTmp" + GlobalVar.CabangID + ".DBF";
            RefreshStatus("Downloading Nota Pembelian..");
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            if (File.Exists(fileName))
            {
                try
                {
                    HtransbDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = HtransbDt.Rows.Count;
                    DownloadNotaPembelian();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    HtransbDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Nota Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NotaPembelianDetailDownload_Load()
        {
            string fileName = "PosDownloadtmp\\Dtbtmp" + GlobalVar.CabangID + ".DBF";
            RefreshStatus("Downloading Nota Pembelian Detail..");
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            if (File.Exists(fileName))
            {
                try
                {
                    NotaPembelianDetail = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = NotaPembelianDetail.Rows.Count;
                    DownloadNotaPembelianDetail();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    NotaPembelianDetail.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Nota Pembelian Detail", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ReturPembelianDownload_Load()
        {
            // string fileName = "PosDownloadtmp\\Hreturb.DBF";
            string fileName = "PosDownloadtmp\\HrbTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Retur Pembelian..");
            if (File.Exists(fileName))
            {
                try
                {
                    HreturbDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = HreturbDt.Rows.Count;
                    DownloadReturPembelian();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    HreturbDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Retur Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void ReturPembelianDetailDownload_Load()
        {
            string fileName = "PosDownloadtmp\\DrbTmp" + GlobalVar.CabangID + ".DBF";
        
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Retur Pembelian Detail..");
          
            if (File.Exists(fileName))
            {
                try
                {
                    DreturbDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = DreturbDt.Rows.Count;
                    DownloadReturPembelianDetail();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    DreturbDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Retur Pembelian Detail", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void PengembalianDownload_Load()
        {
            //string fileName = "PosDownloadtmp\\Hkembali.DBF";
            string fileName = "PosDownloadtmp\\HkbTmp" + GlobalVar.CabangID + ".DBF";

            RefreshStatus("Downloading Pengembalian..");
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            if (File.Exists(fileName))
            {
                try
                {
                    HkembaliDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = HkembaliDt.Rows.Count;
                    DownloadPengembalian();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    HkembaliDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Pengembalian", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void PeminjamanDownload_Load()
        {
            string fileName = "PosDownloadtmp\\HpjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Peminjaman..");
            if (File.Exists(fileName))
            {
                try
                {
                    HpinjamDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = HpinjamDt.Rows.Count;
                    DownloadPeminjaman();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    HpinjamDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Peminjaman", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }


        private void PeminjamanDetailDownload_Load()
        {
            string fileName = "PosDownloadtmp\\DpjTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading PeminjamanDetail..");
            if (File.Exists(fileName))
            {
                try
                {
                    DpinjamDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = DpinjamDt.Rows.Count;
                    DownloadPeminjamanDetail();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    DpinjamDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Peminjaman", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }


        private void RekapKoliDownload_Load()
        {
            string fileName = "PosDownloadtmp\\HxpTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Rekap Koli..");
            if (File.Exists(fileName))
            {
                try
                {
                    HxpdcDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = HxpdcDt.Rows.Count;
                    DownloadRekapKoli();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    HxpdcDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Rekap Koli", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void RekapKoliDetailDownload_Load()
        {
            string fileName = "PosDownloadtmp\\DxpTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Rekap Koli Detail..");
            if (File.Exists(fileName))
            {
                try
                {
                    DxpdcDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = DxpdcDt.Rows.Count;
                    DownloadRekapKoliDetail();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    DxpdcDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Rekap Koli", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void RekapKoliSubDetailDownload_Load()
        {
            string fileName = "PosDownloadtmp\\CxpTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Rekap Koli..");
            if (File.Exists(fileName))
            {
                try
                {
                    CxpdcDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = CxpdcDt.Rows.Count;
                    DownloadRekapKoliSubDetail();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    CxpdcDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Rekap Koli", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MutasiDownload_Load()
        {
            string fileName = "PosDownloadtmp\\HmtTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Mutasi..");
          
            if (File.Exists(fileName))
            {
                try
                {
                    HmutstokDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = HmutstokDt.Rows.Count;
                    DownloadMutasi();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    HmutstokDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Mutasi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void MutasiDetailDownload_Load()
        {
            string fileName = "PosDownloadtmp\\DmtTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading MutasiDetail..");

            if (File.Exists(fileName))
            {
                try
                {
                    DmutstokDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = DmutstokDt.Rows.Count;
                    DownloadMutasiDetail();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    DmutstokDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Mutasi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void AntargudangDownload_Load()
        {
            //string fileName = "PosDownloadtmp\\Hkrmagud.DBF";
            string fileName = "PosDownloadtmp\\HAGTmp" + GlobalVar.CabangID + ".DBF";
            RefreshStatus("Downloading Antar Gudang..");
          
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            if (File.Exists(fileName))
            {
                try
                {
                    HkrmagudDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = HkrmagudDt.Rows.Count;
                    DownloadAntarGudang();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    HkrmagudDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Antar Gudang", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AntargudangDetailDownload_Load()
        {
            //string fileName = "PosDownloadtmp\\Hkrmagud.DBF";
            string fileName = "PosDownloadtmp\\DAGTmp" + GlobalVar.CabangID + ".DBF";
            RefreshStatus("Downloading Antar Gudang Detail..");

            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            if (File.Exists(fileName))
            {
                try
                {
                    DkrmagudDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = DkrmagudDt.Rows.Count;
                    DownloadAntarGudangDetail();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    DkrmagudDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Antar Gudang", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PenjualanPotonganDownload_Load()
        {
            //string fileName = "PosDownloadtmp\\Hpotj.DBF";
            string fileName = "PosDownloadtmp\\HptTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Penjualan Potongan..");
          
            if (File.Exists(fileName))
            {
                try
                {
                    HpotJDt = Foxpro.ReadFile(fileName);
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = HpotJDt.Rows.Count;
                    DownloadPenjualanPotongan();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    HpotJDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Penjualan Potongan", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private void KoreksiPenjualanDownload_Load()
        {
            // string fileName = "PosDownloadtmp\\Kortrans.DBF";
            string fileName = "PosDownloadtmp\\Kortmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Koreksi Penjualan..");
          
            if (File.Exists(fileName))
            {
                try
                {
                    KoreksiPenjualanDt = Foxpro.ReadFile(fileName);

                    DataView dataView = KoreksiPenjualanDt.AsDataView();
                    dataView.RowFilter = "Sumber = 'NPJ'";
                    KoreksiPenjualanDt = dataView.Table;

                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = KoreksiPenjualanDt.Rows.Count;
                    DownloadKoreksiPenjualan();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    KoreksiPenjualanDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Koreksi Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private void KoreksiPembelianDownload_Load()
        {
            string fileName = "PosDownloadtmp\\Kortmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Koreksi Pembelian..");
          
            if (File.Exists(fileName))
            {
                try
                {
                    KoreksiPembelianDt = Foxpro.ReadFile(fileName);

                    DataView dataView = KoreksiPembelianDt.AsDataView();
                    dataView.RowFilter = "Sumber = 'NPB'";
                    KoreksiPembelianDt = dataView.Table;
                    pbSyncDownload.Minimum = 0;
                    pbSyncDownload.Maximum = KoreksiPembelianDt.Rows.Count;
                    DownloadKoreksiPembelian();
                    ctr++;
                    lblCtr.Text = ctr.ToString() + "/31";
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    KoreksiPembelianDt.Dispose();
                }
            }
            else
                MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Koreksi Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void KoreksiReturPembelianDownload_Load()
        {
            string fileName = "PosDownloadtmp\\Kortmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Koreksi Retur Pembelian..");
          
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        KoreksiReturPembelianDt = Foxpro.ReadFile(fileName);

                        DataView dataView = KoreksiReturPembelianDt.AsDataView();
                        dataView.RowFilter = "Sumber = 'NRB'";
                        KoreksiReturPembelianDt = dataView.Table;

                        pbSyncDownload.Minimum = 0;
                        pbSyncDownload.Maximum = KoreksiReturPembelianDt.Rows.Count;
                        DownloadKoreksiReturPembelian();
                        ctr++;
                        lblCtr.Text = ctr.ToString() + "/31";
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        KoreksiReturPembelianDt.Dispose();
                    }
                }
                else
                    MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Koreksi Retur Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void KoreksiReturPenjualanDownload_Load()
        {
            string fileName = "PosDownloadtmp\\Kortmp" + GlobalVar.CabangID + ".DBF";
            RefreshStatus("Koreksi Retur Penjualan..");
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        KoreksiReturPenjualanDt = Foxpro.ReadFile(fileName);
                        DataView dataView = KoreksiReturPenjualanDt.AsDataView();
                        dataView.RowFilter = "Sumber = 'NRJ'";
                        KoreksiReturPenjualanDt = dataView.Table;
                        pbSyncDownload.Minimum = 0;
                        pbSyncDownload.Maximum = KoreksiReturPenjualanDt.Rows.Count;
                        DownloadKoreksiReturPenjualan();
                        KoreksiReturPenjualanDt.Dispose();
                        ctr++;
                        lblCtr.Text = ctr.ToString() + "/31";
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        KoreksiReturPenjualanDt.Dispose();
                    }
                }
                else
                    MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Penjualan Potongan", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void StokDownload_Load()
        {
            string fileName = "PosDownloadtmp\\StkTmp" + GlobalVar.CabangID + ".DBF";
            RefreshStatus("Downloading Stok..");
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        SasStokDt = Foxpro.ReadFile(fileName);
                        pbSyncDownload.Minimum = 0;
                        pbSyncDownload.Maximum = SasStokDt.Rows.Count;
                        DownloadStok();
                        ctr++;
                        lblCtr.Text = ctr.ToString() + "/31";
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        SasStokDt.Dispose();
                    }
                }
                else
                    MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Stok", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void TokoDownload_Load()
        {
            string fileName = "PosDownloadtmp\\TokTmp" + GlobalVar.CabangID + ".DBF";
            RefreshStatus("Downloading Toko..");
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        TokoDt = Foxpro.ReadFile(fileName);
                        pbSyncDownload.Minimum = 0;
                        pbSyncDownload.Maximum = TokoDt.Rows.Count;
                        DownloadToko();
                        ctr++;
                        lblCtr.Text = ctr.ToString() + "/31";
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        TokoDt.Dispose();
                    }
                }
                else
                    MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Stok", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void SalesDownload_Load()
        {
            string fileName = "PosDownloadtmp\\SlsTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Sales..");
          

            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        SalesDt = Foxpro.ReadFile(fileName);
                        pbSyncDownload.Minimum = 0;
                        pbSyncDownload.Maximum = SalesDt.Rows.Count;
                        DownloadSales();
                        ctr++;
                        lblCtr.Text = ctr.ToString() + "/31";
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        SalesDt.Dispose();
                    }
                }
                else
                    MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Stok", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void PemasokDownload_Load()
        {
            string fileName = "PosDownloadtmp\\PmsTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;

            RefreshStatus("Downloading Pemasok..");
          
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        PemasokDt = Foxpro.ReadFile(fileName);
                        pbSyncDownload.Minimum = 0;
                        pbSyncDownload.Maximum = PemasokDt.Rows.Count;
                        DownloadPemasok();
                        ctr++;
                        lblCtr.Text = ctr.ToString() + "/31";
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        PemasokDt.Dispose();
                    }
                }
                else
                    MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Stok", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ExpedisiDownload_Load()
        {
            string fileName = "PosDownloadtmp\\ExpTmp" + GlobalVar.CabangID + ".DBF";
            RefreshStatus("Downloading Expedisi..");
          
            fileName = GlobalVar.DbfDownload + "\\" + fileName;


            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        ExpedisiDt = Foxpro.ReadFile(fileName);
                        pbSyncDownload.Minimum = 0;
                        pbSyncDownload.Maximum = ExpedisiDt.Rows.Count;
                        DownloadExpedisi();
                        ctr++;
                        lblCtr.Text = ctr.ToString() + "/31";
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        ExpedisiDt.Dispose();
                    }
                }
                else
                    MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Stok", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void KompensasiDownload_Load()
        {
            string fileName = "PosDownloadtmp\\KmpTmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Kompensasi..");
          
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        KompensasiDt = Foxpro.ReadFile(fileName);
                        pbSyncDownload.Minimum = 0;
                        pbSyncDownload.Maximum = KompensasiDt.Rows.Count;
                        DownloadKompensasi();
                        ctr++;
                        lblCtr.Text = ctr.ToString() + "/31";
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        KompensasiDt.Dispose();
                    }
                }
                else
                    MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Kompensasi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void OpnameDownload_Load()
        {
            string fileName = "PosDownloadtmp\\Soptmp" + GlobalVar.CabangID + ".DBF";
            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            RefreshStatus("Downloading Opname History..");
          
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        OpnameDt = Foxpro.ReadFile(fileName);
                        pbSyncDownload.Minimum = 0;
                        pbSyncDownload.Maximum = OpnameDt.Rows.Count;
                        DownloadOpname();
                        ctr++;
                        lblCtr.Text = ctr.ToString() + "/31";
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        OpnameDt.Dispose();
                    }
                }
                else
                    MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download Kompensasi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
        #region DownloadSection
        public void DownloadOrderPenjualan()
        {
            string fileName = GlobalVar.DbfDownload + "\\PosDownloadtmp\\Hhjtmp" + GlobalVar.CabangID + ".DBF";
            string _connStrTemplate = "Provider = VFPOLEDB;Data Source={0}";
            
            if (File.Exists(fileName))
            {
                FileInfo info = new FileInfo(fileName);
                string tableName = info.Name;
                string connStr = String.Format(_connStrTemplate, info.DirectoryName);
                //string sqlQuery = "SELECT idhtr, cab1, cab2, cab3, no_rq, DTOC(tgl_rq) as tgl_rq, no_do, DTOC(tgl_do) as tgl_do, no_acc, no_nota, DTOC(tgl_nota) as tgl_nota, no_sj, DTOC(tgl_sj) as tgl_sj, DTOC(tgl_trm) as tgl_trm, hr_krdt, kd_toko,   nm_toko, kd_sales, al_kirim, kota, STR(rp_jual) as rp_jual, STR(rp_jual2) as rp_jual2, STR(rp_jual3) as rp_jual3, STR(rp_net) as rp_net, STR(rp_net2) as rp_net2, STR(rp_net3) as rp_net3, STR(disc_1) as disc_1, STR(disc_2) as disc_2, STR(disc_3) as disc_3, STR(pot_rp) as pot_rp, STR(pot_rp2) as pot_rp2, STR(pot_rp3) as pot_rp3, STR(rp_fee1) as rp_fee1, STR(rp_fee2) as rp_fee2, expedisi, laudit, id_disc, catatan1, catatan2, catatan3, catatan4, catatan5, no_dobo, DTOC(tgl_reord) as tgl_reord, lbo, id_match, id_link, id_tr, hari_krm, hari_sls, nprint, no_acc, shift, checker_1, checker_2   FROM hhjtmp" + GlobalVar.CabangID;
                //
                string sqlQuery = "SELECT idhtr, cab1, cab2, cab3, no_rq, DTOC(tgl_rq) as tgl_rq, no_do, DTOC(tgl_do) as tgl_do, no_acc, no_nota, DTOC(tgl_nota) as tgl_nota, no_sj, DTOC(tgl_sj) as tgl_sj, DTOC(tgl_trm) as tgl_trm, hr_krdt, kd_toko,   nm_toko, kd_sales, al_kirim, kota, STR(rp_jual) as rp_jual, STR(rp_jual2) as rp_jual2, STR(rp_jual3) as rp_jual3, STR(rp_net) as rp_net, STR(rp_net2) as rp_net2, STR(rp_net3) as rp_net3, STR(disc_1) as disc_1, STR(disc_2) as disc_2, STR(disc_3) as disc_3, STR(pot_rp) as pot_rp, STR(pot_rp2) as pot_rp2, STR(pot_rp3) as pot_rp3, STR(rp_fee1) as rp_fee1, STR(rp_fee2) as rp_fee2, expedisi, laudit, id_disc, catatan1, catatan2, catatan3, catatan4, catatan5, no_dobo, DTOC(tgl_reord) as tgl_reord, lbo, id_match, id_link, id_tr, hari_krm, hari_sls, nprint, no_acc, shift, checker_1,Cicil, checker_2  FROM hhjtmp" + GlobalVar.CabangID;
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
                        
                        if(dr["tgl_nota"].ToString().Replace(" ", "") == "//")
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
                            pbSyncDownload.Increment(1);
                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(dr["idhtr"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["cab2"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, Tools.isNull(dr["cab3"], "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, (Tools.isNull(dr["no_rq"], "").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, Tools.isNull(dr["tgl_rq"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, Tools.isNull(dr["no_do"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, Tools.isNull(dr["tgl_do"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, Tools.isNull(dr["checker_1"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, Tools.isNull(dr["no_nota"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, tglNota)); 
                            db.Commands[0].Parameters.Add(new Parameter("@RpACCPiutang", SqlDbType.Money, double.Parse(Tools.isNull(dr["rp_net3"], "").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@RpPlafonToko", SqlDbType.Money, double.Parse(Tools.isNull(dr["pot_rp2"], "").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@RpPiutangTerakhir", SqlDbType.Money, double.Parse(Tools.isNull(dr["pot_rp3"], "").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@RpGiroTolakTerakhir", SqlDbType.Money, double.Parse(Tools.isNull(dr["rp_fee1"], "").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@RpOverdue", SqlDbType.Money, double.Parse(Tools.isNull(dr["rp_fee2"], "").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, Tools.isNull(dr["no_sj"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, Tools.isNull(dr["al_kirim"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, Tools.isNull(dr["kota"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(dr["id_disc"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_1"], "").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_2"], "").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_3"], "").ToString().Trim())));
                            //db.Commands[0].Parameters.Add(new Parameter("@Plafon", SqlDbType.Money, double.Parse(Tools.isNull(dr["pot_rp2"], "").ToString().Trim())));
                            //db.Commands[0].Parameters.Add(new Parameter("@SaldoPiutang", SqlDbType.Money, double.Parse(Tools.isNull(dr["pot_rp3"], "").ToString().Trim())));
                            //db.Commands[0].Parameters.Add(new Parameter("@QtyTolak", SqlDbType.Int, Tools.isNull(dr["rp_fee1"], "0")));
                            //db.Commands[0].Parameters.Add(new Parameter("@Overdue", SqlDbType.Money, double.Parse(Tools.isNull(dr["rp_fee2"], "").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, (Tools.isNull(dr["laudit"], "").ToString().Trim() == "False" ? 0 : 1)));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, Tools.isNull(dr["catatan1"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, Tools.isNull(dr["catatan2"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, Tools.isNull(dr["catatan3"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, Tools.isNull(dr["catatan4"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, Tools.isNull(dr["catatan5"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, Tools.isNull(dr["no_dobo"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglReorder", SqlDbType.DateTime, tglReoder )); 
                            db.Commands[0].Parameters.Add(new Parameter("@StatusBO", SqlDbType.Bit, (Tools.isNull(dr["lbo"], "0").ToString().Trim() == "False" ? 0 : 1)));
                            //db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, (Tools.isNull(dr["id_match"], "0").ToString().Trim() == "False" ? 0 : 1)));
                            db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["id_link"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, Tools.isNull(dr["id_tr"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, Tools.isNull(dr["expedisi"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Shift", SqlDbType.VarChar, Tools.isNull(dr["shift"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, int.Parse(Tools.isNull(dr["hr_krdt"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_krm"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_sls"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString().Trim())));
                            //uncoment after cicil done
                            db.Commands[0].Parameters.Add(new Parameter("@Cicil", SqlDbType.Int, int.Parse(Tools.isNull(dr["cicil"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                    dr.Close();
                    conn.Close();
                }
            }
            
        }

        //public void DownloadOrderPenjualan()
        //{
        //    using (Database db = new Database())
        //    {
        //        db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_OrderPenjualan"));
        //        foreach (DataRow dr in HhtransjDt.Rows)
        //        {
        //            pbSyncDownload.Increment(1);
        //            db.Commands[0].Parameters.Clear();
        //            db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(dr["idhtr"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["cab2"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, Tools.isNull(dr["cab3"], "").ToString()));
        //            db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, (Tools.isNull(dr["no_rq"], "").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, Tools.isNull(dr["tgl_rq"], DBNull.Value)));
        //            db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, Tools.isNull(dr["no_do"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, Tools.isNull(dr["tgl_do"], DBNull.Value)));
        //            db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, Tools.isNull(dr["checker_1"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, Tools.isNull(dr["no_nota"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, Tools.isNull(dr["tgl_nota"], DBNull.Value)));
        //            db.Commands[0].Parameters.Add(new Parameter("@RpACCPiutang", SqlDbType.Money, double.Parse(Tools.isNull(dr["rp_net3"], "").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@RpPlafonToko", SqlDbType.Money, double.Parse(Tools.isNull(dr["pot_rp2"], "").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@RpPiutangTerakhir", SqlDbType.Money, double.Parse(Tools.isNull(dr["pot_rp3"], "").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@RpGiroTolakTerakhir", SqlDbType.Money, double.Parse(Tools.isNull(dr["rp_fee1"], "").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@RpOverdue", SqlDbType.Money, double.Parse(Tools.isNull(dr["rp_fee2"], "").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, Tools.isNull(dr["no_sj"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, Tools.isNull(dr["al_kirim"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, Tools.isNull(dr["kota"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(dr["id_disc"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_1"], "").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_2"], "").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_3"], "").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@Plafon", SqlDbType.Money, double.Parse(Tools.isNull(dr["pot_rp2"], "").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@SaldoPiutang", SqlDbType.Money, double.Parse(Tools.isNull(dr["pot_rp3"], "").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@QtyTolak", SqlDbType.Int, Tools.isNull(dr["rp_fee1"], "0")));
        //            db.Commands[0].Parameters.Add(new Parameter("@Overdue", SqlDbType.Money, double.Parse(Tools.isNull(dr["rp_fee2"], "").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, (Tools.isNull(dr["laudit"], "").ToString().Trim() == "False" ? 0 : 1)));
        //            db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, Tools.isNull(dr["catatan1"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, Tools.isNull(dr["catatan2"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, Tools.isNull(dr["catatan3"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, Tools.isNull(dr["catatan4"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, Tools.isNull(dr["catatan5"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, Tools.isNull(dr["no_dobo"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@TglReorder", SqlDbType.DateTime, Tools.isNull(dr["tgl_reord"], DBNull.Value)));
        //            db.Commands[0].Parameters.Add(new Parameter("@StatusBO", SqlDbType.Bit, (Tools.isNull(dr["lbo"], "0").ToString().Trim() == "False" ? 0 : 1)));
        //            //db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, (Tools.isNull(dr["id_match"], "0").ToString().Trim() == "False" ? 0 : 1)));
        //            db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["id_link"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, Tools.isNull(dr["id_tr"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, Tools.isNull(dr["expedisi"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@Shift", SqlDbType.VarChar, Tools.isNull(dr["shift"], "").ToString().Trim()));
        //            db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, int.Parse(Tools.isNull(dr["hr_krdt"], "0").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_krm"], "0").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_sls"], "0").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString().Trim())));
        //            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
        //            db.Commands[0].ExecuteNonQuery();

        //        }

        //    }
        //}

        public void DownloadOrderPenjualanDetail()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_OrderPenjualanDetail"));
                foreach (DataRow dr in DhtransjDt.Rows)
                {
                    pbSyncDownload.Increment(1);

                    db.Commands[0].Parameters.Clear();
                    // * 
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(dr["idhtr"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, (Tools.isNull(dr["id_brg"], "").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@QtyRequest", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_rq"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_do"], "").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@HrgJual", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_jual"], "").ToString().Trim())));
                    //db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                    //db.Commands[0].Parameters.Add(new Parameter("@TglSuratJalan", SqlDbType.DateTime, Tools.isNull(dr["tgl_sj"], DBNull.Value)));
                    db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Money, double.Parse(Tools.isNull(dr["disc_1"], "").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Money, double.Parse(Tools.isNull(dr["disc_2"], "").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Money, double.Parse(Tools.isNull(dr["disc_3"], "").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@Pot", SqlDbType.Money, double.Parse(Tools.isNull(dr["pot_rp"], "").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(dr["id_disc"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, Tools.isNull(dr["no_bodo"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@NBOPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                }
            }
        }
        public void DownloadNotaPenjualan()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_NotaPenjualanPos"));
                foreach (DataRow dr in HtransjDt.Rows)
                {
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
                    /**/
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
                }
            }
        }
        public void DownloadNotaPenjualanDetail()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_NotaPenjualanDetailPos"));
                foreach (DataRow dr in DtransjDt.Rows)
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
                    db.Commands[0].Parameters.Add(new Parameter("@KetKoli", SqlDbType.VarChar, Tools.isNull(dr["ket_koli"], "0").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@NPackingListPrint", SqlDbType.VarChar, Tools.isNull(dr["nprint"], "").ToString()));
                    /**/
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
                }
            }
        }


        public void DownloadReturPenjualan()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ReturPenjualanPos"));
                foreach (DataRow dr in HreturjDt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["cab2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@ReturID", SqlDbType.VarChar, (Tools.isNull(dr["idretur"], "").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoMPR", SqlDbType.VarChar, (Tools.isNull(dr["no_memo"], "").ToString().Trim())));
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
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, (Tools.isNull(dr["laudit"], "").ToString().Trim() == "False" ? 0 : 1)));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@TglRQRetur", SqlDbType.DateTime, Tools.isNull(dr["tgl_rqret"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        public void DownloadReturPenjualanDetail()
        {

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ReturPenjualanDetailPos"));
                foreach (DataRow dr in DrjtmpDt.Rows)
                {
                    pbSyncDownload.Increment(1);
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
                }
            }
        }

        public void DownloadOrderPembelian()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_OrderPembelian"));
                foreach (DataRow dr in HosheetDt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, Tools.isNull(dr["no_rq"], "").ToString().Trim()));

                        db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, Tools.isNull(dr["tgl_rq"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Pemasok", SqlDbType.VarChar, Tools.isNull(dr["pemasok"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, Tools.isNull(dr["c1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["c2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@EstHrgJual", SqlDbType.Money, double.Parse(Tools.isNull(dr["est_rpjual"], "").ToString().Trim())));

                        db.Commands[0].Parameters.Add(new Parameter("@EstHPP", SqlDbType.Money, double.Parse(Tools.isNull(dr["est_rphpp"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.VarChar, Tools.isNull(dr["id_match"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }


        public void DownloadOrderPembelianDetail()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_OrderPembelianDetail"));
                foreach (DataRow dr in DosheetDt.Rows)
                {
                    pbSyncDownload.Increment(1);
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

                    }
                }
            }
        }

        public void DownloadReturPembelianDetail()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ReturPembelianDetail"));
                foreach (DataRow dr in DreturbDt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@ReturID", SqlDbType.VarChar, Tools.isNull(dr["idretur"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NotaBeliDetailRecID", SqlDbType.VarChar, Tools.isNull(dr["iddtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeRetur", SqlDbType.VarChar, Tools.isNull(dr["kdretur"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyGudang", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_gudang"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyTerima", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_terima"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgBeli", SqlDbType.Money, Double.Parse(Tools.isNull(dr["h_beli"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgNet", SqlDbType.Money, Double.Parse(Tools.isNull(dr["h_net"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgPokok", SqlDbType.Money, Double.Parse(Tools.isNull(dr["h_pokok"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@HPPSolo", SqlDbType.Money, Double.Parse(Tools.isNull(dr["hpp_solo"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, Tools.isNull(dr["tgl_keluar"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        public void DownloadNotaPembelian()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_NotaPembelian"));
                foreach (DataRow dr in HtransbDt.Rows)
                {
                    pbSyncDownload.Increment(1);
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
                        db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_1"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_2"], "").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["disc_3"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(dr["id_disc"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, int.Parse(Tools.isNull(dr["hr_krdt"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@PPN", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["ppn"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Pemasok", SqlDbType.VarChar, (Tools.isNull(dr["Pemasok"], "").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, Tools.isNull(dr["expedisi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, Tools.isNull(dr["cab"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar,""));
                      
                        // db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, (Tools.isNull(dr["Laudit"], "0").ToString().Trim() == "False" ? 0 : 1)));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        public void DownloadNotaPembelianDetail()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_NotaPembelianDetail"));
                foreach (DataRow dr in NotaPembelianDetail.Rows)
                {
                    pbSyncDownload.Increment(1);
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
                }
            }
        }

        public void DownloadReturPembelian()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ReturPembelian"));
                foreach (DataRow dr in HreturbDt.Rows)
                {
                    pbSyncDownload.Increment(1);
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
                        db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, Tools.isNull(dr["laudit"], "").ToString().Trim().Equals("False") ? 0 : 1));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.VarChar, Tools.isNull(dr["nprint"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        public void DownloadPengembalian()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Pengembalian"));
                foreach (DataRow dr in HkembaliDt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, Tools.isNull(dr["nobukti"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKembaliPj", SqlDbType.DateTime, Tools.isNull(dr["tgl_kmbpj"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKembaliGdg", SqlDbType.DateTime, Tools.isNull(dr["tgl_kmbgd"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["print"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.VarChar, Tools.isNull(dr["id_match"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        public void DownloadPeminjaman()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Peminjaman"));
                foreach (DataRow dr in HpinjamDt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, Tools.isNull(dr["nobukti"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, Tools.isNull(dr["tgl_kelpj"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglBatas", SqlDbType.DateTime, Tools.isNull(dr["tgl_btspj"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@StaffPenjualan", SqlDbType.VarChar, Tools.isNull(dr["penjstaff"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["print"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, (Tools.isNull(dr["kd_sales"], "").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }


        public void DownloadPeminjamanDetail()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_PeminjamanDetail"));
                foreach (DataRow dr in DpinjamDt.Rows)
                {
                    pbSyncDownload.Increment(1);
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
                    }
                }
            }
        }
        public void DownloadRekapKoli()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_RekapKoli"));
                foreach (DataRow dr in HxpdcDt.Rows)
                {
                    pbSyncDownload.Increment(1);
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
                        db.Commands[0].Parameters.Add(new Parameter("@Shift", SqlDbType.Int, int.Parse(Tools.isNull(dr["shift"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@BiayaExp1", SqlDbType.Money, double.Parse(Tools.isNull(dr["by_exp"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@BiayaExp2", SqlDbType.Money, double.Parse(Tools.isNull(dr["by_exp2"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@BiayaExp3", SqlDbType.Money, double.Parse(Tools.isNull(dr["by_exp3"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@KP", SqlDbType.VarChar, (Tools.isNull(dr["kp"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        public void DownloadRekapKoliDetail()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_RekapKoliDetail"));
                foreach (DataRow dr in DxpdcDt.Rows)
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
                }
            }
        }
        public void DownloadRekapKoliSubDetail()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_RekapKoliSubDetail"));
                foreach (DataRow dr in CxpdcDt.Rows)
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
                }
            }
        }
        public void DownloadMutasi()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Mutasi"));
                foreach (DataRow dr in HmutstokDt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@MutasiID", SqlDbType.VarChar, Tools.isNull(dr["id_mts"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglMutasi", SqlDbType.DateTime, Tools.isNull(dr["tgl_mts"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NomorMutasi", SqlDbType.VarChar, (Tools.isNull(dr["no_mts"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@KeteranganMutasi", SqlDbType.VarChar, Tools.isNull(dr["ket_mts"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LAudit", SqlDbType.Bit, (Tools.isNull(dr["laudit"], "").ToString().Trim() == "False" ? 0 : 1)));
                        db.Commands[0].Parameters.Add(new Parameter("@TipeMutasi", SqlDbType.VarChar, (Tools.isNull(dr["type"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        public void DownloadMutasiDetail()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_MutasiDetail"));
                foreach (DataRow dr in DmutstokDt.Rows)
                {
                    pbSyncDownload.Increment(1);
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
                    }
                }
            }
        }
        public void DownloadAntarGudang()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_AntarGudang"));
                foreach (DataRow dr in HkrmagudDt.Rows)
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
                }
            }
        }

        public void DownloadAntarGudangDetail()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_AntarGudangDetail"));
                foreach (DataRow dr in DkrmagudDt.Rows)
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
                }
            }
        }

        public void DownloadPenjualanPotongan()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_PenjualanPotongan"));
                foreach (DataRow dr in HpotJDt.Rows)
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
                }
            }
        }
        public void DownloadKoreksiPembelian()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_KoreksiPembelian"));
                foreach (DataRow dr in KoreksiPembelianDt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["id_koreksi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NotaBeliDetailRecID", SqlDbType.VarChar, Tools.isNull(dr["id_detail"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKoreksi", SqlDbType.DateTime, Tools.isNull(dr["tglkoreksi"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoKoreksi", SqlDbType.VarChar, (Tools.isNull(dr["no_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, (Tools.isNull(dr["id_brg"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNotaBaru", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_nota"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgBeliBaru", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_jual"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Pemasok", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Sumber", SqlDbType.VarChar, Tools.isNull(dr["sumber"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["dt_link"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgBeliKoreksi", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNotaKoreksi", SqlDbType.Int, int.Parse(Tools.isNull(dr["n_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }

        }
        public void DownloadKoreksiPenjualan()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_KoreksiPenjualanPos"));
                foreach (DataRow dr in KoreksiPenjualanDt.Rows)
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
                }
            }

        }
        public void DownloadKoreksiReturPembelian()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_KoreksiReturPembelian"));
                foreach (DataRow dr in KoreksiReturPembelianDt.Rows)
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
                }
            }
        }
        public void DownloadKoreksiReturPenjualan()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_KoreksiReturPenjualanPos"));
                foreach (DataRow dr in KoreksiReturPenjualanDt.Rows)
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
                }
            }
        }
        public void DownloadStok()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Stok"));
                foreach (DataRow dr in SasStokDt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Bundle", SqlDbType.VarChar, (Tools.isNull(dr["bundel"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaStok", SqlDbType.VarChar, (Tools.isNull(dr["nama_stok"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSolo", SqlDbType.VarChar, (Tools.isNull(dr["kodesolo"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Kendaraan", SqlDbType.VarChar, (Tools.isNull(dr["kendaraan"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaTertera", SqlDbType.VarChar, (Tools.isNull(dr["nm_tertera"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@PartNo", SqlDbType.VarChar, (Tools.isNull(dr["partno"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Merek", SqlDbType.VarChar, (Tools.isNull(dr["merek"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Dibungkus", SqlDbType.VarChar, (Tools.isNull(dr["dibungkus"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SumberDr", SqlDbType.VarChar, Tools.isNull(dr["sumber_dr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@ProsesID", SqlDbType.VarChar, (Tools.isNull(dr["idproses"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SatSolo", SqlDbType.VarChar, (Tools.isNull(dr["sat_solo"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Material", SqlDbType.VarChar, (Tools.isNull(dr["material"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SatJual", SqlDbType.VarChar, (Tools.isNull(dr["sat_jual"], "").ToString().Trim())));

                        db.Commands[0].Parameters.Add(new Parameter("@KodeRak", SqlDbType.VarChar, Tools.isNull(dr["kd_rak"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeRak1", SqlDbType.VarChar, Tools.isNull(dr["kd_rak1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeRak2", SqlDbType.VarChar, (Tools.isNull(dr["kd_rak2"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@JB", SqlDbType.VarChar, (Tools.isNull(dr["jb"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusPasif", SqlDbType.Bit, Tools.isNull(dr["lpasif"], "").ToString() == "False" ? 0 : 1));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@PrediksiLamaKirim", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_ordb"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@HariRataRata", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_opnm"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@StokMin", SqlDbType.Int, int.Parse(Tools.isNull(dr["stokmin"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@StokMax", SqlDbType.Int, int.Parse(Tools.isNull(dr["stokmax"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@IsiKoli", SqlDbType.Int, int.Parse(Tools.isNull(dr["isi_koli"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));

                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        public void DownloadToko()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Toko"));
                foreach (DataRow dr in TokoDt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@TokoID", SqlDbType.VarChar, Tools.isNull(dr["idtoko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, Tools.isNull(dr["namatoko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, Tools.isNull(dr["alamat"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, (Tools.isNull(dr["kota"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Telp", SqlDbType.VarChar, (Tools.isNull(dr["notelp"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, (Tools.isNull(dr["idwil"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@PenanggungJawab", SqlDbType.VarChar, (Tools.isNull(dr["pngjwb"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, (Tools.isNull(dr["kd_toko"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@PiutangB", SqlDbType.Money, double.Parse(Tools.isNull(dr["piutang_b"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@PiutangJ", SqlDbType.Money, double.Parse(Tools.isNull(dr["piutang_j"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Plafon", SqlDbType.Money, double.Parse(Tools.isNull(dr["plafon"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@ToJual", SqlDbType.Money, double.Parse(Tools.isNull(dr["to_jual"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@ToRetPot", SqlDbType.Money, double.Parse(Tools.isNull(dr["to_retpot"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@JangkaWaktuKredit", SqlDbType.Int, int.Parse(Tools.isNull(dr["jkw_kredit"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, (Tools.isNull(dr["cab2"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Tgl1st", SqlDbType.DateTime, Tools.isNull(dr["tgl1st"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Exist", SqlDbType.Bit, (Tools.isNull(dr["exist"], "").ToString().Trim() == "False" ? 0 : 1)));


                        db.Commands[0].Parameters.Add(new Parameter("@ClassID", SqlDbType.VarChar, Tools.isNull(dr["idclass"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_krm"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@KodePos", SqlDbType.VarChar, (Tools.isNull(dr["kd_pos"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Grade", SqlDbType.VarChar, (Tools.isNull(dr["Grade"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Plafon1st", SqlDbType.Money, double.Parse(Tools.isNull(dr["plafon_1st"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Flag", SqlDbType.VarChar, (Tools.isNull(dr["flag"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Bentrok", SqlDbType.VarChar, (Tools.isNull(dr["bentrok"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, (Tools.isNull(dr["lpasif"], "").ToString().Trim() == "False" ? 0 : 1)));
                        db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_sls"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Daerah", SqlDbType.VarChar, Tools.isNull(dr["daerah"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Propinsi", SqlDbType.VarChar, (Tools.isNull(dr["propinsi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@AlamatRumah", SqlDbType.VarChar, (Tools.isNull(dr["alm_rumah"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Pengelola", SqlDbType.VarChar, (Tools.isNull(dr["pengelola"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.DateTime, Tools.isNull(dr["tgl_lahir"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@HP", SqlDbType.VarChar, Tools.isNull(dr["hp"], "").ToString().Trim()));

                        db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, Tools.isNull(dr["status"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@ThnBerdiri", SqlDbType.VarChar, Tools.isNull(dr["th_berdiri"], "").ToString().Trim()));

                        db.Commands[0].Parameters.Add(new Parameter("@StatusRuko", SqlDbType.Bit, (Tools.isNull(dr["lruko"], "").ToString().Trim() == "False" ? 0 : 1)));
                        db.Commands[0].Parameters.Add(new Parameter("@JmlCabang", SqlDbType.Int, int.Parse(Tools.isNull(dr["jml_cabang"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@JmlSales", SqlDbType.Int, int.Parse(Tools.isNull(dr["jml_sales"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Kinerja", SqlDbType.VarChar, (Tools.isNull(dr["kinerja"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@BidangUsaha", SqlDbType.VarChar, (Tools.isNull(dr["pengelola"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@RefSales", SqlDbType.VarChar, Tools.isNull(dr["reff_sls"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RefCollector", SqlDbType.VarChar, Tools.isNull(dr["reff_col"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RefSupervisor", SqlDbType.VarChar, (Tools.isNull(dr["reff_spv"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@PlafonSurvey", SqlDbType.Money, double.Parse(Tools.isNull(dr["plf_survey"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        // table sales is not generated yet by system.
        public void DownloadSales()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Sales"));
                foreach (DataRow dr in SalesDt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaSales", SqlDbType.VarChar, Tools.isNull(dr["nm_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));

                        db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.DateTime, Tools.isNull(dr["tgl_lahir"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, Tools.isNull(dr["alamat"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Target", SqlDbType.Money, double.Parse(Tools.isNull(dr["target"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@BatasOD", SqlDbType.Money, double.Parse(Tools.isNull(dr["Batas_od"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@TglMasuk", SqlDbType.DateTime, Tools.isNull(dr["tgl_masuk"], "").ToString() == "" ? SqlDateTime.Null : (DateTime)dr["tgl_masuk"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime,  Tools.isNull(dr["tgl_keluar"], "").ToString() == "" ? SqlDateTime.Null : (DateTime)dr["tgl_keluar"]));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, double.Parse(Tools.isNull(dr["id_match"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        public void DownloadPemasok()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Pemasok"));
                foreach (DataRow dr in PemasokDt.Rows)
                {
                    pbSyncDownload.Increment(1);
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
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        public void DownloadExpedisi()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Expedisi"));
                foreach (DataRow dr in ExpedisiDt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@KodeExpedisi", SqlDbType.VarChar, Tools.isNull(dr["kode"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaExpedisi", SqlDbType.VarChar, Tools.isNull(dr["nm_exp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, Tools.isNull(dr["alamat"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Telp", SqlDbType.VarChar, Tools.isNull(dr["telepon"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KotaTujuan", SqlDbType.VarChar, Tools.isNull(dr["kota_tj"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        public void DownloadKompensasi()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Kompensasi"));
                foreach (DataRow dr in KompensasiDt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@DiscKompensasi", SqlDbType.Decimal,decimal.Parse(Tools.isNull(dr["disc_komp"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime,DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();

                    }
                }
            }
        }
        public void DownloadOpname()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_Opname"));
                foreach (DataRow dr in OpnameDt.Rows)
                {
                    pbSyncDownload.Increment(1);
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, Tools.isNull(dr["tgl_opnm"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyOpname", SqlDbType.Int,int.Parse(Tools.isNull(dr["qty_opnm"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kodegudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["ket_opnm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit,int.Parse(Tools.isNull(dr["id_match"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar,SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime,DateTime.Now));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion


        #region Delete

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
            string depan = GlobalVar.DbfDownload + "\\PosDownloadtmp\\";
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
                
                //KompensasiDownload_Load();
                //OpnameDownload_Load();
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

        private bool UnzipFile()
        {
            // store PosDownload table into directory PosDownloadtmp.
            bool retVal = false;
            string extractFileLocation = GlobalVar.DbfDownload + "\\PosDownloadtmp";

            if (!Directory.Exists(extractFileLocation))
            {
                Directory.CreateDirectory(extractFileLocation);
            }
            else
            {
                string[] files = Directory.GetFiles(extractFileLocation);
                
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }

            if (File.Exists(fileZIPName))
            {
                Zip.UnZipFiles(fileZIPName, extractFileLocation, false);
                retVal = true;
            }
            else
            {
                // lblFileNameLocation.Text = "File " + sourceZIPFileName + " tidak ada.";
                pbSyncDownload.Enabled = false;
                MessageBox.Show("File: " + fileZIPName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Pos Download", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retVal;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
