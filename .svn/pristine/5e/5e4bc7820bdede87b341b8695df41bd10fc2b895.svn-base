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

namespace ISA.Trading.HPPA
{
    public partial class frmHPPAProses : ISA.Trading.BaseForm
    {
        string _barangID = "", _namaStok = "";

        public frmHPPAProses()
        {
            InitializeComponent();
        }

        private void frmHPPAProses_Load(object sender, EventArgs e)
        {
            lblPerhatian.Text = "PERHATIAN !!!" + System.Environment.NewLine + System.Environment.NewLine
                + "Proses perhitungan HPP Rata-rata ini akan memakan waktu agak lama, karena "
                + System.Environment.NewLine
                + "semua transaksi pada Bulan Proses akan dihitung ulang HPP-nya. Dianjurkan "
                + System.Environment.NewLine
                + "agar melakukan Proses ini pada saat tidak ada terminal lain yang sedang "
                + System.Environment.NewLine
                + "bekerja dan JANGAN LUPA UNTUK MELAKUKAN BACKUP DATA !!!"
                + System.Environment.NewLine + System.Environment.NewLine
                + "Beberapa hal dibawah ini harus diperhatikan sebelum  Proses Perhitungan "
                + System.Environment.NewLine
                + "HPP Rata-rata ini dijalankan :"
                + System.Environment.NewLine
                + "1. Semua Transaksi Pembelian untuk Bulan Proses harus sudah ada nilai Pembeliannya"
                + System.Environment.NewLine
                + "2. Semua Transaksi Retur Pembelian untuk Bulan Proses juga harus ada nilai Returnya"
                + System.Environment.NewLine
                + "3. Jumlah Stok Awal dan Jumlah Stok Akhir dalam Bulan Proses tidak boleh ada yang bersaldo minus"
                + System.Environment.NewLine
                + "4. Proses ini sebaiknya dilakukan 1x dalam Bulan Proses yaitu pada Akhir Bulan Proses"
                + System.Environment.NewLine
                + "Apabila salah satu dari keempat kriteria diatas  tidak/belum terpenuhi, "
                + System.Environment.NewLine
                + "maka Proses ini TIDAK MENJAMIN NILAI HPP RATA-2 YANG TEPAT !!!";

            /* Initial state */
            rdoPerItem.Checked = true;
            chkPerKelompok.Enabled = false;
            cboKLP.Enabled = false;
            chkBarang.Checked = true;
            chkUpdateTable.Checked = false;
            chkClosing.Visible = false;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                cboKLP.DataSource = dt;
                cboKLP.DisplayMember = "KelompokBrgID";
                cboKLP.ValueMember = "KelompokBrgID";
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

        private bool ValidateInput()
        {
            bool valid = true;

            if (txtFromDate.Text == "")
            {
                errorProvider1.SetError(txtFromDate, "Tanggal masih kosong");
                valid = false;
            }

            if (rdoPerItem.Checked && _namaStok == "")
            {
                errorProvider1.SetError(txtStok, "Belum pilih barang");
                valid = false;
            }
                
            return valid;
        }

        private void cmbProses_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            if (!CekGudang())
            {
                MessageBox.Show("Kode Gudang di tabel Perusahaan tidak ada yang sesuai dengan Kode Gudang yang ada di tabel Gudang", "Perhatian");
                return;
            }

            if(!CekOpname())
            {
                MessageBox.Show("Masih ada StockOpname yang belum ditransfer. Silahkan transfer terlebih dahulu !", "Perhatian");
                return;
            }

            int update = 0;
            if (chkUpdateTable.Checked)
                update = 1;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_HPPA_PREPARE"));
                    //db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, txtFromDate.DateValue));
                    //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, txtToDate.DateValue));
                    
                    if (rdoPerItem.Checked && _barangID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@tipeProses", SqlDbType.VarChar, "BRG"));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    }
                    if (rdoPerKelompok.Checked)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@tipeProses", SqlDbType.VarChar, "KLP"));
                        if (chkPerKelompok.Checked)
                        {                            
                            db.Commands[0].Parameters.Add(new Parameter("@klp", SqlDbType.VarChar, cboKLP.SelectedValue.ToString()));

                            if (chkBarang.Checked && txtStok.Text.Trim() != "")
                                db.Commands[0].Parameters.Add(new Parameter("@namaBarang", SqlDbType.VarChar, txtStok.Text));
                        }
                    }

                    db.Commands[0].Parameters.Add(new Parameter("@update", SqlDbType.Bit, update));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    dt = db.Commands[0].ExecuteDataTable();
                }

                frmHPPAExecute frmChild = new frmHPPAExecute(txtFromDate.DateValue, txtToDate.DateValue, dt, update);                
                frmChild.ShowDialog();
                //DisplayReport(dt);
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
            periode = String.Format("{0} s/d {1}", ((DateTime)txtFromDate.DateValue).ToString("dd/MM/yyyy"), ((DateTime)txtToDate.DateValue).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("HPPA.rptHPPA.rdlc", rptParams, dt, "dsStok_Data");
            ifrmReport.Show();

        } 

        private bool CekGudang()
        {
            bool cek = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Gudang_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeCabang", SqlDbType.VarChar, GlobalVar.Gudang.Substring(0, 2)));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    cek = false;
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

            return cek;
        }

        private void rdoPerItem_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPerItem.Checked)
            {
                chkPerKelompok.Enabled = false;
                chkPerKelompok.Checked = false;
                cboKLP.Enabled = false;
                chkBarang.Checked = true;
                chkBarang.Enabled = false;
            }
        }

        private void rdoPerKelompok_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPerKelompok.Checked)
            {
                chkBarang.Checked = false;
                chkBarang.Enabled = true;

                chkPerKelompok.Enabled = true;
                chkPerKelompok.Checked = false;
                cboKLP.Enabled = false;
            }
        }

        private void chkPerKelompok_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPerKelompok.Checked)
            {
                cboKLP.Enabled = true;
            }
            else
            {
                cboKLP.Enabled = false;
            }
        }

        private void chkBarang_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBarang.Checked)
            {
                txtStok.Enabled = true;
            }
            else
            {
                txtStok.Text = "";
                _barangID = "";
                _namaStok = "";
                txtStok.Enabled = false;
            }
        }

        private void chkUpdateTable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdateTable.Checked)
            {
                chkClosing.Visible = true;
            }
            else
            {
                chkClosing.Visible = false;
            }
        }

        private void txtFromDate_Validating(object sender, CancelEventArgs e)
        {
            if (txtFromDate.DateValue.HasValue)
            {
                if (((DateTime)txtFromDate.DateValue).Day != 1)
                {
                    MessageBox.Show("Tanggal awal harus tanggal 1 (awal bulan)");
                    txtFromDate.Focus();
                    return;
                }

                DateTime nextMonth = ((DateTime)txtFromDate.DateValue).AddMonths(1);
                txtToDate.DateValue = nextMonth.AddDays(-1);
            }
        }

        private void txtStok_Validating(object sender, CancelEventArgs e)
        {
            if (rdoPerItem.Checked && (_namaStok != txtStok.Text || txtStok.Text.Trim() == ""))
            {
                CariStok();
            }
        }

        private void CariStok()
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
                        _namaStok = txtStok.Text;
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

        private void ShowDialogForm()
        {
            Controls.frmStockLookUp ifrmDialog = new Controls.frmStockLookUp();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
            else
            {
                txtStok.Focus();
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
            else
            {
                txtStok.Focus();
            }
        }

        private void GetDialogResult(Controls.frmStockLookUp dialogForm)
        {
            txtStok.Text = dialogForm.NamaStock;
            _barangID = dialogForm.BarangId;
            _namaStok = dialogForm.NamaStock;
        }

        private void cmbCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CekOpname()
        {
            bool cek = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CekOpname"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, txtFromDate.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, txtToDate.DateValue));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    cek = false;
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

            return cek;
        }
    }
}
