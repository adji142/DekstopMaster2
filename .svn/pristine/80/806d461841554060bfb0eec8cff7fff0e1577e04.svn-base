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

namespace ISA.Trading.Laporan.Salesman
{
    public partial class frmRptPerbandinganDONotaBO : ISA.Trading.BaseForm
    {

        private void DisplayReport(DataTable dt, DataTable dt2)
        {
        /*string periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
        //construct parameter
        List<ReportParameter> rptParams=new List<ReportParameter>();
        rptParams.Add(new ReportParameter("UserID",SecurityManager.UserID));
        rptParams.Add(new ReportParameter("Periode", periode));

        //call report viewer
        frmReportViewer ifrmReport=new frmReportViewer("Laporan.Salesman.rptPerbandinganDONotaBO.rdlc",rptParams,dt,"dsOrderPenjualan_Data");
        ifrmReport.Show();
        */

        string periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
        List<ReportParameter> rptParams = new List<ReportParameter>();
        rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
        rptParams.Add(new ReportParameter("periode", periode));
        rptParams.Add(new ReportParameter("Cabang", GlobalVar.Gudang));
        frmReportViewer ifrmReport;
        frmReportViewer ifrmReportRekap;

        if (RB_Salesman.Checked == true)
        {
            ifrmReportRekap = new frmReportViewer("Laporan.Salesman.rptPerbandinganSODONotaBORekap.rdlc", rptParams, dt, "dsOrderPenjualan_Data4");
            ifrmReport = new frmReportViewer("Laporan.Salesman.rptPerbandinganSODONotaBO.rdlc", rptParams, dt, "dsOrderPenjualan_Data4");
            ifrmReportRekap.Show();
        }
        else
        {
            ifrmReportRekap = new frmReportViewer("Laporan.Salesman.rptPerbandinganSODONotaBORekap_Toko.rdlc", rptParams, dt, "dsOrderPenjualan_Data4");
            ifrmReport = new frmReportViewer("Laporan.Salesman.rptPerbandinganSODONotaBO_Toko.rdlc", rptParams, dt, "dsOrderPenjualan_Data4");
            ifrmReportRekap.Show();
        }

        ifrmReport.Show();
        //ifrmReport.ExportToExcelAndSend("Laporan Salesman", "Laporan Salesman_" + periode);
        frmReportViewer ifrmReport2 = new frmReportViewer("Laporan.Salesman.rptLapSalesmanDOBONotaDetail.rdlc", rptParams, dt2, "dsOrderPenjualan_DOBONotaDetail");
        ifrmReport2.Show();
        //ifrmReport.ExportToExcelAndSend("Laporan Salesman Detail", "Laporan Salesman_" + periode);
        }


        public void DisplayReportSalesAuto(string fileName, string fileName2, DataTable dt, DataTable dt2, DateTime d1, DateTime d2)
        {
            string periode = String.Format("{0} s/d {1}", ((DateTime)d1).ToString("dd/MM/yyyy"), ((DateTime)d2).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("periode", periode));
            rptParams.Add(new ReportParameter("Cabang", GlobalVar.Gudang));
            frmReportViewer ifrmReport;

            ifrmReport = new frmReportViewer("Laporan.Salesman.rptPerbandinganSODONotaBO.rdlc", rptParams, dt, "dsOrderPenjualan_SODONotaBO");
            ifrmReport.ExportToExcelAuto(fileName);

            frmReportViewer ifrmReport2 = new frmReportViewer("Laporan.Salesman.rptLapSalesmanDOBONotaDetail.rdlc", rptParams, dt2, "dsOrderPenjualan_DOBONotaDetail");
            ifrmReport2.ExportToExcelAuto(fileName2);
        }

        private void ReloadCBOKel()
        {
            try
            {
                this.Cursor=Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt=new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));
                    dt=db.Commands[0].ExecuteDataTable();
                    dt.Rows.Add("");
                    dt.DefaultView.Sort = "kelompokBrgID ASC";
                    cboKel.ValueMember="kelompokBrgID";
                    cboKel.DisplayMember="kelompokBrgID";
                    cboKel.DataSource=dt;
                }
            }
            
            catch(Exception ex)
            {
                Error.LogError(ex);
            }
            
            finally
            {
                this.Cursor=Cursors.Default;
            }
        }

        public frmRptPerbandinganDONotaBO()
        {
            InitializeComponent();
        }

        private void frmRptPerbandinganDONotaBO_Load(object sender,EventArgs e)
        {
            rangeDateBox1.FromDate=new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
            rangeDateBox1.ToDate=DateTime.Now;
            ReloadCBOKel();
            RB_Salesman.Checked = true;
        }

        private void cmdNo_Click(object sender,EventArgs e)
        
        {
            this.Close();
        }

        private void cmdYes_Click(object sender,EventArgs e)
        {
            /*
            try
                {                
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                        {
                        
                        db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_PerbandinganDONotaBO"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime,rangeDateBox1.FromDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime,rangeDateBox1.ToDate.Value));
            			db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar,GlobalVar.CabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@initPers", SqlDbType.VarChar, lookupGudang1.InitPerusahaan));
                        db.Commands[0].Parameters.Add(new Parameter("@KelompokBarang", SqlDbType.VarChar,cboKel.Text.Trim()));
            
                        dt = db.Commands[0].ExecuteDataTable();
                        }
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No Data");
                        return;
                    }
                    DisplayReport(dt);

                }
            catch (Exception ex)
                {
            		Error.LogError(ex);
                }
            finally
                {
                   this.Cursor = Cursors.Default;
                }
                   */
                
            try
                {     
           
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    using (Database db = new Database())                       
                    {

                        db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_PerbandinganSODONotaBO"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime,rangeDateBox1.ToDate.Value));
            			db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar,GlobalVar.CabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@initPers", SqlDbType.VarChar, GlobalVar.PerusahaanID)); // <- Source Ini Dari ISA / ISA CABANG
                      //db.Commands[0].Parameters.Add(new Parameter("@initPers", SqlDbType.VarChar, lookupGudang1.InitPerusahaan)); -> perbedaan object value <- source ini dari ISA RETAIL DEPO
                        db.Commands[0].Parameters.Add(new Parameter("@KelompokBarang", SqlDbType.VarChar,cboKel.Text));

                        if (RB_Salesman.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@Jenis", SqlDbType.Int, 0));
                        }
                        else
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@Jenis", SqlDbType.Int, 1));
                        }

                        ds = db.Commands[0].ExecuteDataSet();
                    }

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No Data");
                        return;
                    }
                    DisplayReport(ds.Tables[0], ds.Tables[1]);
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
