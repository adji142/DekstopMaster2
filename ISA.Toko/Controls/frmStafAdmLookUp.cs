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
    public partial class frmStafAdmLookUp : ISA.Toko.BaseForm
    {
        Guid _rowID;
        string _Nama;
        string _Kode;
        DataTable Table;
               
        public Guid RowId
        {
            get
            {
                return _rowID;
            }
        }


        public string Nama
        {
            get
            {
                return _Nama;
            }
        }

        public string Kode
        {
            get
            {
                return _Kode;
            }
        }

        public frmStafAdmLookUp()
        {
            InitializeComponent();
        }

        public frmStafAdmLookUp(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
            Table = dt;    
        }

        private void frmStafAdmLookUp_Load(object sender, EventArgs e)
        {
            if (Table != null)
            {
                Table.DefaultView.Sort = "Nama";
                dataGridView1.DataSource = Table.DefaultView;
            }
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

                    db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNama.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, true));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "Nama";
                    dataGridView1.DataSource = dt.DefaultView;
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
                _Nama = dataGridView1.SelectedCells[0].OwningRow.Cells["GridNama"].Value.ToString();
                _Kode = dataGridView1.SelectedCells[0].OwningRow.Cells["GridKode"].Value.ToString();
                //_kecamatan = dataGridView1.SelectedCells[0].OwningRow.Cells["kecamatan"].Value.ToString();
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
