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
    public partial class frmRptDOBatal : ISA.Trading.BaseForm
    {

        private void DisplayReport(DataTable dt)
        {
        string periode;
        periode=String.Format("{0} s/d {1}",((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"),((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
        //construct parameter
        List<ReportParameter> rptParams=new List<ReportParameter>();
        rptParams.Add(new ReportParameter("UserID",SecurityManager.UserID));
        rptParams.Add(new ReportParameter("Gudang",lookupGudang.GudangID));
        rptParams.Add(new ReportParameter("Periode",periode));

        string menu;
       
        if(rdb1.Checked==true)
        {
        menu="STOK";
        }
        else if(rdb2.Checked==true)
        {
        menu="PIUTANG";
        }
        else if(rdb3.Checked==true)
        {
        menu="PENJUALAN";
        }
        else
        {
         menu="";
        }
        rptParams.Add(new ReportParameter("Alasan",menu));
        //call report viewer
        frmReportViewer ifrmReport=new frmReportViewer("Laporan.Salesman.rptDoBatal.rdlc",rptParams,dt,"dsOrderPenjualan_Data");
        ifrmReport.Show();

        }


        public frmRptDOBatal()
        {
        InitializeComponent();
        }

        private void commandButton2_Click(object sender,EventArgs e)
        {
        this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_DOBatal"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));

                    if (lookupGudang.GudangID.ToString().Trim() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, lookupGudang.GudangID));
                    }
                    dt = db.Commands[0].ExecuteDataTable();


                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
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

        private void frmRptDOBatal_Load(object sender,EventArgs e)
        {
        rangeDateBox1.FromDate=new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
        rangeDateBox1.ToDate=DateTime.Now;
        rangeDateBox1.Focus();
        rdb4.Checked=true;
        }

        private void lookupGudang_Leave(object sender,EventArgs e)
        {
            if (lookupGudang.NamaGudang.ToString().Trim()=="")
            {
            lookupGudang.GudangID="";
            }
        }

        private void rdb1_CheckedChanged(object sender,EventArgs e)
        {

        }
    }
}
