using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using ISA.Toko.Class;

namespace ISA.Toko.Kasir
{
    public partial class frmVoucherJournalUmumUpdate : ISA.Toko.BaseForm
    {
        Guid RowID;
        enum enumformMode { New, Update };
        enumformMode formMode;
        int i;
        int index;
        string noperk, uraian, noAcc, jumlah;
        public frmVoucherJournalUmumUpdate(Form caller, string uraian)
        {
            InitializeComponent();
            this.Caller = caller;
            formMode = enumformMode.New;
            this.uraian = uraian;
        }

        public frmVoucherJournalUmumUpdate(Form caller, string noPerkiraan, string uraian, string noACC, string jumlah, int index)
        {
            InitializeComponent();
            this.Caller = caller;
            formMode = enumformMode.Update;
            this.noperk = noPerkiraan;
            this.noAcc = noACC;
            this.jumlah = jumlah;
            this.uraian = uraian;
            this.index = index;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVoucherJournalUmumUpdate_Load(object sender, EventArgs e)
        {
            lookupPerkiraanKoneksi1.Header = "BS";
            if (formMode == enumformMode.New)
            {
                lookupPerkiraanKoneksi1.NamaPerkiraan = "";
                lookupPerkiraanKoneksi1.NoPerkiraan = "[CODE]";
                tbNilai.Clear();
                tbNoAcc.Clear();
                tbUraian.Text = uraian;
            }
            else
            {
                lookupPerkiraanKoneksi1.NamaPerkiraan = "";
                lookupPerkiraanKoneksi1.NoPerkiraan = noperk;
                tbNilai.Text = jumlah;
                tbNoAcc.Text = noAcc;
                tbUraian.Text = uraian;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (formMode == enumformMode.New)
            {
                string RecordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                RowID = Guid.NewGuid();
                frmKasbonUpdate frm = new frmKasbonUpdate();
                frm = (frmKasbonUpdate)Caller;
                frm.InsertGridVoucher(RowID, RecordID, DateTime.Today, lookupPerkiraanKoneksi1.NoPerkiraan, tbUraian.Text, tbNoAcc.Text, Convert.ToDouble(tbNilai.Text));
                frm.VoucherRefresh();
                this.Close();
            }
            else
            {
                frmKasbonUpdate frm = new frmKasbonUpdate();
                frm = (frmKasbonUpdate)Caller;
                frm.UpdateGridVoucher(index,lookupPerkiraanKoneksi1.NoPerkiraan, tbUraian.Text, tbNoAcc.Text, Convert.ToDouble(tbNilai.Text));
                frm.VoucherRefresh();
                this.Close();
            }
        }

     
    }
}
