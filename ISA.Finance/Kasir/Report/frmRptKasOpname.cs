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

namespace ISA.Finance.Kasir
{
    public partial class frmRptKasOpname : ISA.Finance.BaseForm
    {
        public frmRptKasOpname()
        {
            InitializeComponent();
        }

        private void frmRptKasOpname_Load(object sender, EventArgs e)
        {
            dateTextBox1.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {


                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KASIR_BeritaAcaraKasOpname"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, dateTextBox1.DateValue));                    
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

            string TglOpname = String.Format("{0}", ((DateTime)dateTextBox1.DateValue).ToString("dd-MMM-yyyy"));
           


            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("TglOpname", TglOpname));
           



            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptKasOpname.rdlc", rptParams, dt, "dsKasOpname_Data");
            ifrmReport.ExportToExcel(ifrmReport.Name);

        }
        

        
    }
}
