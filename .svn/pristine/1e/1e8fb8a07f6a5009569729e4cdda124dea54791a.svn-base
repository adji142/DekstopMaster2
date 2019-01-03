using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;


namespace ISA.Bengkel.Master
{
    public partial class frmMasterStokBengkelBrowse : ISA.Controls.BaseForm
    {
        
        public frmMasterStokBengkelBrowse()
        {
            InitializeComponent();
        }

        private void frmMasterStokBengkelBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
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
                    db.Commands.Add(db.CreateCommand("usp_StokBengkel_LIST"));
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


        public void RefreshRowDataStok(string _BarangID)
        {
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_StokBengkel_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, _BarangID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }
                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridView1.RefreshDataRow(dtRefresh.Rows[0], "id_brg", _BarangID);
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


        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    cmdDelete_Click(sender, e);
                    break;
                case Keys.Escape:
                    cmdClose_Click(sender, e);
                    break;
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Master.frmMasterStokBengkelUpdate ifrmChild = new Master.frmMasterStokBengkelUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }


        private void cmdEdit_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowIDbkl"].Value;
                Master.frmMasterStokBengkelUpdate ifrmChild = new Master.frmMasterStokBengkelUpdate(this, rowID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show("Data tidak ada");
                return;
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowIDbkl"].Value;
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_StokBengkel_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        this.RefreshData();
                        MessageBox.Show("Record telah dihapus");
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Data tidak ada");
            }
        }

    }
}
