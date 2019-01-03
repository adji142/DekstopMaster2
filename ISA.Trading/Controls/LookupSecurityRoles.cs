using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Controls
{
    public partial class LookupSecurityRoles : UserControl
    {
        public event EventHandler SelectData;

        public enum enRoleType
        {
            Application,
            Business
        }

        public string _RoleType;       

        public string RoleID
        {
            get
            {
                return txtLookupCode.Text;
            }
            set
            {
                txtLookupCode.Text = value;
            }
        }

        public string RoleName
        {
            get
            {
                return txtLookupName.Text;
            }
            set
            {
                txtLookupName.Text = value;
            }
        }

        public enRoleType RoleType
        {
            get
            {
                if (_RoleType == "APPLICATION")
                {
                    return enRoleType.Application;
                }
                else 
                {
                    return enRoleType.Business;
                }               
            }
            set
            {
                if (value == enRoleType.Application)
                {
                    _RoleType = "APPLICATION";
                }
                else
                {
                    _RoleType = "BUSINESS";
                }
            }
        }


        public LookupSecurityRoles()
        {
            InitializeComponent();
        }

        private void ShowDialogForm()
        {
           
            frmSecurityRolesLookup ifrmDialog = new frmSecurityRolesLookup(_RoleType);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {

            frmSecurityRolesLookup ifrmDialog = new frmSecurityRolesLookup(_RoleType, searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmSecurityRolesLookup dialogForm)
        {
            txtLookupCode.Text = dialogForm.roleID;
            txtLookupName.Text = dialogForm.roleName;
            
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        public void Clear()
        {

            txtLookupName.Text = "";
            txtLookupCode.Text = "";

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }

        private void txtLookupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtLookupName.Text != "")
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();

                            db.Commands.Add(db.CreateCommand("usp_SecurityRoles_SEARCH"));
                            db.Commands[0].Parameters.Add(new Parameter("@roleType", SqlDbType.VarChar, _RoleType ));
                            db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookupName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, GlobalVar.ApplicationID));
                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count == 1)
                            {
                                
                                txtLookupCode.Text = Tools.isNull(dt.Rows[0]["RoleID"], "").ToString();
                                txtLookupName.Text = Tools.isNull(dt.Rows[0]["RoleName"], "").ToString();
                            }
                            else
                            {
                                ShowDialogForm(txtLookupName.Text, dt);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                else
                {

                    Clear();
                }
            }
        }
    }
}
