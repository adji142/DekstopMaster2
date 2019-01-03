using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Controls
{
    public partial class LookupExpedisi : UserControl
    {
        public event EventHandler SelectData;

        string _kodeExpedisi;
        string _namaExpedisi;
        bool _bypassCheckInitCab = false;

        public string KodeExpedisi
        {
            get
            {
                return txtLookupCodeExp.Text;
            }
            set
            {
                txtLookupCodeExp.Text = value;
            }
        }

        public string NamaExpedisi
        {
            get
            {
                return txtLookupExp.Text;
            }
            set
            {
                txtLookupExp.Text = value;
            }
        }

        //public string KodeExpedisi
        //{
        //    get
        //    {
        //        return _kodeExpedisi;
        //    }
        //    set
        //    {
        //        _kodeExpedisi = value;
        //    }
        //}

        [Browsable(true), DefaultValue (false)]

        //public bool ByPassCheckInitCab
        //{
        //    get
        //    {
        //        return _bypassCheckInitCab;
        //    }
        //    set
        //    {
        //        _bypassCheckInitCab = value;
        //    }
        //}

        public LookupExpedisi()
        {
            InitializeComponent();
        }


        private void ShowDialogForm()
        {
            frmExpedisiLookup ifrmDialog = new frmExpedisiLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmExpedisiLookup ifrmDialog = new frmExpedisiLookup(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK )
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmExpedisiLookup dialogForm)
        {
            txtLookupExp.Text = dialogForm.namaExpedisi;            
            txtLookupCodeExp.Text = dialogForm.KodeExpedisi;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            txtLookupExp.Text = "";
            txtLookupCodeExp.Text = "";
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }

        private void LookupGudang_Load(object sender, EventArgs e)
        {

        }

        private void txtLookupExp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtLookupExp.Text != "")
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dtx = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Expedisi_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@namaExpedisi", SqlDbType.VarChar, txtLookupExp.Text));
                            dtx = db.Commands[0].ExecuteDataTable();
                            if (dtx.Rows.Count == 1)
                            {
                                txtLookupExp.Text = Tools.isNull(dtx.Rows[0]["NamaExpedisi"], "").ToString();
                                txtLookupCodeExp.Text = Tools.isNull(dtx.Rows[0]["KodeExpedisi"], "").ToString();
                                if (this.SelectData != null)
                                {
                                    this.SelectData(this, new EventArgs());
                                }
                            }
                            else
                            {
                                ShowDialogForm(txtLookupExp.Text, dtx);
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
    }
}
