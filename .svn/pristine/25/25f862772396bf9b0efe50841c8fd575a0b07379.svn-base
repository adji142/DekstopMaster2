using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Controls
{
    public partial class LookupSecurityRights : UserControl
    {
        public event EventHandler SelectData;

        string _applicationID;

        [Browsable(true)]
        public string ApplicationID
        {
            get
            {
                return _applicationID;
            }
            set
            {
                _applicationID = value;
            }
        }

        public string RightID
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

        public string RightName
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



        public LookupSecurityRights()
        {
            InitializeComponent();
        }

        private void ShowDialogForm()
        {
            frmSecurityRightsLookup ifrmDialog = new frmSecurityRightsLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmSecurityRightsLookup ifrmDialog = new frmSecurityRightsLookup(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmSecurityRightsLookup dialogForm)
        {
           
            txtLookupName.Text = dialogForm.rightName;
            txtLookupCode.Text = dialogForm.rightID;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        public void Clear()
        {
            txtLookupName.Text = "";
            txtLookupCode.Text = "";

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }

        private void txtLookupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtLookupName.Text != "")
                {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();

                            db.Commands.Add(db.CreateCommand("usp_SecurityRights_SEARCH"));
                            db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, this.ApplicationID));
                            db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count == 1)
                            {
                                txtLookupName.Text = Tools.isNull(dt.Rows[0]["RightName"], "").ToString();
                                txtLookupCode.Text = Tools.isNull(dt.Rows[0]["RightID"], "").ToString();
                            }
                            else
                            {
                                ShowDialogForm(txtLookupName.Text, dt);
                            }
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
