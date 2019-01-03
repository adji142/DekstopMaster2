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

namespace ISA.Toko.VLapW
{
    public partial class frmRptOmzetHarian : ISA.Toko.BaseForm
    {
       
        DataSet ds = new DataSet();
        public frmRptOmzetHarian()
        {
            InitializeComponent();
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
                using (Database db = new Database())
                {
                  
                    db.Commands.Add(db.CreateCommand("rsp_VLapW_OmzetHarianPerSales"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));

                    if (dateTextBox1.Text!="")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.DateTime, dateTextBox1.DateValue));
                    }
                    
                    if (cabangComboBox1.CabangID!="")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, cabangComboBox1.CabangID));
                    }
                    
                    if (txtKelompok.Text.Trim()!="")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KLP", SqlDbType.VarChar, txtKelompok.Text));
                    }
                    

                   
                    ds = db.Commands[0].ExecuteDataSet();
                }
                if (ds.Tables[0].Rows.Count == 0)
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

        private void frmRptOmzetHarian_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
           
        }

        private void DisplayReport(DataSet ds)
        {
            string periode;
            string Date="";
            string option;
            string Init;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            if (dateTextBox1.Text!="")
            {
                Date = String.Format("OMZET TGL : {0}",((DateTime)dateTextBox1.DateValue).ToString("dd/MM/yyyy"));
            }
            
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Date", Date));
    
            if (txtKelompok.Text.Trim()!="")
            {
                option = "Laporan Harian Detail  Kelp.Brg: " + txtKelompok.Text.Trim();
            }
            else
            {
                option = "Laporan Harian Detail  Kelp.Brg: Semua";
            }
            Init = GlobalVar.PerusahaanID;
            rptParams.Add(new ReportParameter("KLP", option));
            rptParams.Add(new ReportParameter("Init", Init));

           

           // call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("VLapW.rptOmzetHarian.rdlc", rptParams, ds.Tables[0], "dsOrderPenjualan_Data");
            ifrmReport.Show();

            if (chkDetail.Checked==true)
            {
                //call report viewer
                frmReportViewer ifrmReport2 = new frmReportViewer("VLapW.rptOmzetHarianDetail.rdlc", rptParams, ds.Tables[1], "dsOrderPenjualan_Data");
                ifrmReport2.Show();
            }
          

        }
    }
}
