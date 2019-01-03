using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Trading.Master
{
    public partial class frmPemasokUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;
        DataTable dt;
        
        public frmPemasokUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmPemasokUpdate(Form caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
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
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPemasokID.Text))
            {
                MessageBox.Show("Kode belum diisi");
                txtPemasokID.Focus();
                return;
            }

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

                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Pemasok_INSERT"));

                                db.Commands[0].Parameters.Add(new Parameter("@PemasokID", SqlDbType.VarChar, txtPemasokID.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Lengkap", SqlDbType.VarChar, txtLengkap.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, txtKota.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Telp", SqlDbType.VarChar, txtTelp.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Fax", SqlDbType.VarChar, txtFax.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kontak", SqlDbType.VarChar, txtKontrak.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                dt = db.Commands[0].ExecuteDataTable();

                                db.Close();
                                db.Dispose();

                                if (dt.Rows.Count > 0)
                                { 
                                    MessageBox.Show("Pemasok ID : " + txtPemasokID.Text + " sudah terdaftar di database");
                                    txtPemasokID.Text = string.Empty;
                                    txtPemasokID.Focus();
                                    return;
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
                                db.Open();

                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Pemasok_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@PemasokID", SqlDbType.VarChar, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Lengkap", SqlDbType.VarChar, txtLengkap.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, txtKota.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Telp", SqlDbType.VarChar, txtTelp.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Fax", SqlDbType.VarChar, txtFax.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kontak", SqlDbType.VarChar, txtKontrak.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();

                                db.Close();
                                db.Dispose();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                        break;
                }
                this.DialogResult = DialogResult.OK;
                frmPemasokBrowse frmCaller = (frmPemasokBrowse)this.Caller;
                frmCaller.RefreshData();
                this.Close();
                frmCaller.Show();
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

       

      
       

    }
}
