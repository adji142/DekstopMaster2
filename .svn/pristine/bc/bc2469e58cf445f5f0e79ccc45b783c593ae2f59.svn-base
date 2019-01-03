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

namespace ISA.Trading.Laporan.Toko
{
    public partial class frmRptOmzetABETokoFilter : ISA.Trading.BaseForm
    {
        public frmRptOmzetABETokoFilter()
        {
            InitializeComponent();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                string type = "A";
                if (rbBruto.Checked)
                {
                    type = "B";
                }
                else if (rbNetto.Checked)
                {
                    type = "N";
                }

                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_OmzetABEToko"));
                    db.Commands[0].Parameters.Add(new Parameter("@dateFrom", SqlDbType.DateTime, rangeOmzet.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@dateTo", SqlDbType.DateTime, rangeOmzet.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    //db.Commands[0].Parameters.Add(new Parameter("@wilID", SqlDbType.VarChar, cbWilID.WilID));
                    db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, GlobalVar.CabangID));
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

        private void DisplayReport(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeOmzet.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeOmzet.ToDate).ToString("dd/MM/yyyy"));

            string type = "Semua";
            //if (rbBruto.Checked)
            //{
            //    type = "Bruto";
            //}
            //else if (rbNetto.Checked)
            //{
            //    type = "Netto";
            //}

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Sales", string.IsNullOrEmpty(lookupSales.SalesID)==true? "Semua" : lookupSales.SalesID));
            rptParams.Add(new ReportParameter("Wilayah", ""/*string.IsNullOrEmpty(cbWilID.WilID)==true? "Semua" : cbWilID.WilID*/));
            rptParams.Add(new ReportParameter("Type", type));

            //call report viewer
            if (type.Equals("Semua"))
            {
                frmReportViewer ifrmReportAll = new frmReportViewer("Laporan.Toko.rptOmzetABETokoAllOmzet.rdlc", rptParams, dt, "dsToko_Data");
                ifrmReportAll.Show();
            }
            else
            {
                frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptOmzetABEToko.rdlc", rptParams, dt, "dsToko_Data");
                ifrmReport.Show();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptOmzetABETokoFilter_Load(object sender, EventArgs e)
        {
            rangeOmzet.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeOmzet.ToDate = new DateTime(rangeOmzet.FromDate.Value.Year, rangeOmzet.FromDate.Value.Month + 1, 1).AddDays(-1);

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtPostArea = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_WilayahID_LIST"));
                    dtPostArea = db.Commands[0].ExecuteDataTable();
                }
                dtPostArea.Rows.Add("");
                dtPostArea.DefaultView.Sort = "WilID ASC";
                cbWilID.DataSource = dtPostArea;
                cbWilID.DisplayMember = "WilID";
                cbWilID.ValueMember = "WilID";
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


    }
}
