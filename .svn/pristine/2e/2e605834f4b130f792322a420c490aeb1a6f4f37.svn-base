using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;

namespace ISA.Finance.Kasir
{
    public partial class frmVoucherTitipanGiro : ISA.Finance.BaseForm
    {
        int prevGrid1Row = -1;
        int _prefGrid = 0;
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowIDBBM;
        DataTable dtg;
        Guid _GiroID;

        public frmVoucherTitipanGiro(Form caller, Guid rowIDBBM)
        {
            InitializeComponent();
            _rowIDBBM = rowIDBBM;
            this.Caller = caller;
        }

        public frmVoucherTitipanGiro()
        {
            InitializeComponent();
        }

    

        private void frmVoucherTitipanGiro_Load(object sender, EventArgs e)
        {
            try
            {
                
                DataTable dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_VoucherTitipanGiro_GiroCairTolakBatal"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowIDBBM", SqlDbType.UniqueIdentifier, _rowIDBBM));
                    dt = db.Commands[0].ExecuteDataTable();
                    gridVoucher.DataSource = dt;
                }
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

        private void gridVoucher_DoubleClick(object sender, EventArgs e)
        {
            //if (gridVoucher.SelectedCells[0].OwningRow.Cells["InfoToko"].Value.ToString() == "")
            //{
            //    MessageBox.Show("Belum iden ke Toko");
            //    return;
            //}

            if (gridVoucher.SelectedCells.Count > 0)
            {
                DataTable dtcg = new DataTable(GlobalVar.DBName);
                _GiroID = new Guid(gridVoucher.SelectedCells[0].OwningRow.Cells["GiroID"].Value.ToString());

                /*tambahan cek pin giro*/
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_PinGiro_CEK"));
                        db.Commands[0].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, _GiroID));
                        dtcg = db.Commands[0].ExecuteDataTable();
                    }
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

                if (dtcg.Rows.Count > 0)
                {
                    MessageBox.Show("Untuk Pencairan Giro harus minta Pin ke HO.");

                    string _pinKey = GetKey(_GiroID.ToString(), GlobalVar.Gudang, 31);
                    PengajuanPinGiro(dtcg, _pinKey);

                    pin.frmPinMd5 ifrmpin = new pin.frmPinMd5(this, _GiroID, GlobalVar.Gudang, 31, "Untuk Pencairan Giro harus minta Pin ke HO.");
                    ifrmpin.ShowDialog();
                    if (ifrmpin.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_PinGiro_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, _GiroID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            this.Close();
                        }
                        catch (System.Exception ex)
                        {
                            Error.LogError(ex);
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                            this.Close();
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.No;
                        this.Close();
                        return;
                    }
                }

                /*end tambahan*/


                //if (gridVoucher.SelectedCells[0].OwningRow.Cells["InfoToko"].Value.ToString() == "")
                //{
                //    MessageBox.Show("Belum iden ke Toko");
                //    return;
                //}

                string _BankID = "", _BankIDBBM = "";
                _BankID = gridVoucher.SelectedCells[0].OwningRow.Cells["BankID"].Value.ToString();
                _BankIDBBM = gridVoucher.SelectedCells[0].OwningRow.Cells["BankIDBBM"].Value.ToString();

                //if (_BankID != _BankIDBBM)
                //{
                //    MessageBox.Show("BankID Giro Tidak Sama Dengan BankID BBM");
                //    gridVoucher.Focus();
                //    return;
                //}
                
                DateTime _tglJT = (DateTime)gridVoucher.SelectedCells[0].OwningRow.Cells["TglJTempo"].Value;
                this.Close();
                Kasir.frmTransaksiPencairanGiro ifrmChild = new Kasir.frmTransaksiPencairanGiro(this.Caller, _GiroID, _rowIDBBM, _tglJT);
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.ShowDialog();
            }            
        }

        private void gridVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridVoucher_DoubleClick(sender, e);
            }

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (gridVoucher.SelectedCells[0].ColumnIndex == 2)
                {
                    string search = tbSearch.Text;
                    if (search.Length > 0)
                    {
                        search = search.Substring(0, search.Length - 1);
                        tbSearch.Text = search;
                    }
                }
            }
        }

        private void gridVoucher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridVoucher.SelectedCells[0].ColumnIndex == 2)
            {
                if (char.IsNumber(e.KeyChar))
                {
                    string search = tbSearch.Text;
                    search += e.KeyChar;
                    tbSearch.Text = search;



                }
            }
        }

        private void gridVoucher_SelectionChanged(object sender, EventArgs e)
        {
            if (gridVoucher.SelectedCells.Count > 0)
            {
                if (gridVoucher.SelectedCells[0].ColumnIndex != 2)
                {
                    tbSearch.Clear();
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 0)
            {
                string search = tbSearch.Text;
                for (int i = 0; i < (gridVoucher.Rows.Count); i++)
                {
                    if (gridVoucher.Rows[i].Cells["Nomor"].Value.ToString().StartsWith(search))
                    {
                        gridVoucher.Rows[i].Cells["Nomor"].Selected = true;
                        return; // stop looping
                    }
                }
            }
        }

        private string GetKey(string rowID, string kodeGudang, int noAjuan)
        {
            string x = kodeGudang.ToString().Trim().Substring(2, 2) + noAjuan.ToString().Trim().PadLeft(2, '0') +
                       rowID.Replace("-", string.Empty).ToUpper();
            return x;
        }

        private void PengajuanPinGiro(DataTable dtcg, string pinKey)
        {
            DisplayReportToExcell(dtcg, pinKey);
        }

        private void DisplayReportToExcell(DataTable dtg, string pinkey)
        {
            List<ExcelPackage> exs = new List<ExcelPackage>();
            exs.Add(AjuanPinGiro(dtg, pinkey));

            SaveFileDialog sf = new SaveFileDialog();
            sf.InitialDirectory = "C:\\Temp\\";
            sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
            sf.FileName = "PengajuanPinGiro";

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

        private ExcelPackage AjuanPinGiro(DataTable dtg, string pinkey)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Pengajuan Pin Giro.";
            ex.Workbook.Properties.SetCustomPropertyValue("PIN PJT", "1147");

            ex.Workbook.Worksheets.Add("PIN GIRO");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 15;      //nogiro
            ws.Cells[1, 4].Worksheet.Column(4).Width = 13;      //tglgiro
            ws.Cells[1, 5].Worksheet.Column(5).Width = 13;      //tgljttempo
            ws.Cells[1, 6].Worksheet.Column(6).Width = 20;      //bankasal
            ws.Cells[1, 7].Worksheet.Column(7).Width = 20;      //lokasi
            ws.Cells[1, 8].Worksheet.Column(8).Width = 10;      //noacc
            ws.Cells[1, 9].Worksheet.Column(9).Width = 13;      //nominal
            ws.Cells[1, 10].Worksheet.Column(10).Width = 20;    //banktujuan
            ws.Cells[1, 11].Worksheet.Column(11).Width = 40;    //publickey
            ws.Cells[1, 12].Worksheet.Column(12).Width = 40;    //pin
            ws.Cells[1, 13].Worksheet.Column(13).Width = 40;    //infotoko

            int nRow = 0, nHeader = 0, Rowx = 0;
            nHeader++;
            nRow = nHeader + 3;
            Rowx = nRow;

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Pengajuan Pin Giro";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", GlobalVar.DateTimeOfServer);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            int MaxCol = 13;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " No Giro ";
            ws.Cells[Rowx, 4].Value = " Tgl Giro ";
            ws.Cells[Rowx, 5].Value = " Tgl Jt.Tempo ";
            ws.Cells[Rowx, 6].Value = " Nama Bank Asal ";
            ws.Cells[Rowx, 7].Value = " Lokasi ";
            ws.Cells[Rowx, 8].Value = " NoAcc ";
            ws.Cells[Rowx, 9].Value = " Nominal ";
            ws.Cells[Rowx, 10].Value = " Bank Tujuan ";
            ws.Cells[Rowx, 11].Value = " Public Key ";
            ws.Cells[Rowx, 12].Value = " Pin ";
            ws.Cells[Rowx, 13].Value = " Info Toko ";

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx++;

            int no = 0;
            double nSaldo = 0, nQty = 0;

            if (dtg.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dtg.Rows)
                {
                    no++;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = dr1["Nomor"].ToString();
                    ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", dr1["TglGiro"]);
                    ws.Cells[Rowx, 5].Value = string.Format("{0:dd-MMM-yyyy}", dr1["TglJtTempo"]);
                    ws.Cells[Rowx, 6].Value = dr1["NamaBank"].ToString();
                    ws.Cells[Rowx, 7].Value = dr1["Lokasi"].ToString();
                    ws.Cells[Rowx, 8].Value = dr1["NoAcc"].ToString();
                    ws.Cells[Rowx, 9].Value = double.Parse(Tools.isNull(dr1["Nominal"],"0").ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Value = dr1["BankTujuan"].ToString();
                    ws.Cells[Rowx, 11].Value = pinkey;
                    ws.Cells[Rowx, 12].Value = "";
                    ws.Cells[Rowx, 13].Value = dr1["InfoToko"].ToString();
                    Rowx++;
                }

                Rowx++;
                ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

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
    
    }
}
