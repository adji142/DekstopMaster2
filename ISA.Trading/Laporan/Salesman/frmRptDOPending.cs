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

namespace ISA.Trading.Laporan.Salesman
{
    public partial class frmRptDOPending : ISA.Trading.BaseForm
    {
        private void DisplayReport(DataTable dt)
        {
        string periode;
        periode=String.Format("{0} s/d {1}",((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"),((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
        //construct parameter
        List<ReportParameter> rptParams=new List<ReportParameter>();
        rptParams.Add(new ReportParameter("UserID",SecurityManager.UserID));
        rptParams.Add(new ReportParameter("Periode", periode));
        if (lookupSales.SalesID!="")
        {
        rptParams.Add(new ReportParameter("Sales",lookupSales.NamaSales));
        }
        else
        {
        rptParams.Add(new ReportParameter("Sales","Semua"));
        }
        
        if (textBox1.Text!="")
        {
        rptParams.Add(new ReportParameter("WilID",textBox1.Text));
        }
        else
        {
        rptParams.Add(new ReportParameter("WilID","Semua"));
        }
       
        //call report viewer
        frmReportViewer ifrmReport=new frmReportViewer("Laporan.Salesman.rptDOPending.rdlc",rptParams,dt,"dsOrderPenjualan_Data");
        ifrmReport.Show();

        }

        public frmRptDOPending()
        {
        InitializeComponent();
        }

        private void cmdNo_Click(object sender,EventArgs e)
        {
        this.Close();
        }

        private void lookupSales_Load(object sender,EventArgs e)
        {

        }

        private void frmRptDOPending_Load(object sender,EventArgs e)
        {
        rangeDateBox1.FromDate=new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
        rangeDateBox1.ToDate=DateTime.Now;
        rangeDateBox1.Focus();
        }

        private void lookupSales_Leave(object sender,EventArgs e)
        {
            if (lookupSales.NamaSales.ToString().Trim()=="")
            {
            lookupSales.SalesID="";
            }
        }

        private void cmdYes_Click(object sender,EventArgs e)
        {
            try
            {
            this.Cursor=Cursors.WaitCursor; DataTable dt=new DataTable();
                using (Database db = new Database())
                {
                   
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_DOPending"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate",SqlDbType.DateTime,rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate",SqlDbType.DateTime,rangeDateBox1.ToDate.Value));
                    if (lookupSales.SalesID!="")
                    {
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales",SqlDbType.VarChar,lookupSales.SalesID));
                    }
                    if (textBox1.Text.Trim()!="")
                    {
                     db.Commands[0].Parameters.Add(new Parameter("@WilID",SqlDbType.VarChar,textBox1.Text.Trim()));
                    }
                    
                    dt=db.Commands[0].ExecuteDataTable();

                  
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                DisplayReport(dt);



            }
            catch(Exception ex)
            {
            Error.LogError(ex);
            }
            finally
            {
            this.Cursor=Cursors.Default;
            }
        }
    }
}
