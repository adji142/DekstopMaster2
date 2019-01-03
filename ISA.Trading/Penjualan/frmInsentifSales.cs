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


namespace ISA.Trading.Penjualan
{
    public partial class frmInsentifSales : ISA.Controls.BaseForm
    {
        public frmInsentifSales()
        {
            InitializeComponent();
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database("ISADBDepoFinance"))
                {
                    db.Commands.Add(db.CreateCommand("[usp_InsentifSales]")); //cek heri 05042013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangePeriode.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangePeriode.ToDate));

                    db.Commands[0].Parameters.Add(new Parameter("@type", SqlDbType.VarChar, comboType.Text));
                    if (cboRekap.Checked)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.Int, 1));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.Int, 0));
                    }
                    
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

        private void cmdKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayReport(DataTable ds)
        {
            string _periode = DateTime.Parse(rangePeriode.FromDate.ToString()).ToString("dd-MMM-yyyy") +" s/d " + DateTime.Parse(rangePeriode.ToDate.ToString()).ToString("dd-MMM-yyyy");
            string _type = "Tipe "+ comboType.Text;
            string _created ="Created by "+SecurityManager.UserID + " on "+DateTime.Now;
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", _periode));
            rptParams.Add(new ReportParameter("Type", _type));
            rptParams.Add(new ReportParameter("Created", _created));

            string _dataset="";
            string _rdlc="";
            string _judul;
            string _filename = "";

            if(cboRekap.Checked)
            {
                _rdlc = "rptLaporanInsentifSalesRekap.rdlc";
                _dataset = "dsInsentifSales_Rekap";
                _judul="RekapInsentifSalesman" + _periode;
                _filename = "RekapInsentifSalesman" + DateTime.Now.ToString("yyyyMMdd");
                
            }
            else
            {
                _rdlc = "rptLaporanInsentifSalesDetail.rdlc";
                _dataset = "dsInsentifSales_Detail";
                _judul="DetailInsentifSalesman" + _periode;
                _filename = "DetailInsentifSalesman" + DateTime.Now.ToString("yyyyMMdd");
            }

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Penjualan."+_rdlc, rptParams, ds, _dataset);
             ifrmReport.Text = _judul;
             ifrmReport.ExportToExcel(_filename);
        }

        private void frmInsentifSales_Load(object sender, EventArgs e)
        {
            rangePeriode.FromDate = DateTime.Now.AddDays(1 - DateTime.Now.Day); ;
            rangePeriode.ToDate = DateTime.Now;
        }
    }
}
