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
    public partial class frmRptJWJSFilter : ISA.Toko.BaseForm
    {
        public frmRptJWJSFilter()
        {
            InitializeComponent();
        }

        private void frmRptJWJSFilter_Load(object sender, EventArgs e)
        {
            this.Title = "JW / JS";
            this.Text = "Laporan";
            rdbTgl.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTgl.ToDate = DateTime.Now;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtCabang = new DataTable();
                DataTable dtTransType = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    db.Commands.Add(db.CreateCommand("usp_TransactionType_LIST"));
                    dtCabang = db.Commands[0].ExecuteDataTable();
                    dtTransType = db.Commands[1].ExecuteDataTable();
                }
                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "CabangID + ' | ' + Nama");
                dtCabang.Columns.Add(cConcatenated);
                dtCabang.DefaultView.Sort = "CabangID ASC";
                cboCabang.DataSource = dtCabang;
                cboCabang.DisplayMember = "Concatenated";
                cboCabang.ValueMember = "CabangID";

                cboCabang.SelectedValue = GlobalVar.CabangID;

                cboKodeTrans.DataSource = dtTransType;
                cboKodeTrans.DisplayMember = "Kode";
                cboKodeTrans.ValueMember = "Kode";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

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
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_JWJS"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTgl.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTgl.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, cboKodeTrans.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, cboCabang.SelectedValue.ToString()));

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
            string cabang = cboCabang.SelectedValue.ToString();
            string kodeTrans = cboKodeTrans.SelectedValue.ToString();

            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTgl.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTgl.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("TransactionType", kodeTrans));
            rptParams.Add(new ReportParameter("Cabang", cabang));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptJWJS.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();

        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
