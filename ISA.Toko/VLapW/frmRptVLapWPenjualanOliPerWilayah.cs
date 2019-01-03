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
    public partial class frmRptVLapWPenjualanOliPerWilayah : ISA.Toko.BaseForm
    {
        DataSet ds = new DataSet();
        private void ReloadCBO()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();

                    dt.Rows.Add("");
                    dt.DefaultView.Sort = "kelompokBrgID ASC";
                    cb.ValueMember = "kelompokBrgID";
                    cb.DisplayMember = "kelompokBrgID";
                    cb.DataSource = dt;
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
        public frmRptVLapWPenjualanOliPerWilayah()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
              
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_vLapW_PenjualanOliPerWilayah"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    if (cabangComboBox1.CabangID!="")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, cabangComboBox1.CabangID));
                    }

                    if (cb.Text!="")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KLP", SqlDbType.VarChar, cb.Text));
                    }
                    

                    ds = db.Commands[0].ExecuteDataSet();
                }
                if (ds.Tables[0].Rows.Count == 0 || ds.Tables[1].Rows.Count == 0)
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

        private void DisplayReport()
        {
            string periode;
            string option;
            string Init;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));

            if (cb.Text != "")
            {
                option = "Laporan  Per Wil - Kelp.Brg: " + cb.Text;
            }
            else
            {
                option = "Laporan  Per Wil - Kelp.Brg: Semua";
            }
            Init = GlobalVar.PerusahaanID;
            rptParams.Add(new ReportParameter("KLP", option));
            rptParams.Add(new ReportParameter("Init", "SAS-"+GlobalVar.Gudang));

            //call report viewer
            List<DataTable> pTable = new List<DataTable>();
            List<string> pDatasetName = new List<string>();
            pTable.Add(ds.Tables[0]);
            pTable.Add(ds.Tables[1]);
            pTable.Add(ds.Tables[2]);
            pDatasetName.Add("dsKartuPiutang_Data");
            pDatasetName.Add("dsOrderPenjualan_Data1");
            pDatasetName.Add("dsOrderPenjualan_Data2");
            frmReportViewer ifrmReport = new frmReportViewer("VLapW.rptVLapWPenjualanOliPerWilayah.rdlc", rptParams, pTable, pDatasetName);
            ifrmReport.Show();

        }

        private void frmRptVLapWPenjualanOliPerWilayah_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
            ReloadCBO();
        }

    }
}
