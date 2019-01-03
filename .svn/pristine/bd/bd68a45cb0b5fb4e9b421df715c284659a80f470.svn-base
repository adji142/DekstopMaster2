using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Controls
{
    public partial class frmPostAreaLookUp : ISA.Controls.BaseForm
    {
        string _postID, _postName;

        public frmPostAreaLookUp(DataTable dt)
        {
            InitializeComponent();
            dataGridView1.DataSource = dt;
        }

        public string postID
        {
            get
            {
                return _postID;
            }
        }

        public string postName
        {
            get
            {
                return _postName;
            }
        }

        private void frmPostAreaLookUp_Load(object sender, EventArgs e)
        {
            dataGridView1.Focus();
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
                _postID = dataGridView1.SelectedCells[0].OwningRow.Cells["PostID"].Value.ToString();
                _postName = dataGridView1.SelectedCells[0].OwningRow.Cells["PostName"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
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
