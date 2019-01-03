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
    public partial class frm_barcode : ISA.Toko.BaseForm
    {
        Guid _rowID = Guid.Empty;
        string cFrom_ = string.Empty; 

        public frm_barcode(Form Caller, Guid rowID, string cFrom)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = Caller;
            cFrom_ = cFrom;
        }


        private void Barcode_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_TMPLIST"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            TglNota.DateValue = (DateTime?)dt.Rows[0]["TglSuratJalan"];
            NoNota.Text = Tools.isNull(dt.Rows[0]["NoSuratJalan"], "").ToString();
            NamaToko.Text = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
            Alamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
            Kota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();           
            Nominal.Text = Tools.isNull(dt.Rows[0]["SumRpNet"], "").ToString();
            
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void commandButton2_Click(object sender, EventArgs e)
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
                    UpdateDataGridNotaJual();
                    if (this.Caller is frm_detail_xpdc)
                    {
                        frm_detail_xpdc frmCaller = (frm_detail_xpdc)this.Caller;
                        frmCaller.RefreshDataXpdc_GetNotaAgList();
                    }   
                    this.Close();
                }
        }

        private void UpdateDataGridNotaJual()
        {
            using (Database db2 = new Database())
            {
                DataTable dt2 = new DataTable();
                try
                {
                    db2.Commands.Add(db2.CreateCommand("usp_PengirimanXpdc_GetNotaJualAg_UPDATE"));
                    db2.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db2.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, KodeBarcode.Text));
                    db2.Commands[0].ExecuteNonQuery();
                    MessageBox.Show(Messages.Confirm.UpdateSuccess);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    db2.RollbackTransaction();
                    MessageBox.Show("Gagal Menyimpan Data");
                }
            }
        }
    }
}
