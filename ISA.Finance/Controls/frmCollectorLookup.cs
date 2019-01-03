using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Finance.Controls
{
    public partial class frmCollectorLookup : ISA.Finance.BaseForm
    {
        //Guid _rowID;
        string _salesID;
        string _namaSales;

        public frmCollectorLookup()
        {
            InitializeComponent();
        }

        public frmCollectorLookup(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
            dataGridView1.DataSource = dt;
        }

        /*public Guid RowId
        {
            get
            {
                return _rowID;
            }
        }*/

        public string salesId
        {
            get
            {
                return _salesID;
            }
        }

        public string namaSales
        {
            get
            {
                return _namaSales;
            }
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_Collector_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNama.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void ConfirmSelect()
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                //_rowID = new Guid( dataGridView1.SelectedCells[0].OwningRow.Cells["CollectorID"].Value.ToString());
                _salesID = dataGridView1.SelectedCells[0].OwningRow.Cells["Kode"].Value.ToString();
                _namaSales = dataGridView1.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmCollectorLookup_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Focus();
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {
            RefreshData();
            txtNama.Focus();
        }
    }
}
