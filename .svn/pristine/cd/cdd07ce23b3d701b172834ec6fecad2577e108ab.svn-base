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
using System.IO;
using System.Drawing.Printing;
using ISA.Trading.Class;

namespace ISA.Trading.Master
{
    public partial class frmTokoJW : ISA.Controls.BaseForm
    {
        public frmTokoJW()
        {
            InitializeComponent();
        }

        private void frmTokoJW_Load(object sender, EventArgs e)
        {
            refreshdataToko();
            refreshTokoJW();
        }

        private void GVHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            refreshTokoJW();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            splitContainer1.Enabled = false;
            panelPrint.Visible = true;
            panelPrint.BringToFront();

            rangeDateBox1.FromDate = GlobalVar.DateOfServer;
            rangeDateBox1.ToDate = GlobalVar.DateOfServer;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrintLap_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("[usp_TokoJW_LISTbyTgl]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Data");
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

        private void cmdCancelLap_Click(object sender, EventArgs e)
        {
            splitContainer1.Enabled = true;
            panelPrint.Visible = false;
            panelPrint.SendToBack();
        }

        private void refreshdataToko()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("[usp_TokoAktif_LIST]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                GVHeader.DataSource = dt;
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

        private void refreshTokoJW()
        {
            if (GVHeader.Rows.Count > 0)
            {
                try
                {
                    string _kodeToko = GVHeader.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {

                        db.Commands.Add(db.CreateCommand("[usp_TokoJW_LIST]"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _kodeToko));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    GVDetail.DataSource = dt;
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
            else
            {
                GVDetail.DataSource = null;
            }
        }

        private void DisplayReport(DataTable dt)
        {

            string _periode = "Periode : " + ((DateTime)rangeDateBox1.FromDate).ToString("dd-MMM-yyyy") + " s/d " + ((DateTime)rangeDateBox1.ToDate).ToString("dd-MMM-yyyy");
            string _created = "Created by " + SecurityManager.UserID + " on " + GlobalVar.DateTimeOfServer;
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", _periode));
            rptParams.Add(new ReportParameter("Created", _created));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Master.rptLapTokoJW.rdlc", rptParams, dt, "dsToko_TokoJW");
            ifrmReport.Show();
        }

    }
}
