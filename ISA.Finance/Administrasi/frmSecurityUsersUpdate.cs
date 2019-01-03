using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.Administrasi
{
    public partial class frmSecurityUsersUpdate : ISA.Finance.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;

        DataTable dt;

        public frmSecurityUsersUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmSecurityUsersUpdate(Form caller, string rowID)
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
                            db.Commands.Add(db.CreateCommand("usp_SecurityUsers_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, txtUserID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@userName", SqlDbType.VarChar, txtUserName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@initial", SqlDbType.VarChar, txtInitial.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@password", SqlDbType.VarChar, SecurityManager.EncodePassword  (txtPassword.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@tglPassword", SqlDbType.DateTime, DateTime.Now.Date));
                            db.Commands[0].Parameters.Add(new Parameter("@active", SqlDbType.VarChar, chkActive.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_SecurityUsers_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, txtUserID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@userName", SqlDbType.VarChar, txtUserName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@initial", SqlDbType.VarChar, txtInitial.Text));
                            
                            if (dt.Rows[0]["Password"].ToString() != txtPassword.Text)
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@password", SqlDbType.VarChar, SecurityManager.EncodePassword ( txtPassword.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@tglPassword", SqlDbType.DateTime, DateTime.Now.Date));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@password", SqlDbType.VarChar, txtPassword.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@tglPassword", SqlDbType.DateTime, DateTime.Parse( dt.Rows[0]["TglPassword"].ToString())));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@active", SqlDbType.VarChar, chkActive.Checked));
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

        private void frmSecurityUsersUpdate_Load(object sender, EventArgs e)
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
                        db.Commands.Add(db.CreateCommand("usp_SecurityUsers_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtUserID.Text = Tools.isNull(dt.Rows[0]["UserID"], "").ToString();
                    txtUserName.Text = Tools.isNull(dt.Rows[0]["UserName"], "").ToString();
                    txtInitial.Text = Tools.isNull(dt.Rows[0]["Initial"], "").ToString();
                    txtPassword.Text = Tools.isNull(dt.Rows[0]["Password"], "").ToString();
                    chkActive.Checked = bool.Parse(dt.Rows[0]["Active"].ToString());
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

        private void frmSecurityUsersUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmSecurityUsersBrowse)
                {
                    frmSecurityUsersBrowse frmCaller = (frmSecurityUsersBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("UserID", txtUserID.Text);
                }
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
