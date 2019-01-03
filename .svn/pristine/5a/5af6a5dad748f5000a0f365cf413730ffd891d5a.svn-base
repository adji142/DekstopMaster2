using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;

namespace ISA.Controls
{
    public partial class LookupSales : UserControl
    {
        public event EventHandler SelectData;

        Guid  _rowID;
        bool _initCabOnly = false;
        string _lastNamaSales = "";

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

        public string SalesID
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

        public string NamaSales
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

        public LookupSales()
        {
            InitializeComponent();
        }

        public void SetNamaSales(string nama)
        {
            txtLookupName.Text = nama;
            _lastNamaSales = nama;
        }

        private void txtLookupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13 && txtLookupName.Text.Trim() != _lastNamaSales.Trim())
            //{
            //    if (txtLookupName.Text != "")
            //    {
            //        try
            //        {
            //            using (Database db = new Database())
            //            {
            //                DataTable dtStok = new DataTable();

            //                db.Commands.Add(db.CreateCommand("usp_Sales_SEARCH"));
            //                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
            //                if (_initCabOnly)
            //                {
            //                    db.Commands[0].Parameters.Add(new Parameter("@initCab", SqlDbType.VarChar, GlobalVar.CabangID));
            //                }
            //                dtStok = db.Commands[0].ExecuteDataTable();
            //                if (dtStok.Rows.Count == 1)
            //                {
            //                    txtLookupName.Text = Tools.isNull(dtStok.Rows[0]["NamaSales"], "").ToString();
            //                    _lastNamaSales = txtLookupName.Text;
            //                    txtLookupCode.Text = Tools.isNull(dtStok.Rows[0]["SalesID"], "").ToString();
            //                    if (this.SelectData != null)
            //                    {
            //                        this.SelectData(this, new EventArgs());
            //                    }
            //                }
            //                else
            //                {
            //                    ShowDialogForm(txtLookupName.Text, dtStok);
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.LogError(ex);
            //        }
            //    }
            //    else
            //    {

            //        Clear();
            //    }
            //}
        }

        private void ShowDialogForm()
        {
            frmSalesLookup ifrmDialog = new frmSalesLookup();
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
            frmSalesLookup ifrmDialog = new frmSalesLookup(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK )
            {
                GetDialogResult(ifrmDialog);
            }
            else
            {
                txtLookupName.Focus();
            }
        }

        private void GetDialogResult(frmSalesLookup dialogForm)
        {
            _rowID = dialogForm.RowId;
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
            _rowID = new Guid();
            txtLookupName.Text = "";
            _lastNamaSales = txtLookupName.Text;
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
        

        // added to accomodate popup validation
        public void ShowDialogFormValidation()
        {
            if (txtLookupName.Text != "")
            {
                    using (Database db = new Database())
                    {
                        DataTable dtStok = new DataTable();

                        db.Commands.Add(db.CreateCommand("usp_Sales_SEARCH"));
                        db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                        dtStok = db.Commands[0].ExecuteDataTable();
                        if (dtStok.Rows.Count == 1)
                        {
                            txtLookupName.Text = Tools.isNull(dtStok.Rows[0]["NamaSales"], "").ToString();
                            _lastNamaSales = txtLookupName.Text;
                            txtLookupCode.Text = Tools.isNull(dtStok.Rows[0]["SalesID"], "").ToString();
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
        }

        private void txtLookupName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLookupName.Text.Trim() != _lastNamaSales.Trim())
            {
                if (txtLookupName.Text != "")
                {

                        using (Database db = new Database())
                        {
                            DataTable dtStok = new DataTable();

                            db.Commands.Add(db.CreateCommand("usp_Sales_SEARCH"));
                            db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                            if (_initCabOnly)
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@initCab", SqlDbType.VarChar, GlobalVar.CabangID));
                            }
                            dtStok = db.Commands[0].ExecuteDataTable();
                            if (dtStok.Rows.Count == 1)
                            {
                                txtLookupName.Text = Tools.isNull(dtStok.Rows[0]["NamaSales"], "").ToString();
                                _lastNamaSales = txtLookupName.Text;
                                txtLookupCode.Text = Tools.isNull(dtStok.Rows[0]["SalesID"], "").ToString();
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
                else
                {

                    Clear();
                }
            }
        }
    }
}
