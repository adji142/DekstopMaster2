using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Controls
{
    public partial class LookupPostArea : UserControl
    {
        public event EventHandler SelectData;
        string _postName;

        public bool textMatch
        {
            get
            {
                if (lblInfo.Text == "ALL => Semua Pos" && txtLookupName.Text != "")
                    return false;
                else
                    return true;
            }
        }

        public string PostID
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

        public string PostName
        {
            get
            {
                return _postName;
            }
            set
            {
                _postName = value;
            }
        }

        public LookupPostArea()
        {
            InitializeComponent();
        }

        private void txtLookupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtLookupName.Text == "ALL")
                {
                    lblInfo.Text = "=> Semua Pos";
                }
                else
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {

                            db.Commands.Add(db.CreateCommand("usp_PostArea_SEARCH"));
                            if (txtLookupName.Text != "")
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                            }
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Tidak ada data");
                        }
                        else
                        {
                            if (dt.Rows.Count == 1)
                            {
                                txtLookupName.Text = Tools.isNull(dt.Rows[0]["PostID"], "").ToString();
                                _postName = Tools.isNull(dt.Rows[0]["PostName"], "").ToString();
                                lblInfo.Text = "=> " + _postName;
                                if (this.SelectData != null)
                                {
                                    this.SelectData(this, new EventArgs());
                                }
                            }
                            else
                            {
                                ShowDialogForm(dt);
                            }
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }                
            }
        }

        private void ShowDialogForm(DataTable dt)
        {
            frmPostAreaLookUp ifrmDialog = new frmPostAreaLookUp(dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmPostAreaLookUp dialogForm)
        {
            _postName = dialogForm.postName;
            txtLookupName.Text = dialogForm.postID;
            lblInfo.Text = "=> " + _postName; 
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {           
            txtLookupName.Text = "";
            _postName = "";
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void txtLookupName_TextChanged(object sender, EventArgs e)
        {
            if (txtLookupName.Text == "ALL")
                lblInfo.Text = "=> Semua Pos";
            else
                lblInfo.Text = "ALL => Semua Pos";
        }

        private void txtLookupName_Validating(object sender, CancelEventArgs e)
        {
            if (lblInfo.Text == "ALL => Semua Pos" && txtLookupName.Text != "")
            {
                txtLookupName.Focus();
            }
        }
    }
}
