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

namespace ISA.Toko.Laporan.Toko
{
    public partial class frmRptPengirimanGudangFilter : ISA.Toko.BaseForm
    {
        public frmRptPengirimanGudangFilter()
        {
            InitializeComponent();
        }

        private void frmRptPengirimanGudangFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Pengiriman Gudang";
            this.Title = "Laporan";
            txtTgl.DateValue = DateTime.Now;
            txtTgl.Focus();
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (txtTgl.DateValue.ToString() == "")
            {
                errorProvider1.SetError(txtTgl, "Tanggal masih kosong");
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
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_PengirimanGudang"));
                    db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, txtTgl.DateValue));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    dt.DefaultView.Sort = "NoSuratJalan ASC";
                    DisplayReport(dt.DefaultView.ToTable());
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
            string tanggal;
            tanggal = ((DateTime)txtTgl.DateValue).ToString("dd/MM/yyyy");
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Tanggal", tanggal));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptPengirimanGudang.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();

        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
