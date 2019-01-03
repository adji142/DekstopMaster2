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
    public partial class frmPemasokUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;
        Guid RowID;
        DataTable dt;
        
        public frmPemasokUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmPemasokUpdate(Form caller, string rowID, Guid _RowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            RowID = _RowID;
            _rowID  = rowID;
            this.Caller = caller;
        }

        private void frmPemasokUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.Update)
            {
                //retrieving data
                try
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Open();
                        db.Commands.Add(db.CreateCommand("usp_Pemasok_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@pemasokID", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        db.Close();
                        db.Dispose();
                    }
                    //display data
                    txtPemasokID.Enabled = false;
                    txtPemasokID.Text = Tools.isNull(dt.Rows[0]["PemasokID"], "").ToString();
                    txtNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    txtLengkap.Text = Tools.isNull(dt.Rows[0]["Lengkap"], "").ToString();
                    txtAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    txtKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                    txtTelp.Text = Tools.isNull(dt.Rows[0]["Telp"], "").ToString();
                    txtFax.Text = Tools.isNull(dt.Rows[0]["Fax"], "").ToString();
                    txtKontrak.Text = Tools.isNull(dt.Rows[0]["Kontak"], "").ToString();
                    txtKeterangan.Text = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();
                    txtSalesman.Text = Tools.isNull(dt.Rows[0]["Salesman"], "").ToString();
                    txtHPSelesman.Text = Tools.isNull(dt.Rows[0]["HPSalesman"], "").ToString();
                    txtEmailOrder.Text = Tools.isNull(dt.Rows[0]["EmailOrder"], "").ToString();
                    if (dt.Rows[0]["StatusAktif"].ToString() == "True") { rbAktif.Checked = true; } else { rbPasif.Checked = true; }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtPemasokID.Text))
            //{
            //    MessageBox.Show("Kode belum diisi");
            //    txtPemasokID.Focus();
            //    return;
            //}

            if (string.IsNullOrEmpty(txtNama.Text))
            {
                MessageBox.Show("Nama belum diisi");
                txtNama.Focus();
                return;
            }

            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        try
                        {

                            using (Database db = new Database())
                            {
                                db.Open();

                                DataTable dtMessage = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Pemasok_INSERT"));

                                db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Lengkap", SqlDbType.VarChar, txtLengkap.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, txtKota.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Telp", SqlDbType.VarChar, txtTelp.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Fax", SqlDbType.VarChar, txtFax.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kontak", SqlDbType.VarChar, txtKontrak.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Salesman", SqlDbType.VarChar, txtSalesman.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@HPSalesman", SqlDbType.VarChar, txtHPSelesman.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@EmailOrder", SqlDbType.Char, txtEmailOrder.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, rbAktif.Checked==true ? 1:0));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                dtMessage = db.Commands[0].ExecuteDataTable();

                                db.Close();
                                db.Dispose();

                                if (dtMessage.Rows.Count > 0)
                                {
                                    if (dtMessage.Rows[0]["pesan"].ToString() == "Insert Berhasil")
                                    {
                                        this.DialogResult = DialogResult.OK;
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
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }

                        break;
                    case enumFormMode.Update:
                        try
                        {

                            using (Database db = new Database())
                            {
                                if (Tools.cekDuplikasiDataOnDatabase("Pemasok", "Nama", txtNama.Text, "PemasokID", txtPemasokID.Text))
                                {
                                    MessageBox.Show("Pemasok Dengan Nama " + txtNama.Text + " Sudah Ada !!");
                                    txtNama.Focus();
                                    return;
                                }
                                db.Open();

                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Pemasok_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                                db.Commands[0].Parameters.Add(new Parameter("@PemasokID", SqlDbType.VarChar, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Lengkap", SqlDbType.VarChar, txtLengkap.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, txtKota.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Telp", SqlDbType.VarChar, txtTelp.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Fax", SqlDbType.VarChar, txtFax.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kontak", SqlDbType.VarChar, txtKontrak.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Salesman", SqlDbType.VarChar, txtSalesman.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@HPSalesman", SqlDbType.VarChar, txtHPSelesman.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@EmailOrder", SqlDbType.Char, txtEmailOrder.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, rbAktif.Checked == true ? 1 : 0));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();

                                db.Close();
                                db.Dispose();
                                this.DialogResult = DialogResult.OK;
                                frmPemasokBrowse frmCaller = (frmPemasokBrowse)this.Caller;
                                frmCaller.RefreshData();
                                this.Close();
                                frmCaller.Show();
                            }
                        }

                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                        break;
                }
               
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPemasokUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmPemasokBrowse)
                {
                    frmPemasokBrowse frmCaller = (frmPemasokBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("PemasokID", txtPemasokID.Text);
                }
            }
        }

        private void commonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

       

      
       

    }
}
