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
    public partial class frmRptOpnameVersiGroup : ISA.Trading.BaseForm
        {


        private void DisplayReport(DataTable dt)
            {

            //construct parameter
            List<ReportParameter> rptParams=new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport=new frmReportViewer("Persediaan.rptOpnameVersiGroup.rdlc", rptParams, dt, "dsOpname_Data");
            ifrmReport.Show();

            }


        public frmRptOpnameVersiGroup()
            {
            InitializeComponent();
            }

        private void cmdNo_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void numericTextBox_KeyPress(object sender, KeyPressEventArgs e)
            {
             if (e.KeyChar==13)
                {
                cmdYes.PerformClick();
                }
            }

        private void cmdYes_Click(object sender, EventArgs e)
            {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                dt.Columns.Add("NamaStok");

                int isi = 0;
                int n = 1;
                n = Convert.ToInt32(this.numericTextBox.Text);
                if (n <= 0 || numericTextBox.Text == "")
                {
                    numericTextBox.Focus();
                    return;
                }
                for (int i = 1; i <= 6 * n; i++)
                {
                    DataRow rb = dt.NewRow();
                    rb["NamaStok"] = isi.ToString();
                    dt.Rows.Add(rb);
                    if (i % 6 == 0)
                    {
                        isi++;
                    }
                }

                DisplayReport(dt);
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

        private void frmRptOpnameVersiGroup_Load(object sender, EventArgs e)
            {

            }
            
        }
    }
