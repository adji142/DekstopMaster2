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

namespace ISA.Trading.Laporan.Barang
{
    public partial class frmRptGabunganSemuaOrder : ISA.Trading.BaseForm
    {
        public frmRptGabunganSemuaOrder()
        {
            InitializeComponent();
        }

        private void frmRptGabunganSemuaOrder_Load(object sender, EventArgs e)
        {
            rdbDate.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbDate.ToDate = DateTime.Now;
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbDate.FromDate.ToString() == "" || rdbDate.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbDate, "Range Tanggal masih kosong");
                valid = false;
            }

            return valid;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            string kodeToko = Convert.ToString(listToko.KodeToko);
            string kodeSales = Convert.ToString(listSales.SalesID);
            string barangID = Convert.ToString(listStok.BarangID);
            
            if (!ValidateInput())
            {
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Barang_GabunganSemuaOrder"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rdbDate.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbDate.ToDate.Value));
                    if (listToko.NamaToko.Trim() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, listToko.KodeToko));
                    }
                    if (listSales.NamaSales.Trim() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, listSales.SalesID));
                    }
                    if (listStok.NamaStock.Trim() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, listStok.BarangID));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
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

            periode = String.Format("{0} s/d {1}", ((DateTime)rdbDate.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbDate.ToDate).ToString("dd/MM/yyyy"));

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID));
            rptParams.Add(new ReportParameter("Periode", periode));
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptGabunganSemuaOrder.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Show();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
