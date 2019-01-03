using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Finance.Piutang
{
    public partial class frmSaldoPiutangPenjualanTunai : ISA.Controls.BaseForm
    {
        DataTable dtp = new DataTable(GlobalVar.DBName);

        public frmSaldoPiutangPenjualanTunai(Form caller, DataTable dt)
        {
            InitializeComponent();
            dtp = dt;
            this.Caller = caller;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSaldoPiutangPenjualanTunai_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = dtp;
        }
    }
}
