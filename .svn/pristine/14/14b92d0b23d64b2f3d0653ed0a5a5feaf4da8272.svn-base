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
    public partial class frmKodePosUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;

        DataTable dt;

        public frmKodePosUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmKodePosUpdate(Form caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmKodePosUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_KodePos_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@kodePos", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtKodePos.Text = Tools.isNull(dt.Rows[0]["KodePos"], "").ToString();
                    txtWilayah.Text = Tools.isNull(dt.Rows[0]["Wilayah"], "").ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKodePos.Text))
            {
                MessageBox.Show("Kode pos belum diisi");
                txtKodePos.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtWilayah.Text))
            {
                MessageBox.Show("Wilayah belum diisi");
                txtWilayah.Focus();
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
                            db.Commands.Add(db.CreateCommand("usp_KodePos_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@kodePos", SqlDbType.VarChar, txtKodePos.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@wilayah", SqlDbType.VarChar, txtWilayah.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt=db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Kode Pos: " + txtKodePos.Text + " sudah terdaftar");
                                txtKodePos.Text = string.Empty;
                                txtKodePos.Focus();
                                return;
                            }

                            txtKodePos.Text = string.Empty;
                            txtWilayah.Text = string.Empty;

                            txtKodePos.Focus();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_KodePos_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@kodePosAwal", SqlDbType.VarChar, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@kodePos", SqlDbType.VarChar, txtKodePos.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@wilayah", SqlDbType.VarChar, txtWilayah.Text));
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

        private void frmKodePosUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();   
        }

        private void CloseForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmKodePosBrowse)
                {
                    frmKodePosBrowse frmCaller = (frmKodePosBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("KodePos", txtKodePos.Text);
                }
            }
        }


       
    }
}
