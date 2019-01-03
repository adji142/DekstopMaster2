using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Trading;
using ISA.DAL;

namespace ISA.Trading.Administrasi
{
    public partial class frmSecurityRolesUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;

        DataTable dt;

        public frmSecurityRolesUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmSecurityRolesUpdate(Form caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;
        }


        private void frmSecurityRolesUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (cboRoleType.Items.Count > 0)
                {
                    cboRoleType.SelectedIndex = 0;
                }


                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_SecurityRoles_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RoleID", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtRoleID.Text = Tools.isNull(dt.Rows[0]["RoleID"], "").ToString();
                    txtRoleName.Text = Tools.isNull(dt.Rows[0]["RoleName"], "").ToString();
                    cboRoleType.Text = Tools.isNull(dt.Rows[0]["RoleType"], "").ToString();
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
                            db.Commands.Add(db.CreateCommand("usp_SecurityRoles_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RoleID", SqlDbType.VarChar, txtRoleID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, GlobalVar.ApplicationID));
                            db.Commands[0].Parameters.Add(new Parameter("@RoleName", SqlDbType.VarChar, txtRoleName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RoleType", SqlDbType.VarChar, cboRoleType.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {                           
                            db.Commands.Add(db.CreateCommand("usp_SecurityRoles_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RoleID", SqlDbType.VarChar, txtRoleID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, GlobalVar.ApplicationID));
                            db.Commands[0].Parameters.Add(new Parameter("@RoleName", SqlDbType.VarChar, txtRoleName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RoleType", SqlDbType.VarChar, cboRoleType.Text));
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

        private void frmSecurityRolesUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmSecurityRolesBrowse)
                {
                    frmSecurityRolesBrowse frmCaller = (frmSecurityRolesBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("RoleID", txtRoleID.Text);
                }
            }
        }
    }
}
