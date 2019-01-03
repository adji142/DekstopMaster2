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

namespace ISA.Toko.ArusStock
    {
    public partial class frmRptAntarGudangBelumDiterima : ISA.Toko.BaseForm
        {
        public frmRptAntarGudangBelumDiterima()
            {
            InitializeComponent();
            }

        private void cmdClose_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void cmdYes_Click(object sender, EventArgs e)
            {
            if(rdbNota.Checked==true)
                {
                try
                    {
                    this.Cursor=Cursors.WaitCursor;
                    using (Database db = new Database())
                        {
                        DataTable dt=new DataTable();
                        db.Commands.Add(db.CreateCommand("rsp_AntarGudangBelumDiterima_PerNota"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                        if(!string.IsNullOrEmpty(lookupGudang.GudangID))
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, lookupGudang.GudangID));
                        }
                        
                        dt=db.Commands[0].ExecuteDataTable();

                        if(dt.Rows.Count==0)
                            {
                            MessageBox.Show("Tidak Ada Data");
                            return;
                            }
                        DisplayReport2(dt);
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

            if(rdbBarang.Checked==true)
                {
                try
                    {
                    this.Cursor=Cursors.WaitCursor;
                    using (Database db = new Database())
                        {
                        DataTable dt=new DataTable();
                        db.Commands.Add(db.CreateCommand("rsp_AntarGudangBelumDiterima_PerBarang"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                        
                        if(!string.IsNullOrEmpty(lookupGudang.GudangID))
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, lookupGudang.GudangID));
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

            }

        private void frmRptAntarGudangBelumDiterima_Load(object sender, EventArgs e)
        {
        rangeDateBox1.FromDate=new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        rangeDateBox1.ToDate=DateTime.Now;
        lookupGudang.GudangID="";
        }

        private void DisplayReport(DataTable dt)
            {

            //construct parameter
            string periode;
            periode=String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams=new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport=new frmReportViewer("ArusStock.rptAntarGudangBelumDiterimaPerBarang.rdlc", rptParams, dt, "dsAntarGudang_Data");
            ifrmReport.Show();

            }

        private void DisplayReport2(DataTable dt)
            {

            //construct parameter
            string periode;
            periode=String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams=new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            if (lookupGudang.GudangID!="")
            {
            rptParams.Add(new ReportParameter("Pengirim", lookupGudang.GudangID));
            }
            else
                {
                rptParams.Add(new ReportParameter("Pengirim","Semua"));
                }
            

            //call report viewer
            frmReportViewer ifrmReport=new frmReportViewer("ArusStock.rptAntarGudangBelumDiTerimaPerNota.rdlc", rptParams, dt, "dsAntarGudang_Data");
            ifrmReport.Show();

            }

        private void rangeDateBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
            if(e.KeyChar==13)
                {
                cmdYes.PerformClick();
                }
            }

        private void lookupGudang_Leave(object sender, EventArgs e)
            {
            if (lookupGudang.NamaGudang=="")
            {
            lookupGudang.GudangID="";
            }
            }
        
        }
    } 
