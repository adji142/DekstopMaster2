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

namespace ISA.Toko.Pembelian
{
    public partial class frmRptArusPembDanPenjFilter : ISA.Toko.BaseForm
    {
        string _barangID = "";

        public frmRptArusPembDanPenjFilter()
        {
            InitializeComponent();
        }

        private void frmRptArusPembDanPenjFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Laporan Arus Pembelian Dan Penjualan";
            this.Text = "Pembelian";
            rdbTglSJBeli.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTglSJBeli.ToDate = DateTime.Now;
            rdbTglSJJual.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTglSJJual.ToDate = DateTime.Now;
            rdoFixed.Checked = true;
            rdbTglSJBeli.Focus();
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
            _barangID = dialogForm.BarangId;
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbTglSJBeli.FromDate.ToString() == "" || rdbTglSJBeli.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTglSJBeli, "Range tanggal pembelian masih kosong");
                valid = false;
            } 
            if (rdbTglSJJual.FromDate.ToString() == "" || rdbTglSJJual.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTglSJJual, "Range tanggal penjualan masih kosong");
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
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Pembelian_ArusPembDanPenj"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromSJPembDate", SqlDbType.DateTime, rdbTglSJBeli.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toSJPembDate", SqlDbType.DateTime, rdbTglSJBeli.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@fromSJPenjDate", SqlDbType.DateTime, rdbTglSJJual.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toSJPenjDate", SqlDbType.DateTime, rdbTglSJJual.ToDate));
                    if (rdoFixed.Checked && _barangID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    }
                    if (rdoContain.Checked && txtStok.Text != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@searchArgs", SqlDbType.VarChar, txtStok.Text));
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
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

        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string periodeBeli, periodeJual;
            periodeBeli = String.Format("{0} s/d {1}", ((DateTime)rdbTglSJBeli.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglSJBeli.ToDate).ToString("dd/MM/yyyy"));
            periodeJual = String.Format("{0} s/d {1}", ((DateTime)rdbTglSJJual.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglSJJual.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("PeriodeBeli", periodeBeli));
            rptParams.Add(new ReportParameter("PeriodeJual", periodeJual));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptArusPembDanPenj.rdlc", rptParams, dt, "dsNotaPembelian_Data");
            ifrmReport.Show();

        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
