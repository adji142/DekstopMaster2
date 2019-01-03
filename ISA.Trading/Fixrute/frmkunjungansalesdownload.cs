using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISA.Trading.Fixrute
{
    public partial class frmkunjungansalesdownload : ISA.Trading.BaseForm
    {
        public DateTime startdate
        {
            get { return (DateTime)monthYearBox1.FirstDateOfMonth; }
        }
        public DateTime Enddate
        {
            get { return (DateTime)monthYearBox1.LastDateOfMonth; }
        }
        public frmkunjungansalesdownload()
        {
            InitializeComponent();
        }

        private void frmkunjungansalesdownload_Load(object sender, EventArgs e)
        {
            Title = "Download Hasil Kunjungan Sales Force";
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (monthYearBox1.Month == null)
            {
                MessageBox.Show("Bulan tidak di ketahui");
                return;
            }
            else {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
