using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Trading.SIP
{
    public partial class frmPerbandinganItemToko : ISA.Controls.BaseForm
    {
        string _KodeToko;

        public frmPerbandinganItemToko()
        {
            InitializeComponent();
        }

        public frmPerbandinganItemToko(Form caller, string KodeToko)
        {
            InitializeComponent();
            this.Caller = caller;
            _KodeToko = KodeToko;
        }

        private void frmPerbandinganItemToko_Load(object sender, EventArgs e)
        {
            txtTahun1.Text = GlobalVar.DateOfServer.AddYears(-1).Year.ToString();
            txtTahun2.Text = GlobalVar.DateOfServer.Year.ToString();
            try
            {
                Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_Toko_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    lblNamaToko.Text = dt.Rows[0]["NamaToko"].ToString();
                    lblAlamat.Text = dt.Rows[0]["Alamat"].ToString();
                    lblKota.Text = dt.Rows[0]["Kota"].ToString();
                    lblIDWil.Text = dt.Rows[0]["WilID"].ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void cmdProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtTahun1.Text) >= Convert.ToInt32(txtTahun2.Text))
                {
                    MessageBox.Show("Tahun Periode I Harus Lebih Kecil dari Tahun Periode II", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    //DataSet ds = new DataSet();
                    db.Commands.Add(db.CreateCommand("rsp_Perbandingan_Item_Toko"));
                    db.Commands[0].Parameters.Add(new Parameter("@Year1", SqlDbType.VarChar, txtTahun1.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Year2", SqlDbType.VarChar, txtTahun2.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    DisplayReport(dt);
                }
                else
                {
                    MessageBox.Show("Tidak Ada Data!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }



            //txtTahun1.Text = GlobalVar.DateOfServer.AddYears(-1).Year.ToString();
            //txtTahun2.Text = GlobalVar.DateOfServer.Year.ToString();
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    DataTable dt = new DataTable();
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("[usp_Toko_LIST]"));
            //        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
            //        dt = db.Commands[0].ExecuteDataTable();
            //    }
            //    if (dt.Rows.Count > 0)
            //    {
            //        lblNamaToko.Text = dt.Rows[0]["NamaToko"].ToString();
            //        lblAlamat.Text = dt.Rows[0]["Alamat"].ToString();
            //        lblKota.Text = dt.Rows[0]["Kota"].ToString();
            //        lblIDWil.Text = dt.Rows[0]["WilID"].ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}
            //finally
            //{
            //    Cursor = Cursors.Default;
            //}
        }

        private void DisplayReport(DataTable dt)
        {
            String YearNow = GlobalVar.DateOfServer.Year.ToString();
            String PeriodeI, PeriodeII;
            if (YearNow == txtTahun1.Text)
            {
                PeriodeI = String.Format("{0} s/d {1}", (new DateTime(Convert.ToInt32(txtTahun1.Text), 1, 1)).ToString("dd/MM/yyyy"), (GlobalVar.DateOfServer).ToString("dd/MM/yyyy"));
            }
            else
            {
                PeriodeI = String.Format("{0} s/d {1}", (new DateTime(Convert.ToInt32(txtTahun1.Text), 1, 1)).ToString("dd/MM/yyyy"), (new DateTime(Convert.ToInt32(txtTahun1.Text), 12, 31)).ToString("dd/MM/yyyy"));
            }

            if (YearNow == txtTahun2.Text)
            {
                PeriodeII = String.Format("{0} s/d {1}", (new DateTime(Convert.ToInt32(txtTahun2.Text), 1, 1)).ToString("dd/MM/yyyy"), (GlobalVar.DateOfServer).ToString("dd/MM/yyyy"));
            }
            else
            {
                PeriodeII = String.Format("{0} s/d {1}", (new DateTime(Convert.ToInt32(txtTahun2.Text), 1, 1)).ToString("dd/MM/yyyy"), (new DateTime(Convert.ToInt32(txtTahun2.Text), 12, 31)).ToString("dd/MM/yyyy"));
            }

            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("PeriodeI", PeriodeI));
            rptParams.Add(new ReportParameter("PeriodeII", PeriodeII));
            rptParams.Add(new ReportParameter("NamaToko", lblNamaToko.Text));
            rptParams.Add(new ReportParameter("Alamat", lblAlamat.Text));
            rptParams.Add(new ReportParameter("Kota", lblKota.Text));
            rptParams.Add(new ReportParameter("IDWil", lblIDWil.Text));
            rptParams.Add(new ReportParameter("TahunI", txtTahun1.Text));
            rptParams.Add(new ReportParameter("TahunII", txtTahun2.Text));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserName + ", " + GlobalVar.DateTimeOfServer.ToString("dd/MM/yyyy HH:mm:ss")));

            frmReportViewer ifrmReport = new frmReportViewer("SIP.rptPerbandinganItemToko.rdlc", rptParams, dt, "dsPerbandinganItemToko_Data1");
            ifrmReport.Text = "Laporan Perbandingan Item Toko";
            ifrmReport.Show();
        }

    }
}
