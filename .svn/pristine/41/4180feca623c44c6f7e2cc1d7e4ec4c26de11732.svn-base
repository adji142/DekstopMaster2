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
    public partial class frmRpt07RealisasiRencanaTagih : ISA.Finance.BaseForm
    {
        string tipe = string.Empty;
        public frmRpt07RealisasiRencanaTagih()
        {
            InitializeComponent();
        }


        private void frmRpt07RealisasiRencanaTagih_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            dateTextBox1.DateValue = DateTime.Now;
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            tipe =  rdbRekap.Checked? "b": (rdbDetail1.Checked ? "a":"b")  ;

           switch (tipe)
           {
           case "a":
                   GenerateReportA();
           	break;
           case "b":
            GenerateReportB();
            break;

           }
        }


        private void GenerateReportA()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_Tagihan_07RealisasiTagihA]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@InitUser", SqlDbType.VarChar,SecurityManager.UserInitial));
                    db.Commands[0].Parameters.Add(new Parameter("@Ovd", SqlDbType.Int, rdb1.Checked ? 1 : (rdb2.Checked ? 2:3)));
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

        private void GenerateReportB()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_Tagihan_07RealisasiTagihB]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@InitUser", SqlDbType.VarChar, SecurityManager.UserInitial));
                    db.Commands[0].Parameters.Add(new Parameter("@Ovd", SqlDbType.Int, rdb1.Checked ? 1 : (rdb2.Checked ? 2 : 3)));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0 && ds.Tables[1].Rows.Count == 0 && ds.Tables[2].Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                DisplayReport2(ds);
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

        private void DisplayReport(DataSet ds)
        {

            try
            {

                DateTime da = (DateTime)dateTextBox1.DateValue;
                DateTime da2 = (DateTime)dateTextBox1.DateValue;


                string periode = string.Empty;
                periode = String.Format("{0} s/d {1}", da.ToString("dd/MM/yyyy"), da2.ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Tittle", "LAPORAN EVALUASI TAGIHAN KOLEKTOR"));

                frmReportViewer ifrmReport1 = new frmReportViewer("Register.Report.rpt07RealisasiRencanaTagihA1.rdlc", rptParams, ds.Tables[0], "dsTagihan_Data2");
                ifrmReport1.Text = "Giro";
                ifrmReport1.Show();

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

        private void DisplayReport2(DataSet ds)
        {

            try
            {

                DateTime da = (DateTime)dateTextBox1.DateValue;
                DateTime da2 = (DateTime)dateTextBox1.DateValue;


                string periode = string.Empty;
                periode = String.Format("{0} s/d {1}", da.ToString("dd/MM/yyyy"), da2.ToString("dd/MM/yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("OVD", rdb1.Checked ? "PEMBAYARAN <= 7 Hari" : (rdb2.Checked ? "PEMBAYARAN > 7 Hari" : "")));
                rptParams.Add(new ReportParameter("Tittle", "REKAP TAGIHAN NOTA DAN BGC TOLAK (BARANG A)"));

                frmReportViewer ifrmReport1 = new frmReportViewer("Register.Report.rpt07RealisasiRencanaTagihB3.rdlc", rptParams, ds.Tables[0], "dsTagihan_Data2");
                ifrmReport1.Text = "Rekap Brg-A";
                ifrmReport1.Show();

                rptParams.RemoveAt(2);
                rptParams.Add(new ReportParameter("Tittle", "REKAP TAGIHAN NOTA DAN BGC TOLAK (BARANG B-E)"));
                frmReportViewer ifrmReport2 = new frmReportViewer("Register.Report.rpt07RealisasiRencanaTagihB3.rdlc", rptParams, ds.Tables[1], "dsTagihan_Data2");
                ifrmReport2.Text = "Rekap Brg-BE";
                ifrmReport2.Show();


                rptParams.RemoveAt(2);
                rptParams.Add(new ReportParameter("Tittle", "REKAP TAGIHAN NOTA DAN BGC TOLAK"));
                frmReportViewer ifrmReport3 = new frmReportViewer("Register.Report.rpt07RealisasiRencanaTagihB3.rdlc", rptParams, ds.Tables[2], "dsTagihan_Data2");
                ifrmReport3.Text = "Rekap Nota & Bgc";
                ifrmReport3.Show();

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

        private void rdbRekap_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRekap.Checked)
            {
                groupBox3.Enabled = false;
            } 
            else
            {
                groupBox3.Enabled = true;
            }
        }

        private void rdbDetil_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDetil.Checked)
            {
                groupBox3.Enabled = true;
            }
            else
            {
                groupBox3.Enabled = false;
            }
        }
    }
}
