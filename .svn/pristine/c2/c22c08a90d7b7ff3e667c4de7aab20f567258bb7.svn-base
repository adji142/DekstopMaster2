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


namespace ISA.Toko.Persediaan
{
    public partial class frmRptStandarStokTipisBelumLink : ISA.Toko.BaseForm
    {

        private void DisplayReport(DataTable dt)
        {

        //construct parameter
        List<ReportParameter> rptParams=new List<ReportParameter>();
        rptParams.Add(new ReportParameter("UserID",SecurityManager.UserID));

        //call report viewer
        frmReportViewer ifrmReport=new frmReportViewer("Persediaan.rtpStandarStokTipisBelumLink.rdlc",rptParams,dt,"dsOpname_Data1");
        ifrmReport.Show();

        }



        public frmRptStandarStokTipisBelumLink()
        {
        InitializeComponent();
        }

        private void cmdNo_Click(object sender,EventArgs e)
        {
        this.Close();
        }

        private void cmdYes_Click(object sender,EventArgs e)
        {
            try
            {
            this.Cursor=Cursors.WaitCursor;
            using (Database db = new Database())
            {
            DataTable dt=new DataTable();
            db.Commands.Add(db.CreateCommand("rsp_StandarStok_BelumLinkKePBO"));
            dt=db.Commands[0].ExecuteDataTable();

            if(dt.Rows.Count==0)
            {
            MessageBox.Show("Tidak Ada Data");
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

        private void frmRptStandarStokTipisBelumLink_Load(object sender,EventArgs e)
        {

        }
    }
}
