using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using System.IO;
using ISA.Trading.Class;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.ComponentModel;
using ISA.Utility;
 
namespace ISA.Trading.Penjualan
{
    public partial class TabelDO : ISA.Trading.BaseForm
    {
        enum enumSelectedGrid { DOSelected, DetailDOSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.DOSelected;
        DataTable dtDO , dtDetailDO ;
        bool _acak;
        int _nCetak;
        DateTime _fromDate, _toDate;
        double JmlHrgTot = 0.00, HrgNetTot = 0.00, JmlHPPTot = 0.00, JmlPotTot = 0.00;
        string StatausToko_ = string.Empty;
        string fileName1 = "Htjtmp";
        string fileName2 = "Dtjtmp";
        string cKlp = string.Empty;
        string PrnAktif = "0";
        bool TokoDisp = false;
        Guid _doID;

        DateTime _tglDO;
        string _kodeToko;
        string _TrType;
        string _barangID;
        string flagkg = "";
        double HrgJual_ = 0;

        public TabelDO()
        {
            InitializeComponent();
            
        }

        private void frmDOBrowse_Load(object sender, EventArgs e)
        {
            this.Title = "DO";
            this.Text = "Penjualan";
            _acak = true;
            AcakTampilTextBox();
            lblBarang.Text = "";
            dataGridDO.AutoGenerateColumns = false;
            dataGridDetailDO.AutoGenerateColumns = false;
            gvPopUploadResult.AutoGenerateColumns = false;
            _fromDate = DateTime.Now;
            _toDate = DateTime.Now;
            rgbTglDO.FromDate = _fromDate;
            rgbTglDO.ToDate = _toDate;
            rgbTglDO.Focus();
            dataGridDetailDO.GenerateRowNumber = true;
            dataGridDO.GenerateRowNumber = true;
            cmdSearch_Click(sender, e);
          
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataDO();
            dataGridDO.Focus();
            selectedGrid = enumSelectedGrid.DOSelected;
            
        }

        private void rgbTglDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void RefreshDataDO()
        {
            _fromDate = (DateTime)rgbTglDO.FromDate;
            _toDate = (DateTime)rgbTglDO.ToDate;
            
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtDO = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST_FILTER_TglDO")); 
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    dtDO = db.Commands[0].ExecuteDataTable();
                }
                //DataColumn cNoDOAndFlag = new DataColumn("NoDOAndFlag", Type.GetType("System.String"));
                //cNoDOAndFlag.Expression = "NoDO + ' ' + FlagDO";
                //dtDO.Columns.Add(cNoDOAndFlag);
                dtDO.DefaultView.Sort = "TglDO, NoDOAndFlag";
                dataGridDO.DataSource = dtDO.DefaultView;

                if (dataGridDO.SelectedCells.Count > 0)
                {
                    RefreshDataDetailDO();
                    lblToko.Text = "\"" + dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + "\" "
                        + dataGridDO.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString();
                    dataGridDO.Focus();
                }
                else
                {
                    dataGridDetailDO.DataSource = null;
                    lblToko.Text = " ";
                    txtJumlahHarga2.Text = "";
                    txtJumlahPotongan2.Text = "";
                    txtHargaNett2.Text = "";
                    txtJumlahHPP2.Text = "";
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

        public void RefreshRowDataDO(string _rowID)
        {
            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST_FILTER_RowID"));//udah heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier , rowID));                    
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridDO.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());

                    if (dataGridDO.SelectedCells.Count > 0)
                    {
                        RefreshDataDetailDO();
                        lblToko.Text = "\"" + dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + "\" "
                            + dataGridDO.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString();
                        dataGridDO.Focus();
                    }
                    else
                    {
                        dataGridDetailDO.DataSource = null;
                        lblToko.Text = " ";
                        txtJumlahHarga2.Text = "";
                        txtJumlahPotongan2.Text = "";
                        txtHargaNett2.Text = "";
                        txtJumlahHPP2.Text = "";
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


        //public void refreshBarangPromo()
        //{

        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        using (Database db = new Database())
        //        {
                    
        //            Guid _headerID = (Guid) dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
        //            DateTime _TglDO = (DateTime) dataGridDO.SelectedCells[0].OwningRow.Cells["TglDO"].Value ;
                    
        //            db.Commands.Add(db.CreateCommand("usp_cek_barang_promo"));  
        //            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
        //            db.Commands[0].Parameters.Add(new Parameter("@datePro", SqlDbType.DateTime, _TglDO));
        //            db.Commands[0].Parameters.Add(new Parameter("@user", SqlDbType.VarChar, SecurityManager.UserID));
                    
        //            db.Commands[0].ExecuteDataTable();
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        Error.LogError(ex);
        //    }
        //    finally
        //    {
        //        this.Cursor = Cursors.Default;
        //    }
        //}

        public void RefreshDataDetailDO()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    dtDetailDO = new DataTable();
                    Guid _headerID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST_FILTER_HEADERID")); // udah heri
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtDetailDO = db.Commands[0].ExecuteDataTable();
                }
               
              
                dtDetailDO.DefaultView.Sort = "RecordID";
                dataGridDetailDO.DataSource = dtDetailDO;

                if (dataGridDetailDO.SelectedCells.Count > 0)
                {
                    lblBarang.Text = dataGridDetailDO.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();

                    // Selalu update RpJual dan RpNet di Header, untuk antisipasi perubahan pada detail
                    // Contoh: setelah batal do detail QtyDO berubah maka RpJual dan RpNet di Header juga berubah
                    dataGridDO.SelectedCells[0].OwningRow.Cells["RpJual"].Value = dtDetailDO.Compute("SUM(JmlHrg)", string.Empty);
                    dataGridDO.SelectedCells[0].OwningRow.Cells["RpNet"].Value = dtDetailDO.Compute("SUM(HrgNet)", string.Empty);
                    
                  
                }
                else
                {
                    lblBarang.Text = " ";

                    dataGridDO.SelectedCells[0].OwningRow.Cells["RpJual"].Value = 0;
                    dataGridDO.SelectedCells[0].OwningRow.Cells["RpNet"].Value = 0;
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

        public void RefreshRowDataDetailDO(string _rowID)
        {
            

            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST"));//udah heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }
               
                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridDetailDO.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
                } 
                
                if (dataGridDetailDO.SelectedCells.Count > 0)
                {
                    lblBarang.Text = dataGridDetailDO.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();

                    // Selalu update RpJual dan RpNet di Header, untuk antisipasi perubahan pada detail
                    // Contoh: setelah batal do detail QtyDO berubah maka RpJual dan RpNet di Header juga berubah
                    dataGridDO.SelectedCells[0].OwningRow.Cells["RpJual"].Value = dtDetailDO.Compute("SUM(JmlHrg)", string.Empty);
                    dataGridDO.SelectedCells[0].OwningRow.Cells["RpNet"].Value = dtDetailDO.Compute("SUM(HrgNet)", string.Empty);
                }
                else
                {
                    lblBarang.Text = " ";

                    dataGridDO.SelectedCells[0].OwningRow.Cells["RpJual"].Value = 0;
                    dataGridDO.SelectedCells[0].OwningRow.Cells["RpNet"].Value = 0;
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

        private void dataGridDO_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DOSelected;
        }

        private void dataGridDetailDO_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailDOSelected;
        }

        private void CekCetakDO()
        {
            string headerRecID = dataGridDO.SelectedCells[0].OwningRow.Cells["HtrID"].Value.ToString();
            string cab1 = dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang1"].Value.ToString();
            string cab2 = dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang2"].Value.ToString();
            string rpNet =  dataGridDO.SelectedCells[0].OwningRow.Cells["RpNet"].Value.ToString();
            string nprint = dataGridDO.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString();
            string nodo = dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString();
            string cekso = dataGridDO.SelectedCells[0].OwningRow.Cells["CekSO"].Value.ToString();
            string Trtype = dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value.ToString().Substring(0,1);

            StatausToko_ = dataGridDO.SelectedCells[0].OwningRow.Cells["StsToko"].Value.ToString().Trim();

            if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2808")
            {
                if (cekso.ToString() != "1" && Trtype == "K")
                {
                    MessageBox.Show("Belum Cek SO..!!");
                    return;
                }
            }
            if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString().Contains(":"))
            {
                MessageBox.Show("Data sudah diUpload ke 11. Tidak bisa di cetak");
                return;
            }
            if (CekNota("@cekTolak"))
            {
                MessageBox.Show("DO Ini tidak bisa di cetak karena di tolak piutang");
                return;
            }

            if (GlobalVar.CabangID == cab1 && GlobalVar.CabangID != cab2)
            {
                MessageBox.Show("DO ini tidak bisa di cetak karena DO AntarCabang");
                return;
            }

            if (double.Parse(rpNet) == 0 && dataGridDetailDO.RowCount == 0)
            {
                MessageBox.Show("DO belum ada nilainya jangan dicetak");
                return;
            }

            string jenisTransaksi = Convert.ToString(dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value);
            string kodeToko = Convert.ToString(dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value);
            string kodeSales = Convert.ToString(dataGridDO.SelectedCells[0].OwningRow.Cells["KodeSales"].Value);
            
            _doID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;

            if (cab1==GlobalVar.CabangID)
            {
                if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2808")
                {
                    #region ditutup karena sudah ada divalidasi sebelumnya
                    //#region overdue FB
                    ////Overdue BE akan berpengaruh terhadap transaksi BE saja
                    //if (jenisTransaksi == "K2" || jenisTransaksi == "K4")
                    //{
                    //    if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value.ToString() == "OVDFB" ||
                    //        dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString() == "OVDFB")
                    //    {
                    //        if (TokoOverdue.OverdueFB(kodeToko) > 0)
                    //        {
                    //            MessageBox.Show("Toko atas DO ini mempunyai OverdueFB, Ajukan Laporan Pengajuan Overdue");
                    //            Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFB, "Cegatan Overdue FB " + nodo);
                    //            ifrmpin.MdiParent = Program.MainForm;
                    //            Program.MainForm.RegisterChild(ifrmpin);
                    //            ifrmpin.Show();
                    //            return;
                    //        }
                    //        else
                    //        {
                    //            using (Database db = new Database())
                    //            {
                    //                DataTable dt = new DataTable();
                    //                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, PinId.Bagian.OverdueFB));
                    //                db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "LUNAS"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                dt = db.Commands[0].ExecuteDataTable();
                    //                db.Commands[0].ExecuteNonQuery();
                    //            }
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value.ToString() == "OVDFB" ||
                    //        dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString() == "OVDFB")
                    //    {
                    //        MessageBox.Show("Masih ada Overdue Nota FB/FE yang belum lunas");
                    //        return;
                    //    }
                    //}
                    //#endregion 
                    
                    //#region Cek Umur Notafx
                    ////if (jenisTransaksi == "KG" || jenisTransaksi == "KC")
                    ////{
                    ////    double UmurPtgFX = TokoOverdue.HariOverdueFX(kodeSales);
                    ////    if (UmurPtgFX > 30)
                    ////    {
                    ////        MessageBox.Show("Masih ada Nota FX yang belum terbayar lebih dari 30 hari. Harus diselesaikan terlebih dahulu");
                    ////        return;
                    ////    }
                    ////}
                    //#endregion 

                    //#region Overdue FX
                    //if (jenisTransaksi != "K2" && jenisTransaksi != "K4" && jenisTransaksi.ToString().Substring(0,1) != "T")
                    //{
                    //    if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value.ToString() == "OVDFX")
                    //    {
                    //        TokoDisp = false;
                    //        DataTable dtDisp = new DataTable();
                    //        using (Database db = new Database())
                    //        {
                    //            db.Commands.Add(db.CreateCommand("usp_TokoDispensasiOvdFX_LIST"));
                    //            db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodeToko));
                    //            db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, DateTime.Now));
                    //            dtDisp = db.Commands[0].ExecuteDataTable();
                    //            if (dtDisp.Rows.Count > 0)
                    //            {
                    //                TokoDisp = true;
                    //            }
                    //        }
                    //        if (!TokoDisp)
                    //        {
                    //            if (TokoOverdue.OverdueFX(kodeToko) > 0)
                    //            {
                    //                MessageBox.Show("Toko atas DO ini mempunyai OverdueFX..!");
                    //                //Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFX, "Cegatan Overdue FX " + nodo);
                    //                //ifrmpin.MdiParent = Program.MainForm;
                    //                //Program.MainForm.RegisterChild(ifrmpin);
                    //                //ifrmpin.Show();
                    //                return;
                    //                //MessageBox.Show("Toko atas DO ini mempunyai OverdueFX, Segera lunasi overdue FX");
                    //                //return;
                    //            }
                    //            else
                    //            {
                    //                using (Database db = new Database())
                    //                {
                    //                    DataTable dt = new DataTable();
                    //                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                    db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, -1));
                    //                    db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "LUNAS"));
                    //                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                    dt = db.Commands[0].ExecuteDataTable();
                    //                    db.Commands[0].ExecuteNonQuery();
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            using (Database db = new Database())
                    //            {
                    //                DataTable dt = new DataTable();
                    //                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, -1));
                    //                db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "LUNAS"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                dt = db.Commands[0].ExecuteDataTable();
                    //                db.Commands[0].ExecuteNonQuery();
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value.ToString() == "OVDFB" ||
                    //            dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString() == "OVDFB")
                    //        {
                    //            if (TokoOverdue.OverdueFB(kodeToko) > 0)
                    //            {
                    //                MessageBox.Show("Toko atas DO ini mempunyai OverdueFB, Ajukan Laporan Pengajuan Overdue");
                    //                Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFB, "Cegatan Overdue FB " + nodo);
                    //                ifrmpin.MdiParent = Program.MainForm;
                    //                Program.MainForm.RegisterChild(ifrmpin);
                    //                ifrmpin.Show();
                    //                return;
                    //            }
                    //            else
                    //            {
                    //                using (Database db = new Database())
                    //                {
                    //                    DataTable dt = new DataTable();
                    //                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                    db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, PinId.Bagian.OverdueFB));
                    //                    db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "LUNAS"));
                    //                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                    dt = db.Commands[0].ExecuteDataTable();
                    //                    db.Commands[0].ExecuteNonQuery();
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            using (Database db = new Database())
                    //            {
                    //                DataTable dt = new DataTable();
                    //                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, -1));
                    //                db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "LUNAS"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                dt = db.Commands[0].ExecuteDataTable();
                    //                db.Commands[0].ExecuteNonQuery();
                    //            }
                    //        }
                    //    }
                    //}
                    //#endregion 
                    #endregion

                    #region acc barang bonus
                    //Acc Barang Bonus
                    if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value.ToString() == "BONUSAN" ||
                        dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString() == "BONUSAN")
                    {
                        MessageBox.Show("Semua barang dalam DO ini adalah barang bonus." + "\n" +
                            "Silahkan masukan PIN pengajuan bonus terlebih dahulu.");

                        Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.Bonus, "Cegatan Bonus " + nodo);
                        ifrmpin.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmpin);
                        ifrmpin.Show();

                        return;
                    }
                    #endregion

                    #region acc harga
                    //ACC Harga
                    if (CekHargaRendah())
                    {
                        if (jenisTransaksi == "K2" || jenisTransaksi == "K4" || jenisTransaksi.Substring(0,1) == "T")       //jenisTransaksi == "T2" || jenisTransaksi == "T4")   //T2 & T4 tambahan untuk transaksi Tunai di 9x
                        {
                            MessageBox.Show("Harga Jual lebih kecil dari Harga Standar." + "\n" + "Silahkan download ACC harga.");
                        }
                        //else
                        //{
                        //    MessageBox.Show("Harga Jual lebih kecil dari Harga Standar." + "\n" +
                        //        "Silahkan masukan PIN pengajuan harga.");

                        //    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.Harga, "Cegatan Harga " + nodo);
                        //    ifrmpin.MdiParent = Program.MainForm;
                        //    Program.MainForm.RegisterChild(ifrmpin);
                        //    ifrmpin.Show();
                        //}
                        return;
                    }
                    #endregion

                    #region salesbl

                    //if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value.ToString() == "SALESBL")
                    //{
                    //MessageBox.Show("DO ini tidak bisa dicetak karena Sales BL");
                    //Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.SalesBL, "Cegatan Sales BL " + nodo);
                    //ifrmpin.MdiParent = Program.MainForm;
                    //Program.MainForm.RegisterChild(ifrmpin);
                    //ifrmpin.Show();
                    //return;
                    //}
                    #endregion

                    #region over plafon
                    ////Over Plafon
                    //if (GlobalVar.Gudang.ToString().Substring(0, 1) == "9")
                    //{
                    //    if (double.Parse(rpNet) > TokoPlafon.SisaPlafon(kodeToko, jenisTransaksi))
                    //    {
                    //        dataGridDO.SelectedCells[0].OwningRow.Cells[IsOverPlafon.Name].Value = "1";
                    //        MessageBox.Show("Tidak bisa dicetak. Rp Net melebihi Sisa Plafon toko. \n" +
                    //                        "Silahkan melakukan pengajuan plafon ke PS HO \n" +
                    //                        "atau sesuaikan nilai DO-nya sehingga mencukupi sisa plafonnya.");
                    //        return;
                    //        //dataGridDO.SelectedCells[0].OwningRow.Cells["NPrint"].Value = int.Parse(nprint) + 1;
                    //        //MessageBox.Show("Plafon tidak mencukupi");
                    //        //if (MessageBox.Show("Plafon Tidak mencukupi" + System.Environment.NewLine + "Lanjutkan cetak DO ?", "Cetak DO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    //        //{
                    //        //    return;
                    //        //}
                    //    }
                    //    else
                    //    {
                    //        dataGridDO.SelectedCells[0].OwningRow.Cells[IsOverPlafon.Name].Value = string.Empty;
                    //    }
                    //}
                    #endregion

                    #region cetak ulang
                    //Cetak Ulang
                    if (int.Parse(nprint) >= 1)
                    {
                        if (!(SecurityManager.IsManager() || SecurityManager.IsAdministrator() || SecurityManager.HasRight("TRD.CETAK_DO")))
                        {
                            MessageBox.Show(Messages.Error.CetakDONotAuthorized);
                            return;
                        }

                        frmCetakDO ifrmDialog = new frmCetakDO();
                        ifrmDialog.ShowDialog();
                        if (ifrmDialog.DialogResult == DialogResult.OK)
                        {
                            _nCetak = ifrmDialog.Result;
                        }
                        else
                            return;
                    }
                    #endregion

                }
            }

            CetakDO();

            dataGridDO.SelectedCells[0].OwningRow.Cells["NPrint"].Value = 1;    // int.Parse(nprint) + 1;
            dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value = nodo.Substring(0, 7);
            if (int.Parse(nprint)==0)
            {
                dataGridDO.SelectedCells[0].OwningRow.Cells["StsToko"].Value = StatausToko_;
            }
            _nCetak = 0;
            //ChangeSignRQ();
        }


        private void ChangeSign()
        {
            if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoRequest"].Value.ToString().Contains("!") && int.Parse(dataGridDO.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) == 0)
            {
                dataGridDO.SelectedCells[0].OwningRow.Cells["NoRequest"].Style.ForeColor = Color.Red;
                dataGridDO.SelectedCells[0].OwningRow.Cells["NoRequest"].Style.SelectionForeColor = Color.Red;
                dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Style.ForeColor = Color.Red;
                dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Style.SelectionForeColor = Color.Red;
                dataGridDO.Refresh();
                this.Refresh();
                this.Invalidate();
                Application.DoEvents();
            }
        }

        private bool CekToko()
        {
            string kodeToko = dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
            bool tokoExist = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST")); 
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodeToko));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                        tokoExist = true;
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

            return tokoExist;                
        }

        private bool CekHargaRendah()
        {
            bool hargaRendah = false;

            try
            {
                DataRow[] dr;
                dr = dtDetailDO.Select("NoAcc='HARGA' and QtyDO <> 0");
                if (dr.Length > 0)
                {
                    hargaRendah = true;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return hargaRendah;
        }

        private void CetakDO()
        {
            //Tutup sementara
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cekPrinterAktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "DO"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                    PrnAktif = "0";
                else
                    PrnAktif = dt.Rows[0]["Value"].ToString();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            if (PrnAktif == "0")
            {
                Guid rowID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_CetakDO"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No Data or QtyDO = 0");
                        return;
                    }
                    CetakDORaw(dt);
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
            else
            {
                Guid rowID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataSet dts = new DataSet();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_CetakDO_M2"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        dts = db.Commands[0].ExecuteDataSet();
                    }
                    if (dts.Tables.Count == 0)
                    {
                        MessageBox.Show("No Data or QtyDO = 0");
                        return;
                    }
                    DisplayReport(dts, PrnAktif);
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
        
        
        private string CetakHeaderDO(DataTable dt, int nUrut, int nMaxHal, out int nHlm)
        {
            
            BuildString header = new BuildString();

            int nHal = (int)Math.Round((nUrut/18)+ 0.4,0) + 1;
            nHlm = nHal;

            string cat1 = dt.Rows[0]["Catatan1"].ToString();
            string cat3 = dt.Rows[0]["Catatan2"].ToString();
            string sales = GetSales(); 
            string namaToko = dt.Rows[0]["NamaToko"].ToString();
            string cClass = dt.Rows[0]["StsToko"].ToString();
            string DO = dt.Rows[0]["NoDO"].ToString() + " " + header.GetDayName(Convert.ToDateTime(dt.Rows[0]["TglDO"].ToString()).DayOfWeek.ToString()) + ", " + Convert.ToDateTime(dt.Rows[0]["TglDO"].ToString()).ToString("dd-MMM-yyyy");
            string noRq = dt.Rows[0]["NoRequest"].ToString() + " " + header.GetDayName(Convert.ToDateTime(dt.Rows[0]["TglRequest"].ToString()).DayOfWeek.ToString()) + ", " + Convert.ToDateTime(dt.Rows[0]["TglRequest"].ToString()).ToString("dd-MMM-yyyy");
            string alamatKirim = header.Alamat(dt.Rows[0]["Alamat"].ToString().Trim());
            string nSpace = namaToko.Trim() + header.SPACE(namaToko.Trim().Length + (15 - namaToko.Trim().Length) - 7) + cClass;
            string waktu = dt.Rows[0]["HariKredit"].ToString() + " Hari / ";
            string wilID = dt.Rows[0]["WilID"].ToString();
            string daerah = header.Daerah(dt.Rows[0]["Daerah"].ToString()) + "(Wil: " + wilID + ") ";
            string kota = header.Kota(dt.Rows[0]["Kota"].ToString());
            string expedisi = dt.Rows[0]["Expedisi"].ToString();
            string namaExpedisi = dt.Rows[0]["NamaExpedisi"].ToString();
            double plafon = double.Parse(dt.Rows[0]["Plafon"].ToString());
            string grade = dt.Rows[0]["Grade"].ToString();
            string typePrinter = header.GetPrinterName(); //ISA.Trading.LookupInfo.GetValue("PRINTER", "DOT_MATRIX");
            string cKet = header.SPACE(2);
            StatausToko_ = cClass;
            if (_nCetak == 1)
            {
                cKet = "COPY"; 
            }
            else if (_nCetak == 2)
            {
                cKet = "REVISI";
            }
            
            #region Cetak Header
            header.Initialize();
            header.FontCondensed(false);
            header.FontCPI(17);
            header.PageLLine(33);
            header.LeftMargin(1);
            header.BottomMargin(1);
            header.FontCondensed(true);
            if (typePrinter.Contains("LX"))
            {
                header.DoubleHeight(true);
            }
            else
            {
                header.DoubleWidth(true);
            }

            header.PROW(true, 1, "DELIVERY ORDER    (" + nHal.ToString() + "/" + nMaxHal.ToString() + ")" + header.SPACE(3) + cKet);
            header.FontCondensed(false);
            header.DoubleHeight(false);
            header.DoubleWidth(false);
            header.FontCPI(12);
            header.PROW(true, 1, header.Sales(sales));
            header.FontBold(false);
            header.FontItalic(false);
            header.LineSpacing("1/8");
            header.FontItalic(true);
            header.AddCR();
            header.Append(" ");
            header.FontItalic(false);
            header.PROW(false, 53, "ÚÄÄ Pengiriman kepada Toko ÄÄÄÄÄÄÄÄÄÄÄÄÄÄ¿");
            header.PROW(true, 1, cat1.PadRight(47, ' '));
            header.PROW(false, 51, "³                                        ³");
            header.AddCR();
            header.PROW(false, 55, nSpace);
            header.PROW(true, 1, "NOMOR D.O : ");
            header.FontBold(false);
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 13, DO);
            header.FontItalic(false);
            header.PROW(false, 53, "³                                        ³");
            header.FontCondensed(true);
            header.FontItalic(true);
            header.AddCR();
            //header.PROW(false, 92, alamatKirim.Substring(0, 10));
            header.PROW(false, 92, alamatKirim);
            header.FontItalic(false);
            header.FontCondensed(false);
            header.PROW(true, 1, "JK.WAKTU  : ");
            header.FontBold(false);
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 13, waktu + cat3.PadRight(20, ' '));
            header.FontItalic(false);
            header.PROW(false, 53, "³                                        ³");
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 55, daerah);
            header.FontItalic(false);
            header.PROW(true, 1, "NOMOR RQ. : ");
            header.FontBold(false);
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 13, noRq);
            header.FontItalic(false);
            header.PROW(false, 53, "³                                        ³");
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 55, kota);
            header.FontItalic(false);

            header.PROW(true, 1, "EXPEDISI  : ");
            header.FontBold(false);
            header.FontItalic(true);
            if (!expedisi.Equals("SAS"))
            {
                header.PROW(false, 13, expedisi + " (" + namaExpedisi + ")");
            }
            header.FontItalic(false);
            header.PROW(false, 57, "³                               Grade:   ³");
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 55, "PLAFON:" + plafon.ToString("#,###").PadLeft(15, ' '));
            header.FontItalic(false);
            header.PROW(false, 91, header.STR(2, grade));
            header.FontItalic(false);
            header.PROW(true, 1, header.SPACE(50) + "ÀÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÙ");
            header.LetterQuality(false);
            header.FontCondensed(true);
            header.PROW(true, 1, "No. N a m a   B a r a n g                                                     RAK   Dipesan            Dikirim             H.Sat.  Disc./Pot. Jml.Net   Stok");
            header.PROW(true, 1, "ÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ");
            header.LineSpacing("1/6");
            #endregion

            return header.GenerateString();
        }
        
        private void CetakDORaw(DataTable dt)
        {
            BuildString detail = new BuildString();

            int nMaxHal = dt.Rows.Count;
            int nHal = 0;
            int nUrut = 0;
            double x = (nMaxHal/18);
            nMaxHal = nMaxHal % 18 ==0 ? (int)Math.Round(x,0) :(int)(nMaxHal/18) + 1;
            detail.Append(CetakHeaderDO(dt, nUrut, nMaxHal, out nHal));

            #region Cetak Detail
            double nJumlah = 0;

            string NamaStok = string.Empty;
            string KodeRak = string.Empty;
            string Satuan = string.Empty;
            string Dikirim = string.Empty;
            string tempQSisa = string.Empty;
            string JumlahDo = string.Empty;

            int QSisa = 0;
            double Net = 0;

            foreach (DataRow dr in dt.Rows)
            {
                nUrut++;
                NamaStok = dr["NamaBarang"].ToString().PadRight(73, '.');
                KodeRak = detail.STR(7, dr["KodeRak"].ToString());
                Satuan = detail.STR(3, dr["Satuan"].ToString());
                Dikirim = nUrut % 2 == 1 ? detail.STR(3, nUrut.ToString()) + ".[_______]             " : detail.STR(16, nUrut.ToString()) + ".[_______]";
                QSisa = int.Parse(dr["QtySisa"].ToString());
                Net = double.Parse(dr["HrgNet"].ToString());
                JumlahDo = detail.STR(5, dr["QtyDO"].ToString());
                nJumlah = nJumlah + Net;
                tempQSisa = QSisa == 0 ? "      0" : QSisa.ToString("#,###").PadLeft(7, ' ');

                detail.PROW(true, 1, detail.STR(2, nUrut.ToString()) + ". " + NamaStok + " " + KodeRak + " " + JumlahDo + " " + Satuan + Dikirim + detail.SPACE(27) + tempQSisa);

                if ((nUrut % 18 == 0) && (nHal < nMaxHal))
                {
                    detail.PROW(true, 1, "ÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ");
                    detail.PROW(true, 1, "A/R-SAS : " + SecurityManager.UserName + ", Tgl." + DateTime.Now.ToString("dd-MMM-yyy") + " Jam " + DateTime.Now.ToShortTimeString());
                    detail.PROW(true, 1, "");
                    detail.PROW(true, 1, " ");
                    detail.Append("  (     Bag. Piutang     )          (     Bag. Penjualan     )          (     Bag. Gudang     )        (    Bag. Cheker I    )        (   Bag. Cheker II   )");
                    detail.Eject();
                    detail.Append(CetakHeaderDO(dt, nUrut, nMaxHal, out nHal));
                }
            }
            if (nUrut % 18 != 0)
            {
                for (int i = nUrut + 1; i <= nUrut + (18 - (nUrut % 18)); i++)
                {
                    detail.PROW(true, 1, detail.STR(2, i.ToString()) + ". ");
                }
            }
            #endregion

            #region Footer

            detail.LineSpacing("1/8");
            detail.PROW(true, 1, "ÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ");
            detail.PROW(true, 1, "A/R-SAS : " + SecurityManager.UserName + ", Tgl." + DateTime.Now.ToString("dd-MMM-yyy") + " Jam " + DateTime.Now.ToShortTimeString());
            detail.DoubleWidth(true);
            detail.FontItalic(true);
            detail.AddCR();
            detail.PROW(false, 43, "Total D.O ");
            detail.PROW(false, 59, "Rp." + nJumlah.ToString("#,###").PadLeft(14, ' '));
            detail.DoubleWidth(false);
            detail.FontItalic(false);
            detail.PROW(true, 1, "");
            detail.PROW(true, 1, "  (     Bag. Piutang     )          (     Bag. Penjualan     )          (     Bag. Gudang     )        (    Bag. Cheker I    )        (   Bag. Cheker II   )");
            detail.Eject();
            #endregion

            detail.SendToPrinter("do.txt", detail.GenerateString());
            detail.SendToFile("do.txt");

            Application.DoEvents();
            Guid rowID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            this.RefreshDataDO();
            this.FindHeader("RowID", rowID.ToString());
        }

        private void DisplayReport(DataSet dts,string PrnAktif)
        {
            _nCetak = int.Parse(dataGridDO.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString());
            if (_nCetak >= 1)
            {
                frmCetakNota ifrmDialog = new frmCetakNota(this, _nCetak);
                ifrmDialog.ShowDialog();
                if (ifrmDialog.DialogResult == DialogResult.OK)
                {
                    _nCetak = ifrmDialog.Result;
                }
                else
                    return;
            }
            if (_nCetak == 0)
            {
                frmCetakNota ifrmDialog = new frmCetakNota(this, _nCetak);
                ifrmDialog.ShowDialog();
                if (ifrmDialog.DialogResult == DialogResult.OK)
                {
                    _nCetak = ifrmDialog.Result;
                }
                else
                    return;
            }


            string ketDO =  "";
            if (_nCetak == 1)
                ketDO = "COPY";
            if (_nCetak == 2)
                ketDO = "REVISI";

            int jt = 0;
            jt = dts.Tables.Count;

            
            for (int i = 0; i <= jt - 1; i++)
            {
                string NoDO = dts.Tables[0].Rows[0]["NoDO"].ToString();
                string TglDO = dts.Tables[0].Rows[0]["TglDO"].ToString();
                string NoRQ = dts.Tables[0].Rows[0]["NoRequest"].ToString();
                string TglRQ = dts.Tables[0].Rows[0]["TglRequest"].ToString();
                string Expdc = dts.Tables[0].Rows[0]["Expedisi"].ToString();
                string NamaToko = dts.Tables[0].Rows[0]["NamaToko"].ToString();
                string StsToko = dts.Tables[0].Rows[0]["StsToko"].ToString();
                string Alamat = dts.Tables[0].Rows[0]["Alamat"].ToString();
                string Daerah = dts.Tables[0].Rows[0]["Daerah"].ToString();
                string WilID = dts.Tables[0].Rows[0]["WilID"].ToString();
                string Kota = dts.Tables[0].Rows[0]["Kota"].ToString();

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                rptParams.Add(new ReportParameter("Sales", GetSales()));
                rptParams.Add(new ReportParameter("KetDO", ketDO));
                rptParams.Add(new ReportParameter("NoDO", NoDO));
                rptParams.Add(new ReportParameter("TglDO", TglDO));
                rptParams.Add(new ReportParameter("NoRQ", NoRQ));
                rptParams.Add(new ReportParameter("TglRQ", TglRQ));
                rptParams.Add(new ReportParameter("Expedisi", Expdc));
                rptParams.Add(new ReportParameter("NamaToko", NamaToko));
                rptParams.Add(new ReportParameter("StsToko", StsToko));
                rptParams.Add(new ReportParameter("Alamat", Alamat));
                rptParams.Add(new ReportParameter("Daerah", Daerah));
                rptParams.Add(new ReportParameter("WilID", WilID));
                rptParams.Add(new ReportParameter("Kota", Kota));
                rptParams.Add(new ReportParameter("Catatan1", dataGridDO.SelectedCells[0].OwningRow.Cells["Catatan1"].Value.ToString()));
                //rptParams.Add(new ReportParameter("Catatan3", dataGridDO.SelectedCells[0].OwningRow.Cells["Catatan3"].Value.ToString()));
                rptParams.Add(new ReportParameter("JHal", (jt).ToString()));
                rptParams.Add(new ReportParameter("Hal", (i + 1).ToString()));

                int pa = Convert.ToInt32(PrnAktif);

                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptCetakDObaru.rdlc", rptParams, dts.Tables[i], "dsOrderPenjualan_Data");
                ifrmReport.Print();
                //ifrmReport.Show();

                if (pa >= 2)
                {
                    ifrmReport = new frmReportViewer("Penjualan.rptCetakDObaru_copy1.rdlc", rptParams, dts.Tables[i], "dsOrderPenjualan_Data");
                    ifrmReport.Print();
                    //ifrmReport.Show();
                }

                if (pa > 2)
                {
                    ifrmReport = new frmReportViewer("Penjualan.rptCetakDObaru_copy2.rdlc", rptParams, dts.Tables[i], "dsOrderPenjualan_Data");
                    ifrmReport.Print();
                    //ifrmReport.Show();
                }
            }
        }


        private string GetSales()
        {
            string konfersi = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int c1 = int.Parse(dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang1"].Value.ToString()) % 26;
            int c2 = int.Parse(dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang2"].Value.ToString()) % 26;
            string namaSales = dataGridDO.SelectedCells[0].OwningRow.Cells["NamaSales"].Value.ToString();
            if (c1 == 0)
                c1 = 26;
            if (c2 == 0)
                c2 = 26;

            string result = konfersi.Substring(c1-1, 1) + "\\" + konfersi.Substring(c2-1, 1)
                            + "\\" + namaSales;

            return result;
        }

        private void dataGridDO_KeyDown(object sender, KeyEventArgs e)
        {
            string cGud = "";
            string cGudang = GlobalVar.Gudang;
            cGud = cGudang.Substring(0, 1);
            switch (e.KeyCode)
            {
                #region F1 - Mengisi Pin Overdue
                case Keys.F1:
                    string kodeToko = Convert.ToString(dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value);
                    string nodo = dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString();
                    string JnsTR = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value,"").ToString();
                    string NoAccPiut = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value, "").ToString();
                    _doID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                    if (NoAccPiut.Substring(0, 1) != "F")
                    {
                        if (NoAccPiut.Trim() == "OVDFB")
                        {
                            if (TokoOverdue.OverdueFB(kodeToko) > 0)
                            {
                                Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFB, "Cegatan Overdue FB " + nodo);
                                ifrmpin.MdiParent = Program.MainForm;
                                Program.MainForm.RegisterChild(ifrmpin);
                                ifrmpin.Show();
                                return;
                            }
                        }
                        else if (NoAccPiut.Trim() == "OVDFX")
                        {
                            if (TokoOverdue.OverdueFX(kodeToko) > 0)
                            {
                                Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFX, "Cegatan Overdue FX " + nodo);
                                ifrmpin.MdiParent = Program.MainForm;
                                Program.MainForm.RegisterChild(ifrmpin);
                                ifrmpin.Show();
                                return;
                            }
                        }
                    }

                    #region lama
                    ///*Isi Pin Overdue BE*/
                    //if ((JnsTR == "K2" || JnsTR == "K4") && NoAccPiut.Substring(0,1) != "F" )
                    //{
                    //    if (TokoOverdue.OverdueFB(kodeToko) > 0)
                    //    {
                    //        Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFB, "Cegatan Overdue FB " + nodo);
                    //        ifrmpin.MdiParent = Program.MainForm;
                    //        Program.MainForm.RegisterChild(ifrmpin);
                    //        ifrmpin.Show();
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        if (TokoOverdue.OverdueFX(kodeToko) > 0)
                    //        {
                    //            Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFX, "Cegatan Overdue FX " + nodo);
                    //            ifrmpin.MdiParent = Program.MainForm;
                    //            Program.MainForm.RegisterChild(ifrmpin);
                    //            ifrmpin.Show();
                    //            return;
                    //        }
                    //        else
                    //        {
                    //            using (Database db = new Database())
                    //            {
                    //                DataTable dt = new DataTable();
                    //                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, PinId.Bagian.OverdueFB));
                    //                db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "FULLACC"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                dt = db.Commands[0].ExecuteDataTable();
                    //                db.Commands[0].ExecuteNonQuery();
                    //            }
                    //        }
                    //    }
                    //}

                    ///*Isi Pin Overdue FX*/
                    //if (JnsTR != "K2" && JnsTR != "K4" && NoAccPiut.Substring(0,1) != "F")
                    //{
                    //    if (TokoOverdue.OverdueFB(kodeToko) > 0)
                    //    {
                    //        Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFB, "Cegatan Overdue FB " + nodo);
                    //        ifrmpin.MdiParent = Program.MainForm;
                    //        Program.MainForm.RegisterChild(ifrmpin);
                    //        ifrmpin.Show();
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        if (TokoOverdue.OverdueFX(kodeToko) > 0)
                    //        {
                    //            Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFX, "Cegatan Overdue FX " + nodo);
                    //            ifrmpin.MdiParent = Program.MainForm;
                    //            Program.MainForm.RegisterChild(ifrmpin);
                    //            ifrmpin.Show();
                    //            return;
                    //        }
                    //        else
                    //        {
                    //            using (Database db = new Database())
                    //            {
                    //                DataTable dt = new DataTable();
                    //                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, -1));
                    //                db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "FULACC"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                dt = db.Commands[0].ExecuteDataTable();
                    //                db.Commands[0].ExecuteNonQuery();
                    //            }
                    //        }
                    //    }
                    //}
                    #endregion

                    #region kondisi lama
                    //if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value.ToString() == "OVDFX" ||
                    //    dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString() == "OVDFX")
                    //{
                    //    if (TokoOverdue.OverdueFX(kodeToko) > 0)
                    //    {
                    //        //MessageBox.Show("Toko atas DO ini mempunyai OverdueFX..!");
                    //        Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFX, "Cegatan Overdue FX " + nodo);
                    //        ifrmpin.MdiParent = Program.MainForm;
                    //        Program.MainForm.RegisterChild(ifrmpin);
                    //        ifrmpin.Show();
                    //        return;
                    //        //MessageBox.Show("Toko atas DO ini mempunyai OverdueFX, Segera lunasi overdue FX");
                    //        //return;
                    //    }
                    //    else
                    //    {
                    //        if (TokoOverdue.OverdueFB(kodeToko) > 0)
                    //        {
                    //            using (Database db = new Database())
                    //            {
                    //                DataTable dt = new DataTable();
                    //                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, PinId.Bagian.OverdueFB));
                    //                db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, ""));
                    //                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                dt = db.Commands[0].ExecuteDataTable();
                    //                db.Commands[0].ExecuteNonQuery();
                    //                return;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            using (Database db = new Database())
                    //            {
                    //                DataTable dt = new DataTable();
                    //                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, -1));
                    //                db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "LUNAS"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                dt = db.Commands[0].ExecuteDataTable();
                    //                db.Commands[0].ExecuteNonQuery();
                    //            }
                    //        }
                    //    }
                    //}
                    //if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value.ToString() == "OVDFB")
                    //{
                    //    if (TokoOverdue.OverdueFB(kodeToko) > 0)
                    //    {
                    //        Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFB, "Cegatan Overdue FB " + nodo);
                    //        ifrmpin.MdiParent = Program.MainForm;
                    //        Program.MainForm.RegisterChild(ifrmpin);
                    //        ifrmpin.Show();
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        using (Database db = new Database())
                    //        {
                    //            DataTable dt = new DataTable();
                    //            db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //            db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, PinId.Bagian.OverdueFB));
                    //            db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "LUNAS"));
                    //            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //            dt = db.Commands[0].ExecuteDataTable();
                    //            db.Commands[0].ExecuteNonQuery();
                    //        }
                    //    }
                    //}
                    #endregion kondisi lama

                    break;
                #endregion

                #region F2 - Mengisi Pin pengeluaran khusus barang bonus
                case Keys.F2:
                    if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value.ToString() == "BONUSAN")
                    {
                        Guid _DoID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        nodo = dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString();

                        Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _DoID, GlobalVar.Gudang, PinId.Bagian.Bonus, "Cegatan Bonus " + nodo);
                        ifrmpin.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmpin);
                        ifrmpin.Show();
                        return;
                    }

                    #region salesbl
                    //if (cGud == "9")
                    //{
                    //    string _nodo = dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString();
                    //    Guid _doId = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    //    if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value.ToString() == "SALESBL")
                    //    {
                    //        Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doId, GlobalVar.Gudang, PinId.Bagian.SalesBL, "Cegatan Sales BL " + _nodo);
                    //        ifrmpin.MdiParent = Program.MainForm;
                    //        Program.MainForm.RegisterChild(ifrmpin);
                    //        ifrmpin.Show();
                    //        return;
                    //    }
                    //}
                    #endregion
                    break;
                #endregion

                #region F3 - Cetak Do
                case Keys.F3:
                     
                    this.SendToBack();
                    dataGridDO.SendToBack();

                    #region variabel
                    string cab1_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[Cabang1.Name].Value, "").ToString();
                    string kdtoko_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value, "").ToString();
                    string NoDO_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value, "").ToString();
                    string trtype_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value, "").ToString();
                    string NoAccptg_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["NoAccPiutang"].Value, "").ToString();
                    string cekSO_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[CekSO.Name].Value, "").ToString();
                    string Catatan1_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[Catatan1.Name].Value, "").ToString();
                    
                    double RpDO_ = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["RpNet"].Value, 0).ToString());
                    double plafonToko = Convert.ToDouble(Tools.isNull(TokoPlafon.Plafon(kdtoko_, trtype_), 0));
                    /*----------------------------------------------------------------------------------*/
                    //double plafonToko = Convert.ToDouble(Tools.isNull(TokoPlafon.PlafonFin(kdtoko_), 0));
                    /*----------------------------------------------------------------------------------*/
                    double piutangToko = Convert.ToDouble(Tools.isNull(TokoPlafon.Piutang(kdtoko_, trtype_), 0));
                    double gitToko = Convert.ToDouble(Tools.isNull(TokoPlafon.GIT(kdtoko_, trtype_), 0));
                    double giroToko = Convert.ToDouble(Tools.isNull(TokoPlafon.Giro(kdtoko_, trtype_), 0));
                    double giroTolakToko = Convert.ToDouble(Tools.isNull(TokoPlafon.GiroTolak(kdtoko_, trtype_), 0));
                    double sisaPlf = Convert.ToDouble(plafonToko - piutangToko - gitToko - giroToko - giroTolakToko);
                    /*----------------------------------------------------------------------------------*/
                    //double sisaPlf = Convert.ToDouble(Tools.isNull(TokoPlafon.SisaPlafonFin(kdtoko_), 0));
                    /*----------------------------------------------------------------------------------*/
                    double overdueFB = TokoOverdue.OverdueFB(kdtoko_);
                    double overdueFX = TokoOverdue.OverdueFX(kdtoko_);

                    _doID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    #endregion

                    #region cek toko dispensasi
                    TokoDisp = false;
                    //DataTable dtDisp = new DataTable();
                    //using (Database db = new Database())
                    //{
                    //    db.Commands.Add(db.CreateCommand("usp_TokoDispensasiOvdFX_LIST"));
                    //    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kdtoko_));
                    //    db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, DateTime.Now));
                    //    dtDisp = db.Commands[0].ExecuteDataTable();
                    //    if (dtDisp.Rows.Count > 0)
                    //    {
                    //        TokoDisp = true;
                    //    }
                    //}
                    #endregion

                    if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2808")
                    {
                        if (cekSO_.ToString() != "1")
                        {
                            MessageBox.Show("Belum Cek SO..!!");
                            return;
                        }
                    }


                    #region validasi TosForm
                    string CekVerifiedNik = "";
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        DataTable dtApp = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_GetAppSetingTosForm_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@Key", SqlDbType.VarChar, "TOSFORM"));
                            dtApp = db.Commands[0].ExecuteDataTable();
                        }
                        if (dtApp.Rows.Count > 0)
                        {
                            string v = Tools.isNull(dtApp.Rows[0]["Value"], "0").ToString().Trim();
                            if (v == "1")
                            {
                                CekVerifiedNik = "1";
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

                    //tutup dulu sebelum ada kebijakan pemberlakuan
                    ///*cek Verified Nik*/
                    //if (CekVerifiedNik == "1")
                    //{
                    //    try
                    //    {
                    //        this.Cursor = Cursors.WaitCursor;
                    //        DataTable dtvtf = new DataTable();
                    //        using (Database db = new Database())
                    //        {
                    //            db.Commands.Add(db.CreateCommand("usp_VeifiedNIK_LIST"));
                    //            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kdtoko_));
                    //            dtvtf = db.Commands[0].ExecuteDataTable();
                    //        }
                    //        bool vt = bool.Parse(Tools.isNull(dtvtf.Rows[0]["VerifiedNIK"], false).ToString());
                    //        if (vt != true)
                    //        {
                    //            MessageBox.Show("Belum Verifikasi Toko.");
                    //            return;
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Error.LogError(ex);
                    //    }
                    //    finally
                    //    {
                    //        this.Cursor = Cursors.Default;
                    //    }
                    //}
                    #endregion


                    if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2808")
                    {
                        if (NoAccptg_ == "" || NoAccptg_.Substring(0, 1) != "F")
                        {
                            if (NoAccptg_.Trim() == "OVDFB")
                            {
                                if (TokoOverdue.OverdueFB(kdtoko_) > 0)
                                {
                                    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFB, "Cegatan Overdue FB " + NoDO_);
                                    ifrmpin.MdiParent = Program.MainForm;
                                    Program.MainForm.RegisterChild(ifrmpin);
                                    ifrmpin.Show();
                                    return;
                                }
                            }
                            else if (NoAccptg_.Trim() == "OVDFX")
                            {
                                if (TokoOverdue.OverdueFX(kdtoko_) > 0)
                                {
                                    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFX, "Cegatan Overdue FX " + NoDO_);
                                    ifrmpin.MdiParent = Program.MainForm;
                                    Program.MainForm.RegisterChild(ifrmpin);
                                    ifrmpin.Show();
                                    return;
                                }
                            }
                        }
                    }

                    #region Transaksi FX
                    //if (cab1_ == GlobalVar.CabangID)
                    //{
                    //    if (trtype_ != "K2" && trtype_ != "K4" && trtype_.Substring(0,1) == "K")
                    //    {
                    //        if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2808")
                    //        {
                    //            if (cekSO_ == "1")
                    //            {
                    //                //flagkg = ""; GetFlagKg(kdtoko_); 
                    //                if (overdueFB > 0 && NoAccptg_.Trim().Substring(0, 1) != "F")
                    //                {
                    //                    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFB, "Cegatan Overdue FB " + NoDO_);
                    //                    ifrmpin.MdiParent = Program.MainForm;
                    //                    Program.MainForm.RegisterChild(ifrmpin);
                    //                    ifrmpin.Show();
                    //                    return;
                    //                }

                    //                else if (overdueFX > 0 && NoAccptg_.Trim().Substring(0, 1) != "F")
                    //                {
                    //                    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFX, "Cegatan Overdue FX " + NoDO_);
                    //                    ifrmpin.MdiParent = Program.MainForm;
                    //                    Program.MainForm.RegisterChild(ifrmpin);
                    //                    ifrmpin.Show();
                    //                    return;

                    //                    #region kebijakan lama
                    //                    //if (TokoDisp)
                    //                    //{
                    //                    //    using (Database db = new Database())
                    //                    //    {
                    //                    //        DataTable dt = new DataTable();
                    //                    //        db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                    //        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                    //        db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, -1));
                    //                    //        db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "FULLACC"));
                    //                    //        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                    //        dt = db.Commands[0].ExecuteDataTable();
                    //                    //        db.Commands[0].ExecuteNonQuery();
                    //                    //    }
                    //                    //}
                    //                    //else
                    //                    //{
                    //                    //    /*perubahan kebijakan, overdue FX kembali pengajuan pin ke HO*/
                    //                    //    //MessageBox.Show("Masih ada Overdue FX");
                    //                    //    //return;
                    //                    //    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFX, "Cegatan Overdue FX " + NoDO_);
                    //                    //    ifrmpin.MdiParent = Program.MainForm;
                    //                    //    Program.MainForm.RegisterChild(ifrmpin);
                    //                    //    ifrmpin.Show();
                    //                    //    return;
                    //                    //}
                    //                    #endregion
                    //                }
                    //                else
                    //                {
                    //                    using (Database db = new Database())
                    //                    {
                    //                        DataTable dt = new DataTable();
                    //                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                        db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, -1));
                    //                        db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "FULLACC"));
                    //                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                        dt = db.Commands[0].ExecuteDataTable();
                    //                        db.Commands[0].ExecuteNonQuery();
                    //                    }
                    //                }
                    //            }
                    //            else
                    //            {
                    //                MessageBox.Show("DO ini belum di cek SO, Silahkan Bagian Piutang untuk Cek SO");
                    //                return;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            using (Database db = new Database())
                    //            {
                    //                DataTable dt = new DataTable();
                    //                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, -1));
                    //                db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "LUNAS"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                dt = db.Commands[0].ExecuteDataTable();
                    //                db.Commands[0].ExecuteNonQuery();
                    //            }
                    //        }
                    //    }
                    //}
                    #endregion

                    #region Transaksi BE
                    //if (cab1_ == GlobalVar.CabangID)
                    //{
                    //    if (trtype_ == "K2" || trtype_ == "K4")
                    //    {
                    //        if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2808")
                    //        {
                    //            if (cekSO_ == "1")
                    //            {
                    //                //flagkg = ""; GetFlagKg(kdtoko_); 
                    //                if (overdueFB > 0 && NoAccptg_.Trim().Substring(0, 1) != "F")
                    //                {
                    //                    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFB, "Cegatan Overdue FB " + NoDO_);
                    //                    ifrmpin.MdiParent = Program.MainForm;
                    //                    Program.MainForm.RegisterChild(ifrmpin);
                    //                    ifrmpin.Show();
                    //                    return;

                    //                    #region toko dispensasi
                    //                    //if (TokoDisp)
                    //                    //{
                    //                    //    using (Database db = new Database())
                    //                    //    {
                    //                    //        DataTable dt = new DataTable();
                    //                    //        db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                    //        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                    //        db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, PinId.Bagian.OverdueFB));
                    //                    //        db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "FULLACC"));
                    //                    //        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                    //        dt = db.Commands[0].ExecuteDataTable();
                    //                    //        db.Commands[0].ExecuteNonQuery();
                    //                    //    }
                    //                    //}
                    //                    //else
                    //                    //{
                    //                    //    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFB, "Cegatan Overdue FB " + NoDO_);
                    //                    //    ifrmpin.MdiParent = Program.MainForm;
                    //                    //    Program.MainForm.RegisterChild(ifrmpin);
                    //                    //    ifrmpin.Show();
                    //                    //    return;
                    //                    //}
                    //                    #endregion
                    //                }
                    //                else
                    //                {
                    //                    using (Database db = new Database())
                    //                    {
                    //                        DataTable dt = new DataTable();
                    //                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                        db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, PinId.Bagian.OverdueFB));
                    //                        db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "FULLACC"));
                    //                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                        dt = db.Commands[0].ExecuteDataTable();
                    //                        db.Commands[0].ExecuteNonQuery();
                    //                    }
                    //                }
                    //            }
                    //            else
                    //            {
                    //                MessageBox.Show("DO ini belum di cek SO, Silahkan Bagian Piutang untuk Cek SO");
                    //                return;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            using (Database db = new Database())
                    //            {
                    //                DataTable dt = new DataTable();
                    //                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    //                db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, PinId.Bagian.OverdueFB));
                    //                db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "FULLACC"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //                dt = db.Commands[0].ExecuteDataTable();
                    //                db.Commands[0].ExecuteNonQuery();
                    //            }
                    //        }
                    //    }
                    //}
                    #endregion

                    /*dipindah ke nota jual*/
                    //if (RpDO_ > sisaPlf)
                    //{
                    //    MessageBox.Show("Nominal DO melebihi Sisa Plafon.");
                    //    return;
                    //}

                    /*------------------------------------------------------------------------------
                      Tambahan kondisi: jika bukan K2 dan K4 dimana item barang tidak ada barang BE,
                      maka harus pengajuan PIN ke HO untuk penjualan barang FA tsb*
                      -----------------------------------------------------------------------------*/
                    //if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2808" && trtype_.ToString() != "K2" && trtype_.ToString() != "K4")
                    //{
                    //    try
                    //    {
                    //        this.Cursor = Cursors.WaitCursor;
                    //        DataSet dtBE = new DataSet();
                    //        using (Database db = new Database())
                    //        {
                    //            db.Commands.Add(db.CreateCommand("usp_GetPenjualanBE_LIST"));
                    //            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    //            dtBE = db.Commands[0].ExecuteDataSet();
                    //            if (dtBE.Tables.Count == 0) 
                    //            {
                    //                if (Catatan1_ == "")
                    //                {
                    //                    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.BarangBE, "Pengambilan Barang BE " + NoDO_);
                    //                    ifrmpin.MdiParent = Program.MainForm;
                    //                    Program.MainForm.RegisterChild(ifrmpin);
                    //                    ifrmpin.Show();
                    //                    return;
                    //                }
                    //            }
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Error.LogError(ex);
                    //    }
                    //    finally
                    //    {
                    //        this.Cursor = Cursors.Default;
                    //    }
                    //}
                    /*-------------------------------------------------------------------------------------*/

                    CekCetakDO();
                    break;

                #endregion

                #region F4
                case Keys.F4:
                    UploadUlangDO();
                    break;
                #endregion

                #region F5
                case Keys.F5:
                    _doID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string _noRqNew = "";
                    string _norq = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["NoRequest"].Value,"").ToString().Trim();
                    int pnj = Convert.ToInt32(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["NoRequest"].Value,"").ToString().Trim().Length);

                    if (_norq != "")
                    {
                        if (_norq.Substring(0, 1) == "!")
                            _noRqNew = _norq.Substring(1, pnj - 1);
                        else
                            _noRqNew = "!" + _norq;
                    }

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_NoRQ_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _doID));
                            db.Commands[0].Parameters.Add(new Parameter("@NoRQ", SqlDbType.VarChar, _noRqNew));
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

                    dataGridDO.Focus();
                    RefreshDataDO();
                    FindHeader("RowID", _doID.ToString());

                    break;
                #endregion

                #region F6
                case Keys.F6:
                    /* F6 untuk menampilkan riwayat jual DO Header (Riwayat penjualan per toko) */
                    PanggilRiwayatPenjualan();
                    break;
                #endregion

                #region F7
                case Keys.F7:
                    BatalDO();
                    break;
                #endregion

                #region F8
                case Keys.F8:
                    //TODO: List grid 1
                    ListGridDO();
                    break;
                #endregion

                #region F9
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                #endregion

                #region F11 - Pengajuan pin overdue, Barang bonus dan Upload acc harga
                case Keys.F11:
                    bool generated = GeneratePengajuan((DateTime)rgbTglDO.FromDate, (DateTime)rgbTglDO.ToDate);
                    if (!generated)
                    {
                        MessageBox.Show("Tidak ada pengajuan Acc Piutang");     //DO bermasalah");   //. \n" +
                            //"Selanjutnya akan dilakukan proses upload pengajuan harga FB/FE");
                    }

                    #region pengajuan harga BE
                    //StsToko
                    //if (dataGridDO.SelectedCells[0].OwningRow.Cells["StsToko"].Value.ToString()=="RETAIL")
                    //{
                    //cKlp = "";
                    //bool uploaded = false;
                    //try
                    //{
                    //    uploaded = Upload((DateTime)rgbTglDO.FromDate, (DateTime)rgbTglDO.ToDate);
                    //    if (uploaded)
                    //    {
                    //        cKlp = "BE";
                    //        ZipFile();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Tidak ada pengajuan harga FB/FE.");
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    Error.LogError(ex);
                    //}
                    //}
                    #endregion

                    #region pengajuan harga FX
                    /*upload harga dibawan standar KG,KB,KV,KC*/
                    //cKlp = "";
                    //bool uploadedfx = false;
                    //try
                    //{
                    //    uploadedfx = Uploadfx((DateTime)rgbTglDO.FromDate, (DateTime)rgbTglDO.ToDate);
                    //    if (uploadedfx)
                    //    {
                    //        cKlp = "FX";
                    //        ZipFileFX();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Tidak ada pengajuan harga FX,FA atau FC");
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    Error.LogError(ex);
                    //}
                    #endregion 

                    if (generated) //|| uploaded)
                    {
                        UpdatePengajuan((DateTime)rgbTglDO.FromDate, (DateTime)rgbTglDO.ToDate);
                        cmdSearch_Click(sender, new EventArgs());
                    }

                    #region pengajuan khusus Busi Vanbelt (lama)
                    ////UPLOAD HARGA DIBAWAH CTE KB KV ----------------------->>>
                    //cKlp = "";
                    //bool uploadedbv = false;
                    //try
                    //{
                    //    uploadedbv = UploadBusiVanbelt((DateTime)rgbTglDO.FromDate, (DateTime)rgbTglDO.ToDate);
                    //    if (uploadedbv)
                    //    {
                    //        cKlp = "FA";
                    //        ZipFile();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Tidak ada pengajuan harga FAB/FA2/FA4.");
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    Error.LogError(ex);
                    //}
                    //if (generated || uploadedbv)
                    //{
                    //    UpdatePengajuan((DateTime)rgbTglDO.FromDate, (DateTime)rgbTglDO.ToDate);
                    //    cmdSearch_Click(sender, new EventArgs());
                    //}
                    #endregion

                    break;
                #endregion

                #region F12
                case Keys.F12:
                    // Filter barang
                    Penjualan.frmDOFilterBarangBrowser ifrmChild = new Penjualan.frmDOFilterBarangBrowser(_fromDate, _toDate);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                    break;
                #endregion

                #region tombol
                case Keys.Home:
                    if (selectedGrid == enumSelectedGrid.DOSelected)
                    {
                    }
                    break;
                case Keys.End:
                    if (selectedGrid == enumSelectedGrid.DOSelected)
                    {
                    }
                    break;
                case Keys.Tab:
                    if (selectedGrid == enumSelectedGrid.DOSelected)
                    {
                        dataGridDetailDO.Focus();
                        selectedGrid = enumSelectedGrid.DetailDOSelected;
                    }
                    break;
                #endregion

                #region F10
                case Keys.F10:

                    //DataTable dtTrue = new DataTable();
                    ////dataGridDO.DataSource = dtTrue;
                    //_doId = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells[RowID.Name].Value;
                    //DataView dv1 = (DataView)(dataGridDO.DataSource);
                    //dtTrue = dv1.ToTable();
                    ////dtTrue.DefaultView.RowFilter = "CekSO=" + "'" + "1" + "'";
                    ////DataView dv = dtTrue.DefaultView;
                    ////dtTrue = dv.ToTable();
                    ////dtTrue.DefaultView.RowFilter = "RowID=" + "'" + _doId + "'";
                    ////DataView dv2 = dtTrue.DefaultView;
                    ////dtTrue = dv2.ToTable();
                    //    if (dtTrue.Rows.Count != 0)
                    //    {
                    //        if (Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[CekSO.Name].Value, "").ToString() == "0")
                    //        {
                    //            dtTrue.DefaultView.RowFilter = "CekSO=" + "'" + "1" + "'";
                    //            DataView dv3 = dtTrue.DefaultView;
                    //            dtTrue = dv3.ToTable();
                    //            //dtTrue.DefaultView.RowFilter = "RowID=" + "'" + _doId + "'";
                    //            //DataView dv2 = dtTrue.DefaultView;
                    //            //dtTrue = dv2.ToTable();
                    //            if (dtTrue.Rows.Count == 0)
                    //            {
                    //                string message = "Dengan meng-acc ini maka bagian piutang sudah melakukan pengecekan terhadap informasi Sales Order ini adalah benar dan tidak fiktif. Simpanlah bukti Sales Order ini untuk kepentingan pada saat proses auditing.";
                    //                DialogResult dlg = MessageBox.Show(message, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    //                if (dlg == DialogResult.Yes)
                    //                {
                    //                    // update kolom di table
                    //                    using (Database db = new Database())
                    //                    {
                    //                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualanUpdateCekFisik"));
                    //                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _doId));
                    //                        db.Commands[0].Parameters.Add(new Parameter("@Cek", SqlDbType.Bit, 1));
                    //                        db.Commands[0].ExecuteNonQuery();
                    //                    }
                    //                    dataGridDO.SelectedCells[0].OwningRow.Cells[CekSO.Name].Value = "1";
                    //                    dataGridDO.SelectedCells[0].OwningRow.DefaultCellStyle.BackColor = Color.Plum;
                    //                }
                    //            }
                    //            else
                    //            {
                    //                MessageBox.Show("Sudah Ada DO yang Cek SO, silahkan di cetak terlebih dahulu");
                    //                return;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            // update kolom di table
                    //            using (Database db = new Database())
                    //            {
                    //                db.Commands.Add(db.CreateCommand("usp_OrderPenjualanUpdateCekFisik"));
                    //                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _doId));
                    //                db.Commands[0].Parameters.Add(new Parameter("@Cek", SqlDbType.Bit, 0));
                    //                db.Commands[0].ExecuteNonQuery();
                    //            }
                    //            dataGridDO.SelectedCells[0].OwningRow.Cells[CekSO.Name].Value = "0";
                    //            dataGridDO.SelectedCells[0].OwningRow.DefaultCellStyle.BackColor = Color.White;
                    //        }
                    //    }
                    break;
                #endregion
            }
        }

        private void dataGridDetailDO_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    // TODO: Tampilkan info DO
                    break;
                case Keys.F2:
                    if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString() == "BONUSAN")
                    {
                        //MessageBox.Show("Semua barang dalam DO ini adalah bonus." + "\n" +
                        //    "Silahkan masukan PIN pengajuan bonus terlebih dahulu.");

                        /*
                        Pin.frmPin ifrmpin = new Pin.frmPin(this, 0, 7, 10, _doID, DateTime.Today);
                        ifrmpin.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmpin);
                        ifrmpin.Show();
                        */

                        _doID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        string nodo = dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString();

                        Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.Bonus, "Cegatan Bonus " + nodo);
                        ifrmpin.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmpin);
                        ifrmpin.Show();

                        //return;
                    }
                    break;

                case Keys.F4:
                    // Tampilkan info stok
                    PanggilInfoStok();
                    break;
                case Keys.F5:
                    // PPC
                    if (!SecurityManager.IsAuditor())
                    {
                        PPC();
                    }
                    break;
                case Keys.F6:
                    /* F6 untuk menampilkan riwayat jual DO Detail  
                     * (Riwayat penjualan per toko dan barang) */
                    PanggilRiwayatPenjualan();
                    break;
                case Keys.F7:
                    if (SecurityManager.IsManager() || SecurityManager.HasRight("TRD.BATAL_DO"))
                    {
                        BatalDODetail();
                    }
                    break;
                case Keys.F8:
                    /* F8 untuk menampilkan info hrg jual (BMK) dan info penjualan terakhir */
                    ShowInfoHrgJual();
                    break;
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.F11:
                    //TODO: list grid 2
                    ListGridDODetail();
                    break;
                case Keys.Home:
                    if (selectedGrid == enumSelectedGrid.DetailDOSelected)
                    {
                    }
                    break;
                case Keys.End:
                    if (selectedGrid == enumSelectedGrid.DetailDOSelected)
                    {
                    }
                    break;
                case Keys.Tab:
                    if (selectedGrid == enumSelectedGrid.DetailDOSelected)
                    {
                        dataGridDO.Focus();
                        selectedGrid = enumSelectedGrid.DOSelected;
                    }
                    break;
                case Keys.Delete:
                    cmdDELETE.PerformClick();
                    break;
            }
        }

        private void PanggilInfoStok()
        {
            string barangID = dataGridDetailDO.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();
            string namaBrg = dataGridDetailDO.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();

            Penjualan.frmInfoStok ifrmChild = new Penjualan.frmInfoStok(this, barangID, namaBrg);
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);            
            ifrmChild.ShowDialog();
        }

        private void PPC()
        {
            Guid doID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            string htrID = dataGridDO.SelectedCells[0].OwningRow.Cells["HtrID"].Value.ToString();
            string kodeToko = dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PPC_LIST"));//udah heri
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodeToko));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak mendapat bonus !!!");
                    return;
                }
                else
                {
                    Penjualan.frmPPCBrowse ifrmChild = new Penjualan.frmPPCBrowse(this, dt, doID, htrID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
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

        private void UploadUlangDO()
        {
            if (dataGridDO.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }
            int index = dataGridDO.SelectedCells[0].RowIndex;//dataGridDO.SelectedRows[0].Index;

            //if (Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["NoAccPusat"].Value, "").ToString() == "ACC-00")
            //    {
            //        MessageBox.Show("Sudah ada ACC-00");
            //        return;
            //    }

            if (Tools.isNull(dtDO.DefaultView[index]["TglSuratJalan"], "").ToString() != "")
            {
                MessageBox.Show("DO sudah jadi nota..." );
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_UPDATE")); //udah heri
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dtDO.DefaultView[index]["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, dtDO.DefaultView[index]["HtrID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, dtDO.DefaultView[index]["Cabang1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, dtDO.DefaultView[index]["Cabang2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, dtDO.DefaultView[index]["Cabang3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, dtDO.DefaultView[index]["NoRequest"]));
                    db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, dtDO.DefaultView[index]["TglRequest"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, dtDO.DefaultView[index]["NoDO"]));
                    db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, dtDO.DefaultView[index]["TglDO"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, dtDO.DefaultView[index]["ACCPiutangID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, dtDO.DefaultView[index]["NoACCPiutang"]));
                    db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, dtDO.DefaultView[index]["TglACCPiutang"]));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, dtDO.DefaultView[index]["StatusBatal"]));
                    db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, dtDO.DefaultView[index]["HariKredit"]));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, dtDO.DefaultView[index]["KodeToko"]));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, dtDO.DefaultView[index]["KodeSales"]));
                    db.Commands[0].Parameters.Add(new Parameter("@StsToko", SqlDbType.VarChar, dtDO.DefaultView[index]["StsToko"]));
                    db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, dtDO.DefaultView[index]["AlamatKirim"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, dtDO.DefaultView[index]["Kota"]));
                    db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, dtDO.DefaultView[index]["DiscFormula"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Decimal, dtDO.DefaultView[index]["Disc1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Decimal, dtDO.DefaultView[index]["Disc2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Decimal, dtDO.DefaultView[index]["Disc3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dtDO.DefaultView[index]["isClosed"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, dtDO.DefaultView[index]["Catatan1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, dtDO.DefaultView[index]["Catatan2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, dtDO.DefaultView[index]["Catatan3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, dtDO.DefaultView[index]["Catatan4"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, dtDO.DefaultView[index]["Catatan5"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, dtDO.DefaultView[index]["NoDOBO"]));
                    db.Commands[0].Parameters.Add(new Parameter("@TglReorder", SqlDbType.DateTime, dtDO.DefaultView[index]["TglReorder"]));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusBO", SqlDbType.Bit, dtDO.DefaultView[index]["StatusBO"]));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, dtDO.DefaultView[index]["SyncFlag"]));
                    db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, dtDO.DefaultView[index]["LinkID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, dtDO.DefaultView[index]["TransactionType"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, dtDO.DefaultView[index]["Expedisi"]));
                    db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, dtDO.DefaultView[index]["HariKirim"]));
                    db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, dtDO.DefaultView[index]["HariSales"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, dtDO.DefaultView[index]["NPrint"]));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                //RefreshDataDO();
                dataGridDO.SelectedCells[0].OwningRow.Cells["NoAccPusat"].Value = "";
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

        private void KunciACCHrg()
        {
            if (dataGridDO.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }
            int index = dataGridDO.SelectedCells[0].RowIndex;//dataGridDO.SelectedRows[0].Index;

            string _ACCHrg = "";
            if (Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["NoAccPusat"].Value, "").ToString() == "")
                _ACCHrg = "ACC-00";
            else
            {
                if (Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["NoAccPusat"].Value, "").ToString().Contains("ACC-00") == true)
                    _ACCHrg = "";
                else
                    return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_UPDATE")); //udah heri
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dtDO.DefaultView[index]["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, dtDO.DefaultView[index]["HtrID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, dtDO.DefaultView[index]["Cabang1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, dtDO.DefaultView[index]["Cabang2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, dtDO.DefaultView[index]["Cabang3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, dtDO.DefaultView[index]["NoRequest"]));
                    db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, dtDO.DefaultView[index]["TglRequest"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, dtDO.DefaultView[index]["NoDO"]));
                    db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, dtDO.DefaultView[index]["TglDO"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, _ACCHrg));
                    db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, dtDO.DefaultView[index]["ACCPiutangID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, dtDO.DefaultView[index]["NoACCPiutang"]));
                    db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, dtDO.DefaultView[index]["TglACCPiutang"]));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, dtDO.DefaultView[index]["StatusBatal"]));
                    db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, dtDO.DefaultView[index]["HariKredit"]));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, dtDO.DefaultView[index]["KodeToko"]));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, dtDO.DefaultView[index]["KodeSales"]));
                    db.Commands[0].Parameters.Add(new Parameter("@StsToko", SqlDbType.VarChar, dtDO.DefaultView[index]["StsToko"]));
                    db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, dtDO.DefaultView[index]["AlamatKirim"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, dtDO.DefaultView[index]["Kota"]));
                    db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, dtDO.DefaultView[index]["DiscFormula"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Decimal, dtDO.DefaultView[index]["Disc1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Decimal, dtDO.DefaultView[index]["Disc2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Decimal, dtDO.DefaultView[index]["Disc3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dtDO.DefaultView[index]["isClosed"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, dtDO.DefaultView[index]["Catatan1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, dtDO.DefaultView[index]["Catatan2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, dtDO.DefaultView[index]["Catatan3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, dtDO.DefaultView[index]["Catatan4"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, dtDO.DefaultView[index]["Catatan5"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, dtDO.DefaultView[index]["NoDOBO"]));
                    db.Commands[0].Parameters.Add(new Parameter("@TglReorder", SqlDbType.DateTime, dtDO.DefaultView[index]["TglReorder"]));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusBO", SqlDbType.Bit, dtDO.DefaultView[index]["StatusBO"]));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, dtDO.DefaultView[index]["SyncFlag"]));
                    db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, dtDO.DefaultView[index]["LinkID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, dtDO.DefaultView[index]["TransactionType"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, dtDO.DefaultView[index]["Expedisi"]));
                    db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, dtDO.DefaultView[index]["HariKirim"]));
                    db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, dtDO.DefaultView[index]["HariSales"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, dtDO.DefaultView[index]["NPrint"]));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                //RefreshDataDO();
                dataGridDO.SelectedCells[0].OwningRow.Cells["NoAccPusat"].Value = _ACCHrg;
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

        private void PanggilRiwayatPenjualan()
        {
            if (dataGridDO.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }
            if (dataGridDetailDO.SelectedCells.Count == 0 && selectedGrid == enumSelectedGrid.DetailDOSelected)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }
            string _kodeToko = dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
            string _namaToko = dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
            string _alamat = dataGridDO.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString();
            string _barangID = "";
            if (selectedGrid == enumSelectedGrid.DetailDOSelected)
                _barangID = dataGridDetailDO.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();

            
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HistoryPenjualan_LIST"));// udah heri
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                    if (_barangID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data riwayat penjualan");
                    return;
                }


                if (selectedGrid == enumSelectedGrid.DOSelected)
                {
                    Penjualan.frmRiwayatJualHeader ifrmChild = new Penjualan.frmRiwayatJualHeader(this, dt, _acak);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                else
                {
                    Penjualan.frmRiwayatJualDetail ifrmChild = new Penjualan.frmRiwayatJualDetail(this, dt, _acak);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
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

        private void ShowInfoHrgJual()
        {
            DateTime tglDO = (DateTime)dataGridDO.SelectedCells[0].OwningRow.Cells["TglDO"].Value;
            string barangID = dataGridDetailDO.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();
            string kodeToko = dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtInfoHrgJual = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetInfoHrgJual")); //udah cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@tglDO", SqlDbType.DateTime, tglDO));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    dtInfoHrgJual = db.Commands[0].ExecuteDataTable();
                }
                                 
                MessageBox.Show("Harga saat ini: " + System.Environment.NewLine
                    + "B : " + String.Format("{0:0,0}", dtInfoHrgJual.Rows[0]["HrgB"])
                    + "  M : " + String.Format("{0:0,0}", dtInfoHrgJual.Rows[0]["HrgM"])
                    + "  K : " + String.Format("{0:0,0}", dtInfoHrgJual.Rows[0]["HrgK"])
                    + System.Environment.NewLine
                    + "Penjualan terakhir Rp. " + String.Format("{0:0,0}", dtInfoHrgJual.Rows[0]["HrgTerakhir"])
                    + " Tgl. " + String.Format("{0:d-MMM-yyyy}", dtInfoHrgJual.Rows[0]["TglTerakhir"]));
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

        private void BatalDO()
        {
            //if (Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["StatusBatal"].Value, "").ToString().Contains("BATAL") == true)
            //{
            //    MessageBox.Show("DO sudah pernah batal...");
            //    return;
            //}

            String NoACCPusat = dataGridDO.SelectedCells[0].OwningRow.Cells["NoAccPusat"].Value.ToString();
            if (NoACCPusat == "BATAL00")
            {
                MessageBox.Show("DO Sudah Pernah Dibatalkan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string aa = string.Empty;
            aa = dataGridDO.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value.ToString();
            if (aa != "")
            {
                MessageBox.Show("DO sudah jadi nota...");
                return;
            }
            Penjualan.frmBatalDO ifrmChild = new Penjualan.frmBatalDO(this, dataGridDO.SelectedCells[0].OwningRow);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void BatalDODetail()
        {
            if (dataGridDetailDO.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }

            if ((int)Tools.isNull(dataGridDetailDO.SelectedCells[0].OwningRow.Cells["QtySJ"].Value,0) > 0)
            {
                MessageBox.Show("Sudah Cetak Nota"+System.Environment.NewLine+"Tidak bisa dibatalkan..!");
                return;
            }

            // Cari index dari grid untuk pemetaan ke data tabel
            int index = dataGridDetailDO.SelectedCells[0].OwningRow.Index;           

            if (MessageBox.Show("Harga Tidak cocok" + System.Environment.NewLine + "Anda yakin ?", "DO Batal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.Default;
                    using (Database db = new Database())
                    {
                        // Batal detail do: Rubah QtyD0=0 dan NoACC='BATAL00'
                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_UPDATE"));//udah cek heri
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtDetailDO.DefaultView[index]["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtDetailDO.DefaultView[index]["HeaderID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtDetailDO.DefaultView[index]["RecordID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtDetailDO.DefaultView[index]["HtrID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dtDetailDO.DefaultView[index]["BarangID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyRequest", SqlDbType.Int, dtDetailDO.DefaultView[index]["QtyRequest"]));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, dtDetailDO.DefaultView[index]["HrgJual"]));
                        //db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dtDetailDO.DefaultView[index]["KodeToko"]));
                        //db.Commands[0].Parameters.Add(new Parameter("@tglSuratJalan", SqlDbType.DateTime, dtDetailDO.DefaultView[index]["TglSuratJalan"]));
                        db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, dtDetailDO.DefaultView[index]["Disc1"]));
                        db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, dtDetailDO.DefaultView[index]["Disc2"]));
                        db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, dtDetailDO.DefaultView[index]["Disc3"]));
                        db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, dtDetailDO.DefaultView[index]["Pot"]));
                        db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, dtDetailDO.DefaultView[index]["DiscFormula"]));
                        db.Commands[0].Parameters.Add(new Parameter("@noDOBO", SqlDbType.VarChar, dtDetailDO.DefaultView[index]["NoDOBO"]));
                        db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, "BATAL00"));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, dtDetailDO.DefaultView[index]["Catatan"]));
                        db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    RefreshDataDetailDO();
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

        /* Modus Add, Edit dan Delete */

        private void cmdADD_Click(object sender, EventArgs e)
        {
            string sie = Class.AppSetting.GetValue("so_insert_enable");
            if (sie.ToLower() != "true")
            {
                MessageBox.Show("Silakan input melalui https://wiser.sas-autoparts.com");
                return;
            }

            //DO.FrmDO ifrmChild = new DO.FrmDO();
            ////ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.ShowDialog();

            switch (selectedGrid)
            {
                case enumSelectedGrid.DOSelected:
                    MessageBox.Show("Silahkan Gunakan Menu Entry DO");
                    //Penjualan.frmDOUpdate ifrmChild = new Penjualan.frmDOUpdate(this);
                    ////ifrmChild.MdiParent = Program.MainForm;
                    //Program.MainForm.RegisterChild(ifrmChild);
                    //ifrmChild.ShowDialog();
                    break;

                case enumSelectedGrid.DetailDOSelected:
                    if (dataGridDO.SelectedCells.Count == 0)
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                        return;
                    }

                    if (!CekAddEditHapus("tambah"))
                    {
                        return;
                    }

                    GlobalVar.LastClosingDate = (DateTime)dataGridDO.SelectedCells[0].OwningRow.Cells["TglDO"].Value;
                    if ((DateTime)dataGridDO.SelectedCells[0].OwningRow.Cells["TglDO"].Value <= GlobalVar.LastClosingDate)
                    {
                        throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    }

                    bool isAllowEditAcc = LookupInfoValue.CekEditAccDo();
                    int Jdo = Convert.ToInt32(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["QtyDO"].Value,"0").ToString());

                    if (GlobalVar.Gudang != "2808")
                    {
                        if (!isAllowEditAcc)
                        {
                            if (OnGoingAcc())
                            {
                                MessageBox.Show("Status DO masih menunggu ACC dari pusat");
                                return;
                            }

                            if (Jdo > 0)
                            {
                                if (HasAcc())
                                {
                                    MessageBox.Show("Sudah Di ACC dari pusat");
                                    return;
                                }
                            }
                        }
                    }

                    Guid _headerID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string _namatoko = Convert.ToString(dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value);
                    string _jenistrans = Convert.ToString(dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value);
                    string noAccPusat = Convert.ToString(dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value);
                    string TipeTrans = Convert.ToString(dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value);
                    
                    Penjualan.frmDODetailUpdate ifrmChild2 = new Penjualan.frmDODetailUpdate(this, _headerID, _namatoko, _jenistrans, noAccPusat, TipeTrans);
                    Program.MainForm.RegisterChild(ifrmChild2);
                    ifrmChild2.ShowDialog();
                    break;
            }

        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVar.LastClosingDate = (DateTime)dataGridDO.SelectedCells[0].OwningRow.Cells["TglDO"].Value;
                if ((DateTime)dataGridDO.SelectedCells[0].OwningRow.Cells["TglDO"].Value <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(String.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }

                bool isAllowEditAcc = LookupInfoValue.CekEditAccDo();

                switch (selectedGrid)
                {

                    case enumSelectedGrid.DOSelected:
                        if (dataGridDO.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }

                        if (!CekAddEditHapus("edit"))
                        {
                            return;
                        }

                        if (!isAllowEditAcc)
                        {
                            if (OnGoingAcc())
                            {
                                MessageBox.Show("Status DO masih menunggu ACC dari pusat");
                                return;
                            }

                            if (HasAcc())
                            {
                                MessageBox.Show("Sudah Di ACC dari pusat");
                                return;
                            }
                        }

                        Guid rowID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        string jmlHrg = dtDetailDO.Compute("SUM(JmlHrg)", string.Empty).ToString();
                        string jmlNet = dtDetailDO.Compute("SUM(HrgNet)", string.Empty).ToString();

                        Penjualan.frmDOUpdate ifrmChild = new Penjualan.frmDOUpdate(this, rowID, jmlHrg, jmlNet);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                        break;

                    case enumSelectedGrid.DetailDOSelected:

                        string noAccDetail = Tools.isNull(dataGridDetailDO.SelectedCells[0].OwningRow.Cells["DetailNoACC"].Value, string.Empty).ToString();
                        bool isOverPlafon = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[IsOverPlafon.Name].Value, string.Empty).ToString() == "1";
                        string idBrg = dataGridDetailDO.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();
                        Guid _rowID = (Guid)dataGridDetailDO.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                        Guid _headerID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        string jenistransaksi = dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value.ToString();
                        string noAccPusat = dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString();
                        DateTime Tgldo = Convert.ToDateTime(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["TglDO"].Value, DBNull.Value).ToString());

                        if (Tgldo == null)
                        {
                            MessageBox.Show("Tanggal DO kosong");
                            return;
                        }

                        if (dataGridDetailDO.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }

                        if (idBrg.Substring(0, 3) == "FXB")
                        {
                            MessageBox.Show("Barang Promo atau Bonus tidak bisa di-edit.");
                            return;
                        }

                        if (!CekAddEditHapus("edit"))
                        {
                            return;
                        }

                        if (!isAllowEditAcc)
                        {
                            if (!isOverPlafon && OnGoingAcc() && (noAccDetail == "HARGA" || noAccDetail == ""))
                            {
                                MessageBox.Show("Status DO masih menunggu ACC dari pusat");
                                return;
                            }
                            if (noAccDetail != "" && noAccDetail != "AUTOACC" && noAccDetail != "HARGA" && noAccDetail != "BATAL00")
                            {
                                MessageBox.Show("Sudah Di ACC dari pusat");
                                return;
                            }
                            if (noAccDetail == "BATAL00")
                            {
                                MessageBox.Show("Do sudah dibatalkan");
                                return;
                            }
                        }

                        Penjualan.frmDODetailUpdate ifrmChild2 = new Penjualan.frmDODetailUpdate(this, _rowID, _headerID, jenistransaksi, noAccPusat);
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
        }
        
        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVar.LastClosingDate = (DateTime)dataGridDO.SelectedCells[0].OwningRow.Cells["TglDO"].Value;
                if ((DateTime)dataGridDO.SelectedCells[0].OwningRow.Cells["TglDO"].Value <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(String.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }

                bool isAllowEditAcc = LookupInfoValue.CekEditAccDo();

                switch (selectedGrid)
                {
                    case enumSelectedGrid.DOSelected:                        
                        if (dataGridDO.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }

                        if (!CekAddEditHapus("hapus"))
                        {
                            return;
                        }

                        if (!isAllowEditAcc)
                        {
                            if (OnGoingAcc())
                            {
                                MessageBox.Show("Status DO masih menunggu ACC dari pusat");
                                return;
                            }
                            if (HasAcc())
                            {
                                MessageBox.Show("Sudah Di ACC dari pusat");
                                return;
                            }
                        }

                        if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Guid headerID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_DELETE"));//udah cek heri
                                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_DELETE")); //udah cek heri
                                    db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, headerID));

                                    //db.BeginTransaction();
                                    db.Commands[0].ExecuteNonQuery();
                                    db.Commands[1].ExecuteNonQuery();
                                    //db.CommitTransaction();
                                }

                                MessageBox.Show("Record telah dihapus");
                                this.RefreshDataDO();
                            
                        }
                        break;

                    case enumSelectedGrid.DetailDOSelected:
                        string noAccDetail = Tools.isNull(dataGridDetailDO.SelectedCells[0].OwningRow.Cells["DetailNoACC"].Value, string.Empty).ToString();
                        bool isOverPlafon = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[IsOverPlafon.Name].Value, string.Empty).ToString() == "1";

                        if (dataGridDetailDO.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        if (!CekAddEditHapus("hapus"))
                        {
                            return;
                        }

                        if (!isAllowEditAcc)
                        {
                            if (!isOverPlafon && OnGoingAcc() && noAccDetail == "AUTOACC")
                            {
                                MessageBox.Show("Status DO masih menunggu ACC dari pusat");
                                return;
                            }
                            if (!isAllowEditAcc)
                            {
                                if (OnGoingAcc())
                                {
                                    MessageBox.Show("Status DO masih menunggu ACC dari pusat");
                                    return;
                                }
                                if (HasAcc())
                                {
                                    MessageBox.Show("Sudah Di ACC dari pusat");
                                    return;
                                }
                            }

                            //if (!isOverPlafon && HasAcc())
                            //{
                            //    MessageBox.Show("Sudah Di ACC dari pusat");
                            //    return;
                            //}
                            //if (noAccDetail != "" && noAccDetail != "AUTOACC" && noAccDetail != "HARGA")
                            //{
                            //    MessageBox.Show("Sudah Di ACC dari pusat");
                            //    return;
                            //}
                        }

                        if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Guid rowID = (Guid)dataGridDetailDO.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            MessageBox.Show("Record telah dihapus");
                            this.RefreshDataDetailDO();
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

        private bool CekAddEditHapus(string modus)
        {
            string headerRecID = dataGridDO.SelectedCells[0].OwningRow.Cells["HtrID"].Value.ToString();
            string cab1 = dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang1"].Value.ToString();
            string cab2 = dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang2"].Value.ToString();
            string cTrn = dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value.ToString();
            int nprint = Convert.ToInt32 (dataGridDO.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString());
            if ((headerRecID.Substring(0, 3) != GlobalVar.PerusahaanID) && (cab1 == GlobalVar.CabangID) && (cab2 == GlobalVar.CabangID))
            {
                MessageBox.Show("Anda tidak punya wewenang " + modus + " data gudang lain...!");
                return false;
            }
            else if ((bool)dataGridDO.SelectedCells[0].OwningRow.Cells["isClosed"].Value)
            {
                MessageBox.Show("Sudah di audit. Tidak bisa " + modus + " data.");
                return false;
            }
            else if (CekNota("@cekPJ3"))
            {
                MessageBox.Show("Sudah proses PJ3. Tidak bisa " + modus + " data.");
                return false;
            }
            else if (CekNota(""))
            {
                MessageBox.Show("Sudah proses PJ2. Tidak bisa " + modus + " data.");
                return false;
            }
            else if (nprint > 0 && cTrn.ToString().Substring(0, 1) == "K")
            {
                MessageBox.Show("Sudah Cetak DO..!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //else if (CekSudahCetakNota())
            //{
            //    MessageBox.Show("Sudah cetak DO. Tidak bisa " + modus + " data.");
            //    return false;
            //}
            else if (!string.IsNullOrEmpty(dataGridDO.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value.ToString().Trim()))
            {
                MessageBox.Show("Sudah cetak surat jalan. Tidak bisa " + modus + " data.");
                return false;
            }
            //else if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString() != "")
            //{
            //    if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString().Contains(":"))
            //    {
            //        MessageBox.Show("Data sudah diUpload ke 11. Tidak bisa di " + modus + ".");
            //        return false;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Sudah di ACC 11. Tidak bisa di " + modus + ".");
            //        return false;
            //    }
            //}
            else
            {
                return true;
            }            
            /* Tambah-Edit-Hapus Header/Detail
                  LOCAL cMsg
                  cMsg = IIF(cModus='A','Tambah',IIF(cModus='E','Edit','Hapus'))
                  IF cModus='A' AND nGrid = 1
                     RETURN .T.
                  ENDIF
                  DO CASE
                  CASE LEFT(Hhtransj.Idhtr,3) <> cInitPrs AND Hhtransj.Cab1 = cInitCab AND Hhtransj.Cab2 = cInitCab AND !Accessright('017')
                    MESSAGEBOX('Anda tidak punya wewenang'+CHR(13)+cMsg+' data Gudang lain...!',48,'Perhatian')
                    RETURN .F.
                  CASE Hhtransj.lAudit
                    MESSAGEBOX('Data sudah di Audit. Tidak bisa di '+cMsg+' !!!',48,'Perhatian')
                    RETURN .F.
                  CASE !EMPTY(Hhtransj.Tgl_sj) AND Thisform.CekPj3()
                    MESSAGEBOX('Sudah proses PJ3. Tidak bisa '+cMsg+' data',48,'Perhatian')
                    RETURN .F.
                  CASE !EMPTY(Hhtransj.Tgl_sj)
                    MESSAGEBOX('Sudah proses PJ2. Tidak bisa '+cMsg+' data',48,'Perhatian')
                    RETURN .F.
                  CASE !EMPTY(Hhtransj.No_acc)
                    IF nGrid = 1 AND Accessright('006')
                       RETURN .T.
                    ENDIF
                    IF nGrid = 2 AND EMPTY(Dhtransj.No_acc) AND Hhtransj.Nprint = 0 AND Accessright('017') 
                       RETURN .T.
                    ENDIF    
                    IF ':'$Hhtransj.No_Acc
                       MESSAGEBOX('Data sudah diUpload ke 11'+CHR(13)+'Tidak bisa di '+cMsg,48,'Perhatian')
                       RETURN .F.
                    ELSE
                       MESSAGEBOX('Sudah di ACC 11'+CHR(13)+'Tidak bisa di '+cMsg,48,'Perhatian')
                       RETURN .F.
                    ENDIF
                  ENDCASE
                  RETURN .T.
             */                      
        }

        private bool CekSudahCetakNota()
        {
            bool result = false;

            try
            {
                this.Cursor = Cursors.Default;
                Guid rowID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_CekCetakNota"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count != 0)
                    {
                        result = true;
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
            
            return result;
        }

        private bool CekNota(string param)
        {
            bool result = false;
           
            try
            {
                this.Cursor = Cursors.Default;
                Guid rowID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    //db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_DOID"));
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, rowID));
                    if (param != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter(param, SqlDbType.VarChar, param));
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count != 0)
                    {
                        result = true;
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
            // Return true bila sudah PJ3 atau PJ2
            return result;
        }

        /****************************************/



        private void AcakTampilHrg()
        {
            bool normal = true;
            dataGridDO.Columns["RpJual"].DefaultCellStyle.Format = "#,##0";
            dataGridDO.Columns["RpPot"].DefaultCellStyle.Format = "#,##0";
            dataGridDO.Columns["RpNet"].DefaultCellStyle.Format = "#,##0";
            dataGridDO.Columns["RpNet3"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["HrgBMK"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["HrgJual"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["JmlHarga"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["Pot"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["JmlPot"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["HrgNet"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["HPPSolo"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["JmlHPP"].DefaultCellStyle.Format = "#,##0";

            normal = !_acak;
            dataGridDO.Columns["RpJual"].Visible = _acak;
            dataGridDO.Columns["RpPot"].Visible = _acak;
            dataGridDO.Columns["RpNet"].Visible = _acak;
            dataGridDO.Columns["RpNet3"].Visible = _acak;
            dataGridDetailDO.Columns["HrgBMK"].Visible = _acak;
            dataGridDetailDO.Columns["HrgJual"].Visible = _acak;
            dataGridDetailDO.Columns["JmlHarga"].Visible = _acak;
            dataGridDetailDO.Columns["Pot"].Visible = _acak;
            dataGridDetailDO.Columns["JmlPot"].Visible = _acak;
            dataGridDetailDO.Columns["HrgNet"].Visible = _acak;
            dataGridDetailDO.Columns["HPPSolo"].Visible = _acak;
            dataGridDetailDO.Columns["JmlHPP"].Visible = _acak;

            //acak
            dataGridDO.Columns["RpJualAck"].Visible = normal;
            dataGridDO.Columns["RpPotAck"].Visible = normal;
            dataGridDO.Columns["RpNetAck"].Visible = normal;
            dataGridDO.Columns["RpNet3Ack"].Visible = normal;
            dataGridDetailDO.Columns["HrgBMKAck"].Visible = normal;
            dataGridDetailDO.Columns["HrgJualAck"].Visible = normal;
            dataGridDetailDO.Columns["JmlHrgAck"].Visible = normal;
            dataGridDetailDO.Columns["PotAck"].Visible = normal;
            dataGridDetailDO.Columns["JmlPotAck"].Visible = normal;
            dataGridDetailDO.Columns["HrgNetAck"].Visible = normal;
            dataGridDetailDO.Columns["HPPSoloAck"].Visible = normal;
            dataGridDetailDO.Columns["JmlHPPAck"].Visible = normal;
            _acak = normal;

            AcakTampilTextBox();
        }

        private void AcakTampilTextBox()
        {
            if (dtDetailDO != null)
            {
                if (dtDetailDO.Compute("SUM(JmlHrg)", string.Empty).ToString().Equals(string.Empty))
                {
                    JmlHrgTot = 0;
                }
                else
                {
                    JmlHrgTot = double.Parse(dtDetailDO.Compute("SUM(JmlHrg)", string.Empty).ToString());
                }
                if (dtDetailDO.Compute("SUM(JmlPot)", string.Empty).ToString().Equals(string.Empty))
                {
                    JmlPotTot = 0;
                }
                else
                {
                    JmlPotTot = double.Parse(dtDetailDO.Compute("SUM(JmlPot)", string.Empty).ToString());
                }
                
                if (dtDetailDO.Compute("SUM(HrgNet)", string.Empty).ToString().Equals(string.Empty))
                {
                    HrgNetTot = 0;
                }
                else
                {
                    HrgNetTot = double.Parse(dtDetailDO.Compute("SUM(HrgNet)", string.Empty).ToString());
                }

                if (dtDetailDO.Compute("SUM(JmlHPP)", string.Empty).ToString().Equals(string.Empty))
                {
                    JmlHPPTot = 0;
                }
                else
                {
                    JmlHPPTot = double.Parse(dtDetailDO.Compute("SUM(JmlHPP)", string.Empty).ToString());
                }
            }
            if (_acak)
            {
                txtJumlahHarga2.Text = Tools.GetAntiNumeric(JmlHrgTot.ToString("#,##0"));
                txtJumlahPotongan2.Text = Tools.GetAntiNumeric(JmlPotTot.ToString("#,##0"));
                txtHargaNett2.Text = Tools.GetAntiNumeric(HrgNetTot.ToString("#,##0"));
                txtJumlahHPP2.Text = Tools.GetAntiNumeric(JmlHPPTot.ToString("#,##0"));
            }
            else
            {
                txtJumlahHarga2.Text = JmlHrgTot.ToString("#,##0");
                txtJumlahPotongan2.Text = JmlPotTot.ToString("#,##0");
                txtHargaNett2.Text = HrgNetTot.ToString("#,##0");
                txtJumlahHPP2.Text = JmlHPPTot.ToString("#,##0");
            }          
        }
        
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListGridDO()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dg = new DataTable();
                DataView dv = dtDO.DefaultView;
                dg = dv.ToTable();

                if (dg.Rows.Count > 0)                
                {
                    DataTable dtGridList = dg.Copy();
                    dtGridList.DefaultView.RowFilter = "StatusBatal=''";
                    //construct parameter
                    
                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    //call report viewer
                    frmReportViewer ifrmReport = new frmReportViewer("Penjualan.gridHeaderDOBrowser.rdlc", rptParams, dtGridList, "dsOrderPenjualan_Data");
                    ifrmReport.Show();

                }
                else
                {
                    MessageBox.Show(Messages.Error.NotFound);
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

        private void ListGridDODetail()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (dtDetailDO.Rows.Count > 0)
                {
                    //construct parameter            
                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    rptParams.Add(new ReportParameter("C1", dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang1"].Value.ToString()));
                    rptParams.Add(new ReportParameter("C2", dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang2"].Value.ToString()));
                    rptParams.Add(new ReportParameter("NoRequest", dataGridDO.SelectedCells[0].OwningRow.Cells["NoRequest"].Value.ToString()));
                    rptParams.Add(new ReportParameter("TglRequest", dataGridDO.SelectedCells[0].OwningRow.Cells["TglRequest"].Value.ToString()));
                    rptParams.Add(new ReportParameter("NoDO", dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString()));
                    rptParams.Add(new ReportParameter("TglDO", dataGridDO.SelectedCells[0].OwningRow.Cells["TglDO"].Value.ToString()));
                    rptParams.Add(new ReportParameter("TglNota", dataGridDO.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value.ToString()));
                    rptParams.Add(new ReportParameter("JKW", dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString()));
                    rptParams.Add(new ReportParameter("NamaSales", dataGridDO.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString()));
                    rptParams.Add(new ReportParameter("Status", dataGridDO.SelectedCells[0].OwningRow.Cells["StsToko"].Value.ToString()));
                    rptParams.Add(new ReportParameter("NamaToko", dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString()));
                    rptParams.Add(new ReportParameter("AlamatKirim", dataGridDO.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString()));
                    rptParams.Add(new ReportParameter("Kota", dataGridDO.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString()));
                    rptParams.Add(new ReportParameter("Expedisi", dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString()));
                    rptParams.Add(new ReportParameter("JKX", dataGridDO.SelectedCells[0].OwningRow.Cells["HariKirim"].Value.ToString()));
                    rptParams.Add(new ReportParameter("JKS", dataGridDO.SelectedCells[0].OwningRow.Cells["HariSales"].Value.ToString()));
                    rptParams.Add(new ReportParameter("RpJual", JmlHrgTot.ToString("#,##0")));
                    rptParams.Add(new ReportParameter("RpPot", JmlPotTot.ToString("#,##0")));
                    rptParams.Add(new ReportParameter("RpNet", HrgNetTot.ToString("#,##0")));
                    rptParams.Add(new ReportParameter("Disc1", dataGridDO.SelectedCells[0].OwningRow.Cells["Disc1"].Value.ToString()));
                    rptParams.Add(new ReportParameter("Disc2", dataGridDO.SelectedCells[0].OwningRow.Cells["Disc2"].Value.ToString()));
                    rptParams.Add(new ReportParameter("Disc3", dataGridDO.SelectedCells[0].OwningRow.Cells["Disc3"].Value.ToString()));
                    rptParams.Add(new ReportParameter("IdDisc", dataGridDO.SelectedCells[0].OwningRow.Cells["DiscFormula"].Value.ToString()));
                    rptParams.Add(new ReportParameter("TK", dataGridDO.SelectedCells[0].OwningRow.Cells["TunaiKredit"].Value.ToString()));
                    rptParams.Add(new ReportParameter("ACCHarga", dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString()));
                    rptParams.Add(new ReportParameter("ACCPiutang", dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value.ToString()));

                    //call report viewer
                    frmReportViewer ifrmReport = new frmReportViewer("Penjualan.gridDetailDOBrowser.rdlc", rptParams, dtDetailDO, "dsOrderPenjualan_Data");
                    ifrmReport.Show();

                }
                else
                {
                    MessageBox.Show(Messages.Error.NotFound);
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

        private void helpToolTipButton2_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(helpToolTipButton2, toolTip1.GetToolTip(helpToolTipButton2));
        }

        private void dataGridDetailDO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDOBrowser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.F1: dataGridDO.Focus();
                        break;
                    case Keys.F2: dataGridDetailDO.Focus();
                        break;
                }
            }
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridDO.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridDetailDO.FindRow(columnName, value);
        }


        private void dataGridDO_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridDO.SelectedCells.Count > 0)
            {
                    RefreshDataDetailDO();

                    lblToko.Text = "\"" + dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + "\" "
                        + dataGridDO.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString();                  
            }
            else
            {
                lblToko.Text = " ";
            }
        }

        private void dataGridDetailDO_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridDetailDO.SelectedCells.Count > 0)
            {
                lblBarang.Text = dataGridDetailDO.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
            }
            else
            {
                lblBarang.Text = " ";
            }
        }

        public bool OnGoingAcc()
        {
            bool onAcc = false;

            string pengajuan = dataGridDO.SelectedCells[0].OwningRow.Cells["Catatan5"].Value.ToString();
            if (pengajuan == "AJU")
            {
                onAcc = true;
            }

            return onAcc;
        }


        public bool HasAcc()
        {
            bool hasAcc = false;

            string pinAcc = dataGridDO.SelectedCells[0].OwningRow.Cells["Catatan5"].Value.ToString().Trim();

            if (pinAcc == "ACC")
            {
                hasAcc = true;
            }

            return hasAcc;
        }

        private DataSet PengajuanDataset(DateTime fromDate, DateTime toDate)
        {
            DataSet ds;
            
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("rsp_Pengajuan"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                ds = db.Commands[0].ExecuteDataSet();
            }

            return ds;
        }

        private ExcelPackage PengajuanWorksheets()
        {
            ExcelPackage ep = new ExcelPackage();

            ep.Workbook.Worksheets.Add("Overdue");
            ep.Workbook.Worksheets.Add("OverdueFX");
            ep.Workbook.Worksheets.Add("OverdueNota");
            //ep.Workbook.Worksheets.Add("SalesBL");
            //ep.Workbook.Worksheets.Add("DoSalesBL");
            //ep.Workbook.Worksheets.Add("OverdueNota90");
            //ep.Workbook.Worksheets.Add("AccHarga");
            ep.Workbook.Worksheets.Add("BrgBonus");
            //ep.Workbook.Worksheets.Add("OverdueFX30");

            foreach (ExcelWorksheet ws in ep.Workbook.Worksheets)
            {
                ws.View.ShowGridLines = false;
                ws.View.PageLayoutView = true;
                ws.View.PageBreakView = true;
                ws.PrinterSettings.FitToPage = true;
            }

            return ep;
        }

        private ExcelWorksheet OverdueWorksheet(DataSet ds, ExcelPackage ep, DateTime fromDate, DateTime toDate)
        {
            ExcelWorksheet ws = ep.Workbook.Worksheets["Overdue"];

            #region Header
            ws.Cells[1, 1].Value = "PENGAJUAN ACC PIUTANG OVERDUE";
            ws.Cells[2, 1].Value = "PERIODE : " + fromDate.ToString("dd/MM/yyyy") + " s/d " + toDate.ToString("dd/MM/yyyy");
            #endregion

            #region Table header
            ws.Cells[4, 1].Value = "NO.";
            ws.Cells[4, 2].Value = "NO.DO";
            ws.Cells[4, 3].Value = "TGL.DO";
            ws.Cells[4, 4].Value = "KD.SALES";
            ws.Cells[4, 5].Value = "TOKO";
            ws.Cells[4, 6].Value = "ALAMAT";
            ws.Cells[4, 7].Value = "KOTA";
            ws.Cells[4, 8].Value = "JNS TR";
            ws.Cells[4, 9].Value = "PLAFON";
            ws.Cells[4, 10].Value = "PIUTANG";
            ws.Cells[4, 11].Value = "GIT";
            ws.Cells[4, 12].Value = "GIRO";
            ws.Cells[4, 13].Value = "GIRO TOLAK";
            ws.Cells[4, 14].Value = "DO (Rp)";
            ws.Cells[4, 15].Value = "SISA PLF";
            ws.Cells[4, 16].Value = "OVERDUE";
            ws.Cells[4, 22].Value = "KEY";
            ws.Cells[4, 23].Value = "PIN";
            ws.Cells[4, 24].Value = "DI-ACC";
            ws.Cells[4, 25].Value = "TGL.ACC";
            ws.Cells[4, 26].Value = "CATATAN";
            ws.Cells[4, 27].Value = "KETERANGAN";

            ws.Cells[5, 16].Value = "OVD BE";
            ws.Cells[5, 17].Value = "LAMA (Hr)";
            ws.Cells[5, 18].Value = "OVD FX";
            ws.Cells[5, 19].Value = "LAMA (Hr)";
            ws.Cells[5, 20].Value = "OVERDUE";
            ws.Cells[5, 21].Value = "LAMA OVD (Hr)";

            ws.Column(1).Width = 4;
            #endregion

            #region Body
            int rowNo = 1;
            int stDataRow = 6;
            int rowCounter = 6;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ws.Cells[rowCounter, 1].Value = rowNo;
                ws.Cells[rowCounter, 2].Value = dr["NoDO"];
                ws.Cells[rowCounter, 3].Value = dr["TglDO"];
                ws.Cells[rowCounter, 4].Value = dr["KodeSales"];
                ws.Cells[rowCounter, 5].Value = dr["NamaToko"];
                ws.Cells[rowCounter, 6].Value = dr["Alamat"];
                ws.Cells[rowCounter, 7].Value = dr["Kota"];
                ws.Cells[rowCounter, 8].Value = dr["TransactionType"];
                ws.Cells[rowCounter, 9].Value = dr["plf_fb"];
                ws.Cells[rowCounter, 10].Value = dr["piutang"];
                ws.Cells[rowCounter, 11].Value = dr["GIT"];
                ws.Cells[rowCounter, 12].Value = dr["Giro"];
                ws.Cells[rowCounter, 13].Value = dr["GiroTolak"];
                ws.Cells[rowCounter, 14].Value = dr["SumRpNet"];
                ws.Cells[rowCounter, 15].Value = dr["sisaPlf"];
                ws.Cells[rowCounter, 16].Value = dr["ovdBE"];
                ws.Cells[rowCounter, 17].Value = dr["hrbe"];
                ws.Cells[rowCounter, 18].Value = dr["ovdFX"];
                ws.Cells[rowCounter, 19].Value = dr["hrfx"];
                ws.Cells[rowCounter, 20].Value = dr["ovdAll"];
                ws.Cells[rowCounter, 21].Value = dr["hrAll"];
                ws.Cells[rowCounter, 22].Value = Tools.GetKey(dr["RowID"].ToString(), GlobalVar.Gudang, PinId.Bagian.OverdueFB);

                rowNo++;

                rowCounter++;
            }
            #endregion

            #region Format Cells
            #region Border
            ws.Cells[1, 1].Style.Font.Size = 15;
            ws.Cells[1, 1, 5, 27].Style.Font.Bold = true;
            ws.Cells[4, 1, 5, 27].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 1, 5, 27].Style.Fill.BackgroundColor.SetColor(Color.LightCyan);

            var border = ws.Cells[4, 1, rowCounter, 27].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            #region Number
            ws.Cells[stDataRow, 3, rowCounter, 3].Style.Numberformat.Format = "dd/mm/yyyy";
            ws.Cells[stDataRow, 9, rowCounter, 21].Style.Numberformat.Format = "#,##0";
            #endregion
            #endregion

            #region Merge & Center
            ws.Cells[4, 1, 5, 1].Merge = true;
            ws.Cells[4, 2, 5, 2].Merge = true;
            ws.Cells[4, 3, 5, 3].Merge = true;
            ws.Cells[4, 4, 5, 4].Merge = true;
            ws.Cells[4, 5, 5, 5].Merge = true;
            ws.Cells[4, 6, 5, 6].Merge = true;
            ws.Cells[4, 7, 5, 7].Merge = true;
            ws.Cells[4, 8, 5, 8].Merge = true;
            ws.Cells[4, 9, 5, 9].Merge = true;
            ws.Cells[4, 10, 5, 10].Merge = true;
            ws.Cells[4, 11, 5, 11].Merge = true;
            ws.Cells[4, 12, 5, 12].Merge = true;
            ws.Cells[4, 13, 5, 13].Merge = true;
            ws.Cells[4, 14, 5, 14].Merge = true;
            ws.Cells[4, 15, 5, 15].Merge = true;
            ws.Cells[4, 16, 4, 21].Merge = true;
            ws.Cells[4, 22, 5, 22].Merge = true;
            ws.Cells[4, 23, 5, 23].Merge = true;
            ws.Cells[4, 24, 5, 24].Merge = true;
            ws.Cells[4, 25, 5, 25].Merge = true;
            ws.Cells[4, 26, 5, 26].Merge = true;
            ws.Cells[4, 27, 5, 27].Merge = true;

            ws.Cells[4, 1, 5, 27].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[4, 1, 5, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            for (int i = 2; i <= 27; i++)
            {
                ws.Column(i).AutoFit();
            }
            #endregion

            #region Footer
            rowCounter++;
            ws.Cells[rowCounter, 1].Value = "Printed by " + SecurityManager.UserID + ", " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            ws.Cells[rowCounter, 1].Style.Font.Size = 8;
            #endregion

            return ws;
        }

        private ExcelWorksheet OverdueNotaWorksheet(DataSet ds, ExcelPackage ep)
        {
            ExcelWorksheet ws = ep.Workbook.Worksheets["OverdueNota"];

            #region Header
            ws.Cells[1, 1].Value = "NOTA-NOTA OVERDUE";
            ws.Cells[2, 1].Value = "SAMPAI DENGAN: " + DateTime.Today.ToString("dd/MM/yyyy");
            #endregion

            #region Table header
            ws.Cells[4, 1].Value = "NO.";
            ws.Cells[4, 2].Value = "NO. NOTA";
            ws.Cells[4, 3].Value = "TGL. NOTA";
            ws.Cells[4, 4].Value = "JT";
            ws.Cells[4, 5].Value = "JW";
            ws.Cells[4, 6].Value = "JS";
            ws.Cells[4, 7].Value = "TGL.J.TEMPO";
            ws.Cells[4, 8].Value = "SALES";
            ws.Cells[4, 9].Value = "TOKO";
            ws.Cells[4, 10].Value = "ALAMAT";
            ws.Cells[4, 11].Value = "KOTA";
            ws.Cells[4, 12].Value = "SALDO PIUT OVD";
            
            ws.Column(1).Width = 4;
            #endregion

            #region Body
            int rowNo = 1;
            int stDataRow = 6;
            int rowCounter = 6;

            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                ws.Cells[rowCounter, 1].Value = rowNo;
                ws.Cells[rowCounter, 2].Value = dr["NoNota"];
                ws.Cells[rowCounter, 3].Value = dr["TglNota"];
                ws.Cells[rowCounter, 4].Value = dr["JT"];
                ws.Cells[rowCounter, 5].Value = dr["JW"];
                ws.Cells[rowCounter, 6].Value = dr["JS"];
                ws.Cells[rowCounter, 7].Value = dr["TglJatuhTempo"];
                ws.Cells[rowCounter, 8].Value = dr["NamaSales"];
                ws.Cells[rowCounter, 9].Value = dr["NamaToko"];
                ws.Cells[rowCounter, 10].Value = dr["Alamat"];
                ws.Cells[rowCounter, 11].Value = dr["Kota"];
                ws.Cells[rowCounter, 12].Value = dr["PiutangOverdue"];

                rowNo++;

                rowCounter++;
            }
            #endregion

            #region Format Cells
            #region Border
            ws.Cells[1, 1].Style.Font.Size = 15;
            ws.Cells[1, 1, 5, 12].Style.Font.Bold = true;
            ws.Cells[4, 1, 5, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 1, 5, 12].Style.Fill.BackgroundColor.SetColor(Color.LightCyan);

            var border = ws.Cells[4, 1, rowCounter, 12].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            #region Number
            ws.Cells[stDataRow, 3, rowCounter, 3].Style.Numberformat.Format = "dd/mm/yyyy";
            ws.Cells[stDataRow, 7, rowCounter, 7].Style.Numberformat.Format = "dd/mm/yyyy";
            ws.Cells[stDataRow, 12, rowCounter, 12].Style.Numberformat.Format = "#,##0";
            #endregion
            #endregion

            #region Merge & Center
            ws.Cells[4, 1, 5, 1].Merge = true;
            ws.Cells[4, 2, 5, 2].Merge = true;
            ws.Cells[4, 3, 5, 3].Merge = true;
            ws.Cells[4, 4, 5, 4].Merge = true;
            ws.Cells[4, 5, 5, 5].Merge = true;
            ws.Cells[4, 6, 5, 6].Merge = true;
            ws.Cells[4, 7, 5, 7].Merge = true;
            ws.Cells[4, 8, 5, 8].Merge = true;
            ws.Cells[4, 9, 5, 9].Merge = true;
            ws.Cells[4, 10, 5, 10].Merge = true;
            ws.Cells[4, 11, 5, 11].Merge = true;
            ws.Cells[4, 12, 5, 12].Merge = true;

            ws.Cells[4, 1, 5, 12].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[4, 1, 5, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            for (int i = 2; i <= 12; i++)
            {
                ws.Column(i).AutoFit();
            }
            #endregion

            #region Footer
            rowCounter++;
            ws.Cells[rowCounter, 1].Value = "Printed by " + SecurityManager.UserID + ", " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            ws.Cells[rowCounter, 1].Style.Font.Size = 8;
            #endregion

            return ws;
        }


        private ExcelWorksheet OverdueFXWorksheet(DataSet ds, ExcelPackage ep, DateTime fromDate, DateTime toDate)
        {
            ExcelWorksheet ws = ep.Workbook.Worksheets["OverdueFX"];

            #region Header
            ws.Cells[1, 1].Value = "PENGAJUAN ACC PIUTANG OVERDUE FX";
            ws.Cells[2, 1].Value = "PERIODE : " + fromDate.ToString("dd/MM/yyyy") + " s/d " + toDate.ToString("dd/MM/yyyy");
            #endregion

            #region Table header
            ws.Cells[4, 1].Value = "NO.";
            ws.Cells[4, 2].Value = "NO.DO";
            ws.Cells[4, 3].Value = "TGL.DO";
            ws.Cells[4, 4].Value = "KD.SALES";
            ws.Cells[4, 5].Value = "TOKO";
            ws.Cells[4, 6].Value = "ALAMAT";
            ws.Cells[4, 7].Value = "KOTA";
            ws.Cells[4, 8].Value = "JNS TR";
            ws.Cells[4, 9].Value = "PLAFON";
            ws.Cells[4, 10].Value = "PIUTANG";
            ws.Cells[4, 11].Value = "GIT";
            ws.Cells[4, 12].Value = "GIRO";
            ws.Cells[4, 13].Value = "GIRO TOLAK";
            ws.Cells[4, 14].Value = "DO (Rp)";
            ws.Cells[4, 15].Value = "SISA PLF";
            ws.Cells[4, 16].Value = "OVERDUE";
            ws.Cells[4, 22].Value = "KEY";
            ws.Cells[4, 23].Value = "PIN";
            ws.Cells[4, 24].Value = "DI-ACC";
            ws.Cells[4, 25].Value = "TGL.ACC";
            ws.Cells[4, 26].Value = "CATATAN";
            ws.Cells[4, 27].Value = "KETERANGAN";

            ws.Cells[5, 16].Value = "OVD BE";
            ws.Cells[5, 17].Value = "LAMA (Hr)";
            ws.Cells[5, 18].Value = "OVD FX";
            ws.Cells[5, 19].Value = "LAMA (Hr)";
            ws.Cells[5, 20].Value = "OVERDUE";
            ws.Cells[5, 21].Value = "LAMA OVD (Hr)";

            ws.Column(1).Width = 4;
            #endregion

            #region Body
            int rowNo = 1;
            int stDataRow = 6;
            int rowCounter = 6;

            foreach (DataRow dr in ds.Tables[4].Rows)
            {
                ws.Cells[rowCounter, 1].Value = rowNo;
                ws.Cells[rowCounter, 2].Value = dr["NoDO"];
                ws.Cells[rowCounter, 3].Value = dr["TglDO"];
                ws.Cells[rowCounter, 4].Value = dr["KodeSales"];
                ws.Cells[rowCounter, 5].Value = dr["NamaToko"];
                ws.Cells[rowCounter, 6].Value = dr["Alamat"];
                ws.Cells[rowCounter, 7].Value = dr["Kota"];
                ws.Cells[rowCounter, 8].Value = dr["TransactionType"];
                ws.Cells[rowCounter, 9].Value = dr["plf_fb"];
                ws.Cells[rowCounter, 10].Value = dr["piutang"];
                ws.Cells[rowCounter, 11].Value = dr["GIT"];
                ws.Cells[rowCounter, 12].Value = dr["Giro"];
                ws.Cells[rowCounter, 13].Value = dr["GiroTolak"];
                ws.Cells[rowCounter, 14].Value = dr["SumRpNet"];
                ws.Cells[rowCounter, 15].Value = dr["sisaPlf"];
                ws.Cells[rowCounter, 16].Value = dr["ovdBE"];
                ws.Cells[rowCounter, 17].Value = dr["hrbe"];
                ws.Cells[rowCounter, 18].Value = dr["ovdFX"];
                ws.Cells[rowCounter, 19].Value = dr["hrfx"];
                ws.Cells[rowCounter, 20].Value = dr["ovdAll"];
                ws.Cells[rowCounter, 21].Value = dr["hrAll"];
                ws.Cells[rowCounter, 22].Value = Tools.GetKey(dr["RowID"].ToString(), GlobalVar.Gudang, PinId.Bagian.OverdueFX);
                rowNo++;
                rowCounter++;
            }
            #endregion

            #region Format Cells
            #region Border
            ws.Cells[1, 1].Style.Font.Size = 15;
            ws.Cells[1, 1, 5, 27].Style.Font.Bold = true;
            ws.Cells[4, 1, 5, 27].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 1, 5, 27].Style.Fill.BackgroundColor.SetColor(Color.LightCyan);

            var border = ws.Cells[4, 1, rowCounter, 27].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            #region Number
            ws.Cells[stDataRow, 3, rowCounter, 3].Style.Numberformat.Format = "dd/mm/yyyy";
            ws.Cells[stDataRow, 9, rowCounter, 21].Style.Numberformat.Format = "#,##0";
            #endregion
            #endregion

            #region Merge & Center
            ws.Cells[4, 1, 5, 1].Merge = true;
            ws.Cells[4, 2, 5, 2].Merge = true;
            ws.Cells[4, 3, 5, 3].Merge = true;
            ws.Cells[4, 4, 5, 4].Merge = true;
            ws.Cells[4, 5, 5, 5].Merge = true;
            ws.Cells[4, 6, 5, 6].Merge = true;
            ws.Cells[4, 7, 5, 7].Merge = true;
            ws.Cells[4, 8, 5, 8].Merge = true;
            ws.Cells[4, 9, 5, 9].Merge = true;
            ws.Cells[4, 10, 5, 10].Merge = true;
            ws.Cells[4, 11, 5, 11].Merge = true;
            ws.Cells[4, 12, 5, 12].Merge = true;
            ws.Cells[4, 13, 5, 13].Merge = true;
            ws.Cells[4, 14, 5, 14].Merge = true;
            ws.Cells[4, 15, 5, 15].Merge = true;
            ws.Cells[4, 16, 4, 21].Merge = true;
            ws.Cells[4, 22, 5, 22].Merge = true;
            ws.Cells[4, 23, 5, 23].Merge = true;
            ws.Cells[4, 24, 5, 24].Merge = true;
            ws.Cells[4, 25, 5, 25].Merge = true;
            ws.Cells[4, 26, 5, 26].Merge = true;
            ws.Cells[4, 27, 5, 27].Merge = true;

            ws.Cells[4, 1, 5, 27].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[4, 1, 5, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            for (int i = 2; i <= 27; i++)
            {
                ws.Column(i).AutoFit();
            }
            #endregion

            #region Footer
            rowCounter++;
            ws.Cells[rowCounter, 1].Value = "Printed by " + SecurityManager.UserID + ", " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            ws.Cells[rowCounter, 1].Style.Font.Size = 8;
            #endregion

            return ws;
        }



        private ExcelWorksheet SalesBLWorksheet(DataSet ds, ExcelPackage ep)
        {
            ExcelWorksheet ws = ep.Workbook.Worksheets["SalesBL"];

            #region Header
            ws.Cells[1, 1].Value = "SALES BERMASALAH";
            ws.Cells[2, 1].Value = "SAMPAI DENGAN: " + DateTime.Today.ToString("dd/MM/yyyy");
            #endregion

            #region Table header
            ws.Cells[4, 1].Value = "NO.";
            ws.Cells[4, 2].Value = "KD.SALES";
            ws.Cells[4, 3].Value = "OVD > 90 Hr";

            ws.Column(1).Width = 4;
            #endregion

            #region Body
            int rowNo = 1;
            int rowCounter = 6;

            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                ws.Cells[rowCounter, 1].Value = rowNo;
                ws.Cells[rowCounter, 2].Value = dr["KodeSales"];
                ws.Cells[rowCounter, 3].Value = dr["Ovd90Hr"];
                ws.Cells[rowCounter, 3].Style.Numberformat.Format = "#,##0";
                rowNo++;

                rowCounter++;
            }
            #endregion

            #region Format Cells
            #region Border
            ws.Cells[1, 1].Style.Font.Size = 15;
            ws.Cells[1, 1, 5, 3].Style.Font.Bold = true;
            ws.Cells[4, 1, 5, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 1, 5, 3].Style.Fill.BackgroundColor.SetColor(Color.LightCyan);

            var border = ws.Cells[4, 1, rowCounter, 3].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion
            #endregion

            #region Merge & Center
            ws.Cells[4, 1, 5, 1].Merge = true;
            ws.Cells[4, 2, 5, 2].Merge = true;
            ws.Cells[4, 3, 5, 3].Merge = true;

            ws.Cells[4, 1, 5, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[4, 1, 5, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            for (int i = 2; i <= 3; i++)
            {
                ws.Column(i).AutoFit();
            }
            #endregion

            #region Footer
            rowCounter++;
            ws.Cells[rowCounter, 1].Value = "Printed by " + SecurityManager.UserID + ", " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            ws.Cells[rowCounter, 1].Style.Font.Size = 8;
            #endregion

            return ws;
        }

        private ExcelWorksheet DoSalesBLWorksheet(DataSet ds, ExcelPackage ep, DateTime fromDate, DateTime toDate)
        {
            ExcelWorksheet ws = ep.Workbook.Worksheets["DoSalesBL"];

            #region Header
            ws.Cells[1, 1].Value = "PENGAJUAN DO SALES BERMASALAH";
            ws.Cells[2, 1].Value = "PERIODE : " + fromDate.ToString("dd/MM/yyyy") + " s/d " + toDate.ToString("dd/MM/yyyy");
            #endregion

            #region Table header
            ws.Cells[4, 1].Value = "NO.";
            ws.Cells[4, 2].Value = "NO.DO";
            ws.Cells[4, 3].Value = "TGL.DO";
            ws.Cells[4, 4].Value = "KD.SALES";
            ws.Cells[4, 5].Value = "TOKO";
            ws.Cells[4, 6].Value = "ALAMAT";
            ws.Cells[4, 7].Value = "KOTA";
            ws.Cells[4, 8].Value = "PLAFON";
            ws.Cells[4, 9].Value = "PIUTANG";
            ws.Cells[4, 10].Value = "GIT";
            ws.Cells[4, 11].Value = "GIRO";
            ws.Cells[4, 12].Value = "GIRO TOLAK";
            ws.Cells[4, 13].Value = "DO (Rp)";
            ws.Cells[4, 14].Value = "SISA PLF";
            ws.Cells[4, 15].Value = "OVERDUE";
            ws.Cells[4, 16].Value = "LAMA OVD (Hr)";
            ws.Cells[4, 17].Value = "KEY";
            ws.Cells[4, 18].Value = "PIN";
            ws.Cells[4, 19].Value = "DI-ACC";
            ws.Cells[4, 20].Value = "TGL.ACC";
            ws.Cells[4, 21].Value = "CATATAN";
            ws.Cells[4, 22].Value = "KETERANGAN";


            ws.Column(1).Width = 4;
            #endregion

            #region Body
            int rowNo = 1;
            int stDataRow = 6;
            int rowCounter = 6;

            foreach (DataRow dr in ds.Tables[3].Rows)
            {
                ws.Cells[rowCounter, 1].Value = rowNo;
                ws.Cells[rowCounter, 2].Value = dr["NoDO"];
                ws.Cells[rowCounter, 3].Value = dr["TglDO"];
                ws.Cells[rowCounter, 4].Value = dr["KodeSales"];
                ws.Cells[rowCounter, 5].Value = dr["NamaToko"];
                ws.Cells[rowCounter, 6].Value = dr["Alamat"];
                ws.Cells[rowCounter, 7].Value = dr["Kota"];
                ws.Cells[rowCounter, 8].Value = dr["plf_fb"];
                ws.Cells[rowCounter, 9].Value = dr["piutang"];
                ws.Cells[rowCounter, 10].Value = dr["GIT"];
                ws.Cells[rowCounter, 11].Value = dr["Giro"];
                ws.Cells[rowCounter, 12].Value = dr["GiroTolak"];
                ws.Cells[rowCounter, 13].Value = dr["SumRpNet"];
                ws.Cells[rowCounter, 14].Value = dr["sisaPlf"];
                ws.Cells[rowCounter, 15].Value = dr["ovdBE"];
                ws.Cells[rowCounter, 16].Value = dr["hrbe"];
                ws.Cells[rowCounter, 17].Value = Tools.GetKey(dr["RowID"].ToString(), GlobalVar.Gudang, PinId.Bagian.SalesBL);

                rowNo++;

                rowCounter++;
            }
            #endregion

            #region Format Cells
            #region Border
            ws.Cells[1, 1].Style.Font.Size = 15;
            ws.Cells[1, 1, 5, 22].Style.Font.Bold = true;
            ws.Cells[4, 1, 5, 22].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 1, 5, 22].Style.Fill.BackgroundColor.SetColor(Color.LightCyan);

            var border = ws.Cells[4, 1, rowCounter, 22].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            #region Number
            ws.Cells[stDataRow, 3, rowCounter, 3].Style.Numberformat.Format = "dd/mm/yyyy";
            ws.Cells[stDataRow, 8, rowCounter, 15].Style.Numberformat.Format = "#,##0";
            #endregion
            #endregion

            #region Merge & Center
            ws.Cells[4, 1, 5, 1].Merge = true;
            ws.Cells[4, 2, 5, 2].Merge = true;
            ws.Cells[4, 3, 5, 3].Merge = true;
            ws.Cells[4, 4, 5, 4].Merge = true;
            ws.Cells[4, 5, 5, 5].Merge = true;
            ws.Cells[4, 6, 5, 6].Merge = true;
            ws.Cells[4, 7, 5, 7].Merge = true;
            ws.Cells[4, 8, 5, 8].Merge = true;
            ws.Cells[4, 9, 5, 9].Merge = true;
            ws.Cells[4, 10, 5, 10].Merge = true;
            ws.Cells[4, 11, 5, 11].Merge = true;
            ws.Cells[4, 12, 5, 12].Merge = true;
            ws.Cells[4, 13, 5, 13].Merge = true;
            ws.Cells[4, 14, 5, 14].Merge = true;
            ws.Cells[4, 15, 5, 15].Merge = true;
            ws.Cells[4, 16, 5, 16].Merge = true;
            ws.Cells[4, 17, 5, 17].Merge = true;
            ws.Cells[4, 18, 5, 18].Merge = true;
            ws.Cells[4, 19, 5, 19].Merge = true;
            ws.Cells[4, 20, 5, 20].Merge = true;
            ws.Cells[4, 21, 5, 21].Merge = true;
            ws.Cells[4, 22, 5, 22].Merge = true;

            ws.Cells[4, 1, 5, 22].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[4, 1, 5, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            for (int i = 2; i <= 22; i++)
            {
                ws.Column(i).AutoFit();
            }
            #endregion

            #region Footer
            rowCounter++;
            ws.Cells[rowCounter, 1].Value = "Printed by " + SecurityManager.UserID + ", " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            ws.Cells[rowCounter, 1].Style.Font.Size = 8;
            #endregion

            return ws;
        }

        private ExcelWorksheet OverdueNota90Worksheet(DataSet ds, ExcelPackage ep)
        {
            ExcelWorksheet ws = ep.Workbook.Worksheets["OverdueNota90"];

            #region Header
            ws.Cells[1, 1].Value = "OVERDUE NOTA LEBIH DARI 90 HARI";
            ws.Cells[2, 1].Value = "SAMPAI DENGAN: " + DateTime.Today.ToString("dd/MM/yyyy");
            #endregion

            #region Table header
            ws.Cells[4, 1].Value = "NO.";
            ws.Cells[4, 2].Value = "NO. NOTA";
            ws.Cells[4, 3].Value = "TGL. NOTA";
            ws.Cells[4, 4].Value = "JT";
            ws.Cells[4, 5].Value = "JW";
            ws.Cells[4, 6].Value = "JS";
            ws.Cells[4, 7].Value = "TGL.J.TEMPO";
            ws.Cells[4, 8].Value = "SALES";
            ws.Cells[4, 9].Value = "TOKO";
            ws.Cells[4, 10].Value = "ALAMAT";
            ws.Cells[4, 11].Value = "KOTA";
            ws.Cells[4, 12].Value = "OVERDUE";

            ws.Column(1).Width = 4;
            #endregion

            #region Body
            int rowNo = 1;
            int stDataRow = 6;
            int rowCounter = 6;

            foreach (DataRow dr in ds.Tables[4].Rows)
            {
                ws.Cells[rowCounter, 1].Value = rowNo;
                ws.Cells[rowCounter, 2].Value = dr["NoNota"];
                ws.Cells[rowCounter, 3].Value = dr["TglNota"];
                ws.Cells[rowCounter, 4].Value = dr["JT"];
                ws.Cells[rowCounter, 5].Value = dr["JW"];
                ws.Cells[rowCounter, 6].Value = dr["JS"];
                ws.Cells[rowCounter, 7].Value = dr["TglJatuhTempo"];
                ws.Cells[rowCounter, 8].Value = dr["KodeSales"];
                ws.Cells[rowCounter, 9].Value = dr["NamaToko"];
                ws.Cells[rowCounter, 10].Value = dr["Alamat"];
                ws.Cells[rowCounter, 11].Value = dr["Kota"];
                ws.Cells[rowCounter, 12].Value = dr["PiutangOverdue"];

                rowNo++;

                rowCounter++;
            }
            #endregion

            #region Format Cells
            #region Border
            ws.Cells[1, 1].Style.Font.Size = 15;
            ws.Cells[1, 1, 5, 12].Style.Font.Bold = true;
            ws.Cells[4, 1, 5, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 1, 5, 12].Style.Fill.BackgroundColor.SetColor(Color.LightCyan);

            var border = ws.Cells[4, 1, rowCounter, 12].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            #region Number
            ws.Cells[stDataRow, 3, rowCounter, 3].Style.Numberformat.Format = "dd/mm/yyyy";
            ws.Cells[stDataRow, 7, rowCounter, 7].Style.Numberformat.Format = "dd/mm/yyyy";
            ws.Cells[stDataRow, 12, rowCounter, 12].Style.Numberformat.Format = "#,##0";
            #endregion
            #endregion

            #region Merge & Center
            ws.Cells[4, 1, 5, 1].Merge = true;
            ws.Cells[4, 2, 5, 2].Merge = true;
            ws.Cells[4, 3, 5, 3].Merge = true;
            ws.Cells[4, 4, 5, 4].Merge = true;
            ws.Cells[4, 5, 5, 5].Merge = true;
            ws.Cells[4, 6, 5, 6].Merge = true;
            ws.Cells[4, 7, 5, 7].Merge = true;
            ws.Cells[4, 8, 5, 8].Merge = true;
            ws.Cells[4, 9, 5, 9].Merge = true;
            ws.Cells[4, 10, 5, 10].Merge = true;
            ws.Cells[4, 11, 5, 11].Merge = true;
            ws.Cells[4, 12, 5, 12].Merge = true;

            ws.Cells[4, 1, 5, 12].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[4, 1, 5, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            for (int i = 2; i <= 12; i++)
            {
                ws.Column(i).AutoFit();
            }
            #endregion

            #region Footer
            rowCounter++;
            ws.Cells[rowCounter, 1].Value = "Printed by " + SecurityManager.UserID + ", " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            ws.Cells[rowCounter, 1].Style.Font.Size = 8;
            #endregion

            return ws;
        }

        private ExcelWorksheet AccHargaWorksheet(DataSet ds, ExcelPackage ep, DateTime fromDate, DateTime toDate)
        {
            ExcelWorksheet ws = ep.Workbook.Worksheets["AccHarga"];

            #region Header
            ws.Cells[1, 1].Value = "PENGAJUAN HARGA";
            ws.Cells[2, 1].Value = "PERIODE : " + fromDate.ToString("dd/MM/yyyy") + " s/d " + toDate.ToString("dd/MM/yyyy");
            #endregion

            #region Table header
            ws.Cells[4, 1].Value = "NO.";
            ws.Cells[4, 2].Value = "NAMA STOK";
            ws.Cells[4, 3].Value = "ID.BRG";
            ws.Cells[4, 4].Value = "SAT";
            ws.Cells[4, 5].Value = "HARGA HPP";
            ws.Cells[4, 6].Value = "HARGA BMK";
            ws.Cells[4, 7].Value = "NO.DO";
            ws.Cells[4, 8].Value = "TGL.DO";
            ws.Cells[4, 9].Value = "HARGA DO";
            ws.Cells[4, 10].Value = "QTY DO";            
            ws.Cells[4, 11].Value = "KD.SALES";
            ws.Cells[4, 12].Value = "TOKO";
            ws.Cells[4, 13].Value = "ALAMAT";
            ws.Cells[4, 14].Value = "KETERANGAN";
            ws.Cells[4, 15].Value = "KEY";
            ws.Cells[4, 16].Value = "PIN";
            ws.Cells[4, 17].Value = "TGL.ACC";


            ws.Column(1).Width = 4;
            #endregion

            #region Body
            int rowNo = 1;
            int stDataRow = 6;
            int rowCounter = 6;

            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                ws.Cells[rowCounter, 1].Value = rowNo;
                ws.Cells[rowCounter, 2].Value = dr["NamaStok"];
                ws.Cells[rowCounter, 3].Value = dr["BarangID"];
                ws.Cells[rowCounter, 4].Value = dr["Satuan"];
                ws.Cells[rowCounter, 5].Value = dr["HPPSolo"];
                ws.Cells[rowCounter, 6].Value = dr["HrgBMK"];
                ws.Cells[rowCounter, 7].Value = dr["NoDO"];
                ws.Cells[rowCounter, 8].Value = dr["TglDO"];
                ws.Cells[rowCounter, 9].Value = dr["HrgJual"];
                ws.Cells[rowCounter, 10].Value = dr["QtyDO"];
                ws.Cells[rowCounter, 11].Value = dr["KodeSales"];
                ws.Cells[rowCounter, 12].Value = dr["NamaToko"];
                ws.Cells[rowCounter, 13].Value = dr["Alamat"];
                ws.Cells[rowCounter, 14].Value = dr["Keterangan"];
                ws.Cells[rowCounter, 15].Value = Tools.GetKey(dr["DetailRowID"].ToString(), GlobalVar.Gudang, PinId.Bagian.Harga);

                rowNo++;

                rowCounter++;
            }
            #endregion

            #region Format Cells
            #region Border
            ws.Cells[1, 1].Style.Font.Size = 15;
            ws.Cells[1, 1, 5, 17].Style.Font.Bold = true;
            ws.Cells[4, 1, 5, 17].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 1, 5, 17].Style.Fill.BackgroundColor.SetColor(Color.LightCyan);

            var border = ws.Cells[4, 1, rowCounter, 17].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            #region Number
            ws.Cells[stDataRow, 5, rowCounter, 6].Style.Numberformat.Format = "#,##0";
            ws.Cells[stDataRow, 8, rowCounter, 8].Style.Numberformat.Format = "dd/mm/yyyy";
            ws.Cells[stDataRow, 9, rowCounter, 9].Style.Numberformat.Format = "#,##0";
            #endregion
            #endregion

            #region Merge & Center
            ws.Cells[4, 1, 5, 1].Merge = true;
            ws.Cells[4, 2, 5, 2].Merge = true;
            ws.Cells[4, 3, 5, 3].Merge = true;
            ws.Cells[4, 4, 5, 4].Merge = true;
            ws.Cells[4, 5, 5, 5].Merge = true;
            ws.Cells[4, 6, 5, 6].Merge = true;
            ws.Cells[4, 7, 5, 7].Merge = true;
            ws.Cells[4, 8, 5, 8].Merge = true;
            ws.Cells[4, 9, 5, 9].Merge = true;
            ws.Cells[4, 10, 5, 10].Merge = true;
            ws.Cells[4, 11, 5, 11].Merge = true;
            ws.Cells[4, 12, 5, 12].Merge = true;
            ws.Cells[4, 13, 5, 13].Merge = true;
            ws.Cells[4, 14, 5, 14].Merge = true;
            ws.Cells[4, 15, 5, 15].Merge = true;
            ws.Cells[4, 16, 5, 16].Merge = true;
            ws.Cells[4, 17, 5, 17].Merge = true;

            ws.Cells[4, 1, 5, 17].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[4, 1, 5, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            for (int i = 2; i <= 17; i++)
            {
                ws.Column(i).AutoFit();
            }
            #endregion

            #region Footer
            rowCounter++;
            ws.Cells[rowCounter, 1].Value = "Printed by " + SecurityManager.UserID + ", " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            ws.Cells[rowCounter, 1].Style.Font.Size = 8;
            #endregion

            return ws;
        }

        private ExcelWorksheet BrgBonusWorksheet(DataSet ds, ExcelPackage ep, DateTime fromDate, DateTime toDate)
        {
            ExcelWorksheet ws = ep.Workbook.Worksheets["BrgBonus"];

            #region Header
            ws.Cells[1, 1].Value = "PENGAJUAN PENGELUARAN BARANG BONUS";
            ws.Cells[2, 1].Value = "PERIODE : " + fromDate.ToString("dd/MM/yyyy") + " s/d " + fromDate.ToString("dd/MM/yyyy");
            #endregion

            #region Table header
            ws.Cells[4, 1].Value = "NO.";
            ws.Cells[4, 2].Value = "NO.DO";
            ws.Cells[4, 3].Value = "TGL.DO";
            ws.Cells[4, 4].Value = "KD.SALES";
            ws.Cells[4, 5].Value = "TOKO";
            ws.Cells[4, 6].Value = "ALAMAT";
            ws.Cells[4, 7].Value = "KOTA";
            ws.Cells[4, 8].Value = "NAMA STOK";
            ws.Cells[4, 9].Value = "ID.BRG";
            ws.Cells[4, 10].Value = "KEY";
            ws.Cells[4, 11].Value = "PIN";
            ws.Cells[4, 12].Value = "TGL.ACC";
            ws.Cells[4, 13].Value = "DI-ACC";

            ws.Column(1).Width = 4;
            #endregion

            #region Body
            int rowNo = 1;
            int stDataRow = 6;
            int rowCounter = 6;

            foreach (DataRow dr in ds.Tables[3].Rows)
            {
                ws.Cells[rowCounter, 1].Value = rowNo;
                ws.Cells[rowCounter, 2].Value = dr["NoDO"];
                ws.Cells[rowCounter, 3].Value = dr["TglDO"];
                ws.Cells[rowCounter, 4].Value = dr["KodeSales"];
                ws.Cells[rowCounter, 5].Value = dr["NamaToko"];
                ws.Cells[rowCounter, 6].Value = dr["Alamat"];
                ws.Cells[rowCounter, 7].Value = dr["Kota"];
                ws.Cells[rowCounter, 8].Value = dr["NamaStok"];
                ws.Cells[rowCounter, 9].Value = dr["BarangID"];
                ws.Cells[rowCounter, 10].Value = Tools.GetKey(dr["RowID"].ToString(), GlobalVar.Gudang, PinId.Bagian.Bonus);

                rowNo++;

                rowCounter++;
            }
            #endregion

            #region Format Cells
            #region Border
            ws.Cells[1, 1].Style.Font.Size = 15;
            ws.Cells[1, 1, 5, 13].Style.Font.Bold = true;
            ws.Cells[4, 1, 5, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 1, 5, 13].Style.Fill.BackgroundColor.SetColor(Color.LightCyan);

            var border = ws.Cells[4, 1, rowCounter, 13].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            #region Number
            ws.Cells[stDataRow, 3, rowCounter, 3].Style.Numberformat.Format = "dd/mm/yyyy";
            #endregion
            #endregion

            #region Merge & Center
            ws.Cells[4, 1, 5, 1].Merge = true;
            ws.Cells[4, 2, 5, 2].Merge = true;
            ws.Cells[4, 3, 5, 3].Merge = true;
            ws.Cells[4, 4, 5, 4].Merge = true;
            ws.Cells[4, 5, 5, 5].Merge = true;
            ws.Cells[4, 6, 5, 6].Merge = true;
            ws.Cells[4, 7, 5, 7].Merge = true;
            ws.Cells[4, 8, 5, 8].Merge = true;
            ws.Cells[4, 9, 5, 9].Merge = true;
            ws.Cells[4, 10, 5, 10].Merge = true;
            ws.Cells[4, 11, 5, 11].Merge = true;
            ws.Cells[4, 12, 5, 12].Merge = true;
            ws.Cells[4, 13, 5, 13].Merge = true;

            ws.Cells[4, 1, 5, 13].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[4, 1, 5, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            for (int i = 2; i <= 13; i++)
            {
                ws.Column(i).AutoFit();
            }
            #endregion

            #region Footer
            rowCounter++;
            ws.Cells[rowCounter, 1].Value = "Printed by " + SecurityManager.UserID + ", " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            ws.Cells[rowCounter, 1].Style.Font.Size = 8;
            #endregion

            return ws;
        }

        private ExcelWorksheet OverdueFX30Worksheet(DataSet ds, ExcelPackage ep, DateTime fromDate, DateTime toDate)
        {
            ExcelWorksheet ws = ep.Workbook.Worksheets["OverdueFX30"];

            #region Header
            ws.Cells[1, 1].Value = "INFORMASI OVERDUE FX DENGAN UMUR PIUTANG LEBIH 30 HARI";
            ws.Cells[2, 1].Value = "PERIODE : " + fromDate.ToString("dd/MM/yyyy") + " s/d " + toDate.ToString("dd/MM/yyyy");
            #endregion

            #region Table header
            ws.Cells[4, 1].Value = "NO.";
            ws.Cells[4, 2].Value = "NO.DO";
            ws.Cells[4, 3].Value = "TGL.DO";
            ws.Cells[4, 4].Value = "KD.SALES";
            ws.Cells[4, 5].Value = "TOKO";
            ws.Cells[4, 6].Value = "ALAMAT";
            ws.Cells[4, 7].Value = "KOTA";
            ws.Cells[4, 8].Value = "JNS TR";
            ws.Cells[4, 9].Value = "PLAFON";
            ws.Cells[4, 10].Value = "PIUTANG";
            ws.Cells[4, 11].Value = "GIT";
            ws.Cells[4, 12].Value = "GIRO";
            ws.Cells[4, 13].Value = "GIRO TOLAK";
            ws.Cells[4, 14].Value = "DO (Rp)";
            ws.Cells[4, 15].Value = "SISA PLF";
            ws.Cells[4, 16].Value = "OVERDUE";
            ws.Cells[4, 22].Value = "KEY";
            ws.Cells[4, 23].Value = "PIN";
            ws.Cells[4, 24].Value = "DI-ACC";
            ws.Cells[4, 25].Value = "TGL.ACC";
            ws.Cells[4, 26].Value = "CATATAN";
            ws.Cells[4, 27].Value = "KETERANGAN";

            ws.Cells[5, 16].Value = "OVD BE";
            ws.Cells[5, 17].Value = "LAMA (Hr)";
            ws.Cells[5, 18].Value = "OVD FX";
            ws.Cells[5, 19].Value = "LAMA (Hr)";
            ws.Cells[5, 20].Value = "OVERDUE";
            ws.Cells[5, 21].Value = "LAMA OVD (Hr)";

            ws.Column(1).Width = 4;
            #endregion

            #region Body
            int rowNo = 1;
            int stDataRow = 6;
            int rowCounter = 6;

            foreach (DataRow dr in ds.Tables[5].Rows)
            {
                ws.Cells[rowCounter, 1].Value = rowNo;
                ws.Cells[rowCounter, 2].Value = dr["NoDO"];
                ws.Cells[rowCounter, 3].Value = dr["TglDO"];
                ws.Cells[rowCounter, 4].Value = dr["KodeSales"];
                ws.Cells[rowCounter, 5].Value = dr["NamaToko"];
                ws.Cells[rowCounter, 6].Value = dr["Alamat"];
                ws.Cells[rowCounter, 7].Value = dr["Kota"];
                ws.Cells[rowCounter, 8].Value = dr["TransactionType"];
                ws.Cells[rowCounter, 9].Value = dr["plf_fb"];
                ws.Cells[rowCounter, 10].Value = dr["piutang"];
                ws.Cells[rowCounter, 11].Value = dr["GIT"];
                ws.Cells[rowCounter, 12].Value = dr["Giro"];
                ws.Cells[rowCounter, 13].Value = dr["GiroTolak"];
                ws.Cells[rowCounter, 14].Value = dr["SumRpNet"];
                ws.Cells[rowCounter, 15].Value = dr["sisaPlf"];
                ws.Cells[rowCounter, 16].Value = dr["ovdBE"];
                ws.Cells[rowCounter, 17].Value = dr["hrbe"];
                ws.Cells[rowCounter, 18].Value = dr["ovdFX"];
                ws.Cells[rowCounter, 19].Value = dr["hrfx"];
                ws.Cells[rowCounter, 20].Value = dr["ovdAll"];
                ws.Cells[rowCounter, 21].Value = dr["hrAll"];
                ws.Cells[rowCounter, 22].Value = Tools.GetKey(dr["RowID"].ToString(), GlobalVar.Gudang, PinId.Bagian.OverdueFX);
                rowNo++;
                rowCounter++;
            }
            #endregion

            #region Format Cells
            #region Border
            ws.Cells[1, 1].Style.Font.Size = 15;
            ws.Cells[1, 1, 5, 27].Style.Font.Bold = true;
            ws.Cells[4, 1, 5, 27].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[4, 1, 5, 27].Style.Fill.BackgroundColor.SetColor(Color.LightCyan);

            var border = ws.Cells[4, 1, rowCounter, 27].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;
            #endregion

            #region Number
            ws.Cells[stDataRow, 3, rowCounter, 3].Style.Numberformat.Format = "dd/mm/yyyy";
            ws.Cells[stDataRow, 9, rowCounter, 21].Style.Numberformat.Format = "#,##0";
            #endregion
            #endregion

            #region Merge & Center
            ws.Cells[4, 1, 5, 1].Merge = true;
            ws.Cells[4, 2, 5, 2].Merge = true;
            ws.Cells[4, 3, 5, 3].Merge = true;
            ws.Cells[4, 4, 5, 4].Merge = true;
            ws.Cells[4, 5, 5, 5].Merge = true;
            ws.Cells[4, 6, 5, 6].Merge = true;
            ws.Cells[4, 7, 5, 7].Merge = true;
            ws.Cells[4, 8, 5, 8].Merge = true;
            ws.Cells[4, 9, 5, 9].Merge = true;
            ws.Cells[4, 10, 5, 10].Merge = true;
            ws.Cells[4, 11, 5, 11].Merge = true;
            ws.Cells[4, 12, 5, 12].Merge = true;
            ws.Cells[4, 13, 5, 13].Merge = true;
            ws.Cells[4, 14, 5, 14].Merge = true;
            ws.Cells[4, 15, 5, 15].Merge = true;
            ws.Cells[4, 16, 4, 21].Merge = true;
            ws.Cells[4, 22, 5, 22].Merge = true;
            ws.Cells[4, 23, 5, 23].Merge = true;
            ws.Cells[4, 24, 5, 24].Merge = true;
            ws.Cells[4, 25, 5, 25].Merge = true;
            ws.Cells[4, 26, 5, 26].Merge = true;
            ws.Cells[4, 27, 5, 27].Merge = true;

            ws.Cells[4, 1, 5, 27].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[4, 1, 5, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            for (int i = 2; i <= 27; i++)
            {
                ws.Column(i).AutoFit();
            }
            #endregion

            #region Footer
            rowCounter++;
            ws.Cells[rowCounter, 1].Value = "Printed by " + SecurityManager.UserID + ", " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            ws.Cells[rowCounter, 1].Style.Font.Size = 8;
            #endregion

            return ws;
        }

        private bool SavePengajuan(ExcelPackage ep)
        {
            bool isSaved = true;

            try
            {
                string directory = "C:\\Temp\\";
                string fileName = "Pengajuan_DO_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
                string filePath = directory + fileName;

                Byte[] bin = ep.GetAsByteArray();

                if (File.Exists(filePath))
                {
                    SaveFileDialog sf = new SaveFileDialog();
                    sf.InitialDirectory = "C:\\Temp\\";
                    sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                    sf.FileName = fileName;
                    sf.OverwritePrompt = true;
                    if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                    {
                        filePath = sf.FileName.ToString();
                    }
                }

                File.WriteAllBytes(filePath, bin);
                Process.Start(filePath);
                MessageBox.Show("Pembuatan pengajuan telah selesai dan disimpan di: " + "\n" + filePath + ".\n" +
                    "Selanjutnya akan dilakukan proses upload pengajuan harga FB/FE.");
            }
            catch (Exception ex)
            {
                isSaved = false;

                Error.LogError(ex);
            }

            return isSaved;
        }

        private bool GeneratePengajuan(DateTime fromDate, DateTime toDate)
        {
            bool isGenerated = true;

            try
            {
                DataSet ds = PengajuanDataset(fromDate, toDate);

                int allRows = 0;
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (i == 0 || i == 2 || i == 3 || i == 4)   // || i == 5) -> overdue FX dengan umur piutang lebih dari 30 hari 
                    {
                        allRows += ds.Tables[i].Rows.Count;
                    }
                }

                if (allRows > 0)
                {
                    ExcelPackage ep = PengajuanWorksheets();
                    ExcelWorksheet wsOverdue = OverdueWorksheet(ds, ep, fromDate, toDate);
                    ExcelWorksheet wsOverdueFX = OverdueFXWorksheet(ds, ep, fromDate, toDate);
                    ExcelWorksheet wsOverdueNota = OverdueNotaWorksheet(ds, ep);
                    //ExcelWorksheet wsSalesBL = SalesBLWorksheet(ds, ep);
                    //ExcelWorksheet wsDoSalesBL = DoSalesBLWorksheet(ds, ep, fromDate, toDate);
                    //ExcelWorksheet wsOverdueNota90 = OverdueNota90Worksheet(ds, ep);
                    //ExcelWorksheet wsAccHarga = AccHargaWorksheet(ds, ep, fromDate, toDate);
                    ExcelWorksheet wsBrgBonus = BrgBonusWorksheet(ds, ep, fromDate, toDate);
                    //ExcelWorksheet wsOverdueFX30 = OverdueFX30Worksheet(ds, ep, fromDate, toDate);
                    isGenerated = SavePengajuan(ep);
                }
                else
                {
                    isGenerated = false;
                }
            }
            catch(Exception ex)
            {
                isGenerated = false;

                Error.LogError(ex);
            }

            return isGenerated;
        }

        private void UpdatePengajuan(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updatePengajuan"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    dt = db.Commands[0].ExecuteDataTable();
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private bool Upload(DateTime fromDate, DateTime toDate)
        {
            bool isUploaded = true;

            DataSet ds = new DataSet();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Pengajuan_Harga_UPLOAD"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                ds = db.Commands[0].ExecuteDataSet();
            }

            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                string physical1 = GlobalVar.DbfUpload + "\\" + fileName1 + ".dbf";
                string physical2 = GlobalVar.DbfUpload + "\\" + fileName2 + ".dbf";

                if (File.Exists(physical1))
                {
                    File.Delete(physical1);
                }

                if (File.Exists(physical2))
                {
                    File.Delete(physical2);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("HtrID", "Idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Cabang1", "Cab1", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang2", "Cab2", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang3", "Cab3", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("NoRequest", "No_rq", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglRequest", "Tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoDO", "No_do", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglDO", "Tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoACCPiutang", "No_nota", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglACCPiutang", "Tgl_nota", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("StatusBatal", "No_sj", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglSuratJalan", "Tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglTerima", "Tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("HariKredit", "Hr_krdt", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("TokoId", "Kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("KodeSales", "Kd_sales", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("NamaToko", "Nm_toko", Foxpro.enFoxproTypes.Char, 31));
                fields.Add(new Foxpro.DataStruct("AlamatKirim", "Al_kirim", Foxpro.enFoxproTypes.Char, 60));
                fields.Add(new Foxpro.DataStruct("Kota", "Kota", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("RpJual", "Rp_jual", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpJual2", "Rp_jual2", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpJual3", "Rp_jual3", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNet", "Rp_net", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNet2", "Rp_net2", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNet3", "Rp_net3", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("Disc1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("RpPot", "Pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("Plafon", "Pot_rp2", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("SaldoPiutang", "Pot_rp3", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("QtyTolak", "Rp_fee1", Foxpro.enFoxproTypes.Numeric, 11));
                fields.Add(new Foxpro.DataStruct("Overdue", "Rp_fee2", Foxpro.enFoxproTypes.Numeric, 11));
                fields.Add(new Foxpro.DataStruct("Expedisi", "Expedisi", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("isClosed", "Laudit", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("DiscFormula", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Memo, 4));
                fields.Add(new Foxpro.DataStruct("NoDOBO", "No_dobo", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglReorder", "Tgl_reord", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("StatusBO", "Lbo", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("LinkID", "Id_link", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("TransactionType", "Id_tr", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("HariKirim", "Hari_krm", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("HariSales", "Hari_sls", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("NPrint", "Nprint", Foxpro.enFoxproTypes.Numeric, 2));
                fields.Add(new Foxpro.DataStruct("NoACCPusat", "No_acc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Shift", "Shift", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("ACCPiutangID", "Checker_1", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("Checker2", "Checker_2", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("Catatan1", "Catatan1", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan2", "Catatan2", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan3", "Catatan3", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan4", "Catatan4", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan5", "Catatan5", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Cicil", "Cicil", Foxpro.enFoxproTypes.Numeric, 2));

                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                index.Add(new Foxpro.IndexStruct("idhtr", "IDHTR"));

                Foxpro.WriteFile(GlobalVar.DbfUpload, fileName1, fields, ds.Tables[0]);


                List<Foxpro.DataStruct> fields2 = new List<Foxpro.DataStruct>();

                fields2.Add(new Foxpro.DataStruct("RecordID", "Idrec", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("HtrID", "Idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("NamaStok", "Nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields2.Add(new Foxpro.DataStruct("KodeSolo", "Klp", Foxpro.enFoxproTypes.Char, 3));
                fields2.Add(new Foxpro.DataStruct("QtyRequest", "J_rq", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtyDO", "J_do", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtySuratJalan", "J_sj", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtyNota", "J_nota", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtyRetur", "J_retur", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtyKoli", "J_koli", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("KoliAwal", "Koli_awal", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("KoliAkhir", "Koli_akhir", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("NoKoli", "No_koli", Foxpro.enFoxproTypes.Char, 15));
                fields2.Add(new Foxpro.DataStruct("Satuan", "Satuan", Foxpro.enFoxproTypes.Char, 3));
                fields2.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("TglSuratJalan", "Tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields2.Add(new Foxpro.DataStruct("HrgJual", "H_jual", Foxpro.enFoxproTypes.Numeric, 7));
                fields2.Add(new Foxpro.DataStruct("HargaPokok", "H_pokok", Foxpro.enFoxproTypes.Numeric, 7));
                fields2.Add(new Foxpro.DataStruct("HPPSolo", "Hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
                fields2.Add(new Foxpro.DataStruct("Disc1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("Disc2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("Disc3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("Pot", "Pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields2.Add(new Foxpro.DataStruct("DiscFormula", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields2.Add(new Foxpro.DataStruct("KoreksiID", "Id_koreksi", Foxpro.enFoxproTypes.Char, 19));
                fields2.Add(new Foxpro.DataStruct("KodeToko", "Kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields2.Add(new Foxpro.DataStruct("NoDOBO", "No_bodo", Foxpro.enFoxproTypes.Char, 7));
                fields2.Add(new Foxpro.DataStruct("SyncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
                fields2.Add(new Foxpro.DataStruct("NBOPrint", "Nprint", Foxpro.enFoxproTypes.Numeric, 1));
                fields2.Add(new Foxpro.DataStruct("NoACC", "No_acc", Foxpro.enFoxproTypes.Char, 7));
                fields2.Add(new Foxpro.DataStruct("KetKoli", "Ket_koli", Foxpro.enFoxproTypes.Char, 20));
                fields2.Add(new Foxpro.DataStruct("BarangID", "Id_brg", Foxpro.enFoxproTypes.Char, 23));

                List<Foxpro.IndexStruct> index2 = new List<Foxpro.IndexStruct>();
                index2.Add(new Foxpro.IndexStruct("idhtr", "IDHTR"));

                Foxpro.WriteFile(GlobalVar.DbfUpload, fileName2, fields2, ds.Tables[1]);
            }
            else
            {
                isUploaded = false;
            }

            return isUploaded;
        }



        private bool Uploadfx(DateTime fromDate, DateTime toDate)
        {
            bool isUploaded = true;

            DataSet ds = new DataSet();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Pengajuan_HargaFX_UPLOAD"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                ds = db.Commands[0].ExecuteDataSet();
            }

            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                string physical1 = GlobalVar.DbfUpload + "\\" + fileName1 + ".dbf";
                string physical2 = GlobalVar.DbfUpload + "\\" + fileName2 + ".dbf";

                if (File.Exists(physical1))
                {
                    File.Delete(physical1);
                }

                if (File.Exists(physical2))
                {
                    File.Delete(physical2);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("HtrID", "Idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Cabang1", "Cab1", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang2", "Cab2", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang3", "Cab3", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("NoRequest", "No_rq", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglRequest", "Tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoDO", "No_do", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglDO", "Tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoACCPiutang", "No_nota", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglACCPiutang", "Tgl_nota", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("StatusBatal", "No_sj", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglSuratJalan", "Tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglTerima", "Tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("HariKredit", "Hr_krdt", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("TokoId", "Kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("KodeSales", "Kd_sales", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("NamaToko", "Nm_toko", Foxpro.enFoxproTypes.Char, 31));
                fields.Add(new Foxpro.DataStruct("AlamatKirim", "Al_kirim", Foxpro.enFoxproTypes.Char, 60));
                fields.Add(new Foxpro.DataStruct("Kota", "Kota", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("RpJual", "Rp_jual", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpJual2", "Rp_jual2", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpJual3", "Rp_jual3", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNet", "Rp_net", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNet2", "Rp_net2", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNet3", "Rp_net3", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("Disc1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("RpPot", "Pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("Plafon", "Pot_rp2", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("SaldoPiutang", "Pot_rp3", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("QtyTolak", "Rp_fee1", Foxpro.enFoxproTypes.Numeric, 11));
                fields.Add(new Foxpro.DataStruct("Overdue", "Rp_fee2", Foxpro.enFoxproTypes.Numeric, 11));
                fields.Add(new Foxpro.DataStruct("Expedisi", "Expedisi", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("isClosed", "Laudit", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("DiscFormula", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Memo, 4));
                fields.Add(new Foxpro.DataStruct("NoDOBO", "No_dobo", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglReorder", "Tgl_reord", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("StatusBO", "Lbo", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("LinkID", "Id_link", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("TransactionType", "Id_tr", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("HariKirim", "Hari_krm", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("HariSales", "Hari_sls", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("NPrint", "Nprint", Foxpro.enFoxproTypes.Numeric, 2));
                fields.Add(new Foxpro.DataStruct("NoACCPusat", "No_acc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Shift", "Shift", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("ACCPiutangID", "Checker_1", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("Checker2", "Checker_2", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("Catatan1", "Catatan1", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan2", "Catatan2", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan3", "Catatan3", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan4", "Catatan4", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan5", "Catatan5", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Cicil", "Cicil", Foxpro.enFoxproTypes.Numeric, 2));

                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                index.Add(new Foxpro.IndexStruct("idhtr", "IDHTR"));

                Foxpro.WriteFile(GlobalVar.DbfUpload, fileName1, fields, ds.Tables[0]);


                List<Foxpro.DataStruct> fields2 = new List<Foxpro.DataStruct>();

                fields2.Add(new Foxpro.DataStruct("RecordID", "Idrec", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("HtrID", "Idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("NamaStok", "Nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields2.Add(new Foxpro.DataStruct("KodeSolo", "Klp", Foxpro.enFoxproTypes.Char, 3));
                fields2.Add(new Foxpro.DataStruct("QtyRequest", "J_rq", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtyDO", "J_do", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtySuratJalan", "J_sj", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtyNota", "J_nota", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtyRetur", "J_retur", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtyKoli", "J_koli", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("KoliAwal", "Koli_awal", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("KoliAkhir", "Koli_akhir", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("NoKoli", "No_koli", Foxpro.enFoxproTypes.Char, 15));
                fields2.Add(new Foxpro.DataStruct("Satuan", "Satuan", Foxpro.enFoxproTypes.Char, 3));
                fields2.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("TglSuratJalan", "Tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields2.Add(new Foxpro.DataStruct("HrgJual", "H_jual", Foxpro.enFoxproTypes.Numeric, 7));
                fields2.Add(new Foxpro.DataStruct("HargaPokok", "H_pokok", Foxpro.enFoxproTypes.Numeric, 7));
                fields2.Add(new Foxpro.DataStruct("HPPSolo", "Hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
                fields2.Add(new Foxpro.DataStruct("Disc1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("Disc2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("Disc3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("Pot", "Pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields2.Add(new Foxpro.DataStruct("DiscFormula", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields2.Add(new Foxpro.DataStruct("KoreksiID", "Id_koreksi", Foxpro.enFoxproTypes.Char, 19));
                fields2.Add(new Foxpro.DataStruct("KodeToko", "Kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields2.Add(new Foxpro.DataStruct("NoDOBO", "No_bodo", Foxpro.enFoxproTypes.Char, 7));
                fields2.Add(new Foxpro.DataStruct("SyncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
                fields2.Add(new Foxpro.DataStruct("NBOPrint", "Nprint", Foxpro.enFoxproTypes.Numeric, 1));
                fields2.Add(new Foxpro.DataStruct("NoACC", "No_acc", Foxpro.enFoxproTypes.Char, 7));
                fields2.Add(new Foxpro.DataStruct("KetKoli", "Ket_koli", Foxpro.enFoxproTypes.Char, 20));
                fields2.Add(new Foxpro.DataStruct("BarangID", "Id_brg", Foxpro.enFoxproTypes.Char, 23));

                List<Foxpro.IndexStruct> index2 = new List<Foxpro.IndexStruct>();
                index2.Add(new Foxpro.IndexStruct("idhtr", "IDHTR"));

                Foxpro.WriteFile(GlobalVar.DbfUpload, fileName2, fields2, ds.Tables[1]);
            }
            else
            {
                isUploaded = false;
            }

            return isUploaded;
        }



        private bool UploadBusiVanbelt(DateTime fromDate, DateTime toDate)
        {
            bool isUploaded = true;

            DataSet ds = new DataSet();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Pengajuan_HargaBV_UPLOAD"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                ds = db.Commands[0].ExecuteDataSet();
            }

            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                string physical1 = GlobalVar.DbfUpload + "\\" + fileName1 + ".dbf";
                string physical2 = GlobalVar.DbfUpload + "\\" + fileName2 + ".dbf";

                if (File.Exists(physical1))
                {
                    File.Delete(physical1);
                }

                if (File.Exists(physical2))
                {
                    File.Delete(physical2);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("HtrID", "Idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Cabang1", "Cab1", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang2", "Cab2", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("Cabang3", "Cab3", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("NoRequest", "No_rq", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglRequest", "Tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoDO", "No_do", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglDO", "Tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoACCPiutang", "No_nota", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglACCPiutang", "Tgl_nota", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("StatusBatal", "No_sj", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglSuratJalan", "Tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglTerima", "Tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("HariKredit", "Hr_krdt", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("TokoId", "Kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("KodeSales", "Kd_sales", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("NamaToko", "Nm_toko", Foxpro.enFoxproTypes.Char, 31));
                fields.Add(new Foxpro.DataStruct("AlamatKirim", "Al_kirim", Foxpro.enFoxproTypes.Char, 60));
                fields.Add(new Foxpro.DataStruct("Kota", "Kota", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("RpJual", "Rp_jual", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpJual2", "Rp_jual2", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpJual3", "Rp_jual3", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNet", "Rp_net", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNet2", "Rp_net2", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("RpNet3", "Rp_net3", Foxpro.enFoxproTypes.Numeric, 14));
                fields.Add(new Foxpro.DataStruct("Disc1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("Disc3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("RpPot", "Pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("Plafon", "Pot_rp2", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("SaldoPiutang", "Pot_rp3", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("QtyTolak", "Rp_fee1", Foxpro.enFoxproTypes.Numeric, 11));
                fields.Add(new Foxpro.DataStruct("Overdue", "Rp_fee2", Foxpro.enFoxproTypes.Numeric, 11));
                fields.Add(new Foxpro.DataStruct("Expedisi", "Expedisi", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("isClosed", "Laudit", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("DiscFormula", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Memo, 4));
                fields.Add(new Foxpro.DataStruct("NoDOBO", "No_dobo", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("TglReorder", "Tgl_reord", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("StatusBO", "Lbo", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("LinkID", "Id_link", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("TransactionType", "Id_tr", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("HariKirim", "Hari_krm", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("HariSales", "Hari_sls", Foxpro.enFoxproTypes.Numeric, 3));
                fields.Add(new Foxpro.DataStruct("NPrint", "Nprint", Foxpro.enFoxproTypes.Numeric, 2));
                fields.Add(new Foxpro.DataStruct("NoACCPusat", "No_acc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Shift", "Shift", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("ACCPiutangID", "Checker_1", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("Checker2", "Checker_2", Foxpro.enFoxproTypes.Char, 11));
                fields.Add(new Foxpro.DataStruct("Catatan1", "Catatan1", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan2", "Catatan2", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan3", "Catatan3", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan4", "Catatan4", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Catatan5", "Catatan5", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("Cicil", "Cicil", Foxpro.enFoxproTypes.Numeric, 2));

                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                index.Add(new Foxpro.IndexStruct("idhtr", "IDHTR"));

                Foxpro.WriteFile(GlobalVar.DbfUpload, fileName1, fields, ds.Tables[0]);


                List<Foxpro.DataStruct> fields2 = new List<Foxpro.DataStruct>();

                fields2.Add(new Foxpro.DataStruct("RecordID", "Idrec", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("HtrID", "Idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("NamaStok", "Nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields2.Add(new Foxpro.DataStruct("KodeSolo", "Klp", Foxpro.enFoxproTypes.Char, 3));
                fields2.Add(new Foxpro.DataStruct("QtyRequest", "J_rq", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtyDO", "J_do", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtySuratJalan", "J_sj", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtyNota", "J_nota", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtyRetur", "J_retur", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("QtyKoli", "J_koli", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("KoliAwal", "Koli_awal", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("KoliAkhir", "Koli_akhir", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("NoKoli", "No_koli", Foxpro.enFoxproTypes.Char, 15));
                fields2.Add(new Foxpro.DataStruct("Satuan", "Satuan", Foxpro.enFoxproTypes.Char, 3));
                fields2.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("TglSuratJalan", "Tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields2.Add(new Foxpro.DataStruct("HrgJual", "H_jual", Foxpro.enFoxproTypes.Numeric, 7));
                fields2.Add(new Foxpro.DataStruct("HargaPokok", "H_pokok", Foxpro.enFoxproTypes.Numeric, 7));
                fields2.Add(new Foxpro.DataStruct("HPPSolo", "Hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
                fields2.Add(new Foxpro.DataStruct("Disc1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("Disc2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("Disc3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("Pot", "Pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields2.Add(new Foxpro.DataStruct("DiscFormula", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields2.Add(new Foxpro.DataStruct("KoreksiID", "Id_koreksi", Foxpro.enFoxproTypes.Char, 19));
                fields2.Add(new Foxpro.DataStruct("KodeToko", "Kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields2.Add(new Foxpro.DataStruct("NoDOBO", "No_bodo", Foxpro.enFoxproTypes.Char, 7));
                fields2.Add(new Foxpro.DataStruct("SyncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
                fields2.Add(new Foxpro.DataStruct("NBOPrint", "Nprint", Foxpro.enFoxproTypes.Numeric, 1));
                fields2.Add(new Foxpro.DataStruct("NoACC", "No_acc", Foxpro.enFoxproTypes.Char, 7));
                fields2.Add(new Foxpro.DataStruct("KetKoli", "Ket_koli", Foxpro.enFoxproTypes.Char, 20));
                fields2.Add(new Foxpro.DataStruct("BarangID", "Id_brg", Foxpro.enFoxproTypes.Char, 23));

                List<Foxpro.IndexStruct> index2 = new List<Foxpro.IndexStruct>();
                index2.Add(new Foxpro.IndexStruct("idhtr", "IDHTR"));

                Foxpro.WriteFile(GlobalVar.DbfUpload, fileName2, fields2, ds.Tables[1]);
            }
            else
            {
                isUploaded = false;
            }

            return isUploaded;
        }
        
        
        private void ZipFile()
        {
            string fileName1Full = GlobalVar.DbfUpload + "\\" + fileName1 + ".dbf";
            string fileName1FPT = GlobalVar.DbfUpload + "\\" + fileName1 + ".fpt";
            string fileName2Full = GlobalVar.DbfUpload + "\\" + fileName2 + ".dbf";
            string fileIndex1 = GlobalVar.DbfUpload + "\\" + fileName1 + ".cdx";
            string fileIndex2 = GlobalVar.DbfUpload + "\\" + fileName2 + ".cdx";

            string fileZipName = string.Empty;

            if (cKlp == "BE")
            {
                fileZipName = GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang + ".zip";
            }
            else
                if (cKlp == "FA")
                {
                    fileZipName = GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang + "FA.zip";
                }

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            List<string> files = new List<string>();
            files.Add(fileName1Full);
            files.Add(fileName2Full);
            
            if (File.Exists(fileIndex1))
            {
                files.Add(fileIndex1);
            }

            if (File.Exists(fileIndex2))
            {
                files.Add(fileIndex2);
            }

            if (File.Exists(fileName1FPT))
            {
                files.Add(fileName1FPT);
            }

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(fileName1Full))
            {
                File.Delete(fileName1Full);
            }

            if (File.Exists(fileName2Full))
            {
                File.Delete(fileName2Full);
            }

            if (File.Exists(fileIndex1))
            {
                File.Delete(fileIndex1);
            }

            if (File.Exists(fileIndex2))
            {
                File.Delete(fileIndex2);
            }

            if (File.Exists(fileName1FPT))
            {
                File.Delete(fileName1FPT);
            }

            if (cKlp=="BE")
                MessageBox.Show("Upload pengajuan harga FB/FE telah selesai dan disimpan di: " + "\n" + GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang + ".zip");
            else
                if (cKlp=="FA")
                    MessageBox.Show("Upload pengajuan harga FX,FAB/FA2/FA4 telah selesai dan disimpan di: " + "\n" + GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang + "FA.zip");
        }


        private void ZipFileFX()
        {
            string fileName1Full = GlobalVar.DbfUpload + "\\" + fileName1 + ".dbf";
            string fileName1FPT = GlobalVar.DbfUpload + "\\" + fileName1 + ".fpt";
            string fileIndex1 = GlobalVar.DbfUpload + "\\" + fileName1 + ".cdx";
            string fileName2Full = GlobalVar.DbfUpload + "\\" + fileName2 + ".dbf";
            string fileIndex2 = GlobalVar.DbfUpload + "\\" + fileName2 + ".cdx";

            string fileZipName = string.Empty;

            if (cKlp == "BE")
            {
                fileZipName = GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang + ".zip";
            }
            else
                if (cKlp == "FX")
                {
                    fileZipName = GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang + "FX.zip";
                }

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            List<string> files = new List<string>();
            files.Add(fileName1Full);
            files.Add(fileName2Full);

            if (File.Exists(fileIndex1))
            {
                files.Add(fileIndex1);
            }

            if (File.Exists(fileIndex2))
            {
                files.Add(fileIndex2);
            }

            if (File.Exists(fileName1FPT))
            {
                files.Add(fileName1FPT);
            }

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(fileName1Full))
            {
                File.Delete(fileName1Full);
            }

            if (File.Exists(fileName2Full))
            {
                File.Delete(fileName2Full);
            }

            if (File.Exists(fileIndex1))
            {
                File.Delete(fileIndex1);
            }

            if (File.Exists(fileIndex2))
            {
                File.Delete(fileIndex2);
            }

            if (File.Exists(fileName1FPT))
            {
                File.Delete(fileName1FPT);
            }

            if (cKlp == "BE")
                MessageBox.Show("Upload pengajuan harga FB/FE telah selesai dan disimpan di: " + "\n" + GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang + ".zip");
            else
                if (cKlp == "FX")
                    MessageBox.Show("Upload pengajuan harga FX,FA atau FC telah selesai dan disimpan di: " + "\n" + GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang + "FX.zip");
        }



        #region LINK OH
        private void cmdOH_Click(object sender, EventArgs e)
        {
            // ambil data dari datagrid simpan ke oh
            saveOH();
        }

        private void saveOH()
        {

            Database db = new Database();

                // prepare header var
                Guid RowIDPenjualan = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Guid IDOrder = Guid.NewGuid();
                string recordID = GlobalVar.PerusahaanID; //! dari function frmDoBeliBrowserUploadPurchasingOrder()
                string noRequest = (string)dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value;
                //DateTime tglRequest = (DateTime)dataGridDO.SelectedCells[0].OwningRow.Cells["TglRequest"].Value;
                DateTime tglRequest = DateTime.Now;
                string Pemasok = "KP-SOLO"; // -- selalu KP-SOLO -- 
                string Catatan = (string)dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value; // yang ini bener atau tidak ? tanya ke pak dwy
                string NoACCPiutang = (string)dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value;
                string Catatan5 = (string)dataGridDO.SelectedCells[0].OwningRow.Cells["Catatan5"].Value;
                Guid jadwalkrmID = Guid.Empty;
                string tglSuratJalan = Convert.ToString(dataGridDO.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value);
                int NPrint = Convert.ToInt32(dataGridDO.SelectedCells[0].OwningRow.Cells["NPrint"].Value);
                string Cabang1 = Convert.ToString(dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang1"].Value);
                string Cabang2 = Convert.ToString(dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang2"].Value);    

                // untuk looping database transaction
                int looper = 0;

                try
                {
                    // sebelum save validasi dulu ...
                    saveOHValidation(RowIDPenjualan, NoACCPiutang, Catatan5, sumQtyDODetail(), Cabang1, Cabang2, tglSuratJalan, NPrint);

                    db.Commands.Clear();

                    //preparing header data ...
                    db.Commands.Add(db.CreateCommand("usp_OrderPembelian_INSERT"));
                    db.Commands[looper].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, IDOrder)); 
                    db.Commands[looper].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, recordID)); //!!
                    db.Commands[looper].Parameters.Add(new Parameter("@noRequest", SqlDbType.VarChar, noRequest)); 
                    db.Commands[looper].Parameters.Add(new Parameter("@tglRequest", SqlDbType.DateTime, tglRequest)); 
                    db.Commands[looper].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, Pemasok));
                    db.Commands[looper].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, Cabang1)); 
                    db.Commands[looper].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, Cabang2)); 
                    db.Commands[looper].Parameters.Add(new Parameter("@estHrgJual", SqlDbType.Money, 0)); //!!
                    db.Commands[looper].Parameters.Add(new Parameter("@estHPP", SqlDbType.Money, 0)); //!!
                    db.Commands[looper].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, Catatan));
                    db.Commands[looper].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, NoACCPiutang)); //!!
                    db.Commands[looper].Parameters.Add(new Parameter("@jadwalkrmID", SqlDbType.UniqueIdentifier, jadwalkrmID)); //!!
                    db.Commands[looper].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0)); 
                    db.Commands[looper].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID)); 
                    looper++;

                    int detailDoNumRows = dataGridDetailDO.Rows.Count;
                    for (int i = 0; i < detailDoNumRows; i++ )
                    {
                        // declare detail var..
                        Guid rowID = Guid.NewGuid();
                        Guid headerID = IDOrder;
                        string recordIDDetail = "";
                        string headerRecID = recordID;
                        string barangID = (string)dataGridDetailDO.Rows[i].Cells["BarangID"].Value;
                        int qtyDO = (int)dataGridDetailDO.Rows[i].Cells["QtyDO"].Value;
                        int qtyBO = (int)dataGridDetailDO.Rows[i].Cells["QtyBO"].Value;
                        int qtyTambahan = (int)dataGridDetailDO.Rows[i].Cells["QtyDO"].Value; //!!
                        int qtyJual = 0; 
                        int qtyAkhir = 0; 
                        string keterangan = "";
                        string kodeGudang = GlobalVar.Gudang;
                        string CatatanDetail = (string)dataGridDetailDO.Rows[i].Cells["Catatan"].Value;

                        db.Commands.Add(db.CreateCommand("usp_OrderPembelianDetail_INSERT"));
                        db.Commands[looper].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[looper].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                        db.Commands[looper].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, recordIDDetail));
                        db.Commands[looper].Parameters.Add(new Parameter("@headerRecID", SqlDbType.VarChar, headerRecID));
                        db.Commands[looper].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                        db.Commands[looper].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, qtyDO));
                        db.Commands[looper].Parameters.Add(new Parameter("@qtyBO", SqlDbType.Int, qtyBO));
                        db.Commands[looper].Parameters.Add(new Parameter("@qtyTambahan", SqlDbType.Int, qtyTambahan)); //!!
                        db.Commands[looper].Parameters.Add(new Parameter("@qtyJual", SqlDbType.Int, qtyJual));
                        db.Commands[looper].Parameters.Add(new Parameter("@qtyAkhir", SqlDbType.Int, qtyAkhir));
                        db.Commands[looper].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, keterangan));
                        db.Commands[looper].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, kodeGudang));
                        db.Commands[looper].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, CatatanDetail));
                        db.Commands[looper].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[looper].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        
                        looper++;
                    }

                    // update NPrint to 1 di OrderPenjualan
                    updateNPrint(ref db, ref looper, RowIDPenjualan);

                    // executing stored procedure...
                    db.BeginTransaction();
                    for (int i = 0; i < looper; i++ )
                    {
                        db.Commands[i].ExecuteNonQuery();
                    }
                    db.CommitTransaction();

                    refreshAllGrid();

                    MessageBox.Show("Link Ke OH Berhasil");
                }
                catch(Exception e)
                {
                    db.RollbackTransaction();
                    MessageBox.Show(e.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                
        }

        private void refreshAllGrid()
        {
            RefreshDataDO();
            dataGridDO.Focus();
            selectedGrid = enumSelectedGrid.DOSelected;
        }

        // melakukan validasi sebelum link OH
        // letakkan di dalam try catch
        private void saveOHValidation(Guid HeaderID, string NoAccPiutang, string Catatan5, double SumQtyDO, string Cabang1, string Cabang2, string TglSuratJalan, int NPrint)
        {
            // check by NoAccPiutang
            if (NoAccPiutang == null || NoAccPiutang == "")
            {
                throw new Exception("Belum ACC Piutang.");
            }

            //// check by Full ACC Piutang
            if (NoAccPiutang.Substring(0, 1) != "F")
            {
                throw new Exception("ACC Piutang Tidak Full.");
            }
            
            // check by catatan 5
            /* sementara tidak dipakai dulu ...
            if (Catatan5 == null || Catatan5 == "")
            {
                hasil = false;
                throw new Exception("Belum ACC Piutang");
            }*/

            // check by cabang peminta dan cabang pengirim
            if(Cabang1 != Cabang2)
            {
                throw new Exception("Cabang Peminta dan Cabang Pengirim Harus Sama");
            }

            // check by ketersediaan surat jalan
            if (TglSuratJalan != "")
            {
                throw new Exception("Sudah Nota.");
            }

            // check by total qty DO
            if (SumQtyDO <= 0)
            {
                throw new Exception("Qty harus lebih dari 0.");
            }

            // check by NPrint 
            if (NPrint == 1)
            {
                throw new Exception("Sudah di Link OH");
            }

            // ada harga yang tidak valid ?
            if(isValidHargaJualDO(HeaderID) == false)
            {
                throw new Exception("Ada harga yang lebih rendah dari BMK");
            }

        }

        // just a save oh validation
        // ada header data dan detail data yang harus divalidasi
        // masukkan dalam blok try catch
        /*private void saveOHValidation()
        { 
            // declare header variable
            string NoAccPiutang;
            string Catatan5;
            double SumQtyDO; 
            string Cabang1;
            string Cabang2;

        }*/
        
        // cek perbandingan harga dengan BMK
        private bool isValidHargaJualDO(Guid HeaderID)
        {
            bool hasil = true;

            DataTable dt = new DataTable();
            Database db = new Database();
            db.Commands.Add(db.CreateCommand("ISADBDepoRetail.dbo.psp_NonValidHargaJualDO"));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID));
            dt = db.Commands[0].ExecuteDataTable();

            int notValidHarga = 0;
            // cek value dari sp 
            foreach(DataRow dr in dt.Rows)
            {
                notValidHarga += (int)dr["NotValidHarga"];
            }

            // kalau ketemu yang tidak valid maka langsung false
            if(notValidHarga > 0)
            {
                hasil = false;
            }

            return hasil;
        }

        // fungsinya untuk menghitung sum dari qtyDO dari table orderpenjualandetail
        // output dari ini hanya untuk fungsi validasi apakah bisa dilakukan link oh atau tidak
        private int sumQtyDODetail()
        {
            int hasil = 0;
            int qtyDo = 0;

            int numRows = dataGridDetailDO.Rows.Count;
            for (int i = 0; i < numRows; i++ )
            {
                qtyDo = (int)dataGridDetailDO.Rows[i].Cells["QtyDO"].Value;
                hasil = hasil + qtyDo;
            }

            return hasil;
        }

        //mengubah nilai NPrint menjadi 1 yang artinya sudah di link OH
        private void updateNPrint(ref Database db, ref int looper, Guid RowID)
        {
            db.Commands.Add(db.CreateCommand("ISADBDepoRetail.dbo.psp_OrderPenjualanNPrintUpdate"));
            db.Commands[looper].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            looper++;
        }

        #endregion

        
        private void cmdRef_Click(object sender, EventArgs e)
        {
            if (dataGridDO.SelectedCells.Count == 0)
            {
                return;
            }

            Guid RowID_ = new Guid(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value, "").ToString());
            string cab1_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang1"].Value, "").ToString();
            string cab2_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang2"].Value, "").ToString();
            string sync_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["colWiserDCSync"].Value, "").ToString();
            string kdtoko_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value, "").ToString();
            string trtype_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value, "").ToString();
            string NoAccPiutang = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value, "").ToString();
            double RpDO_ = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["RpNet"].Value, 0).ToString());
            double sisaPlf = 0;

            if (cab1_ != cab2_ && sync_ != "")
            {
                MessageBox.Show("Sudah Sync, Tidak bisa diRefresh.");
                return;
            }

            DataTable dtbo = new DataTable();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanBackOrder_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                    dtbo = db.Commands[0].ExecuteDataTable();
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
            if (dtbo.Rows.Count > 0)
            {
                MessageBox.Show("DO sudah jadi nota...");
                return;
            }


            //double plafonToko = Convert.ToDouble(Tools.isNull(TokoPlafon.Plafon(kdtoko_, trtype_), 0));
            //double plafonToko = Convert.ToDouble(Tools.isNull(TokoPlafon.PlafonFin(kdtoko_), 0));
            //double piutangToko = Convert.ToDouble(Tools.isNull(TokoPlafon.Piutang(kdtoko_, trtype_), 0));
            //double piutangToko = Convert.ToDouble(Tools.isNull(TokoPlafon.PiutangFin(kdtoko_), 0));
            //double gitToko = Convert.ToDouble(Tools.isNull(TokoPlafon.GIT(kdtoko_, trtype_), 0));
            //double gitToko = Convert.ToDouble(Tools.isNull(TokoPlafon.GITFin(kdtoko_), 0));
            //double giroTolakToko = Convert.ToDouble(Tools.isNull(TokoPlafon.GiroTolak(kdtoko_, trtype_), 0));
            //double giroTolakToko = Convert.ToDouble(Tools.isNull(TokoPlafon.GiroTolakFin(kdtoko_), 0));

            //double giroToko = 0, giroTokoFX = 0;
            //if (trtype_ == "K2" || trtype_ == "K4")
            //    //giroToko = Convert.ToDouble(Tools.isNull(TokoPlafon.Giro(kdtoko_, trtype_), 0));
            //    giroToko = Convert.ToDouble(Tools.isNull(TokoPlafon.GiroFin(kdtoko_), 0));
            //else
            //    //giroTokoFX = Convert.ToDouble(Tools.isNull(TokoPlafon.Giro(kdtoko_, trtype_), 0));
            //    giroTokoFX = Convert.ToDouble(Tools.isNull(TokoPlafon.GiroFin(kdtoko_), 0));

            //if (trtype_ == "K2" || trtype_ == "K4")
            //    sisaPlf = Convert.ToDouble(plafonToko - piutangToko - gitToko - giroToko - giroTolakToko);
            //else
            //    sisaPlf = Convert.ToDouble(plafonToko - piutangToko - gitToko - giroTokoFX - giroTolakToko);
            sisaPlf = Convert.ToDouble(Tools.isNull(TokoPlafon.SisaPlafonFinV2(kdtoko_,RowID_), 0));

            double overdueFB = TokoOverdue.OverdueFB(kdtoko_);
            double overdueFX = TokoOverdue.OverdueFX(kdtoko_);

            _tglDO = Convert.ToDateTime(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["TglDO"].Value, "").ToString());
            _kodeToko = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value, "").ToString();
            _TrType = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value, "").ToString();

            if (overdueFB <= 0 && overdueFX <= 0)
            {
                NoAccPiutang = "FULLACC";
            }

            #region refresh headerDO
            Guid _rowID = (Guid)dataGridDetailDO.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;

            //tutup sementara
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("psp_OrderPenjualan_RefreshSummary_DODetailID"));
            //        db.Commands[0].Parameters.Add(new Parameter("@DODetailID", SqlDbType.UniqueIdentifier, _rowID));
            //        db.Commands[0].ExecuteNonQuery();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
            #endregion 


            Double RpAccPtg_ = 0;
            //if (RpDO_ <= sisaPlf)
            //    RpAccPtg_ = RpDO_;
            //else
            //    RpAccPtg_ = sisaPlf;

            double nBayar = TokoPlafon.Pembayaran(_kodeToko);
            double nHrovd = TokoPlafon.LamaOverdue(_kodeToko);

            if (overdueFB > 0 || overdueFX > 0)
            {
                if (sisaPlf > 0)
                {
                    if (sisaPlf > RpDO_)
                    {
                        if (RpDO_ > nBayar)
                            RpAccPtg_ = nBayar;
                        else
                            RpAccPtg_ = RpDO_;
                    }
                    else
                    {
                        if (sisaPlf > nBayar)
                            RpAccPtg_ = nBayar;
                        else
                            RpAccPtg_ = sisaPlf;
                    }
                }
                else
                {
                    RpAccPtg_ = 0;
                }
            }
            else
            {
                if (sisaPlf > 0)
                {
                    if (sisaPlf > RpDO_)
                        RpAccPtg_ = RpDO_;
                    else
                        RpAccPtg_ = sisaPlf;
                }
            }


            int index = dataGridDO.SelectedCells[0].RowIndex;

            //if (dtbo.Rows.Count == 0)
            //{
            //    if (Tools.isNull(dtDO.DefaultView[index]["TglSuratJalan"], "").ToString() != "")
            //    {
            //        MessageBox.Show("DO sudah jadi nota...");
            //        return;
            //    }
            //}

            int a = 0, fxb = 0, fxx = 0;
            string NoAccpusat = "";
            string NoAccHarga = "";

            for (a = 0; a < dataGridDetailDO.Rows.Count; ++a)
            {
                string cklp = "";
                string idbrg = Convert.ToString(Tools.isNull(dataGridDetailDO.Rows[a].Cells[34].Value, ""));
                double hrbrg = Convert.ToDouble(Tools.isNull(dataGridDetailDO.Rows[a].Cells[12].Value, "0").ToString());
                string acchr = Tools.isNull(dataGridDetailDO.SelectedCells[0].OwningRow.Cells["DetailNoACC"].Value, "").ToString();

                string _recordID = Convert.ToString(Tools.isNull(dataGridDetailDO.Rows[a].Cells[33].Value, ""));
                _barangID = Convert.ToString(Tools.isNull(dataGridDetailDO.Rows[a].Cells[34].Value, ""));

                GetHrgJualDO();

                if (idbrg != "")
                {
                    cklp = idbrg.Trim().Substring(0, 3);
                }
                if (cklp == "FXB" || (cklp != "" && cklp != "FXB" && hrbrg == 0))   //barang bonus
                    fxb += 1;
                else if (cklp != "" && cklp != "FXB" && hrbrg > 0)
                    fxx += 1;

                if (hrbrg >= HrgJual_)
                {
                    if (acchr != "" && acchr != "HARGA")
                    {
                        NoAccpusat = "AUTOACC";
                        NoAccHarga = acchr;
                    }
                    else
                    {
                        NoAccpusat = "AUTOACC";
                        NoAccHarga = "AUTOACC";
                    }
                }
                else
                {
                    if (acchr != "" && acchr != "HARGA")
                    {
                        NoAccpusat = "AUTOACC";
                        NoAccHarga = acchr;
                    }
                    else
                    {
                        NoAccHarga = "HARGA";
                    }
                }

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetailAccHarga_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, _recordID));
                        db.Commands[0].Parameters.Add(new Parameter("@NoAccHarga", SqlDbType.VarChar, NoAccHarga));
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

            string KBrgBonus = "";
            if (fxb > 0 && fxx == 0)
            {
                KBrgBonus = "BONUSAN";
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_RpAccPiutang_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                    db.Commands[0].Parameters.Add(new Parameter("@RpAccPtg", SqlDbType.Money, RpAccPtg_));
                    db.Commands[0].Parameters.Add(new Parameter("@overdueFB", SqlDbType.Money, overdueFB));
                    db.Commands[0].Parameters.Add(new Parameter("@overdueFX", SqlDbType.Money, overdueFX));
                    db.Commands[0].Parameters.Add(new Parameter("@kBrgBonus", SqlDbType.VarChar, KBrgBonus));
                    if (NoAccpusat != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@NoAccpusat", SqlDbType.VarChar, NoAccpusat));
                    }
                    db.Commands[0].ExecuteNonQuery();
                }
                //RefreshDataDO();
                //FindHeader("RowID", RowID_.ToString());
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


            /*refresh data status toko*/
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_StatusToko_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
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

            RefreshDataDO();
            FindHeader("RowID", RowID_.ToString());
            MessageBox.Show("Refresh DO Selesai.");
        }


        private void GetFlagKg(string kodetoko)
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Toko_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodetoko));
                    dt = db.Commands[0].ExecuteDataTable();
                    flagkg = Tools.isNull(dt.Rows[0]["RefSupervisor"], "").ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void dataGridDO_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //if (dataGridDO.Rows[e.RowIndex].Cells["NoRequest"].Value.ToString().Contains("!") &&
            //    int.Parse(dataGridDO.Rows[e.RowIndex].Cells["NPrint"].Value.ToString()) == 0)
            //{
            //    dataGridDO.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            //}

            // TODO: (dari complaint program)
            // if RPaccpiutang < dari apa? 
            // Yang di highlight kuning di do browser grid1 itu yang bagaimana?
            //dataGridDO.Rows[e.RowIndex].Cells["NoDO"].Style.BackColor = Color.Yellow;
            //dataGridDO.Rows[e.RowIndex].Cells["NoACCPiutang"].Style.BackColor = Color.Yellow;

            for (int rowIndex = 0; rowIndex < dataGridDO.Rows.Count; rowIndex++)
            {
                if (dataGridDO.Rows[rowIndex].Cells["NoRequest"].Value.ToString().Contains("!") && int.Parse(dataGridDO.Rows[rowIndex].Cells["NPrint"].Value.ToString()) == 0)
                {
                    dataGridDO.Rows[rowIndex].Cells["NoRequest"].Style.ForeColor = Color.Red;
                    dataGridDO.Rows[rowIndex].Cells["NoRequest"].Style.SelectionForeColor = Color.Red;
                    dataGridDO.Rows[rowIndex].Cells["NoDO"].Style.ForeColor = Color.Red;
                    dataGridDO.Rows[rowIndex].Cells["NoDO"].Style.SelectionForeColor = Color.Red;
                }

                if (int.Parse(dataGridDO.Rows[rowIndex].Cells["NPrint"].Value.ToString()) > 0)
                {
                    dataGridDO.Rows[rowIndex].Cells["NoRequest"].Style.ForeColor = Color.Black;
                    //dataGridDO.Rows[rowIndex].Cells["NoRequest"].Style.SelectionForeColor = Color.White;
                    dataGridDO.Rows[rowIndex].Cells["NoDO"].Style.ForeColor = Color.Black;
                    // dataGridDO.Rows[rowIndex].Cells["NoDO"].Style.SelectionForeColor = Color.White;
                }

                if (dataGridDO.Rows[rowIndex].Cells["NoACCPiutang"].Value.ToString() == "OVDFB"
                    || dataGridDO.Rows[rowIndex].Cells["NoACCPiutang"].Value.ToString() == "OVDFX"
                    || dataGridDO.Rows[rowIndex].Cells["NoACCPiutang"].Value.ToString() == "BONUSAN"
                    //|| dataGridDO.Rows[rowIndex].Cells["NoACCPiutang"].Value.ToString() == "SALESBL"
                    )
                {
                    //warna kuning kalau overdue dan salesbl
                    dataGridDO.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    //dataGridDO.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.White;
                }

                if (dataGridDO.Rows[rowIndex].Cells["StatusBatal"].ToString().Contains("BATAL"))
                {
                    dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.BackColor = Color.FromArgb(255, 125, 190);
                }

                dataGridDO.Rows[rowIndex].Cells["RpJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridDO.Rows[rowIndex].Cells["RpPotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridDO.Rows[rowIndex].Cells["RpNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridDO.Rows[rowIndex].Cells["RpNet3Ack"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //Isi Acak
                double harga = double.Parse(dataGridDO.Rows[rowIndex].Cells["RpJual"].Value.ToString());
                double rpPot = double.Parse(Tools.isNull(dataGridDO.Rows[rowIndex].Cells["RpPot"].Value, 0).ToString());
                double rpNet = double.Parse(Tools.isNull(dataGridDO.Rows[rowIndex].Cells["RpNet"].Value, 0).ToString());
                double rpNet3 = double.Parse(Tools.isNull(dataGridDO.Rows[rowIndex].Cells["RpNet3"].Value, 0).ToString());

                if (rpNet3 < rpNet)
                {
                    dataGridDO.Rows[rowIndex].Cells["NoDO"].Style.BackColor = Color.Yellow;
                    dataGridDO.Rows[rowIndex].Cells["RpNet3"].Style.BackColor = Color.Yellow;
                    dataGridDO.Rows[rowIndex].Cells["RpNet3Ack"].Style.BackColor = Color.Yellow;
                    //dataGridDO.Rows[rowIndex].Cells["NoACCPiutang"].Style.BackColor = Color.Yellow;
                }
                //else if (rpNet3 > rpNet)
                //{
                //    dataGridDO.Rows[rowIndex].Cells["NoDO"].Style.BackColor = Color.White;
                //    dataGridDO.Rows[rowIndex].Cells["NoACCPiutang"].Style.BackColor = Color.White;
                //}

                if (string.IsNullOrEmpty(dataGridDO.Rows[rowIndex].Cells["NoACCPiutang"].Value.ToString()))
                {
                    dataGridDO.Rows[rowIndex].Cells["NoDO"].Style.BackColor = Color.Yellow;
                }
                //else if (!string.IsNullOrEmpty(dataGridDO.Rows[rowIndex].Cells["NoACCPiutang"].Value.ToString()))
                //{
                //    dataGridDO.Rows[rowIndex].Cells["NoDO"].Style.BackColor = Color.White;
                //}
                if (Tools.isNull(dataGridDO.Rows[rowIndex].Cells[CekSO.Name].Value, "").ToString() != "0")
                {
                    dataGridDO.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Plum;
                }

                dataGridDO.Rows[rowIndex].Cells["RpJualAck"].Value = Tools.GetAntiNumeric(harga.ToString("#,##0"));
                dataGridDO.Rows[rowIndex].Cells["RpPotAck"].Value = Tools.GetAntiNumeric(rpPot.ToString("#,##0"));
                dataGridDO.Rows[rowIndex].Cells["RpNetAck"].Value = Tools.GetAntiNumeric(rpNet.ToString("#,##0"));
                dataGridDO.Rows[rowIndex].Cells["RpNet3Ack"].Value = Tools.GetAntiNumeric(rpNet3.ToString("#,##0"));
            }

        }

        private void dataGridDetailDO_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double _hrgJual = 0;
            double _hrgBMK = 0;
            double _hppSolo = 0;

            for (int rowIndex = 0; rowIndex < dataGridDetailDO.Rows.Count; rowIndex++)
            {
                if (dataGridDetailDO.Rows[rowIndex].Cells["HrgJual"].Value.ToString() != "")
                    _hrgJual = double.Parse(dataGridDetailDO.Rows[rowIndex].Cells["HrgJual"].Value.ToString());
                if (dataGridDetailDO.Rows[rowIndex].Cells["HrgBMK"].Value.ToString() != "")
                    _hrgBMK = double.Parse(dataGridDetailDO.Rows[rowIndex].Cells["HrgBMK"].Value.ToString());
                if (dataGridDetailDO.Rows[rowIndex].Cells["HPPSolo"].Value.ToString() != "")
                    _hppSolo = double.Parse(dataGridDetailDO.Rows[rowIndex].Cells["HPPSolo"].Value.ToString());

                // If HrgJual < HrgBMK
                if (_hrgJual < _hrgBMK && _hrgBMK != 0)
                {
                    dataGridDetailDO.Rows[rowIndex].Cells["HrgBMK"].Style.ForeColor = Color.Red;
                    dataGridDetailDO.Rows[rowIndex].Cells["HrgBMK"].Style.SelectionForeColor = Color.Red;
                }

                // If HrgJual < HPPSolo
                if (_hrgJual < _hppSolo && _hppSolo != 0)
                {
                    //dataGridDetailDO.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridDetailDO.Rows[rowIndex].Cells["HPPSolo"].Style.ForeColor = Color.Red;
                    dataGridDetailDO.Rows[rowIndex].Cells["HPPSolo"].Style.SelectionForeColor = Color.Red;
                }


                // If HrgJual < HPPSolo AND HrgJual > HrgBMK
                if ((_hrgJual < _hppSolo) && (_hrgJual > _hrgBMK) && (_hppSolo != 0) && (_hrgBMK != 0))
                {
                    dataGridDetailDO.Rows[rowIndex].Cells["HrgJual"].Style.ForeColor = Color.Red;
                    dataGridDetailDO.Rows[rowIndex].Cells["HrgJual"].Style.SelectionForeColor = Color.Red;
                }

                //Jika Noacc = "HARGA" maka ada warna kuning
                if (dataGridDetailDO.Rows[rowIndex].Cells["DetailNoACC"].Value.ToString() == "HARGA")
                {
                    foreach (DataGridViewCell dc in dataGridDetailDO.Rows[rowIndex].Cells)
                    {
                        dataGridDetailDO.Rows[rowIndex].Cells[dc.ColumnIndex].Style.BackColor = Color.Yellow;
                    }
                }


                // If NoACC = 'BATAL00' AND QtyDO = 0 -- DO Detail Batal
                /*Edited
                if (dataGridDetailDO.Rows[rowIndex].Cells["DetailNoACC"].Value.ToString().Trim() == "BATAL00"
                        &&
                    (int)dataGridDetailDO.Rows[rowIndex].Cells["QtyDO"].Value == 0)
                {
                    dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.ForeColor = Color.Orange;
                    dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.SelectionForeColor = Color.Orange;
                }*/


                // If NoACC = "" AND QtyDO = 0 -- Harga Ditolak
                /*Edit
                if (dataGridDetailDO.Rows[rowIndex].Cells["DetailNoACC"].Value.ToString().Trim() == ""
                        &&
                    (int)dataGridDetailDO.Rows[rowIndex].Cells["QtyDO"].Value == 0)
                {
                    dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.ForeColor = Color.Purple;
                    dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.SelectionForeColor = Color.Purple;
                }
                else
                {
                    dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.ForeColor = Color.Black;
                    dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.SelectionForeColor = Color.White;
                }
                */

                if ((int)dataGridDetailDO.Rows[rowIndex].Cells["QtyDO"].Value == 0)
                {
                    if (dataGridDetailDO.Rows[rowIndex].Cells["DetailNoACC"].Value.ToString().Trim() == "BATAL00")
                    {
                        dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.ForeColor = Color.Orange;
                        dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.SelectionForeColor = Color.Orange;
                    }
                    else if (dataGridDetailDO.Rows[rowIndex].Cells["DetailNoACC"].Value.ToString().Trim() == "")
                    {
                        dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.ForeColor = Color.Purple;
                        dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.SelectionForeColor = Color.Purple;
                    }
                    else
                    {
                        dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.ForeColor = Color.Black;
                        dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.SelectionForeColor = Color.White;
                    }

                }
                else
                {
                    dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.ForeColor = Color.Black;
                    dataGridDetailDO.Rows[rowIndex].Cells["NamaStok"].Style.SelectionForeColor = Color.White;
                }

                double HrgBMK = double.Parse(Tools.isNull(dataGridDetailDO.Rows[rowIndex].Cells["HrgBMK"].Value, 0).ToString());
                double HrgJual = double.Parse(Tools.isNull(dataGridDetailDO.Rows[rowIndex].Cells["HrgJual"].Value, 0).ToString());
                double JmlHarga = double.Parse(Tools.isNull(dataGridDetailDO.Rows[rowIndex].Cells["JmlHarga"].Value, 0).ToString());
                double Pot = double.Parse(Tools.isNull(dataGridDetailDO.Rows[rowIndex].Cells["Pot"].Value, 0).ToString());
                double JmlPot = double.Parse(Tools.isNull(dataGridDetailDO.Rows[rowIndex].Cells["JmlPot"].Value, 0).ToString());
                double HrgNet = double.Parse(Tools.isNull(dataGridDetailDO.Rows[rowIndex].Cells["HrgNet"].Value, 0).ToString());
                double HPPSolo = double.Parse(Tools.isNull(dataGridDetailDO.Rows[rowIndex].Cells["HPPSolo"].Value, 0).ToString());
                double JmlHPP = double.Parse(Tools.isNull(dataGridDetailDO.Rows[rowIndex].Cells["JmlHPP"].Value, 0).ToString());

                dataGridDetailDO.Rows[rowIndex].Cells["HrgBMKAck"].Value = Tools.GetAntiNumeric(HrgBMK.ToString("#,##0"));
                dataGridDetailDO.Rows[rowIndex].Cells["HrgJualAck"].Value = Tools.GetAntiNumeric(HrgJual.ToString("#,##0"));
                dataGridDetailDO.Rows[rowIndex].Cells["JmlHrgAck"].Value = Tools.GetAntiNumeric(JmlHarga.ToString("#,##0"));
                dataGridDetailDO.Rows[rowIndex].Cells["PotAck"].Value = Tools.GetAntiNumeric(Pot.ToString("#,##0"));
                dataGridDetailDO.Rows[rowIndex].Cells["JmlPotAck"].Value = Tools.GetAntiNumeric(JmlPot.ToString("#,##0"));
                dataGridDetailDO.Rows[rowIndex].Cells["HrgNetAck"].Value = Tools.GetAntiNumeric(HrgNet.ToString("#,##0"));
                dataGridDetailDO.Rows[rowIndex].Cells["HPPSoloAck"].Value = Tools.GetAntiNumeric(HPPSolo.ToString("#,##0"));
                dataGridDetailDO.Rows[rowIndex].Cells["JmlHPPAck"].Value = Tools.GetAntiNumeric(JmlHPP.ToString("#,##0"));

                dataGridDetailDO.Rows[rowIndex].Cells["HrgBMKAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridDetailDO.Rows[rowIndex].Cells["HrgJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridDetailDO.Rows[rowIndex].Cells["JmlHrgAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridDetailDO.Rows[rowIndex].Cells["PotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridDetailDO.Rows[rowIndex].Cells["JmlPotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridDetailDO.Rows[rowIndex].Cells["HrgNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridDetailDO.Rows[rowIndex].Cells["HPPSoloAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridDetailDO.Rows[rowIndex].Cells["JmlHPPAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
        }

        private void dataGridDO_Click_1(object sender, EventArgs e)
        {
            dataGridDO.Focus();
            selectedGrid = enumSelectedGrid.DOSelected;
        }

        private void GetHrgJualDO()
        {
            try
            {
                DataTable dtGetHrgJual = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetHrgJual"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, _tglDO));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, _TrType));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    db.Commands[0].Parameters.Add(new Parameter("@flagkg", SqlDbType.VarChar, flagkg));
                    dtGetHrgJual = db.Commands[0].ExecuteDataTable();
                }
                if (dtGetHrgJual.Rows.Count > 0)
                {
                    HrgJual_ = Convert.ToDouble(dtGetHrgJual.Rows[0]["HrgJual"]);
                }
                else
                {
                    HrgJual_ = 0;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public static void SynchOrderPenjualanWDC(Action<bool, string, DataTable> cb)
        {
            DateTime now = GlobalVar.DateOfServer;
            TabelDO.SynchOrderPenjualanWDC(DateTime.Parse(now.ToString("yyyy-MM-01")), now, cb);
        }
        public static void SynchOrderPenjualanWDC(Guid[] RowIDs, Action<bool, string, DataTable> cb)
        {
            DateTime now = GlobalVar.DateOfServer;
            TabelDO.SynchOrderPenjualanWDC(RowIDs, null, null, cb);
        }
        public static void SynchOrderPenjualanWDC(DateTime from, DateTime to, Action<bool, string, DataTable> cb)
        {
            TabelDO.SynchOrderPenjualanWDC(null, from, to, cb);
        }
        public static void SynchOrderPenjualanWDC(Guid[] RowIDs, DateTime? from, DateTime? to, Action<bool, string, DataTable> cb)
        {
            string url = "http://devwiserdc.sas-autoparts.com:8000";
            url = AppSetting.GetValue("WiserDC_Host");
            if (url.Length <= 0 || url == "false")
            {
                if (cb != null) cb(false, "Wiser DC belum di setting", null);
                return;
            }

            DataTable dtblr = new DataTable();
            dtblr.Columns.Add("RowID", typeof(Guid));
            dtblr.Columns.Add("NoRequest", typeof(string));
            dtblr.Columns.Add("NoDO", typeof(string));
            dtblr.Columns.Add("Result", typeof(bool));
            dtblr.Columns.Add("Message", typeof(string));

            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += (a, b) =>
            {
                using (var db = new Database())
                {
                    string ids = "";
                    if (RowIDs != null && RowIDs.Length > 0)
                    {
                        foreach (Guid c in RowIDs)
                        {
                            if (ids.Length > 0) ids += ",";
                            ids += c.ToString();
                        }
                    }
                    db.Commands.Add(db.CreateCommand("[usp_OrderPenjualan_RSOPAC_GET]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowIDS", SqlDbType.VarChar, (ids.Length > 0 ? ids : null)));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, (from.HasValue ? from : null)));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, (to.HasValue ? to : null)));
                    db.Commands[0].Parameters.Add(new Parameter("@RowSpliter", SqlDbType.VarChar, ","));
                    DataSet dset = db.Commands[0].ExecuteDataSet();

                    if (dset.Tables.Count < 3)
                    {
                        b.Result = "Terjadi kegagalan saat pengambilan data";
                        return;
                    }
                    else if (dset.Tables[0].Rows.Count <= 0)
                    {
                        b.Result = true;
                        return;
                    }

                    double cnt = 0;
                    JSON jdat = new JSON(JSONType.Object);
                    foreach (DataRow dr in dset.Tables[0].Rows)
                    {
                        if (dr["_Error"].ToString().Length > 0)
                        {
                            dtblr.Rows.Add(new object[] {
                                new Guid(dr["RowID"].ToString()),
                                dr["NoRequest"],
                                dr["NoDO"],
                                false,
                                dr["_Error"].ToString()
                            });
                            continue;
                        }

                        JSON sdat = new JSON(JSONType.Object);
                        foreach (DataColumn dc in dset.Tables[0].Columns) sdat[dc.ColumnName.ToLower()] = new JSON(dr[dc]);
                        sdat["details"] = new JSON(JSONType.Object);

                        DataRow[] drs = dset.Tables[1].Select("HeaderID = '" + dr["RowID"].ToString() + "'");
                        foreach (DataRow dr2 in drs)
                        {
                            JSON sdat2 = new JSON(JSONType.Object);
                            foreach (DataColumn dc2 in dset.Tables[1].Columns) sdat2[dc2.ColumnName.ToLower()] = new JSON(dr2[dc2]);
                            sdat["details"].ObjAdd(dr2["RowID"].ToString(), sdat2);
                            cnt += 1;
                        }

                        sdat["toko"] = new JSON(JSONType.Object);
                        drs = dset.Tables[2].Select("KodeToko = '" + dr["KodeToko"].ToString() + "'");
                        if (drs.Length >= 1)
                        {
                            foreach (DataColumn dc2 in dset.Tables[2].Columns) sdat["toko"][dc2.ColumnName.ToLower()] = new JSON(drs[0][dc2]);
                        }

                        sdat["sales"] = new JSON(JSONType.Object);
                        drs = dset.Tables[3].Select("SalesID = '" + dr["KodeSales"].ToString() + "'");
                        if (drs.Length >= 1)
                        {
                            foreach (DataColumn dc2 in dset.Tables[3].Columns) sdat["sales"][dc2.ColumnName.ToLower()] = new JSON(drs[0][dc2]);
                        }

                        jdat[dr["RowID"].ToString()] = sdat;
                        cnt += 1;
                    }

                    if (dset.Tables[0].Rows.Count > 0 && jdat.Count <= 0)
                    {
                        b.Result = "No record(s) available";
                        return;
                    }
                    else if (cnt <= 0)
                    {
                        b.Result = "";
                        return;
                    }
                    JSON mdat = new JSON(JSONType.Object);
                    mdat["data"] = jdat;

                    XNet xnc = new XNet(url + "/api/orderpenjualan/rsopac/sync/" + GlobalVar.Gudang, XNetMode.Synchronous);
                    xnc.Post(mdat, r =>
                    {
                        if (r.Error != null)
                        {
                            b.Result = r.Error.Message;
                            return;
                        }
                        else if (r.Message.Length > 0)
                        {
                            b.Result = r.Message;
                            return;
                        }

                        if (r.Result)
                        {
                            string res = "";
                            JSON jres = null;
                            try
                            {
                                jres = JSON.Parse(r.Output);
                            }
                            catch (Exception) { }
                            if (jres != null && jres.Type == JSONType.Object)
                            {
                                if (jres["Result", new JSON(false)].BoolValue && jres.ObjExists("List"))
                                {
                                    db.Commands.Clear();
                                    db.Commands.Add(db.CreateCommand("[usp_OrderPenjualan_RSOPAC_UPDATE]"));

                                    List<string> errl = new List<string>();
                                    foreach (string k in jres["List"].ObjKeys)
                                    {
                                        try
                                        {
                                            DataRow[] drc = dset.Tables[0].Select("RowID = '" + k.ToString() + "'");
                                            if (jres["List"][k].Type == JSONType.Bool && jres["List"][k].BoolValue)
                                            {
                                                db.Commands[0].Parameters.Clear();
                                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, new Guid(k)));
                                                db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.Bit, true));
                                                db.Commands[0].ExecuteNonQuery();

                                                dtblr.Rows.Add(new object[] {
                                                    new Guid(k),
                                                    (drc.Length > 0 ? drc[0]["NoRequest"] : null),
                                                    (drc.Length > 0 ? drc[0]["NoDO"] : null),
                                                    true,
                                                    "OK"
                                                });
                                            }
                                            else
                                            {
                                                string elist = "- ";
                                                if (drc.Length > 0) elist += "No Request '" + drc[0]["NoRequest"] + "' List '" + drc[0]["NoDO"] + "'";
                                                else elist += "Row '" + k.ToString() + "'";
                                                errl.Add(elist + ": " + jres["List"][k].StringValue);

                                                dtblr.Rows.Add(new object[] {
                                                    new Guid(k),
                                                    (drc.Length > 0 ? drc[0]["NoRequest"] : null),
                                                    (drc.Length > 0 ? drc[0]["NoDO"] : null),
                                                    false,
                                                    jres["List"][k].StringValue
                                                });
                                            }
                                        }
                                        catch (Exception) { }
                                    }
                                    if (errl.Count > 0) res = String.Join("\r\n", errl.ToArray());
                                }
                                else res = jres["Msg", new JSON("Internal error")].StringValue;
                            }
                            else res = r.Output;
                            b.Result = res;
                        }
                        else b.Result = "Cannot connect to server";
                    });

                }
            };
            bgw.RunWorkerCompleted += (a, b) =>
            {
                string msg = "";
                if (b.Error != null) msg = b.Error.Message;
                if (b.Result != null)
                {
                    if (b.Result.ToString().Length >= 0) msg = b.Result.ToString();
                }
                else msg = "Unknown error";
                if (cb != null) cb((msg.Length <= 0), msg, dtblr);
            };
            bgw.RunWorkerAsync();
        }

        InPopup ipSynchWiser;
        InPopup ipProgress;
        InPopup ipUploadRSOPAC;
        InPopup ipRSOPACResult;

        private void btnSynchWiser_Click(object sender, EventArgs e)
        {
            if (ipSynchWiser == null) ipSynchWiser = new InPopup(this, pnlPopWiserSync);
            if (ipProgress == null) ipProgress = new InPopup(this, pnlPopProgress);
            if (ipUploadRSOPAC == null) ipUploadRSOPAC = new InPopup(this, pnlPopUploadRSOPAC);
            if (ipRSOPACResult == null) ipRSOPACResult = new InPopup(this, pnlPopUploadResult);

            ipSynchWiser.Open(btnSynchWiser);
        }

        private void btnPopSyncWiserDownload_Click(object sender, EventArgs e)
        {
            ipSynchWiser.Close(true);
            Penjualan.frmSalesOrderSynch frmSOS = new Penjualan.frmSalesOrderSynch();
            frmSOS.ShowDialog();

            if (frmSOS.Result == DialogResult.OK) RefreshDataDO();
        }

        private void btnPopSyncWiserUpload_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnPopSyncWiserUpload))
            {
                ipSynchWiser.Close(true);
                if (ipProgress == null) ipProgress = new InPopup(this, pnlPopProgress);
                if (ipUploadRSOPAC == null) ipUploadRSOPAC = new InPopup(this, pnlPopUploadRSOPAC);
                if (ipRSOPACResult == null) ipRSOPACResult = new InPopup(this, pnlPopUploadResult);

                Form mother = this;
                string host = AppSetting.GetValue("WiserDC_Host");
                if (host.Length <= 0 || host == "false")
                {
                    MessageBox.Show("Wiser DC belum di setting");
                    return;
                }

                List<Guid> glist = new List<Guid>();
                DataTable ulist = new DataTable();
                ulist.Columns.Add("RowID", typeof(Guid));
                ulist.Columns.Add("NoRequest", typeof(string));
                ulist.Columns.Add("NoDO", typeof(string));
                ulist.Columns.Add("Status", typeof(string));
                ulist.Columns.Add("Message", typeof(string));
                foreach (DataGridViewRow dr in dataGridDO.Rows)
                {
                    if (dr.Cells["colCheck"].Value != null && dr.Cells["colCheck"].Value.Equals(true))
                    {
                        glist.Add(new Guid(dr.Cells["RowID"].Value.ToString()));
                        ulist.Rows.Add(new object[] {
                            new Guid(dr.Cells["RowID"].Value.ToString()),
                            dr.Cells["NoRequest"].Value.ToString(),
                            dr.Cells["NoDO"].Value.ToString(),
                            "TOLAK",
                            "Tidak di ketahui"
                        });
                    }
                }

                if (glist.Count > 0)
                {
                    DialogResult dres = MessageBox.Show(this, "Yakin akan upload " + glist.Count + " item?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dres == DialogResult.Yes)
                    {
                        ipProgress.OpenDialog(mother);
                        TabelDO.SynchOrderPenjualanWDC(glist.ToArray(), (a, b, c) =>
                        {
                            ipProgress.Close(a);
                            if (!a && b.ToLower() != "true" && (c == null || (c != null && c.Rows.Count <= 0)))
                            {
                                MessageBox.Show("Gagal: " + b);
                                return;
                            }

                            int scount = 0;
                            foreach (DataRow dr in c.Rows)
                            {
                                DataRow[] drs = ulist.Select("RowID = '" + dr["RowID"] + "'");
                                foreach (DataRow dr2 in drs)
                                {
                                    dr2["Status"] = ((bool)dr["Result"] ? "SUKSES" : "GAGAL");
                                    dr2["Message"] = dr["Message"];
                                }
                                scount += ((bool)dr["Result"] ? 1 : 0);
                            }

                            dataGridDO.Invoke(new Action(() =>
                            {
                                foreach (DataGridViewRow crow in dataGridDO.Rows) crow.Cells["colCheck"].Value = false;
                            }));

                            if (scount == ulist.Rows.Count)
                            {
                                MessageBox.Show("Upload " + scount + " RSOPAC telah berhasil");
                                return;
                            }
                            gvPopUploadResult.Invoke(new Action(() =>
                            {
                                if (gvPopUploadResult.DataSource != null) ((DataTable)gvPopUploadResult.DataSource).Clear();
                                gvPopUploadResult.DataSource = ulist;
                            }));

                            ipRSOPACResult.Open(mother);
                        });
                    }
                }
                else
                {
                    DateTime now = GlobalVar.DateOfServer;
                    drangePopUploadRSOPACRange.FromDate = DateTime.Parse(now.ToString("yyyy-MM-01"));
                    drangePopUploadRSOPACRange.ToDate = now;
                    ipUploadRSOPAC.Open(this);
                }
            }
            else if (sender.Equals(btnPopSyncWiserDownload))
            {
                ipSynchWiser.Close(true);
                Penjualan.frmSalesOrderSynch frm = new Penjualan.frmSalesOrderSynch();
                frm.ShowDialog();
                if (frm.Result == DialogResult.OK) RefreshDataDO();
            }
        }

        private bool IsNull(object obj)
        {
            if (obj == null) return true;
            else if (obj == DBNull.Value) return true;
            else return false;
        }

        private void dataGridDO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (
                e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
                dataGridDO.Columns[e.ColumnIndex].Name == "colCheck"
            )
            {
                DataGridViewCell ccel = dataGridDO.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (IsNull(dataGridDO.Rows[e.RowIndex].Cells["colWiserDCSync"].Value))
                {
                    if (ccel.Value == null) ccel.Value = true;
                    else ccel.Value = (ccel.Value.Equals(true) ? false : true);
                }
                else ccel.Value = false;
            }
        }

        private void btnPopUploadResultClose_Click(object sender, EventArgs e)
        {
            ipRSOPACResult.Close(true);
        }

        private void btnPopUploadRSOPACClose_Click(object sender, EventArgs e)
        {
            ipUploadRSOPAC.Close(false);
        }

        private void btnPopUploadRSOPACUpload_Click(object sender, EventArgs e)
        {
            ipProgress.OpenDialog(this);

            Form mother = this;
            TabelDO.SynchOrderPenjualanWDC(
                (DateTime)drangePopUploadRSOPACRange.FromDate,
                (DateTime)drangePopUploadRSOPACRange.ToDate,
                (a, b, c) =>
                {
                    ipProgress.Close(a);
                    if (!a && (c == null || (c != null && c.Rows.Count <= 0)))
                    {
                        MessageBox.Show((b.ToLower() == "true" ? "Tidak ada inputan RSOPAC" : "Gagal: " + b));
                        return;
                    }

                    bool oke = true;
                    c.Columns.Add("Status", typeof(string));
                    foreach (DataRow dr in c.Rows)
                    {
                        if (oke) oke = (bool)dr["Result"];
                        dr["Status"] = ((bool)dr["Result"] ? "SUKSES" : "GAGAL");
                    }

                    ipUploadRSOPAC.Close(a);
                    if (oke)
                    {
                        MessageBox.Show("Upload RSOPAC telah berhasil");
                        return;
                    }

                    gvPopUploadResult.Invoke(new Action(() =>
                    {
                        if (gvPopUploadResult.DataSource != null) ((DataTable)gvPopUploadResult.DataSource).Clear();
                        gvPopUploadResult.DataSource = c;
                    }));
                    ipRSOPACResult.Open(mother);
                }
            );
        }

        private void btnCopyDO_Click(object sender, EventArgs e)
        {
            if (dataGridDO.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }

            DateTime tglDO = (DateTime)dataGridDO.SelectedCells[0].OwningRow.Cells["TglDO"].Value;
            if (tglDO >= GlobalVar.DateOfServer.Date)
            {
                MessageBox.Show("DO masih berlaku, tidak dapat di-copy-kan. \n Hubungi manager anda !");
                return;
            }

            Guid doRowID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            DataTable dtCekCopyDO = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_CekCopyDO"));
                db.Commands[0].Parameters.Add(new Parameter("@DOIDLama", SqlDbType.UniqueIdentifier, doRowID));
                dtCekCopyDO = db.Commands[0].ExecuteDataTable();
            }
            if (dtCekCopyDO.Rows.Count > 0)
            {
                MessageBox.Show("DO sudah dicopy. Tidak bisa Copy ulang. Hubungi manager anda.");
                return;
            }

            DataTable dtCek = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Cek_SisaRQ"));
                db.Commands[0].Parameters.Add(new Parameter("@OrderPenjualanRowID", SqlDbType.UniqueIdentifier, doRowID));
                dtCek = db.Commands[0].ExecuteDataTable();
            }

            if (dtCek.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada item barang yang mempunyai sisa BO aktif.");
                return;
            }

            //if (SecurityManager.AskPasswordManager())
            //{
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_COPY"));
                    db.Commands[0].Parameters.Add(new Parameter("@SourceRowID", SqlDbType.UniqueIdentifier, doRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.BeginTransaction();
                    object retVal = db.Commands[0].ExecuteScalar();
                    db.CommitTransaction();

                    if (retVal != null)
                        MessageBox.Show(retVal.ToString());

                    cmdSearch.PerformClick();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            //}

        }

    }
}
