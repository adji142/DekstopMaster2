using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ISA.Common;
using ISA.DAL;

namespace ISA.Toko.xpdc
{
    public partial class frmXpdcDetailAdd : ISA.Controls.BaseForm
    {
        private Guid _headerId;
        private DateTime _tglKirim;
        private DataTable _detailDt = new DataTable();

        public frmXpdcDetailAdd(Guid headerId, DateTime tglKirim, DataTable detailDt)
        {
            _headerId = headerId;
            _tglKirim = tglKirim;
            _detailDt = detailDt;

            InitializeComponent();
        }

        private void frmXpdcDetailAdd_Load(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private bool NotaFound(string noNota)
        {
            bool isFound = false;

            foreach (DataGridViewRow row in dgvNota.Rows)
            {
                if (noNota == Tools.isNull(row.Cells[Nomor.Name].Value, string.Empty).ToString())
                {
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            frmXpdcDetailAddNota frm = new frmXpdcDetailAddNota();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK && frm.NotaEkspedisiList.Count > 0)
            {
                foreach (NotaEkspedisi notaEkspedisi in frm.NotaEkspedisiList)
                {
                    if (!NotaFound(notaEkspedisi.Nomor))
                    {
                        int newRow = dgvNota.Rows.Add(1);

                        DataGridViewRow row = dgvNota.Rows[newRow];

                        row.Cells[RowID.Name].Value = notaEkspedisi.RowID;
                        row.Cells[Barcode.Name].Value = string.Empty;
                        row.Cells[QtyPcs.Name].Value = GetQtyNota(notaEkspedisi.RowID, notaEkspedisi.TransactionType);
                        row.Cells[TransacType.Name].Value = notaEkspedisi.TransactionType;
                        row.Cells[Tanggal.Name].Value = notaEkspedisi.Tanggal;
                        row.Cells[Nomor.Name].Value = notaEkspedisi.Nomor;
                        row.Cells[Kode.Name].Value = notaEkspedisi.Kode;
                        row.Cells[Nama.Name].Value = notaEkspedisi.Nama;
                        row.Cells[Alamat.Name].Value = notaEkspedisi.Alamat;
                        row.Cells[Kota.Name].Value = notaEkspedisi.Kota;
                        row.Cells[BarcodeNota.Name].Value = notaEkspedisi.Barcode;

                        if (notaEkspedisi.TransactionType == "AG" || notaEkspedisi.TransactionType == "TG")
                            row.Cells[Barcode.Name].Value = notaEkspedisi.TransactionType + notaEkspedisi.Nomor;
                    }
                }
            }
        }

        private bool BarcodeFound(string barcode)
        {
            bool isFound = false;

            foreach (DataGridViewRow row in dgvNota.Rows)
            {
                if (barcode == Tools.isNull(row.Cells[Barcode.Name].Value, string.Empty).ToString())
                {
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }

        private bool BarcodeFound(DataTable dt, string barcode)
        {
            bool isFound = false;

            if (dt != null)
            {
                DataRow[] dr = dt.Select("Barcode = '" + barcode + "'");

                isFound = dr.Length > 0;
            }

            return isFound;
        }

        private bool BarcodeFound(string barcode, int excludeRow)
        {
            bool isFound = false;

            foreach (DataGridViewRow row in dgvNota.Rows)
            {
                string cBarcode = Tools.isNull(row.Cells[Barcode.Name].Value, string.Empty).ToString();
                if (row.Index != excludeRow && barcode == cBarcode && cBarcode != "")
                {
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_SEARCH_Nota"));
                    db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, barcode));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                    isFound = true;
            }

            return isFound;
        }


        private int GetQtyNota(Guid notaRowId, string transactionType)
        {
            int qtyNota = 0;

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_Aggregate"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, notaRowId));
                db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, transactionType));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                if (!dt.Rows[0].IsNull("QtySuratJalan"))
                    qtyNota = Convert.ToInt32(dt.Rows[0]["QtySuratJalan"]);
            }


            return qtyNota;
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtBarcode.Text != string.Empty)
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_SEARCH_Barcode"));
                        db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, txtBarcode.Text));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    if (dt.Rows.Count > 0)
                    {
                        if (BarcodeFound(txtBarcode.Text))
                        {
                            MessageBox.Show("Barcode sudah terdaftar.");
                            txtBarcode.SelectAll();
                            txtBarcode.Focus();
                            return;
                        }

                        if (BarcodeFound(_detailDt, txtBarcode.Text))
                        {
                            MessageBox.Show("Barcode sudah terdaftar.");
                            txtBarcode.SelectAll();
                            txtBarcode.Focus();
                            return;
                        }

                        Guid notaJualId = (Guid)dt.Rows[0]["RowID"];
                        string noNota = dt.Rows[0]["NoSuratJalan"].ToString();
                        DataTable dtXpdc = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_SEARCH_Nota"));
                            db.Commands[0].Parameters.Add(new Parameter("@NotaJualID", SqlDbType.UniqueIdentifier, notaJualId));
                            dtXpdc = db.Commands[0].ExecuteDataTable();
                        }

                        if (dtXpdc.Rows.Count > 0)
                        {
                            MessageBox.Show("Sudah ada pengiriman terhadap nota " + noNota);
                            txtBarcode.SelectAll();
                            txtBarcode.Focus();
                            return;
                        }

                        int newRow = dgvNota.Rows.Add(1);

                        DataGridViewRow row = dgvNota.Rows[newRow];

                        row.Cells[RowID.Name].Value = (Guid)dt.Rows[0]["RowID"];
                        row.Cells[Barcode.Name].Value = txtBarcode.Text;
                        row.Cells[QtyPcs.Name].Value = GetQtyNota((Guid)dt.Rows[0]["RowID"], dt.Rows[0]["TransactionType"].ToString());
                        row.Cells[TransacType.Name].Value = dt.Rows[0]["TransactionType"].ToString();
                        row.Cells[Tanggal.Name].Value = (DateTime)dt.Rows[0]["TglSuratJalan"];
                        row.Cells[Nomor.Name].Value = dt.Rows[0]["NoSuratJalan"].ToString();
                        row.Cells[Kode.Name].Value = dt.Rows[0]["KodeToko"].ToString();
                        row.Cells[Nama.Name].Value = dt.Rows[0]["NamaToko"].ToString();
                        row.Cells[Alamat.Name].Value = dt.Rows[0]["Alamat"].ToString();
                        row.Cells[Kota.Name].Value = dt.Rows[0]["Kota"].ToString();
                        row.Cells[BarcodeNota.Name].Value = txtBarcode.Text;

                        txtBarcode.SelectAll();
                        txtBarcode.Focus();
                    }
                    else
                        cmdSearch_Click(sender, new EventArgs());
                }
                catch (Exception ex) { Error.LogError(ex); }
                finally { Cursor.Current = Cursors.Default; }
            }
        }

        private bool IsNumeric(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (dgvNota.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    using (Database db = new Database())
                    {
                        int index = 0;

                        foreach (DataGridViewRow row in dgvNota.Rows)
                        {
                            string barcode = Tools.isNull(row.Cells[Barcode.Name].Value, string.Empty).ToString();
                            if (barcode == string.Empty)
                            {
                                MessageBox.Show("Barcode harus diisi.");
                                row.Cells[Barcode.Name].Selected = true;
                                return;
                            }

                            DateTime tglNota = (DateTime)row.Cells[Tanggal.Name].Value;
                            string noNota = Tools.isNull(row.Cells[Nomor.Name].Value, string.Empty).ToString();
                            string barcodeNota = Tools.isNull(row.Cells[BarcodeNota.Name].Value, string.Empty).ToString();
                            if (barcodeNota != string.Empty)
                            {
                                if (barcode != barcodeNota)
                                {
                                    MessageBox.Show("Invalid barcode. Barcode tidak sesuai dengan yang tercetak di nota " + noNota);
                                    row.Cells[Barcode.Name].Selected = true;
                                    return;
                                }
                            }

                            string transacType = row.Cells[TransacType.Name].Value.ToString();
                            //if (transacType != "AG" && transacType != "TG" && !IsNumeric(barcode))
                            if (transacType != "AG" && !IsNumeric(barcode))
                            {
                                if (barcode.Length != 12)
                                {
                                    if (MessageBox.Show("Invalid barcode. Panjang barcode " + noNota + " tidak sesuai. Lanjut?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                    {
                                        row.Cells[Barcode.Name].Selected = true;
                                        return;
                                    }
                                }

                                string checkBarcode = noNota + tglNota.ToString("yyyy").Substring(1,3) + tglNota.ToString("MM");
                                if (barcode != checkBarcode)
                                {
                                    if (MessageBox.Show("Invalid barcode. Barcode tidak sesuai dengan yang tercetak di nota " + noNota + ". Lanjut?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                    {
                                        row.Cells[Barcode.Name].Selected = true;
                                        return;
                                    }
                                }
                            }

                            int qtyKoli = 0;
                            string koli = Tools.isNull(row.Cells[QtyKoli.Name].Value, "0").ToString();

                            if (!int.TryParse(koli, out qtyKoli))
                            {
                                MessageBox.Show("Koli harus diisi angka.");
                                row.Cells[QtyKoli.Name].Selected = true;
                                return;
                            }

                            if (qtyKoli < 0)
                            {
                                MessageBox.Show("Invalid koli.");
                                row.Cells[QtyKoli.Name].Selected = true;
                                return;
                            }

                            int qtyPcs = 0;
                            string pcs = Tools.isNull(row.Cells[QtyPcs.Name].Value, "0").ToString();

                            if (!int.TryParse(pcs, out qtyPcs))
                            {
                                MessageBox.Show("Pcs harus diisi angka.");
                                row.Cells[QtyPcs.Name].Selected = true;
                                return;
                            }

                            if (qtyPcs == 0)
                            {
                                MessageBox.Show("Pcs harus diisi.");
                                row.Cells[QtyPcs.Name].Selected = true;
                                return;
                            }

                            //if (BarcodeFound(barcode, row.Index))
                            //{
                            //    MessageBox.Show("Barcode sudah terdaftar.");
                            //    row.Cells[Barcode.Name].Selected = true;
                            //    return;
                            //}

                            db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_INSERT"));
                            db.Commands[index].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                            db.Commands[index].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _headerId));
                            db.Commands[index].Parameters.Add(new Parameter("@NotaJualID", SqlDbType.UniqueIdentifier, (Guid)row.Cells[RowID.Name].Value));
                            db.Commands[index].Parameters.Add(new Parameter("@TglSuratJalan", SqlDbType.DateTime, (DateTime)row.Cells[Tanggal.Name].Value));
                            db.Commands[index].Parameters.Add(new Parameter("@NoSuratJalan", SqlDbType.VarChar, row.Cells[Nomor.Name].Value.ToString()));
                            db.Commands[index].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, transacType));
                            db.Commands[index].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, row.Cells[Kode.Name].Value.ToString()));
                            db.Commands[index].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, barcode));
                            db.Commands[index].Parameters.Add(new Parameter("@JumlahKoli", SqlDbType.Int, qtyKoli));
                            db.Commands[index].Parameters.Add(new Parameter("@JumlahPcs", SqlDbType.Int, qtyPcs));
                            db.Commands[index].Parameters.Add(new Parameter("@KeteranganKoli", SqlDbType.VarChar, Tools.isNull(row.Cells[KeteranganKoli.Name].Value,string.Empty).ToString()));
                            db.Commands[index].Parameters.Add(new Parameter("@TglKirim", SqlDbType.DateTime, _tglKirim));
                            db.Commands[index].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));

                            index++;
                        }

                        db.BeginTransaction();
                        foreach (Command cmd in db.Commands)
                        {
                            cmd.ExecuteNonQuery();
                        }
                        db.CommitTransaction();

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex) { Error.LogError(ex); }
                finally { Cursor.Current = Cursors.Default; }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
