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
    public partial class frmRptStokGudangKartuStok : ISA.Trading.BaseForm
        {

        private void DisplayReport(DataTable dt)
            {

            //construct parameter
            string periode;
            periode=String.Format("{0} s/d {1}", ((DateTime)rangeDateBox.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams=new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("NamaStok", lookupStock.NamaStock));
            rptParams.Add(new ReportParameter("Gudang", lookupGudang.GudangID));

            //call report viewer
            frmReportViewer ifrmReport=new frmReportViewer("Persediaan.rptGudangKartuStok2.rdlc", rptParams, dt, "dsOpname_Data1");
            ifrmReport.Show();

            }


        public frmRptStokGudangKartuStok()
            {
            InitializeComponent();
            }

        private void cmdNo_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void frmStokGudangKartuStok_Load(object sender, EventArgs e)
            {
            rangeDateBox.FromDate=new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox.ToDate=DateTime.Now;
            }

        private void cmdYes_Click(object sender, EventArgs e)
            {
            if (lookupStock.BarangID==""||lookupStock.NamaStock=="")
            {
            lookupStock.Focus();
            return;
            }

            if (lookupGudang.GudangID==""||lookupGudang.NamaGudang=="")
            {
            lookupGudang.Focus();
            return;
            }

           if (rangeDateBox.FromDate.Value<rangeDateBox.ToDate.Value)
           {
           rangeDateBox.Focus();
           }

            try
                {
                this.Cursor=Cursors.WaitCursor;
                using (Database db = new Database())
                    {
                    DataTable dt=new DataTable();
                    db.Commands.Add(db.CreateCommand("[rsp_StokGudang_New_KartuStok]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, lookupStock.BarangID));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, lookupGudang.GudangID));
                    db.Commands[0].Parameters.Add(new Parameter("@InitGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@HppBeli", SqlDbType.Bit,1));
           
                    
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
    }
