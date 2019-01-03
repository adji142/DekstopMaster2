using System.Data.SqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Finance.Class;
using ISA.Finance;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;

namespace ISA.Finance.Hutang.Report
{
    public partial class frmRptHutangPBLokal_RekapDetail : ISA.Controls.BaseForm
    {
        SqlGuid HP = SqlGuid.Null;
        Guid _RowIDPerusahaan;

        public frmRptHutangPBLokal_RekapDetail()
        {
            InitializeComponent();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (NotValid())
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                
                using (Database db = new Database(/*GlobalVar.DBTrading*/))
                {
                    db.Commands.Add(db.CreateCommand("[rsp_HutangBeliLokal_RekapDetail]"));
                    if (cTools.isNull(lookUpVendor1.RowIDPemasok,"").ToString() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, lookUpVendor1.RowIDPemasok));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@HutangBeliRowID", SqlDbType.UniqueIdentifier, HP));
                    if (cboPerusahaan.Text != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@RowIDPerusahaan", SqlDbType.UniqueIdentifier, _RowIDPerusahaan));
                    }

                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                DisplayReport(ds);
                //GenerateExcell(ds);
            }
            catch (System.Exception ex)
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
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                //rptParams.Add(new ReportParameter("Periode", periode));
                //rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
                // rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd-MMM-yyyy")));
                //rptParams.Add(new ReportParameter("Title", "LAPORAN HARGA BELI"));

                frmReportViewer ifrmReport = new frmReportViewer("Hutang.Report.rptHutangPBLokal_RekapDetail.rdlc", rptParams, ds.Tables[0], "dsRincianHutangLokal_dtHutang");
                ifrmReport.Text = "Rekap Invoice Per Detail Pembayaran";
                ifrmReport.Show();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptHutangPBLokal_RekapDetail_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPerusahaan = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan2_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@flag", SqlDbType.VarChar, "I"));
                    dtPerusahaan = db.Commands[0].ExecuteDataTable();
                    dtPerusahaan.Rows.Add(Guid.Empty);
                }
                if (dtPerusahaan.Rows.Count > 0)
                {
                    //_RowIDPerusahaan = new Guid(dtPerusahaan.Rows[0]["RowID"].ToString());
                    dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";
                    cboPerusahaan.DataSource = dtPerusahaan;
                    cboPerusahaan.DisplayMember = "Nama";
                    cboPerusahaan.ValueMember = "RowID";

                    //dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";
                    //cboPerusahaan.ValueMember = "InitPerusahaan";
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void initHP()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_HutangPembelian_LIST]"));
                db.Commands[0].Parameters.Add(new Parameter("@VendorROwID", SqlDbType.UniqueIdentifier, lookUpVendor1.RowIDPemasok));
                dt = db.Commands[0].ExecuteDataTable();
                dt.DefaultView.RowFilter = "";
            }
            if (dt.Rows.Count == 0)
            {
                HP = SqlGuid.Null;
                commonTextBox1.Text = "";
                throw new Exception("Tidak Ada Link Hutang Pembelian Untuk Vendor Ini !!");
            }

            frmPembayaranGetBukti ifrm = new frmPembayaranGetBukti(dt, "Invoice");
            ifrm.ShowDialog();

            if (ifrm.DialogResult == DialogResult.OK)
            {
                HP = new Guid(ifrm.GetData["RowID"].ToString());
                commonTextBox1.Text = ifrm.GetData["InvoiceNo"].ToString();

            }
            else
            {
                HP = SqlGuid.Null;
                commonTextBox1.Text = "";
                throw new Exception("Tak Ada Data yang di pilih !!!!");

            }
        }


        private void cmdCari_Click(object sender, EventArgs e)
        {
            if (cTools.isNull(lookUpVendor1.RowIDPemasok,"").ToString() == "")
            {
                HP = SqlGuid.Null;
                lookUpVendor1.Focus();
                ErrorProvider err = new ErrorProvider();
                err.SetError(lookUpVendor1, "Select First !!!");
                return;
            }

            try { this.Cursor = Cursors.WaitCursor; initHP(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { this.Cursor = Cursors.Default; }
        }

        private bool NotValid()
        {
            bool val = false;
            ErrorProvider err = new ErrorProvider();

            //if (lookUpVendor21.VendorID=="")
            //{
            //    err.SetError(lookUpVendor21, "Pilih Data Vendor !!!");
            //     val = true;
            //}

            //if (HP == SqlGuid.Null)
            //{
            //    err.SetError(lookUpHutang, "Pilih Data Invoice !!!");
            //    val = true;
            //}
            return val;
        }

        private void cboPerusahaan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPerusahaan.Text == "")
            {
                _RowIDPerusahaan = Guid.Empty;
            }
            else
            {
                DataRowView row = (DataRowView)cboPerusahaan.SelectedItem;
                if (row != null)
                {
                    _RowIDPerusahaan = new Guid(row[0].ToString());
                }
            }

        }

    }
}
