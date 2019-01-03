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
    public partial class frmRptPembPerBarangFilter : ISA.Trading.BaseForm
    {
        public frmRptPembPerBarangFilter()
        {
            InitializeComponent();
        }

        private void frmPembelianPerBarangFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Laporan Pembelian per Barang";
            this.Text = "Pembelian";
            rdbTglTerima.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTglTerima.ToDate = DateTime.Now;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtGudang = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Gudang_LIST"));
                    dtGudang = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "GudangID + ' | ' + NamaGudang");
                dtGudang.Columns.Add(cConcatenated);
                dtGudang.Rows.Add("");
                dtGudang.DefaultView.Sort = "GudangID ASC";
                cboGudang.DataSource = dtGudang;
                cboGudang.DisplayMember = "Concatenated";
                cboGudang.ValueMember = "GudangID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            rdoHrgBeli.Checked = true;
            rdbTglTerima.Focus();
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbTglTerima.FromDate.ToString() == "" || rdbTglTerima.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTglTerima, "Range Tgl.Terima masih kosong");
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
                    db.Commands.Add(db.CreateCommand("rsp_Pembelian_PembelianPerBarang"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTglTerima.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTglTerima.ToDate));

                    //if (rdoHPPA.Checked)
                    //    db.Commands[0].Parameters.Add(new Parameter("@tipeHPP", SqlDbType.VarChar, "AVG"));
                    if (cboGudang.SelectedValue.ToString() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, cboGudang.SelectedValue.ToString()));

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
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTglTerima.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglTerima.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptPembPerBarang.rdlc", rptParams, dt, "dsNotaPembelian_Data");
            ifrmReport.Show();

        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
