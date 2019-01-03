using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Finance.Kasir
{
    public partial class frmIndenDetailPiutangBrowse : ISA.Finance.BaseForm
    {
        DataTable dt;
        public frmIndenDetailPiutangBrowse(Form caller, DataTable dt)
        {
            InitializeComponent();
            this.Caller = caller;
            this.dt = dt.Copy();
        }

        private void frmIndenDetailPiutangBrowse_Load(object sender, EventArgs e)
        {
            dt.DefaultView.Sort = "TglTransaksi";
            customGridView1.DataSource = dt.DefaultView.ToTable();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
