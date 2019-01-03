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
    public partial class frmRptOpnameDetailPerKelompok : ISA.Toko.BaseForm
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

        public frmRptOpnameDetailPerKelompok()
            {
            InitializeComponent();
            }

        private void cmdNo_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void cmdYes_Click(object sender, EventArgs e)
            {
            try
                {
                this.Cursor=Cursors.WaitCursor;
                using (Database db = new Database())
                    {
                    DataTable dt=new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_Opname_FormDetailPerKelompok"));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaBarang", SqlDbType.VarChar, txtxNama.Text.Trim()));
                    dt=db.Commands[0].ExecuteDataTable();

                    if(dt.Rows.Count==0)
                        {
                        MessageBox.Show("Tidak Ada Data");
                        this.DialogResult=DialogResult.OK;
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

        private void txtxNama_KeyPress(object sender, KeyPressEventArgs e)
            {
            if (e.KeyChar==13 && txtxNama.Text!="")
            {
            cmdYes.PerformClick();
            }
            }
        }
    }
