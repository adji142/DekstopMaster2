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
    public partial class frmRptDetailKosong : ISA.Trading.BaseForm
        {

        private void DisplayReport(DataTable dt)
            {

            //construct parameter
            List<ReportParameter> rptParams=new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport=new frmReportViewer("Persediaan.rptDetailKosong.rdlc", rptParams, dt, "dsOpname_Data");
            ifrmReport.Show();
            }

        public frmRptDetailKosong()
            {
            InitializeComponent();
            }

        private void cmdYes_Click(object sender, EventArgs e)
            {
            if ((numericTextBox1.Text=="") || Convert.ToInt32(numericTextBox1.Text)<=0)
                {
                numericTextBox1.Focus();
                return;
                }

            DataTable dt=new DataTable();
            dt.Columns.Add("NamaStok");

            int isi=0;
            int n=1;
            n=Convert.ToInt32(this.numericTextBox1.Text);
            if(n<1)
                {
                numericTextBox1.Focus();
                return;
                }
            for(int i=1; i<=1*n; i++)
                {

                DataRow rb=dt.NewRow();
                rb["NamaStok"]=isi.ToString();
                dt.Rows.Add(rb);
                if(i%1==0)
                    {
                    isi++;
                    }
                }

            DisplayReport(dt);
            }

        private void cmdNo_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void numericTextBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
            if (e.KeyChar==13)
            {
            cmdYes.PerformClick();
            }
            }

        private void frmRptDetailKosong_Load(object sender, EventArgs e)
            {
            numericTextBox1.Text="1";
            }

        private void numericTextBox1_Validating(object sender, CancelEventArgs e)
            {
            
            }
        }
    }
