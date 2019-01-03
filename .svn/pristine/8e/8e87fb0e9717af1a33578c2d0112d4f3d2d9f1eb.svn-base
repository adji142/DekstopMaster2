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
    public partial class frmRptRegisterReturJual : ISA.Toko.BaseForm
    {
        public frmRptRegisterReturJual()
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

        private void frmRptRegisterReturJual_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
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
                this.Cursor = Cursors.WaitCursor;DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_RegisterReturJualHPP"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    if (lookupGudang.GudangID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, lookupGudang.GudangID));
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

        private void DisplayReport(DataTable dt)
        {
            string periode;
            string option;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));

            if (lookupGudang.GudangID != "")
            {
                option = lookupGudang.GudangID;
            }
            else
            {
                option = GlobalVar.CabangID;
            }

       
            rptParams.Add(new ReportParameter("Option", option));
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Salesman.rptRegisterReturJual.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }
    }
}
