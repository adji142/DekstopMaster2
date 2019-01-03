using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using System.Globalization;
using Microsoft.Reporting.WinForms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;

namespace ISA.Toko.Penjualan
{
    public partial class frmAccDOBrowser : ISA.Controls.BaseForm
    {
        Double MaxAcc = 0;
        Double JmlDo = 0;
        DataSet dsData = new DataSet();
        
        public frmAccDOBrowser()
        {
            InitializeComponent();
        }

        private void frmAccDOBrowser_Load(object sender, EventArgs e)
        {
            rdbTglDO.FromDate = GlobalVar.DateOfServer;
            rdbTglDO.ToDate = GlobalVar.DateOfServer;
            bool isAccDo = LookupInfoValue.CekAccDo(SecurityManager.UserID);
            cmdYes.Visible = isAccDo;

            if (GlobalVar.Gudang == "2807")
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
            }
            else
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
            }

            cmdSearch_Click(sender, e);
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        
        private void rdbTglDO_KeyDown(object sender, KeyEventArgs e)
        {
            cmdSearch_Click(sender, new EventArgs());
        }


        private void RefreshData()
        {
            string _kdgud = GlobalVar.Gudang;
            string _ckovd = string.Empty;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pengajuan_OVD_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, (DateTime)rdbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, (DateTime)rdbTglDO.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                dataGridDO.DataSource = dt;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            if (GlobalVar.Gudang != "2807")
            {
                GetPlafonAccOvd();
                textBox1.Text = MaxAcc.ToString();
                textBox3.Text = (MaxAcc - JmlDo).ToString();
            }

            GetJumlahAcc();
            textBox2.Text = JmlDo.ToString();
        }


        private void GetPlafonAccOvd()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Lookup_MaxAcc_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    MaxAcc = Convert.ToDouble(Tools.isNull(dt.Rows[0]["RowOrder"], 0));
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

        private void GetJumlahAcc()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DateTime datenow = GlobalVar.DateTimeOfServer;
                DateTime fromdate_ = new DateTime(datenow.Year, datenow.Month, 1);
                DateTime todate_ = fromdate_.AddMonths(1).AddDays(-1);

                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HistAcc_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromdate_));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, todate_));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    JmlDo = Convert.ToDouble(Tools.isNull(dt.Rows[0]["JmlDo"], 0));
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



        private void UpdateAcc(Guid rowId, int bagian)
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowId));
                db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, bagian));
                db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "ACC"));
                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                dt = db.Commands[0].ExecuteDataTable();
                db.Commands[0].ExecuteNonQuery();
            }
        }


        private void UpdateHistAcc(Guid rowId, int bagian, String NoAccPst, String NoAccPtg, String noDO, DateTime TglDo
            , String KdSales, String KdToko, Double Plf, Double Ptg, Double Git, Double Gro, Double Grt, Double JDo
            , Double Ovd, Double Hro, Double Ovs)
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateHistACCPiutang"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowId));
                db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, bagian));
                db.Commands[0].Parameters.Add(new Parameter("@NoAccPst", SqlDbType.VarChar, NoAccPst));
                db.Commands[0].Parameters.Add(new Parameter("@NoAccPtg", SqlDbType.VarChar, NoAccPtg));
                db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "ACC"));
                db.Commands[0].Parameters.Add(new Parameter("@NoDo", SqlDbType.VarChar, noDO));
                db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, TglDo));
                db.Commands[0].Parameters.Add(new Parameter("@KdSales", SqlDbType.VarChar, KdSales));
                db.Commands[0].Parameters.Add(new Parameter("@KdToko", SqlDbType.VarChar, KdToko));
                db.Commands[0].Parameters.Add(new Parameter("@plafon", SqlDbType.Money, Plf));
                db.Commands[0].Parameters.Add(new Parameter("@piutang", SqlDbType.Money, Ptg));
                db.Commands[0].Parameters.Add(new Parameter("@git", SqlDbType.Money, Git));
                db.Commands[0].Parameters.Add(new Parameter("@giro", SqlDbType.Money, Gro));
                db.Commands[0].Parameters.Add(new Parameter("@girotolak", SqlDbType.Money, Grt));
                db.Commands[0].Parameters.Add(new Parameter("@sumrpnet", SqlDbType.Money, JDo));
                db.Commands[0].Parameters.Add(new Parameter("@ovdbe", SqlDbType.Money, Ovd));
                db.Commands[0].Parameters.Add(new Parameter("@hrbe", SqlDbType.Money, Hro));
                db.Commands[0].Parameters.Add(new Parameter("@ovdsbl", SqlDbType.Money, Ovs));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                dt = db.Commands[0].ExecuteDataTable();
                db.Commands[0].ExecuteNonQuery();
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (dataGridDO.SelectedCells.Count > 0)
            {
                if (GlobalVar.Gudang != "2807")
                {
                    GetPlafonAccOvd();
                    GetJumlahAcc();
                    Double newDo = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[ovdBE.Name].Value, 0).ToString());
                    //Double newDo = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[SumRpNet.Name].Value, 0).ToString());

                    if (JmlDo + newDo > MaxAcc)
                    {
                        MessageBox.Show("Plafon acc overdue sudah habis");
                        return;
                    }
                }

                Guid rowId = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells[RowID.Name].Value;
                bool isOverdueBe = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[IsOverdueBE.Name].Value, "").ToString() == "YA";
                bool isSalesBl = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[IsSalesBL.Name].Value,"").ToString() == "YA";
                string noDo = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[NoDo.Name].Value,"").ToString();
                
                DateTime TglDo = Convert.ToDateTime(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[TglDO.Name].Value,"").ToString());
                String KdSales = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[KodeSales.Name].Value,"").ToString();
                String KdToko  = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[KodeToko.Name].Value,"").ToString();
                Double Plf = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[plf_fb.Name].Value,0).ToString());
                Double Ptg = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[piutang.Name].Value,0).ToString());
                Double Git = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[GIT.Name].Value,0).ToString());
                Double Gro = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[Giro.Name].Value,0).ToString());
                Double Grt = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[GiroTolak.Name].Value,0).ToString());
                Double JDo = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[SumRpNet.Name].Value,0).ToString());
                Double Ovd = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[ovdBE.Name].Value,0).ToString());
                Double Hro = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[hrbe.Name].Value,0).ToString());
                Double Ovs = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[ovdsbl.Name].Value, 0).ToString());
                String NoAccPst = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[NoAccPusat.Name].Value, "").ToString();
                String NoAccPtg = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[NoAccPiutang.Name].Value, "").ToString();
                String _kdgud = GlobalVar.Gudang;
                
                if (_kdgud == "2807")
                {
                    DialogResult dlg = new DialogResult();
                    if (isOverdueBe)
                    {
                        dlg = MessageBox.Show("Acc Pengajuan Overdue DO " + noDo + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dlg == DialogResult.Yes)
                        {
                            //UpdateAcc(rowId, PinId.Bagian.OverdueFB);
                            UpdateHistAcc(rowId, PinId.Bagian.OverdueFB,NoAccPst,NoAccPtg,noDo,TglDo,KdSales,KdToko
                            ,Plf,Ptg,Git,Gro,Grt,JDo,Ovd,Hro,Ovs);
                            cmdSearch_Click(sender, e);
                        }
                    }

                    //if (isSalesBl)
                    //{
                    //    dlg = MessageBox.Show("Acc Pengajuan Sales BL DO " + noDo + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    //    if (dlg == DialogResult.Yes)
                    //    {
                    //        bool isAcc = DialogResult == DialogResult.Yes;
                    //        UpdateAcc(rowId, PinId.Bagian.SalesBL);
                    //        cmdSearch_Click(sender, e);
                    //    }
                    //}
                }
                else
                {
                    DialogResult dlg = new DialogResult();
                    if (isOverdueBe)
                    {
                        dlg = MessageBox.Show("Acc Pengajuan Overdue DO " + noDo + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dlg == DialogResult.Yes)
                        {
                            UpdateHistAcc(rowId, PinId.Bagian.OverdueFB,NoAccPst,NoAccPtg,noDo,TglDo,KdSales,KdToko
                            ,Plf,Ptg,Git,Gro,Grt,JDo,Ovd,Hro,Ovs);
                            cmdSearch_Click(sender, e);
                        }
                    }

                    //if (isSalesBl)
                    //{
                    //    dlg = MessageBox.Show("Acc Pengajuan Sales BL DO " + noDo + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    //    if (dlg == DialogResult.Yes)
                    //    {
                    //        bool isAcc = DialogResult == DialogResult.Yes;
                    //        UpdateHistAcc(rowId, PinId.Bagian.SalesBL, NoAccPst, NoAccPtg, noDo, TglDo, KdSales, KdToko
                    //            ,Plf,Ptg,Git,Gro,Grt,JDo,Ovd,Hro,Ovs);
                    //        cmdSearch_Click(sender, e);
                    //    }
                    //}
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DateTime datenow = GlobalVar.DateTimeOfServer;
                DateTime fromdate_ = new DateTime(datenow.Year, datenow.Month, 1);
                DateTime todate_ = fromdate_.AddMonths(1).AddDays(-1);

                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_HistAcc_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromdate_));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, todate_));
                    dsData = db.Commands[0].ExecuteDataSet();
                }
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    DisplayReport(fromdate_,todate_);
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


        private void DisplayReport(DateTime fromdate_,DateTime todate_)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapHistAcc(fromdate_,todate_));

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_HistoryAcc";

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
                #endregion

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private ExcelPackage LapHistAcc(DateTime fromdate_,DateTime todate_)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author= "PS";
            ex.Workbook.Properties.Title = "Histtory Acc Overdue";
            ex.Workbook.Properties.SetCustomPropertyValue("Acc DO", "1147");

            ex.Workbook.Worksheets.Add("Laporan");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            // Width
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       
            ws.Cells[1, 2].Worksheet.Column(2).Width = 10;      
            ws.Cells[1, 3].Worksheet.Column(3).Width = 15;      
            ws.Cells[1, 4].Worksheet.Column(4).Width = 10;      
            ws.Cells[1, 5].Worksheet.Column(5).Width = 10;      
            ws.Cells[1, 6].Worksheet.Column(6).Width = 7;
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;
            ws.Cells[1, 8].Worksheet.Column(8).Width = 15;
            ws.Cells[1, 9].Worksheet.Column(9).Width = 15;
            ws.Cells[1, 10].Worksheet.Column(10).Width = 15;
            ws.Cells[1, 11].Worksheet.Column(11).Width = 15;
            ws.Cells[1, 12].Worksheet.Column(12).Width = 15;
            ws.Cells[1, 13].Worksheet.Column(13).Width = 15;
            ws.Cells[1, 14].Worksheet.Column(14).Width = 15;
            ws.Cells[1, 15].Worksheet.Column(15).Width = 35;
            ws.Cells[1, 16].Worksheet.Column(16).Width = 75;
            ws.Cells[1, 17].Worksheet.Column(17).Width = 25;
            ws.Cells[1, 18].Worksheet.Column(18).Width = 15;      

            int rowAcc = 0, nHeader = 0, rowx = 0;

            #region Laporan
            if (dsData.Tables[0].Rows.Count > 0)
            {
                nHeader++;
                nHeader++;
                rowAcc = nHeader + 2;
                rowx = rowAcc;

                ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
                ws.Cells[nHeader, 2].Value = " LAPORAN HISTORY ACC ";
                ws.Cells[nHeader, 2].Style.Font.Bold = true;
                ws.Cells[nHeader + 1, 2].Value = "Periode : "+ string.Format("{0:dd-MMM-yyyy}", fromdate_) + " s/d " + string.Format("{0:dd-MMM-yyyy}", todate_);
                ws.Cells[nHeader + 1, 2].Style.Font.Bold = true;
                
                int MaxCol = 18;
                double nRpDo = 0, nRpAcc = 0;

                ws.Cells[rowx, 2].Value = " No DO ";
                ws.Cells[rowx, 3].Value = " TGL DO ";
                ws.Cells[rowx, 4].Value = " OVD BE ";
                ws.Cells[rowx, 5].Value = " SALES BL ";
                ws.Cells[rowx, 6].Value = " KET ";
                ws.Cells[rowx, 7].Value = " Rp.DO ";
                ws.Cells[rowx, 8].Value = " Rp.ACC ";
                ws.Cells[rowx, 9].Value = " PLAFON ";
                ws.Cells[rowx, 10].Value = " PIUTANG ";
                ws.Cells[rowx, 11].Value = " GIT ";
                ws.Cells[rowx, 12].Value = " GIRO ";
                ws.Cells[rowx, 13].Value = " GIRO TOLAK ";
                ws.Cells[rowx, 14].Value = " KODE SALES ";
                ws.Cells[rowx, 15].Value = " NAMA TOKO ";
                ws.Cells[rowx, 16].Value = " ALAMAT ";
                ws.Cells[rowx, 17].Value = " KOTA ";
                ws.Cells[rowx, 18].Value = " IDWIl ";

                ws.Cells[rowx, 2, rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[rowx, 2, rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                rowx++;

                foreach (DataRow dr1 in dsData.Tables[0].Rows)
                {
                    ws.Cells[rowx, 2].Value = Tools.isNull(dr1["NoDO"], "");    
                    ws.Cells[rowx, 3].Value = string.Format("{0:dd-MMM-yyyy}",Tools.isNull(dr1["TglDO"], ""));
                    ws.Cells[rowx, 4].Value = Tools.isNull(dr1["OvBE"], "");
                    ws.Cells[rowx, 5].Value = Tools.isNull(dr1["OvSL"], "");
                    ws.Cells[rowx, 6].Value = Tools.isNull(dr1["pin"], "");
                    ws.Cells[rowx, 7].Value = Tools.isNull(dr1["SumRpNet"], 0);
                    ws.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 8].Value = Tools.isNull(dr1["SumRpNet"], 0);
                    ws.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 9].Value = Tools.isNull(dr1["plf_fb"], 0);
                    ws.Cells[rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 10].Value = Tools.isNull(dr1["Piutang"], 0);
                    ws.Cells[rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 11].Value = Tools.isNull(dr1["Git"], 0);
                    ws.Cells[rowx, 11].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 12].Value = Tools.isNull(dr1["Giro"], 0);
                    ws.Cells[rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 13].Value = Tools.isNull(dr1["GiroTolak"], 0);
                    ws.Cells[rowx, 13].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[rowx, 14].Value = Tools.isNull(dr1["KodeSales"], "");
                    ws.Cells[rowx, 15].Value = Tools.isNull(dr1["NamaToko"], "");
                    ws.Cells[rowx, 16].Value = Tools.isNull(dr1["Alamat"], "");
                    ws.Cells[rowx, 17].Value = Tools.isNull(dr1["Kota"], "");
                    ws.Cells[rowx, 18].Value = Tools.isNull(dr1["WilID"], "");

                    nRpDo = nRpDo + Convert.ToDouble(Tools.isNull(dr1["SumRpNet"], 0));
                    nRpAcc = nRpAcc + Convert.ToDouble(Tools.isNull(dr1["SumRpNet"], 0));
                    rowx++;
                }
                ws.Cells[rowx, 2].Value = "Total".ToString();
                ws.Cells[rowx, 2].Style.Font.Bold = true;
                ws.Cells[rowx, 7].Value = Tools.isNull(nRpDo, 0);
                ws.Cells[rowx, 7].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 7].Style.Font.Bold = true;
                ws.Cells[rowx, 8].Value = Tools.isNull(nRpAcc, 0);
                ws.Cells[rowx, 8].Style.Numberformat.Format = "#,##;(#,##);0";
                ws.Cells[rowx, 8].Style.Font.Bold = true;

                var border = ws.Cells[rowAcc + 1, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowAcc, 2, rowAcc, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[rowx, 2, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[rowx, 2, rowx, 2].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[rowx, 4, rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                nHeader = rowx;
            }
            #endregion
            return ex;
        }
    }
}
