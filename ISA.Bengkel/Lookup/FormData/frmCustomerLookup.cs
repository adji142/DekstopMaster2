using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;
using ISA.Bengkel.Helper;

namespace ISA.Bengkel.Lookup
{
    public partial class frmCustomerLookup : ISA.Bengkel.BaseForm
    {
        string _rowID;
        string _kodeCust;
        string _namaCust;
        string _alamat;
        string _kota;
        string _daerah;        

        public frmCustomerLookup()
        {
            InitializeComponent();
        }

        public frmCustomerLookup(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
            dataGridView1.DataSource = dt;            
        }       


        public string RowId
        {
            get
            {
                return _rowID;
            }
        }

        public string KodeCust
        {
            get
            {
                return _kodeCust;
            }
        }

        public string NamaCust
        {
            get
            {
                return _namaCust;
            }
        }

        public string AlamatCust
        {
            get
            {
                return _alamat;
            }
        }

        public string Kota
        {
            get
            {
                return _kota;
            }
        }

        public string Daerah
        {
            get
            {
                return _daerah;
            }
        }


        private void frmCustomerLookUp_Load(object sender, EventArgs e)
        {
            RefreshData();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Focus();
            }
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_bkl_mCustomerService_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@nama_cust", SqlDbType.VarChar, txtNama.Text));
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
                _rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                _kodeCust = dataGridView1.SelectedCells[0].OwningRow.Cells["kd_cust"].Value.ToString();
                _namaCust = dataGridView1.SelectedCells[0].OwningRow.Cells["nama_cust"].Value.ToString();
                _alamat = dataGridView1.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString();
                _kota = dataGridView1.SelectedCells[0].OwningRow.Cells["City"].Value.ToString();
                
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
