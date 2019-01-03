using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.PJTools
{
    public partial class frmKelompokBarangUpdate : ISA.Finance.BaseForm
    {

        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;

        DataTable dt;



        public frmKelompokBarangUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmKelompokBarangUpdate(Form caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;
        }

        private void frmKelompokBarangUpdate_Load(object sender, EventArgs e)
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
                        db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@KelompokBrgID", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtKelompokBrgID.Text = Tools.isNull(dt.Rows[0]["KelompokBrgID"], "").ToString();                    
                    txtKeterangan.Text = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();
                    txtKelompok.Text = Tools.isNull(dt.Rows[0]["Kelompok"], "").ToString();
                    txtNoPerk.Text = Tools.isNull(dt.Rows[0]["NoPerk"], "").ToString();
                    txtNopRj.Text = Tools.isNull(dt.Rows[0]["NopRj"], "").ToString();
                    txtNopStk.Text = Tools.isNull(dt.Rows[0]["NopStk"], "").ToString();
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKelompokBrgID.Text))
            {
                MessageBox.Show("Kode belum diisi");
                txtKelompokBrgID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtKeterangan.Text))
            {
                MessageBox.Show("Keterangan belum diisi");
                txtKeterangan.Focus();
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
                            db.Commands.Add(db.CreateCommand("usp_KelompokBarang_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@KelompokBrgID", SqlDbType.VarChar, txtKelompokBrgID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Kelompok", SqlDbType.VarChar, txtKelompok.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@MainAcc", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@SubAcc", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerk", SqlDbType.VarChar, txtNoPerk.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NopRj", SqlDbType.VarChar, txtNopRj.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NopStk", SqlDbType.VarChar, txtNopStk.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_KelompokBarang_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@KelompokBrgID", SqlDbType.VarChar, txtKelompokBrgID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Kelompok", SqlDbType.VarChar, txtKelompok.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@MainAcc", SqlDbType.VarChar, dt.Rows[0]["MainAcc"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@SubAcc", SqlDbType.VarChar, dt.Rows[0]["SubAcc"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerk", SqlDbType.VarChar, txtNoPerk.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NopRj", SqlDbType.VarChar, txtNopRj.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NopStk", SqlDbType.VarChar, txtNopStk.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID)); 
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                MessageBox.Show(Messages.Confirm.UpdateSuccess);
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmKelompokBarangBrowse)
                {
                    frmKelompokBarangBrowse frmCaller = (frmKelompokBarangBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("cKelompokBrgID", txtKelompokBrgID.Text);
                }
            }
            //this.Close();
        }
    }
}
