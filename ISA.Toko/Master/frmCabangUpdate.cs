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
    public partial class frmCabangUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;

        DataTable dt;

        public frmCabangUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmCabangUpdate(Form caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;
        }

        private void frmCabangUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@cabangID", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtCabangID.Text = Tools.isNull(dt.Rows[0]["CabangID"], "").ToString();
                    txtCabangID.Enabled = false;
                    txtNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    txtTelModem.Text = Tools.isNull(dt.Rows[0]["TelModem"], "").ToString();
                    txtKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                    txtAlamat1.Text = Tools.isNull(dt.Rows[0]["Alamat1"], "").ToString();
                    txtAlamat2.Text = Tools.isNull(dt.Rows[0]["Alamat2"], "").ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCabangID.Text))
            {
                MessageBox.Show("Kode belum diisi");
                txtCabangID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNama.Text))
            {
                MessageBox.Show("Cabang belum diisi");
                txtNama.Focus();
                return;
            }
            
            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Cabang_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@cabangID", SqlDbType.VarChar, txtCabangID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@telModem", SqlDbType.VarChar, txtTelModem.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat1", SqlDbType.VarChar, txtAlamat1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat2", SqlDbType.VarChar, txtAlamat2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Cabang ID: " + txtCabangID.Text + " Sudah terdaftar di database");
                                txtCabangID.Text = string.Empty;
                                txtCabangID.Focus();
                                return;
                            }
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Cabang_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@cabangID", SqlDbType.VarChar, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@telModem", SqlDbType.VarChar, txtTelModem.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat1", SqlDbType.VarChar, txtAlamat1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat2", SqlDbType.VarChar, txtAlamat2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                this.DialogResult = DialogResult.OK;
                closeForm();
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCabangUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForm();
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmCabangBrowse)
                {
                    frmCabangBrowse frmCaller = (frmCabangBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("CabangID", txtCabangID.Text);
                }
            }
            //this.Close();
        }
    }
}
