using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Trading.DataTemplates;


namespace ISA.Trading.Persediaan
    {
    public partial class frmRptKartuStok : ISA.Trading.BaseForm
        {
        public frmRptKartuStok()
            {
            InitializeComponent();
            }

        private void frmRptKartuStok_Load(object sender, EventArgs e)
            {
                rangeDateBox.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                rangeDateBox.ToDate = DateTime.Now;
                rangeDateBox.Focus();
            }

        private void cmdNo_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void cmdYes_Click(object sender, EventArgs e)
            {
                if (lookupStock.BarangID=="")
                {
                lookupStock.Focus();
                return;
                }

                if (lookupGudang.GudangID=="")
                {
                lookupGudang.Focus();
                return;
                }

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("[rsp_StokGudang_New_KartuStok]"));
                            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox.FromDate.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox.ToDate.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, GlobalVar.CabangID));

                            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, lookupGudang.GudangID));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, lookupStock.BarangID));

                            if (rdb1.Checked==true)
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@HppBeli", SqlDbType.Bit, 0));
                            }else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@HppBeli", SqlDbType.Bit, 1));
                            }

                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("No Data");
                                return;
                            }

                            DisplayReport(dt);
                        }
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

        private void lookupStock_Leave(object sender, EventArgs e)
        {

        }

        private void DisplayReport(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));

            rptParams.Add(new ReportParameter("Gudang",lookupGudang.GudangID));
            rptParams.Add(new ReportParameter("NamaStok", lookupStock.NamaStock));

            frmReportViewer ifrmReport = new frmReportViewer("Persediaan.rptGudangKartuStok2.rdlc", rptParams, dt, "dsOpname_Data1");
            ifrmReport.Show();
        }

        }
    }
