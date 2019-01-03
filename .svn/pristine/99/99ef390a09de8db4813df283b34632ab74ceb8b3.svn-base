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
    public partial class frmRptArusPembelianFilter : ISA.Toko.BaseForm
    {
        string _barangID = ""; 

        public frmRptArusPembelianFilter()
        {
            InitializeComponent();
        }

        private void frmRptArusPembelianFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Laporan Arus Pembelian";
            this.Text = "Pembelian";
            rdbTglNota.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbTglNota.ToDate = DateTime.Now;
            rdoNota.Checked = true;
            rdoFixed.Checked = true;
            rdbTglNota.Focus();
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

            if (rdbTglNota.FromDate.ToString() == "" || rdbTglNota.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbTglNota, "Range Tgl Nota masih kosong");
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

            string mode = "N";
            if (rdoBarang.Checked)
                mode = "B";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Pembelian_ArusPembelian"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTglNota.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTglNota.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@mode", SqlDbType.VarChar, mode));
                    if (rdoFixed.Checked && _barangID != "")
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    if (rdoContain.Checked && txtStok.Text != "")
                        db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtStok.Text));
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
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbTglNota.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglNota.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptArusPembelian.rdlc", rptParams, dt, "dsNotaPembelian_Data");
            ifrmReport.Show();

        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
