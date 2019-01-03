using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using ISA.Controls;
using ISA.DAL;

namespace ISA.Controls
{
    public partial class LookupNotaJual : UserControl
    {
        public event EventHandler SelectData;

        Guid _rowID;
        string _noDO;
        string _notaRecID;
        string _namaSales;

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

        public string NoNotaJual
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

        public string NotaRecID
        {
            get
            {
                return _notaRecID;
            }
            set
            {
                _notaRecID = value;
            }
        }

        public string NoDO
        {
            get
            {
                return _noDO;
            }
            set
            {
                _noDO = value;
            }
        }

        public string NamaSales
        {
            get
            {
                return _namaSales;
            }
            set
            {
                _namaSales = value;
            }
        }

        public LookupNotaJual()
        {
            InitializeComponent();
        }

        private void txtLookupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtLookupName.Text != "")
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();

                            db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_SEARCH"));
                            db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count == 1)
                            {
                                txtLookupName.Text = Tools.isNull(dt.Rows[0]["NoNota"], "").ToString();
                            }
                            else
                            {
                                ShowDialogForm(txtLookupName.Text, dt);
                            }
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.WaitCursor;
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
            frmNotaJualLookUp ifrmDialog = new frmNotaJualLookUp();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmNotaJualLookUp ifrmDialog = new frmNotaJualLookUp(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmNotaJualLookUp dialogForm)
        {
            _rowID = dialogForm.rowID;
            txtLookupName.Text = dialogForm.noNota;
            _notaRecID = dialogForm.notaRecID;
            _noDO = dialogForm.noDO;
            _namaSales = dialogForm.namaSales;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            _rowID = new Guid();
            txtLookupName.Text = "";
            _notaRecID = "";
            _noDO = "";
            _namaSales = "";
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
