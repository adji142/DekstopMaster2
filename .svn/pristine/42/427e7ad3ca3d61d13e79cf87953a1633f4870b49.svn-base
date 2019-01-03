using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Bengkel.Helper;
using ISA.Bengkel.Library;

namespace ISA.Bengkel.Master
{
    public partial class frmMekanikUpdate : ISA.Bengkel.BaseForm
    {
        FormTools.enumFormMode formMode;
        Guid _rowID;
        

        DataTable dt;

        public frmMekanikUpdate(Form caller)
        {
            InitializeComponent();
            formMode = FormTools.enumFormMode.New;
            this.Caller = caller;
        }

        public frmMekanikUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = FormTools.enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;            
        }

        private void frmMekanikUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (formMode == FormTools.enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {

                        if (formMode == FormTools.enumFormMode.Update)
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_mMekanikService_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                    }

                    //display data
                    txtKode.Text = Tools.isNull(dt.Rows[0]["kd_mk"], "").ToString();
                    txtKode.Enabled = false;
                    txtNama.Text = Tools.isNull(dt.Rows[0]["nama"], "").ToString();
                    txtJabatan.Text = Tools.isNull(dt.Rows[0]["jabatan"], "").ToString();
                    txtTelepon.Text = Tools.isNull(dt.Rows[0]["telpon"], "").ToString();
                    txtAlamat.Text = Tools.isNull(dt.Rows[0]["alamat"], "").ToString();
                    dtp1.Value = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["tgl_masuk"], "").ToString());
                    //dtp2.Value = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["tgl_keluar"], "").ToString());
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
            if (!ValidateInput())
            {
                return;
            }
            
            
            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case FormTools.enumFormMode.New:
                        _rowID = Guid.NewGuid();
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_bkl_mMekanikService_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_mk", SqlDbType.VarChar, txtKode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@telpon", SqlDbType.VarChar, txtTelepon.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tgl_masuk", SqlDbType.Date, dtp1.Value));
                            //db.Commands[0].Parameters.Add(new Parameter("@tgl_keluar", SqlDbType.Date, dtp2.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@jabatan", SqlDbType.VarChar, txtJabatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));                            
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Mekanik ID: " + txtKode.Text + " Sudah terdaftar di database");
                                txtKode.Text = string.Empty;
                                txtKode.Focus();
                                return;
                            }
                        }
                        break;
                    case FormTools.enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_bkl_mMekanikService_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_mk", SqlDbType.VarChar, txtKode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@telpon", SqlDbType.VarChar, txtTelepon.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tgl_masuk", SqlDbType.Date, dtp1.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@tgl_keluar", SqlDbType.Date, dtp2.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@jabatan", SqlDbType.VarChar, txtJabatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));
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

        private bool ValidateInput()
        {
            bool valid = true;


            if (FormTools.IsBlank(txtKode))
            {
                valid = false;
                goto finish;
            }

            if (FormTools.IsBlank(txtNama))
            {
                valid = false;
                goto finish;
            }

            if (formMode == FormTools.enumFormMode.New)
            {
                if (FormTools.IsDataExist("usp_Bkl_mMekanikService_LIST", "@kd_mk", SqlDbType.VarChar, txtKode.Text))
                {
                    valid = false;
                    goto finish;
                }
            }

            finish:
            return valid;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMekanikUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForm();
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmMekanikBrowse)
                {
                    frmMekanikBrowse frmCaller = (frmMekanikBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("kd_mk", txtKode.Text);
                }
            }
            //this.Close();
        }
    }
}
