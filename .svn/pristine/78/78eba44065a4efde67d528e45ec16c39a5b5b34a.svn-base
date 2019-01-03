using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ISA.DAL;

namespace ISA.Finance.Register
{
    public partial class frmRegisterUpdateBarcode : Form
    {
        private Guid _headerId;
        private string _barcode;

        private string _kpRecId;
        public string KpRecId
        {
            get { return _kpRecId; }
        }

        public frmRegisterUpdateBarcode(Guid headerId, string barcode)
        {
            this.DialogResult = DialogResult.Cancel;

            _headerId = headerId;
            _barcode = barcode;

            InitializeComponent();
        }

        private void frmRegisterUpdateBarcode_Load(object sender, EventArgs e)
        {
            txtBarcode.Text = _barcode;
            txtBarcode.Focus();
        }

        private void txtNoNota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdOK_Click(sender, e);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            string noNota = txtNoNota.Text.Trim();

            if (noNota == string.Empty)
            {
                MessageBox.Show("No. Nota harus diisi.");
                return;
            }

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_SEARCH_NoNota"));
                db.Commands[0].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, noNota));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Nota tidak ditemukan di Nota Penjualan.");
                return;
            }
            else if (dt.Rows.Count > 1)
            {
                MessageBox.Show("Nota ditemukan lebih dari satu di Nota Penjualan.");
                return;
            }

            Guid notaJualId = (Guid)dt.Rows[0]["RowID"];
            _kpRecId = dt.Rows[0]["RecordID"].ToString();

            dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_SEARCH_Nota"));
                db.Commands[0].Parameters.Add(new Parameter("@NotaJualID", SqlDbType.UniqueIdentifier, notaJualId));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Belum ada ekspedisi untuk nota tersebut. Silahkan masukan data ekspedisinya.");
                return;
            }

            Guid xpdcDetailRowId = (Guid)dt.Rows[0]["RowID"];

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_UPDATE"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, xpdcDetailRowId));
                db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, _barcode));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();
            }

            dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_TagihanDetail_LIST_ByRecID"));
                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _headerId));
                db.Commands[0].Parameters.Add(new Parameter("@KPRecID", SqlDbType.VarChar, _kpRecId));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Nota belum terdaftar di register tagihan.");
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
