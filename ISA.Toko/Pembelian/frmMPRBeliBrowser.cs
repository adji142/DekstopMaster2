using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Toko.Class;
using System.Threading;
using System.Globalization;


namespace ISA.Toko.Pembelian
{
    public partial class frmMPRBeliBrowser : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        DataTable dtDetail;
        string _format;
        bool _acak = true;

        public frmMPRBeliBrowser()
        {
            InitializeComponent();
        }

        private void frmMPRBeliBrowser_Load(object sender, EventArgs e)
        {
           
            lblNamaBarang.Text = "";
            AcakTampilTextBox();
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            rgbTglMPR.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglMPR.ToDate = DateTime.Now;
            rgbTglMPR.Focus();
            AcakTampilHrg();
            //txtInit.Text = GlobalVar.PerusahaanID;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataReturBeli();
        }

        private void rgbTglRQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void RefreshDataReturBeli()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtHeader = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_ReturPembelian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglMPR.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglMPR.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPers", SqlDbType.VarChar, txtInit.Text));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                    dataGridHeader.DataSource = dtHeader;
                }
                if (dataGridHeader.Rows.Count == 0)
                {
                    dataGridDetail.DataSource = null;
                    lblNamaBarang.Text = "";
                    AcakTampilTextBox();
                }
                else
                {
                    RefreshDataReturBeliDetail();
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

        public void RefreshDataReturBeliDetail()
        {
            Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPembelianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                }
                dataGridDetail.DataSource = dtDetail;

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

        private void cmdADD_Click(object sender, EventArgs e)
        {

            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    Pembelian.frmMPRBeliUpdate ifrmChild = new Pembelian.frmMPRBeliUpdate(this);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                    break;
                case enumSelectedGrid.DetailSelected:
                    try
                    {

                        if (!CekAddEditDelDetail("add"))
                        {
                            return;
                        }
                        if (int.Parse(dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) > 0 && !SecurityManager.IsManager())
                        {
                            if (!SecurityManager.AskPasswordManager())
                            {
                                return;
                            }
                        }
                        //GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value;
                        //if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value <= GlobalVar.LastClosingDate)
                        //{
                        //    throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        //}

                        Guid rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        Pembelian.frmMPRBeliDetailUpdate ifrmChild2 = new Pembelian.frmMPRBeliDetailUpdate(this, rowID);
                        ifrmChild2.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild2);
                        ifrmChild2.Show();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    break;
            }
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            Guid rowID;
            try
            {

                //int a = 0;
                //a = Convert.ToInt32(Tools.isNull(dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value,"0"));
                bool Closing = false;
                
                GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value;
                Closing = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value < GlobalVar.LastClosingDate ? true : false;
               
             
             
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        if (((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value < GlobalVar.LastClosingDate) )
                        {
                            throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }

                        if (!CekEditDelHeader("edit"))
                        {
                            return;
                        }
                        if (int.Parse(dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) > 0 && !SecurityManager.IsManager())
                        {
                            if (!SecurityManager.AskPasswordManager())
                            {
                                return;
                            }
                        }

                        rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        Pembelian.frmMPRBeliUpdate ifrmChild = new Pembelian.frmMPRBeliUpdate(this, rowID,Closing);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                        break;
                    case enumSelectedGrid.DetailSelected:
                       

                        if (!CekAddEditDelDetail("edit"))
                        {
                            return;
                        }
                        if (int.Parse(dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) > 0)
                        {
                            if (!SecurityManager.AskPasswordManager())
                            {
                                return;
                            }
                        }
                        if (((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value < GlobalVar.LastClosingDate) )
                        {
                            throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }

                        Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        rowID = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                        Guid notaID = Guid.Empty;
                        if (dataGridDetail.SelectedCells[0].OwningRow.Cells["KodeRetur"].Value.ToString() == "1")
                        {
                            if (dataGridDetail.SelectedCells[0].OwningRow.Cells["NotaBeliDetailID"].Value.ToString() != "")
                                notaID = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["NotaBeliDetailID"].Value;
                        }
                        Pembelian.frmMPRBeliDetailUpdate ifrmChild2 = new Pembelian.frmMPRBeliDetailUpdate(this, headerID, rowID, notaID);
                        ifrmChild2.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild2);
                        ifrmChild2.Show();
                        break;
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

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            Guid rowID;
            try
            {
                GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value;
                //if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value <= GlobalVar.LastClosingDate)
                //{
                //    //throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate.ToString("dd MMM yyyy")));
                //    MessageBox.Show("Periode transaksi sampai tanggal " + GlobalVar.LastClosingDate.ToString("dd MMM yyyy") + " sudah diclosing");
                //}

                if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value <= GlobalVar.LastClosingDate)
                {
                    //throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate.ToString("dd MMM yyyy")));
                    MessageBox.Show("Periode transaksi sampai tanggal " + GlobalVar.LastClosingDate.ToString("dd MMM yyyy") + " sudah diclosing");
                }
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        if (!CekEditDelHeader("del"))
                        {
                            return;
                        }
                        if (int.Parse(dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) > 0 && !SecurityManager.IsManager())
                        {
                            if (!SecurityManager.AskPasswordManager())
                            {
                                return;
                            }
                        }

                        rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_ReturPembelian_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            MessageBox.Show("Record telah dihapus");
                            RefreshDataReturBeli();

                        }
                        break;
                    case enumSelectedGrid.DetailSelected:
                        if (!CekAddEditDelDetail("del"))
                        {
                            return;
                        }
                        if (int.Parse(dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) > 0 && !SecurityManager.IsManager())
                        {
                            if (!SecurityManager.AskPasswordManager())
                            {
                                return;
                            }
                        }

                        rowID = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                        string kodeRetur = dataGridDetail.SelectedCells[0].OwningRow.Cells["KodeRetur"].Value.ToString();
                        if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_ReturPembelianDetail_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeRetur", SqlDbType.VarChar, kodeRetur));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            MessageBox.Show("Record telah dihapus");
                            RefreshDataReturBeliDetail();

                        }
                        break;
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

        private bool CekEditDelHeader(string tag)
        {
            // tag = 'del' / 'edit'
            bool cek = true;

            if (dataGridHeader.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                cek = false;
                goto SelesaiCek;
            }
            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["ReturID"].Value.ToString().Substring(0, 3)
                != GlobalVar.PerusahaanID)
            {
                MessageBox.Show("Hanya untuk cabang " + GlobalVar.PerusahaanID);
                cek = false;
                goto SelesaiCek;
            }
            //if (dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString() == "2")
            //{ 
            //    ***ASK PASWORD MANAGER***
            //}
            if (tag == "del" && dataGridDetail.Rows.Count != 0)
            {
                MessageBox.Show("Untuk hapus header..." + System.Environment.NewLine + "hapus detail terlebih dahulu.");
                cek = false;
                goto SelesaiCek;
            }

        SelesaiCek:
            return cek; 
        }

        private bool CekAddEditDelDetail(string tag)
        {
            // tag = 'del' / 'edit' / 'add'
            bool cek = true;

            if (dataGridHeader.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                cek = false;
                goto SelesaiCek;
            }
            if (dataGridDetail.SelectedCells.Count == 0 && tag != "add")
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                cek = false;
                goto SelesaiCek;
            }

            DateTime Mbrptgl = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value;// (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value; //Convert.ToDateTime(dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value);
            if ( Mbrptgl != GlobalVar.DateOfServer)
            {
                MessageBox.Show("Tgl MPRB tidak sama dengan datetime server");
                cek = false;
                goto SelesaiCek;
            }

        SelesaiCek:
            return cek; 
        }

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void dataGridDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.F3:
                    if (!SecurityManager.IsAuditor())
                    {
                        CetakMPRBeli();
                        IncreamentNPrint();
                    }
                    break;
                case Keys.Tab:
                    selectedGrid = enumSelectedGrid.DetailSelected;
                    dataGridDetail.Focus();
                    break;
            }
        }

        private void CetakMPRBeli()
        {
            if (dataGridHeader.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }
            if (dataGridDetail.RowCount == 0)
            {
                MessageBox.Show("Tidak ada detail retur");
                return;
            }
            if (dataGridDetail.SelectedCells[0].OwningRow.Cells["KodeGudang"].Value.ToString() != GlobalVar.Gudang)
            {
                MessageBox.Show("Hanya untuk gudang " + GlobalVar.Gudang);
                return;
            }
            //if (dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString() == "2")
            //{
            //    ***ASK PASSWORD MANAGER***
            //}
            if (int.Parse(dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) > 0 && !SecurityManager.IsManager())
            {
                if (!SecurityManager.AskPasswordManager())
                {
                    return;
                }
            }

            Guid rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPembelianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rowID));

                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                    return;
                }
                else
                {
                    DisplayReportMprb(dt);
                    //PrintRawSPPB(dt);
                    //PrintReport(dt);
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

        private void PrintReport(DataTable dt)
        {
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("KodeGudang", GlobalVar.Gudang));
            
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptCetakMPRBeli.rdlc", rptParams, dt, "dsReturPembelian_Data");
            ifrmReport.Show();
            //ifrmReport.Print();
        }

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.Tab:
                    selectedGrid = enumSelectedGrid.HeaderSelected;
                    dataGridHeader.Focus();
                    break;
            }
        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridHeader.RowCount>0)
            {
                double _nilaiRetur = double.Parse(dataGridHeader.Rows[e.RowIndex].Cells["NilaiRetur"].Value.ToString());

                dataGridHeader.Rows[e.RowIndex].Cells["NilaiRetur"].Style.Format = "#,##0";

                dataGridHeader.Rows[e.RowIndex].Cells["NilaiReturAck"].Value = Tools.GetAntiNumeric(_nilaiRetur.ToString("#,##0"));

                dataGridHeader.Rows[e.RowIndex].Cells["NilaiReturAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            
        }

        private void dataGridDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridDetail.RowCount>0)
            {
                double _hrgBeli = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["HrgBeli"].Value.ToString());
                double _jmlHrgRet = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgRetur"].Value.ToString());

                dataGridDetail.Rows[e.RowIndex].Cells["HrgBeli"].Style.Format = "#,##0";
                dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgRetur"].Style.Format = "#,##0";

                dataGridDetail.Rows[e.RowIndex].Cells["HrgBeliAck"].Value = Tools.GetAntiNumeric(_hrgBeli.ToString("#,##0"));
                dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgReturAck"].Value = Tools.GetAntiNumeric(_jmlHrgRet.ToString("#,##0"));
                //dataGridDetail.Rows[e.RowIndex].Cells["HrgBeliAck"].Value =_hrgBeli.ToString("#,##0");
                //dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgReturAck"].Value = _jmlHrgRet.ToString("#,##0");

                dataGridDetail.Rows[e.RowIndex].Cells["HrgBeliAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgReturAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
           
        }

        private void AcakTampilHrg()
        {
            _acak = !_acak;

            dataGridHeader.Columns["NilaiRetur"].Visible = !_acak;
            dataGridDetail.Columns["HrgBeli"].Visible = !_acak;
            dataGridDetail.Columns["JmlHrgRetur"].Visible = !_acak;

            dataGridHeader.Columns["NilaiReturAck"].Visible = _acak;
            dataGridDetail.Columns["HrgBeliAck"].Visible = _acak;
            dataGridDetail.Columns["JmlHrgReturAck"].Visible = _acak;

            AcakTampilTextBox();

        }

        private void AcakTampilTextBox()
        {
            double nilaiRetur = 0, totPot = 0;
            if (dataGridDetail.RowCount > 0)
            {
                nilaiRetur = double.Parse(dtDetail.Compute("SUM(JmlHrgRetur)", string.Empty).ToString());
                totPot = double.Parse(dtDetail.Compute("SUM(Pot)", string.Empty).ToString());
            }

            if (_acak)
            {
                txtNilaiRetur.Text = Tools.GetAntiNumeric(nilaiRetur.ToString("#,##0"));
                txtTotalPot.Text = Tools.GetAntiNumeric(totPot.ToString("#,##0"));
            }
            else
            {
                txtNilaiRetur.Text = nilaiRetur.ToString("#,##0");
                txtTotalPot.Text = totPot.ToString("#,##0");
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridHeader.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridDetail.FindRow(columnName, value);
        }


        private void PrintRawSPPB(DataTable dt)
        {

            BuildString sppb = new BuildString();
            int No = 0;

            #region "Header"
            string NoMPR_ = dt.Rows[0]["NoMPR"].ToString();
            string TglKirim_ = DateTime.Parse(dt.Rows[0]["TglKirim"].ToString()).ToString("dd-MMM-yyyy");
            string TglMPR_ = DateTime.Parse(dt.Rows[0]["TglMPR"].ToString()).ToString("dd-MMM-yyyy");
            string KodeGudang_ = dt.Rows[0]["KodeGudang"].ToString();

            sppb.Initialize();
            sppb.FontCondensed(false);
            sppb.FontCPI(12);
            sppb.PageLLine(33);
            sppb.LeftMargin(0);
            sppb.FontBold(true);
            sppb.LetterQuality(true);

            sppb.PROW(true, 1, "No.MPR      : "+NoMPR_ + sppb.SPACE(45)+" Tanggal Kirim : "+ TglKirim_);
            sppb.PROW(true, 1, "Tanggal MPR : "+TglMPR_);
            sppb.PROW(true, 1, "");
            sppb.DoubleHeight(true);
            sppb.DoubleWidth(true);

            sppb.FontCPI(12);
            sppb.PROW(true, 1, sppb.SPACE(12) + "MEMO PERMOHONAN RETUR");
            sppb.DoubleHeight(false);
            sppb.DoubleWidth(false);
            sppb.LineSpacing("1/8");
            sppb.PROW(true, 1, " ");
            sppb.PROW(true, 1, "Kepada : 011");
            sppb.PROW(true, 1, "Dari   : "+ KodeGudang_);
            sppb.FontCPI(15);

            sppb.PROW(true, 1, sppb.PrintDoubleLine(119));
            sppb.PROW(true, 1, "No. N a m a   B a r a n g                                                     Sat Qty    Harga       Alasan Retur      ");
            sppb.PROW(true, 1, sppb.PrintHorizontalLine(119));
         
            #endregion

            #region "Detail"
            string temp = string.Empty;
            string namaStok_ = string.Empty;
            string asalNota_ = string.Empty;
            string satuan_ = string.Empty;
            string catatan_ = string.Empty;
            int QtyTerima_ = 0;
            double HrgBeli_ = 0;

            foreach (DataRow dr in dt.Rows)
            {
                No++;
                temp = string.Empty;
                namaStok_ = dr["NamaBarang"].ToString();
                satuan_ = dr["Satuan"].ToString();
                catatan_ = dr["Catatan"].ToString();
                QtyTerima_ = int.Parse(dr["QtyTerima"].ToString());
                HrgBeli_ = Convert.ToDouble(Tools.isNull(dr["HrgBeli"], "0").ToString());

                temp += No.ToString().PadLeft(2, '0') + ".  ";
                temp += namaStok_.PadRight(73, '.') + sppb.SPACE(1);
                temp += satuan_.PadRight(3, ' ') + sppb.SPACE(1);
                temp += QtyTerima_.ToString().PadLeft(3, ' ') + sppb.SPACE(1);
                temp += Tools.GetAntiNumeric(HrgBeli_.ToString("#,##0")).PadLeft(9, ' ')
                    + sppb.SPACE(1);
                temp += catatan_;
                sppb.PROW(true, 1, temp);
            }

            No++;
            for (int i = No; i <= 15; i++)
            {
                sppb.PROW(true, 1, i.ToString().PadLeft(2, '0') + ". ");
            }

            #endregion

            #region "Footer"
            sppb.PROW(true, 1, sppb.PrintDoubleLine(119));
            sppb.PROW(true, 1, "");
            sppb.PROW(true, 1, "   Dibuat oleh              Checker 1              Checker 2           Ka.Operasional            Penerima  ");
            sppb.PROW(true, 1, "");
            sppb.PROW(true, 1, "");
            sppb.PROW(true, 1, "");
            sppb.PROW(true, 1, "  (            )          (           )          (           )          (           )          (           )");
            sppb.Eject();
            #endregion


            sppb.SendToPrinter("sppb.txt");
        }

        private void IncreamentNPrint()
        {
            int Nprint_ = 0;
            Nprint_ = (int)dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value;
            Nprint_++;
            dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value = Nprint_.ToString();
            this.dataGridHeader.RefreshEdit();
            this.simpanNprint(Nprint_);
        }

        private void simpanNprint(int N)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                Guid rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_ReturPembelian_UPDATE_Print]"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, N));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
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

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                    RefreshDataReturBeliDetail();
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

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (!SecurityManager.IsAuditor())
            {
                
                CetakMPRBeli();
                IncreamentNPrint();
            }

        }

        public void DisplayReportMprb(DataTable dt)
        {
            try
            {
                //getdataheader();

                object sumObject;
                sumObject = dt.Compute("Sum(JmlHrgRetur)", "");
                Double Total = Convert.ToDouble(sumObject);
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("NoMPRB_", dataGridHeader.SelectedCells[0].OwningRow.Cells[NoMPR.Name].Value.ToString()));
                rptParams.Add(new ReportParameter("TglKirim_", dataGridHeader.SelectedCells[0].OwningRow.Cells[TglKirim.Name].Value.ToString()));
                rptParams.Add(new ReportParameter("TglMPRB_", dataGridHeader.SelectedCells[0].OwningRow.Cells[TglKeluar.Name].Value.ToString()));
                rptParams.Add(new ReportParameter("Pemasok_", dataGridHeader.SelectedCells[0].OwningRow.Cells[Pemasok.Name].Value.ToString()));
                rptParams.Add(new ReportParameter("JumlahTotal", Total.ToString()));
                rptParams.Add(new ReportParameter("footer", string.Format("{0:dddd, dd MMM yyyy HH:mm:ss}", DateTime.Now) + ", " + SecurityManager.UserName));

                frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptDOCetakMprbPembelian.rdlc", rptParams, dt, "dsReturPembelian_Data");
                //ifrmReport.Show();
                ifrmReport.Print();
                frmReportViewer ifrmReportWatermark = new frmReportViewer("Pembelian.rptDOCetakMprbPembelianWatermark.rdlc", rptParams, dt, "dsReturPembelian_Data");
                //ifrmReport.Show();
                ifrmReportWatermark.Print();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                bool Closing = false;

                GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value;
                Closing = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value < GlobalVar.LastClosingDate ? true : false;

                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKirim"].Value.ToString() != "")
                {
                    if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKirim"].Value != GlobalVar.DateOfServer)
                    {
                        MessageBox.Show("TglKirim sudah terisi dan tidak sama dengan datetime server");
                        return;
                    }
                    
                }
                Guid rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                Pembelian.frmMPRBeliUpdate ifrmChild = new Pembelian.frmMPRBeliUpdate(this, rowID, Closing,"edit tgl kirim");
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

    }
}
