using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;
using ISA.Bengkel.Helper;

namespace ISA.Bengkel.Lookup
{
    public partial class LookupSales : UserControl
    {
        public event EventHandler SelectData;

       
        bool _bypassCheckInitCab = false;
        string _kodeSales;
        string _namaSales;


        public string KodeSales
        {
            get
            {
                return txtLookupCode.Text;                
            }
            set
            {
                txtLookupCode.Text = value;
                _kodeSales = value;
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
                _namaSales = value;
            }
        }
        
        [Browsable(true), DefaultValue (false)]
        public bool ByPassCheckInitCab
        {
            get
            {
                return _bypassCheckInitCab;
            }
            set
            {
                _bypassCheckInitCab = value;
            }
        }

        public LookupSales()
        {
            InitializeComponent();
        }

        private void txtLookupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtLookupName.Text != "")
                {
                    //if (txtLookupName.Text == GlobalVar.CabangID && _bypassCheckInitCab)
                    //{
                    //    return;
                    //}
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();

                            db.Commands.Add(db.CreateCommand("usp_bkl_sales_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@nm_sales", SqlDbType.VarChar, txtLookupName.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count == 1)
                            {
                                txtLookupName.Text = Tools.isNull(dt.Rows[0]["nm_sales"], "").ToString();
                                txtLookupCode.Text = Tools.isNull(dt.Rows[0]["kd_sales"], "").ToString();
                                _kodeSales = Tools.isNull(dt.Rows[0]["kd_sales"], "").ToString();
                                _namaSales = Tools.isNull(dt.Rows[0]["nm_sales"], "").ToString();

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
                else
                {

                    Clear();
                }
            }
        }

        private void ShowDialogForm()
        {
            frmSalesLookup ifrmDialog = new frmSalesLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
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
        }

        private void GetDialogResult(frmSalesLookup dialogForm)
        {
            txtLookupName.Text = dialogForm.NamaSales;
            txtLookupCode.Text = dialogForm.KodeSales;
           
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            txtLookupName.Text = "";
            txtLookupCode.Text = "";
            _kodeSales = "";
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
