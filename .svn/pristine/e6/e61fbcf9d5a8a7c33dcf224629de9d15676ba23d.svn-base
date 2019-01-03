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
    public partial class frmRptMasterKosong : ISA.Trading.BaseForm
        {
        public frmRptMasterKosong()
            {
            InitializeComponent();
            }

        private void cmdNo_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void commandButton1_Click(object sender, EventArgs e)
            {
            
            DataTable dt=new DataTable();
            dt.Columns.Add("NamaStok");

            int isi=0;
            int n=1;
            n=Convert.ToInt32(this.numericTextBox1.Text);
            if (n<1)
            {
            numericTextBox1.Focus();
            return;
            }
            for(int i=1; i<=26*n; i++)
                {
                DataRow rb=dt.NewRow();
                rb["NamaStok"]=isi.ToString();
                dt.Rows.Add(rb);
                if(i%26==0)
                    {
                    isi++;
                    }
                }

            DisplayReport(dt);
            }


        private void DisplayReport(DataTable dt)
            {

            //construct parameter
            List<ReportParameter> rptParams=new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport=new frmReportViewer("Persediaan.rptMasterKosong.rdlc", rptParams, dt, "dsOpname_Data");
            ifrmReport.Show();

            }

        private void numericTextBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
            if(e.KeyChar==13)
                {
                commandButton1.PerformClick();
                }
            }

        private void frmRptMasterKosong_Load(object sender, EventArgs e)
            {

            }
        }
    }
