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

namespace ISA.Bengkel.Lookup.FormData
{
    public partial class frmCustomerALLLookup : ISA.Bengkel.BaseForm
    {
        string _rowID;
        string _nomember;
        string _namaCust;
        string _alamat;
        string _kota;
        string _daerah;
        string _notelp;
        string _noktp;
        string _nopol;
        string _kdtype;
        string _tahun;
        string _warna;
        string _nomesin;
        string _norangka;
        
        
        public frmCustomerALLLookup()
        {
            InitializeComponent();
        }

        public frmCustomerALLLookup(string nomember, DataTable dt)
        {
            InitializeComponent();
            //txtNoMember.Text = searchArg;
            dataGridView1.DataSource = dt.DefaultView;            
        }
        public string RowId
        {
            get
            {
                return _rowID;
            }
        }
        public string NomerMember
        {
            get
            {
                return _nomember;
            }
            set
            {
               _nomember = value;
            }
        }
        public string NamaCust
        {
            get
            {
                return _namaCust;
            }
            set
            {
                _namaCust = value;
            }
        }

        public string Alamat
        {
            get
            {
                return _alamat;
            }
            set
            {
                _alamat = value;
            }
        }

        public string Kota
        {
            get
            {
                return _kota;
            }
            set
            {
                _kota = value;
            }
        }

        public string NoTelepon
        {
            get
            {
                return _notelp;
            }
            set
            {
                _notelp = value;
            }
        }

        public string Daerah
        {
            get
            {
                return _daerah;
            }
            set
            {
                _daerah = value;
            }
        }

        public string NoKTP
        {
            get
            {
                return _noktp;
            }
            set
            {
                _noktp = value;
            }
        }
        public string Nopol
        {
            get
            {
                return _nopol;
            }
            set
            {
                _nopol = value;
            }
        }
        public string Kdtype
        {
            get
            {
                return _kdtype;
            }
            set
            {
                _kdtype = value;
            }
        }
        public string tahun
        {
            get
            {
                return _tahun;
            }
            set
            {
                _tahun = value;
            }
        }
        public string warna
        {
            get
            {
                return _warna;
            }
            set
            {
                _warna = value;
            }
        }
        public string Nomesin
        {
            get
            {
                return _nomesin;
            }
            set
            {
                _nomesin = value;
            }
        }
        public string Norangka
        {
            get
            {
                return _norangka;
            }
            set
            {
                _norangka = value;
            }
        }
        private void frmCustomerALLLookup_Load(object sender, EventArgs e)
        {
            //RefreshData();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Focus();
            }
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            confirmselect();
        }
        private void confirmselect()
        {
            _rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
            _nomember = dataGridView1.SelectedCells[0].OwningRow.Cells["NoMember"].Value.ToString();
            _namaCust = dataGridView1.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
            _alamat = dataGridView1.SelectedCells[0].OwningRow.Cells["AlamatIdt"].Value.ToString();
            _kota = dataGridView1.SelectedCells[0].OwningRow.Cells["KotaIdt"].Value.ToString();
            _notelp = dataGridView1.SelectedCells[0].OwningRow.Cells["NoTelp"].Value.ToString();
            _noktp = dataGridView1.SelectedCells[0].OwningRow.Cells["NoIdentitas"].Value.ToString();
            _daerah = dataGridView1.SelectedCells[0].OwningRow.Cells["KecamatanIdt"].Value.ToString();
            _nopol = dataGridView1.SelectedCells[0].OwningRow.Cells["NoPol"].Value.ToString();
            _kdtype = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaType"].Value.ToString();
            _tahun = dataGridView1.SelectedCells[0].OwningRow.Cells["Tahun"].Value.ToString();
            _nomesin = dataGridView1.SelectedCells[0].OwningRow.Cells["NoMesin"].Value.ToString();
            _norangka = dataGridView1.SelectedCells[0].OwningRow.Cells["NoRangka"].Value.ToString();
           
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                confirmselect();
            }
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_bkl_mCustomerMember_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@nomember", SqlDbType.VarChar, txtNoMember.Text));
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

        //private void dataGridView1_DoubleClick(object sender, EventArgs e)
        //{
        //    if (dataGridView1.SelectedCells.Count == 1)
        //    {
        //        ConfirmSelect();
        //    }
        //}

        //private void ConfirmSelect()
        //{
        //    if (dataGridView1.SelectedCells.Count == 1)
        //    {
        //        _rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
        //        _nomember = dataGridView1.SelectedCells[0].OwningRow.Cells["NoMember"].Value.ToString();
        //        _namaCust = dataGridView1.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
        //        _alamat = dataGridView1.SelectedCells[0].OwningRow.Cells["AlamatIdt"].Value.ToString();
        //        _kota = dataGridView1.SelectedCells[0].OwningRow.Cells["KotaIdt"].Value.ToString();
        //        _notelp = dataGridView1.SelectedCells[0].OwningRow.Cells["NoTelp"].Value.ToString();
        //        _noktp = dataGridView1.SelectedCells[0].OwningRow.Cells["NoIdentitas"].Value.ToString();
        //        _daerah = dataGridView1.SelectedCells[0].OwningRow.Cells["KecamatanIdt"].Value.ToString();

        //    }
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}


        //private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter && dataGridView1.SelectedCells.Count == 1)
        //    {
        //        e.SuppressKeyPress = true;
        //        ConfirmSelect();

        //    }
        //}

        

       
    }
}
