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

namespace ISA.Trading.Expedisi
{
    public partial class frmRptEkspedisiSuratJalan : ISA.Trading.BaseForm
    {

#region "Function"
        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string periode;
            string title = "";
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
        
          
            //call report viewer
            if (rdoTerkirim.Checked==true)
            {
                frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptEkspedisiSuratJalan.rdlc", rptParams, dt, "dsEkspedisi_Data");
                ifrmReport.Show();
            }
           
            if (rdoPending.Checked==true)
            {
                frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptEkspedisiSuratJalan2.rdlc", rptParams, dt, "dsEkspedisi_Data");
                ifrmReport.Show();
            }
            if (rdoBelumDikirim.Checked == true)
            {
                frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptEkspedisiSuratJalan3.rdlc", rptParams, dt, "dsEkspedisi_Data");
                ifrmReport.Show();
            }


        }

        private void ReportBarangTerkirim()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_Expedisi_SuratJalanTerkirim]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));

                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    DisplayReport(dt);

                }
                else
                {
                    MessageBox.Show("no data");
                    return;
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

        private void ReportBarangPending()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    

                    db.Commands.Add(db.CreateCommand("[rsp_Expedisi_SuratJalanPending]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));

                    dt = db.Commands[0].ExecuteDataTable();
              

                }
                if (dt.Rows.Count > 0)
                {
                    DisplayReport(dt);

                }else
                {
                    MessageBox.Show("no data");
                    return;
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

        private void ReportBarangBelumTerkirim()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                   

                    db.Commands.Add(db.CreateCommand("[rsp_Expedisi_SuratJalanBelumDiKirim]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));

                    dt = db.Commands[0].ExecuteDataTable();
                  
                }
                if (dt.Rows.Count > 0)
                {
                    DisplayReport(dt);

                }
                else
                {
                    MessageBox.Show("no data");
                    return;
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
#endregion
        public frmRptEkspedisiSuratJalan()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
          if (rdoTerkirim.Checked==true)
          {
              ReportBarangTerkirim();
          }else

          if (rdoPending.Checked == true)
          {
              ReportBarangPending();
          }
           else if (rdoBelumDikirim.Checked == true)
          {
              ReportBarangBelumTerkirim();
          }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptEkspedisiSuratJalan_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rdoTerkirim.Checked = true;
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (rdoTerkirim.Checked == true)
            {
                ReportBarangTerkirim();
            }
            else

                if (rdoPending.Checked == true)
                {
                    ReportBarangPending();
                }
                else if (rdoBelumDikirim.Checked == true)
                {
                    ReportBarangBelumTerkirim();
                }

        }
    }
}
