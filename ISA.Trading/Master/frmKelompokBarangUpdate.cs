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
    public partial class frmKelompokBarangUpdate : ISA.Trading.BaseForm
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
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Open();
                        db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@kelompokBrgID", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        db.Close();
                        db.Dispose();
                    }

                    //display data



                    txtKelompokBrgID.Text = Tools.isNull(dt.Rows[0]["KelompokBrgID"], "").ToString();
                    txtKelompokBrgID.Enabled = false;
                    txtKeterangan.Text = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();
                    txtKelompok.Text = Tools.isNull(dt.Rows[0]["Kelompok"], "").ToString();
                    txtMainACC.Text = Tools.isNull(dt.Rows[0]["MainACC"], "").ToString();
                    txtSubACC.Text = Tools.isNull(dt.Rows[0]["SubACC"], "").ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void ClearForm()
        {
            txtKelompok.Text = string.Empty;
            txtKelompokBrgID.Text = string.Empty;
            txtKeterangan.Text = string.Empty;
            txtMainACC.Text = string.Empty;
            txtSubACC.Text = string.Empty;

            txtKelompokBrgID.Focus();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKelompokBrgID.Text))
            {
                MessageBox.Show("Kelompok barang id belum diisi");
                txtKelompokBrgID.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtKeterangan.Text))
            {
                MessageBox.Show("Keterangan belum diisi");
                txtKeterangan.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtKelompok.Text))
            {
                MessageBox.Show("Kelompok belum diisi");
                txtKelompok.Focus();
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
                            db.Commands.Add(db.CreateCommand("usp_KelompokBarang_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@kelompokBrgID", SqlDbType.VarChar, txtKelompokBrgID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, txtKelompok.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@mainACC", SqlDbType.VarChar, txtMainACC.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@subACC", SqlDbType.VarChar, txtSubACC.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Kelompok barang id: " + txtKelompokBrgID.Text + " sudah terdaftar di database");
                                txtKelompokBrgID.Text = string.Empty;
                                txtKelompokBrgID.Focus();
                                return;
                            }

                            ClearForm();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_KelompokBarang_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@kelompokBrgID", SqlDbType.VarChar, txtKelompokBrgID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, txtKelompok.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@mainACC", SqlDbType.VarChar, txtMainACC.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@subACC", SqlDbType.VarChar, txtSubACC.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                this.DialogResult = DialogResult.OK;
                CloseForm();
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

        private void frmKelompokBarangUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();   
        }

        private void CloseForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                frmKelompokBarangBrowse frmCaller = (frmKelompokBarangBrowse)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow("KelompokBrgID", txtKelompokBrgID.Text);
            }
        }
    }
}
