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
    public partial class LookupCollector : UserControl
    {
        public event EventHandler SelectData;

        //Guid  _rowID;
        bool _initCabOnly = false;
        string _lastNamaSales = "";

        /*public Guid RowID
        {
            get
            {
                return _rowID;
            }
            set
            {
                _rowID = value;
            }
        }*/

        public string CollectorID
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

        public string NamaCollector
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
        [Browsable(true), DefaultValue(false)]
        public bool InitCabOnly
        {
            get
            {
                return _initCabOnly;
            }
            set
            {
                _initCabOnly = value;
            }
        }

        public LookupCollector()
        {
            InitializeComponent();
        }

        public void SetNamaCollector(string nama)
        {
            txtLookupName.Text = nama;
            _lastNamaSales = nama;
        }

        private void ShowDialogForm()
        {
            frmCollectorLookup ifrmDialog = new frmCollectorLookup();
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
            frmCollectorLookup ifrmDialog = new frmCollectorLookup(searchArg, dt);
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

        private void GetDialogResult(frmCollectorLookup dialogForm)
        {
            //_rowID = dialogForm.RowId;
            txtLookupName.Text = dialogForm.namaSales;
            _lastNamaSales = txtLookupName.Text;
            txtLookupCode.Text = dialogForm.salesId;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            //_rowID = new Guid();
            txtLookupName.Text = "";
            _lastNamaSales = txtLookupName.Text;
            txtLookupCode.Text = "";
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }


        // added to accomodate popup validation
        public void ShowDialogFormValidation()
        {
            if (txtLookupName.Text != "")
            {
                try
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        DataTable dtStok = new DataTable();

                        db.Commands.Add(db.CreateCommand("usp_Collector_SEARCH"));
                        db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                        dtStok = db.Commands[0].ExecuteDataTable();
                        if (dtStok.Rows.Count == 1)
                        {
                            txtLookupName.Text = Tools.isNull(dtStok.Rows[0]["Nama"], "").ToString();
                            _lastNamaSales = txtLookupName.Text;
                            txtLookupCode.Text = Tools.isNull(dtStok.Rows[0]["Kode"], "").ToString();
                            if (this.SelectData != null)
                            {
                                this.SelectData(this, new EventArgs());
                            }
                        }
                        else
                        {
                            ShowDialogForm(txtLookupName.Text, dtStok);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cmdLookup_Click_1(object sender, EventArgs e)
        {
            ShowDialogForm();
        }

        private void txtLookupName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLookupName.Text.Trim() != _lastNamaSales.Trim())
            {
                if (txtLookupName.Text != "")
                {
                    try
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            DataTable dtStok = new DataTable();

                            db.Commands.Add(db.CreateCommand("usp_Collector_SEARCH"));
                            //db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, txtLookupName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                            if (_initCabOnly)
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@initCab", SqlDbType.VarChar, GlobalVar.CabangID));
                            }
                            dtStok = db.Commands[0].ExecuteDataTable();
                            if (dtStok.Rows.Count == 1)
                            {
                                txtLookupName.Text = Tools.isNull(dtStok.Rows[0]["Nama"], "").ToString();
                                _lastNamaSales = txtLookupName.Text;
                                txtLookupCode.Text = Tools.isNull(dtStok.Rows[0]["Kode"], "").ToString();
                                if (this.SelectData != null)
                                {
                                    this.SelectData(this, new EventArgs());
                                }
                            }
                            else
                            {
                                ShowDialogForm(txtLookupName.Text, dtStok);
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
