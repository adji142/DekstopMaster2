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
    public partial class LookupBankAsal : UserControl
    {
        public event EventHandler SelectData;
      

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

        public string Lokasi
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

        public LookupBankAsal()
        {
            InitializeComponent();
        }

        private void ShowDialogForm()
        {
            frmBankAsalLookup ifrmDialog = new frmBankAsalLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmBankAsalLookup ifrmDialog = new frmBankAsalLookup(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmBankAsalLookup dialogForm)
        {
            txtLookup.Text = dialogForm.NamaBank;
            lblLookup.Text = dialogForm.Lokasi;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        public void Clear()
        {
            txtLookup.Text = "";
            lblLookup.Text = "[LOKASI]";
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
                    db.Commands.Add(db.CreateCommand("[usp_BankKota_LIST_ByRow]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, BankRowID));
                    DataTable dtbl = db.Commands[0].ExecuteDataTable();
                    if (dtbl.Rows.Count > 0)
                    {
                        lblLookup.Text = Tools.isNull(dtbl.Rows[0]["Lokasi"], "").ToString();
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

                        db.Commands.Add(db.CreateCommand("usp_BANKKota_LOOKUP"));
                        db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookup.Text));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count == 1)
                        {
                            lblLookup.Text = Tools.isNull(dt.Rows[0]["Lokasi"], "").ToString();
                            txtLookup.Text = Tools.isNull(dt.Rows[0]["NamaBank"], "").ToString();
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

        private void LookupBankAsal_Load(object sender, EventArgs e)
        {

        }

    }
}
