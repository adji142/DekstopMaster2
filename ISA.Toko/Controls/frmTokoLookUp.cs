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
    public partial class frmTokoLookUp : ISA.Toko.BaseForm
    {
        Guid _rowID;
        string _tokoID;
        string _namaToko;
        string _kodeToko;
        string _alamat, _propinsi;
        string _kecamatan;
        string _daerah;
        string _kota;
        int _hrSales, _hrKirim;
        string _wilID;
               
        public Guid RowId
        {
            get
            {
                return _rowID;
            }
        }

        public string wilID
        {
            get { return _wilID; }
            set { _wilID = value; }
        }
        public string TokoId
        {
            get
            {
                return _tokoID;
            }
        }

        public string namaToko
        {
            get
            {
                return _namaToko;
            }
        }

        public string kodeToko
        {
            get
            {
                return _kodeToko;
            }
        }

        public string alamat
        {
            get
            {
                return _alamat;
            }
        }

        public string daerah
        {
            get
            {
                return _daerah;
            }
        }

        public string kota
        {
            get
            {
                return _kota;
            }
        }

        public int hariSales
        {
            get
            {
                return _hrSales;
            }
        }

        public int hariKirim
        {
            get
            {
                return _hrKirim;
            }
        }
        //public string Kecamatan
        //{
        //    get
        //    {
        //        return _kecamatan;
        //    }
        //    set
        //    {
        //        _kecamatan = value;
        //    }
        //}

        public string propinsi
        {
            get
            {
                return _propinsi;
            }
            set
            {
                _propinsi = value;
            }
        }


        public frmTokoLookUp()
        {
            InitializeComponent();
        }

        public frmTokoLookUp(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
            dt.DefaultView.Sort = "NamaToko";
            dataGridView1.DataSource = dt.DefaultView;            
        }

        private void frmTokoLookUp_Load(object sender, EventArgs e)
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

                    db.Commands.Add(db.CreateCommand("usp_Toko_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNama.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "NamaToko";
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
                _tokoID = dataGridView1.SelectedCells[0].OwningRow.Cells["TokoID"].Value.ToString();
                _namaToko = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                _kodeToko = dataGridView1.SelectedCells[0].OwningRow.Cells["TokoID"].Value.ToString();
                _alamat = dataGridView1.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString();
                _daerah = dataGridView1.SelectedCells[0].OwningRow.Cells["Daerah"].Value.ToString();
                _kota = dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();
                _hrSales = int.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells["HariSales"].Value.ToString());
                _hrKirim = int.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells["HariKirim"].Value.ToString());
                _wilID = dataGridView1.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString();
                //_kecamatan = dataGridView1.SelectedCells[0].OwningRow.Cells["kecamatan"].Value.ToString();
                _propinsi = dataGridView1.SelectedCells[0].OwningRow.Cells["prop"].Value.ToString();
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
