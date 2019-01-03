using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Master
{
    public partial class frmHPPABrowse : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;

        public frmHPPABrowse()
        {
            InitializeComponent();
        }

        private void frmHPPABrowse_Load(object sender, EventArgs e)
        {

        }

        public void RefreshDataStok()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtStok = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtSearch.Text));
                    dtStok = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dtStok;
                }
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    RefreshDataHPPA();
                    lblNamaBarang.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
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

        public void RefreshDataHPPA()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtHPPA = new DataTable();

                    string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();

                    db.Commands.Add(db.CreateCommand("usp_HistoryHPPA_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    dtHPPA = db.Commands[0].ExecuteDataTable();
                    dataGridView2.DataSource = dtHPPA;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataStok();            
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                RefreshDataHPPA();
                lblNamaBarang.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["namaStok"].Value.ToString();
            }  
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            Communicator.frmHPPRataRataDownload ifrmChild = new Communicator.frmHPPRataRataDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
