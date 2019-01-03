using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.Class;
using System.Diagnostics;
using Microsoft.Reporting.WinForms;
using ISA.Trading.DataTemplates;
using System.Data.SqlTypes;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using Microsoft.VisualBasic;


namespace ISA.Trading.Laporan.Toko
{
    public partial class frmTokoAktif2 : ISA.Trading.BaseForm
    {
        #region Variable
        DataSet dsT = new DataSet();// Template DS
        DataTable dtT = new DataTable(); //List All Toko
        DataTable dtV = new DataTable(); //List Toko YG valid
        DataSet dsTV = new DataSet();// Nilai Transaksi Nota yg Valid
        DataSet dsPV = new DataSet();// Nilai Transaksi Piutang yg Valid
        DataTable dtKLP = new DataTable();// List KLP
        DataSet DSMonthly = new DataSet();
        List<int> LNToko = new List<int>();
        DateTime FromDate = new DateTime();
        DateTime ToDate = new DateTime();

        DataSet dsKelas = new DataSet();
        DataSet dsPelas = new DataSet();
        string KodeSales = "";
        string Kodegudang = "";
        string cabang = "";
        int Month = 0;
        int LCol = 4;
        int HCol = 10;
        int MCol = 28;
        #endregion

        #region "Procedure"
        public static int MonthDiff(DateTime d1, DateTime d2)
        {
            int a = 0;
            a = Math.Abs((d1.Month - d2.Month) + 12 * (d1.Year - d2.Year));
            return a;

        }

        private bool NotValid()
        {
            bool valid = false;
            ErrorProvider err = new ErrorProvider();

            if (monthYearBox2.FirstDateOfMonth < monthYearBox1.FirstDateOfMonth)
            {
                err.SetError(monthYearBox1, "Harus lebih kecil dari periode 2  ");
                err.SetError(monthYearBox2, "Harus lebih besar dari periode 1  ");
                valid = true;
            }


            if (MonthDiff(monthYearBox2.FirstDateOfMonth, monthYearBox1.FirstDateOfMonth) >= 12)
            {
                err.SetError(monthYearBox1, "Harus lebih kecil dari periode 2  ");
                err.SetError(monthYearBox2, "Harus lebih besar dari periode 1  ");
                valid = true;
            }

            return valid;
        }

        private int GetIdx(string Field)
        {
            int idx = 0;

            switch (Field.ToUpper())
            {
                case "FB2":
                    idx = (LCol + 1);
                    break;
                case "FB4":
                    idx = (LCol + 5);
                    break;
                case "FE2":
                    idx = (LCol + 9);
                    break;
                case "FE4":
                    idx = (LCol + 13);
                    break;
                case "LAINYA":
                    idx = (LCol + 17);
                    break;

            }
            return idx;
        }


        private void setVal(string Field, DataRowView dv, Toko TK)
        {


            switch (Field.ToUpper())
            {
                case "FB2":
                    TK.FB2Omset = TK.FB2Omset + Convert.ToDouble(dv["RpOmset"]);
                    TK.FB2Hpp = TK.FB2Hpp + Convert.ToDouble(dv["RpHPP"]);
                    break;
                case "FB4":
                    TK.FB4Omset = TK.FB4Omset + Convert.ToDouble(dv["RpOmset"]);
                    TK.FB4Hpp = TK.FB4Hpp + Convert.ToDouble(dv["RpHPP"]);
                    break;
                case "FE2":
                    TK.FE2Omset = TK.FE2Omset + Convert.ToDouble(dv["RpOmset"]);
                    TK.FE2Hpp = TK.FE2Hpp + Convert.ToDouble(dv["RpHPP"]);
                    break;
                case "FE4":
                    TK.FE4Omset = TK.FE4Omset + Convert.ToDouble(dv["RpOmset"]);
                    TK.FE4Hpp = TK.FE4Hpp + Convert.ToDouble(dv["RpHPP"]);
                    break;
                case "LAINYA":
                    TK.LainyaOmset = TK.LainyaOmset + Convert.ToDouble(dv["RpOmset"]);
                    TK.LainyaHpp = TK.LainyaHpp + Convert.ToDouble(dv["RpHPP"]);
                    break;

            }

        }

        private void ClearR()
        {
            dtT.Clear(); dtV.Clear();
            dsTV.Tables.Clear(); dsPV.Tables.Clear(); dtKLP.Rows.Clear();

            LNToko = new List<int>();
            FromDate = monthYearBox1.FirstDateOfMonth;
            ToDate = monthYearBox2.LastDateOfMonth;
            Kodegudang = lookupGudang1.GudangID;
            KodeSales = lookupSales1.SalesID;
            cabang = cabangComboBox1.CabangID;
            DSMonthly.Tables.Clear();
            Month = MonthDiff(monthYearBox2.FirstDateOfMonth, monthYearBox1.FirstDateOfMonth) + 1;
            dsKelas = new dsTokoAktif();
            dsPelas = new dsTokoAktifPiutang();

        }

        private void FillToko()
        {
            int nStatus = 0;
            if (rdbAktif.Checked)
                nStatus = 0;
            else if(rdbPasif.Checked)
                nStatus = 1;

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[rsp_TokoAktif_GetToko]"));
                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, txtWilID.Text.Trim()));
                db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.Int, nStatus));
                dtT = db.Commands[0].ExecuteDataTable();
            }

            if (dtT.Rows.Count == 0)
            {
                throw new Exception("Tidak Ada Data");
            }
            progressBar1.Value = 0;
            progressBar1.Maximum = dtT.Rows.Count;
        }

        private DataTable GetPiutang(string KodeToko_)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[rsp_TokoAktif_GetPiutang]"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, KodeSales));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;
        }

        private DataTable GetNota(DateTime FromDate_)
        {
            DataTable dt = new DataTable();
            dt.TableName = "B" + FromDate_.Month.ToString();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[rsp_TokoAktif_GetNota2]"));
                //db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, FromDate_));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, FromDate_));
                db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, KodeSales));
                db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, Kodegudang));
                db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, cabang));
                db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, txtWilID.Text.Trim()));
                dt = db.Commands[0].ExecuteDataTable();
            }

            return dt;
        }

        private void PopulateData()
        {
            DateTime tgla = new DateTime(FromDate.Year, FromDate.Month, 1);
            DateTime TglS = new DateTime(FromDate.Year, FromDate.Month, 1);
            int val = MonthDiff(monthYearBox2.FirstDateOfMonth, monthYearBox1.FirstDateOfMonth) + 1;
            Month = val;
            for (int i = 1; i <= val; i++)
            {
                txtNamaToko.Text = tgla.ToString("MMMM yyyy");
                Application.DoEvents();
                this.Invalidate();
                DSMonthly.Tables.Add(GetNota(tgla).Copy());
                DSMonthly.Tables[DSMonthly.Tables.Count - 1].TableName = "B" + tgla.ToString("MMMM yyyy");
                tgla = TglS.AddMonths(i);
            }
            bool Trans = false;
            foreach (DataTable dt in DSMonthly.Tables)
            {
                if (dt.Rows.Count > 0)
                {
                    Trans = true;
                }
            }
            if (!Trans)
            {
                throw new Exception("Tidak Ada Transaksi");
            }

            if (cboRat.Checked)
            {
                DataTable dtTokoAll = dtT.Clone();// bisa msh kembar beda bulan
                Application.DoEvents();
                this.Invalidate();
                txtNamaToko.Text = "Proses Validasi Filter nominal nota..............";
                //Get all toko
                foreach (DataTable dt in DSMonthly.Tables)
                {
                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = dt.TableName;
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dt1 = dt.DefaultView.ToTable(true, "KodeToko", "NamaToko").Copy();

                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            DataRow drI = dtTokoAll.NewRow();
                            drI["KodeToko"] = dr1["KodeToko"];
                            drI["NamaToko"] = dr1["NamaToko"];
                            dtTokoAll.Rows.Add(drI);
                        }

                    }
                }



                //Toko Unik
                DataTable dtStore = dtTokoAll.DefaultView.ToTable(true, "KodeToko", "NamaToko").Copy();
                DataTable dtInvalid = dtStore.Clone();
                dtInvalid.Rows.Clear();
                //Cari yg non qualified
                foreach (DataRow dr in dtStore.Rows)
                {
                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = dr["NamaToko"].ToString();
                    Double RpOmset = 0;
                    foreach (DataTable dt in DSMonthly.Tables)
                    {
                        dt.DefaultView.RowFilter = "KodeToko='" + dr["KodeToko"].ToString() + "'";
                        if (dt.DefaultView.Count > 0)
                        {
                            RpOmset = RpOmset + Convert.ToDouble(dt.DefaultView.ToTable().Compute("SUM(RpOmset)", string.Empty));
                        }
                    }

                    RpOmset = RpOmset / (Month);
                    RpOmset = Math.Round(RpOmset, 0);
                    if (cboRat.Checked && (RpOmset < txtNominal1.GetDoubleValue || RpOmset > txtNominal2.GetDoubleValue))
                    {
                        DataRow dr1 = dtInvalid.NewRow();
                        dr1["KodeToko"] = dr["KodeToko"];
                        dtInvalid.Rows.Add(dr1);
                    }


                }


                foreach (DataRow dr in dtInvalid.Rows)
                {
                    tgla = new DateTime(FromDate.Year, FromDate.Month, 1);
                    TglS = new DateTime(FromDate.Year, FromDate.Month, 1);
                    for (int i = 1; i <= val; i++)
                    {
                        Application.DoEvents();
                        this.Invalidate();


                        Application.DoEvents();
                        this.Invalidate();
                        txtNamaToko.Text = dr["NamaToko"].ToString();

                        string SqlFilter = "KodeToko='" + dr["KodeToko"] + "'";

                        DeleteDataTable(DSMonthly.Tables["B" + tgla.ToString("MMMM yyyy")], SqlFilter);
                        DSMonthly.Tables["B" + tgla.ToString("MMMM yyyy")].AcceptChanges();
                        tgla = TglS.AddMonths(i);
                    }
                }
            }
        }

        public void DeleteDataTable(DataTable dt, string filterExpression)
        {
            DataRow[] toBeDeleted;
            toBeDeleted = dt.Select(filterExpression);

            if (toBeDeleted.Length > 0)
            {
                foreach (DataRow dr in toBeDeleted)
                {
                    dt.Rows.Remove(dr);

                }
            }
        }

        private int NTokoPerKota(string Kota, string NamaTable)
        {
            int val = 0;

            DataTable dt;

            dt = dsKelas.Tables[NamaTable].Copy();
            if (Kota.Trim().Length > 0)
            {
                dt.DefaultView.RowFilter = "Kota='" + Kota + "'";
            }

            val = dt.DefaultView.ToTable(true, "KodeToko").Rows.Count;
            return val;
        }

        private int TTokoPerKota(string Kota)
        {
            int val = 0;
            DataTable dtTokos = new DataTable();
            dtTokos.Columns.Add("KodeToko", typeof(string));

            foreach (DataTable dtt in dsKelas.Tables)
            {
                DataTable dt;

                dt = dtt.Copy();
                if (Kota.Trim().Length > 0)
                {
                    dt.DefaultView.RowFilter = "Kota='" + Kota + "'";
                }

                foreach (DataRowView dv in dt.DefaultView)
                {
                    DataRow dr = dtTokos.NewRow();
                    dr["KodeToko"] = dv["KodeToko"];
                    dtTokos.Rows.Add(dr);
                }
            }
            val = dtTokos.DefaultView.ToTable(true, "KodeToko").Rows.Count;

            return val;
        }

        private string PiutangKelas(string KodeToko)
        {
            string namatable = string.Empty;
            DataSet ds = dsKelas.Copy();
            foreach (DataTable dt in ds.Tables)
            {
                dt.DefaultView.RowFilter = "KodeToko='" + KodeToko + "'";

                if (dt.DefaultView.ToTable().Rows.Count > 0)
                {
                    namatable = dt.TableName;
                    break;
                }
            }


            return namatable;
        }
        #endregion

        #region "Generate2"
        private ExcelPackage Process1()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "SAS";
            if (rdbAktif.Checked)
                ex.Workbook.Properties.Title = "Toko Aktif";
            else
                ex.Workbook.Properties.Title = "Toko Pasif";

            int m = FromDate.Month - 1;

            #region Bulan

            DateTime Tgl = new DateTime(FromDate.Year, FromDate.Month, 1);
            DateTime TglS = new DateTime(FromDate.Year, FromDate.Month, 1);
            int val = MonthDiff(monthYearBox2.FirstDateOfMonth, monthYearBox1.FirstDateOfMonth) + 1;
            for (int i = 1; i <= val; i++)
            {
                DataTable dt = new DataTable();
                ex.Workbook.Worksheets.Add(Tgl.ToString("MMMM yyyy"));
                ExcelWorksheet ws = ex.Workbook.Worksheets[i];

                double RpOmset = 0;
                double RpHPP = 0;
                double Laba = 0;
                dt = DSMonthly.Tables["B" + Tgl.ToString("MMMM yyyy")].Copy();

                #region Header Bulanan
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";

                // Width
                ws.Cells[1, 1].Worksheet.Column(1).Width = 40;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 10;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 30;

                for (int y = 5; y <= 28; y++)
                {
                    ws.Cells[1, y].Worksheet.Column(y).Width = 13;
                }

                //Tiitle
                if (rdbAktif.Checked)
                    ws.Cells[1, 1].Value = "Laporan     : Toko Aktif";
                else
                    ws.Cells[1, 1].Value = "Laporan     : Toko Pasif";

                ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws.Cells[3, 1].Value = "Cabang      : " + cabangComboBox1.CabangID;
                ws.Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws.Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;

                ws.Cells[1, 1, 1, 4].Merge = true;
                ws.Cells[2, 1, 2, 4].Merge = true;
                ws.Cells[3, 1, 3, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[5, 1, 5, 4].Merge = true;

                ws.Cells[1, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[1, 1, 5, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //Header
                ws.Cells[8, 1].Value = "Nama Toko"; ws.Cells[8, 1, 10, 1].Merge = true;
                ws.Cells[8, 2].Value = "WilID"; ws.Cells[8, 2, 10, 2].Merge = true;
                ws.Cells[8, 3].Value = "KOTA"; ws.Cells[8, 3, 10, 3].Merge = true;
                ws.Cells[8, 4].Value = "DAERAH"; ws.Cells[8, 4, 10, 4].Merge = true;
                ws.Cells[8, 5].Value = Tgl.ToString("MMMM yyyy"); ws.Cells[8, 5, 8, 24].Merge = true;

                ws.Cells[9, 5].Value = "FB2"; ws.Cells[9, 5, 9, 8].Merge = true;
                ws.Cells[9, 9].Value = "FB4"; ws.Cells[9, 9, 9, 12].Merge = true;
                ws.Cells[9, 13].Value = "FE2"; ws.Cells[9, 13, 9, 16].Merge = true;
                ws.Cells[9, 17].Value = "FE4"; ws.Cells[9, 17, 9, 20].Merge = true;
                ws.Cells[9, 21].Value = "Lainya"; ws.Cells[9, 21, 9, 24].Merge = true;

                for (int y = 5; y <= 28; y += 4)
                {
                    ws.Cells[10, y].Value = "OMSET";
                    ws.Cells[10, y + 1].Value = "HPP";
                    ws.Cells[10, y + 2].Value = "LABA RP";
                    ws.Cells[10, y + 3].Value = "LABA %";
                }
                ws.Cells[8, 25].Value = "Total"; ws.Cells[8, 25, 9, 28].Merge = true;
                ws.Cells[8, 1, 10, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[8, 1, 10, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                #endregion
                // List Summary Kode toko per bulan
                #region Bulanan
                DataTable dtToko1 = dt.DefaultView.ToTable(true, "KodeToko");
                int idx = 11;
                int ic = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtToko1.Rows.Count;
                foreach (DataRow dr1 in dtToko1.Rows)
                {
                    dt.DefaultView.RowFilter = "KodeToko='" + dr1["KodeToko"].ToString() + "'";
                    //List<string> toko  =  drToko(dr1["KodeToko"].ToString());
                    ws.Cells[idx, 1].Value = dt.DefaultView.ToTable().Rows[0]["NamaToko"].ToString();
                    ws.Cells[idx, 2].Value = dt.DefaultView.ToTable().Rows[0]["WilID"].ToString();
                    ws.Cells[idx, 3].Value = dt.DefaultView.ToTable().Rows[0]["Kota"].ToString();
                    ws.Cells[idx, 4].Value = dt.DefaultView.ToTable().Rows[0]["Daerah"].ToString();
                    DataRow drT = dtV.NewRow();
                    drT["NamaToko"] = dt.DefaultView.ToTable().Rows[0]["NamaToko"].ToString();
                    drT["WilID"] = dt.DefaultView.ToTable().Rows[0]["WilID"].ToString();
                    drT["Kota"] = dt.DefaultView.ToTable().Rows[0]["Kota"].ToString();
                    drT["Daerah"] = dt.DefaultView.ToTable().Rows[0]["Daerah"].ToString();
                    drT["KodeToko"] = dr1["KodeToko"].ToString();
                    dtV.Rows.Add(drT);
                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = dt.DefaultView.ToTable().Rows[0]["NamaToko"].ToString();
                    progressBar1.Value = ic;
                    ic++;

                    foreach (DataRowView dv in dt.DefaultView)
                    {
                        if (GetIdx(dv["KLP"].ToString()) > 0)
                        {
                            ws.Cells[idx, GetIdx(dv["KLP"].ToString())].Value =
                                Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString())].Value) + Convert.ToDouble(dv["RpOmset"]);

                            ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value =
                                Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value) + Convert.ToDouble(dv["RpHPP"]);

                            ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value =
                                Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value) + Convert.ToDouble(dv["Laba"]);
                        }
                    }

                    RpOmset = 0;
                    double RpLaba = 0;
                    for (int y = 8; y <= 24; y += 4)
                    {
                        RpOmset = Convert.ToDouble(ws.Cells[idx, y - 3].Value);
                        RpLaba = Convert.ToDouble(ws.Cells[idx, y - 1].Value);
                        if (RpOmset != 0 && RpLaba != 0)
                        {
                            ws.Cells[idx, y].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                        }

                        ws.Cells[idx, y - 3, idx, y - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, y - 3, idx, y - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[idx, y - 3, idx, y - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }

                    ws.Cells[idx, 25].Formula = "(" + ws.Cells[idx, 5].Address +
                                                        "+" + ws.Cells[idx, 9].Address +
                                                        "+" + ws.Cells[idx, 13].Address +
                                                        "+" + ws.Cells[idx, 17].Address +
                                                        "+" + ws.Cells[idx, 21].Address +
                                                        ")";
                    ws.Cells[idx, 26].Formula = "(" + ws.Cells[idx, 6].Address +
                                                       "+" + ws.Cells[idx, 10].Address +
                                                       "+" + ws.Cells[idx, 14].Address +
                                                       "+" + ws.Cells[idx, 18].Address +
                                                       "+" + ws.Cells[idx, 22].Address +
                                                       ")";
                    ws.Cells[idx, 27].Formula = "(" + ws.Cells[idx, 7].Address +
                                                         "+" + ws.Cells[idx, 11].Address +
                                                         "+" + ws.Cells[idx, 15].Address +
                                                         "+" + ws.Cells[idx, 19].Address +
                                                         "+" + ws.Cells[idx, 23].Address +
                                                         ")";
                    ws.Cells[idx, 28].Formula = "(" + ws.Cells[idx, 27].Address +
                                                           "/" + ws.Cells[idx, 25].Address +
                                                           "*100)";
                    ws.Cells[idx, 28, idx, 28].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    ws.Cells[idx, 25, idx, 28].Style.Font.Bold = true;
                    ws.Cells[idx, 25, idx, 27].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 25, idx, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, 25, idx, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    idx++;
                }

                #region Summary bawah
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 4].Merge = true;
                ws.Cells[idx, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                var border3 = ws.Cells[8, 1, idx, 28].Style.Border;
                border3.Bottom.Style =
                 border3.Top.Style =
                 border3.Left.Style =
                 border3.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[idx, 1, idx, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, 4].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 28].Style.Font.Bold = true;
                ws.Cells[8, 1, 10, 28].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[8, 1, 10, 28].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[8, 1, 10, 28].Style.Font.Bold = true;
                for (int t = 8; t <= 28; t += 4)
                {
                    ws.Cells[idx, t - 3].Formula = "SUM(" + ws.Cells[11, t - 3].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 3].Address + ")";
                    ws.Cells[idx, t - 2].Formula = "SUM(" + ws.Cells[11, t - 2].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 2].Address + ")";
                    ws.Cells[idx, t - 1].Formula = "SUM(" + ws.Cells[11, t - 1].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 1].Address + ")";

                    ws.Cells[idx, t].Formula = "(" + ws.Cells[idx, t - 1].Address +
                                                         "/" + ws.Cells[idx, t - 3].Address +
                                                         "*100)";
                    ws.Cells[idx, t].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";


                    ws.Cells[idx, t - 3, idx, t - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, t - 3, idx, t - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, t - 3, idx, t - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                #endregion
                #endregion

                Tgl = TglS.AddMonths(i);
            }

            #endregion

            #region Total
            Tgl = new DateTime(FromDate.Year, FromDate.Month, 1);
            for (int i = 1; i <= 1; i++)
            {
                int j = FromDate.Month - 1;

                ex.Workbook.Worksheets.Add("Total");
                ExcelWorksheet ws = ex.Workbook.Worksheets[Month + 1];

                double RpOmset = 0;
                double RpHPP = 0;
                double Laba = 0;
                //dt = DSMonthly.Tables[i - FromDate.Month].Copy();

                #region Header Bulanan
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";

                // Width
                ws.Cells[1, 1].Worksheet.Column(1).Width = 40;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 10;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 30;


                for (int y = 5; y <= 28; y++)
                {
                    ws.Cells[1, y].Worksheet.Column(y).Width = 13;
                }

                //Tiitle
                if (rdbAktif.Checked)
                    ws.Cells[1, 1].Value = "Laporan     : Toko Aktif";
                else
                    ws.Cells[1, 1].Value = "Laporan     : Toko Pasif";

                ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws.Cells[3, 1].Value = "Cabang      : " + cabangComboBox1.CabangID;
                ws.Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws.Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;

                ws.Cells[1, 1, 1, 4].Merge = true;
                ws.Cells[2, 1, 2, 4].Merge = true;
                ws.Cells[3, 1, 3, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[5, 1, 5, 4].Merge = true;

                ws.Cells[1, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[1, 1, 5, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                //Header

                ws.Cells[8, 1].Value = "Nama Toko"; ws.Cells[8, 1, 10, 1].Merge = true;
                ws.Cells[8, 2].Value = "WilID"; ws.Cells[8, 2, 10, 2].Merge = true;
                ws.Cells[8, 3].Value = "KOTA"; ws.Cells[8, 3, 10, 3].Merge = true;
                ws.Cells[8, 4].Value = "DAERAH"; ws.Cells[8, 4, 10, 4].Merge = true;
                ws.Cells[8, 5].Value = "Total " + FromDate.ToString("MMMM yyyy") + " s/d " + ToDate.ToString("MMMM yyyy"); ws.Cells[8, 5, 8, 24].Merge = true;

                ws.Cells[9, 5].Value = "FB2"; ws.Cells[9, 5, 9, 8].Merge = true;
                ws.Cells[9, 9].Value = "FB4"; ws.Cells[9, 9, 9, 12].Merge = true;
                ws.Cells[9, 13].Value = "FE2"; ws.Cells[9, 13, 9, 16].Merge = true;
                ws.Cells[9, 17].Value = "FE4"; ws.Cells[9, 17, 9, 20].Merge = true;
                ws.Cells[9, 21].Value = "Lainya"; ws.Cells[9, 21, 9, 24].Merge = true;


                for (int y = 5; y <= 28; y += 4)
                {
                    ws.Cells[10, y].Value = "OMSET";
                    ws.Cells[10, y + 1].Value = "HPP";
                    ws.Cells[10, y + 2].Value = "LABA RP";
                    ws.Cells[10, y + 3].Value = "LABA %";
                }
                ws.Cells[8, 25].Value = "Total"; ws.Cells[8, 25, 9, 28].Merge = true;


                ws.Cells[8, 1, 10, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[8, 1, 10, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                #endregion
                // List Summary Kode toko per bulan
                #region Bulanan
                DataTable dtToko1 = dtV.DefaultView.ToTable(true, "KodeToko", "NamaToko", "WilID", "Kota", "Daerah");
                int idx = 11;
                int ic = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtToko1.Rows.Count;
                foreach (DataRow dr1 in dtToko1.Rows)
                {

                    //List<string> toko  =  drToko(dr1["KodeToko"].ToString());
                    ws.Cells[idx, 1].Value = dr1["NamaToko"].ToString();
                    ws.Cells[idx, 2].Value = dr1["WilID"].ToString();
                    ws.Cells[idx, 3].Value = dr1["Kota"].ToString();
                    ws.Cells[idx, 4].Value = dr1["Daerah"].ToString();
                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = dr1["NamaToko"].ToString();
                    progressBar1.Value = ic;
                    ic++;

                    foreach (DataTable dtBln in DSMonthly.Tables)
                    {
                        dtBln.DefaultView.RowFilter = "KodeToko='" + dr1["KodeToko"].ToString() + "'";
                        foreach (DataRowView dv in dtBln.DefaultView)
                        {
                            if (GetIdx(dv["KLP"].ToString()) > 0)
                            {
                                ws.Cells[idx, GetIdx(dv["KLP"].ToString())].Value =
                                    Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString())].Value) + Convert.ToDouble(dv["RpOmset"]);

                                ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value =
                                    Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value) + Convert.ToDouble(dv["RpHPP"]);

                                ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value =
                                    Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value) + Convert.ToDouble(dv["Laba"]);
                            }
                        }

                    }

                    RpOmset = 0;
                    double RpLaba = 0;
                    for (int y = 8; y <= 24; y += 4)
                    {
                        RpOmset = Convert.ToDouble(ws.Cells[idx, y - 3].Value);
                        RpLaba = Convert.ToDouble(ws.Cells[idx, y - 1].Value);
                        if (RpOmset != 0 && RpLaba != 0)
                        {
                            ws.Cells[idx, y].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                        }

                        ws.Cells[idx, y - 3, idx, y - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, y - 3, idx, y - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[idx, y - 3, idx, y - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }

                    ws.Cells[idx, 25].Formula = "(" + ws.Cells[idx, 5].Address +
                                                        "+" + ws.Cells[idx, 9].Address +
                                                        "+" + ws.Cells[idx, 13].Address +
                                                        "+" + ws.Cells[idx, 17].Address +
                                                        "+" + ws.Cells[idx, 21].Address +
                                                        ")";
                    ws.Cells[idx, 26].Formula = "(" + ws.Cells[idx, 6].Address +
                                                       "+" + ws.Cells[idx, 10].Address +
                                                       "+" + ws.Cells[idx, 14].Address +
                                                       "+" + ws.Cells[idx, 18].Address +
                                                       "+" + ws.Cells[idx, 22].Address +
                                                       ")";
                    ws.Cells[idx, 27].Formula = "(" + ws.Cells[idx, 7].Address +
                                                         "+" + ws.Cells[idx, 11].Address +
                                                         "+" + ws.Cells[idx, 15].Address +
                                                         "+" + ws.Cells[idx, 19].Address +
                                                         "+" + ws.Cells[idx, 23].Address +
                                                         ")";
                    ws.Cells[idx, 28].Formula = "(" + ws.Cells[idx, 27].Address +
                                                           "/" + ws.Cells[idx, 25].Address +
                                                           "*100)";
                    ws.Cells[idx, 28, idx, 28].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    ws.Cells[idx, 25, idx, 28].Style.Font.Bold = true;
                    ws.Cells[idx, 25, idx, 27].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 25, idx, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, 25, idx, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    idx++;
                }

                #region Summary bawah
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 4].Merge = true;
                ws.Cells[idx, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                var border3 = ws.Cells[8, 1, idx, 28].Style.Border;
                border3.Bottom.Style =
                 border3.Top.Style =
                 border3.Left.Style =
                 border3.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[idx, 1, idx, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, 4].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 28].Style.Font.Bold = true;
                ws.Cells[8, 1, 10, 28].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[8, 1, 10, 28].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[8, 1, 10, 28].Style.Font.Bold = true;
                for (int t = 8; t <= 28; t += 4)
                {
                    ws.Cells[idx, t - 3].Formula = "SUM(" + ws.Cells[11, t - 3].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 3].Address + ")";
                    ws.Cells[idx, t - 2].Formula = "SUM(" + ws.Cells[11, t - 2].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 2].Address + ")";
                    ws.Cells[idx, t - 1].Formula = "SUM(" + ws.Cells[11, t - 1].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 1].Address + ")";

                    ws.Cells[idx, t].Formula = "(" + ws.Cells[idx, t - 1].Address +
                                                         "/" + ws.Cells[idx, t - 3].Address +
                                                         "*100)";
                    ws.Cells[idx, t].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";


                    ws.Cells[idx, t - 3, idx, t - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, t - 3, idx, t - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, t - 3, idx, t - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                #endregion
                #endregion

            }

            #endregion

            #region Rata2
            for (int i = 1; i <= 1; i++)
            {
                int j = FromDate.Month - 1;

                ex.Workbook.Worksheets.Add("Rata - rata");
                ExcelWorksheet ws = ex.Workbook.Worksheets[Month + 1 + 1];

                double RpOmset = 0;
                double RpHPP = 0;
                double Laba = 0;
                //dt = DSMonthly.Tables[i - FromDate.Month].Copy();

                #region Header Bulanan
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";

                // Width
                ws.Cells[1, 1].Worksheet.Column(1).Width = 40;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 10;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 30;

                for (int y = 5; y <= 28; y++)
                {
                    ws.Cells[1, y].Worksheet.Column(y).Width = 13;
                }

                //Tiitle
                if (rdbAktif.Checked)
                    ws.Cells[1, 1].Value = "Laporan     : Toko Aktif (Omset Rata - rata)";
                else
                    ws.Cells[1, 1].Value = "Laporan     : Toko Pasif (Omset Rata - rata)";

                ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws.Cells[3, 1].Value = "Cabang      : " + cabangComboBox1.CabangID;
                ws.Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws.Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;

                ws.Cells[1, 1, 1, 4].Merge = true;
                ws.Cells[2, 1, 2, 4].Merge = true;
                ws.Cells[3, 1, 3, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[5, 1, 5, 4].Merge = true;

                ws.Cells[1, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[1, 1, 5, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                //Header

                ws.Cells[8, 1].Value = "Nama Toko"; ws.Cells[8, 1, 10, 1].Merge = true;
                ws.Cells[8, 2].Value = "WilID"; ws.Cells[8, 2, 10, 2].Merge = true;
                ws.Cells[8, 3].Value = "KOTA"; ws.Cells[8, 3, 10, 3].Merge = true;
                ws.Cells[8, 4].Value = "DAERAH"; ws.Cells[8, 4, 10, 4].Merge = true;
                ws.Cells[8, 5].Value = "Rata - rata " + FromDate.ToString("MMMM") + " s/d " + ToDate.ToString("MMMM yyyy"); ws.Cells[8, 5, 8, 24].Merge = true;

                ws.Cells[9, 5].Value = "FB2"; ws.Cells[9, 5, 9, 8].Merge = true;
                ws.Cells[9, 9].Value = "FB4"; ws.Cells[9, 9, 9, 12].Merge = true;
                ws.Cells[9, 13].Value = "FE2"; ws.Cells[9, 13, 9, 16].Merge = true;
                ws.Cells[9, 17].Value = "FE4"; ws.Cells[9, 17, 9, 20].Merge = true;
                ws.Cells[9, 21].Value = "Lainya"; ws.Cells[9, 21, 9, 24].Merge = true;


                for (int y = 5; y <= 28; y += 4)
                {
                    ws.Cells[10, y].Value = "OMSET";
                    ws.Cells[10, y + 1].Value = "HPP";
                    ws.Cells[10, y + 2].Value = "LABA RP";
                    ws.Cells[10, y + 3].Value = "LABA %";
                }
                ws.Cells[8, 25].Value = "Total"; ws.Cells[8, 25, 9, 28].Merge = true;


                ws.Cells[8, 1, 10, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[8, 1, 10, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                #endregion
                // List Summary Kode toko per bulan
                #region Bulanan
                DataTable dtToko1 = dtV.DefaultView.ToTable(true, "KodeToko", "NamaToko", "WilID", "Kota", "Daerah");
                int idx = 11;
                int ic = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtToko1.Rows.Count;

                foreach (DataRow dr1 in dtToko1.Rows)
                {

                    //List<string> toko  =  drToko(dr1["KodeToko"].ToString());
                    ws.Cells[idx, 1].Value = dr1["NamaToko"].ToString();
                    ws.Cells[idx, 2].Value = dr1["WilID"].ToString();
                    ws.Cells[idx, 3].Value = dr1["Kota"].ToString();
                    ws.Cells[idx, 4].Value = dr1["Daerah"].ToString();
                    Toko TK = new Toko();
                    TK.KodeToko = dr1["KodeToko"].ToString();
                    TK.Kota = dr1["Kota"].ToString();
                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = dr1["NamaToko"].ToString();
                    progressBar1.Value = ic;
                    ic++;
                    double TN = 0;
                    double avg = 0;
                    bool ada = false;
                    foreach (DataTable dtBln in DSMonthly.Tables)
                    {
                        dtBln.DefaultView.RowFilter = "KodeToko='" + dr1["KodeToko"].ToString() + "'";

                        foreach (DataRowView dv in dtBln.DefaultView)
                        {
                            if (GetIdx(dv["KLP"].ToString()) > 0)
                            {
                                ws.Cells[idx, GetIdx(dv["KLP"].ToString())].Value =
                                    Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString())].Value) + Convert.ToDouble(dv["RpOmset"]);

                                ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value =
                                    Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value) + Convert.ToDouble(dv["RpHPP"]);

                                ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value =
                                    Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value) + Convert.ToDouble(dv["Laba"]);



                                switch (dv["KLP"].ToString().ToUpper())
                                {
                                    case "FB2":
                                        TK.FB2Omset = TK.FB2Omset + Convert.ToDouble(dv["RpOmset"]);
                                        TK.FB2Hpp = TK.FB2Hpp + Convert.ToDouble(dv["RpHPP"]);
                                        TK.FB2Laba = TK.FB2Laba + Convert.ToDouble(dv["Laba"]);
                                        break;
                                    case "FB4":
                                        TK.FB4Omset = TK.FB4Omset + Convert.ToDouble(dv["RpOmset"]);
                                        TK.FB4Hpp = TK.FB4Hpp + Convert.ToDouble(dv["RpHPP"]);
                                        TK.FB4Laba = TK.FB4Laba + Convert.ToDouble(dv["Laba"]);
                                        break;
                                    case "FE2":
                                        TK.FE2Omset = TK.FE2Omset + Convert.ToDouble(dv["RpOmset"]);
                                        TK.FE2Hpp = TK.FE2Hpp + Convert.ToDouble(dv["RpHPP"]);
                                        TK.FE2Laba = TK.FE2Laba + Convert.ToDouble(dv["Laba"]);
                                        break;
                                    case "FE4":
                                        TK.FE4Omset = TK.FE4Omset + Convert.ToDouble(dv["RpOmset"]);
                                        TK.FE4Hpp = TK.FE4Hpp + Convert.ToDouble(dv["RpHPP"]);
                                        TK.FE4Laba = TK.FE4Laba + Convert.ToDouble(dv["Laba"]);
                                        break;
                                    case "LAINYA":
                                        TK.LainyaOmset = TK.LainyaOmset + Convert.ToDouble(dv["RpOmset"]);
                                        TK.LainyaHpp = TK.LainyaHpp + Convert.ToDouble(dv["RpHPP"]);
                                        TK.LainyaLaba = TK.LainyaLaba + Convert.ToDouble(dv["Laba"]);
                                        break;

                                }
                                TN = TN + Convert.ToDouble(dv["RpOmset"]);
                                ada = true;
                            }
                        }



                    }
                    if (ada)
                    {

                        avg = TN / Month;
                        if (avg <= 5000000)
                        {
                            DataRow drr = dsKelas.Tables["TokoBronze"].NewRow();
                            drr["KodeToko"] = TK.KodeToko;
                            drr["Kota"] = TK.Kota;

                            drr["FB2Omset"] = TK.FB2Omset;
                            drr["FB2Hpp"] = TK.FB2Hpp;
                            drr["FB2Laba"] = TK.FB2Laba;

                            drr["FB4Omset"] = TK.FB4Omset;
                            drr["FB4Hpp"] = TK.FB4Hpp;
                            drr["FB4Laba"] = TK.FB4Laba;

                            drr["FE2Omset"] = TK.FE2Omset;
                            drr["FE2Hpp"] = TK.FE2Hpp;
                            drr["FE2Laba"] = TK.FE2Laba;

                            drr["FE4Omset"] = TK.FE4Omset;
                            drr["FE4Hpp"] = TK.FE4Hpp;
                            drr["FE4Laba"] = TK.FE4Laba;

                            drr["LainyaOmset"] = TK.LainyaOmset;
                            drr["LainyaHpp"] = TK.LainyaHpp;
                            drr["LainyaLaba"] = TK.LainyaLaba;



                            dsKelas.Tables["TokoBronze"].Rows.Add(drr);
                        }
                        else if (avg > 5000000 && avg <= 10000000)
                        {
                            DataRow drr = dsKelas.Tables["TokoSilver"].NewRow();
                            drr["KodeToko"] = TK.KodeToko;
                            drr["Kota"] = TK.Kota;

                            drr["FB2Omset"] = TK.FB2Omset;
                            drr["FB2Hpp"] = TK.FB2Hpp;
                            drr["FB2Laba"] = TK.FB2Laba;

                            drr["FB4Omset"] = TK.FB4Omset;
                            drr["FB4Hpp"] = TK.FB4Hpp;
                            drr["FB4Laba"] = TK.FB4Laba;

                            drr["FE2Omset"] = TK.FE2Omset;
                            drr["FE2Hpp"] = TK.FE2Hpp;
                            drr["FE2Laba"] = TK.FE2Laba;

                            drr["FE4Omset"] = TK.FE4Omset;
                            drr["FE4Hpp"] = TK.FE4Hpp;
                            drr["FE4Laba"] = TK.FE4Laba;

                            drr["LainyaOmset"] = TK.LainyaOmset;
                            drr["LainyaHpp"] = TK.LainyaHpp;
                            drr["LainyaLaba"] = TK.LainyaLaba;



                            dsKelas.Tables["TokoSilver"].Rows.Add(drr);
                        }
                        else if (avg > 10000000)
                        {
                            DataRow drr = dsKelas.Tables["TokoGold"].NewRow();
                            drr["KodeToko"] = TK.KodeToko;
                            drr["Kota"] = TK.Kota;

                            drr["FB2Omset"] = TK.FB2Omset;
                            drr["FB2Hpp"] = TK.FB2Hpp;
                            drr["FB2Laba"] = TK.FB2Laba;

                            drr["FB4Omset"] = TK.FB4Omset;
                            drr["FB4Hpp"] = TK.FB4Hpp;
                            drr["FB4Laba"] = TK.FB4Laba;

                            drr["FE2Omset"] = TK.FE2Omset;
                            drr["FE2Hpp"] = TK.FE2Hpp;
                            drr["FE2Laba"] = TK.FE2Laba;

                            drr["FE4Omset"] = TK.FE4Omset;
                            drr["FE4Hpp"] = TK.FE4Hpp;
                            drr["FE4Laba"] = TK.FE4Laba;

                            drr["LainyaOmset"] = TK.LainyaOmset;
                            drr["LainyaHpp"] = TK.LainyaHpp;
                            drr["LainyaLaba"] = TK.LainyaLaba;

                            dsKelas.Tables["TokoGold"].Rows.Add(drr);
                        }
                    }

                    RpOmset = 0;
                    double RpLaba = 0;
                    for (int k = 8; k <= 24; k += 4)
                    {
                        ws.Cells[idx, k - 3].Value = Convert.ToDouble(ws.Cells[idx, k - 3].Value) / Month;
                        ws.Cells[idx, k - 2].Value = Convert.ToDouble(ws.Cells[idx, k - 2].Value) / Month;
                        ws.Cells[idx, k - 1].Value = Convert.ToDouble(ws.Cells[idx, k - 1].Value) / Month;
                        RpOmset = Convert.ToDouble(ws.Cells[idx, k - 3].Value);
                        RpLaba = Convert.ToDouble(ws.Cells[idx, k - 1].Value);
                        if (RpOmset != 0 && RpLaba != 0)
                        {
                            ws.Cells[idx, k].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                        }

                        ws.Cells[idx, k - 3, idx, k - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, k - 3, idx, k - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[idx, k - 3, idx, k - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }

                    RpOmset = 0;
                    RpLaba = 0;
                    for (int y = 8; y <= 24; y += 4)
                    {
                        RpOmset = Convert.ToDouble(ws.Cells[idx, y - 3].Value);
                        RpLaba = Convert.ToDouble(ws.Cells[idx, y - 1].Value);
                        if (RpOmset != 0 && RpLaba != 0)
                        {
                            ws.Cells[idx, y].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                        }

                        ws.Cells[idx, y - 3, idx, y - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, y - 3, idx, y - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[idx, y - 3, idx, y - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }

                    ws.Cells[idx, 25].Formula = "(" + ws.Cells[idx, 5].Address +
                                                        "+" + ws.Cells[idx, 9].Address +
                                                        "+" + ws.Cells[idx, 13].Address +
                                                        "+" + ws.Cells[idx, 17].Address +
                                                        "+" + ws.Cells[idx, 21].Address +
                                                        ")";
                    ws.Cells[idx, 26].Formula = "(" + ws.Cells[idx, 6].Address +
                                                       "+" + ws.Cells[idx, 10].Address +
                                                       "+" + ws.Cells[idx, 14].Address +
                                                       "+" + ws.Cells[idx, 18].Address +
                                                       "+" + ws.Cells[idx, 22].Address +
                                                       ")";
                    ws.Cells[idx, 27].Formula = "(" + ws.Cells[idx, 7].Address +
                                                         "+" + ws.Cells[idx, 11].Address +
                                                         "+" + ws.Cells[idx, 15].Address +
                                                         "+" + ws.Cells[idx, 19].Address +
                                                         "+" + ws.Cells[idx, 23].Address +
                                                         ")";
                    ws.Cells[idx, 28].Formula = "(" + ws.Cells[idx, 27].Address +
                                                           "/" + ws.Cells[idx, 25].Address +
                                                           "*100)";
                    ws.Cells[idx, 28, idx, 28].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    ws.Cells[idx, 25, idx, 28].Style.Font.Bold = true;
                    ws.Cells[idx, 25, idx, 27].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 25, idx, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, 25, idx, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    idx++;
                }

                #region Summary bawah
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 4].Merge = true;
                ws.Cells[idx, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                var border3 = ws.Cells[8, 1, idx, 28].Style.Border;
                border3.Bottom.Style =
                 border3.Top.Style =
                 border3.Left.Style =
                 border3.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[idx, 1, idx, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, 4].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 28].Style.Font.Bold = true;
                ws.Cells[8, 1, 10, 28].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[8, 1, 10, 28].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[8, 1, 10, 28].Style.Font.Bold = true;
                for (int t = 8; t <= 28; t += 4)
                {
                    ws.Cells[idx, t - 3].Formula = "SUM(" + ws.Cells[11, t - 3].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 3].Address + ")";
                    ws.Cells[idx, t - 2].Formula = "SUM(" + ws.Cells[11, t - 2].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 2].Address + ")";
                    ws.Cells[idx, t - 1].Formula = "SUM(" + ws.Cells[11, t - 1].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 1].Address + ")";

                    ws.Cells[idx, t].Formula = "(" + ws.Cells[idx, t - 1].Address +
                                                         "/" + ws.Cells[idx, t - 3].Address +
                                                         "*100)";
                    ws.Cells[idx, t].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";


                    ws.Cells[idx, t - 3, idx, t - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, t - 3, idx, t - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, t - 3, idx, t - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                #endregion
                #endregion

            }

            #endregion

            #region Piutang
            for (int h = 1; h <= 1; h++)
            {
                DataTable dtToko1 = dtV.DefaultView.ToTable(true, "KodeToko", "NamaToko", "WilID", "Kota", "Daerah");
                ex.Workbook.Worksheets.Add("Piutang");
                ExcelWorksheet ws = ex.Workbook.Worksheets[Month + 1 + 1 + 1];
                #region Init Data Piutang;
                int ic = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtToko1.Rows.Count;
                foreach (DataRow dr in dtToko1.Rows)
                {
                    DataTable dp = new DataTable();
                    txtNamaToko.Text = "Piutang 1 : " + dr["NamaToko"].ToString();
                    Application.DoEvents();
                    this.Invalidate();
                    dp = GetPiutang(dr["KodeToko"].ToString());
                    if (dp.Rows.Count > 0)
                    {
                        dsPV.Tables.Add(dp.Copy());
                        dsPV.Tables[dsPV.Tables.Count - 1].TableName = dr["KodeToko"].ToString();
                        string namatable = string.Empty;
                        namatable = PiutangKelas(dr["KodeToko"].ToString());
                        DataRow drrr = dsPelas.Tables[namatable].NewRow();
                        drrr["KodeToko"] = dr["KodeToko"].ToString();
                        drrr["Kota"] = dr["Kota"].ToString();
                        drrr["A"] = dp.Rows[0]["A"];
                        drrr["B"] = dp.Rows[0]["B"];
                        drrr["C"] = dp.Rows[0]["C"];
                        drrr["D"] = Convert.ToDouble(dp.Rows[0]["A"]) + Convert.ToDouble(dp.Rows[0]["B"]) + Convert.ToDouble(dp.Rows[0]["C"]);
                        dsPelas.Tables[namatable].Rows.Add(drrr);
                    }
                    ic++;
                    progressBar1.Value = ic;
                }
                #endregion
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";
                // Width
                ws.Cells[1, 1].Worksheet.Column(1).Width = 32;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 9;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 32;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 32;
                if (rdbAktif.Checked)
                    ws.Cells[1, 1].Value = "Laporan     : TOKO AKTIF  (Umur Piutang)";
                else
                    ws.Cells[1, 1].Value = "Laporan     : TOKO PASIF  (Umur Piutang)";
                ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws.Cells[3, 1].Value = "Cabang1     : " + cabangComboBox1.CabangID;
                ws.Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws.Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;
                for (int i = 5; i <= 8; i++)
                {
                    ws.Cells[1, i].Worksheet.Column(i).Width = 13;
                }
                ws.Cells[9, 1].Value = "Nama Toko"; ws.Cells[9, 1, 10, 1].Merge = true;
                ws.Cells[9, 2].Value = "WilID"; ws.Cells[9, 2, 10, 2].Merge = true;
                ws.Cells[9, 3].Value = "KOTA"; ws.Cells[9, 3, 10, 3].Merge = true;
                ws.Cells[9, 4].Value = "DAERAH"; ws.Cells[9, 4, 10, 4].Merge = true;
                ws.Cells[9, 5].Value = "Umur Piutang " + monthYearBox2.FirstDateOfMonth.ToString("MMMM yyyy");
                ws.Cells[9, 5, 9, 8].Merge = true;
                ws.Cells[10, 5].Value = "<90 HARI";
                ws.Cells[10, 6].Value = "91 -120 HARI";
                ws.Cells[10, 7].Value = ">120 HARI";
                ws.Cells[10, 8].Value = "Total";
                ws.Cells[8, 1, 10, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[8, 1, 10, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                //isi Total
                int idx = 11;
                ic = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtToko1.Rows.Count;
                foreach (DataRow dr in dtToko1.Rows)
                {
                    ws.Cells[idx, 1].Value = dr["NamaToko"].ToString().Trim();
                    ws.Cells[idx, 2].Value = dr["WilID"].ToString();
                    ws.Cells[idx, 3].Value = dr["Kota"].ToString().Trim();
                    ws.Cells[idx, 4].Value = dr["Daerah"].ToString().Trim();
                    dsPV.Tables[dr["KodeToko"].ToString()].DefaultView.RowFilter = "KodeToko='" + dr["KodeToko"].ToString() + "'";
                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = dr["NamaToko"].ToString();
                    ic++;
                    progressBar1.Value = ic;
                    foreach (DataRowView dv in dsPV.Tables[dr["KodeToko"].ToString()].DefaultView)
                    {
                        ws.Cells[idx, 5].Value = Convert.ToDouble(dv["A"]);
                        ws.Cells[idx, 6].Value = Convert.ToDouble(dv["B"]);
                        ws.Cells[idx, 7].Value = Convert.ToDouble(dv["C"]);
                        ws.Cells[idx, 8].Value = Convert.ToDouble(dv["A"]) + Convert.ToDouble(dv["B"]) + Convert.ToDouble(dv["C"]);
                    }
                    ws.Cells[idx, 5, idx, 8].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 5, idx, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, 5, idx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    idx++;
                }
                ws.Cells[9, 1, 10, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[9, 1, 10, 8].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[9, 1, 10, 8].Style.Font.Bold = true;
                var border3 = ws.Cells[9, 1, idx - 1, 8].Style.Border;
                border3.Bottom.Style =
                border3.Top.Style =
                border3.Left.Style =
                border3.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[9, 1, idx - 1, 8].Style.WrapText = true;
            }
            #endregion
            return ex;
        }
        #endregion


        private List<string> drToko(string KodeToko_)
        {
            //  DataTable dt = dtT.Copy();
            dtT.DefaultView.RowFilter = "KodeToko='" + KodeToko_ + "'";

            List<string> NamaToko = new List<string>();
            NamaToko.Add(Tools.isNull(dtT.DefaultView.ToTable().Rows[0]["NamaToko"], "").ToString());
            NamaToko.Add(Tools.isNull(dtT.DefaultView.ToTable().Rows[0]["Kota"], "").ToString());
            NamaToko.Add(Tools.isNull(dtT.DefaultView.ToTable().Rows[0]["WilID"], "").ToString());
            NamaToko.Add(Tools.isNull(dtT.DefaultView.ToTable().Rows[0]["Daerah"], "").ToString());
            return NamaToko;
        }

        public frmTokoAktif2()
        {
            InitializeComponent();
        }

        private void frmTokoAktif2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            monthYearBox1.Month = 1;
            monthYearBox1.Year = DateTime.Now.Year;

            monthYearBox2.Month = DateTime.Now.Month;
            monthYearBox2.Year = DateTime.Now.Year;
            dsT = new dsToko();
            dtKLP = dsT.Tables["KLP"].Copy();
            dtV = dsT.Tables["Toko"].Copy();
            txtNamaToko.Text = "";
            progressBar1.Visible = false;
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (NotValid())
            {
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ClearR();
                FillToko();
                progressBar1.Visible = true;

                PopulateData();

                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(Process1());
                exs.Add(Process2());
                //exs.Add(ProsesToko());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                if (rdbAktif.Checked)
                    sf.FileName = "Laporan Toko Aktif(Toko).xlsx";
                else
                    sf.FileName = "Laporan Toko Pasif(Toko).xlsx";


                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    string file2 = sf.FileName.ToString().Replace(".xlsx", "(Kota).xlsx");

                    Byte[] bin1 = exs[0].GetAsByteArray();
                    Byte[] bin2 = exs[1].GetAsByteArray();
                    File.WriteAllBytes(file, bin1);
                    File.WriteAllBytes(file2, bin2);
                    MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file + Environment.NewLine + file2);
                    Process.Start(sf.FileName.ToString());
                    Process.Start(file2);
                }
                #endregion
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                progressBar1.Visible = false;
                txtNamaToko.Text = string.Empty;
                progressBar1.Visible = false;
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private ExcelPackage Process2()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "SAS";
            ex.Workbook.Properties.Title = "Kota Aktif";
            int m = FromDate.Month - 1;
            DataTable dt = new DataTable();

            #region Bulan <clear>
            DateTime Tgl = new DateTime(FromDate.Year, FromDate.Month, 1);
            DateTime TglS = new DateTime(FromDate.Year, FromDate.Month, 1);
            int val = MonthDiff(monthYearBox2.FirstDateOfMonth, monthYearBox1.FirstDateOfMonth) + 1;
            for (int i = 1; i <= val; i++)
            {

                ex.Workbook.Worksheets.Add(Tgl.ToString("MMMM yyyy"));
                ExcelWorksheet ws = ex.Workbook.Worksheets[i];

                double RpOmset = 0;
                double RpHPP = 0;
                double Laba = 0;
                dt = DSMonthly.Tables["B" + Tgl.ToString("MMMM yyyy")].Copy();

                #region Header Bulanan
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";

                // Width
                ws.Cells[1, 1].Worksheet.Column(1).Width = 40;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 5;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 5;

                for (int y = 5; y <= 28; y++)
                {
                    ws.Cells[1, y].Worksheet.Column(y).Width = 13;
                }

                //Tiitle
                if (rdbAktif.Checked)
                    ws.Cells[1, 1].Value = "Laporan     : Toko Aktif";
                else
                    ws.Cells[1, 1].Value = "Laporan     : Toko Pasif";

                ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws.Cells[3, 1].Value = "Cabang      : " + cabangComboBox1.CabangID;
                ws.Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws.Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;

                ws.Cells[1, 1, 1, 4].Merge = true;
                ws.Cells[2, 1, 2, 4].Merge = true;
                ws.Cells[3, 1, 3, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[5, 1, 5, 4].Merge = true;

                ws.Cells[1, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[1, 1, 5, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                //Header

                //ws.Cells[8, 1].Value = "Nama Toko"; ws.Cells[8, 1, 10, 1].Merge = true;
                //ws.Cells[8, 2].Value = "WilID"; ws.Cells[8, 2, 10, 2].Merge = true;
                ws.Cells[8, 1].Value = "KOTA"; ws.Cells[8, 1, 10, 4].Merge = true;
                //ws.Cells[8, 3].Value = "KOTA"; ws.Cells[8, 3, 10, 3].Merge = true;
                //ws.Cells[8, 4].Value = "DAERAH"; ws.Cells[8, 4, 10, 4].Merge = true;
                ws.Cells[8, 5].Value = Tgl.ToString("MMMM yyyy"); ws.Cells[8, 5, 8, 24].Merge = true;

                ws.Cells[9, 5].Value = "FB2"; ws.Cells[9, 5, 9, 8].Merge = true;
                ws.Cells[9, 9].Value = "FB4"; ws.Cells[9, 9, 9, 12].Merge = true;
                ws.Cells[9, 13].Value = "FE2"; ws.Cells[9, 13, 9, 16].Merge = true;
                ws.Cells[9, 17].Value = "FE4"; ws.Cells[9, 17, 9, 20].Merge = true;
                ws.Cells[9, 21].Value = "Lainya"; ws.Cells[9, 21, 9, 24].Merge = true;


                for (int y = 5; y <= 28; y += 4)
                {
                    ws.Cells[10, y].Value = "OMSET";
                    ws.Cells[10, y + 1].Value = "HPP";
                    ws.Cells[10, y + 2].Value = "LABA RP";
                    ws.Cells[10, y + 3].Value = "LABA %";
                }
                ws.Cells[8, 25].Value = "Total"; ws.Cells[8, 25, 9, 28].Merge = true;


                ws.Cells[8, 1, 10, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[8, 1, 10, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                #endregion
                // List Summary Kode toko per bulan
                #region Bulanan
                DataTable dtToko1 = dt.DefaultView.ToTable(true, "Kota");
                int idx = 11;
                int ic = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtToko1.Rows.Count;
                foreach (DataRow dr1 in dtToko1.Rows)
                {
                    dt.DefaultView.RowFilter = "Kota='" + dr1["Kota"].ToString() + "'";

                    //List<string> toko  =  drToko(dr1["KodeToko"].ToString());
                    ws.Cells[idx, 1].Value = dt.DefaultView.ToTable().Rows[0]["Kota"].ToString();
                    ws.Cells[idx, 1, idx, 4].Merge = true;
                    //ws.Cells[idx, 2].Value = dt.DefaultView.ToTable().Rows[0]["WilID"].ToString();
                    //ws.Cells[idx, 3].Value = dt.DefaultView.ToTable().Rows[0]["Kota"].ToString();
                    //ws.Cells[idx, 4].Value = dt.DefaultView.ToTable().Rows[0]["Daerah"].ToString();

                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = dt.DefaultView.ToTable().Rows[0]["NamaToko"].ToString();
                    progressBar1.Value = ic;
                    ic++;

                    foreach (DataRow dv in dt.DefaultView.ToTable().Rows)
                    {
                        if (GetIdx(dv["KLP"].ToString()) > 0)
                        {
                            ws.Cells[idx, GetIdx(dv["KLP"].ToString())].Value =
                                Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString())].Value) + Convert.ToDouble(dv["RpOmset"]);

                            ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value =
                                Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value) + Convert.ToDouble(dv["RpHPP"]);

                            ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value =
                                Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value) + Convert.ToDouble(dv["Laba"]);
                        }
                    }

                    RpOmset = 0;
                    double RpLaba = 0;
                    for (int y = 8; y <= 24; y += 4)
                    {
                        RpOmset = Convert.ToDouble(ws.Cells[idx, y - 3].Value);
                        RpLaba = Convert.ToDouble(ws.Cells[idx, y - 1].Value);
                        if (RpOmset != 0 && RpLaba != 0)
                        {
                            ws.Cells[idx, y].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                        }

                        ws.Cells[idx, y - 3, idx, y - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, y - 3, idx, y - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[idx, y - 3, idx, y - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }

                    ws.Cells[idx, 25].Formula = "(" + ws.Cells[idx, 5].Address +
                                                        "+" + ws.Cells[idx, 9].Address +
                                                        "+" + ws.Cells[idx, 13].Address +
                                                        "+" + ws.Cells[idx, 17].Address +
                                                        "+" + ws.Cells[idx, 21].Address +
                                                        ")";
                    ws.Cells[idx, 26].Formula = "(" + ws.Cells[idx, 6].Address +
                                                       "+" + ws.Cells[idx, 10].Address +
                                                       "+" + ws.Cells[idx, 14].Address +
                                                       "+" + ws.Cells[idx, 18].Address +
                                                       "+" + ws.Cells[idx, 22].Address +
                                                       ")";
                    ws.Cells[idx, 27].Formula = "(" + ws.Cells[idx, 7].Address +
                                                         "+" + ws.Cells[idx, 11].Address +
                                                         "+" + ws.Cells[idx, 15].Address +
                                                         "+" + ws.Cells[idx, 19].Address +
                                                         "+" + ws.Cells[idx, 23].Address +
                                                         ")";
                    ws.Cells[idx, 28].Formula = "(" + ws.Cells[idx, 27].Address +
                                                           "/" + ws.Cells[idx, 25].Address +
                                                           "*100)";
                    ws.Cells[idx, 28, idx, 28].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    ws.Cells[idx, 25, idx, 28].Style.Font.Bold = true;
                    ws.Cells[idx, 25, idx, 27].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 25, idx, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, 25, idx, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    idx++;
                }

                #region Summary bawah
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 4].Merge = true;
                ws.Cells[idx, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                var border3 = ws.Cells[8, 1, idx, 28].Style.Border;
                border3.Bottom.Style =
                 border3.Top.Style =
                 border3.Left.Style =
                 border3.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[idx, 1, idx, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, 4].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 28].Style.Font.Bold = true;
                ws.Cells[8, 1, 10, 28].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[8, 1, 10, 28].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[8, 1, 10, 28].Style.Font.Bold = true;
                for (int t = 8; t <= 28; t += 4)
                {
                    ws.Cells[idx, t - 3].Formula = "SUM(" + ws.Cells[11, t - 3].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 3].Address + ")";
                    ws.Cells[idx, t - 2].Formula = "SUM(" + ws.Cells[11, t - 2].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 2].Address + ")";
                    ws.Cells[idx, t - 1].Formula = "SUM(" + ws.Cells[11, t - 1].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 1].Address + ")";

                    ws.Cells[idx, t].Formula = "(" + ws.Cells[idx, t - 1].Address +
                                                         "/" + ws.Cells[idx, t - 3].Address +
                                                         "*100)";
                    ws.Cells[idx, t].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";


                    ws.Cells[idx, t - 3, idx, t - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, t - 3, idx, t - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, t - 3, idx, t - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                #endregion
                #endregion

                Tgl = TglS.AddMonths(i);
            }

            #endregion

            #region Total <clear>

            for (int i = ToDate.Month; i <= ToDate.Month; i++)
            {
                int j = FromDate.Month - 1;

                ex.Workbook.Worksheets.Add("Total");
                ExcelWorksheet ws = ex.Workbook.Worksheets[Month + 1];

                double RpOmset = 0;
                double RpHPP = 0;
                double Laba = 0;
                //dt = DSMonthly.Tables[i - FromDate.Month].Copy();

                #region Header Bulanan
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";

                // Width
                ws.Cells[1, 1].Worksheet.Column(1).Width = 40;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 5;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 5;

                for (int y = 5; y <= 28; y++)
                {
                    ws.Cells[1, y].Worksheet.Column(y).Width = 13;
                }

                //Tiitle
                if (rdbAktif.Checked)
                    ws.Cells[1, 1].Value = "Laporan     : Toko Aktif";
                else
                    ws.Cells[1, 1].Value = "Laporan     : Toko Pasif";

                ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws.Cells[3, 1].Value = "Cabang      : " + cabangComboBox1.CabangID;
                ws.Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws.Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;

                ws.Cells[1, 1, 1, 4].Merge = true;
                ws.Cells[2, 1, 2, 4].Merge = true;
                ws.Cells[3, 1, 3, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[5, 1, 5, 4].Merge = true;

                ws.Cells[1, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[1, 1, 5, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                //Header

                //ws.Cells[8, 1].Value = "Nama Toko"; ws.Cells[8, 1, 10, 1].Merge = true;
                //ws.Cells[8, 2].Value = "WilID"; ws.Cells[8, 2, 10, 2].Merge = true;
                ws.Cells[8, 1].Value = "KOTA"; ws.Cells[8, 1, 10, 4].Merge = true;
                //ws.Cells[8, 3].Value = "KOTA"; ws.Cells[8, 3, 10, 3].Merge = true;
                //ws.Cells[8, 4].Value = "DAERAH"; ws.Cells[8, 4, 10, 4].Merge = true;
                ws.Cells[8, 5].Value = "Total " + FromDate.ToString("MMMM yyyy") + " s/d " + ToDate.ToString("MMMM yyyy"); ws.Cells[8, 5, 8, 24].Merge = true;

                ws.Cells[9, 5].Value = "FB2"; ws.Cells[9, 5, 9, 8].Merge = true;
                ws.Cells[9, 9].Value = "FB4"; ws.Cells[9, 9, 9, 12].Merge = true;
                ws.Cells[9, 13].Value = "FE2"; ws.Cells[9, 13, 9, 16].Merge = true;
                ws.Cells[9, 17].Value = "FE4"; ws.Cells[9, 17, 9, 20].Merge = true;
                ws.Cells[9, 21].Value = "Lainya"; ws.Cells[9, 21, 9, 24].Merge = true;


                for (int y = 5; y <= 28; y += 4)
                {
                    ws.Cells[10, y].Value = "OMSET";
                    ws.Cells[10, y + 1].Value = "HPP";
                    ws.Cells[10, y + 2].Value = "LABA RP";
                    ws.Cells[10, y + 3].Value = "LABA %";
                }
                ws.Cells[8, 25].Value = "Total"; ws.Cells[8, 25, 9, 28].Merge = true;


                ws.Cells[8, 1, 10, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[8, 1, 10, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                #endregion
                // List Summary Kode toko per bulan
                #region Bulanan
                DataTable dtToko1 = dtV.DefaultView.ToTable(true, "Kota");
                int idx = 11;
                int ic = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtToko1.Rows.Count;
                foreach (DataRow dr1 in dtToko1.Rows)
                {
                    //dt.DefaultView.RowFilter = "Kota='" + dr1["Kota"].ToString() + "'";
                    ws.Cells[idx, 1].Value = dr1["Kota"].ToString();
                    ws.Cells[idx, 1, idx, 4].Merge = true;


                    ////List<string> toko  =  drToko(dr1["KodeToko"].ToString());
                    //ws.Cells[idx, 1].Value = dr1["NamaToko"].ToString();
                    //ws.Cells[idx, 2].Value = dr1["WilID"].ToString();
                    //ws.Cells[idx, 3].Value = dr1["Kota"].ToString();
                    //ws.Cells[idx, 4].Value = dr1["Daerah"].ToString();
                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = dr1["Kota"].ToString();
                    progressBar1.Value = ic;
                    ic++;

                    foreach (DataTable dtBln in DSMonthly.Tables)
                    {
                        dtBln.DefaultView.RowFilter = "Kota='" + dr1["Kota"].ToString() + "'";
                        foreach (DataRowView dv in dtBln.DefaultView)
                        {
                            if (GetIdx(dv["KLP"].ToString()) > 0)
                            {
                                ws.Cells[idx, GetIdx(dv["KLP"].ToString())].Value =
                                    Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString())].Value) + Convert.ToDouble(dv["RpOmset"]);

                                ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value =
                                    Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value) + Convert.ToDouble(dv["RpHPP"]);

                                ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value =
                                    Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value) + Convert.ToDouble(dv["Laba"]);
                            }
                        }

                    }

                    RpOmset = 0;
                    double RpLaba = 0;
                    for (int y = 8; y <= 24; y += 4)
                    {
                        RpOmset = Convert.ToDouble(ws.Cells[idx, y - 3].Value);
                        RpLaba = Convert.ToDouble(ws.Cells[idx, y - 1].Value);
                        if (RpOmset != 0 && RpLaba != 0)
                        {
                            ws.Cells[idx, y].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                        }

                        ws.Cells[idx, y - 3, idx, y - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, y - 3, idx, y - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[idx, y - 3, idx, y - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }

                    ws.Cells[idx, 25].Formula = "(" + ws.Cells[idx, 5].Address +
                                                        "+" + ws.Cells[idx, 9].Address +
                                                        "+" + ws.Cells[idx, 13].Address +
                                                        "+" + ws.Cells[idx, 17].Address +
                                                        "+" + ws.Cells[idx, 21].Address +
                                                        ")";
                    ws.Cells[idx, 26].Formula = "(" + ws.Cells[idx, 6].Address +
                                                       "+" + ws.Cells[idx, 10].Address +
                                                       "+" + ws.Cells[idx, 14].Address +
                                                       "+" + ws.Cells[idx, 18].Address +
                                                       "+" + ws.Cells[idx, 22].Address +
                                                       ")";
                    ws.Cells[idx, 27].Formula = "(" + ws.Cells[idx, 7].Address +
                                                         "+" + ws.Cells[idx, 11].Address +
                                                         "+" + ws.Cells[idx, 15].Address +
                                                         "+" + ws.Cells[idx, 19].Address +
                                                         "+" + ws.Cells[idx, 23].Address +
                                                         ")";
                    ws.Cells[idx, 28].Formula = "(" + ws.Cells[idx, 27].Address +
                                                           "/" + ws.Cells[idx, 25].Address +
                                                           "*100)";
                    ws.Cells[idx, 28, idx, 28].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    ws.Cells[idx, 25, idx, 28].Style.Font.Bold = true;
                    ws.Cells[idx, 25, idx, 27].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 25, idx, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, 25, idx, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    idx++;
                }

                #region Summary bawah
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 4].Merge = true;
                ws.Cells[idx, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                var border3 = ws.Cells[8, 1, idx, 28].Style.Border;
                border3.Bottom.Style =
                 border3.Top.Style =
                 border3.Left.Style =
                 border3.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[idx, 1, idx, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, 4].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 28].Style.Font.Bold = true;
                ws.Cells[8, 1, 10, 28].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[8, 1, 10, 28].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[8, 1, 10, 28].Style.Font.Bold = true;
                for (int t = 8; t <= 28; t += 4)
                {
                    ws.Cells[idx, t - 3].Formula = "SUM(" + ws.Cells[11, t - 3].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 3].Address + ")";
                    ws.Cells[idx, t - 2].Formula = "SUM(" + ws.Cells[11, t - 2].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 2].Address + ")";
                    ws.Cells[idx, t - 1].Formula = "SUM(" + ws.Cells[11, t - 1].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 1].Address + ")";

                    ws.Cells[idx, t].Formula = "(" + ws.Cells[idx, t - 1].Address +
                                                         "/" + ws.Cells[idx, t - 3].Address +
                                                         "*100)";
                    ws.Cells[idx, t].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";


                    ws.Cells[idx, t - 3, idx, t - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, t - 3, idx, t - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, t - 3, idx, t - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                #endregion
                #endregion

            }
            #endregion

            #region Rata2 <clear>
            for (int i = ToDate.Month; i <= ToDate.Month; i++)
            {


                ex.Workbook.Worksheets.Add("Rata - rata");
                ExcelWorksheet ws = ex.Workbook.Worksheets[Month + 1 + 1];

                double RpOmset = 0;
                double RpHPP = 0;
                double Laba = 0;
                //dt = DSMonthly.Tables[i - FromDate.Month].Copy();

                #region Header Bulanan
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";

                // Width
                ws.Cells[1, 1].Worksheet.Column(1).Width = 40;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 5;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 5;

                for (int y = 5; y <= 28; y++)
                {
                    ws.Cells[1, y].Worksheet.Column(y).Width = 13;
                }

                //Tiitle
                if (rdbAktif.Checked)
                    ws.Cells[1, 1].Value = "Laporan     : Toko Aktif";
                else
                    ws.Cells[1, 1].Value = "Laporan     : Toko Pasif";

                ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws.Cells[3, 1].Value = "Cabang      : " + cabangComboBox1.CabangID;
                ws.Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws.Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;

                ws.Cells[1, 1, 1, 4].Merge = true;
                ws.Cells[2, 1, 2, 4].Merge = true;
                ws.Cells[3, 1, 3, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[5, 1, 5, 4].Merge = true;

                ws.Cells[1, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[1, 1, 5, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                //Header

                //ws.Cells[8, 1].Value = "Nama Toko"; ws.Cells[8, 1, 10, 1].Merge = true;
                ws.Cells[8, 1].Value = "KOTA"; ws.Cells[8, 1, 10, 4].Merge = true;
                //ws.Cells[8, 2].Value = "WilID"; ws.Cells[8, 2, 10, 2].Merge = true;
                //ws.Cells[8, 3].Value = "KOTA"; ws.Cells[8, 3, 10, 3].Merge = true;
                // ws.Cells[8, 4].Value = "DAERAH"; ws.Cells[8, 4, 10, 4].Merge = true;
                ws.Cells[8, 5].Value = "Rata - rata " + FromDate.ToString("MMMM") + " s/d " + Tgl.ToString("MMMM yyyy"); ws.Cells[8, 5, 8, 24].Merge = true;

                ws.Cells[9, 5].Value = "FB2"; ws.Cells[9, 5, 9, 8].Merge = true;
                ws.Cells[9, 9].Value = "FB4"; ws.Cells[9, 9, 9, 12].Merge = true;
                ws.Cells[9, 13].Value = "FE2"; ws.Cells[9, 13, 9, 16].Merge = true;
                ws.Cells[9, 17].Value = "FE4"; ws.Cells[9, 17, 9, 20].Merge = true;
                ws.Cells[9, 21].Value = "Lainya"; ws.Cells[9, 21, 9, 24].Merge = true;


                for (int y = 5; y <= 28; y += 4)
                {
                    ws.Cells[10, y].Value = "OMSET";
                    ws.Cells[10, y + 1].Value = "HPP";
                    ws.Cells[10, y + 2].Value = "LABA RP";
                    ws.Cells[10, y + 3].Value = "LABA %";
                }
                ws.Cells[8, 25].Value = "Total"; ws.Cells[8, 25, 9, 28].Merge = true;


                ws.Cells[8, 1, 10, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[8, 1, 10, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                #endregion
                // List Summary Kode toko per bulan
                #region Bulanan
                DataTable dtToko1 = dtV.DefaultView.ToTable(true, "Kota");
                int idx = 11;
                int ic = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtToko1.Rows.Count;
                foreach (DataRow dr1 in dtToko1.Rows)
                {

                    //List<string> toko  =  drToko(dr1["KodeToko"].ToString());

                    ws.Cells[idx, 1].Value = dr1["Kota"].ToString();
                    ws.Cells[idx, 1, idx, 4].Merge = true;

                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = dr1["Kota"].ToString();
                    progressBar1.Value = ic;
                    ic++;

                    foreach (DataTable dtBln in DSMonthly.Tables)
                    {
                        dtBln.DefaultView.RowFilter = "Kota='" + dr1["Kota"].ToString() + "'";
                        foreach (DataRowView dv in dtBln.DefaultView)
                        {
                            if (GetIdx(dv["KLP"].ToString()) > 0)
                            {
                                ws.Cells[idx, GetIdx(dv["KLP"].ToString())].Value =
                                    Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString())].Value) + Convert.ToDouble(dv["RpOmset"]);

                                ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value =
                                    Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 1].Value) + Convert.ToDouble(dv["RpHPP"]);

                                ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value =
                                    Convert.ToDouble(ws.Cells[idx, GetIdx(dv["KLP"].ToString()) + 2].Value) + Convert.ToDouble(dv["Laba"]);
                            }
                        }

                    }

                    RpOmset = 0;
                    double RpLaba = 0;
                    for (int k = 8; k <= 24; k += 4)
                    {
                        ws.Cells[idx, k - 3].Value = Convert.ToDouble(ws.Cells[idx, k - 3].Value) / Month;
                        ws.Cells[idx, k - 2].Value = Convert.ToDouble(ws.Cells[idx, k - 2].Value) / Month;
                        ws.Cells[idx, k - 1].Value = Convert.ToDouble(ws.Cells[idx, k - 1].Value) / Month;
                        RpOmset = Convert.ToDouble(ws.Cells[idx, k - 3].Value);
                        RpLaba = Convert.ToDouble(ws.Cells[idx, k - 1].Value);
                        if (RpOmset != 0 && RpLaba != 0)
                        {
                            ws.Cells[idx, k].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                        }

                        ws.Cells[idx, k - 3, idx, k - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, k - 3, idx, k - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[idx, k - 3, idx, k - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }

                    RpOmset = 0;
                    RpLaba = 0;
                    for (int y = 8; y <= 24; y += 4)
                    {
                        RpOmset = Convert.ToDouble(ws.Cells[idx, y - 3].Value);
                        RpLaba = Convert.ToDouble(ws.Cells[idx, y - 1].Value);
                        if (RpOmset != 0 && RpLaba != 0)
                        {
                            ws.Cells[idx, y].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                        }

                        ws.Cells[idx, y - 3, idx, y - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, y - 3, idx, y - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[idx, y - 3, idx, y - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }

                    ws.Cells[idx, 25].Formula = "(" + ws.Cells[idx, 5].Address +
                                                        "+" + ws.Cells[idx, 9].Address +
                                                        "+" + ws.Cells[idx, 13].Address +
                                                        "+" + ws.Cells[idx, 17].Address +
                                                        "+" + ws.Cells[idx, 21].Address +
                                                        ")";
                    ws.Cells[idx, 26].Formula = "(" + ws.Cells[idx, 6].Address +
                                                       "+" + ws.Cells[idx, 10].Address +
                                                       "+" + ws.Cells[idx, 14].Address +
                                                       "+" + ws.Cells[idx, 18].Address +
                                                       "+" + ws.Cells[idx, 22].Address +
                                                       ")";
                    ws.Cells[idx, 27].Formula = "(" + ws.Cells[idx, 7].Address +
                                                         "+" + ws.Cells[idx, 11].Address +
                                                         "+" + ws.Cells[idx, 15].Address +
                                                         "+" + ws.Cells[idx, 19].Address +
                                                         "+" + ws.Cells[idx, 23].Address +
                                                         ")";
                    ws.Cells[idx, 28].Formula = "(" + ws.Cells[idx, 27].Address +
                                                           "/" + ws.Cells[idx, 25].Address +
                                                           "*100)";
                    ws.Cells[idx, 28, idx, 28].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    ws.Cells[idx, 25, idx, 28].Style.Font.Bold = true;
                    ws.Cells[idx, 25, idx, 27].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 25, idx, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, 25, idx, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    idx++;
                }

                #region Summary bawah
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 4].Merge = true;
                ws.Cells[idx, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                var border3 = ws.Cells[8, 1, idx, 28].Style.Border;
                border3.Bottom.Style =
                 border3.Top.Style =
                 border3.Left.Style =
                 border3.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[idx, 1, idx, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, 4].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 28].Style.Font.Bold = true;
                ws.Cells[8, 1, 10, 28].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[8, 1, 10, 28].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[8, 1, 10, 28].Style.Font.Bold = true;
                for (int t = 8; t <= 28; t += 4)
                {
                    ws.Cells[idx, t - 3].Formula = "SUM(" + ws.Cells[11, t - 3].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 3].Address + ")";
                    ws.Cells[idx, t - 2].Formula = "SUM(" + ws.Cells[11, t - 2].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 2].Address + ")";
                    ws.Cells[idx, t - 1].Formula = "SUM(" + ws.Cells[11, t - 1].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 1].Address + ")";

                    ws.Cells[idx, t].Formula = "(" + ws.Cells[idx, t - 1].Address +
                                                         "/" + ws.Cells[idx, t - 3].Address +
                                                         "*100)";
                    ws.Cells[idx, t].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";


                    ws.Cells[idx, t - 3, idx, t - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, t - 3, idx, t - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, t - 3, idx, t - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                #endregion
                #endregion

            }


            #endregion

            #region Piutang <body error>
            for (int h = 1; h <= 1; h++)
            {
                DataTable dtToko1 = dtV.DefaultView.ToTable(true, "KodeToko", "NamaToko", "WilID", "Kota", "Daerah");
                DataTable dtKota = dtToko1.DefaultView.ToTable(true, "Kota");

                ex.Workbook.Worksheets.Add("Piutang");
                ExcelWorksheet ws = ex.Workbook.Worksheets[Month + 3];



                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";

                // Width

                ws.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 5;

                if (rdbAktif.Checked)
                    ws.Cells[1, 1].Value = "Laporan     : TOKO AKTIF  (Umur Piutang)";
                else
                    ws.Cells[1, 1].Value = "Laporan     : TOKO PASIF  (Umur Piutang)";
                ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws.Cells[3, 1].Value = "Cabang1     : " + cabangComboBox1.CabangID;
                ws.Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws.Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;
                for (int i = 4; i <= 10; i++)
                {
                    ws.Cells[1, i].Worksheet.Column(i).Width = 13;
                }
                ws.Cells[11, 2].Value = "No"; ws.Cells[11, 2, 13, 2].Merge = true;
                ws.Cells[11, 3].Value = "KOTA"; ws.Cells[11, 3, 13, 3].Merge = true;
                ws.Cells[11, 4].Value = "Umur Piutang " + monthYearBox2.FirstDateOfMonth.ToString("MMMM yyyy");
                ws.Cells[11, 4, 11, 10].Merge = true;
                ws.Cells[12, 4].Value = "<90 HARI"; ws.Cells[12, 4, 12, 5].Merge = true;
                ws.Cells[12, 6].Value = "91 -120 HARI"; ws.Cells[12, 6, 12, 7].Merge = true;
                ws.Cells[12, 8].Value = ">120 HARI"; ws.Cells[12, 8, 12, 9].Merge = true;
                ws.Cells[12, 10].Value = "Total"; ws.Cells[12, 10, 13, 10].Merge = true;

                ws.Cells[13, 4].Value = "Rp";
                ws.Cells[13, 5].Value = "%";
                ws.Cells[13, 6].Value = "Rp";
                ws.Cells[13, 7].Value = "%";
                ws.Cells[13, 8].Value = "Rp";
                ws.Cells[13, 9].Value = "%";
                ws.Cells[13, 10].Value = "Total";

                ws.Cells[11, 1, 13, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[11, 1, 13, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //isi Total
                int idx = 14;
                int no = 1;
                int ic = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtKota.Rows.Count;
                foreach (DataRow drKota in dtKota.Rows)
                {
                    dtToko1.DefaultView.RowFilter = "Kota='" + drKota["Kota"].ToString() + "'";
                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = "Piutang Kota : " + drKota["Kota"].ToString();
                    ic++;
                    progressBar1.Value = ic;
                    ws.Cells[idx, 2].Value = no;
                    ws.Cells[idx, 3].Value = drKota["Kota"].ToString();
                    foreach (DataRowView dv1 in dtToko1.DefaultView)
                    {
                        foreach (DataRow dv in dsPV.Tables[dv1["KodeToko"].ToString()].Rows)
                        {
                            ws.Cells[idx, 4].Value = Convert.ToDouble(ws.Cells[idx, 4].Value) + Convert.ToDouble(dv["A"]);
                            ws.Cells[idx, 6].Value = Convert.ToDouble(ws.Cells[idx, 6].Value) + Convert.ToDouble(dv["B"]);
                            ws.Cells[idx, 8].Value = Convert.ToDouble(ws.Cells[idx, 8].Value) + Convert.ToDouble(dv["C"]);
                            Double T = 0;
                            T = Convert.ToDouble(dv["A"]) + Convert.ToDouble(dv["B"]) + Convert.ToDouble(dv["C"]);
                            ws.Cells[idx, 10].Value = Convert.ToDouble(ws.Cells[idx, 10].Value) + T;
                        }
                    }
                    ws.Cells[idx, 5, idx, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, 5, idx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    double tt = 0;
                    tt = Convert.ToDouble(ws.Cells[idx, 10].Value) * 100;
                    ws.Cells[idx, 5].Value = (tt == 0) ? 0 : Convert.ToDouble(ws.Cells[idx, 4].Value) / tt * 10000;
                    ws.Cells[idx, 7].Value = (tt == 0) ? 0 : Convert.ToDouble(ws.Cells[idx, 6].Value) / tt * 10000;
                    ws.Cells[idx, 9].Value = (tt == 0) ? 0 : Convert.ToDouble(ws.Cells[idx, 8].Value) / tt * 10000;
                    ws.Cells[idx, 5].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, 7].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, 9].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, 4].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 6].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 8].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    idx++;
                    no++;
                }
                //summary
                ws.Cells[idx, 2].Value = "Total"; ws.Cells[idx, 2, idx, 3].Merge = true;
                ws.Cells[idx, 2, idx, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 2, idx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[14, 4, idx, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[14, 4, idx, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[11, 2, 13, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[11, 2, 13, 10].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[11, 2, 13, 10].Style.Font.Bold = true;
                ws.Cells[idx, 2, idx, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 2, idx, 3].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 2, idx, 10].Style.Font.Bold = true;
                ws.Cells[14, 10, idx - 1, 10].Style.Font.Bold = true;
                var border3 = ws.Cells[11, 2, idx, 10].Style.Border;
                border3.Bottom.Style =
                 border3.Top.Style =
                 border3.Left.Style =
                 border3.Right.Style = ExcelBorderStyle.Thin;

                ws.Cells[11, 2, idx, 10].Style.WrapText = true;
                if (dtKota.Rows.Count > 0)
                {

                    ws.Cells[idx, 10].Formula = "SUM(" + ws.Cells[14, 10].Address +
                                                ":" + ws.Cells[idx - 1, 10].Address + ")";
                    ws.Cells[idx, 10].Style.Numberformat.Format = "#,##0;(#,##0);0";

                    for (int z = 4; z <= 8; z += 2)
                    {
                        ws.Cells[idx, z].Formula = "SUM(" + ws.Cells[14, z].Address +
                                                    ":" + ws.Cells[idx - 1, z].Address + ")";

                        ws.Cells[idx, z + 1].Formula = "(" + ws.Cells[idx, z].Address +
                                                "/" + ws.Cells[idx, 10].Address + ")*100";


                        ws.Cells[idx, z].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, z + 1].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    }

                }
            }
            #endregion

            #region TokoBronze <clear>
            for (int i = ToDate.Month; i <= ToDate.Month; i++)
            {


                ex.Workbook.Worksheets.Add("Bronze");
                ExcelWorksheet ws = ex.Workbook.Worksheets[Month + 4];

                double RpOmset = 0;
                double RpHPP = 0;
                double Laba = 0;
                //dt = DSMonthly.Tables[i - FromDate.Month].Copy();

                #region Header Bulanan
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";

                // Width
                ws.Cells[1, 1].Worksheet.Column(1).Width = 40;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 5;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 5;

                for (int y = 5; y <= 28; y++)
                {
                    ws.Cells[1, y].Worksheet.Column(y).Width = 13;
                }

                //Tiitle
                ws.Cells[1, 1].Value = "Laporan     : TOKO AKTIF KOTA (OMSET RATA-RATA BRONZE)";
                ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws.Cells[3, 1].Value = "Cabang1     : " + cabangComboBox1.CabangID;
                ws.Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws.Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;
                //ws.Cells[4, 1].Value =  Convert.ToDouble(dsKelas.Tables["TokoBronze"].Compute("SUM(FB2Omset)", string.Empty))+
                //                        Convert.ToDouble(dsKelas.Tables["TokoSilver"].Compute("SUM(FB2Omset)", string.Empty))+
                //                        Convert.ToDouble(dsKelas.Tables["TokoGold"].Compute("SUM(FB2Omset)", string.Empty))
                //                        ;

                //ws.Cells[5, 1].Value = Convert.ToDouble(dsKelas.Tables["TokoBronze"].Compute("SUM(FB2Omset)", "Kota='JAKARTA SELATAN'")) +
                //                     Convert.ToDouble(dsKelas.Tables["TokoSilver"].Compute("SUM(FB2Omset)", "Kota='JAKARTA SELATAN'")) +
                //                     Convert.ToDouble(dsKelas.Tables["TokoGold"].Compute("SUM(FB2Omset)", "Kota='JAKARTA SELATAN'"))
                //                     ;


                ws.Cells[1, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[1, 1, 5, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                //Header

                //ws.Cells[8, 1].Value = "Nama Toko"; ws.Cells[8, 1, 10, 1].Merge = true;
                ws.Cells[8, 1].Value = "KOTA"; ws.Cells[8, 1, 10, 4].Merge = true;
                ws.Cells[8, 5].Value = "Rata - rata " + FromDate.ToString("MMMM") + " s/d " + Tgl.ToString("MMMM yyyy"); ws.Cells[8, 5, 8, 24].Merge = true;

                ws.Cells[9, 5].Value = "FB2"; ws.Cells[9, 5, 9, 8].Merge = true;
                ws.Cells[9, 9].Value = "FB4"; ws.Cells[9, 9, 9, 12].Merge = true;
                ws.Cells[9, 13].Value = "FE2"; ws.Cells[9, 13, 9, 16].Merge = true;
                ws.Cells[9, 17].Value = "FE4"; ws.Cells[9, 17, 9, 20].Merge = true;
                ws.Cells[9, 21].Value = "Lainya"; ws.Cells[9, 21, 9, 24].Merge = true;


                for (int y = 5; y <= 24; y += 4)
                {
                    ws.Cells[10, y].Value = "OMSET";
                    ws.Cells[10, y + 1].Value = "HPP";
                    ws.Cells[10, y + 2].Value = "LABA RP";
                    ws.Cells[10, y + 3].Value = "LABA %";
                }

                ws.Cells[8, 25].Value = "Populasi Toko"; ws.Cells[8, 25, 10, 25].Merge = true;
                ws.Cells[8, 26].Value = "Populasi %"; ws.Cells[8, 26, 10, 26].Merge = true;

                ws.Cells[10, 27].Value = "OMSET";
                ws.Cells[10, 27 + 1].Value = "HPP";
                ws.Cells[10, 27 + 2].Value = "LABA RP";
                ws.Cells[10, 27 + 3].Value = "LABA %";



                ws.Cells[8, 27].Value = "Total"; ws.Cells[8, 27, 9, 30].Merge = true;


                ws.Cells[8, 1, 10, 30].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[8, 1, 10, 30].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                #endregion
                // List Summary Kode toko per bulan
                #region Bulanan
                DataTable dtToko1 = dsKelas.Tables["TokoBronze"].DefaultView.ToTable(true, "Kota").Copy();
                int idx = 11;
                int ic = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtToko1.Rows.Count;
                foreach (DataRow dr1 in dtToko1.Rows)
                {

                    //List<string> toko  =  drToko(dr1["KodeToko"].ToString());

                    ws.Cells[idx, 1].Value = dr1["Kota"].ToString();
                    ws.Cells[idx, 1, idx, 4].Merge = true;

                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = dr1["Kota"].ToString();
                    progressBar1.Value = ic;
                    ic++;

                    dsKelas.Tables["TokoBronze"].DefaultView.RowFilter = "Kota='" + dr1["Kota"].ToString() + "'";

                    foreach (DataRowView dv in dsKelas.Tables["TokoBronze"].DefaultView)
                    {

                        ws.Cells[idx, 5].Value =
                            Convert.ToDouble(ws.Cells[idx, 5].Value) + Convert.ToDouble(dv["FB2Omset"]);
                        ws.Cells[idx, 6].Value =
                            Convert.ToDouble(ws.Cells[idx, 6].Value) + Convert.ToDouble(dv["FB2Hpp"]);
                        ws.Cells[idx, 7].Value =
                            Convert.ToDouble(ws.Cells[idx, 7].Value) + Convert.ToDouble(dv["FB2Laba"]);


                        ws.Cells[idx, 9].Value =
                            Convert.ToDouble(ws.Cells[idx, 9].Value) + Convert.ToDouble(dv["FB4Omset"]);
                        ws.Cells[idx, 10].Value =
                            Convert.ToDouble(ws.Cells[idx, 10].Value) + Convert.ToDouble(dv["FB4Hpp"]);
                        ws.Cells[idx, 11].Value =
                            Convert.ToDouble(ws.Cells[idx, 11].Value) + Convert.ToDouble(dv["FB4Laba"]);


                        ws.Cells[idx, 13].Value =
                            Convert.ToDouble(ws.Cells[idx, 13].Value) + Convert.ToDouble(dv["FE2Omset"]);
                        ws.Cells[idx, 14].Value =
                            Convert.ToDouble(ws.Cells[idx, 14].Value) + Convert.ToDouble(dv["FE2Hpp"]);
                        ws.Cells[idx, 15].Value =
                            Convert.ToDouble(ws.Cells[idx, 15].Value) + Convert.ToDouble(dv["FE2Laba"]);


                        ws.Cells[idx, 17].Value =
                            Convert.ToDouble(ws.Cells[idx, 17].Value) + Convert.ToDouble(dv["FE4Omset"]);
                        ws.Cells[idx, 18].Value =
                            Convert.ToDouble(ws.Cells[idx, 18].Value) + Convert.ToDouble(dv["FE4Hpp"]);
                        ws.Cells[idx, 19].Value =
                            Convert.ToDouble(ws.Cells[idx, 19].Value) + Convert.ToDouble(dv["FE4Laba"]);


                        ws.Cells[idx, 21].Value =
                            Convert.ToDouble(ws.Cells[idx, 21].Value) + Convert.ToDouble(dv["LainyaOmset"]);
                        ws.Cells[idx, 22].Value =
                            Convert.ToDouble(ws.Cells[idx, 22].Value) + Convert.ToDouble(dv["LainyaHpp"]);
                        ws.Cells[idx, 23].Value =
                            Convert.ToDouble(ws.Cells[idx, 23].Value) + Convert.ToDouble(dv["LainyaLaba"]);

                    }



                    RpOmset = 0;
                    double RpLaba = 0;
                    for (int k = 8; k <= 24; k += 4)
                    {
                        ws.Cells[idx, k - 3].Value = Convert.ToDouble(ws.Cells[idx, k - 3].Value) / Month;
                        ws.Cells[idx, k - 2].Value = Convert.ToDouble(ws.Cells[idx, k - 2].Value) / Month;
                        ws.Cells[idx, k - 1].Value = Convert.ToDouble(ws.Cells[idx, k - 1].Value) / Month;
                        RpOmset = Convert.ToDouble(ws.Cells[idx, k - 3].Value);
                        RpLaba = Convert.ToDouble(ws.Cells[idx, k - 1].Value);
                        if (RpOmset != 0 && RpLaba != 0)
                        {
                            ws.Cells[idx, k].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                        }

                        ws.Cells[idx, k - 3, idx, k - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, k].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                        ws.Cells[idx, k - 3, idx, k].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[idx, k - 3, idx, k].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    }
                    ws.Cells[idx, 25].Value = NTokoPerKota(dr1["Kota"].ToString(), "TokoBronze");
                    ws.Cells[idx, 26].Value = Math.Round(
                                                Convert.ToDouble(NTokoPerKota(dr1["Kota"].ToString(), "TokoBronze")) /
                                               Convert.ToDouble(TTokoPerKota(dr1["Kota"].ToString())) * 100.00,
                                                2);
                    RpOmset = 0;
                    RpLaba = 0;


                    ws.Cells[idx, 27].Formula = "(" + ws.Cells[idx, 5].Address +
                                                        "+" + ws.Cells[idx, 9].Address +
                                                        "+" + ws.Cells[idx, 13].Address +
                                                        "+" + ws.Cells[idx, 17].Address +
                                                        "+" + ws.Cells[idx, 21].Address +
                                                        ")";
                    ws.Cells[idx, 28].Formula = "(" + ws.Cells[idx, 6].Address +
                                                       "+" + ws.Cells[idx, 10].Address +
                                                       "+" + ws.Cells[idx, 14].Address +
                                                       "+" + ws.Cells[idx, 18].Address +
                                                       "+" + ws.Cells[idx, 22].Address +
                                                       ")";
                    ws.Cells[idx, 29].Formula = "(" + ws.Cells[idx, 7].Address +
                                                         "+" + ws.Cells[idx, 11].Address +
                                                         "+" + ws.Cells[idx, 15].Address +
                                                         "+" + ws.Cells[idx, 19].Address +
                                                         "+" + ws.Cells[idx, 23].Address +
                                                         ")";
                    ws.Cells[idx, 30].Formula = "(" + ws.Cells[idx, 29].Address +
                                                           "/" + ws.Cells[idx, 27].Address +
                                                           "*100)";
                    ws.Cells[idx, 30].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    ws.Cells[idx, 27, idx, 30].Style.Font.Bold = true;
                    ws.Cells[idx, 27, idx, 29].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 5, idx, 30].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, 5, idx, 30].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    idx++;
                }

                #region Summary bawah
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 4].Merge = true;
                ws.Cells[idx, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                var border3 = ws.Cells[8, 1, idx, 30].Style.Border;
                border3.Bottom.Style =
                 border3.Top.Style =
                 border3.Left.Style =
                 border3.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[idx, 1, idx, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, 4].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 30].Style.Font.Bold = true;
                ws.Cells[8, 1, 10, 30].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[8, 1, 10, 30].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[8, 1, 10, 30].Style.Font.Bold = true;
                for (int t = 8; t <= 24; t += 4)
                {
                    ws.Cells[idx, t - 3].Formula = "SUM(" + ws.Cells[11, t - 3].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 3].Address + ")";
                    ws.Cells[idx, t - 2].Formula = "SUM(" + ws.Cells[11, t - 2].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 2].Address + ")";
                    ws.Cells[idx, t - 1].Formula = "SUM(" + ws.Cells[11, t - 1].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 1].Address + ")";

                    ws.Cells[idx, t].Formula = "(" + ws.Cells[idx, t - 1].Address +
                                                         "/" + ws.Cells[idx, t - 3].Address +
                                                         "*100)";
                    ws.Cells[idx, t].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";


                    ws.Cells[idx, t - 3, idx, t - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, t - 3, idx, t - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, t - 3, idx, t - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                ws.Cells[idx, 25].Formula = "SUM(" + ws.Cells[11, 25].Address +
                                                                           ":" + ws.Cells[idx - 1, 25].Address + ")";
                ws.Cells[idx, 26].Value = Math.Round(
                                            (double)NTokoPerKota(string.Empty, "TokoBronze") /
                                            (double)TTokoPerKota(string.Empty) * 100.00,
                                            2);
                for (int t = 30; t <= 30; t += 4)
                {
                    ws.Cells[idx, t - 3].Formula = "SUM(" + ws.Cells[11, t - 3].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 3].Address + ")";
                    ws.Cells[idx, t - 2].Formula = "SUM(" + ws.Cells[11, t - 2].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 2].Address + ")";
                    ws.Cells[idx, t - 1].Formula = "SUM(" + ws.Cells[11, t - 1].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 1].Address + ")";

                    ws.Cells[idx, t].Formula = "(" + ws.Cells[idx, t - 1].Address +
                                                         "/" + ws.Cells[idx, t - 3].Address +
                                                         "*100)";
                    ws.Cells[idx, t].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";


                    ws.Cells[idx, t - 3, idx, t - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, t - 3, idx, t].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, t - 3, idx, t].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                #endregion
                #endregion

            }


            #endregion

            #region TokoSilver <clear>
            for (int i = ToDate.Month; i <= ToDate.Month; i++)
            {


                ex.Workbook.Worksheets.Add("Silver");
                ExcelWorksheet ws = ex.Workbook.Worksheets[Month + 5];

                double RpOmset = 0;

                //dt = DSMonthly.Tables[i - FromDate.Month].Copy();

                #region Header Bulanan
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";

                // Width
                ws.Cells[1, 1].Worksheet.Column(1).Width = 40;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 5;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 5;

                for (int y = 5; y <= 28; y++)
                {
                    ws.Cells[1, y].Worksheet.Column(y).Width = 13;
                }

                //Tiitle
                if (rdbAktif.Checked)
                    ws.Cells[1, 1].Value = "Laporan     : TOKO AKTIF KOTA (OMSET RATA-RATA Silver)";
                else
                    ws.Cells[1, 1].Value = "Laporan     : TOKO PASIF KOTA (OMSET RATA-RATA Silver)";

                ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws.Cells[3, 1].Value = "Cabang1     : " + cabangComboBox1.CabangID;
                ws.Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws.Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;



                ws.Cells[1, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[1, 1, 5, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                //Header

                //ws.Cells[8, 1].Value = "Nama Toko"; ws.Cells[8, 1, 10, 1].Merge = true;
                ws.Cells[8, 1].Value = "KOTA"; ws.Cells[8, 1, 10, 4].Merge = true;
                ws.Cells[8, 5].Value = "Rata - rata " + FromDate.ToString("MMMM") + " s/d " + Tgl.ToString("MMMM yyyy"); ws.Cells[8, 5, 8, 24].Merge = true;

                ws.Cells[9, 5].Value = "FB2"; ws.Cells[9, 5, 9, 8].Merge = true;
                ws.Cells[9, 9].Value = "FB4"; ws.Cells[9, 9, 9, 12].Merge = true;
                ws.Cells[9, 13].Value = "FE2"; ws.Cells[9, 13, 9, 16].Merge = true;
                ws.Cells[9, 17].Value = "FE4"; ws.Cells[9, 17, 9, 20].Merge = true;
                ws.Cells[9, 21].Value = "Lainya"; ws.Cells[9, 21, 9, 24].Merge = true;


                for (int y = 5; y <= 24; y += 4)
                {
                    ws.Cells[10, y].Value = "OMSET";
                    ws.Cells[10, y + 1].Value = "HPP";
                    ws.Cells[10, y + 2].Value = "LABA RP";
                    ws.Cells[10, y + 3].Value = "LABA %";
                }

                ws.Cells[8, 25].Value = "Populasi Toko"; ws.Cells[8, 25, 10, 25].Merge = true;
                ws.Cells[8, 26].Value = "Populasi %"; ws.Cells[8, 26, 10, 26].Merge = true;

                ws.Cells[10, 27].Value = "OMSET";
                ws.Cells[10, 27 + 1].Value = "HPP";
                ws.Cells[10, 27 + 2].Value = "LABA RP";
                ws.Cells[10, 27 + 3].Value = "LABA %";



                ws.Cells[8, 27].Value = "Total"; ws.Cells[8, 27, 9, 30].Merge = true;


                ws.Cells[8, 1, 10, 30].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[8, 1, 10, 30].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                #endregion
                // List Summary Kode toko per bulan
                #region Bulanan
                DataTable dtToko1 = dsKelas.Tables["TokoSilver"].DefaultView.ToTable(true, "Kota").Copy();
                int idx = 11;
                int ic = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtToko1.Rows.Count;
                foreach (DataRow dr1 in dtToko1.Rows)
                {

                    //List<string> toko  =  drToko(dr1["KodeToko"].ToString());

                    ws.Cells[idx, 1].Value = dr1["Kota"].ToString();
                    ws.Cells[idx, 1, idx, 4].Merge = true;

                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = dr1["Kota"].ToString();
                    progressBar1.Value = ic;
                    ic++;

                    dsKelas.Tables["TokoSilver"].DefaultView.RowFilter = "Kota='" + dr1["Kota"].ToString() + "'";

                    foreach (DataRowView dv in dsKelas.Tables["TokoSilver"].DefaultView)
                    {

                        ws.Cells[idx, 5].Value =
                            Convert.ToDouble(ws.Cells[idx, 5].Value) + Convert.ToDouble(dv["FB2Omset"]);
                        ws.Cells[idx, 6].Value =
                            Convert.ToDouble(ws.Cells[idx, 6].Value) + Convert.ToDouble(dv["FB2Hpp"]);
                        ws.Cells[idx, 7].Value =
                            Convert.ToDouble(ws.Cells[idx, 7].Value) + Convert.ToDouble(dv["FB2Laba"]);


                        ws.Cells[idx, 9].Value =
                            Convert.ToDouble(ws.Cells[idx, 9].Value) + Convert.ToDouble(dv["FB4Omset"]);
                        ws.Cells[idx, 10].Value =
                            Convert.ToDouble(ws.Cells[idx, 10].Value) + Convert.ToDouble(dv["FB4Hpp"]);
                        ws.Cells[idx, 11].Value =
                            Convert.ToDouble(ws.Cells[idx, 11].Value) + Convert.ToDouble(dv["FB4Laba"]);


                        ws.Cells[idx, 13].Value =
                            Convert.ToDouble(ws.Cells[idx, 13].Value) + Convert.ToDouble(dv["FE2Omset"]);
                        ws.Cells[idx, 14].Value =
                            Convert.ToDouble(ws.Cells[idx, 14].Value) + Convert.ToDouble(dv["FE2Hpp"]);
                        ws.Cells[idx, 15].Value =
                            Convert.ToDouble(ws.Cells[idx, 15].Value) + Convert.ToDouble(dv["FE2Laba"]);


                        ws.Cells[idx, 17].Value =
                            Convert.ToDouble(ws.Cells[idx, 17].Value) + Convert.ToDouble(dv["FE4Omset"]);
                        ws.Cells[idx, 18].Value =
                            Convert.ToDouble(ws.Cells[idx, 18].Value) + Convert.ToDouble(dv["FE4Hpp"]);
                        ws.Cells[idx, 19].Value =
                            Convert.ToDouble(ws.Cells[idx, 19].Value) + Convert.ToDouble(dv["FE4Laba"]);


                        ws.Cells[idx, 21].Value =
                            Convert.ToDouble(ws.Cells[idx, 21].Value) + Convert.ToDouble(dv["LainyaOmset"]);
                        ws.Cells[idx, 22].Value =
                            Convert.ToDouble(ws.Cells[idx, 22].Value) + Convert.ToDouble(dv["LainyaHpp"]);
                        ws.Cells[idx, 23].Value =
                            Convert.ToDouble(ws.Cells[idx, 23].Value) + Convert.ToDouble(dv["LainyaLaba"]);

                    }



                    RpOmset = 0;
                    double RpLaba = 0;
                    for (int k = 8; k <= 24; k += 4)
                    {
                        ws.Cells[idx, k - 3].Value = Convert.ToDouble(ws.Cells[idx, k - 3].Value) / Month;
                        ws.Cells[idx, k - 2].Value = Convert.ToDouble(ws.Cells[idx, k - 2].Value) / Month;
                        ws.Cells[idx, k - 1].Value = Convert.ToDouble(ws.Cells[idx, k - 1].Value) / Month;
                        RpOmset = Convert.ToDouble(ws.Cells[idx, k - 3].Value);
                        RpLaba = Convert.ToDouble(ws.Cells[idx, k - 1].Value);
                        if (RpOmset != 0 && RpLaba != 0)
                        {
                            ws.Cells[idx, k].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                        }

                        ws.Cells[idx, k - 3, idx, k - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, k].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                        ws.Cells[idx, k - 3, idx, k].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[idx, k - 3, idx, k].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    }
                    ws.Cells[idx, 25].Value = NTokoPerKota(dr1["Kota"].ToString(), "TokoSilver");
                    ws.Cells[idx, 26].Value = Math.Round(
                                               (Double)NTokoPerKota(dr1["Kota"].ToString(), "TokoSilver") /
                                               (Double)TTokoPerKota(dr1["Kota"].ToString()) * 100,
                                                2);
                    RpOmset = 0;
                    RpLaba = 0;


                    ws.Cells[idx, 27].Formula = "(" + ws.Cells[idx, 5].Address +
                                                        "+" + ws.Cells[idx, 9].Address +
                                                        "+" + ws.Cells[idx, 13].Address +
                                                        "+" + ws.Cells[idx, 17].Address +
                                                        "+" + ws.Cells[idx, 21].Address +
                                                        ")";
                    ws.Cells[idx, 28].Formula = "(" + ws.Cells[idx, 6].Address +
                                                       "+" + ws.Cells[idx, 10].Address +
                                                       "+" + ws.Cells[idx, 14].Address +
                                                       "+" + ws.Cells[idx, 18].Address +
                                                       "+" + ws.Cells[idx, 22].Address +
                                                       ")";
                    ws.Cells[idx, 29].Formula = "(" + ws.Cells[idx, 7].Address +
                                                         "+" + ws.Cells[idx, 11].Address +
                                                         "+" + ws.Cells[idx, 15].Address +
                                                         "+" + ws.Cells[idx, 19].Address +
                                                         "+" + ws.Cells[idx, 23].Address +
                                                         ")";
                    ws.Cells[idx, 30].Formula = "(" + ws.Cells[idx, 29].Address +
                                                           "/" + ws.Cells[idx, 27].Address +
                                                           "*100)";
                    ws.Cells[idx, 30].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                    ws.Cells[idx, 27, idx, 30].Style.Font.Bold = true;
                    ws.Cells[idx, 27, idx, 29].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 27, idx, 30].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, 27, idx, 30].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    idx++;
                }
                if (dtToko1.Rows.Count == 0)
                {
                    continue; ;
                }
                #region Summary bawah
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 4].Merge = true;
                ws.Cells[idx, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                var border3 = ws.Cells[8, 1, idx, 30].Style.Border;
                border3.Bottom.Style =
                 border3.Top.Style =
                 border3.Left.Style =
                 border3.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[idx, 1, idx, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, 4].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 28].Style.Font.Bold = true;
                ws.Cells[8, 1, 10, 30].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[8, 1, 10, 30].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[8, 1, 10, 30].Style.Font.Bold = true;
                for (int t = 8; t <= 24; t += 4)
                {
                    ws.Cells[idx, t - 3].Formula = "SUM(" + ws.Cells[11, t - 3].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 3].Address + ")";
                    ws.Cells[idx, t - 2].Formula = "SUM(" + ws.Cells[11, t - 2].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 2].Address + ")";
                    ws.Cells[idx, t - 1].Formula = "SUM(" + ws.Cells[11, t - 1].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 1].Address + ")";

                    ws.Cells[idx, t].Formula = "(" + ws.Cells[idx, t - 1].Address +
                                                         "/" + ws.Cells[idx, t - 3].Address +
                                                         "*100)";
                    ws.Cells[idx, t].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";


                    ws.Cells[idx, t - 3, idx, t - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, t - 3, idx, t - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, t - 3, idx, t - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                ws.Cells[idx, 25].Formula = "SUM(" + ws.Cells[11, 25].Address +
                                                                         ":" + ws.Cells[idx - 1, 25].Address + ")";
                ws.Cells[idx, 26].Value = Math.Round(
                                            (double)NTokoPerKota(string.Empty, "TokoSilver") /
                                             (double)TTokoPerKota(string.Empty) * 100.00,
                                             2);
                for (int t = 30; t <= 30; t += 4)
                {
                    ws.Cells[idx, t - 3].Formula = "SUM(" + ws.Cells[11, t - 3].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 3].Address + ")";
                    ws.Cells[idx, t - 2].Formula = "SUM(" + ws.Cells[11, t - 2].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 2].Address + ")";
                    ws.Cells[idx, t - 1].Formula = "SUM(" + ws.Cells[11, t - 1].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 1].Address + ")";

                    ws.Cells[idx, t].Formula = "(" + ws.Cells[idx, t - 1].Address +
                                                         "/" + ws.Cells[idx, t - 3].Address +
                                                         "*100)";
                    ws.Cells[idx, t].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";


                    ws.Cells[idx, t - 3, idx, t - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, t - 3, idx, t].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, t - 3, idx, t].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                #endregion
                #endregion

            }


            #endregion

            #region TokoGold <clear>
            for (int i = ToDate.Month; i <= ToDate.Month; i++)
            {
                ex.Workbook.Worksheets.Add("Gold");
                ExcelWorksheet ws = ex.Workbook.Worksheets[Month + 6];
                double RpOmset = 0;
                //dt = DSMonthly.Tables[i - FromDate.Month].Copy();

                #region Header Bulanan
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";

                // Width
                ws.Cells[1, 1].Worksheet.Column(1).Width = 40;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 5;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 5;

                for (int y = 5; y <= 28; y++)
                {
                    ws.Cells[1, y].Worksheet.Column(y).Width = 13;
                }

                //Tiitle
                if (rdbAktif.Checked)
                    ws.Cells[1, 1].Value = "Laporan     : TOKO AKTIF KOTA (OMSET RATA-RATA Gold)";
                else
                    ws.Cells[1, 1].Value = "Laporan     : TOKO PASIF KOTA (OMSET RATA-RATA Gold)";

                ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws.Cells[3, 1].Value = "Cabang1     : " + cabangComboBox1.CabangID;
                ws.Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws.Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;
                ws.Cells[1, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[1, 1, 5, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //Header
                //ws.Cells[8, 1].Value = "Nama Toko"; ws.Cells[8, 1, 10, 1].Merge = true;
                ws.Cells[8, 1].Value = "KOTA"; ws.Cells[8, 1, 10, 4].Merge = true;
                ws.Cells[8, 5].Value = "Rata - rata " + FromDate.ToString("MMMM") + " s/d " + Tgl.ToString("MMMM yyyy"); ws.Cells[8, 5, 8, 24].Merge = true;
                ws.Cells[9, 5].Value = "FB2"; ws.Cells[9, 5, 9, 8].Merge = true;
                ws.Cells[9, 9].Value = "FB4"; ws.Cells[9, 9, 9, 12].Merge = true;
                ws.Cells[9, 13].Value = "FE2"; ws.Cells[9, 13, 9, 16].Merge = true;
                ws.Cells[9, 17].Value = "FE4"; ws.Cells[9, 17, 9, 20].Merge = true;
                ws.Cells[9, 21].Value = "Lainya"; ws.Cells[9, 21, 9, 24].Merge = true;

                for (int y = 5; y <= 24; y += 4)
                {
                    ws.Cells[10, y].Value = "OMSET";
                    ws.Cells[10, y + 1].Value = "HPP";
                    ws.Cells[10, y + 2].Value = "LABA RP";
                    ws.Cells[10, y + 3].Value = "LABA %";
                }
                ws.Cells[8, 25].Value = "Populasi Toko"; ws.Cells[8, 25, 10, 25].Merge = true;
                ws.Cells[8, 26].Value = "Populasi %"; ws.Cells[8, 26, 10, 26].Merge = true;
                ws.Cells[10, 27].Value = "OMSET";
                ws.Cells[10, 27 + 1].Value = "HPP";
                ws.Cells[10, 27 + 2].Value = "LABA RP";
                ws.Cells[10, 27 + 3].Value = "LABA %";
                ws.Cells[8, 27].Value = "Total"; ws.Cells[8, 27, 9, 30].Merge = true;
                ws.Cells[8, 1, 10, 30].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[8, 1, 10, 30].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                #endregion
                // List Summary Kode toko per bulan
                #region Bulanan
                DataTable dtToko1 = dsKelas.Tables["TokoGold"].DefaultView.ToTable(true, "Kota").Copy();
                int idx = 11;
                int ic = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtToko1.Rows.Count;
                foreach (DataRow dr1 in dtToko1.Rows)
                {
                    //List<string> toko  =  drToko(dr1["KodeToko"].ToString());
                    ws.Cells[idx, 1].Value = dr1["Kota"].ToString();
                    ws.Cells[idx, 1, idx, 4].Merge = true;
                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = dr1["Kota"].ToString();
                    progressBar1.Value = ic;
                    ic++;
                    dsKelas.Tables["TokoGold"].DefaultView.RowFilter = "Kota='" + dr1["Kota"].ToString() + "'";
                    foreach (DataRowView dv in dsKelas.Tables["TokoGold"].DefaultView)
                    {
                        ws.Cells[idx, 5].Value =
                            Convert.ToDouble(ws.Cells[idx, 5].Value) + Convert.ToDouble(dv["FB2Omset"]);
                        ws.Cells[idx, 6].Value =
                            Convert.ToDouble(ws.Cells[idx, 6].Value) + Convert.ToDouble(dv["FB2Hpp"]);
                        ws.Cells[idx, 7].Value =
                            Convert.ToDouble(ws.Cells[idx, 7].Value) + Convert.ToDouble(dv["FB2Laba"]);
                        ws.Cells[idx, 9].Value =
                            Convert.ToDouble(ws.Cells[idx, 9].Value) + Convert.ToDouble(dv["FB4Omset"]);
                        ws.Cells[idx, 10].Value =
                            Convert.ToDouble(ws.Cells[idx, 10].Value) + Convert.ToDouble(dv["FB4Hpp"]);
                        ws.Cells[idx, 11].Value =
                            Convert.ToDouble(ws.Cells[idx, 11].Value) + Convert.ToDouble(dv["FB4Laba"]);
                        ws.Cells[idx, 13].Value =
                            Convert.ToDouble(ws.Cells[idx, 13].Value) + Convert.ToDouble(dv["FE2Omset"]);
                        ws.Cells[idx, 14].Value =
                            Convert.ToDouble(ws.Cells[idx, 14].Value) + Convert.ToDouble(dv["FE2Hpp"]);
                        ws.Cells[idx, 15].Value =
                            Convert.ToDouble(ws.Cells[idx, 15].Value) + Convert.ToDouble(dv["FE2Laba"]);
                        ws.Cells[idx, 17].Value =
                            Convert.ToDouble(ws.Cells[idx, 17].Value) + Convert.ToDouble(dv["FE4Omset"]);
                        ws.Cells[idx, 18].Value =
                            Convert.ToDouble(ws.Cells[idx, 18].Value) + Convert.ToDouble(dv["FE4Hpp"]);
                        ws.Cells[idx, 19].Value =
                            Convert.ToDouble(ws.Cells[idx, 19].Value) + Convert.ToDouble(dv["FE4Laba"]);
                        ws.Cells[idx, 21].Value =
                            Convert.ToDouble(ws.Cells[idx, 21].Value) + Convert.ToDouble(dv["LainyaOmset"]);
                        ws.Cells[idx, 22].Value =
                            Convert.ToDouble(ws.Cells[idx, 22].Value) + Convert.ToDouble(dv["LainyaHpp"]);
                        ws.Cells[idx, 23].Value =
                            Convert.ToDouble(ws.Cells[idx, 23].Value) + Convert.ToDouble(dv["LainyaLaba"]);
                    }
                    RpOmset = 0;
                    double RpLaba = 0;
                    for (int k = 8; k <= 24; k += 4)
                    {
                        ws.Cells[idx, k - 3].Value = Convert.ToDouble(ws.Cells[idx, k - 3].Value) / Month;
                        ws.Cells[idx, k - 2].Value = Convert.ToDouble(ws.Cells[idx, k - 2].Value) / Month;
                        ws.Cells[idx, k - 1].Value = Convert.ToDouble(ws.Cells[idx, k - 1].Value) / Month;
                        RpOmset = Convert.ToDouble(ws.Cells[idx, k - 3].Value);
                        RpLaba = Convert.ToDouble(ws.Cells[idx, k - 1].Value);
                        if (RpOmset != 0 && RpLaba != 0)
                        {
                            ws.Cells[idx, k].Value = Math.Round(RpLaba / RpOmset * 100, 2);
                        }
                        ws.Cells[idx, k - 3, idx, k - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, k].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                        ws.Cells[idx, k - 3, idx, k].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[idx, k - 3, idx, k].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    RpOmset = 0;
                    RpLaba = 0;
                    ws.Cells[idx, 25].Value = NTokoPerKota(dr1["Kota"].ToString(), "TokoGold");
                    ws.Cells[idx, 26].Value = Math.Round(
                                               (double)NTokoPerKota(dr1["Kota"].ToString(), "TokoGold") /
                                               (double)TTokoPerKota(dr1["Kota"].ToString()) * 100.00,
                                                2);
                    ws.Cells[idx, 27].Formula = "(" + ws.Cells[idx, 5].Address +
                                                        "+" + ws.Cells[idx, 9].Address +
                                                        "+" + ws.Cells[idx, 13].Address +
                                                        "+" + ws.Cells[idx, 17].Address +
                                                        "+" + ws.Cells[idx, 21].Address +
                                                        ")";
                    ws.Cells[idx, 28].Formula = "(" + ws.Cells[idx, 6].Address +
                                                       "+" + ws.Cells[idx, 10].Address +
                                                       "+" + ws.Cells[idx, 14].Address +
                                                       "+" + ws.Cells[idx, 18].Address +
                                                       "+" + ws.Cells[idx, 22].Address +
                                                       ")";
                    ws.Cells[idx, 29].Formula = "(" + ws.Cells[idx, 7].Address +
                                                         "+" + ws.Cells[idx, 11].Address +
                                                         "+" + ws.Cells[idx, 15].Address +
                                                         "+" + ws.Cells[idx, 19].Address +
                                                         "+" + ws.Cells[idx, 23].Address +
                                                         ")";
                    ws.Cells[idx, 30].Formula = "(" + ws.Cells[idx, 29].Address +
                                                           "/" + ws.Cells[idx, 27].Address +
                                                           "*100)";
                    ws.Cells[idx, 30].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, 27, idx, 30].Style.Font.Bold = true;
                    ws.Cells[idx, 27, idx, 29].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 27, idx, 30].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, 27, idx, 30].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    idx++;
                }
                if (dtToko1.Rows.Count == 0)
                {
                    continue; ;
                }
                #region Summary bawah
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 4].Merge = true;
                ws.Cells[idx, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                var border3 = ws.Cells[8, 1, idx, 30].Style.Border;
                border3.Bottom.Style =
                 border3.Top.Style =
                 border3.Left.Style =
                 border3.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[idx, 1, idx, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, 4].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 1, idx, 28].Style.Font.Bold = true;
                ws.Cells[8, 1, 10, 30].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[8, 1, 10, 30].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[8, 1, 10, 30].Style.Font.Bold = true;
                for (int t = 8; t <= 24; t += 4)
                {
                    ws.Cells[idx, t - 3].Formula = "SUM(" + ws.Cells[11, t - 3].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 3].Address + ")";
                    ws.Cells[idx, t - 2].Formula = "SUM(" + ws.Cells[11, t - 2].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 2].Address + ")";
                    ws.Cells[idx, t - 1].Formula = "SUM(" + ws.Cells[11, t - 1].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 1].Address + ")";
                    ws.Cells[idx, t].Formula = "(" + ws.Cells[idx, t - 1].Address +
                                                         "/" + ws.Cells[idx, t - 3].Address +
                                                         "*100)";
                    ws.Cells[idx, t].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, t - 3, idx, t - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, t - 3, idx, t - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, t - 3, idx, t - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                ws.Cells[idx, 25].Formula = "SUM(" + ws.Cells[11, 25].Address +
                                                                         ":" + ws.Cells[idx - 1, 25].Address + ")";
                ws.Cells[idx, 26].Value = Math.Round(
                                            (double)NTokoPerKota(string.Empty, "TokoGold") /
                                            (double)TTokoPerKota(string.Empty) * 100.00,
                                             2);
                for (int t = 30; t <= 30; t += 4)
                {
                    ws.Cells[idx, t - 3].Formula = "SUM(" + ws.Cells[11, t - 3].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 3].Address + ")";
                    ws.Cells[idx, t - 2].Formula = "SUM(" + ws.Cells[11, t - 2].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 2].Address + ")";
                    ws.Cells[idx, t - 1].Formula = "SUM(" + ws.Cells[11, t - 1].Address +
                                                                           ":" + ws.Cells[idx - 1, t - 1].Address + ")";
                    ws.Cells[idx, t].Formula = "(" + ws.Cells[idx, t - 1].Address +
                                                         "/" + ws.Cells[idx, t - 3].Address +
                                                         "*100)";
                    ws.Cells[idx, t].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, t - 3, idx, t - 1].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, t - 3, idx, t].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[idx, t - 3, idx, t].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                #endregion
                #endregion
            }


            #endregion

            #region PiutangBronze <clear>
            for (int h = 1; h <= 1; h++)
            {
                DataTable dtKota = dsPelas.Tables["TokoBronze"].DefaultView.ToTable(true, "Kota");
                ex.Workbook.Worksheets.Add("PiutangBronze");
                ExcelWorksheet ws = ex.Workbook.Worksheets[Month + 7];
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";
                // Width
                ws.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 5;
                if (rdbAktif.Checked)
                    ws.Cells[1, 1].Value = "Laporan     : TOKO AKTIF  (Umur Piutang Bronze)";
                else
                    ws.Cells[1, 1].Value = "Laporan     : TOKO PASIF  (Umur Piutang Bronze)";
                ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws.Cells[3, 1].Value = "Cabang1     : " + cabangComboBox1.CabangID;
                ws.Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws.Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;
                for (int i = 4; i <= 10; i++)
                {
                    ws.Cells[1, i].Worksheet.Column(i).Width = 13;
                }
                ws.Cells[11, 2].Value = "No"; ws.Cells[11, 2, 13, 2].Merge = true;
                ws.Cells[11, 3].Value = "KOTA"; ws.Cells[11, 3, 13, 3].Merge = true;
                ws.Cells[11, 4].Value = "Umur Piutang " +
                                               monthYearBox2.FirstDateOfMonth.ToString("MMMM yyyy")
                                            ;
                ws.Cells[11, 4, 11, 10].Merge = true;
                ws.Cells[12, 4].Value = "<90 HARI"; ws.Cells[12, 4, 12, 5].Merge = true;
                ws.Cells[12, 6].Value = "91 -120 HARI"; ws.Cells[12, 6, 12, 7].Merge = true;
                ws.Cells[12, 8].Value = ">120 HARI"; ws.Cells[12, 8, 12, 9].Merge = true;
                ws.Cells[12, 10].Value = "Total"; ws.Cells[12, 10, 13, 10].Merge = true;
                ws.Cells[13, 4].Value = "Rp";
                ws.Cells[13, 5].Value = "%";
                ws.Cells[13, 6].Value = "Rp";
                ws.Cells[13, 7].Value = "%";
                ws.Cells[13, 8].Value = "Rp";
                ws.Cells[13, 9].Value = "%";
                ws.Cells[13, 10].Value = "Total";
                ws.Cells[11, 1, 13, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[11, 1, 13, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                //isi Total
                int idx = 14;
                int ic = 0;
                int no = 1;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtKota.Rows.Count;
                dtKota.DefaultView.Sort = "Kota";
                foreach (DataRowView drKota in dtKota.DefaultView)
                {
                    dsPelas.Tables["TokoBronze"].DefaultView.RowFilter = "Kota='" + drKota["Kota"].ToString() + "'";
                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = drKota["Kota"].ToString();
                    ic++;
                    progressBar1.Value = ic;
                    ws.Cells[idx, 2].Value = no;
                    ws.Cells[idx, 3].Value = drKota["Kota"].ToString();
                    foreach (DataRowView dv in dsPelas.Tables["TokoBronze"].DefaultView)
                    {
                        ws.Cells[idx, 4].Value = Convert.ToDouble(ws.Cells[idx, 4].Value) + Convert.ToDouble(dv["A"]);
                        ws.Cells[idx, 6].Value = Convert.ToDouble(ws.Cells[idx, 6].Value) + Convert.ToDouble(dv["B"]);
                        ws.Cells[idx, 8].Value = Convert.ToDouble(ws.Cells[idx, 8].Value) + Convert.ToDouble(dv["C"]);
                        Double T = 0;
                        T = Convert.ToDouble(dv["A"]) + Convert.ToDouble(dv["B"]) + Convert.ToDouble(dv["C"]);
                        ws.Cells[idx, 10].Value = Convert.ToDouble(ws.Cells[idx, 10].Value) + T;
                    }
                    double tt = 0;
                    tt = Convert.ToDouble(ws.Cells[idx, 10].Value) * 100;
                    ws.Cells[idx, 5].Value = (tt == 0) ? 0 : Convert.ToDouble(ws.Cells[idx, 4].Value) / tt * 10000;
                    ws.Cells[idx, 7].Value = (tt == 0) ? 0 : Convert.ToDouble(ws.Cells[idx, 6].Value) / tt * 10000;
                    ws.Cells[idx, 9].Value = (tt == 0) ? 0 : Convert.ToDouble(ws.Cells[idx, 8].Value) / tt * 10000;
                    ws.Cells[idx, 5].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, 7].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, 9].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, 4].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 6].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 8].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    idx++;
                    no++;
                }
                //summary
                ws.Cells[idx, 2].Value = "Total"; ws.Cells[idx, 2, idx, 3].Merge = true;
                ws.Cells[idx, 2, idx, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 2, idx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[14, 4, idx, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[14, 4, idx, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[11, 2, 13, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[11, 2, 13, 10].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[11, 2, 13, 10].Style.Font.Bold = true;
                ws.Cells[idx, 2, idx, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 2, idx, 3].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 2, idx, 10].Style.Font.Bold = true;
                if (idx > 14)
                {
                    ws.Cells[14, 10, idx - 1, 10].Style.Font.Bold = true;
                }
                var border3 = ws.Cells[11, 2, idx, 10].Style.Border;
                border3.Bottom.Style =
                 border3.Top.Style =
                 border3.Left.Style =
                 border3.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[11, 2, idx, 10].Style.WrapText = true;
                if (dtKota.Rows.Count > 0)
                {
                    ws.Cells[idx, 10].Formula = "SUM(" + ws.Cells[14, 10].Address +
                                                ":" + ws.Cells[idx - 1, 10].Address + ")";
                    ws.Cells[idx, 10].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    for (int z = 4; z <= 8; z += 2)
                    {
                        ws.Cells[idx, z].Formula = "SUM(" + ws.Cells[14, z].Address +
                                                    ":" + ws.Cells[idx - 1, z].Address + ")";
                        ws.Cells[idx, z + 1].Formula = "(" + ws.Cells[idx, z].Address +
                                                "/" + ws.Cells[idx, 10].Address + ")*100";
                        ws.Cells[idx, z].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, z + 1].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    }
                }
            }
            #endregion

            #region PiutangSilver <clear>
            for (int h = 1; h <= 1; h++)
            {
                DataTable dtKota = dsPelas.Tables["TokoSilver"].DefaultView.ToTable(true, "Kota");
                ex.Workbook.Worksheets.Add("PiutangSilver");
                ExcelWorksheet ws = ex.Workbook.Worksheets[Month + 8];
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";
                // Width
                ws.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 5;

                if (rdbAktif.Checked)
                    ws.Cells[1, 1].Value = "Laporan     : TOKO AKTIF  (Umur Piutang Silver)";
                else
                    ws.Cells[1, 1].Value = "Laporan     : TOKO PASIF  (Umur Piutang Silver)";

                ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws.Cells[3, 1].Value = "Cabang1     : " + cabangComboBox1.CabangID;
                ws.Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws.Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;
                for (int i = 4; i <= 10; i++)
                {
                    ws.Cells[1, i].Worksheet.Column(i).Width = 13;
                }
                ws.Cells[11, 2].Value = "No"; ws.Cells[11, 2, 13, 2].Merge = true;
                ws.Cells[11, 3].Value = "KOTA"; ws.Cells[11, 3, 13, 3].Merge = true;
                ws.Cells[11, 4].Value = "Umur Piutang " + monthYearBox2.FirstDateOfMonth.ToString("MMMM yyyy");
                ws.Cells[11, 4, 11, 10].Merge = true;
                ws.Cells[12, 4].Value = "<90 HARI"; ws.Cells[12, 4, 12, 5].Merge = true;
                ws.Cells[12, 6].Value = "91 -120 HARI"; ws.Cells[12, 6, 12, 7].Merge = true;
                ws.Cells[12, 8].Value = ">120 HARI"; ws.Cells[12, 8, 12, 9].Merge = true;
                ws.Cells[12, 10].Value = "Total"; ws.Cells[12, 10, 13, 10].Merge = true;
                ws.Cells[13, 4].Value = "Rp";
                ws.Cells[13, 5].Value = "%";
                ws.Cells[13, 6].Value = "Rp";
                ws.Cells[13, 7].Value = "%";
                ws.Cells[13, 8].Value = "Rp";
                ws.Cells[13, 9].Value = "%";
                ws.Cells[13, 10].Value = "Total";
                ws.Cells[11, 1, 13, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[11, 1, 13, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                //isi Total
                int idx = 14;
                int ic = 0;
                int no = 1;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtKota.Rows.Count;
                dtKota.DefaultView.Sort = "Kota";
                foreach (DataRowView drKota in dtKota.DefaultView)
                {
                    dsPelas.Tables["TokoSilver"].DefaultView.RowFilter = "Kota='" + drKota["Kota"].ToString() + "'";
                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = drKota["Kota"].ToString();
                    ic++;
                    progressBar1.Value = ic;
                    ws.Cells[idx, 2].Value = no;
                    ws.Cells[idx, 3].Value = drKota["Kota"].ToString();
                    foreach (DataRowView dv in dsPelas.Tables["TokoSilver"].DefaultView)
                    {
                        ws.Cells[idx, 4].Value = Convert.ToDouble(ws.Cells[idx, 4].Value) + Convert.ToDouble(dv["A"]);
                        ws.Cells[idx, 6].Value = Convert.ToDouble(ws.Cells[idx, 6].Value) + Convert.ToDouble(dv["B"]);
                        ws.Cells[idx, 8].Value = Convert.ToDouble(ws.Cells[idx, 8].Value) + Convert.ToDouble(dv["C"]);
                        Double T = 0;
                        T = Convert.ToDouble(dv["A"]) + Convert.ToDouble(dv["B"]) + Convert.ToDouble(dv["C"]);
                        ws.Cells[idx, 10].Value = Convert.ToDouble(ws.Cells[idx, 10].Value) + T;
                    }
                    double tt = 0;
                    tt = Convert.ToDouble(ws.Cells[idx, 10].Value) * 100;
                    ws.Cells[idx, 5].Value = (tt == 0) ? 0 : Convert.ToDouble(ws.Cells[idx, 4].Value) / tt * 10000;
                    ws.Cells[idx, 7].Value = (tt == 0) ? 0 : Convert.ToDouble(ws.Cells[idx, 6].Value) / tt * 10000;
                    ws.Cells[idx, 9].Value = (tt == 0) ? 0 : Convert.ToDouble(ws.Cells[idx, 8].Value) / tt * 10000;
                    ws.Cells[idx, 5].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, 7].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, 9].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, 4].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 6].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 8].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    idx++;
                    no++;
                }
                //summary
                ws.Cells[idx, 2].Value = "Total"; ws.Cells[idx, 2, idx, 3].Merge = true;
                ws.Cells[idx, 2, idx, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 2, idx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[14, 4, idx, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[14, 4, idx, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[11, 2, 13, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[11, 2, 13, 10].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[11, 2, 13, 10].Style.Font.Bold = true;
                ws.Cells[idx, 2, idx, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 2, idx, 3].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 2, idx, 10].Style.Font.Bold = true;
                if (idx > 14)
                {
                    ws.Cells[14, 10, idx - 1, 10].Style.Font.Bold = true;
                }
                var border3 = ws.Cells[11, 2, idx, 10].Style.Border;
                border3.Bottom.Style =
                border3.Top.Style =
                border3.Left.Style =
                border3.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[11, 2, idx, 10].Style.WrapText = true;
                if (dtKota.Rows.Count > 0)
                {
                    ws.Cells[idx, 10].Formula = "SUM(" + ws.Cells[14, 10].Address +
                                                ":" + ws.Cells[idx - 1, 10].Address + ")";
                    ws.Cells[idx, 10].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    for (int z = 4; z <= 8; z += 2)
                    {
                        ws.Cells[idx, z].Formula = "SUM(" + ws.Cells[14, z].Address +
                                                    ":" + ws.Cells[idx - 1, z].Address + ")";
                        ws.Cells[idx, z + 1].Formula = "(" + ws.Cells[idx, z].Address +
                                            "/" + ws.Cells[idx, 10].Address + ")*100";
                        ws.Cells[idx, z].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, z + 1].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    }
                }
            }
            #endregion

            #region PiutangGold <clear>
            for (int h = 1; h <= 1; h++)
            {
                DataTable dtKota = dsPelas.Tables["TokoGold"].DefaultView.ToTable(true, "Kota");
                ex.Workbook.Worksheets.Add("PiutangGold");
                ExcelWorksheet ws = ex.Workbook.Worksheets[Month + 9];
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial";
                // Width
                ws.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 5;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 20;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 5;
                if (rdbAktif.Checked)
                    ws.Cells[1, 1].Value = "Laporan     : TOKO AKTIF  (Umur Piutang Gold)";
                else
                    ws.Cells[1, 1].Value = "Laporan     : TOKO PASIF  (Umur Piutang Gold)";
                ws.Cells[2, 1].Value = "Periode     : " + string.Format("{0:MMMM yyyy}", monthYearBox1.FirstDateOfMonth) + " - " + string.Format("{0:MMMM yyyy}", monthYearBox2.LastDateOfMonth);
                ws.Cells[3, 1].Value = "Cabang1     : " + cabangComboBox1.CabangID;
                ws.Cells[4, 1].Value = "Kode Sales  : " + lookupSales1.SalesID + "  " + lookupSales1.NamaSales;
                ws.Cells[5, 1].Value = "Kode Gudang : " + lookupGudang1.GudangID + "  " + lookupGudang1.NamaGudang;
                for (int i = 4; i <= 10; i++)
                {
                    ws.Cells[1, i].Worksheet.Column(i).Width = 13;
                }
                ws.Cells[11, 2].Value = "No"; ws.Cells[11, 2, 13, 2].Merge = true;
                ws.Cells[11, 3].Value = "KOTA"; ws.Cells[11, 3, 13, 3].Merge = true;
                ws.Cells[11, 4].Value = "Umur Piutang " +
                                               monthYearBox2.FirstDateOfMonth.ToString("MMMM yyyy")
                                            ;
                ws.Cells[11, 4, 11, 10].Merge = true;
                ws.Cells[12, 4].Value = "<90 HARI"; ws.Cells[12, 4, 12, 5].Merge = true;
                ws.Cells[12, 6].Value = "91 -120 HARI"; ws.Cells[12, 6, 12, 7].Merge = true;
                ws.Cells[12, 8].Value = ">120 HARI"; ws.Cells[12, 8, 12, 9].Merge = true;
                ws.Cells[12, 10].Value = "Total"; ws.Cells[12, 10, 13, 10].Merge = true;
                ws.Cells[13, 4].Value = "Rp";
                ws.Cells[13, 5].Value = "%";
                ws.Cells[13, 6].Value = "Rp";
                ws.Cells[13, 7].Value = "%";
                ws.Cells[13, 8].Value = "Rp";
                ws.Cells[13, 9].Value = "%";
                ws.Cells[13, 10].Value = "Total";
                ws.Cells[11, 1, 13, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[11, 1, 13, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                //isi Total
                int idx = 14;
                int ic = 0;
                int no = 1;
                progressBar1.Value = 0;
                progressBar1.Maximum = dtKota.Rows.Count;
                dtKota.DefaultView.Sort = "Kota";
                foreach (DataRowView drKota in dtKota.DefaultView)
                {
                    dsPelas.Tables["TokoGold"].DefaultView.RowFilter = "Kota='" + drKota["Kota"].ToString() + "'";
                    Application.DoEvents();
                    this.Invalidate();
                    txtNamaToko.Text = drKota["Kota"].ToString();
                    ic++;
                    progressBar1.Value = ic;
                    ws.Cells[idx, 2].Value = no;
                    ws.Cells[idx, 3].Value = drKota["Kota"].ToString();
                    foreach (DataRowView dv in dsPelas.Tables["TokoGold"].DefaultView)
                    {
                        ws.Cells[idx, 4].Value = Convert.ToDouble(ws.Cells[idx, 4].Value) + Convert.ToDouble(dv["A"]);
                        ws.Cells[idx, 6].Value = Convert.ToDouble(ws.Cells[idx, 6].Value) + Convert.ToDouble(dv["B"]);
                        ws.Cells[idx, 8].Value = Convert.ToDouble(ws.Cells[idx, 8].Value) + Convert.ToDouble(dv["C"]);
                        Double T = 0;
                        T = Convert.ToDouble(dv["A"]) + Convert.ToDouble(dv["B"]) + Convert.ToDouble(dv["C"]);
                        ws.Cells[idx, 10].Value = Convert.ToDouble(ws.Cells[idx, 10].Value) + T;
                    }
                    double tt = 0;
                    tt = Convert.ToDouble(ws.Cells[idx, 10].Value) * 100;
                    ws.Cells[idx, 5].Value = (tt == 0) ? 0 : Convert.ToDouble(ws.Cells[idx, 4].Value) / tt * 10000;
                    ws.Cells[idx, 7].Value = (tt == 0) ? 0 : Convert.ToDouble(ws.Cells[idx, 6].Value) / tt * 10000;
                    ws.Cells[idx, 9].Value = (tt == 0) ? 0 : Convert.ToDouble(ws.Cells[idx, 8].Value) / tt * 10000;
                    ws.Cells[idx, 5].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, 7].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, 9].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    ws.Cells[idx, 4].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 6].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    ws.Cells[idx, 8].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    idx++;
                    no++;
                }
                //summary
                ws.Cells[idx, 2].Value = "Total"; ws.Cells[idx, 2, idx, 3].Merge = true;
                ws.Cells[idx, 2, idx, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 2, idx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[14, 4, idx, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[14, 4, idx, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[11, 2, 13, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[11, 2, 13, 10].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[11, 2, 13, 10].Style.Font.Bold = true;
                ws.Cells[idx, 2, idx, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 2, idx, 3].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                ws.Cells[idx, 2, idx, 10].Style.Font.Bold = true;
                if (idx > 14)
                {
                    ws.Cells[14, 10, idx - 1, 10].Style.Font.Bold = true;
                }
                var border3 = ws.Cells[11, 2, idx, 10].Style.Border;
                border3.Bottom.Style =
                 border3.Top.Style =
                 border3.Left.Style =
                 border3.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[11, 2, idx, 10].Style.WrapText = true;
                if (dtKota.Rows.Count > 0)
                {
                    ws.Cells[idx, 10].Formula = "SUM(" + ws.Cells[14, 10].Address +
                                                ":" + ws.Cells[idx - 1, 10].Address + ")";
                    ws.Cells[idx, 10].Style.Numberformat.Format = "#,##0;(#,##0);0";
                    double aa = Convert.ToDouble(ws.Cells[idx, 10].Value);
                    for (int z = 4; z <= 8; z += 2)
                    {
                        ws.Cells[idx, z].Formula = "SUM(" + ws.Cells[14, z].Address +
                                                    ":" + ws.Cells[idx - 1, z].Address + ")";
                        ws.Cells[idx, z + 1].Formula = "(" + ws.Cells[idx, z].Address +
                                               "/" + ws.Cells[idx, 10].Address + ")*100";
                        ws.Cells[idx, z].Style.Numberformat.Format = "#,##0;(#,##0);0";
                        ws.Cells[idx, z + 1].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";
                    }
                }
            }
            #endregion
            return ex;
        }

    }
}
