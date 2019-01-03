using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.RJ3
{
    public partial class frmRJ3Update : ISA.Toko.BaseForm
    {
        Guid _rowID;
        DataTable dt;

        public frmRJ3Update(Form caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmRJ3Update_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                txtTglMPR.DateValue = (DateTime)dt.Rows[0]["TglMPR"];
                txtTglGudang.DateValue = (DateTime)dt.Rows[0]["TglGudang"];
                txtTglNotaRetur.DateValue = (DateTime)(Tools.isNull(dt.Rows[0]["TglNotaRetur"], dt.Rows[0]["TglGudang"]));
                txtNoMPR.Text = dt.Rows[0]["NoMPR"].ToString();
                txtNoNotaRetur.Text = dt.Rows[0]["NoNotaRetur"].ToString();
                txtBagPenjualan.Text = Tools.isNull(dt.Rows[0]["BagPenjualan"], "").ToString();
                txtPenerima.Text = Tools.isNull(dt.Rows[0]["Penerima"], "").ToString();
                txtNamaToko.Text = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
                txtAlamat.Text = Tools.isNull(dt.Rows[0]["AlamatKirim"], "").ToString();
                txtKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                txtNilaiRetur.Text = Tools.isNull(dt.Rows[0]["NilaiRetur"], 0).ToString();
                txtNilaiRetur2.Text = Tools.isNull(dt.Rows[0]["NilaiRetur2"], 0).ToString();

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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tgl Terima Retur: " + txtTglNotaRetur.Text + ", Data akan disimpan?", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        // Proses isi TglNotaRetur
                        db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dt.Rows[0]["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, dt.Rows[0]["Cabang1"]));
                        db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, dt.Rows[0]["Cabang1"]));
                        db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dt.Rows[0]["ReturID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@noMPR", SqlDbType.VarChar, dt.Rows[0]["NoMPR"]));
                        db.Commands[0].Parameters.Add(new Parameter("@noNotaRetur", SqlDbType.VarChar, dt.Rows[0]["NoNotaRetur"]));
                        db.Commands[0].Parameters.Add(new Parameter("@noTolak", SqlDbType.VarChar, dt.Rows[0]["NoTolak"]));
                        db.Commands[0].Parameters.Add(new Parameter("@tglMPR", SqlDbType.DateTime, dt.Rows[0]["TglMPR"]));
                        db.Commands[0].Parameters.Add(new Parameter("@tglNotaRetur", SqlDbType.DateTime, txtTglNotaRetur.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dt.Rows[0]["KodeToko"]));
                        db.Commands[0].Parameters.Add(new Parameter("@tglTolak", SqlDbType.DateTime, dt.Rows[0]["TglTolak"]));
                        db.Commands[0].Parameters.Add(new Parameter("@pengambilan", SqlDbType.VarChar, dt.Rows[0]["Pengambilan"]));
                        db.Commands[0].Parameters.Add(new Parameter("@tglPengambilan", SqlDbType.DateTime, dt.Rows[0]["TglPengambilan"]));
                        db.Commands[0].Parameters.Add(new Parameter("@tglGudang", SqlDbType.DateTime, dt.Rows[0]["TglGudang"]));
                        db.Commands[0].Parameters.Add(new Parameter("@bagPenjualan", SqlDbType.VarChar, dt.Rows[0]["BagPenjualan"]));
                        db.Commands[0].Parameters.Add(new Parameter("@penerima", SqlDbType.VarChar, dt.Rows[0]["Penerima"]));
                        db.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, dt.Rows[0]["LinkID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dt.Rows[0]["isClosed"]));
                        db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, dt.Rows[0]["NPrint"]));
                        db.Commands[0].Parameters.Add(new Parameter("@tglRQRetur", SqlDbType.DateTime, dt.Rows[0]["TglRQRetur"]));
                        db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRJ3Update_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmRJ3Browser)
                {
                    frmRJ3Browser frmCaller = (frmRJ3Browser)this.Caller;
                    frmCaller.RefreshDataReturJual();
                    frmCaller.FindHeader("HeaderRowID", _rowID.ToString());
                }
            }
        }
    }
   
}
