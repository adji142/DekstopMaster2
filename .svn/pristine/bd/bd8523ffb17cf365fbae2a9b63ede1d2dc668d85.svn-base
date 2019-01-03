using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmTokoUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string _Noid, docNo = "NUMERATOR_IDTOKO", depan, belakang;
        int iNomor, lebar;
        DataTable dt;

        public frmTokoUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
            //generateNumerator();
            
        }

        public void generateNumerator(){

            DataTable dtNum = Tools.GetGeneralNumerator(docNo);
            lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
            iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
            depan = dtNum.Rows[0]["Depan"].ToString();
            belakang = dtNum.Rows[0]["Belakang"].ToString();
            iNomor++;

            _Noid = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
            txtIdtoko.Text = _Noid;
        }
        public frmTokoUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmTokoUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if (formMode == enumFormMode.Update)
                {

                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtIdtoko.Text = Tools.isNull(dt.Rows[0]["TokoID"], "").ToString();
                    RBPasif.Checked = (!(bool)dt.Rows[0]["StatusAktifBit"]);
                    txtNamaToko.Text = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
                    txtAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    txtDaerah.Text = Tools.isNull(dt.Rows[0]["Daerah"], "").ToString();
                    txtKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                    txtTelp.Text = Tools.isNull(dt.Rows[0]["Telp"], "").ToString();
                    txtHp.Text = Tools.isNull(dt.Rows[0]["HP"], "").ToString();
                    TxtNamaPemilik.Text = Tools.isNull(dt.Rows[0]["nama_pemilik"], "").ToString();
                    TxtEmail.Text = Tools.isNull(dt.Rows[0]["email"], "").ToString();
                    txtPenanggungJawab.Text = Tools.isNull(dt.Rows[0]["PenanggungJawab"], "").ToString();
                    txtCatatan.Text = Tools.isNull(dt.Rows[0]["Catatan"], "").ToString();
                }
                else { txtIdtoko.Visible = false;
                Idtoko.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                double _plafon = 0;
                if (txtPlafon.Text != "")
                    _plafon = double.Parse(txtPlafon.Text);
                
                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database())
                        {
                            DataTable dtMessage = new DataTable();
                            db.Commands.Add(db.CreateCommand("[usp_Toko_INSERT]"));
                            _rowID = Guid.NewGuid();
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, txtNamaToko.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@telp", SqlDbType.VarChar, txtTelp.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@HP", SqlDbType.VarChar, txtHp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@email", SqlDbType.VarChar, TxtEmail.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nama_pemilik", SqlDbType.VarChar, TxtNamaPemilik.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@penanggungJawab", SqlDbType.VarChar, txtPenanggungJawab.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, RBAktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            
                           
                            dtMessage = db.Commands[0].ExecuteDataTable();
                            
                            db.Close();
                            db.Dispose();

                            if (dtMessage.Rows.Count > 0)
                            {
                                if (dtMessage.Rows[0]["pesan"].ToString() == "Insert Berhasil")
                                {
                                    this.DialogResult = DialogResult.OK;
                                    CloseForm();
                                    this.Close();
                                }
                                else { MessageBox.Show(dtMessage.Rows[0]["pesan"].ToString()); return; }
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
                            if (Tools.cekDuplikasiDataOnDatabase("Toko", "NamaToko", txtNamaToko.Text, "TokoID", txtIdtoko.Text))
                            {
                                MessageBox.Show("Toko Dengan Nama " + txtNamaToko.Text + " Sudah Ada !!");
                                txtNamaToko.Focus();
                                return;
                            }
                            db.Commands.Add(db.CreateCommand("[usp_Toko_UPDATE]"));
                            DataTable dt = new DataTable();
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, txtNamaToko.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@telp", SqlDbType.VarChar, txtTelp.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@HP", SqlDbType.VarChar, txtHp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@email", SqlDbType.VarChar, TxtEmail.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nama_pemilik", SqlDbType.VarChar, TxtNamaPemilik.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@penanggungJawab", SqlDbType.VarChar, txtPenanggungJawab.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, RBAktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            db.CommitTransaction();
                            this.DialogResult = DialogResult.OK;
                            CloseForm();
                            this.Close();
                        }
                        break;
                }
                
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private bool ValidateInput()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (txtNamaToko.Text == "")

            {
                errorProvider1.SetError(txtNamaToko, Messages.Error.InputRequired);
                valid = false;
            }
            if (txtAlamat.Text == "")
            {
                errorProvider1.SetError(txtAlamat, Messages.Error.InputRequired);
                valid = false;
            }

            if (txtDaerah.Text == "")
            {
                errorProvider1.SetError(txtDaerah, Messages.Error.InputRequired);
                valid = false;
            }

            if (txtKota.Text == "")
            {
                errorProvider1.SetError(txtKota, Messages.Error.InputRequired);
                valid = false;
            }

            if (txtPenanggungJawab.Text == "")
            {
                errorProvider1.SetError(txtPenanggungJawab, Messages.Error.InputRequired);
                valid = false;
            }

            return valid;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTokoUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmTokoBrowse)
                {
                    frmTokoBrowse frmCaller = (frmTokoBrowse)this.Caller;
                    frmCaller.RefreshDataToko();
                    frmCaller.FindRow("RowID", _rowID.ToString());
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void commonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void commonTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void commonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAlamat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPenanggungJawab_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtKota_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDaerah_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void commonTextBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void commonTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void commonTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
