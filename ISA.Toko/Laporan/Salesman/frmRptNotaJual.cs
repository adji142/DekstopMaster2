﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Laporan.Salesman
{
    public partial class frmRptNotaJual : ISA.Toko.BaseForm
    {
        public frmRptNotaJual()
        {
            InitializeComponent();
        }

        private void frmRptNotaJual_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;  DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                  
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Salesman_NotaJual"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    if (lookupSales.SalesID!="")
                    { 
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    }
                    
                    if (txtWilID.Text.Trim()!="")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar,txtWilID.Text));
                    }

                    if (txtInit.Text!= "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Init", SqlDbType.VarChar,txtInit.Text));
                    }

                    dt = db.Commands[0].ExecuteDataTable();

                } if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
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

        private void lookupSales_Leave(object sender, EventArgs e)
        {
            if (lookupSales.NamaSales.Trim()=="")
            {
                lookupSales.SalesID = "";
            }
        }

        private void DisplayReport(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Option", "2"));
            

            //if (lookupSales.SalesID=="")
            //{
            //    rptParams.Add(new ReportParameter("Salesman", "Semua"));
            //}
            //else
            //{
            //    rptParams.Add(new ReportParameter("Salesman", lookupSales.NamaSales));
            //}

            //if (txtWilID.Text != "")
            //{
            //    rptParams.Add(new ReportParameter("WilID", txtWilID.Text));
            //}
            //else
            //{
            //    rptParams.Add(new ReportParameter("WilID", "Semua"));
            //}
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Salesman.rptNotaJual.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Show();

        }
    }
}