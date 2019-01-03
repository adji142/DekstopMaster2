using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.Controls
{
    public partial class LookupBank : UserControl
    {
        public event EventHandler SelectData;
        Guid _rowID;

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


        public string BankID
        {
            get
            {
                return lblLookup.Text;
            }
            set
            {
                lblLookup.Text = value;
            }
        }

        public string NamaBank
        {
            get
            {
                return txtLookup.Text;
            }
            set
            {
                txtLookup.Text = value;
            }
        }

        public LookupBank()
        {
            InitializeComponent();
        }

        private void ShowDialogForm()
        {
            frmBankLookup ifrmDialog = new frmBankLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmBankLookup ifrmDialog = new frmBankLookup(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmBankLookup dialogForm)
        {
            txtLookup.Text = dialogForm.NamaBank;
            lblLookup.Text = dialogForm.BankID;
            _rowID = dialogForm.RowID;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        public void Clear()
        {
            txtLookup.Text = "";
            lblLookup.Text = "[CODE]";
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        public bool Set()
        {
            return this.Set(Guid.Empty);
        }
        public bool Set(Guid BankRowID)
        {
            try
            {
                this.Clear();
                if (BankRowID == Guid.Empty) return true;
                using (var db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Bank_LIST_ByRowID]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, BankRowID));
                    DataTable dtbl = db.Commands[0].ExecuteDataTable();
                    if (dtbl.Rows.Count > 0)
                    {
                        lblLookup.Text = Tools.isNull(dtbl.Rows[0]["BankID"], "").ToString();
                        txtLookup.Text = Tools.isNull(dtbl.Rows[0]["NamaBank"], "").ToString();
                        _rowID = (Guid)Tools.isNull(dtbl.Rows[0]["RowID"], Guid.Empty);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return false;
        }

        private void txtLookup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtLookup.Text != "")
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        DataTable dt = new DataTable();

                        db.Commands.Add(db.CreateCommand("usp_BANK_LOOKUP"));
                        db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookup.Text));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count == 1)
                        {
                            lblLookup.Text = Tools.isNull(dt.Rows[0]["BankID"], "").ToString();
                            txtLookup.Text = Tools.isNull(dt.Rows[0]["NamaBank"], "").ToString();
                            _rowID = (Guid)Tools.isNull(dt.Rows[0]["RowID"], "");
                            if (this.SelectData != null)
                            {
                                this.SelectData(this, new EventArgs());
                            }
                        }
                        else
                        {
                            ShowDialogForm(txtLookup.Text, dt);
                        }
                    }


                }
                else
                {

                    Clear();
                }
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }
    }
}
