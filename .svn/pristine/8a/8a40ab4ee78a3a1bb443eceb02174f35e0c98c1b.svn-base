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
    public partial class frmRpt08InfoTagih : ISA.Finance.BaseForm
    {
        private void DisplayReport(DataSet ds)
        {

            try
            {

                DateTime da = (DateTime)dateTextBox1.DateValue;
                DateTime da2 = (DateTime)dateTextBox2.DateValue;

                string periode = string.Empty;
                periode = String.Format("PERIODE : {0} s/d {1}", da.ToString("dd/MM/yyyy"), da2.ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("WilID", textBox1.Text.Trim()=="" ? "ALL":textBox1.Text.Trim()));


                List<DataTable> pTable = new List<DataTable>();
                pTable.Add(ds.Tables[0]);

                List<string> pDatasetName = new List<string>();
                pDatasetName.Add("dsTagihan_Data2");

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Register.Report.rpt08InfoTagih.rdlc", rptParams, pTable, pDatasetName);
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

        public frmRpt08InfoTagih()
        {
            InitializeComponent();
        }

        private void frmRpt08InfoTagih_Load(object sender, EventArgs e)
        {
             this.WindowState = FormWindowState.Normal;
            dateTextBox1.DateValue = DateTime.Now;
            dateTextBox2.DateValue = dateTextBox1.DateValue.Value.AddDays(+6);

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

                    db.Commands.Add(db.CreateCommand("[rsp_Tagihan_08InfoTagih]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, dateTextBox2.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, textBox1.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Jt", SqlDbType.Bit, rdb1Lwt.Checked? 1:0));

                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
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

        private void dateTextBox1_Validated(object sender, EventArgs e)
        {
            if (dateTextBox1.DateValue.HasValue==false)
            {
                errorProvider1.SetError(dateTextBox1, " Harap Di isi ");
            }else
            {
                dateTextBox2.DateValue = dateTextBox1.DateValue.Value.AddDays(+6);
            }
        }
    }
}
