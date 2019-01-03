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
    public partial class LookupNotaJualDetail : UserControl
    {
        public event EventHandler SelectData;

        Guid _rowID;
        DateTime _tglNota;
        string _kodeToko, _barangID;

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

        public string NoNota
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

        public DateTime TglNota
        {
            get
            {
                return _tglNota;
            }

            set
            {
                _tglNota = value;
            }
        }

        public string KodeToko
        {
            get
            {
                return _kodeToko;
            }
            set
            {
                _kodeToko = value;
            }
        }

        public string BarangID
        {
            get
            {
                return _barangID;
            }
            set
            {
                _barangID = value;
            }
        }

        public LookupNotaJualDetail()
        {
            InitializeComponent();
        }

        private void SearchData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    if (txtLookupName.Text != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, txtLookupName.Text));
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data");
                    txtLookupName.Text = "";
                }
                else if (dt.Rows.Count == 1)
                {
                    txtLookupName.Text = Tools.isNull(dt.Rows[0]["NoNota"], "").ToString();
                    _rowID = (Guid)(dt.Rows[0]["RowID"]);
                    _tglNota = (DateTime)Tools.isNull(dt.Rows[0]["TglNota"], "");
                }
                else
                {
                    ShowDialogForm(dt);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ShowDialogForm(DataTable dt)
        {
            frmNotaJualDetailLookUp ifrmDialog = new frmNotaJualDetailLookUp(dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmNotaJualDetailLookUp dialogForm)
        {
            _rowID = dialogForm.RowID;
            txtLookupName.Text = dialogForm.NoNota;
            _tglNota = dialogForm.TgNota;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            _rowID = new Guid();
            txtLookupName.Text = "";
            _tglNota = DateTime.Parse("");
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void txtLookupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SearchData();
            }
        }

    }
}
