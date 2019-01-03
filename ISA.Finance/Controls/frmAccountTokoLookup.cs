using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Finance.Controls
{
    public partial class frmAccountTokoLookup : ISA.Finance.BaseForm
    {
        string _noAccount;
        string _kodeToko;

        public string NoAccount
        {
            get
            {
                return _noAccount;
            }
            set
            {
                _noAccount = value;
            }
        }

        public string KodeToko
        {
            get
            {
                return _kodeToko;
            }
            set
            {
                _kodeToko = value;
            }
        }


        public frmAccountTokoLookup()
        {
            InitializeComponent();
        }

        public frmAccountTokoLookup(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtSearch.Text = searchArg;
            customGridView1.DataSource = dt; 
        }

        public void RefreshData()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_AccountToko_LOOKUP"));
                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtSearch.Text));
                dt = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    customGridView1.Focus();
                }
            }
        }

        private void ConfirmSelect()
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                _noAccount = customGridView1.SelectedCells[0].OwningRow.Cells["cNoAccount"].Value.ToString();
                _kodeToko = customGridView1.SelectedCells[0].OwningRow.Cells["cKodeToko"].Value.ToString();
                
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void frmAccountTokoLookup_Load(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void customGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && customGridView1.SelectedCells.Count == 1)
            {
                e.SuppressKeyPress = true;
                ConfirmSelect();

            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmAccountTokoLookup_Shown(object sender, EventArgs e)
        {
            if (customGridView1.Rows.Count > 0)
            {
                customGridView1.Focus();
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }
    }
}
