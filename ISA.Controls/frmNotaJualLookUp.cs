using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Controls
{
    public partial class frmNotaJualLookUp : ISA.Controls.BaseForm
    {
        Guid _rowID;
        string _noNota;
        string _notaRecID;
        string _noDO;
        string _namaSales;

        public frmNotaJualLookUp()
        {
            InitializeComponent();
        }

        public frmNotaJualLookUp(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
            dataGridView1.DataSource = dt;
        }

        public Guid rowID
        {
            get
            {
                return _rowID;
            }
        }

        public string noNota
        {
            get
            {
                return _noNota;
            }
        }

        public string notaRecID
        {
            get
            {
                return _notaRecID;
            }
        }

        public string noDO
        {
            get
            {
                return _noDO;
            }
        }

        public string namaSales
        {
            get
            {
                return _namaSales;
            }
        }

        private void frmNotaJualLookUp_Load(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Focus();
            }
        }

        public void RefreshData()
        {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNama.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Focus();
                    }
                }
            
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedRows.Count > 0)
            {
                ConfirmSelect();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void ConfirmSelect()
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                _rowID = new Guid(dataGridView1.SelectedRows[0].Cells["NotaID"].Value.ToString());
                _noNota = dataGridView1.SelectedRows[0].Cells["NoNota"].Value.ToString();
                _notaRecID = dataGridView1.SelectedRows[0].Cells["RecordID"].Value.ToString();
                _noDO = dataGridView1.SelectedRows[0].Cells["NoDO"].Value.ToString();
                _namaSales = dataGridView1.SelectedRows[0].Cells["NamaSales"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
