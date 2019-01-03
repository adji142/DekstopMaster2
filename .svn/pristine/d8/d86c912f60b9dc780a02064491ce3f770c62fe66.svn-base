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

namespace ISA.Trading.Persediaan
    {
    public partial class frmRptStandarStokAVGJual : ISA.Trading.BaseForm
        {


        private void DisplayReport(DataTable dt)
            {

            //construct parameter
            List<ReportParameter> rptParams=new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", dateTextBox1.DateValue.Value.ToString("dd-MMM-yyyy")));
            rptParams.Add(new ReportParameter("Kelompok", cboKel.Text));

            //call report viewer
            frmReportViewer ifrmReport=new frmReportViewer("Persediaan.rptStandarStokAVGJual.rdlc", rptParams, dt, "dsOpname_Data");
            ifrmReport.Show();

            }

        private void ReloadCBO()
            {
            try
                {
                this.Cursor=Cursors.WaitCursor;
                using (Database db = new Database())
                    {
                    DataTable dt=new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));
                    dt=db.Commands[0].ExecuteDataTable();
                    object[] a = {"",""};
                    dt.Rows.Add(a);

                    cboKel.ValueMember="kelompokBrgID";
                    cboKel.DisplayMember="kelompokBrgID";
                    cboKel.DataSource=dt;

                    cboKel.SelectedValue = "";
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

        public frmRptStandarStokAVGJual()
            {
            InitializeComponent();
            }

        private void frmRptStandarStokAVGJual_Load(object sender, EventArgs e)
            {
            dateTextBox1.DateValue=DateTime.Now;
            ReloadCBO();
            }

        private void cmdYes_Click(object sender, EventArgs e)
            {
            try
                {
                this.Cursor=Cursors.WaitCursor;
                using (Database db = new Database())
                    {
                    DataTable dt=new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_StandarStok_AVGJual"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tgl", SqlDbType.DateTime,dateTextBox1.DateValue));
                    if (cboKel.Text!="")
                    {
                    db.Commands[0].Parameters.Add(new Parameter("@KelompokBarang", SqlDbType.VarChar,cboKel.Text));
                    }
                    dt=db.Commands[0].ExecuteDataTable();

                    if(dt.Rows.Count==0)
                        {
                        MessageBox.Show("Tidak Ada Data");
                        return;
                        }
                    DisplayReport(dt);
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

        private void cmdNo_Click(object sender, EventArgs e)
            {
            this.Close();
            }
        }
    }
