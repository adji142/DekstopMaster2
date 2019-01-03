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
    public partial class frmKolektorUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { NEW, UPDATE };
        enumFormMode formMode;
        string _rowID;
        string collectorID;

        DataTable dt;

        public frmKolektorUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.NEW;
            this.Caller = caller;
        }

        public frmKolektorUpdate(Form caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.UPDATE ;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmKolektorUpdate_Load(object sender, EventArgs e)
        {
            cmdSave.Enabled = true;

            if (formMode == enumFormMode.UPDATE)
            {
                rbMurni.Checked = true;
                rbcs.Checked = false;
                try
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Collector_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    collectorID = Tools.isNull(dt.Rows[0]["CollectorID"], "").ToString();
                    txtKode.Text = Tools.isNull(dt.Rows[0]["Kode"], "").ToString();
                    txtNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //Error.LogError(ex);
                }

            }
        }

       

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKode.Text))
            {
                MessageBox.Show("Kode belum diisi");
                txtKode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNama.Text))
            {
                MessageBox.Show("Nama belum diisi");
                txtNama.Focus();
                return;
            }

            int ColMurni = 0;
            if (rbMurni.Checked)
                ColMurni = 1;
            else if (rbcs.Checked)
                ColMurni = 0;

            try
            {
                switch (formMode)
                {
                    case enumFormMode.NEW:

                        using (Database db = new Database())
                        {
                            collectorID = Tools.CreateFingerPrint();
                            db.Open();

                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Collector_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, collectorID));
                            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, txtKode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@barangC", SqlDbType.Int, ColMurni));
                            dt = db.Commands[0].ExecuteDataTable();

                            db.Close();
                            db.Dispose();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Kode : " + txtKode.Text + " sudah terdaftar");
                                txtKode.Text = string.Empty;
                                txtKode.Focus();
                                return;
                            }
                        }
                        break;
                    case enumFormMode.UPDATE:
                        using (Database db = new Database())
                        {
                            db.Open();

                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Collector_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, txtKode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@barangC", SqlDbType.Int, ColMurni));
                            db.Commands[0].ExecuteNonQuery();

                            db.Close();
                            db.Dispose();
                        }
                        break;
                }
                
                this.DialogResult = DialogResult.OK;
                CloseForm();
                this.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Error.LogError(ex);
            }
        }

        private void frmKolektorUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmKolektorBrowse)
                {
                    frmKolektorBrowse frmCaller = (frmKolektorBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("Kode", txtKode.Text);
                }
            }
        }

    }
}
