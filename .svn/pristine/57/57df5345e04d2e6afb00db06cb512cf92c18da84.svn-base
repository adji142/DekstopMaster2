using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;
using ISA.DAL;

namespace ISA.Finance.GL
{
    public partial class frmRptAuditTrans : ISA.Finance.BaseForm
    {

        private void DisplayReport(DataSet ds)
        {
            try
            {

                string periode = string.Empty;
                periode = String.Format("{0} s/d {1} ", rangeDateBox1.FromDate.Value.ToString("dd-MMM-yyyy"), rangeDateBox1.ToDate.Value.ToString("dd-MMM-yyyy"));

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                //call report viewer

                //List<DataTable> pTable = new List<DataTable>();
                //pTable.Add(ds.Tables[0]);
                //pTable.Add(ds.Tables[1]);
                ////  pTable.Add(ds.Tables[1]);

                //List<string> pDatasetName = new List<string>();
                //pDatasetName.Add("dsJurnal.xsd");
                //pDatasetName.Add("dsJurnal.xsd");
                // pDatasetName.Add("dsSetoran_Data1");

                frmReportViewer ifrmReport = new frmReportViewer("GL.rptAuditTrans1.rdlc", rptParams, ds.Tables[0], "dsJurnal_Data");
                ifrmReport.Text = "NotBalance";
                ifrmReport.Show();

                frmReportViewer ifrmReport2 = new frmReportViewer("GL.rptAuditTrans2.rdlc", rptParams, ds.Tables[1], "dsJurnal_Journal");
                ifrmReport2.Text = "NoMasterPerk";
                ifrmReport2.Show();


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

        public frmRptAuditTrans()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptAuditTrans_Load(object sender, EventArgs e)
        {
            this.rangeDateBox1.ToDate = DateTime.Now;
            this.rangeDateBox1.FromDate = DateTime.Now.AddYears(-1);
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_Journal_AuditTrans"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime,rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0 && ds.Tables[1].Rows.Count==0)
                {
                    MessageBox.Show("Semua journal balance","Balance");
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
