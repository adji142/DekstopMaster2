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
    public partial class frmTujuanExpedisiUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;

        DataTable dt;

        public frmTujuanExpedisiUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmTujuanExpedisiUpdate(Form caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;
        }

        private void frmTujuanExpedisiUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_TujuanExpedisi_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@tujuan", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtTujuan.Text = Tools.isNull(dt.Rows[0]["Tujuan"], "").ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTujuan.Text))
            {

                MessageBox.Show("Tujuan belum diisi");
                txtTujuan.Focus();
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
                            db.Commands.Add(db.CreateCommand("usp_TujuanExpedisi_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@tujuan", SqlDbType.VarChar, txtTujuan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Tujuan: " + txtTujuan.Text + " sudah terdaftar di database");
                                txtTujuan.Text = string.Empty;
                                txtTujuan.Focus();
                                return;
                            }
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_TujuanExpedisi_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@tujuanAwal", SqlDbType.VarChar, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@tujuan", SqlDbType.VarChar, txtTujuan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
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

        private void frmTujuanExpedisiUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClose();
        }

        private void FormClose()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                frmTujuanExpedisiBrowse frmCaller = (frmTujuanExpedisiBrowse)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow("Tujuan", txtTujuan.Text);
            }
        }
    }
}
