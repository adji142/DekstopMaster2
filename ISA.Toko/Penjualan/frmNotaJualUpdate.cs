using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;
using ISA.Toko.Class;

namespace ISA.Toko.Penjualan
{
    public partial class frmNotaJualUpdate : ISA.Toko.BaseForm
    {
        Guid _doID;
        Guid _notaHeaderRowID;
        string _doHtrID, _transType, _kodeToko;
        string  _Cat1 = string.Empty, _Cat2 = string.Empty, _Cat3 = string.Empty, 
                _Cat4 = string.Empty, _Cat5 = string.Empty, _CatD = string.Empty;
        double _rpSisaACCPiutang, _jmlHrgNota, _rpACCPiutang;
        int _hariKredit;
        string _NoDo = "";
        DataTable dt, dtDO;

        public frmNotaJualUpdate(Form caller, Guid doID, double jmlHrgNota, string KdToko, string TK, double _rpACCPiutang)
            /*, string doHtrID, double rpACCPiutang, string transType, int hariKredit)*/
        {
            InitializeComponent();
            _doID = doID;
            _jmlHrgNota = jmlHrgNota;
            _kodeToko = KdToko;
            _transType = TK;
            this.Caller = caller;
        }

        public frmNotaJualUpdate(Form caller, Guid doID, double jmlHrgNota, string KdToko, string TK, double _rpACCPiutang, string NoDo)
        /*, string doHtrID, double rpACCPiutang, string transType, int hariKredit)*/
        {
            InitializeComponent();
            _doID = doID;
            _jmlHrgNota = jmlHrgNota;
            _kodeToko = KdToko;
            _transType = TK;
            this.Caller = caller;
            _NoDo = NoDo;
        }

        public void RefreshDataNota()
        {
            dataGridDetailDO.AutoGenerateColumns = false;
            dataGridDetailDO.GenerateRowNumber = true;
            //dataGridDetailDO.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                //retrieving data
                dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataView dv = new DataView();
                    DataTable dtt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST_FILTER_HEADERID_2"));//udah cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _doID));
                    dt = db.Commands[0].ExecuteDataTable();
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST_FILTER_RowID"));//udah cek heri
                    db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _doID));
                    dtDO = db.Commands[1].ExecuteDataTable();

                    dataGridDetailDO.DataSource = dt;
                }

                DataColumn cJmlHrg = new DataColumn("TotalHrg", Type.GetType("System.Double"));
                cJmlHrg.Expression = "QtySisa * HrgJual";
                dt.Columns.Add(cJmlHrg);

                _doHtrID = Tools.isNull(dtDO.Rows[0]["HtrID"], "").ToString();
                _rpACCPiutang = double.Parse(Tools.isNull(dtDO.Rows[0]["RpACCPiutang"], "0.0").ToString());
                _rpSisaACCPiutang = _rpACCPiutang - _jmlHrgNota;
                _transType = Tools.isNull(dtDO.Rows[0]["TransactionType"], "").ToString();
                _hariKredit = int.Parse(Tools.isNull(dtDO.Rows[0]["HariKredit"], "0").ToString());
                _Cat1 = dtDO.Rows[0]["Catatan1"].ToString();
                _Cat2 = dtDO.Rows[0]["Catatan2"].ToString();
                _Cat3 = dtDO.Rows[0]["Catatan3"].ToString();
                _Cat4 = dtDO.Rows[0]["Catatan4"].ToString();
                _Cat5 = dtDO.Rows[0]["Catatan5"].ToString();
                _kodeToko = Tools.isNull(dtDO.Rows[0]["KodeToko"], "").ToString();

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

        private void frmNotaJualUpdate_Load(object sender, EventArgs e)
        {
            RefreshDataNota();
            txtPlafon.Text = string.Format("{0:N0}", 0);
            TtxtSO.Text = string.Format("{0:N0}", 0);
            txtSisa.Text = string.Format("{0:N0}", 0);
            txtRpAccPiutang.Text = string.Format("{0:N0}", Tools.isNull(_rpACCPiutang,0));
            hitung();
        }

        private void hitung()
        {
            #region Plafon
            double plafonToko = TokoPlafon.Plafon(_kodeToko, _transType);
            //txtPlafon.Text = string.Format("{0:N0}", plafonToko);
            #endregion

            #region Piutang
            double piutangToko = TokoPlafon.Piutang(_kodeToko, _transType);

            #endregion

            #region DoDalamProses
            double DoDalamProses = TokoPlafon.DODLMPROSES(_kodeToko);

//            txtDoDlmProses.Text = string.Format("{0:N0}", DoDalamProses);
            #endregion

            #region GIT
            double gitToko = TokoPlafon.GIT(_kodeToko, _transType);
            #endregion

            #region Giro
            double giroToko = TokoPlafon.Giro(_kodeToko, _transType);
            #endregion

            #region Giro Tolak
            double giroTolakToko = TokoPlafon.GiroTolak(_kodeToko, _transType);
            #endregion

            #region Sisa Plafon
            double sisaPlafonToko = TokoPlafon.SisaPlafon(plafonToko, piutangToko, gitToko, giroToko, giroTolakToko, DoDalamProses);

            txtPlafon.Text = string.Format("{0:N0}", sisaPlafonToko);
            #endregion


            int SO = 0;
            TtxtSO.Text = SO.ToString();

            int sum = 0;
            int qty = 0;
            int hjual = 0;

            for (int i = 0; i < dataGridDetailDO.Rows.Count; ++i)
            {
                qty = Convert.ToInt32(dataGridDetailDO.Rows[i].Cells["QtySisa"].Value);
                hjual = Convert.ToInt32(dataGridDetailDO.Rows[i].Cells["HrgJual"].Value);
                sum = (qty * hjual) + sum;
                //kuantiti2 += Convert.ToInt32(DataGridDO.Rows[i].Cells[2].Value);
            }
            TtxtSO.Text = string.Format("{0:N0}", sum);
            int sisa = 0,sisaAcc = 0;
            sisa = Convert.ToInt32(sisaPlafonToko - sum);
            txtSisa.Text = string.Format("{0:N0}", sisa);
            sisaAcc = Convert.ToInt32(_rpACCPiutang - sum);
            txtSisaAcc.Text = string.Format("{0:N0}", sisaAcc);
        }

        private bool Validasichecker() 
        {
            bool TerisaAll = true;
            String Message = "Nama ";
            if (lookupStafAdm1.Nama == "") 
            {
                Message += "Checker1";
                TerisaAll = false;
            }
            if (lookupStafAdm2.Nama== "")
            {
                Message += " dan Checker2";
                TerisaAll = false;
            }
            if (!TerisaAll) MessageBox.Show(Message + " belum diisi lengkap. Mohon diisi dengan lengkap.");
            return TerisaAll;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        
        {
            ///MessageBox.Show(Tools.AutoNumbering("NoNota", "ISADBDepoRetail.dbo.NotaPenjualan").ToString());
            //return;
            dt.AcceptChanges();
            double _totalHrg = 0;// double.Parse(dt.Compute("SUM(TotalHrg)", string.Empty).ToString());
            int x = 0;
            double _disc1 = 0;
            double _disc2 = 0;
            double _disc3 = 0;
            double _discFormula = 0;
            double _harga3D = 0;
            bool isBonusan = false;

            if (!Validasichecker())
                return;

            #region "Stok Minus Lock New"
            
            DataRow[] dr1 = dt.Select("QtySisa>0 AND StatusDO='BOLEH'");
            using (Stock st = new Stock())
            {
                foreach (DataRow drd in dr1)
                {
                    st.AddList(drd["BarangID"].ToString(), "",Convert.ToInt32( drd["QtySisa"]));
                }
                // pass = st.Pass();
                if (!st.Pass())
                {
                    MessageBox.Show("Tidak Bisa Proses,\n nilai transaksi menyebabkan stok minus! ", "Warning");
                    
                    if (MessageBox.Show("Batal Seluruh Nota  ?", "Batal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        st.ReportMinus();
                        if (MessageBox.Show("Cetak Form Opname?", "Opname", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            st.PrintOutMinus();
                        }
                        this.DialogResult = DialogResult.No;
                        this.Close();
                        return;
                    }else
                    {
                        st.ReportMinus();
                        if (MessageBox.Show("Cetak Form Opname?", "Opname", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            st.PrintOutMinus();
                        }

                        for (int i = 0; i < st.GetListBarangs.Count;i++ )
                        {
                            if (st.ListBarangs(i).SaldoStok-st.ListBarangs(i).QtyTrans<0)
                            {
                                var rows = dt.Select("BarangID='" + st.ListBarangs(i).KodeBarang+"'");

                                foreach (var row in rows)
                                {
                                    row.Delete();
                                }
                                dt.AcceptChanges();
                            }
                        }
                      
                    }
                }
            }
            

            int sum = 0;
            for (int i = 0; i < dataGridDetailDO.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridDetailDO.Rows[i].Cells["QtyNota"].Value);
            }
            if(sum == 0 ) 
            { 
                MessageBox.Show("Tidak bisa simpan record dengan Qty. Nota = 0. Mohon diisi Qty. Nota atau batalkan", "Cak Qty Nota");
                return;
            }

            #endregion


            //#region RpaccPiutang
            //DataTable dtt = new DataTable();
            //dtt = dt.Copy();
            //dr1 = dtt.Select("QtySisa>0 AND StatusDO='BOLEH'");
            //double _RpDO = 0;
            //int xx = 0;
            //foreach (DataRow drr in dr1)
            //{
            //    xx++;
            //    double qtDo = double.Parse(Tools.isNull(drr["QtySisa"], "0").ToString());
            //    double Hrjl = double.Parse(Tools.isNull(drr["HrgJual"], "0").ToString());
            //    double RpDo = qtDo * Hrjl;
            //    _disc1 = double.Parse(Tools.isNull(drr["Disc1"], "0").ToString());
            //    _disc2 = double.Parse(Tools.isNull(drr["Disc2"], "0").ToString());
            //    _disc3 = double.Parse(Tools.isNull(drr["Disc3"], "0").ToString());
            //    if (drr["DiscFormula"].ToString() == string.Empty)
            //    {
            //        _discFormula = 0;
            //    }

            //    DataTable dtNet3 = new DataTable();
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_GetNet3Disc"));
            //        db.Commands[0].Parameters.Add(new Parameter("@jmlHrg", SqlDbType.Money, RpDo));
            //        db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, _disc1));
            //        db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, _disc2));
            //        db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, _disc3));
            //        db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, _discFormula));
            //        dtNet3 = db.Commands[0].ExecuteDataTable();
            //    }

            //    if (drr["BarangID"].ToString().Substring(0, 3).Equals("FXB"))
            //        _RpDO = _RpDO + 0;
            //    else
            //        _RpDO = _RpDO + double.Parse(Tools.isNull(dtNet3.Rows[0]["HrgNet3Disc"], "0").ToString());
            //}
            
            
            //if (_RpDO > _rpSisaACCPiutang)
            //{
            //    MessageBox.Show("Nilai Nota Rp. " + _RpDO + "\n  Lebih besar dari nilai ACC piutang Rp. "
            //        + _rpACCPiutang + "\nProsess pembuatan nota tidak dapat dilanjutkan");
            //    this.DialogResult = DialogResult.No;
            //    this.Close();
            //    return;
            //}


            //if (xx==0)
            //{
            //    DataTable dtBonus = new DataTable();
            //    dtBonus = dt.Copy();
            //    DataRow[] drBonus = dtBonus.Select("BarangID LIKE 'FXB%'");

            //    if (dt.Rows.Count > 0 && drBonus.Length == dt.Rows.Count)
            //    {
            //        isBonusan = true;
            //    }

            //    if (!isBonusan)
            //    {
            //        MessageBox.Show("Nilai DO : 0 \nProsess pembuatan nota tidak dapat dilanjutkan");
            //        this.DialogResult = DialogResult.No;
            //        this.Close();
            //        return;
            //    }
            //}
            //#endregion
            
            
            //for (x=0; x < dt.Rows.Count; x++)
            //{
            //    double qtDo = double.Parse(Tools.isNull(dt.Rows[x]["QtySisa"], "0").ToString());
            //    double Hrjl = double.Parse(Tools.isNull(dt.Rows[x]["HrgJual"], "0").ToString());
            //    _totalHrg   = qtDo * Hrjl;
            //    //_totalHrg = double.Parse(Tools.isNull(dt.Rows[x]["TotalHrg"], "").ToString());
            //    _disc1 = double.Parse(Tools.isNull(dt.Rows[x]["Disc1"], "").ToString());
            //    _disc2 = double.Parse(Tools.isNull(dt.Rows[x]["Disc2"], "").ToString());
            //    _disc3 = double.Parse(Tools.isNull(dt.Rows[x]["Disc3"], "").ToString());
            //    if (dt.Rows[x]["DiscFormula"].ToString() == string.Empty)
            //    {
            //        _discFormula = 0;
            //    }
                
            //    DataTable dtNet3Disc = new DataTable();
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_GetNet3Disc"));
            //        db.Commands[0].Parameters.Add(new Parameter("@jmlHrg", SqlDbType.Money, _totalHrg));
            //        db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, _disc1));
            //        db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, _disc2));
            //        db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, _disc3));
            //        db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, _discFormula));
            //        dtNet3Disc = db.Commands[0].ExecuteDataTable();
            //    }
            //    if (dt.Rows[x]["BarangID"].ToString().Substring(0, 3).Equals("FXB"))
            //        _harga3D =_harga3D+ 0;
            //    else
            //        _harga3D = _harga3D + double.Parse(Tools.isNull(dtNet3Disc.Rows[0]["HrgNet3Disc"], "0").ToString());
            //}

            double _totalHrgNota = _harga3D;
            string cCab1 = dtDO.Rows[0]["Cabang1"].ToString().Trim();
            string cCab2 = dtDO.Rows[0]["Cabang2"].ToString().Trim();
            
            //if (_totalHrgNota > _rpSisaACCPiutang)
            //{
            //    if (cCab1 == GlobalVar.CabangID || cCab2 == GlobalVar.CabangID)
            //    {
            //        MessageBox.Show("Nilai Nota Rp. " + _totalHrgNota + "\nlebih besar dari nilai ACC piutang Rp. "
            //            + _rpACCPiutang + "\nProsess pembuatan nota tidak dapat dilanjutkan");
            //        return;
            //    }
            //}

            cCab1 = dtDO.Rows[0]["Cabang1"].ToString().Trim();
            if (cCab1 == GlobalVar.CabangID)
            {
                //if (dtDO.Rows[0]["NoACCPiutang"].ToString() != "BONUSAN")
                //{
                //    if (_totalHrgNota > TokoPlafon.SisaPlafon(_kodeToko, _transType))
                //    {
                //        MessageBox.Show("Tidak bisa buat nota. Nilai Nota melebihi Sisa Plafon toko. \n" +
                //                        "Silahkan melakukan pengajuan plafon ke PS HO");
                //        this.DialogResult = DialogResult.No;
                //        return;
                //    }
                //}
            }
            
                try
                {                    
                    int k; int l; 
                    k = 0; l = 0;
                    _notaHeaderRowID = Guid.NewGuid();
                    string _notaHeaderRecID = Tools.CreateShortFingerPrint(k);
                    string _notaDetailRecID = string.Empty;
                    // Add new Nota Penjualan Header
                    this.Cursor = Cursors.WaitCursor;
                    string temp = string.Empty;
                    //Generate Nomor Nota
                    string kodeNota = "";
                    string nomorNota = "";
                    string PTpattern = "KH,TH,KL,TL";


                    string depan = "";
                    string belakang = "";
                    int iNomor;
                    int lebar;
                    int lebarOriginal = 0;
                    int ctr = 0;
                    int lastCtr = 0;
                    int ctrBef = 0;
                    DataTable dtNum;
                    int countRows = 0;

                    if (IsTokoPT())
                    {
                        string transType = _transType;
                        if (PTpattern.Contains(transType))
                        {
                            kodeNota = "NOMOR_NOTA_TAX_2";
                        }
                        else
                        {
                            kodeNota = "NOMOR_NOTA_TAX";
                        }
                        depan = GetInitialPT();
                    }
                    else
                    {
                        if (Tools.Left(dtDO.Rows[0]["Cabang1"].ToString(),1)=="9")
                        {
                            kodeNota = "NOMOR_NOTA_PS";
                        }
                        else
                        {
                            kodeNota = "NOMOR_NOTA";
                        }
                       
                        depan = Tools.GeneralInitial();
                    }

                    if (DateTime.Today <= GlobalVar.LastClosingDate)
                    {
                        throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    }
                    //dtNum = Tools.GetGeneralNumerator(kodeNota, depan);
                    //lebarOriginal = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                    //lebar = lebarOriginal;
                    //iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());

                    //belakang = dtNum.Rows[0]["Belakang"].ToString();
                    //iNomor++;
                    //nomorNota = Tools.AutoNumbering("NoNota", "ISADBDepoRetail.dbo.NotaPenjualan");
                    nomorNota = _NoDo;
                               
                    //PROSES NOTA
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_INSERT"));//udah cek heri
                        
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _notaHeaderRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, _notaHeaderRecID)); //_notaHeaderRecID));
                        db.Commands[0].Parameters.Add(new Parameter("@DOID", SqlDbType.UniqueIdentifier, _doID));
                        db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, _doHtrID));
                        db.Commands[0].Parameters.Add(new Parameter("@noSJ", SqlDbType.VarChar, nomorNota));//Tools.GetGeneralNumerator("NOMOR_NOTA").Rows[0].ToString()));

                        db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, nomorNota));
                        db.Commands[0].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, GlobalVar.DateOfServer));
                        db.Commands[0].Parameters.Add(new Parameter("@tglSJ", SqlDbType.DateTime, DateTime.Today));
                        db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, SqlDateTime.Null));
                        db.Commands[0].Parameters.Add(new Parameter("@tglSerahTerimaChecker", SqlDbType.DateTime, SqlDateTime.Null));
                        db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, dtDO.Rows[0]["Cabang1"]));
                        db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, dtDO.Rows[0]["Cabang2"]));
                        db.Commands[0].Parameters.Add(new Parameter("@cabang3", SqlDbType.VarChar, dtDO.Rows[0]["Cabang3"]));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, dtDO.Rows[0]["KodeSales"]));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dtDO.Rows[0]["KodeToko"]));
                        db.Commands[0].Parameters.Add(new Parameter("@alamatKirim", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, _Cat1));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, _Cat2));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan3", SqlDbType.VarChar, _Cat3));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan4", SqlDbType.VarChar, _Cat4));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan5", SqlDbType.VarChar, _Cat5));
                        db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, _transType));
                        db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, _hariKredit));
                        db.Commands[0].Parameters.Add(new Parameter("@hariKirim", SqlDbType.Int, dtDO.Rows[0]["HariKirim"]));
                        db.Commands[0].Parameters.Add(new Parameter("@hariSales", SqlDbType.Int, dtDO.Rows[0]["HariSales"]));
                        db.Commands[0].Parameters.Add(new Parameter("@checker1", SqlDbType.UniqueIdentifier, lookupStafAdm1.RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@checker2", SqlDbType.UniqueIdentifier, lookupStafAdm2.RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                       
                        countRows = dt.Rows.Count;
                        DataRow[] dr = dt.Select("QtySisa>0 AND StatusDO='BOLEH'");
                       
                        int a=0;
                        foreach (DataRow drd in dr)
                        {
                              a++;
                        }

                        lastCtr = a;
                        
                        
                        db.BeginTransaction();
                        for (int j = 0; j < db.Commands.Count; j++)
                        {
                            db.Commands[j].ExecuteNonQuery();
                        }
                        db.CommitTransaction();
                        
                        int counter = 0;
                        for (int i = 0; i < countRows; i++)
                        {
                            db.Commands.Clear();

                            int _qtySisa = (int)dataGridDetailDO.Rows[i].Cells["QtySisa"].Value;
                            int _qtyMin = (int)dataGridDetailDO.Rows[i].Cells["QtyMin"].Value;
                           
                            Guid _doDetailID = (Guid)dataGridDetailDO.Rows[i].Cells["DetailRowID"].Value;
                            string _StatusDO = dataGridDetailDO.Rows[i].Cells["StatusDO"].Value.ToString();

                            //db.Commands.Clear();

                            int _qtyNota =  Convert.ToInt32(dataGridDetailDO.Rows[i].Cells["QtyNota"].Value);
                            if (_qtyNota > 0)
                            {
                                if (_qtySisa > 0 && _StatusDO.Equals("BOLEH") || isBonusan)
                                {
                                    _notaDetailRecID = Tools.CreateShortFingerPrint(counter + 1);

                                    temp = _notaDetailRecID;

                                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_INSERT")); // udah cek heri

                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _notaHeaderRowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, _notaDetailRecID));
                                    db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, _notaHeaderRecID));
                                    db.Commands[0].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, _doID));
                                    db.Commands[0].Parameters.Add(new Parameter("@doDetailID", SqlDbType.UniqueIdentifier, _doDetailID));
                                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dataGridDetailDO.Rows[i].Cells["BarangID"].Value));
                                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                    db.Commands[0].Parameters.Add(new Parameter("@qtySJ", SqlDbType.Int, _qtySisa));
                                    db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, dataGridDetailDO.Rows[i].Cells["HrgJual"].Value));
                                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, dataGridDetailDO.Rows[i].Cells["DetailDisc1"].Value));
                                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, dataGridDetailDO.Rows[i].Cells["DetailDisc2"].Value));
                                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, dataGridDetailDO.Rows[i].Cells["DetailDisc3"].Value));
                                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, dataGridDetailDO.Rows[i].Cells["DetailDiscFormula"].Value));
                                    db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, dataGridDetailDO.Rows[i].Cells["Pot"].Value));
                                    db.Commands[0].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, _qtyNota));
                                    db.Commands[0].Parameters.Add(new Parameter("@qtyKoli", SqlDbType.Int, 0));
                                    db.Commands[0].Parameters.Add(new Parameter("@koliAwal", SqlDbType.Int, 0));
                                    db.Commands[0].Parameters.Add(new Parameter("@koliAkhir", SqlDbType.Int, 0));
                                    db.Commands[0].Parameters.Add(new Parameter("@noKoli", SqlDbType.VarChar, dataGridDetailDO.Rows[i].Cells["NoKoli"].Value.ToString()));
                                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, dataGridDetailDO.Rows[i].Cells["Catatan"].Value.ToString()));
                                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                    db.Commands[0].Parameters.Add(new Parameter("@ketKoli", SqlDbType.VarChar, ""));
                                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    //tambahan fefe
                                    db.Commands[0].Parameters.Add(new Parameter("@NPackingListPrint", SqlDbType.VarChar, ""));
                                    ctr++;
                                    counter++;
                                }
                            

                            //EXECUTE ALL COMMANDS
                            db.BeginTransaction();
                            for (int j = 0; j < db.Commands.Count; j++)
                            {
                                    db.Commands[j].ExecuteNonQuery();
                                }
                                db.CommitTransaction();
                            }
                            #region Insert Nota
                            if ((ctr % 20 == 0) && (ctr != 0) && (ctr != lastCtr) && (ctr!=ctrBef))
                            {
                                //lastCtr = ctr;
                                ctrBef = ctr;
                                _notaHeaderRowID = Guid.NewGuid();
                                _notaHeaderRecID = Tools.CreateShortFingerPrint(k);

                                //dtNum = Tools.GetGeneralNumerator(kodeNota);
                                //lebarOriginal = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                                ////lebar = lebarOriginal - 3;
                                ////Update 2013-05-28
                                //lebar = lebarOriginal;
                                //iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());

                                //belakang = dtNum.Rows[0]["Belakang"].ToString();
                                //iNomor++;
                                ////nomorNota = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                                //nomorNota = Tools.AutoNumbering("NoNota", "SADBDepoRetail.dbo.NotaPenjualan");
                                nomorNota = _NoDo;
                                db.Commands.Clear();
                                db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_INSERT")); //udah cek heri

                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _notaHeaderRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, _notaHeaderRecID));
                                db.Commands[0].Parameters.Add(new Parameter("@DOID", SqlDbType.UniqueIdentifier, _doID));
                                db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, _doHtrID));
                                db.Commands[0].Parameters.Add(new Parameter("@noSJ", SqlDbType.VarChar, nomorNota));//Tools.GetGeneralNumerator("NOMOR_NOTA").Rows[0].ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, SqlDateTime.Null));
                                db.Commands[0].Parameters.Add(new Parameter("@tglSJ", SqlDbType.DateTime, DateTime.Today));
                                db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, SqlDateTime.Null));
                                db.Commands[0].Parameters.Add(new Parameter("@tglSerahTerimaChecker", SqlDbType.DateTime, SqlDateTime.Null));
                                db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, dtDO.Rows[0]["Cabang1"]));
                                db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, dtDO.Rows[0]["Cabang2"]));
                                db.Commands[0].Parameters.Add(new Parameter("@cabang3", SqlDbType.VarChar, dtDO.Rows[0]["Cabang3"]));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, dtDO.Rows[0]["KodeSales"]));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dtDO.Rows[0]["KodeToko"]));
                                db.Commands[0].Parameters.Add(new Parameter("@alamatKirim", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, _Cat1));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, _Cat2));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan3", SqlDbType.VarChar, _Cat3));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan4", SqlDbType.VarChar, _Cat4));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan5", SqlDbType.VarChar, _Cat5));
                                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, _transType));
                                db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, _hariKredit));
                                db.Commands[0].Parameters.Add(new Parameter("@hariKirim", SqlDbType.Int, dtDO.Rows[0]["HariKirim"]));
                                db.Commands[0].Parameters.Add(new Parameter("@hariSales", SqlDbType.Int, dtDO.Rows[0]["HariSales"]));
                                db.Commands[0].Parameters.Add(new Parameter("@checker1", SqlDbType.UniqueIdentifier, lookupStafAdm1.RowID));
                                db.Commands[0].Parameters.Add(new Parameter("@checker2", SqlDbType.UniqueIdentifier, lookupStafAdm2.RowID));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                //db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                                //db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, kodeNota));
                                //db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                                //db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                                //db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                                //db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebarOriginal));
                                //db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                countRows = dt.Rows.Count;
                               
                                db.BeginTransaction();
                                for (int j = 0; j < db.Commands.Count; j++)
                                {
                                    db.Commands[0].ExecuteNonQuery();
                                }
                                db.CommitTransaction();
                            } k++;
                            #endregion

                            #region recalculate
                            string barangID = dataGridDetailDO.Rows[i].Cells["BarangID"].Value.ToString();
                            string gudang = GlobalVar.Gudang;
                            Recalculate(barangID, gudang);
                            //MessageBox.Show("Proses RECALCULATE Selesai");
                            this.Cursor = Cursors.Default;

                            #endregion  
                        }
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show(Messages.Confirm.UpdateSuccess + "\nNomor Nota: " + nomorNota);

                                                  

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
                frmNotaJualBrowser frmCaller = (frmNotaJualBrowser)this.Caller;
                frmCaller.RefreshDataNotaJual();
            //}
            this.Close();
        }

        private void Recalculate(string idbarang_, string gudang_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {


                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("psp_StokGudang_Recalculation"));
                    db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, gudang_));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, idbarang_));
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridDetailDO_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridDetailDO.RowCount>0)
            {
                int _qtyNota = int.Parse(dataGridDetailDO.Rows[e.RowIndex].Cells["QtySisa"].Value.ToString());
                string noACCDet = Tools.isNull(dataGridDetailDO.Rows[e.RowIndex].Cells["DetailNoACC"].Value, string.Empty).ToString();

                if (_qtyNota < 1)
                {
                    dataGridDetailDO.Rows[e.RowIndex].Cells["QtySisa"].ReadOnly = true;
                    dataGridDetailDO.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.LightGray;
                }

                string _StatusDO = dataGridDetailDO.Rows[e.RowIndex].Cells["StatusDO"].Value.ToString();
                if (_StatusDO.Equals("GAK"))
                {
                    dataGridDetailDO.Rows[e.RowIndex].Cells["QtySisa"].ReadOnly = true;
                    dataGridDetailDO.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.LightGray;
                }

                if (noACCDet.ToUpper() == "HARGA")
                {
                    dataGridDetailDO.Rows[e.RowIndex].Cells["HrgJual"].Style.ForeColor = Color.Red;
                }
            }
            
        }

        private bool IsTokoPT()
        {
            bool result = false;
            DataTable dtToko;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));                
                db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dt.Rows[0]["KodeToko"]));

                dtToko = db.Commands[0].ExecuteDataTable();
            }
            if (dtToko.Rows.Count >= 0)
            {
                if (dtToko.Rows[0]["Cabang2"].ToString().Trim() == "PT")
                {
                    result= true;
                }
            }

            if (dtDO.Rows[0]["Cabang1"].ToString() != dtDO.Rows[0]["Cabang2"].ToString() && Tools.Left(dtDO.Rows[0]["Cabang1"].ToString(),1)=="9")
            {
                result= false;
            }
            return result;
        }

        private string GetInitialPT()
        {
            string code1;
            string code2;
            string code3;

            DataTable dtGudang;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Gudang_LIST")); //cek heri
                db.Commands[0].Parameters.Add(new Parameter("@gudangID", SqlDbType.VarChar,GlobalVar.Gudang ));
                dtGudang = db.Commands[0].ExecuteDataTable();                
            }
            code1 = dtGudang.Rows[0]["Fax"].ToString();
            code2 = Tools.ToCode("NOTA_PT_M");
            code3 = Tools.ToCode("NOTA_PT_Y");

            return code1 + code2 + code3;
        }

        private void frmNotaJualUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmNotaJualBrowser)
                {
                    frmNotaJualBrowser frmCaller = (frmNotaJualBrowser)this.Caller;
                    frmCaller.RefreshRowDataDO(_doID.ToString());
                    frmCaller.RefreshRowDataNotaJual(_notaHeaderRowID.ToString());
                    frmCaller.RefreshDataNotaJualDetail();
                    frmCaller.FindHeader("NotaRowID", _notaHeaderRowID.ToString());    
                }
            }
        }

        private void dataGridDetailDO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridDetailDO_SelectionRowChanged(object sender, EventArgs e)
        {
            string transactionType = Tools.isNull(dataGridDetailDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value, string.Empty).ToString();
            string noACCDet = Tools.isNull(dataGridDetailDO.SelectedCells[0].OwningRow.Cells["DetailNoACC"].Value, string.Empty).ToString();

            cmdPIN.Visible = false;
            lblKetDlAccHarga.Visible = false;
            if (noACCDet == "HARGA")
            {
                if (transactionType == "K2" || transactionType == "K4")
                {
                    cmdPIN.Visible = false;
                    lblKetDlAccHarga.Visible = true;
                }
                else
                {
                    cmdPIN.Visible = true;
                    lblKetDlAccHarga.Visible = false;
                }
            }
        }

        private void cmdPIN_Click(object sender, EventArgs e)
        {
            Guid headerID = (Guid)dataGridDetailDO.SelectedCells[0].OwningRow.Cells["HeaderID"].Value;
            Guid rowID = (Guid)dataGridDetailDO.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
            string namaStok = Tools.isNull(dataGridDetailDO.SelectedCells[0].OwningRow.Cells["NamaStok"].Value, string.Empty).ToString();

            Pin.frmPinMd5 ifrmpin = new Pin.frmPinMd5(this, headerID, rowID, GlobalVar.Gudang, PinId.Bagian.Harga, "Cegatan Harga " + namaStok);
            ifrmpin.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmpin);
            ifrmpin.Show();
        }

        private void dataGridDetailDO_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((int)dataGridDetailDO[3, e.RowIndex].Value > (int)dataGridDetailDO[2, e.RowIndex].Value) 
            {
                MessageBox.Show("Nilai Qty Nota melebihi Qty Sisa.");
                dataGridDetailDO[3, e.RowIndex].Value = dataGridDetailDO[2, e.RowIndex].Value;
                return;
            }
            if ((int)dataGridDetailDO[3, e.RowIndex].Value > (int)dataGridDetailDO[1, e.RowIndex].Value)
            {
                MessageBox.Show("Nilai Qty Nota melebihi Qty DO.");
                dataGridDetailDO[3, e.RowIndex].Value = dataGridDetailDO[1, e.RowIndex].Value;
                return;
            }
            hitung();
        }
    }
}
