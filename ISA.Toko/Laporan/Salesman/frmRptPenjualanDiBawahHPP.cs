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
    public partial class frmRptPenjualanDiBawahHPP : ISA.Toko.BaseForm
    {

        private void ReloadCBOCab()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();

                    cboCab.ValueMember = "CabangID";
                    cboCab.DisplayMember = "Cab";
                    cboCab.DataSource = dt;
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

        public frmRptPenjualanDiBawahHPP()
        {
        InitializeComponent();
        }

        private void frmRptPenjualanDiBawahHPP_Load(object sender,EventArgs e)
        {
        rangeDateBox1.FromDate=new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
        rangeDateBox1.ToDate=DateTime.Now;
        ReloadCBOCab();
        }

        private void cmdYes_Click(object sender,EventArgs e)
        {
        try
        {
        this.Cursor=Cursors.WaitCursor;
        using (Database db = new Database())
        {
        DataTable dt=new DataTable();
        db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_PenjualanDiBawahHPP"));
        db.Commands[0].Parameters.Add(new Parameter("@fromDate",SqlDbType.DateTime,rangeDateBox1.FromDate.Value));
        db.Commands[0].Parameters.Add(new Parameter("@toDate",SqlDbType.DateTime,rangeDateBox1.ToDate.Value));        
        db.Commands[0].Parameters.Add(new Parameter("@CabangID",SqlDbType.VarChar,cboCab.SelectedValue.ToString()));

        dt=db.Commands[0].ExecuteDataTable();

        if(dt.Rows.Count==0)
        {
        MessageBox.Show("No Data");
        return;
        }

        DisplayReport(dt);
        }
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

        private void DisplayReport(DataTable dt)
        {
        string periode;
        periode=String.Format("{0} s/d {1}",((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"),((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
        //construct parameter
        List<ReportParameter> rptParams=new List<ReportParameter>();
        rptParams.Add(new ReportParameter("UserID",SecurityManager.UserID));
        rptParams.Add(new ReportParameter("Periode",periode));
        //call report viewer
        frmReportViewer ifrmReport=new frmReportViewer("Laporan.Salesman.rptPenjualanDiBawahHPP.rdlc",rptParams,dt,"dsNotaPenjualan_Data");
        ifrmReport.Show();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
