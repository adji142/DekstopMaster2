using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using Microsoft.Reporting.WinForms;

namespace ISA.Finance.DKNForm
{
    public partial class frmRptDKNRKDetail : ISA.Finance.BaseForm
    {
        public frmRptDKNRKDetail()
        {
            InitializeComponent();
        }

        private void frmRptDKNRKDetail_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = DateTime.Now;
            rangeDateBox1.ToDate = DateTime.Now;

            rangeDateBox1.Focus();

        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            string Cabang = txtCabang.Text;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_DKN_RKDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, txtCabang.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));


                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReport(dt);
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
        }

        private void DisplayReport(DataTable dt)
        {
            //construct parameter


            string periode;
            string cabang;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            cabang = txtCabang.Text.ToString();

            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Cabang", cabang));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("DKNForm.rptDKNRKDetail.rdlc", rptParams, dt, "dsDKN_Data");
            ifrmReport.Show();

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
