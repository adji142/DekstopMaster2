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
using ISA.Bengkel;

namespace ISA.Bengkel.Lookup
{
    public partial class frmSalesLookup : ISA.Bengkel.BaseForm
    {
        string _kodeSales;
        string _namaSales;
        

        public frmSalesLookup()
        {
            InitializeComponent();
        }

        public frmSalesLookup(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
            dataGridView1.DataSource = dt;            
        }       


        public string KodeSales
        {
            get
            {
                return _kodeSales;
            }
        }

        public string NamaSales
        {
            get
            {
                return _namaSales;
            }
        }


        private void frmSalesLookUp_Load(object sender, EventArgs e)
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

                    db.Commands.Add(db.CreateCommand("usp_bkl_sales_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@nm_sales", SqlDbType.VarChar, txtNama.Text));                    
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
                _kodeSales = dataGridView1.SelectedCells[0].OwningRow.Cells["kd_sales"].Value.ToString();
                _namaSales = dataGridView1.SelectedCells[0].OwningRow.Cells["nm_sales"].Value.ToString();
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
