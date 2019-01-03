using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmStokBarcode : ISA.Toko.BaseForm
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
                    db.Commands[0].Parameters.Add(new Parameter("@bit", SqlDbType.Bit, true));

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

            if (dataGridView1.SelectedCells.Count <= 0) { MessageBox.Show("Tidak Ada Data Yang dipilih"); return; }
            string _idBarang = dataGridView1.SelectedCells[0].OwningRow.Cells["IDBarang"].Value.ToString();
            string _Header = dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
            
                Master.frmStokBarcodeUpdate ifrmChild = new Master.frmStokBarcodeUpdate(this, _Header, _idBarang);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (txtSearch.Focused != true)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    if (dataGridView2.SelectedCells.Count > 0)
                    {
                        Guid _rowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["row"].Value;
                        string _idBarang = dataGridView1.SelectedCells[0].OwningRow.Cells["IDBarang"].Value.ToString();
                        string _namaStok = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
                        Master.frmStokBarcodeUpdate ifrmChild = new Master.frmStokBarcodeUpdate(this, _rowID, _idBarang, _namaStok);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    else { MessageBox.Show(Messages.Error.RowNotSelected); }
                }
                else { MessageBox.Show(Messages.Error.RowNotSelected); }
            }
         }

        private void hapusData()
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                Guid RowID_ = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["row"].Value;
                if (MessageBox.Show("Hapus Data : " + RowID_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            hapusData();
            RefreshDataStokBarcode();
        }

        private void CMDGenerate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count <= 0) { MessageBox.Show("Tidak Ada Data Yang dipilih"); return; }
            string _idBarang = dataGridView1.SelectedCells[0].OwningRow.Cells["IDBarang"].Value.ToString();
            string _Header = dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
            string _generate = "generate";

            Master.frmStokBarcodeUpdate ifrmChild = new Master.frmStokBarcodeUpdate(this, _Header, _idBarang, _generate);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }
    }
}