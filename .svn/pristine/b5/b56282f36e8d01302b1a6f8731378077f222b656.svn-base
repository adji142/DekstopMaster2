using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Toko.Master
{
    public partial class frmRoleBusinessUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _roleID;

        DataTable dt;


        public frmRoleBusinessUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmRoleBusinessUpdate(Form caller, string roleID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update ;
            _roleID = roleID;
            this.Caller = caller;
        }

        private void frmRoleBusinessUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.Update)
            {
                try
                {

                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_RoleBusiness_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RoleID", SqlDbType.VarChar, _roleID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data

                    txtRoleID.Text = Tools.isNull(dt.Rows[0]["RoleID"], "").ToString();
                    txtRoleID.Enabled = false;
                    txtRoleName.Text = Tools.isNull(dt.Rows[0]["RoleName"], "").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //Error.LogError(ex);
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_RoleBusiness_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@RoleID", SqlDbType.VarChar, txtRoleID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RoleName", SqlDbType.VarChar, txtRoleName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_RoleBusiness_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RoleID", SqlDbType.VarChar, txtRoleID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RoleName", SqlDbType.VarChar, txtRoleName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                MessageBox.Show("Data telah tersimpan");
                this.DialogResult = DialogResult.OK;
                frmRoleBusinessBrowse  frmCaller = (frmRoleBusinessBrowse )this.Caller;
                frmCaller.RefreshData();
                this.Close();
                frmCaller.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
