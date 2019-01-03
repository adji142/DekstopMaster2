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

namespace ISA.Toko.Bonus
{
    public partial class frmRptPerhitunganBonusFilter : ISA.Toko.BaseForm
    {
        DataSet ds;
        public frmRptPerhitunganBonusFilter()
        {
            InitializeComponent();
        }

        private void frmRptPerhitunganBonusFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Perhitungan Bonus";
            this.Text = "Bonus";
            rgbPeriode.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbPeriode.ToDate = ((DateTime)rgbPeriode.FromDate).AddMonths(1).AddDays(-1);
            LoadGroupNamaStokComboBox();
        }

        private void LoadGroupNamaStokComboBox()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtStokGroup = new DataTable();
                DataTable dtKlp = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_StokGroup_LIST"));
                    dtStokGroup = db.Commands[0].ExecuteDataTable();

                    db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));
                    dtKlp = db.Commands[1].ExecuteDataTable();
                }

                dtStokGroup.Rows.Add("");
                dtStokGroup.DefaultView.Sort = "NamaGroup ASC";
                cboGroupBrg.DataSource = dtStokGroup;
                cboGroupBrg.DisplayMember = "NamaGroup";
                cboGroupBrg.ValueMember = "StokGroupID";

                dtKlp.Rows.Add("");
                dtKlp.DefaultView.Sort = "KelompokBrgID ASC";
                cboKlp.DataSource = dtKlp;
                cboKlp.DisplayMember = "";
                cboKlp.ValueMember = "KelompokBrgID";
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
                ds = new DataSet();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Bonus_PerhitunganBonus"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbPeriode.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbPeriode.ToDate));

                    if (cboGroupBrg.SelectedValue.ToString() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@stokGroupID", SqlDbType.VarChar, cboGroupBrg.SelectedValue.ToString()));
                    if (lookupSales.NamaSales.Trim() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    if (lookupToko.NamaToko.Trim() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko.KodeToko));
                    if (cboKlp.SelectedValue.ToString() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@klp", SqlDbType.VarChar, cboKlp.SelectedValue.ToString()));

                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReport(ds);
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

        private void DisplayReport(DataSet ds)
        {
            //construct parameter
            string sales = "Semua";
            if (lookupSales.NamaSales.Trim() != "")
                sales = lookupSales.SalesID;
            string toko = "Semua";
            if (lookupToko.NamaToko.Trim() != "")
                toko = lookupToko.NamaToko;
            string klp = "Semua";
            if (cboKlp.SelectedValue.ToString() != "")
                klp = cboKlp.SelectedValue.ToString();

            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rgbPeriode.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rgbPeriode.ToDate).ToString("dd/MM/yyyy"));

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Sales", sales));
            rptParams.Add(new ReportParameter("KlpBarang", klp));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            List<DataTable> rptDt = new List<DataTable>();
            rptDt.Add(ds.Tables[0]);

            List<string> rptDs = new List<string>();
            rptDs.Add("dsNotaPenjualan_Data");

            if (ds.Tables.Count == 2)
            {
                rptDt.Add(ds.Tables[1]);
                rptDs.Add("dsNotaPenjualan_Data2");
            }
            else
            {
                DataTable dt = new DataTable();
                rptDt.Add(dt);
                rptDs.Add("dsNotaPenjualan_Data2");
            }

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Bonus.rptPerhitunganBonus.rdlc", rptParams, rptDt, rptDs);
            ifrmReport.Show();
            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
