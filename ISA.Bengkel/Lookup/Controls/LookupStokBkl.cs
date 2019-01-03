using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Bengkel.Helper;

namespace ISA.Bengkel.Lookup
{
    public partial class LookupStokBkl : UserControl
    {
        public event EventHandler SelectData;
        public enum EnumLookUpType { Normal, Extended };

        string _satuan, _lastStokBklName = "";
        Guid _rowStokBkl;
        EnumLookUpType _lookUpType = EnumLookUpType.Normal;
    
        public EnumLookUpType LookUpType
        {
            get
            {
                return _lookUpType;
            }
            set
            {
                _lookUpType = value;
            }
        }

        public void ResetAll()
        {
            txtLookupName.Text = string.Empty;
            txtLookupCode.Text = string.Empty;
            cmdLookup.Focus();
        }

        public string KodeStokBkl
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

        public string NamaStokBkl
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

        public string Satuan
        {
            get
            {
                return _satuan;
            }
            set
            {
                _satuan = value;
            }
        }

        public Guid RowStokBkl
        {
            get
            {
                return _rowStokBkl;
            }
            set
            {
                _rowStokBkl = value;
            }
        }
        
        public LookupStokBkl()
        {
            InitializeComponent();
        }

        public void SetStokBklName(string nama)
        {
            txtLookupName.Text = nama;
            _lastStokBklName = nama;
        }

        /* Call normal dialog form */

        private void ShowDialogForm()
        {
            frmStokBklLookup ifrmDialog = new frmStokBklLookup();
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
            frmStokBklLookup ifrmDialog = new frmStokBklLookup(searchArg, dt);
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

        private void GetDialogResult(frmStokBklLookup dialogForm)
        {
            txtLookupName.Text = dialogForm.NamaStokBkl;
            _lastStokBklName = txtLookupName.Text;
            txtLookupCode.Text = dialogForm.KodeStokBkl;
            _satuan = dialogForm.Satuan;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        /* Call extended dialog form */

        private void ShowDialogForm2()
        {
            frmStokBklLookup frmDialog = new frmStokBklLookup();
            frmDialog.ShowDialog();
            if (frmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult2(frmDialog);
            }
            else
            {
                txtLookupName.Focus();
            }
        }

        private void ShowDialogForm2(string searchArg, DataTable dt)
        {
            frmStokBklLookup frmDialog = new frmStokBklLookup(searchArg, dt);
            frmDialog.ShowDialog();
            if (frmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult2(frmDialog);
            }
            else
            {
                txtLookupName.Focus();
            }
        }

        private void GetDialogResult2(frmStokBklLookup dialogForm)
        {
            txtLookupName.Text = dialogForm.NamaStokBkl;
            _lastStokBklName = txtLookupName.Text;
            txtLookupCode.Text = dialogForm.KodeStokBkl;
            _satuan = dialogForm.Satuan;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        /*************************************************************/

        private void Clear()
        {
            txtLookupName.Text = "";
            _lastStokBklName = txtLookupName.Text;
            txtLookupCode.Text = "";
            _satuan = "";
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }


        // added to accomodate popup validation by only leaving the control
        public void ShowDialogFormValidation()
        {
            if (txtLookupName.Text != "")
            {

                    DataTable dtStok = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_bkl_stokbkl_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, txtLookupName.Text));
                        dtStok = db.Commands[0].ExecuteDataTable();
                    }

                    if (dtStok.Rows.Count == 1)
                    {
                        txtLookupName.Text = Tools.isNull(dtStok.Rows[0]["nama_stok"], "").ToString();
                        _lastStokBklName = txtLookupName.Text;
                        txtLookupCode.Text = Tools.isNull(dtStok.Rows[0]["id_brg"], "").ToString();
                        _satuan = Tools.isNull(dtStok.Rows[0]["sat_jual"], "").ToString();
                        _rowStokBkl = (Guid)dtStok.Rows[0]["RowID"];
                        if (this.SelectData != null)
                        {
                            this.SelectData(this, new EventArgs());
                        }
                    }
                    else
                    {
                        if (_lookUpType == EnumLookUpType.Normal)
                        {
                            if (dtStok.Rows.Count == 0)
                            {
                                MessageBox.Show("Tidak ada barang tersebut");
                                return;
                            }
                            else
                            {
                                ShowDialogForm(txtLookupName.Text, dtStok);
                            }
                        }
                        else
                        {
                            if (dtStok.Rows.Count == 0)
                            {
                                MessageBox.Show("Tidak ada barang tersebut");
                                return;
                            }
                            else
                            {
                                ShowDialogForm2(txtLookupName.Text, dtStok);
                            }
                        }
                    }

                
            }
        }

        private void txtLookupName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLookupName.Text != "" && txtLookupName.Text.Trim() != _lastStokBklName.Trim())
            {

                    DataTable dtStok = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_bkl_stokbkl_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, txtLookupName.Text));
                        dtStok = db.Commands[0].ExecuteDataTable();
                    }

                    if (dtStok.Rows.Count == 1)
                    {
                        txtLookupName.Text = Tools.isNull(dtStok.Rows[0]["nama_stok"], "").ToString();
                        _lastStokBklName = txtLookupName.Text;
                        txtLookupCode.Text = Tools.isNull(dtStok.Rows[0]["id_brg"], "").ToString();
                        _satuan = Tools.isNull(dtStok.Rows[0]["sat_jual"], "").ToString();
                        _rowStokBkl = (Guid)dtStok.Rows[0]["RowID"];
                        if (this.SelectData != null)
                        {
                            this.SelectData(this, new EventArgs());
                        }
                    }
                    else
                    {
                        if (_lookUpType == EnumLookUpType.Normal)
                        {
                            if (dtStok.Rows.Count == 0)
                            {
                                MessageBox.Show("Tidak ada barang tersebut");
                                return;
                            }
                            else
                            {
                                ShowDialogForm(txtLookupName.Text, dtStok);
                            }
                        }
                        else
                        {
                            if (dtStok.Rows.Count == 0)
                            {
                                MessageBox.Show("Tidak ada barang tersebut");
                                return;
                            }
                            else
                            {
                                ShowDialogForm2(txtLookupName.Text, dtStok);
                            }
                        }
                    }
                
            }          
        }

    }
}
