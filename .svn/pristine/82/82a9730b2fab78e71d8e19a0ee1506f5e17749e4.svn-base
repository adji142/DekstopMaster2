using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using ISA.Common;
using ISA.DAL;
using ISA.Utility;
using ISA.Finance.Class;

namespace ISA.Finance.Kasir
{
    public partial class frmPenerimaanViaPaycoll : ISA.Controls.BaseForm
    {
        DataRow _perusahaan;
        string _kodeCollector, _namaCollector, _hRecordID, _noBukti, _cmbText;
        DataTable _lists, _idenLists, dtbl2;
        Guid _headerRowID;
        DateTime _tglIden;

        bool _itOk = false;
        public bool itOK
        {
            get { return _itOk; }
        }

        public DateTime FromDate
        {
            get
            {
                return rangeDateBox1.FromDate.Value;
            }
            set
            {
                rangeDateBox1.FromDate = value;
            }
        }

        public DateTime ToDate
        {
            get
            {
                return rangeDateBox1.ToDate.Value;
            }
            set
            {
                rangeDateBox1.ToDate = value;
            }
        }

        private string _cmbKodeCollector
        {
            get
            {
                string _cc = _cmbText;
                int _ix = _cc.IndexOf("(");
                if (_ix > 0) return _cc.Substring(0, _ix).Trim();
                else return _cc.Trim();
            }
        }

        private string _cmbNamaCollector
        {
            get
            {
                string nm = _cmbText;
                int i = nm.IndexOf("(") + 1;
                nm = nm.Substring(i, nm.Length - i - 1);
                return nm.Trim();
            }
        }

        #region "Initializing"
        InPopup ipProgress;
        public frmPenerimaanViaPaycoll(Guid HeaderRowID, String HRecordID, string NamaCollector, DateTime TglIden, string NoBukti, string KodeCollector)
        {
            InitializeComponent();
            _kodeCollector = KodeCollector;
            _headerRowID = HeaderRowID;
            _hRecordID = HRecordID.TrimEnd();
            _namaCollector = NamaCollector;
            _tglIden = TglIden;
            _noBukti = NoBukti;

            Initialize();
        }

        private void Initialize()
        {
            if (ipProgress == null) ipProgress = new InPopup(this, pnlProgress);
            GV01.AutoGenerateColumns = GV02.AutoGenerateColumns = GV03.AutoGenerateColumns = GV04.AutoGenerateColumns = false;

            _lists = new DataTable();
            _lists.Columns.AddRange(new DataColumn[] {
                new DataColumn("RowID", typeof(Guid)),
                new DataColumn("HeaderRowID", typeof(Guid)),
                new DataColumn("KaryawanID", typeof(string)),
                new DataColumn("KodeToko", typeof(string)),
                new DataColumn("JnsTrans", typeof(string)),
                new DataColumn("TglTrans", typeof(DateTime)),
                new DataColumn("Nominal", typeof(double)),
                new DataColumn("NominalIden", typeof(double)),
                new DataColumn("BankRowID", typeof(Guid)),
                new DataColumn("NamaBank", typeof(string)),
                new DataColumn("BankID", typeof(string)),
                new DataColumn("AccBGC", typeof(string)),
                new DataColumn("TglRK", typeof(DateTime)),
                new DataColumn("GiroAttachPath", typeof(string))
            });

            _idenLists = new DataTable();
            _idenLists.Columns.AddRange(new DataColumn[] {
                new DataColumn("RowID", typeof(Guid)),
                new DataColumn("HeaderRowID", typeof(Guid)),
                new DataColumn("IdenRowID", typeof(Guid)),
                new DataColumn("Nominal", typeof(double)),
                new DataColumn("SFID", typeof(int)),
                new DataColumn("Tanggal", typeof(DateTime))
            });

            DataTable dtbl = new DataTable();
            using (var db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_Perusahaan_LIST]"));
                dtbl = db.Commands[0].ExecuteDataTable();
                if (dtbl.Rows.Count > 0) _perusahaan = dtbl.Copy().Rows[0];
                else
                {
                    MessageBox.Show("Tidak dapat di akses");
                    this.Close();
                }

                int _i = -1,
                    _s = 0;

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("[usp_Collector_LIST]"));
                db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, true));
                dtbl = db.Commands[0].ExecuteDataTable();
                if (dtbl.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtbl.Rows)
                    {
                        _i += 1;
                        string kode = dr["Kode"].ToString().Trim();
                        if (kode == _kodeCollector) _s = _i;
                        cmbCollectors.Items.Add(kode + " (" + dr["Nama"].ToString() + ")");
                    }
                }

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("[usp_Sales_LIST]"));
                db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, _perusahaan["InitCabang"].ToString()));
                dtbl = db.Commands[0].ExecuteDataTable();
                if (dtbl.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtbl.Rows)
                    {
                        _i += 1;
                        string kode = dr["SalesID"].ToString().Trim();
                        if (kode == _kodeCollector) _s = _i;
                        cmbCollectors.Items.Add(kode + " (" + dr["NamaSales"].ToString() + ")");
                    }
                }
                cmbCollectors.SelectedIndex = _s;
            }
            _cmbText = cmbCollectors.Text;
        }
        #endregion

        #region "Event Handler"
        private void frmPenerimaanViaPaycoll_Load(object sender, EventArgs e)
        {
            tabPage1.Tag = "!";
            tabPage2.Tag = "!";
            tabPage3.Tag = "!";
            RefreshGV01();
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            if (sender.Equals(btnSearch)) RefreshGV01();
            else if (sender.Equals(btnAdd))
            {
                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += (a, b) => _itOk = this.SavingData();
                bgw.RunWorkerCompleted += (a, b) =>
                {
                    ipProgress.Close(_itOk);
                    if (_itOk) this.Close();
                };
                bgw.RunWorkerAsync();
                ipProgress.OpenDialog(this);
            }
            else if (sender.Equals(btnRefresh))
            {
                _iGV02 = -1;
                _lists.Clear();
                _idenLists.Clear();

                this.CalcTotal();
                this.RefreshGV01();
                this.RefreshGV02();
            }
            else if (sender.Equals(btnClose)) this.Close();
        }

        private void cmbCollectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cmbText = cmbCollectors.Text;
            RefreshGV01();
            CalcTotal();
        }

        private void img_Clicked(object sender, EventArgs e)
        {
            PictureBox obj = (PictureBox)sender;
            frmImageViewer frm = new frmImageViewer(obj.Image);
            frm.ShowDialog();
        }

        private void tab_Changed(object sender, EventArgs e)
        {
            RefreshGV01();
        }

        private void txt_Changed(object sender, EventArgs e)
        {
            if (sender.Equals(txtPopNomKoreksi))
            {
                double num = 0;
                if (!double.TryParse(txtPopNomKoreksi.Text, out num)) num = 0;

                JSON conf = (JSON)ipKoreksi.Tag;
                txtPopNomFinal.Text = (conf["Nominal"].NumberValue + num).ToString("#,##0");
            }
        }
        #endregion

        #region "GV Data"
        List<Guid> BGTWhitelist = new List<Guid>();
        private void RefreshGV01()
        {
            string ctag = "";
            if (rangeDateBox1.FromDate.HasValue && rangeDateBox1.ToDate.HasValue)
            {
                ctag = rangeDateBox1.FromDate.Value.ToString("ddMMyyyy") + rangeDateBox1.ToDate.Value.ToString("ddMMyyyy");
            }

            if (tabMain.SelectedTab.Tag == null || (tabMain.SelectedTab.Tag != null && !tabMain.SelectedTab.Tag.Equals(ctag)))
            {
                if (tabMain.SelectedTab == tabPage1)
                {
                    tabPage1.Tag = ctag;

                    _iGV02 = -1;
                    BGTWhitelist.Clear();
                    using (var db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_Paycoll_Penerimaan_LIST_ByTglSynch]"));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeCollector", SqlDbType.VarChar, _cmbKodeCollector));
                        DataTable dtbl = db.Commands[0].ExecuteDataTable();

                        dtbl.Columns.Add("Check");
                        if (dtbl.Columns.IndexOf("HeaderRowID") < 0) dtbl.Columns.Add("HeaderRowID");
                        if (dtbl.Columns.IndexOf("BGTujuanUI") < 0) dtbl.Columns.Add("BGTujuanUI");
                        if (dtbl.Columns.IndexOf("BankRowID") < 0) dtbl.Columns.Add("BankRowID");
                        if (dtbl.Columns.IndexOf("TglRKUI") < 0) dtbl.Columns.Add("TglRKUI");
                        if (dtbl.Columns.IndexOf("TglRK") < 0) dtbl.Columns.Add("TglRK");
                        if (dtbl.Columns.IndexOf("BankID") < 0) dtbl.Columns.Add("BankID");
                        if (dtbl.Columns.IndexOf("AccBGC") < 0) dtbl.Columns.Add("AccBGC");
                        if (dtbl.Columns.IndexOf("Actions") < 0) dtbl.Columns.Add("Actions");
                        if (dtbl.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtbl.Rows)
                            {
                                DataRow[] rows = _lists.Select("RowID = '" + dr["RowID"].ToString() + "'");
                                dr["Check"] = (rows != null ? rows.Length > 0 : false);
                                dr["BankID"] = (rows != null && rows.Length > 0 ? rows[0]["BankID"] : dr["BankID"]);
                                dr["BankRowID"] = (rows != null && rows.Length > 0 ? rows[0]["BankRowID"] : dr["BankRowID"]);
                                dr["AccBGC"] = (rows != null && rows.Length > 0 ? rows[0]["AccBGC"] : dr["AccBGC"]);
                                dr["TglRK"] = (rows != null && rows.Length > 0 ? rows[0]["TglRK"] : dr["TglRK"]);

                                dr["TglRKUI"] = (dr["TglRK"] != DBNull.Value ? ((DateTime)dr["TglRK"]).ToString("dd-MM-yyyy") : "Set TglRK");

                                string jnst = dr["TipeTransaksi"].ToString();
                                switch (dr["TipeTransaksi"].ToString())
                                {
                                    case "TRN":
                                    case "BNK":
                                        dr["Actions"] = (dr["TipeTransaksi"].ToString() == "BNK" ? "Lihat Bukti" : "View");
                                        if (dr["TipeTransaksi"].ToString() == "BNK" && dr["BankRowID"] == DBNull.Value) BGTWhitelist.Add(new Guid(dr["RowID"].ToString()));
                                        dr["BGTujuanUI"] = (
                                            rows != null && rows.Length > 0 ? (
                                                rows[0]["NamaBank"] != DBNull.Value ? rows[0]["NamaBank"] : (
                                                    dr["StatusCode"].ToString() == "0" ? "-" : "Pilih Bank"
                                                )
                                            ) : (
                                                dr["BGTujuanUI"] == DBNull.Value ? (
                                                    dr["StatusCode"].ToString() == "0" ? "-" : "Pilih Bank"
                                                ) : dr["BGTujuanUI"]
                                            )
                                        );
                                        break;

                                    case "BGC":
                                        dr["Actions"] = "View";
                                        dr["BGTujuanUI"] = (
                                            rows != null && rows.Length > 0 ? (
                                                rows[0]["AccBGC"] != DBNull.Value ? rows[0]["AccBGC"] : (
                                                    dr["StatusCode"].ToString() == "0" ? "-" : "Pilih AccGiro"
                                                )
                                            ) : (
                                                dr["AccBGC"] == DBNull.Value ? (
                                                    dr["StatusCode"].ToString() == "0" ? "-" : "Pilih AccGiro"
                                                ) : dr["AccBGC"]
                                            )
                                        );
                                        break;
                                }
                            }
                        }
                        GV01.DataSource = dtbl.DefaultView;
                        this.cbox_Changed(cbox_RowFilter, null);
                    }
                }
                else if (tabMain.SelectedTab == tabPage2)
                {
                    tabPage2.Tag = ctag;

                    using (var db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_Paycoll_TokoBayar_LIST]"));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeCollector", SqlDbType.VarChar, this._cmbKodeCollector));
                        db.Commands[0].Parameters.Add(new Parameter("@ItPreview", SqlDbType.Bit, true));
                        DataTable dtbl = db.Commands[0].ExecuteDataTable();

                        if (dtbl.Columns.IndexOf("Actions") < 0) dtbl.Columns.Add("Actions");
                        foreach (DataRow dr in dtbl.Rows) dr["Actions"] = "Lihat Verify";
                        GV03.DataSource = dtbl.DefaultView;
                    }
                }
                else if (tabMain.SelectedTab == tabPage3)
                {
                    tabPage3.Tag = ctag;

                    using (var db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_Paycoll_HasilTagihan_LIST]"));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeCollector", SqlDbType.VarChar, this._cmbKodeCollector));
                        db.Commands[0].Parameters.Add(new Parameter("@ItPreview", SqlDbType.Bit, true));
                        DataTable dtbl = db.Commands[0].ExecuteDataTable();

                        if (dtbl.Columns.IndexOf("Actions") < 0) dtbl.Columns.Add("Actions");
                        foreach (DataRow dr in dtbl.Rows) dr["Actions"] = "Lihat Verify";
                        GV04.DataSource = dtbl.DefaultView;
                    }
                }
            }
        }

        int _iGV02;
        private void RefreshGV02()
        {
            if (GV01.SelectedCells.Count > 0)
            {
                DataGridViewRow crow = GV01.SelectedCells[0].OwningRow;
                if (crow.Index == _iGV02) return; else _iGV02 = crow.Index;

                using (var db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Paycoll_Iden_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TBDetailRowID", SqlDbType.UniqueIdentifier, crow.Cells["colRowID"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, crow.Cells["colJnsTransaksi"].Value.ToString()));
                    DataTable dtbl = db.Commands[0].ExecuteDataTable();

                    double nom = 0;
                    double budget = double.Parse(crow.Cells["colNominalIden"].Value.ToString()) + (crow.Cells["colNominalKoreksi"].Value != DBNull.Value ? double.Parse(crow.Cells["colNominalKoreksi"].Value.ToString()) : 0);
                    if (!double.TryParse(crow.Cells["colNominalIden"].Value.ToString(), out nom)) nom = 0;
                    foreach (DataRow dr in dtbl.Rows)
                    {
                        double cnom = 0;
                        string crid = dr["RowID"].ToString();
                        DataRow[] rows = _idenLists.Select("RowID = '" + crid + "' AND HeaderRowID = '" + crow.Cells["colRowID"].Value.ToString() + "' AND IdenRowID = '" + dr["IdenRowID"].ToString() + "'");
                        if (rows.Length > 0)
                        {
                            if (!double.TryParse(rows[0]["Nominal"].ToString(), out cnom)) cnom = 0;
                            if (nom < cnom) cnom = nom;
                            nom -= cnom;

                            if (cnom >= budget) cnom = budget;
                            budget -= cnom;

                            dr["NomIden2"] = cnom;
                            rows[0]["Nominal"] = cnom;
                        }
                        else
                        {
                            if (!double.TryParse(dr["NomIden2"].ToString(), out cnom)) cnom = 0;
                            if (nom < cnom) cnom = nom;
                            nom -= cnom;

                            if (cnom >= budget) cnom = budget;
                            budget -= cnom;

                            dr["NomIden2"] = cnom;
                            _idenLists.Rows.Add(new object[] {
                                new Guid(crid),
                                new Guid(crow.Cells["colRowID"].Value.ToString()),
                                new Guid(dr["IdenRowID"].ToString()),
                                cnom,
                                int.Parse(dr["SFID"].ToString())
                            });
                        }

                    }
                    GV02.DataSource = dtbl.DefaultView;
                }
                return;
            }
            if (GV02.DataSource is DataView) ((DataView)GV02.DataSource).Table.Rows.Clear();
            else if (GV02.DataSource is DataTable) ((DataTable)GV02.DataSource).Rows.Clear();
            _iGV02 = -1;
        }

        private void cbox_Changed(object sender, EventArgs e)
        {
            if (sender.Equals(cbox_RowFilter))
            {
                if (GV01.DataSource != null)
                {
                    DataView dv = null;
                    if (GV01.DataSource is DataView) dv = (DataView)GV01.DataSource;
                    else if (GV01.DataSource is DataTable) dv = ((DataTable)GV01.DataSource).DefaultView;

                    if (dv != null) dv.RowFilter = (cbox_RowFilter.Checked ? "StatusCode = 1" : "");
                }
            }
            else
            {
                if (chkToko2.Checked)
                {
                    label26.Visible = true;
                    txtTotalDKN.Visible = true;
                    txtTotalDKN.Text = "";
                    using (var db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_Paycoll_Penerimaan_LIST_ByTglSynch]"));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeCollector", SqlDbType.VarChar, _cmbKodeCollector));
                        dtbl2 = db.Commands[0].ExecuteDataTable();

                        GVDKN.DataSource = dtbl2.DefaultView;
                    }
                }
                else
                {
                    txtTotalDKN.Text = "";
                    label26.Visible = false;
                    txtTotalDKN.Visible = false;
                    dtbl2.Rows.Clear();
                    GVDKN.DataSource = dtbl2.DefaultView;
                }
            }
        }
        #endregion

        #region "Data Action"
        private void CalcTotal()
        {
            double[] ttls = new double[] {
                0, // [0]: TRN CS
                0, // [1]: TRN CS IDEN
                0, // [2]: BGC
                0, // [3]: BGC IDEN
                0, // [4]: TRN
                0, // [5]: TRN IDEN
                0, // [6]: ALL
                0  // [7]: ALL IDEN
            };

            foreach (DataRow dr in _lists.Rows)
            {
                if (dr["KaryawanID"].ToString() != this._cmbKodeCollector) continue;
                switch (dr["JnsTrans"].ToString())
                {
                    case "BNK":
                        ttls[0] += (double)dr["Nominal"];
                        ttls[1] += (double)dr["NominalIden"];
                        ttls[6] += (double)dr["Nominal"];
                        ttls[7] += (double)dr["NominalIden"];
                        break;

                    case "BGC":
                        ttls[2] += (double)dr["Nominal"];
                        ttls[3] += (double)dr["NominalIden"];
                        ttls[6] += (double)dr["Nominal"];
                        ttls[7] += (double)dr["NominalIden"];
                        break;

                    case "TRN":
                        ttls[4] += (double)dr["Nominal"];
                        ttls[5] += (double)dr["NominalIden"];
                        ttls[6] += (double)dr["Nominal"];
                        ttls[7] += (double)dr["NominalIden"];
                        break;
                }
            }

            txtTRNCS.Text = ttls[0].ToString("#,##0");
            txtTRNCSIden.Text = ttls[1].ToString("#,##0");
            txtBGC.Text = ttls[2].ToString("#,##0");
            txtBGCIden.Text = ttls[3].ToString("#,##0");
            txtTRN.Text = ttls[4].ToString("#,##0");
            txtTRNIden.Text = ttls[5].ToString("#,##0");
        }

        private bool validateData()
        {
            if (PeriodeClosing.IsPJTClosed(GlobalVar.DateOfServer))
            {
                MessageBox.Show("Sudah Closing!");
                return false;
            }
            
            string msg = "";
            foreach (DataRow dr in _lists.Rows)
            {
                if (dr["KaryawanID"].ToString() != this._cmbKodeCollector) continue;
                switch (dr["JnsTrans"].ToString())
                {
                    case "TRN":
                    case "BNK":
                        if (dr["TglRK"] == DBNull.Value || dr["TglRK"] == null)
                        {
                            msg = "Transaksi tanggal: " + ((DateTime)dr["TglTrans"]).ToString("dd/MM/yyyy") + ", nominal: " + double.Parse(dr["Nominal"].ToString()).ToString("#,##0") +
                                "\nTanggal RK belum terisi";
                        }
                        if (dr["BankRowID"] == DBNull.Value || dr["BankRowID"] == null)
                        {
                            msg = "Transaksi tanggal: " + ((DateTime)dr["TglTrans"]).ToString("dd/MM/yyyy") + ", nominal: " + double.Parse(dr["Nominal"].ToString()).ToString("#,##0") +
                                "\nBelum ada bank tujuan";
                        }
                        break;

                    case "BGC":
                        if (dr["AccBGC"] == DBNull.Value || dr["AccBGC"] == null)
                        {
                            msg = "Transkasi tanggal " + ((DateTime)dr["TglTrans"]).ToString("dd/MM/yyyy") + ", nominal: " + double.Parse(dr["Nominal"].ToString()).ToString("#,##0") +
                                "\nBelum ada no account giro";
                        }
                        break;
                }
                if (msg != "") break;
            }

            if (msg != "")
            {
                MessageBox.Show(msg);
                return false;
            }
            return true;
        }

        private JSON GenerateData0()
        {
            JSON mdat = new JSON(JSONType.Array);

            JSON xdat = new JSON(JSONType.Object);
            xdat["KPTagih"] = new JSON(JSONType.Object);

            using (var db = new Database(GlobalVar.DBName))
            {
                foreach (DataRow dr in _lists.Rows)
                {
                    if (dr["KaryawanID"].ToString() != this._cmbKodeCollector) continue;
                    if (dr["JnsTrans"].ToString() == "BNK")
                    {
                        int ix = db.Commands.Count;
                        db.Commands.Add(db.CreateCommand("[usp_Paycoll_SetorUang_LIST]"));
                        db.Commands[ix].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr["RowID"]));
                        DataTable dtbl = db.Commands[ix].ExecuteDataTable();

                        if (dtbl.Rows.Count <= 0) return null;
                        double nomt = double.Parse(dtbl.Rows[0]["NominalFinal"].ToString());
                        nomt += double.Parse(dtbl.Rows[0]["NominalTambahan"].ToString());

                        JSON opt = new JSON(JSONType.Object);
                        opt.ObjAdd("TipeTransaksi", new JSON("KAS"));
                        opt.ObjAdd("DirectRowID", new JSON(dr["RowID"]));
                        opt.ObjAdd("DoType", new JSON((dtbl.Rows[0]["BankRowID"].ToString() == "11111111-1111-1111-1111-111111111111" ? "" : "T")));
                        opt.ObjAdd("Berita", new JSON(dtbl.Rows[0]["BeritaTransfer"]));
                        opt.ObjAdd("TglTrans", new JSON(dtbl.Rows[0]["TglTransfer"]));
                        opt.ObjAdd("TglRK", new JSON(dtbl.Rows[0]["TglTransfer"]));
                        opt.ObjAdd("Lists", new JSON(JSONType.Array));
                        opt.ObjAdd("Nominal", new JSON(JSONType.Object));
                        opt["Nominal"].ObjAdd("Cash", new JSON((opt["DoType"].StringValue == "T" ? 0 : nomt)));
                        opt["Nominal"].ObjAdd("Transfer", new JSON((opt["DoType"].StringValue == "T" ? nomt : 0)));

                        List<Guid> lst = new List<Guid>();
                        DataRow[] rows = _idenLists.Select("HeaderRowID = '" + dr["RowID"] + "'");
                        foreach (DataRow dr2 in rows)
                        {
                            Guid cg = new Guid(dr2["RowID"].ToString());
                            if (lst.IndexOf(cg) < 0)
                            {
                                int ci = db.Commands.Count;
                                db.Commands.Add(db.CreateCommand("[usp_Paycoll_TokoBayarDetail_LIST]"));
                                db.Commands[ci].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, cg));
                                DataTable dtbl2 = db.Commands[ci].ExecuteDataTable();

                                if (dtbl2.Rows.Count <= 0) return null;

                                opt["Lists"].ArrAdd(new JSON(JSONType.Unknown, dtbl2.Rows[0]));
                                lst.Add(cg);
                            }
                        }

                        JSON dat = this.GenerateData1(db, xdat, Guid.Empty, opt);
                        if (dat == null) return null;
                        mdat.ArrAdd(dat);

                    }
                    else
                    {
                        JSON dat = this.GenerateData1(db, xdat, new Guid(dr["RowID"].ToString()), null);
                        if (dat == null) return null;
                        mdat.ArrAdd(dat);
                    }
                }
            }
            return mdat;
        }

        private JSON GenerateData1(Database db, JSON xdat, Guid RowID, JSON Opt)
        {
            if (Opt == null) Opt = new JSON(JSONType.Object);
            if (Opt.Type != JSONType.Object) Opt = new JSON(JSONType.Object);

            int ci = db.Commands.Count;
            JSON dat = new JSON(JSONType.Object);
            DataTable dtbl = new DataTable(), tmpdtbl;

            if (!Opt.ObjExists("Lists"))
            {
                db.Commands.Add(db.CreateCommand("[usp_Paycoll_TokoBayarDetail_LIST]"));
                db.Commands[ci].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                dtbl = db.Commands[ci].ExecuteDataTable();
            }
            else ci -= 1;

            if (dtbl.Rows.Count > 0 || Opt.ObjExists("Lists"))
            {
                DataRow dr = null, dr2 = null;
                if (dtbl.Rows.Count > 0) dr = dtbl.Rows[0];
                string DirRowID = (Opt.ObjExists("DirectRowID") ? Opt["DirectRowID"].GuidValue().ToString() : dr["DirectRowID"].ToString());
                string TipeTrans = (Opt.ObjExists("TipeTransaksi") ? Opt["TipeTransaksi"].StringValue : dr["TipeTransaksi"].ToString());

                DataRow[] rows = _lists.Select("RowID = '" + DirRowID + "'");
                if (rows.Length <= 0) return null;

                dr2 = rows[0];
                string _dotype = null, _noBGC = null, _ket = null, _noAcc = null;
                double _rpCash = 0, _rpGiro = 0, _rpTrn = 0, _rpCrd = 0, _rpDbt = 0;
                Object _tglBGC = DBNull.Value, _tglRK = DBNull.Value, _tglJTempo = DBNull.Value;
                DateTime _tglTrn = DateTime.Now;

                switch (TipeTrans)
                {
                    case "KAS":
                        ci += 1;
                        if (!Opt.ObjExists("DoType") || !Opt.ObjExists("TglRK") || !Opt.ObjExists("TglTrans") || !Opt.ObjExists("Berita"))
                        {
                            db.Commands.Add(db.CreateCommand("[usp_Paycoll_SetorUang_LIST]"));
                            db.Commands[ci].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr["SetorRowID"]));
                            tmpdtbl = db.Commands[ci].ExecuteDataTable();
                            if (tmpdtbl.Rows.Count <= 0) return null;

                            _tglTrn = DateTime.Parse(tmpdtbl.Rows[0]["TglTransfer"].ToString());
                            _ket = tmpdtbl.Rows[0]["BeritaTransfer"].ToString();
                            _tglRK = tmpdtbl.Rows[0]["TglTransfer"];

                            if (tmpdtbl.Rows[0]["BankRowID"].ToString() == "11111111-1111-1111-1111-111111111111")
                            {
                                _rpCash = double.Parse(dr["NominalFinal"].ToString());
                                _dotype = "";
                            }
                            else
                            {
                                _rpTrn = double.Parse(dr["NominalFinal"].ToString());
                                _dotype = "T";
                            }
                        }

                        _dotype = (Opt.ObjExists("DoType") ? Opt["DoType"].StringValue : _dotype);
                        _tglTrn = (Opt.ObjExists("TglTrans") ? (DateTime)Opt["TglTrans"].DateTimeValue(DateTime.Now) : _tglTrn);
                        _tglRK = (Opt.ObjExists("TglRK") ? Opt["TglRK"].DateTimeValue() : _tglRK);
                        _ket = (Opt.ObjExists("Berita") ? Opt["Berita"].StringValue : _ket);

                        if (Opt.ObjExists("Nominal"))
                        {
                            JSON nom = Opt["Nominal"];
                            _rpCash = (nom.ObjExists("Cash") ? nom["Cash"].NumberValue : 0);
                            _rpGiro = (nom.ObjExists("Giro") ? nom["Giro"].NumberValue : 0);
                            _rpTrn = (nom.ObjExists("Transfer") ? nom["Transfer"].NumberValue : 0);
                            _rpCrd = (nom.ObjExists("Credit") ? nom["Credit"].NumberValue : 0);
                            _rpDbt = (nom.ObjExists("Debet") ? nom["Debet"].NumberValue : 0);
                        }
                        break;

                    case "TRN":
                        _dotype = "T";
                        _tglRK = dr2["TglRK"];
                        _ket = dr["Keterangan"].ToString();
                        _rpTrn += double.Parse(dr["NominalFinal"].ToString());
                        _tglTrn = DateTime.Parse(dr["TglTransaksi"].ToString());
                        break;

                    case "BGC":
                        _dotype = "G";
                        //_tglRK = dr2["TglRK"];
                        _tglRK = GlobalVar.DateOfServer;
                        _ket = dr["Keterangan"].ToString();
                        _tglBGC = dr["TglTransaksi"];
                        _tglJTempo = dr["TglJTBGC"];
                        _noBGC = dr["NoBGC"].ToString();
                        _noAcc = dr2["AccBGC"].ToString();
                        _tglTrn = DateTime.Parse(dr["TglTransaksi"].ToString());
                        _rpGiro += double.Parse(dr["NominalFinal"].ToString());

                        using (var db2 = new Database(GlobalVar.DBName))
                        {
                            db2.Commands.Add(db2.CreateCommand("[usp_Paycoll_TokoBayarDetail_LIST_State]"));
                            db2.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                            DataTable dtbl2 = db2.Commands[0].ExecuteDataTable();
                            if (dtbl2.Rows.Count > 0)
                            {
                                try
                                {
                                    if (dtbl2.Rows[0]["GiroAttach"] != DBNull.Value && dtbl2.Rows[0]["GiroAttach"] != null)
                                    {
                                        byte[] byts = (byte[])dtbl2.Rows[0]["GiroAttach"];
                                        if (byts.Length > 0)
                                        {
                                            using (var mem = new System.IO.MemoryStream(byts))
                                            {
                                                Image img = Image.FromStream(mem);
                                                dat["GiroAttach"] = new JSON(JSONType.Unknown, img);
                                            }
                                        }
                                    }
                                    else if (dtbl2.Rows[0]["Attachment"] != DBNull.Value && dtbl2.Rows[0]["Attachment"] != null)
                                    {
                                        string txt = dtbl2.Rows[0]["Attachment"].ToString().Replace("\\", "");
                                        if (txt.Length > 0)
                                        {
                                            byte[] bys = System.Convert.FromBase64String(txt);
                                            using (var mem = new System.IO.MemoryStream(bys))
                                            {
                                                Image img = Image.FromStream(mem);
                                                dat["GiroAttach"] = new JSON(JSONType.Unknown, img);
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Image rendering error: " + ex.Message);
                                    return null;
                                }
                            }
                        }
                        break;
                }

                dat["CHBG2"] = new JSON((_dotype == "T" ? "TRN" : (_dotype == "G" ? "BGC" : (_dotype == "" ? "KAS" : ""))));
                dat["Nominal"] = new JSON((_rpCash + _rpGiro + _rpTrn + _rpCrd + _rpDbt));
                dat["NominalIden"] = new JSON(dr2["NominalIden"]);
                dat["KaryawanID"] = new JSON(this._cmbKodeCollector);
                dat["KaryawanNama"] = new JSON(this._cmbNamaCollector);
                dat["BankRowID"] = new JSON(dr2["BankRowID"]);
                dat["NamaBank2"] = new JSON(dr2["NamaBank"]);
                dat["TglTransaksi"] = new JSON(_tglTrn);

                if (dat["Nominal"].NumberValue <= 0)
                {
                    string msg = "Transaksi tanggal: " + ((DateTime)dat["TglTransaksi"].DateTimeValue(DateTime.Now)).ToString("dd/MM/yyyy") + ", nominal: " + dat["Nominal"].NumberValue.ToString("#,##0") +
                        "\nNominal transaksi kosong";
                    MessageBox.Show(msg);
                    return null;
                }

                dat["RowID"] = new JSON(Guid.NewGuid());
                dat["RecordID"] = new JSON(Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial));
                dat["HeaderID"] = new JSON(_headerRowID);
                dat["HRecordID"] = new JSON(_hRecordID);
                dat["TglTrf"] = new JSON(_tglRK);
                dat["NamaBank"] = new JSON(dr2["NamaBank"]);
                dat["BankID"] = new JSON((TipeTrans == "BGC" ? "" : dr2["BankID"].ToString()));
                dat["Lokasi"] = new JSON((TipeTrans != "BGC" ? "" : dr2["BankID"].ToString()));
                dat["CHBG"] = new JSON(_dotype);
                dat["Nomor"] = new JSON(_noBGC);
                dat["NoAcc"] = new JSON(_noAcc);
                dat["Ket"] = new JSON(_ket);
                dat["TglGiro"] = new JSON(_tglBGC);
                dat["TglJt"] = new JSON(_tglJTempo);
                dat["RpCash"] = new JSON(_rpCash);
                dat["RpGiro"] = new JSON(_rpGiro);
                dat["RpTrf"] = new JSON(_rpTrn);
                dat["RpCrd"] = new JSON(_rpCrd);
                dat["RpDbt"] = new JSON(_rpDbt);
                dat["LastUpdatedBy"] = new JSON(SecurityManager.UserName);

                JSON cdat = new JSON(JSONType.Object);
                cdat["RowID"] = new JSON(RowID);
                cdat["User"] = new JSON(SecurityManager.UserName);
                dat["TBC"] = cdat;

                switch (_dotype)
                {
                    case "":
                        if (!xdat.ObjExists("NoPerkiraan")) xdat["NoPerkiraan"] = new JSON(Perkiraan.GetPerkiraanKoneksiDetail("IND").Rows[0]["NoPerkiraan"]);
                        if (!xdat.ObjExists("BKMRowID"))
                        {
                            DataTable bkmd = Inden.CekRelasiInden("Bukti", "SrcID", _headerRowID.ToString(), "", "").Copy();
                            if (bkmd.Rows.Count <= 0)
                            {
                                xdat["BKMRowID"] = new JSON(_headerRowID);

                                cdat = new JSON(JSONType.Object);
                                cdat["RowID"] = new JSON(xdat["BKMRowID"].Value);
                                cdat["HeaderID"] = new JSON(_headerRowID);
                                cdat["RecordID"] = new JSON(BKM.GetRecordIDBukti(_hRecordID, "IND"));
                                cdat["NoBKM"] = new JSON(Numerator.BookNumerator("BKM", (DateTime)_tglRK));
                                cdat["JenisBKM"] = new JSON("K");
                                cdat["Src"] = new JSON("IND");
                                cdat["Tanggal"] = new JSON(_tglIden);
                                cdat["Kepada"] = new JSON(this._cmbNamaCollector);
                                cdat["Pembukuan"] = new JSON("");
                                cdat["NoAcc"] = new JSON(_noAcc);
                                cdat["Kasir"] = new JSON(SecurityManager.UserName);
                                cdat["Penerima"] = new JSON(SecurityManager.UserName);
                                dat["BKM"] = cdat;
                            }
                            else xdat["BKMRowID"] = new JSON(bkmd.Rows[0][0]);
                        }

                        cdat = new JSON(JSONType.Object);
                        cdat["RowID"] = new JSON(dat["RowID"].GuidValue());
                        cdat["HeaderID"] = new JSON(xdat["BKMRowID"].GuidValue());
                        cdat["RecordID"] = new JSON(dat["RecordID"].StringValue);
                        cdat["HRecordID"] = new JSON(BKM.GetRecordIDBukti(_hRecordID, "IND"));
                        cdat["BSRecordID"] = new JSON("");
                        cdat["Kode"] = new JSON("");
                        cdat["Sub"] = new JSON("");
                        cdat["NoAcc"] = new JSON(_noAcc);
                        cdat["NoPerkiraan"] = new JSON(xdat["NoPerkiraan"].Value);
                        cdat["Uraian"] = new JSON("PENERIMAAN BELUM IDENTIFIKASI (" + _noBukti + ")");
                        cdat["Nominal"] = new JSON(dat["Nominal"].NumberValue);
                        dat["BKMD"] = cdat;
                        break;

                    case "T":
                        if (!xdat.ObjExists("NoPerkiraan")) xdat["NoPerkiraan"] = new JSON(Perkiraan.GetPerkiraanKoneksiDetail("IND").Rows[0]["NoPerkiraan"]);
                        if (!xdat.ObjExists("TBNKRowID"))
                        {
                            DataTable tbnkd = Inden.CekRelasiInden("TransferBank", "SrcID", _headerRowID.ToString(), "", "").Copy();
                            if (tbnkd.Rows.Count <= 0)
                            {
                                xdat["TBNKRowID"] = new JSON(_headerRowID);
                                xdat["TBNKNoBBM"] = new JSON(Numerator.BookNumerator("BBM", (DateTime)_tglRK));

                                cdat = new JSON(JSONType.Object);
                                cdat["RowID"] = new JSON(xdat["TBNKRowID"].Value);
                                cdat["HeaderID"] = new JSON(_headerRowID);
                                cdat["RecordID"] = new JSON(BKM.GetRecordIDBukti(_hRecordID, "IND"));
                                cdat["TglBBM"] = new JSON(_tglRK);
                                cdat["NoBBM"] = new JSON(xdat["TBNKNoBBM"].Value);
                                cdat["MK"] = new JSON("M");
                                cdat["BankID"] = new JSON("");
                                cdat["Ket"] = new JSON("DKN. No " + lookupDKN1.NoDKN);
                                cdat["Pembukuan"] = new JSON("");
                                cdat["Diketahui"] = new JSON("");
                                cdat["Kasir"] = new JSON(SecurityManager.UserName);
                                cdat["Penyetor"] = new JSON("");
                                dat["TBNKBBM"] = cdat;

                                xdat["TBNKRowIDBBK"] = new JSON(Guid.NewGuid());
                                xdat["TBNKNoBBK"] = new JSON(Numerator.BookNumerator("BBK", (DateTime)_tglRK));

                                cdat = new JSON(JSONType.Object);
                                cdat["RowID"] = new JSON(xdat["TBNKRowIDBBK"].Value);
                                cdat["HeaderID"] = new JSON(cdat["RowID"].Value);
                                cdat["RecordID"] = new JSON(_hRecordID + "4");
                                cdat["TglBBM"] = new JSON(_tglRK);
                                cdat["NoBBM"] = new JSON(xdat["TBNKNoBBK"].Value);
                                cdat["MK"] = new JSON("K");
                                cdat["BankID"] = new JSON("");
                                cdat["Ket"] = new JSON("DKN. No " + lookupDKN1.NoDKN);
                                cdat["Pembukuan"] = new JSON("");
                                cdat["Diketahui"] = new JSON("");
                                cdat["Kasir"] = new JSON(SecurityManager.UserName);
                                cdat["Penyetor"] = new JSON("");
                                dat["TBNKBBK"] = cdat;

                            }
                            else
                            {
                                xdat["TBNKRowID"] = new JSON(tbnkd.Rows[0][0]);
                                xdat["TBNKNoBBM"] = new JSON(tbnkd.Rows[0][1]);

                                DataTable dtBBK = new DataTable();
                                using (Database db1 = new Database(GlobalVar.DBName))
                                {
                                    db1.Commands.Add(db.CreateCommand("usp_GetRowIDBBK"));
                                    db1.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, xdat["TBNKRowID"].GuidValue()));
                                    dtBBK = db1.Commands[0].ExecuteDataTable();
                                }

                                xdat["TBNKRowIDBBK"] = new JSON(dtBBK.Rows[0][0]);
                                xdat["TBNKNoBBK"] = new JSON(dtBBK.Rows[0][1]);
                            }
                        }

                        cdat = new JSON(JSONType.Object);
                        cdat["RowID"] = new JSON(dat["RowID"].GuidValue());
                        cdat["HeaderID"] = new JSON(xdat["TBNKRowID"].GuidValue(Guid.Empty));
                        cdat["RecordID"] = new JSON(dat["RecordID"].StringValue);
                        cdat["HRecordID"] = new JSON(BKM.GetRecordIDBukti(_hRecordID, "IND"));
                        cdat["KodeCollector"] = new JSON(this._cmbKodeCollector);
                        cdat["NamaCollector"] = new JSON(this._cmbNamaCollector);
                        cdat["NamaBank"] = new JSON(dat["NamaBank"].StringValue);
                        cdat["Lokasi"] = new JSON("");
                        cdat["Nomor"] = new JSON("");
                        cdat["TglTrans"] = new JSON(_tglRK);
                        cdat["Nominal"] = new JSON(dat["Nominal"].NumberValue);
                        cdat["Titip1"] = new JSON("");
                        cdat["Titip2"] = new JSON("");
                        cdat["Piut1"] = new JSON("");
                        cdat["Piut2"] = new JSON("");
                        cdat["BankID"] = new JSON("");
                        cdat["NoPerkiraan"] = new JSON(xdat["NoPerkiraan"].Value);
                        cdat["TitikPerkiraan"] = new JSON("");
                        dat["TBNKDBBM"] = cdat;

                        cdat = new JSON(JSONType.Object);
                        cdat["RowID"] = new JSON(Guid.NewGuid());
                        cdat["HeaderID"] = new JSON(xdat["TBNKRowIDBBK"].GuidValue(Guid.Empty));
                        cdat["RecordID"] = new JSON(dat["RecordID"].StringValue.Trim() + "K");
                        cdat["HRecordID"] = new JSON(_hRecordID + "4");
                        cdat["KodeCollector"] = new JSON(this._cmbKodeCollector);
                        cdat["NamaCollector"] = new JSON(this._cmbNamaCollector);
                        cdat["NamaBank"] = new JSON(dat["NamaBank"].StringValue);
                        cdat["Lokasi"] = new JSON("");
                        cdat["Nomor"] = new JSON("");
                        cdat["TglTrans"] = new JSON(_tglRK);
                        cdat["Nominal"] = new JSON(dat["Nominal"].NumberValue);
                        cdat["Titip1"] = new JSON("");
                        cdat["Titip2"] = new JSON("");
                        cdat["Piut1"] = new JSON("");
                        cdat["Piut2"] = new JSON("");
                        cdat["BankID"] = new JSON("");
                        cdat["NoPerkiraan"] = new JSON(xdat["NoPerkiraan"].Value);
                        cdat["TitikPerkiraan"] = new JSON("");
                        dat["TBNKDBBK"] = cdat;

                        cdat = new JSON(JSONType.Object);
                        cdat["RowID"] = new JSON(dat["RowID"].GuidValue());
                        cdat["LinkBankID"] = new JSON(Guid.Empty);
                        cdat["NoBBK"] = new JSON(xdat["TBNKNoBBM"].Value);
                        cdat["NoBGCH"] = new JSON("");
                        cdat["HeaderID"] = new JSON(dat["BankRowID"].GuidValue(Guid.Empty));
                        cdat["RegID"] = new JSON("");
                        cdat["TglTrans"] = new JSON(_tglRK);
                        cdat["JnsTrans"] = new JSON("BBM");
                        cdat["Ket"] = new JSON("TRANSFER DARI : " + this._cmbNamaCollector + " (BANK TRANSFER)");
                        cdat["VTA"] = new JSON("IDR");
                        cdat["Debet"] = new JSON(dat["Nominal"].NumberValue);
                        cdat["Kredit"] = new JSON(0);
                        cdat["TglBank"] = new JSON(DateTime.Now);
                        cdat["TglRK"] = new JSON(_tglRK);
                        cdat["LinkRK"] = new JSON("");
                        cdat["Kode"] = new JSON("");
                        cdat["Sub"] = new JSON("");
                        cdat["Catatan"] = new JSON("");
                        cdat["NoPerkiraan"] = new JSON(xdat["NoPerkiraan"].Value);
                        cdat["BankID"] = new JSON(dat["BankID"].StringValue);
                        cdat["RecordID"] = new JSON(dat["RecordID"].StringValue);
                        dat["BNKDBBM"] = cdat;

                        cdat = new JSON(JSONType.Object);
                        cdat["RowID"] = new JSON(Guid.NewGuid());
                        cdat["LinkBankID"] = new JSON(Guid.Empty);
                        cdat["NoBBK"] = new JSON(xdat["TBNKNoBBK"].Value);
                        cdat["NoBGCH"] = new JSON("");
                        cdat["HeaderID"] = new JSON(dat["BankRowID"].GuidValue(Guid.Empty));
                        cdat["RegID"] = new JSON("");
                        cdat["TglTrans"] = new JSON(_tglRK);
                        cdat["JnsTrans"] = new JSON("BBK");
                        cdat["Ket"] = new JSON("TRANSFER DARI : " + this._cmbNamaCollector + " (BANK TRANSFER)");
                        cdat["VTA"] = new JSON("IDR");
                        cdat["Debet"] = new JSON(0);
                        cdat["Kredit"] = new JSON(dat["Nominal"].NumberValue);
                        cdat["TglBank"] = new JSON(DateTime.Now);
                        cdat["TglRK"] = new JSON(_tglRK);
                        cdat["LinkRK"] = new JSON("");
                        cdat["Kode"] = new JSON("");
                        cdat["Sub"] = new JSON("");
                        cdat["Catatan"] = new JSON("");
                        //cdat["NoPerkiraan"] = new JSON(xdat["NoPerkiraan"].Value);
                        cdat["NoPerkiraan"] = new JSON("210310200");
                        cdat["BankID"] = new JSON(dat["BankID"].StringValue);
                        cdat["RecordID"] = new JSON(dat["RecordID"].StringValue.Trim() + "K");
                        dat["BNKDBBK"] = cdat;
                        break;

                    case "G":
                        if (DateTime.Parse(_tglJTempo.ToString()) < GlobalVar.DateOfServer)
                        {
                            string msg = "Transaksi tanggal: " + ((DateTime)dat["TglTransaksi"].DateTimeValue(DateTime.Now)).ToString("dd/MM/yyyy") + ", nominal: " + dat["Nominal"].NumberValue.ToString("#,##0") +
                                "\nTgl Jatuh tempo giro sudah terlewati";
                            MessageBox.Show(msg);
                            return null;
                        }

                        if (!xdat.ObjExists("NoPerkiraan")) xdat["NoPerkiraan"] = new JSON(Perkiraan.GetPerkiraanKoneksiDetail("IND").Rows[0]["NoPerkiraan"]);
                        if (!xdat.ObjExists("VJRowID"))
                        {
                            DataTable vjd = Inden.CekRelasiInden("VoucherJournal", "RefRowID", _headerRowID.ToString(), "PG", "").Copy();
                            if (vjd.Rows.Count <= 0)
                            {
                                xdat["VJRowID"] = new JSON(Guid.NewGuid());
                                xdat["VJRecordID"] = new JSON(BKM.GetRecordIDBukti(_hRecordID, "IND"));

                                cdat = new JSON(JSONType.Object);
                                cdat["RowID"] = new JSON(xdat["VJRowID"].Value);
                                cdat["HeaderID"] = new JSON(_headerRowID);
                                cdat["RecordID"] = new JSON(xdat["VJRecordID"].StringValue);
                                cdat["Type"] = new JSON("PG");
                                cdat["TglVoucher"] = new JSON(GlobalVar.DateOfServer);
                                cdat["NoVoucher"] = new JSON(Numerator.BookNumerator("VPG", (DateTime)_tglBGC));
                                cdat["Uraian1"] = new JSON("PENERIMAAN GIRO IND. NO " + _noBukti);
                                cdat["Uraian2"] = new JSON("");
                                cdat["Uraian3"] = new JSON("");
                                cdat["Pembuat"] = new JSON("");
                                cdat["Pembukuan"] = new JSON("");
                                cdat["Mengetahui"] = new JSON("");
                                cdat["BankID"] = new JSON("");
                                cdat["NamaBank"] = new JSON("");
                                cdat["NPrint"] = new JSON(0);
                                cdat["SynchFlag"] = new JSON(true);
                                dat["VJ"] = cdat;
                            }
                            else
                            {
                                xdat["VJRowID"] = new JSON(vjd.Rows[0][0]);
                                xdat["VJRecordID"] = new JSON(vjd.Rows[0][1]);
                            }
                        }

                        cdat = new JSON(JSONType.Object);
                        cdat["RowID"] = new JSON(dat["RowID"].GuidValue());
                        cdat["HeaderID"] = new JSON(xdat["VJRowID"].GuidValue(Guid.Empty));
                        cdat["BBMID"] = new JSON(Guid.Empty);
                        cdat["TitipID"] = new JSON(Guid.Empty);
                        cdat["VoucherRecID"] = new JSON(xdat["VJRecordID"].StringValue);
                        cdat["BBMRecID"] = new JSON("");
                        cdat["TitipRecID"] = new JSON("");
                        cdat["GiroRecID"] = new JSON(dat["RecordID"].StringValue);
                        cdat["KodeToko"] = new JSON(dr["KodeToko"]);
                        cdat["NamaBank"] = new JSON(dat["NamaBank"].StringValue);
                        cdat["Lokasi"] = new JSON("");
                        cdat["CHBG"] = new JSON(_dotype);
                        cdat["Nomor"] = new JSON(dat["Nomor"].StringValue);
                        cdat["TglGiro"] = new JSON(dat["TglGiro"].DateTimeValue(DateTime.Now));
                        cdat["TglTempo"] = new JSON(dat["TglJt"].DateTimeValue(DateTime.Now));
                        cdat["Nominal"] = new JSON(dat["Nominal"].NumberValue);
                        cdat["CairTolak"] = new JSON("");
                        cdat["TglCair"] = new JSON(JSONType.Null);
                        cdat["Titip1"] = new JSON("");
                        cdat["Titip2"] = new JSON("");
                        cdat["Piut1"] = new JSON("");
                        cdat["Piut2"] = new JSON("");
                        cdat["BankID"] = new JSON("");
                        cdat["NamaBanki"] = new JSON("");
                        cdat["NoPerkiraan"] = new JSON(xdat["NoPerkiraan"].StringValue);
                        cdat["TglTitip"] = new JSON(JSONType.Null);
                        cdat["SynchFlag"] = new JSON(true);
                        cdat["NoAcc"] = new JSON(_noAcc);
                        cdat["TitikPerkiraan"] = new JSON("");
                        dat["GD"] = cdat;
                        break;
                }

                if (Opt.ObjExists("Lists"))
                {
                    double budget = dat["NominalIden"].NumberValue;

                    dat["TBC"] = new JSON(JSONType.Array);
                    dat["Iden"] = new JSON(JSONType.Array);
                    for (int i = 0; i < Opt["Lists"].Count; i++)
                    {
                        cdat = new JSON(JSONType.Object);
                        cdat["RowID"] = new JSON(((DataRow)Opt["Lists"][i].Value)["RowID"]);
                        cdat["User"] = new JSON(SecurityManager.UserName);
                        dat["TBC"].ArrAdd(cdat);

                        JSON lst = this.GenerateData2(db, xdat, (DataRow)Opt["Lists"][i].Value, dat);
                        if (lst != null && lst.Type == JSONType.Array) {
                            for (int i2 = 0; i2 < lst.Count; i2++)
                            {
                                budget -= double.Parse(lst[i2]["RpNominal"].ToString());
                                if (budget < 0)
                                {
                                    string msg = "Transaksi tanggal: " + ((DateTime)dat["TglTransaksi"].DateTimeValue(DateTime.Now)).ToString("dd/MM/yyyy") + ", nominal: " + dat["Nominal"].NumberValue.ToString("#,##0") +
                                        "\nNominal identifikasi melebihi nominal transfer";
                                    MessageBox.Show(msg);
                                    return null;
                                }
                                dat["Iden"].ArrAdd(lst[i2]);
                            }
                        }
                        else return null;
                    }
                }
                else dat["Iden"] = this.GenerateData2(db, xdat, dr, dat);

                if (dat["Iden"] == null) return null;
                else return dat;
            }
            else return null;
        }

        private JSON GenerateData2(Database db, JSON xdat, DataRow TBDetail, JSON DData)
        {
            JSON dat = new JSON(JSONType.Array);

            int ci = db.Commands.Count;
            db.Commands.Add(db.CreateCommand("[usp_Paycoll_TokoBayar_LIST]"));
            db.Commands[ci].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, TBDetail["TokoBayarRowID"]));
            DataTable dtbl = db.Commands[ci].ExecuteDataTable();

            if (dtbl.Rows.Count > 0)
            {
                JSON sdat = new JSON(JSONType.Object);

                double ttl = 0;
                DataRow[] rows = _idenLists.Select("RowID = '" + TBDetail["RowID"].ToString() + "' AND HeaderRowID = '" + TBDetail["DirectRowID"].ToString() + "'");
                foreach (DataRow dr in rows) ttl += double.Parse(dr["Nominal"].ToString());

                if (DData["NominalIden"].NumberValue < ttl)
                {
                    string msg = "Transaksi tanggal: " + ((DateTime)DData["TglTransaksi"].DateTimeValue(DateTime.Now)).ToString("dd/MM/yyyy") + ", nominal: " + DData["Nominal"].NumberValue.ToString("#,##0") +
                        "\nNominal identifikasi melebihi nominal penerimaan";
                    MessageBox.Show(msg);
                    return null;
                }

                if (dtbl.Rows[0]["NamaToko"].ToString().Trim().Length <= 0)
                {
                    if (ttl == 0) return dat;
                    string msg = "Transaksi tanggal: " + ((DateTime)DData["TglTransaksi"].DateTimeValue(DateTime.Now)).ToString("dd/MM/yyyy") + ", nominal: " + DData["Nominal"].NumberValue.ToString("#,##0") +
                        "\nToko '" + dtbl.Rows[0]["KodeToko"].ToString() + "' tidak di temukan";
                    MessageBox.Show(msg);
                    return null;
                }

                sdat["RowID"] = new JSON(Guid.NewGuid());
                sdat["HeaderID"] = new JSON(DData["RowID"].GuidValue());
                sdat["IndenID"] = new JSON(_headerRowID);
                sdat["RecordID"] = new JSON(Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial));
                sdat["HRecordID"] = new JSON(DData["RecordID"].StringValue);
                sdat["KodeToko"] = new JSON(dtbl.Rows[0]["KodeToko"]);
                sdat["NamaToko"] = new JSON(dtbl.Rows[0]["NamaToko"]);
                sdat["RpNominal"] = new JSON(ttl);
                sdat["NoReg"] = new JSON(dtbl.Rows[0]["NoRegister"]);
                sdat["NoBPP"] = new JSON("PC" + (TBDetail["WiserID"].ToString()).PadLeft(6, '0'));
                sdat["TglBPP"] = new JSON(DData["TglTrf"].DateTimeValue(TBDetail["TglTransaksi"]));
                sdat["TglKasir"] = new JSON(_tglIden);
                sdat["LastUpdatedBy"] = new JSON(SecurityManager.UserName);

                JSON ssdat;
                if (DData["CHBG2"].StringValue == "BGC")
                {
                    ssdat = new JSON(JSONType.Object);
                    ssdat["GiroID"] = new JSON(sdat["RowID"].GuidValue());
                    ssdat["KodeToko"] = new JSON(sdat["KodeToko"].StringValue);
                    ssdat["LastUpdatedBy"] = new JSON(SecurityManager.UserName);
                    sdat["GIRO"] = ssdat;
                }
                else sdat["GIRO"] = new JSON(JSONType.Null);

                double budget = ttl;
                sdat["SubIden"] = new JSON(JSONType.Array);
                foreach (DataRow dr in rows)
                {
                    ssdat = this.GenerateData3(db, xdat, TBDetail, dr, DData, sdat);
                    if (ssdat == null) return null;
                    else if (ssdat.Type == JSONType.Object && ssdat.ObjExists("RowID"))
                    {
                        if (ssdat.ObjExists("RpInden")) budget -= ssdat["RpInden"].NumberValue;
                        if (budget < 0)
                        {
                            string msg = "Transaksi tanggal: " + ((DateTime)DData["TglTransaksi"].DateTimeValue(DateTime.Now)).ToString("dd/MM/yyyy") + ", nominal: " + DData["Nominal"].NumberValue.ToString("#,##0") +
                                "\nNominal identifikasi melebihi nominal penerimaan";
                            MessageBox.Show(msg);
                            return null;
                        }
                        sdat["SubIden"].ArrAdd(ssdat);
                    }
                }

                if (ttl > 0) dat.ArrAdd(sdat);
                return dat;
            }
            else return null;
        }

        private JSON GenerateData3(Database db, JSON xdat, DataRow TBDetail, DataRow IdenTB, JSON DData, JSON DIData)
        {
            JSON dat = new JSON(JSONType.Object);

            int ci = db.Commands.Count;
            db.Commands.Add(db.CreateCommand("[usp_Paycoll_IdenPembayaran_LIST]"));
            db.Commands[ci].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, IdenTB["IdenRowID"]));
            DataTable dtbl = db.Commands[ci].ExecuteDataTable();

            if (dtbl.Rows.Count > 0)
            {
                if (dtbl.Rows[0]["KartuPiutangID"].ToString() == "-1") return new JSON(JSONType.Object);

                string kpRowID = dtbl.Rows[0]["KPRowID"].ToString();
                double rpIden = double.Parse(IdenTB["Nominal"].ToString());
                double rpTagih = double.Parse(dtbl.Rows[0]["KPRpTagih"].ToString());
                if (xdat["KPTagih"].ObjExists(kpRowID))
                {
                    dtbl.Rows[0]["KPRpTagih"] = rpTagih = xdat["KPTagih"][kpRowID].NumberValue;
                    xdat["KPTagih"][kpRowID] = new JSON(rpTagih - rpIden);
                }
                else xdat["KPTagih"].ObjAdd(kpRowID, new JSON(rpTagih - rpIden));

                if (rpIden <= 0) return new JSON(JSONType.Object);
                if ((rpTagih - rpIden) < 0)
                {
                    string msg = "Transaksi tanggal: " + ((DateTime)DData["TglTransaksi"].DateTimeValue(DateTime.Now)).ToString("dd/MM/yyyy") + ", nominal: " + DData["Nominal"].NumberValue.ToString("#,##0") +
                        "\nNominal yang teridentifikasi melebihi sisa tagihan";
                    MessageBox.Show(msg);
                    return null;
                }

                dat["RowID"] = new JSON(Guid.NewGuid());
                dat["HeaderID"] = new JSON(DIData["RowID"].GuidValue());
                dat["IndenID"] = new JSON(_headerRowID);
                dat["IndenDetailID"] = new JSON(DData["RowID"].GuidValue());
                dat["RecordID"] = new JSON(Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial));
                dat["HRecordID"] = new JSON(DIData["RecordID"].StringValue);
                dat["TagihDetailID"] = new JSON(dtbl.Rows[0]["TDRowID"]);
                dat["TagihDetailRecID"] = new JSON(dtbl.Rows[0]["TDRecordID"]);
                dat["KPID"] = new JSON(dtbl.Rows[0]["KPRowID"]);
                dat["KPRecID"] = new JSON(dtbl.Rows[0]["KPRecordID"]);
                dat["TglBPP"] = new JSON(DIData["TglBPP"].Value);
                dat["NoReg"] = new JSON(DIData["NoReg"].StringValue);
                dat["Src"] = new JSON("KP");
                dat["Ref"] = new JSON(DData["CHBG2"].StringValue);
                dat["NoBukti"] = new JSON(_noBukti);
                dat["TglInden"] = new JSON(GlobalVar.DateOfServer);
                //dat["TglInden"] = new JSON(DData["TglTrf"].DateTimeValue(TBDetail["TglBayar"]));
                dat["TglJatuhTempo"] = new JSON(dtbl.Rows[0]["KPJTTempo"]);
                dat["Kode"] = new JSON("");
                dat["Sub"] = new JSON("");
                dat["NoPerk"] = new JSON("");
                dat["RpInden"] = new JSON(IdenTB["Nominal"]);
                dat["RpNota"] = new JSON(dtbl.Rows[0]["KPRpNota"]);
                dat["RpTagih"] = new JSON(dtbl.Rows[0]["KPRpTagih"]);
                dat["Keterangan"] = new JSON("");
                dat["LastUpdatedBy"] = new JSON(SecurityManager.UserName);
                dat["PublicKey"] = new JSON("");

                JSON sdat = new JSON(JSONType.Object);
                sdat["RowID"] = new JSON(dat["RowID"].GuidValue());
                sdat["HeaderID"] = new JSON(dtbl.Rows[0]["KPRowID"]);
                sdat["RecordID"] = new JSON(dat["RecordID"].StringValue);
                sdat["KPID"] = new JSON(dtbl.Rows[0]["KPRecordID"]);
                sdat["TglTransaksi"] = new JSON(GlobalVar.DateOfServer);//job okt req dwy to aji ->asumsi pascal croscek aji execute by ANDREAS //new JSON(DData["TglTrf"].DateTimeValue(TBDetail["TglBayar"]));
                sdat["KodeTransaksi"] = new JSON(DData["CHBG2"].StringValue);
                sdat["Debet"] = new JSON(0);
                sdat["Kredit"] = new JSON(IdenTB["Nominal"]);
                sdat["TglJTGiro"] = new JSON(DData["TglJt"].Value);
                sdat["Uraian"] = new JSON(_noBukti + "." + DIData["NoBPP"].StringValue + "/" + DData["CHBG2"].StringValue + ":" + DData["Nominal"].StringValue);
                sdat["NoBuktiKasMasuk"] = new JSON((GlobalVar.IsXtd ? "" : Tools.Right(DIData["NoReg"].StringValue.Trim(), 5)));
                sdat["NoGiro"] = new JSON(DData["Nomor"].StringValue);
                sdat["Bank"] = new JSON(DData["NamaBank"].StringValue);
                sdat["NoACC"] = new JSON(DData["NoAcc"].StringValue);
                sdat["LastUpdatedBy"] = new JSON(SecurityManager.UserName);
                dat["KP"] = sdat;

                sdat = new JSON(JSONType.Object);
                sdat["RowID"] = new JSON(dtbl.Rows[0]["TDRowID"]);
                sdat["TglInden"] = new JSON(DData["TglTrf"].DateTimeValue(TBDetail["TglBayar"]));
                sdat["Keterangan"] = new JSON("IDENTIFIKASI PEMBAYARAN : " + (dtbl.Rows[0]["KPRpTagih"].ToString() == IdenTB["Nominal"].ToString() ? _noBukti : dtbl.Rows[0]["KPNota"].ToString()) + " (" + IdenTB["Nominal"].ToString() + ")");
                sdat["LastUpdatedBy"] = new JSON(SecurityManager.UserName);
                dat["TD"] = sdat;

                sdat = new JSON(JSONType.Object);
                sdat["RowID"] = new JSON(dat["RowID"].GuidValue());
                sdat["HeaderID"] = new JSON(dtbl.Rows[0]["TDRowID"]);
                sdat["TanggalKunjung"] = new JSON(DData["TglTrf"].DateTimeValue(TBDetail["TglBayar"]));
                sdat["RecordID"] = new JSON(dat["RecordID"].StringValue);
                sdat["HRecordID"] = new JSON(dtbl.Rows[0]["TDRecordID"]);
                sdat["Keterangan"] = new JSON(dat["TD"]["Keterangan"].StringValue);
                sdat["RpInd"] = new JSON(IdenTB["Nominal"]);
                sdat["LastUpdatedBy"] = new JSON(SecurityManager.UserName);
                dat["TSD"] = sdat;

                sdat = new JSON(JSONType.Object);
                sdat["IndenSubDetailID"] = new JSON(DIData["RowID"].GuidValue());
                sdat["IndenSuperDetailID"] = new JSON(dat["RowID"].GuidValue());
                sdat["KartuPiutangID"] = new JSON(dtbl.Rows[0]["KPRowID"]);
                sdat["TanggalJatuhTempo"] = new JSON(dtbl.Rows[0]["KPJTTempo"]);
                sdat["TglBPP"] = new JSON(DIData["TglBPP"].Value);
                sdat["CHBG"] = new JSON(DData["CHBG2"].StringValue);
                sdat["RpNota"] = new JSON(dtbl.Rows[0]["KPRpNota"]);
                sdat["KodeGudang"] = new JSON(GlobalVar.Gudang);
                sdat["IsUser"] = new JSON(SecurityManager.UserName);
                dat["RIS"] = sdat;

                sdat = new JSON(JSONType.Object);
                sdat["RowID"] = new JSON(dat["RowID"].GuidValue());
                sdat["RecordID"] = new JSON(Tools.Right(dat["RecordID"].StringValue.TrimEnd(), 19));
                sdat["BungaDendaTagihanPerTahun"] = new JSON(Convert.ToInt32(AppSetting.GetValue("BungaDendaTagihanpertahun")));
                sdat["Nominal"] = new JSON(IdenTB["Nominal"]);
                sdat["TglJatuhTempo"] = new JSON(dtbl.Rows[0]["KPJTTempo"]);
                sdat["TglBPP"] = new JSON(DIData["TglBPP"].Value);
                sdat["CreatedBy"] = new JSON(SecurityManager.UserName);
                dat["DT"] = sdat;

                return dat;
            }
            else
            {
                if (double.Parse(IdenTB["Nominal"].ToString()) == 0) return new JSON(JSONType.Object);
                string msg = "Transaksi tanggal: " + ((DateTime)DData["TglTransaksi"].DateTimeValue(DateTime.Now)).ToString("dd/MM/yyyy") + ", nominal: " + DData["Nominal"].NumberValue.ToString("#,##0") +
                    "\nIdentifikasi nota pembayaran tidak valid";
                MessageBox.Show(msg);
                return null;
            }
        }

        private bool SavingData()
        {
            if (!validateData()) return false;
            JSON mdat = this.GenerateData0();
            if (mdat == null) return false;
            if (mdat.Type != JSONType.Array) return false;
            if (mdat.Count <= 0)
            {
                MessageBox.Show("Belum ada data yang di pilih");
                return false;
            }

            using (var db = new Database(GlobalVar.DBName))
            using (var db2 = new Database(GlobalVar.DBName))
            {
                db.BeginTransaction();
                db2.BeginTransaction();
                try
                {
                    int ci = 0;
                    DataTable tmpdtbl = new DataTable();
                    for (int i = 0; i < mdat.Count; i++)
                    {
                        JSON dat1 = mdat[i];
                        ci = db.Commands.Count;
                        db.Commands.Add(db.CreateCommand("[usp_IndenDetail_INSERT]"));
                        db.Commands[ci].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@TglTrf", SqlDbType.DateTime, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@CHBG", SqlDbType.VarChar, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@Nomor", SqlDbType.VarChar, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@Ket", SqlDbType.VarChar, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@TglGiro", SqlDbType.DateTime, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@TglJt", SqlDbType.DateTime, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@RpCash", SqlDbType.Money, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@RpGiro", SqlDbType.Money, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@RpTrf", SqlDbType.Money, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@RpCrd", SqlDbType.Money, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@RpDbt", SqlDbType.Money, null));
                        db.Commands[ci].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, null));
                        dat1.CopyToParameterList(db.Commands[ci].Parameters);
                        db.Commands[ci].ExecuteNonQuery();

                        if (dat1.ObjExists("TBC"))
                        {
                            if (dat1["TBC"].Type == JSONType.Array)
                            {
                                for (int i2 = 0; i2 < dat1["TBC"].Count; i2++)
                                {
                                    ci = db.Commands.Count;
                                    db.Commands.Add(db.CreateCommand("[usp_Paycoll_TokoBayarDetail_CLOSING]"));
                                    db.Commands[ci].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, null));
                                    dat1["TBC"][i2].CopyToParameterList(db.Commands[ci].Parameters);
                                    db.Commands[ci].ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                ci = db.Commands.Count;
                                db.Commands.Add(db.CreateCommand("[usp_Paycoll_TokoBayarDetail_CLOSING]"));
                                db.Commands[ci].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, null));
                                dat1["TBC"].CopyToParameterList(db.Commands[ci].Parameters);
                                db.Commands[ci].ExecuteNonQuery();
                            }
                        }

                        switch (dat1["CHBG"].StringValue)
                        {
                            case "":
                                if (dat1.ObjExists("BKM"))
                                {
                                    BKM.AddHeader(
                                        db2,
                                        (Guid)dat1["BKM"]["RowID"].GuidValue(Guid.Empty),
                                        (Guid)dat1["BKM"]["HeaderID"].GuidValue(Guid.Empty),
                                        dat1["BKM"]["RecordID"].StringValue,
                                        dat1["BKM"]["NoBKM"].StringValue,
                                        dat1["BKM"]["JenisBKM"].StringValue,
                                        dat1["BKM"]["Src"].StringValue,
                                        (DateTime)dat1["BKM"]["Tanggal"].DateTimeValue(DateTime.Now),
                                        dat1["BKM"]["Kepada"].StringValue,
                                        dat1["BKM"]["Pembukuan"].StringValue,
                                        dat1["BKM"]["NoAcc"].StringValue,
                                        dat1["BKM"]["Kasir"].StringValue,
                                        dat1["BKM"]["Penerima"].StringValue);
                                }

                                if (dat1.ObjExists("BKMD"))
                                {
                                    BKM.AddDetail(
                                        db2,
                                        (Guid)dat1["BKMD"]["RowID"].GuidValue(Guid.Empty),
                                        (Guid)dat1["BKMD"]["HeaderID"].GuidValue(Guid.Empty),
                                        dat1["BKMD"]["RecordID"].StringValue,
                                        dat1["BKMD"]["HRecordID"].StringValue,
                                        dat1["BKMD"]["BSRecordID"].StringValue,
                                        dat1["BKMD"]["Kode"].StringValue,
                                        dat1["BKMD"]["Sub"].StringValue,
                                        dat1["BKMD"]["NoAcc"].StringValue,
                                        dat1["BKMD"]["NoPerkiraan"].StringValue,
                                        dat1["BKMD"]["Uraian"].StringValue,
                                        dat1["BKMD"]["Nominal"].NumberValue.ToString());
                                }
                                break;

                            case "T":
                                if (dat1.ObjExists("TBNKBBM"))
                                {
                                    TransferBank.addHeader(
                                        db2,
                                        (Guid)dat1["TBNKBBM"]["RowID"].GuidValue(Guid.Empty),
                                        (Guid)dat1["TBNKBBM"]["HeaderID"].GuidValue(Guid.Empty),
                                        dat1["TBNKBBM"]["RecordID"].StringValue,
                                        (DateTime)dat1["TBNKBBM"]["TglBBM"].DateTimeValue(DateTime.Now),
                                        dat1["TBNKBBM"]["NoBBM"].StringValue,
                                        dat1["TBNKBBM"]["MK"].StringValue,
                                        dat1["TBNKBBM"]["BankID"].StringValue,
                                        dat1["TBNKBBM"]["Ket"].StringValue,
                                        dat1["TBNKBBM"]["Pembukuan"].StringValue,
                                        dat1["TBNKBBM"]["Diketahui"].StringValue,
                                        dat1["TBNKBBM"]["Kasir"].StringValue,
                                        dat1["TBNKBBM"]["Penyetor"].StringValue);
                                }

                                if (dat1.ObjExists("TBNKBBK"))
                                {
                                    TransferBank.addHeader(
                                        db2,
                                        (Guid)dat1["TBNKBBK"]["RowID"].GuidValue(Guid.Empty),
                                        (Guid)dat1["TBNKBBK"]["HeaderID"].GuidValue(Guid.Empty),
                                        dat1["TBNKBBK"]["RecordID"].StringValue,
                                        (DateTime)dat1["TBNKBBK"]["TglBBM"].DateTimeValue(DateTime.Now),
                                        dat1["TBNKBBK"]["NoBBM"].StringValue,
                                        dat1["TBNKBBK"]["MK"].StringValue,
                                        dat1["TBNKBBK"]["BankID"].StringValue,
                                        dat1["TBNKBBK"]["Ket"].StringValue,
                                        dat1["TBNKBBK"]["Pembukuan"].StringValue,
                                        dat1["TBNKBBK"]["Diketahui"].StringValue,
                                        dat1["TBNKBBK"]["Kasir"].StringValue,
                                        dat1["TBNKBBK"]["Penyetor"].StringValue);
                                }

                                if (dat1.ObjExists("TBNKDBBM"))
                                {
                                    TransferBank.addDetail(
                                        db2,
                                        (Guid)dat1["TBNKDBBM"]["RowID"].GuidValue(Guid.Empty),
                                        (Guid)dat1["TBNKDBBM"]["HeaderID"].GuidValue(Guid.Empty),
                                        dat1["TBNKDBBM"]["RecordID"].StringValue,
                                        dat1["TBNKDBBM"]["HRecordID"].StringValue,
                                        dat1["TBNKDBBM"]["KodeCollector"].StringValue,
                                        dat1["TBNKDBBM"]["NamaCollector"].StringValue,
                                        dat1["TBNKDBBM"]["NamaBank"].StringValue,
                                        dat1["TBNKDBBM"]["Lokasi"].StringValue,
                                        dat1["TBNKDBBM"]["Nomor"].StringValue,
                                        (DateTime)dat1["TBNKDBBM"]["TglTrans"].DateTimeValue(DateTime.Now),
                                        dat1["TBNKDBBM"]["Nominal"].StringValue,
                                        dat1["TBNKDBBM"]["Titip1"].StringValue,
                                        dat1["TBNKDBBM"]["Titip2"].StringValue,
                                        dat1["TBNKDBBM"]["Piut1"].StringValue,
                                        dat1["TBNKDBBM"]["Piut2"].StringValue,
                                        dat1["TBNKDBBM"]["BankID"].StringValue,
                                        dat1["TBNKDBBM"]["NoPerkiraan"].StringValue,
                                        dat1["TBNKDBBM"]["TitikPerkiraan"].StringValue);
                                }

                                if (dat1.ObjExists("TBNKDBBK"))
                                {
                                    TransferBank.addDetail(
                                        db2,
                                        (Guid)dat1["TBNKDBBK"]["RowID"].GuidValue(Guid.Empty),
                                        (Guid)dat1["TBNKDBBK"]["HeaderID"].GuidValue(Guid.Empty),
                                        dat1["TBNKDBBK"]["RecordID"].StringValue,
                                        dat1["TBNKDBBK"]["HRecordID"].StringValue,
                                        dat1["TBNKDBBK"]["KodeCollector"].StringValue,
                                        dat1["TBNKDBBK"]["NamaCollector"].StringValue,
                                        dat1["TBNKDBBK"]["NamaBank"].StringValue,
                                        dat1["TBNKDBBK"]["Lokasi"].StringValue,
                                        dat1["TBNKDBBK"]["Nomor"].StringValue,
                                        (DateTime)dat1["TBNKDBBK"]["TglTrans"].DateTimeValue(DateTime.Now),
                                        dat1["TBNKDBBK"]["Nominal"].StringValue,
                                        dat1["TBNKDBBK"]["Titip1"].StringValue,
                                        dat1["TBNKDBBK"]["Titip2"].StringValue,
                                        dat1["TBNKDBBK"]["Piut1"].StringValue,
                                        dat1["TBNKDBBK"]["Piut2"].StringValue,
                                        dat1["TBNKDBBK"]["BankID"].StringValue,
                                        dat1["TBNKDBBK"]["NoPerkiraan"].StringValue,
                                        dat1["TBNKDBBK"]["TitikPerkiraan"].StringValue);
                                }

                                if (dat1.ObjExists("BNKDBBM"))
                                {
                                    Bank.AddBankDetail(
                                        db2,
                                        (Guid)dat1["BNKDBBM"]["RowID"].GuidValue(Guid.Empty),
                                        (Guid)dat1["BNKDBBM"]["LinkBankID"].GuidValue(Guid.Empty),
                                        dat1["BNKDBBM"]["NoBBK"].StringValue,
                                        dat1["BNKDBBM"]["NoBGCH"].StringValue,
                                        (Guid)dat1["BNKDBBM"]["HeaderID"].GuidValue(Guid.Empty),
                                        dat1["BNKDBBM"]["RegID"].StringValue,
                                        (DateTime)dat1["BNKDBBM"]["TglTrans"].DateTimeValue(DateTime.Now),
                                        dat1["BNKDBBM"]["JnsTrans"].StringValue,
                                        dat1["BNKDBBM"]["Ket"].StringValue,
                                        dat1["BNKDBBM"]["VTA"].StringValue,
                                        dat1["BNKDBBM"]["Debet"].StringValue,
                                        dat1["BNKDBBM"]["Kredit"].StringValue,
                                        (DateTime)dat1["BNKDBBM"]["TglBank"].DateTimeValue(DateTime.Now),
                                        (DateTime)dat1["BNKDBBM"]["TglRK"].DateTimeValue(DateTime.Now),
                                        dat1["BNKDBBM"]["LinkRK"].StringValue,
                                        dat1["BNKDBBM"]["Kode"].StringValue,
                                        dat1["BNKDBBM"]["Sub"].StringValue,
                                        dat1["BNKDBBM"]["Catatan"].StringValue,
                                        dat1["BNKDBBM"]["NoPerkiraan"].StringValue,
                                        dat1["BNKDBBM"]["BankID"].StringValue,
                                        dat1["BNKDBBM"]["RecordID"].StringValue);
                                }

                                if (dat1.ObjExists("BNKDBBK"))
                                {
                                    Bank.AddBankDetail(
                                        db2,
                                        (Guid)dat1["BNKDBBK"]["RowID"].GuidValue(Guid.Empty),
                                        (Guid)dat1["BNKDBBK"]["LinkBankID"].GuidValue(Guid.Empty),
                                        dat1["BNKDBBK"]["NoBBK"].StringValue,
                                        dat1["BNKDBBK"]["NoBGCH"].StringValue,
                                        (Guid)dat1["BNKDBBK"]["HeaderID"].GuidValue(Guid.Empty),
                                        dat1["BNKDBBK"]["RegID"].StringValue,
                                        (DateTime)dat1["BNKDBBK"]["TglTrans"].DateTimeValue(DateTime.Now),
                                        dat1["BNKDBBK"]["JnsTrans"].StringValue,
                                        dat1["BNKDBBK"]["Ket"].StringValue,
                                        dat1["BNKDBBK"]["VTA"].StringValue,
                                        dat1["BNKDBBK"]["Debet"].StringValue,
                                        dat1["BNKDBBK"]["Kredit"].StringValue,
                                        (DateTime)dat1["BNKDBBK"]["TglBank"].DateTimeValue(DateTime.Now),
                                        (DateTime)dat1["BNKDBBK"]["TglRK"].DateTimeValue(DateTime.Now),
                                        dat1["BNKDBBK"]["LinkRK"].StringValue,
                                        dat1["BNKDBBK"]["Kode"].StringValue,
                                        dat1["BNKDBBK"]["Sub"].StringValue,
                                        dat1["BNKDBBK"]["Catatan"].StringValue,
                                        dat1["BNKDBBK"]["NoPerkiraan"].StringValue,
                                        dat1["BNKDBBK"]["BankID"].StringValue,
                                        dat1["BNKDBBK"]["RecordID"].StringValue);
                                }
                                break;

                            case "G":
                                if (dat1.ObjExists("VJ"))
                                {
                                    VoucherJournal.AddHeader(
                                        db2,
                                        (Guid)dat1["VJ"]["RowID"].GuidValue(Guid.Empty),
                                        (Guid)dat1["VJ"]["HeaderID"].GuidValue(Guid.Empty),
                                        dat1["VJ"]["RecordID"].StringValue,
                                        dat1["VJ"]["Type"].StringValue,
                                        (DateTime)dat1["VJ"]["TglVoucher"].DateTimeValue(DateTime.Now),
                                        dat1["VJ"]["NoVoucher"].StringValue,
                                        dat1["VJ"]["Uraian1"].StringValue,
                                        dat1["VJ"]["Uraian2"].StringValue,
                                        dat1["VJ"]["Uraian3"].StringValue,
                                        dat1["VJ"]["Pembuat"].StringValue,
                                        dat1["VJ"]["Pembukuan"].StringValue,
                                        dat1["VJ"]["Mengetahui"].StringValue,
                                        dat1["VJ"]["BankID"].StringValue,
                                        dat1["VJ"]["NamaBank"].StringValue,
                                        (int)dat1["VJ"]["NPrint"].NumberValue,
                                        dat1["VJ"]["SynchFlag"].BoolValue);
                                }

                                if (dat1.ObjExists("GD"))
                                {
                                    Giro.Add(
                                        db2,
                                        (Guid)dat1["GD"]["RowID"].GuidValue(Guid.Empty),
                                        (Guid)dat1["GD"]["HeaderID"].GuidValue(Guid.Empty),
                                        (Guid)dat1["GD"]["BBMID"].GuidValue(Guid.Empty),
                                        (Guid)dat1["GD"]["TitipID"].GuidValue(Guid.Empty),
                                        dat1["GD"]["VoucherRecID"].StringValue,
                                        dat1["GD"]["BBMRecID"].StringValue,
                                        dat1["GD"]["TitipRecID"].StringValue,
                                        dat1["GD"]["GiroRecID"].StringValue,
                                        dat1["GD"]["KodeToko"].StringValue,
                                        dat1["GD"]["NamaBank"].StringValue,
                                        dat1["GD"]["Lokasi"].StringValue,
                                        dat1["GD"]["CHBG"].StringValue,
                                        dat1["GD"]["Nomor"].StringValue,
                                        (DateTime)dat1["GD"]["TglGiro"].DateTimeValue(DateTime.Now),
                                        (DateTime)dat1["GD"]["TglTempo"].DateTimeValue(),
                                        dat1["GD"]["Nominal"].NumberValue,
                                        dat1["GD"]["CairTolak"].StringValue,
                                        dat1["GD"]["TglCair"].DateTimeValue(null),
                                        dat1["GD"]["Titip1"].StringValue,
                                        dat1["GD"]["Titip2"].StringValue,
                                        dat1["GD"]["Piut1"].StringValue,
                                        dat1["GD"]["Piut2"].StringValue,
                                        dat1["GD"]["BankID"].StringValue,
                                        dat1["GD"]["NamaBanki"].StringValue,
                                        dat1["GD"]["NoPerkiraan"].StringValue,
                                        dat1["GD"]["TglTitip"].DateTimeValue(null),
                                        dat1["GD"]["SynchFlag"].BoolValue,
                                        dat1["GD"]["NoAcc"].StringValue,
                                        dat1["GD"]["TitikPerkiraan"].StringValue);
                                }

                                if (dat1.ObjExists("GiroAttach"))
                                {
                                    string _fdir = AppSetting.GetValue("LokasiSimpanScanGiro"),
                                           _fpath = _fdir + "\\" + String.Format(
                                                "{0}{1:yyyyMMdd}{2}",
                                                GlobalVar.Gudang,
                                                (DateTime)dat1["TglGiro"].DateTimeValue(DateTime.Now),
                                                dat1["Nomor"].StringValue) + ".jpg";

                                    if (!System.IO.Directory.Exists(_fdir)) System.IO.Directory.CreateDirectory(_fdir);
                                    ((Image)dat1["GiroAttach"].Value).Save(_fpath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                }
                                break;
                        }

                        for (int i2 = 0; i2 < dat1["Iden"].Count; i2++)
                        {
                            JSON dat2 = dat1["Iden"][i2];
                            ci = db.Commands.Count;

                            db.Commands.Add(db.CreateCommand("[usp_IndenSubDetail_INSERT]"));
                            db.Commands[ci].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, null));
                            db.Commands[ci].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, null));
                            db.Commands[ci].Parameters.Add(new Parameter("@IndenID", SqlDbType.UniqueIdentifier, null));
                            db.Commands[ci].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, null));
                            db.Commands[ci].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, null));
                            db.Commands[ci].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, null));
                            db.Commands[ci].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, null));
                            db.Commands[ci].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, null));
                            db.Commands[ci].Parameters.Add(new Parameter("@NoBPP", SqlDbType.VarChar, null));
                            db.Commands[ci].Parameters.Add(new Parameter("@TglBPP", SqlDbType.DateTime, null));
                            db.Commands[ci].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, null));
                            db.Commands[ci].Parameters.Add(new Parameter("@RpNominal", SqlDbType.Money, null));
                            db.Commands[ci].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, null));
                            dat2.CopyToParameterList(db.Commands[ci].Parameters);
                            db.Commands[ci].ExecuteNonQuery();

                            if (dat2["GIRO"].Type != JSONType.Null)
                            {
                                ci = db.Commands.Count;
                                db.Commands.Add(db.CreateCommand("[usp_Giro_UPDATE]"));
                                db.Commands[ci].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, null));
                                dat2["GIRO"].CopyToParameterList(db.Commands[ci].Parameters);
                                db.Commands[ci].ExecuteNonQuery();
                            }

                            for (int i3 = 0; i3 < dat2["SubIden"].Count; i3++)
                            {
                                JSON dat3 = dat2["SubIden"][i3];
                                ci = db.Commands.Count;

                                db.Commands.Add(db.CreateCommand("[usp_IndenSuperDetail_INSERT]"));
                                db.Commands[ci].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@IndenID", SqlDbType.UniqueIdentifier, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@IndenDetailID", SqlDbType.UniqueIdentifier, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@TagihDetailID", SqlDbType.UniqueIdentifier, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@TagihDetailRecID", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@KPID", SqlDbType.UniqueIdentifier, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@KPRecID", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@TglBPP", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@TglInden", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@TglJatuhTempo", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@NoPerk", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@RpInden", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@RpNota", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@RpTagih", SqlDbType.VarChar, null));
                                //db.Commands[ci].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, null));
                                //db.Commands[ci].Parameters.Add(new Parameter("@PublicKey", SqlDbType.VarChar, null));
                                dat3.CopyToParameterList(db.Commands[ci].Parameters);
                                db.Commands[ci].ExecuteNonQuery();

                                ci = db.Commands.Count;
                                db.Commands.Add(db.CreateCommand("[usp_KartuPiutangDetail_Insert]"));
                                db.Commands[ci].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@TglJTGiro", SqlDbType.DateTime, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@NoBuktiKasMasuk", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, null));
                                dat3["KP"].CopyToParameterList(db.Commands[ci].Parameters);
                                db.Commands[ci].ExecuteNonQuery();

                                ci = db.Commands.Count;
                                db.Commands.Add(db.CreateCommand("[usp_TagihanDetail_UPDATE]"));
                                db.Commands[ci].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@TglInden", SqlDbType.DateTime, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, null));
                                dat3["TD"].CopyToParameterList(db.Commands[ci].Parameters);
                                db.Commands[ci].ExecuteNonQuery();

                                ci = db.Commands.Count;
                                db.Commands.Add(db.CreateCommand("[usp_TagihanSubDetail_INSERT]"));
                                db.Commands[ci].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@TanggalKunjung", SqlDbType.DateTime, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@RpInd", SqlDbType.Money, null));
                                db.Commands[ci].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, null));
                                dat3["TSD"].CopyToParameterList(db.Commands[ci].Parameters);
                                db.Commands[ci].ExecuteNonQuery();

                                if (dat3["RpTagih"].NumberValue == dat3["RpInden"].NumberValue)
                                {
                                    ci = db.Commands.Count;
                                    db.Commands.Add(db.CreateCommand("[usp_RewardIdenSuperDetail]"));
                                    db.Commands[ci].Parameters.Add(new Parameter("@IndenSubDetailID", SqlDbType.UniqueIdentifier, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@IndenSuperDetailID", SqlDbType.UniqueIdentifier, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@KartuPiutangID", SqlDbType.UniqueIdentifier, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@TanggalJatuhTempo", SqlDbType.Date, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@TglBPP", SqlDbType.Date, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@CHBG", SqlDbType.VarChar, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@RpNota", SqlDbType.Money, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@IsUser", SqlDbType.VarChar, null));
                                    dat3["RIS"].CopyToParameterList(db.Commands[ci].Parameters);
                                    db.Commands[ci].ExecuteNonQuery();
                                }

                                if (dat3["Src"].StringValue != "DT" && (dat1["CHBG"].StringValue == "KAS" || dat1["CHBG"].StringValue == "TRN"))
                                {
                                    ci = db.Commands.Count;
                                    db.Commands.Add(db.CreateCommand("[usp_DendaTagihan_INSERT_TK]"));
                                    db.Commands[ci].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@BungaDendaTagihanPerTahun", SqlDbType.Int, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@TglJatuhTempo", SqlDbType.DateTime, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@TglBPP", SqlDbType.DateTime, null));
                                    db.Commands[ci].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, null));
                                    dat3["DT"].CopyToParameterList(db.Commands[ci].Parameters);
                                    db.Commands[ci].ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    db.CommitTransaction();
                    db2.CommitTransaction();
                    return true;
                }
                catch (Exception ex)
                {
                    db.RollbackTransaction();
                    db2.RollbackTransaction();

                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }
        #endregion

        #region "GV Manipulate"
        InPopup ipBankTujuan, ipAccGiro, /*ipTglRK, */ipDetail, ipKoreksi;
        private void GV01_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender.Equals(GV01))
            {
                if (GV01.Columns[e.ColumnIndex].DataPropertyName == "Check" && e.RowIndex >= 0)
                {
                    DataRow[] rows;
                    DataGridViewRow crow = GV01.Rows[e.RowIndex];
                    if (crow.Cells["colStatusCode"].Value.ToString() != "1") return;
                    bool cstat = !(bool.Parse(crow.Cells[e.ColumnIndex].Value.ToString()));
                    crow.Cells[e.ColumnIndex].Value = cstat;

                    if (cstat)
                    {
                        _lists.Rows.Add(new object[] {
                            crow.Cells["colRowID"].Value,
                            crow.Cells["colHeaderRowID"].Value,
                            crow.Cells["colKodeCollector"].Value,
                            crow.Cells["colKodeToko"].Value,
                            crow.Cells["colJnsTransaksi"].Value,
                            crow.Cells["colTglTransaksi"].Value,
                            crow.Cells["colNominal"].Value,
                            crow.Cells["colNominalIden"].Value,
                            crow.Cells["colBankRowID"].Value,
                            (
                                crow.Cells["colBankRowID"].Value != DBNull.Value ?
                                (
                                    crow.Cells["colJnsTransaksi"].Value.ToString() == "BGC" ?
                                    crow.Cells["colBank"].Value :
                                    crow.Cells["colBGTujuanUI"].Value
                                ) :
                                DBNull.Value
                            ),
                            crow.Cells["colBankID"].Value,
                            crow.Cells["colAccGiro"].Value,
                            crow.Cells["colTglRK"].Value,
                            ""
                        });
                        foreach (DataGridViewRow gr in GV02.Rows)
                        {
                            DataRow[] rows2 = _idenLists.Select("RowID = '" + gr.Cells["coldRowID"].Value.ToString() + "' AND HeaderRowID = '" + crow.Cells["colRowID"].Value.ToString() + "'");
                            if (rows2.Length <= 0)
                            {
                                _idenLists.Rows.Add(new object[] {
                                    gr.Cells["coldRowID"].Value,
                                    crow.Cells["colRowID"].Value,
                                    gr.Cells["coldIdenRowID"].Value,
                                    double.Parse(gr.Cells["coldNominalIden2"].Value.ToString()),
                                    int.Parse(gr.Cells["coldSFID"].Value.ToString()),
                                    DateTime.Parse(gr.Cells["coldTglIden"].Value.ToString())
                                });
                            }
                        }
                    }
                    else
                    {
                        rows = _lists.Select("RowID = '" + crow.Cells["colRowID"].Value.ToString() + "'");
                        foreach (DataRow cr in rows) _lists.Rows.Remove(cr);
                    }
                    CalcTotal();

                }
                else if ((GV01.Columns[e.ColumnIndex].Name == "colBGTujuanUI" || GV01.Columns[e.ColumnIndex].Name == "colTglRKUI") && e.RowIndex >= 0)
                {
                    DataGridViewRow crow = GV01.Rows[e.RowIndex];
                    bool cstat = bool.Parse(crow.Cells["colCheck"].Value.ToString());
                    DateTime tglrk = DateTime.Now;

                    if (cstat)
                    {
                        string jnst = crow.Cells["colJnsTransaksi"].Value.ToString();
                        DataRow[] rs = _lists.Select("RowID = '" + crow.Cells["colRowID"].Value.ToString() + "'");
                        if (rs.Length > 0 && rs[0]["TglRK"] != null && rs[0]["TglRK"] != DBNull.Value) tglrk = (DateTime)rs[0]["TglRK"];

                        switch (jnst)
                        {
                            case "TRN":
                            case "BNK":
                                if (jnst == "BNK" && BGTWhitelist.IndexOf(new Guid(crow.Cells["colRowID"].Value.ToString())) < 0) return;
                                txtPopCatatan.Enabled = datepPopBank.Enabled = (jnst != "BNK");
                                datepPopBank.Value = tglrk;

                                txtPopCatatan.Text = "";
                                if (jnst == "TRN") txtPopCatatan.Text = crow.Cells["colCatatan"].Value.ToString();

                                if (ipBankTujuan == null) ipBankTujuan = new InPopup(this, pnlPopBank);
                                if (crow.Cells["colBankRowID"].Value != null && crow.Cells["colBankRowID"].Value.ToString() != "")
                                {
                                    lookupPopBank.Set(new Guid(crow.Cells["colBankRowID"].Value.ToString()));
                                }
                                else lookupPopBank.Set();
                                if (crow.Cells["colNoDKN"].Value != null && crow.Cells["colNoDKN"].Value.ToString() != "")
                                {
                                    lookupDKN1.Set(crow.Cells["colNoDKN"].Value.ToString());
                                }
                                else lookupDKN1.Set();
                                ipBankTujuan.Open(this, (a) =>
                                {
                                    if (a)
                                    {
                                        tglrk = datepPopGiro.Value;
                                        List<Parameter> pars = new List<Parameter>(new Parameter[] {
                                            new Parameter("@BankRowID", SqlDbType.UniqueIdentifier, lookupPopBank.RowID),
                                            new Parameter("@TglRK", SqlDbType.Date, tglrk)
                                        });
                                        if (jnst == "TRN" || jnst == "BNK")
                                        {
                                            txtPopCatatan.Text = txtPopCatatan.Text.Trim();
                                            pars.Add(new Parameter("@Catatan", SqlDbType.VarChar, txtPopCatatan.Text));
                                            pars.Add(new Parameter("@NoDKN", SqlDbType.VarChar, lookupDKN1.NoDKN));
                                        }
                                        this.SaveState("TokoBayarDetail", new Guid(crow.Cells["colRowID"].Value.ToString()), pars.ToArray());

                                        foreach (DataRow dr in rs)
                                        {
                                            dr["BankRowID"] = lookupPopBank.RowID;
                                            dr["NamaBank"] = lookupPopBank.NamaBank;
                                            dr["BankID"] = lookupPopBank.BankID;
                                            dr["TglRK"] = tglrk;
                                        }
                                        crow.Cells["colBGTujuanUI"].Value = lookupPopBank.NamaBank;
                                        crow.Cells["colBankRowID"].Value = lookupPopBank.RowID;
                                        crow.Cells["colBankID"].Value = lookupPopBank.BankID;
                                        crow.Cells["colTglRKUI"].Value = tglrk.ToString("dd-MM-yyyy");
                                        crow.Cells["colCatatan"].Value = txtPopCatatan.Text;
                                        crow.Cells["colTglRK"].Value = tglrk;
                                    }
                                });
                                break;

                            case "BGC":
                                txtPopGiroAttachPath.Text = "";
                                if (picPopGiroAttach.Image != null) picPopGiroAttach.Image = null;
                                datepPopGiro.Value = GlobalVar.DateOfServer;
                                picPopGiroAttach.Tag = -1;

                                datepPopGiroJT.Value = DateTime.Parse(crow.Cells["colTglJTBGC"].Value.ToString());
                                datepPopGiroJT.Enabled = (datepPopGiroJT.Value < GlobalVar.DateOfServer);

                                using (var db = new Database(GlobalVar.DBName))
                                {
                                    db.Commands.Add(db.CreateCommand("[usp_Paycoll_TokoBayarDetail_LIST_State]"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, new Guid(crow.Cells["colRowID"].Value.ToString())));
                                    DataTable dtbl = db.Commands[0].ExecuteDataTable();

                                    if (dtbl.Rows.Count > 0)
                                    {
                                        try
                                        {
                                            picPopGiroAttach.Image = null;
                                            if (dtbl.Rows[0]["GiroAttach"] != DBNull.Value && dtbl.Rows[0]["GiroAttach"] != null)
                                            {
                                                picPopGiroAttach.Image = null;
                                                using (var ms = new System.IO.MemoryStream((byte[])dtbl.Rows[0]["GiroAttach"]))
                                                {
                                                    picPopGiroAttach.Image = Image.FromStream(ms);
                                                }
                                                picPopGiroAttach.Tag = 1;
                                            }
                                            else if (dtbl.Rows[0]["Attachment"] != DBNull.Value && dtbl.Rows[0]["Attachment"] != null)
                                            {
                                                string txt = dtbl.Rows[0]["Attachment"].ToString().Replace("\\", "");
                                                if (txt.Length > 0)
                                                {
                                                    byte[] bys = System.Convert.FromBase64String(txt);
                                                    using (var mem = new System.IO.MemoryStream(bys)) picPopGiroAttach.Image = Image.FromStream(mem);
                                                }
                                                picPopGiroAttach.Tag = 0;
                                            }
                                        }
                                        catch (Exception) { }
                                    }
                                }

                                DataRow[] rs2 = _lists.Select("RowID = '" + crow.Cells["colRowID"].Value.ToString() + "'");
                                if (rs2.Length > 0) txtPopGiroAttachPath.Text = rs2[0]["GiroAttachPath"].ToString();

                                ltokoPopGiro.Enabled = (crow.Cells["colAllowSetToko"].Value.ToString() == "1");
                                ltokoPopGiro.InitToko(crow.Cells["colKodeToko"].Value.ToString());

                                if (crow.Cells["colBankRowID"].Value != null && crow.Cells["colBankRowID"].Value.ToString() != "")
                                {
                                    lbnkPopGiro.Set(new Guid(crow.Cells["colBankRowID"].Value.ToString()));
                                }
                                else lbnkPopGiro.Set();

                                if (ipAccGiro == null) ipAccGiro = new InPopup(this, pnlPopGiro);
                                if (crow.Cells["colAccGiro"].Value != null && crow.Cells["colAccGiro"].Value.ToString() != "")
                                {
                                    txtPopGiro.Text = crow.Cells["colAccGiro"].Value.ToString();
                                }
                                else txtPopGiro.Text = "";
                                ipAccGiro.Tag = crow.Cells["colKodeToko"].Value.ToString();
                                ipAccGiro.Open(this, (a) =>
                                {
                                    if (a)
                                    {
                                        tglrk = datepPopGiro.Value;
                                        byte[] img = new byte[] {};
                                        if (picPopGiroAttach.Tag != null && (picPopGiroAttach.Tag.Equals(1)))
                                        {
                                            ImageConverter ic = new ImageConverter();
                                            img = (byte[])ic.ConvertTo(picPopGiroAttach.Image, typeof(byte[]));
                                        }

                                        List<Parameter> pars = new List<Parameter>();
                                        pars.AddRange(new Parameter[] {
                                            new Parameter("@GiroAccount", SqlDbType.VarChar, txtPopGiro.Text),
                                            new Parameter("@BankRowID", SqlDbType.UniqueIdentifier, lbnkPopGiro.RowID),
                                            new Parameter("@TglRK", SqlDbType.Date, tglrk)
                                        });
                                        if (img.Length > 0) pars.Add(new Parameter("@GiroAttach", SqlDbType.Image, img));
                                        if (ltokoPopGiro.Enabled) pars.Add(new Parameter("@KodeToko", SqlDbType.VarChar, ltokoPopGiro.KodeToko));
                                        if (datepPopGiroJT.Enabled) pars.Add(new Parameter("@TglJTBGC", SqlDbType.Date, datepPopGiroJT.Value));
                                        this.SaveState("TokoBayarDetail", new Guid(crow.Cells["colRowID"].Value.ToString()), pars.ToArray());

                                        foreach (DataRow dr in rs2)
                                        {
                                            dr["GiroAttachPath"] = txtPopGiroAttachPath.Text;
                                            if (ltokoPopGiro.Enabled) dr["KodeToko"] = ltokoPopGiro.KodeToko;
                                            dr["BankRowID"] = lbnkPopGiro.RowID;
                                            dr["NamaBank"] = lbnkPopGiro.NamaBank;
                                            dr["BankID"] = lbnkPopGiro.Lokasi;
                                            dr["AccBGC"] = txtPopGiro.Text;
                                            dr["TglRK"] = tglrk;
                                        }

                                        crow.Cells["colBGTujuanUI"].Value = txtPopGiro.Text;
                                        crow.Cells["colAccGiro"].Value = txtPopGiro.Text;
                                        crow.Cells["colBank"].Value = lbnkPopGiro.NamaBank;
                                        crow.Cells["colBankRowID"].Value = lbnkPopGiro.RowID;
                                        crow.Cells["colBankID"].Value = lbnkPopGiro.Lokasi;
                                        crow.Cells["colTglRKUI"].Value = tglrk.ToString("dd-MM-yyyy");
                                        crow.Cells["colTglJTBGC"].Value = datepPopGiroJT.Value;
                                        crow.Cells["colTglRK"].Value = tglrk;
                                        if (ltokoPopGiro.Enabled)
                                        {
                                            crow.Cells["colKodeToko"].Value = ltokoPopGiro.KodeToko;
                                            crow.Cells["colNamaToko"].Value = ltokoPopGiro.NamaToko;

                                            _iGV02 = -1;
                                            this.RefreshGV02();
                                        }
                                    }
                                });
                                break;
                        }
                    }

                }
                else if (GV01.Columns[e.ColumnIndex].Name == "colNominalKoreksi" && e.RowIndex >= 0)
                {
                    DataGridViewRow crow = GV01.Rows[e.RowIndex];
                    bool cstat = bool.Parse(crow.Cells["colCheck"].Value.ToString());

                    if (cstat)
                    {
                        if (ipKoreksi == null) ipKoreksi = new InPopup(this, pnlPopKoreksi);

                        JSON dat = new JSON(JSONType.Object);
                        dat["Nominal"] = new JSON(double.Parse(crow.Cells["colNominalColes"].Value.ToString()));
                        dat["Max"] = new JSON(double.Parse(crow.Cells["colNominalIden"].Value.ToString()));
                        ipKoreksi.Tag = dat;

                        txtPopNomKoreksi.Text = crow.Cells["colNominalKoreksi"].Value.ToString();
                        txtPopNomFinal.Text = (dat["Nominal"].NumberValue + double.Parse(txtPopNomKoreksi.Text)).ToString("#,##0");
                        txtPopKetKoreksi.Text = crow.Cells["colKetKoreksi"].Value.ToString();

                        ipKoreksi.Open(this, (a) =>
                        {
                            if (a)
                            {
                                double nom = double.Parse(txtPopNomKoreksi.Text);
                                using (var db = new Database(GlobalVar.DBName))
                                {
                                    db.Commands.Add(db.CreateCommand("[usp_Paycoll_TokoBayarDetail_UPDATE_Koreksi]"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, crow.Cells["colRowID"].Value));
                                    db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, nom));
                                    db.Commands[0].Parameters.Add(new Parameter("@Ket", SqlDbType.VarChar, txtPopKetKoreksi.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@ByUser", SqlDbType.VarChar, SecurityManager.UserID));
                                    db.Commands[0].ExecuteNonQuery();
                                }

                                DataRow[] rows = _lists.Select("RowID = '" + crow.Cells["colRowID"].Value.ToString() + "'");
                                if (rows.Length > 0)
                                {
                                    double nom2 = double.Parse(crow.Cells["colNominalColes"].Value.ToString()) + nom;
                                    double nom3 = double.Parse(crow.Cells["colNominalIden"].Value.ToString()) + nom;
                                    foreach (DataRow row in rows)
                                    {
                                        row["Nominal"] = nom2;
                                        row["NominalIden"] = nom3;
                                    }

                                    crow.Cells["colNominalKoreksi"].Value = nom;
                                    crow.Cells["colTglKoreksi"].Value = DateTime.Now;
                                    crow.Cells["colKetKoreksi"].Value = txtPopKetKoreksi.Text;
                                    crow.Cells["colNominal"].Value = nom2;

                                    rows = _idenLists.Select("HeaderRowID = '" + crow.Cells["colRowID"].Value.ToString() + "'");
                                    foreach (DataRow row in rows)
                                    {
                                        double nomc = double.Parse(row["Nominal"].ToString());
                                        if (nom3 < nomc) nomc = nom3;
                                        row["Nominal"] = nomc;
                                        nom3 -= nomc;
                                    }

                                    _iGV02 = -1;
                                    this.RefreshGV02();
                                }
                            }
                        });
                    }

                }
                else if (GV01.Columns[e.ColumnIndex].Name == "colActions" && e.RowIndex >= 0)
                {
                    DataGridViewRow crow = GV01.Rows[e.RowIndex];

                    switch (crow.Cells["colJnsTransaksi"].Value.ToString())
                    {
                        case "BNK":
                            using (var db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("[usp_Paycoll_SetorUang_LIST]"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, crow.Cells["colRowID"].Value));
                                DataTable dtbl = db.Commands[0].ExecuteDataTable();

                                if (dtbl.Rows.Count > 0)
                                {
                                    try
                                    {
                                        string txt = "";
                                        Image img = null;
                                        byte[] bys = new byte[] { };
                                        if (dtbl.Rows[0]["BuktiTransfer"] != DBNull.Value)
                                        {
                                            try
                                            {
                                                txt = dtbl.Rows[0]["BuktiTransfer"].ToString().Replace("\\", ""); ;
                                                bys = System.Convert.FromBase64String(txt);
                                                using (var mem = new System.IO.MemoryStream(bys)) img = Image.FromStream(mem);
                                                txt = "Foto Bukti Transfer";
                                            }
                                            catch (Exception ex) {
                                                MessageBox.Show("Error: " + ex.Message);
                                            }
                                        }
                                        picPopDetail01.Image = img;
                                        lblPopDetail.Text = (txt.Length > 0 ? txt : "Foto");

                                        if (ipDetail == null) ipDetail = new InPopup(this, pnlPopDetail);
                                        ipDetail.Open(this);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message);
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            else if (sender.Equals(GV03))
            {
                if (GV03.Columns[e.ColumnIndex].Name == "col2Actions" && e.RowIndex >= 0)
                {
                    DataGridViewRow crow = GV03.Rows[e.RowIndex];

                    using (var db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_Paycoll_TokoBayar_LIST]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, crow.Cells["col2RowID"].Value));
                        DataTable dtbl = db.Commands[0].ExecuteDataTable();

                        if (dtbl.Rows.Count > 0)
                        {
                            try
                            {
                                string txt = "";
                                Image img = null;
                                byte[] bys = new byte[] { };
                                if (dtbl.Rows[0]["TTD"] != DBNull.Value)
                                {
                                    try
                                    {
                                        txt = dtbl.Rows[0]["TTD"].ToString().Replace("\\", "");
                                        bys = System.Convert.FromBase64String(txt);
                                        using (var mem = new System.IO.MemoryStream(bys)) img = Image.FromStream(mem);
                                        txt = "Foto Tanda Tangan";
                                    }
                                    catch (Exception ex) {
                                        MessageBox.Show("Error: " + ex.Message);
                                    }
                                }
                                if (dtbl.Rows[0]["Foto"] != DBNull.Value)
                                {
                                    try
                                    {
                                        txt = dtbl.Rows[0]["Foto"].ToString().Replace("\\", "");
                                        bys = System.Convert.FromBase64String(txt);
                                        using (var mem = new System.IO.MemoryStream(bys)) img = Image.FromStream(mem);
                                        txt = "Foto Verifikasi";
                                    }
                                    catch (Exception ex) {
                                        MessageBox.Show("Error: " + ex.Message);
                                    }
                                }
                                picPopDetail01.Image = img;
                                lblPopDetail.Text = (txt.Length > 0 ? txt : "Foto");

                                if (ipDetail == null) ipDetail = new InPopup(this, pnlPopDetail);
                                ipDetail.Open(this);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                    }
                }
            }
            else if (sender.Equals(GV04))
            {
                if (GV04.Columns[e.ColumnIndex].Name == "col3Actions" && e.RowIndex >= 0)
                {
                    DataGridViewRow crow = GV04.Rows[e.RowIndex];

                    using (var db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_Paycoll_HasilTagihan_LIST]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, crow.Cells["col3RowID"].Value));
                        DataTable dtbl = db.Commands[0].ExecuteDataTable();

                        if (dtbl.Rows.Count > 0)
                        {
                            try
                            {
                                string txt = "";
                                Image img = null;
                                byte[] bys = new byte[] { };
                                if (dtbl.Rows[0]["Attachment"] != DBNull.Value)
                                {
                                    try
                                    {
                                        txt = dtbl.Rows[0]["Attachment"].ToString().Replace("\\","");
                                        bys = System.Convert.FromBase64String(txt);
                                        using (var mem = new System.IO.MemoryStream(bys)) img = Image.FromStream(mem);
                                        switch (dtbl.Rows[0]["TypeAttachment"].ToString())
                                        {
                                            case "FOTO":
                                                txt = "Foto Verifikasi";
                                                break;
                                            case "TTD":
                                                txt = "Foto Tanda Tangan";
                                                break;
                                            default:
                                                txt = "";
                                                break;
                                        }
                                    }
                                    catch (Exception ex) {
                                        MessageBox.Show("Error : " + ex.Message);
                                    }
                                }
                                picPopDetail01.Image = img;
                                lblPopDetail.Text = (txt.Length > 0 ? txt : "Foto");

                                if (ipDetail == null) ipDetail = new InPopup(this, pnlPopDetail);
                                ipDetail.Open(this);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                    }
                }
            }
        }

        private void SaveState(string tbn, Guid id, string coln, SqlDbType typ, object val)
        {
            this.SaveState(tbn, id, new Parameter[] { new Parameter("@" + coln, typ, val) });
        }
        private void SaveState(string tbn, Guid id, Parameter[] pars)
        {
            using (var db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("[usp_Paycoll_" + tbn + "_UPDATE_State]"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, id));
                foreach (Parameter p in pars) db.Commands[0].Parameters.Add(p);
                db.Commands[0].ExecuteNonQuery();
            }
        }

        private void GV01_SelectionChanged(object sender, EventArgs e)
        {
            RefreshGV02();
        }

        private void btnPop_Clicked(object sender, EventArgs e)
        {
            if (sender.Equals(btnPopBankOK))
            {
                if (lookupPopBank.RowID == Guid.Empty)
                {
                    MessageBox.Show("Bank masih kosong");
                    return;
                }
                if (lookupDKN1.NoDKN == "")
                {
                    MessageBox.Show("No DKN masih kosong");
                    return;
                }

                string _jml = GV01.SelectedCells[0].OwningRow.Cells["colNominal"].Value.ToString();
                if (txtTotalDKN.Text != "0")
                {
                    if (txtTotalDKN.GetDoubleValue != double.Parse(lookupDKN1.Jumlah))
                    {
                        MessageBox.Show("Nominal transfer: " + txtTotalDKN.GetDoubleValue + " tidak sesuai dengan Total DKN: " + double.Parse(lookupDKN1.Jumlah));
                        return;
                    }
                }
                else {
                    if (double.Parse(lookupDKN1.Jumlah) != double.Parse(_jml))
                    {
                        MessageBox.Show("Nominal transfer: " + double.Parse(_jml) + " tidak sesuai dengan Total DKN: " + double.Parse(lookupDKN1.Jumlah));
                        return;
                    }
                }

                ipBankTujuan.Close(true);

            }
            else if (sender.Equals(btnPopBankCancel)) ipBankTujuan.Close(false);
            else if (sender.Equals(btnPopGiroOK))
            {
                txtPopGiro.Text = txtPopGiro.Text.Trim();

                if (lbnkPopGiro.NamaBank == "")
                {
                    MessageBox.Show("Bank masih kosong");
                    return;
                }
                if (datepPopGiroJT.Value < GlobalVar.DateOfServer)
                {
                    MessageBox.Show("Tgl jatuh tempo giro tidak valid");
                    return;
                }
                ipAccGiro.Close(true);
            }
            else if (sender.Equals(btnPopGiroAttach))
            {
                OpenFileDialog frm = new OpenFileDialog()
                {
                    FileName = txtPopGiroAttachPath.Text,
                    Filter = "Image File|*.jpeg;*.jpg;*.png;*.bmp",
                    CheckFileExists = true,
                    Multiselect = false
                };
                DialogResult dr = frm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        using (Image img = Image.FromFile(frm.FileName))
                        {
                            Size ns = this.calcThumb(img.Size, new Size(1024, 1024));

                            picPopGiroAttach.Image = new Bitmap(img, ns);
                            txtPopGiroAttachPath.Text = frm.FileName;
                            picPopGiroAttach.Tag = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else if (sender.Equals(btnPopGiroCancel)) ipAccGiro.Close(false);
            else if (sender.Equals(btnPopDetailOK)) ipDetail.Close(false);
            else if (sender.Equals(btnPopKoreksiCancel)) ipKoreksi.Close(false);
            else if (sender.Equals(btnPopKoreksiOK))
            {
                double num = 0;
                if (!double.TryParse(txtPopNomKoreksi.Text, out num))
                {
                    MessageBox.Show("Masukkan nominal dengan benar");
                    return;
                }
                if (num != 0 && txtPopKetKoreksi.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Catatan koreksi masih kosong");
                    return;
                }

                JSON conf = (JSON)ipKoreksi.Tag;
                if (conf["Max"].NumberValue + num < 0)
                {
                    MessageBox.Show("Minimal koreksi hingga " + (conf["Nominal"].NumberValue - conf["Max"].NumberValue).ToString("#,##0"));
                    return;
                }
                ipKoreksi.Close(true);
            }
        }

        private Size calcThumb(Size cur, Size max)
        {
            int curW = cur.Width,
                curH = cur.Height,
                maxW = max.Width,
                maxH = max.Height;

            maxW = maxW <= 0 ? 500 : maxW;
            maxH = maxH <= 0 ? 300 : maxH;

            if (curW > curH)
            {
                if (curW > maxW)
                {
                    float tmpch = (float)curH * ((float)maxW / (float)curW);
                    curH = Convert.ToInt32(tmpch);
                    curW = maxW;
                }
            }
            else
            {
                if (curH > maxH)
                {
                    float tmpcw = (float)curW * ((float)maxH / (float)curH);
                    curW = Convert.ToInt32(tmpcw);
                    curH = maxH;
                }
            }
            return new Size(curW, curH);
        }

        private double calcIden()
        {
            double ttl = 0;
            foreach (DataGridViewRow r in GV02.Rows)
            {
                double val;
                if (!double.TryParse(r.Cells["coldNominalIden2"].Value.ToString(), out val)) val = 0;
                r.Cells["coldNominalIden2"].Value = val;

                ttl += val;
            }
            return ttl;
        }

        private void GV02_BeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (GV01.SelectedCells.Count > 0)
            {
                e.Cancel = !bool.Parse(GV01.SelectedCells[0].OwningRow.Cells["colCheck"].Value.ToString());
            }
            else e.Cancel = true;
        }

        private void GV02_EndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (GV01.SelectedCells.Count > 0)
            {
                DataGridViewRow crow = GV02.Rows[e.RowIndex];
                DataGridViewRow row = GV01.SelectedCells[0].OwningRow;
                DataGridViewColumn col = GV02.Columns[e.ColumnIndex];
                switch (col.Name) {
                    case "coldNominalIden2":
                        double mst = double.Parse(row.Cells["colNominalIden"].Value.ToString()),
                               ttl = this.calcIden();

                        if (row.Cells["colNominalKoreksi"].Value != DBNull.Value) mst += double.Parse(row.Cells["colNominalKoreksi"].Value.ToString());
                        
                        DataGridViewCell cell = GV02.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        double cval = double.Parse(cell.Value.ToString());
                        if (cval < 0)
                        {
                            cell.Value = ttl = 0;
                            MessageBox.Show("Nominal tidak boleh negatif");
                        }
                        if (ttl > mst)
                        {
                            cell.Value = ttl = mst - (ttl - double.Parse(cell.Value.ToString()));
                            MessageBox.Show("Total iden melebihi nominal " + mst.ToString("#,##0"));
                        }
                        else ttl = double.Parse(cell.Value.ToString());

                        DataRow[] rows = _lists.Select("RowID = '" + row.Cells["colRowID"].Value.ToString() + "'");
                        if (rows.Length > 0) foreach (DataRow dr in rows) dr["NominalIden"] = this.calcIden();

                        rows = _idenLists.Select("RowID = '" + crow.Cells["coldRowID"].Value.ToString() + "' AND HeaderRowID = '" + row.Cells["colRowID"].Value.ToString() + "' AND IdenRowID = '" + crow.Cells["coldIdenRowID"].Value.ToString() + "'");
                        if (rows.Length > 0) foreach (DataRow dr in rows) dr["Nominal"] = ttl;

                        CalcTotal();
                        break;
                }
            }
        }

        private void GV_RowAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView GV = (DataGridView)sender;
            for (int i = e.RowIndex; i < (e.RowIndex + e.RowCount); i++)
            {
                DataGridViewRow row = GV.Rows[i];
                bool vld = true;
                string rs = "";

                if (GV == GV01)
                {
                    rs = row.Cells["colStatusCode"].Value.ToString();
                    vld = !(row.Cells["colNamaToko"].Value == null || row.Cells["colNamaToko"].Value == DBNull.Value);
                    vld = !(!vld ? true : row.Cells["colStatusCode"].Value.ToString() == "3");
                }
                else if (GV == GV02)
                {
                    rs = row.Cells["coldStatusCode"].Value.ToString();
                    vld = !(row.Cells["coldNamaToko"].Value == null || row.Cells["coldNamaToko"].Value == DBNull.Value);
                }
                else if (GV == GV03)
                {
                    rs = "";
                    vld = !(row.Cells["col2NamaToko"].Value == null || row.Cells["col2NamaToko"].Value == DBNull.Value);
                }
                else if (GV == GV04)
                {
                    rs = "";
                    vld = !(row.Cells["col3NamaToko"].Value == null || row.Cells["col3NamaToko"].Value == DBNull.Value);
                }

                foreach (DataGridViewCell cl in row.Cells)
                {
                    if (vld)
                    {
                        if (GV == GV01)
                        {
                            switch (rs)
                            {
                                case "0":
                                    cl.Style.BackColor = Color.FromArgb(224, 224, 224);
                                    break;
                                case "2":
                                    cl.Style.BackColor = Color.FromArgb(255, 250, 219);
                                    break;
                                default:
                                    cl.Style.BackColor = GV.DefaultCellStyle.BackColor;
                                    break;
                            }
                        }
                        else if (GV == GV02)
                        {
                            switch (rs)
                            {
                                case "0":
                                    cl.Style.BackColor = Color.FromArgb(255, 247, 204);
                                    break;
                                default:
                                    cl.Style.BackColor = GV.DefaultCellStyle.BackColor;
                                    break;
                            }
                        }
                        else cl.Style.BackColor = GV.DefaultCellStyle.BackColor;
                    }
                    else cl.Style.BackColor = Color.FromArgb(255, 196, 196);
                }
            }
        }
        #endregion

        private void GVDKN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView GV = (DataGridView)sender;
            double ttl = 0;
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewRow cur = GVDKN.Rows[e.RowIndex];

                if (cur.Cells["colCheckT"].Value == null) cur.Cells["colCheckT"].Value = false;
                cur.Cells["colCheckT"].Value = !bool.Parse(cur.Cells["colCheckT"].Value.ToString());
                bool cstat = bool.Parse(cur.Cells["colCheckT"].Value.ToString());

                foreach (DataGridViewRow c in GVDKN.Rows)
                {
                    DataGridViewCheckBoxCell chkchecking = c.Cells[0] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(chkchecking.Value) == true)
                    { 
                        ttl += double.Parse(c.Cells["colNomFinalT"].Value.ToString());
                    }
                }
            }
            txtTotalDKN.Text = ttl.ToString();
        }

        private void pnlPopBank_Leave(object sender, EventArgs e)
        {
            //chkToko2.Checked = false;
            //dtbl2.Rows.Clear();
            //GVDKN.DataSource = dtbl2.DefaultView;
        }

        private void lookupDKN1_SelectData(object sender, EventArgs e)
        {
            //txtTotalDKN.Text = lookupDKN1.Jumlah;
        }

    }
}
