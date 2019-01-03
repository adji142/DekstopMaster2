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
    public partial class frmGudangLookup : ISA.Controls.BaseForm
    {
        string _gudangID;
        string _namaGudang;
        string _kodeCabang;
        string _initPerusahaan;

        public frmGudangLookup()
        {
            InitializeComponent();
        }

        public frmGudangLookup(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
            dataGridView1.DataSource = dt;            
        }       


        public string gudangId
        {
            get
            {
                return _gudangID;
            }
        }

        public string namaGudang
        {
            get
            {
                return _namaGudang;
            }
        }

        public string kodeCabang
        {
            get
            {
                return _kodeCabang;
            }
        }

        public string initPerusahaan
        {
            get
            {
                return _initPerusahaan;
            }
        }

        private void frmGudangLookUp_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Focus();
            }
        }

        public void RefreshData()
        {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_Gudang_SEARCH"));
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

        private void ConfirmSelect()
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {                
                _gudangID = dataGridView1.SelectedCells[0].OwningRow.Cells["GudangID"].Value.ToString();
                _namaGudang = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaGudang"].Value.ToString();
                _kodeCabang = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeCabang"].Value.ToString();
                _initPerusahaan =dataGridView1.SelectedCells[0].OwningRow.Cells["InitPerusahaan"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedCells.Count == 1)
            {
                e.SuppressKeyPress = true;
                ConfirmSelect();
                
            }
        }

    }
}
