using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko;

namespace ISA.Toko.Controls
{
    public partial class frmSecurityRolesLookup : ISA.Toko.BaseForm
    {
        string _roleID;
        string _roleName;
        string _roleType;

        public string roleID
        {
            get
            {
                return _roleID;
            }
        }

        public string roleName
        {
            get
            {
                return _roleName;
            }
        }

        public string roleType
        {
            get
            {
                return _roleType;
            }
        }

        public frmSecurityRolesLookup(string roleType)
        {
            InitializeComponent();
            _roleType = roleType;
            this.Title = "SECURITY - " + _roleType + " ROLES";
        }

        public frmSecurityRolesLookup(string roleType, string searchArg, DataTable dt)
        {
            InitializeComponent();
            _roleType = roleType;
            this.Title = "SECURITY - " + _roleType + " ROLES";
            txtNama.Text = searchArg;
            dataGridView1.DataSource = dt;
        }       

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }


        private void ConfirmSelect()
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {                
                _roleID = dataGridView1.SelectedCells[0].OwningRow.Cells["RoleID"].Value.ToString();
                _roleName = dataGridView1.SelectedCells[0].OwningRow.Cells["RoleName"].Value.ToString();

            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_SecurityRoles_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, GlobalVar.ApplicationID));
                    db.Commands[0].Parameters.Add(new Parameter("@RoleType", SqlDbType.VarChar, _roleType));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNama.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmSecurityRolesLookup_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Focus();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }


    }
}
