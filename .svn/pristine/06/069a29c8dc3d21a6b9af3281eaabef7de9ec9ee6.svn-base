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

namespace ISA.Toko.Penjualan
{
    public partial class frmLaporanNotaAnakCabang : ISA.Toko.BaseForm
    {
        public frmLaporanNotaAnakCabang()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLaporanNotaAnakCabang_Load(object sender, EventArgs e)
        {
            rangeTerima.FromDate = DateTime.Now;
            rangeTerima.ToDate = DateTime.Now;
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Penjualan_NotaAnakCabang")); //cek heri 05032013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeTerima.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeTerima.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@linkPiutang", SqlDbType.Int, rbUnlink.Checked ? 1:2));
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
            string reportTitle;
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeTerima.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeTerima.ToDate).ToString("dd/MM/yyyy"));

            string sorting = string.Empty;

            if (rbUnlink.Checked)
                reportTitle = "LAPORAN NOTA-NOTA (PENJUALAN KREDIT) DARI ANAK CABANG YANG BELUM LINK KE PIUTANG";
            else
                reportTitle = "LAPORAN NOTA-NOTA (PENJUALAN KREDIT) DARI ANAK CABANG YANG SUDAH LINK KE PIUTANG";

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Title", reportTitle));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptLaporanNotaAnakCabang.rdlc", rptParams, dt, "dsToko_Data2");
            ifrmReport.Show();
        }

    }
}
