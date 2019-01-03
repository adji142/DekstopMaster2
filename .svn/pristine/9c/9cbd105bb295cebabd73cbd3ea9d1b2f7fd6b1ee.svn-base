using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using Microsoft.Reporting.WinForms;
using System.IO;
using ISA.Finance.Class;

namespace ISA.Finance.DKNForm
{
    public partial class frmDebetKreditNotaCetak : ISA.Finance.BaseForm
    {
        string _NoDKN;

        public frmDebetKreditNotaCetak(Form Caller, string rowID)
        {
            InitializeComponent();
            _NoDKN = rowID;
        } 

        public frmDebetKreditNotaCetak()
        {
            InitializeComponent();
        }


        private void Cetak(DataTable dt)
        {
            BuildString detail = new BuildString();

            string NoDKN = Tools.isNull(dt.Rows[0]["NoDKN"], "").ToString();
            string Tanggal = Tools.isNull(dt.Rows[0]["Tanggal"], "").ToString();            
            string Cabang = Tools.isNull(dt.Rows[0]["Cabang"], "").ToString();
            string DK = Tools.isNull(dt.Rows[0]["DK"], "").ToString();

            string headerTitle = string.Empty;
            string deskripsi = string.Empty;
            int posHeader = 0;

            if (DK == "K")
            {
                headerTitle = "KREDIT NOTA";
                deskripsi = "Dengan ini kami menkredit Rekening Saudara untuk transaksi sebagai berikut";
                posHeader = 12;
            }
            else if (DK == "D")
            {
                headerTitle = "DEBET NOTA";
                deskripsi = "Dengan ini kami mendebet Rekening Saudara untuk transaksi sebagai berikut";
                posHeader = 13;
            }

            string Perkiraan = string.Empty;
            string Uraian = string.Empty;
            double Jumlah = 0;
            double sumJumlah = 0;
            string tempJumlah = string.Empty;
            string typePrinter = detail.GetPrinterName();

            detail.Initialize();
            detail.FontCondensed(false);
            detail.FontCPI(7);
            detail.PageLLine(33);
            detail.LeftMargin(5);
            detail.BottomMargin(1);
            detail.FontCondensed(true);            


            #region Header
            if (typePrinter.Contains("LX"))
            {
                detail.LetterQuality(false);
                detail.FontBold(true);
                detail.FontCondensed(true);
                detail.DoubleHeight(true);
            }
            else
            {
                detail.LetterQuality(true);
                detail.FontBold(true);
                detail.DoubleHeight(true);
                detail.DoubleWidth(true);
            }

            detail.FontBold(false);
            detail.DoubleHeight(false);
            detail.DoubleWidth(false);
            detail.FontCondensed(false);
            detail.LineSpacing("1/8");
            
            detail.AddCR();
            detail.FontCPI(12);
            detail.PROW(true, 1, detail.PrintTopLeftCorner() + detail.PrintHorizontalLine(92) + detail.PrintTopRightCorner());
            detail.PROW(false, 30, detail.PrintTTOp());
            
            detail.PROW(true, 1,  detail.PrintVerticalLine());
            //detail.FontBold(true);
            
                       
            //detail.FontBold(false);
            detail.PROW(false, 30, detail.PrintVerticalLine() + " Tanggal   : " + ((DateTime)dt.Rows[0]["Tanggal"]).ToString("dd/MM/yyyy").PadRight(51) + detail.PrintVerticalLine());

            
            detail.PROW(true, 1, detail.PrintVerticalLine());
            detail.FontCPI(14);
            detail.FontBold(true);
            detail.PROW(false, posHeader, headerTitle);
            detail.FontCPI(12);
            detail.FontBold(false);
            detail.PROW(false, 36, detail.PrintTLeft() + detail.PrintHorizontalLine(64) + detail.PrintTRight());
            

            detail.PROW(true, 1, detail.PrintVerticalLine());            
            detail.PROW(false, 30, detail.PrintVerticalLine() + detail.SPACE(1) + "Kepada    : Kepala Administrasi " + Cabang.PadRight(31) + detail.PrintVerticalLine());

            detail.PROW(true, 1, detail.PrintVerticalLine());
            detail.PROW(false, 8, "[No: " + NoDKN + "]");
            detail.PROW(false, 30, detail.PrintTLeft() + detail.PrintHorizontalLine(64) + detail.PrintTRight());

            detail.PROW(true, 1, detail.PrintVerticalLine());
            detail.PROW(false, 30, detail.PrintVerticalLine() + detail.SPACE(1) + "Lampiran  :" + detail.SPACE(10) + "lbr: ".PadRight(42) + detail.PrintVerticalLine());

            detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(92) + detail.PrintTRight());
            detail.PROW(false, 30, detail.PrintTBottom());

            detail.PROW(true, 1, detail.PrintVerticalLine() + deskripsi.PadRight(93)  + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(91) + detail.PrintTRight());
            detail.PROW(false, 15, detail.PrintTTOp());
            detail.PROW(false, 84, detail.PrintTTOp());

            detail.PROW(true, 1, detail.PrintVerticalLine() + "  Perkiraan  " + detail.PrintVerticalLine()  + detail.SPACE(31) + "Uraian"  + detail.SPACE(31) + detail.PrintVerticalLine()  + "  Jumlah  "  + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(91) + detail.PrintTRight());
            detail.PROW(false, 15, detail.PrintTLeft());
            detail.PROW(false, 84, detail.PrintTRight());

            #endregion




            #region CetakDetail

            foreach (DataRow dr in dt.Rows)
            {
                Perkiraan = dr["NoPerkiraan"].ToString();
                Uraian = dr["Uraian"].ToString();
                Jumlah = double.Parse(dr["Jumlah"].ToString());
                sumJumlah = sumJumlah + Jumlah;
                tempJumlah = Jumlah.ToString("#,##0");
                detail.PROW(true, 1, detail.PrintVerticalLine() + Perkiraan + detail.SPACE(1) + detail.PrintVerticalLine() + Uraian.PadRight(68) + detail.PrintVerticalLine()    + tempJumlah.PadLeft(10)+ detail.PrintVerticalLine());
                detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(91) + detail.PrintTRight());
                detail.PROW(false, 15, detail.PrintTBottom());
                detail.PROW(false, 84, detail.PrintTBottom());
                //header.PROW(true, 1, header.PrintVerticalLine() + header.SPACE(2) + "Perkiraan" + header.SPACE(2) + header.PrintVerticalLine() + header.SPACE(22) + "Uraian" + header.SPACE(22) + header.PrintVerticalLine() + header.SPACE(2) + "Jumlah" + header.SPACE(2) + header.PrintVerticalLine());
            }
                       
            detail.PROW(true, 1, detail.PrintVerticalLine() + detail.SPACE(14) + "Total" + detail.SPACE(64) + sumJumlah.ToString("#,##0").PadLeft(10) + detail.PrintVerticalLine());   
            detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(93) + detail.PrintTRight());
            

            detail.PROW(true, 1, detail.PrintVerticalLine() + "Terbilang" + detail.SPACE(5) + ISA.Common.Tools.Terbilang(sumJumlah).PadRight(79)  + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintVerticalLine() + detail.SPACE(93) + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(91) + detail.PrintTRight());
            detail.PROW(false, 32, detail.PrintTTOp());
            detail.PROW(false, 61, detail.PrintTTOp());

            #endregion


            #region Footer
             
            detail.PROW(true, 1, detail.PrintVerticalLine() + "          Dibuat Oleh         " + detail.PrintVerticalLine() + "         Mengetahui         " + detail.PrintVerticalLine() + "         Dibukukan Oleh          " + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(91) + detail.PrintTRight());
            detail.PROW(false, 32, detail.PrintTTOp());
            detail.PROW(false, 61, detail.PrintTTOp());

            detail.PROW(true, 1, detail.PrintVerticalLine() + "                              " + detail.PrintVerticalLine() + "                            " + detail.PrintVerticalLine() + "                                 " + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintVerticalLine() + "                              " + detail.PrintVerticalLine() + "                            " + detail.PrintVerticalLine() + "                                 " + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintVerticalLine() + "                              " + detail.PrintVerticalLine() + "                            " + detail.PrintVerticalLine() + "                                 " + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintVerticalLine() + "                              " + detail.PrintVerticalLine() + "                            " + detail.PrintVerticalLine() + "                                 " + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintVerticalLine() + "                              " + detail.PrintVerticalLine() + "                            " + detail.PrintVerticalLine() + "                                 " + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintVerticalLine() + "            MNG               " + detail.PrintVerticalLine() + "                            " + detail.PrintVerticalLine() + "                                 " + detail.PrintVerticalLine());           
            detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(91) + detail.PrintRightBottomCorner2());
            detail.PROW(false, 32, detail.PrintTBottom());
            detail.PROW(false, 61, detail.PrintTBottom());


            #endregion



            detail.Eject();
            detail.SendToPrinter("DebetKreditNota.txt",detail.GenerateString());
        }


       

        private void cmdOK_Click(object sender, EventArgs e)
        {

            if (rdoStandart.Checked)
            {
                Standart();
            }
            else if (rdoTolak.Checked)
            {
                Tolak();
            }
            
            
        }


        private void Standart()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("rsp_CetakDKN_Standart"));
                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _NoDKN));
                //db.Commands[0].Parameters.Add(new Parameter("@oli", SqlDbType.Int, _nOli));
                dt = db.Commands[0].ExecuteDataTable();

                if (dt.Rows.Count > 0)
                {
                    Cetak(dt);
                }
                else
                {
                    MessageBox.Show("Tidak Ada Data");
                }
                
            }
        }

        private void Tolak()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("rsp_CetakDKN_Tolak"));
                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _NoDKN));
                //db.Commands[0].Parameters.Add(new Parameter("@oli", SqlDbType.Int, _nOli));
                dt = db.Commands[0].ExecuteDataTable();

                if (dt.Rows.Count > 0)
                {
                    Cetak(dt);
                }
                else
                {
                    MessageBox.Show("Tidak Ada Data");
                }

                
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
