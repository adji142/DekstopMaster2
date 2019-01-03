using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Finance
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void bKMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmBKMBrowse ifrmChild = new Kasir.frmBKMBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        public void RegisterChild(Control iform)
        {
            //this.pnlMain.ContentPanel.Controls.Add(iform);
        }

        

        private void bukuBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmBukuBankBrowse ifrmChild = new Kasir.frmBukuBankBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {            
            GlobalVar.initialize();
            Setorans.initialize();
            //Kasirs.initialize();
            //SecurityManager.AlwaysAuthenticate();
            //statusStrip1.Items[0].Text = SecurityManager.UserID;
            if (!SecurityManager.IsManager())
            {
                PerformSecurityCheck();
            }
            tsUserID.Text = "User ID: " + SecurityManager.UserID;
            tsHost.Text = "Host: " + ISA.DAL.Database.Host;
            txtVersion.Text = txtVersion.Text + Application.ProductVersion;
            if (SecurityManager.UserID == "DEV")
            {
                debugToolStripMenuItem.Visible = true;
            }

            if (GlobalVar.Gudang != "2808")
            {
                cekLKH();
            }

            if (SecurityManager.UserName == "MANAGER")
            {
                uploadDownloadToolStripMenuItem.Enabled = true;
            }
            else
            {
                uploadDownloadToolStripMenuItem.Enabled = false;
            }
        }

        private void cekLKH()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KASIR_LaporanKasHarian_Auto"));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void PerformSecurityCheck()
        {
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


        private void frmDebugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDebug ifrmChild = new frmDebug();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void laporanJournalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRpt01LaporanJournals ifrmChild = new GL.frmRpt01LaporanJournals();
            ifrmChild.MdiParent = this;           
            ifrmChild.Show();            
        }

        private void bukuBesarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRpt02BukuBesar ifrmChild = new GL.frmRpt02BukuBesar();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();   
        }

        private void frmTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmKasOpnameUpdate ifrmChild = new Kasir.frmKasOpnameUpdate();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();          
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void voucherJournalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmVoucherJournalBrowse ifrmChild = new Kasir.frmVoucherJournalBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();            
            
        }


        private void penyeselesainNotaPersalesmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt3PenyelesainNotaPersalesman ifrmChild = new Piutang.Report.frmRpt3PenyelesainNotaPersalesman();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void kasirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GL.frmPerkiraanKoneksiArusKasBrowse ifrmChild = new GL.frmPerkiraanKoneksiArusKasBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void nonKasirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmPerkiraanKoneksiModulLainBrowse ifrmChild = new GL.frmPerkiraanKoneksiModulLainBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void kasOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmKasOpnameUpdate ifrmChild = new Kasir.frmKasOpnameUpdate();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Normal;
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void debetKreditNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DKNForm.frmDebetKreditNotaBrowse ifrmChild = new DKNForm.frmDebetKreditNotaBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void cabangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DKNForm.frmDebetKreditNotaCabangBrowse ifrmChild = new DKNForm.frmDebetKreditNotaCabangBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Normal;
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void kelompokTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DKNForm.frmDebetKreditNotaKelTransBrowse ifrmChild = new DKNForm.frmDebetKreditNotaKelTransBrowse();
            ifrmChild.MdiParent = this;
            //ifrmChild.WindowState = FormWindowState.Normal;
            //ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void lapDKNBelumUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DKNForm.frmRptDKNBelumUpload ifrmChild = new DKNForm.frmRptDKNBelumUpload();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Normal;            
            ifrmChild.Show();
        }

        private void lapDKNRKDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DKNForm.frmRptDKNRKDetail ifrmChild = new DKNForm.frmRptDKNRKDetail();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Normal;            
            ifrmChild.Show();
        }

        private void lapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DKNForm.frmRptDKNRekapHI ifrmChild = new DKNForm.frmRptDKNRekapHI();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Normal;
            ifrmChild.Show();
        }

        private void lapDKNBelumHIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DKNForm.frmRptDKNBelumHI ifrmChild = new DKNForm.frmRptDKNBelumHI();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Normal;            
            ifrmChild.Show();
        }

        private void uploadDKNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dendaSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void downloadDKNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            
        }

      

        private void piutangMinusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt15EvaluasiACCDO ifrmChild = new Piutang.Report.frmRpt15EvaluasiACCDO();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();

        }

        private void bKKToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Kasir.frmBKKBrowse ifrmChild = new Kasir.frmBKKBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void evaluasiACCDOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void notaJTOverdueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt17NotaJTOVD ifrmChild = new Piutang.Report.frmRpt17NotaJTOVD();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }
        

        private void buktiTransferMasukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmBuktiTransferMasuk ifrmChild = new Kasir.frmBuktiTransferMasuk();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void notaJTOverdueToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            
        }

        private void voucherGiroMasukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmVoucherGiroMasukBrowse ifrmChild = new Kasir.frmVoucherGiroMasukBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void voucherGiroTitipanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmVoucherGiroTitipanBrowse ifrmChild = new Kasir.frmVoucherGiroTitipanBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void buktiTransferKeluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmBuktiTransferKeluar ifrmChild = new Kasir.frmBuktiTransferKeluar();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void agingScheduleNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void linkKeGLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmLinkKeGLBrowse ifrmChild = new Kasir.frmLinkKeGLBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void transaksiToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            V_Otong.frmTabelWilID ifrmChild = new V_Otong.frmTabelWilID();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void rekapTongolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V_Otong.Report.frmRpt01RekapTongolan ifrmChild = new V_Otong.Report.frmRpt01RekapTongolan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void rekapPemegangKPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V_Otong.Report.frmRpt02PemegangKP ifrmChild = new V_Otong.Report.frmRpt02PemegangKP();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void piutangKaryawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmPiutangKaryawan ifrmChild = new Kasir.frmPiutangKaryawan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void rekapOverdueNotaPerSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V_Otong.Report.frmRpt03NotaOverduePerSales ifrmChild = new V_Otong.Report.frmRpt03NotaOverduePerSales();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            V_Otong.Report.frmRpt04PiutangGiro ifrmChild = new V_Otong.Report.frmRpt04PiutangGiro();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void penerimaanBelumIdentifikasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmPenerimaanBelumTeridentifikasiBrowse ifrmChild = new Kasir.frmPenerimaanBelumTeridentifikasiBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void transaksiToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Register.frmRegisterBrowser ifrmChild = new Register.frmRegisterBrowser();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();

        }

        private void piutangKaryawanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Kasir.frmRptLapPiutangKaryawan ifrmChild = new Kasir.frmRptLapPiutangKaryawan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void tokoTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.Report.frmRpt01TokoTransfer ifrmChild = new Register.Report.frmRpt01TokoTransfer();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }


        private void tabelBiayaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.frmCollectorBrowser ifrmChild = new Register.frmCollectorBrowser();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void infoTagihToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.Report.frmRpt08InfoTagih ifrmChild = new Register.Report.frmRpt08InfoTagih();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void rencanaTagihToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.Report.frmRpt06RencanaTagih ifrmChild = new Register.Report.frmRpt06RencanaTagih();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void evaluasiCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.Report.frmRpt02EvaluasiCollector ifrmChild = new Register.Report.frmRpt02EvaluasiCollector();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void giroCairTolakBatalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmGiroCairTolakBatal ifrmChild = new Kasir.frmGiroCairTolakBatal();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void evaluasiCollectorWilayahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.Report.frmRpt03EvaluasiCollectorWil ifrmChild = new Register.Report.frmRpt03EvaluasiCollectorWil();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Register.Report.frmRpt04EvaluasiCollector ifrmChild = new Register.Report.frmRpt04EvaluasiCollector();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void bonusCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.Report.frmRpt05BonusCollector ifrmChild = new Register.Report.frmRpt05BonusCollector();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void realisasiTagihBGCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.Report.frmRpt07RealisasiRencanaTagih ifrmChild = new Register.Report.frmRpt07RealisasiRencanaTagih();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void penerimaanGiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptPenerimaanGiro ifrmChild = new Kasir.frmRptPenerimaanGiro();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void kasbonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmKasbonBrowse ifrmChild = new Kasir.frmKasbonBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void kelompokBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PJTools.frmKelompokBarangBrowse ifrmChild = new PJTools.frmKelompokBarangBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void titipGiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptTitipGiro ifrmChild = new Kasir.frmRptTitipGiro();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void giroCairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptGiroCair ifrmChild = new Kasir.frmRptGiroCair();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void giroBatalTitipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptGiroBatalTitip ifrmChild = new Kasir.frmRptGiroBatalTitip();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void giroTolakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptGiroTolak ifrmChild = new Kasir.frmRptGiroTolak();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void saldoGiroBGDBGTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptSaldoGiro ifrmChild = new Kasir.frmRptSaldoGiro();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void uploadDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmUploadDownload ifrmChild = new Kasir.frmUploadDownload();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void preferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.frmPreferenceSetoran ifrmChild = new Setoran.frmPreferenceSetoran();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void liburToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.frmLibur ifrmChild = new Setoran.frmLibur();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void penerimaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.frmPerencanaan ifrmChild = new Setoran.frmPerencanaan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void uploadPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.frmUploadPiutang ifrmChild = new Piutang.frmUploadPiutang();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void downloadPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.frmDownloadPiutang ifrmChild = new Piutang.frmDownloadPiutang() ;
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void penerimaanToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Setoran.frmPerencanaan ifrmChild = new Setoran.frmPerencanaan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void pengeluaranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.frmPengeluaran ifrmChild = new Setoran.frmPengeluaran();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void penerimaanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Setoran.frmRPerencanaan ifrmChild = new Setoran.frmRPerencanaan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void pengeluaranToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Setoran.frmRPengeluaran ifrmChild = new Setoran.frmRPengeluaran();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void saldoAwalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.frmSaldoAwal ifrmChild = new Setoran.frmSaldoAwal();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void saldoAwalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Setoran.frmRSaldoAwal ifrmChild = new Setoran.frmRSaldoAwal();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void saldoTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.frmSaldoTO ifrmChild = new Setoran.frmSaldoTO();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void saldoTOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Setoran.frmRSaldoTO ifrmChild = new Setoran.frmRSaldoTO();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void bukaGiroChequeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmBukaGiro ifrmChild = new Kasir.frmBukaGiro();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void transferBelumTeridentifikasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.frmTransferG ifrmChild = new Setoran.frmTransferG();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void tabelCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.frmDataCustomer ifrmChild = new Setoran.frmDataCustomer();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void getDataRencanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.frmGetDataRencana ifrmChild = new Setoran.frmGetDataRencana();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void prediksiRealisasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.frmPrediksiRealisasi ifrmChild = new Setoran.frmPrediksiRealisasi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void saldoTitipanGiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.frmStokTitipanGiro ifrmChild = new Setoran.frmStokTitipanGiro();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void tabelBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.fmTableBank ifrmChild = new Setoran.fmTableBank();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void rencanaUlangNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.frmRencanaUlangNota ifrmChild = new Setoran.frmRencanaUlangNota();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Kasir.frmRptPenerimaanBlmIdentifikasi ifrmChild = new Kasir.frmRptPenerimaanBlmIdentifikasi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }
                

        
        private void getDataRealisasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.frmGetRealisasi ifrmChild = new Setoran.frmGetRealisasi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void notaNotaJatuhTempoRencanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.Report.frmRpt12NotaJtRencana ifrmChild = new Setoran.Report.frmRpt12NotaJtRencana();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void identfikasiNonPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptPenerimaanBlmIdentifikasiNonPiutang ifrmChild = new Kasir.frmRptPenerimaanBlmIdentifikasiNonPiutang();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void pembayaran3BulanTerakhirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.Report.frmRpt11Pembayaran3Bulan ifrmChild = new Setoran.Report.frmRpt11Pembayaran3Bulan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void realisasiPenjualanJatuhTempoBulanDepanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.Report.frmRpt10PenjualanJTBulanDepan ifrmChild = new Setoran.Report.frmRpt10PenjualanJTBulanDepan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void identifikasiPembayaranKeNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptLapIdenSetorPiutang ifrmChild = new Kasir.frmRptLapIdenSetorPiutang();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

       

        private void penjualanCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.Report.frmRpt09ARealisasiCash ifrmChild = new Setoran.Report.frmRpt09ARealisasiCash();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

       
        private void identifikasiGiro1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptIdenGiro ifrmChild = new Kasir.frmRptIdenGiro();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptPenerimaanPembayaranPiutang ifrmChild = new Kasir.frmRptPenerimaanPembayaranPiutang();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void giroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.Report.frmRpt09BGiro ifrmChild = new Setoran.Report.frmRpt09BGiro();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void saldoIdentifikasiPembayaranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptSaldoIdentBayar ifrmChild = new Kasir.frmRptSaldoIdentBayar();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void identifikasiPembayaranPerHariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptIdentBayarPerHari ifrmChild = new Kasir.frmRptIdentBayarPerHari();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void penerimaanSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptSlipTarikTunai ifrmChild = new Kasir.frmRptSlipTarikTunai();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void piutangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Setoran.Report.frmRpt09CPiutang ifrmChild = new Setoran.Report.frmRpt09CPiutang();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void identifikasiAcc1TokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptIdentAccountToko ifrmChild = new Kasir.frmRptIdentAccountToko();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void laporanAccBKKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptAccBKKBKK ifrmChild = new Kasir.frmRptAccBKKBKK();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void laporanAccVJUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptAccBKKVJ ifrmChild = new Kasir.frmRptAccBKKVJ();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void rekapDebetKreditCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptRekapCrdDbtCard ifrmChild = new Kasir.frmRptRekapCrdDbtCard();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void pencairanDebetKreditCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptPencairanCrdDbtCard ifrmChild = new Kasir.frmRptPencairanCrdDbtCard();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void titipanPelunasanPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.Report.frmRpt08TitipPiutang ifrmChild = new Setoran.Report.frmRpt08TitipPiutang();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void rencanaSetoranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.Report.frmRpt05RSetoran ifrmChild = new Setoran.Report.frmRpt05RSetoran();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void kasHarianLKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptLaporanKasHarian ifrmChild = new Kasir.frmRptLaporanKasHarian();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void beritaAcaraKasOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptKasOpname ifrmChild = new Kasir.frmRptKasOpname();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void mutasiKasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptLaporanMutasiKas ifrmChild = new Kasir.frmRptLaporanMutasiKas();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void pertanggungJawabanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRptLaporanPertanggungJawaban ifrmChild = new Kasir.frmRptLaporanPertanggungJawaban();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void realisasiSetoranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.Report.frmRpt06RSSetoran ifrmChild = new Setoran.Report.frmRpt06RSSetoran();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void piutangGiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.Report.frmRpt04PGiro ifrmChild = new Setoran.Report.frmRpt04PGiro();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void realisasiSetoranToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Setoran.Report.frmRpt06RSSetoran ifrmChild = new Setoran.Report.frmRpt06RSSetoran();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void selisihSetoranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setoran.Report.frmRpt07SSSetoran ifrmChild = new Setoran.Report.frmRpt07SSSetoran();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void jurnalUmumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmJournalBrowse ifrmChild = new GL.frmJournalBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void downloadMasterPerkiraanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmDownloadPerkiraanKoneksi ifrmChild = new GL.frmDownloadPerkiraanKoneksi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            //GL.frmDownloadPerkiraan ifrmChild = new GL.frmDownloadPerkiraan();
            //ifrmChild.MdiParent = this;
            //ifrmChild.Show();
        }

        private void auditTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRptAuditTrans ifrmChild = new GL.frmRptAuditTrans();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void tutupBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmTutupBuku ifrmChild = new GL.frmTutupBuku();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void riwayatSaldoTutupBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRiwayatSaldoTutupBuku ifrmChild = new GL.frmRiwayatSaldoTutupBuku();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void gLReportDesignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmGlReportDesign ifrmChild = new GL.frmGlReportDesign();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void uploadJournalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GL.frmUploadJournal ifrmChild = new GL.frmUploadJournal();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void neracaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRpt06Neraca ifrmChild = new GL.frmRpt06Neraca();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void neracaKonsolidasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRpt07NeracaKonsolidasi ifrmChild = new GL.frmRpt07NeracaKonsolidasi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void laporanJournalPerKelompokTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRpt10JournalperKelompokTransaksi ifrmChild = new GL.frmRpt10JournalperKelompokTransaksi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();            
        }

        private void aLabaRugiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRpt05ALabaRugi ifrmChild = new GL.frmRpt05ALabaRugi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void nonKasirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GL.frmPerkiraanKoneksiModulLainBrowse ifrmChild = new GL.frmPerkiraanKoneksiModulLainBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void posisiSaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmKasirLogBrowse ifrmChild = new Kasir.frmKasirLogBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void recalculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmRecalculateKasirLog ifrmChild = new Kasir.frmRecalculateKasirLog();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void plafonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void rekapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void evalusaiTagihanCollectorDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.Report.frmRpt09EvaluasiCollectorDetail ifrmChild = new Register.Report.frmRpt09EvaluasiCollectorDetail();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void lapDKNHarianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DKNForm.frmRptDKNHarian ifrmChild = new DKNForm.frmRptDKNHarian();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void cRugiLabaAccumulationGlobalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRpt05CLabaRugi ifrmChild = new GL.frmRpt05CLabaRugi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();            
        }

        private void neracaSaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRpt03NeracaPercobaan ifrmChild = new GL.frmRpt03NeracaPercobaan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void bRugiLabaMonthlyDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRpt05BLabaRugi ifrmChild = new GL.frmRpt05BLabaRugi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();       
        }

        private void subPerkiraanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmPartnerBrowse ifrmChild = new GL.frmPartnerBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void dRugiLabaAccumulationDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRpt05DLabaRugi ifrmChild = new GL.frmRpt05DLabaRugi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();   
        }

        private void cashFlowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GL.frmRpt08CashFlow ifrmChild = new GL.frmRpt08CashFlow();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();   
        }

        private void penjualanTunaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmPJTBrowser ifrmChild = new Kasir.frmPJTBrowser();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void catatanAtasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRpt09ACatLapKeuangan ifrmChild = new GL.frmRpt09ACatLapKeuangan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();   
        }

        private void penyeselesainNotaPersalesmanToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void saldoPiutangBersihNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void giroJatuhTempoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void penyelesaianNotaPerWilayahToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void transaksiBelumLinkToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void posisiPiutangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void lapPeriodikPerTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void nota2SalesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void dendaSalesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void uploadDKNToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DKNForm.frmUploadDKN ifrmChild = new DKNForm.frmUploadDKN();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Normal;
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void downloadDKNToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //DKNForm.frmDonwloadDKN ifrmChild = new DKNForm.frmDonwloadDKN();
            DKNForm.frmDownloadDKNPilih ifrmChild = new DKNForm.frmDownloadDKNPilih();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void saldoPiutangBersihNotaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt1SaldoBersihPiutangNota ifrmChild = new Piutang.Report.frmRpt1SaldoBersihPiutangNota();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void giroJatuhTempoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt2GiroJatuhTempo ifrmChild = new Piutang.Report.frmRpt2GiroJatuhTempo();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void penyelesaianNotaPerWilayahToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt4PenyelesainNotaPerWilayah ifrmChild = new Piutang.Report.frmRpt4PenyelesainNotaPerWilayah();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void transaksiBelumLinkToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt5TransaksiBelumLink ifrmChild = new Piutang.Report.frmRpt5TransaksiBelumLink();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void posisiPiutangToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt6PosisiPiutang ifrmChild = new Piutang.Report.frmRpt6PosisiPiutang();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void lapPeriodikPerTransaksiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt7PeriodikPerTrans ifrmChild = new Piutang.Report.frmRpt7PeriodikPerTrans();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void nota2SalesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt8Nota2Sales ifrmChild = new Piutang.Report.frmRpt8Nota2Sales();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void dendaSalesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt9DendaSales ifrmChild = new Piutang.Report.frmRpt9DendaSales();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void rekapUmurPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt11UmurPiutang ifrmChild = new Piutang.Report.frmRpt11UmurPiutang();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void piutangMinusToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt13Piutangminus ifrmChild = new Piutang.Report.frmRpt13Piutangminus();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void evaluasiACCDOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt15EvaluasiACCDO ifrmChild = new Piutang.Report.frmRpt15EvaluasiACCDO();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void notaJTOVDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt17NotaJTOVD ifrmChild = new Piutang.Report.frmRpt17NotaJTOVD();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void rekapTokoKasusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt19TokoKasus ifrmChild = new Piutang.Report.frmRpt19TokoKasus();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void agingScheduleCashFlowNotaGiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt20AgingA ifrmChild = new Piutang.Report.frmRpt20AgingA();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void rekapKeteranganTagihToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt22KetTagih ifrmChild = new Piutang.Report.frmRpt22KetTagih();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void agingScheduleNotaGiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRpt23AgingScheduleNotaGiro2 ifrmChild = new Piutang.Report.frmRpt23AgingScheduleNotaGiro2();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        

        private void kartuPiutangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_SaldoPiutangPenjualanTunai_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    dt.DefaultView.Sort = "TglNota";
                    Piutang.frmSaldoPiutangPenjualanTunai ifrmChildp = new Piutang.frmSaldoPiutangPenjualanTunai(this, dt);
                    ifrmChildp.ShowDialog();
                }
                //else
                //{
                //    MessageBox.Show("data tidak ada");
                //}
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            Piutang.frmKartuPiutangBrowse ifrmChild = new Piutang.frmKartuPiutangBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void giroTolakToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Piutang.frmGiroTolak ifrmChild = new Piutang.frmGiroTolak();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void tokoKasusToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Piutang.frmTokoHistory ifrmChild = new Piutang.frmTokoHistory();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void plafonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Piutang.frmPlafon ifrmChild = new Piutang.frmPlafon();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void vOtongToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityApplicationsBrowse ifrmChild = new Administrasi.frmSecurityApplicationsBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void partsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityPartsBrowse ifrmChild = new Administrasi.frmSecurityPartsBrowse(GlobalVar.ApplicationID);
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityRolesBrowse ifrmChild = new Administrasi.frmSecurityRolesBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityUsersBrowse ifrmChild = new Administrasi.frmSecurityUsersBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void rightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityRightsBrowse ifrmChild = new Administrasi.frmSecurityRightsBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void bukuBesarPartnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRptBukuBesarPartner ifrmChild = new GL.frmRptBukuBesarPartner();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();

        }

        private void linkPJToGLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PJTools.frmLinkPJBrowse ifrmChild = new PJTools.frmLinkPJBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void linkRJToGLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PJTools.frmLinkRjBrowse ifrmChild = new PJTools.frmLinkRjBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void kelompokBarangToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PJTools.frmKelompokBarangBrowse ifrmChild = new PJTools.frmKelompokBarangBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void gantiIDWilToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
        }

        private void perkiraanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GL.frmPerkiraanBrowse ifrmChild = new GL.frmPerkiraanBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void subPerkiraanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GL.frmPerkiraanBrowse ifrmChild = new GL.frmPerkiraanBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Testing.frmGenerate_Excel ifrm= new Testing.frmGenerate_Excel();
            ifrm.Show();
        }

        private void gantiIDWilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VWil.frmRiwayatIDWilBrowse ifrmChild = new VWil.frmRiwayatIDWilBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void uploadIDWilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VWil.frmRiwayatIDWilUpload ifrmChild = new VWil.frmRiwayatIDWilUpload();            
            ifrmChild.ShowDialog();
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadIND.frmUploadIND ifrmChild = new UploadIND.frmUploadIND();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void downloadIDWilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VWil.frmRiwayatIDWilDownload ifrmChild = new VWil.frmRiwayatIDWilDownload();
            ifrmChild.ShowDialog();
        }

        private void uploadTagihanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.frmUploadDownloadTagihan ifrmChild = new Register.frmUploadDownloadTagihan();
            ifrmChild.ShowDialog();
        }

        private void tokoAktifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmTokoAktif ifrmChild = new Piutang.Report.frmTokoAktif();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void UploadISA_Click(object sender, EventArgs e)
        {
            Kasir.frmKasirUploadDownloadISA ifrmChild = new Kasir.frmKasirUploadDownloadISA();
            ifrmChild.Show();
        }

        private void downloadISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmKasirDownloadISA ifrmChild = new Kasir.frmKasirDownloadISA();
            ifrmChild.Show();
        }

        private void downloadISAManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmKasirDownloadISA_Manual ifrmChild = new Kasir.frmKasirDownloadISA_Manual();
            ifrmChild.Show();
        }

        private void linkAGToGLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PJTools.frmLinkAGBrowse ifrmChild = new PJTools.frmLinkAGBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void vWilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VWil.frmRiwayatIDWilBrowse ifrmChild = new VWil.frmRiwayatIDWilBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Kasir.Budget.frmAccBiaya ifrmChild = new ISA.Finance.Kasir.Budget.frmAccBiaya();
            //ifrmChild.Show();
        }

        private void downloadJurnalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           //GL.frmDownloadJournal ifrmChild = new GL.frmDownloadJournal();
            //ifrmChild.MdiParent = this;
            //ifrmChild.Show();
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DKNForm.frmHiRegisterBrowse ifrmChild = new DKNForm.frmHiRegisterBrowse();
            ifrmChild.MdiParent = this;

            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();

        }

        private void barcodeNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.frmBarcodeNotaBrowse ifrmChild = new Piutang.frmBarcodeNotaBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void lapOpnameNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRptOpnameNota ifrmChild = new Piutang.Report.frmRptOpnameNota();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void saldoPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.FrmSaldoPiutangBrowse ifrmChild = new Piutang.FrmSaldoPiutangBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void PenerimaanTunaitoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmPenerimaanTunai ifrmChild = new Kasir.frmPenerimaanTunai();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;   
        }

        private void BPPtoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Kasir.frmBPPBrowse ifrmChild = new Kasir.frmBPPBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;   
        }

        private void transaksiToolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void tACToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tac.frmTAC ifrmChild = new Tac.frmTAC();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Normal;   

        }

        private void laporanSalesBLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRptSalesBL ifrmChild = new Piutang.Report.frmRptSalesBL();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Normal;   
        }

        private void tACDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tac.frmTACdownload ifrmChild = new Tac.frmTACdownload();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Normal;
        }

        private void pencapaianKolektorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmPencapaianColektor ifrmChild = new Piutang.Report.frmPencapaianColektor();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Normal;
        }

        private void kasirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void laporanLaporanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void laporanOmsetVsPembayaranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRptOmsetVsBayar ifrmChild = new Piutang.Report.frmRptOmsetVsBayar();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Normal;

        }

        private void laporanRegRekapPerBulanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.Report.frmRptRegRekapperBulan ifrmChild = new Register.Report.frmRptRegRekapperBulan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void hutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hutang.frmDaftarHutangLokal ifrmChild = new Hutang.frmDaftarHutangLokal();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void hutangPerInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hutang.Report.frmRptHutangPBLokal_Rekap_Psho ifrmChild = new Hutang.Report.frmRptHutangPBLokal_Rekap_Psho();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hutangPerInvoiceDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hutang.Report.frmRptHutangPBLokal_RekapDetail ifrmChild = new Hutang.Report.frmRptHutangPBLokal_RekapDetail();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanInsentifTagihanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.Report.frmRptInsentifTagihan ifrmChild = new Register.Report.frmRptInsentifTagihan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();

        }

        private void laporanInsentifTagihanSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.Report.frmRptInsentifTagihanSales ifrmChild = new Register.Report.frmRptInsentifTagihanSales();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void laporanAnalisaPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.Report.frmRptKebiasaanPembayaranPiutang ifrmChild = new Piutang.Report.frmRptKebiasaanPembayaranPiutang();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Normal;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Kasir.frmPenerimaanKN ifrmChild = new Kasir.frmPenerimaanKN();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;   

        }

        private void kreditNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DKNForm.frmDKNBrowse ifrmChild = new ISA.Finance.DKNForm.frmDKNBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;   
        }

        private void dKNToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kartuPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transaksiToolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void pJ3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PJ3.frmPJ3Browse ifrmChild = new PJ3.frmPJ3Browse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;

        }

        private void mingguanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.Budget.frmBudgetMingguan ifrmChild = new Kasir.Budget.frmBudgetMingguan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void bulananToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmBudget ifrmChild = new Kasir.frmBudget();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void biayaOperasionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmBiayaOperasionalBrowse ifrmChild = new Kasir.frmBiayaOperasionalBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void plafonBaruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Piutang.frmPlafonBaru ifrmChild = new Piutang.frmPlafonBaru();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();

        }

        private void uploadBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmBudgetUpload ifrmChild = new Kasir.frmBudgetUpload();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void downloadBudgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmBudgetDownload ifrmChild = new Kasir.frmBudgetDownload();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void laporanMonitoringPaycollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.Report.frmMonitoringPaycoll ifrmChild = new Kasir.Report.frmMonitoringPaycoll();
            //ifrmChild.MdiParent = this;
            ifrmChild.ShowDialog();
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            Piutang.Report.frmOmsetUmurPiutangJS Frm = new ISA.Finance.Piutang.Report.frmOmsetUmurPiutangJS();
            Frm.Show();
        }
    }
}
