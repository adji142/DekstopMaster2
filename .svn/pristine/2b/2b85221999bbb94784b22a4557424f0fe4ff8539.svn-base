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

namespace ISA.Toko.Laporan.Salesman
{
    public partial class frmRptRekapitulasiPenjualanSales : ISA.Toko.BaseForm
    {
        DataSet ds = new DataSet();

        public frmRptRekapitulasiPenjualanSales()
        {
            InitializeComponent();
        }

        private void lookupGudang_Leave(object sender, EventArgs e)
        {
            if (lookupGudang.NamaGudang.Trim()=="")
            {
                lookupGudang.GudangID = "";
            }
        }

        private void frmRptRekapitulasiPenjualanSales_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            cabangComboBox1.CabangID = GlobalVar.CabangID;
            rangeDateBox1.Focus();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_RekapitulasiPenjualanSales"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, cabangComboBox1.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@HPP", SqlDbType.Bit, 0));
                    if (lookupGudang.GudangID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, lookupGudang.GudangID));
                    }

                    ds = db.Commands[0].ExecuteDataSet();

                   
                }
                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                DisplayReport();



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


        private void DisplayReport()
        {
            string periode;
            string option;
            string harga;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            
            
            if (lookupGudang.GudangID != "")
            {
                option = lookupGudang.GudangID;
            }
            else
            {
                option = GlobalVar.CabangID;
            }

            harga = "AVG";
            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Option", option));
            rptParams.Add(new ReportParameter("Harga", harga));
            rptParams.Add(new ReportParameter("Report", "Bruto"));
          

          

            List<DataTable> pTable = new List<DataTable>();
            pTable.Add(ds.Tables[0]);
            pTable.Add(ds.Tables[1]);
            pTable.Add(ds.Tables[2]);
            pTable.Add(ds.Tables[3]);
            pTable.Add(ds.Tables[4]);
            //pTable.Add(ds.Tables[5]);
   

            List<string> pDatasetName = new List<string>();
            pDatasetName.Add("dsNotaPenjualan_Data");
            pDatasetName.Add("dsNotaPenjualan_Data11");
            pDatasetName.Add("dsNotaPenjualan_Data12");
            pDatasetName.Add("dsNotaPenjualan_Data13");
            pDatasetName.Add("dsNotaPenjualan_Data14");
      
            


            //call report viewer
          
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Salesman.rptRekapitulasiPenjualanSales2.rdlc", rptParams, pTable, pDatasetName);
            //ifrmReport.Text = "Penjualan Bruto";
            ifrmReport.Show();

            //rptParams.RemoveAt(4);
            //rptParams.Add(new ReportParameter("Report", "Koreksi Jual"));
            //frmReportViewer ifrmReport2 = new frmReportViewer("Laporan.Salesman.rptRekapitulasiPenjualanSales2.rdlc", rptParams, pTable[1], "dsNotaPenjualan_Data");
            //ifrmReport2.Text = "Koreksi Jual";
            //ifrmReport2.Show();

            //rptParams.RemoveAt(4);
            //rptParams.Add(new ReportParameter("Report", "Retur Kotor"));
            //frmReportViewer ifrmReport3 = new frmReportViewer("Laporan.Salesman.rptRekapitulasiPenjualanSales2.rdlc", rptParams, pTable[2], "dsNotaPenjualan_Data");
            //ifrmReport3.Text = "Retur Kotor";
            //ifrmReport3.Show();

            //rptParams.RemoveAt(4);
            //rptParams.Add(new ReportParameter("Report", "Koreksi Retur"));
            //frmReportViewer ifrmReport4 = new frmReportViewer("Laporan.Salesman.rptRekapitulasiPenjualanSales2.rdlc", rptParams, pTable[3], "dsNotaPenjualan_Data");
            //ifrmReport4.Text = "Koreksi Retur";
            //ifrmReport4.Show();

            //rptParams.RemoveAt(4);
            //rptParams.Add(new ReportParameter("Report", "Penjualan Netto"));
            //frmReportViewer ifrmReport1 = new frmReportViewer("Laporan.Salesman.rptRekapitulasiPenjualanSales2.rdlc", rptParams, pTable[4], "dsNotaPenjualan_Data");
            //ifrmReport1.Text = "Penjualan Netto";
            //ifrmReport1.Show();
        }
    }
}
