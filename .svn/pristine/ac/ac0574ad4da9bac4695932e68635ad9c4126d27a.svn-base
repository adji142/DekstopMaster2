using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using ISA.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.Reporting.WinForms;
namespace ISA.Trading.Laporan.Analisa
{
    public partial class frmanalisaFR : ISA.Trading.BaseForm
    {
        MailMessage mail = new MailMessage();

        public frmanalisaFR()
        {
            InitializeComponent();
        }

        private void frmanalisaFR_Load(object sender, EventArgs e)
        {
            Title = "MONITORING TARGET FIXED ROUTE";
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("rsp_monitoringtargetFR"));
                db.Commands[0].Parameters.Add(new Parameter("@tglAwal", SqlDbType.Date, monthYearBox1.FirstDateOfMonth));
                db.Commands[0].Parameters.Add(new Parameter("@tglAkhir", SqlDbType.Date, monthYearBox1.LastDateOfMonth));
                ds = db.Commands[0].ExecuteDataSet();
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                DisplayReportAnalisaFR(ds);
            }
            else
            {
                DisplayReportAnalisaFR(ds);
            }
        }

        private void DisplayReportAnalisaFR(DataSet ds)
        {
            string _blntahun = monthYearBox1.MonthName + " " + monthYearBox1.Year;
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(GenerateReportExcel(ds));

                Byte[] bin = exs[0].GetAsByteArray();

                //string file = "C:\\Temp\\RekapHutanDetailPerInvoice.xls";
                //ws.Cells.Style.ShrinkToFit = true;
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Kunjungan Harian Salesman_" + _blntahun + "_" + GlobalVar.DateTimeOfServer.ToString("yyyyMMddhhiiss") + ".xlsx";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    System.IO.File.WriteAllBytes(file, bin);
                    Email.Send("Kunjungan Harian Salesman", file);
                    MessageBox.Show("Laporan Selesai. " + file);
                    System.Diagnostics.Process.Start(sf.FileName.ToString());
                }
            }

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void DisplayReportAnalisaFRAuto(string fileName, DataSet ds)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(GenerateReportExcel(ds));

                Byte[] bin = exs[0].GetAsByteArray();

                string dir = "C:\\Temp\\";
                string file = dir + fileName + ".xlsx";
                System.IO.File.WriteAllBytes(file, bin);
                
            }

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private ExcelPackage GenerateReportExcel(DataSet ds)
        {
            string _blntahun = monthYearBox1.MonthName + " " + monthYearBox1.Year;
            int _no = 1;
            string _no1 = "01";
            int _enddate = monthYearBox1.LastDateOfMonth.Day;
            string _judullaporan = "Jadwal Detail Kunjungan Harian Salesman";
            ExcelPackage p = new ExcelPackage();
            p.Workbook.Properties.Author = "SAS";
            p.Workbook.Properties.Title = _judullaporan;
            int _kolommulai = 9;
            int MaxCol = 7 + (10 * _enddate) + 10;
            int StartH = 5;
            p.Workbook.Worksheets.Add("Rekap");
            ExcelWorksheet ws = p.Workbook.Worksheets[1];
            ws.Name = "Rekap"; //Setting Sheet's name
            ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
            ws.Cells.Style.Font.Name = "Calibri";

            ws.Column(1).Width = 15;
            ws.Column(2).Width = 15;

            _kolommulai = 3;
            for (int i = 1; i <= _enddate; i++) {
                ws.Column(_kolommulai).Width = 15;
                ws.Column(_kolommulai + 1).Width = 15;
                ws.Column(_kolommulai + 2).Width = 15;
                ws.Column(_kolommulai + 3).Width = 15;
                ws.Column(_kolommulai + 4).Width = 15;
                ws.Column(_kolommulai + 5).Width = 15;
                ws.Column(_kolommulai + 6).Width = 15;
                ws.Column(_kolommulai + 7).Width = 15;
                ws.Column(_kolommulai + 8).Width = 15;
                ws.Column(_kolommulai + 9).Width = 15;

                _kolommulai = _kolommulai + 10;
            }
            ws.Column(_kolommulai).Width = 15;
            ws.Column(_kolommulai + 1).Width = 15;
            ws.Column(_kolommulai + 2).Width = 15;
            ws.Column(_kolommulai + 3).Width = 15;
            ws.Column(_kolommulai + 4).Width = 15;
            ws.Column(_kolommulai + 5).Width = 15;
            ws.Column(_kolommulai + 6).Width = 15;
            ws.Column(_kolommulai + 7).Width = 15;
            ws.Column(_kolommulai + 8).Width = 15;
            ws.Column(_kolommulai + 9).Width = 15;

            _kolommulai = _kolommulai + 9;

            MaxCol = _kolommulai;

            ws.Cells[1, 1].Value = "Rekap Kunjungan Harian Salesman";
            ws.Cells[1, 1, 1, 5].Merge = true;
            ws.Cells[1, 1, 1, 5].Style.Font.Size = 14;

            ws.Cells[3, 1].Value = "Cabang";
            ws.Cells[3, 2].Value = ": " + GlobalVar.Gudang;

            StartH = 5;

            ws.Cells[StartH, 1].Value = "Cabang";
            ws.Cells[StartH, 2].Value = "KodeSales";
            for (int i = 1; i <= 2; i++)
            {
                ws.Cells[StartH, i, StartH + 2, i].Merge = true;
            }
            _no = 1;
            _no1 = "01";
            _kolommulai = 3;

            for (int i = 1; i <= _enddate; i++)
            {
                _no1 = (i).ToString();
                if (i < 10)
                {
                    _no1 = "0" + _no1;
                }

                ws.Cells[StartH, _kolommulai].Value = _no1 + " " + _blntahun;
                ws.Cells[StartH, _kolommulai, StartH, _kolommulai + 7].Merge = true;

                ws.Cells[StartH + 1, _kolommulai].Value = "Call";
                ws.Cells[StartH + 1, _kolommulai, StartH + 1, _kolommulai + 1].Merge = true;
                ws.Cells[StartH + 2, _kolommulai].Value = "Target";
                ws.Cells[StartH + 2, _kolommulai + 1].Value = "Real";

                ws.Cells[StartH + 1, _kolommulai + 2].Value = "EC";
                ws.Cells[StartH + 1, _kolommulai + 2, StartH + 1, _kolommulai + 3].Merge = true;
                ws.Cells[StartH + 2, _kolommulai + 2].Value = "Target";
                ws.Cells[StartH + 2, _kolommulai + 3].Value = "Real";

                ws.Cells[StartH + 1, _kolommulai + 4].Value = "Ver";
                ws.Cells[StartH + 1, _kolommulai + 4, StartH + 1, _kolommulai + 5].Merge = true;
                ws.Cells[StartH + 2, _kolommulai + 4].Value = "Target";
                ws.Cells[StartH + 2, _kolommulai + 5].Value = "Real";

                ws.Cells[StartH + 1, _kolommulai + 6].Value = "Collection (Nom)";
                ws.Cells[StartH + 1, _kolommulai + 6, StartH + 1, _kolommulai + 7].Merge = true;
                ws.Cells[StartH + 2, _kolommulai + 6].Value = "Target";
                ws.Cells[StartH + 2, _kolommulai + 7].Value = "Real";

                //ws.Cells[StartH + 1, _kolommulai + 8].Value = "Collection (Nom)";
                //ws.Cells[StartH + 1, _kolommulai + 8, StartH + 1, _kolommulai + 9].Merge = true;
                //ws.Cells[StartH + 2, _kolommulai + 8].Value = "Target";
                //ws.Cells[StartH + 2, _kolommulai + 9].Value = "Real";

                _kolommulai = _kolommulai + 8;

            }
            ws.Cells[StartH, _kolommulai].Value = "TOTAL";
            ws.Cells[StartH, _kolommulai, StartH, _kolommulai + 5].Merge = true;

            ws.Cells[StartH + 1, _kolommulai].Value = "Call";
            ws.Cells[StartH + 1, _kolommulai, StartH + 1, _kolommulai + 1].Merge = true;
            ws.Cells[StartH + 2, _kolommulai].Value = "Target";
            ws.Cells[StartH + 2, _kolommulai + 1].Value = "Real";

            ws.Cells[StartH + 1, _kolommulai + 2].Value = "EC";
            ws.Cells[StartH + 1, _kolommulai + 2, StartH + 1, _kolommulai + 3].Merge = true;
            ws.Cells[StartH + 2, _kolommulai + 2].Value = "Target";
            ws.Cells[StartH + 2, _kolommulai + 3].Value = "Real";

            ws.Cells[StartH + 1, _kolommulai + 4].Value = "Ver";
            ws.Cells[StartH + 1, _kolommulai + 4, StartH + 1, _kolommulai + 5].Merge = true;
            ws.Cells[StartH + 2, _kolommulai + 4].Value = "Target";
            ws.Cells[StartH + 2, _kolommulai + 5].Value = "Real";

            ws.Cells[StartH + 1, _kolommulai + 6].Value = "Collection (Nom)";
            ws.Cells[StartH + 1, _kolommulai + 6, StartH + 1, _kolommulai + 7].Merge = true;
            ws.Cells[StartH + 2, _kolommulai + 6].Value = "Target";
            ws.Cells[StartH + 2, _kolommulai + 7].Value = "Real";

            //ws.Cells[StartH + 1, _kolommulai + 8].Value = "Collection (Nom)";
            //ws.Cells[StartH + 1, _kolommulai + 8, StartH + 1, _kolommulai + 9].Merge = true;
            //ws.Cells[StartH + 2, _kolommulai + 8].Value = "Target";
            //ws.Cells[StartH + 2, _kolommulai + 9].Value = "Real";

            _kolommulai = _kolommulai + 8;

            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.Font.Bold = true;
            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[StartH, 1, StartH + 2, _kolommulai].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



            //filldata
            _no = 1;
            int idx = StartH + 3;
            int _rowAwal = idx;
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                ws.Cells[idx, 1].Value = dr["GudangID"].ToString();
                ws.Cells[idx, 2].Value = dr["SalesID"].ToString();

                _kolommulai = 3;

                for (int i = 1; i <= _enddate; i++)
                {
                    _no1 = (i).ToString();
                    if (i < 10)
                    {
                        _no1 = "0" + _no1;
                    }
                    ws.Cells[idx, _kolommulai].Value = dr["ks" + _no1];
                    ws.Cells[idx, _kolommulai + 1].Value = dr["hk" + _no1];
                    ws.Cells[idx, _kolommulai + 2].Value = dr["ec" + _no1];
                    ws.Cells[idx, _kolommulai + 3].Value = dr["hec" + _no1];
                    ws.Cells[idx, _kolommulai + 4].Value = dr["xver" + _no1];
                    ws.Cells[idx, _kolommulai + 5].Value = dr["ver" + _no1];
                    ws.Cells[idx, _kolommulai + 6].Value = dr["piut"+_no1];
                    ws.Cells[idx, _kolommulai + 7].Value = dr["byr" + _no1];
                    //ws.Cells[idx, _kolommulai + 8].Value = dr["piut" + _no1];
                    //ws.Cells[idx, _kolommulai + 9].Value = dr["byr" + _no1];

                    _kolommulai = _kolommulai + 8;
                }

                ws.Cells[idx, _kolommulai].Value = dr["ksT"];
                ws.Cells[idx, _kolommulai + 1].Value = dr["hkT"];
                ws.Cells[idx, _kolommulai + 2].Value = dr["ecT"];
                ws.Cells[idx, _kolommulai + 3].Value = dr["hecT"];
                ws.Cells[idx, _kolommulai + 4].Value = dr["xverT"];
                ws.Cells[idx, _kolommulai + 5].Value = dr["verT"];
                ws.Cells[idx, _kolommulai + 6].Value = dr["piutT"];
                ws.Cells[idx, _kolommulai + 7].Value = dr["byrT"];
                //ws.Cells[idx, _kolommulai + 8].Value = dr["piutT"];
                //ws.Cells[idx, _kolommulai + 9].Value = dr["byrT"];

                _kolommulai = _kolommulai + 8;

                idx++;
            }
            ws.Cells[idx, 1].Value = "Total";
            ws.Cells[idx, 1, idx, 2].Merge = true;
            _kolommulai = 3;
            for (int i = 1; i <= _enddate; i++)
            {
                ws.Cells[idx, _kolommulai].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai].Address + ":" + ws.Cells[idx - 1, _kolommulai].Address + ")";
                ws.Cells[idx, _kolommulai + 1].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 1].Address + ":" + ws.Cells[idx - 1, _kolommulai + 1].Address + ")";
                ws.Cells[idx, _kolommulai + 2].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 2].Address + ":" + ws.Cells[idx - 1, _kolommulai + 2].Address + ")";
                ws.Cells[idx, _kolommulai + 3].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 3].Address + ":" + ws.Cells[idx - 1, _kolommulai + 3].Address + ")";
                ws.Cells[idx, _kolommulai + 4].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 4].Address + ":" + ws.Cells[idx - 1, _kolommulai + 4].Address + ")";
                ws.Cells[idx, _kolommulai + 5].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 5].Address + ":" + ws.Cells[idx - 1, _kolommulai + 5].Address + ")";
                ws.Cells[idx, _kolommulai + 6].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 6].Address + ":" + ws.Cells[idx - 1, _kolommulai + 6].Address + ")";
                ws.Cells[idx, _kolommulai + 7].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 7].Address + ":" + ws.Cells[idx - 1, _kolommulai + 7].Address + ")";
                //ws.Cells[idx, _kolommulai + 8].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 8].Address + ":" + ws.Cells[idx - 1, _kolommulai + 8].Address + ")";
                //ws.Cells[idx, _kolommulai + 9].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 9].Address + ":" + ws.Cells[idx - 1, _kolommulai + 9].Address + ")";

                _kolommulai = _kolommulai + 8;
            }

            ws.Cells[idx, _kolommulai].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai].Address + ":" + ws.Cells[idx - 1, _kolommulai].Address + ")";
            ws.Cells[idx, _kolommulai + 1].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 1].Address + ":" + ws.Cells[idx - 1, _kolommulai + 1].Address + ")";
            ws.Cells[idx, _kolommulai + 2].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 2].Address + ":" + ws.Cells[idx - 1, _kolommulai + 2].Address + ")";
            ws.Cells[idx, _kolommulai + 3].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 3].Address + ":" + ws.Cells[idx - 1, _kolommulai + 3].Address + ")";
            ws.Cells[idx, _kolommulai + 4].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 4].Address + ":" + ws.Cells[idx - 1, _kolommulai + 4].Address + ")";
            ws.Cells[idx, _kolommulai + 5].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 5].Address + ":" + ws.Cells[idx - 1, _kolommulai + 5].Address + ")";
            ws.Cells[idx, _kolommulai + 6].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 6].Address + ":" + ws.Cells[idx - 1, _kolommulai + 6].Address + ")";
            ws.Cells[idx, _kolommulai + 7].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 7].Address + ":" + ws.Cells[idx - 1, _kolommulai + 7].Address + ")";
            //ws.Cells[idx, _kolommulai + 8].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 8].Address + ":" + ws.Cells[idx - 1, _kolommulai + 8].Address + ")";
            //ws.Cells[idx, _kolommulai + 9].Formula = "=SUM(" + ws.Cells[_rowAwal, _kolommulai + 9].Address + ":" + ws.Cells[idx - 1, _kolommulai + 9].Address + ")";

            ws.Cells[idx, 1, idx, _kolommulai + 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[idx, 1, idx, _kolommulai + 9].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

            _kolommulai = _kolommulai + 7;


            //formating
            var border = ws.Cells[StartH, 1, idx, _kolommulai + 9].Style.Border;
            border = ws.Cells[StartH, 1, idx, _kolommulai].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[StartH + 3, 3, idx, MaxCol].Style.Numberformat.Format = "#,##0;(#,##0);0";

            ws.Cells[StartH + 3, 1, idx, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[StartH + 3, 1, idx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[StartH + 3, 3, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[StartH + 3, 3, idx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            
            return p;

            
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Anda akan download Rencana Kunjungan dan hasil kunjungan \n dari SalesForce. \n Data yang di ambil data 5 hari kebelakang. \n lanjutkan ?", "Warning", MessageBoxButtons.YesNo);
            if (dlg == DialogResult.Yes)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_PullDataSF"));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally {
                    MessageBox.Show("Sukses");
                }
            }
        }
    }
}
