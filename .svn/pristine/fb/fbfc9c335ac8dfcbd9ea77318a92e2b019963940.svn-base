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
using ISA.Toko.Class;
using ISA.Toko;

namespace ISA.Toko.xpdc
{
    public partial class frm_barcode_detail_kirim : ISA.Controls.BaseForm
    {
        Guid _rowID = Guid.Empty;

        public frm_barcode_detail_kirim(Form Caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = Caller;
        }

        private void frm_barcode_detail_kirim_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_GRIDLIST"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            TglNota.DateValue = (DateTime?)dt.Rows[0]["TglSuratJalan"];
            NoNota.Text = Tools.isNull(dt.Rows[0]["NoSuratJalan"], "").ToString();
            NamaToko.Text = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
            Alamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
            Kota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
            KodeBarcode.Text = Tools.isNull(dt.Rows[0]["Barcode"], "").ToString();
            Nominal.Text = Tools.isNull(dt.Rows[0]["SumRpNet"], 0).ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KodeBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cek_barcode(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (MessageBox.Show("Data Sudah Benar...?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UpdateDataGridDetailxpdc();
                    if (this.Caller is frm_kirim)
                    {
                        frm_kirim frmCaller = (frm_kirim)this.Caller;
                        frmCaller.RefreshDataDetail();
                    }
                    this.Close();
                }
        }

        private void UpdateDataGridDetailxpdc()
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                try
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, KodeBarcode.Text));
                    db.Commands[0].ExecuteNonQuery();
                    MessageBox.Show(Messages.Confirm.UpdateSuccess);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    db.RollbackTransaction();
                    MessageBox.Show("Gagal Menyimpan Data");
                }
            }
        }

    }
}
