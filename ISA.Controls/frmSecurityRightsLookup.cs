using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;

namespace ISA.Controls
{
    public partial class frmSecurityRightsLookup : ISA.Controls.BaseForm
    {
        string _rightID;
        string _rightName;
        string _applicationID;


        public string rightID
        {
            get
            {
                return _rightID;
            }
        }

        public string rightName
        {
            get
            {
                return _rightName;
            }
        }

        [Browsable (true)]
        public string ApplicationID
        {
            get
            {
                return _applicationID;
            }
            set
            {
                _applicationID = value;
            }
        }

        public frmSecurityRightsLookup()
        {
            InitializeComponent();
        }

        public frmSecurityRightsLookup(string searchArg, DataTable dt)
        {
            InitializeComponent();
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
                _rightID = dataGridView1.SelectedCells[0].OwningRow.Cells["RightID"].Value.ToString();
                _rightName = dataGridView1.SelectedCells[0].OwningRow.Cells["RightName"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void RefreshData()
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_SecurityRights_SEARCH"));
                db.Commands[0].Parameters.Add(new Parameter("@applicationID", SqlDbType.VarChar, this.ApplicationID));
                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNama.Text));
                dt = db.Commands[0].ExecuteDataTable();
                dataGridView1.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Focus();
                }
            }
        
        }

        private void frmSecurityRightsLookup_Load(object sender, EventArgs e)
        {
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
