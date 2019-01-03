using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Finance.Piutang.Report
{
    public partial class frmRptOpnameNota : ISA.Finance.BaseForm
    {
        public frmRptOpnameNota()
        {
            InitializeComponent();
        }

        private void frmRptOpnameNota_Load(object sender, EventArgs e)
        { 
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_UserWilID_List"));
                dt = db.Commands[0].ExecuteDataTable();
            }
            cboPemegangKP.DataSource = dt;
            cboPemegangKP.DisplayMember = "UserID";
            cboPemegangKP.ValueMember = "UserID";
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (rangeDateBox1.FromDate.Value.ToString() == "" || rangeDateBox1.ToDate.Value.ToString() == "")
            {
                MessageBox.Show("Tanggal Opname Masih Kosong!","Informasi");
            }
            else if ((rangeDateBox1.ToDate.Value - rangeDateBox1.FromDate.Value).TotalDays > 2)
            {
                MessageBox.Show("Tidak Boleh Lebih Dari 3 hari", "Informasi");
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                DataTable dtopname = new DataTable();
                DataTable dtbelumopname = new DataTable();
                DataTable dtbelumreg = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_NotaOpname"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@PemegangKP", SqlDbType.VarChar, cboPemegangKP.Text));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                this.Cursor = Cursors.Default;
                dtopname = ds.Tables[0];
                dtbelumopname = ds.Tables[1];
                dtbelumreg = ds.Tables[2];

                // this.Cursor = Cursors.n

                if (dtopname.Rows.Count > 0)
                {
                    DisplayReport(dtopname, "LAPORAN NOTA SUDAH OPNAME (Fisik Ada)", "Tgl Opname : ");
                }
                else
                {
                    MessageBox.Show("Tidak Ada Data Nota Sudah Opname", "Informasi");
                }

                if (dtbelumopname.Rows.Count > 0)
                {
                    DisplayReport(dtbelumopname, "LAPORAN NOTA BELUM OPNAME(Fisik Tidak Ada)", "Tgl Opname : ");
                }
                else
                {
                    MessageBox.Show("Tidak Ada Data Nota Belum Opname", "Informasi");
                }

                if (dtbelumreg.Rows.Count > 0)
                {
                    DisplayReport(dtbelumreg, "LAPORAN NOTA BELUM REGISTRASI", "Tgl Proses : ");
                }
                else
                {
                    MessageBox.Show("Tidak Ada Data Nota Belum Registrasi", "Informasi");
                }
            }
        }

        private void DisplayReport(DataTable dt, String judul, string NamaTgl)
        {
            String FromDate = Convert.ToDateTime(rangeDateBox1.FromDate.Value).ToString("dd-MMM-yyyy") + " sampai ";
            String ToDate = Convert.ToDateTime(rangeDateBox1.ToDate.Value).ToString("dd-MMM-yyyy");

            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("FromDate", FromDate));
            rptParams.Add(new ReportParameter("ToDate", ToDate));
            rptParams.Add(new ReportParameter("Judul", judul));
            rptParams.Add(new ReportParameter("NamaTgl", NamaTgl));

            //call report viewer
            //  frmReportViewer ifrmReport = new frmReportViewer("Penjualan.Report.rptRekapOrderHarian.rdlc", rptParams, dt, "dsPenjualan_Data");
            frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rptNotaOpname.rdlc", rptParams, dt, "dsNotaBarcode_Data1");
            ifrmReport.Show();

        }
    }
}
