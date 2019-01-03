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
    public partial class frmRptPenjualanBedasarkanABE : ISA.Toko.BaseForm
    {
        public frmRptPenjualanBedasarkanABE()
        {
            InitializeComponent();
        }

        private void frmRptPenjualanBedasarkanABE_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lookupGudang_Leave(object sender, EventArgs e)
        {
            if (lookupGudang.NamaGudang.Trim()=="")
            {
                lookupGudang.GudangID = "";
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor; DataSet ds = new DataSet();
                using (Database db = new Database())
                {
                  
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_PenjualanBedasarkanABE"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    if (lookupGudang.GudangID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, lookupGudang.GudangID));
                    }

                    ds = db.Commands[0].ExecuteDataSet();


                } if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                DisplayReport(ds);
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

        private void rangeDateBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void DisplayReport(DataSet ds)
        {
            string periode;
            string option;
            string harga;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            if (lookupGudang.GudangID != "")
            {
                option = lookupGudang.GudangID;
            }
            else
            {
                option = GlobalVar.CabangID;
            }

            
            harga = "AVG";
            
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Option", option));
            rptParams.Add(new ReportParameter("Harga", harga));
            rptParams.Add(new ReportParameter("Report", "Penjualan Bruto"));
            List<DataTable> pTable = new List<DataTable>();
           // List<string> pDatasetName = new List<string>();
            pTable.Add(ds.Tables[0]);
            pTable.Add(ds.Tables[1]);
            pTable.Add(ds.Tables[2]);
            pTable.Add(ds.Tables[3]);
            pTable.Add(ds.Tables[4]);
          
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Salesman.rptPenjualanBedasarkanABE.rdlc", rptParams, pTable[0], "dsNotaPenjualan_Data");
            ifrmReport.Text = "Penjualan Bruto";
            ifrmReport.Show();

            rptParams.RemoveAt(4);
            rptParams.Add(new ReportParameter("Report", "Koreksi Jual"));
            frmReportViewer ifrmReport1 = new frmReportViewer("Laporan.Salesman.rptPenjualanBedasarkanABE.rdlc", rptParams, pTable[1], "dsNotaPenjualan_Data");
            ifrmReport1.Text = "Koreksi Jual";
            ifrmReport1.Show();

            rptParams.RemoveAt(4);
            rptParams.Add(new ReportParameter("Report", "Retur Kotor"));
            frmReportViewer ifrmReport2 = new frmReportViewer("Laporan.Salesman.rptPenjualanBedasarkanABE.rdlc", rptParams, pTable[2], "dsNotaPenjualan_Data");
            ifrmReport2.Text = "Retur Kotor";
            ifrmReport2.Show(); 

            rptParams.RemoveAt(4);
            rptParams.Add(new ReportParameter("Report", "Koreksi Retur"));
            frmReportViewer ifrmReport3 = new frmReportViewer("Laporan.Salesman.rptPenjualanBedasarkanABE.rdlc", rptParams, pTable[3], "dsNotaPenjualan_Data");
            ifrmReport3.Text = "Koreksi Retur";
            ifrmReport3.Show();
            
            rptParams.RemoveAt(4);
            rptParams.Add(new ReportParameter("Report", "Penjualan Netto"));
            frmReportViewer ifrmReport4 = new frmReportViewer("Laporan.Salesman.rptPenjualanBedasarkanABE.rdlc", rptParams, pTable[4], "dsNotaPenjualan_Data");
            ifrmReport4.Text = "Penjualan Netto";
            ifrmReport4.Show();

           
        }
    }
}
