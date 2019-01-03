using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Bengkel.Master
{
    public partial class frmCustomerFilterBrowse : ISA.Bengkel.BaseForm
    {
        DataTable dt = new DataTable();

        public frmCustomerFilterBrowse(Form caller, DataTable dtc)
        {
            InitializeComponent();
            this.Caller = caller;
            dt = dtc;
        }

        private void frmCustomerFilterBrowse_Load(object sender, EventArgs e)
        {
            dataGridCustSpm.DataSource = dt.DefaultView;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
