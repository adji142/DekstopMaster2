using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.DAL;
using System.IO;
using System.Globalization;

namespace ISA.Trading.PSReport
{
    public partial class frmSendToMail : ISA.Trading.BaseForm
    {
        public frmSendToMail()
        {
            InitializeComponent();
        }

        private void frmSendToMail_Load(object sender, EventArgs e)
        {

        }

        private void cmbProses_Click(object sender, EventArgs e)
        {
            RunProsesLaporan();
        }

        //Fungsi untuk generate laporan, dipanggil otomatis di timer_tick sesuai waktu yang sudah ditentukan by Afif
        private void ProsesLaporan(string timeState)
        {
            DateTime d1;
            DateTime d2;

            int day = GlobalVar.DateTimeOfServer.Day;
            int thn = GlobalVar.DateTimeOfServer.Year;
            int bln = GlobalVar.DateTimeOfServer.Month;
            DateTime D1 = new DateTime(thn, bln, 1);

            string logName = "LogDepo-" + day + bln + thn + "-" + timeState;

            if (!EmailSent(logName))
            {
                if (MessageBox.Show("System akan memproses laporan untuk dikirim ke email. Proses Laporan ?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                return;
            }

            d1 = D1;
            if (timeState == "pagi")
            {
                int har2 = GlobalVar.DateTimeOfServer.Day - 1;
                DateTime D2 = new DateTime(thn, bln, har2);
                d2 = D2;
            }
            else
            {
                d2 = GlobalVar.DateTimeOfServer;
            }

            Cursor.Current = Cursors.WaitCursor;

            DataTable dtSales = new DataTable();
            DataTable dtGit = new DataTable();
            DataSet dsFR = new DataSet();
            DataSet dsSales = new DataSet();

            string[] fileName = new string[5];
            string[] file = new string[5];

            string dir = "C:\\Temp\\";

            fileName[0] = "Kunjuangan Harian Salesman_" + bln + thn;
            fileName[4] = "Performance Salesman_" + bln + thn;
            fileName[1] = "Good In Transit_" + bln + thn;
            fileName[2] = "Laporan Sales_" + bln + thn;
            fileName[3] = "Laporan Sales Detail_" + bln + thn;

            for (int i = 0; i < fileName.Length; i++)
            {
                file[i] = dir + fileName[i] + ".xlsx";
            }

            Laporan.Analisa.frmRptPerformanceSalesman frmSalesman = new ISA.Trading.Laporan.Analisa.frmRptPerformanceSalesman();
            Laporan.Analisa.frmanalisaFR frmAnalisaFR = new ISA.Trading.Laporan.Analisa.frmanalisaFR();
            Penjualan.frmLaporanGoodInTransit frmGIT = new ISA.Trading.Penjualan.frmLaporanGoodInTransit();
            Laporan.Salesman.frmRptPerbandinganDONotaBO frmSales = new ISA.Trading.Laporan.Salesman.frmRptPerbandinganDONotaBO();

            try
            {
                using (Database db1 = new Database())
                {
                    db1.Commands.Add(db1.CreateCommand("rsp_monitoringtargetFR"));
                    db1.Commands[0].Parameters.Add(new Parameter("@tglAwal", SqlDbType.Date, d1));
                    db1.Commands[0].Parameters.Add(new Parameter("@tglAkhir", SqlDbType.Date, d2));
                    dsFR = db1.Commands[0].ExecuteDataSet();
                }

                using (Database db2 = new Database())
                {
                    db2.Commands.Add(db2.CreateCommand("rsp_Laporan_PerformanceSales"));
                    db2.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, d1));
                    db2.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, d2));
                    dtSales = db2.Commands[0].ExecuteDataTable();
                }

                using (Database db3 = new Database())
                {
                    db3.Commands.Add(db3.CreateCommand("rsp_Laporan_Penjualan_GoodInTransit")); //cek heri 05032013
                    db3.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, d1));
                    db3.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, d2));
                    db3.Commands[0].Parameters.Add(new Parameter("@cab1", SqlDbType.VarChar, GlobalVar.CabangID));
                    //db.Commands[0].Parameters.Add(new Parameter("@wilayah", SqlDbType.VarChar, GlobalVar.));
                    db3.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dtGit = db3.Commands[0].ExecuteDataTable();
                }

                using (Database db4 = new Database())
                {
                    db4.Commands.Add(db4.CreateCommand("rsp_Laporan_Salesman_PerbandinganSODONotaBO"));
                    db4.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, d1));
                    db4.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, d2));
                    db4.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    db4.Commands[0].Parameters.Add(new Parameter("@initPers", SqlDbType.VarChar, GlobalVar.PerusahaanID)); // <- Source Ini Dari ISA / ISA CABANG
                    //db.Commands[0].Parameters.Add(new Parameter("@KelompokBarang", SqlDbType.VarChar, cboKel.Text));
                    db4.Commands[0].Parameters.Add(new Parameter("@Jenis", SqlDbType.Int, 0));

                    dsSales = db4.Commands[0].ExecuteDataSet();
                }

                if (dsFR.Tables[0].Rows.Count > 0 ||
                    dtSales.Rows.Count > 0 ||
                    dtGit.Rows.Count > 0 ||
                    dsSales.Tables[0].Rows.Count > 0)
                {
                    frmAnalisaFR.DisplayReportAnalisaFRAuto(fileName[0], dsFR);
                    frmSalesman.DisplayReportPerformanceSalesmanAuto(fileName[4], dtSales, d1, d2);
                    frmGIT.DisplayReportGITAuto(fileName[1], dtGit, d1, d2);
                    frmSales.DisplayReportSalesAuto(fileName[2], fileName[3], dsSales.Tables[0], dsSales.Tables[1], d1, d2);
                }
                else
                {
                    frmAnalisaFR.DisplayReportAnalisaFRAuto(fileName[0], dsFR);
                    frmSalesman.DisplayReportPerformanceSalesmanAuto(fileName[4], dtSales, d1, d2);
                    frmGIT.DisplayReportGITAuto(fileName[1], dtGit, d1, d2);
                    frmSales.DisplayReportSalesAuto(fileName[2], fileName[3], dsSales.Tables[0], dsSales.Tables[1], d1, d2);
                }

                try
                {
                    Email.Send("Laporan Depo", file);
                    Email.Log(logName, "", 1, "Terkirim ke email tujuan pada " + timeState + " hari");
                }
                catch (Exception ex)
                {
                    Email.Log(logName, "", 0, "Terkirim ke email tujuan pada " + timeState + " hari");
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        //Validate data by Afif
        private bool EmailSent(string logName)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Log_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@LogName", SqlDbType.VarChar, logName));
                    db.Commands[0].Parameters.Add(new Parameter("@LogState", SqlDbType.Bit, 1));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return false;
        }

        private void RunProsesLaporan()
        {
            DateTime d1 = DateTime.Parse(GlobalVar.DateTimeOfServer.Date.ToString("yyyy/MM/dd") + " " + "08:45:01.00");
            DateTime d2 = GlobalVar.DateTimeOfServer;
            DateTime d3 = DateTime.Parse(GlobalVar.DateTimeOfServer.Date.ToString("yyyy/MM/dd") + " " + "16:00:01.00");

            if(d2 < d1)
            {
                ProsesLaporan("pagi");
            }else if (d2 > d1 && d2 < d3)
            {
                ProsesLaporan("pagi");
            }
            else if (d2 > d3)
            {
                ProsesLaporan("sore");
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
