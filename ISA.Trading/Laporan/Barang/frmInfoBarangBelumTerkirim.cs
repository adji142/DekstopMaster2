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
    public partial class frmInfoBarangBelumTerkirim : ISA.Trading.BaseForm
    {
        public frmInfoBarangBelumTerkirim()
        {
            InitializeComponent();
        }

        private void frmInfoBarangBelumTerkirim_Load(object sender, EventArgs e)
        {
            rdbTglDO.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTglDO.ToDate = DateTime.Now;
           

            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();

                    object[] a = { "", "" };
                    dt.Rows.Add(a);

                    cboKelompok.DataSource = dt;
                    cboKelompok.DisplayMember = "kelompokBrgID";
                    cboKelompok.ValueMember = "kelompokBrgID";
                    //cboKelompok.SelectedIndex = -1;
                    cboKelompok.SelectedValue = "";
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            rdoHBeli.Checked = true;

        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            string optHPP;

            if (rdoHBeli.Checked)
            {
                optHPP = "";
            }
            else
            {
                optHPP = "avg";
            }


            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Barang_BarangBelumTerkirim"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTglDO.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@optHPP", SqlDbType.VarChar, optHPP));
                    if (!string.IsNullOrEmpty(cboKelompok.Text))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@cKel", SqlDbType.VarChar, cboKelompok.SelectedValue));
                    }

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
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTglDO.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglDO.ToDate).ToString("dd/MM/yyyy"));
            
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID));
            if (cboKelompok.SelectedIndex >= 0)
            {
                rptParams.Add(new ReportParameter("KelBrg", cboKelompok.SelectedValue.ToString()));
            }
            else
            {
                rptParams.Add(new ReportParameter("KelBrg", "All"));
            }
            rptParams.Add(new ReportParameter("Periode", periode));
            

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptInfoBarangBelumTerkirim.rdlc", rptParams, dt, "dsLaporanBarang_Data");
            ifrmReport.Show();
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
