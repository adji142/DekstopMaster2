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
    public partial class LookupMekanik : UserControl
    {
        public event EventHandler SelectData;

       
        bool _bypassCheckInitCab = false;
        string _kodeMekanik;
        string _namaMekanik;


        public string KodeMekanik
        {
            get
            {
                return txtLookupCode.Text;                
            }
            set
            {
                txtLookupCode.Text = value;
                _kodeMekanik = value;
            }
        }

        public string NamaMekanik
        {
            get
            {
                return txtLookupName.Text;
            }
            set
            {
                txtLookupName.Text = value;
                _namaMekanik = value;
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

        public LookupMekanik()
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

                            db.Commands.Add(db.CreateCommand("usp_bkl_mMekanikService_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtLookupName.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count == 1)
                            {
                                txtLookupName.Text = Tools.isNull(dt.Rows[0]["nama"], "").ToString();
                                txtLookupCode.Text = Tools.isNull(dt.Rows[0]["kd_mk"], "").ToString();
                                _kodeMekanik = Tools.isNull(dt.Rows[0]["kd_mk"], "").ToString();
                                _namaMekanik = Tools.isNull(dt.Rows[0]["nama"], "").ToString();

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
            frmMekanikLookup ifrmDialog = new frmMekanikLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmMekanikLookup ifrmDialog = new frmMekanikLookup(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK )
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmMekanikLookup dialogForm)
        {
            txtLookupName.Text = dialogForm.NamaMekanik;
            txtLookupCode.Text = dialogForm.KodeMekanik;
           
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            txtLookupName.Text = "";
            txtLookupCode.Text = "";
            _kodeMekanik = "";
            _namaMekanik = "";
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
