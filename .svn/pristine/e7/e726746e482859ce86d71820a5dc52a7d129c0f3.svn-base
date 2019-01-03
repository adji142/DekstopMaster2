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
    public partial class frmRptStokOpnameAnalisaDetail : ISA.Toko.BaseForm
    {

        private void DisplayReport(DataTable dt)
        {

            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Persediaan.rptAnalisaPerbandinganStokOpnameDetail.rdlc", rptParams, dt, "dsOpname_Data");
            ifrmReport.Show();

        }

        private void ReloadCBO()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    object[] a = { "", "" };
                    dt.Rows.Add(a);
                    cboKelompokBarang.ValueMember = "kelompokBrgID";
                    cboKelompokBarang.DisplayMember = "kelompokBrgID";
                    cboKelompokBarang.DataSource = dt;
                    cboKelompokBarang.SelectedValue = "";
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


        public frmRptStokOpnameAnalisaDetail()
        {
            InitializeComponent();
        }

        private void frmRptStokOpnameAnalisaDetail_Load(object sender, EventArgs e)
        {
            ReloadCBO();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_Opname_AnalisaDetail"));
                    if (!string.IsNullOrEmpty(cboKelompokBarang.Text))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KelompokBarang", SqlDbType.VarChar, cboKelompokBarang.Text));
                    }
                    if (!string.IsNullOrEmpty(lookupStock.Text))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@NamaStok", SqlDbType.VarChar, lookupStock.Text));
                    }
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Tidak Ada Data");
                        return;
                    }
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
    }
}
