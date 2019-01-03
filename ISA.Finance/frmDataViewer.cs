using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Finance
{
    public partial class frmDataViewer : ISA.Finance.BaseForm
    {
        public frmDataViewer(DataTable dt)
        {
            InitializeComponent();
            customGridView1.AutoGenerateColumns = true;
            customGridView1.DataSource = dt.DefaultView;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
