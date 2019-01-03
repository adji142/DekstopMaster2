using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Administrasi
{
    public partial class frmSecurityApplicationsUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;

        DataTable dt;

        public frmSecurityApplicationsUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmSecurityApplicationsUpdate(Form caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;
        }


        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case enumFormMode.New:

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_SecurityApplications_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, txtApplicationID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@applicationName", SqlDbType.VarChar, txtApplicationName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_SecurityApplications_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, txtApplicationID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@applicationName", SqlDbType.VarChar, txtApplicationName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                MessageBox.Show("Data telah tersimpan");
                this.DialogResult = DialogResult.OK;
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

        private void frmSecurityApplicationsUpdate_Load(object sender, EventArgs e)
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
                        db.Commands.Add(db.CreateCommand("usp_SecurityApplications_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar,_rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtApplicationID.Text = Tools.isNull(dt.Rows[0]["ApplicationID"], "").ToString();
                    txtApplicationName.Text = Tools.isNull(dt.Rows[0]["ApplicationName"], "").ToString();
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

        private void frmSecurityApplicationsUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmSecurityApplicationsBrowse)
                {
                    frmSecurityApplicationsBrowse frmCaller = (frmSecurityApplicationsBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("ApplicationID", txtApplicationID.Text);
                }
            }
        }
    }
}
