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


namespace ISA.Toko.Persediaan
    {
    public partial class frmRptCtkDetailOpnamePerBarang : ISA.Toko.BaseForm
        {


        private void DisplayReport(DataTable dt)
            {

            //construct parameter
            List<ReportParameter> rptParams=new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport=new frmReportViewer("Persediaan.rptFrmOpnamePerKelompok.rdlc", rptParams, dt, "dsOpname_Data");
            ifrmReport.Show();

            }


        public frmRptCtkDetailOpnamePerBarang()
            {
            InitializeComponent();
            }

        private void cmdYes_Click(object sender, EventArgs e)
            {
            if (lookupStock1.BarangID=="")
            {
            lookupStock1.Focus();
            return;
            }

            try
                {
                this.Cursor=Cursors.WaitCursor;
                using (Database db = new Database())
                    {
                    DataTable dt=new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, lookupStock1.BarangID));
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

        private void lookupStock1_Leave(object sender, EventArgs e)
            {
            if (lookupStock1.NamaStock=="")
            {
            lookupStock1.BarangID="";
            }
            }

        private void frmRptCtkDetailOpnamePerBarang_Load(object sender, EventArgs e)
            {

            }

        private void cmdNo_Click(object sender, EventArgs e)
            {
            this.Close();
            }
        }
    }
