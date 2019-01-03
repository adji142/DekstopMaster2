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

namespace ISA.Toko.ArusStock
{
    public partial class frmBarangKeluar : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;

        #region "Var & Procedure"
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;

        //For Header
        Guid _RowID;
        string _RecordID;

        //For Detail
        Guid _RowIDD, _HeaderIDD;

        #region "Function"
        public void FillHeader()
        {
            _RowID = (Guid)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            _RecordID = dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
        }

        public void FillDetail()
        {
            _HeaderIDD = _RowID;
            _RowIDD = (Guid)dataGridPeminjamanDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value;
        }
        public void RefreshHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtP = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Peminjaman_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglDO.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPers", SqlDbType.VarChar, txtInit.Text));
                    dtP = db.Commands[0].ExecuteDataTable();
                    this.dataGridPeminjaman.DataSource = dtP;

                }

                if (dataGridPeminjaman.SelectedCells.Count > 0)
                {
                    RefreshDetail();
                }
                else
                {
                    dataGridPeminjamanDetail.DataSource = null;
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

        public void RefreshDetail()
        {
            try
            {

                _HeaderIDD = (Guid)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtPD = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PeminjamanDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderIDD));
                    dtPD = db.Commands[0].ExecuteDataTable();
                    this.dataGridPeminjamanDetail.DataSource = dtPD;
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

        private void DisplayReport(DataTable dt)
        {

            //construct parameter
            // periode = String.Format("{0} s/d {1}", ((DateTime)rgbTglDO.FromDate.Value).ToString("dd/MM/yyyy"), ((DateTime)rgbTglDO.ToDate.Value).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            // rptParams.Add(new ReportParameter("Periode", periode));

            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("ArusStock.rptBuktiPeminjamanBarang.rdlc", rptParams, dt, "dsPinjam_Data");
            ifrmReport.Show();

        }

        private void PrintOut()
        {
            try
            {
                _RowID = (Guid)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                this.Cursor = Cursors.WaitCursor;
                DataTable dtPD = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("rsp_Peminjaman"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@QtyKeluarGudang", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    dtPD = db.Commands[0].ExecuteDataTable();

                    //DisplayReport(dtPD);

                }
                if (dtPD.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Data" + System.Environment.NewLine + "Isi Qty Keluar Dahulu(F12) !!");
                    return;
                }
                PrintRawBarangKeluar(dtPD);
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

        private void PrintRawBarangKeluar(DataTable dt)
        {
            BuildString barangKeluar = new BuildString();

            string sales = dt.Rows[0]["Sales"].ToString().PadRight(23);
            string tglKeluar = DateTime.Parse(dt.Rows[0]["TglKeluar"].ToString()).ToString("dd-MMM-yyyy");
            string tglBatas = DateTime.Parse(dt.Rows[0]["TglBatas"].ToString()).ToString("dd-MMM-yyyy");
            string noBukti = dt.Rows[0]["NoBukti"].ToString();
            string penjamin = dt.Rows[0]["Penjamin"].ToString().PadRight(10);
            string catatan = dt.Rows[0]["CatatanH"].ToString();
            int No = 0;

            barangKeluar.Initialize();
            barangKeluar.PageLLine(33);
            barangKeluar.FontCPI(12);
            barangKeluar.Append(Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)1));
            barangKeluar.PROW(true, 1, barangKeluar.PadCenter(88, "BUKTI PEMINJAMAN BARANG"));
            barangKeluar.PROW(true, 1, "");
            barangKeluar.PROW(true, 1, "Nama salesman : " + sales + barangKeluar.SPACE(12) + "Tanggal pinjam        : " + tglKeluar);
            barangKeluar.PROW(true, 1, "Nomor pinjam  : " + noBukti.PadRight(10) + barangKeluar.SPACE(25) + "Batas tanggal pinjam  : " + tglBatas);
            barangKeluar.PROW(true, 1, "Penjamin      : " + penjamin);
            barangKeluar.PROW(true, 1, barangKeluar.PrintEqualSymbol(88));
            barangKeluar.PROW(true, 1, "No                                   Nama Barang                                 Qty");
            barangKeluar.PROW(true, 1, barangKeluar.PrintMinusSymbol(88));

            string namaStok = string.Empty;
            int qtyKeluarGudang = 0;

            foreach (DataRow dr in dt.Rows)
            {
                No++;
                namaStok = dr["NamaStok"].ToString().PadRight(73);
                qtyKeluarGudang = int.Parse(dr["QtyKeluarGudang"].ToString());

                barangKeluar.PROW(true, 1, No.ToString().PadLeft(2) + " " + namaStok + barangKeluar.SPACE(5) + qtyKeluarGudang.ToString().PadLeft(3));
            }
            barangKeluar.PROW(true, 1, barangKeluar.PrintEqualSymbol(88));
            barangKeluar.PROW(true, 1, "Catatan : " + catatan);
            barangKeluar.PROW(true, 1, "");
            barangKeluar.PROW(true, 1, "");
            barangKeluar.PROW(true, 1, "                   Penjualan                                Peminjam");
            barangKeluar.Eject();

            barangKeluar.SendToPrinter("BarangKeluar.txt");
        }

        private void IsiQty()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {



                    db.Commands.Add(db.CreateCommand("usp_PeminjamanDetail_UPDATE"));

                    for (int i = 0; i < dataGridPeminjamanDetail.Rows.Count; i++)
                    {

                        Guid _rowid = (Guid)dataGridPeminjamanDetail.Rows[i].Cells["RowIDD"].Value;
                        int _qtymemo = (int)dataGridPeminjamanDetail.Rows[i].Cells["QtyMemo"].Value;
                        string _catatan = dataGridPeminjamanDetail.Rows[i].Cells["CatatanD"].Value.ToString();
                        string _kodeBarang = dataGridPeminjamanDetail.Rows[i].Cells["KodeBarang"].Value.ToString();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowid));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyMemo", SqlDbType.Int, _qtymemo));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyKeluarGudang", SqlDbType.Int, _qtymemo));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, _catatan));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, _kodeBarang));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                    }



                    RefreshDetail();


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
        #endregion
        #endregion
        public frmBarangKeluar()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rgbTglDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void frmBarangKeluar_Load(object sender, EventArgs e)
        {
            dataGridPeminjaman.AutoGenerateColumns = false;
            dataGridPeminjamanDetail.AutoGenerateColumns = false;
            selectedGrid = enumSelectedGrid.HeaderSelected;
            rgbTglDO.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtInit.Text = GlobalVar.PerusahaanID;
            rgbTglDO.ToDate = DateTime.Now;
        }

        private void dataGridPeminjaman_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
            if (dataGridPeminjaman.SelectedCells.Count > 0)
            {
                FillHeader();
            }
        }

        private void dataGridPeminjamanDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
            if (dataGridPeminjamanDetail.SelectedCells.Count > 0)
            {
                FillDetail();
            }
        }

        

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshHeader();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.DetailSelected:
                    try
                    {
                        GlobalVar.LastClosingDate = (DateTime)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value;
                        if ((DateTime)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        if (dataGridPeminjamanDetail.SelectedCells.Count > 0)
                        {
                            if (Convert.ToInt32(dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["NPrint"].Value) > 2 || dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString() == "1")
                            {
                                if (!SecurityManager.AskPasswordManager())
                                {
                                    return;
                                }
                            }
                            ArusStock.frmBarangKeluarUpdate ifrmChild = new ArusStock.frmBarangKeluarUpdate(this, _RowIDD);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    break;
                case enumSelectedGrid.HeaderSelected:
                    if (dataGridPeminjaman.SelectedCells.Count > 0)
                    {
                        dataGridPeminjaman.Focus();
                    }

                    break;
            }
        }

        private void dataGridPeminjaman_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridPeminjaman.SelectedCells.Count > 0)
            {
                if (e.KeyCode == Keys.F3)
                {
                    if (!SecurityManager.IsAuditor())
                    {
                        if (Convert.ToInt32(dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["NPrint"].Value) >= 2)
                        {
                            if (!SecurityManager.AskPasswordManager())
                            {
                                return;
                            }
                        }

                        PrintOut();
                        RefreshHeader();
                    }
                }

                if (e.KeyCode == Keys.F12)
                {
                    if (!SecurityManager.IsAuditor())
                    {
                        try
                        {
                            GlobalVar.LastClosingDate = (DateTime)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value;
                            if ((DateTime)dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["TglKeluar"].Value <= GlobalVar.LastClosingDate)
                            {
                                throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                            }
                            if (Convert.ToInt32(dataGridPeminjaman.SelectedCells[0].OwningRow.Cells["NPrint"].Value) != 1)
                            {
                                if (!SecurityManager.AskPasswordManager())
                                {
                                    return;
                                }
                            }
                            IsiQty();
                            RefreshDetail();
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }
                }
            }
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridPeminjaman.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridPeminjamanDetail.FindRow(columnName, value);
        }

        private void dataGridPeminjaman_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridPeminjaman.SelectedCells.Count > 0)
            {
                FillHeader();
                RefreshDetail();

            }
        }

    }
}
