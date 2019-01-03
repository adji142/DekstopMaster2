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
    public partial class LookupBarang : UserControl
    {
        public event EventHandler SelectData;
        public enum EnumLookUpType { Normal, Extended };

        string _satuan, _lastBarangName = "", _bundel;
        int _isiKoli;
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

        public string KodeBarang
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

        public string NamaBarang
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

        public int IsiKoli
        {
            get
            {
                return _isiKoli;
            }
            set
            {
                _isiKoli = value;
            }
        }

        public string Bundel
        {
            get
            {
                return _bundel;
            }
            set
            {
                _bundel = value;
            }
        }

        public LookupBarang()
        {
            InitializeComponent();
        }

        public void SetBarangName(string nama)
        {
            txtLookupName.Text = nama;
            _lastBarangName = nama;
        }

        /* Call normal dialog form */

        private void ShowDialogForm()
        {
            frmBarangLookup ifrmDialog = new frmBarangLookup();
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
            frmBarangLookup ifrmDialog = new frmBarangLookup(searchArg, dt);
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

        private void GetDialogResult(frmBarangLookup dialogForm)
        {
            txtLookupName.Text = dialogForm.NamaBarang;
            _lastBarangName = txtLookupName.Text;
            txtLookupCode.Text = dialogForm.KodeBarang;
            _satuan = dialogForm.Satuan;
            _isiKoli = dialogForm.IsiKoli;
            _bundel = dialogForm.Bundel;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        /* Call extended dialog form */

        private void ShowDialogForm2()
        {
            frmBarangLookup frmDialog = new frmBarangLookup();
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
            frmBarangLookup frmDialog = new frmBarangLookup(searchArg, dt);
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

        private void GetDialogResult2(frmBarangLookup dialogForm)
        {
            txtLookupName.Text = dialogForm.NamaBarang;
            _lastBarangName = txtLookupName.Text;
            txtLookupCode.Text = dialogForm.KodeBarang;
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
            _lastBarangName = txtLookupName.Text;
            txtLookupCode.Text = "";
            _satuan = "";
            _isiKoli = 0;
            _bundel = "";
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
                        db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, txtLookupName.Text));
                        dtStok = db.Commands[0].ExecuteDataTable();
                    }

                    if (dtStok.Rows.Count == 1)
                    {
                        txtLookupName.Text = Tools.isNull(dtStok.Rows[0]["nama_stok"], "").ToString();
                        _lastBarangName = txtLookupName.Text;
                        txtLookupCode.Text = Tools.isNull(dtStok.Rows[0]["id_brg"], "").ToString();
                        _satuan = Tools.isNull(dtStok.Rows[0]["sat_jual"], "").ToString();
                        _isiKoli = (int)Tools.isNull(dtStok.Rows[0]["isi_koli"], 0);
                        _bundel = Tools.isNull(dtStok.Rows[0]["bundel"], "").ToString();
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
            if (txtLookupName.Text != "" && txtLookupName.Text.Trim() != _lastBarangName.Trim())
            {

                    DataTable dtStok = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, txtLookupName.Text));
                        dtStok = db.Commands[0].ExecuteDataTable();
                    }

                    if (dtStok.Rows.Count == 1)
                    {
                        txtLookupName.Text = Tools.isNull(dtStok.Rows[0]["nama_stok"], "").ToString();
                        _lastBarangName = txtLookupName.Text;
                        txtLookupCode.Text = Tools.isNull(dtStok.Rows[0]["id_brg"], "").ToString();
                        _satuan = Tools.isNull(dtStok.Rows[0]["sat_jual"], "").ToString();
                        _isiKoli = (int)Tools.isNull(dtStok.Rows[0]["isi_koli"], 0);
                        _bundel = Tools.isNull(dtStok.Rows[0]["bundel"], "").ToString();
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
