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
    public partial class frmBarangLookup : ISA.Bengkel.BaseForm
    {
        string _kodeBarang;
        string _namaBarang;
        string _satuan;
        int _isiKoli;
        string _bundel;
        

        public frmBarangLookup()
        {
            InitializeComponent();
        }

        public frmBarangLookup(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
            dataGridView1.DataSource = dt;            
        }       


        public string KodeBarang
        {
            get
            {
                return _kodeBarang;
            }
        }

        public string NamaBarang
        {
            get
            {
                return _namaBarang;
            }
        }

        public string Satuan
        {
            get
            {
                return _satuan;
            }
        }

        public int IsiKoli
        {
            get
            {
                return _isiKoli;
            }
        }

        public string Bundel
        {
            get
            {
                return _bundel;
            }
        }

        private void frmBarangLookUp_Load(object sender, EventArgs e)
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

                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, txtNama.Text));                    
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
                _kodeBarang = dataGridView1.SelectedCells[0].OwningRow.Cells["id_brg"].Value.ToString();
                _namaBarang = dataGridView1.SelectedCells[0].OwningRow.Cells["nama_stok"].Value.ToString();
                _satuan = dataGridView1.SelectedCells[0].OwningRow.Cells["sat_jual"].Value.ToString();
                _isiKoli = (int)dataGridView1.SelectedCells[0].OwningRow.Cells["isi_koli"].Value;
                _bundel = dataGridView1.SelectedCells[0].OwningRow.Cells["bundel"].Value.ToString();
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
