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
    public partial class frm_batal_kirim : ISA.Controls.BaseForm
    {
        Guid _rowID = Guid.Empty;

        public frm_batal_kirim(Form Caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = Caller;
        }

        private void frm_batal_kirim_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_GRIDLIST"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            NamaToko.Text = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
            Alamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
            Kota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
            TransactionType.Text = Tools.isNull(dt.Rows[0]["TransactionType"], "").ToString();
            Catatan.Text = Tools.isNull(dt.Rows[0]["Catatan"], "").ToString();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                try
                {
                    /*
                    int nKembali = 0;
                    string cKembali = string.Empty;
                    string cKemb;
                    cKembali = dt.Rows[0]["Kembali"].ToString();
                    if (cKembali == null || cKembali == "")
                    {
                        nKembali = 0;
                    }
                    else
                    {
                        nKembali = Convert.ToInt32(cKembali);
                    }
                    nKembali++;
                    cKemb = nKembali.ToString();
                    MessageBox.Show(cKemb);
                     */ 

                    db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_BatalKirim_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Catatan.Text));
                    db.Commands[0].ExecuteNonQuery();
                    MessageBox.Show(Messages.Confirm.UpdateSuccess);

                    if (this.Caller is frm_kirim)
                    {
                        frm_kirim frmCaller = (frm_kirim)this.Caller;
                        frmCaller.RefreshDataDetail();
                    }
                    this.Close();
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
