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

namespace ISA.Toko.Laporan.Toko
{
    public partial class frmRptPenyelesaianDOJualFilter : ISA.Toko.BaseForm
    {
        string _barangID = "", _namaBarang = ""; 

        public frmRptPenyelesaianDOJualFilter()
        {
            InitializeComponent();
        }

        private void frmRptPenyelesaianDOJualFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Penyelesaian Order Penjualan";
            this.Text = "Laporan";
            rdbTglDO.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTglDO.ToDate = DateTime.Now;
            cabangComboBox1.CabangID = GlobalVar.CabangID;
            cabangComboBox2.CabangID = GlobalVar.CabangID;
            rdoFixed.Checked = true;
            txtCab.Text = GlobalVar.PerusahaanID;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtKel = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));
                    dtKel = db.Commands[0].ExecuteDataTable();
                }
                dtKel.Rows.Add("");
                dtKel.DefaultView.Sort = "KelompokBrgID ASC";
                cboKelBrg.DataSource = dtKel;
                cboKelBrg.DisplayMember = "KelompokBrgID";
                cboKelBrg.ValueMember = "KelompokBrgID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            rdbTglDO.Focus();
        }
        private void txtStok_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && rdoFixed.Checked)
            {
                if (txtStok.Text != "")
                {
                    try
                    {

                        DataTable dtStok = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Stok_SEARCH"));
                            db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtStok.Text));
                            dtStok = db.Commands[0].ExecuteDataTable();
                        }

                        if (dtStok.Rows.Count == 1)
                        {
                            txtStok.Text = Tools.isNull(dtStok.Rows[0]["NamaStok"], "").ToString();
                            _barangID = Tools.isNull(dtStok.Rows[0]["BarangID"], "").ToString();
                        }
                        else
                        {
                            if (dtStok.Rows.Count == 0)
                            {
                                MessageBox.Show("Tidak ada barang tersebut");
                                return;
                            }
                            else
                            {
                                ShowDialogForm(txtStok.Text, dtStok);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                else
                {
                    ShowDialogForm();
                }
            }
        }

        private void ShowDialogForm()
        {
            Controls.frmStockLookUp ifrmDialog = new Controls.frmStockLookUp();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            Controls.frmStockLookUp ifrmDialog = new Controls.frmStockLookUp(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(Controls.frmStockLookUp dialogForm)
        {
            txtStok.Text = dialogForm.NamaStock;
            _namaBarang = dialogForm.NamaStock;
            _barangID = dialogForm.BarangId;
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbTglDO.FromDate.ToString() == "" || rdbTglDO.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTglDO, "Range Tanggal masih kosong");
                valid = false;
            }

            return valid;
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {

            if (!ValidateInput())
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Toko_PenyelesaianDO"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTglDO.ToDate));

                    if (cabangComboBox1.CabangID != "")
                        db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, cabangComboBox1.CabangID));
                    if (cabangComboBox2.CabangID != "")
                        db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, cabangComboBox2.CabangID));

                    if (lookupSales.NamaSales != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    if (lookupToko.NamaToko != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko.KodeToko));
                    if (txtWilID.Text != "")
                        db.Commands[0].Parameters.Add(new Parameter("@wilID", SqlDbType.VarChar, txtWilID.Text));

                    if (rdoFixed.Checked && _barangID != "")
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    if (rdoContain.Checked && txtStok.Text != "")
                        db.Commands[0].Parameters.Add(new Parameter("@namaBarang", SqlDbType.VarChar, txtStok.Text));

                    if (cboKelBrg.SelectedValue.ToString() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@KLP", SqlDbType.VarChar, cboKelBrg.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@InitCab", SqlDbType.VarChar, txtCab.Text));

                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReport(ds);
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

        private void DisplayReport(DataSet ds)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTglDO.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglDO.ToDate).ToString("dd/MM/yyyy"));
            
            string kelompok = "Semua";
            if (cboKelBrg.SelectedValue.ToString() != "")
                kelompok = cboKelBrg.SelectedValue.ToString();
            
            string barang = "Semua";
            if (txtStok.Text != "" && rdoContain.Checked)
                barang = "(mengandung) " + txtStok.Text;
            if (_barangID != "" && rdoFixed.Checked)
                barang = _namaBarang;

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID)); 
            rptParams.Add(new ReportParameter("KelompokBarang", kelompok));
            rptParams.Add(new ReportParameter("Barang", barang));

            List<ReportParameter> rptParams2 = new List<ReportParameter>();
            rptParams2.Add(new ReportParameter("Periode", periode));
            rptParams2.Add(new ReportParameter("UserID", SecurityManager.UserID)); 

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Toko.rptPenyelesaianDO.rdlc", rptParams, ds.Tables[0], "dsNotaPenjualan_Data");
            frmReportViewer ifrmReport2 = new frmReportViewer("Laporan.Toko.rptRekapPenyelesaianSO.rdlc", rptParams2, ds.Tables[1], "dsNotaPenjualan_Data1");

            ifrmReport.Show();
            ifrmReport2.Show();
        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
