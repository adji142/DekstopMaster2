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

namespace ISA.Toko.VLapW
{
    public partial class frmRptOmzetPerWilayahDetail : ISA.Toko.BaseForm
    {
        public frmRptOmzetPerWilayahDetail()
        {
            InitializeComponent();
        }

        private void frmRptOmzetPerWilayahDetail_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
            rdbToko.Checked = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (cabangComboBox1.CabangID=="")
            {
                cabangComboBox1.Focus();
                return;
            }

            if (txtKelompok.Text.Trim()=="")
            {
                txtKelompok.Focus();
            }

           if (rdbToko.Checked==true)
           {
               CetakToko();
           } else
           {
               CetakKota();
           }

        }

        private void DisplayReport(DataTable dt)
        {
            string periode;
            string option;
            string Init;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            option =  txtKelompok.Text;
            Init = GlobalVar.PerusahaanID;
            rptParams.Add(new ReportParameter("KLP", option));
            rptParams.Add(new ReportParameter("Init", Init));
            
            
            if (rdbToko.Checked==true)
            {
	            //call report viewer
	            frmReportViewer ifrmReport = new frmReportViewer("VLapW.rptOmzetPerWilayahDetailMenurutToko.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
	            ifrmReport.Show();
            }
            else
            {
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("VLapW.rptOmzetPerWilayahDetailMenurutKota.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
                ifrmReport.Show();
            }

        }

        private void CetakToko()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_VLapW_OmzetPerWilayahDetail_MenurutToko]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, cabangComboBox1.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@KLP", SqlDbType.VarChar, txtKelompok.Text));

                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count==0)
                {
                    MessageBox.Show("Tidak ada data...!");
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
        }

        private void CetakKota()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_VLapW_OmzetPerWilayahDetail_MenurutKota]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, cabangComboBox1.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@KLP", SqlDbType.VarChar, txtKelompok.Text));

                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data...!");
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
        }
    }
}
