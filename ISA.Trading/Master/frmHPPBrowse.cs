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
    public partial class frmHPPBrowse : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;

        public frmHPPBrowse()
        {
            InitializeComponent();
        }
        
        private void frmHPPBrowse_Load(object sender, EventArgs e)
        {
            //RefreshDataStok();
        } 

        public void RefreshDataStok()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtSearch.Text));

                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    RefreshDataHPP();
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

        public void RefreshDataHPP()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtHPP = new DataTable();

                    string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();

                    db.Commands.Add(db.CreateCommand("usp_HistoryHPP_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    dtHPP = db.Commands[0].ExecuteDataTable();
                    dataGridViewHPP.DataSource = dtHPP;
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
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void dataGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                    RefreshDataHPP();
                    lblNamaBarang.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["namaStok"].Value.ToString();
                
            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            Master.frmHppDownload ifrmChild = new Master.frmHppDownload();
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
