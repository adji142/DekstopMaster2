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
    public partial class LookupCustomer : UserControl
    {
        public event EventHandler SelectData;

       
        bool _bypassCheckInitCab = false;
        string _rowID;
        string _kodeCust;
        string _namaCust;
        string _alamat;
        string _kota;
        string _daerah; 

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

        public LookupCustomer()
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

                            db.Commands.Add(db.CreateCommand("usp_bkl_mCustomerService_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@nama_cust", SqlDbType.VarChar, txtLookupName.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count == 1)
                            {
                                txtLookupName.Text = Tools.isNull(dt.Rows[0]["nama_cust"], "").ToString();
                                txtLookupCode.Text = Tools.isNull(dt.Rows[0]["CustomerID"], "").ToString();
                                _rowID = Tools.isNull(dt.Rows[0]["RowID"], "").ToString();
                                _alamat = Tools.isNull(dt.Rows[0]["alamat"], "").ToString();
                                _kota = Tools.isNull(dt.Rows[0]["kota"], "").ToString();
                                _daerah = Tools.isNull(dt.Rows[0]["daerah"], "").ToString();

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
            frmCustomerLookup ifrmDialog = new frmCustomerLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmCustomerLookup ifrmDialog = new frmCustomerLookup(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK )
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmCustomerLookup dialogForm)
        {
            txtLookupName.Text = dialogForm.NamaCust;            
            txtLookupCode.Text = dialogForm.KodeCust;
            _rowID = dialogForm.RowId;
            _kodeCust = dialogForm.KodeCust;
            _namaCust = dialogForm.NamaCust;
            _alamat = dialogForm.AlamatCust;
            _kota = dialogForm.Kota; 
            _daerah = dialogForm.Daerah;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            txtLookupName.Text = "";
            txtLookupCode.Text = "";
            _kodeCust = "";
            _namaCust = "";
            _alamat = "";
            _kota = "";
            _daerah = "";
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
