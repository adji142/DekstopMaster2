using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.Class;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Trading.Fixrute
{
    public partial class frmRptLaporanKunjunganHarianPerSalesman : ISA.Trading.BaseForm
    {
        DataTable dtKunj;
        string tanggal;
        public frmRptLaporanKunjunganHarianPerSalesman()
        {
            InitializeComponent();
        }

        private void frmRptLaporanKunjunganHarianPerSalesman_Load(object sender, EventArgs e)
        {

            //dateTextBox1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_cetakLaporanKunjSalesPerhari"));
                db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, dateTimePicker1.Value.Date));
                db.Commands[0].Parameters.Add(new Parameter("@kodesales", SqlDbType.VarChar, lookupSales1.SalesID));
                dtKunj = db.Commands[0].ExecuteDataTable();
                
            }
            if (dtKunj.Rows.Count == 0)
            {
                MessageBox.Show("data tidak ditemukan");
                return;
            }
            else
            {
                cetak(dtKunj);
            }
        }


        private void cetak(DataTable dt)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                string tt = string.Format("{0:dd-MMM-yyyy}", dtKunj.Rows[0]["tmt1"]);
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("namasales", dtKunj.Rows[0]["kd_sales"].ToString()));
                rptParams.Add(new ReportParameter("tmt1", tt.Contains("1900") ? "" : tt));
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Fixrute.Report1.rdlc", rptParams, dt, "dsKunjSalesPerHari_Data");
                ifrmReport.Text = "Data Pegawai";
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

        //public void CetakLaporan(DataTable dt)
        //{
        //    BuildString data = new BuildString();
        //    string typePrinter = data.GetPrinterName();//ISA.Trading.LookupInfo.GetValue("PRINTER", "DOT_MATRIX"); 
        //    string sNamaSales = dt.Rows[0]["kd_sales"].ToString().Trim();
        //    string sTanggal = dt.Rows[0]["tmt1"].ToString().Trim();
            

        //    data.Initialize();
        //    data.PageLLine(33);
        //    data.LeftMargin(1);
        //    data.BottomMargin(1);

        //    #region Header
        //    if (typePrinter.Contains("LX"))
        //    {
        //        data.LetterQuality(false);
        //        data.FontBold(true);
        //        data.FontCondensed(true);
        //        data.DoubleHeight(true);
        //    }
        //    else
        //    {
        //        data.LetterQuality(true);
        //        data.FontBold(true);
        //        data.DoubleHeight(true);
        //        data.DoubleWidth(true);
        //    }
        //    data.PROW(true, 1, "FORM KUNJUNGAN SALESMAN");
        //    data.DoubleHeight(false);
        //    data.DoubleWidth(false);
        //    data.FontCPI(12);
        //    data.LineSpacing("1/8");
        //    data.FontCondensed(false);
        //    data.LetterQuality(false);
        //    data.FontCondensed(false);
        //    data.PROW(true, 1, "Nama Salesman   : " + sNamaSales+ " ");
        //    data.FontItalic(true);
        //    data.PROW(true, 1, "Tanggal         : " + sTanggal+ " ");
        //    data.FontItalic(true);
        //    data.PROW(true, 1, "");
        //    data.FontCondensed(true);

        //    data.PROW(false, 2, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
        //    data.PROW(true, 1, "NO.   N A M A   T O K O / A L A M A T                            K O T A                         Catatan               Stamp / TT    ");
        //    data.PROW(true, 1, "NO.   N A M A   T O K O / A L A M A T                            K O T A                         Catatan               Stamp / TT    ");
        //    data.PROW(true, 1, data.PrintDoubleLine(134));
        //    #endregion

        //    #region Detail
        //    int nUrut = 0;
        //    string sNmBrg, sSatuan, sTemp, subNamaBarang;
        //    double nQty, nHrgSat, nHrgBruto;
        //    double nSumHrgBruto = 0, nSumDisc = 0, nSumPot = 0, nTotalHrg = 0;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        nUrut++;
        //        sNmBrg = dr["NamaBarang"].ToString();
        //        int panjanghuruf = sNmBrg.Length;
        //        if (panjanghuruf >= 52)
        //        {
        //            subNamaBarang = sNmBrg.Substring(0, 52);
        //        }
        //        else
        //        {
        //            subNamaBarang = sNmBrg;
        //        }
        //        //string subNamaBarang = sNmBrg.Substring(Math.Max(0, sNmBrg.Length - 30));
        //        sSatuan = dr["Satuan"].ToString();
        //        nQty = int.Parse(dr["QtySuratJalan"].ToString());
        //        nHrgSat = double.Parse(dr["HrgJual"].ToString());
        //        nHrgBruto = nQty * nHrgSat;
        //        nSumDisc = double.Parse(dr["Disc"].ToString());
        //        nSumPot = double.Parse(dr["Pot"].ToString());
        //        nSumHrgBruto = nSumHrgBruto + nHrgBruto;
        //        nTotalHrg = nTotalHrg + (nHrgBruto - double.Parse(dr["Disc"].ToString()) - double.Parse(dr["Pot"].ToString()));

        //        sTemp = "  " + nUrut.ToString().PadLeft(2, '0') + ". ";
        //        sTemp = sTemp + subNamaBarang.PadRight(58, '.') + "  ";
        //        sTemp = sTemp + nQty.ToString("#,###").PadLeft(7) + "." + sSatuan + "    ";
        //        sTemp = sTemp + "Rp. " + nHrgSat.ToString("#,###").PadLeft(9);
        //        sTemp = sTemp + nSumDisc.ToString("#,###").PadLeft(8);
        //        sTemp = sTemp + "Rp. " + nSumPot.ToString("#,###").PadLeft(8);
        //        sTemp = sTemp + "Rp." + nHrgBruto.ToString("#,###").PadLeft(10);
        //        data.PROW(true, 1, sTemp);
        //        //data.PROW(true, 1, "");
        //    }
        //    data.FontCondensed(true);
        //    data.AddCR();
        //    if (nUrut % 20 > 0)
        //    {
        //        data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
        //        for (int n = nUrut + 1; n <= nUrut + (20 - (nUrut % 20)); n++)
        //        {
        //            data.PROW(true, 1, "  " + n.ToString().PadLeft(2, '0') + ".  ");
        //            //data.PROW(true, 1, "");
        //        }
        //    }
        //    //string sBayar = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan3"].Value.ToString();
        //    //string sLain = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan4"].Value.ToString();
        //    data.PROW(true, 1, data.PrintDoubleLine(134));
        //    data.AddCR();
        //    data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
        //    data.PROW(true, 1, "* HARGA SUDAH TERMASUK PPN 10 %" + data.SPACE(21)
        //        + "                                                  Jumlah         Rp. "
        //        + nSumHrgBruto.ToString("#,###").PadLeft(13));            
        //    data.PROW(true, 1, "* Barang yang sudah dibeli tidak boleh ditukar/dikembalikan.");
        //    data.Eject();
        //    #endregion // end region detail

        //    data.SendToPrinter("notaJualTax.txt");
        //}
    }
}
