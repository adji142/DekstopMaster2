using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Controls
{
    public partial class frmUnitKerjaLookup : ISA.Toko.BaseForm
    {
        Guid _rowID;
        string _kode;
        string _nama, _keterangan;

        public frmUnitKerjaLookup()
        {
            InitializeComponent();
        }

        public frmUnitKerjaLookup(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
            dataGridView1.DataSource = dt;            
        }       

        public Guid RowId
        {
            get
            {
                return _rowID;
            }
        }

        public string kode
        {
            get
            {
                return _kode;
            }
        }

        public string nama
        {
            get
            {
                return _nama;
            }
        }

        public string keterangan
        {
            get
            {
                return _keterangan;
            }
        }


        private void frmUnitKerjaLookup_Load(object sender, EventArgs e)
        {
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

                    db.Commands.Add(db.CreateCommand("[usp_UnitKerja_LIST]"));
                    if( txtNama.Text !=""){
                    db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtNama.Text));                    }
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
                _rowID = new Guid( dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                _kode = dataGridView1.SelectedCells[0].OwningRow.Cells["Kode"].Value.ToString();
                _nama = dataGridView1.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
                _keterangan = dataGridView1.SelectedCells[0].OwningRow.Cells["Keterangan"].Value.ToString();               
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }





    }
}
