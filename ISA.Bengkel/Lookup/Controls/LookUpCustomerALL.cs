using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;
using ISA.Bengkel.Helper;

namespace ISA.Bengkel.Lookup
{
    public partial class LookupCustomerALL : UserControl
    {
        public event EventHandler SelectData;


        bool _bypassCheckInitCab = false;
        string _rowID;
        string _nomember;
        string _namaCust;
        string _alamat;
        string _kota;
        string _notelp;
        string _noktp;
        string _daerah;
        string _nopol;
        string _kdtype;
        string _tahun;
        string _warna;
        string _nomesin;
        string _norangka;



        public string NomerMember
        {
            get
            {
                return txtNoMember.Text;
            }
            set
            {
                txtNoMember.Text = value;
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
        public string NoPol
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
        public string KdType
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
        public string Tahun
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
        public string Warna
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
        public string NoMesin
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
        public string NoRangka
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


        [Browsable(true), DefaultValue(false)]
        public bool ByPassCheckInitCab
        {
            get
            {
                return _bypassCheckInitCab;
            }
            set
            {
                _bypassCheckInitCab = value;
            }
        }

        public LookupCustomerALL()
        {
            InitializeComponent();
        }

        private void txtNoMember_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtNoMember.Text != "")
                {
                    //if (txtLookupName.Text == GlobalVar.CabangID && _bypassCheckInitCab)
                    //{
                    //    return;
                    //}
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();

                            db.Commands.Add(db.CreateCommand("usp_bkl_mCustomerMember_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@nomember", SqlDbType.VarChar, txtNoMember.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count == 1)
                            {
                                txtNoMember.Text = Tools.isNull(dt.Rows[0]["NoMember"], "").ToString();
                                _rowID = Tools.isNull(dt.Rows[0]["RowID"], "").ToString();
                                _namaCust = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                                _alamat = Tools.isNull(dt.Rows[0]["AlamatIdt"], "").ToString();
                                _kota = Tools.isNull(dt.Rows[0]["KotaIdt"], "").ToString();
                                _notelp = Tools.isNull(dt.Rows[0]["NoTelp"], "").ToString();
                                _noktp = Tools.isNull(dt.Rows[0]["NoIdentitas"], "").ToString();
                                _daerah = Tools.isNull(dt.Rows[0]["KecamatanIdt"], "").ToString();
                                _nopol = Tools.isNull(dt.Rows[0]["NoPol"],"").ToString();
                                _kdtype = Tools.isNull(dt.Rows[0]["NamaType"], "").ToString();
                                _tahun = Tools.isNull(dt.Rows[0]["Tahun"], "").ToString();
                                _warna = Tools.isNull(dt.Rows[0]["Warna"], "").ToString();
                                _nomesin = Tools.isNull(dt.Rows[0]["NoMesin"], "").ToString();
                                _norangka = Tools.isNull(dt.Rows[0]["NoRangka"], "").ToString();

                                if (this.SelectData != null)
                                {
                                    this.SelectData(this, new EventArgs());
                                }
                            }
                            else
                            {
                                ShowDialogForm(txtNoMember.Text, dt);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }

                }
                else
                {

                    Clear();
                }
            }
        }

        private void ShowDialogForm()
        {
            Lookup.FormData.frmCustomerALLLookup ifrmDialog = new Lookup.FormData.frmCustomerALLLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            Lookup.FormData.frmCustomerALLLookup ifrmDialog = new Lookup.FormData.frmCustomerALLLookup(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(Lookup.FormData.frmCustomerALLLookup dialogForm)
        {

            txtNoMember.Text = dialogForm.NomerMember;
            _rowID = dialogForm.RowId;
            _namaCust = dialogForm.NamaCust;
            _alamat = dialogForm.Alamat;
            _noktp = dialogForm.NoKTP;
            _notelp = dialogForm.NoTelepon;
            _daerah = dialogForm.Daerah;
            _nopol = dialogForm.Nopol;
            _kdtype = dialogForm.Kdtype;
            _tahun = dialogForm.tahun;
            _warna = dialogForm.warna;
            _nomesin = dialogForm.Nomesin;
            _norangka = dialogForm.Norangka;
            

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            txtNoMember.Text = "";
            _namaCust = "";
            _alamat = "";
            _kota = "";
            _notelp="";
            _noktp = "";
            _daerah = "";
            _nopol = "";
            _kdtype = "";
            _tahun = "";
            _warna = "";
            _nomesin = "";
            _norangka = "";
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }
    }
}




