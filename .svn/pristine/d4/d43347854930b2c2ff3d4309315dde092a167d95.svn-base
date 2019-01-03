using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;
using Microsoft.Reporting.WinForms;

namespace ISA.Finance.GL
{
    public partial class frmRpt10JournalperKelompokTransaksi : ISA.Finance.BaseForm
    {
        DataTable dtLookup, dtLaporan;
        string kodeGudang="", keltran="";
        DateTime fromDate, toDate;
        public frmRpt10JournalperKelompokTransaksi()
        {
            InitializeComponent();
        }

        private void frmRpt10JournalperKelompokTransaksi_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = DateTime.Today;
            rangeDateBox1.ToDate = DateTime.Today;
            lookupGudang1.GudangID = "";
            GetKelompokTransaksi();
            rangeDateBox1.Focus();
        }

        private void GetKelompokTransaksi()
        {
            dtLookup = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Lookup_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@lookupType", SqlDbType.VarChar, "GL_KelTran"));
                dtLookup = db.Commands[0].ExecuteDataTable();
            }
            if (dtLookup.Rows.Count > 0)
            {
                dtLookup.DefaultView.Sort = "RowOrder";
                cbKelTran.DataSource = dtLookup.DefaultView;
                cbKelTran.DisplayMember = "Value";
                cbKelTran.BindingContext = this.BindingContext;
            }
            else
            {
                cbKelTran.DataSource = null;
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            //if (lookupGudang1.GudangID != "" && lookupGudang1.GudangID != "[CODE]")
            //{
                kodeGudang = lookupGudang1.GudangID;
                keltran = cbKelTran.Text.Substring(0, 3);
                fromDate = (DateTime)rangeDateBox1.FromDate;
                toDate = (DateTime)rangeDateBox1.ToDate;
                dtLaporan = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_10LaporanJournalTransaksi"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, kodeGudang));
                    if(keltran!="ALL")
                        db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, keltran));
                    dtLaporan = db.Commands[0].ExecuteDataTable();
                }

                if (dtLaporan.Rows.Count > 0)
                {
                    ShowReport(dtLaporan);
                }
                else
                {
                    MessageBox.Show(Messages.Confirm.NoDataAvailable);
                }
            //}
        }

        private void ShowReport(DataTable dt)
        {
            
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("title", "LAPORAN JOURNAL TRANSAKSI ("+keltran+")"));
                rptParams.Add(new ReportParameter("perusahaanID", kodeGudang));
                rptParams.Add(new ReportParameter("periode", String.Format("{0:dd-MMM-yyyy}",fromDate) + " S/D " + String.Format("{0:dd-MMM-yyyy}",toDate)));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("GL.rptJournalperKelompokTransaksi.rdlc", rptParams, dt, "dsJournalTransaksi_Data");
                ifrmReport.Text = "10 Laporan Journal Transaksi";
                ifrmReport.Show();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
