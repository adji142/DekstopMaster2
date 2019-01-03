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

namespace ISA.Toko.LapKpl
{
    public partial class frmRptTargetSales : ISA.Toko.BaseForm
    {
        DataSet ds = new DataSet();
        public frmRptTargetSales()
        {
            InitializeComponent();
        }

        private void cmdyes_Click(object sender, EventArgs e)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_TargetSales_Analisa]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate2", SqlDbType.DateTime, rangeDateBox2.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate2", SqlDbType.DateTime, rangeDateBox2.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    if (this.rdbDO.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Option", SqlDbType.Int, 1));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Option", SqlDbType.Int, 2));
                    }
                    if (rdbOverdueF.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Overdue", SqlDbType.Int, 0));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Overdue", SqlDbType.Int, 1));
                    }

                    ds = db.Commands[0].ExecuteDataSet();
                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data...!");
                    return;
                }
                DisplayReport();
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

        private void frmRptTargetSales_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox2.FromDate= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox2.ToDate= DateTime.Now;

            rdbDO.Checked = true;
            rdbOverdueF.Checked = true;

        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayReport()
        {
            string periode;
            string Level;
            string type = "DO";
            if (rdbNota.Checked)
                type = "NOTA";
            Level = SecurityManager.IsManager().ToString();
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            string periode2 = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox2.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox2.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Manager", Level));
            rptParams.Add(new ReportParameter("Periode1", periode));
            rptParams.Add(new ReportParameter("Periode2", periode2));
            rptParams.Add(new ReportParameter("Type", type));

            rptParams.Add(new ReportParameter("TotalQty1", Convert.ToInt32(ds.Tables[1].Rows[0][0]).ToString("#,##0")));
            rptParams.Add(new ReportParameter("TotalQty2", Convert.ToInt32(ds.Tables[1].Rows[0][1]).ToString("#,##0")));

            //call report viewer
            List<DataTable> pTable = new List<DataTable>();
            pTable.Add(ds.Tables[0]);
            pTable.Add(ds.Tables[0]);
            pTable.Add(ds.Tables[0]);
            pTable.Add(ds.Tables[0]);
            pTable.Add(ds.Tables[0]);
            pTable.Add(ds.Tables[0]);
            pTable.Add(ds.Tables[0]);

            List<string> pDatasetName = new List<string>();
            pDatasetName.Add("dsSales_Data");
            pDatasetName.Add("dsSales_Data1");
            pDatasetName.Add("dsSales_Data2");
            pDatasetName.Add("dsSales_Data3");
            pDatasetName.Add("dsSales_Data4");
            pDatasetName.Add("dsSales_Data5");
            pDatasetName.Add("dsPinjam_Data");
            frmReportViewer ifrmReport = new frmReportViewer("LapKpl.rptTargetSales.rdlc", rptParams, pTable, pDatasetName);
            ifrmReport.Show();

        }


    }
}
