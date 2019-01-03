using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Controls
{
    public partial class LookupStafAdm : UserControl
    {
        public event EventHandler SelectData;

        Guid  _rowID;

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

        public string Kode
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

        public string Nama
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

        public LookupStafAdm()
        {
            InitializeComponent();
        }

        public void SetNama(string nama)
        {
            txtLookupName.Text = nama;
        }

        private void txtLookupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void ShowDialogForm()
        {
            frmStafAdmLookUp ifrmDialog = new frmStafAdmLookUp();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
            else
            {
                txtLookupName.Focus();
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmStafAdmLookUp ifrmDialog = new frmStafAdmLookUp(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
            else
            {
                txtLookupName.Focus();
            }
        }

        private void GetDialogResult(frmStafAdmLookUp dialogForm)
        {
            _rowID = dialogForm.RowId;
            txtLookupName.Text = dialogForm.Nama;
            txtLookupCode.Text = dialogForm.Kode;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            _rowID = new Guid();
            txtLookupName.Text = "";
            txtLookupCode.Text = "[CODE]";
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }

        public void ShowDialogFormValidation()
        {
            if (txtLookupName.Text != "")
            {
                SearchToko();
            }
        
        }

        public void SearchToko()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, true));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 1)
                    {
                        txtLookupName.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                        txtLookupCode.Text = Tools.isNull(dt.Rows[0]["Kode"], "").ToString();
                        _rowID = (Guid)dt.Rows[0]["RowID"];
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

        public void SetToko(string Kode_)
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_Toko_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Kode_));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 1)
                    {
                        txtLookupName.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                        txtLookupCode.Text = Tools.isNull(dt.Rows[0]["kode"], "").ToString();
                        _rowID = (Guid)dt.Rows[0]["RowID"];
                        
                        //_kecamatan = Tools.isNull(dt.Rows[0]["Kecamatan"], "").ToString();
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

        private void txtLookupName_Validating(object sender, CancelEventArgs e)
        {
            //if (_lastNama.Trim() != txtLookupName.Text.Trim())
            //{
                if (txtLookupName.Text != "")
                {
                    SearchToko();
                }
                else
                {
                    Clear();
                }
            //}
        }

        private void LookupStafAdm_Load(object sender, EventArgs e)
        {

        }
    }
}
