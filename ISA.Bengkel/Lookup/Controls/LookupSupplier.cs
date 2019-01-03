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
    public partial class LookupSupplier : UserControl
    {
        public event EventHandler SelectData;

       
        bool _bypassCheckInitCab = false;
        string _kodeSupplier;
        string _namaSupplier;


        public string KodeSupplier
        {
            get
            {
                return txtLookupCode.Text;                
            }
            set
            {
                txtLookupCode.Text = value;
                _kodeSupplier = value;
            }
        }

        public string NamaSupplier
        {
            get
            {
                return txtLookupName.Text;
            }
            set
            {
                txtLookupName.Text = value;
                _namaSupplier = value;
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

        public LookupSupplier()
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

                            db.Commands.Add(db.CreateCommand("usp_bkl_pemasok_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtLookupName.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count == 1)
                            {
                                txtLookupName.Text = Tools.isNull(dt.Rows[0]["nama"], "").ToString();
                                txtLookupCode.Text = Tools.isNull(dt.Rows[0]["idp"], "").ToString();
                                _kodeSupplier = Tools.isNull(dt.Rows[0]["idp"], "").ToString();
                                _namaSupplier = Tools.isNull(dt.Rows[0]["nama"], "").ToString();

                                if (this.SelectData != null)
                                {
                                    this.SelectData(this, new EventArgs());
                                }
                            }
                            else
                            {
                                //ShowDialogForm(txtLookupName.Text, dt);
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
            frmSupplierLookup ifrmDialog = new frmSupplierLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        //private void ShowDialogForm(string searchArg, DataTable dt)
        //{
        //    frmSupplierLookup ifrmDialog = new frmSupplierLookup(searchArg, dt);
        //    ifrmDialog.ShowDialog();
        //    if (ifrmDialog.DialogResult == DialogResult.OK )
        //    {
        //        GetDialogResult(ifrmDialog);
        //    }
        //}

        private void GetDialogResult(frmSupplierLookup dialogForm)
        {
            txtLookupName.Text = dialogForm.NamaSupplier;
            txtLookupCode.Text = dialogForm.KodeSupplier;
           
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            txtLookupName.Text = "";
            txtLookupCode.Text = "";
            _kodeSupplier = "";
            _namaSupplier = "";
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
