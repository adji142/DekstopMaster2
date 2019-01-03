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
    public partial class frmStockLookUpExtended : ISA.Controls.BaseForm
    {
        Guid _rowID;
        string _barangID;
        string _namaStok;
        string _satuan;
       

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


        public frmStockLookUpExtended()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        public frmStockLookUpExtended(string searchArg, DataTable dt)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            txtNama.Text = searchArg;
            dt.DefaultView.Sort = "NamaStok";
            dataGridView1.DataSource = dt.DefaultView;            
        }

        private void frmStockLookUpExtended_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Focus();
            }
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
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
                if (dataGridView1.SelectedCells.Count == 0)
                {
                    Clear();
                }
                else
                {
                    SetDisplay();
                }
            }
            finally 
            {
                this.Cursor = Cursors.Default;
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                Clear();
            }
            else
            {
                SetDisplay();
            }
        }

        private void SetDisplay()
        {
            lblNamaBarang.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
            txtQtyStok.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["QtySisa"].Value.ToString();
            GetData();
            txtHrgPokok.Text = "0";
            txtHrgJual.Text = "0";
            txtHrgB.Text = "0";
            txtHrgM.Text = "0";
            txtHrgK.Text = "0";
            txtPartNumber.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["PartNo"].Value.ToString();
            txtMerk.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["Merek"].Value.ToString();
            txtKodeRak.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeRak"].Value.ToString();
        }

        private void GetData()
        {
            string barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtBMK = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_GetHrgBMK"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                    db.Commands[0].Parameters.Add(new Parameter("@tglDO", SqlDbType.VarChar, DateTime.Now));
                    dtBMK = db.Commands[0].ExecuteDataTable();
                    if (dtBMK.Rows.Count > 0)
                    {
                        txtHrgB.Text = dtBMK.Rows[0]["HargaB"].ToString();
                        txtHrgM.Text = dtBMK.Rows[0]["HargaM"].ToString();
                        txtHrgK.Text = dtBMK.Rows[0]["HargaK"].ToString();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Clear()
        {
            lblNamaBarang.Text = "";
            txtQtyStok.Text = "0";
            txtHrgPokok.Text = "0";
            txtHrgJual.Text = "0";
            txtHrgB.Text = "0";
            txtHrgM.Text = "0";
            txtHrgK.Text = "0";
            txtPartNumber.Text = "";
            txtMerk.Text = "";
            txtKodeRak.Text = "";
        }
    }
}
