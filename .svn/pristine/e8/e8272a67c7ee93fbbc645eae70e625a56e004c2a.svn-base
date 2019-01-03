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
    public partial class frmSecurityPartsUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;
        string _appID;

        DataTable dt;

        public frmSecurityPartsUpdate(Form caller, string appID)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
            _appID = appID;
        }

        public frmSecurityPartsUpdate(Form caller, string rowID, string appID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;
            _appID = appID;
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
                            db.Commands.Add(db.CreateCommand("usp_SecurityParts_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@PartID", SqlDbType.VarChar, txtPartID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, _appID));
                            db.Commands[0].Parameters.Add(new Parameter("@PartName", SqlDbType.VarChar, txtPartName.Text));                           
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_SecurityParts_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@PartID", SqlDbType.VarChar, txtPartID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, _appID));
                            db.Commands[0].Parameters.Add(new Parameter("@PartName", SqlDbType.VarChar, txtPartName.Text));                           
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

        private void frmSecurityPartsUpdate_Load(object sender, EventArgs e)
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
                        db.Commands.Add(db.CreateCommand("usp_SecurityParts_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@partID", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtPartID.Text = Tools.isNull(dt.Rows[0]["PartID"], "").ToString();
                    txtPartName.Text = Tools.isNull(dt.Rows[0]["PartName"], "").ToString();                }
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

        private void frmSecurityPartsUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmSecurityPartsBrowse)
                {
                    frmSecurityPartsBrowse frmCaller = (frmSecurityPartsBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("PartID", txtPartID.Text);
                }
            }
        }
    }
}
