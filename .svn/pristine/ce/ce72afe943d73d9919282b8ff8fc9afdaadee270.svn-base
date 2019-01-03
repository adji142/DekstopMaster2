using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Trading.VACCDO_Pos
{
    public partial class frmRptACCDeviationFilterPos : ISA.Trading.BaseForm
    {
        public frmRptACCDeviationFilterPos()
        {
            InitializeComponent();
        }

        private void frmRptACCDeviationFilter_Load(object sender, EventArgs e)
        {
            rgbTglDO.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglDO.ToDate = DateTime.Now;
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            if (!lookupPostArea.textMatch)
            {
                MessageBox.Show("Pos tidak ada");
                lookupPostArea.Focus();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_PenyimpanganACC_Pos"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglDO.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@c1", SqlDbType.VarChar, txtC1.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@postID", SqlDbType.VarChar, lookupPostArea.PostID));

                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                    MessageBox.Show("Tidak ada data...!");
                else
                    DisplayReport(dt);
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

        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rgbTglDO.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rgbTglDO.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Title", "Laporan Penyimpangan ACC"));
            rptParams.Add(new ReportParameter("InitPrs", GetInitPrs()));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("VACCDO_Pos.rptDOACCPos.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Show();

        }

        private string GetInitPrs()
        {
            string initGudang = "";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count != 0)
                {
                    initGudang = dt.Rows[0]["InitGudang"].ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return initGudang;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
