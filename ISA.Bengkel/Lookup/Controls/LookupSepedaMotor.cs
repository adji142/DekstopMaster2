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
    public partial class LookupSepedaMotor : UserControl
    {
        public event EventHandler SelectData;

       
        bool _bypassCheckInitCab = false;
        string _kodeSepedaMotor;
        string _namaSepedaMotor;


        public string KodeSepedaMotor
        {
            get
            {
                return txtLookupCode.Text;                
            }
            set
            {
                txtLookupCode.Text = value;
                _kodeSepedaMotor = value;
            }
        }

        public string NamaSepedaMotor
        {
            get
            {
                return txtLookupName.Text;
            }
            set
            {
                txtLookupName.Text = value;
                _namaSepedaMotor = value;
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

        public LookupSepedaMotor()
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

                            db.Commands.Add(db.CreateCommand("usp_bkl_mMotor_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@jns_spm", SqlDbType.VarChar, txtLookupName.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count == 1)
                            {
                                txtLookupName.Text = Tools.isNull(dt.Rows[0]["jns_spm"], "").ToString();
                                txtLookupCode.Text = Tools.isNull(dt.Rows[0]["kode"], "").ToString();
                                _kodeSepedaMotor = Tools.isNull(dt.Rows[0]["kode"], "").ToString();
                                _namaSepedaMotor = Tools.isNull(dt.Rows[0]["jns_spm"], "").ToString();

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
            frmSepedaMotorLookup ifrmDialog = new frmSepedaMotorLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmSepedaMotorLookup ifrmDialog = new frmSepedaMotorLookup(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK )
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmSepedaMotorLookup dialogForm)
        {
            txtLookupName.Text = dialogForm.NamaSepedaMotor;
            txtLookupCode.Text = dialogForm.KodeSepedaMotor;
           
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            txtLookupName.Text = "";
            txtLookupCode.Text = "";
            _kodeSepedaMotor = "";
            _namaSepedaMotor = "";
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
