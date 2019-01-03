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
using System.IO;
using ISA.Toko.Class;
using System.Management;

namespace ISA.Toko.Penjualan
{
    public partial class frmNotaJualBrowser : ISA.Toko.BaseForm
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
        string initCab = GlobalVar.CabangID;
        string cCab1 = "";
        public frmNotaJualBrowser()
        {
            InitializeComponent();
        }

        private void frmNotaJualBrowse_Load(object sender, EventArgs e)
        {
            this.Title = "Nota Jual";
            //this.Text = "Penjualan (Nota)";
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
            this.WindowState = FormWindowState.Maximized;
            AcakTampilHrg();

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
                    db.Commands.Add(db.CreateCommand("[usp_OrderPenjualan_LIST_FILTER_TglDO]")); // udah dicek
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

        public void RefreshRowDataNotaJual(string _rowID)
        {
            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_DOID"));// sudah dicek
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

        public void RefreshDataNotaJualDetail()
        {
            try
            {
                Guid _headerID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;

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
            cmdPrint.Enabled = false;
        }

        private void dataGridNotaJual_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.NotaJualHeaderSelected;
            cmdPrint.Enabled = true;
        }

        private void dataGridNotaJualDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.NotaJualDetailSelected;
            cmdPrint.Enabled = false;
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
           

            if (selectedGrid == enumSelectedGrid.NotaJualHeaderSelected)
            {
                if (dataGridDO.SelectedCells.Count == 0)
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                    return;
                }
                Guid _doID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["DORowID"].Value;
                cCab1 = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang1"].Value, "").ToString();
                string nodo = "";
                double _jmlHrgNota = 0;
                if (!_acak)
                {
                    _jmlHrgNota = double.Parse(txtJmlHrgHeader2.Text);
                }
                else
                {
                    if (dtNotaJual.Compute("SUM(RpJual2)", string.Empty).ToString().Trim() != string.Empty)
                    {
                        _jmlHrgNota = double.Parse(dtNotaJual.Compute("SUM(RpNet2)", string.Empty).ToString());
                    }
                }
                if (Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["TotJadiDo"].Value,0)) == Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells["RpNet"].Value,0))) 
                {
                    MessageBox.Show("Tidak bisa tambah data lagi. Semua DO sudah jadi Nota.");
                    return;
                }

                double _rpACCPiutang = 0;
                if (dataGridDO.SelectedCells[0].OwningRow.Cells["RpACCPiutang"].Value.ToString() != "")
                    _rpACCPiutang = double.Parse(dataGridDO.SelectedCells[0].OwningRow.Cells["RpACCPiutang"].Value.ToString());
                double _rpSisaACCPiutang = _rpACCPiutang - _jmlHrgNota;

                string NODO = dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString();
                string KdToko = dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                string tipetrans = dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value.ToString();

                Penjualan.frmNotaJualUpdate ifrmChild = new Penjualan.frmNotaJualUpdate(this, _doID, _jmlHrgNota, KdToko, tipetrans, _rpACCPiutang, NODO);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
        }


        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridNotaJual.SelectedCells.Count == 0)
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                    return;
                }
                GlobalVar.LastClosingDate = (DateTime)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value;

                Guid _RowID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
                DataTable Dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_DOID"));
                    db.Commands[0].Parameters.Add(new Parameter("@NotaID", SqlDbType.UniqueIdentifier, _RowID));
                    Dt = db.Commands[0].ExecuteDataTable();
                }
                DateTime? TglTerima = null;
                DateTime TglSuratJalan = new DateTime();
                if (dtNotaJual.Rows.Count > 0)
                {
                    if ( !Dt.Rows[0]["TglTerima"].ToString().Equals("")) TglTerima = Convert.ToDateTime(Dt.Rows[0]["TglTerima"].ToString());
                    TglSuratJalan = Convert.ToDateTime(Dt.Rows[0]["TglSuratJalan"]);
                }
                if (TglSuratJalan <= GlobalVar.LastClosingDate)
                {
                    KotakPesan.Warning(String.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, TglSuratJalan.ToString("dd-MM-yyyy")));
                    return;
                    
                }
                if (selectedGrid == enumSelectedGrid.NotaJualHeaderSelected)
                {
                        
                    /*CASE cUserLevel = 'ADMINISTRATOR'
                      MESSAGEBOX('Anda tidak punya wewenang hapus Nota',48,'Perhatian')*/
                    if (!TglTerima.ToString().Equals(""))
                    {
                        KotakPesan.Warning("Tidak bisa hapus record. Nota Jual sudah diterima Toko.");
                        return;
                        
                    } else
                    {
                        if (!SecurityManager.AskPasswordManager()) 
                        {
                            return;
                        }
                    }

                    if ((DateTime)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value != GlobalVar.DateOfServer)
                    {
                        if (MessageBox.Show("Tidak bisa hapus record. Tanggal Nota Jual tidak sama dengan tanggal server.. \nAnda Membutuhkan kewenangan manager Untuk melanjutkan Proses", "Cek Tenggal Nota", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (!SecurityManager.AskPasswordManager()) 
                            {
                                return;
                            }
                        }
                        else { return; }
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
                //else if ((selectedGrid == enumSelectedGrid.NotaJualDetailSelected) && dataGridNotaJualDetail.RowCount > 0)
                //{

                //    if ((int)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaNPrint"].Value > 0)
                //    {
                //        MessageBox.Show("Sudah JAdi Nota !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;

                //    }
                //    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //    {
                //        Guid rowID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;

                //        Guid doRowID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["DORowID"].Value;
                //        Guid NotaID = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailHeaderID"].Value;
                        
                //            this.Cursor = Cursors.WaitCursor;
                //            using (Database db = new Database())
                //            {
                //                db.Commands.Add(db.CreateCommand("usp_NotaPenjualandetail_DELETE_2")); //udah cek heri
                //                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                //                db.Commands[0].ExecuteNonQuery();

                //            }

                           

                //            int i = 0;
                //            int n = 0;
                //            i = dataGridNotaJualDetail.SelectedCells[0].RowIndex;
                //            n = dataGridNotaJualDetail.SelectedCells[0].ColumnIndex;
                //            DataRowView dv = (DataRowView)dataGridNotaJualDetail.SelectedCells[0].OwningRow.DataBoundItem;
                //            DataRow drr = dv.Row;
                //            drr.Delete();
                //            dtNotaJualDetail.AcceptChanges();
                //            dataGridNotaJualDetail.Focus();
                //            if (dataGridNotaJualDetail.RowCount > 0)
                //            {
                //                if (i == 0)
                //                {
                //                    dataGridNotaJualDetail.CurrentCell = dataGridNotaJualDetail.Rows[0].Cells[n];
                //                    dataGridNotaJualDetail.RefreshEdit();
                //                }
                //                else
                //                {
                //                    dataGridNotaJualDetail.CurrentCell = dataGridNotaJualDetail.Rows[i - 1].Cells[n];
                //                    dataGridNotaJualDetail.RefreshEdit();
                //                }

                //            }

                            
                //            //this.RefreshDataDO();
                //            RefreshRowDataNota(NotaID.ToString());
                //            RefreshRowDataDO(doRowID.ToString());
                           
                //            MessageBox.Show("Record telah dihapus");
                //          //  
                //DataNotaJualDetail();
                        
                       
                //    }
                //}
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
            }
        }

        private void dataGridNotaJual_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
               case Keys.F3:
                    int NotaNPrint = int.Parse(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaNPrint"].Value.ToString());
                    /* F3 untuk mecetak nota (Cetak per satu nota Header yang terpilih) */

                    //if (NotaNPrint >= 3)
                    //{
                    //    MessageBox.Show("Sudah cetak 3 kali, tidak bisa cetak ulang", "Informasi");
                    //    break;
                    //}

                    if (SecurityManager.IsManager() || SecurityManager.IsAdministrator() || SecurityManager.HasRight("TRD.CETAK_NOTA"))
                    {
                        if (NotaNPrint >= 1)
                        {
                            if (SecurityManager.AskPasswordSpv())
                            {
                                CekCetakNota();
                            }
                        }
                        else
                        {
                            CekCetakNota();
                        }
                    }
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
                for (i = 0; i < dtNotaJual.Rows.Count ; i++)
                {
                    sw.Write(dtNotaJual.Rows[i]["NoNota"] + System.Environment.NewLine);
                }
                sw.WriteLine();
                sw.Close();
                MessageBox.Show("List Nomor nota sudah disimpan ke file NOMORNOTA.TXT");
            }
            catch(Exception ex)
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
            if (initCab != c2)
            {
                MessageBox.Show("Cabang 2 nota yang dicetak harus sama dengan Init Cabang");
                return;
            }

            //if (int.Parse(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaNPrint"].Value.ToString()) >0 && !SecurityManager.IsManager() )
            //{
            //    if (!SecurityManager.AskPasswordManager())
            //    {
            //        return;
            //    }
            //}
            _nCetak = int.Parse(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaNPrint"].Value.ToString());
            
                String AppSet = AppSetting.GetValue("DokumenDO");
                if (AppSet == "1" || AppSet == "2" || AppSet == "3")
                {
                    _nCetak = Convert.ToInt32(AppSet == "" ? "0" : AppSet);
                }
                else { MessageBox.Show("Setting Dokumen DO belum dilakukan dengan benar. Mohon perbaiki nilai di APPSetting."); return; }

                
            
            string jnstransaksi = dtNotaJual.Rows[0]["TunaiKredit"].ToString();
            //if (jnstransaksi == "T")
            //{
            //    CetakNotapos();
            //}
            
            //else
            //{
                #region Nota lama
                //if (CekPTToko() && c1.Substring(0, 1) == "9")
                //    CetakNotaTax();
                //else
                //    CetakNota();
                #endregion
                #region nota baru
                    CetakNota();
                
                #endregion

            //}

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

                if (_nCetak == 3 || _nCetak == 4 || _nCetak == 6)
                {
                    //buat memilih printer 
                    //printerName = "INKJET";
                    //printer = Convert.ToString(CekAppSetting(printerName));

                    DisplayReportNotaJual(dt, "rptCetakNotaJualBaru");
                    DisplayReportNotaJual(dt, "rptCetakNotaJualCopy1");
                    DisplayReportNotaJual(dt, "rptCetakNotaJualCopy2");

                }
                else
                {
                    //printerName = "DOTMATRIX";
                    //printer = Convert.ToString(CekAppSetting(printerName));
                    //GetPrinter(printerName);
                    CetakNotaposRaw(dt);
                }
                //CetakNotaposRaw(dt);
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
            data.SendToPrinter("notaJualTax.txt");
            //buat pilih printer
            //data.SendToPrinter("notaJualTax.txt",printer);
        }




        private void CetakNota()
        {
            string transType = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TransactionTypeNota"].Value.ToString();
            
            if (transType == "KB") 
            {
                MessageBox.Show("Nota dicetak dengan harga PRICELIST");
            }

            if (transType == "HL")
            {
                MessageBox.Show("Nota dicetak dengan harga PRICELIST");
                _nOli = 2;
            }
   
            if (_nCetak == 2 || _nCetak ==4)
            {
                _ketNota = "RE";
            }
            else if (_nCetak == 5 || _nCetak == 6)
            {
                _ketNota = string.Empty;
            }
            else if (_nCetak == 1 || _nCetak ==3)
            {
                _ketNota = "CP";
            }



            Guid rowID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;

            if (GlobalVar.Gudang != "2803")
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST_FILTER_HeaderID"));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }


                    //if (_nCetak == 3 || _nCetak == 4 || _nCetak == 6)
                    //{
                        //buat pilih printer
                        //printerName = "INKJET";
                        //printer = Convert.ToString(CekAppSetting(printerName));
                    int JumlahRangkap =Convert.ToInt16(AppSetting.GetValue("DokumenNotaJual"));
                    if (JumlahRangkap >= 4 || JumlahRangkap <= 0) { KotakPesan.Warning("Setting Dokumen DO belum dilakukan dengan benar. Mohon perbaiki nilai di APPSetting.", "Peringatan AppSetting"); return; }
                    if (JumlahRangkap >= 1) DisplayReportNotaJual(dt, "rptCetakNotaJual");
                    if (JumlahRangkap >= 2) DisplayReportNotaJual(dt, "rptCetakNotaJualCopy1");
                    if (JumlahRangkap >= 3) DisplayReportNotaJual(dt, "rptCetakNotaJualCopy2");

                        //DisplayReportNotaJual(dt, "rptCetakNotaJualCopy1");
                        //DisplayReportNotaJual(dt, "rptCetakNotaJualCopy2");
                    //}
                    //else
                    //{
                    //    //buat pilih printer
                    //    //printerName = "DOTMATRIX";
                    //    //printer = Convert.ToString(CekAppSetting(printerName));

                    //    CetakNotaRaw(dt);
                    //}

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
                        //buat pilih printer
                        //printerName = "INKJET";
                        //printer = Convert.ToString(CekAppSetting(printerName));

                        //DisplayReportNotaJual(dt, "rptCetakNotaJualBaru_unLogo");
                        //DisplayReportNotaJual(dt, "rptCetakNotaJualCopy1_unLogo");
                        //DisplayReportNotaJual(dt, "rptCetakNotaJualCopy2_unLogo");
                        DisplayReportNotaJual(dt, "rptNotaCetak");
                    }
                    else
                    {
                        //buat pilih printer
                        //printerName = "DOTMATRIX";
                        //printer = Convert.ToString(CekAppSetting(printerName));

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



        public void DisplayReportNotaJual(DataTable dt, String ReportName)
        {
            string sExpedisi = dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString();
            double Total = 0;
            double TotalDisc = 0;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    int QtySJ = Convert.ToInt32(dr["QtySuratJalan"]);
            //    Double HrgJual = Convert.ToDouble(dr["HrgJual"]);

            //    Double Disc = Convert.ToInt32(dr["Disc"]);
            //    Double Pot = Convert.ToInt32(dr["Pot"]);

            //    TotalDisc = TotalDisc + ((Disc * QtySJ) + (Pot * QtySJ));

            //    if (GlobalVar.Gudang == "2803")
            //    {
            //        Double x = QtySJ * HrgJual;
            //        Decimal dcash = Convert.ToDecimal(Tools.isNull(dr["Disc1"], "0").ToString());
            //        Decimal dcash2= Convert.ToDecimal(Tools.isNull(dr["Disc2"], "0").ToString()); 
            //        Double y = x - Convert.ToDouble(Math.Round(((dcash / 100) * Convert.ToDecimal(x)),0));
            //        Double z = y - Convert.ToDouble(Math.Round(((dcash2 / 100) * Convert.ToDecimal(y)), 0));
            //        Total = Total + Convert.ToDouble(z);
            //    }
            //    else
            //    {
            //        Total = Total + (QtySJ * HrgJual);
            //    }
            //}

            Double TotalAkumulasi = Total - TotalDisc;

            if (dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString() != "SAS")
            {
                sExpedisi = string.Empty;
            }
            DateTime tglSJ = Convert.ToDateTime(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value.ToString());
            String tglSJFix = tglSJ.ToString("dd-MMM-yyyy");
            String tglSJBarcode = tglSJ.ToString("dd-MM-yyyy");
            string barcodeNota =(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NoSuratJalan"].Value.ToString() + tglSJ.ToString("yyy").Substring(1,3) + tglSJ.ToString("MM"));

            dataGridNotaJual.SelectedCells[0].OwningRow.Cells["Barcode"].Value = barcodeNota;

            string jnstransaksi = dtNotaJual.Rows[0]["TunaiKredit"].ToString();
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("NomorDO", dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString()));
            rptParams.Add(new ReportParameter("HariKredit", dataGridDO.SelectedCells[0].OwningRow.Cells["tempo"].Value.ToString()));
            rptParams.Add(new ReportParameter("Sales", dataGridDO.SelectedCells[0].OwningRow.Cells["NamaSales"].Value.ToString()));
            rptParams.Add(new ReportParameter("Expedisi", dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString()));
            rptParams.Add(new ReportParameter("NamaToko", dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString()));
            rptParams.Add(new ReportParameter("Alamat", dataGridDO.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString()));
            rptParams.Add(new ReportParameter("Daerah", dataGridDO.SelectedCells[0].OwningRow.Cells["Daerah"].Value.ToString().Trim()));
            rptParams.Add(new ReportParameter("Kota", dataGridDO.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString().Trim()));
            rptParams.Add(new ReportParameter("Catatan4", "XXX"));
            rptParams.Add(new ReportParameter("NoSuratJalan", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NoSuratJalan"].Value.ToString()));
            rptParams.Add(new ReportParameter("TglSuratJalan", tglSJFix));
            rptParams.Add(new ReportParameter("Total", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRpNet"].Value.ToString()));
                //rptParams.Add(new ReportParameter("Catatan", ));
                //rptParams.Add(new ReportParameter("footer", ));
            rptParams.Add(new ReportParameter("NamaPerusahaan", GlobalVar.PerusahaanName));
            rptParams.Add(new ReportParameter("AlamatPerusahaan", GlobalVar.PerusahaanAddress));
            rptParams.Add(new ReportParameter("KotaPerusahaan", GlobalVar.PerusahaanKota));
            rptParams.Add(new ReportParameter("TelpPerusahaan", GlobalVar.PerusahaanTelp));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("TglProses", "(" + GlobalVar.DateTimeOfServer.ToString("dd MMM yyyy HH:mm:ss") + ")"));    
                //if (jnstransaksi == "T")
                //{
                //    frmReportViewer ifrmReport = new frmReportViewer("POS." + ReportName + ".rdlc", rptParams, dt, "dsNotaPenjualan_NotaJual");
                //    ifrmReport.Print();
                //    //ifrmReport.Show();
                //}
                //else
                //{
                    frmReportViewer ifrmReport = new frmReportViewer("Penjualan." + ReportName + ".rdlc", rptParams, dt, "dsNotaPenjualan_NotaJual");
                    ifrmReport.Print();
                    //ifrmReport.Show();
                //}
                
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
            header.FontItalic(true);
            header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(false);
            header.AddCR();
            header.PROW(false, 55, sToko);
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
            header.PROW(true, 1, "No.   N a m a   B a r a n g                                             Q t y    Harga Sat     Disc      Pot          Jumlah Harga");
            header.PROW(true, 1, header.PrintDoubleLine(134));
            #endregion // end region header

            return header.GenerateString();
        }

        private void CetakNotaRaw(DataTable dt)
        {

            BuildString detail = new BuildString();
            detail.Append(CetakHeaderNota(dt));

            #region Cetak Detail
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

                sSatuan = dr["Satuan"].ToString();
                nQty = int.Parse(dr["QtySuratJalan"].ToString());
                nHrgSat = double.Parse(dr["HrgJual"].ToString());
                nHrgBruto = nQty * nHrgSat;
                nSumDisc += double.Parse(dr["Disc"].ToString());
                nSumPot += double.Parse(dr["Pot"].ToString());
                nSumHrgBruto = nSumHrgBruto + nHrgBruto;
                nTotalHrg = nTotalHrg + (nHrgBruto - double.Parse(dr["Disc"].ToString()));

                sTemp = (nUrut < 10 ? "0" + nUrut.ToString() : nUrut.ToString()) + ".";
                sTemp = sTemp + subNamaBarang.PadRight(65, '.') + " ";
                sTemp = sTemp + nQty.ToString("#,###").PadLeft(3,' ') + "." +sSatuan.PadRight(3,' ') + "  ";
                sTemp = sTemp + "Rp." + nHrgSat.ToString("#,###").PadLeft(9,' ');
                sTemp = sTemp + nSumDisc.ToString("#,###").PadLeft(8,' ')+"     ";
                sTemp = sTemp + "Rp." + nSumPot.ToString("#,###").PadLeft(8,' ');
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


            detail.SendToPrinter("notaJual.txt");
            //detail.SendToPrinter("notaJual.txt", printer);// tambah inputan printer buat mengambil default printer sesuai yang dipilih pada radio button
        }

       
        private string GetSales()
        {
            string konfersi = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int c1 = int.Parse(dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang1"].Value.ToString())%26;
            int c2 = int.Parse(dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang2"].Value.ToString())%26;
            string namaSales = dataGridDO.SelectedCells[0].OwningRow.Cells["NamaSales"].Value.ToString();
            if (c1 == 0)
                c1 = 26;
            if (c2 == 0)
                c2 = 26;
            string result = konfersi.Substring(c1-1, 1) + "\\" + konfersi.Substring(c2-1, 1)
                            + "\\" + namaSales;

            return result;
        }

        private void CetakNotaTax()
        {
            // Cetak nota dengan Toko yang kode 'Cabang2' nya 'PT'
            string transType = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TransactionTypeNota"].Value.ToString();

            if (transType == "KB")
            {
                MessageBox.Show("Nota dicetak dengan harga PRICELIST");
            }

            if (transType == "HL")
            {
                MessageBox.Show("Nota dicetak dengan harga PRICELIST");
                _nOli = 2;
            }

            //if (_nCetak == 1)
            //    _ketNota = "CP";
            //else
            //    _ketNota = "RE";
            if (_nCetak == 9)
            {
                _ketNota = "RE";
            }
            else if (_nCetak == -1 || _nCetak == 0)
            {
                _ketNota = string.Empty;
            }
            else
            {
                _ketNota = "CP";
            }

            Guid rowID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
            


            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {                   
                    db.Commands.Add(db.CreateCommand("rsp_CetakNotaPenjualanTax")); //udah cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@oli", SqlDbType.Int, _nOli));
                    dt = db.Commands[0].ExecuteDataTable();                    
                }

                CetakNotaTaxRaw(dt);
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

        private void CetakNotaTaxRaw(DataTable dt)
        {
            BuildString data = new BuildString();
            string typePrinter = data.GetPrinterName();//ISA.Trading.LookupInfo.GetValue("PRINTER", "DOT_MATRIX"); 
            string sNamaToko = dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString().Trim();
            string sToko = sNamaToko + data.SPACE(sNamaToko.Length + (15 - sNamaToko.Length) - 7);
            string sAlamat = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaAlamatKirim"].Value.ToString().Trim();
            string sDaerah = dataGridDO.SelectedCells[0].OwningRow.Cells["Daerah"].Value.ToString().Trim();
            string sKota = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaKota"].Value.ToString().Trim().PadRight(20)
                + " (" + dataGridDO.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString().Trim() + ")";
            string sTempo = dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString();


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
            data.PROW(true, 1, "Alamat     : " + dt.Rows[0]["AlamatPrs"].ToString());
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintTopLeftCorner() + data.PrintHorizontalLine(2) + " Pengiriman kepada Toko " + data.PrintHorizontalLine(14) + data.PrintTopRightCorner());
            data.FontItalic(false);
            data.PROW(true, 1, "NPWP/PKP   : " + dt.Rows[0]["NPWP"].ToString().PadRight(25));
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            data.FontItalic(false);
            data.AddCR();
            data.PROW(false, 55, sToko);
            if (dt.Rows[0]["TglPKP"].ToString() == "")
            {
                data.PROW(true, 1, "TANGGAL PKP:  ");
            }
            else
            {
                data.PROW(true, 1, "TANGGAL PKP: " + ((DateTime)dt.Rows[0]["TglPKP"]).ToString("ddMMyyyy"));
            }
            //data.PROW(true, 1, "TANGGAL PKP: " + ((DateTime)dt.Rows[0]["TglPKP"]).ToString("ddMMyyyy"));
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
            data.PROW(true, 1, "TEMPO       : " + sTempo + " (" + Tools.Terbilang(int.Parse(sTempo)) + ") ");
            data.FontItalic(true);
            data.PROW(false, 53, data.PrintBottomLeftCorner() + data.PrintHorizontalLine(40) + data.PrintBottomRightCorner());
            data.FontItalic(false);
            data.PROW(true, 1, "");
            data.FontCondensed(true);
            data.PROW(false, 2, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            data.PROW(true, 1, "No.   N a m a   B a r a n g                                                             Q t y      Harga Satuan       Jumlah Harga");
            data.PROW(true, 1, data.PrintDoubleLine(134));
            #endregion

            #region Detail
            int nUrut = 0;
            string sNmBrg, sSatuan, sTemp;
            double nQty, nHrgSat, nHrgBruto;
            double nSumHrgBruto = 0, nSumDisc = 0, nSumPot = 0, nTotalHrg = 0;
            foreach (DataRow dr in dt.Rows)
            {
                nUrut++;
                sNmBrg = dr["NamaBarang"].ToString();
                sSatuan = dr["Satuan"].ToString();
                nQty = int.Parse(dr["QtySuratJalan"].ToString());
                nHrgSat = double.Parse(dr["HrgJual"].ToString());
                nHrgBruto = nQty * nHrgSat;
                nSumDisc =+ double.Parse(dr["Disc"].ToString());
                nSumPot =+ double.Parse(dr["Pot"].ToString());
                nSumHrgBruto = nSumHrgBruto + nHrgBruto;
                nTotalHrg = nTotalHrg + (nHrgBruto - double.Parse(dr["Disc"].ToString()) - double.Parse(dr["Pot"].ToString()));

                sTemp = "  " + nUrut.ToString().PadLeft(2,'0') + ".   ";
                sTemp = sTemp + sNmBrg.Trim().PadRight(75, '.') + "   ";
                sTemp = sTemp + nQty.ToString("#,###").PadLeft(7) + "." + sSatuan + "  ";
                sTemp = sTemp + "Rp. " + nHrgSat.ToString("#,###").PadLeft(9);
                sTemp = sTemp + "     Rp. " + nHrgBruto.ToString("#,###").PadLeft(13);
                data.PROW(true, 1, sTemp);
                data.PROW(true, 1, "");
            }
            data.FontCondensed(true);
            data.AddCR();
            if (nUrut % 11 > 0)
            {
                data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
                for (int n = nUrut+1; n <= nUrut + (11 - (nUrut % 11)); n++)
                {
                    data.PROW(true, 1, "  " + n.ToString().PadLeft(2, '0') + ".  ");
                    data.PROW(true, 1, "");
                }
            }
            string sBayar = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan3"].Value.ToString();
            string sLain = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan4"].Value.ToString();
            data.PROW(true, 1, data.PrintDoubleLine(134));
            data.AddCR();
            data.PROW(false, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            data.PROW(true, 1, " HARGA SUDAH TERMASUK PPN 10 %" + data.SPACE(21) 
                + "                                                  Jumlah         Rp. " 
                + nSumHrgBruto.ToString("#,###").PadLeft(13));
            data.PROW(true, 1, data.SPACE(101) + "Disc:          Rp. " 
                + (nSumDisc>0 ? (nSumDisc).ToString("#,###").PadLeft(13) : (nSumPot).ToString("#,###").PadLeft(13)) );
            data.PROW(true, 1, "Pembayaran : " + sBayar);
            data.PROW(true, 1, "Catatan    : " + sLain);
            data.PROW(true, 1, data.SPACE(21) + "                                                                                Total          Rp. "
                + (nTotalHrg-nSumDisc-nSumPot).ToString("#,###").PadLeft(13));
            data.PROW(true, 1, "Bila nota ini belum terbayar sesuai waktu yang ditentukan, maka kami berhak menarik kembali barang-barang tersebut.");
            data.Eject();
            #endregion // end region detail

            data.SendToPrinter("notaJualTax.txt");
        }

        private void DisplayReportNotaTax(DataTable dt)
        {
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("HariKredit", dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString()));
            rptParams.Add(new ReportParameter("NamaToko", dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString()));
            rptParams.Add(new ReportParameter("AlamatToko", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaAlamatKirim"].Value.ToString()));
            rptParams.Add(new ReportParameter("Kota", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaKota"].Value.ToString()));
            rptParams.Add(new ReportParameter("Daerah", dataGridDO.SelectedCells[0].OwningRow.Cells["Daerah"].Value.ToString()));
            rptParams.Add(new ReportParameter("WilID", dataGridDO.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString()));
            rptParams.Add(new ReportParameter("KetNota", _ketNota));
            rptParams.Add(new ReportParameter("Catatan3", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan3"].Value.ToString()));
            rptParams.Add(new ReportParameter("Catatan4", dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaCatatan4"].Value.ToString()));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptCetakNotaJualTax.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }

        private void dataGridDO_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridDO.Rows[e.RowIndex].Cells["RpACCPiutangAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDO.Rows[e.RowIndex].Cells["RpJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDO.Rows[e.RowIndex].Cells["RpPotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDO.Rows[e.RowIndex].Cells["RpNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDO.Rows[e.RowIndex].Cells["TotJadiDo"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            //Isi Acak
            double accpiutang = double.Parse(Tools.isNull(dataGridDO.Rows[e.RowIndex].Cells["RpACCPiutang"].Value, 0).ToString());
            double harga = double.Parse(Tools.isNull(dataGridDO.Rows[e.RowIndex].Cells["RpJual"].Value, 0).ToString());
            double rpPot = double.Parse(Tools.isNull(dataGridDO.Rows[e.RowIndex].Cells["RpPot"].Value, 0).ToString());
            double rpNet = double.Parse(Tools.isNull(dataGridDO.Rows[e.RowIndex].Cells["RpNet"].Value, 0).ToString());

            dataGridDO.Rows[e.RowIndex].Cells["RpACCPiutangAck"].Value = Tools.GetAntiNumeric(accpiutang.ToString("#,##0"));
            dataGridDO.Rows[e.RowIndex].Cells["RpJualAck"].Value = Tools.GetAntiNumeric(harga.ToString("#,##0"));
            dataGridDO.Rows[e.RowIndex].Cells["RpPotAck"].Value = Tools.GetAntiNumeric(rpPot.ToString("#,##0"));
            dataGridDO.Rows[e.RowIndex].Cells["RpNetAck"].Value = Tools.GetAntiNumeric(rpNet.ToString("#,##0"));
            if (dataGridDO.Rows[e.RowIndex].Cells["NPrint"].Value.ToString().Contains("0")) { dataGridDO.Rows[e.RowIndex].Cells["NPrint"].Style.BackColor = Color.DarkGray; }
            //dataGridDO.Rows[e.RowIndex].Cells["RpACCPiutangAck"].Value =accpiutang.ToString("#,##0");
            //dataGridDO.Rows[e.RowIndex].Cells["RpJualAck"].Value = harga.ToString("#,##0");
            //dataGridDO.Rows[e.RowIndex].Cells["RpPotAck"].Value = rpPot.ToString("#,##0");
            //dataGridDO.Rows[e.RowIndex].Cells["RpNetAck"].Value = rpNet.ToString("#,##0");

            if (Convert.ToDouble(Tools.isNull(dataGridDO.Rows[e.RowIndex].Cells["TotJadiDo"].Value, 0)) != Convert.ToDouble(Tools.isNull(dataGridDO.Rows[e.RowIndex].Cells["RpNet"].Value, 0)))
            {
                dataGridDO.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
            
        }

        private void dataGridNotaJual_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Isi Acak
            double nota = double.Parse(Tools.isNull(dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpJual"].Value, 0).ToString());
            double rpPot = double.Parse(Tools.isNull(dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpPot"].Value, 0).ToString());
            double rpNet = double.Parse(Tools.isNull(dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpNet"].Value, 0).ToString());

            dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpJualAck"].Value = Tools.GetAntiNumeric(nota.ToString("#,##0"));
            dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpPotAck"].Value = Tools.GetAntiNumeric(rpPot.ToString("#,##0"));
            dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpNetAck"].Value = Tools.GetAntiNumeric(rpNet.ToString("#,##0"));


            //dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpJualAck"].Value = nota.ToString("#,##0");
            //dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpPotAck"].Value = rpPot.ToString("#,##0");
            //dataGridNotaJual.Rows[e.RowIndex].Cells["NotaRpNetAck"].Value = rpNet.ToString("#,##0");

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

            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHrgJualAck"].Value = Tools.GetAntiNumeric(dethrg.ToString("#,##0"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHrgAck"].Value = Tools.GetAntiNumeric(detjuml.ToString("#,##0"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailPotAck"].Value = Tools.GetAntiNumeric(detpot.ToString("#,##0"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlPotAck"].Value = Tools.GetAntiNumeric(jmlpot.ToString("#,##0"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHrgNetAck"].Value = Tools.GetAntiNumeric(hrgnet.ToString("#,##0"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHPPSoloAck"].Value = Tools.GetAntiNumeric(hpp.ToString("#,##0"));
            dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHPPSoloAck"].Value = Tools.GetAntiNumeric(jmlhpp.ToString("#,##0"));

            //dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHrgJualAck"].Value =dethrg.ToString("#,##0");
            //dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHrgAck"].Value = detjuml.ToString("#,##0");
            //dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailPotAck"].Value = detpot.ToString("#,##0");
            //dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlPotAck"].Value = jmlpot.ToString("#,##0");
            //dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHrgNetAck"].Value = hrgnet.ToString("#,##0");
            //dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailHPPSoloAck"].Value = hpp.ToString("#,##0");
            //dataGridNotaJualDetail.Rows[e.RowIndex].Cells["NotaDetailJmlHPPSoloAck"].Value = jmlhpp.ToString("#,##0");
            
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
            //dataGridDO.Columns["RpACCPiutang"].DefaultCellStyle.Format = "#,##0";
            //dataGridDO.Columns["RpJual"].DefaultCellStyle.Format = "#,##0";
            //dataGridDO.Columns["RpPot"].DefaultCellStyle.Format = "#,##0";
            dataGridDO.Columns["RpNet"].DefaultCellStyle.Format = "#,##0";

           // dataGridNotaJual.Columns["NotaRpJual"].DefaultCellStyle.Format = "#,##0";
            //dataGridNotaJual.Columns["NotaRpPot"].DefaultCellStyle.Format = "#,##0";
            dataGridNotaJual.Columns["NotaRpNet"].DefaultCellStyle.Format = "#,##0";

            dataGridNotaJualDetail.Columns["NotaDetailHrgJual"].DefaultCellStyle.Format = "#,##0";
            dataGridNotaJualDetail.Columns["NotaDetailJmlHrg"].DefaultCellStyle.Format = "#,##0";
            dataGridNotaJualDetail.Columns["NotaDetailPot"].DefaultCellStyle.Format = "#,##0";
            dataGridNotaJualDetail.Columns["NotaDetailJmlPot"].DefaultCellStyle.Format = "#,##0";
            dataGridNotaJualDetail.Columns["NotaDetailHrgNet"].DefaultCellStyle.Format = "#,##0";
            dataGridNotaJualDetail.Columns["NotaDetailHPPSolo"].DefaultCellStyle.Format = "#,##0";
            dataGridNotaJualDetail.Columns["NotaDetailJmlHPPSolo"].DefaultCellStyle.Format = "#,##0";

            normal = !_acak;
            //dataGridDO.Columns["RpACCPiutang"].Visible = _acak;
            //dataGridDO.Columns["RpJual"].Visible = _acak;
            //dataGridDO.Columns["RpPot"].Visible = _acak;
            dataGridDO.Columns["RpNet"].Visible = _acak;

            //dataGridNotaJual.Columns["NotaRpJual"].Visible = _acak;
            //dataGridNotaJual.Columns["NotaRpPot"].Visible = _acak;
            dataGridNotaJual.Columns["NotaRpNet"].Visible = _acak;

            //dataGridNotaJualDetail.Columns["NotaDetailHrgJual"].Visible = _acak;
            //dataGridNotaJualDetail.Columns["NotaDetailJmlHrg"].Visible = _acak;
            //dataGridNotaJualDetail.Columns["NotaDetailPot"].Visible = _acak;
            //dataGridNotaJualDetail.Columns["NotaDetailJmlPot"].Visible = _acak;
            dataGridNotaJualDetail.Columns["NotaDetailHrgNet"].Visible = _acak;
            //dataGridNotaJualDetail.Columns["NotaDetailHPPSolo"].Visible = _acak;
            //dataGridNotaJualDetail.Columns["NotaDetailJmlHPPSolo"].Visible = _acak;


            //acak
            //dataGridDO.Columns["RpACCPiutangAck"].Visible = normal;
            //dataGridDO.Columns["RpJualAck"].Visible = normal;
            //dataGridDO.Columns["RpPotAck"].Visible = normal;
            dataGridDO.Columns["RpNetAck"].Visible = normal;

            //dataGridNotaJual.Columns["NotaRpJualAck"].Visible = normal;
           // dataGridNotaJual.Columns["NotaRpPotAck"].Visible = normal;
            dataGridNotaJual.Columns["NotaRpNetAck"].Visible = normal;

            //dataGridNotaJualDetail.Columns["NotaDetailHrgJualAck"].Visible = normal;
            //dataGridNotaJualDetail.Columns["NotaDetailJmlHrgAck"].Visible = normal;
            //dataGridNotaJualDetail.Columns["NotaDetailPotAck"].Visible = normal;
            //dataGridNotaJualDetail.Columns["NotaDetailJmlPotAck"].Visible = normal;
            dataGridNotaJualDetail.Columns["NotaDetailHrgNetAck"].Visible = normal;
            //dataGridNotaJualDetail.Columns["NotaDetailHPPSoloAck"].Visible = normal;
            //dataGridNotaJualDetail.Columns["NotaDetailJmlHPPSoloAck"].Visible = normal;
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
                txtJmlHrgDetail2.Text = Tools.GetAntiNumeric(hrgdet.ToString("#,##0"));
                txtJmlNettDetail2.Text = Tools.GetAntiNumeric(netdet.ToString("#,##0"));
                txtJmlPotDetail2.Text = Tools.GetAntiNumeric(potdet.ToString("#,##0"));
                txtJmlHPPDetail2.Text = Tools.GetAntiNumeric(hppdet.ToString("#,##0"));
                txtJmlHrgHeader2.Text = Tools.GetAntiNumeric(hrgheader.ToString("#,##0"));
                txtJmlNettHeader2.Text = Tools.GetAntiNumeric(netheader.ToString("#,##0"));
                txtJmlPotHeader2.Text = Tools.GetAntiNumeric(potheader.ToString("#,##0"));
            }
            else
            {
                txtJmlHrgDetail2.Text = hrgdet.ToString("#,##0");
                txtJmlNettDetail2.Text = netdet.ToString("#,##0");
                txtJmlPotDetail2.Text = potdet.ToString("#,##0");
                txtJmlHPPDetail2.Text = hppdet.ToString("#,##0");
                txtJmlHrgHeader2.Text = hrgheader.ToString("#,##0");
                txtJmlNettHeader2.Text = netheader.ToString("#,##0");
                txtJmlPotHeader2.Text = potheader.ToString("#,##0");
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
            try
            {
                if (dataGridNotaJualDetail.RowCount > 0 && selectedGrid == enumSelectedGrid.NotaJualDetailSelected)
                {
                    if ((int)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaNPrint"].Value > 0)
                    {
                        MessageBox.Show("Sudah Jadi Nota !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    GlobalVar.LastClosingDate = (DateTime)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value;
                    if ((DateTime)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value <= GlobalVar.LastClosingDate)
                    {
                        throw new Exception(String.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    }
                    Guid rowID_ = (Guid)dataGridNotaJualDetail.SelectedCells[0].OwningRow.Cells["NotaDetailRowID"].Value;
                    Penjualan.frmNotaJualDetailUpdate ifrmChild2 = new Penjualan.frmNotaJualDetailUpdate(this, rowID_);
                    ifrmChild2.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild2);
                    ifrmChild2.Show();

                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
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

        private void dataGridNotaJualDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            int NotaNPrint = int.Parse(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaNPrint"].Value.ToString());
            /* F3 untuk mecetak nota (Cetak per satu nota Header yang terpilih) */

            //if (NotaNPrint >= 3)
            //{
            //    MessageBox.Show("Sudah cetak 3 kali, tidak bisa cetak ulang", "Informasi");
            //    break;
            //}

            if (SecurityManager.IsManager() || SecurityManager.IsAdministrator() || SecurityManager.HasRight("TRD.CETAK_NOTA"))
            {
                Guid rowID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
                if (NotaNPrint >= 1)
                {
                    if (SecurityManager.AskPasswordManager())
                    {
                        //CekCetakNota();
                        cetakNota(rowID);
                    }
                }
                else
                {
                    //CekCetakNota();
                    cetakNota(rowID);
                }
            }
        }

        private void dataGridNotaJual_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridNotaJual_Leave(object sender, EventArgs e)
        {
            
        }

        private void dataGridNotaJual_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        public void cetakNota(Guid _RowID)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST_FILTER_HeaderID"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                //if (_nCetak == 3 || _nCetak == 4 || _nCetak == 6)
                //{
                //buat pilih printer
                //printerName = "INKJET";
                //printer = Convert.ToString(CekAppSetting(printerName));
                int JumlahRangkap = Convert.ToInt16(AppSetting.GetValue("DokumenNotaJual"));
                if (JumlahRangkap >= 4 || JumlahRangkap <= 0) { KotakPesan.Warning("Setting Dokumen DO belum dilakukan dengan benar. Mohon perbaiki nilai di APPSetting.", "Peringatan AppSetting"); return; }
                else DisplayReportNotaJual(dt, "rptCetakNotaJual");
                //if (JumlahRangkap >= 1) DisplayReportNotaJual(dt, "rptCetakNotaJual");
                //if (JumlahRangkap >= 2) DisplayReportNotaJual(dt, "rptCetakNotaJualCopy1");
                //if (JumlahRangkap >= 3) DisplayReportNotaJual(dt, "rptCetakNotaJualCopy2");

                //DisplayReportNotaJual(dt, "rptCetakNotaJualCopy1");
                //DisplayReportNotaJual(dt, "rptCetakNotaJualCopy2");
                //}
                //else
                //{
                //    //buat pilih printer
                //    //printerName = "DOTMATRIX";
                //    //printer = Convert.ToString(CekAppSetting(printerName));

                //    CetakNotaRaw(dt);
                //}

                //IncreamentNPrint();
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
}
