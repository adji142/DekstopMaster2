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
    public partial class frmRpt09EvaluasiCollectorDetail : ISA.Finance.BaseForm
    {
        private void DisplayReport(DataSet ds)
        {

            try
            {

                DateTime da = (DateTime)rangeDateBox1.FromDate;
                DateTime da2 = (DateTime)rangeDateBox1.ToDate;


                string periode = string.Empty;
                periode = String.Format("{0} s/d {1}", da.ToString("dd/MM/yyyy"), da2.ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Tittle", "EVALUASI TAGIHAN KOLEKTOR DETAIL TOKO : "
                    + (textBox2.SelectedText==""?"" : " : "+textBox2.SelectedText.ToString())
                    ));
                rptParams.Add(new ReportParameter("v1", ds.Tables[1].Rows[0][0].ToString()));
                rptParams.Add(new ReportParameter("v2", ds.Tables[1].Rows[0][1].ToString()));
                rptParams.Add(new ReportParameter("v3", ds.Tables[1].Rows[0][2].ToString()));

                frmReportViewer ifrmReport = new frmReportViewer("Register.Report.rpt09EvaluasiCollectorDetail.rdlc", rptParams, ds.Tables[0], "dsTagihan_Data2");
                ifrmReport.Text = "LAPORAN EVALUASI TAGIHAN KOLEKTOR";
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


        private void GetCollector()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_Collector_LIST]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                //dt.Rows.Add("");
                dt.DefaultView.Sort = "Nama ASC";
                //textBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                textBox2.DataSource = dt;
                textBox2.DisplayMember = "Nama";
                textBox2.ValueMember = "Kode";
                textBox2.Text = "";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        public frmRpt09EvaluasiCollectorDetail()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRpt09EvaluasiCollectorDetail_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            GetCollector();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            //if (textBox2.SelectedValue.ToString()=="")
            //{
            //    ErrorProvider ep = new ErrorProvider();
            //    ep.SetError(textBox2, "Wajib di isi !!!");
            //    return;
            //}
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("rsp_Tagihan_09EvaluasiCollectorDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    if (textBox2.Text != "")
                        db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, textBox2.SelectedValue.ToString()));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

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
