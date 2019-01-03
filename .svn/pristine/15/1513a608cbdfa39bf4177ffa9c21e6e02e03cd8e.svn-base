using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Finance.Kasir
{
    public partial class frmKasirLogModeBrowse : ISA.Finance.BaseForm
    {
        DataTable dtKasirLog;
        public frmKasirLogModeBrowse(DataTable dt)
        {
            InitializeComponent();
            dtKasirLog = dt.Copy();
        }

        private void frmKasirLogModeBrowse_Load(object sender, EventArgs e)
        {
            dgKasirLog.DataSource = dtKasirLog;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
