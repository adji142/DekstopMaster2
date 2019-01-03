using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;

namespace ISA.Controls
{
    public partial class frmStockLookUp : ISA.Controls.BaseForm
    {
        Guid _rowID;
        string _barangID;
        string _namaStok;
        string _satuan;
        int _isiKoli;
       

        public Guid RowId
        {
            get
            {
                return _rowID;
            }
        }

        public string BarangId
        {
            get
            {
                return _barangID;
            }
        }

        public string NamaStock
        {
            get
            {
                return _namaStok;
            }
        }

        public string Satuan
        {
            get
            {
                return _satuan;
            }
        }

        public int nIsiKoli
        {
            get
            {
                return _isiKoli;
            }
        }

        public frmStockLookUp()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        public frmStockLookUp(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
            dataGridView1.AutoGenerateColumns = false;
            dt.DefaultView.Sort = "NamaStok";
            dataGridView1.DataSource = dt.DefaultView;            
        }

        private void frmStockLookUp_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

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

                    db.Commands.Add(db.CreateCommand("usp_Stok_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNama.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "NamaStok";
                    dataGridView1.DataSource = dt.DefaultView;
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
                _rowID = new Guid( dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();
                _namaStok = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
                _satuan = dataGridView1.SelectedCells[0].OwningRow.Cells["SatSolo"].Value.ToString();
                _isiKoli = int.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells["IsiKoli"].Value.ToString());
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }



    }
}
