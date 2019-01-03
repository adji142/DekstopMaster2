using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Trading.Controls;


namespace ISA.Trading.Laporan.Barang
{
    public partial class FrmPenjualanItemPerKotaFilter : ISA.Trading.BaseForm
    {
        public FrmPenjualanItemPerKotaFilter()
        {
            InitializeComponent();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptPenjualanBarangPerItem_Load(object sender, EventArgs e)
        {

            if (rbfixed.Checked)
                lkpStock.AutoValidate = AutoValidate.EnableAllowFocusChange;
            else if (rbcontain.Checked)
                lkpStock.AutoValidate = AutoValidate.Disable;
            try
            {
                RngDateRange.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                RngDateRange.ToDate = DateTime.Now;
                cmdYes.Focus();
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    DataTable dt2 = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));
                    db.Commands.Add(db.CreateCommand("usp_Gudang_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.Rows.Add("");
                    dt.DefaultView.Sort = "KelompokBrgID ASC";
                    cmbKelompok.DataSource = dt;
                    cmbKelompok.ValueMember = "KelompokBrgID";
                    cmbKelompok.DisplayMember = "KelompokBrgID";
                    cmbKelompok.SelectedValue = "";

                    dt2.Clear();
                    dt2 = db.Commands[1].ExecuteDataTable();
                    DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "GudangID + ' | ' + NamaGudang");
                    dt2.Columns.Add(cConcatenated);
                    dt2.Rows.Add("");
                    dt2.DefaultView.Sort = "GudangID ASC";
                    cmbGudang.DataSource = dt2;
                    cmbGudang.ValueMember = "GudangID";
                    cmbGudang.DisplayMember = "Concatenated";
                    cmbGudang.SelectedValue = "";


                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (RngDateRange.FromDate == null || RngDateRange.ToDate == null)
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    string category = string.Empty;
                    string jenis = string.Empty;
                    if (rbBruto.Checked)
                        jenis = "bruto";
                    else if (rbNetto.Checked)
                        jenis = "netto";

                    
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_barang_penjualanBarang_peritem"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, RngDateRange.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, RngDateRange.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, string.IsNullOrEmpty(lkpSalesman.SalesID) ? null : lkpSalesman.SalesID));
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, string.IsNullOrEmpty(txtkota.Text) ? null : txtkota.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kodegudang", SqlDbType.VarChar, cmbGudang.SelectedValue == null ? null : cmbGudang.SelectedValue));
                    if (cmbKelompok.SelectedValue.ToString()!="")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, cmbKelompok.SelectedValue));
                    }
                   
                    db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, jenis));

                    if (rbfixed.Checked)
                    {
                        if (lkpToko.NamaToko.Trim() != "" && lkpToko.KodeToko != "")
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lkpToko.KodeToko));
                        }
                        if (lkpStock.NamaStock.Trim() != "" && lkpStock.BarangID != "")
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@barangId", SqlDbType.VarChar, lkpStock.BarangID));
                        }
                    }
                    else
                    {
                        if (txtNamaToko.Text.Trim() != "")
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, txtNamaToko.Text));
                        }
                        if (txtNamaStok.Text.Trim()!= "")
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@NamaBarang", SqlDbType.VarChar, txtNamaStok.Text));
                        }
                    }
                    
                    //db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, string.IsNullOrEmpty(lkpToko.NamaToko) ? null : lkpToko.NamaToko));
                    //db.Commands[0].Parameters.Add(new Parameter("@barangId", SqlDbType.VarChar, string.IsNullOrEmpty(lkpStock.BarangID) ? null : lkpStock.BarangID));
                    //if (lkpStock.BarangID=="" && lkpStock.NamaStock.Trim()!="")
                    //{
                    //    db.Commands[0].Parameters.Add(new Parameter("@NamaBarang", SqlDbType.VarChar, jenis));
                    //}
                    //if (lkpToko.KodeToko=="" && lkpToko.NamaToko.Trim()!="")
                    //{
                    //    db.Commands[0].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, jenis));
                    //}
                    
                    dt = db.Commands[0].ExecuteDataTable();

                   
                }
                if (dt.Rows.Count == 0)
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

        private void DisplayReport(DataTable dt)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)RngDateRange.FromDate).ToString("dd/MM/yyyy"), ((DateTime)RngDateRange.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Type",rbBruto.Checked ? "BRUTO" : "NETTO"));
            //call report viewer
            //frmReportViewer ifrmReport = new frmReportViewer((rbBruto.Checked) ? "Laporan.Barang.rptPenjualanBarangPerItem.rdlc" : "Laporan.Barang.rptPenjualanBarangPerItemNetto.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptPenjualanBarangPerItem.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();

        }

        private void lkpStock_Leave(object sender, EventArgs e)
        {
            if (rbfixed.Checked)
                lkpStock.ShowDialogFormValidation();

            if (rbcontain.Checked)
            {
                if (lkpStock.NamaStock.Trim()=="")
                {
                    lkpStock.BarangID = "";
                } 

            }
        }

        private void lkpSalesman_Leave(object sender, EventArgs e)
        {
            if (rbfixed.Checked)
                lkpSalesman.ShowDialogFormValidation();
        }

        private void lkpToko_Leave(object sender, EventArgs e)
        {
            if (rbfixed.Checked)
                lkpToko.ShowDialogFormValidation();

            if (rbcontain.Checked)
            { 
                if (lkpToko.NamaToko.Trim()=="")
                {
                    lkpToko.KodeToko = "";
                }
                    
            }
        }

        private void rbfixed_CheckedChanged(object sender, EventArgs e)
        {
            if (rbfixed.Checked)
            {
                lkpStock.Visible = true;
                lkpToko.Visible = true;
                txtNamaStok.Visible = false;
                txtNamaToko.Visible = false;
            }
            else
            {
                lkpStock.Visible = false;
                lkpToko.Visible = false;
                txtNamaStok.Visible = true;
                txtNamaToko.Visible = true;
            }
        }
    }
}
