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
    public partial class frmRptOpnameAnalisa : ISA.Trading.BaseForm
        {

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
                    cb.ValueMember="kelompokBrgID";
                    cb.DisplayMember="kelompokBrgID";
                    cb.DataSource=dt;
                    cb.SelectedValue = "";
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

        public frmRptOpnameAnalisa()
            {
            InitializeComponent();
            }

        private void cmdNo_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void frmRptOpnameAnalisa_Load(object sender, EventArgs e)
            {
            ReloadCBO();
            rdbA1.Checked=true;
            rdbB1.Checked=true;
            rdbC1.Checked=true;
            }

        private void cmdYes_Click(object sender, EventArgs e)
            {
            try
                {                
                    this.Cursor = Cursors.WaitCursor; 
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                        {
                       
                        db.Commands.Add(db.CreateCommand("rsp_Opname_Analisa"));

                        if (!string.IsNullOrEmpty(txtNamaStok.Text))
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@NamaStok", SqlDbType.VarChar, txtNamaStok.Text.Trim()));
                        }

                        if (!string.IsNullOrEmpty(cb.Text))
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@KelompokBarang", SqlDbType.VarChar, cb.Text));
                        }

                        if (rdbC2.Checked==true)
                        {
                        db.Commands[0].Parameters.Add(new Parameter("@Selisih", SqlDbType.VarChar,"2"));
                        }

                        if(rdbC3.Checked==true)
                        {
                        db.Commands[0].Parameters.Add(new Parameter("@Selisih", SqlDbType.VarChar, "3"));
                        }

                       
                            
                        dt = db.Commands[0].ExecuteDataTable();
                        if(rdbA1.Checked==true)
                            {
                            dt.DefaultView.Sort="NamaStok ASC";
                            }
                        else if (rdbA2.Checked == true)
                            {
                            dt.DefaultView.Sort="KodeBarang ASC";
                            }
                        else
                            {
                            dt.DefaultView.Sort = "KodeRak ASC";
                            }
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

        private void DisplayReport(DataTable dt)
            {

            //construct parameter
            List<ReportParameter> rptParams=new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            
            if (rdbB1.Checked==true)
            {
            rptParams.Add(new ReportParameter("Hitung", "1"));
            }

            if(rdbB2.Checked==true)
            {
            rptParams.Add(new ReportParameter("Hitung", "2"));
            }

            if(rdbB3.Checked==true)
            {
            rptParams.Add(new ReportParameter("Hitung", "3"));
            }

            if(rdbB4.Checked==true)
            {
            rptParams.Add(new ReportParameter("Hitung", "4"));
            }
            
          

            //call report viewer
            frmReportViewer ifrmReport=new frmReportViewer("Persediaan.rptOpnameAnalisa.rdlc", rptParams, dt, "dsOpname_Data");
            ifrmReport.Show();

            }
        }
    }
