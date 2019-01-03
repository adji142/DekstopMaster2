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
    public partial class frmCustMemberUpdate : ISA.Bengkel.BaseForm
    {
        FormTools.enumFormMode formMode;
        Guid rowID, headerID;
        

        DataTable dt;

        public frmCustMemberUpdate(Form caller)
        {
            InitializeComponent();
            formMode = FormTools.enumFormMode.New;
            this.Caller = caller;
        }

        public frmCustMemberUpdate(Form caller, Guid _rowID)
        {
            InitializeComponent();
            formMode = FormTools.enumFormMode.Update;
            rowID  = _rowID;
            this.Caller = caller;            
        }

        public frmCustMemberUpdate(Form caller, Guid _rowID, FormTools.enumFormMode _formMode)
        {
            InitializeComponent();
            formMode = _formMode;
            if (formMode == FormTools.enumFormMode.Update)
            {
                rowID = _rowID;
            }
            else
            {
                headerID = _rowID;
            }
            this.Caller = caller;
        }

        private void frmCustMemberUpdate_Load(object sender, EventArgs e)
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
                            db.Commands.Add(db.CreateCommand("usp_bkl_mMemberService_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                    }

                    //display data
                    txtNomor.Text = Tools.isNull(dt.Rows[0]["id_member"], "").ToString();
                    txtNomor.Enabled = false;
                    txtKeterangan.Text = Tools.isNull(dt.Rows[0]["ket"], "").ToString();
                    txtIDBM.Text = Tools.isNull(dt.Rows[0]["idbm"], "").ToString();
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
                        rowID = Guid.NewGuid();
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_bkl_mMemberService_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@id_member", SqlDbType.VarChar, txtNomor.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@idbm", SqlDbType.VarChar, txtIDBM.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));                            
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Member ID: " + txtNomor.Text + " Sudah terdaftar di database");
                                txtNomor.Text = string.Empty;
                                txtNomor.Focus();
                                return;
                            }
                        }
                        break;
                    case FormTools.enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_bkl_mMemberService_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@id_member", SqlDbType.VarChar, txtNomor.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@idbm", SqlDbType.VarChar, txtIDBM.Text));
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

            if (FormTools.IsBlank(txtNomor))
            {
                valid = false;
                goto finish;
            }

            if (FormTools.IsBlank(txtKeterangan))
            {
                valid = false;
                goto finish;
            }

            if (formMode == FormTools.enumFormMode.New)
            {
                if (FormTools.IsDataExist("usp_bkl_mMemberService_LIST", "@id_member", SqlDbType.VarChar, txtNomor.Text))
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

        private void frmCustMemberUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForm();
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmCustomerBrowse)
                {
                    frmCustomerBrowse frmCaller = (frmCustomerBrowse)this.Caller;
                    frmCaller.RefreshData(FormTools.detailIndex.detail2);
                    //frmCaller.FindRow(FormTools.detailIndex.detail2, "id_member", txtNomor.Text);
                }
            }
            //this.Close();
        }
    }
}
