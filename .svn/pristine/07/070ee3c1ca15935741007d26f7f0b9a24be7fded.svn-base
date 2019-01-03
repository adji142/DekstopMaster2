using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Controls
{
    public partial class LookupSecurityUsers : UserControl
    {
        public event EventHandler SelectData;


        public string UserID
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

        public string UserName
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

        public LookupSecurityUsers()
        {
            InitializeComponent();
        }

        private void ShowDialogForm()
        {
            frmSecurityUsersLookup ifrmDialog = new frmSecurityUsersLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmSecurityUsersLookup ifrmDialog = new frmSecurityUsersLookup(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmSecurityUsersLookup dialogForm)
        {
            txtLookupName.Text = dialogForm.userName;
            txtLookupCode.Text = dialogForm.userID;

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
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();

                            db.Commands.Add(db.CreateCommand("usp_SecurityUsers_SEARCH"));
                            db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count == 1)
                            {
                                txtLookupName.Text = Tools.isNull(dt.Rows[0]["UserName"], "").ToString();
                                txtLookupCode.Text = Tools.isNull(dt.Rows[0]["UserID"], "").ToString();
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
    }
}
