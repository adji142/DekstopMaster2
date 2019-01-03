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
    public partial class LookupCustomerBengkel : UserControl
    {
        public event EventHandler SelectData;

       
        bool _bypassCheckInitCab = false;

        Guid _customerServiceRowID;
        public Guid CustomerServiceRowID
        {
            get
            {
                return _customerServiceRowID;
            }
            set
            {
                _customerServiceRowID = value;
            }
        }

        Guid _motorServiceRowID;
        public Guid MotorServiceRowID
        {
            get
            {
                return _motorServiceRowID;
            }
            set
            {
                _motorServiceRowID = value;
            }
        }

        string _idCust;
        public string IdCust
        {
            get
            {
                return _idCust;
            }
            set
            {
                _idCust = value;
            }
        }

        string _kodeCust;
        public string KodeCust
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

        string _namaCust;
        public string NamaCust
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

        string _pemilik;
        public string Pemilik
        {
            get
            {
                return _pemilik;
            }
            set
            {
                _pemilik = value;
            }
        }

        string _noID;
        public string NoID
        {
            get
            {
                return _noID;
            }
            set
            {
                _noID = value;
            }
        }

        string _alamat;
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

        string _kota;
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

        string _daerah;
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

        string _noTelp;
        public string NoTelp
        {
            get
            {
                return _noTelp;
            }
            set
            {
                _noTelp = value;
            }
        }

        string _noPol;
        public string NoPol
        {
            get
            {
                return _noPol;
            }
            set
            {
                _noPol = value;
            }
        }

        string _kodeSpm;
        public string KodeSpm
        {
            get
            {
                return _kodeSpm;
            }
            set
            {
                _kodeSpm = value;
            }
        }

        string _jnsSpm;
        public string JnsSpm
        {
            get
            {
                return _jnsSpm;
            }
            set
            {
                _jnsSpm = value;
            }
        }

        string _spm;
        public string Spm
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

        string _noMesin;
        public string NoMesin
        {
            get
            {
                return _noMesin;
            }
            set
            {
                _noMesin = value;
            }
        }

        string _noRangka;
        public string NoRangka
        {
            get
            {
                return _noRangka;
            }
            set
            {
                _noRangka = value;
            }
        }

        string _warna;
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

        string _tahun;
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

        Guid _memberServiceRowID;
        public Guid MemberServiceRowID
        {
            get
            {
                return _memberServiceRowID;
            }
            set
            {
                _memberServiceRowID = value;
            }
        }

        string _idMember;
        public string IdMember
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

        public LookupCustomerBengkel()
        {
            InitializeComponent();
        }

        private void ShowDialogForm()
        {
            ISA.Bengkel.Master.frmCustomerBrowse ifrmDialog = new ISA.Bengkel.Master.frmCustomerBrowse();
            ifrmDialog.MinimizeBox = false;
            ifrmDialog.MaximizeBox = false;
            ifrmDialog.WindowState = FormWindowState.Normal;
            ifrmDialog.ShowDialog();

            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg)
        {
            ISA.Bengkel.Master.frmCustomerBrowse ifrmDialog = new ISA.Bengkel.Master.frmCustomerBrowse(searchArg);
            ifrmDialog.MinimizeBox = false;
            ifrmDialog.MaximizeBox = false;
            ifrmDialog.WindowState = FormWindowState.Normal;
            ifrmDialog.ShowDialog();

            if (ifrmDialog.DialogResult == DialogResult.OK )
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(ISA.Bengkel.Master.frmCustomerBrowse dialogForm)
        {
            txtLookupName.Text = dialogForm.NamaCust;            
            txtLookupCode.Text = dialogForm.KodeCust;
            _customerServiceRowID = dialogForm.CustomerServiceRowID;
            _motorServiceRowID = dialogForm.MotorServiceRowID;
            _idCust = dialogForm.IdCust;
            _kodeCust = dialogForm.KodeCust;
            _namaCust = dialogForm.NamaCust;
            _pemilik = dialogForm.Pemilik;
            _noID = dialogForm.NoID;
            _alamat = dialogForm.Alamat;
            _kota = dialogForm.Kota;
            _daerah = dialogForm.Daerah;
            _noTelp = dialogForm.NoTelp;
            _noPol = dialogForm.NoPol;
            _kodeSpm = dialogForm.KodeSpm;
            _jnsSpm = dialogForm.JnsSpm;
            _spm = dialogForm.Spm;
            _noMesin = dialogForm.NoMesin;
            _noRangka = dialogForm.NoRangka;
            _warna = dialogForm.Warna;
            _tahun = dialogForm.Tahun;
            _memberServiceRowID = dialogForm.MemberServiceRowID;
            _idMember = dialogForm.IdMember;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            txtLookupName.Text = string.Empty;
            txtLookupCode.Text = string.Empty;
            _idCust = string.Empty;
            _kodeCust = string.Empty;
            _namaCust = string.Empty;
            _pemilik = string.Empty;
            _noID = string.Empty;
            _alamat = string.Empty;
            _kota = string.Empty;
            _daerah = string.Empty;
            _noTelp = string.Empty;
            _noPol = string.Empty;
            _kodeSpm = string.Empty;
            _jnsSpm = string.Empty;
            _spm = string.Empty;
            _noMesin = string.Empty;
            _noRangka = string.Empty;
            _warna = string.Empty;
            _tahun = string.Empty;
            _idMember = string.Empty;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }

        private void txtLookupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtLookupName.Text != string.Empty)
                {
                    try
                    {
                        DataTable dt = new DataTable();

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_mCustomerService_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@nama_cust", SqlDbType.VarChar, txtLookupName.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        if (dt.Rows.Count == 1)
                        {
                            _customerServiceRowID = (Guid)dt.Rows[0]["RowID"];

                            DataTable dtMember = new DataTable();

                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_bkl_mMemberService_LIST"));
                                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _customerServiceRowID));
                                dtMember = db.Commands[0].ExecuteDataTable();
                            }

                            if (dtMember.Rows.Count == 1)
                            {
                                _memberServiceRowID = (Guid)dtMember.Rows[0]["RowID"];
                                _idMember = Tools.isNull(dtMember.Rows[0]["id_member"], string.Empty).ToString();
                            }

                            DataTable dtMotor = new DataTable();

                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_bkl_mMotorService_LIST"));
                                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _customerServiceRowID));
                                dtMotor = db.Commands[0].ExecuteDataTable();
                            }

                            if (dtMotor.Rows.Count == 1)
                            {
                                txtLookupName.Text = Tools.isNull(dt.Rows[0]["nama_cust"], string.Empty).ToString();
                                txtLookupCode.Text = Tools.isNull(dt.Rows[0]["kd_cust"], string.Empty).ToString();

                                _motorServiceRowID = (Guid)dtMotor.Rows[0]["RowID"];
                                _noID = Tools.isNull(dtMotor.Rows[0]["no_id"], string.Empty).ToString();
                                _pemilik = Tools.isNull(dtMotor.Rows[0]["pemilik"], string.Empty).ToString();
                                _alamat = Tools.isNull(dtMotor.Rows[0]["alamat"], string.Empty).ToString();
                                _kota = Tools.isNull(dtMotor.Rows[0]["kota"], string.Empty).ToString();
                                _daerah = Tools.isNull(dtMotor.Rows[0]["daerah"], string.Empty).ToString();
                                _noTelp = Tools.isNull(dtMotor.Rows[0]["no_telp"], string.Empty).ToString();
                                _noPol = Tools.isNull(dtMotor.Rows[0]["no_pol"], string.Empty).ToString();
                                _kodeSpm = Tools.isNull(dtMotor.Rows[0]["kode"], string.Empty).ToString();
                                _jnsSpm = Tools.isNull(dtMotor.Rows[0]["jns_spm"], string.Empty).ToString();
                                _spm = Tools.isNull(dtMotor.Rows[0]["spm"], string.Empty).ToString();
                                _noMesin = Tools.isNull(dtMotor.Rows[0]["no_mesin"], string.Empty).ToString();
                                _noRangka = Tools.isNull(dtMotor.Rows[0]["no_rangka"], string.Empty).ToString();
                                _warna = Tools.isNull(dtMotor.Rows[0]["warna"], string.Empty).ToString();
                                _tahun = Tools.isNull(dtMotor.Rows[0]["tahun"], string.Empty).ToString();

                                if (this.SelectData != null)
                                {
                                    this.SelectData(this, new EventArgs());
                                }
                            }
                        }
                        else
                        {
                            ShowDialogForm(txtLookupName.Text);
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
    }
}
