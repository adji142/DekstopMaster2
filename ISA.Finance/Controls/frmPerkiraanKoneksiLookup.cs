using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance;

namespace ISA.Finance.Controls
{
    public partial class frmPerkiraanKoneksiLookup : ISA.Finance.BaseForm
    {
        string _noPerkiraan;
        string _namaPerkiraan;
        string _header="";
        string _Transaksi = "";

        public string NoPerkiraan
        {
            get
            {
                return _noPerkiraan;
            }
        }

        public string NamaPerkiraan
        {
            get
            {
                return _namaPerkiraan;
            }
        }

        

        string _kode;
        public frmPerkiraanKoneksiLookup(string kode)
        {
            InitializeComponent();
            _kode = kode;
        }

        public frmPerkiraanKoneksiLookup(string kode, string header)
        {
            InitializeComponent();
            _kode = kode;
            _header = header;
        }

        public frmPerkiraanKoneksiLookup(string kode, string header,string Transaksi)
        {
            InitializeComponent();
            _kode = kode;
            _header = header;
            _Transaksi = Transaksi;
        }

        private void ConfirmSelect()
        {
            if (gridDetail.SelectedCells.Count == 1)
            {
                _noPerkiraan = gridDetail.SelectedCells[0].OwningRow.Cells["cNoPerkiraan"].Value.ToString();
                _namaPerkiraan = gridDetail.SelectedCells[0].OwningRow.Cells["cUraian"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        public void RefreshHeader()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksi_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, _kode));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (_header != "PENYELESAIAN")
                    {
                        if (_header != "")
                            dt.DefaultView.RowFilter = "Uraian='" + _header + "'";
                    }
                    cboHeader.ValueMember = "RowID";
                    cboHeader.DisplayMember = "Uraian";
                    cboHeader.DataSource = dt.DefaultView;

                    //if (cboHeader.Items.Count > 0)
                    //{
                    //    cboHeader.SelectedIndex = 0;
                    //}
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        public void RefreshDetail()
        {
            
            if (cboHeader.SelectedIndex >= 0)
            {               
                try
                {
                    //DataRowView dr = (DataRowView) cboHeader.SelectedValue;

                    Guid headerID = new Guid(cboHeader.SelectedValue.ToString());
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        DataTable dt = new DataTable();

                        db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiDetail_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                        //if (_Transaksi == "KASBON" || _Transaksi == "PENYELESAIAN")
                        //{
                        //    db.Commands[0].Parameters.Add(new Parameter("@Filter", SqlDbType.VarChar, _Transaksi));
                        //}

                        dt = db.Commands[0].ExecuteDataTable();
                        gridDetail.DataSource = dt;
                        if (dt.Rows.Count > 0)
                        {
                            gridDetail.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void frmPerkiraanKoneksiLookup_Load(object sender, EventArgs e)
        {
            RefreshHeader();
            
            RefreshDetail();
        }

        private void cboHeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            RefreshDetail();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }

        private void gridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gridDetail.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
            
        }

        private void gridDetail_DoubleClick(object sender, EventArgs e)
        {
            if (gridDetail.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void frmPerkiraanKoneksiLookup_Shown(object sender, EventArgs e)
        {
            if (gridDetail.Rows.Count > 0)
            {
                gridDetail.Focus();
            }
        }
    }
}
