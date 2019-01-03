using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using Microsoft.Reporting.WinForms;


namespace ISA.Finance.Kasir
{
    public partial class frmPenerimaanKN : ISA.Controls.BaseForm
    {
        public frmPenerimaanKN()
        {
            InitializeComponent();
        }

        private void cmdSeacrh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            if (rangeTanggal.FromDate.ToString() == "" || rangeTanggal.ToDate.ToString() == "")
            {
                MessageBox.Show("Range tanggal isi dengan benar");
                rangeTanggal.Focus();
                return;
            }


            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanKN_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeTanggal.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeTanggal.ToDate.Value));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        cgvPenerimaanKN.DataSource = dt;
                    }
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPenerimaanKN_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            int thn = DateTime.Now.Year;
            int bln = DateTime.Now.Month;
            rangeTanggal.FromDate = new DateTime(thn, bln, 1);
            rangeTanggal.ToDate = DateTime.Now;
        }
    }
}
