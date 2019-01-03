using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.VisualBasic;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Common;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using ISA.Utility;

namespace ISA.Trading.Master
{
    public partial class frmTokoBrowse : ISA.Trading.BaseForm
    {
        DataTable dtToko = new DataTable();
        DataTable hawuk = new DataTable();
        JSON mdat;
        DataSet dset;
        public frmTokoBrowse()
        {
            InitializeComponent();
        }

        private void frmTokoBrowse_Load(object sender, EventArgs e)
        {
            RefreshDataToko();
            RefreshDataCabang();
            dataGridCabang.FindRow("CabangID", GlobalVar.CabangID);
        }

        public void RefreshDataToko()
        {
            try
            {
                using (Database db = new Database())
                {

                    dtToko = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, txtSearch.Text));
                    dtToko = db.Commands[0].ExecuteDataTable();
                    dataGridToko.DataSource = dtToko;
                }
                if (dataGridToko.SelectedCells.Count > 0)
                {
                    lblToko.Text = "\"" + (dataGridToko.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString())
                    + "\"  "
                    + (dataGridToko.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString());

                    if (dataGridCabang.SelectedCells.Count > 0)
                    {
                        RefreshDataStatusToko();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshDataCabang()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtCabang = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    dtCabang = db.Commands[0].ExecuteDataTable();
                    dataGridCabang.DataSource = dtCabang;
                }
                if (dataGridCabang.SelectedCells.Count > 0 && dataGridToko.SelectedCells.Count > 0)
                {
                    RefreshDataStatusToko();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshDataStatusToko()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtStsToko = new DataTable();

                    string _kodeToko = dataGridToko.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                    string _cabangID = dataGridCabang.SelectedCells[0].OwningRow.Cells["CabangID"].Value.ToString();

                    db.Commands.Add(db.CreateCommand("usp_StatusToko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@cabangID", SqlDbType.VarChar, _cabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                    dtStsToko = db.Commands[0].ExecuteDataTable();
                    dataGridStsToko.DataSource = dtStsToko;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataToko();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //Master.frmTokoUpdate ifrmChild = new Master.frmTokoUpdate(this);
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show(); 
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {

        }

        public void FindRow(string columnName, string value)
        {
            dataGridToko.FindRow(columnName, value);
        }


        public void RefreshPlafon()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtPlafon = new DataTable();

                    string _kodeToko = dataGridToko.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();

                    db.Commands.Add(db.CreateCommand("usp_PlafonToko_List"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                    dtPlafon = db.Commands[0].ExecuteDataTable();
                    datagridPlafon.DataSource = dtPlafon;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        private void dataGridToko_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //RefreshPlafon();
        }

        private void dataGridToko_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridToko.SelectedCells.Count > 0)
            {
                try
                {
                    if (e.Shift == true && e.KeyCode == Keys.K)
                    {
                        string _KodeToko = dataGridToko.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                        string val = dataGridToko.SelectedCells[0].OwningRow.Cells["Cabang2"].Value.ToString().Trim();
                        dataGridToko.SelectedCells[0].OwningRow.Cells["Cabang2"].Value = EditPT(_KodeToko, val);
                        dataGridToko.RefreshEdit();
                    }
                    if (e.KeyCode == Keys.Space)
                    {
                        string _KodeToko = dataGridToko.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                        string val = string.Empty;
                        string Temp_ = "";

                        Temp_ = Tools.isNull(dataGridToko.SelectedCells[0].OwningRow.Cells["KodePos"].Value, "").ToString();
                        //  val = Interaction.InputBox("Toko KodePos : ", "Edit KodePos. Toko", Temp_, 20, 20);

                        frmTokoKdPosUpdate ifrmDialog = new frmTokoKdPosUpdate(Temp_);
                        ifrmDialog.ShowDialog();
                        if (ifrmDialog.DialogResult == DialogResult.OK)
                        {
                            val = ifrmDialog.KodePos;
                            if (val.Trim() != Temp_.Trim())
                            {
                                EditUraianKpiutang(val, _KodeToko);
                                dataGridToko.SelectedCells[0].OwningRow.Cells["KodePos"].Value = val;
                                dataGridToko.RefreshEdit();
                            }

                        }
                    }
                    if (e.Shift == true && e.KeyCode == Keys.L)
                    {

                        ListToko();

                    }

                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }

            }

        }

        private void ListToko()
        {

            DataTable da = dtToko.DefaultView.ToTable().Copy();
            Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            ExcelApp.Application.Workbooks.Add(Type.Missing);

            progressBar1.Visible = true;
            progressBar1.Maximum = dataGridToko.Rows.Count;
            progressBar1.Value = 0;
            //for (int i = 1; i < dataGridToko.Columns.Count + 1; i++)
            //{
            //    //ExcelApp.Cells[1, i] = dataGridToko.Columns[i - 1].HeaderText;
            //    ExcelApp.Cells[1, 1] = dataGridToko.Columns[0].HeaderText;
            //    ExcelApp.Cells[1, 2] = dataGridToko.Columns[1].HeaderText;
            //}

            ExcelApp.Cells[1, 1] = "Nama Toko";
            ExcelApp.Cells[1, 2] = "Id.Wil";
            ExcelApp.Cells[1, 3] = "Id.Toko";
            ExcelApp.Cells[1, 4] = "K";
            ExcelApp.Cells[1, 5] = "Alamat";
            ExcelApp.Cells[1, 6] = "Kota";
            ExcelApp.Cells[1, 7] = "Daerah";
            ExcelApp.Cells[1, 8] = "Propinsi";
            ExcelApp.Cells[1, 9] = "No.Telp";
            ExcelApp.Cells[1, 10] = "Penanggung Jawab";
            ExcelApp.Cells[1, 11] = "Hari Sales";
            ExcelApp.Cells[1, 12] = "Hari Kirim";
            ExcelApp.Cells[1, 13] = "Status";

            int x = 0;
            int i = 0;
            foreach (DataRow dr in da.Rows)
            {
                Application.DoEvents();
                this.Invalidate();

                progressBar1.Value = x;
                x++;
                ExcelApp.Cells[i + 2, 1] = Tools.isNull(dr["NamaToko"], "").ToString().Trim();
                ExcelApp.Cells[i + 2, 2] = Tools.isNull(dr["WilID"], "").ToString().Trim();
                ExcelApp.Cells[i + 2, 3] = Tools.isNull("'" + dr["TokoID"], "").ToString().Trim();
                ExcelApp.Cells[i + 2, 4] = Tools.isNull(dr["Cabang2"], "").ToString().Trim();
                ExcelApp.Cells[i + 2, 5] = Tools.isNull(dr["Alamat"], "").ToString().Trim();
                ExcelApp.Cells[i + 2, 6] = Tools.isNull(dr["Kota"], "").ToString().Trim();
                ExcelApp.Cells[i + 2, 7] = Tools.isNull(dr["Daerah"], "").ToString().Trim();
                ExcelApp.Cells[i + 2, 8] = Tools.isNull(dr["Propinsi"], "").ToString().Trim();
                ExcelApp.Cells[i + 2, 9] = Tools.isNull("'" + dr["Telp"], "").ToString().Trim();
                ExcelApp.Cells[i + 2, 10] = Tools.isNull(dr["PenanggungJawab"], "").ToString().Trim();
                ExcelApp.Cells[i + 2, 11] = Tools.isNull(dr["HariSales"], "").ToString().Trim();
                ExcelApp.Cells[i + 2, 12] = Tools.isNull(dr["JangkaWaktuKredit"], "").ToString().Trim();
                ExcelApp.Cells[i + 2, 13] = Tools.isNull(dr["StatusAktif"], "").ToString().Trim();
                i++;
            }


            //for (int i = 0; i < dataGridToko.Rows.Count; i++)
            //{
            //    Application.DoEvents();
            //    this.Invalidate();

            //    progressBar1.Value = x;
            //    x++;
            //    for (int j = 0; j < dataGridToko.Columns.Count; j++)
            //    {
            //        //ExcelApp.Cells[i + 2, j + 1] = dataGridToko.Rows[i].Cells[j].Value.ToString();
            //        //ExcelApp.Cells[i + 2, j + 1] = Tools.isNull(dataGridToko.Rows[i].Cells[j].Value,"").ToString();
            //          ExcelApp.Cells[i + 2, 1] = Tools.isNull(dataGridToko.Rows[i].Cells[0].Value, "").ToString();
            //          ExcelApp.Cells[i + 2, 2] = Tools.isNull(dataGridToko.Rows[i].Cells[1].Value, "").ToString();

            //    }
            //}



            ExcelApp.ActiveWorkbook.SaveCopyAs("C:\\Temp\\Toko.xls");
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
            progressBar1.Visible = false;
        }

        private void EditUraianKpiutang(string txt_, string _kodeToke)
        {
            try
            {
                using (Database db = new Database())
                {
                    //dataGridHeader.SelectedCells[0].OwningRow.Cells["KeteranganTagihan"].Value


                    db.Commands.Add(db.CreateCommand("[usp_Toko_KodePos]"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodePOs", SqlDbType.VarChar, txt_));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _kodeToke));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private string EditPT(string _KodeToko, string val)
        {

            val = (val == "PT" ? "" : "PT");
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_Toko_Cabang2]"));
                db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, val));
                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                db.Commands[0].ExecuteNonQuery();
            }

            return val;
        }

        private void dataGridToko_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridToko.SelectedCells.Count > 0)
            {
                lblToko.Text = "\"" + (dataGridToko.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString())
                    + "\"  "
                    + (dataGridToko.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString());

                if (dataGridCabang.SelectedCells.Count > 0)
                {
                    RefreshDataStatusToko();
                }

                RefreshPlafon();

                string no_ktp = dataGridToko.SelectedCells[0].OwningRow.Cells["no_ktp"].Value.ToString();
                //tutup sementara
                //uploadFotoKtp1.NomorKtp = no_ktp;
                lblnoktp.Text = no_ktp;
            }
        }

        private void dataGridCabang_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridCabang.SelectedCells.Count > 0 && dataGridToko.SelectedCells.Count > 0)
            {
                //tutup sementara
                //RefreshDataStatusToko();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridToko_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //RefreshPlafon();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridToko.SelectedCells.Count > 0)
            {
                string _tokoID = dataGridToko.SelectedCells[0].OwningRow.Cells["TokoID"].Value.ToString();

                if (_tokoID == "")
                {
                    Guid rowID = (Guid)dataGridToko.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    Master.frmTokoUpdate ifrmChild = new Master.frmTokoUpdate(this, rowID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                else
                {
                    MessageBox.Show("Hanya untuk toko baru");
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            //Master.frmTokoDownloadData ifrmChild = new Master.frmTokoDownloadData();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
            MessageBox.Show("Download di Master Toko - Pull Toko WISER");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (dataGridToko.Rows.Count >0)
            {
                string _kodeToko = dataGridToko.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                string _namaToko = dataGridToko.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                String FileName = dataGridToko.SelectedCells[0].OwningRow.Cells["ft_toko"].Value.ToString();

                if (FileName == "")
                {
                    MessageBox.Show("Foto Toko tidak tersedia");
                    return;
                }
                frmTokoAttachmentView frm = new frmTokoAttachmentView(this, FileName, _kodeToko, _namaToko);
                frm.ShowDialog();
            }
        }

        private void cmdList_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("View Daftar Master Toko ?", "View", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        dtToko = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                        dtToko = db.Commands[0].ExecuteDataTable();
                    }
                    if (dataGridToko.SelectedCells.Count > 0)
                    {
                        DisplayReportToko(dtToko);
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }        
        }

        private void DisplayReportToko(DataTable dt)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(ListToko(dt));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_ListToko";

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


        private ExcelPackage ListToko(DataTable dt)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "LIST TOKO";
            ex.Workbook.Properties.SetCustomPropertyValue("List Toko", "1147");

            ex.Workbook.Worksheets.Add("Master Toko");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Size = 9;

            int nRow = 0, nHeader = 1, Rowx = 0;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 31;      //namatoko
            ws.Cells[1, 4].Worksheet.Column(4).Width = 8;       //idwil
            ws.Cells[1, 5].Worksheet.Column(5).Width = 8;       //idtoko
            ws.Cells[1, 6].Worksheet.Column(6).Width = 3;       //K
            ws.Cells[1, 7].Worksheet.Column(7).Width = 60;      //alamat
            ws.Cells[1, 8].Worksheet.Column(8).Width = 22;      //kota
            ws.Cells[1, 9].Worksheet.Column(9).Width = 22;      //daerah
            ws.Cells[1, 10].Worksheet.Column(10).Width = 22;    //propinsi
            ws.Cells[1, 11].Worksheet.Column(11).Width = 20;    //notelp
            ws.Cells[1, 12].Worksheet.Column(12).Width = 20;    //hp
            ws.Cells[1, 13].Worksheet.Column(13).Width = 20;    //penangungjawab
            ws.Cells[1, 14].Worksheet.Column(14).Width = 5;     //jw
            ws.Cells[1, 15].Worksheet.Column(15).Width = 5;     //js
            ws.Cells[1, 16].Worksheet.Column(16).Width = 5;     //jx
            ws.Cells[1, 17].Worksheet.Column(17).Width = 10;    //status
            ws.Cells[1, 18].Worksheet.Column(18).Width = 10;    //status toko
            ws.Cells[1, 19].Worksheet.Column(19).Width = 15;    //tgl input toko
            ws.Cells[1, 20].Worksheet.Column(20).Width = 13;    //kodesales
            ws.Cells[1, 21].Worksheet.Column(21).Width = 20;    //kodetoko
            ws.Cells[1, 22].Worksheet.Column(22).Width = 10;    //verified
            ws.Cells[1, 23].Worksheet.Column(23).Width = 30;    //verified
            ws.Cells[1, 24].Worksheet.Column(24).Width = 30;    //verified

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "List Toko";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", DateTime.Now);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 3, 2].Value = "Depo " + GlobalVar.Gudang;
            ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 2, 2].Style.Font.Italic = true;

            nRow = nHeader + 3;
            Rowx = nRow;
            int MaxCol = 24;

            for (int i = 2; i <= MaxCol; i++)
            {
                ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            }

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Nama Toko ";
            ws.Cells[Rowx, 4].Value = " Id.Wil ";
            ws.Cells[Rowx, 5].Value = " Id.Toko ";
            ws.Cells[Rowx, 6].Value = " K ";
            ws.Cells[Rowx, 7].Value = " Alamat ";
            ws.Cells[Rowx, 8].Value = " Kota ";
            ws.Cells[Rowx, 9].Value = " Daerah ";
            ws.Cells[Rowx, 10].Value = " Propinsi ";
            ws.Cells[Rowx, 11].Value = " No.Telp ";
            ws.Cells[Rowx, 12].Value = " No.HP ";
            ws.Cells[Rowx, 13].Value = " Penanggung Jawab ";
            ws.Cells[Rowx, 14].Value = " Jw ";
            ws.Cells[Rowx, 15].Value = " Js ";
            ws.Cells[Rowx, 16].Value = " Jx ";
            ws.Cells[Rowx, 17].Value = " Status ";
            ws.Cells[Rowx, 18].Value = " Status Toko ";
            ws.Cells[Rowx, 19].Value = " Tgl Input Toko ";
            ws.Cells[Rowx, 20].Value = " Kode Sales ";
            ws.Cells[Rowx, 21].Value = " Kode Toko ";
            ws.Cells[Rowx, 22].Value = " Verified ";
            ws.Cells[Rowx, 23].Value = " No KTP ";
            ws.Cells[Rowx, 24].Value = " CATATAN ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;
            int no = 0;
            double Jumlah = 0;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dt.Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["WilID"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["TokoID"], "").ToString();
                    ws.Cells[Rowx, 6].Value = "";
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["Alamat"], "").ToString();
                    ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["Daerah"], "").ToString();
                    ws.Cells[Rowx, 10].Value = Tools.isNull(dr1["Propinsi"], "").ToString();
                    ws.Cells[Rowx, 11].Value = Tools.isNull(dr1["Telp"], "").ToString();
                    ws.Cells[Rowx, 12].Value = Tools.isNull(dr1["HP"], "").ToString();
                    ws.Cells[Rowx, 13].Value = Tools.isNull(dr1["PenanggungJawab"], "").ToString();
                    ws.Cells[Rowx, 14].Value = Int32.Parse(Tools.isNull(dr1["JangkaWaktuKredit"], "0").ToString());
                    ws.Cells[Rowx, 14].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 15].Value = Int32.Parse(Tools.isNull(dr1["HariSales"], "0").ToString());
                    ws.Cells[Rowx, 15].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 16].Value = Int32.Parse(Tools.isNull(dr1["HariKirim"], "0").ToString());
                    ws.Cells[Rowx, 16].Style.Numberformat.Format = "#,##;(#,##);";
                    ws.Cells[Rowx, 17].Value = Tools.isNull(dr1["StatusAktif"], "").ToString();
                    ws.Cells[Rowx, 18].Value = Tools.isNull(dr1["StatusToko"], "").ToString(); ;  //statustoko
                    ws.Cells[Rowx, 19].Value = string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dr1["LastUpdatedTime"].ToString()));
                    ws.Cells[Rowx, 20].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
                    ws.Cells[Rowx, 21].Value = Tools.isNull(dr1["KodeToko"], "").ToString();
                    ws.Cells[Rowx, 22].Value = Tools.isNull(dr1["VerifiedNIK"], "").ToString();
                    ws.Cells[Rowx, 23].Value = Tools.isNull(dr1["no_ktp"], "").ToString();
                    ws.Cells[Rowx, 24].Value = Tools.isNull(dr1["catatan"], "").ToString();
                    Rowx++;
                }
            }
            Rowx++;

            //ws.Cells[Rowx, 10].Value = Tools.isNull(Jumlah, 0);
            //ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
            //ws.Cells[Rowx, 10].Style.Font.Bold = true;

            //ws.Cells[Rowx, 10, Rowx, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells[Rowx, 10, Rowx, 10].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            var border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style = ExcelBorderStyle.Thin;
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            //border = ws.Cells[Rowx, 10, Rowx, 10].Style.Border;
            //border.Bottom.Style =
            //border.Top.Style =
            //border.Left.Style =
            //border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            Rowx += 2;
            ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
            ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;

            return ex;

        }

        private void cmdPullStatus_Click(object sender, EventArgs e)
        {
            Master.frmTokoSynch frm = new Master.frmTokoSynch();
            frm.ShowDialog();
        }

        private void btnPullData_Click(object sender, EventArgs e)
        {
            Master.frmTokoSynch frm = new Master.frmTokoSynch();
            frm.ShowDialog();
        }

    }
}
