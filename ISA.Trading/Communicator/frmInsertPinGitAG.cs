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
using System.IO;
using ISA.Trading.Class;
using System.Management;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;

namespace ISA.Trading.Communicator
{
    public partial class frmInsertPinGitAG : ISA.Controls.BaseForm
    {
        string _publicKey = "";
        DataTable dtGitAG;

        public frmInsertPinGitAG()
        {
            InitializeComponent();
        }

        public frmInsertPinGitAG(Form _caller, DataTable dtAG)
        {
            InitializeComponent();
            this.Caller = _caller;
            dtGitAG = dtAG;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void frmInsertPinGitAG_Load(object sender, EventArgs e)
        {
            createPublicKey();
            rptGitAG(dtGitAG,txtPublicKey.Text);
        }

        private void createPublicKey()
        {
            _publicKey = ISA.Pin.Generator.CreateKey(GlobalVar.Gudang, 30, DateTime.Now);
            txtPublicKey.Text = _publicKey;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            string _pin = txtPIN.Text;
            if (ISA.Pin.Generator.VerifyPin(_publicKey, _pin))
            {
                LastPinTglUpdate();
                MessageBox.Show("PIN Benar");
            }
            else
            {
                MessageBox.Show("PIN Salah");
                return;
            }
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void LastPinTglUpdate()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_LastPinGitAG_UPDATE"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "LastPinGitAG"));
                db.Commands[0].ExecuteNonQuery();
            }

        }

        private void rptGitAG(DataTable dtAG,string pkey)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(Lap_GitAG(dtAG, pkey));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan_GitAG";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    Byte[] bin1 = exs[0].GetAsByteArray();
                    File.WriteAllBytes(file, bin1);
                    MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
                    Process.Start(sf.FileName.ToString());
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private ExcelPackage Lap_GitAG(DataTable dtAG, string pkey)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Laporan AG Belum Terima";
            ex.Workbook.Properties.SetCustomPropertyValue("Laporan AG Belum Terima", "1147");

            ex.Workbook.Worksheets.Add("AG Belum Terima");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Name = "Calibri";
            ws.Cells.Style.Font.Size = 9;

            #region Laporan AG Belum Terima

            int nRow = 0, nHeader = 1, Rowx = 0;

            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 7;       //dr gudang
            ws.Cells[1, 4].Worksheet.Column(4).Width = 7;       //ke gudang
            ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      //no ag
            ws.Cells[1, 6].Worksheet.Column(6).Width = 13;      //tgl kirim
            ws.Cells[1, 7].Worksheet.Column(7).Width = 13;      //tgl terima
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;      //kode barang
            ws.Cells[1, 9].Worksheet.Column(9).Width = 75;      //namastok
            ws.Cells[1, 10].Worksheet.Column(10).Width = 5;     //sat
            ws.Cells[1, 11].Worksheet.Column(11).Width = 10;    //qty

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Laporan AG Belum Terima";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Per Tanggal : " + string.Format("{0:dd-MMM-yyyy}", DateTime.Now);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 3, 2].Value = "Public Key       : ";
            ws.Cells[nHeader + 3, 4].Value = pkey;
            ws.Cells[nHeader + 4, 2].Value = "PIN                  : ";
            ws.Cells[nHeader + 3, 2, nHeader + 4, 4].Style.Font.Bold = true;

            nRow = nHeader + 6;

            Rowx = nRow;
            int MaxCol = 11;

            nRow = Rowx;

            for (int i = 2; i <= MaxCol; i++)
            {
                ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            }

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Dr Gud ";
            ws.Cells[Rowx, 4].Value = " Ke Gud ";
            ws.Cells[Rowx, 5].Value = " No AG ";
            ws.Cells[Rowx, 6].Value = " Tgl Kirim ";
            ws.Cells[Rowx, 7].Value = " Tgl Terima ";
            ws.Cells[Rowx, 8].Value = " Kode Barang ";
            ws.Cells[Rowx, 9].Value = " Nama Stok ";
            ws.Cells[Rowx, 10].Value = " Sat ";
            ws.Cells[Rowx, 11].Value = " Qty Kirim ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;
            int no = 0;
            double nJumlah = 0;

            if (dtAG.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dtAG.Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["DrGudang"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["KeGudang"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["NoAG"], "").ToString();
                    ws.Cells[Rowx, 6].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglKirim"], ""));
                    ws.Cells[Rowx, 7].Value = string.Format("{0:dd-MMM-yyyy}", Tools.isNull(dr1["TglTerima"], ""));
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["KodeBarang"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["NamaStok"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Tools.isNull(dr1["SatJual"], "").ToString();
                    ws.Cells[Rowx, 11].Value = Convert.ToDouble(Tools.isNull(dr1["QtyKirim"], "0").ToString());
                    ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";

                    nJumlah += Convert.ToDouble(Tools.isNull(dr1["QtyKirim"], "0").ToString());
                    Rowx++;
                }
            }

            Rowx++;
            ws.Cells[Rowx, 9].Value = "Jumlah".ToString();
            ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 9].Style.Font.Bold = true;

            ws.Cells[Rowx, 11].Value = Tools.isNull(nJumlah, 0);
            ws.Cells[Rowx, 11].Style.Numberformat.Format = "#,##;(#,##);";
            ws.Cells[Rowx, 11].Style.Font.Bold = true;

            var border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style = ExcelBorderStyle.Thin;
            border.Right.Style = ExcelBorderStyle.None;

            border = ws.Cells[Rowx, 11, Rowx, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            nHeader = Rowx;
            Rowx += 1;

            ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx, 2].Style.Font.Size = 8;
            ws.Cells[Rowx, 2].Style.Font.Italic = true;

            #endregion

            return ex;
        }
    }
}
