using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.PJ3
{
    public partial class frmLinkPiutangMasalFilter : ISA.Trading.BaseForm
    {
        bool _perToko;
        DataTable dtNota;

        public frmLinkPiutangMasalFilter(Form caller, bool perToko)
        {
            InitializeComponent();
            _perToko = perToko;
            this.Caller = caller;            
        }

        private void frmLinkPiutangMasalFilter_Load(object sender, EventArgs e)
        {
            if (_perToko)
            {
                lblNamaToko.Visible = true;
                lookupToko.Visible = true;
                this.Title = "Link Penjualan Kredit per Toko ke Piutang";
                this.Text = "PJ3";
            }
            else
            {
                lblNamaToko.Visible = false;
                lookupToko.Visible = false;
                this.Title = "Link Penjualan Kredit ke Piutang";
                this.Text = "PJ3";
            }

            rdbTglterima.Focus();            
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbTglterima.FromDate.ToString() == "" || rdbTglterima.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTglterima, "Range Tgl Terima masih kosong");
                valid = false;
            }

            if (_perToko && lookupToko.KodeToko == "[Code]")
            {
                errorProvider1.SetError(lookupToko, "Belum pilih toko");
                valid = false;
            }
            return valid;
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }
            LinkToPiutangMasal();
        }

        private void LinkToPiutangMasal()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_LinkPiutangMasal"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTglterima.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTglterima.ToDate));
                    if (_perToko)
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko.KodeToko));
                    if (txtNoNota.Text != "")
                        db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.DateTime, rdbTglterima.ToDate));

                    dtNota = db.Commands[0].ExecuteDataTable();
                }

                if (dtNota.Rows.Count > 0)
                {
                    using (Database db = new Database())
                    {
                        db.BeginTransaction();
                        for (int i = 0; i < dtNota.Rows.Count; i++)
                        {
                            db.Commands.Add(db.CreateCommand("psp_PJ3_LinkToPiutang"));
                            db.Commands[i].Parameters.Add(new Parameter("@notaID", SqlDbType.UniqueIdentifier, dtNota.Rows[i]["RowID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtNota.Rows[i]["RecordID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@tglJatuhTempo", SqlDbType.DateTime, dtNota.Rows[i]["TglJatuhTempo"]));
                            db.Commands[i].Parameters.Add(new Parameter("@tipeLink", SqlDbType.VarChar, "2")); // TipeLink 2 untuk link piutang anak cabang
                            db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[i].ExecuteNonQuery();
                        }
                        db.CommitTransaction();
                    }
                    MessageBox.Show("PROSES SELESAI...");
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("TIDAK ADA DATA...");
                }
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLinkPiutangMasalFilter_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.Yes)
            {
                frmPJ3Browser frmCaller = (frmPJ3Browser)this.Caller;
                frmCaller.RefreshDataNotaJual();
            }
        }


    }
}
