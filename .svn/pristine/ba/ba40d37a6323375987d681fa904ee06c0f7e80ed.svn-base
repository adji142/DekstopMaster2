using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Master
{
    public partial class frmStokBarcode : ISA.Trading.BaseForm
    {
        DataTable dt = new DataTable();
        DataTable dtStokBarcode = new DataTable();

        public frmStokBarcode()
        {
            InitializeComponent();
        }

        public void RefreshDataStok()
        {
            dataGridView1.AutoGenerateColumns = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtSearch.Text));

                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    RefreshDataStokBarcode();
                    lblNamaBarang.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["namaStok"].Value.ToString();
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

        public void RefreshDataStokBarcode()
        {
            try
            {
                using (Database db = new Database())
                {
                    string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["IDBarang"].Value.ToString();

                    db.Commands.Add(db.CreateCommand("usp_StokBarcode_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    dtStokBarcode = db.Commands[0].ExecuteDataTable();
                    dataGridView2.DataSource = dtStokBarcode;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmStokBarcode_Load(object sender, EventArgs e)
        {
            if (SecurityManager.UserID == "PSHO")
            {
                cmdAdd.Enabled = true;
                cmdEdit.Enabled = true;
                cmdDelete.Enabled = true;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataStok();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                RefreshDataStokBarcode();
                lblNamaBarang.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["namaStok"].Value.ToString();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (!lUserAccess())
            {
                MessageBox.Show("Belum ada wewenang.");
                return;
            }

            if (dataGridView1.SelectedCells.Count > 0)
            {
                string _idBarang = dataGridView1.SelectedCells[0].OwningRow.Cells["IDBarang"].Value.ToString();
                string _Header = dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                //if (dtStokBarcode.Rows.Count > 0)
                //{
                //    MessageBox.Show("ID Barang " + _idBarang + " sudah memiliki Barcode");
                //}
                //else
                //{
                    Master.frmStokBarcodeUpdate ifrmChild = new Master.frmStokBarcodeUpdate(this, _Header, _idBarang);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();

            //}
            }
            else
            {
                MessageBox.Show("Tekan Tombol Search dulu untuk menampilkan data master Stok.");
            }
        }

        private bool lUserAccess()
        {
            Boolean x = true;
            if (SecurityManager.UserName != "MANAGER")
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dtUser = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_UserAccess_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, "STOK BARCODE"));
                        db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, SecurityManager.UserID));
                        dtUser = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtUser.Rows.Count > 0)
                    {
                        if (Tools.isNull(dtUser.Rows[0]["Value"], "0").ToString() == "0")
                        {
                            x = false;
                        }
                    }
                    else
                    {
                        x = false;
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
            return x;
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (!lUserAccess())
            {
                MessageBox.Show("Belum ada wewenang.");
                return;
            }

            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Tidak ada data yang diedit.");
                return;
            }
            else if (dataGridView2.SelectedCells.Count == 0)
            {
                MessageBox.Show("Tidak ada data yang diedit.");
                return;
            }
            Guid _rowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["row"].Value;
            string _idBarang = dataGridView1.SelectedCells[0].OwningRow.Cells["IDBarang"].Value.ToString();
            string _namaStok = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
            Master.frmStokBarcodeUpdate ifrmChild = new Master.frmStokBarcodeUpdate(this, _rowID, _idBarang, _namaStok);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hapusData()
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Tidak ada data yang didelete.");
                return;
            }
            else if (dataGridView2.SelectedCells.Count == 0)
            {
                MessageBox.Show("Tidak ada data yang didelete.");
                return;
            }
            if (dataGridView2.SelectedCells.Count > 0)
            {
                Guid RowID_ = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["row"].Value;
                string Barcode_ = dataGridView2.SelectedCells[0].OwningRow.Cells["Barcode"].Value.ToString();

                if (MessageBox.Show("Hapus Data : " + Barcode_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_StokBarcode_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, RowID_));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Record telah dihapus");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (!lUserAccess())
            {
                MessageBox.Show("Belum ada wewenang.");
                return;
            }
            hapusData();
            RefreshDataStokBarcode();
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {


        }

        private void txtBarcode_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dtc = new DataTable();
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_StokBarcode_CEK"));
                        db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, txtBarcode.Text));
                        dtc = db.Commands[0].ExecuteDataTable();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (dtc.Rows.Count > 0)
                {
                    MessageBox.Show("Barcode sudah terdaftar !!");
                    return;
                }
            }
        }

        private void dataGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            RefreshDataStokBarcode();
        }

    }
}