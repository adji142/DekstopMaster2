using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Toko;
using ISA.DAL;
using System.IO;
//using ISA.Bengkel;
using ISA.Pin;
using ISA.Common;
using System.Net;


namespace ISA.Toko
{
    public partial class frmMain : Form
    {
        string hari = string.Empty;
        Guid AutoRowID, LastROwID;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ApplyAppSetting();
            //SecurityManager.AlwaysAuthenticate();
            GlobalVar.initialize();
            //MessageBox.Show(GlobalVar.Gudang);
            //statusStrip1.Items[0].Text = SecurityManager.UserID;

            bwAuto.RunWorkerAsync();
            if (!SecurityManager.IsManager())
            {
                PerformSecurityCheck();
            }
            tsUserID.Text = "User ID: " + SecurityManager.UserID;
            tsHost.Text = "Host: " + ISA.DAL.Database.Host;
            txtVersion.Text = txtVersion.Text + Application.ProductVersion;
            if (ISA.DAL.Database.Host.Contains("DEV") || ISA.DAL.Database.Host.Contains("TEST"))
                debugToolStripMenuItem.Visible = true;
            else
                debugToolStripMenuItem.Visible = false;
        }

        private void ApplyAppSetting()
        {
            DataTable dtAppSettings = new DataTable();


            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                dtAppSettings = db.Commands[0].ExecuteDataTable();

            }


            DataRow[] dr;
            dr = dtAppSettings.Select("Key='UPL_POS_FOX'");
            if (dr.Length > 0)
            {
                if (!Convert.ToBoolean(dr[0]["Value"].ToString()))
                {

                    uploadToolStripMenuItem2.Visible = false;

                }

            }

            dr = dtAppSettings.Select("Key='COCKPIT'");
            if (dr.Length > 0)
            {
                if (!Convert.ToBoolean(dr[0]["Value"].ToString()))
                {

                    uploadToolStripMenuItem.Visible = false;

                }

            }

            dr = dtAppSettings.Select("Key='DWN_VACCDO_POS'");
            if (dr.Length > 0)
            {
                if (!Convert.ToBoolean(dr[0]["Value"].ToString()))
                {

                    downloadVACCDOPOSToolStripMenuItem.Visible = false;

                }

            }


            dr = dtAppSettings.Select("Key='DWN_VACCDO_POS_CBG'");
            if (dr.Length > 0)
            {
                if (!Convert.ToBoolean(dr[0]["Value"].ToString()))
                {

                    downloadVToolStripMenuItem.Visible = false;

                }

            }

            dr = dtAppSettings.Select("Key='UPL_VACCDO_POS'");
            if (dr.Length > 0)
            {
                if (!Convert.ToBoolean(dr[0]["Value"].ToString()))
                {

                    uploadVACCDOPOSToolStripMenuItem.Visible = false;

                }

            }

            dr = dtAppSettings.Select("Key='UPL_VACCDO_POS_CBG'");
            if (dr.Length > 0)
            {
                if (!Convert.ToBoolean(dr[0]["Value"].ToString()))
                {

                    uploadVACCDOPOSCBGToolStripMenuItem.Visible = false;

                }

            }

        }

        private void PerformSecurityCheck()
        {
            administrasiToolStripMenuItem.Enabled = false;
            masterToolStripMenuItem.Enabled = false;
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                CheckMenuAuthorization(item);
                GetSubMenu(item);
            }
        }

        private void GetSubMenu(ToolStripMenuItem current)
        {
            foreach (Object item in current.DropDownItems)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menu = (ToolStripMenuItem)item;
                    if (!SecurityManager.IsManager() && !SecurityManager.IsAdministrator())
                    {
                        CheckMenuAuthorization(menu);
                    }
                    GetSubMenu(menu);
                }
            }

        }

        private void CheckMenuAuthorization(ToolStripMenuItem item)
        {
            if (item.Tag != null)
            {
                if (item.Tag.ToString() != "")
                {
                    string partID = item.Tag.ToString();
                    if (!SecurityManager.HasPart(partID))
                    {
                        item.Visible = false;
                    }
                    else
                    {
                        item.Visible = true;
                    }
                }
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ifrmChild = new frmChangePassword();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SecurityManager.SetUserLogin(SecurityManager.UserID, false);

            SecurityManager.LogOut();

            this.Close();
            Program.LoginForm.AskLogin();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SecurityManager.SetUserLogin(SecurityManager.UserID, false);
            Application.Exit();
        }

        private void cabangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmCabangBrowse ifrmChild = new Master.frmCabangBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void gudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmGudangBrowse ifrmChild = new Master.frmGudangBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tujuanExpedisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTujuanExpedisiBrowse ifrmChild = new Master.frmTujuanExpedisiBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pemasokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmPemasokBrowse ifrmChild = new Master.frmPemasokBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void expedisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmExpedisiBrowse ifrmChild = new Master.frmExpedisiBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void checkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmCheckerBrowse ifrmChild = new Master.frmCheckerBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void sopirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmSopirBrowse ifrmChild = new Master.frmSopirBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void stafPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmStafPenjualanBrowser ifrmChild = new Master.frmStafPenjualanBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmSalesBrowser ifrmChild = new Master.frmSalesBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void kelompokBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmKelompokBarangBrowse ifrmChild = new Master.frmKelompokBarangBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void kodePosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmKodePosBrowse ifrmChild = new Master.frmKodePosBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void kolektorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmKolektorBrowse ifrmChild = new Master.frmKolektorBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        public void RegisterChild(Control iform)
        {
            //this.pnlMain.ContentPanel.Controls.Add(iform);
        }

        private void penanggungJawabRakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmPenanggungjawabRakBrowse ifrmChild = new Master.frmPenanggungjawabRakBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void identitasPerusahaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmIdentitasPerusahaan ifrmChild = new Administrasi.frmIdentitasPerusahaan();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void masterStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmMasterStokBrowse ifrmChild = new Master.frmMasterStokBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void frmRTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRTest ifrmChild = new frmRTest();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void lookUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmLookupBrowse ifrmChild = new Master.frmLookupBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmHPPBrowse ifrmChild = new Master.frmHPPBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTokoBrowse ifrmChild = new Master.frmTokoBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void syncronizeDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSyncDownloadBrowse ifrmChild = new Administrasi.frmSyncDownloadBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void syncronizeUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSyncUploadBrowse ifrmChild = new Administrasi.frmSyncUploadBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void stockLookUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmRightsBrowse ifrmChild = new Master.frmRightsBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void setNumeratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmNumeratorBrowse ifrmChild = new Penjualan.frmNumeratorBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dataBMKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmFoxproDownloader ifrmChild = new Communicator.frmFoxproDownloader(ISA.Toko.Communicator.frmFoxproDownloader.enDownloadType.BMK);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void packingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ekspedisi.frmPackingListBrowse ifrmChild = new Ekspedisi.frmPackingListBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapKoliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expedisi.frmRekapKoliBrowse ifrmChild = new Expedisi.frmRekapKoliBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPreferences ifrmChild = new frmPreferences();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void statusTokoOtomatisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmStatusTokoUpload11 ifrmChild = new Communicator.frmStatusTokoUpload11();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pengirimanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            xpdc.frm_kirim ifrmChild = new xpdc.frm_kirim();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
       }

        private void dataHPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmFoxproDownloader ifrmChild = new Communicator.frmFoxproDownloader(ISA.Toko.Communicator.frmFoxproDownloader.enDownloadType.HPP);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void dataSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmFoxproDownloader ifrmChild = new Communicator.frmFoxproDownloader(ISA.Toko.Communicator.frmFoxproDownloader.enDownloadType.Sales);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void dataTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmFoxproDownloader ifrmChild = new Communicator.frmFoxproDownloader(ISA.Toko.Communicator.frmFoxproDownloader.enDownloadType.Toko);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void dataStatusTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmFoxproDownloader ifrmChild = new Communicator.frmFoxproDownloader(ISA.Toko.Communicator.frmFoxproDownloader.enDownloadType.StatusToko);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void dataStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Communicator.frmFoxproDownloader ifrmChild = new Communicator.frmFoxproDownloader(ISA.Trading.Communicator.frmFoxproDownloader.enDownloadType.Stock);
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.MinimizeBox = false;
            //ifrmChild.Show();
            Master.frmMasterStokDownload ifrmChild = new Master.frmMasterStokDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PJ3.frmPJ3Browser ifrmChild = new PJ3.frmPJ3Browser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transaksiToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            RJ3.frmRJ3Browser ifrmChild = new RJ3.frmRJ3Browser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transaksiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RJ3.frmRJ3Browser ifrmChild = new RJ3.frmRJ3Browser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void penyelesaianKirimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Expedisi.frmPenyelesaianEkspedisiBrowse ifrmChild = new Expedisi.frmPenyelesaianEkspedisiBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pengajuanHargaDOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmDOUpload11 ifrmChild = new Communicator.frmDOUpload11();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapKoliToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Expedisi.frmRptRekapKoliFilter ifrmChild = new Expedisi.frmRptRekapKoliFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapCheckerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expedisi.frmRptRekapChecker ifrmChild = new Expedisi.frmRptRekapChecker();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void buktiPenyerahanBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expedisi.frmRptBuktiPenyerahanBarang ifrmChild = new Expedisi.frmRptBuktiPenyerahanBarang();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapPenyelesaianPackingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expedisi.frmRptRekapanPenyPackingList ifrmChild = new Expedisi.frmRptRekapanPenyPackingList();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void penjualanTunaiKreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expedisi.frmRptPenjualanTunaiKreditFilter ifrmChild = new Expedisi.frmRptPenjualanTunaiKreditFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapKoliToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Expedisi.frmRptRekapKoliFilter2 ifrmChild = new Expedisi.frmRptRekapKoliFilter2();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dalamKotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expedisi.frmRptExpDalamKotaFilter ifrmChild = new Expedisi.frmRptExpDalamKotaFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void luarKotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expedisi.frmRptExpLuarKotaFilter ifrmChild = new Expedisi.frmRptExpLuarKotaFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapEkspedisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expedisi.frmRptRekapExpedisiFilter ifrmChild = new Expedisi.frmRptRekapExpedisiFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rugiLabaEkspedisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expedisi.frmRptEkspedisiRugiLaba ifrmChild = new Expedisi.frmRptEkspedisiRugiLaba();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void suratJalanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expedisi.frmRptEkspedisiSuratJalan ifrmChild = new Expedisi.frmRptEkspedisiSuratJalan();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void ekspedisiPerHariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expedisi.frmRptEkspedisiPerHari ifrmChild = new Expedisi.frmRptEkspedisiPerHari();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void aCCDOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dOBelumACCToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dOACCSebagianToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dOACCSemuaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dOTolakACCToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dOTolakACCDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void penyimpanganACCToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void analisaAuditAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SecurityManager.State == SecurityManager.enState.LogIn)
            {
                SecurityManager.SetUserLogin(SecurityManager.UserID, false);
                Application.Exit();
            }
            else
            {
                Program.LoginForm.AskLogin();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (SecurityManager.State == SecurityManager.enState.LogIn)
            {
                SecurityManager.AddCounter();
                if (SecurityManager.TimeOutCounter >= Config.TimeOutLimit)
                {
                    //SecurityManager.LogOut();
                    //Program.LoginForm.AskLogin();
                    logOutToolStripMenuItem.PerformClick();
                }
            }

            //if (!SecurityManager.IsManager())
            //    administrasiToolStripMenuItem.DropDownItems["securityToolStripMenuItem"].Enabled = false;
            //else
            //    administrasiToolStripMenuItem.DropDownItems["securityToolStripMenuItem"].Enabled = true;

        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            SecurityManager.ResetCounter();
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            SecurityManager.ResetCounter();
            if (e.KeyChar == (Char)Keys.J && Control.ModifierKeys==Keys.Control)
            {
                POS.FrmPOS ifrmChild = new POS.FrmPOS();
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show(); 
            }
            else if (e.KeyChar == (Char)Keys.D && Control.ModifierKeys == Keys.Control)
            {
                DO.FrmDO ifrmChild = new DO.FrmDO(null);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();

            }
            else if (e.KeyChar == (Char)Keys.B && Control.ModifierKeys == Keys.Control)
            {
                Pembelian.frmDOBeliBrowser ifrmChild = new Pembelian.frmDOBeliBrowser();
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ArusStock.frmMutasi ifrmChild = new ArusStock.frmMutasi();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void memoPeminjmanBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArusStock.frmPeminjaman ifrmChild = new ArusStock.frmPeminjaman();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void memoBarangKeluarDariGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArusStock.frmBarangKeluar ifrmChild = new ArusStock.frmBarangKeluar();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void barangKembaliKePenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArusStock.frmBarangKembaliKePenjualan ifrmChild = new ArusStock.frmBarangKembaliKePenjualan();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void barangDiterimaGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArusStock.frmBarangKembaliKeGudang ifrmChild = new ArusStock.frmBarangKembaliKeGudang();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ArusStock.frmRptMutasi ifrmChild = new ArusStock.frmRptMutasi();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapMutasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArusStock.frmRptMutasiRekap ifrmChild = new ArusStock.frmRptMutasiRekap();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void registerMutasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArusStock.frmRptMutasiRegister ifrmChild = new ArusStock.frmRptMutasiRegister();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void pinjamanJatuhTempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArusStock.frmRptPeminjamanJatuhTempo ifrmChild = new ArusStock.frmRptPeminjamanJatuhTempo();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void antarGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArusStock.frmAntarGudang ifrmChild = new ArusStock.frmAntarGudang();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void bedaKirimTerimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArusStock.frmRptAntarGudangPerbedaanQty ifrmChild = new ArusStock.frmRptAntarGudangPerbedaanQty();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hppToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ArusStock.frmRptAntarGudangHPP ifrmChild = new ArusStock.frmRptAntarGudangHPP();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void aGBelumDiterimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArusStock.frmRptAntarGudangBelumDiterima ifrmChild = new ArusStock.frmRptAntarGudangBelumDiterima();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.TabelDO ifrmChild = new Penjualan.TabelDO();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void notaJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmNotaJualBrowser ifrmChild = new Penjualan.frmNotaJualBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void backOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmBOBrowser ifrmChild = new Penjualan.frmBOBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void mPRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmMPRBrowser ifrmChild = new Penjualan.frmMPRBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void notaReturJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmNotaReturJualBrowse ifrmChild = new Penjualan.frmNotaReturJualBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void orderPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmDOBeliBrowser ifrmChild = new Pembelian.frmDOBeliBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void notaPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmNotaBeliBrowser ifrmChild = new Pembelian.frmNotaBeliBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void barangDiterimaGudangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pembelian.frmBrgDiterimaGdgBrowser ifrmChild = new Pembelian.frmBrgDiterimaGdgBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void mPRBeliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmMPRBeliBrowser ifrmChild = new Pembelian.frmMPRBeliBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void barangDiterimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmBrgDiterimaSupplierBrowser ifrmChild = new Pembelian.frmBrgDiterimaSupplierBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void stokGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmStokGudang ifrmChild = new Persediaan.frmStokGudang();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void stokOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmStokOpname ifrmChild = new Persediaan.frmStokOpname();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void aCCHargaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmDODownload ifrmChild = new Communicator.frmDODownload(ISA.Toko.Communicator.frmDODownload.enDownloadType.Data11);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void upgradeSastokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmStokOpnameUpgrade ifrmChild = new Persediaan.frmStokOpnameUpgrade();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transferOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmStokOpnameTransfer ifrmChild = new Persediaan.frmStokOpnameTransfer();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadSaldoAkhirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmStokOpnameDownload ifrmChild = new Persediaan.frmStokOpnameDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptStokTidakAdaHPP ifrmChild = new Persediaan.frmRptStokTidakAdaHPP();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void barangYgDoubleIDBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptStokDoubleBarangID ifrmChild = new Persediaan.frmRptStokDoubleBarangID();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void barangYgTidakAdaIDRecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptTidakAdaRecordID ifrmChild = new Persediaan.frmRptTidakAdaRecordID();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void barangBelum3XHitungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptStokOpnameBelum3XHitung ifrmChild = new Persediaan.frmRptStokOpnameBelum3XHitung();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void barangBelumTerOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptStokOpnameBelumTerOpname ifrmChild = new Persediaan.frmRptStokOpnameBelumTerOpname();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void perbandinganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptStokOpnameAnalisaDetail ifrmChild = new Persediaan.frmRptStokOpnameAnalisaDetail();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void infoBarangBelumTerkirimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Barang.frmInfoBarangBelumTerkirim ifrmChild = new Laporan.Barang.frmInfoBarangBelumTerkirim();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void detailOpnamePerBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptCtkDetailOpnamePerBarang ifrmChild = new Persediaan.frmRptCtkDetailOpnamePerBarang();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void detailOpnamePerKElompokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptOpnameDetailPerKelompok ifrmChild = new Persediaan.frmRptOpnameDetailPerKelompok();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void masterKosongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptMasterKosong ifrmChild = new Persediaan.frmRptMasterKosong();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void detailKosongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptDetailKosong ifrmChild = new Persediaan.frmRptDetailKosong();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void masterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptMasterPerKodeRak ifrmChild = new Persediaan.frmRptMasterPerKodeRak();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void barangBelumTerkirimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Barang.frmInfoBarangBelumTerkirim ifrmChild = new Laporan.Barang.frmInfoBarangBelumTerkirim();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void analisaHasilStokOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptOpnameAnalisa ifrmChild = new Persediaan.frmRptOpnameAnalisa();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void detailPerKodeRakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptDetailPerKodeRak ifrmChild = new Persediaan.frmRptDetailPerKodeRak();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void opnameversiGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptOpnameVersiGroup ifrmChild = new Persediaan.frmRptOpnameVersiGroup();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptOpnameDetailAll ifrmChild = new Persediaan.frmRptOpnameDetailAll();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void partsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityPartsBrowse ifrmChild = new Administrasi.frmSecurityPartsBrowse(GlobalVar.ApplicationID);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityRolesBrowse ifrmChild = new Administrasi.frmSecurityRolesBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityUsersBrowse ifrmChild = new Administrasi.frmSecurityUsersBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rightsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityRightsBrowse ifrmChild = new Administrasi.frmSecurityRightsBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityApplicationsBrowse ifrmChild = new Administrasi.frmSecurityApplicationsBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void kartuStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptStokGudangKartuStok ifrmChild = new Persediaan.frmRptStokGudangKartuStok();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void stokPerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptGudangPosisiStok ifrmChild = new Persediaan.frmRptGudangPosisiStok();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rataRataJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptStandarStokAVGJual ifrmChild = new Persediaan.frmRptStandarStokAVGJual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void stokBanyakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptStandarStokBanyak ifrmChild = new Persediaan.frmRptStandarStokBanyak();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void standarStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmStandarStok ifrmChild = new Persediaan.frmStandarStok();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void stokTipisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptStandarStokTipis ifrmChild = new Persediaan.frmRptStandarStokTipis();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void stokTipisYgBelumLinkKePBOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptStandarStokTipisBelumLink ifrmChild = new Persediaan.frmRptStandarStokTipisBelumLink();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void analisaBackOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptAnalisaBOFilter ifrmChild = new Pembelian.frmRptAnalisaBOFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void barangBelumTerpenuhiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptBrgBlmTerpenuhiFilter ifrmChild = new Pembelian.frmRptBrgBlmTerpenuhiFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void arusPembelianDanPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptArusPembDanPenjFilter ifrmChild = new Pembelian.frmRptArusPembDanPenjFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekaptulasiPembelianBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptRekapPembelianFilter ifrmChild = new Pembelian.frmRptRekapPembelianFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void arusBarangPerTanggalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptArusBarangFilter ifrmChild = new Pembelian.frmRptArusBarangFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void arusPembelianBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptArusPembelianFilter ifrmChild = new Pembelian.frmRptArusPembelianFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pembelianPerNamaBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptPembPerBarangFilter ifrmChild = new Pembelian.frmRptPembPerBarangFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void registerPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptRegisterPembFilter ifrmChild = new Pembelian.frmRptRegisterPembFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void registerKoreksiPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptRegisterKoreksiPembFilter ifrmChild = new Pembelian.frmRptRegisterKoreksiPembFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void barangBelumDiterimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptBrgBlmDiterimaFilter ifrmChild = new Pembelian.frmRptBrgBlmDiterimaFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapReturBeliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptRekapReturBeliFilter ifrmChild = new Pembelian.frmRptRekapReturBeliFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapKoreksiReturBeliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptRekapKoreksiReturBeliFilter ifrmChild = new Pembelian.frmRptRekapKoreksiReturBeliFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void returBeliPerNamaBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptReturBeliPerBarangFilter ifrmChild = new Pembelian.frmRptReturBeliPerBarangFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void registerReturBeliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptRegisterReturBeliFilter ifrmChild = new Pembelian.frmRptRegisterReturBeliFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void registerKoreksiReturBeliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptRegisterKoreksiReturBeliFilter ifrmChild = new Pembelian.frmRptRegisterKoreksiReturBeliFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void closingStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmClosingStok ifrmChild = new Persediaan.frmClosingStok();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapitulasiPenjualanDiBawahHPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptPenjualanDiBawahHPP ifrmChild = new Laporan.Salesman.frmRptPenjualanDiBawahHPP();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void perbandinganDONOtaBOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptPerbandinganDONotaBO ifrmChild = new Laporan.Salesman.frmRptPerbandinganDONotaBO();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dOBatalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptDOBatal ifrmChild = new Laporan.Salesman.frmRptDOBatal();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptDOPending ifrmChild = new Laporan.Salesman.frmRptDOPending();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapitulasiPenjualanSamaDenganHPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptPenjualanSamaDenganHPP ifrmChild = new Laporan.Salesman.frmRptPenjualanSamaDenganHPP();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void omsetPerKotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptOmzetPerKota ifrmChild = new Laporan.Salesman.frmRptOmzetPerKota();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void absensiSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptAbsensiSalesman ifrmChild = new Laporan.Salesman.frmRptAbsensiSalesman();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptPenyelesaianOrderSales ifrmChild = new Laporan.Salesman.frmRptPenyelesaianOrderSales();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptEvaluasiOmzetPerSalesman ifrmChild = new Laporan.Salesman.frmRptEvaluasiOmzetPerSalesman();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void dOBelumJadiNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptDOBelumJadiNota ifrmChild = new Laporan.Salesman.frmRptDOBelumJadiNota();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        /* Laporan > Toko  */

        private void penyelesaianOrderPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptPenyelesaianDOJualFilter ifrmChild = new Laporan.Toko.frmRptPenyelesaianDOJualFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void aCCHargaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptACCHargaFilter ifrmChild = new Laporan.Toko.frmRptACCHargaFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void aCCHargaDitolakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptACCHrgDitolakFilter ifrmChild = new Laporan.Toko.frmRptACCHrgDitolakFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pengirimanGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptPengirimanGudangFilter ifrmChild = new Laporan.Toko.frmRptPengirimanGudangFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void registerPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptRegisterPenjualanFilter ifrmChild = new Laporan.Toko.frmRptRegisterPenjualanFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void registerKoreksiPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptRegisterKoreksiJualFilter ifrmChild = new Laporan.Toko.frmRptRegisterKoreksiJualFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void registerPenjualanTunaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptRegisterPenjualanTunaiFilter ifrmChild = new Laporan.Toko.frmRptRegisterPenjualanTunaiFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void jWJSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptJWJSFilter ifrmChild = new Laporan.Toko.frmRptJWJSFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void notaYangBelumDibikinkanSuratJalanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptNotaBlmAdaSJFilter ifrmChild = new Laporan.Toko.frmRptNotaBlmAdaSJFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void notaYangSudahDibikinkanSuratJalanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptNotaSudahAdaSJFilter ifrmChild = new Laporan.Toko.frmRptNotaSudahAdaSJFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void analisaPer3BulanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptAnalisaPer3BulanFilter ifrmChild = new Laporan.Toko.frmRptAnalisaPer3BulanFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void omzetTertinggiTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptOmzetTertinggiTokoFilter ifrmChild = new Laporan.Toko.frmRptOmzetTertinggiTokoFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void omzetABETokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptOmzetABETokoFilter ifrmChild = new Laporan.Toko.frmRptOmzetABETokoFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void evaluasiPenyelesaianOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptEvaluasiPenyelesaianOrderFilter ifrmChild = new Laporan.Toko.frmRptEvaluasiPenyelesaianOrderFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void evaluasiOmzetPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptEvaluasiOmzetPosFilter ifrmChild = new Laporan.Toko.frmRptEvaluasiOmzetPosFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void analisaTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptAnalisaTokoFilter ifrmChild = new Laporan.Toko.frmRptAnalisaTokoFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapKoliMenurutToko00ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptRekapKoliMenurutToko00 ifrmChild = new Laporan.Toko.frmRptRekapKoliMenurutToko00();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapPenyelesaianPackingListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptRekapanPenyelesaianPackingList ifrmChild = new Laporan.Toko.frmRptRekapanPenyelesaianPackingList();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapReturJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptRekapReturJualFilter ifrmChild = new Laporan.Toko.frmRptRekapReturJualFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void returJualPerTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptReturJualPerTokoFilter ifrmChild = new Laporan.Toko.frmRptReturJualPerTokoFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void registerKoreksiReturJualPerKelompokBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptRegisterKoreksiReturJualFilter ifrmChild = new Laporan.Toko.frmRptRegisterKoreksiReturJualFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void analisaKunjunganSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptAnalisaKunjunganSalesFilter ifrmChild = new Laporan.Toko.frmRptAnalisaKunjunganSalesFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hargaKhususToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptHargaKhususFilter ifrmChild = new Laporan.Toko.frmRptHargaKhususFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void informasiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void informasiNotaBelumDiSelesaikanOlehCheckerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptNotaBelumDiSelesaikanOlehChecker ifrmChild = new Laporan.Salesman.frmRptNotaBelumDiSelesaikanOlehChecker();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptPenjualanDiBawahBMK ifrmChild = new Laporan.Salesman.frmRptPenjualanDiBawahBMK();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void informasiProduktifitasSalesmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptProduktifitasSalesman ifrmChild = new Laporan.Salesman.frmRptProduktifitasSalesman();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void informasiNotaBelumAdaSuratJalanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptNotaBelumAdaSuratJalan ifrmChild = new Laporan.Salesman.frmRptNotaBelumAdaSuratJalan();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void informasiNotaBelumAdaTandaTerimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptNotaBelumAdaTandaTerima ifrmChild = new Laporan.Salesman.frmRptNotaBelumAdaTandaTerima();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hPPHPPRatarataDanHargaJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Barang.frmRptHPPFilter ifrmChild = new Laporan.Barang.frmRptHPPFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapitulasiHPPPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Barang.frmInfoRptRekapHPPPenjualan ifrmChild = new Laporan.Barang.frmInfoRptRekapHPPPenjualan();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void notaJualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
    
            Laporan.Salesman.frmRptNotaJual ifrmChild = new Laporan.Salesman.frmRptNotaJual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void koreksiJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptKoreksiNotaJual ifrmChild = new Laporan.Salesman.frmRptKoreksiNotaJual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void notaReturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptReturNotaJual ifrmChild = new Laporan.Salesman.frmRptReturNotaJual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void koreksiReturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptKoreksiNotaReturJual ifrmChild = new Laporan.Salesman.frmRptKoreksiNotaReturJual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Laporan.Barang.frmDaftarPembelianCustomer ifrmChild = new ISA.Toko.Laporan.Barang.frmDaftarPembelianCustomer();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Laporan.Barang.frmAccReturJualKe11 ifrmChild = new ISA.Toko.Laporan.Barang.frmAccReturJualKe11();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            Laporan.Barang.frmRptBuktiPenyerahanBarangFilter ifrmChild = new Laporan.Barang.frmRptBuktiPenyerahanBarangFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void barangToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Laporan.Barang.frmRptTargetTokoDanSalesman ifrmChild = new Laporan.Barang.frmRptTargetTokoDanSalesman();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Laporan.Barang.frmPenjualanBarangPerItemPerkota ifrmChild = new Laporan.Barang.frmPenjualanBarangPerItemPerkota();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Laporan.Barang.FrmPenjualanItemPerKotaFilter ifrmChild = new Laporan.Barang.FrmPenjualanItemPerKotaFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void registerPenjulanPerSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptRegisterpenjulanSales ifrmChild = new Laporan.Salesman.frmRptRegisterpenjulanSales();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void registerPenjualanSalesHPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptregisterPenjualanSalesHPP ifrmChild = new Laporan.Salesman.frmRptregisterPenjualanSalesHPP();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void RegisterReturPenjualantoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptRegisterReturJual ifrmChild = new Laporan.Salesman.frmRptRegisterReturJual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            //Laporan.Barang.frmReturJualPerNamaBarangFilter ifrmChild = new Laporan.Barang.frmReturJualPerNamaBarangFilter();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            Laporan.Barang.frmRegisterJualPerKelompokBarangFilter ifrmChild = new Laporan.Barang.frmRegisterJualPerKelompokBarangFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Laporan.Barang.frmRptBackOrderFilter ifrmChild = new Laporan.Barang.frmRptBackOrderFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void RegisterReturPenjualantoolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptRegisterReturJual ifrmChild = new Laporan.Salesman.frmRptRegisterReturJual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void PenjualanBerdasrkanABEtoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptPenjualanBedasarkanABE ifrmChild = new Laporan.Salesman.frmRptPenjualanBedasarkanABE();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void RekapKoliSalestoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptRekapKoli ifrmChild = new Laporan.Salesman.frmRptRekapKoli();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void HargaKhusustoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptPenjualanHargaKhusus ifrmChild = new Laporan.Salesman.frmRptPenjualanHargaKhusus();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Laporan.Barang.frmRptGabunganSemuaOrder ifrmChild = new Laporan.Barang.frmRptGabunganSemuaOrder();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem17_Click_1(object sender, EventArgs e)
        {
            Laporan.Barang.frmReturJualPerNamaBarangFilter ifrmChild = new Laporan.Barang.frmReturJualPerNamaBarangFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapitulasiPenjualanSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptRekapitulasiPenjualanSales ifrmChild = new Laporan.Salesman.frmRptRekapitulasiPenjualanSales();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void PerbandinganDOdanRealisasiOmzetPersales_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptPerbandinganDODanRealisasiOmzetPerSalesFilter ifrmChild = new Laporan.Salesman.frmRptPerbandinganDODanRealisasiOmzetPerSalesFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tokoOrderBaruMenu_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptTokoOrderBaruFilter ifrmChild = new Laporan.Toko.frmRptTokoOrderBaruFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void riwayatHPPRata2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //HPPA.frmHPPAProses ifrmChild = new HPPA.frmHPPAProses();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void infoBarangBelumTerkirimMenu_Click(object sender, EventArgs e)
        {
            Laporan.Barang.frmInfoBarangBelumTerkirim ifrmChild = new Laporan.Barang.frmInfoBarangBelumTerkirim();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void omzetPerPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptOmzetPerPos ifrmChild = new Laporan.Salesman.frmRptOmzetPerPos();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void PenjualanHItoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptPenjualanHI ifrmChild = new Laporan.Salesman.frmRptPenjualanHI();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void fTPSyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDebugFTPSync ifrmChild = new frmDebugFTPSync();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void AnalisaSalesman_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptAnalisaSalesman ifrmChild = new Laporan.Salesman.frmRptAnalisaSalesman();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadAntarGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmAntargudangUpload ifrmChild = new Communicator.frmAntargudangUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadAntarGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmAntarGudangDownload ifrmChild = new Communicator.frmAntarGudangDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadTransaksiToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Communicator.frmPenjualanDOUpload00 ifrmChild = new Communicator.frmPenjualanDOUpload00();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadTransaksiDari00ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmPenjualanDODownload00 ifrmChild = new Communicator.frmPenjualanDODownload00();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmPembelianUpload ifrmChild = new Communicator.frmPembelianUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadReturPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmReturPembelianUpload ifrmChild = new Communicator.frmReturPembelianUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Communicator.frmCockpitUpload ifrmChild = new Communicator.frmCockpitUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Communicator.frmOrderPembelianDownload ifrmChild = new Communicator.frmOrderPembelianDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmNotaPembelianDownload ifrmChild = new Communicator.frmNotaPembelianDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadPembelianAntarCabangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmNotaPembelianDownloadAntarCabang ifrmChild = new Communicator.frmNotaPembelianDownloadAntarCabang();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadDataKe11Menu_Click(object sender, EventArgs e)
        {
            Communicator.frmPenjualanNotaUpload11 ifrmChild = new Communicator.frmPenjualanNotaUpload11();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadDataKeC1Menu_Click(object sender, EventArgs e)
        {
            Communicator.frmPenjualanNotaUploadC1 ifrmChild = new Communicator.frmPenjualanNotaUploadC1();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadDariC2Menu_Click(object sender, EventArgs e)
        {
            Communicator.frmPenjualanNotaDownloadC2 ifrmChild = new Communicator.frmPenjualanNotaDownloadC2();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Communicator.frmPotonganUpload ifrmChild = new Communicator.frmPotonganUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Communicator.frmPotonganDownload ifrmChild = new Communicator.frmPotonganDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transaksiToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            //Communicator.frmFoxproDownloader ifrmChild = new Communicator.frmFoxproDownloader(ISA.Trading.Communicator.frmFoxproDownloader.enDownloadType.Stock);
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.MinimizeBox = false;
            //ifrmChild.Show();
            PJ3.frmPJ3Browser ifrmChild = new PJ3.frmPJ3Browser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void transaksiToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            RJ3.frmRJ3Browser ifrmChild = new RJ3.frmRJ3Browser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transaksiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            VACCDO.frmACCDOBrowse ifrmChild = new VACCDO.frmACCDOBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dOBelumACCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VACCDO.frmRptDOBlmACCFilter ifrmChild = new VACCDO.frmRptDOBlmACCFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dOACCSemuaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VACCDO.frmRptDOFullACCFilter ifrmChild = new VACCDO.frmRptDOFullACCFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dOACCSebagianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VACCDO.frmRptDOHalfACCFilter ifrmChild = new VACCDO.frmRptDOHalfACCFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dOTolakACCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VACCDO.frmRptDOTolakACCFilter ifrmChild = new VACCDO.frmRptDOTolakACCFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dOTolakACCDetailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VACCDO.frmRptDOTolakACCDetailFilter ifrmChild = new VACCDO.frmRptDOTolakACCDetailFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void penyimpanganACCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VACCDO.frmRptACCDeviationFilter ifrmChild = new VACCDO.frmRptACCDeviationFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void analisaAuditACCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VACCDO.frmRptAnalisaAuditFilter ifrmChild = new VACCDO.frmRptAnalisaAuditFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void penjualanPotonganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmRptPenjualanPotongan ifrmChild = new Penjualan.frmRptPenjualanPotongan();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void goodInTransitMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmLaporanGoodInTransit ifrmChild = new Penjualan.frmLaporanGoodInTransit();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanInputSerahTerimaMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmLaporanInputTanggalTerima ifrmChild = new Penjualan.frmLaporanInputTanggalTerima();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanNotaNotaAnakCabangMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmLaporanNotaAnakCabang ifrmChild = new Penjualan.frmLaporanNotaAnakCabang();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void stockLookUpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDebug2 ifrmChild = new frmDebug2();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void stockLookUpToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            frmDebug2 ifrmChild = new frmDebug2();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmPOSDownload ifrmChild = new Communicator.frmPOSDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Communicator.frmCockpitDownload ifrmChild = new Communicator.frmCockpitDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Communicator.frmPOSSUpload ifrmChild = new Communicator.frmPOSSUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Communicator.frmPOSDownload ifrmChild = new Communicator.frmPOSDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void potonganToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Penjualan.frmPenjualanPotonganBrowser ifrmChild = new Penjualan.frmPenjualanPotonganBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void sIPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SIP.frmSIPBrowse ifrmChild = new SIP.frmSIPBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            VLapW.frmKoliToneBrowse ifrmChild = new VLapW.frmKoliToneBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            VLapW.frmWilayahBrowse ifrmChild = new VLapW.frmWilayahBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            VLapW.frmRptVLapWPenjualanOliPerWilayah ifrmChild = new VLapW.frmRptVLapWPenjualanOliPerWilayah();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            VLapW.frmRptOmzetHarian ifrmChild = new VLapW.frmRptOmzetHarian();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            VLapW.frmRptOmzetPerWilayahDetail ifrmChild = new VLapW.frmRptOmzetPerWilayahDetail();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            VLapW.frmRptLapBrgA ifrmChild = new VLapW.frmRptLapBrgA();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            VLapW.frmRptRekapPembayaranDanPenjualan ifrmChild = new VLapW.frmRptRekapPembayaranDanPenjualan();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            LapKpl.frmTargetSalesBrowser ifrmChild = new LapKpl.frmTargetSalesBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
            LapKpl.frmRptTargetSales ifrmChild = new LapKpl.frmRptTargetSales();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmHPPABrowse ifrmChild = new Master.frmHPPABrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HPPA.frmHPPAProses ifrmChild = new HPPA.frmHPPAProses();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            VWil.frmRiwayatIDWilBrowse ifrmChild = new VWil.frmRiwayatIDWilBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadDariPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmHPPRataRataDownload ifrmChild = new Communicator.frmHPPRataRataDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadKePOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmHPPRataRataUpload ifrmChild = new Communicator.frmHPPRataRataUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapReturJualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RJ3.frmRptRekapReturJual ifrmChild = new RJ3.frmRptRekapReturJual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapReturJualPerTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RJ3.frmRptRekapReturJualPerToko ifrmChild = new RJ3.frmRptRekapReturJualPerToko();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapReturJualPerBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RJ3.frmRptReturJualPerBarang ifrmChild = new RJ3.frmRptReturJualPerBarang();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapReturJualPenyelesainyaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RJ3.frmRptRekapReturJualDanPenyelesainya ifrmChild = new RJ3.frmRptRekapReturJualDanPenyelesainya();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void returBelumLinkKePiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RJ3.frmRptReturBelumLinkKePiutang ifrmChild = new RJ3.frmRptReturBelumLinkKePiutang();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dODownloadPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmPenjualanDODownloadPos ifrmChild = new Penjualan.frmPenjualanDODownloadPos();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dOUploadPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmPenjualanDOUploadPos ifrmChild = new Penjualan.frmPenjualanDOUploadPos();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transaksiToolStripMenuItem1_Click_2(object sender, EventArgs e)
        {
            VACCDO_Pos.frmACCDOPosBrowse ifrmChild = new VACCDO_Pos.frmACCDOPosBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void penyimpanganACCToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            VACCDO_Pos.frmRptACCDeviationFilterPos ifrmChild = new VACCDO_Pos.frmRptACCDeviationFilterPos();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void doBelumACCToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            VACCDO_Pos.frmRptDOBlmACCFilterPos ifrmChild = new VACCDO_Pos.frmRptDOBlmACCFilterPos();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dOACCSemuaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            VACCDO_Pos.frmRptDOFullACCFilterPos ifrmChild = new VACCDO_Pos.frmRptDOFullACCFilterPos();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void sIPToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SIP.frmSIPBrowse ifrmChild = new SIP.frmSIPBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dOTolakACCToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            VACCDO_Pos.frmRptDOTolakACCFilterPos ifrmChild = new VACCDO_Pos.frmRptDOTolakACCFilterPos();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void stokOpnameToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Master.frmStokOpnameBrowse ifrmChild = new Master.frmStokOpnameBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void sistemInformasiDanPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SIP.frmSIPBrowse ifrmChild = new SIP.frmSIPBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void confirmationUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmCockpitConfirm ifrmChild = new Communicator.frmCockpitConfirm();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void dOTolakACCDetailToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            VACCDO_Pos.frmRptDOTolakACCDetailFilterPos ifrmChild = new VACCDO_Pos.frmRptDOTolakACCDetailFilterPos();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void analisaAuditACCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VACCDO_Pos.frmRptAnalisaAuditFilterPos ifrmChild = new VACCDO_Pos.frmRptAnalisaAuditFilterPos();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tabulasiBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bonus.frmTabulasiBarangBrowser ifrmChild = new Bonus.frmTabulasiBarangBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pengajuanBonusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bonus.frmPengajuanBonusBrowser ifrmChild = new Bonus.frmPengajuanBonusBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tabelPerolehanBonusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bonus.frmPerolehanBonusBrowser ifrmChild = new Bonus.frmPerolehanBonusBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void prosesDataBonusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bonus.frmRptProsesDataBonusFilter ifrmChild = new Bonus.frmRptProsesDataBonusFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hargaJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmHargaJual ifrmChild = new Master.frmHargaJual();
            ifrmChild.MdiParent = Program.MainForm;
            ifrmChild.WindowState = FormWindowState.Maximized;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dumpUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmDumpUpload ifrmChild = new Communicator.frmDumpUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadToPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmPenjualanDOUploadPos ifrmChild = new Penjualan.frmPenjualanDOUploadPos();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadDariPosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Penjualan.frmPenjualanDODownloadPos ifrmChild = new Penjualan.frmPenjualanDODownloadPos();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void perhitunganBonusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bonus.frmRptPerhitunganBonusFilter ifrmChild = new Bonus.frmRptPerhitunganBonusFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transferDataPengajuanBonusKe11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bonus.frmTransferDataPengajuanFilter ifrmChild = new Bonus.frmTransferDataPengajuanFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadPengajuanKe11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmBonusPengajuanKe11Upload ifrmChild = new Communicator.frmBonusPengajuanKe11Upload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadPengajuanDari11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmBonusPengajuanDari11Download ifrmChild = new Communicator.frmBonusPengajuanDari11Download();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadDataBonusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmBonusDataDownload ifrmChild = new Communicator.frmBonusDataDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmCockpitRestore ifrmChild = new Communicator.frmCockpitRestore();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dumpUploadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Communicator.frmDumpUpload ifrmChild = new Communicator.frmDumpUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pJTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PJT.frmPJTBrowser ifrmChild = new PJT.frmPJTBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
            Penjualan.frmRptPenjualanPotongan ifrmChild = new Penjualan.frmRptPenjualanPotongan();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dataKasirPiutangPendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmFoxproInjector ifrmChild = new Penjualan.frmFoxproInjector();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void backOrderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Communicator.frmBackOrderUpload ifrmChild = new ISA.Toko.Communicator.frmBackOrderUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pajakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmUploadPajak ifrmChild = new ISA.Toko.Communicator.frmUploadPajak();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void fTagihToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmFTagihBrowser ifrmChild = new ISA.Toko.Penjualan.frmFTagihBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void koreksiRJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KoreksiReturJual.frmKoreksiReturJualTKBrowser ifrmChild = new KoreksiReturJual.frmKoreksiReturJualTKBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmSendFile ifrmChild = new CommunicatorISA.frmSendFile();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void bonusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void downloadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmDownloadFile ifrmChild = new CommunicatorISA.frmDownloadFile();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void downloadManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmDownloadManual ifrmChild = new CommunicatorISA.frmDownloadManual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dataViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmDataViewer ifrmChild = new CommunicatorISA.frmDataViewer();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmSendFile ifrmChild = new CommunicatorISA.frmSendFile();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmDownloadFile ifrmChild = new CommunicatorISA.frmDownloadFile();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadManualISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmDownloadManual ifrmChild = new CommunicatorISA.frmDownloadManual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dataViewerISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmDataViewer ifrmChild = new CommunicatorISA.frmDataViewer();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadINPMANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmPersediaanUploadINPMAN ifrmChild = new Communicator.frmPersediaanUploadINPMAN();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void uploadISAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmUploadHPPA ifrmChild = new CommunicatorISA.frmUploadHPPA();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadFileISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmISADownloadFTP ifrmChild = new CommunicatorISA.frmISADownloadFTP();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadManualISAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmISADownloadManual ifrmChild = new CommunicatorISA.frmISADownloadManual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void closingPJTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Finance.frmClosingPJTools ifrmChild = new Finance.frmClosingPJTools();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadKoreksiPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmKoreksiPembelianDownload ifrmChild = new Communicator.frmKoreksiPembelianDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void penjualanBOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmLaporanPembelianBO ifrmChild = new Penjualan.frmLaporanPembelianBO();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void selisihPengakuanPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptSelishPengakuanPembelian ifrmChild = new Pembelian.frmRptSelishPengakuanPembelian();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadAntarGudangISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmAntarGudangUpload ifrmChild = new CommunicatorISA.frmAntarGudangUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadAntarGudangISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.AntarGudangDownload ifrmChild = new CommunicatorISA.AntarGudangDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void memoReturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmRptPengajuanRetur ifrmChild = new Pembelian.frmRptPengajuanRetur();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transaksiISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PJ3.frmPJ3BrowserISA ifrmChild = new PJ3.frmPJ3BrowserISA();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pJTISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PJT.frmPJTBrowserISA ifrmChild = new PJT.frmPJTBrowserISA();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void potonganISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmPenjualanPotonganBrowserISA ifrmChild = new Penjualan.frmPenjualanPotonganBrowserISA();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transaksiISAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VACCDO.frmACCDOBrowseISA ifrmChild = new VACCDO.frmACCDOBrowseISA();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transaksiISAToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            VACCDO_Pos.frmACCDOPosBrowseISA ifrmChild = new VACCDO_Pos.frmACCDOPosBrowseISA();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void returopacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rsopac.frmRsReturUpload ifrmChild = new Rsopac.frmRsReturUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rSOPACToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rsopac.frmRsUpload ifrmChild = new Rsopac.frmRsUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmDOAntarCabangUpload ifrmChild = new CommunicatorISA.frmDOAntarCabangUpload();
            ifrmChild.Show();

            //Rsopac.frmRsUpload ifrmChild = new Rsopac.frmRsUpload();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void uploadKe11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rsopac.frmRsReturUpload ifrmChild = new Rsopac.frmRsReturUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadISAToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmPosUpload ifrmChild = new CommunicatorISA.frmPosUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanStandarStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmRptStandarStok ifrmChild = new Persediaan.frmRptStandarStok();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadISAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmPosDownload ifrmChild = new CommunicatorISA.frmPosDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dataTokoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmDownloMasterData ifrmChild = new CommunicatorISA.frmDownloMasterData();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dataMasterFTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmDownloadMasterDataFTP ifrmChild = new CommunicatorISA.frmDownloadMasterDataFTP();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem41_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmTokoAktif2 ifrmChild = new Laporan.Toko.frmTokoAktif2();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadKoreksiPembelianDevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmISAKPBdownload ifrmChild = new CommunicatorISA.frmISAKPBdownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void exportDataPenunjangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmExportDataPenunjang ifrmChild = new Communicator.frmExportDataPenunjang();
            ifrmChild.Show();
        }

        private void uploadAntarGudangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmAntarGudangUpload ifrmChild = new CommunicatorISA.frmAntarGudangUpload();
            ifrmChild.Show();
        }

        private void uploadDOAntarCabangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmDOAntarCabangUpload ifrmChild = new CommunicatorISA.frmDOAntarCabangUpload();
            ifrmChild.Show();
        }

        private void uploadNotaAntarCabangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CommunicatorISA.frmNotaAntarCabang ifrmChild = new CommunicatorISA.frmNotaAntarCabang();
            CommunicatorISA.frmUploadRSOPAC ifrmChild = new CommunicatorISA.frmUploadRSOPAC();
            ifrmChild.Show();
        }

        private void uploadPotonganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmPotonganUpload ifrmChild = new CommunicatorISA.frmPotonganUpload();
            ifrmChild.Show();
        }

        private void uploadNotaPembelianAntarCabangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.NotaPembelianAntarCabang ifrmChild = new CommunicatorISA.NotaPembelianAntarCabang();
            ifrmChild.Show();
        }

        private void fTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmDownloadDataISA ifrmChild = new CommunicatorISA.frmDownloadDataISA();
            ifrmChild.Show();
        }

        private void uploadPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CommunicatorISA.frmPosUpload ifrmChild = new CommunicatorISA.frmPosUpload();
            CommunicatorISA.frmNewPosUpload ifrmChild = new CommunicatorISA.frmNewPosUpload();
            ifrmChild.Show();
        }

        private void uploadHPPAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmUploadHPPA ifrmChild = new CommunicatorISA.frmUploadHPPA();
            ifrmChild.Show();
        }

        private void uploadVACCDOPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmUploadVcAccDOPos ifrmChild = new CommunicatorISA.frmUploadVcAccDOPos();
            ifrmChild.Show();
        }

        private void uploadINPMANToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void downloadVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmDownloadVAccDOPosCBG ifrmChild = new CommunicatorISA.frmDownloadVAccDOPosCBG();
            ifrmChild.Show();
        }

        private void uploadVACCDOPOSCBGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmUploadVAccDOPosCBG ifrmChild = new CommunicatorISA.frmUploadVAccDOPosCBG();
            ifrmChild.Show();
        }

        private void downloadVACCDOPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmDownloadVAccDOPos ifrmChild = new CommunicatorISA.frmDownloadVAccDOPos();
            ifrmChild.Show();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicatorISA.frmDownloadDataISA_Manual ifrmChild = new CommunicatorISA.frmDownloadDataISA_Manual();
            ifrmChild.Show();
        }

        private void returJualHIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem42_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptReturJualHI ifrmChild = new Laporan.Salesman.frmRptReturJualHI();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadINPMANToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            CommunicatorISA.frmUploadINPMAN ifrmChild = new CommunicatorISA.frmUploadINPMAN();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void targetSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTargetSales ifrmChild = new Master.frmTargetSales();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void budgetPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.FrmBudgetPembelian ifrmChild = new Master.FrmBudgetPembelian();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void targetCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTargetCollector ifrmChild = new Master.frmTargetCollector();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rencanaKunjunganSalesmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmRencKunjSalesBrowser ifrmChild = new Penjualan.frmRencKunjSalesBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void targetTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTargetToko ifrmChild = new Master.frmTargetToko();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void promoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Master.frmPromo ifrmChild = new Master.frmPromo();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();

            Master.frmMasterPromo ifrmChild = new Master.frmMasterPromo();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void targetKotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTargetKotaBrowse ifrmChild = new Master.frmTargetKotaBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void salesmanScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Laporan.Salesman.frmRptSalesmanScore ifrmChild = new Laporan.Salesman.frmRptSalesmanScore();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void downloadToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Rsopac.frmRsDownload ifrmChild = new Rsopac.frmRsDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void salesmanScoreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Laporan.Analisa.frmRptSalesmanScore ifrmChild = new Laporan.Analisa.frmRptSalesmanScore();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void budgetPembelianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Laporan.Analisa.frmBudgetPembelian ifrmChild = new Laporan.Analisa.frmBudgetPembelian();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pOSToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
            POS.FrmPOS ifrmChild = new POS.FrmPOS();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show(); 
           
        }

        private void Laporan_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void antarGudangToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PO.frmPO ifrmChild = new PO.frmPO();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tabelPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POS.FrmTabelPOS ifrmChild = new POS.FrmTabelPOS();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();


            //POS.FrmTabelPOS  ifrmChild = new POS.FrmTabelPOS ();

            //    PO.frmPO ifrmChild = new PO.frmPO();
            //    ifrmChild.MdiParent = Program.MainForm;
            //    Program.MainForm.RegisterChild(ifrmChild);
            //    ifrmChild.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void masterToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void CIntiTooStripMenuItem_Click(object sender, EventArgs e)
        {
            CSM.frmMasterCustomerInti ifrmChild = new CSM.frmMasterCustomerInti("Customer Inti", "INTI");

            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POS.Laporan.FrmPOSLaporan ifrmChild = new POS.Laporan.FrmPOSLaporan();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void samplingOpnameHarianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmStokOpname ifrmChild = new Persediaan.frmStokOpname();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void BengkeltoolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tabelMekanikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bengkel.Master.frmMekanikBrowse ifrmChild = new Bengkel.Master.frmMekanikBrowse();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void refilPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PO.frmPO ifrmChild = new PO.frmPO();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tabelJenisMotorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bengkel.Master.frmMotorBrowse ifrmChild = new Bengkel.Master.frmMotorBrowse();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void tabelMotorCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bengkel.Master.frmCustomerBrowse ifrmChild = new Bengkel.Master.frmCustomerBrowse();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void serviceSPMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bengkel.Transaksi.frmServiceBrowser ifrmChild = new Bengkel.Transaksi.frmServiceBrowser();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void tabelStandarServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bengkel.Master.frmStandarServiceBrowse ifrmChild = new Bengkel.Master.frmStandarServiceBrowse();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void pembelianSparepartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bengkel.Transaksi.frmPembelianBrowser ifrmChild = new Bengkel.Transaksi.frmPembelianBrowser();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void pINGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dOToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //DO.FrmDO ifrmChild = new DO.FrmDO();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void tabelSchedulePOPENGIRIMANBAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PO.frmJadwalPO ifrmChild = new PO.frmJadwalPO();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanREFILLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PO.frmLaporanRefilPO ifrmChild = new PO.frmLaporanRefilPO();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void entryDOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DO.FrmDO ifrmChild = new DO.FrmDO(null);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void refilPOToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PO.frmPO ifrmChild = new PO.frmPO();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void samplingOpnameHarianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.frmStokOpnameBrowse ifrmChild = new Master.frmStokOpnameBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanRefilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PO.frmLaporanRefilPO ifrmChild = new PO.frmLaporanRefilPO();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tabelSchedulePOPengirimanBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PO.frmJadwalPO ifrmChild = new PO.frmJadwalPO();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void customerBenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bengkel.Master.frmCustomerBrowse ifrmChild = new Bengkel.Master.frmCustomerBrowse();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void memberBengkelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mekanikBengkelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bengkel.Master.frmMekanikBrowse ifrmChild = new Bengkel.Master.frmMekanikBrowse();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void motorBengkelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bengkel.Master.frmMotorBrowse ifrmChild = new Bengkel.Master.frmMotorBrowse();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void standarServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bengkel.Master.frmStandarServiceBrowse ifrmChild = new Bengkel.Master.frmStandarServiceBrowse();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void serviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bengkel.Transaksi.frmServiceBrowser ifrmChild = new Bengkel.Transaksi.frmServiceBrowser();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void pembelianDariLuarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bengkel.Transaksi.frmPembelianBrowser ifrmChild = new Bengkel.Transaksi.frmPembelianBrowser();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void StokPartTollStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmStokPartBrowse ifrmChild = new Master.frmStokPartBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void StokBarcodeTollStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmStokBarcode ifrmChild = new Master.frmStokBarcode();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void masterAreaKecamatanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixrute.frmMasterArea ifrmChild = new Fixrute.frmMasterArea();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void masterOutletBaruBlmTerdaftarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixrute.frmMasterOutletBaru ifrmChild = new Fixrute.frmMasterOutletBaru();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void masterRencanaKunjunganFixrouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixrute.frmFixRuteSalesman ifrmChild = new Fixrute.frmFixRuteSalesman();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void CollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AKC.frmMasterCollector ifrmChild = new AKC.frmMasterCollector();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void kunjunganSalesmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixrute.frmKunjunganSalesman ifrmChild = new Fixrute.frmKunjunganSalesman();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void monitoringFixruteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixrute.frmMonitoringFixrute ifrmChild = new Fixrute.frmMonitoringFixrute();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem43_Click(object sender, EventArgs e)
        {
            Fixrute.frmRptMonitoringFixruteSalesman ifrmChild = new Fixrute.frmRptMonitoringFixruteSalesman();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem44_Click(object sender, EventArgs e)
        {
            Fixrute.frmRptKunjunganSales ifrmChild = new Fixrute.frmRptKunjunganSales();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanOmsetPerKelompokBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSM.frmLaporanOmsetPekelompok ifrmChild = new CSM.frmLaporanOmsetPekelompok();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanOmsetPerKendaraaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSM.frmLaporanOmsetPerKendaraan ifrmChild = new CSM.frmLaporanOmsetPerKendaraan();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanAnalisisOmsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSM.frmLaporanAnalisisOmset ifrmChild = new CSM.frmLaporanAnalisisOmset();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void entryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AKC.frmEntryKunjunganCollector ifrmChild = new AKC.frmEntryKunjunganCollector();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanHasilKunjunganCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AKC.LaporanHasilKunjunganCollector ifrmChild = new AKC.LaporanHasilKunjunganCollector();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tabelMistraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSM.frmMasterCustomerInti ifrmChild = new CSM.frmMasterCustomerInti("Mitra PS", "MITRAPS");

            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

            //CSM.frmMasterMitraPS ifrmChild = new CSM.frmMasterMitraPS();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void tableMitraSASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSM.frmMasterCustomerInti ifrmChild = new CSM.frmMasterCustomerInti("Mitra SAS", "MITRASAS");

            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

            //CSM.frmMasterMitraSAS ifrmChild = new CSM.frmMasterMitraSAS();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void masterTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTokoDownloadData ifrmChild = new Master.frmTokoDownloadData();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void plafonTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmPlafonTokoDownload ifrmChild = new Communicator.frmPlafonTokoDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tabelTargetSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PSReport.frmMasterTargetSalesBrowse ifrmChild = new PSReport.frmMasterTargetSalesBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void targetPerSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PSReport.frmMasterTargetPerSales ifrmChild = new PSReport.frmMasterTargetPerSales();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tabelTargetAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PSReport.frmMasterTargetAreaBrowse ifrmChild = new PSReport.frmMasterTargetAreaBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void targetPerAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PSReport.frmMasterTargetPerAreaBrowse ifrmChild = new PSReport.frmMasterTargetPerAreaBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        public void datetoHari(DateTime tanggal)
        {
            int tgl = Convert.ToInt16(tanggal.DayOfWeek);
            switch (tgl)
            {
                case 1:
                    hari = "SENIN";
                    break;
                case 2:
                    hari = "SELASA";
                    break;
                case 3:
                    hari = "RABU";
                    break;
                case 4:
                    hari = "KAMIS";
                    break;
                case 5:
                    hari = "JUMAT";
                    break;
                case 6:
                    hari = "SABTU";
                    break;
                case 7:
                    hari = "MINGGU";
                    break;

            }
        }

        private void laporanPenjualanPerItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PO.frmPO frmCaller = new PO.frmPO();
            DateTime _tanggal = DateTime.Now;
            
            datetoHari(_tanggal);
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_POJadwalCekHari"));
                db.Commands[0].Parameters.Add(new Parameter("@gudang", SqlDbType.VarChar, GlobalVar.Gudang));
                db.Commands[0].Parameters.Add(new Parameter("@hari", SqlDbType.VarChar, hari));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                //cek udah PO apa belum
                DataTable dtCekPO = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_RefilPo_SearchPO"));
                    dtCekPO = db.Commands[0].ExecuteDataTable();
                }
                if (dtCekPO.Rows.Count == 0)
                {
                    MessageBox.Show("Hari Ini Jadwal PO, Lakukan Proses PO atau Minta PIN PSHO");
                    Pin.frmPinDaily ifrmChild = new Pin.frmPinDaily(this, PinId.Bagian.PO, DateTime.Today, "PIN PO");
                    ifrmChild.Show();
                    //return;

                }
                else
                {
                    PSReport.frmLaporanPenjualanPerItem ifrmChild = new PSReport.frmLaporanPenjualanPerItem();
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }


            }
            else
            {
                PSReport.frmLaporanPenjualanPerItem ifrmChild2 = new PSReport.frmLaporanPenjualanPerItem();
                ifrmChild2.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild2);
                ifrmChild2.Show();
            }
        }

        private void tokoDispenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rekon.frmTokoDispen ifrmChild = new Rekon.frmTokoDispen();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void overdueFUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rekon.frmMasterOverdueFU ifrmChild = new Rekon.frmMasterOverdueFU();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void masterToolStripMenuItem8_Click(object sender, EventArgs e)
        {

        }

        private void uploadAGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmAntargudangUpload ifrmChild = new Communicator.frmAntargudangUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uplToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PO.frmPO ifrmChild = new PO.frmPO();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadMasterStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmMasterStokDownload ifrmChild = new Master.frmMasterStokDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadHPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmHppDownload ifrmChild = new Master.frmHppDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadHPPRatarataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmHPPADownload ifrmChild = new Master.frmHPPADownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadAntarGudangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Communicator.frmAntarGudangDownload ifrmChild = new Communicator.frmAntarGudangDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadDataMatchingStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmPOSSUpload ifrmChild = new Communicator.frmPOSSUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadHargaJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.FrmHargaJualDownload ifrmChild = new Master.FrmHargaJualDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadPlafonStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmPlafonTokoDownload ifrmChild = new Communicator.frmPlafonTokoDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadOBBaruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTokoDownloadData ifrmChild = new Master.frmTokoDownloadData();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadValidasiOverdueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rekon.frmDownloadOverdueFU ifrmChild = new Rekon.frmDownloadOverdueFU();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transaksiToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Rekon.frmrekonclosing ifrmChild = new Rekon.frmrekonclosing();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void entryDOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Penjualan.frmNotaReturJualBrowse ifrmChild = new Penjualan.frmNotaReturJualBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
          
        }
        
        private void notaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmNotaJualBrowser ifrmChild = new Penjualan.frmNotaJualBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void backOrderToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Gudang.Substring(0, 1) != "9")
            {
                bool isHasRekon = LookupInfoValue.CekRekonHarian();

                if (isHasRekon)
                {
                    DataTable dtCekRekon = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Rekon_Cek_Now"));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, DateTime.Today));
                        dtCekRekon = db.Commands[0].ExecuteDataTable();
                    }

                  /*  if (dtCekRekon.Rows.Count == 0)
                    {
                        MessageBox.Show("Belum closing rekon, silahkan closing rekon terlebih dahulu");

                        return;
                    }*/

                    DataTable dtRekonNow = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Rekon_List_Now"));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, DateTime.Today));
                        dtRekonNow = db.Commands[0].ExecuteDataTable();
                    }

                    if (dtRekonNow.Rows.Count > 0)
                    {
                        MessageBox.Show("Silahkan masukan pin via menu transaksi rekon");

                        return;
                    }
                }
            }
            Penjualan.frmBOBrowser ifrmChild = new Penjualan.frmBOBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pJ3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                PJ3.frmPJ3BrowserISA ifrmChild = new PJ3.frmPJ3BrowserISA();
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            
        }

        private void pJTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PJT.frmPJTBrowserISA ifrmChild = new PJT.frmPJTBrowserISA();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rJ3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                RJ3.frmRJ3Browser ifrmChild = new RJ3.frmRJ3Browser();
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            
        }

        private void mPRToolStripMenuItem1_Click(object sender, EventArgs e)
        {            
            Penjualan.frmMPRBrowser ifrmChild = new Penjualan.frmMPRBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void notaReturToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Penjualan.frmNotaReturJualBrowse ifrmChild = new Penjualan.frmNotaReturJualBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dataPlafonTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmFoxproDownloader ifrmChild = new Communicator.frmFoxproDownloader(ISA.Toko.Communicator.frmFoxproDownloader.enDownloadType.PlafonToko);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void fTagihToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
                Penjualan.frmFTagihBrowser ifrmChild = new ISA.Toko.Penjualan.frmFTagihBrowser();
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            
        }

        private void lapGITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmLaporanGoodInTransit ifrmChild = new Penjualan.frmLaporanGoodInTransit();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void lapPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptRegisterPenjualanFilter ifrmChild = new Laporan.Toko.frmRptRegisterPenjualanFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmRptLaporanPOS ifrmChild = new Penjualan.frmRptLaporanPOS();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tabelDOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (GlobalVar.Gudang.Substring(0, 1) != "9" && GlobalVar.Gudang != "2803")
            //{
            //    bool isHasRekon = LookupInfoValue.CekRekonHarian();

            //    if (isHasRekon)
            //    {
            //        DataTable dtCekRekon = new DataTable();
            //        using (Database db = new Database())
            //        {
            //            db.Commands.Add(db.CreateCommand("usp_Rekon_Cek_Now"));
            //            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, DateTime.Today));
            //            dtCekRekon = db.Commands[0].ExecuteDataTable();
            //        }

            //        if (dtCekRekon.Rows.Count == 0)
            //        {
            //            MessageBox.Show("Belum closing rekon, silahkan closing rekon terlebih dahulu");

            //            return;
            //        }

            //        DataTable dtRekonNow = new DataTable();
            //        using (Database db = new Database())
            //        {
            //            db.Commands.Add(db.CreateCommand("usp_Rekon_List_Now"));
            //            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, DateTime.Today));
            //            dtRekonNow = db.Commands[0].ExecuteDataTable();
            //        }

            //        if (dtRekonNow.Rows.Count > 0)
            //        {
            //            MessageBox.Show("Silahkan masukan pin via menu transaksi rekon");

            //            return;
            //        }
            //    }
            //}
            Penjualan.TabelDO ifrmChild = new Penjualan.TabelDO();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanRefillToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Penjualan.frmRptlaporanRefilToko ifrmChild = new Penjualan.frmRptlaporanRefilToko();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanPerBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmRptLaporanPerbarangNetto ifrmChild = new Penjualan.frmRptLaporanPerbarangNetto();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanReturJualPerTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RJ3.frmRptRekapReturJualPerToko ifrmChild = new RJ3.frmRptRekapReturJualPerToko();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanRekapReturJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RJ3.frmRptRekapReturJual ifrmChild = new RJ3.frmRptRekapReturJual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanPengajuanReturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RJ3.frmRptPengajuanRetur ifrmChild = new RJ3.frmRptPengajuanRetur();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanOverdueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmRptOUTSTANDINGOVERDUE ifrmChild = new Penjualan.frmRptOUTSTANDINGOVERDUE();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void refilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmRptlaporanRefilToko ifrmChild = new Penjualan.frmRptlaporanRefilToko();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptRegisterPenjualanFilter ifrmChild = new Laporan.Toko.frmRptRegisterPenjualanFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void notaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptNotaJual ifrmChild = new Laporan.Salesman.frmRptNotaJual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void returToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptReturNotaJual ifrmChild = new Laporan.Salesman.frmRptReturNotaJual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dOBelumJadiNotaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptDOBelumJadiNota ifrmChild = new Laporan.Salesman.frmRptDOBelumJadiNota();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dataHPPAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmHPPRataRataDownload ifrmChild = new Communicator.frmHPPRataRataDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }
        
        private void uploadDataBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmPOSSUpload ifrmChild = new Communicator.frmPOSSUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dataAntarGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmAntarGudangDownload ifrmChild = new Communicator.frmAntarGudangDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadINPMANToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Communicator.frmPersediaanUploadINPMAN ifrmChild = new Communicator.frmPersediaanUploadINPMAN();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PO.frmPO ifrmChild = new PO.frmPO();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadAGToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Communicator.frmAntargudangUpload ifrmChild = new Communicator.frmAntargudangUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadPromoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmMasterPromo ifrmChild = new Master.frmMasterPromo();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tabelMonitoringStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persediaan.frmStandarStok ifrmChild = new Persediaan.frmStandarStok();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void closingStokToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Persediaan.frmClosingStok ifrmChild = new Persediaan.frmClosingStok();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void masterFixSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixrute.frmMasterFixSales ifrmChild = new Fixrute.frmMasterFixSales();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanRekapReturPerBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RJ3.frmRptReturJualPerBarang ifrmChild = new RJ3.frmRptReturJualPerBarang();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();

            Laporan.Barang.frmReturJualPerNamaBarangFilter ifrmChild = new Laporan.Barang.frmReturJualPerNamaBarangFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RJ3.frmRptRekapReturJualDanPenyelesainya ifrmChild = new RJ3.frmRptRekapReturJualDanPenyelesainya();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanReturBelumLinkKePiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RJ3.frmRptReturBelumLinkKePiutang ifrmChild = new RJ3.frmRptReturBelumLinkKePiutang();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanFormKunjunganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixrute.frmRptLaporanKunjunganHarianPerSalesman ifrmChild = new Fixrute.frmRptLaporanKunjunganHarianPerSalesman();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void stokGudangToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void laporanMonitoringSalesmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixrute.frmRptMonitoringSalesman ifrmChild = new Fixrute.frmRptMonitoringSalesman();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanRekapKunjunganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixrute.frmRptRegisterKunjunganSales ifrmChild = new Fixrute.frmRptRegisterKunjunganSales();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tokoIDWiliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptLaporanIdwillToko ifrmChild = new Laporan.Toko.frmRptLaporanIdwillToko();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanAnalisaKunjunganSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixrute.frmRptAnalisaKunjunganSales ifrmChild = new Fixrute.frmRptAnalisaKunjunganSales();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void uploadMatchingAGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArusStock.frmUploadMatchingAG ifrmChild = new ArusStock.frmUploadMatchingAG();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void konfirmasiTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xpdc.frmRptKonfirmasiToko ifrmChild = new xpdc.frmRptKonfirmasiToko();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanSamplingOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmRptSamplingOpname ifrmChild = new Master.frmRptSamplingOpname();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void pengirimanAGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArusStock.frmRptLaporanAGPenerima ifrmChild = new ArusStock.frmRptLaporanAGPenerima();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void errorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmErrorBrowse ifrmChild = new Administrasi.frmErrorBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void batchProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmProcessLog ifrmChild = new Administrasi.frmProcessLog();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void updateBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xpdc.FrmUpdateBarcode ifrmChild = new xpdc.FrmUpdateBarcode();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dataHargaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmHargaDownload ifrmChild = new Communicator.frmHargaDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tabelRegulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSM.frmMasterCustomerInti ifrmChild = new CSM.frmMasterCustomerInti("Reguler", "REG");

            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transaksiToolStripMenuItem10_Click(object sender, EventArgs e)
        {

        }

        private void laporanSalesmanScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Analisa.frmRptSalesmanScore ifrmChild = new Laporan.Analisa.frmRptSalesmanScore();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanAnalisaOAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PSReport.frmLaporanAnalisaOA ifrmChild = new PSReport.frmLaporanAnalisaOA();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dataTokoDispensasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmFoxproDownloader ifrmChild = new Communicator.frmFoxproDownloader(ISA.Toko.Communicator.frmFoxproDownloader.enDownloadType.TokoDispensasi);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void TokoDispensasitoolStripMenuItem39_Click(object sender, EventArgs e)
        {
            Master.frmTokoDispensasiBrowse ifrmChild = new Master.frmTokoDispensasiBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void uploadTokoDispensasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTokoDispensasiUpload ifrmChild = new Master.frmTokoDispensasiUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void dataBMKToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Communicator.frmFoxproDownloader ifrmChild = new Communicator.frmFoxproDownloader(ISA.Toko.Communicator.frmFoxproDownloader.enDownloadType.BMK11);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void dataHPPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Communicator.frmFoxproDownloader ifrmChild = new Communicator.frmFoxproDownloader(ISA.Toko.Communicator.frmFoxproDownloader.enDownloadType.HPP11);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void orderSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmOrderSheetDownload ifrmChild = new Communicator.frmOrderSheetDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void laporanRegisterPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Toko.frmRptRegisterPenjualanFilter ifrmChild = new Laporan.Toko.frmRptRegisterPenjualanFilter();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanDOBelumJadiNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptDOBelumJadiNota ifrmChild = new Laporan.Salesman.frmRptDOBelumJadiNota();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void accDOToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Penjualan.frmAccDOBrowser ifrmChild = new Penjualan.frmAccDOBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void aCCReturSPVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmACCReturBrowse ifrmChild = new Penjualan.frmACCReturBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
            Penjualan.frmACCSOBrowse ifrmChild = new Penjualan.frmACCSOBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void salesmanScoreV2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Analisa.frmRptSalesmanScoreV2 ifrmChild = new Laporan.Analisa.frmRptSalesmanScoreV2();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void monitoringARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Analisa.frmMonitoringAR ifrmChild = new Laporan.Analisa.frmMonitoringAR();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTargetCollection ifrmChild = new Master.frmTargetCollection();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void targetOverdueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTargetOverdue ifrmChild = new Master.frmTargetOverdue();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void analisaPerformanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void marketShareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Analisa.frmRptMarketShare ifrmChild = new Laporan.Analisa.frmRptMarketShare();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanInputTanggalTerimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmLaporanInputTanggalTerima ifrmChild = new Penjualan.frmLaporanInputTanggalTerima();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void orderPembelianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Pembelian.frmDOBeliBrowser ifrmChild = new Pembelian.frmDOBeliBrowser();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();

            Gudang.frmDOBeli ifrmChild = new Gudang.frmDOBeli();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tabelHistoryAccOverdueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmACCOverdueBrowse ifrmChild = new Penjualan.frmACCOverdueBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void downloadDODariC1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmPenjualanDODownload00 ifrmChild = new Communicator.frmPenjualanDODownload00();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void uploadNotaKeC2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rsopac.frmRsUpload ifrmChild = new Rsopac.frmRsUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

            //Communicator.frmPenjualanNotaUploadC1 ifrmChild = new Communicator.frmPenjualanNotaUploadC1();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();

        }

        private void tokokKhususToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTokoKhususBrowse ifrmChild = new Master.frmTokoKhususBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void dataTokoKhususToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communicator.frmFoxproDownloader ifrmChild = new Communicator.frmFoxproDownloader(ISA.Toko.Communicator.frmFoxproDownloader.enDownloadType.TokoKhusus);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void inputDeliveryOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DO.FrmDO2803 ifrmChild = new DO.FrmDO2803(null);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void jToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void unitKerjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmUnitKerjaBrowser ifrmChild = new Master.frmUnitKerjaBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void arusStokToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transaksiToolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void JasatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmJasaBrowse ifrmChild = new Master.frmJasaBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void StatusHargaStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.FrmStatusHargaBrowse ifrmChild = new Master.FrmStatusHargaBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void TipeTransaksiStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTipeTransaksiBrowse ifrmChild = new Master.frmTipeTransaksiBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanToolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void jenisBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmJenisBarangBrowse ifrmChild = new Master.frmJenisBarangBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem45_Click(object sender, EventArgs e)
        {

            Master.frmKategoriReturBrowse ifrmChild = new Master.frmKategoriReturBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void AppSettingtoolStripMenuItem46_Click(object sender, EventArgs e)
        {

            Master.frmAppSettingBrowse ifrmChild = new Master.frmAppSettingBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void PerusahaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmMasterPerusahaan ifrmChild = new Master.frmMasterPerusahaan();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void kartuPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.frmKartuPiutangBrowse ifrmChild = new Piutang.frmKartuPiutangBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void penerimaanUangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmPenerimaanBelumTeridentifikasiBrowse ifrmChild = new Kasir.frmPenerimaanBelumTeridentifikasiBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void penjualanTunaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmPJTBrowser ifrmChild = new Kasir.frmPJTBrowser();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void registerTagihanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.frmRegisterBrowser ifrmChild = new Register.frmRegisterBrowser();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void bKMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmBKMBrowse ifrmChild = new Kasir.frmBKMBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void bKKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmBKKBrowse ifrmChild = new Kasir.frmBKKBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void voucherGiroMasukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmVoucherGiroMasukBrowse ifrmChild = new Kasir.frmVoucherGiroMasukBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void voucherGiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmVoucherGiroTitipanBrowse ifrmChild = new Kasir.frmVoucherGiroTitipanBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void giroCairTolakBatalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmGiroCairTolakBatal ifrmChild = new Kasir.frmGiroCairTolakBatal();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void bukaGiroChequeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmBukaGiro ifrmChild = new Kasir.frmBukaGiro();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void toolStripMenuItem46_Click(object sender, EventArgs e)
        {
            Master.frmBankKotaBrowse ifrmChild = new Master.frmBankKotaBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void buktiTransferMasukToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Kasir.frmBuktiTransferMasuk ifrmChild = new Kasir.frmBuktiTransferMasuk();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void buktiTransferKeluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmBuktiTransferKeluar ifrmChild = new Kasir.frmBuktiTransferKeluar();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void kasbonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Kasir.frmKasbonBrowse ifrmChild = new Kasir.frmKasbonBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void bukuBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmBukuBankBrowse ifrmChild = new Kasir.frmBukuBankBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void opNamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmKasOpnameUpdate ifrmChild = new Kasir.frmKasOpnameUpdate();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void toolStripMenuItem47_Click(object sender, EventArgs e)
        {
            Master.frmArmadaKirim ifrmChild = new Master.frmArmadaKirim();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void voucherJournalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmVoucherJournalBrowser ifrmChild = new Kasir.frmVoucherJournalBrowser();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void stokOpnameToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Persediaan.frmStokOpname ifrmChild = new Persediaan.frmStokOpname();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void upgradeSastokToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Persediaan.frmStokOpnameUpgrade ifrmChild = new Persediaan.frmStokOpnameUpgrade();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void downloadSaldoAkhirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Persediaan.frmStokOpnameDownload ifrmChild = new Persediaan.frmStokOpnameDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transferOpnameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Persediaan.frmStokOpnameTransfer ifrmChild = new Persediaan.frmStokOpnameTransfer();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanSaldoHarianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmLaporanSaldoperPeriode ifrmChild = new Kasir.frmLaporanSaldoperPeriode();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();//
        }

        private void entryDOToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            DO.FrmDO ifrmChild = new DO.FrmDO(null);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void notaJualToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Penjualan.frmNotaJualBrowser ifrmChild = new Penjualan.frmNotaJualBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void penjualanKreditToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void linkPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PJ3.frmPJ3BrowserISA ifrmChild = new PJ3.frmPJ3BrowserISA();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void entryDOToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            DO.FrmDO ifrmChild = new DO.FrmDO(null);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void notaJualToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Penjualan.frmNotaJualBrowser ifrmChild = new Penjualan.frmNotaJualBrowser();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanPenjualanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
         
        }

        private void laporanPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.frmLaporanPiutang ifrmChild = new Piutang.frmLaporanPiutang();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void notaPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Salesman.frmRptNotaJual ifrmChild = new Laporan.Salesman.frmRptNotaJual();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanPenjualanToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Penjualan.frmLaporanPenjualan ifrmChild = new Penjualan.frmLaporanPenjualan();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.J && Control.ModifierKeys == Keys.Control)
            {
                POS.FrmPOS ifrmChild = new POS.FrmPOS();
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control)
            {
                DO.FrmDO ifrmChild = new DO.FrmDO(null);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();

            }
            else if (e.KeyCode == Keys.B && Control.ModifierKeys == Keys.Control)
            {
                Pembelian.frmDOBeliBrowser ifrmChild = new Pembelian.frmDOBeliBrowser();
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else if (e.KeyCode == Keys.H && Control.ModifierKeys == Keys.Control)
            {
                Penjualan.FrmCekBarang ifrmChild = new Penjualan.FrmCekBarang();
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
        }

        private void cekHargaBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.FrmCekBarang ifrmChild = new Penjualan.FrmCekBarang();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        void GenerateDatatoXML()
        {
            DateTime fromdate, todate, tanggal;
            tanggal = GlobalVar.DateOfServer;
            fromdate = tanggal.AddDays(1 - tanggal.Day);
            todate = tanggal;
            string pjfilename = "LaporanPenjualan" + todate.ToString("ddMMyyyy");
            string stockfilename = "LaporanStock" + todate.ToString("ddMMyyyy");
            string zipfilename = GlobalVar.CabangID + "_autosynchtoko_" + GlobalVar.DateTimeOfServer.ToString("ddMMyyyyHHmmss");
            string zipfileoutput = @"C:\Temp\" + EncodeData(zipfilename) + ".ZIP";
            
            //Ambil Data
            DataSet ds, dsstock = new DataSet();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[rsp_laporanPenjualanPerbarangNetto]"));
                db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, fromdate));
                db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, todate));
                ds = db.Commands[0].ExecuteDataSet();
            }

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[rsp_StokGudang_PosisiStokNew]"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromdate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, fromdate));
                db.Commands[0].Parameters.Add(new Parameter("@InitGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                dsstock = db.Commands[0].ExecuteDataSet();
            }

            List<string> files = new List<string>();
            string pjfileOutput = @"C:\Temp\" + pjfilename + ".xml";
            ds.WriteXml(pjfileOutput);
            files.Add(pjfileOutput);
            string stfileOutput = @"C:\Temp\" + stockfilename + ".xml";
            dsstock.WriteXml(stfileOutput);
            files.Add(stfileOutput);
            //Generate File
            try
            {
                //Encrypt File
                File.WriteAllBytes(pjfileOutput, EncryptFile(pjfileOutput));
                File.WriteAllBytes(stfileOutput, EncryptFile(stfileOutput));
                InsertLog(AutoRowID, GlobalVar.DateTimeOfServer, DateTime.MinValue, SecurityManager.ClientIPAddress.ToString(), "Generating", "Berhasil");
            }
            catch (Exception ex)
            {
                InsertLog(AutoRowID, DateTime.MinValue, DateTime.MinValue, SecurityManager.ClientIPAddress.ToString(), "Generating", ex.ToString());
            }

            //Zip File
            try
            {
                Zip.ZipFiles(files, zipfileoutput);
                InsertLog(AutoRowID, DateTime.MinValue, DateTime.MinValue, SecurityManager.ClientIPAddress.ToString(), "Zipping", "Berhasil");
                //Delete File
                File.Delete(pjfileOutput);
                File.Delete(stfileOutput);
            }
            catch (Exception ex)
            {
                InsertLog(AutoRowID, DateTime.MinValue, DateTime.MinValue, SecurityManager.ClientIPAddress.ToString(), "Zipping", ex.ToString());
                //Delete File
                File.Delete(pjfileOutput);
                File.Delete(stfileOutput);
            }

            //Upload File
            string FTPName = "ftp://fileserver.sas-autoparts.com/ISAToko/"+ GlobalVar.CabangID +"/";
            string FilePath = zipfileoutput;

            string Username = "isalive";
            string Pass = "isalive12345";

            try
            {
                uploadFile(FTPName, FilePath, Username, Pass);
                InsertLog(AutoRowID, DateTime.MinValue, DateTime.Now, SecurityManager.ClientIPAddress.ToString(), "Uploading", "Berhasil");
                File.Delete(FilePath);
            }
            catch (Exception ex)
            {
                InsertLog(AutoRowID, DateTime.MinValue, DateTime.MinValue, SecurityManager.ClientIPAddress.ToString(), "Uploading", ex.ToString());
                File.Delete(FilePath);
            }
        }

        void updateLog()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("ISADbDepoRetail.dbo.usp_AutoSynchLog"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, LastROwID));
                db.Commands[0].Parameters.Add(new Parameter("@End", SqlDbType.DateTime, GlobalVar.DateTimeOfServer));
                db.Commands[0].ExecuteNonQuery();
            }
        }

        void InsertLog(Guid RowID,DateTime starttime, DateTime endtime, string ipcomp, string status, string error)
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("ISADbDepoRetail.dbo.psp_InsertAutoSynchLog"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                if (starttime != DateTime.MinValue)
                {
                    db.Commands[0].Parameters.Add(new Parameter("@Start", SqlDbType.DateTime, starttime));
                }
                if (endtime != DateTime.MinValue)
                {
                    db.Commands[0].Parameters.Add(new Parameter("@End", SqlDbType.DateTime, endtime));
                }
                db.Commands[0].Parameters.Add(new Parameter("@IpComputer", SqlDbType.VarChar, ipcomp));
                db.Commands[0].Parameters.Add(new Parameter("@LastStatus", SqlDbType.VarChar, status));
                db.Commands[0].Parameters.Add(new Parameter("@Error", SqlDbType.VarChar, error));
                db.Commands[0].ExecuteNonQuery();
            }
        }

        string EncodeData(string data)
        {
            string result = "";

            data = data.Trim();

            for (int i = 0; i < data.Length; i++)
            {
                int x = (int)data[i];

                result += char.ConvertFromUtf32((x + 4) * 2);
            }
            return result;
        }

        byte[] EncryptFile(string data)
        {
            byte[] thefile = File.ReadAllBytes(data);

            for (int i = 0; i < thefile.Length; i++)
            {
                int a = int.Parse(thefile[i].ToString());
                if (a != 0)
                    a = a - 1;
                else
                    a = 255;
                thefile[i] = Convert.ToByte(a);
            }

            return thefile;
        }

        byte[] DecryptFile(string data)
        {
            byte[] thefile = File.ReadAllBytes(data);

            for (int i = 0; i < thefile.Length; i++)
            {
                int a = int.Parse(thefile[i].ToString());
                if (a != 255)
                    a = a + 1;
                else
                    a = 0;
                thefile[i] = Convert.ToByte(a);
            }

            return thefile;
        }

        private void uploadFile(string FTPAddress, string filePath, string username, string password)
        {
            //Buat FTP request
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(FTPAddress + "/" + Path.GetFileName(filePath));
            //FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(FTPAddress);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            //Load the file
            FileStream stream = File.OpenRead(filePath);
            byte[] buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);
            stream.Close();

            //Upload file
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void bwAuto_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Convert.ToInt32(Class.AppSetting.GetValue("AutoSynch")) == 1)
            {
                //Cek File
                DateTime todate = GlobalVar.DateOfServer;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("ISADbDepoRetail.dbo.vsp_AutoSynchLog"));
                    db.Commands[0].Parameters.Add(new Parameter("@date", SqlDbType.DateTime, todate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count != 0)
                {
                    DateTime awal, akhir;
                    awal = Convert.ToDateTime(dt.Rows[0]["starttime"].ToString());
                    akhir = Convert.ToDateTime(DateTime.Now.ToString());
                    Double selisih = akhir.Subtract(awal).TotalMinutes;

                    if (Convert.ToDateTime(dt.Rows[0]["starttime"].ToString()) != null && Convert.ToDateTime(Tools.isNull(dt.Rows[0]["endtime"].ToString(), DateTime.MinValue)) != DateTime.MinValue)
                    {
                        return;
                    }
                    else
                    {
                        if (Convert.ToDateTime(dt.Rows[0]["starttime"].ToString()) != null && Convert.ToDateTime(Tools.isNull(dt.Rows[0]["endtime"].ToString(), DateTime.MinValue)) == DateTime.MinValue && selisih < 240)
                        {
                            return;
                        }
                        else
                        {
                            LastROwID = (Guid)dt.Rows[0]["RowID"];
                            AutoRowID = Guid.NewGuid();
                            updateLog();
                            InsertLog(AutoRowID, GlobalVar.DateTimeOfServer, DateTime.MinValue, SecurityManager.ClientIPAddress.ToString(), "Mulai Proses", "");
                            GenerateDatatoXML();
                        }
                    }
                }
                else
                {
                    AutoRowID = Guid.NewGuid();
                    InsertLog(AutoRowID, GlobalVar.DateTimeOfServer, DateTime.MinValue, SecurityManager.ClientIPAddress.ToString(), "Mulai Proses", "");
                    GenerateDatatoXML();
                }
            }
        }
        
    }
}

