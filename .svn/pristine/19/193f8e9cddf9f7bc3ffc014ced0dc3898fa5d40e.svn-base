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
    public partial class LookupCustomerMotor : UserControl
    {
        public event EventHandler SelectData;

       
        bool _bypassCheckInitCab = false;
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

        public string NoPolisi
        {
            get
            {
                return txtLookupCode.Text;
            }
            set
            {
                txtLookupCode.Text = value;
                _noPol = value;
            }
        }

        public string Pemilik
        {
            get
            {
                return txtLookupName.Text;
            }
            set
            {
                txtLookupName.Text = value;
                _pemilik = value;
            }
        }

        public string SPM
        {
            get
            {
                return _spm;
            }
            set
            {
                _spm = value;
            }
        }

        public string SPMType
        {
            get
            {
                return _spmType;
            }
            set
            {
                _spmType = value;
            }
        }

        public string SPMTypeDescr
        {
            get
            {
                return _spmTypeDescr;
            }
            set
            {
                _spmTypeDescr = value;
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

        public string IDMember
        {
            get
            {
                return _idMember;
            }
            set
            {
                _idMember = value;
            }
        }


        public string KTP_SIM
        {
            get
            {
                return _idKTP_SIM;
            }
            set
            {
                _idKTP_SIM = value;
            }
        }
        
        [Browsable(true), DefaultValue (false)]
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

        public LookupCustomerMotor()
        {
            InitializeComponent();
        }

        private void txtLookupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtLookupName.Text != "")
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

                            db.Commands.Add(db.CreateCommand("usp_bkl_mMotorService_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@no_pol", SqlDbType.VarChar, txtLookupName.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count == 1)
                            {
                                txtLookupName.Text = Tools.isNull(dt.Rows[0]["no_pol"], "").ToString();
                                txtLookupCode.Text = Tools.isNull(dt.Rows[0]["pemilik"], "").ToString();
                                _rowID = Tools.isNull(dt.Rows[0]["RowID"], "").ToString();
                                _pemilik = Tools.isNull(dt.Rows[0]["pemilik"], "").ToString();
                                _spm = Tools.isNull(dt.Rows[0]["spm"], "").ToString();
                                _spmType = Tools.isNull(dt.Rows[0]["kode"], "").ToString();
                                _spmTypeDescr = Tools.isNull(dt.Rows[0]["jns_spm"], "").ToString();
                                _warna = Tools.isNull(dt.Rows[0]["warna"], "").ToString();
                                _tahun = Tools.isNull(dt.Rows[0]["tahun"], "").ToString();
                                _alamat = Tools.isNull(dt.Rows[0]["alamat"], "").ToString();
                                _kota = Tools.isNull(dt.Rows[0]["kota"], "").ToString();
                                _daerah = Tools.isNull(dt.Rows[0]["daerah"], "").ToString();
                                _idMember = Tools.isNull(dt.Rows[0]["id_member"], "").ToString();
                                _idKTP_SIM = Tools.isNull(dt.Rows[0]["no_id"], "").ToString();

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
                else
                {

                    Clear();
                }
            }
        }

        private void ShowDialogForm()
        {
            frmCustomerMotorLookup ifrmDialog = new frmCustomerMotorLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmCustomerMotorLookup ifrmDialog = new frmCustomerMotorLookup(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK )
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmCustomerMotorLookup dialogForm)
        {
            txtLookupName.Text = dialogForm.NoPolisi;            
            txtLookupCode.Text = dialogForm.Pemilik;
            _rowID = dialogForm.RowId;
            _noPol = dialogForm.NoPolisi;
            _pemilik = dialogForm.Pemilik;
            _spm = dialogForm.SPM;
            _spmType = dialogForm.SPMType;
            _spmTypeDescr = dialogForm.SPMTypeDescr;
            _warna = dialogForm.Warna;
            _tahun = dialogForm.Tahun;
            _alamat = dialogForm.Alamat;
            _kota = dialogForm.Kota;
            _daerah = dialogForm.Daerah;
            _idKTP_SIM = dialogForm.KTP_SIM;
            _idMember = dialogForm.IDMember;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            txtLookupName.Text = "";
            txtLookupCode.Text = "";
            _noPol = "";
            _pemilik = "";
            _spm = "";
            _warna = "";
            _tahun = "";
            _alamat = "";
            _kota = "";
            _daerah = "";
            _idKTP_SIM = "";
            _idMember = "";

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
