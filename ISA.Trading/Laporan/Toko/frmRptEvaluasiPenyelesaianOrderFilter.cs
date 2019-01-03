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
    public partial class frmRptEvaluasiPenyelesaianOrderFilter : ISA.Trading.BaseForm
    {
        public frmRptEvaluasiPenyelesaianOrderFilter()
        {
            InitializeComponent();
        }

        private void frmRptEvaluasiPenyelesaianOrderFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Evaluasi Penyelesaian Order";
            this.Text = "Laporan";
            rdbTgl.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTgl.ToDate = DateTime.Now;
            rdoTglRQ.Checked = true;
            rdbTgl.Focus();
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbTgl.FromDate.ToString() == "" || rdbTgl.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTgl, "Range tanggal masih kosong");
                valid = false;
            }

            if (txtInitPrs.Text.Length != 3 && txtInitPrs.Text != "")
            {
                errorProvider1.SetError(txtInitPrs, "Initial Perusahaan panjangnya 3 character");
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

            string tipeTgl = "RQ";
            if (rdoTglDO.Checked)
                tipeTgl = "DO";
            if (rdoTglSJ.Checked)
                tipeTgl = "SJ";
            if (rdoTglNota.Checked)
                tipeTgl = "NT";
            if (rdoTglTerima.Checked)
                tipeTgl = "TR";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_EvaluasiPenyelesaianOrder"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTgl.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTgl.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@tipeTgl", SqlDbType.VarChar, tipeTgl));

                    if (postAreaComboBox.PostID != "")
                        db.Commands[0].Parameters.Add(new Parameter("@postID", SqlDbType.VarChar, postAreaComboBox.PostID));
                    if (cabangComboBox.CabangID != "")
                        db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, cabangComboBox.CabangID));
                    if (lookupSales.NamaSales != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    if (lookupToko.NamaToko != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko.KodeToko));
                    if (txtInitPrs.Text != "")
                        db.Commands[0].Parameters.Add(new Parameter("@initPrs", SqlDbType.VarChar, txtInitPrs.Text));

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
            string tipeTgl = "REQUEST ORDER";
            if (rdoTglDO.Checked)
                tipeTgl = "DELIVERY ORDER";
            if (rdoTglSJ.Checked)
                tipeTgl = "SURAT JALAN";
            if (rdoTglNota.Checked)
                tipeTgl = "PENGEMBALIAN NOTA";
            if (rdoTglTerima.Checked)
                tipeTgl = "TERIMA TOKO";

            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTgl.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTgl.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("TipeTgl", tipeTgl));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptEvaluasiPenyelesaianOrder.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();

        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
