using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Toko.Controls;
using ISA.DAL;

namespace ISA.Toko.Controls
{
    public partial class LookupStock : UserControl
    {
        public event EventHandler SelectData;
        public enum EnumLookUpType { Normal, Extended };
        public enum EnumPasif { All, Aktiv };

        Guid  _rowID;
        string _satuan, _lastStockName = "";
        int _isiKoli = 0;
        EnumLookUpType _lookUpType = EnumLookUpType.Normal;
        EnumPasif _LPasifType = EnumPasif.Aktiv;

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

        public EnumPasif LPasif
        {
            get { return _LPasifType; }
            set { _LPasifType = value; }
        }

        public void ResetAll()
        {
            txtLookupName.Text = string.Empty;
            txtLookupCode.Text = string.Empty;
            cmdLookup.Focus();
        }

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

        public string BarangID
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

        public string NamaStock
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

        public LookupStock()
        {
            InitializeComponent();
        }

        public void SetStockName(string nama)
        {
            txtLookupName.Text = nama;
            _lastStockName = nama;
        }

        /* Call normal dialog form */

        private void ShowDialogForm()
        {
            frmStockLookUp ifrmDialog = new frmStockLookUp();
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
            frmStockLookUp ifrmDialog = new frmStockLookUp(searchArg, dt);
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

        private void GetDialogResult(frmStockLookUp dialogForm)
        {
            _rowID = dialogForm.RowId;
            txtLookupName.Text = dialogForm.NamaStock;
            _lastStockName = txtLookupName.Text;
            txtLookupCode.Text = dialogForm.BarangId;
            _satuan = dialogForm.Satuan;
            _isiKoli = dialogForm.nIsiKoli;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        /* Call extended dialog form */

        private void ShowDialogForm2()
        {
            frmStockLookUpExtended ifrmDialog = new frmStockLookUpExtended();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult2(ifrmDialog);
            }
            else
            {
                txtLookupName.Focus();
            }
        }

        private void ShowDialogForm2(string searchArg, DataTable dt)
        {
            frmStockLookUpExtended ifrmDialog = new frmStockLookUpExtended(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult2(ifrmDialog);
            }
            else
            {
                txtLookupName.Focus();
            }
        }

        private void GetDialogResult2(frmStockLookUpExtended dialogForm)
        {
            _rowID = dialogForm.RowId;
            txtLookupName.Text = dialogForm.NamaStock;
            _lastStockName = txtLookupName.Text;
            txtLookupCode.Text = dialogForm.BarangId;
            _satuan = dialogForm.Satuan;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        /*************************************************************/

        private void Clear()
        {
            _rowID = new Guid();
            txtLookupName.Text = "";
            _lastStockName = txtLookupName.Text;
            txtLookupCode.Text = "";
            _satuan = "";
            LPasif = EnumPasif.Aktiv;
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
                try
                {

                    DataTable dtStok = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Stok_SEARCH"));
                        db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                        if (LPasif == EnumPasif.Aktiv)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@LPasif", SqlDbType.Bit, 0));
                        }
                        dtStok = db.Commands[0].ExecuteDataTable();
                    }

                    if (dtStok.Rows.Count == 1)
                    {
                        txtLookupName.Text = Tools.isNull(dtStok.Rows[0]["NamaStok"], "").ToString();
                        _lastStockName = txtLookupName.Text;
                        txtLookupCode.Text = Tools.isNull(dtStok.Rows[0]["BarangID"], "").ToString();
                        _satuan = Tools.isNull(dtStok.Rows[0]["SatJual"], "").ToString();
                        _isiKoli = int.Parse(Tools.isNull(dtStok.Rows[0]["IsiKoli"], "").ToString());
                        _rowID = (Guid)dtStok.Rows[0]["RowID"];
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
                catch (Exception ex)
                {
                    Console.WriteLine("TEst 2");
                    Error.LogError(ex);
                }
            }
        }

        private void txtLookupName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLookupName.Text != "" && txtLookupName.Text.Trim() != _lastStockName.Trim())
            {
                try
                {

                    DataTable dtStok = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Stok_SEARCH"));
                        db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                        if (LPasif == EnumPasif.Aktiv)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@LPasif", SqlDbType.Bit, 0));
                        }
                        dtStok = db.Commands[0].ExecuteDataTable();
                    }

                    if (dtStok.Rows.Count == 1)
                    {
                        txtLookupName.Text = Tools.isNull(dtStok.Rows[0]["NamaStok"], "").ToString();
                        _lastStockName = txtLookupName.Text;
                        txtLookupCode.Text = Tools.isNull(dtStok.Rows[0]["BarangID"], "").ToString();
                        _satuan = Tools.isNull(dtStok.Rows[0]["SatJual"], "").ToString();
                        _isiKoli = int.Parse(Tools.isNull(dtStok.Rows[0]["IsiKoli"], "").ToString());
                        _rowID = (Guid)dtStok.Rows[0]["RowID"];
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
                catch (Exception ex)
                {
                    Console.WriteLine("TEst 1");
                    Error.LogError(ex);
                }
            }
            //else
            //{
            //    if (_lookUpType == EnumLookUpType.Normal)
            //    {
            //        ShowDialogForm();
            //    }
            //    else
            //    {
            //        ShowDialogForm2();
            //    }
            //}
        }

    }
}
