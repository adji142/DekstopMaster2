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
namespace ISA.Trading.ArusStock
{
    public partial class frmRptMutasiRegister : ISA.Trading.BaseForm
    {
        string _KodeGudang;

        private void DisplayReport(DataTable dt)
        {

            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("ArusStock.rptMutasiRegister.rdlc", rptParams, dt, "dsStok_Data");
            ifrmReport.Show();

        }

        public frmRptMutasiRegister()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptMutasiRegister_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            _KodeGudang = "";
        }

        private void rangeDateBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cmdYes.PerformClick();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_Mutasi_Register"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    if (_KodeGudang!="")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, _KodeGudang));
                    }
                    
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count==0)
                    {
                        MessageBox.Show("Tidak Ada Data");
                        return;
                    }
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

        private void lookupGudang1_SelectData(object sender, EventArgs e)
        {
            _KodeGudang = lookupGudang1.GudangID;
        }

        private void lookupGudang1_Leave(object sender, EventArgs e)
            {
            if (lookupGudang1.NamaGudang=="")
            {
            lookupGudang1.GudangID="";
            }
            }

         

    }
}
