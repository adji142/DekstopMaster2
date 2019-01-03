using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Expedisi
{
    public partial class frmRptPenjualanTunaiKreditFilter : ISA.Toko.BaseForm
    {
        string shift, tunaiKredit;

        public frmRptPenjualanTunaiKreditFilter()
        {
            InitializeComponent();
        }

        private void frmRptPenjualanTunaiKreditFilter_Load(object sender, EventArgs e)
        {
            rgbTglSuratJalan.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglSuratJalan.ToDate = DateTime.Now;
            rdoKredit.Checked = true;
            rdoShift1.Checked = true;
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            if (rdoTunai.Checked == true)
                tunaiKredit = "T";
            if (rdoKredit.Checked == true)
                tunaiKredit = "K";
            if (rdoKreditTunai.Checked == true)
                tunaiKredit = "A";

            if (rdoShift1.Checked == true)
                shift = "1";
            if (rdoShift2.Checked == true)
                shift = "2";
            if (rdoSemuaShift.Checked == true)
                shift = "0";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("rsp_PenjualanTunaiKredit"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglSuratJalan.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglSuratJalan.ToDate));
                    if (shift != "0")
                        db.Commands[0].Parameters.Add(new Parameter("@shift", SqlDbType.Int, int.Parse(shift)));
                    if (tunaiKredit != "A")
                        db.Commands[0].Parameters.Add(new Parameter("@tunaiKredit", SqlDbType.VarChar, tunaiKredit));

                    dt = db.Commands[0].ExecuteDataTable();
                }
                string PrevNota="";
                string CurNota = "";
                string PrevSj="";
                string CurSj="";
                foreach (DataRow dr in dt.Rows)
                {

                    CurNota = dr["NoNota"].ToString();
                    CurSj = dr["NoSuratJalan"].ToString();
                    if (PrevNota==CurNota && PrevSj==CurSj)
                    {
                        dr["Nominal"] = 0;
                        
                    }
                    PrevNota = CurNota;
                    PrevSj = CurSj;
                }
                
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
            periode = String.Format("{0} s/d {1}", ((DateTime)rgbTglSuratJalan.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rgbTglSuratJalan.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Shift", shift));
            rptParams.Add(new ReportParameter("TunaiKredit", tunaiKredit));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptPenjualanTunaiKredit.rdlc", rptParams, dt, "dsRekapKoli_Data");
            ifrmReport.Show();

        } 

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
