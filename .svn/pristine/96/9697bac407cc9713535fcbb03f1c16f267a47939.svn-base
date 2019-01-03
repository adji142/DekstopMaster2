using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Trading.Administrasi
{
    public partial class frmSecurityRightsUpdate : ISA.Trading.BaseForm
    {

        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;

        DataTable dt;

        public frmSecurityRightsUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmSecurityRightsUpdate(Form caller, string rowID)
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
                            db.Commands.Add(db.CreateCommand("usp_SecurityRights_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RightID", SqlDbType.VarChar, txtRightID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, GlobalVar.ApplicationID));
                            db.Commands[0].Parameters.Add(new Parameter("@RightName", SqlDbType.VarChar, txtRightName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_SecurityRights_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RightID", SqlDbType.VarChar, txtRightID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, GlobalVar.ApplicationID));
                            db.Commands[0].Parameters.Add(new Parameter("@RightName", SqlDbType.VarChar, txtRightName.Text));
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

        private void frmSecurityRightsUpdate_Load(object sender, EventArgs e)
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
                        db.Commands.Add(db.CreateCommand("usp_SecurityRights_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RightID", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtRightID.Text = Tools.isNull(dt.Rows[0]["RightID"], "").ToString();
                    txtRightName.Text = Tools.isNull(dt.Rows[0]["RightName"], "").ToString();
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSecurityRightsUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmSecurityRightsBrowse)
                {
                    frmSecurityRightsBrowse frmCaller = (frmSecurityRightsBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("RightID", txtRightID.Text);
                }
            }
        }
    }
}
