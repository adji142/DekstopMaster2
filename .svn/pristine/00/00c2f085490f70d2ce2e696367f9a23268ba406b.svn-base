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
    public partial class frmUserUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;

        DataTable dt;

        public frmUserUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmUserUpdate(Form caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmUserUpdate_Load(object sender, EventArgs e)
        {
            DataTable dtRoleApplication = new DataTable();
            DataTable dtRoleBusiness = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_RoleApplication_LIST"));
                    db.Commands.Add(db.CreateCommand("usp_RoleBusiness_LIST"));

                    dtRoleApplication = db.Commands[0].ExecuteDataTable();
                    dtRoleBusiness = db.Commands[1].ExecuteDataTable();
                }
                cboRoleApplication.DataSource = dtRoleApplication;
                cboRoleApplication.DisplayMember = "RoleID";
                cboRoleApplication.ValueMember = "RoleID";
                cboRoleBusiness.DataSource = dtRoleBusiness;
                cboRoleBusiness.DisplayMember = "RoleID";
                cboRoleBusiness.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }


            try
            {
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_User_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data

                    txtUserID.Text = Tools.isNull(dt.Rows[0]["UserID"], "").ToString();
                    txtUserID.ReadOnly = true;
                    txtUserName.Text = Tools.isNull(dt.Rows[0]["UserName"], "").ToString();
                    txtPassword.Text = Tools.isNull(dt.Rows[0]["Password"], "").ToString();
                    cboRoleApplication.SelectedItem = Tools.isNull(dt.Rows[0]["RoleApplicationID"], "").ToString();
                    cboRoleBusiness.SelectedItem = Tools.isNull(dt.Rows[0]["RoleBusinessID"], "").ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_User_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, txtUserID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@userName", SqlDbType.VarChar, txtUserName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@password", SqlDbType.VarChar, txtPassword.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@roleApplicationID", SqlDbType.VarChar, cboRoleApplication.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@roleBusinessID", SqlDbType.VarChar, cboRoleBusiness.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_User_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, txtUserID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@userName", SqlDbType.VarChar, txtUserName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@password", SqlDbType.VarChar, txtPassword.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@roleApplicationID", SqlDbType.VarChar, cboRoleApplication.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@roleBusinessID", SqlDbType.VarChar, cboRoleBusiness.SelectedValue.ToString()));
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
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                frmUserBrowse frmCaller = (frmUserBrowse)this.Caller;
                frmCaller.RefreshData();
            }
        }
    }
}
