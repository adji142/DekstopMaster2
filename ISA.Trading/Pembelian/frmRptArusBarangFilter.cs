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

namespace ISA.Trading.Pembelian
{
    public partial class frmRptArusBarangFilter : ISA.Trading.BaseForm
    {
        public frmRptArusBarangFilter()
        {
            InitializeComponent();
        }

        private void frmRptArusBarangFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Laporan Arus Barang";
            this.Text = "Pembelian";
            txtTglTerima.DateValue = DateTime.Now;
            txtTglTerima.Focus();
        }

        private void txtTglTerima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdYES.PerformClick();
            }
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (txtTglTerima.Text == "")
            {
                errorProvider1.SetError(txtTglTerima, "TglTerima masih kosong");
                valid = false;
            }

            return valid;
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
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
                    db.Commands.Add(db.CreateCommand("rsp_Pembelian_ArusBarang"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, txtTglTerima.DateValue));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReport(dt);
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
            //construct parameter
            string tgl;
            tgl = ((DateTime)txtTglTerima.DateValue).ToString("dd/MM/yyyy");
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("TglTerima", tgl));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptArusBarang.rdlc", rptParams, dt, "dsNotaPembelian_Data");
            ifrmReport.Show();

        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
