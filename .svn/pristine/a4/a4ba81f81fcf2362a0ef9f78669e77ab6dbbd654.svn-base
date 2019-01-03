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
using System.Data.SqlTypes;

namespace ISA.Trading.Bonus
{
    public partial class frmTransferDataPengajuanFilter : ISA.Trading.BaseForm
    {
        public frmTransferDataPengajuanFilter()
        {
            InitializeComponent();
        }

        private void frmTransferDataPengajuanFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Transfer Data Pengajuan Bonus ke 11";
            this.Text = "Bonus";
            rgbPeriode.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbPeriode.ToDate = ((DateTime)rgbPeriode.FromDate).AddMonths(1).AddDays(-1);
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rgbPeriode.FromDate.ToString() == "" || rgbPeriode.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rgbPeriode, "Periode masih kosong");
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
                    db.Commands.Add(db.CreateCommand("rsp_Bonus_TransferDataPengajuan"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbPeriode.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbPeriode.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data...");
                }
                else 
                {
                    DisplayReport(dt);

                    if (MessageBox.Show("Update perolehan bonus", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        UpdateTablePerolehanBonus(dt);
                    }
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
            periode = String.Format("{0} s/d {1}", ((DateTime)rgbPeriode.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rgbPeriode.ToDate).ToString("dd/MM/yyyy"));

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Bonus.rptPerolehanBonusPenjualan.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }

        private void UpdateTablePerolehanBonus(DataTable dt)
        {
            try
            {
                this.Cursor = Cursors.Default;
                using (Database db = new Database())
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        db.Commands.Add(db.CreateCommand("usp_PerolehanBonusSales_UPDATE_ForTransfer"));
                        db.Commands[i].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, dt.Rows[i]["KodeSales"]));
                        db.Commands[i].Parameters.Add(new Parameter("@periode", SqlDbType.VarChar, dt.Rows[i]["Periode"]));
                        db.Commands[i].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, dt.Rows[i]["Tanggal"]));
                        db.Commands[i].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, ""));
                        db.Commands[i].Parameters.Add(new Parameter("@tglACC", SqlDbType.DateTime, SqlDateTime.Null));
                        db.Commands[i].Parameters.Add(new Parameter("@rpBonus", SqlDbType.Money, dt.Rows[i]["NilaiBonus"]));
                        db.Commands[i].Parameters.Add(new Parameter("@rpACC", SqlDbType.Money, 0.0));
                        db.Commands[i].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, ""));
                        db.Commands[i].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 0));
                        db.Commands[i].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, ""));
                        db.Commands[i].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    }

                    db.BeginTransaction();
                    for (int j = 0; j < db.Commands.Count; j++)
                    {
                        db.Commands[j].ExecuteNonQuery();
                    }
                    db.CommitTransaction();
                }
                MessageBox.Show("Data telah disimpan");
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
