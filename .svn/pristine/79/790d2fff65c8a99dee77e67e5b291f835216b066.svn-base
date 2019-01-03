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
using System.Security.Cryptography;
using System.Linq;
using ISA.Controls;
using ISA.DAL;
using ISA.Pin;


namespace ISA.Trading.Penjualan
{
    public partial class frmNotaJualBrowser : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;
        int prevGrid2Row = -1;

        enum enumSelectedGrid { DOSelected, NotaJualHeaderSelected, NotaJualDetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.DOSelected;
        DataTable dtNotaJual, dtNotaJualDetail,dtPrinter ;
        string printerName,printer;
        int _nCetak = -1, _nOli = 1;
        string _ketNota = "";
        bool _acak;
        double hrgdet = 0, netdet = 0, potdet = 0, hppdet = 0, hrgheader = 0, potheader = 0, netheader = 0;

        string initCab = GlobalVar.Gudang;
        string cCab1 = "";
        string _KdSales = "";
        string _TokoPnt = "";

        string flagkg = "";
        bool _isOk = true;
        bool TokoDisp = false;
        bool _KdSalesKhusus = false;

        DateTime LastTgl;
        string TglLast = "";

        Guid _headerID;

        public frmNotaJualBrowser()
        {
            InitializeComponent();
        }

        private void frmNotaJualBrowse_Load(object sender, EventArgs e)
        {
            //this.Title = "Nota Jual";
            this.Text = "Penjualan (Nota)";
            _acak = true;
            AcakTampilTextBox();
            lblToko.Text = "";
            lblBarang.Text = "";
            rgbTglDO.FromDate = DateTime.Now; // new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglDO.ToDate = DateTime.Now;
            dataGridDO.AutoGenerateColumns = false;
            dataGridNotaJual.AutoGenerateColumns = false;
            dataGridNotaJualDetail.AutoGenerateColumns = false;
            rgbTglDO.Focus();
            dataGridNotaJualDetail.GenerateRowNumber = true;
            dataGridNotaJual.GenerateRowNumber = true;

            if (GlobalVar.Gudang == "2803")
            {
                cmdEdit.Visible = true;
                cmdEdit.TabStop = true;
            }
            else
            {
                cmdEdit.Visible = false;
                cmdEdit.TabStop = false;
            }

            this.WindowState = FormWindowState.Maximized;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataDO();
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
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtDO = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST_FILTER_TglDO")); //-- udah di cek, heri
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglDO.ToDate));
                    dtDO = db.Commands[0].ExecuteDataTable();
                    dataGridDO.DataSource = dtDO;
                }

                if (dataGridDO.SelectedCells.Count > 0)
                {
                    RefreshDataNotaJual();
                    lblToko.Text = "\"" + dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + "\" "
                        + dataGridDO.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString();
                }
                else
                {
                    lblToko.Text = " ";

                    // Retur Header //
                    dataGridNotaJual.DataSource = null;
                    txtJmlHrgHeader2.Text = "";
                    txtJmlNettHeader2.Text = "";
                    txtJmlPotHeader2.Text = "";
                    // Retur Detail //
                    dataGridNotaJualDetail.DataSource = null;
                    lblBarang.Text = " ";
                    txtJmlHrgDetail2.Text = "";
                    txtJmlNettDetail2.Text = "";
                    txtJmlPotDetail2.Text = "";
                    txtJmlHPPDetail2.Text = "";

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
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST")); // udah dicek
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridDO.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
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

        public void RefreshRowDataNota(string _rowID)
        {
            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_DOID")); // udah di cek
                    db.Commands[0].Parameters.Add(new Parameter("@NotaID", SqlDbType.UniqueIdentifier, rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridNotaJual.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
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




        public void RefreshDataNotaJual()
        {
            try
            {
                Guid _doID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["DORowID"].Value;

                this.Cursor = Cursors.WaitCursor;
                dtNotaJual = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_DOID")); // udah dicek
                    db.Commands[0].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, _doID));
                    dtNotaJual = db.Commands[0].ExecuteDataTable();
                }
                dtNotaJual.DefaultView.Sort = "RecordID";
                dataGridNotaJual.DataSource = dtNotaJual;

                if (dataGridNotaJual.SelectedCells.Count > 0)
                {


                    RefreshDataNotaJualDetail();
                    dataGridDO.Focus();
                }
                else
                {
                    dataGridNotaJualDetail.DataSource = null;
                    txtJmlHrgHeader2.Text = "";
                    txtJmlNettHeader2.Text = "";
                    txtJmlPotHeader2.Text = "";
                    // -- //
                    lblBarang.Text = " ";
                    txtJmlHrgDetail2.Text = "";
                    txtJmlNettDetail2.Text = "";
                    txtJmlPotDetail2.Text = "";
                    txtJmlHPPDetail2.Text = "";
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

        //public void RefreshRowDataNotaJual(string _rowID)
        //{
        //    Guid rowID = new Guid(_rowID);
        //    DataTable dtRefresh;
        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        dtRefresh = new DataTable();
        //        using (Database db = new Database())
        //        {
        //            db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_DOID"));// sudah dicek
        //            db.Commands[0].Parameters.Add(new Parameter("@NotaID", SqlDbType.UniqueIdentifier, rowID));
        //            dtRefresh = db.Commands[0].ExecuteDataTable();
        //        }

        //        if (dtRefresh.Rows.Count > 0)
        //        {
        //            //string recID = Tools.isNull(dtRefresh.Rows[0]["RecordID"], "").ToString();
        //            //dataGridNotaJual.RefreshDataRow(dtRefresh.Rows[0], "RecordID", recID);
        //            //dataGridNotaJual.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
        //            //dataGridNotaJual.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID.ToString());
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

        public void RefreshDataNotaJualDetail()
        {
            try
            {
                _headerID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;

                this.Cursor = Cursors.WaitCursor;
                dtNotaJualDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST_FILTER_HeaderID")); // udah dicek
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtNotaJualDetail = db.Commands[0].ExecuteDataTable();
                }
                dtNotaJualDetail.DefaultView.Sort = "RecordID";
                dataGridNotaJualDetail.DataSource = dtNotaJualDetail;

                if (dataGridNotaJualDetail.SelectedCells.Count > 0)
                {
                    lblBarang.Text = dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
                }
                else
                {
                    lblBarang.Text = " ";
                    txtJmlHrgDetail2.Text = "";
                    txtJmlNettDetail2.Text = "";
                    txtJmlPotDetail2.Text = "";
                    txtJmlHPPDetail2.Text = "";
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

        private void dataGridNotaJual_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.NotaJualHeaderSelected;
        }

        private void dataGridNotaJualDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.NotaJualDetailSelected;
        }

        private bool CekHargaRendah(Guid doID)
        {
            bool hargaRendah = false;

            try
            {
                DataTable dtDetailDO = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_SEARCH_HeaderID"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, doID));
                    dtDetailDO = db.Commands[0].ExecuteDataTable();
                }

                DataRow[] dr;
                dr = dtDetailDO.Select("NoAcc='HARGA'");

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

        private bool CekGiroTolakPerToko(string kodeToko)
        {
            bool giroTolak = false;
            try
            {
                DataTable dtGiroTolak = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GiroTolakPerToko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodeToko));
                    dtGiroTolak = db.Commands[0].ExecuteDataTable();
                }
                giroTolak = dtGiroTolak.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return giroTolak;
        }


        private bool CekUmurNotaPerToko(string kodeToko)
        {
            bool UmurNota = false;
            try
            {
                DataTable dtUmurNota = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_UmurNotaPerToko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodeToko));
                    dtUmurNota = db.Commands[0].ExecuteDataTable();
                }
                UmurNota = dtUmurNota.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return UmurNota;
        }


        private bool CekOverdueFX(string kodeToko, string trType)
        {
            bool UmurNota = false;
            try
            {
                DataTable dtUmurNota = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_UmurNotaPerToko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodeToko));
                    dtUmurNota = db.Commands[0].ExecuteDataTable();
                }
                UmurNota = dtUmurNota.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return UmurNota;
        }


        private bool CekGiroTolak(string kodeToko)
        {
            bool giroTolak = false;

            try
            {
                DataTable dtGiroTolak = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GiroTolak_LIST_KodeToko"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodeToko));
                    dtGiroTolak = db.Commands[0].ExecuteDataTable();
                }

                giroTolak = dtGiroTolak.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return giroTolak;
        }


        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Guid _doID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["DORowID"].Value;
            cCab1 = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang1"].Value, "").ToString();
            string kodeToko = dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
            string nodo = "";
            string trType = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value, "").ToString();
            string cekso = dataGridDO.SelectedCells[0].OwningRow.Cells["CekSO"].Value.ToString();

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
            //            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodeToko));
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


            /*sementara menunggu kebijakan dikeluarkan, kondisi dibawah ini ditutup*/
            #region Git AG > 7 hari, minta pin ke HO
            //tutup sementara
            //if (GlobalVar.Gudang != "2803")     // && GlobalVar.Gudang != "2808")
            //{
            //    /*Cek AG yang belum diterima lebih dari 7 hari*/
            //    DataTable dtAg = new DataTable();
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_AntarGudang_BelumTerima_CEK"));
            //        dtAg = db.Commands[0].ExecuteDataTable();
            //    }

            //    /*cek LastPinGitAG*/
            //    string TglNow = string.Format("{0:dd-MMM-yyyy}", DateTime.Now);
            //    DataTable dtLastGitAG = new DataTable();
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_LastPinGitAG_LIST"));
            //        db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "LastPinGitAG"));
            //        dtLastGitAG = db.Commands[0].ExecuteDataTable();
            //    }
            //    if (dtLastGitAG.Rows.Count > 0)
            //    {
            //        if (dtLastGitAG.Rows[0]["Value"].ToString() != "")
            //        {
            //            LastTgl = Convert.ToDateTime(dtLastGitAG.Rows[0]["Value"].ToString());
            //        }
            //    }
            //    TglLast = string.Format("{0:dd-MMM-yyyy}", LastTgl);

            //    if (dtAg.Rows.Count > 0 && TglLast != TglNow)
            //    {
            //        Communicator.frmInsertPinGitAG ifrmChilds = new Communicator.frmInsertPinGitAG(this, dtAg);
            //        ifrmChilds.ShowDialog();
            //        return;
            //    }
            //}
            #endregion

            #region toko dispensasi
            //TokoDisp = false;
            //DataTable dtDisp = new DataTable();
            //using (Database db = new Database())
            //{
            //    db.Commands.Add(db.CreateCommand("usp_TokoDispensasiOvdFX_LIST"));
            //    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, KodeToko.ToString()));
            //    db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, DateTime.Now));
            //    dtDisp = db.Commands[0].ExecuteDataTable();
            //    if (dtDisp.Rows.Count > 0)
            //    {
            //        TokoDisp = true;
            //    }
            //}
            #endregion

            if (selectedGrid == enumSelectedGrid.NotaJualHeaderSelected)
            {
                #region validasi flagkg
                //if (GlobalVar.Gudang != "2823" && GlobalVar.Gudang != "2803")
                //{
                //    GenuineTrans();
                //    if (!_isOk)
                //    {
                //        return;
                //    }
                //}
                #endregion

                if (dataGridDO.SelectedCells.Count == 0)
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                    return;
                }

                double _jmlHrgNota = 0;
                double _rpACCPiutang = 0;
                if (dataGridDO.SelectedCells[0].OwningRow.Cells["RpACCPiutang"].Value.ToString() != "")
                {
                    _rpACCPiutang = double.Parse(dataGridDO.SelectedCells[0].OwningRow.Cells["RpACCPiutang"].Value.ToString());
                }
                double _rpSisaACCPiutang = _rpACCPiutang - _jmlHrgNota;

                #region cegatan sebelum create nota jual

                if (Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value, " ").ToString().Substring(0, 1) == "T")
                {
                    MessageBox.Show("DO ditolak Piutang");
                    return;
                }

                string bataldo = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["StatusBatal"].Value, "").ToString();
                if (bataldo != "" && bataldo.Length >= 5)
                {
                    if (bataldo.Substring(0, 5) == "BATAL")
                    {
                        MessageBox.Show("DO ini Sudah Dibatalkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value.ToString().Substring(0, 1) == "K")
                {
                    if (Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value, "").ToString() == "")
                    {
                        MessageBox.Show("Belum ACC Piutang");
                        return;
                    }
                    else if (Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["RpACCPiutang"].Value, "").ToString() == "")
                    {
                        MessageBox.Show("Rp ACC Piutang kosong");
                        return;
                    }
                }

                if (GlobalVar.Gudang != "2808")
                {
                    if (cekso.ToString() != "1")
                    {
                        MessageBox.Show("Belum Cek SO..!!");
                        return;
                    }
                }

                if (GlobalVar.Gudang != "2808" && GlobalVar.Gudang != "2803")
                {
                    if (trType.ToString().Substring(0, 1) == "K")
                    {
                        int c = Convert.ToInt32(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["NPrint"].Value, "0").ToString());
                        if (c < 1)
                        {
                            MessageBox.Show("Belum cetak DO");
                            return;
                        }

                        #region giro tolak -> plafon 0
                        bool _GiroTolak = CekGiroTolakPerToko(kodeToko);
                        //bool _UmurNota = CekUmurNotaPerToko(kodeToko);

                        if (_GiroTolak == true)
                        {
                            if (MessageBox.Show("Toko ini mempunyai Giro Tolak. Jika dilanjutkan Plafon akan nol." + "\n" +
                                                "Proses dilanjutkan ?", "Konfirmasi Giro Tolak", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                PlafonTokoUpdate(kodeToko);
                            }
                            else
                            {
                                return;
                            }
                        }
                        else if (CekGiroTolak(kodeToko))
                        {
                            MessageBox.Show("Toko mempunyai giro tolak yang masih open.");
                            return;
                        }
                        #endregion
                    }
                }

                if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value.ToString() == "BONUSAN")
                {
                    MessageBox.Show("Semua barang dalam DO ini adalah barang bonus." + "\n" +
                        "Silahkan masukan PIN pengajuan bonus terlebih dahulu.");
                    nodo = dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString();
                    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.Bonus, "Cegatan Bonus " + nodo);
                    ifrmpin.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmpin);
                    ifrmpin.Show();
                    return;
                }

                bool ACC = false;
                Guid _RowIDDo = new Guid(dataGridDO.SelectedCells[0].OwningRow.Cells["DORowID"].Value.ToString());
                string _Nodo = dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString();
                DateTime _TglDO = Convert.ToDateTime(dataGridDO.SelectedCells[0].OwningRow.Cells["TglDO"].Value.ToString());
                string _doHtrID = dataGridDO.SelectedCells[0].OwningRow.Cells["DOHtrID"].Value.ToString();
                string _transType = dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value.ToString();
                string _hariKredit = dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString();
                string kodeSales = dataGridDO.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
                string NoAccPiutang_ = dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value.ToString();
                nodo = dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString();
                string kdtoko_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value, "").ToString();
                string NoAccptg_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["NoAccPiutang"].Value, "").ToString();
                double overdueFB = TokoOverdue.OverdueFB(kdtoko_);
                double overdueFX = TokoOverdue.OverdueFX(kdtoko_);
                double JumlahNota = 0;

                #region CekDataTokoBermasalah
                try
                {
                    DataTable dtctf = new DataTable();
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_TokoFiktif_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kdtoko_));
                        dtctf = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtctf.Rows.Count > 0)
                    {
                        MessageBox.Show("Toko Bermasalah, tidak bisa bertransaksi.");
                        return;
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
                #endregion

                #region Nota
                try
                {
                    DataTable dtNota = new DataTable();
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetRealisasiDO_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDDo));
                        dtNota = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtNota.Rows.Count > 0)
                    {
                        JumlahNota = double.Parse(Tools.isNull(dtNota.Rows[0]["JumlahNota"],"0").ToString());
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
                #endregion

                if (NoAccPiutang_ != "")
                {
                    if (NoAccPiutang_.Substring(0, 1) != "F")
                    {
                        MessageBox.Show("Belum ada AccPiutang.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Belum ada AccPiutang.");
                    return;
                }

                if (cCab1 == GlobalVar.CabangID)
                {
                    if (GlobalVar.Gudang != "2808" && GlobalVar.Gudang != "2803")
                    {
                        #region overdue BE dan FX
                        if (NoAccptg_ == "" || NoAccptg_.Substring(0, 1) != "F")
                        {
                            double nHrovd = TokoPlafon.LamaOverdue(kdtoko_);
                            if (TokoOverdue.OverdueFB(kdtoko_) > 0)
                            {
                                if (nHrovd > 30)
                                {
                                    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFB, "Cegatan Overdue FB " + nodo);
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
                                    if (nHrovd > 30)
                                    {
                                        Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFX, "Cegatan Overdue FX " + nodo);
                                        ifrmpin.MdiParent = Program.MainForm;
                                        Program.MainForm.RegisterChild(ifrmpin);
                                        ifrmpin.Show();
                                        return;
                                    }
                                }
                            }
                            //if (NoAccptg_.Trim() == "OVDFB")
                            //{
                            //    if (TokoOverdue.OverdueFB(kdtoko_) > 0)
                            //    {
                            //        Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFB, "Cegatan Overdue FB " + nodo);
                            //        ifrmpin.MdiParent = Program.MainForm;
                            //        Program.MainForm.RegisterChild(ifrmpin);
                            //        ifrmpin.Show();
                            //        return;
                            //    }
                            //}
                            //else if (NoAccptg_.Trim() == "OVDFX")
                            //{
                            //    if (TokoOverdue.OverdueFX(kdtoko_) > 0)
                            //    {
                            //        Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFX, "Cegatan Overdue FX " + nodo);
                            //        ifrmpin.MdiParent = Program.MainForm;
                            //        Program.MainForm.RegisterChild(ifrmpin);
                            //        ifrmpin.Show();
                            //        return;
                            //    }
                            //}
                        }
                        #endregion

                        #region validasi Harga
                        if (cCab1 == GlobalVar.CabangID)
                        {
                            if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString() != "AUTOACC")
                            {
                                MessageBox.Show("Harga belum di ACC Pusat");
                                return;
                            }
                        }
                        else
                        {
                            if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString() == "")
                            {
                                MessageBox.Show("Harga belum di ACC Pusat");
                                return;
                            }
                        }
                        #endregion

                        #region validasi ulang overdue toko dari Do Backorder penjualan
                        if (NoAccptg_ != "" && NoAccptg_.Substring(0, 1) == "F")
                        {
                            try
                            {
                                DataTable dtDetailDO = new DataTable();
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanBackOrder_SEARCH_HeaderID"));
                                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _RowIDDo));
                                    dtDetailDO = db.Commands[0].ExecuteDataTable();
                                }
                                if (dtDetailDO.Rows.Count > 0)
                                {
                                    /*cegatan lagi nih gan untuk BO an, walaupun BO kalo ada overdue mandeg sik dilit yo.
                                      iya nu..., oleh metu opo ora, ho oh toh*/
                                    /*---------------tambahan validasi -> cek lama overdue--------------*/
                                    double nHrovd = TokoPlafon.LamaOverdue(kdtoko_);

                                    if (TokoOverdue.OverdueFB(kdtoko_) > 0)
                                    {
                                        if (nHrovd > 30)
                                        {
                                            GeneratePengajuan(_TglDO, _TglDO, _RowIDDo);
                                            Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFBBo, "Overdue FB Back Order" + nodo);
                                            ifrmpin.ShowDialog();
                                            if (ifrmpin.DialogResult != DialogResult.OK) return;
                                        }
                                    }
                                    else if (TokoOverdue.OverdueFX(kdtoko_) > 0)
                                    {
                                        if (nHrovd > 30)
                                        {
                                            GeneratePengajuan(_TglDO, _TglDO, _RowIDDo);
                                            Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFXBo, "Overdue FX Back Order" + nodo);
                                            ifrmpin.ShowDialog();
                                            if (ifrmpin.DialogResult != DialogResult.OK) return;
                                        }
                                    }

                                    /*---------------------------------------------------------*/
                                    //if (TokoOverdue.OverdueFB(kdtoko_) > 0)
                                    //{
                                    //    GeneratePengajuan(_TglDO, _TglDO, _RowIDDo);
                                    //    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFBBo, "Overdue FB Back Order" + nodo);
                                    //    ifrmpin.ShowDialog();
                                    //    if (ifrmpin.DialogResult != DialogResult.OK)
                                    //        return;
                                    //}
                                    //else if (TokoOverdue.OverdueFX(kdtoko_) > 0)
                                    //{
                                    //    GeneratePengajuan(_TglDO, _TglDO, _RowIDDo);
                                    //    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, _doID, GlobalVar.Gudang, PinId.Bagian.OverdueFXBo, "Overdue FX Back Order" + nodo);
                                    //    ifrmpin.ShowDialog();
                                    //    if (ifrmpin.DialogResult != DialogResult.OK)
                                    //        return;
                                    //}
                                }
                            }
                            catch (Exception ex)
                            {
                                Error.LogError(ex);
                            }
                        }
                        #endregion

                    }
                }
                #endregion

                string KdToko = dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                string tipetrans = dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value.ToString();

                Penjualan.frmNotaJualUpdate ifrmChild = new Penjualan.frmNotaJualUpdate(this, _doID, _jmlHrgNota, KdToko, tipetrans, _rpACCPiutang, JumlahNota);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
        }


        private void PlafonTokoUpdate(string kodetoko)
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PlafonPerToko_UPDATE"));
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodetoko));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private bool GeneratePengajuan(DateTime fromDate, DateTime toDate, Guid _RowIDDo)
        {
            bool isGenerated = true;

            try
            {
                DataSet ds = PengajuanDataset(fromDate, toDate, _RowIDDo);

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
            catch (Exception ex)
            {
                isGenerated = false;

                Error.LogError(ex);
            }

            return isGenerated;
        }

        private DataSet PengajuanDataset(DateTime fromDate, DateTime toDate, Guid _RowIDDo)
        {
            DataSet ds;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("rsp_Pengajuan"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                db.Commands[0].Parameters.Add(new Parameter("@RowIDDO", SqlDbType.UniqueIdentifier, _RowIDDo));
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
                ws.Cells[rowCounter, 22].Value = Tools.GetKey(dr["RowID"].ToString(), GlobalVar.Gudang, PinId.Bagian.OverdueFBBo);

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
                ws.Cells[rowCounter, 22].Value = Tools.GetKey(dr["RowID"].ToString(), GlobalVar.Gudang, PinId.Bagian.OverdueFXBo);
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
                //MessageBox.Show("Pembuatan pengajuan telah selesai dan disimpan di: " + "\n" + filePath + ".\n" +
                //    "Selanjutnya akan dilakukan proses upload pengajuan harga FB/FE.");
            }
            catch (Exception ex)
            {
                isSaved = false;

                Error.LogError(ex);
            }

            return isSaved;
        }


        //private bool CekHargaRendah(Guid doID)
        //{
        //    bool databo = false;
        //    try
        //    {
        //        DataTable dtDetailDO = new DataTable();
        //        using (Database db = new Database())
        //        {
        //            db.Commands.Add(db.CreateCommand("usp_OrderPenjualanBackOrder_SEARCH_HeaderID"));
        //            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, doID));
        //            dtDetailDO = db.Commands[0].ExecuteDataTable();
        //        }
        //        if (dtDetailDO.Rows.Count > 0)
        //        {
        //            databo = false;
        //        }
        //        //DataRow[] dr;
        //        //dr = dtDetailDO.Select("NoAcc='HARGA'");
        //        //if (dr.Length > 0)
        //        //{
        //        //    hargaRendah = true;
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        Error.LogError(ex);
        //    }
        //    return databo;
        //}


        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVar.LastClosingDate = (DateTime)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value;
                if ((DateTime)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }
                if (selectedGrid == enumSelectedGrid.NotaJualHeaderSelected)
                {
                    if (dataGridNotaJual.SelectedCells.Count == 0)
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                        return;
                    }
                    /*CASE cUserLevel = 'ADMINISTRATOR'
                      MESSAGEBOX('Anda tidak punya wewenang hapus Nota',48,'Perhatian')*/
                    if (dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString() != "")
                    {
                        MessageBox.Show("Sudah proses PJ3, Tidak bisa hapus....!!!");
                        return;
                    }

                    if (dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaNPrint"].Value.ToString() != "0")
                    {
                        MessageBox.Show("Sudah cetak nota tidak bisa hapus");
                        return;
                    }

                    if (dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaisClosed"].Value.ToString() == "1")
                    {
                        MessageBox.Show("Tidak bisa Hapus data, sudah di Audit");
                        return;
                    }

                    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Guid rowID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
                        Guid doRowID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["DORowID"].Value;

                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_NotaPenjualandetail_DELETE"));//udah dicek heri
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_DELETE")); // udah dicek heri
                            db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));

                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            db.Commands[1].ExecuteNonQuery();
                            db.CommitTransaction();
                        }

                        MessageBox.Show("Record telah dihapus");
                        //this.RefreshDataDO();
                        RefreshRowDataDO(doRowID.ToString());
                        RefreshDataNotaJual();

                    }
                }
                else if ((selectedGrid == enumSelectedGrid.NotaJualDetailSelected) && dataGridNotaJualDetail.RowCount > 0)
                {

                    if ((int)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaNPrint"].Value > 0)
                    {
                        MessageBox.Show("Sudah JAdi Nota !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Guid rowID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;

                        Guid doRowID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["DORowID"].Value;
                        Guid NotaID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailHeaderID"].Value;

                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_NotaPenjualandetail_DELETE_2")); //udah cek heri
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].ExecuteNonQuery();

                        }



                        int i = 0;
                        int n = 0;
                        i = dataGridNotaJualDetail.SelectedCells[0].RowIndex;
                        n = dataGridNotaJualDetail.SelectedCells[0].ColumnIndex;
                        DataRowView dv = (DataRowView)dataGridNotaJualDetail.SelectedCells[0].OwningRow.DataBoundItem;
                        DataRow drr = dv.Row;
                        drr.Delete();
                        dtNotaJualDetail.AcceptChanges();
                        dataGridNotaJualDetail.Focus();
                        if (dataGridNotaJualDetail.RowCount > 0)
                        {
                            if (i == 0)
                            {
                                dataGridNotaJualDetail.CurrentCell = dataGridNotaJualDetail.Rows[0].Cells[n];
                                dataGridNotaJualDetail.RefreshEdit();
                            }
                            else
                            {
                                dataGridNotaJualDetail.CurrentCell = dataGridNotaJualDetail.Rows[i - 1].Cells[n];
                                dataGridNotaJualDetail.RefreshEdit();
                            }

                        }


                        //this.RefreshDataDO();
                        RefreshRowDataNota(NotaID.ToString());
                        RefreshRowDataDO(doRowID.ToString());

                        MessageBox.Show("Record telah dihapus");
                        //  RefreshDataNotaJualDetail();


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

        private void dataGridDO_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.F1:
                    DateTime _fromDate = DateTime.Parse(rgbTglDO.FromDate.ToString());
                    DateTime _toDate = DateTime.Parse(rgbTglDO.ToDate.ToString());
                    PJ3.frmHistoryPenjualanBrowser ifrmChild = new PJ3.frmHistoryPenjualanBrowser(_fromDate, _toDate);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                    break;


            }
        }

        private void dataGridNotaJual_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:

                    if (GlobalVar.Gudang != "2803")
                    {
                        int NotaNPrint = int.Parse(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaNPrint"].Value.ToString());
                        if (NotaNPrint > 0)
                        {
                            MessageBox.Show("Nota sudah di Print.");
                            return;
                        }
                    }
                    CekCetakNota();
                    break;

                case Keys.F2:
                    CreateFileListNoNotaTXT();
                    break;
                case Keys.F9:
                    AcakTampilHrg();
                    break;
            }
        }

        private void dataGridNotaJualDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
            }
        }

        private void CreateFileListNoNotaTXT()
        {
            if (dataGridNotaJual.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }

            int i = 0;
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("C:\\Temp\\NOTANOMOR.TXT", false);
                for (i = 0; i < dtNotaJual.Rows.Count; i++)
                {
                    sw.Write(dtNotaJual.Rows[i]["NoNota"] + System.Environment.NewLine);
                }
                sw.WriteLine();
                sw.Close();
                MessageBox.Show("List Nomor nota sudah disimpan ke file NOMORNOTA.TXT");
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private bool CekPTToko()
        {
            string kodeToko = dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
            string tokoC2 = "";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtToko;
                using (Database db = new Database())
                {
                    dtToko = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST")); //udah cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodeToko));
                    dtToko = db.Commands[0].ExecuteDataTable();
                }
                if (dtToko.Rows.Count > 0)
                    tokoC2 = Tools.isNull(dtToko.Rows[0]["Cabang2"], "").ToString();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            if (tokoC2 == "PT")
                return true;
            else
                return false;
        }

        private void CekCetakNota()
        {
            string c2 = dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang2"].Value.ToString();
            string c1 = dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang1"].Value.ToString();

            #region toko penetrasi
            /*tidak berlaku lagi*/
            //DataTable dtp = new DataTable();
            //try
            //{
            //    string kdToko = dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
            //    this.Cursor = Cursors.WaitCursor;
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_TokoKhususPnt_LIST"));
            //        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kdToko));
            //        dtp = db.Commands[0].ExecuteDataTable();
            //        if (dtp.Rows.Count > 0)
            //        {
            //            _TokoPnt = "1";
            //        }
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

            if (initCab != c2 /*&& Tools.Left(c2,2) == "28"*/)
            {
                MessageBox.Show("Cabang 2 nota yang dicetak harus sama dengan Init Cabang");
                return;
            }

            _nCetak = int.Parse(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaNPrint"].Value.ToString());
            if (_nCetak > 0)
            {
                Guid rowidNota = new Guid(Tools.isNull(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value, Guid.Empty).ToString());
                string _nota = Tools.isNull(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NoSuratJalan"].Value, "").ToString();
                string _cat3 = Tools.isNull(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan3"].Value, "").ToString();
                DateTime _Tglnota = DateTime.Parse(Tools.isNull(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value, DateTime.MinValue).ToString());

                /*tutup sementara*/
                //string _pinKey = Tools.GetKey(rowidNota.ToString(), GlobalVar.Gudang, PinId.Bagian.CetakUlangNota);
                //MD5 md5Hash = MD5.Create();
                //string _pin = key.GetMd5Hash(md5Hash, _pinKey);

                //if (_cat3 != _pin)
                //{
                //    GeneratePengajuanCetakUlangNota(_Tglnota,rowidNota);
                //    Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, rowidNota, GlobalVar.Gudang, PinId.Bagian.CetakUlangNota, "Cegatan Cetak Ulang Nota Jual." + _nota);
                //    ifrmpin.MdiParent = Program.MainForm;
                //    Program.MainForm.RegisterChild(ifrmpin);
                //    ifrmpin.Show();
                //    return;
                //}
            }

            //if (GlobalVar.Gudang != "2808")
            //{
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
            //}
            string jnstransaksi = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value, "KG").ToString().Substring(0, 1);
            if (jnstransaksi == "T")
                CetakNotapos();
            else
                CetakNota();
        }

        public string CekAppSetting(string jenisprinter)
        {
            //buat nota cetakan baru
            return Convert.ToString(AppSetting.GetValue(jenisprinter));

        }


        public void CetakNotapos()
        {
            if (_nCetak == 2 || _nCetak == 4)
            {
                _ketNota = "RE";
            }
            else if (_nCetak == 5 || _nCetak == 6)
            {
                _ketNota = string.Empty;
            }
            else if (_nCetak == 1 || _nCetak == 3)
            {
                _ketNota = "CP";
            }

            string transType = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TransactionTypeNota"].Value.ToString();

            /*tidak berlaku lagi*/
            //if (transType == "TB")
            //{
            //    _KdSales = dataGridDO.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
            //    _KdSalesKhusus = CekSalesKhusus( _KdSales);
            //}

            if (GlobalVar.Gudang != "2803")
            {
                try
                {
                    Guid _notaHeaderRowID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_CetakNotaPenjualanTax")); //udah cek heri
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _notaHeaderRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@oli", SqlDbType.Int, _nOli));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    if (GlobalVar.Gudang.Substring(0, 2) == "28")
                    {
                        //if (GlobalVar.Gudang != "2808")
                        //{
                            if (_nCetak == 3 || _nCetak == 4 || _nCetak == 6)
                            {
                                /*tidak berlaku lagi*/
                                //if (_KdSalesKhusus)
                                //{
                                //    DisplayReportNotaJual(dt, "rptCetakNotaJualKhusus");
                                //    DisplayReportNotaJual(dt, "rptCetakNotaJualKhususCopy1");
                                //    DisplayReportNotaJual(dt, "rptCetakNotaJualKhususCopy2");
                                //}
                                //else
                                //{
                                DisplayReportNotaJual(dt, "rptCetakNotaJualBaru");
                                DisplayReportNotaJual(dt, "rptCetakNotaJualCopy1");
                                DisplayReportNotaJual(dt, "rptCetakNotaJualCopy2");
                                //}
                            }
                            else
                            {
                                CetakNotaposRaw(dt);
                            }
                        //}
                        //else
                        //{
                            //CetakNotaRaw2808(dt);
                        //    CetakNotaTaxRaw(dt);
                        //}
                    }
                    else
                    {
                        CetakNotaTaxRawOto(dt);
                    }
                    IncreamentNPrintpos();
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


        private void CetakNotaTaxRawOto(DataTable dt)
        {
            BuildString data = new BuildString();
            string typePrinter = data.GetPrinterName(); //ISA.Trading.LookupInfo.GetValue("PRINTER", "DOT_MATRIX"); 
            string sNamaToko = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString().Trim();
            string sToko = "";
            if (sNamaToko.Length > 37)
                sToko = sNamaToko.Substring(0, 37);
            else
                sToko = sNamaToko;
            string sAlamat = dt.Rows[0]["Alamat"].ToString().Trim();
            string sDaerah = dt.Rows[0]["Daerah"].ToString().Trim();
            string sKota = dt.Rows[0]["Kota"].ToString().Trim().PadRight(20)
                + " (" + dt.Rows[0]["WilID"].ToString().Trim() + ")";
            string sPramuniaga = dt.Rows[0]["KodeSales"].ToString().Trim();

            //string sTempo = dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString();

            data.Initialize();
            data.PageLLine(33);
            data.LeftMargin(1);
            data.BottomMargin(1);

            #region Header
            if (typePrinter.Contains("LX"))
            {
                data.LetterQuality(false);
                data.FontBold(true);
                data.FontCondensed(true);
                data.DoubleHeight(true);
            }
            else
            {
                data.LetterQuality(true);
                data.FontBold(true);
                data.DoubleHeight(true);
                data.DoubleWidth(true);
            }
            data.PROW(true, 1, dt.Rows[0]["NamaPrs"].ToString().Trim());
            data.PROW(false, 47, "NOTA : " + dt.Rows[0]["NoSuratJalan"].ToString() + "   " + _ketNota);
            data.DoubleHeight(false);
            data.DoubleWidth(false);
            data.FontCPI(12);
            data.LineSpacing("1/8");
            data.FontCondensed(false);  //conden false
            data.LetterQuality(false);
            data.FontCondensed(false);  //conden false
            data.PROW(true, 1, dt.Rows[0]["AlamatPrs"].ToString());
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintTopLeftCorner() + data.PrintHorizontalLine(2) + " Pengiriman kepada Toko " + data.PrintHorizontalLine(14) + data.PrintTopRightCorner());
            data.FontItalic(false);
            data.PROW(true, 1, "NPWP/PKP    : " + dt.Rows[0]["NPWP"].ToString().PadRight(25));
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(false, 55, sToko);
            if (dt.Rows[0]["TglPKP"].ToString() == "")
            {
                data.PROW(true, 1, "TANGGAL PKP :  ");
            }
            else
            {
                data.PROW(true, 1, "TANGGAL PKP : " + ((DateTime)dt.Rows[0]["TglPKP"]).ToString("ddMMyyyy"));
            }

            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.FontCondensed(false);   //conden true
            data.AddCR();
            data.PROW(false, 55, sAlamat.PadRight(37));
            //data.PROW(false, 92, sAlamat.PadRight(65));
            data.FontCondensed(false);  //conden false
            data.PROW(true, 1, "");
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(false, 55, sDaerah.PadRight(25));
            data.PROW(true, 1, "TANGGAL NOTA: " + ((DateTime)dt.Rows[0]["TglSuratJalan"]).ToString("dd-MMM-yyyy"));
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(false, 55, sKota);
            data.PROW(true, 1, "Pramuniaga  : " + sPramuniaga + " ");
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(true, 1, "Penjualan   : " + "Tunai");
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintBottomLeftCorner() + data.PrintHorizontalLine(40) + data.PrintBottomRightCorner());
            data.FontItalic(false);
            data.PROW(true, 1, "");

            //data.FontCondensed(false);  //conden false

            //data.PROW(false, 2, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));

            /*                  12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890*/
            /*                           1         2         3         4         5         6         7         8         9         10        11        12        13        14*/
            data.PROW(true, 1, "No. Nama Barang                Part Number   Qty      Harga(Rp)  Dc(%) Pot(Rp)  Jumlah(Rp)");
            /*                   1. 1234567890123456789012345  123456789012  111 sat  9,999,999  99,99 999,999  99,999,999*/
            data.PROW(true, 1, data.PrintDoubleLine(90));
            //data.PROW(true, 1, data.PrintDoubleLine(134));
            #endregion

            #region Detail
            int nUrut = 0;
            string sNmBrg, sSatuan, sTemp, subNamaBarang, sPartNumber;
            double nQty = 0, nHrgSat = 0, nHrgBruto = 0, ndisc1 = 0, ndisc2 = 0, ndisc3 = 0;
            double nSumHrgBruto = 0, nSumDisc = 0, nSumPot = 0, nTotalHrg = 0, nPot = 0, nSumHrgNetto = 0;
            foreach (DataRow dr in dt.Rows)
            {
                nUrut++;
                sNmBrg = dr["NamaBarang"].ToString();
                int panjanghuruf = sNmBrg.Length;
                if (panjanghuruf >= 25)
                    subNamaBarang = sNmBrg.Substring(0, 25);
                else
                    subNamaBarang = sNmBrg;
                //string subNamaBarang = sNmBrg.Substring(Math.Max(0, sNmBrg.Length - 30));

                sPartNumber = dr["PartNo"].ToString().Substring(0, 12);
                sSatuan = dr["Satuan"].ToString();
                nQty = int.Parse(Tools.isNull(dr["QtySuratJalan"], "0").ToString());
                nHrgSat = double.Parse(Tools.isNull(dr["HrgJual"], "0").ToString());
                nHrgBruto = nQty * nHrgSat;
                ndisc1 = double.Parse(Tools.isNull(dr["Disc1"], "0").ToString());
                nSumDisc = double.Parse(Tools.isNull(dr["Disc"], "0").ToString());
                nPot = double.Parse(Tools.isNull(dr["Pot"], "0").ToString());
                nSumPot = double.Parse(Tools.isNull(dr["Potongan"], "0").ToString());
                nSumHrgBruto = nSumHrgBruto + nHrgBruto;
                nSumHrgNetto = nHrgBruto - nSumDisc - nSumPot;
                nTotalHrg = nTotalHrg + (nHrgBruto - nSumDisc - nSumPot);

                sTemp = (nUrut < 10 ? "0" + nUrut.ToString() : nUrut.ToString()) + ". ";
                sTemp = sTemp + subNamaBarang.PadRight(25, '.') + "  ";
                sTemp = sTemp + sPartNumber.PadRight(12, ' ') + "  ";
                sTemp = sTemp + nQty.ToString("#,###").PadLeft(3, ' ') + " " + sSatuan.PadRight(3, ' ') + "  ";
                sTemp = sTemp + nHrgSat.ToString("#,###").PadLeft(9, ' ') + "  ";
                sTemp = sTemp + ndisc1.ToString("#,###0.#0").PadLeft(5, ' ') + " ";
                sTemp = sTemp + nSumPot.ToString("#,###").PadLeft(7, ' ') + "  ";
                sTemp = sTemp + nSumHrgNetto.ToString("#,###").PadLeft(10);
                data.PROW(true, 1, sTemp);
            }

            //data.FontCondensed(false);      //true

            data.AddCR();
            if (nUrut % 20 > 0)
            {
                //data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));

                for (int n = nUrut + 1; n <= nUrut + (20 - (nUrut % 20)); n++)
                {
                    data.PROW(true, 1, " ");
                    //data.PROW(true, 1, (n < 10 ? "0" : "") + n.ToString() + ".   ");
                }
            }
            data.PROW(true, 1, data.PrintDoubleLine(90));
            //data.PROW(true, 1, data.PrintDoubleLine(134));
            data.AddCR();

            //data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));

            data.PROW(true, 1, "* HARGA SUDAH TERMASUK PPN 10 %");
            data.PROW(false, 65, "Jumlah       Rp." + nTotalHrg.ToString("#,###").PadLeft(10));

            //data.PROW(true, 1, "* HARGA SUDAH TERMASUK PPN 10 %" + data.SPACE(21)
            //    + "                                                  Jumlah         Rp. "
            //    + nTotalHrg.ToString("#,###").PadLeft(13));
            //+ nSumHrgBruto.ToString("#,###").PadLeft(13));

            data.PROW(true, 1, "* Barang yang sudah dibeli tidak boleh ditukar/dikembalikan.");
            data.Eject();
            #endregion // end region detail

            data.SendToFile("notaJualTax.txt");
            //data.SendToPrinter("notaJualTax.txt",printer);  //buat pilih printer
        }


        private void IncreamentNPrintpos()
        {
            Guid _notaHeaderRowID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
            int Nprint_ = 0;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_cekNprintNota")); //udah cek heri
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _notaHeaderRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            Nprint_ = Convert.ToInt32(dt.Rows[0]["Nprint"]);
            Nprint_++;
            dt.Rows[0]["Nprint"] = Nprint_.ToString();
            //this.dataGridNotaJual.RefreshEdit();
        }

        private void CetakNotaposRaw(DataTable dt)
        {
            BuildString data = new BuildString();
            string typePrinter = data.GetPrinterName();//ISA.Trading.LookupInfo.GetValue("PRINTER", "DOT_MATRIX"); 
            string sNamaToko = dt.Rows[0]["NamaToko"].ToString().Trim();
            string sToko = sNamaToko + data.SPACE(sNamaToko.Length + (15 - sNamaToko.Length) - 7);
            string sAlamat = dt.Rows[0]["Alamat"].ToString().Trim();
            string sDaerah = dt.Rows[0]["Daerah"].ToString().Trim();
            string sKota = dt.Rows[0]["Kota"].ToString().Trim().PadRight(20)
                + " (" + dt.Rows[0]["WilID"].ToString().Trim() + ")";
            string sPramuniaga = dt.Rows[0]["KodeSales"].ToString().Trim();

            DateTime tglSJ = Convert.ToDateTime(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value.ToString());
            string barcodeNota = (dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NoSuratJalan"].Value.ToString() + tglSJ.ToString("yyy").Substring(1, 3) + tglSJ.ToString("MM"));

            data.Initialize();
            data.PageLLine(33);
            data.LeftMargin(1);
            data.BottomMargin(1);

            #region Header
            if (typePrinter.Contains("LX"))
            {
                data.LetterQuality(false);
                data.FontBold(true);
                data.FontCondensed(true);
                data.DoubleHeight(true);
            }
            else
            {
                data.LetterQuality(true);
                data.FontBold(true);
                data.DoubleHeight(true);
                data.DoubleWidth(true);
            }
            data.PROW(true, 1, dt.Rows[0]["NamaPrs"].ToString().Trim());
            data.PROW(false, 47, "NOTA : " + dt.Rows[0]["NoSuratJalan"].ToString() + "   " + _ketNota);
            data.DoubleHeight(false);
            data.DoubleWidth(false);
            data.FontCPI(12);
            data.LineSpacing("1/8");
            data.FontCondensed(false);
            data.LetterQuality(false);
            data.FontCondensed(false);
            data.PROW(true, 1, dt.Rows[0]["AlamatPrs"].ToString());
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintTopLeftCorner() + data.PrintHorizontalLine(2) + " Pengiriman kepada Toko " + data.PrintHorizontalLine(14) + data.PrintTopRightCorner());
            data.FontItalic(false);

            data.PROW(true, 1, "                                       ");
            data.PROW(false, 51, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.PROW(true, 1, "NPWP/PKP    : " + dt.Rows[0]["NPWP"].ToString().PadRight(25));
            
            //data.FontItalic(true);
            data.PROW(false, 51, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();

            data.DoubleHeight(true);
            data.PROW(false, 58, sToko);
            data.DoubleHeight(false);

            if (dt.Rows[0]["TglPKP"].ToString() == "")
            {
                data.PROW(true, 1, "TANGGAL PKP :  ");
            }
            else
            {
                data.PROW(true, 1, "TANGGAL PKP : " + ((DateTime)dt.Rows[0]["TglPKP"]).ToString("ddMMyyyy"));
            }
            data.FontItalic(true);

            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.FontCondensed(true);
            data.AddCR();
            data.PROW(false, 92, sAlamat.PadRight(60));
            data.FontCondensed(false);
            data.PROW(true, 1, "");
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(false, 55, sDaerah.PadRight(25));
            data.PROW(true, 1, "TANGGAL NOTA: " + ((DateTime)dt.Rows[0]["TglSuratJalan"]).ToString("dd-MMM-yyyy"));
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(false, 55, sKota);
            data.PROW(true, 1, "Pramuniaga  : " + sPramuniaga + " ");
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(true, 1, "Penjualan   : " + "Tunai");

            data.FontItalic(true);
            data.PROW(false, 53, data.PrintBottomLeftCorner() + data.PrintHorizontalLine(40) + data.PrintBottomRightCorner());
            data.FontItalic(false);
            data.PROW(true, 1, "Barcode No  : " + barcodeNota);

            data.PROW(true, 1, "");
            data.FontCondensed(true);

            data.PROW(false, 2, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            data.PROW(true, 1, "No.   N a m a   B a r a n g                                             Q t y    Harga Sat     Disc      Pot          Jumlah Harga");
            data.PROW(true, 1, data.PrintDoubleLine(134));
            #endregion

            #region Detail
            int nUrut = 0;
            string sNmBrg, sSatuan, sTemp, subNamaBarang;
            double nQty, nHrgSat, nHrgBruto;
            double nSumHrgBruto = 0, nSumDisc = 0, nSumPot = 0, nTotalHrg = 0;
            foreach (DataRow dr in dt.Rows)
            {
                nUrut++;
                sNmBrg = dr["NamaBarang"].ToString();
                int panjanghuruf = sNmBrg.Length;
                if (panjanghuruf >= 65)
                {
                    subNamaBarang = sNmBrg.Substring(0, 65);
                }
                else
                {
                    subNamaBarang = sNmBrg;
                }
                //string subNamaBarang = sNmBrg.Substring(Math.Max(0, sNmBrg.Length - 30));
                sSatuan = dr["Satuan"].ToString();
                nQty = int.Parse(dr["QtySuratJalan"].ToString());
                nHrgSat = double.Parse(dr["HrgJual"].ToString());
                nHrgBruto = nQty * nHrgSat;
                nSumDisc = double.Parse(dr["Disc"].ToString());
                nSumPot = double.Parse(dr["Pot"].ToString());
                nSumHrgBruto = nSumHrgBruto + nHrgBruto;
                nTotalHrg = nTotalHrg + (nHrgBruto - double.Parse(dr["Disc"].ToString()) - double.Parse(dr["Pot"].ToString()));

                sTemp = "  " + nUrut.ToString().PadLeft(2, '0') + ". ";
                sTemp = sTemp + subNamaBarang.PadRight(65, '.') + "  ";
                sTemp = sTemp + nQty.ToString("#,###").PadLeft(3, ' ') + "." + sSatuan.PadRight(3, ' ') + "  ";
                sTemp = sTemp + "Rp." + nHrgSat.ToString("#,###").PadLeft(9, ' ');
                sTemp = sTemp + nSumDisc.ToString("#,###").PadLeft(8, ' ');
                sTemp = sTemp + "Rp." + nSumPot.ToString("#,###").PadLeft(8, ' ');
                sTemp = sTemp + "Rp." + nHrgBruto.ToString("#,###").PadLeft(10) + " ";
                data.PROW(true, 1, sTemp);
                //data.PROW(true, 1, "");
            }
            data.FontCondensed(true);
            data.AddCR();
            if (nUrut % 20 > 0)
            {
                data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
                for (int n = nUrut + 1; n <= nUrut + (20 - (nUrut % 20)); n++)
                {
                    data.PROW(true, 1, "  " + n.ToString().PadLeft(2, '0') + ".  ");
                    //data.PROW(true, 1, "");
                }
            }
            //string sBayar = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan3"].Value.ToString();
            //string sLain = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan4"].Value.ToString();
            data.PROW(true, 1, data.PrintDoubleLine(134));
            data.AddCR();
            data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            data.PROW(true, 1, "* HARGA SUDAH TERMASUK PPN 10 %" + data.SPACE(21)
                + "                                                  Jumlah         Rp. "
                + nSumHrgBruto.ToString("#,###").PadLeft(13));
            data.PROW(true, 1, "* Barang yang sudah dibeli tidak boleh ditukar/dikembalikan.");
            data.Eject();
            #endregion // end region detail
            //data.SendToPrinter("notaJualTax.txt");
            //buat pilih printer
            data.SendToFile("notaJualTax.txt");
        }




        private void CetakNota()
        {
            if (_nCetak == 2 || _nCetak == 4)
            {
                _ketNota = "RE";
            }
            else if (_nCetak == 5 || _nCetak == 6)
            {
                _ketNota = string.Empty;
            }
            else if (_nCetak == 1 || _nCetak == 3)
            {
                _ketNota = "CP";
            }

            string kdToko = dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
            string transType = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TransactionTypeNota"].Value.ToString();
            string TK = transType.ToString().Substring(0, 1);
            //if (transType == "KB" || transType == "TB")
            //{
            //    _KdSales = dataGridDO.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
            //    _KdSalesKhusus = CekSalesKhusus(_KdSales);
            //}

            Guid rowID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;

            if (GlobalVar.Gudang != "2803")
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    #region get toko penetrasi
                    /*tidak berlaku lagi*/
                    /*Toko sparepart pnt*/
                    //DataTable dtp = new DataTable();
                    //using (Database db = new Database())
                    //{
                    //    db.Commands.Add(db.CreateCommand("usp_TokoKhususPnt_LIST"));
                    //    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kdToko));
                    //    dtp = db.Commands[0].ExecuteDataTable();
                    //}
                    /*------------------*/
                    #endregion

                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_CetakNotaPenjualan"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@oli", SqlDbType.Int, _nOli));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    /*tutup kondisi, cetak nota disamakan dengan depo lain*/
                    //if (GlobalVar.Gudang != "2808")
                    //{
                        /*printerName Inkjet*/
                        if (_nCetak == 3 || _nCetak == 4 || _nCetak == 6)
                        {
                            if (TK == "K")
                            {
                                DisplayReportNotaJual(dt, "rptCetakNotaJualBaru");
                                DisplayReportNotaJual(dt, "rptCetakNotaJualCopy1");
                                DisplayReportNotaJual(dt, "rptCetakNotaJualCopy2");
                            }
                            else
                            {
                                DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiBaru");
                                DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiCopy1");
                                DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiCopy2");
                            }
                        }
                        else
                        {
                            /*printerName = "DOTMATRIX", printer = Convert.ToString(CekAppSetting(printerName));*/
                            CetakNotaRaw(dt);
                        }
                    //}
                    //else
                    //{
                    //    CetakNotaRaw2808New(dt);
                    //    //CetakNotaRaw2808(dt);
                    //}
                    IncreamentNPrint();

                    #region kondisi lama, sudah tidak berlaku
                    /*printerName Inkjet*/
                    //if (GlobalVar.Gudang != "2808")
                    //{
                    //    /*printerName Inkjet*/
                    //    if (_nCetak == 3 || _nCetak == 4 || _nCetak == 6)
                    //    {
                    //        /*Cek Toko PNT*/
                    //        if (dtp.Rows.Count == 0)
                    //        {
                    //            if (TK == "K")
                    //            {
                    //                if (_KdSalesKhusus && transType == "KB")
                    //                {
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualKhusus");
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualKhususCopy1");
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualKhususCopy2");
                    //                }
                    //                else
                    //                {
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualBaru");
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualCopy1");
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualCopy2");
                    //                }
                    //            }
                    //            else
                    //            {
                    //                if (_KdSalesKhusus && transType == "TB")
                    //                {
                    //                    //DisplayReportNotaJual(dt, "rptCetakNotaJualKhusus");
                    //                    //DisplayReportNotaJual(dt, "rptCetakNotaJualKhususCopy1");
                    //                    //DisplayReportNotaJual(dt, "rptCetakNotaJualKhususCopy2");
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiBaru");
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiCopy1");
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiCopy2");
                    //                }
                    //                else
                    //                {
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiBaru");
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiCopy1");
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiCopy2");
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            if (transType != "K2" && transType != "K4" && transType != "T2" && transType != "T4" &&
                    //                transType != "KB" && transType != "TB")
                    //            {
                    //                /*Toko SparePart PNT*/
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualSPKhusus");
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualSPKhususCopy1");
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualSPKhususCopy2");
                    //            }
                    //            else if (_KdSalesKhusus && transType == "KB")
                    //            {
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualKhusus");
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualKhususCopy1");
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualKhususCopy2");
                    //            }
                    //            else if (_KdSalesKhusus && transType == "TB")
                    //            {
                    //                //DisplayReportNotaJual(dt, "rptCetakNotaJualKhusus");
                    //                //DisplayReportNotaJual(dt, "rptCetakNotaJualKhususCopy1");
                    //                //DisplayReportNotaJual(dt, "rptCetakNotaJualKhususCopy2");
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiBaru");
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiCopy1");
                    //                DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiCopy2");
                    //            }
                    //            else
                    //            {
                    //                if (TK == "K")
                    //                {
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualBaru");
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualCopy1");
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualCopy2");
                    //                }
                    //                else
                    //                {
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiBaru");
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiCopy1");
                    //                    DisplayReportNotaJual(dt, "rptCetakNotaJualTunaiCopy2");
                    //                }
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        //printerName = "DOTMATRIX";
                    //        //printer = Convert.ToString(CekAppSetting(printerName));
                    //        CetakNotaRaw(dt);
                    //    }
                    //}
                    //else
                    //{
                    //    CetakNotaRaw2808(dt);
                    //}
                    //IncreamentNPrint();
                    #endregion

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
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_CetakNotaPenjualan_Disc2803"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@oli", SqlDbType.Int, _nOli));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    if (_nCetak == 3 || _nCetak == 4 || _nCetak == 6)
                    {
                        /*printerName = "INKJET", printer = Convert.ToString(CekAppSetting(printerName));*/
                        DisplayReportNotaJual(dt, "rptCetakNotaJualBaru_unLogoNew_v2");
                        DisplayReportNotaJual(dt, "rptCetakNotaJualCopy1_unLogoNew_v2");
                        DisplayReportNotaJual(dt, "rptCetakNotaJualCopy2_unLogoNew_v2");
                    }
                    else
                    {
                        /*printerName = "DOTMATRIX", printer = Convert.ToString(CekAppSetting(printerName));*/
                        CetakNotaRaw(dt);
                    }
                    IncreamentNPrint();
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


        //private Boolean CekSalesKhusus(string KdSales)
        //{
        //    bool x = false;
        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        DataTable dts = new DataTable();
        //        using (Database db = new Database())
        //        {
        //            db.Commands.Add(db.CreateCommand("usp_KodeSalesKhusus_LIST"));
        //            db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, KdSales));
        //            dts = db.Commands[0].ExecuteDataTable();
        //            if (dts.Rows.Count > 0)
        //            {
        //                x = true;
        //                if (_nCetak == 2 || _nCetak == 4)
        //                {
        //                    _ketNota = "(R)";
        //                }
        //                else if (_nCetak == 5 || _nCetak == 6)
        //                {
        //                    _ketNota = string.Empty;
        //                }
        //                else if (_nCetak == 1 || _nCetak == 3)
        //                {
        //                    _ketNota = "(C)";
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
        //    return x;    
        //}


        public void DisplayReportNotaJual(DataTable dt, String ReportName)
        {
            string sExpedisi = dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString();
            double Total = 0;
            double TotalDisc = 0;
            foreach (DataRow dr in dt.Rows)
            {
                Double QtySJ = Convert.ToInt32(Tools.isNull(dr["QtySuratJalan"], "0"));
                Double HrgJual = Convert.ToDouble(Tools.isNull(dr["HrgJual"], "0"));
                Double Disc = Convert.ToInt32(dr["Disc"]);
                decimal Disc1 = Convert.ToDecimal(Tools.isNull(dr["Disc1"], "0"));
                decimal Disc2 = Convert.ToDecimal(Tools.isNull(dr["Disc2"], "0"));
                Double Pot = Convert.ToInt32(Tools.isNull(dr["Pot"], "0"));

                TotalDisc = TotalDisc + ((Disc * QtySJ) + (Pot * QtySJ));

                if (GlobalVar.Gudang == "2803")
                {
                    /*RpNet Detail*/
                    Double w = HrgJual * QtySJ;
                    Double x = w - Convert.ToDouble((Disc1 / 100) * Convert.ToDecimal(w));
                    Double y = x - Convert.ToDouble((Disc2 / 100) * Convert.ToDecimal(x));
                    Total += Math.Round(y, 0) - Pot;
                }
                else
                {
                    Total = Total + (QtySJ * HrgJual);
                }
            }

            Double TotalAkumulasi = Total - TotalDisc;

            if (dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString() != "SAS")
            {
                sExpedisi = string.Empty;
            }
            DateTime tglSJ = Convert.ToDateTime(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value.ToString());
            String tglSJFix = tglSJ.ToString("dd-MMM-yyyy");
            String tglSJBarcode = tglSJ.ToString("dd-MM-yyyy");
            string TunaiKredit = dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value.ToString().Substring(0, 1);
            string barcodeNota = (dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NoSuratJalan"].Value.ToString() + tglSJ.ToString("yyy").Substring(1, 3) + tglSJ.ToString("MM"));
            string Sales = "";
            if (_KdSalesKhusus)
                Sales = dataGridDO.SelectedCells[0].OwningRow.Cells["NamaSales"].Value.ToString();
            else
                Sales = GetSales();
            string jw = "";
            if (GlobalVar.Gudang != "2803")
            {
                jw = dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString();
            }
            dataGridNotaJual.SelectedCells[0].OwningRow.Cells["Barcode"].Value = barcodeNota;

            string jnstransaksi = dtNotaJual.Rows[0]["TunaiKredit"].ToString();
            string KodeGudang = GlobalVar.Gudang;
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("NomorDO", dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString()));
            rptParams.Add(new ReportParameter("NoSuratJalan", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NoSuratJalan"].Value.ToString()));
            rptParams.Add(new ReportParameter("TglSuratJalan", tglSJFix));
            rptParams.Add(new ReportParameter("HariKredit", jw));
            rptParams.Add(new ReportParameter("Sales", Sales));
            rptParams.Add(new ReportParameter("Expedisi", sExpedisi));
            rptParams.Add(new ReportParameter("NamaToko", dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString().Trim()));
            rptParams.Add(new ReportParameter("Alamat", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaAlamatKirim"].Value.ToString().Trim()));
            rptParams.Add(new ReportParameter("Kota", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaKota"].Value.ToString()));
            rptParams.Add(new ReportParameter("Daerah", dataGridDO.SelectedCells[0].OwningRow.Cells["Daerah"].Value.ToString()));
            rptParams.Add(new ReportParameter("WilID", dataGridDO.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString()));
            rptParams.Add(new ReportParameter("KetNota", _ketNota));
            rptParams.Add(new ReportParameter("Total", Total.ToString()));
            rptParams.Add(new ReportParameter("TotalDisc", TotalDisc.ToString()));
            rptParams.Add(new ReportParameter("TotalAkumulasi", TotalAkumulasi.ToString()));
            rptParams.Add(new ReportParameter("Catatan3", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan3"].Value.ToString()));
            rptParams.Add(new ReportParameter("Catatan4", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan4"].Value.ToString()));
            rptParams.Add(new ReportParameter("BarcodeBar", "*" + barcodeNota + "*"));
            rptParams.Add(new ReportParameter("Barcode", barcodeNota));
            rptParams.Add(new ReportParameter("Catatan", ""));
            rptParams.Add(new ReportParameter("TK", TunaiKredit));
            rptParams.Add(new ReportParameter("KodeGudang", KodeGudang));

            if (_TokoPnt != "1")
            {
                if (jnstransaksi == "T")
                {
                    frmReportViewer ifrmReport = new frmReportViewer("POS." + ReportName + ".rdlc", rptParams, dt, "dsNotaPenjualan_Data");
                    ifrmReport.Print();
                    //ifrmReport.Show();
                }
                else
                {
                    frmReportViewer ifrmReport = new frmReportViewer("Penjualan." + ReportName + ".rdlc", rptParams, dt, "dsNotaPenjualan_Data");
                    ifrmReport.Print();
                    //ifrmReport.Show();
                }
            }
            else
            {
                frmReportViewer ifrmReport = new frmReportViewer("Penjualan." + ReportName + ".rdlc", rptParams, dt, "dsNotaPenjualan_Data");
                ifrmReport.Print();
            }
            //ifrmReport.Show();
        }

        private string CetakHeaderNota(DataTable dt)
        {
            BuildString header = new BuildString();

            //string typePrinter = header.GetPrinterDotmatrix(printer);
            string typePrinter = header.GetPrinterName();
            string sNamaToko = dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString().Trim();
            string sToko = sNamaToko + header.SPACE(sNamaToko.Length + (15 - sNamaToko.Length) - 7);
            string sAlamat = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaAlamatKirim"].Value.ToString().Trim();
            string sDaerah = dataGridDO.SelectedCells[0].OwningRow.Cells["Daerah"].Value.ToString().Trim();
            string sKota = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaKota"].Value.ToString().Trim().PadRight(20)
                + " (" + dataGridDO.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString().Trim() + ")";
            string sExpedisi = string.Empty; ;
            string sTempo = dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString();

            DateTime tglSJ = Convert.ToDateTime(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value.ToString());
            string barcodeNota = (dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NoSuratJalan"].Value.ToString() + tglSJ.ToString("yyy").Substring(1, 3) + tglSJ.ToString("MM"));

            if (dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString() != "SAS")
            {
                sExpedisi = string.Empty;
            }

            #region Header
            header.Initialize();
            header.PageLLine(33);
            header.LeftMargin(1);
            if (typePrinter.Contains("LX"))
            {
                header.BottomMargin(0);
                header.LetterQuality(false);
                header.FontBold(true);
                header.FontCondensed(true);
                header.DoubleHeight(true);
                header.PROW(true, 1, header.SPACE(25) + "NOTA  : "
                    + dt.Rows[0]["NoSuratJalan"].ToString() + "   "
                    + _ketNota);
            }
            else
            {
                header.BottomMargin(1);
                header.LetterQuality(true);
                header.FontBold(true);
                header.DoubleHeight(true);
                header.DoubleWidth(true);
                header.PROW(true, 1, header.SPACE(21) + "NOTA  : "
                    + dt.Rows[0]["NoSuratJalan"].ToString() + "   "
                    + _ketNota);
            }
            //header.FontBold(false);
            header.DoubleWidth(false);
            header.DoubleHeight(false);
            header.FontCPI(12);
            header.LineSpacing("1/8");
            header.FontCondensed(false);
            header.PROW(true, 1, "NOMOR DO   : " + dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString());
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintTopLeftCorner() + header.PrintHorizontalLine(2) + " Pengiriman kepada Toko " + header.PrintHorizontalLine(14) + header.PrintTopRightCorner());
            header.FontItalic(false);

            
            header.PROW(true, 1, "SUB        :  ");
            //header.FontItalic(true);
            header.PROW(false, 51, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.PROW(true, 1, "              ");
            header.PROW(false, 51, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(false);
            header.AddCR();

            header.DoubleHeight(true);
            header.PROW(false, 58, sToko);
            header.DoubleHeight(false);

            header.PROW(true, 1, "TANGGAL    : " + ((DateTime)dt.Rows[0]["TglSuratJalan"]).ToString("dd-MMM-yyyy"));
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(false);
            header.FontCondensed(true);
            header.AddCR();
            header.PROW(false, 92, sAlamat.PadRight(60));
            header.FontCondensed(false);
            header.PROW(true, 1, "TEMPO      : " + sTempo + " (" + Tools.Terbilang(int.Parse(sTempo)) + ")");
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(false);
            header.AddCR();
            header.PROW(false, 55, sDaerah.PadRight(25));
            header.PROW(true, 1, "SALESMAN   : " + GetSales().PadRight(27));
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(false);
            header.AddCR();
            header.PROW(false, 55, sKota);
            header.PROW(true, 1, "EXPEDISI   : " + sExpedisi);
            header.PROW(false, 55, "Barcode No : " + barcodeNota);
            header.FontItalic(true);
            header.PROW(false, 51, header.PrintBottomLeftCorner() + header.PrintHorizontalLine(40) + header.PrintBottomRightCorner());
            header.FontItalic(false);
            header.PROW(true, 1, "");
            header.FontCondensed(false);
            header.AddCR();
            header.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            header.PROW(true, 1, "No.   N a m a   B a r a n g                                             Q t y    Harga Sat     Disc      Pot          Jumlah Harga");
            header.PROW(true, 1, header.PrintDoubleLine(134));
            #endregion // end region header

            return header.GenerateString();
        }


        private string CetakHeaderNota2808(DataTable dt)
        {
            BuildString header = new BuildString();

            //string typePrinter = header.GetPrinterDotmatrix(printer);
            string typePrinter = header.GetPrinterName();
            string sNamaToko = dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString().Trim();
            string sToko = sNamaToko + header.SPACE(sNamaToko.Length + (15 - sNamaToko.Length) - 7);
            string sAlamat = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaAlamatKirim"].Value.ToString().Trim();
            string sDaerah = dataGridDO.SelectedCells[0].OwningRow.Cells["Daerah"].Value.ToString().Trim();
            string sKota = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaKota"].Value.ToString().Trim().PadRight(20)
                + " (" + dataGridDO.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString().Trim() + ")";
            string sExpedisi = string.Empty; ;
            string sTempo = dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString();


            if (dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString() != "SAS")
            {
                sExpedisi = string.Empty;
            }

            #region Header
            header.Initialize();
            header.PageLLine(33);
            header.LeftMargin(1);
            if (typePrinter.Contains("LX"))
            {
                header.BottomMargin(0);
                header.LetterQuality(false);
                header.FontBold(true);
                header.FontCondensed(true);
                header.DoubleHeight(true);
                header.PROW(true, 1, header.SPACE(25) + "NOTA  : "
                    + dt.Rows[0]["NoSuratJalan"].ToString() + "   "
                    + _ketNota);
            }
            else
            {
                header.BottomMargin(1);
                header.LetterQuality(true);
                header.FontBold(true);
                header.DoubleHeight(true);
                header.DoubleWidth(true);
                header.PROW(true, 1, header.SPACE(21) + "NOTA  : "
                    + dt.Rows[0]["NoSuratJalan"].ToString() + "   "
                    + _ketNota);
            }
            //header.FontBold(false);
            header.DoubleWidth(false);
            header.DoubleHeight(false);
            header.FontCPI(12);
            header.LineSpacing("1/8");
            header.FontCondensed(false);
            header.PROW(true, 1, "NOMOR DO   : " + dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString());
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintTopLeftCorner() + header.PrintHorizontalLine(2) + " Pengiriman kepada Toko " + header.PrintHorizontalLine(14) + header.PrintTopRightCorner());
            header.FontItalic(false);
            header.PROW(true, 1, "SUB        :  ");
            header.PROW(false, 51, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.PROW(true, 1, "              ");
            //header.FontItalic(true);
            header.PROW(false, 51, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(false);
            header.AddCR();
            header.DoubleHeight(true);
            header.PROW(false, 58, sToko);
            header.DoubleHeight(false);
            header.PROW(true, 1, "TANGGAL    : " + ((DateTime)dt.Rows[0]["TglSuratJalan"]).ToString("dd-MMM-yyyy"));
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(false);
            header.FontCondensed(true);
            header.AddCR();
            header.PROW(false, 92, sAlamat.PadRight(60));
            header.FontCondensed(false);
            header.PROW(true, 1, "TEMPO      : " + sTempo + " (" + Tools.Terbilang(int.Parse(sTempo)) + ")");
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(false);
            header.AddCR();
            header.PROW(false, 55, sDaerah.PadRight(25));
            header.PROW(true, 1, "SALESMAN   : " + GetSales().PadRight(27));
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(false);
            header.AddCR();
            header.PROW(false, 55, sKota);
            header.PROW(true, 1, "EXPEDISI   : " + sExpedisi);
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintBottomLeftCorner() + header.PrintHorizontalLine(40) + header.PrintBottomRightCorner());
            header.FontItalic(false);
            header.PROW(true, 1, "");
            header.FontCondensed(false);
            header.AddCR();
            header.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            //header.PROW(true, 1, "No.   N a m a   B a r a n g                                             Q t y    Harga Sat     Disc      Pot          Jumlah Harga");
            header.PROW(true, 1, "No. N a m a   B a r a n g                           Q t y  Harga Net     Jumlah");
            //                    12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678
            //                             1         2         3         4         5         6         7         8         9         10        11        12
            header.PROW(true, 1, header.PrintDoubleLine(134));
            #endregion // end region header

            return header.GenerateString();
        }


        private string CetakHeaderNota2808New(DataTable dt)
        {
            BuildString header = new BuildString();

            //string typePrinter = header.GetPrinterDotmatrix(printer);
            string typePrinter = header.GetPrinterName();
            string sNamaToko = dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString().Trim();
            string sToko = sNamaToko + header.SPACE(sNamaToko.Length + (15 - sNamaToko.Length) - 7);
            string sAlamat = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaAlamatKirim"].Value.ToString().Trim();
            string sDaerah = dataGridDO.SelectedCells[0].OwningRow.Cells["Daerah"].Value.ToString().Trim();
            string sKota = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaKota"].Value.ToString().Trim().PadRight(20)
                + " (" + dataGridDO.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString().Trim() + ")";
            string sExpedisi = string.Empty; ;
            string sTempo = dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString();


            if (dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString() != "SAS")
            {
                sExpedisi = string.Empty;
            }

            #region Header
            header.Initialize();
            header.PageLLine(33);
            header.LeftMargin(1);
            if (typePrinter.Contains("LX"))
            {
                header.BottomMargin(0);
                header.LetterQuality(false);
                header.FontBold(true);
                header.FontCondensed(true);
                header.DoubleHeight(true);
                header.PROW(true, 1, header.SPACE(25) + "NOTA  : "
                    + dt.Rows[0]["NoSuratJalan"].ToString() + "   "
                    + _ketNota);
            }
            else
            {
                header.BottomMargin(1);
                header.LetterQuality(true);
                header.FontBold(true);
                header.DoubleHeight(true);
                header.DoubleWidth(true);
                header.PROW(true, 1, header.SPACE(21) + "NOTA  : "
                    + dt.Rows[0]["NoSuratJalan"].ToString() + "   "
                    + _ketNota);
            }
            //header.FontBold(false);
            header.DoubleWidth(false);
            header.DoubleHeight(false);
            header.FontCPI(12);
            header.LineSpacing("1/8");
            header.FontCondensed(false);
            header.PROW(true, 1, "NOMOR DO   : " + dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString());
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintTopLeftCorner() + header.PrintHorizontalLine(2) + " Pengiriman kepada Toko " + header.PrintHorizontalLine(14) + header.PrintTopRightCorner());
            header.FontItalic(false);
            header.PROW(true, 1, "SUB        :  ");
            header.PROW(false, 51, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.PROW(true, 1, "              ");
            //header.FontItalic(true);
            header.PROW(false, 51, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(false);
            header.AddCR();
            header.DoubleHeight(true);
            header.PROW(false, 58, sToko);
            header.DoubleHeight(false);
            header.PROW(true, 1, "TANGGAL    : " + ((DateTime)dt.Rows[0]["TglSuratJalan"]).ToString("dd-MMM-yyyy"));
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(false);
            header.FontCondensed(true);
            header.AddCR();
            header.PROW(false, 92, sAlamat.PadRight(60));
            header.FontCondensed(false);
            header.PROW(true, 1, "TEMPO      : " + sTempo + " (" + Tools.Terbilang(int.Parse(sTempo)) + ")");
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(false);
            header.AddCR();
            header.PROW(false, 55, sDaerah.PadRight(25));
            header.PROW(true, 1, "SALESMAN   : " + GetSales().PadRight(27));
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(false);
            header.AddCR();
            header.PROW(false, 55, sKota);
            header.PROW(true, 1, "EXPEDISI   : " + sExpedisi);
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintBottomLeftCorner() + header.PrintHorizontalLine(40) + header.PrintBottomRightCorner());
            header.FontItalic(false);
            header.PROW(true, 1, "");
            header.FontCondensed(false);
            header.AddCR();
            header.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            //header.PROW(true, 1, "No.   N a m a   B a r a n g                                             Q t y    Harga Sat     Disc      Pot          Jumlah Harga");
            header.PROW(true, 1, "No. N a m a   B a r a n g           Part.No   Part.No Q t y  Harga Net     Jumlah");
            //                    12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678
            //                             1         2         3         4         5         6         7         8         9         10        11        12
            header.PROW(true, 1, header.PrintDoubleLine(134));
            #endregion // end region header

            return header.GenerateString();
        }


        private void CetakNotaRaw(DataTable dt)
        {

            BuildString detail = new BuildString();
            if (GlobalVar.Gudang == "2808")
                detail.Append(CetakHeaderNota2808(dt));
            else
                detail.Append(CetakHeaderNota(dt));

            #region Cetak Detail
            int nUrut = 0;
            string sNmBrg, sSatuan, sTemp, subNamaBarang,PartNo;
            double nQty, nHrgSat, nHrgBruto;
            double nSumHrgBruto = 0, nSumDisc = 0, nSumPot = 0, nTotalHrg = 0;
            //tutup sementara
            foreach (DataRow dr in dt.Rows)
            {
                nUrut++;
                sNmBrg = dr["NamaBarang"].ToString();
                int panjanghuruf = sNmBrg.Length;
                if (panjanghuruf >= 65)
                {
                    subNamaBarang = sNmBrg.Substring(0, 65);
                }
                else
                {
                    subNamaBarang = sNmBrg;
                }

                sSatuan = dr["Satuan"].ToString();
                PartNo = dr["PartNo"].ToString();
                nQty = int.Parse(dr["QtySuratJalan"].ToString());
                nHrgSat = double.Parse(dr["HrgJual"].ToString());
                nHrgBruto = nQty * nHrgSat;
                nSumDisc += double.Parse(dr["Disc"].ToString());
                nSumPot += double.Parse(dr["Pot"].ToString());
                nSumHrgBruto = nSumHrgBruto + nHrgBruto;
                nTotalHrg = nTotalHrg + (nHrgBruto - double.Parse(dr["Disc"].ToString()));

                sTemp = (nUrut < 10 ? "0" + nUrut.ToString() : nUrut.ToString()) + ".";
                sTemp = sTemp + subNamaBarang.PadRight(65, '.') + " ";
                sTemp = sTemp + PartNo.PadRight(10, '.') + " ";
                sTemp = sTemp + nQty.ToString("#,###").PadLeft(3, ' ') + "." + sSatuan.PadRight(3, ' ') + "  ";
                sTemp = sTemp + "Rp." + nHrgSat.ToString("#,###").PadLeft(9, ' ');
                sTemp = sTemp + nSumDisc.ToString("#,###").PadLeft(8, ' ') + "     ";
                sTemp = sTemp + "Rp." + nSumPot.ToString("#,###").PadLeft(8, ' ');
                sTemp = sTemp + "Rp." + nHrgBruto.ToString("#,###").PadLeft(10) + " ";
                detail.PROW(true, 1, sTemp);
            }
            detail.FontCondensed(true);
            detail.AddCR();
            if (nUrut % 20 > 0)
            {
                detail.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
                for (int n = nUrut + 1; n <= nUrut + (20 - (nUrut % 20)); n++)
                {
                    detail.PROW(true, 1, (n < 10 ? "0" : "") + n.ToString() + ".   ");
                }
            }
            string sBayar = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan3"].Value.ToString();
            string sLain = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan4"].Value.ToString();
            detail.PROW(true, 1, detail.PrintDoubleLine(134));
            detail.AddCR();
            detail.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            detail.PROW(true, 1, "Pembayaran : " + sBayar);
            detail.PROW(false, 118, "Rp. " + nSumHrgBruto.ToString("#,###").PadLeft(11));

            if (Convert.ToBoolean(Class.AppSetting.GetValue("BIAYA_KIRIM")))
            {
                detail.PROW(true, 1, "Catatan    : Biaya Kirim Gratis " + sLain);
            }
            else
            {
                detail.PROW(true, 1, "Catatan    : " + sLain);
            }
            detail.PROW(true, 1, "Packing : " + sBayar);
            detail.PROW(false, 39, "Penerima");
            detail.PROW(false, 60, "Admin");
            detail.PROW(false, 81, "Pengirim");
            detail.PROW(true, 1, "");
            detail.PROW(true, 1, "");
            detail.PROW(false, 39, detail.PrintHorizontalLine(13));
            detail.PROW(false, 60, detail.PrintHorizontalLine(13));
            detail.PROW(false, 81, detail.PrintHorizontalLine(13));

            detail.PROW(false, 118, detail.PrintHorizontalLine(15));
            detail.PROW(true, 118, "Rp. " + (nTotalHrg).ToString("#,###").PadLeft(11));
            detail.PROW(true, 1, "- Bila nota ini belum terbayar sesuai waktu yang ditentukan, maka kami berhak menarik kembali barang-barang tersebut.");
            detail.PROW(true, 1, "- Agar tidak terjadi kesalahan dalam pencatatan pembayaran, mohon setelah melakukan pembayaran / Retur berkenan melakukan");
            detail.PROW(true, 1, "  konfirmasi via sms / telepon ke Hp. 08170631848 / 087836167652 ");
            //detail.PROW(true, 1, "");//mus tambah
            detail.Eject();
            //--website:www.sas-autoparts.com '+IIF(nOli=2,Thisform.Rp2Kode(nReal),'')
            #endregion // end region cetak detail
            //string nama = "";


            //detail.SendToPrinter("notaJual.txt");
            detail.SendToFile("notaJual.txt");
            //detail.SendToPrinter("notaJual.txt", printer);// tambah inputan printer buat mengambil default printer sesuai yang dipilih pada radio button
        }


        private void CetakNotaRaw2808New(DataTable dt)
        {

            BuildString detail = new BuildString();
            detail.Append(CetakHeaderNota2808New(dt));

            //header.PROW(true,1,"No. N a m a   B a r a n g           Part.No        Q t y  Harga Net     Jumlah");
            //                    12345678901234567890123456789012345678901234567890123456789012345678901234567890
            //                             1         2         3         4         5         6         7         8

            #region Cetak Detail
            int nUrut = 0;
            string sNmBrg, sSatuan, sTemp, subNamaBarang,partNo;
            double nQty, nHrgSat, nHrgBruto;
            double nSumHrgBruto = 0, nSumDisc = 0, nSumPot = 0, nTotalHrg = 0,
                   nDisc1 = 0, nDisc2 = 0, nDisc3 = 0, nPot = 0, nJmlNetto = 0, HrgNet = 0;
            foreach (DataRow dr in dt.Rows)
            {
                nUrut++;
                sNmBrg = dr["NamaBarang"].ToString();
                int panjanghuruf = sNmBrg.Length;
                if (panjanghuruf >= 57)
                {
                    subNamaBarang = sNmBrg.Substring(0, 57);
                }
                else
                {
                    subNamaBarang = sNmBrg;
                }

                sSatuan = dr["Satuan"].ToString();
                partNo = dr["PartNo"].ToString();
                partNo = dr["PartNo"].ToString();
                nQty = int.Parse(dr["QtySuratJalan"].ToString());
                nHrgSat = double.Parse(dr["HrgJual"].ToString());
                nHrgBruto = nQty * nHrgSat;
                //nSumDisc += double.Parse(dr["Disc"].ToString());
                nDisc1 = double.Parse(Tools.isNull(dr["Disc1"], "0").ToString());
                nDisc2 = double.Parse(Tools.isNull(dr["Disc2"], "0").ToString());
                nPot = double.Parse(Tools.isNull(dr["Pot"], "0").ToString());
                nSumPot += double.Parse(Tools.isNull(dr["Pot"], "0").ToString());
                nTotalHrg = nTotalHrg + (nHrgBruto - double.Parse(dr["Disc"].ToString()));

                HrgNet = Convert.ToDouble(Tools.isNull(HitNet3D(nHrgSat, nDisc1, nDisc2, nDisc3), "0").ToString()) - nPot;
                nJmlNetto = nQty * HrgNet;
                nSumHrgBruto = nSumHrgBruto + nJmlNetto;

                sTemp = (nUrut < 10 ? "0" + nUrut.ToString() : nUrut.ToString()) + ".";
                sTemp = sTemp + subNamaBarang.PadRight(57, '.') + " ";
                sTemp = sTemp + partNo.PadRight(10, '.') + " ";
                sTemp = sTemp + nQty.ToString("#,###").PadLeft(3, ' ') + "." + sSatuan.PadRight(3, ' ') + " ";
                //sTemp = sTemp + "Rp." + nHrgSat.ToString("#,###").PadLeft(10, ' ') + " ";
                //sTemp = sTemp + nDisc1.ToString("#,###0.#0") + " ";
                //sTemp = sTemp + nDisc2.ToString("#,###0.#0") + " ";
                //sTemp = sTemp + "Rp." + nPot.ToString("#,###").PadLeft(7, ' ') + " ";
                sTemp = sTemp + "Rp." + HrgNet.ToString("#,###").PadLeft(10) + " ";
                sTemp = sTemp + "Rp." + nJmlNetto.ToString("#,###").PadLeft(10) + " ";
                detail.PROW(true, 1, sTemp);
            }
            detail.FontCondensed(true);
            detail.AddCR();
            if (nUrut % 20 > 0)
            {
                detail.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
                for (int n = nUrut + 1; n <= nUrut + (20 - (nUrut % 20)); n++)
                {
                    detail.PROW(true, 1, (n < 10 ? "0" : "") + n.ToString() + ".   ");
                }
            }
            string sBayar = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan3"].Value.ToString();
            string sLain = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan4"].Value.ToString();
            detail.PROW(true, 1, detail.PrintDoubleLine(134));
            detail.AddCR();
            detail.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            detail.PROW(true, 1, "Pembayaran : " + sBayar);
            detail.PROW(false, 120, "Rp. " + nSumHrgBruto.ToString("#,###").PadLeft(11));

            if (Convert.ToBoolean(Class.AppSetting.GetValue("BIAYA_KIRIM")))
            {
                detail.PROW(true, 1, "Catatan    : Biaya Kirim Gratis " + sLain);
            }
            else
            {
                detail.PROW(true, 1, "Catatan    : " + sLain);
            }
            detail.PROW(true, 1, "Packing : " + sBayar);
            detail.PROW(false, 39, "Penerima");
            detail.PROW(false, 60, "Admin");
            detail.PROW(false, 81, "Pengirim");
            detail.PROW(true, 1, "");
            detail.PROW(true, 1, "");
            detail.PROW(false, 39, detail.PrintHorizontalLine(13));
            detail.PROW(false, 60, detail.PrintHorizontalLine(13));
            detail.PROW(false, 81, detail.PrintHorizontalLine(13));

            detail.PROW(false, 120, detail.PrintHorizontalLine(15));
            //detail.PROW(true, 120, "Rp. " + nSumHrgBruto.ToString("#,###").PadLeft(11));
            detail.PROW(true, 1, "- Bila nota ini belum terbayar sesuai waktu yang ditentukan, maka kami berhak menarik kembali barang-barang tersebut.");
            detail.PROW(true, 1, "- Agar tidak terjadi kesalahan dalam pencatatan pembayaran, mohon setelah melakukan pembayaran / Retur berkenan melakukan");
            detail.PROW(true, 1, "  konfirmasi via sms / telepon ke Hp. 08170631848 / 087836167652 ");
            detail.PROW(true, 1, "");//mus tambah
            detail.Eject();
            //--website:www.sas-autoparts.com '+IIF(nOli=2,Thisform.Rp2Kode(nReal),'')
            #endregion // end region cetak detail
            //string nama = "";


            detail.SendToPrinter("notaJual.txt");
            //detail.SendToFile("notaJual.txt");
            //detail.SendToPrinter("notaJual.txt", printer);// tambah inputan printer buat mengambil default printer sesuai yang dipilih pada radio button
        }




        private void CetakNotaRaw2808(DataTable dt)
        {

            BuildString detail = new BuildString();
            detail.Append(CetakHeaderNota2808(dt));

            #region Cetak Detail
            int nUrut = 0;
            string sNmBrg, sSatuan, sTemp, subNamaBarang;
            double nQty, nHrgSat, nHrgBruto;
            double nSumHrgBruto = 0, nSumDisc = 0, nSumPot = 0, nTotalHrg = 0,
                   nDisc1 = 0, nDisc2 = 0, nDisc3 = 0, nPot = 0, nJmlNetto = 0, HrgNet = 0;
            foreach (DataRow dr in dt.Rows)
            {
                nUrut++;
                sNmBrg = dr["NamaBarang"].ToString();
                int panjanghuruf = sNmBrg.Length;
                if (panjanghuruf >= 57)
                {
                    subNamaBarang = sNmBrg.Substring(0, 57);
                }
                else
                {
                    subNamaBarang = sNmBrg;
                }

                sSatuan = dr["Satuan"].ToString();
                nQty = int.Parse(dr["QtySuratJalan"].ToString());
                nHrgSat = double.Parse(dr["HrgJual"].ToString());
                nHrgBruto = nQty * nHrgSat;
                //nSumDisc += double.Parse(dr["Disc"].ToString());
                nDisc1 = double.Parse(Tools.isNull(dr["Disc1"], "0").ToString());
                nDisc2 = double.Parse(Tools.isNull(dr["Disc2"], "0").ToString());
                nPot = double.Parse(Tools.isNull(dr["Pot"], "0").ToString());
                nSumPot += double.Parse(Tools.isNull(dr["Pot"], "0").ToString());
                nTotalHrg = nTotalHrg + (nHrgBruto - double.Parse(dr["Disc"].ToString()));

                HrgNet = Convert.ToDouble(Tools.isNull(HitNet3D(nHrgSat, nDisc1, nDisc2, nDisc3), "0").ToString()) - nPot;
                nJmlNetto = nQty * HrgNet;
                nSumHrgBruto = nSumHrgBruto + nJmlNetto;

                sTemp = (nUrut < 10 ? "0" + nUrut.ToString() : nUrut.ToString()) + ".";
                sTemp = sTemp + subNamaBarang.PadRight(57, '.') + " ";
                sTemp = sTemp + nQty.ToString("#,###").PadLeft(3, ' ') + "." + sSatuan.PadRight(3, ' ') + "  ";
                sTemp = sTemp + "Rp." + nHrgSat.ToString("#,###").PadLeft(10, ' ') + " ";
                sTemp = sTemp + nDisc1.ToString("#,###0.#0") + " ";
                sTemp = sTemp + nDisc2.ToString("#,###0.#0") + " ";
                sTemp = sTemp + "Rp." + nPot.ToString("#,###").PadLeft(7, ' ') + " ";
                sTemp = sTemp + "Rp." + HrgNet.ToString("#,###").PadLeft(10) + " ";
                sTemp = sTemp + "Rp." + nJmlNetto.ToString("#,###").PadLeft(10) + " ";
                detail.PROW(true, 1, sTemp);
            }
            detail.FontCondensed(true);
            detail.AddCR();
            if (nUrut % 20 > 0)
            {
                detail.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
                for (int n = nUrut + 1; n <= nUrut + (20 - (nUrut % 20)); n++)
                {
                    detail.PROW(true, 1, (n < 10 ? "0" : "") + n.ToString() + ".   ");
                }
            }
            string sBayar = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan3"].Value.ToString();
            string sLain = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan4"].Value.ToString();
            detail.PROW(true, 1, detail.PrintDoubleLine(134));
            detail.AddCR();
            detail.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            detail.PROW(true, 1, "Pembayaran : " + sBayar);
            detail.PROW(false, 120, "Rp. " + nSumHrgBruto.ToString("#,###").PadLeft(11));

            if (Convert.ToBoolean(Class.AppSetting.GetValue("BIAYA_KIRIM")))
            {
                detail.PROW(true, 1, "Catatan    : Biaya Kirim Gratis " + sLain);
            }
            else
            {
                detail.PROW(true, 1, "Catatan    : " + sLain);
            }
            detail.PROW(true, 1, "Packing : " + sBayar);
            detail.PROW(false, 39, "Penerima");
            detail.PROW(false, 60, "Admin");
            detail.PROW(false, 81, "Pengirim");
            detail.PROW(true, 1, "");
            detail.PROW(true, 1, "");
            detail.PROW(false, 39, detail.PrintHorizontalLine(13));
            detail.PROW(false, 60, detail.PrintHorizontalLine(13));
            detail.PROW(false, 81, detail.PrintHorizontalLine(13));

            detail.PROW(false, 120, detail.PrintHorizontalLine(15));
            detail.PROW(true, 120, "Rp. " + nSumHrgBruto.ToString("#,###").PadLeft(11));
            detail.PROW(true, 1, "- Bila nota ini belum terbayar sesuai waktu yang ditentukan, maka kami berhak menarik kembali barang-barang tersebut.");
            detail.PROW(true, 1, "- Agar tidak terjadi kesalahan dalam pencatatan pembayaran, mohon setelah melakukan pembayaran / Retur berkenan melakukan");
            detail.PROW(true, 1, "  konfirmasi via sms / telepon ke Hp. 08170631848 / 087836167652 ");
            detail.PROW(true, 1, "");//mus tambah
            detail.Eject();
            //--website:www.sas-autoparts.com '+IIF(nOli=2,Thisform.Rp2Kode(nReal),'')
            #endregion // end region cetak detail
            //string nama = "";


            //detail.SendToPrinter("notaJual.txt");
            detail.SendToFile("notaJual.txt");
            //detail.SendToPrinter("notaJual.txt", printer);// tambah inputan printer buat mengambil default printer sesuai yang dipilih pada radio button
        }


        private double HitNet3D(double hrg, double d1, double d2, double d3)
        {
            double Harga = 0;
            Harga = hrg - ((d1 / 100) * hrg);
            Harga = Harga - ((d2 / 100) * Harga);
            Harga = Math.Round(Harga - ((d3 / 100) * Harga), 0);
            return Harga;
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
            string result = konfersi.Substring(c1 - 1, 1) + "\\" + konfersi.Substring(c2 - 1, 1)
                            + "\\" + namaSales;

            return result;
        }

        //private void CetakNotaTax()
        //{
        //    // Cetak nota dengan Toko yang kode 'Cabang2' nya 'PT'
        //    string transType = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TransactionTypeNota"].Value.ToString();

        //    if (transType == "KB")
        //    {
        //        MessageBox.Show("Nota dicetak dengan harga PRICELIST");
        //    }

        //    if (transType == "HL")
        //    {
        //        MessageBox.Show("Nota dicetak dengan harga PRICELIST");
        //        _nOli = 2;
        //    }

        //    //if (_nCetak == 1)
        //    //    _ketNota = "CP";
        //    //else
        //    //    _ketNota = "RE";
        //    if (_nCetak == 9)
        //    {
        //        _ketNota = "RE";
        //    }
        //    else if (_nCetak == -1 || _nCetak == 0)
        //    {
        //        _ketNota = string.Empty;
        //    }
        //    else
        //    {
        //        _ketNota = "CP";
        //    }

        //    Guid rowID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
            


        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        DataTable dt = new DataTable();
        //        using (Database db = new Database())
        //        {                   
        //            db.Commands.Add(db.CreateCommand("rsp_CetakNotaPenjualanTax")); //udah cek heri
        //            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
        //            db.Commands[0].Parameters.Add(new Parameter("@oli", SqlDbType.Int, _nOli));
        //            dt = db.Commands[0].ExecuteDataTable();                    
        //        }

        //        CetakNotaTaxRaw(dt);
        //        IncreamentNPrint();
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

        //private void CetakNotaTaxRaw(DataTable dt)
        //{
        //    BuildString data = new BuildString();
        //    string typePrinter = data.GetPrinterName();//ISA.Trading.LookupInfo.GetValue("PRINTER", "DOT_MATRIX"); 
        //    string sNamaToko = dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString().Trim();
        //    string sToko = sNamaToko + data.SPACE(sNamaToko.Length + (15 - sNamaToko.Length) - 7);
        //    string sAlamat = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaAlamatKirim"].Value.ToString().Trim();
        //    string sDaerah = dataGridDO.SelectedCells[0].OwningRow.Cells["Daerah"].Value.ToString().Trim();
        //    string sKota = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaKota"].Value.ToString().Trim().PadRight(20)
        //        + " (" + dataGridDO.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString().Trim() + ")";
        //    string sTempo = dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString();


        //    data.Initialize();
        //    data.PageLLine(33);
        //    data.LeftMargin(1);
        //    data.BottomMargin(1);

        //    #region Header
        //    if (typePrinter.Contains("LX"))
        //    {
        //        data.LetterQuality(false);
        //        data.FontBold(true);
        //        data.FontCondensed(true); 
        //        data.DoubleHeight(true);
        //    }
        //    else
        //    {
        //        data.LetterQuality(true);
        //        data.FontBold(true);
        //        data.DoubleHeight(true);
        //        data.DoubleWidth(true);
        //    }
        //    data.PROW(true, 1, dt.Rows[0]["NamaPrs"].ToString().Trim());
        //    data.PROW(false, 47, "NOTA : " + dt.Rows[0]["NoSuratJalan"].ToString() + "   " + _ketNota);
        //    data.DoubleHeight(false);
        //    data.DoubleWidth(false);
        //    data.FontCPI(12);
        //    data.LineSpacing("1/8");
        //    data.FontCondensed(false);
        //    data.LetterQuality(false);
        //    data.FontCondensed(false);
        //    data.PROW(true, 1, "Alamat     : " + dt.Rows[0]["AlamatPrs"].ToString());
        //    data.FontItalic(true);
        //    data.PROW(false, 53, data.PrintTopLeftCorner() + data.PrintHorizontalLine(2) + " Pengiriman kepada Toko " + data.PrintHorizontalLine(14) + data.PrintTopRightCorner());
        //    data.FontItalic(false);
        //    data.PROW(true, 1, "NPWP/PKP   : " + dt.Rows[0]["NPWP"].ToString().PadRight(25));
        //    data.FontItalic(true);
        //    data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
        //    data.FontItalic(false);
        //    data.AddCR();
        //    data.PROW(false, 55, sToko);
        //    if (dt.Rows[0]["TglPKP"].ToString() == "")
        //    {
        //        data.PROW(true, 1, "TANGGAL PKP:  ");
        //    }
        //    else
        //    {
        //        data.PROW(true, 1, "TANGGAL PKP: " + ((DateTime)dt.Rows[0]["TglPKP"]).ToString("ddMMyyyy"));
        //    }
        //    //data.PROW(true, 1, "TANGGAL PKP: " + ((DateTime)dt.Rows[0]["TglPKP"]).ToString("ddMMyyyy"));
        //    data.FontItalic(true);
        //    data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
        //    data.FontItalic(false);
        //    data.FontCondensed(true);
        //    data.AddCR();
        //    data.PROW(false, 92, sAlamat.PadRight(60));
        //    data.FontCondensed(false);
        //    data.PROW(true, 1, "");
        //    data.FontItalic(true);
        //    data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
        //    data.FontItalic(false);
        //    data.AddCR();
        //    data.PROW(false, 55, sDaerah.PadRight(25));
        //    data.PROW(true, 1, "TANGGAL NOTA: " + ((DateTime)dt.Rows[0]["TglSuratJalan"]).ToString("dd-MMM-yyyy"));
        //    data.FontItalic(true);
        //    data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
        //    data.FontItalic(false);
        //    data.AddCR();
        //    data.PROW(false, 55, sKota);
        //    data.PROW(true, 1, "TEMPO       : " + sTempo + " (" + Tools.Terbilang(int.Parse(sTempo)) + ") ");
        //    data.FontItalic(true);
        //    data.PROW(false, 53, data.PrintBottomLeftCorner() + data.PrintHorizontalLine(40) + data.PrintBottomRightCorner());
        //    data.FontItalic(false);
        //    data.PROW(true, 1, "");
        //    data.FontCondensed(true);
        //    data.PROW(false, 2, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
        //    data.PROW(true, 1, "No.   N a m a   B a r a n g                                                             Q t y      Harga Satuan       Jumlah Harga");
        //    data.PROW(true, 1, data.PrintDoubleLine(134));
        //    #endregion

        //    #region Detail
        //    int nUrut = 0;
        //    string sNmBrg, sSatuan, sTemp;
        //    double nQty, nHrgSat, nHrgBruto;
        //    double nSumHrgBruto = 0, nSumDisc = 0, nSumPot = 0, nTotalHrg = 0;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        nUrut++;
        //        sNmBrg = dr["NamaBarang"].ToString();
        //        sSatuan = dr["Satuan"].ToString();
        //        nQty = int.Parse(dr["QtySuratJalan"].ToString());
        //        nHrgSat = double.Parse(dr["HrgJual"].ToString());
        //        nHrgBruto = nQty * nHrgSat;
        //        nSumDisc =+ double.Parse(dr["Disc"].ToString());
        //        nSumPot =+ double.Parse(dr["Pot"].ToString());
        //        nSumHrgBruto = nSumHrgBruto + nHrgBruto;
        //        nTotalHrg = nTotalHrg + (nHrgBruto - double.Parse(dr["Disc"].ToString()) - double.Parse(dr["Pot"].ToString()));

        //        sTemp = "  " + nUrut.ToString().PadLeft(2,'0') + ".   ";
        //        sTemp = sTemp + sNmBrg.Trim().PadRight(75, '.') + "   ";
        //        sTemp = sTemp + nQty.ToString("#,###").PadLeft(7) + "." + sSatuan + "  ";
        //        sTemp = sTemp + "Rp. " + nHrgSat.ToString("#,###").PadLeft(9);
        //        sTemp = sTemp + "     Rp. " + nHrgBruto.ToString("#,###").PadLeft(13);
        //        data.PROW(true, 1, sTemp);
        //        data.PROW(true, 1, "");
        //    }
        //    data.FontCondensed(true);
        //    data.AddCR();
        //    if (nUrut % 11 > 0)
        //    {
        //        data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
        //        for (int n = nUrut+1; n <= nUrut + (11 - (nUrut % 11)); n++)
        //        {
        //            data.PROW(true, 1, "  " + n.ToString().PadLeft(2, '0') + ".  ");
        //            data.PROW(true, 1, "");
        //        }
        //    }
        //    string sBayar = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan3"].Value.ToString();
        //    string sLain = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan4"].Value.ToString();
        //    data.PROW(true, 1, data.PrintDoubleLine(134));
        //    data.AddCR();
        //    data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
        //    data.PROW(true, 1, " HARGA SUDAH TERMASUK PPN 10 %" + data.SPACE(21) 
        //        + "                                                  Jumlah         Rp. " 
        //        + nSumHrgBruto.ToString("#,###").PadLeft(13));
        //    data.PROW(true, 1, data.SPACE(101) + "Disc:          Rp. " 
        //        + (nSumDisc>0 ? (nSumDisc).ToString("#,###").PadLeft(13) : (nSumPot).ToString("#,###").PadLeft(13)) );
        //    data.PROW(true, 1, "Pembayaran : " + sBayar);
        //    data.PROW(true, 1, "Catatan    : " + sLain);
        //    data.PROW(true, 1, data.SPACE(21) + "                                                                                Total          Rp. "
        //        + (nTotalHrg-nSumDisc-nSumPot).ToString("#,###").PadLeft(13));
        //    data.PROW(true, 1, "Bila nota ini belum terbayar sesuai waktu yang ditentukan, maka kami berhak menarik kembali barang-barang tersebut.");
        //    data.Eject();
        //    #endregion // end region detail

        //    data.SendToPrinter("notaJualTax.txt");
        //}

        //private void DisplayReportNotaTax(DataTable dt)
        //{
        //    //construct parameter            
        //    List<ReportParameter> rptParams = new List<ReportParameter>();
        //    rptParams.Add(new ReportParameter("HariKredit", dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString()));
        //    rptParams.Add(new ReportParameter("NamaToko", dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString()));
        //    rptParams.Add(new ReportParameter("AlamatToko", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaAlamatKirim"].Value.ToString()));
        //    rptParams.Add(new ReportParameter("Kota", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaKota"].Value.ToString()));
        //    rptParams.Add(new ReportParameter("Daerah", dataGridDO.SelectedCells[0].OwningRow.Cells["Daerah"].Value.ToString()));
        //    rptParams.Add(new ReportParameter("WilID", dataGridDO.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString()));
        //    rptParams.Add(new ReportParameter("KetNota", _ketNota));
        //    rptParams.Add(new ReportParameter("Catatan3", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan3"].Value.ToString()));
        //    rptParams.Add(new ReportParameter("Catatan4", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan4"].Value.ToString()));

        //    //call report viewer
        //    frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptCetakNotaJualTax.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
        //    ifrmReport.Show();
        //}

        private void dataGridDO_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridDO.Rows[e.RowIndex].Cells["RpACCPiutangAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDO.Rows[e.RowIndex].Cells["RpJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDO.Rows[e.RowIndex].Cells["RpPotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDO.Rows[e.RowIndex].Cells["RpNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Isi Acak
            double accpiutang = double.Parse(Tools.isNull(dataGridDO.Rows[e.RowIndex].Cells["RpACCPiutang"].Value, 0).ToString());
            double harga = double.Parse(Tools.isNull(dataGridDO.Rows[e.RowIndex].Cells["RpJual"].Value, 0).ToString());
            double rpPot = double.Parse(Tools.isNull(dataGridDO.Rows[e.RowIndex].Cells["RpPot"].Value, 0).ToString());
            double rpNet = double.Parse(Tools.isNull(dataGridDO.Rows[e.RowIndex].Cells["RpNet"].Value, 0).ToString());

            dataGridDO.Rows[e.RowIndex].Cells["RpACCPiutangAck"].Value = Tools.GetAntiNumeric(accpiutang.ToString("#,##0.00"));
            dataGridDO.Rows[e.RowIndex].Cells["RpJualAck"].Value = Tools.GetAntiNumeric(harga.ToString("#,##0.00"));
            dataGridDO.Rows[e.RowIndex].Cells["RpPotAck"].Value = Tools.GetAntiNumeric(rpPot.ToString("#,##0.00"));
            dataGridDO.Rows[e.RowIndex].Cells["RpNetAck"].Value = Tools.GetAntiNumeric(rpNet.ToString("#,##0.00"));

        }

        private void dataGridNotaJual_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Isi Acak
            double nota = double.Parse(Tools.isNull(dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpJual"].Value, 0).ToString());
            double rpPot = double.Parse(Tools.isNull(dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpPot"].Value, 0).ToString());
            double rpNet = double.Parse(Tools.isNull(dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpNet"].Value, 0).ToString());

            dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpJualAck"].Value = Tools.GetAntiNumeric(nota.ToString("#,##0.00"));
            dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpPotAck"].Value = Tools.GetAntiNumeric(rpPot.ToString("#,##0.00"));
            dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpNetAck"].Value = Tools.GetAntiNumeric(rpNet.ToString("#,##0.00"));

            dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpPotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void dataGridNotaJualDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Isi Acak
            double dethrg = double.Parse(Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHrgJual"].Value, 0).ToString());
            double detjuml = double.Parse(Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHrg"].Value, 0).ToString());
            double detpot = double.Parse(Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailPot"].Value, 0).ToString());
            double jmlpot = double.Parse(Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlPot"].Value, 0).ToString());
            double hrgnet = double.Parse(Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHrgNet"].Value, 0).ToString());
            double hpp = double.Parse(Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHPPSolo"].Value, 0).ToString());
            double jmlhpp = double.Parse(Tools.isNull(dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHPPSolo"].Value, 0).ToString());

            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHrgJualAck"].Value = Tools.GetAntiNumeric(dethrg.ToString("#,##0.00"));  //"#,##0.00"
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHrgAck"].Value = Tools.GetAntiNumeric(detjuml.ToString("#,##0.00"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailPotAck"].Value = Tools.GetAntiNumeric(detpot.ToString("#,##0.00"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlPotAck"].Value = Tools.GetAntiNumeric(jmlpot.ToString("#,##0.00"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHrgNetAck"].Value = Tools.GetAntiNumeric(hrgnet.ToString("#,##0.00"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHPPSoloAck"].Value = Tools.GetAntiNumeric(hpp.ToString("#,##0.00"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHPPSoloAck"].Value = Tools.GetAntiNumeric(jmlhpp.ToString("#,##0.00"));

            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHrgJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHrgAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailPotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlPotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHrgNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHPPSoloAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHPPSoloAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void AcakTampilHrg()
        {
            bool normal = true;
            dataGridDO.Columns["RpACCPiutang"].DefaultCellStyle.Format = "#,##0.00";
            dataGridDO.Columns["RpJual"].DefaultCellStyle.Format = "#,##0.00";
            dataGridDO.Columns["RpPot"].DefaultCellStyle.Format = "#,##0.00";
            dataGridDO.Columns["RpNet"].DefaultCellStyle.Format = "#,##0.00";

            dataGridNotaJual.Columns["NotaRpJual"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJual.Columns["NotaRpPot"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJual.Columns["NotaRpNet"].DefaultCellStyle.Format = "#,##0.00";

            dataGridNotaJualDetail.Columns["NotaDetailHrgJual"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailJmlHrg"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailPot"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailJmlPot"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailHrgNet"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailHPPSolo"].DefaultCellStyle.Format = "#,##0.00";
            dataGridNotaJualDetail.Columns["NotaDetailJmlHPPSolo"].DefaultCellStyle.Format = "#,##0.00";

            normal = !_acak;
            dataGridDO.Columns["RpACCPiutang"].Visible = _acak;
            dataGridDO.Columns["RpJual"].Visible = _acak;
            dataGridDO.Columns["RpPot"].Visible = _acak;
            dataGridDO.Columns["RpNet"].Visible = _acak;

            dataGridNotaJual.Columns["NotaRpJual"].Visible = _acak;
            dataGridNotaJual.Columns["NotaRpPot"].Visible = _acak;
            dataGridNotaJual.Columns["NotaRpNet"].Visible = _acak;

            dataGridNotaJualDetail.Columns["NotaDetailHrgJual"].Visible = _acak;
            dataGridNotaJualDetail.Columns["NotaDetailJmlHrg"].Visible = _acak;
            dataGridNotaJualDetail.Columns["NotaDetailPot"].Visible = _acak;
            dataGridNotaJualDetail.Columns["NotaDetailJmlPot"].Visible = _acak;
            dataGridNotaJualDetail.Columns["NotaDetailHrgNet"].Visible = _acak;
            dataGridNotaJualDetail.Columns["NotaDetailHPPSolo"].Visible = _acak;
            dataGridNotaJualDetail.Columns["NotaDetailJmlHPPSolo"].Visible = _acak;


            //acak
            dataGridDO.Columns["RpACCPiutangAck"].Visible = normal;
            dataGridDO.Columns["RpJualAck"].Visible = normal;
            dataGridDO.Columns["RpPotAck"].Visible = normal;
            dataGridDO.Columns["RpNetAck"].Visible = normal;

            dataGridNotaJual.Columns["NotaRpJualAck"].Visible = normal;
            dataGridNotaJual.Columns["NotaRpPotAck"].Visible = normal;
            dataGridNotaJual.Columns["NotaRpNetAck"].Visible = normal;

            dataGridNotaJualDetail.Columns["NotaDetailHrgJualAck"].Visible = normal;
            dataGridNotaJualDetail.Columns["NotaDetailJmlHrgAck"].Visible = normal;
            dataGridNotaJualDetail.Columns["NotaDetailPotAck"].Visible = normal;
            dataGridNotaJualDetail.Columns["NotaDetailJmlPotAck"].Visible = normal;
            dataGridNotaJualDetail.Columns["NotaDetailHrgNetAck"].Visible = normal;
            dataGridNotaJualDetail.Columns["NotaDetailHPPSoloAck"].Visible = normal;
            dataGridNotaJualDetail.Columns["NotaDetailJmlHPPSoloAck"].Visible = normal;
            _acak = normal;

            AcakTampilTextBox();
        }

        private void AcakTampilTextBox()
        {
            hrgdet = 0;
            netdet = 0;
            potdet = 0;
            hppdet = 0;
            hrgheader = 0;
            netheader = 0;
            potheader = 0;

            if (dataGridNotaJualDetail.DataSource != null)
            {
                if (dtNotaJualDetail.Compute("SUM(JmlHrg2)", string.Empty).ToString().Equals(string.Empty))
                {
                    hrgdet = 0;
                }
                else
                {
                    hrgdet = double.Parse(dtNotaJualDetail.Compute("SUM(JmlHrg2)", string.Empty).ToString());
                }

                if (dtNotaJualDetail.Compute("SUM(HrgNet2)", string.Empty).ToString().Equals(string.Empty))
                {
                    netdet = 0;
                }
                else
                {
                    netdet = double.Parse(dtNotaJualDetail.Compute("SUM(HrgNet2)", string.Empty).ToString());
                }

                if (dtNotaJualDetail.Compute("SUM(JmlPot2)", string.Empty).ToString().Equals(string.Empty))
                {
                    potdet = 0;
                }
                else
                {
                    potdet = double.Parse(dtNotaJualDetail.Compute("SUM(JmlPot2)", string.Empty).ToString());
                }

                if (dtNotaJualDetail.Compute("SUM(JmlHPPSolo)", string.Empty).ToString().Equals(string.Empty))
                {
                    hppdet = 0;
                }
                else
                {
                    hppdet = double.Parse(dtNotaJualDetail.Compute("SUM(JmlHPPSolo)", string.Empty).ToString());
                }

                if (dtNotaJual.Compute("SUM(RpJual2)", string.Empty).ToString().Equals(string.Empty))
                {
                    hrgheader = 0;
                }
                else
                {
                    hrgheader = double.Parse(dtNotaJual.Compute("SUM(RpJual2)", string.Empty).ToString());
                }

                if (dtNotaJual.Compute("SUM(RpNet2)", string.Empty).ToString().Equals(string.Empty))
                {
                    netheader = 0;
                }
                else
                {
                    netheader = double.Parse(dtNotaJual.Compute("SUM(RpNet2)", string.Empty).ToString());
                }

                if (dtNotaJual.Compute("SUM(RpPot2)", string.Empty).ToString().Equals(string.Empty))
                {
                    potheader = 0;
                }
                else
                {
                    potheader = double.Parse(dtNotaJual.Compute("SUM(RpPot2)", string.Empty).ToString());
                }
            }
            if (_acak)
            {
                txtJmlHrgDetail2.Text = Tools.GetAntiNumeric(hrgdet.ToString("#,##0.00"));
                txtJmlNettDetail2.Text = Tools.GetAntiNumeric(netdet.ToString("#,##0.00"));
                txtJmlPotDetail2.Text = Tools.GetAntiNumeric(potdet.ToString("#,##0.00"));
                txtJmlHPPDetail2.Text = Tools.GetAntiNumeric(hppdet.ToString("#,##0.00"));
                txtJmlHrgHeader2.Text = Tools.GetAntiNumeric(hrgheader.ToString("#,##0.00"));
                txtJmlNettHeader2.Text = Tools.GetAntiNumeric(netheader.ToString("#,##0.00"));
                txtJmlPotHeader2.Text = Tools.GetAntiNumeric(potheader.ToString("#,##0.00"));
            }
            else
            {
                txtJmlHrgDetail2.Text = hrgdet.ToString("#,##0.00");
                txtJmlNettDetail2.Text = netdet.ToString("#,##0.00");
                txtJmlPotDetail2.Text = potdet.ToString("#,##0.00");
                txtJmlHPPDetail2.Text = hppdet.ToString("#,##0.00");
                txtJmlHrgHeader2.Text = hrgheader.ToString("#,##0.00");
                txtJmlNettHeader2.Text = netheader.ToString("#,##0.00");
                txtJmlPotHeader2.Text = potheader.ToString("#,##0.00");
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

        public void FindHeaderDO(string columnName, string value)
        {
            dataGridDO.FindRow(columnName, value);
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridNotaJual.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridNotaJualDetail.FindRow(columnName, value);
        }

        private void IncreamentNPrint()
        {
            Guid notaRowId = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
            Guid doRowId = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["DORowID"].Value;
            string barcodeNota = Tools.isNull(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["Barcode"].Value, string.Empty).ToString();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_UPDATE_Print"));//udah cek heri
                db.Commands[0].Parameters.Add(new Parameter("@NotaRowID", SqlDbType.UniqueIdentifier, notaRowId));
                db.Commands[0].Parameters.Add(new Parameter("@DORowId", SqlDbType.UniqueIdentifier, doRowId));
                db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, barcodeNota));
                db.Commands[0].ExecuteDataTable();
            }

            int Nprint_ = 0;
            Nprint_ = (int)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaNPrint"].Value;
            Nprint_++;
            dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaNPrint"].Value = Nprint_.ToString();
            this.dataGridNotaJual.RefreshEdit();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dataGridNotaJualDetail.RowCount > 0 && selectedGrid == enumSelectedGrid.NotaJualDetailSelected)
            //    {
            //        if (GlobalVar.Gudang != "2803")
            //        {
            //            if ((int)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaNPrint"].Value > 0)
            //            {
            //                MessageBox.Show("Sudah Jadi Nota !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }
            //        }


            //        GlobalVar.LastClosingDate = (DateTime)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value;
            //        if ((DateTime)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value <= GlobalVar.LastClosingDate)
            //        {
            //            throw new Exception(String.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
            //        }
            //        string tglTerima = Tools.isNull(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglTerima"].Value, "").ToString();
            //        string Idlink = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaLinkID"].Value.ToString();
            //        if (tglTerima != "")
            //        {
            //            MessageBox.Show("Nota sudah diLink ke Piutang.");
            //            return;
            //        }
            //        Guid DORowID_ = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["DORowID"].Value;
            //        Guid NotaRowID_ = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
            //        Guid rowID_ = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;
            //        _headerID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;
            //        Penjualan.frmNotaJualDetailUpdate ifrmChild2 = new Penjualan.frmNotaJualDetailUpdate(this, _headerID, DORowID_, NotaRowID_);
            //        ifrmChild2.MdiParent = Program.MainForm;
            //        Program.MainForm.RegisterChild(ifrmChild2);
            //        ifrmChild2.Show();

            //    }
            //}
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}
        }

        private void dataGridNotaJual_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedGrid = enumSelectedGrid.NotaJualHeaderSelected;
        }

        private void dataGridDO_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedGrid = enumSelectedGrid.DOSelected;
        }

        private void dataGridNotaJualDetail_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedGrid = enumSelectedGrid.NotaJualDetailSelected;
        }

        private void frmNotaJualBrowser_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    cmdDelete.PerformClick();
                    break;
            }
        }

        private void dataGridDO_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridDO.SelectedCells.Count > 0)
            {
                RefreshDataNotaJual();
                lblToko.Text = "\"" + dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + "\" "
                    + dataGridDO.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString();

            }
            else
            {
                dataGridNotaJual.DataSource = null;
                lblToko.Text = " ";
            }
        }

        private void dataGridNotaJual_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridNotaJual.SelectedCells.Count > 0)
            {

                RefreshDataNotaJualDetail();
            }
            else
            {
                dataGridNotaJualDetail.DataSource = null;
            }
        }

        private void dataGridNotaJualDetail_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridNotaJualDetail.SelectedCells.Count > 0)
            {
                lblBarang.Text = dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
            }
            else
            {
                lblBarang.Text = " ";
            }
        }


        //private void GenuineTrans()
        //{
        //    _isOk = true;
        //    string trtype_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value, "").ToString();
        //    if (trtype_ == "KG")
        //    {
        //        if (GlobalVar.Gudang != "2823")
        //        {
        //            string kdtoko_ = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value, "").ToString();
        //            double overdueFX = TokoOverdue.OverdueFX(kdtoko_);

        //            GetFlagKg(kdtoko_);
        //            if (flagkg == "KG")
        //            {
        //                if (overdueFX > 0)
        //                {
        //                    MessageBox.Show("Masih ada Nota FX yang sudah jatuh tempo dan belum terbayar");
        //                    _isOk = false;
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Pengambilan barang Genuine harus menggunakan Transaksi Tunai");
        //                _isOk = false;
        //            }
        //        }
        //    }
        //}


        //private void GetFlagKg(string kodetoko)
        //{
        //    try
        //    {
        //        using (Database db = new Database())
        //        {
        //            DataTable dt = new DataTable();
        //            db.Commands.Add(db.CreateCommand("usp_Toko_SEARCH"));
        //            db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodetoko));
        //            dt = db.Commands[0].ExecuteDataTable();
        //            flagkg = Tools.isNull(dt.Rows[0]["RefSupervisor"], "").ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Error.LogError(ex);
        //    }
        //}

        private void dataGridDO_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
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
                    dataGridDO.Rows[rowIndex].Cells["NoDO"].Style.ForeColor = Color.Black;
                }

                if (dataGridDO.Rows[rowIndex].Cells["NoACCPiutang"].Value.ToString() == "OVDFB"
                    || dataGridDO.Rows[rowIndex].Cells["NoACCPiutang"].Value.ToString() == "OVDFX"
                    || dataGridDO.Rows[rowIndex].Cells["NoACCPiutang"].Value.ToString() == "BONUSAN"
                    )
                {
                    dataGridDO.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (dataGridDO.Rows[rowIndex].Cells["StatusBatal"].ToString().Contains("BATAL"))
                {
                    dataGridDO.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (Tools.isNull(dataGridDO.Rows[rowIndex].Cells[CekSO.Name].Value, "").ToString() != "0")
                {
                    dataGridDO.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Plum;
                }


                //dataGridDO.Rows[rowIndex].Cells["RpJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dataGridDO.Rows[rowIndex].Cells["RpPotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dataGridDO.Rows[rowIndex].Cells["RpNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dataGridDO.Rows[rowIndex].Cells["RpNet3Ack"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                ////Isi Acak
                //double harga = double.Parse(dataGridDO.Rows[rowIndex].Cells["RpJual"].Value.ToString());
                //double rpPot = double.Parse(Tools.isNull(dataGridDO.Rows[rowIndex].Cells["RpPot"].Value, 0).ToString());
                //double rpNet = double.Parse(Tools.isNull(dataGridDO.Rows[rowIndex].Cells["RpNet"].Value, 0).ToString());
                //double rpNet3 = double.Parse(Tools.isNull(dataGridDO.Rows[rowIndex].Cells["RpNet3"].Value, 0).ToString());

                //if (rpNet3 < rpNet)
                //{
                //    dataGridDO.Rows[rowIndex].Cells["NoDO"].Style.BackColor = Color.Yellow;
                //    dataGridDO.Rows[rowIndex].Cells["RpNet3"].Style.BackColor = Color.Yellow;
                //    dataGridDO.Rows[rowIndex].Cells["RpNet3Ack"].Style.BackColor = Color.Yellow;
                //}

                //if (string.IsNullOrEmpty(dataGridDO.Rows[rowIndex].Cells["NoACCPiutang"].Value.ToString()))
                //{
                //    dataGridDO.Rows[rowIndex].Cells["NoDO"].Style.BackColor = Color.Yellow;
                //}
                //if (Tools.isNull(dataGridDO.Rows[rowIndex].Cells[CekSO.Name].Value, "").ToString() != "0")
                //{
                //    dataGridDO.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Plum;
                //}

                //dataGridDO.Rows[rowIndex].Cells["RpJualAck"].Value = Tools.GetAntiNumeric(harga.ToString("#,##0"));
                //dataGridDO.Rows[rowIndex].Cells["RpPotAck"].Value = Tools.GetAntiNumeric(rpPot.ToString("#,##0"));
                //dataGridDO.Rows[rowIndex].Cells["RpNetAck"].Value = Tools.GetAntiNumeric(rpNet.ToString("#,##0"));
                //dataGridDO.Rows[rowIndex].Cells["RpNet3Ack"].Value = Tools.GetAntiNumeric(rpNet3.ToString("#,##0"));
            }

        }

        //private void GeneratePengajuanCetakUlangNota(DateTime Tglnota, Guid RowIDNota)
        //{
        //    try
        //    {
        //        DataTable dtp;
        //        using (Database db = new Database())
        //        {
        //            db.Commands.Add(db.CreateCommand("rsp_Pengajuan_CetakUlangNota"));
        //            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDNota));
        //            dtp = db.Commands[0].ExecuteDataTable();
        //        }
        //        if (dtp.Rows.Count > 0)
        //        {
        //            PengajuanCetakUlangNota(Tglnota, dtp);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Error.LogError(ex);
        //    }
        //}

        //private void PengajuanCetakUlangNota(DateTime Tglnota, DataTable dt)
        //{
        //    try
        //    {
        //        List<ExcelPackage> exs = new List<ExcelPackage>();
        //        exs.Add(AjuanCetakUlangNota(Tglnota, dt));

        //        SaveFileDialog sf = new SaveFileDialog();
        //        sf.InitialDirectory = "C:\\Temp\\";
        //        sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
        //        sf.FileName = "Pengajuan_PinCetakUlangNotaPenjualan";

        //        sf.OverwritePrompt = true;
        //        if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
        //        {
        //            string file = sf.FileName.ToString();
        //            Byte[] bin1 = exs[0].GetAsByteArray();
        //            File.WriteAllBytes(file, bin1);
        //            MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
        //            Process.Start(sf.FileName.ToString());
        //        }
        //    }

        //    catch (System.Exception ex)
        //    {
        //        Error.LogError(ex);
        //    }
        //}


        //private ExcelPackage AjuanCetakUlangNota(DateTime Tglnota, DataTable dt)
        //{
        //    ExcelPackage ex = new ExcelPackage();
        //    ex.Workbook.Properties.Author = "PS";
        //    ex.Workbook.Properties.Title = "Pengajuan Pin Cetak Ulang Nota Jual.";
        //    ex.Workbook.Properties.SetCustomPropertyValue("Ajuan Pin", "1147");

        //    ex.Workbook.Worksheets.Add("Ajuan Pin");
        //    ExcelWorksheet ws = ex.Workbook.Worksheets[1];
        //    ws.View.ShowGridLines = false;
        //    ws.Cells.Style.Font.Size = 9;

        //    int nRow = 0, nHeader = 1, Rowx = 0;
        //    ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
        //    ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
        //    ws.Cells[1, 3].Worksheet.Column(3).Width = 8;       //nonota
        //    ws.Cells[1, 4].Worksheet.Column(4).Width = 11;      //tglnota
        //    ws.Cells[1, 5].Worksheet.Column(5).Width = 11;      //kodesales
        //    ws.Cells[1, 6].Worksheet.Column(6).Width = 31;      //namatoko
        //    ws.Cells[1, 7].Worksheet.Column(7).Width = 20;      //kota
        //    ws.Cells[1, 8].Worksheet.Column(8).Width = 8;       //idwil
        //    ws.Cells[1, 9].Worksheet.Column(9).Width = 5;       //tr
        //    ws.Cells[1, 10].Worksheet.Column(10).Width = 12;    //rpnota
        //    ws.Cells[1, 11].Worksheet.Column(11).Width = 35;    //key
        //    ws.Cells[1, 12].Worksheet.Column(12).Width = 30;    //keterangan
        //    ws.Cells[1, 13].Worksheet.Column(13).Width = 30;    //pin

        //    ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
        //    ws.Cells[nHeader, 2].Value = "Pengajuan Pin Cetak Ulang Nota.";
        //    ws.Cells[nHeader, 2].Style.Font.Size = 14;
        //    ws.Cells[nHeader, 2].Style.Font.Bold = true;
        //    ws.Cells[nHeader + 1, 2].Value = "Periode : " + string.Format("{0:dd-MMM-yyyy}", Tglnota);
        //    ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
        //    ws.Cells[nHeader + 3, 2].Value = "Depo " + GlobalVar.Gudang;
        //    ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
        //    //ws.Cells[nHeader + 2, 2].Style.Font.Italic = true;

        //    nRow = nHeader + 3;
        //    Rowx = nRow;
        //    int MaxCol = 13;

        //    for (int i = 2; i <= MaxCol; i++)
        //    {
        //        ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
        //    }
        //    ws.Cells[Rowx, 2].Value = " No ";
        //    ws.Cells[Rowx, 3].Value = " No Nota ";
        //    ws.Cells[Rowx, 4].Value = " Tgl Nota ";
        //    ws.Cells[Rowx, 5].Value = " Kode Sales ";
        //    ws.Cells[Rowx, 6].Value = " Nama Toko ";
        //    ws.Cells[Rowx, 7].Value = " Kota ";
        //    ws.Cells[Rowx, 8].Value = " Idwil ";
        //    ws.Cells[Rowx, 9].Value = " TR ";
        //    ws.Cells[Rowx, 10].Value = " Rp Nota ";
        //    ws.Cells[Rowx, 11].Value = " Public Key ";
        //    ws.Cells[Rowx, 12].Value = " Keterangan ";
        //    ws.Cells[Rowx, 13].Value = " Pin ";

        //    ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //    ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

        //    ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //    ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

        //    Rowx += 2;
        //    int no = 0;
        //    double Jumlah = 0;

        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr1 in dt.Rows)
        //        {
        //            no += 1;
        //            ws.Cells[Rowx, 2].Value = no.ToString();
        //            ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
        //            ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NoSuratJalan"], "").ToString();
        //            ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", Tglnota);
        //            ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["KodeSales"], "").ToString();
        //            ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["NamaToko"], "").ToString();
        //            ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["Kota"], "").ToString();
        //            ws.Cells[Rowx, 8].Value = Tools.isNull(dr1["WilID"], "").ToString();
        //            ws.Cells[Rowx, 9].Value = Tools.isNull(dr1["TransactionType"], "").ToString();
        //            ws.Cells[Rowx, 10].Value = Tools.isNull(dr1["RpNet2"], "0").ToString();
        //            ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);";
        //            ws.Cells[Rowx, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
        //            ws.Cells[Rowx, 11].Value = Tools.GetKey(dr1["RowID"].ToString(), GlobalVar.Gudang, PinId.Bagian.CetakUlangNota);
        //            ws.Cells[Rowx, 12].Value = "";
        //            ws.Cells[Rowx, 13].Value = "";
        //            Rowx++;
        //        }
        //    }
        //    Rowx++;

        //    var border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
        //    border.Bottom.Style =
        //    border.Top.Style = ExcelBorderStyle.None;
        //    border.Left.Style =
        //    border.Right.Style = ExcelBorderStyle.Thin;

        //    border = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
        //    border.Bottom.Style = ExcelBorderStyle.Thin;
        //    border.Top.Style = ExcelBorderStyle.None;
        //    border.Left.Style =
        //    border.Right.Style = ExcelBorderStyle.Thin;

        //    border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
        //    border.Bottom.Style =
        //    border.Top.Style =
        //    border.Left.Style =
        //    border.Right.Style = ExcelBorderStyle.Thin;

        //    Rowx += 2;
        //    ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
        //    ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
        //    ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;

        //    return ex;

        //}


        private void CetakNotaTaxRaw(DataTable dt)
        {
            BuildString data = new BuildString();
            string typePrinter = data.GetPrinterName();//ISA.Trading.LookupInfo.GetValue("PRINTER", "DOT_MATRIX"); 
            string sNamaToko = dt.Rows[0]["NamaToko"].ToString().Trim();
            string sToko = sNamaToko;// +data.SPACE(sNamaToko.Length + (15 - sNamaToko.Length) - 7);
            string sAlamat = dt.Rows[0]["Alamat"].ToString().Trim();
            string sDaerah = dt.Rows[0]["Daerah"].ToString().Trim();
            string sKota = dt.Rows[0]["Kota"].ToString().Trim().PadRight(20)
                + " (" + dt.Rows[0]["WilID"].ToString().Trim() + ")";
            string sPramuniaga = dt.Rows[0]["KodeSales"].ToString().Trim();

            //string sTempo = dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString();


            data.Initialize();
            data.PageLLine(33);
            data.LeftMargin(1);
            data.BottomMargin(1);

            #region Header
            if (typePrinter.Contains("LX"))
            {
                data.LetterQuality(false);
                data.FontBold(true);
                data.FontCondensed(true);
                data.DoubleHeight(true);
            }
            else
            {
                data.LetterQuality(true);
                data.FontBold(true);
                data.DoubleHeight(true);
                data.DoubleWidth(true);
            }
            data.PROW(true, 1, dt.Rows[0]["NamaPrs"].ToString().Trim());
            data.PROW(false, 47, "NOTA : " + dt.Rows[0]["NoSuratJalan"].ToString() + "   " + _ketNota);
            data.DoubleHeight(false);
            data.DoubleWidth(false);
            data.FontCPI(12);
            data.LineSpacing("1/8");
            data.FontCondensed(false);
            data.LetterQuality(false);
            data.FontCondensed(false);
            data.PROW(true, 1, dt.Rows[0]["AlamatPrs"].ToString());
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintTopLeftCorner() + data.PrintHorizontalLine(2) + " Pengiriman kepada Toko " + data.PrintHorizontalLine(14) + data.PrintTopRightCorner());
            data.FontItalic(false);

            data.PROW(true, 1, "                                       ");
            data.PROW(false, 51, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.PROW(true, 1, "NPWP/PKP    : " + dt.Rows[0]["NPWP"].ToString().PadRight(25));
            
            //data.FontItalic(true);
            data.PROW(false, 51, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();

            data.DoubleHeight(true);
            data.PROW(false, 58, sToko);
            data.DoubleHeight(false);

            if (dt.Rows[0]["TglPKP"].ToString() == "")
            {
                data.PROW(true, 1, "TANGGAL PKP :  ");
            }
            else
            {
                data.PROW(true, 1, "TANGGAL PKP : " + ((DateTime)dt.Rows[0]["TglPKP"]).ToString("ddMMyyyy"));
            }
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.FontCondensed(true);
            data.AddCR();
            data.PROW(false, 92, sAlamat.PadRight(60));
            data.FontCondensed(false);
            data.PROW(true, 1, "");
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(false, 55, sDaerah.PadRight(25));
            data.PROW(true, 1, "TANGGAL NOTA: " + ((DateTime)dt.Rows[0]["TglSuratJalan"]).ToString("dd-MMM-yyyy"));
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(false, 55, sKota);
            data.PROW(true, 1, "Pramuniaga  : " + sPramuniaga + " ");
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(true, 1, "Penjualan   : " + "Tunai");
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintBottomLeftCorner() + data.PrintHorizontalLine(40) + data.PrintBottomRightCorner());
            data.FontItalic(false);
            data.PROW(true, 1, "");
            data.FontCondensed(true);

            data.PROW(false, 2, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            /*                  12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890*/
            /*                           1         2         3         4         5         6         7         8         9         10        11        12        13        14*/
            data.PROW(true, 1, "No.   N a m a   B a r a n g                     Part Number             Q t y    Harga Sat     Disc(%)   Pot          Jumlah Harga");
            data.PROW(true, 1, data.PrintDoubleLine(134));
            #endregion

            #region Detail
            int nUrut = 0;
            string sNmBrg, sSatuan, sTemp, subNamaBarang, sPartNumber;
            double nQty = 0, nHrgSat = 0, nHrgBruto = 0, ndisc1 = 0, ndisc2 = 0, ndisc3 = 0;
            double nSumHrgBruto = 0, nSumDisc = 0, nSumPot = 0, nTotalHrg = 0, nPot = 0, nSumHrgNetto = 0, nPotongan = 0;
            foreach (DataRow dr in dt.Rows)
            {
                nUrut++;
                sNmBrg = dr["NamaBarang"].ToString();
                int panjanghuruf = sNmBrg.Length;
                if (panjanghuruf >= 40)
                    subNamaBarang = sNmBrg.Substring(0, 40);
                else
                    subNamaBarang = sNmBrg;
                //string subNamaBarang = sNmBrg.Substring(Math.Max(0, sNmBrg.Length - 30));

                if (dr["PartNo"].ToString().Trim().Length > 20)
                    sPartNumber = dr["PartNo"].ToString().Substring(0, 20);
                else
                    sPartNumber = dr["PartNo"].ToString();

                sSatuan = dr["Satuan"].ToString();
                nQty = int.Parse(Tools.isNull(dr["QtySuratJalan"], "0").ToString());
                nHrgSat = double.Parse(Tools.isNull(dr["HrgJual"], "0").ToString());
                nHrgBruto = nQty * nHrgSat;
                ndisc1 = double.Parse(Tools.isNull(dr["Disc1"], "0").ToString());
                nSumDisc = double.Parse(Tools.isNull(dr["Disc"], "0").ToString());
                nPot = double.Parse(Tools.isNull(dr["Pot"], "0").ToString());
                nSumPot = double.Parse(Tools.isNull(dr["Potongan"], "0").ToString());
                nSumHrgBruto = nSumHrgBruto + nHrgBruto;
                nSumHrgNetto = nHrgBruto - nSumDisc - nSumPot;
                nTotalHrg = nTotalHrg + (nHrgBruto - nSumDisc - nSumPot);

                if (subNamaBarang.ToString().Trim() != "")
                    sTemp = (nUrut < 10 ? "0" + nUrut.ToString() : nUrut.ToString()) + ".";
                else
                    sTemp = " ";

                sTemp = sTemp + subNamaBarang.PadRight(40, '.') + "  ";
                sTemp = sTemp + sPartNumber.PadRight(20, ' ') + " ";
                sTemp = sTemp + nQty.ToString("#,###").PadLeft(3, ' ') + "." + sSatuan.PadRight(3, ' ') + "  ";
                sTemp = sTemp + "Rp." + nHrgSat.ToString("#,###").PadLeft(9, ' ');
                sTemp = sTemp + ndisc1.ToString("#,###").PadLeft(8, ' ');
                sTemp = sTemp + "Rp." + nSumPot.ToString("#,###").PadLeft(8, ' ');
                sTemp = sTemp + "Rp." + nSumHrgNetto.ToString("#,###").PadLeft(10) + " ";
                data.PROW(true, 1, sTemp);
            }
            data.FontCondensed(true);
            data.AddCR();
            if (nUrut % 20 > 0)
            {
                data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
                for (int n = nUrut + 1; n <= nUrut + (20 - (nUrut % 20)); n++)
                {
                    data.PROW(true, 1, (n < 10 ? "0" : "") + n.ToString() + ".   ");
                }
            }
            //string sBayar = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan3"].Value.ToString();
            //string sLain = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan4"].Value.ToString();
            data.PROW(true, 1, data.PrintDoubleLine(134));
            data.AddCR();
            data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            data.PROW(true, 1, "* HARGA SUDAH TERMASUK PPN 10 %" + data.SPACE(21)
                + "                                                  Jumlah         Rp. "
                + nTotalHrg.ToString("#,###").PadLeft(13));
            //+ nSumHrgBruto.ToString("#,###").PadLeft(13));
            data.PROW(true, 1, "* Barang yang sudah dibeli tidak boleh ditukar/dikembalikan.");
            data.Eject();
            #endregion // end region detail

            data.SendToFile("notaJualTax.txt");
            //data.SendToPrinter("notaJualTax.txt",printer);  //buat pilih printer
        }

        private void btnPullWDC_Click(object sender, EventArgs e)
        {
            Penjualan.frmNotaPenjualanSynch frm = new Penjualan.frmNotaPenjualanSynch();
            frm.ShowDialog();
            //if (frm.Result == DialogResult.OK) RefreshDataBO();
        }

        private void dataGridNotaJual_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = e.RowIndex; i < e.RowIndex+e.RowCount; i++)
            {
                Color color;
                if (dataGridNotaJual.Rows[i].Cells["NoSuratJalan"].Value.ToString() == "" &&
                    dataGridNotaJual.Rows[i].Cells["TglSuratJalan"].Value.ToString() == "")
                {
                    color = Color.FromArgb(255,186,186);
                }
                else if (dataGridNotaJual.Rows[i].Cells["TglTerima"].Value.ToString() == "")
                {
                    color = Color.FromArgb(255, 241, 168);
                }
                else 
                {
                    continue;
                }
                foreach(DataGridViewColumn dc in dataGridNotaJual.Columns)
                {
                    dataGridNotaJual.Rows[i].Cells[dc.Index].Style.BackColor = color;
                }
            }
        }
    }
}
