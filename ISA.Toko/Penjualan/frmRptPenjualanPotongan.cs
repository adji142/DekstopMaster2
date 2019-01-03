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
    public partial class frmRptPenjualanPotongan : ISA.Toko.BaseForm
    {
        double sumPOt;
        public frmRptPenjualanPotongan()
        {
            InitializeComponent();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (lookupToko.KodeToko=="")
            {
                lookupToko.Focus();
                return;
            }

            try
            {
                sumPOt = 0;
                DataSet dtResult = new DataSet();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_PenjualanPotongan]")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko.KodeToko));

                    dtResult = db.Commands[0].ExecuteDataSet();
                    if (dtResult.Tables[0].Rows.Count==0)
                    {
                        MessageBox.Show("No Data");
                        return;
                    }

                    sumPOt = Convert.ToDouble(dtResult.Tables[1].Rows[0][0]);
                    DisplayReport(dtResult.Tables[0]);
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptPenjualanPotongan_Load(object sender, EventArgs e)
        {
            dateTextBox1.DateValue = DateTime.Now;
            dateTextBox1.Focus();
        }

         private void DisplayReport(DataTable dt)
        {

          string periode;
        periode = String.Format("Tanggal : {0}",  ((DateTime)dateTextBox1.DateValue).ToString("dd/MM/yyyy"));
        //construct parameter
        List<ReportParameter> rptParams=new List<ReportParameter>();
        rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
         rptParams.Add(new ReportParameter("Periode", periode));
        rptParams.Add(new ReportParameter("NamaToko", lookupToko.NamaToko));
        rptParams.Add(new ReportParameter("AlamatToko", lookupToko.Alamat));
        rptParams.Add(new ReportParameter("sumPOT", sumPOt.ToString("#,##0")));

        //call report viewer
        frmReportViewer ifrmReport=new frmReportViewer("Penjualan.rptPenjualanPotongan.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
        ifrmReport.Show();
        }

        
    }
}
