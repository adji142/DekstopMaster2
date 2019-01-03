using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Trading.Laporan.Toko
{
    public partial class frmRptLaporanIdwillToko : ISA.Trading.BaseForm
    {
        DataTable dt;
        public frmRptLaporanIdwillToko()
        {
            InitializeComponent();
        }

        private void frmRptLaporanIdwillToko_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "SEMUA";
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "ADA")
            {
                idwillada();
            }
            if (comboBox1.SelectedItem == "TIDAK ADA")
            {
                idwilltidakada();
            }
            else
            {
                semuanya();
            }

            if (dt.Rows.Count > 0)
            {
                DisplayReport(dt);
            }
            else
            {
                MessageBox.Show("Tidak Ada Data");
            }
        }


        public void idwillada()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_idwillAda"));
                //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
        }

        public void idwilltidakada()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_idwillTidakAda"));
                //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
        }
        public void semuanya()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("rsp_Toko_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
            }
        }


        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.RptLaporanIdwillToko.rdlc", rptParams, dt, "dsToko_IDWill");
            ifrmReport.Show();


        } 
    }
}
