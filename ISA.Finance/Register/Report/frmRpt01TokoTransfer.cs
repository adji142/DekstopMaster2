using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;
using System.Data.SqlTypes;

namespace ISA.Finance.Register.Report
{
    public partial class frmRpt01TokoTransfer : ISA.Finance.BaseForm
    {

        private void DisplayReport(DataSet ds)
        {

            try
            {

                DateTime da = (DateTime)rangeDateBox1.FromDate;
                DateTime da2 = (DateTime)rangeDateBox1.ToDate;

                string periode = string.Empty;
                periode = String.Format("PERIODE : {0} s/d {1}", da.ToString("dd/MM/yyyy"), da2.ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));


                List<DataTable> pTable = new List<DataTable>();
                pTable.Add(ds.Tables[0]);
                pTable.Add(ds.Tables[1]);
                pTable.Add(ds.Tables[2]);

                List<string> pDatasetName = new List<string>();
                pDatasetName.Add("dsTagihan_Data");
                pDatasetName.Add("dsTagihan_Data1");
                pDatasetName.Add("dsTagihan_Data2");

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Register.Report.rpt01TokoTransfer.rdlc", rptParams, pTable, pDatasetName);
                ifrmReport.Text = "Toko Transfer";
                ifrmReport.Show();


            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        public frmRpt01TokoTransfer()
        {
            InitializeComponent();
        }

        private void frmRpt01TokoTransfer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.FromDate = DateTime.Now.AddDays(+1).AddMonths(-3);
            rangeDateBox1.Enabled = false;
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_Tagihan_01TokoTransfer]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));

                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0 && ds.Tables[1].Rows.Count == 0 && ds.Tables[2].Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                // dt.DefaultView.Sort = cboSort.SelectedValue.ToString();
                DisplayReport(ds);
            }
            catch (System.Exception ex)
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
