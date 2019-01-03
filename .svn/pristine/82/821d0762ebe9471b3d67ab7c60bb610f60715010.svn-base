using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.DAL;

namespace ISA.Finance.Kasir
{
    public partial class frmRptLaporanPertanggungJawaban : ISA.Finance.BaseForm
    {
        string nip = "",sort="", cut="", posko;
        DataSet dsKasbon;
        DateTime fromDate, toDate;
        public frmRptLaporanPertanggungJawaban()
        {
            InitializeComponent();
        }

        private void frmRptLaporanPertanggungJawaban_Load(object sender, EventArgs e)
        {
            tbTanggal.FromDate = DateTime.Today;
            tbTanggal.ToDate = DateTime.Today;
            txtPID.Text = GlobalVar.PerusahaanID;
        }

        private void lookupPegawai1_SelectData(object sender, EventArgs e)
        {
            nip = lookupPegawai1.Nip;
        }

        private void rbCutTidak_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCutTidak.Checked == true)
                tbTanggal.Enabled = false;
            else
                tbTanggal.Enabled = true;
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            fromDate = (DateTime)tbTanggal.FromDate;
            toDate = (DateTime)tbTanggal.ToDate;
            posko = GlobalVar.PerusahaanID;

            

            if(rbCutYa.Checked==true)
                cut="Ya";
            else
                cut="Tidak";

            if (rbSortNama.Checked == true)
                sort = "Nama";
            else if (rbSortSaldoAsc.Checked == true)
                sort = "sisa";
            else if (rbSortSaldoDesc.Checked == true)
                sort = "sisa Desc";
            else if (rbSortTgl.Checked == true)
                sort = "Tgl";

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KASIR_PertanggungJawaban"));                    
                    db.Commands[0].Parameters.Add(new Parameter("@posko", SqlDbType.VarChar, txtPID.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@cut", SqlDbType.VarChar, cut));
                    if (rbCutYa.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                    }
                    if(nip!="")
                        db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, nip));

                    dsKasbon = db.Commands[0].ExecuteDataSet();
                }
                //if (rbModelS.Checked == true)
                //    dsKasbon.Tables[0].DefaultView.RowFilter = "sisa<>0";

                if (rbCetM.Checked == true)
                    dsKasbon.Tables[0].DefaultView.RowFilter = "sisa<0";
                else if (rbCetP.Checked == true)
                    dsKasbon.Tables[0].DefaultView.RowFilter = "sisa>0";

                if (dsKasbon.Tables[0].DefaultView.Count != 0)
                {
                    dsKasbon.Tables[0].DefaultView.Sort = sort;

                    RptPertanggungJawaban(dsKasbon);
                }
                else
                {
                    MessageBox.Show("Tidak Ada Data");
                    return;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void RptPertanggungJawaban(DataSet ds)
        {

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("fromDate", String.Format("{0:dd-MMM-yyyy}", fromDate)));
            rptParams.Add(new ReportParameter("toDate", String.Format("{0:dd-MMM-yyyy}", toDate)));

            //call report viewer
            List<DataTable> pTable = new List<DataTable>();
            pTable.Add(ds.Tables[0].DefaultView.ToTable());


            List<string> pDatasetName = new List<string>();
            pDatasetName.Add("dsKasbon_Data");
            if (rbModelS.Checked == true)
            {
                frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptPertanggungJawabanShort.rdlc", rptParams, pTable, pDatasetName);
                ifrmReport.Text = "lap_pertanggungjawaban";
                ifrmReport.ExportToExcel(ifrmReport.Name);
            }
            else
            {
                frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptPertanggungjawabanLong.rdlc", rptParams, pTable, pDatasetName);
                ifrmReport.Text = "lap_pertanggungjawaban";
                ifrmReport.ExportToExcel(ifrmReport.Name);
            }
        }

    }
}
