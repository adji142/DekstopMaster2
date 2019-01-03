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
    public partial class frmExpedisiUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;

        DataTable dt;

        public frmExpedisiUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmExpedisiUpdate(Form caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;
        }

        private void frmExpedisiUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Open();
                        db.Commands.Add(db.CreateCommand("usp_Expedisi_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@kodeExpedisi", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        db.Close();
                        db.Dispose();
                    }

                    //display data

                    txtKodeExpedisi.Text = Tools.isNull(dt.Rows[0]["KodeExpedisi"], "").ToString();
                    txtKodeExpedisi.Enabled = false;
                    txtNamaExpedisi.Text = Tools.isNull(dt.Rows[0]["NamaExpedisi"], "").ToString();
                    tbNoTelp.Text = Tools.isNull(dt.Rows[0]["Telp"], "").ToString();
                    txtAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    txtKotaTujuan.Text = Tools.isNull(dt.Rows[0]["KotaTujuan"], "").ToString();
                    RBPasif.Checked = !(bool)Tools.isNull(dt.Rows[0]["StatusAktif"], true);
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKodeExpedisi.Text))
            {
                MessageBox.Show("Kode Expedisi belum diisi");
                txtKodeExpedisi.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNamaExpedisi.Text))
            {
                MessageBox.Show("Nama Expedisi belum diisi");
                txtNamaExpedisi.Focus();
                return;
            }

            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Expedisi_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeExpedisi", SqlDbType.VarChar, txtKodeExpedisi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@namaExpedisi", SqlDbType.VarChar, txtNamaExpedisi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kotaTujuan", SqlDbType.VarChar, txtKotaTujuan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoTelp", SqlDbType.VarChar, tbNoTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, RBAktif.Checked));
                            
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 1)
                            {
                                MessageBox.Show("Kode Expedisi: " + txtKodeExpedisi.Text + " sudah terdaftar di database");
                                txtKodeExpedisi.Text = string.Empty;
                                txtKodeExpedisi.Focus();
                                return;
                            } else if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Nama Expedisi: " + txtKodeExpedisi.Text + " sudah terdaftar di database");
                                txtNamaExpedisi.Text = string.Empty;
                                txtNamaExpedisi.Focus();
                                return;
                            }
                        }
                        break;
                    case enumFormMode.Update:
                        if (Tools.cekDuplikasiDataOnDatabase("Expedisi", "NamaExpedisi", txtNamaExpedisi.Text, "KodeExpedisi",txtKodeExpedisi.Text))
                        {
                            MessageBox.Show("Expedisi Dengan Nama " + txtNamaExpedisi.Text + " Sudah Ada !!");
                            txtNamaExpedisi.Focus();
                            return;
                        }
                        
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Expedisi_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeExpedisi", SqlDbType.VarChar, txtKodeExpedisi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@namaExpedisi", SqlDbType.VarChar, txtNamaExpedisi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kotaTujuan", SqlDbType.VarChar, txtKotaTujuan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoTelp", SqlDbType.VarChar, tbNoTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, RBAktif.Checked));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                
                this.DialogResult = DialogResult.OK;
                FormClose();
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmExpedisiUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClose();
        }
        private void FormClose()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmExpedisiBrowse)
                {
                    frmExpedisiBrowse frmCaller = (frmExpedisiBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("KodeExpedisi", txtKodeExpedisi.Text);
                }
            }
        }

    }
}
