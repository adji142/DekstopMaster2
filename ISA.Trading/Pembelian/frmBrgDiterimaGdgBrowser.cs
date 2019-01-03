using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading;
using ISA.Trading.Class;

namespace ISA.Trading.Pembelian
{
    public partial class frmBrgDiterimaGdgBrowser : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        DataTable dtDetail;
        DateTime _fromDate, _toDate;
        bool _acak = true;
        int _prefGrid = 0;
        public frmBrgDiterimaGdgBrowser()
        {
            InitializeComponent();
        }

        private void frmBrgDiterimaGdgBrowser_Load(object sender, EventArgs e)
        {
            this.Title = "Barang diterima Gudang";
            this.Text = "Pembelian"; 
            lblNamaBarang.Text = "";
            AcakTampilTextBox();
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            _fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            _toDate = DateTime.Now;
            rgbTglNota.FromDate = _fromDate;
            rgbTglNota.ToDate = _toDate;
            rgbTglNota.Focus();
            //txtInit.Text = GlobalVar.PerusahaanID;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataNotaBeli();
            dataGridHeader.Focus();
        }

        private void rgbTglNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void RefreshDataNotaBeli()
        {
            _fromDate = (DateTime)rgbTglNota.FromDate;
            _toDate = (DateTime)rgbTglNota.ToDate;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtHeader = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPers", SqlDbType.VarChar, txtInit.Text));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                dataGridHeader.DataSource = dtHeader;
                if (dtHeader.Rows.Count == 0)
                {
                    lblNamaBarang.Text = "";
                    dataGridDetail.DataSource = null;
                    AcakTampilTextBox();
                }
                else
                {
                    RefreshDataNotaBeliDetail();
                    dataGridHeader.Focus();
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

        public void RefreshDataNotaBeliDetail()
        {
            Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;                
                dtDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                    dataGridDetail.DataSource = dtDetail;
                }

                if (dtDetail.Rows.Count == 0)
                {
                    lblNamaBarang.Text = "";
                }
                else
                {
                    lblNamaBarang.Text = dataGridDetail.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
                } 
                AcakTampilTextBox();
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

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
            _prefGrid = 1;
        }

        private void dataGridDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
            _prefGrid = 2;
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if(!CekEdit())
            {
                return;
            }
            Guid rowID;
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    try
                    {
                        if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString().Trim()!="")
                      {
                          GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value;
                          if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value <= GlobalVar.LastClosingDate)
                          {
                              throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                          }
                      }
                        rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        Pembelian.frmBrgDiterimaGdgUpdate ifrmChild = new Pembelian.frmBrgDiterimaGdgUpdate(this, rowID);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                        
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    
                    break;
                case enumSelectedGrid.DetailSelected:
                    try
                    {
                        GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value;
                        if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }

                        rowID = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                        DateTime tglTerima = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value;
                        Pembelian.frmBrgDiterimaGdgDetailUpdate ifrmChild2 = new Pembelian.frmBrgDiterimaGdgDetailUpdate(this, rowID, tglTerima);
                        ifrmChild2.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild2);
                        ifrmChild2.Show();
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    
                    break;
            }
        }

        private bool CekEdit()
        {
            bool cek = true;

            if (dataGridHeader.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                cek = false;
                goto SelesaiCek;
            }

            if (dataGridDetail.SelectedCells.Count == 0)
            {
                MessageBox.Show("Hanya nota tidak ada detail");
                cek = false;
                goto SelesaiCek;
            }

            if (dataGridDetail.SelectedCells[0].OwningRow.Cells["KodeGudang"].Value.ToString() !=
                GlobalVar.Gudang)
            {
                MessageBox.Show("Hanya untuk Gudang " + GlobalVar.Gudang);
                cek = false;
                goto SelesaiCek;
            }

            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString() == ""
                && selectedGrid == enumSelectedGrid.DetailSelected)
            {
                MessageBox.Show("Tanggal terima masih kosong");
                cek = false;
                goto SelesaiCek;
            }

            /*
            if (selectedGrid = enumSelectedGrid.HeaderSelected)
            {
                if (SyncFlag Header == 1)
                minta password manager
                goto SelesaiCek;
            }

            if (selectedGrid = enumSelectedGrid.HeaderSelected)
            {
                if (SyncFlag Detail == 1)
                minta password manager
                goto SelesaiCek;
            }
             * */

            SelesaiCek:
            return cek;
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.Shift == true && e.KeyCode == Keys.P)
            {
                _fromDate = (DateTime)rgbTglNota.FromDate;
                _toDate = (DateTime)rgbTglNota.ToDate;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                { 
                    db.Commands.Add(db.CreateCommand("usp_GetSelisihQty"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate",SqlDbType.DateTime,_fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    cetakMemoKomplain(dt);
                }
                else
                {
                    MessageBox.Show("Tidak ada selisih");
                }
            }
            else if(e.KeyCode==Keys.F9)
            {
                    AcakTampilHrg();
            }
            else if(e.KeyCode== Keys.F12)
            {
                    // Filter barang
                    Pembelian.frmPembelianFilterBarangBrowser ifrmChild = new Pembelian.frmPembelianFilterBarangBrowser(_fromDate, _toDate);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
            }
            else if (e.KeyCode == Keys.Tab)
            {
                dataGridDetail.Focus();
                selectedGrid = enumSelectedGrid.DetailSelected;
            }

            
            
        }

        

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.F11:
                    if (!SecurityManager.IsAuditor())
                    {
                        // Koreksi
                        KoreksiPembelian();
                    }
                    break;
                case Keys.Tab:
                    dataGridHeader.Focus();
                    selectedGrid = enumSelectedGrid.HeaderSelected;
                    break;
            }
        }

        private void KoreksiPembelian()
        {
            Guid detailRowID = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;

            if (CekReturPembelian(detailRowID))
            {
                MessageBox.Show("Tidak bisa lakukan koreksi karena sudah pernah retur pembelian");
                return;
            }

            if (dataGridDetail.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }
            if (dataGridDetail.SelectedCells[0].OwningRow.Cells["KodeGudang"].Value.ToString() != GlobalVar.Gudang)
            {
                MessageBox.Show("Hanya untuk gudang " + GlobalVar.Gudang);
                return;
            }
            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString() == "")
            {
                MessageBox.Show("Tanggal Terima masih kosong");
                return;
            }
            
            Pembelian.frmKoreksiBeliBrowser ifrmChild = new Pembelian.frmKoreksiBeliBrowser(detailRowID);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private bool CekReturPembelian(Guid value)
        {
            DataTable dt;
            bool retVal = false;
                
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_CekReturNotaPembelian"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, value));
                dt = db.Commands[0].ExecuteDataTable();

                if (dt.Rows.Count > 0)
                {
                    retVal = true;
                }
            }

            return retVal;
        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double _rpBeli = double.Parse(dataGridHeader.Rows[e.RowIndex].Cells["RpBeli"].Value.ToString());
            double _rpNet = double.Parse(dataGridHeader.Rows[e.RowIndex].Cells["RpNet"].Value.ToString());
            
            dataGridHeader.Rows[e.RowIndex].Cells["RpBeli"].Style.Format = "#,##0";
            dataGridHeader.Rows[e.RowIndex].Cells["RpNet"].Style.Format = "#,##0";

            dataGridHeader.Rows[e.RowIndex].Cells["RpBeliAck"].Value = Tools.GetAntiNumeric(_rpBeli.ToString("#,##0"));
            dataGridHeader.Rows[e.RowIndex].Cells["RpNetAck"].Value = Tools.GetAntiNumeric(_rpNet.ToString("#,##0"));

            dataGridHeader.Rows[e.RowIndex].Cells["RpBeliAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridHeader.Rows[e.RowIndex].Cells["RpNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void dataGridDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double _hrgBeli = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["HrgBeli"].Value.ToString());
            double _jmlHrgBeli = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgBeli"].Value.ToString());
            double _hpp = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["HPP"].Value.ToString());
            double _jmlHPP = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["JmlHPP"].Value.ToString());

            dataGridDetail.Rows[e.RowIndex].Cells["HrgBeli"].Style.Format = "#,##0";
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgBeli"].Style.Format = "#,##0";
            dataGridDetail.Rows[e.RowIndex].Cells["HPP"].Style.Format = "#,##0";
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHPP"].Style.Format = "#,##0";

            dataGridDetail.Rows[e.RowIndex].Cells["HrgBeliAck"].Value = Tools.GetAntiNumeric(_hrgBeli.ToString("#,##0"));
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgBeliAck"].Value = Tools.GetAntiNumeric(_jmlHrgBeli.ToString("#,##0"));
            dataGridDetail.Rows[e.RowIndex].Cells["HPPAck"].Value = Tools.GetAntiNumeric(_hpp.ToString("#,##0"));
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHPPAck"].Value = Tools.GetAntiNumeric(_jmlHPP.ToString("#,##0"));

            dataGridDetail.Rows[e.RowIndex].Cells["HrgBeliAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgBeliAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetail.Rows[e.RowIndex].Cells["HPPAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHPPAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void AcakTampilHrg()
        {
            _acak = !_acak;

            dataGridHeader.Columns["RpBeli"].Visible = !_acak;
            dataGridHeader.Columns["RpNet"].Visible = !_acak;            
            dataGridDetail.Columns["HrgBeli"].Visible = !_acak;
            dataGridDetail.Columns["JmlHrgBeli"].Visible = !_acak;
            dataGridDetail.Columns["HPP"].Visible = !_acak;
            dataGridDetail.Columns["JmlHPP"].Visible = !_acak;

            dataGridHeader.Columns["RpBeliAck"].Visible = _acak;
            dataGridHeader.Columns["RpNetAck"].Visible = _acak;
            dataGridDetail.Columns["HrgBeliAck"].Visible = _acak;
            dataGridDetail.Columns["JmlHrgBeliAck"].Visible = _acak;
            dataGridDetail.Columns["HPPAck"].Visible = _acak;
            dataGridDetail.Columns["JmlHPPAck"].Visible = _acak;

            AcakTampilTextBox();
        }

        private void AcakTampilTextBox()
        {
            double total = 0;
            double total2 = 0;

            if (dataGridDetail.RowCount > 0)
            {
                total = double.Parse(dtDetail.Compute("SUM(JmlHrgBeli)", string.Empty).ToString());
                total2 = double.Parse(dtDetail.Compute("SUM(JmlhHargaBeli)", string.Empty).ToString());
            }

            if (_acak)
            {
                txtTotJmlHrgBeli.Text = Tools.GetAntiNumeric(total.ToString("#,##0"));
                txtTotJmlHPP.Text = Tools.GetAntiNumeric(total2.ToString("#,##0"));
            }
            else
            {
                txtTotJmlHrgBeli.Text = total.ToString("#,##0");
                txtTotJmlHPP.Text = total2.ToString("#,##0"); 
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolTipButton1_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(helpToolTipButton1, toolTip1.GetToolTip(helpToolTipButton1));
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridHeader.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridDetail.FindRow(columnName, value);
        }

        private void dataGridHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridDetail_Validated(object sender, EventArgs e)
        {
            
           
        }

        private void dataGridHeader_Validated(object sender, EventArgs e)
        {
            if (dataGridHeader.Focused == true)
            {
                selectedGrid = enumSelectedGrid.HeaderSelected;
                _prefGrid = 1;
            }
            
           
        }

        private void dataGridDetail_TabIndexChanged(object sender, EventArgs e)
        {
            //if (dataGridDetail.Focused == false)
            //{
            //    selectedGrid = enumSelectedGrid.HeaderSelected;
            //}
        }

        private void dataGridDetail_Leave(object sender, EventArgs e)
        {
            if (_prefGrid==1 && selectedGrid!=enumSelectedGrid.HeaderSelected)
            {
                dataGridHeader.Focus();
                selectedGrid = enumSelectedGrid.HeaderSelected;
            }
        }

        private void cetakMemoKomplain(DataTable dt)
        {
            
            BuildString komplain = new BuildString();
            komplain.LeftMargin(3);
            foreach(DataRow dr in dt.Rows)
            {
                komplain.FontCondensed(false);
                komplain.FontBold(true);
                komplain.FontCPI(20);
                komplain.PROW(true, 1, "MEMO KOMPLAIN PEMBELIAN 0000");
                komplain.PROW(true, 1, "");
                komplain.FontCondensed(true);
                komplain.FontBold(false);

                komplain.PROW(true, 1, "No. Nota".PadRight(20) + dr["NoNota"].ToString().PadRight(40) + "Tanggal Nota".PadRight(20) +
                    string.Format("{0:dd-MMM-yyyy}", dr["TglNota"]));

                komplain.PROW(true, 1, "Pemasok".PadRight(20) + dr["pemasok"].ToString().PadRight(40) + "Tanggal Terima".PadRight(20) +
                    string.Format("{0:dd-MMM-yyyy}", dr["TglTerima"]));

                komplain.PROW(true,1,komplain.PrintHorizontalLine(130));


                //Tabel QTY
                komplain.PROW(true, 1, "Qty");

                komplain.PROW(true, 1, komplain.PrintTopLeftCorner() + komplain.PrintHorizontalLine(83) + komplain.PrintTTOp() +
                    komplain.PrintHorizontalLine(44) + komplain.PrintTopRightCorner());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.PadCenter(44, "QTY") + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.PadCenter(83,"Nama Barang") + komplain.PrintTLeft() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTTOp() + komplain.PrintHorizontalLine(14) + komplain.PrintTTOp() + 
                    komplain.PrintHorizontalLine(14)+komplain.PrintTRight());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.PadCenter(14, "Nota") + komplain.PrintVerticalLine() + komplain.PadCenter(14, "Terima") + komplain.PrintVerticalLine()
                    + komplain.PadCenter(14, "Selisih") + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintTLeft() + komplain.PrintHorizontalLine(83) + komplain.PrintTMidlle() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTMidlle() + komplain.PrintHorizontalLine(14) + komplain.PrintTMidlle() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTRight());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.SPACE(14) + komplain.PrintVerticalLine() + komplain.SPACE(14)
                    + komplain.PrintVerticalLine() + komplain.SPACE(14) + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + dr["NamaStok"].ToString().PadRight(83) + komplain.PrintVerticalLine() +
                    dr["QtyNota"].ToString().PadLeft(14) + komplain.PrintVerticalLine() + dr["QtySuratJalan"].ToString().PadLeft(14)
                    + komplain.PrintVerticalLine() + dr["selisih"].ToString().PadLeft(14) + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.SPACE(14) + komplain.PrintVerticalLine() + komplain.SPACE(14)
                    + komplain.PrintVerticalLine() + komplain.SPACE(14) + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintBottomLeftCorner() + komplain.PrintHorizontalLine(83) + komplain.PrintTBottom() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTBottom() + komplain.PrintHorizontalLine(14) + komplain.PrintTBottom() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintBottomRightCorner());

                //Tabel koli
                komplain.PROW(true, 1, "KOLI");

                komplain.PROW(true, 1, komplain.PrintTopLeftCorner() + komplain.PrintHorizontalLine(83) + komplain.PrintTTOp() +
                    komplain.PrintHorizontalLine(44) + komplain.PrintTopRightCorner());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.PadCenter(44, "Koli") + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.PadCenter(83, "Nama Barang") + komplain.PrintTLeft() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTTOp() + komplain.PrintHorizontalLine(14) + komplain.PrintTTOp() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTRight());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.PadCenter(14, "Nota") + komplain.PrintVerticalLine() + komplain.PadCenter(14, "Terima") + komplain.PrintVerticalLine()
                    + komplain.PadCenter(14, "Selisih") + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintTLeft() + komplain.PrintHorizontalLine(83) + komplain.PrintTMidlle() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTMidlle() + komplain.PrintHorizontalLine(14) + komplain.PrintTMidlle() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTRight());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.SPACE(14) + komplain.PrintVerticalLine() + komplain.SPACE(14)
                    + komplain.PrintVerticalLine() + komplain.SPACE(14) + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + dr["NamaStok"].ToString().PadRight(83) + komplain.PrintVerticalLine() +
                    komplain.SPACE(14) + komplain.PrintVerticalLine() + komplain.SPACE(14)+ komplain.PrintVerticalLine() + 
                    komplain.SPACE(14) + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.SPACE(14) + komplain.PrintVerticalLine() + komplain.SPACE(14)
                    + komplain.PrintVerticalLine() + komplain.SPACE(14) + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintBottomLeftCorner() + komplain.PrintHorizontalLine(83) + komplain.PrintTBottom() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTBottom() + komplain.PrintHorizontalLine(14) + komplain.PrintTBottom() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintBottomRightCorner());

                //Kolom Tanda Tangan

                komplain.PROW(true, 1, komplain.PrintTopLeftCorner() + komplain.PrintHorizontalLine(42) + komplain.PrintTTOp()
                    + komplain.PrintHorizontalLine(42) + komplain.PrintTTOp() + komplain.PrintHorizontalLine(42) + komplain.PrintTopRightCorner());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.PadCenter(42,"Penghitung, Mengajukan") + komplain.PrintVerticalLine()
                    + komplain.PadCenter(42,"Ka. Gudang, Menyetujui") + komplain.PrintVerticalLine() + 
                    komplain.PadCenter(42,"Accounting, Mengetahui") + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintTLeft() + komplain.PrintHorizontalLine(42) + komplain.PrintTMidlle()
                    + komplain.PrintHorizontalLine(42) + komplain.PrintTMidlle() + komplain.PrintHorizontalLine(42) + komplain.PrintTRight());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine()
                    + komplain.SPACE(42) + komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine());
                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine()
                    + komplain.SPACE(42) + komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine());
                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine()
                    + komplain.SPACE(42) + komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine());
                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine()
                    + komplain.SPACE(42) + komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintTLeft() + komplain.PrintHorizontalLine(42) + komplain.PrintTMidlle()
                    + komplain.PrintHorizontalLine(42) + komplain.PrintTMidlle() + komplain.PrintHorizontalLine(42) + komplain.PrintTRight());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + "("+komplain.SPACE(40)+")" + komplain.PrintVerticalLine()
                    + "(" + komplain.SPACE(40) + ")" + komplain.PrintVerticalLine() + "(" + komplain.SPACE(40) + ")" + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintBottomLeftCorner() + komplain.PrintHorizontalLine(42) + komplain.PrintTBottom()
                    + komplain.PrintHorizontalLine(42) + komplain.PrintTBottom() + komplain.PrintHorizontalLine(42) + komplain.PrintBottomRightCorner());

                komplain.PROW(true, 1, string.Format("{0:dd-MMM-yyyy-hh-mm-ss}", DateTime.Now) + ", " + SecurityManager.UserID);
                komplain.Eject();
            }
            komplain.SendToPrinter("memokomplainpembelian.txt");
        }

        private void dataGridDetail_Validating(object sender, CancelEventArgs e)
        {
            if (dataGridDetail.Focused == true)
            {
                selectedGrid = enumSelectedGrid.DetailSelected;
                _prefGrid = 2;
            }
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                    RefreshDataNotaBeliDetail();
            }
        }

        private void dataGridDetail_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridDetail.SelectedCells.Count > 0)
            {
                lblNamaBarang.Text = dataGridDetail.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
            }
            else
            {
                lblNamaBarang.Text = "";
            }
        }
    }
}
