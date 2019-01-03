using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Collections;

namespace ISA.Trading.Master
{
    public partial class frmMasterStokUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;

        DataTable dt;

        public frmMasterStokUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmMasterStokUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;
        }

        private void frmMasterStokUpdate_Load(object sender, EventArgs e)
        {   
            try
            {
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data

                    txtBarangID.Text = Tools.isNull(dt.Rows[0]["barangID"], "").ToString();
                    txtBarangID.Enabled = false;
                    txtNamaStok.Text = Tools.isNull(dt.Rows[0]["NamaStok"], "").ToString();
                    txtNamaStok.Enabled = false;
                    txtKodeRak.Text = Tools.isNull(dt.Rows[0]["KodeRak"], "").ToString();
                    txtKodeRak1.Text = Tools.isNull(dt.Rows[0]["KodeRak1"], "").ToString();
                    txtKodeRak2.Text = Tools.isNull(dt.Rows[0]["KodeRak2"], "").ToString();
                    txtSatJual.Text = Tools.isNull(dt.Rows[0]["SatJual"], "").ToString();
                    txtSatJual.Enabled = false;
                    txtSatSolo.Text = Tools.isNull(dt.Rows[0]["SatSolo"], "").ToString();
                    txtSatSolo.Enabled = false;
                    chkStatusAktif.Checked = !((bool)dt.Rows[0]["StatusPasif"]);
                    txtPrediksiLamaKirim.Text = Tools.isNull(dt.Rows[0]["PrediksiLamaKirim"], "").ToString();
                    txtHariRataRata.Text = Tools.isNull(dt.Rows[0]["HariRataRata"], "").ToString();
                    cboBundle.SelectedItem = Tools.isNull(dt.Rows[0]["Bundle"], "").ToString() == "FM" ? "FAST" : "SLOW";
                    txtKendaraan.Text = Tools.isNull(dt.Rows[0]["Kendaraan"], "").ToString();
                    txtKendaraan.Enabled = false;

                    if (Tools.isNull(dt.Rows[0]["KodeSolo"], "").ToString() == "FXT")
                    {
                        //txtSatJual.Enabled = false;
                        //txtSatSolo.Enabled = false;
                        txtNamaStok.Enabled = true;
                    }

                }
                else
                {
                    chkStatusAktif.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Gudang.ToString().Trim().Substring(0, 2) == "28")
            {
                if (txtBarangID.Text.ToString().Trim().Length != 12)
                {
                    MessageBox.Show("Kode Barang harus 12 Character");
                    txtBarangID.Focus();
                    return;
                }
            }

            if (string.IsNullOrEmpty(txtBarangID.Text))
            {
                MessageBox.Show("Barang ID belum diisi");
                txtBarangID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNamaStok.Text))
            {
                MessageBox.Show("Nama stok belum diisi");
                txtNamaStok.Focus();
                return;
            }
            if (txtKodeRak.Text.Trim()!="")
            {
                if (!KodeRak())
                {
                    errorProvider1.SetError(txtKodeRak, "KodeRak Sudah Ada");
                    txtKodeRak.Focus();
                    return;
                }
            }
           
            //if (string.IsNullOrEmpty(txtSatJual.Text))
            //{
            //    MessageBox.Show("Satuan jual belum diisi");
            //    txtSatJual.Focus();
            //    return;
            //}

            //if (string.IsNullOrEmpty(txtSatSolo.Text))
            //{
            //    MessageBox.Show("Satuan beli belum diisi");
            //    txtSatSolo.Focus();
            //    return;
            //}
            
            string barangIDSubString = txtBarangID.Text.Substring(0, 3).ToUpper();
            //if (barangIDSubString.CompareTo("FXT") == 0)
            //{
                try
                {
                    int _prediksiLamaKirim = 0;
                    int _hariRataRata = 0;

                    if (txtPrediksiLamaKirim.Text != "")
                        _prediksiLamaKirim = txtPrediksiLamaKirim.GetIntValue;

                    if (txtHariRataRata.Text != "")
                        _hariRataRata = txtHariRataRata.GetIntValue;

                    switch (formMode)
                    {
                        case enumFormMode.New:
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Stok_INSERT"));

                                _rowID = Guid.NewGuid();

                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                                db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, txtBarangID.Text.ToUpper()));
                                db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtNamaStok.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeRak", SqlDbType.VarChar, txtKodeRak.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeRak1", SqlDbType.VarChar, txtKodeRak1.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeRak2", SqlDbType.VarChar, txtKodeRak2.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@satJual", SqlDbType.VarChar, txtSatJual.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@satSolo", SqlDbType.VarChar, txtSatSolo.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@statusPasif", SqlDbType.Bit, !chkStatusAktif.Checked));
                                db.Commands[0].Parameters.Add(new Parameter("@prediksiLamaKirim", SqlDbType.Int, _prediksiLamaKirim));
                                db.Commands[0].Parameters.Add(new Parameter("@hariRataRata", SqlDbType.Int, _hariRataRata));
                                db.Commands[0].Parameters.Add(new Parameter("@bundle", SqlDbType.VarChar, cboBundle.Text == "SLOW" ? "SM" : "FM"));
                                db.Commands[0].Parameters.Add(new Parameter("@kendaraan", SqlDbType.VarChar, txtKendaraan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                dt = db.Commands[0].ExecuteDataTable();
                                if (dt.Rows.Count > 0)
                                {
                                    MessageBox.Show("Data sudah ada !!");
                                    return;
                                }
                            }
                            break;
                        case enumFormMode.Update:
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Stok_UPDATE"));

                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, txtBarangID.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtNamaStok.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeRak", SqlDbType.VarChar, txtKodeRak.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeRak1", SqlDbType.VarChar, txtKodeRak1.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeRak2", SqlDbType.VarChar, txtKodeRak2.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@satJual", SqlDbType.VarChar, txtSatJual.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@satSolo", SqlDbType.VarChar, txtSatSolo.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@statusPasif", SqlDbType.Bit, !chkStatusAktif.Checked));
                                db.Commands[0].Parameters.Add(new Parameter("@prediksiLamaKirim", SqlDbType.Int, txtPrediksiLamaKirim.GetIntValue));
                                db.Commands[0].Parameters.Add(new Parameter("@hariRataRata", SqlDbType.Int, txtHariRataRata.GetIntValue));
                                db.Commands[0].Parameters.Add(new Parameter("@bundle", SqlDbType.VarChar, cboBundle.Text == "SLOW" ? "SM" : "FM"));
                                db.Commands[0].Parameters.Add(new Parameter("@kendaraan", SqlDbType.VarChar, txtKendaraan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            break;
                    }
                    this.DialogResult = DialogResult.OK;
                    //CloseForm();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            //}
            //else
            //{
            //    MessageBox.Show(Messages.Error.CustomStock);
            //}
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool KodeRak()
        {
            bool valid = true;

            int i = 0;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_CekKodeRak"));

                db.Commands[0].Parameters.Add(new Parameter("@KodeRak", SqlDbType.VarChar, txtKodeRak.Text.Trim()));
                db.Commands[0].Parameters.Add(new Parameter("@kodeBarang", SqlDbType.VarChar, txtBarangID.Text));
                i = (Int32)db.Commands[0].ExecuteScalar();
            }
            valid = (i == 0) ? true : false;
            return valid;
        }
        private void frmMasterStokUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmMasterStokBrowse)
                {
                    frmMasterStokBrowse frmCaller = (frmMasterStokBrowse)this.Caller;
                    frmCaller.RefreshRowDataStok(txtBarangID.Text);
                    frmCaller.FindRow("BarangID", txtBarangID.Text);
                }
            }
        }

        private void txtPrediksiLamaKirim_Validated(object sender, EventArgs e)
        {
            if (txtPrediksiLamaKirim.Text.Trim()=="")
            {
                txtPrediksiLamaKirim.Text = "0";
            }
        }

        private void txtHariRataRata_Validated(object sender, EventArgs e)
        {
            if (txtHariRataRata.Text.Trim() == "")
            {
                txtHariRataRata.Text = "0";
            }
        }

        private void txtBarangID_Validating(object sender, CancelEventArgs e)
        {
            if (GlobalVar.Gudang.ToString().Trim().Substring(0, 2) == "28")
            {
                if (txtBarangID.Text.ToString().Trim().Length != 12)
                {
                    MessageBox.Show("Kode Barang harus 12 Character");
                    txtBarangID.Focus();
                    return;
                }
            }
        }
        
    }
}
