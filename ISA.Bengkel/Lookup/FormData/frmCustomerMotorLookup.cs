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
    public partial class frmCustomerMotorLookup : ISA.Bengkel.BaseForm
    {
        string _rowID;
        string _noPol;
        string _spm;
        string _spmType;
        string _spmTypeDescr;
        string _warna;
        string _tahun;
        string _pemilik;
        string _alamat;
        string _kota;
        string _daerah;
        string _idMember;
        string _idKTP_SIM; 
     
        public frmCustomerMotorLookup()
        {
            InitializeComponent();
        }

        public frmCustomerMotorLookup(string searchArg, DataTable dt)
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

        public string NoPolisi
        {
            get
            {
                return _noPol;
            }
        }

        public string SPM
        {
            get
            {
                return _spm;
            }
        }

        public string SPMType
        {
            get
            {
                return _spmType;
            }
        }

        public string SPMTypeDescr
        {
            get
            {
                return _spmTypeDescr;
            }
        }
        
        public string Pemilik
        {
            get
            {
                return _pemilik;
            }
        }

        public string Warna
        {
            get
            {
                return _warna;
            }
        }

        public string Tahun
        {
            get
            {
                return _tahun;
            }
        }

        public string Alamat
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

        public string IDMember
        {
            get
            {
                return _idMember;
            }
        }

        public string KTP_SIM
        {
            get
            {
                return _idKTP_SIM;
            }
        }


        private void frmCustomerMotorLookUp_Load(object sender, EventArgs e)
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

                    db.Commands.Add(db.CreateCommand("usp_bkl_mMotorService_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@no_pol", SqlDbType.VarChar, txtNama.Text));                    
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
                _noPol = dataGridView1.SelectedCells[0].OwningRow.Cells["kd_cust"].Value.ToString();
                _pemilik = dataGridView1.SelectedCells[0].OwningRow.Cells["pemilik"].Value.ToString();
                _spm = dataGridView1.SelectedCells[0].OwningRow.Cells["spm"].Value.ToString();
                _spmType = dataGridView1.SelectedCells[0].OwningRow.Cells["kode"].Value.ToString();
                _spmTypeDescr = dataGridView1.SelectedCells[0].OwningRow.Cells["jns_spm"].Value.ToString();
                _warna = dataGridView1.SelectedCells[0].OwningRow.Cells["warna"].Value.ToString();
                _tahun = dataGridView1.SelectedCells[0].OwningRow.Cells["tahun"].Value.ToString();
                _alamat = dataGridView1.SelectedCells[0].OwningRow.Cells["alamat"].Value.ToString();
                _kota = dataGridView1.SelectedCells[0].OwningRow.Cells["kota"].Value.ToString();
                _daerah = dataGridView1.SelectedCells[0].OwningRow.Cells["daerah"].Value.ToString();
                _idKTP_SIM = dataGridView1.SelectedCells[0].OwningRow.Cells["no_id"].Value.ToString();
                _idMember = dataGridView1.SelectedCells[0].OwningRow.Cells["id_member"].Value.ToString();
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
