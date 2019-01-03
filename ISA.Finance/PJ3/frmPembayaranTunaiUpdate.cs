using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance.Class;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;


namespace ISA.Finance.PJ3
{
    public partial class frmPembayaranTunaiUpdate : ISA.Controls.BaseForm
    {
        Guid _rowID;
        DataTable dt;
        DataTable dtNota;
        DataTable dtNotaJualdetail;
        DataTable dtNotaJual;
        double nRpNota = 0;
        double nRpBayar = 0;
        DateTime _tglTrm;
        DateTime _tglJT;
        string _trType;
        string _cat3;

        public frmPembayaranTunaiUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = caller;
        }

        public frmPembayaranTunaiUpdate(Form caller, Guid rowID, DataTable dtNotaJlDetail, DataTable dtNotaJl,
               DateTime tglJT, DateTime tglTRM, string trType, string cat3)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = caller;
            dtNotaJualdetail = dtNotaJlDetail;
            dtNotaJual = dtNotaJl;
            _tglTrm = tglTRM;
            _tglJT = tglJT;
            _trType = trType;
            _cat3 = cat3;
        }
        private void frmPembayaranTunaiUpdate_Load(object sender, EventArgs e)
        {
            if (this.Caller is Finance.PJ3.frmPJ3Browse)
            {
                this.cmdCLOSE.Enabled = false;
                this.cmdCLOSE.Visible = false;
            }
            this.Text = "PJT";
            GetDataNota();

            txtNoNota.Text = dt.Rows[0]["NoNota"].ToString();
            txtTglNota.DateValue = (DateTime)dt.Rows[0]["TglNota"];
            txtNamaToko.Text = dt.Rows[0]["NamaToko"].ToString();
            txtKodeSales.Text = dt.Rows[0]["KodeSales"].ToString();
            txtNoPerkiraan.Text = GetNoPerkiraan();
            txtUraian.Text =
                txtNoPerkiraan.Text.Trim() + ", NOTA : " + txtNoNota.Text
                + " " + ((DateTime)txtTglNota.DateValue).ToString("dd-MM-yyyy");
            //txtBayar.Text = dt.Rows[0]["RpNet3"].ToString();
            txtBayar.Text = "0";
            txtPLL.Text = "0";
            txtPot.Text = "0";

            if (dt.Rows[0]["RpNet3"].ToString().Trim() != "")
            {
                nRpNota = Convert.ToDouble(dt.Rows[0]["RpNet3"].ToString());
            }

        }

        private void GetDataNota()
        {
            try
            {
                this.Cursor = Cursors.Default;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_RowID"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
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

        private string GetNoPerkiraan()
        {
            string noPerkiraan = "";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string kodeTrn = "COL" + dt.Rows[0]["WilID"].ToString().Substring(0, 1);
                //bikin sp di trading untuk cari no perkiraan
                //noPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail(kodeTrn).Rows[0]["NoPerkiraan"].ToString();

                this.Cursor = Cursors.WaitCursor;
                DataTable dtGL = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeTrn", SqlDbType.VarChar, kodeTrn));
                    dtGL = db.Commands[0].ExecuteDataTable();
                }
                if (dtGL.Rows.Count > 0)
                {
                    noPerkiraan = dtGL.Rows[0]["NoPerkiraan"].ToString();
                }
                else
                {
                    MessageBox.Show("Kode PJT untuk cabang " + GlobalVar.CabangID + " belum ada di tabel, hubungi manager Anda", "Perhatian");
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return noPerkiraan;
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            double nRpBayar = 0;
            //if (txtBayar.Text.ToString().Trim() != "" && txtBayar.Text.ToString().Trim() != "0")
            //{
                nRpBayar = Convert.ToDouble(txtBayar.Text.ToString());
            //}

            /*tutup sementara*/
            //if (nRpNota != nRpBayar)
            //{
            //    string _pinKey = GetKey(_rowID.ToString(), GlobalVar.Gudang, 26);

            //    MessageBox.Show("Nominal Nota beda dengan nominal Pembayaran kasir." + "\n" +
            //                    "Silahkan Pengajuan PIN ke HO.");
            //    PengajuanPinPenjualanTunai(_rowID, nRpBayar, _pinKey);

            //    pin.frmPinMd5 ifrmpin = new pin.frmPinMd5(this, _rowID, GlobalVar.Gudang, 26, "Rp Nota beda dengan Rp Bayar");
            //    ifrmpin.ShowDialog();
            //    if (ifrmpin.DialogResult != DialogResult.OK)
            //    {
            //        this.DialogResult = DialogResult.No;
            //        this.Close();
            //        return;
            //    }
            //}

            string rpNet3 = dt.Rows[0]["RpNet3"].ToString();
            double n = double.Parse(rpNet3) - double.Parse(txtBayar.Text);
            txtPLL.Text = (0).ToString();
            txtPot.Text = (0).ToString();
            if (n > 0 && n <= 1000)
            {
                txtPot.Text = n.ToString();
            }
            if (n < 0 && n >= -1000)
            {
                txtPLL.Text = Math.Abs(n).ToString();
            }

            if (nRpBayar >= 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_PJT_LinkToKasir_ISA"));
                        db.Commands[0].Parameters.Add(new Parameter("@nilaiBayar", SqlDbType.Money, double.Parse(txtBayar.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@notaID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@noPerkiraan", SqlDbType.VarChar, txtNoPerkiraan.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@uraian", SqlDbType.VarChar, txtUraian.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@nilaiPOT", SqlDbType.Money, double.Parse(txtPot.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@nilaiPLL", SqlDbType.Money, double.Parse(txtPLL.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    MessageBox.Show("Data telah disimpan");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
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
        }

        private string GetKey(string rowID, string kodeGudang, int noAjuan)
        {
            string x = kodeGudang.ToString().Trim().Substring(2, 2) + noAjuan.ToString().Trim().PadLeft(2, '0') +
                       rowID.Replace("-", string.Empty).ToUpper();
            return x;
        }

        private void PengajuanPinPenjualanTunai(Guid rowid, double nByr, string pinKey)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pengajuan_PenjualanTunai"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowid));
                    db.Commands[0].Parameters.Add(new Parameter("@Bayar", SqlDbType.Money, nByr));
                    dtNota = db.Commands[0].ExecuteDataTable();
                    if (dtNota.Rows.Count > 0)
                    {
                        DisplayReportToExcell(dtNota, pinKey);
                    }
                }
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

        private void DisplayReportToExcell(DataTable dtNota, string pinkey)
        {
            List<ExcelPackage> exs = new List<ExcelPackage>();
            exs.Add(PengajuanPinPJT(dtNota, pinkey));

            SaveFileDialog sf = new SaveFileDialog();
            sf.InitialDirectory = "C:\\Temp\\";
            sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
            sf.FileName = "PengajuanPinPJT";

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

        private ExcelPackage PengajuanPinPJT(DataTable dtNota, string pinkey)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Penajuan Pin Penjualan Tunai";
            ex.Workbook.Properties.SetCustomPropertyValue("PIN PJT", "1147");

            ex.Workbook.Worksheets.Add("PIN PJT");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 10;      //nosuratjalan
            ws.Cells[1, 4].Worksheet.Column(4).Width = 13;      //tglsuratjalan
            ws.Cells[1, 5].Worksheet.Column(5).Width = 13;      //kodesales
            ws.Cells[1, 6].Worksheet.Column(6).Width = 30;      //namatoko
            ws.Cells[1, 7].Worksheet.Column(7).Width = 20;      //daerah
            ws.Cells[1, 8].Worksheet.Column(8).Width = 10;      //idwil
            ws.Cells[1, 9].Worksheet.Column(9).Width = 13;      //rpnota
            ws.Cells[1, 10].Worksheet.Column(10).Width = 13;    //rpbayar
            ws.Cells[1, 11].Worksheet.Column(11).Width = 40;    //publickey
            ws.Cells[1, 12].Worksheet.Column(12).Width = 40;    //pin
            ws.Cells[1, 13].Worksheet.Column(13).Width = 40;    //keterangan

            int nRow = 0, nHeader = 0, Rowx = 0;
            nHeader++;
            nHeader++;
            nRow = nHeader + 3;
            Rowx = nRow;

            ws.Cells[nHeader, 1].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 1].Value = "Pengajuan Pin Link Penjualan Tunai";
            ws.Cells[nHeader, 1].Style.Font.Size = 14;
            ws.Cells[nHeader, 1].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", GlobalVar.DateTimeOfServer);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            //ws.Cells[nHeader + 2, 2].Value = "Kelompok Barang FX dan FC";

            int MaxCol = 13;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " No Nota ";
            ws.Cells[Rowx, 4].Value = " Tgl Nota ";
            ws.Cells[Rowx, 5].Value = " Kode Sales ";
            ws.Cells[Rowx, 6].Value = " Nama Toko ";
            ws.Cells[Rowx, 7].Value = " Daerah ";
            ws.Cells[Rowx, 8].Value = " Idwil ";
            ws.Cells[Rowx, 9].Value = " Rp Nota ";
            ws.Cells[Rowx, 10].Value = " Rp Bayar ";
            ws.Cells[Rowx, 11].Value = " Public Key ";
            ws.Cells[Rowx, 12].Value = " Pin ";
            ws.Cells[Rowx, 13].Value = " Keterangan ";

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx++;

            int no = 0;
            double nSaldo = 0, nQty = 0;

            if (dtNota.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dtNota.Rows)
                {
                    no++;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = dr1["NoSuratJalan"].ToString();
                    ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", dr1["TglSuratJalan"]);
                    ws.Cells[Rowx, 5].Value = dr1["KodeSales"].ToString();
                    ws.Cells[Rowx, 6].Value = dr1["NamaToko"].ToString();
                    ws.Cells[Rowx, 7].Value = dr1["Daerah"].ToString();
                    ws.Cells[Rowx, 8].Value = dr1["WilID"].ToString();
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(dr1["RpNetto"].ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Value = Convert.ToDouble(dr1["Bayar"].ToString());
                    ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 11].Value = pinkey;
                    ws.Cells[Rowx, 12].Value = "";
                    ws.Cells[Rowx, 13].Value = "";
                    Rowx++;
                }

                Rowx++;
                //ws.Cells[Rowx, 9].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                //ws.Cells[Rowx, 10].Value = Tools.isNull(nQty, 0);
                //ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                //ws.Cells[Rowx, 10].Style.Font.Bold = true;

                //ws.Cells[Rowx, 12].Value = Tools.isNull(nSaldo, 0);
                //ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                //ws.Cells[Rowx, 12].Style.Font.Bold = true;

                var border = ws.Cells[nRow, 2, nRow, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
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

                border = ws.Cells[Rowx, 10, Rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                nHeader = Rowx;
                Rowx += 1;

                ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx, 2].Style.Font.Size = 8;
                ws.Cells[Rowx, 2].Style.Font.Italic = true;
            }
            return ex;
        }

        //untuk disable close di kanan atas
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void txtBayar_Validating(object sender, CancelEventArgs e)
        {
            if (txtBayar.Text.ToString().Trim() != "")
            {
                nRpBayar = Convert.ToDouble(txtBayar.Text.ToString());
            }
            if (nRpBayar != nRpNota)
            {
                MessageBox.Show("Beda ndul");
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

    }
}
