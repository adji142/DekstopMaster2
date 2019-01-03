using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmMasterStokBrowse : ISA.Toko.BaseForm
    {
        public frmMasterStokBrowse()
        {
            InitializeComponent();
        }

        private void frmMasterStokBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtSearch.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void DeleteData()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                //cek dulu apakah barang pernah digunakan di ISADBDepoRetail.dbo.OrderPenjualanDetail dan NotaPembelianDetail
                int jumlahbarang = 0;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    string barangid = dataGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();
                    db.Commands.Add(db.CreateCommand("usp_Stok_DELETE_VRF"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangid));
                    dt = db.Commands[0].ExecuteDataTable();
                    jumlahbarang = Convert.ToInt32(dt.Rows[0]["jumlah"]);
                }
                if (jumlahbarang == 0)
                {
                    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        try
                        {
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Stok_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                dt = db.Commands[0].ExecuteDataTable();
                            }

                            MessageBox.Show("Record telah dihapus");
                            this.RefreshData();
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(Messages.Error.CustomStockUsed);
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void txtSeacrh_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Length > 0)
            {
                string search = txtSearch.Text.Trim();
                for (int i = 0; i < (dataGridView1.Rows.Count); i++)
                {

                    if (dataGridView1.Rows[i].Cells["NamaStok"].Value.ToString().StartsWith(search))
                    {
                        dataGridView1.Rows[i].Cells["NamaStok"].Selected = true;
                        return; // stop looping
                    }
                }
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                lblNamaBarang.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
            }
            
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
           
            
            switch (e.KeyCode)
           {
              case Keys.Space:
                   cmdEDIT.PerformClick();
           	    break;
                case Keys.Insert:
                    cmdADD.PerformClick();
                break;
                
                //case Keys.Delete:
                //    cmdDELETE.PerformClick();
                //break;
               case Keys.Escape:
                   cmdClose_Click(sender, e);
                break;
           }
        }
        
        public void RefreshRowDataStok(string _BarangID)
        {
            
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, _BarangID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridView1.RefreshDataRow(dtRefresh.Rows[0], "BarangID", _BarangID);
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

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string barangIDSubString = dataGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString().Substring(0, 3);
                //if ( barangIDSubString.CompareTo("FXT") == 0)
                //{
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Master.frmMasterStokUpdate ifrmChild = new Master.frmMasterStokUpdate(this, rowID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
                //}
                //else
                //{
                //    MessageBox.Show(Messages.Error.CustomStock);
                //}
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Master.frmMasterStokUpdate ifrmChild = new Master.frmMasterStokUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            Master.frmMasterStokDownload ifrmChild = new Master.frmMasterStokDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                e.Value = e.Value.ToString() == "FM" ? "FAST" : "SLOW";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }


}
