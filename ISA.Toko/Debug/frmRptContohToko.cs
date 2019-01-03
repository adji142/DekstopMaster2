using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Toko.Controls;

namespace ISA.Toko.Debug
{
    public partial class frmRptContohToko : ISA.Toko.BaseForm
    {
        public frmRptContohToko()
        {
            InitializeComponent();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if ((rangeDateBox1.FromDate.Value == null) || (rangeDateBox1.ToDate.Value == null))
                return;

            DataTable dt=new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, txtNama.Text));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No Data");
                return;
            }

            DisplayReport(dt);
        }

        private void DisplayReport(DataTable dt)
        {
            string periode;
            periode=string.Format("{0} s/d {1}",((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"),((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParam=new List<ReportParameter>();
            rptParam.Add(new ReportParameter("Periode", periode));
            rptParam.Add(new ReportParameter("UserID", SecurityManager.UserID));
            frmReportViewer ifrmReport = new frmReportViewer("Debug.rptContohToko.rdlc", rptParam, dt, "dsToko_Data");
            ifrmReport.Show();
        }
    }

    
}
