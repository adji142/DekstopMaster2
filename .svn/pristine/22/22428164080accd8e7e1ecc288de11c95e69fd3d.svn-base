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
    public partial class frmRptReturJualPerBarang : ISA.Trading.BaseForm
    {
        private void LoadKategori()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtCabang = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_Kategori_LIST]")); //cek hr, 16032013
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

        public frmRptReturJualPerBarang()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            //if (cboJenis.Text=="")
            //{
            //    cboJenis.Focus();
            //    return;
            //}
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_RekapReturPenjualan_PerBarang"));//cek hr 16032013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@InitCAb", SqlDbType.VarChar, textBox1.Text.Trim()));
                    if (lookupSales.SalesID!="")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    }

                    if (cabangComboBox1.SelectedValue.ToString()!="")
                    {
                       db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, cabangComboBox1.SelectedValue.ToString()));
                    }

                    if (cboKategori.SelectedValue.ToString() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Kategori", SqlDbType.VarChar, cboKategori.SelectedValue.ToString()));
                    }


                    db.Commands[0].Parameters.Add(new Parameter("@Option", SqlDbType.VarChar, cboJenis.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data...!");
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

        private void frmRptReturJualPerBarang_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
            cboJenis.Items.Clear();
            cboJenis.Items.Add("");
            cboJenis.Items.Add("1");
            cboJenis.Items.Add("2");
            cboJenis.Items.Add("3");
            cboJenis.MaxLength = 1;
            cboJenis.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadKategori();
        }

        private void DisplayReport(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));

            //call report viewer

            frmReportViewer ifrmReport = new frmReportViewer("RJ3.RptReturJualPerBarang.rdlc", rptParams, dt, "dsReturPenjualan_Data");
            ifrmReport.Show();

        }

        private void lookupSales_Leave(object sender, EventArgs e)
        {
            if (lookupSales.NamaSales.Trim()=="")
            {
                lookupSales.SalesID = "";
            }
        }
    }
}
