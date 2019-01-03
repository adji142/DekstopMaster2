using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Toko.Class;
using ISA.DAL;
using ISA.Common;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Kasir
{
    public partial class frmLaporanSaldoperPeriode : ISA.Controls.BaseForm
    {
        public frmLaporanSaldoperPeriode()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_LaporanSaldoperPeriode"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, comboJenisTr.Text));
                    //if (SecurityManager.UserID == "MANAGER")
                    //{
                    //    db.Commands[0].Parameters.Add(new Parameter("@lapUser", SqlDbType.VarChar, "MGR"));
                    //}
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data Kosong");
                    return;
                }
                viewReport(dt);

               
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmLaporanSaldoperPeriode_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.DateTimeOfServer;
            rangeDateBox1.ToDate = GlobalVar.DateTimeOfServer;
        }
        private void viewReport(DataTable dt)
        {
            string _periode = "Periode " + ((DateTime)rangeDateBox1.FromDate).ToString("dd MMM yyyy") + " s/d " + ((DateTime)rangeDateBox1.ToDate).ToString("dd MMM yyyy");
            string _userid = "Created by " + SecurityManager.UserID + " on " + GlobalVar.DateTimeOfServer;

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", _periode));
            rptParams.Add(new ReportParameter("UserID", _userid));

            Form frmTaskReport = new frmReportViewer("Kasir.rptLapperPeriode.rdlc", rptParams, dt, "dsSaldoperPeriode_Data");
            frmTaskReport.MdiParent = this.MdiParent;
            frmTaskReport.Show();
        }
    }
}
