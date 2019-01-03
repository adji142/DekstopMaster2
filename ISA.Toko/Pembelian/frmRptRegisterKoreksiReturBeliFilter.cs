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
using ISA.FTP;

namespace ISA.Toko.Pembelian
{
    public partial class frmRptRegisterKoreksiReturBeliFilter : ISA.Toko.BaseForm
    {
        public frmRptRegisterKoreksiReturBeliFilter()
        {
            InitializeComponent();
        }

        private void frmRptRegisterKoreksiReturBeliFilter_Load(object sender, EventArgs e)
        {
            
            this.Text = "Pembelian";
            T1.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            t2.DateValue = DateTime.Now;

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
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            T1.Focus();
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (T1.DateValue.HasValue == false || t2.DateValue.HasValue == false)
            {
                errorProvider1.SetError(T1, "Range Tgl. Koreksi masih kosong");
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
                    db.Commands.Add(db.CreateCommand("rsp_ReturBeli_RegisterKoreksiReturBeli"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, T1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, t2.DateValue));

                    if (cboGudang.SelectedValue.ToString() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, cboGudang.SelectedValue.ToString()));

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
                    if (MessageBox.Show("Upload register koreksi retur pembelian ?", "Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            DataSet ds = new DataSet();
                            if (dt.Rows.Count > 0)
                            {
                                ds.Tables.Add(dt);
                                string gudang = GlobalVar.Gudang;
                                string fileOuput = FtpEngine.UploadDirectory + "\\" + "UPLOADHIKRB" + gudang + " " + Guid.NewGuid().ToString() + ".xml";
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
            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptRegisterKoreksiReturBeli.rdlc", rptParams, dt, "dsReturPembelian_Data");
            ifrmReport.Show();
        } 

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void p0_CheckedChanged(object sender, EventArgs e)
        {
            if (p0.Checked)
            {
                T1.Enabled = true;
                t2.Enabled = true;
                T1.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                t2.DateValue = DateTime.Now;

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

            }
        }

        private void p1_CheckedChanged(object sender, EventArgs e)
        {
            if (p0.Checked)
            {
                T1.Enabled = true;
                t2.Enabled = true;
                T1.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                t2.DateValue = DateTime.Now;

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

            }

            if (p2.Checked)
            {
                T1.Enabled = false;
                t2.Enabled = false;
                monthYearBox1.Enabled = true;

                T1.DateValue = new DateTime(monthYearBox1.FirstDateOfMonth.Year, monthYearBox1.FirstDateOfMonth.Month, 16);
                t2.DateValue = monthYearBox1.LastDateOfMonth;

            }
        }
    }
}
