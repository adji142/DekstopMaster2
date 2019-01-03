using System.Data.SqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Finance.Class;
using ISA.Finance;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;


namespace ISA.Finance.Hutang.Report
{
    public partial class frmRincianHutangLokal : ISA.Controls.BaseForm
    {
        Guid _RowIDPerusahaan;
         

        public frmRincianHutangLokal()
        {
            InitializeComponent();
            this.Location = new Point(300, 165);
        }

        private void frmRincianHutangLokal_Load(object sender, EventArgs e)
        {
          // DateTime dtm = new DateTime();
            cbIMLOK.SelectedIndex = 0;
           monthYearBox1.Month = Convert.ToInt32(DateTime.Now.ToString("MM"));
           monthYearBox1.Year = Convert.ToInt32(GlobalVar.DateOfServer.Year);

           try
           {
               DataTable dtPerusahaan = new DataTable();
               using (Database db = new Database())
               {
                   db.Commands.Add(db.CreateCommand("usp_Perusahaan2_LIST"));
                   db.Commands[0].Parameters.Add(new Parameter("@flag", SqlDbType.VarChar, "I"));
                   dtPerusahaan = db.Commands[0].ExecuteDataTable();
                   dtPerusahaan.Rows.Add(Guid.Empty);
               }
               if (dtPerusahaan.Rows.Count > 0)
               {
                   //_RowIDPerusahaan = new Guid(dtPerusahaan.Rows[0]["RowID"].ToString());
                   dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";
                   cboPerusahaan.DataSource = dtPerusahaan;
                   cboPerusahaan.DisplayMember = "Nama";
                   cboPerusahaan.ValueMember = "RowID";

                   //dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";
                   //cboPerusahaan.ValueMember = "InitPerusahaan";
               }
           }
           catch (Exception ex)
           {
               Error.LogError(ex);
           }

        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        frmReportViewer ifrmReport;
        private void commandButton1_Click(object sender, EventArgs e)
        {
            bool import = true ;
            DataSet ds = new DataSet();

            if (cbIMLOK.Text == "IMPORT")
                import = true;
            else if (cbIMLOK.Text == "LOKAL")
                import = false;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();

                string titleReport = cbIMLOK.Text ;
                rptParams.Add(new ReportParameter("titleReport", titleReport));      

                string periodReport = monthYearBox1.LastDateOfMonth.Day + " " + monthYearBox1.MonthName + " " + monthYearBox1.Year.ToString() ;
                rptParams.Add(new ReportParameter("periodeReport", periodReport));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_rincian_hutang_lokal"));
                    db.Commands[0].Parameters.Add(new Parameter("@StartDate", SqlDbType.DateTime, monthYearBox1.FirstDateOfMonth.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@import", SqlDbType.Bit , import));
                    if (cboPerusahaan.Text != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@RowIDPerusahaan", SqlDbType.UniqueIdentifier, _RowIDPerusahaan));
                    }

                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (cbIMLOK.Text == "LOKAL")
                    {
                        ifrmReport = new frmReportViewer("Hutang.Report.laporanRincianHutangLokal.rdlc", rptParams, ds.Tables[0], "dsRincianHutangLokal_rincianHutangLokal");
                    }
                    //if (cbIMLOK.Text == "IMPORT")
                    //{
                    //    ifrmReport = new frmReportViewer("Keuangan.Hutang.Report.laporanRekapHutang.rdlc", rptParams, ds.Tables[0], "dsRincianHutangLokal_rincianHutangLokal");
                    //}
                    ifrmReport.Text = "Rekap Hutang " + periodReport;
                    ifrmReport.Show();
                }
                else
                {
                    MessageBox.Show("Data tidak Ada");
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

        private void monthYearBox1_Load(object sender, EventArgs e)
        {
            
        }

        private void cboPerusahaan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPerusahaan.Text == "")
            {
                _RowIDPerusahaan = Guid.Empty;
            }
            else
            {
                DataRowView row = (DataRowView)cboPerusahaan.SelectedItem;
                if (row != null)
                {
                    _RowIDPerusahaan = new Guid(row[0].ToString());
                }
            }

        }
    }
}
