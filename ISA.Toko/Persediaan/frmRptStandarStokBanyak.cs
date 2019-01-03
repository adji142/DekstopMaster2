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
    public partial class frmRptStandarStokBanyak : ISA.Toko.BaseForm
        {

        private void DisplayReport(DataTable dt)
            {

            //construct parameter
            List<ReportParameter> rptParams=new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", dateTextBox1.DateValue.ToString()));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Kelompok",cboKel.Text));


            //call report viewer
            frmReportViewer ifrmReport=new frmReportViewer("Persediaan.rptStandarStokBanyak.rdlc", rptParams, dt, "dsOpname_Data1");
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

                    object[] a = { "", "" };
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


        public frmRptStandarStokBanyak()
            {
            InitializeComponent();
            }

        private void frmRptStandarStokBanyak_Load(object sender, EventArgs e)
            {
            ReloadCBO();
            dateTextBox1.DateValue=DateTime.Now;
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
                    db.Commands.Add(db.CreateCommand("rsp_StandarStok_Banyak"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tgl", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@InitGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@KelompokBarang", SqlDbType.VarChar, cboKel.Text));

                    dt=db.Commands[0].ExecuteDataTable();


                    if (dt.Rows.Count==0)
                    {
                    MessageBox.Show("No Data");
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

        
        }
    }
