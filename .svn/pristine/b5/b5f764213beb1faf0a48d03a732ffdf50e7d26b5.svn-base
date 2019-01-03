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


namespace ISA.Trading.SIP
{
    public partial class frmRptProgresSKUToko : ISA.Controls.BaseForm
    {
        private string kodeToko;
        private string namaToko;
        private string alamatToko;
        private string kotaToko;
        private string wilID;

        private DateTime ToDate
        {
            get
            {
                if (txtYear.Text == string.Empty)
                {
                    DateTime today = GlobalVar.DateOfServer;

                    if (today.Month == 1)
                        txtYear.Text = (today.Year - 1).ToString();
                    else
                        txtYear.Text = today.Year.ToString();
                }

                int m = cboMonth.SelectedIndex + 1;
                int y = int.Parse(txtYear.Text);
                if (m == 12)
                {
                    m = 1;
                    y++;
                }
                else
                {
                    m++;
                }
                return (new DateTime(y, m, 1).AddDays(-1));
            }
        }

        private DateTime FromDate
        {
            get
            {
                DateTime prevYear = ToDate.AddYears(-1).AddMonths(1);
                return new DateTime(prevYear.Year, prevYear.Month, 1);
            }
        }

        public frmRptProgresSKUToko(string kodeToko, string namaToko, string alamatToko, string kotaToko, string wilID)
        {
            this.kodeToko = kodeToko;
            this.namaToko = namaToko;
            this.alamatToko = alamatToko;
            this.kotaToko = kotaToko;
            this.wilID = wilID;

            InitializeComponent();
        }

        public frmRptProgresSKUToko()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptProgresSKUToko_Load(object sender, EventArgs e)
        {
            DateTime today = GlobalVar.DateOfServer;

            int monthIndex = 0;
            if (today.Month == 1)
            {
                monthIndex = 11;
                txtYear.Text = (today.Year - 1).ToString();
            }
            else
            {
                monthIndex = (today.Month - 1) - 1;
                txtYear.Text = today.Year.ToString();
            }

            cboMonth.SelectedIndex = monthIndex;
            dtbFrom.DateValue = FromDate;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            DateTime today = GlobalVar.DateOfServer;
            DateTime firstDay = new DateTime(today.Year, today.Month, 1);

            if (ToDate >= firstDay)
            {
                MessageBox.Show("Bulan dan tahun yang dipilih harus bulan lampau.");
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_ProgresSKUToko]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, (DateTime)dtbFrom.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, this.kodeToko));

                    dt = db.Commands[0].ExecuteDataTable();
                }


                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }

                if (radioButton1.Checked)
                {
                    DataTable dtFiltered = new DataTable();
                    try
                    {
                        dtFiltered = dt.Select("QtyOrderBlnBerjalan = 0").CopyToDataTable();

                    }
                    catch { };

                    dt.Rows.Clear();
                    dt = dtFiltered.Copy();
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
            string fromDate = ((DateTime)dtbFrom.DateValue).ToString("dd/MM/yyyy");
            string toDate = ToDate.ToString("dd/MM/yyyy");

            string periode = String.Format("Periode {0} s/d {1}", fromDate, toDate);

            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserName", SecurityManager.UserName));
            rptParams.Add(new ReportParameter("KodeCabang", GlobalVar.CabangID));
            rptParams.Add(new ReportParameter("NamaToko", this.namaToko));
            rptParams.Add(new ReportParameter("AlamatToko", this.alamatToko));
            rptParams.Add(new ReportParameter("Kota", this.kotaToko));
            rptParams.Add(new ReportParameter("IdWil", this.wilID));
            rptParams.Add(new ReportParameter("KodeToko", this.kodeToko));
            rptParams.Add(new ReportParameter("Kelompok", string.Empty));

            frmReportViewer ifrmReport = new frmReportViewer("SIP.rptProgresSKUToko.rdlc", rptParams, dt, "dsProgresSKUToko_Data");
            ifrmReport.Text = "Report";
            ifrmReport.Show();
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtbFrom.DateValue = FromDate;
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (txtYear.Text.Length == 4 && IsNumber(txtYear.Text))
                dtbFrom.DateValue = FromDate;
        }

        private bool IsNumber(string value)
        {
            bool result = true;

            if (value != string.Empty)
            {
                foreach (char c in value.ToCharArray())
                {
                    if (!Char.IsDigit(c))
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
                result = false;

            return result;
        }

    }
}
