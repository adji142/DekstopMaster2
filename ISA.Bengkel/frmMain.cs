using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Bengkel
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            ISA.Bengkel.Helper.SecurityManager.IsAuthenticate("IAN", "password");
        }

        public void RegisterChild(Control iform)
        {
            //this.pnlMain.ContentPanel.Controls.Add(iform);
        }

        private void BuildForm(BaseForm ifrmChild)
        {
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void tabelMekanikToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BuildForm(new Master.frmMekanikBrowse());
        }

        private void tabelJenisMotorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildForm(new Master.frmMotorBrowse());
        }

        private void tabelMotorCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildForm(new Master.frmCustomerBrowse());
        }

        private void pembelianSparePartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaksi.frmPembelianBengkel ifrmChild = new Transaksi.frmPembelianBengkel();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void serviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaksi.frmServiceBrowser ifrmChild = new Transaksi.frmServiceBrowser();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void customerBengkelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildForm(new Master.frmCustomerBrowse());
        }

        private void mekanikBengkelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildForm(new Master.frmMekanikBrowse());
        }

        private void motorBengkelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildForm(new Master.frmMotorBrowse());
        }

        private void laporanBengkelPerPeriodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmRptLaporanBengkel ifrmChild = new Laporan.frmRptLaporanBengkel();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GlobalVar.initialize();
            //Setorans.initialize();
            //Kasirs.initialize();
            //SecurityManager.AlwaysAuthenticate();
            //statusStrip1.Items[0].Text = SecurityManager.UserID;
            //if (!SecurityManager.IsManager())
            //{
            //    PerformSecurityCheck();
            //}
            tsUserID.Text = "User ID: " + SecurityManager.UserID;
            tsHost.Text = "Host: " + ISA.DAL.Database.Host;
            txtVersion.Text = txtVersion.Text + Application.ProductVersion;
            //if (SecurityManager.UserID == "DEV")
            //{
            //    debugToolStripMenuItem.Visible = true;
            //}
        }

        private void frmMain_Load_1(object sender, EventArgs e)
        {
            GlobalVar.initialize();
            //Setorans.initialize();
            //Kasirs.initialize();
            //SecurityManager.AlwaysAuthenticate();
            //statusStrip1.Items[0].Text = SecurityManager.UserID;
            //if (!SecurityManager.IsManager())
            //{
            //    PerformSecurityCheck();
            //}
            tsUserID.Text = "User ID: " + SecurityManager.UserID;
            tsHost.Text = "Host: " + ISA.DAL.Database.Host;
            txtVersion.Text = txtVersion.Text + Application.ProductVersion;
            //if (SecurityManager.UserID == "DEV")
            //{
            //    debugToolStripMenuItem.Visible = true;
            //}
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
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

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SecurityManager.SetUserLogin(SecurityManager.UserID, false);
            Application.Exit();
        }

        private void standarServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Master.frmStandarServiceBrowse ifrmChild = new Master.frmStandarServiceBrowse();
            Master.frmStandarBiayaServiceBrowse ifrmChild = new Master.frmStandarBiayaServiceBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void masterStokBengkelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmMasterStokBengkelBrowse ifrmChild = new Master.frmMasterStokBengkelBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void orderPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmRptOrderPembelianBarang ifrmChild = new Laporan.frmRptOrderPembelianBarang();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void laporanKasHarianToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void laporanPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmRptPembelianBengkel ifrmChild = new Laporan.frmRptPembelianBengkel();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanRekapServiceBengkelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLaporanRekapBengkel ifrmChild = new Laporan.frmLaporanRekapBengkel();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void laporanRekapPerNotaBengkelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmRptRekapNotaBengkel ifrmChild = new Laporan.frmRptRekapNotaBengkel();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Laporan.frmRptServiceBengkelDetail ifrmChild = new Laporan.frmRptServiceBengkelDetail();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void masterInstansiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.FrmInstansi FRM = new ISA.Bengkel.Master.FrmInstansi();
            FRM.MdiParent = this;
            this.RegisterChild(FRM);
            FRM.Show();
        }
    }
}

