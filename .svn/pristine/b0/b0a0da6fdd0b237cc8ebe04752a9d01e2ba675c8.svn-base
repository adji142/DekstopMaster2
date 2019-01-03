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
    public partial class frmXpdcDetailAddNota : ISA.Controls.BaseForm
    {
        private IList<NotaEkspedisi> _notaEkspedisiList = new List<NotaEkspedisi>();
        public IList<NotaEkspedisi> NotaEkspedisiList
        {
            get { return _notaEkspedisiList; }
        }

        public frmXpdcDetailAddNota()
        {
            InitializeComponent();
        }

        private void frmXpdcDetailAddNota_Load(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;

            rdbTgl.FromDate = GlobalVar.DateOfServer;
            rdbTgl.ToDate = GlobalVar.DateOfServer;

            cboSearch.SelectedIndex = 0;
            txtNoNota.Focus();
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNoNota.Visible = cboSearch.SelectedIndex == 0;
            rdbTgl.Visible = cboSearch.SelectedIndex == 1;

            if (cboSearch.SelectedIndex == 1)
            {
                txtNoNota.Text = string.Empty;
                cmdSearch_Click(sender, e);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_XpcDetail_Nota_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    if (txtNoNota.Text != string.Empty)
                        db.Commands[0].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, txtNoNota.Text));
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, (DateTime)rdbTgl.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, (DateTime)rdbTgl.ToDate));
                    }

                    dt = db.Commands[0].ExecuteDataTable();
                }
                dgvNota.AutoGenerateColumns = false;
                dgvNota.DataSource = dt;
            }
            catch (Exception ex) { Error.LogError(ex); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void txtNoNota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdSearch_Click(sender, e);
        }

        private void rdbTgl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdSearch_Click(sender, e);
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            _notaEkspedisiList = new List<NotaEkspedisi>();

            try
            {
                foreach (DataGridViewRow row in dgvNota.Rows)
                {
                    bool isChecked = (bool)Tools.isNull(row.Cells[Cek.Name].Value, false);
                    if (isChecked)
                    {
                        NotaEkspedisi notaEkspedisi = new NotaEkspedisi();
                        notaEkspedisi.RowID = (Guid)row.Cells[RowID.Name].Value;
                        notaEkspedisi.TransactionType = row.Cells[TransacType.Name].Value.ToString();
                        notaEkspedisi.Tanggal = (DateTime)row.Cells[Tanggal.Name].Value;
                        notaEkspedisi.Nomor = row.Cells[Nomor.Name].Value.ToString();
                        notaEkspedisi.Kode = row.Cells[Kode.Name].Value.ToString();
                        notaEkspedisi.Nama = row.Cells[Nama.Name].Value.ToString();
                        notaEkspedisi.Alamat = Tools.isNull(row.Cells[Alamat.Name].Value, string.Empty).ToString();
                        notaEkspedisi.Kota = Tools.isNull(row.Cells[Kota.Name].Value, string.Empty).ToString();
                        notaEkspedisi.Barcode = Tools.isNull(row.Cells[Barcode.Name].Value, string.Empty).ToString();

                        _notaEkspedisiList.Add(notaEkspedisi);
                    }
                }
            }
            catch (Exception ex) { Error.LogError(ex); }
            finally { Cursor.Current = Cursors.Default; }

            if (_notaEkspedisiList.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Tidak ada data yang dipilih. Silahkan pilih dulu datanya.");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class NotaEkspedisi
    {
        public Guid RowID { get; set; }
        public string TransactionType { get; set; }
        public DateTime Tanggal { get; set; }
        public string Nomor { get; set; }
        public string Kode { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Kota { get; set; }
        public string Barcode { get; set; }
    }
}
