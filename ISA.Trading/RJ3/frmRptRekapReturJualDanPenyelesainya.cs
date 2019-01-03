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

namespace ISA.Trading.RJ3
{
    public partial class frmRptRekapReturJualDanPenyelesainya : ISA.Trading.BaseForm
    {
        DataSet ds = new DataSet();
        private void LoadKategori()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtCabang = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_Kategori_LIST]"));
                    dtCabang = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "Kategori + ' | ' + Keterangan");
                dtCabang.Columns.Add(cConcatenated);
                dtCabang.Rows.Add("");
                dtCabang.DefaultView.Sort = "Kategori ASC";

                cboKategori.DataSource = dtCabang;
                cboKategori.DisplayMember = "Concatenated";
                cboKategori.ValueMember = "Kategori";

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
            string periode;
            string sales;
            string cabang;
            string Kategori;
            if (rdbTglRq.Checked==true)
            {
                periode = String.Format("TANGGAL REQUEST RETUR : {0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            }else
            {
                periode = String.Format("TANGGAL NOTA RETUR    : {0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            }
            if (lookupSales.SalesID!="")
            {
                sales = lookupSales.SalesID;
            } else
            {
                sales = "All";
            }
            cabang = "C1 : "+cboCabang1.SelectedValue.ToString() + "  C2 : " + cboCabang2.SelectedValue.ToString();
           
            if (cboKategori.SelectedValue.ToString()!="")
            {
                Kategori = cboKategori.SelectedValue.ToString();
            }      else
            {
                Kategori = "Semua";
            }
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Kategori", Kategori));
            rptParams.Add(new ReportParameter("Cabang", cabang));
            rptParams.Add(new ReportParameter("Sales", sales));
            //call report viewer

            frmReportViewer ifrmReport = new frmReportViewer("RJ3.RptRekapReturJualDanPenyelesainya.rdlc", rptParams, dt, "dsReturPenjualan_Data");
            ifrmReport.Show();
        }

        public frmRptRekapReturJualDanPenyelesainya()
        {
            InitializeComponent();
        }

        private void frmRptRekapReturJualDanPenyelesainya_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
            LoadKategori();
            rdbTglRq.Checked = true;
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdyes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_RekapReturPenjualan_Penyelesaian]"));//hr, 16032013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    if (lookupSales.SalesID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    }

                    if (cboCabang1.SelectedValue.ToString() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, cboCabang1.SelectedValue.ToString()));
                    }
                    if (cboCabang2.SelectedValue.ToString() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, cboCabang2.SelectedValue.ToString()));
                    }

                    if (cboKategori.SelectedValue.ToString() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Kategori", SqlDbType.VarChar, cboKategori.SelectedValue.ToString()));
                    }
                    ds = db.Commands[0].ExecuteDataSet();
                }
                if (ds.Tables[0].Rows.Count==0)
                {
                    MessageBox.Show("Tidak ada data...!");
                    return;
                }
                if (rdbTglRq.Checked==true)
                {
                    DisplayReport(ds.Tables[0]);
                }  else
                {
                    DisplayReport(ds.Tables[1]);
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

        private void lookupSales_Leave(object sender, EventArgs e)
        {
            if (lookupSales.NamaSales.Trim()=="")
            {
                lookupSales.SalesID = "";
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_RekapReturPenjualan_Penyelesaian]"));//hr, 16032013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    if (lookupSales.SalesID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    }

                    if (cboCabang1.SelectedValue.ToString() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, cboCabang1.SelectedValue.ToString()));
                    }
                    if (cboCabang2.SelectedValue.ToString() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, cboCabang2.SelectedValue.ToString()));
                    }

                    if (cboKategori.SelectedValue.ToString() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Kategori", SqlDbType.VarChar, cboKategori.SelectedValue.ToString()));
                    }
                    ds = db.Commands[0].ExecuteDataSet();
                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data...!");
                    return;
                }
                if (rdbTglRq.Checked == true)
                {
                    DisplayReport(ds.Tables[0]);
                }
                else
                {
                    DisplayReport(ds.Tables[1]);
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

    }
}
