using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using ISA.Trading.Class;

namespace ISA.Trading.Fixrute
{
    public partial class frmRptMonitoringSalesman : ISA.Trading.BaseForm
    {
        DataTable dtGit,dtDOPending,dtRekap,dtDetail,dtDOSelese;
        public frmRptMonitoringSalesman()
        {
            InitializeComponent();
        }

        private void frmRptMonitoringSalesman_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(DateTime.Now.ToString("ddMMyyy"));
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1);

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " dd,MMMM,yyyy";
            dateTimePicker1.ShowUpDown = true;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " dd,MMMM,yyyy";
            dateTimePicker2.ShowUpDown = true;
        }

        public void LaporanGit()
        {
            string cabang = GlobalVar.Gudang.Substring(0,2);
           
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("[rsp_Laporan_Fixrute_GoodInTransit]")); //cek heri 05032013
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime,dateTimePicker1.Value ));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dateTimePicker2.Value));
                db.Commands[0].Parameters.Add(new Parameter("@cab1", SqlDbType.VarChar, cabang));
                db.Commands[0].Parameters.Add(new Parameter("@wilayah", SqlDbType.VarChar, ""));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                dtGit = db.Commands[0].ExecuteDataTable();
            }
        }


        public void LaporanDOPending()
        {
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("rsp_Laporan_Fixrute_dopendingSales"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateTimePicker1.Value));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dateTimePicker2.Value));
                if (lookupSales1.SalesID != "")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales1.SalesID));
                }
               // db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, ""));

                dtDOPending = db.Commands[0].ExecuteDataTable();
            }
        }

        public void LaporanRekapKunjungan()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("rsp_RekapKunjunganSales"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateTimePicker1.Value));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dateTimePicker2.Value));
                if (lookupSales1.SalesID != "")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@kodesales", SqlDbType.VarChar, lookupSales1.SalesID));
                }
                dtRekap = db.Commands[0].ExecuteDataTable();
            }
        }

        public void LaporanDetailKunjungan()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("rsp_DetailKunjunganSales"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateTimePicker1.Value));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dateTimePicker2.Value));
                if (lookupSales1.SalesID != "")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@kodesales", SqlDbType.VarChar, lookupSales1.SalesID));
                }
                dtRekap = db.Commands[0].ExecuteDataTable();
            }
        }

        public void LaporanDO()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("rsp_LaporanPenyelesaianSales"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateTimePicker1.Value));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, dateTimePicker2.Value));
                //if (lookupSales1.SalesID != "")
                //{
                //    db.Commands[0].Parameters.Add(new Parameter("@kodesales", SqlDbType.VarChar, lookupSales1.SalesID));
                //}
                dtDOSelese = db.Commands[0].ExecuteDataTable();
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            LaporanGit();
            LaporanDOPending();
            LaporanRekapKunjungan();
            //LaporanDetailKunjungan();
            LaporanDO();//belum
            GenerateExcellKunjungan(dtGit,dtDOPending,dtRekap,dtDOSelese);
        }

        public void GenerateExcellKunjungan(DataTable dtGIT, DataTable dtDOPending, DataTable dtRekap, DataTable dtDOSelese)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Title = "MONITORING KUNJUNGAN SALES" + DateTime.Now.ToString("ddMMyyy");

                #region Laporan Rekap Kunjungan Sales
                p.Workbook.Worksheets.Add("Sheet1");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.View.ShowGridLines = false;                
                ws.Name = "Kunjungan"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";
                //Range rg = (Excel.Range)worksheetobject.Cells[1, 1];
                //rg.EntireColumn.NumberFormat = "MM/DD/YYYY";

                int MaxCol = 14;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 5;       //no
                ws.Cells[1, 2].Worksheet.Column(2).Width = 12;      //sales
                ws.Cells[1, 3].Worksheet.Column(3).Width = 8;       //jml kunj
                ws.Cells[1, 4].Worksheet.Column(4).Width = 10;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 25;      //area
                ws.Cells[1, 6].Worksheet.Column(6).Width = 31;      //namatoko
                ws.Cells[1, 7].Worksheet.Column(7).Width = 20;      //kota
                ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //fixrute
                ws.Cells[1, 9].Worksheet.Column(9).Width = 13;      //sts do
                ws.Cells[1, 10].Worksheet.Column(10).Width = 13;     //rp do
                ws.Cells[1, 11].Worksheet.Column(11).Width = 5;     //sku
                ws.Cells[1, 12].Worksheet.Column(12).Width = 17;    //sts toko
                ws.Cells[1, 13].Worksheet.Column(13).Width = 28;
                ws.Cells[1, 14].Worksheet.Column(14).Width = 28;

                ws.Cells[1, 1].Value = "LAPORAN HASIL KUNJUNGAN SALES";
                ws.Cells[3, 1].Value = "Tanggal  : "+ dateTimePicker1.Value.ToString("dd-MMM-yyy") + " s/d " +dateTimePicker2.Value.ToString("dd-MMM-yyy");
                ws.Cells[4, 1].Value = "";
                ws.Cells[1, 1, 1, MaxCol].Merge = true;
                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[1, 1].Style.Font.Size = 14;
                ws.Cells[2, 1].Style.Font.Size = 11;

                #region Generate Header
                ws.Cells[5, 1, 6, 1].Merge = true;
                ws.Cells[5, 2, 6, 2].Merge = true;
                ws.Cells[5, 3, 6, 3].Merge = true;
                ws.Cells[5, 4, 5, 12].Merge = true;
                //ws.Cells[5, 4, 5, 11].Merge = true;
                ws.Cells[5, 13, 6, 13].Merge = true;
                ws.Cells[5, 14, 6, 14].Merge = true;

                ws.Cells[5, 1].Value = "NO.";
                ws.Cells[5, 2].Value = "SALESMAN";
                ws.Cells[5, 3].Value = "JLH.KUNJ";
                ws.Cells[5, 4].Value = "INFORMASI KUNJUNGAN";
                ws.Cells[6, 4].Value = "TGL.KUNJ";
                ws.Cells[6, 5].Value = "AREA";
                ws.Cells[6, 6].Value = "NAMA TOKO";
                ws.Cells[6, 7].Value = "KOTA";
                ws.Cells[6, 8].Value = "FIXROUTE";
                ws.Cells[6, 9].Value = "STS.D/O.";
                ws.Cells[6, 10].Value = "Rp.D/O";
                ws.Cells[6, 11].Value = "SKU";
                ws.Cells[6, 12].Value = "STS.TOKO";
                ws.Cells[5, 13].Value = "ALASAN TIDAK ORDER";
                ws.Cells[5, 14].Value = "KENDALA";

                ws.Cells[5, 1, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[5, 1, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                #endregion

                #region FillData
                int brs = 7, idx = 7, num = 1;
                double RpDO = 0;

                foreach (DataRow dr in dtRekap.Rows)
                {
                    string status = dr["kd_toko"].ToString();
                    string statustoko;
                    if (status == "")
                        statustoko = "Tidak terdaftar";
                    else
                        statustoko = "Sdh Terdaftar";

                    //DateTime tgl = Convert.ToDateTime(dr["tgl_kunj"].ToString());
                    //string tanggalKunj = tgl.ToString("dd-MMM-yyy");

                    ws.Cells[idx, 1].Value = num;
                    ws.Cells[idx, 2].Value = dr["kd_sales"];
                    ws.Cells[idx, 3].Value = dr["jmlkunj"];
                    //ws.Cells[idx, 4].Value = dr["tgl_kunj"];
                    ws.Cells[idx, 4].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr["tgl_kunj"], ""));
                    ws.Cells[idx, 5].Value = dr["area"];
                    ws.Cells[idx, 6].Value = dr["namatoko"];
                    ws.Cells[idx, 7].Value = dr["kota"];
                    ws.Cells[idx, 8].Value = dr["Fixroute"];
                    ws.Cells[idx, 9].Value = dr["stsdo"];
                    ws.Cells[idx, 10].Value = dr["SumRpNet3"];
                    ws.Cells[idx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[idx, 11].Value = dr["sku"];
                    ws.Cells[idx, 12].Value = statustoko;
                    ws.Cells[idx, 13].Value = dr["alasan"];
                    ws.Cells[idx, 14].Value = dr["kendala"];
                    RpDO +=  Convert.ToDouble(Tools.isNull(dr["SumRpNet3"],"0").ToString());
                    idx++;
                    num++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[5, 1, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[5, 1, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws.Cells[6, 1, 6, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[6, 1, 6, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 9].Value = "Jumlah";
                ws.Cells[idx, 9].Style.Font.Bold = true;
                ws.Cells[idx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 10].Value = RpDO;
                ws.Cells[idx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[idx, 10].Style.Font.Color.SetColor(Color.Blue);

                var border = ws.Cells[5, 1, brs-1, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[brs, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[idx, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style = ExcelBorderStyle.None;
                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.None;

                ws.Cells[idx, 1].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[idx, 1].Style.Font.Size = 8;
                ws.Cells[idx, 1].Style.Font.Italic = true;

                #endregion
                #endregion

                #region Laporan Penyelesaian DO

                p.Workbook.Worksheets.Add("Sheet2");
                ExcelWorksheet ws1 = p.Workbook.Worksheets[2];

                ws1.Name = "Penyelesaian DO"; //Setting Sheet's name
                ws1.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws1.Cells.Style.Font.Name = "Calibri";
                //Range rg = (Excel.Range)worksheetobject.Cells[1, 1];
                //rg.EntireColumn.NumberFormat = "MM/DD/YYYY";

                int MaxCol1 = 21;

                ws1.Cells[1, 1].Worksheet.Column(1).Width = 8;
                ws1.Cells[1, 2].Worksheet.Column(2).Width = 35;
                ws1.Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws1.Cells[1, 4].Worksheet.Column(4).Width = 15;
                ws1.Cells[1, 5].Worksheet.Column(5).Width = 9; //nomor
                ws1.Cells[1, 6].Worksheet.Column(6).Width = 11;//tanggal
                ws1.Cells[1, 7].Worksheet.Column(7).Width = 5;//jw
                ws1.Cells[1, 8].Worksheet.Column(8).Width = 9;//nomor
                ws1.Cells[1, 9].Worksheet.Column(9).Width = 11;
                ws1.Cells[1, 10].Worksheet.Column(10).Width = 15;
                ws1.Cells[1, 11].Worksheet.Column(11).Width = 5;//jw
                ws1.Cells[1, 12].Worksheet.Column(12).Width = 9;
                ws1.Cells[1, 13].Worksheet.Column(13).Width = 11;
                ws1.Cells[1, 14].Worksheet.Column(14).Width = 15;
                ws1.Cells[1, 15].Worksheet.Column(15).Width = 5;//jw
                ws1.Cells[1, 16].Worksheet.Column(16).Width = 15;//tglkirim
                ws1.Cells[1, 17].Worksheet.Column(17).Width = 5;//jw
                ws1.Cells[1, 18].Worksheet.Column(18).Width = 11;
                ws1.Cells[1, 19].Worksheet.Column(19).Width = 15;
                ws1.Cells[1, 20].Worksheet.Column(20).Width = 15;
                ws1.Cells[1, 21].Worksheet.Column(21).Width = 10;

                ws1.Cells[1, 1].Value = "LAPORAN PENYELESAIAN DO";
                ws1.Cells[3, 1].Value = "Tanggal  : " + dateTimePicker1.Value.ToString("dd-MMM-yyy") + " s/d " + dateTimePicker2.Value.ToString("dd-MMM-yyy");
                ws1.Cells[4, 1].Value = "";
                ws1.Cells[1, 1, 1, MaxCol1].Merge = true;
                ws1.Cells[2, 1, 2, MaxCol1].Merge = true;
                ws1.Cells[1, 1, 2, MaxCol1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws1.Cells[1, 1, 2, MaxCol1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws1.Cells[1, 1, 2, MaxCol1].Style.Font.Bold = true;
                ws1.Cells[1, 1].Style.Font.Size = 14;
                ws1.Cells[2, 1].Style.Font.Size = 11;

                #region Generate Header
                ws1.Cells[5, 1, 6, 1].Merge = true;
                ws1.Cells[5, 2, 6, 2].Merge = true;
                ws1.Cells[5, 3, 6, 3].Merge = true;
                ws1.Cells[5, 4, 6, 4].Merge = true;//SALESMAN
                ws1.Cells[5, 5, 5, 6].Merge = true;
                ws1.Cells[5, 7, 6, 7].Merge = true;
                ws1.Cells[5, 8, 5, 10].Merge = true;
                ws1.Cells[5, 11, 6, 11].Merge = true;
                ws1.Cells[5, 12, 5, 14].Merge = true;
                ws1.Cells[5, 15, 6, 15].Merge = true;
                ws1.Cells[5, 16, 6, 16].Merge = true;
                ws1.Cells[5, 17, 6, 17].Merge = true;
                ws1.Cells[5, 18, 5, 19].Merge = true;
                ws1.Cells[5, 20, 6, 20].Merge = true;
                ws1.Cells[5, 21, 6, 21].Merge = true;

                ws1.Cells[5, 1].Value = "NO.";
                ws1.Cells[5, 2].Value = "NAMA TOKO";
                ws1.Cells[5, 3].Value = "KOTA";
                ws1.Cells[5, 4].Value = "SALESMAN";
                ws1.Cells[5, 5].Value = "SALES ORDER";
                ws1.Cells[6, 5].Value = "NOMOR";
                ws1.Cells[6, 6].Value = "TANGGAL";
                ws1.Cells[5, 7].Value = "JW";
                ws1.Cells[5, 8].Value = "DELIVERY ORDER";
                ws1.Cells[6, 8].Value = "NOMOR";
                ws1.Cells[6, 9].Value = "TANGGAL";
                ws1.Cells[6, 10].Value = "JUMLAH";
                ws1.Cells[5, 11].Value = "JW";
                ws1.Cells[5, 12].Value = "NOTA/FAKTUR";
                ws1.Cells[6, 12].Value = "NOMOR";
                ws1.Cells[6, 13].Value = "TANGGAL";
                ws1.Cells[6, 14].Value = "JUMLAH";
                ws1.Cells[5, 15].Value = "JW";
                ws1.Cells[5, 16].Value = "TGL.KIRIM";
                ws1.Cells[5, 17].Value = "JW";
                ws1.Cells[5, 18].Value = "TERIMA TOKO";
                ws1.Cells[6, 18].Value = "TANGGAL";
                ws1.Cells[6, 19].Value = "JUMLAH";
                ws1.Cells[5, 20].Value = "AVERAGE";
                ws1.Cells[5, 21].Value = "JNS.TR";

                ws1.Cells[5, 1, 6, MaxCol1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws1.Cells[5, 1, 6, MaxCol1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx1 = 7;
                int num1 = 1;
                foreach (DataRow dr in dtDOSelese.Rows)
                {
                    int jw1 = Convert.ToInt32(dr["jw1"]);
                    int jw2 = Convert.ToInt32(dr["jw2"]);
                    int jw3 = Convert.ToInt32(dr["jw3"]);
                    int jw4 = Convert.ToInt32(dr["jw4"]);
                    int avg = jw1 + jw2 + jw3 + jw4;

                    ws1.Cells[idx1, 1].Value = num1;
                    ws1.Cells[idx1, 2].Value = dr["NamaToko"];
                    ws1.Cells[idx1, 3].Value = dr["Kota"];
                    ws1.Cells[idx1, 4].Value = dr["salesman"];
                    ws1.Cells[idx1, 5].Value = dr["NoRequest"];
                    ws1.Cells[idx1, 6].Value = dr["TglRequest"];
                    ws1.Cells[idx1, 7].Value = dr["jw1"];
                    ws1.Cells[idx1, 8].Value = dr["NoDO"];
                    ws1.Cells[idx1, 9].Value = dr["TglDO"];
                    ws1.Cells[idx1, 10].Value = dr["SumRpNet"];
                    ws1.Cells[idx1, 11].Value = dr["jw2"];
                    ws1.Cells[idx1, 12].Value = dr["NoNota"];
                    ws1.Cells[idx1, 13].Value = dr["TglSuratJalan"];
                    ws1.Cells[idx1, 14].Value = dr["SumRpNet3"];
                    ws1.Cells[idx1, 15].Value = dr["jw3"];
                    ws1.Cells[idx1, 16].Value = dr["TglKirim"];
                    ws1.Cells[idx1, 17].Value = dr["jw4"];
                    ws1.Cells[idx1, 18].Value = dr["TglTerima"];
                    ws1.Cells[idx1, 19].Value = dr["SumRpNet3"];
                    ws1.Cells[idx1, 20].Value = avg;
                    ws1.Cells[idx1, 21].Value = dr["TransactionType"];

                    idx1++;
                    num1++;
                }
                #endregion

                #region Summary & Formatting
                ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws1.Cells[5, 1, 5, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                ws1.Cells[6, 1, 6, MaxCol1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws1.Cells[6, 1, 6, MaxCol1].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border1 = ws1.Cells[5, 1, idx1 + 1, MaxCol1].Style.Border;
                //ws.Cells[5, 7].sty

                border1.Bottom.Style =
                border1.Top.Style =
                border1.Left.Style =
                border1.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region Laporan Penyelesaian GIT

                p.Workbook.Worksheets.Add("Sheet3");
                ExcelWorksheet ws2 = p.Workbook.Worksheets[3];

                ws2.Name = "GIT"; //Setting Sheet's name
                ws2.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws2.Cells.Style.Font.Name = "Calibri";
                //Range rg = (Excel.Range)worksheetobject.Cells[1, 1];
                //rg.EntireColumn.NumberFormat = "MM/DD/YYYY";

                int MaxCol2 = 15;

                ws2.Cells[1, 1].Worksheet.Column(1).Width = 15;
                ws2.Cells[1, 2].Worksheet.Column(2).Width = 13;
                ws2.Cells[1, 3].Worksheet.Column(3).Width = 15;
                ws2.Cells[1, 4].Worksheet.Column(4).Width = 30;
                ws2.Cells[1, 5].Worksheet.Column(5).Width = 60; 
                ws2.Cells[1, 6].Worksheet.Column(6).Width = 20;
                ws2.Cells[1, 7].Worksheet.Column(7).Width = 13;
                ws2.Cells[1, 8].Worksheet.Column(8).Width = 5;
                ws2.Cells[1, 9].Worksheet.Column(9).Width = 15;
                ws2.Cells[1, 10].Worksheet.Column(10).Width = 15;
                ws2.Cells[1, 11].Worksheet.Column(11).Width = 15;
                ws2.Cells[1, 12].Worksheet.Column(12).Width = 15;
                ws2.Cells[1, 13].Worksheet.Column(13).Width = 15;
                ws2.Cells[1, 14].Worksheet.Column(14).Width = 13;
                ws2.Cells[1, 15].Worksheet.Column(15).Width = 20;


                ws2.Cells[1, 1].Value = "GOOD IN TRANSIT";
                ws2.Cells[3, 1].Value = "PERIODE  : " + dateTimePicker1.Value.ToString("dd-MMM-yyy") + " S.D " + dateTimePicker2.Value.ToString("dd-MMM-yyy");
                ws2.Cells[4, 1].Value = "";
                ws2.Cells[1, 1, 1, MaxCol2].Merge = true;
                ws2.Cells[2, 1, 2, MaxCol2].Merge = true;
                ws2.Cells[1, 1, 2, MaxCol2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[1, 1, 2, MaxCol2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws2.Cells[1, 1, 2, MaxCol2].Style.Font.Bold = true;
                ws2.Cells[1, 1].Style.Font.Size = 14;
                ws2.Cells[2, 1].Style.Font.Size = 11;

                #region Generate Header

                ws2.Cells[5, 1].Value = "TGL.NOTA";
                ws2.Cells[5, 2].Value = "NO.NOTA";
                ws2.Cells[5, 3].Value = "KD.SALES";
                ws2.Cells[5, 4].Value = "NAMA TOKO";
                ws2.Cells[5, 5].Value = "ALAMAT";
                ws2.Cells[5, 6].Value = "KOTA";
                ws2.Cells[5, 7].Value = "RP.NOTA";
                ws2.Cells[5, 8].Value = "TR";
                ws2.Cells[5, 9].Value = "TGL.PL";
                ws2.Cells[5, 10].Value = "CHEKER_1";
                ws2.Cells[5, 11].Value = "CHEKER_2";
                ws2.Cells[5, 12].Value = "TGL.SJ";
                ws2.Cells[5, 13].Value = "TGL.TERIMA";
                ws2.Cells[5, 14].Value = "ASAL DO";
                ws2.Cells[5, 15].Value = "KETERANGAN";

                ws2.Cells[5, 1, 6, MaxCol2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[5, 1, 6, MaxCol2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx2 = 6;
                //int num = 1;
                foreach (DataRow dr in dtGit.Rows)
                {
                    DateTime TglN = Convert.ToDateTime(dr["TglNota"]);
                    string TglNota = TglN.ToString("dd-MMM-yyy");

                    //DateTime tglPl = Convert.ToDateTime(dr["TglSerahTerimaChecker"].ToString());
                    //string TglPL = tglPl.ToString("dd-MMM-yyy");

                    //DateTime tglTRm = Convert.ToDateTime(dr["TglTerima"]);
                    //string TglTerima = tglTRm.ToString("dd-MMM-yyy");

                    //DateTime tglSj = Convert.ToDateTime(dr["TglSuratJalan"]);
                    //string TglSuratJalan = tglSj.ToString("dd-MMM-yyy");

                    ws2.Cells[idx2, 1].Value = TglNota;
                    ws2.Cells[idx2, 2].Value = dr["NoNota"];
                    ws2.Cells[idx2, 3].Value = dr["KodeSales"];
                    ws2.Cells[idx2, 4].Value = dr["toko"];
                    ws2.Cells[idx2, 5].Value = dr["Alamat"];
                    ws2.Cells[idx2, 6].Value = dr["Kota"];
                    ws2.Cells[idx2, 7].Value = dr["RpNet"];
                    ws2.Cells[idx2, 8].Value = dr["TransactionType"];
                    ws2.Cells[idx2, 9].Value = dr["TglSerahTerimaChecker"];
                    ws2.Cells[idx2, 10].Value = "";//checker1
                    ws2.Cells[idx2, 11].Value = "";//checker2
                    ws2.Cells[idx2, 12].Value = dr["TglSuratJalan"];
                    ws2.Cells[idx2, 13].Value = dr["TglTerima"];
                    ws2.Cells[idx2, 14].Value = dr["NoDo"];
                    ws2.Cells[idx2, 15].Value = "";
                    
                    idx2++;

                }
                #endregion

                #region Summary & Formatting
                ws2.Cells[5, 1, 5, MaxCol2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Cells[5, 1, 5, MaxCol2].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border2 = ws2.Cells[5, 1, idx2 + 1, MaxCol2].Style.Border;
                //ws.Cells[5, 7].sty

                border2.Bottom.Style =
                border2.Top.Style =
                border2.Left.Style =
                border2.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region DO Pending

                p.Workbook.Worksheets.Add("Sheet4");
                ExcelWorksheet ws3 = p.Workbook.Worksheets[4];

                ws3.Name = "Do Pending"; //Setting Sheet's name
                ws3.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws3.Cells.Style.Font.Name = "Calibri";
                //Range rg = (Excel.Range)worksheetobject.Cells[1, 1];
                //rg.EntireColumn.NumberFormat = "MM/DD/YYYY";

                int MaxCol3 = 11;

                ws3.Cells[1, 1].Worksheet.Column(1).Width = 15;
                ws3.Cells[1, 2].Worksheet.Column(2).Width = 13;
                ws3.Cells[1, 3].Worksheet.Column(3).Width = 15;
                ws3.Cells[1, 4].Worksheet.Column(4).Width = 30;
                ws3.Cells[1, 5].Worksheet.Column(5).Width = 60;
                ws3.Cells[1, 6].Worksheet.Column(6).Width = 20;
                ws3.Cells[1, 7].Worksheet.Column(7).Width = 13;
                ws3.Cells[1, 8].Worksheet.Column(8).Width = 5;
                ws3.Cells[1, 9].Worksheet.Column(9).Width = 15;
                ws3.Cells[1, 10].Worksheet.Column(10).Width = 20;
                ws3.Cells[1, 11].Worksheet.Column(11).Width = 25;



                ws3.Cells[1, 1].Value = "DO PENDING";
                ws3.Cells[3, 1].Value = "PERIODE  : " + dateTimePicker1.Value.ToString("dd-MMM-yyy") + " S.D " + dateTimePicker2.Value.ToString("dd-MMM-yyy");
                ws3.Cells[4, 1].Value = "";
                ws3.Cells[1, 1, 1, MaxCol3].Merge = true;
                ws3.Cells[2, 1, 2, MaxCol3].Merge = true;
                ws3.Cells[1, 1, 2, MaxCol3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws3.Cells[1, 1, 2, MaxCol3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws3.Cells[1, 1, 2, MaxCol3].Style.Font.Bold = true;
                ws3.Cells[1, 1].Style.Font.Size = 14;
                ws3.Cells[2, 1].Style.Font.Size = 11;

                #region Generate Header

                ws3.Cells[5, 1].Value = "TGL.DO";
                ws3.Cells[5, 2].Value = "NO.DO";
                ws3.Cells[5, 3].Value = "KD.SALES";
                ws3.Cells[5, 4].Value = "NAMA TOKO";
                ws3.Cells[5, 5].Value = "ALAMAT";
                ws3.Cells[5, 6].Value = "KOTA";
                ws3.Cells[5, 7].Value = "RP.DO";
                ws3.Cells[5, 8].Value = "TR";
                ws3.Cells[5, 9].Value = "ACC PIUT";
                ws3.Cells[5, 10].Value = "ALASAN";
                ws3.Cells[5, 11].Value = "KETERANGAN";
                

                ws3.Cells[5, 1, 6, MaxCol3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws3.Cells[5, 1, 6, MaxCol3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                #endregion

                #region FillData
                int idx3 = 6;
                foreach (DataRow dr in dtDOPending.Rows)
                {
                    string alasan = dr["Alasan"].ToString();
                    
                    if (alasan != "")
                    {
                        alasan = "PROSES";
                    }
                    else
                    {
                        alasan = " ";
                    }
                    DateTime tgl = Convert.ToDateTime(dr["TglDO"].ToString());
                    string tanggal = tgl.ToString("dd-MMM-yyy");


                    ws3.Cells[idx3, 1].Value = tanggal;
                    ws3.Cells[idx3, 2].Value = dr["NoDO"];
                    ws3.Cells[idx3, 3].Value = dr["KodeSales"];
                    ws3.Cells[idx3, 4].Value = dr["NamaToko"];
                    ws3.Cells[idx3, 5].Value = dr["Alamat"];//alamat
                    ws3.Cells[idx3, 6].Value = dr["Kota"];//kota
                    ws3.Cells[idx3, 7].Value = dr["SumRpNet"];//rpdo
                    ws3.Cells[idx3, 8].Value = dr["TransactionType"];//tr
                    ws3.Cells[idx3, 9].Value = dr["NoNota"];//acc piut
                    ws3.Cells[idx3, 10].Value = alasan; //alasan
                    ws3.Cells[idx3, 11].Value = alasan; //keterangan



                    idx3++;
                   
                }
                #endregion

                #region Summary & Formatting
                ws3.Cells[5, 1, 5, MaxCol3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws3.Cells[5, 1, 5, MaxCol3].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                var border3 = ws3.Cells[5, 1, idx3 + 1, MaxCol3].Style.Border;
                //ws.Cells[5, 7].sty

                border3.Bottom.Style =
                border3.Top.Style =
                border3.Left.Style =
                border3.Right.Style = ExcelBorderStyle.Thin;

                #endregion
                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                //sf.FileName = "MONITORING SALES ORDER_" + DateTime.Now.ToString("ddMMyyy") + ".xlsx";
                sf.FileName = "MONITORING KUNJUNGAN SALES_" + DateTime.Now.ToString("ddMMyyy") + ".xlsx";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    File.WriteAllBytes(file, bin);
                    MessageBox.Show("Laporan Selesai. " + file);
                    Process.Start(sf.FileName.ToString());
                }

                #endregion
            }
        }



        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
