using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Data.SqlTypes;
using ISA.Controls;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;

namespace ISA.Finance.Setoran
{
    public partial class frmRencanaUlangNota : ISA.Finance.BaseForm
    {
#region "Procedure"
        DataTable dt = new DataTable();
      
        private void LoadData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_KPiutang_List]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    db.Commands[0].Parameters.Add(new Parameter("@TglPrediksi", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    dt = db.Commands[0].ExecuteDataTable();
                  
                }
                customGridView1.DataSource = dt;
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

        private void DisplayReport(DataTable dt)
        {
            try
            {
                List<ReportParameter> rptParams = new List<ReportParameter>();
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Setoran.rptRencanaUlang.rdlc", rptParams, dt, "dsSetoran_Data");
                ifrmReport.Text = "Rencana Ulang Nota";
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
#endregion


        public frmRencanaUlangNota()
        {
            InitializeComponent();
        }

        private void frmRencanaUlangNota_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            customGridView1.AutoGenerateColumns = false;
            LoadData();
        }


        
        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (customGridView1.RowCount==0)
            {
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_Setoran_KPiutang_List]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                // dt.DefaultView.Sort = cboSort.SelectedValue.ToString();
                DisplayReport(dt.DefaultView.ToTable("tes"));
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Setoran.frmPreferenceSetoran ifrmChild = new Setoran.frmPreferenceSetoran();
            ifrmChild.ShowDialog();
        }
    }
}
