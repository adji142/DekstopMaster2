using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Collections;

namespace ISA.Toko.Master
{
    public partial class frmMasterStokUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;

        DataTable dt, TransactTypeTable, TableJenisBarang;

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

        private void getTempo(String Rowid) {
            foreach (DataRow row in TransactTypeTable.Rows)
            {
                if (row["RowID"].ToString() == Rowid)
                {
                    LblTempo.Text = "Tempo       : "+ row["jw"].ToString();
                }
            }
        
        }

        private void fillComboBoxTransactionType() {

            try
            {

                //retrieving data

               // dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_TransactionType_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@Aktif", SqlDbType.Bit, true));
                    TransactTypeTable = db.Commands[0].ExecuteDataTable();
                }

                //display data
                cbTransactionType.DataSource = TransactTypeTable;
                cbTransactionType.DisplayMember = "keterangan";
                cbTransactionType.ValueMember = "RowID";
                

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void fillComboBoxJenisBarangType()
        {

            try
            {

                //retrieving data

                // dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_JenisBarang_list]"));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, true));
                    TableJenisBarang = db.Commands[0].ExecuteDataTable();
                }

                //display data
                cbJenisBarang.DataSource = TableJenisBarang;
              cbJenisBarang.DisplayMember = "Jenis";
              cbJenisBarang.ValueMember = "RowID";


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmMasterStokUpdate_Load(object sender, EventArgs e)
        {   
            try
            {
                fillComboBoxJenisBarangType();
                fillComboBoxTransactionType();
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
                    txtNamaStok.Text = Tools.isNull(dt.Rows[0]["NamaStok"], "").ToString();
                    txtNamaStok.Enabled = true;
                    txtSebutanBengkel.Enabled = true;
                    txtKodeRak.Text = Tools.isNull(dt.Rows[0]["KodeRak"], "").ToString();
                    txtKodeRak1.Text = Tools.isNull(dt.Rows[0]["KodeRak1"], "").ToString();
                    txtKodeRak2.Text = Tools.isNull(dt.Rows[0]["KodeRak2"], "").ToString();
                    txtSatJual.Text = Tools.isNull(dt.Rows[0]["SatJual"], "").ToString();
                    txtSatJual.Enabled = true;
                    txtSatSolo.Text = Tools.isNull(dt.Rows[0]["SatSolo"], "").ToString();
                    txtSatSolo.Enabled = true;
                    
                    RBPasif.Checked = (!(bool)dt.Rows[0]["StatusAktif"]);
                    txtPrediksiLamaKirim.Text = Tools.isNull(dt.Rows[0]["PrediksiLamaKirim"], "").ToString();
                    txtHariRataRata.Text = Tools.isNull(dt.Rows[0]["HariRataRata"], "").ToString();
                    RBOSLOW.Checked = Tools.isNull(dt.Rows[0]["Bundle"], "").ToString() == "SM" ? true : false;
                    txtKendaraan.Text = Tools.isNull(dt.Rows[0]["Kendaraan"], "").ToString();
                    txtKendaraan.Enabled = true;
                    txtSuplier.Text = Tools.isNull(dt.Rows[0]["Suplier"], "").ToString();
                    txtSebutanBengkel.Text = Tools.isNull(dt.Rows[0]["NamaSebutanBengkel"], "").ToString();
                    cbTransactionType.SelectedValue = Tools.isNull(dt.Rows[0]["TransactionTypeRowID"], "").ToString();
                    txtCatatan.Text = Tools.isNull(dt.Rows[0]["Catatan"], "").ToString();
                    txtAtribute.Text = Tools.isNull(dt.Rows[0]["Attribute"], "").ToString();
                    cbJenisBarang.SelectedValue  = Tools.isNull(dt.Rows[0]["jenisbarangid"], "").ToString();
                    
                    
                    //if (Tools.isNull(dt.Rows[0]["KodeSolo"], "").ToString() == "FXT")
                    //{
                    //    //txtSatJual.Enabled = false;
                    //    //txtSatSolo.Enabled = false;
                    //    txtNamaStok.Enabled = true;
                    //}

                }
                else
                {
                    //txtTglIsi.DateValue = DateTime.Now;
                    //txtTglUpdate.DateValue = DateTime.Now;
                    RBAktif.Checked = true;
                }
                getTempo(cbTransactionType.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
           

            if (string.IsNullOrEmpty(txtNamaStok.Text))
            {
                MessageBox.Show("Nama stok belum diisi");
                txtNamaStok.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtSebutanBengkel.Text))
            {
                MessageBox.Show("Nama Sebutan Bengkel belum diisi");
                txtNamaStok.Focus();
                return;
            }
            //if (txtKodeRak.Text.Trim() != "")
            //{
            //    if (!KodeRak())
            //    {
            //        errorProvider1.SetError(txtKodeRak, "KodeRak Sudah Ada");
            //        txtKodeRak.Focus();
            //        return;
            //    }
            //}
           
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
                                DataTable dtMessage = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Stok_INSERT"));

                                _rowID = Guid.NewGuid();

                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtNamaStok.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeRak", SqlDbType.VarChar, txtKodeRak.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeRak1", SqlDbType.VarChar, txtKodeRak1.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeRak2", SqlDbType.VarChar, txtKodeRak2.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@satJual", SqlDbType.VarChar, txtSatJual.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@satSolo", SqlDbType.VarChar, txtSatSolo.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, RBAktif.Checked));
                                db.Commands[0].Parameters.Add(new Parameter("@prediksiLamaKirim", SqlDbType.Int, _prediksiLamaKirim));
                                db.Commands[0].Parameters.Add(new Parameter("@hariRataRata", SqlDbType.Int, _hariRataRata));
                                db.Commands[0].Parameters.Add(new Parameter("@bundle", SqlDbType.VarChar, RBOSLOW.Checked == true ? "SM" : "FM"));
                                db.Commands[0].Parameters.Add(new Parameter("@kendaraan", SqlDbType.VarChar, txtKendaraan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@Suplier", SqlDbType.VarChar, txtSuplier.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@NamaSebutanBengkel", SqlDbType.VarChar, txtSebutanBengkel.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@TransactionTypeRowID", SqlDbType.UniqueIdentifier, new Guid(cbTransactionType.SelectedValue.ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, txtCatatan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Attribute", SqlDbType.VarChar, txtAtribute.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@JenisBarangID", SqlDbType.UniqueIdentifier, new Guid(cbJenisBarang.SelectedValue.ToString())));
                                dtMessage = db.Commands[0].ExecuteDataTable();
                                db.Close();
                                db.Dispose();

                                if (dtMessage.Rows.Count > 0)
                                {
                                    MessageBox.Show(dtMessage.Rows[0]["pesan"].ToString());
                                    char[] delimiterChars = {':',','};

                                    string text = dtMessage.Rows[0]["pesan"].ToString();

                                    string[] words = text.Split(delimiterChars);
                                    errorProvider1.Clear();
                                    if (words[0] == "Maaf Terdapat Duplikasi Data ")
                                    {
                                        foreach (string s in words)
                                        { 
                                            if (s == " Nama Stok")
                                           {
                                               errorProvider1.SetError(txtNamaStok, s +" Sudah Ada");
                                               txtNamaStok.Focus();
                                           }
                                            else if (s == "  Nama Sebutan Bengkel")
                                            {
                                                errorProvider1.SetError(txtSebutanBengkel,s+" Sudah Ada");
                                                txtSebutanBengkel.Focus();
                                            }
                                           
                                        }
                                    }
                                    else if (words[0] == "Insert Berhasil")
                                    {
                                        this.DialogResult = DialogResult.OK;
                                        CloseForm();
                                        this.Close();
                                    }
                                    else { return; }
                                    //if (dt.Rows[0]["pesan"].ToString() == "Data Sudah Ada")
                                    //{
                                    //    txtKode.Text = string.Empty;
                                    //    txtKode.Focus();
                                    //    return;
                                    //}
                                }
                            }
                            break;
                        case enumFormMode.Update:
                            using (Database db = new Database())
                            {
                                if (Tools.cekDuplikasiDataOnDatabase("Stok", "namaStok", txtNamaStok.Text, "barangID", txtBarangID.Text))
                                {
                                    MessageBox.Show("Stok Dengan Nama " + txtNamaStok.Text + " Sudah Ada !!");
                                    txtNamaStok.Focus();
                                    return;
                                }
                                if (Tools.cekDuplikasiDataOnDatabase("Stok", "NamaSebutanBengkel", txtSebutanBengkel.Text, "barangID", txtBarangID.Text))
                                {
                                    MessageBox.Show("Stok Dengan Nama Sebutan Bengkel " + txtSebutanBengkel.Text + " Sudah Ada !!");
                                    txtSebutanBengkel.Focus();
                                    return;
                                }
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
                                db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, RBAktif.Checked));
                                db.Commands[0].Parameters.Add(new Parameter("@prediksiLamaKirim", SqlDbType.Int, txtPrediksiLamaKirim.GetIntValue));
                                db.Commands[0].Parameters.Add(new Parameter("@hariRataRata", SqlDbType.Int, txtHariRataRata.GetIntValue));
                                db.Commands[0].Parameters.Add(new Parameter("@bundle", SqlDbType.VarChar, RBOSLOW.Checked == true ? "SM" : "FM"));
                                db.Commands[0].Parameters.Add(new Parameter("@kendaraan", SqlDbType.VarChar, txtKendaraan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@Suplier", SqlDbType.VarChar, txtSuplier.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@NamaSebutanBengkel", SqlDbType.VarChar, txtSebutanBengkel.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@TransactionTypeRowID", SqlDbType.UniqueIdentifier, new Guid(cbTransactionType.SelectedValue.ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, txtCatatan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Attribute", SqlDbType.VarChar, txtAtribute.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@JenisBarangID", SqlDbType.UniqueIdentifier, new Guid(cbJenisBarang.SelectedValue.ToString())));
                                db.Commands[0].ExecuteNonQuery();
                                MessageBox.Show("Update Berhasil");
                                this.DialogResult = DialogResult.OK;
                                CloseForm();
                                this.Close();
                            }
                            break;
                    }
                    //this.DialogResult = DialogResult.OK;
                    //CloseForm();
                    //this.Close();
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
                    frmCaller.RefreshData();
                    frmCaller.FindRow("RowID", _rowID.ToString());
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTempo(cbTransactionType.SelectedValue.ToString());
        }

        private void txtSuplier_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void cboBundle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkStatusAktif_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtHariRataRata_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPrediksiLamaKirim_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKendaraan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtSatSolo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSatJual_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKodeRak_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtKodeRak1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtKodeRak2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtSebutanBengkel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBarangID_TextChanged(object sender, EventArgs e)
        {

        }

        private void commonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        
    }
}
