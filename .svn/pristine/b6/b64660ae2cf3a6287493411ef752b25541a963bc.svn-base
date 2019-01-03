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

namespace ISA.Trading.PO
{
    public partial class frmLaporanRefilPO : ISA.Trading.BaseForm
    {
        public frmLaporanRefilPO()
        {
            InitializeComponent();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cetakRefil"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglfrom", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@tglto", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    DisplayReport(dt);
                }
                else
                {
                    MessageBox.Show(Messages.Error.NotFound);
                }
        }

        private void DisplayReport(DataTable dt)
        {
            string tanggal1 = String.Format(((DateTime)rangeDateBox1.FromDate).ToString("dd-MMM-yyyy"));
            string tanggal2 = String.Format(((DateTime)rangeDateBox1.ToDate).ToString("dd-MMM-yyyy"));
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Gudang", GlobalVar.Gudang));
            rptParams.Add(new ReportParameter("tanggal1", tanggal1));
            rptParams.Add(new ReportParameter("tanggal2", tanggal2));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("PO.rptCetakRefil.rdlc", rptParams, dt, "dsCetakRefil_data");
            ifrmReport.Show();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLaporanRefilPO_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = DateTime.Now;
            rangeDateBox1.ToDate = DateTime.Now;
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_cetakRefil"));
                db.Commands[0].Parameters.Add(new Parameter("@tglfrom", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@tglto", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                DisplayReport(dt);
            }
            else
            {
                MessageBox.Show(Messages.Error.NotFound);
            }

        }
    }
}
