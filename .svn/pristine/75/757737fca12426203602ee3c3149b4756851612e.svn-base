using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Controls
{
    public partial class LookupToko : UserControl
    {
        public event EventHandler SelectData;

        Guid  _rowID;
        string _tokoID;
        string _alamat, _propinsi;
        //string _kecamatan;
        string _kota;
        string _daerah;
        string _lastNamaToko = "";
        int _hrSales, _hrKirim;
        string _wilID = string.Empty;

        public Guid RowID
        {
            get
            {
                return _rowID;
            }
            set
            {
                _rowID = value;
            }
        }

        public string WilID
        {
            get { return _wilID; }
            set { _wilID = value;}
        }
        public string KodeToko
        {
            get
            {
                return txtLookupCode.Text;
            }
            set
            {
                txtLookupCode.Text = value;
            }
        }

        public string NamaToko
        {
            get
            {
                return txtLookupName.Text;
            }
            set
            {
                txtLookupName.Text = value;
            }
        }

        public string TokoID
        {
            get
            {
                return _tokoID;
            }
            set
            {
                _tokoID = value;
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

        public int HariSales
        {
            get
            {
                return _hrSales;
            }
            set
            {
                _hrSales = value;
            }
        }

        public int HariKirim
        {
            get
            {
                return _hrKirim;
            }
            set
            {
                _hrKirim = value;
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

        public string Propinsi
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

        public LookupToko()
        {
            InitializeComponent();
        }

        public void SetNamaToko(string nama)
        {
            txtLookupName.Text = nama;
            _lastNamaToko = nama;
        }

        private void txtLookupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13 && _lastNamaToko.Trim() != txtLookupName.Text.Trim())
            //{
            //    if (txtLookupName.Text != "")
            //    {
            //        try
            //        {
            //            using (Database db = new Database())
            //            {
            //                DataTable dt = new DataTable();

            //                db.Commands.Add(db.CreateCommand("usp_Toko_SEARCH"));
            //                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
            //                dt = db.Commands[0].ExecuteDataTable();
            //                if (dt.Rows.Count == 1)
            //                {
            //                    txtLookupName.Text = Tools.isNull( dt.Rows[0]["NamaToko"],"").ToString();                                
            //                    txtLookupCode.Text = Tools.isNull(dt.Rows[0]["TokoID"], "").ToString();
            //                    _lastNamaToko = txtLookupCode.Text;
            //                    _rowID = (Guid)dt.Rows[0]["RowID"];
            //                    _tokoID = Tools.isNull(dt.Rows[0]["TokoID"], "").ToString();
            //                    _alamat = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
            //                    _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
            //                    if (this.SelectData != null)
            //                    {
            //                        this.SelectData(this, new EventArgs());
            //                    }
            //                }
            //                else
            //                {
            //                    ShowDialogForm(txtLookupName.Text, dt );
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.LogError(ex);
            //        }
            //    }
            //    else
            //    {

            //        Clear();
            //    }
            //}
        }

        private void ShowDialogForm()
        {
            frmTokoLookUp ifrmDialog = new frmTokoLookUp();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
            else
            {
                txtLookupName.Focus();
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmTokoLookUp ifrmDialog = new frmTokoLookUp(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
            else
            {
                txtLookupName.Focus();
            }
        }

        private void GetDialogResult(frmTokoLookUp dialogForm)
        {
            _rowID = dialogForm.RowId;
            txtLookupName.Text = dialogForm.namaToko;
            _lastNamaToko = txtLookupName.Text;
            txtLookupCode.Text = dialogForm.kodeToko;
            _tokoID = dialogForm.TokoId;
            _alamat = dialogForm.alamat;
            _daerah = dialogForm.daerah;
            _kota = dialogForm.kota;
            _hrKirim = dialogForm.hariKirim;
            _hrSales = dialogForm.hariSales;
            _wilID = dialogForm.wilID;
            //_kecamatan = dialogForm.Kecamatan;
            _propinsi = dialogForm.propinsi;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            _rowID = new Guid();
            txtLookupName.Text = "";
            _lastNamaToko = txtLookupName.Text;
            txtLookupCode.Text = "";
            _tokoID = "";
            _alamat = "";
            _daerah = "";
            _kota = "";
            //_kecamatan = "";
            _propinsi = "";
            _hrKirim = 0;
            _hrSales = 0;
            _wilID = string.Empty;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }

        public void ShowDialogFormValidation()
        {
            if (txtLookupName.Text != "")
            {
                SearchToko();
            }
        
        }

        public void SearchToko()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_Toko_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 1)
                    {
                        txtLookupName.Text = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
                        txtLookupCode.Text = Tools.isNull(dt.Rows[0]["TokoID"], "").ToString();
                        _lastNamaToko = txtLookupCode.Text;
                        _rowID = (Guid)dt.Rows[0]["RowID"];
                        _tokoID = Tools.isNull(dt.Rows[0]["TokoID"], "").ToString();
                        _alamat = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                        _wilID = Tools.isNull(dt.Rows[0]["WilID"], "").ToString();
                        _daerah = Tools.isNull(dt.Rows[0]["Daerah"], "").ToString();
                        _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        //_kecamatan = Tools.isNull(dt.Rows[0]["Kecamatan"], "").ToString();
                        _propinsi = Tools.isNull(dt.Rows[0]["Propinsi"], "").ToString();
                        _hrKirim = int.Parse(Tools.isNull(dt.Rows[0]["HariKirim"], "").ToString());
                        _hrSales = int.Parse(Tools.isNull(dt.Rows[0]["HariSales"], "").ToString()); 
                        if (this.SelectData != null)
                        {
                            this.SelectData(this, new EventArgs());
                        }
                    }
                    else
                    {
                        ShowDialogForm(txtLookupName.Text, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
 
        }


        public void SetToko(string KodeToko_)
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_Toko_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 1)
                    {
                        txtLookupName.Text = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
                        txtLookupCode.Text = Tools.isNull(dt.Rows[0]["TokoID"], "").ToString();
                        _lastNamaToko = txtLookupCode.Text;
                        _rowID = (Guid)dt.Rows[0]["RowID"];
                        _tokoID = Tools.isNull(dt.Rows[0]["TokoID"], "").ToString();
                        _alamat = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                        _wilID = Tools.isNull(dt.Rows[0]["WilID"], "").ToString();
                        _daerah = Tools.isNull(dt.Rows[0]["Daerah"], "").ToString();
                        _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        //_kecamatan = Tools.isNull(dt.Rows[0]["Kecamatan"], "").ToString();
                        _propinsi = Tools.isNull(dt.Rows[0]["Propinsi"], "").ToString();
                        _hrKirim = int.Parse(Tools.isNull(dt.Rows[0]["HariKirim"], "").ToString());
                        _hrSales = int.Parse(Tools.isNull(dt.Rows[0]["HariSales"], "").ToString());
                        if (this.SelectData != null)
                        {
                            this.SelectData(this, new EventArgs());
                        }
                    }
                    else
                    {
                        ShowDialogForm(txtLookupName.Text, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void txtLookupName_Validating(object sender, CancelEventArgs e)
        {
            if (_lastNamaToko.Trim() != txtLookupName.Text.Trim())
            {
                if (txtLookupName.Text != "")
                {
                    SearchToko();
                }
                else
                {
                    Clear();
                }
            }
        }

        private void LookupToko_Load(object sender, EventArgs e)
        {

        }
    }
}
