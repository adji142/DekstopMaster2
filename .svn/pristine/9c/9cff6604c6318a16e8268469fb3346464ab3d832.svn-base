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
using ISA.FTP;

namespace ISA.Trading.Pembelian
{
    public partial class frmRptRegisterPembFilter : ISA.Trading.BaseForm
    {
        public frmRptRegisterPembFilter()
        {
            InitializeComponent();
        }

        private void frmRptRegisterPembFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Laporan Register Pembelian";
            this.Text = "Pembelian";
           
            T1.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            t2.DateValue= DateTime.Now;
            monthYearBox1.Month = DateTime.Now.Month; ;
            monthYearBox1.Year = DateTime.Now.Year;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtGudang = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Gudang_LIST"));
                    dtGudang = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "GudangID + ' | ' + NamaGudang");
                dtGudang.Columns.Add(cConcatenated);
                dtGudang.Rows.Add("");
                dtGudang.DefaultView.Sort = "GudangID ASC";
                cboGudang.DataSource = dtGudang;
                cboGudang.DisplayMember = "Concatenated";
                cboGudang.ValueMember = "GudangID";
                cboGudang.SelectedValue = "";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            rdoTglNota.Checked = true;
            T1.Focus();
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (T1.DateValue.HasValue==false )
            {
                errorProvider1.SetError(T1, "Range Tanggal masih kosong");
                valid = false;
            }

            if (t2.DateValue.HasValue == false)
            {
                errorProvider1.SetError(t2, "Range Tanggal masih kosong");
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

            string tipeTgl = "NT";
            if (rdoTglTerima.Checked)
                tipeTgl = "TR";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Pembelian_RegisterPembelian"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, T1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, t2.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tipeTgl", SqlDbType.VarChar, tipeTgl));

                    if (cboGudang.SelectedValue != null)
                    {
                        if (cboGudang.SelectedValue.ToString() != "")
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, cboGudang.SelectedValue.ToString()));
                        }
                    }

                    if (cboGudang.SelectedValue == null && string.IsNullOrEmpty(cboGudang.SelectedText))
                    {
                        MessageBox.Show("Kode Gudang belum dipilih");
                        cboGudang.Focus();
                        return;
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                }

                string sSum = dt.Compute("SUM(Nilai)", "Nilai IS NOT NULL").ToString();

                if (sSum == "")
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReport(dt);
                    if (MessageBox.Show("Upload register pembelian ?", "Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            DataSet ds = new DataSet();
                            if (dt.Rows.Count > 0)
                            {
                                ds.Tables.Add(dt);
                                string gudang = GlobalVar.Gudang;
                                string fileOuput = FtpEngine.UploadDirectory + "\\" + "UPLOADHIPB" + gudang + " " + Guid.NewGuid().ToString() + ".xml";
                                ds.WriteXml(fileOuput);
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
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private DataTable WriteXml(string fileOuput)
        {
            throw new NotImplementedException();
        }

        private void DisplayReport(DataTable dt)
        {
            //construct parameter

            string gudang = "Semua";
            if (cboGudang.SelectedValue.ToString() != "")
            {
                gudang = cboGudang.SelectedValue.ToString();
            }

            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)T1.DateValue).ToString("dd/MM/yyyy"), ((DateTime)t2.DateValue).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Gudang", gudang));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptRegisterPemb.rdlc", rptParams, dt, "dsNotaPembelian_Data");
            ifrmReport.Show();
        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void p1_CheckedChanged(object sender, EventArgs e)
        {
            if (p0.Checked)
            {
                T1.Enabled = true;
                t2.Enabled = true;
                T1.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                t2.DateValue = DateTime.Now;
                groupBox2.Enabled = true;
                monthYearBox1.Enabled = false;
                monthYearBox1.Month = DateTime.Now.Month; ;
                monthYearBox1.Year = DateTime.Now.Year;
                
            }

            if (p1.Checked)
            {
                T1.Enabled = false;
                t2.Enabled = false;
                monthYearBox1.Enabled = true;
                monthYearBox1.Month = DateTime.Now.Month; ;
                monthYearBox1.Year = DateTime.Now.Year;
                T1.DateValue = monthYearBox1.FirstDateOfMonth;
                t2.DateValue = new DateTime(monthYearBox1.FirstDateOfMonth.Year, monthYearBox1.FirstDateOfMonth.Month, 15);
                groupBox2.Enabled = false;
                rdoTglTerima.Checked = true;
            }

            if (p2.Checked)
            {
                T1.Enabled = false;
                t2.Enabled = false;
                monthYearBox1.Enabled = true;
                monthYearBox1.Month = DateTime.Now.Month; ;
                monthYearBox1.Year = DateTime.Now.Year;
                T1.DateValue = monthYearBox1.FirstDateOfMonth;
                t2.DateValue = monthYearBox1.LastDateOfMonth;
                groupBox2.Enabled = false;
                rdoTglTerima.Checked = true;
            }
        }

        private void p0_CheckedChanged(object sender, EventArgs e)
        {
            if (p0.Checked)
            {
                T1.Enabled = true;
                t2.Enabled = true;
                T1.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                t2.DateValue = DateTime.Now;
                groupBox2.Enabled = true;
                monthYearBox1.Enabled = false;
                monthYearBox1.Month = DateTime.Now.Month; ;
                monthYearBox1.Year = DateTime.Now.Year;

            }

            if (p1.Checked)
            {
                T1.Enabled = false;
                t2.Enabled = false;
                monthYearBox1.Enabled = true;
                monthYearBox1.Month = DateTime.Now.Month; ;
                monthYearBox1.Year = DateTime.Now.Year;
                T1.DateValue = monthYearBox1.FirstDateOfMonth;
                t2.DateValue = new DateTime(monthYearBox1.FirstDateOfMonth.Year, monthYearBox1.FirstDateOfMonth.Month, 15);
                groupBox2.Enabled = false;
                rdoTglTerima.Checked = true;
            }

            if (p2.Checked)
            {
                T1.Enabled = false;
                t2.Enabled = false;
                monthYearBox1.Enabled = true;
                monthYearBox1.Month = DateTime.Now.Month; ;
                monthYearBox1.Year = DateTime.Now.Year;
                T1.DateValue = new DateTime(monthYearBox1.FirstDateOfMonth.Year, monthYearBox1.FirstDateOfMonth.Month, 16);
                t2.DateValue = monthYearBox1.LastDateOfMonth;
                groupBox2.Enabled = false;
                rdoTglTerima.Checked = true;
            }
        }

        private void p2_CheckedChanged(object sender, EventArgs e)
        {
            if (p0.Checked)
            {
                T1.Enabled = true;
                t2.Enabled = true;
                T1.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                t2.DateValue = DateTime.Now;
                groupBox2.Enabled = true;
                monthYearBox1.Enabled = false;
                monthYearBox1.Month = DateTime.Now.Month; ;
                monthYearBox1.Year = DateTime.Now.Year;

            }

            if (p1.Checked)
            {
                T1.Enabled = false;
                t2.Enabled = false;
                monthYearBox1.Enabled = true;
                monthYearBox1.Month = DateTime.Now.Month; ;
                monthYearBox1.Year = DateTime.Now.Year;
                T1.DateValue = monthYearBox1.FirstDateOfMonth;
                t2.DateValue = new DateTime(monthYearBox1.FirstDateOfMonth.Year, monthYearBox1.FirstDateOfMonth.Month, 15);
                groupBox2.Enabled = false;
                rdoTglTerima.Checked = true;
            }

            if (p2.Checked)
            {
                T1.Enabled = false;
                t2.Enabled = false;
                monthYearBox1.Enabled = true;
                monthYearBox1.Month = DateTime.Now.Month; ;
                monthYearBox1.Year = DateTime.Now.Year;
                T1.DateValue = new DateTime(monthYearBox1.FirstDateOfMonth.Year, monthYearBox1.FirstDateOfMonth.Month, 16);
                t2.DateValue = monthYearBox1.LastDateOfMonth;
                groupBox2.Enabled = false;
                rdoTglTerima.Checked = true;
            }
        }

        private void monthYearBox1_Validating(object sender, CancelEventArgs e)
        {
            if (p1.Checked)
            {
                T1.Enabled = false;
                t2.Enabled = false;
                monthYearBox1.Enabled = true;
           
                T1.DateValue = monthYearBox1.FirstDateOfMonth;
                t2.DateValue = new DateTime(monthYearBox1.FirstDateOfMonth.Year, monthYearBox1.FirstDateOfMonth.Month, 15);
                groupBox2.Enabled = false;
                rdoTglTerima.Checked = true;
            }

            if (p2.Checked)
            {
                T1.Enabled = false;
                t2.Enabled = false;
                monthYearBox1.Enabled = true;
             
                T1.DateValue = new DateTime(monthYearBox1.FirstDateOfMonth.Year, monthYearBox1.FirstDateOfMonth.Month, 16);
                t2.DateValue = monthYearBox1.LastDateOfMonth;
                groupBox2.Enabled = false;
                rdoTglTerima.Checked = true;
            }
        }
    }
}
