using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ISA.Common;
using ISA.DAL;

namespace ISA.Trading.xpdc
{
    public partial class frmXpdcDetailUpdate : ISA.Controls.BaseForm
    {
        Guid _detailRowId;
        DataTable _detailDt;

        public frmXpdcDetailUpdate(Guid detailRowId, DataTable detailDt)
        {
            _detailRowId = detailRowId;
            _detailDt = detailDt;

            InitializeComponent();
        }

        private void frmXpdcDetailUpdate_Load(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;

            DataRow[] drs = _detailDt.Select("RowID = '" + _detailRowId.ToString() + "'");
            if (drs.Length > 0)
            {
                DataRow dr = drs[0];

                txtTglNota.DateValue = (DateTime)dr["TglSuratJalan"];
                txtNoNota.Text = dr["NoSuratJalan"].ToString();
                if (!dr.IsNull("NamaToko"))
                    txtNamaToko.Text = dr["NamaToko"].ToString();
                if (!dr.IsNull("Alamat"))
                    txtAlamat.Text = dr["Alamat"].ToString();
                if (!dr.IsNull("Kota"))
                    txtKota.Text = dr["Kota"].ToString();
                if (!dr.IsNull("Barcode"))
                    txtBarcode.Text = dr["Barcode"].ToString();
                if (!dr.IsNull("JumlahKoli"))
                    txtJmlKoli.Text = dr["JumlahKoli"].ToString();
                if (!dr.IsNull("JumlahPcs"))
                    txtJmlPcs.Text = dr["JumlahPcs"].ToString();
                if (!dr.IsNull("KeteranganKoli"))
                    txtKeteranganKoli.Text = dr["KeteranganKoli"].ToString();

                txtBarcode.Focus();
            }
            else
                cmdSave.Enabled = false;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text == string.Empty)
            {
                MessageBox.Show("Barcode harus diisi.");
                return;
            }

            if (txtJmlKoli.Text == "0")
            {
                MessageBox.Show("Jumlah Koli harus diisi.");
                return;
            }

            if (txtJmlPcs.Text == "0")
            {
                MessageBox.Show("Jumlah Pcs harus diisi.");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _detailRowId));
                    db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, txtBarcode.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@JumlahKoli", SqlDbType.Int, txtJmlKoli.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@JumlahPcs", SqlDbType.Int, txtJmlPcs.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@KeteranganKoli", SqlDbType.VarChar, txtKeteranganKoli.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { Error.LogError(ex); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
