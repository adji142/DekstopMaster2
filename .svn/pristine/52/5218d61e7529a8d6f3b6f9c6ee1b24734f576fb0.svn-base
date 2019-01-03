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
    public partial class frmStandarServiceUpdate : ISA.Bengkel.BaseForm
    {
        FormTools.enumFormMode formMode;
        Guid _rowID;
        

        DataTable dt;

        public frmStandarServiceUpdate(Form caller)
        {
            InitializeComponent();
            formMode = FormTools.enumFormMode.New;
            this.Caller = caller;
        }

        public frmStandarServiceUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = FormTools.enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;            
        }

        private void frmStandarServiceUpdate_Load(object sender, EventArgs e)
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
                            db.Commands.Add(db.CreateCommand("usp_bkl_hpoint_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                    }

                    //display data
                    txtKode.Text = Tools.isNull(dt.Rows[0]["kode"], "").ToString();
                    txtKode.Enabled = false;
                    txtKategori.Text = Tools.isNull(dt.Rows[0]["kategori"], "").ToString();
                    lkpSepedaMotor.KodeSepedaMotor = Tools.isNull(dt.Rows[0]["kd_spm"], "").ToString();
                    lkpSepedaMotor.NamaSepedaMotor = Tools.isNull(dt.Rows[0]["jns_spm"], "").ToString();
                    txtBiaya.Text = Tools.isNull(dt.Rows[0]["biaya"], "").ToString();
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
                            db.Commands.Add(db.CreateCommand("usp_bkl_hpoint_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, txtKode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, txtKategori.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@biaya", SqlDbType.Decimal, txtBiaya.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_spm", SqlDbType.VarChar, lkpSepedaMotor.KodeSepedaMotor));
                            db.Commands[0].Parameters.Add(new Parameter("@jns_spm", SqlDbType.VarChar, lkpSepedaMotor.NamaSepedaMotor));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));                            
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("StandarService ID: " + txtKode.Text + " Sudah terdaftar di database");
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
                            db.Commands.Add(db.CreateCommand("usp_bkl_hpoint_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@biaya", SqlDbType.Decimal, txtBiaya.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_spm", SqlDbType.VarChar, lkpSepedaMotor.KodeSepedaMotor));
                            db.Commands[0].Parameters.Add(new Parameter("@jns_spm", SqlDbType.VarChar, lkpSepedaMotor.NamaSepedaMotor));
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

            if (FormTools.IsBlank(txtKategori))
            {
                valid = false;
                goto finish;
            }

            if (FormTools.IsDataExist("usp_bkl_hpoint_LIST", "@kode", SqlDbType.VarChar, txtKode.Text))
            {
                valid = false;               
                goto finish;
            }


            finish:
            return valid;
        }

       

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStandarServiceUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForm();
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmStandarServiceBrowse)
                {
                    frmStandarServiceBrowse frmCaller = (frmStandarServiceBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("kode", txtKode.Text);
                }
            }
            //this.Close();
        }
    }
}
