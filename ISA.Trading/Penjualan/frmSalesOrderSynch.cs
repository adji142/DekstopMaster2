using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Utility;
using ISA.DAL;

namespace ISA.Trading.Penjualan
{
    public partial class frmSalesOrderSynch : ISA.Trading.BaseForm
    {
        string InitGudang;
        bool hasSynch = false;
        public DialogResult Result
        {
            get { return (hasSynch ? DialogResult.OK : DialogResult.Cancel); }
        }

        public frmSalesOrderSynch()
        {
            InitializeComponent();

            using (var db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_Perusahaan_LIST]"));
                DataTable dtbl = db.Commands[0].ExecuteDataTable();

                if (dtbl.Rows.Count > 0)
                {
                    InitGudang = dtbl.Rows[0]["InitGudang"].ToString();
                }
                else MessageBox.Show("Perusahaan tidak di temukan");
            }
        }

        private void frmSalesOrderSynch_Load(object sender, EventArgs e)
        {
            if (InitGudang == null || InitGudang == "") this.Close();
            rangeDateBox1.FromDate = rangeDateBox1.ToDate = DateTime.Now;
            GV01.AutoGenerateColumns = false;
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            if (sender.Equals(btnSearch)) GetData();
            else if (sender.Equals(btnClose)) this.Close();
            else if (sender.Equals(btnDownload))
            {
                DataGridView GV = null;
                if (mainTab.SelectedTab == tabPage1) GV = GV01;
                else if (mainTab.SelectedTab == tabPage2) GV = GV02;
                else return;

                if (mainTab.SelectedTab == tabPage2)
                {
                    MessageBox.Show("Fitur ini belum dapat di gunakan.");
                    return;
                }

                List<int> idx = new List<int>();
                foreach (DataGridViewRow row in GV.Rows)
                {
                    if (Boolean.Parse(row.Cells[(GV == GV01 ? "colCheck" : "col2Check")].Value.ToString()))
                    {
                        idx.Add(int.Parse(row.Cells[(GV == GV01 ? "colid" : "col2id")].Value.ToString()));
                    }
                }

                if (idx.Count > 0)
                {
                    ImportData(idx.ToArray());
                    TolakOtomatis();
                }
                else MessageBox.Show("Tidak ada item untuk di synch");
            }
        }

        JSON mdat;
        DataSet dset;

        InPopup ipProgress;
        FakeProgress fpProgress;

        private void GetData()
        {
            Form thisx = this;

            if (ipProgress == null) ipProgress = new InPopup(this, pnlProgress);
            if (fpProgress == null) fpProgress = new FakeProgress(progbProgress);

            TabPage curp = mainTab.SelectedTab;

            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += (a, b) =>
            {
                fpProgress.Start();

                JSON opt = new JSON(JSONType.Object);
                opt.ObjAdd("from", new JSON(rangeDateBox1.FromDate.Value.ToString("yyyy-MM-dd")));
                opt.ObjAdd("to", new JSON(rangeDateBox1.ToDate.Value.ToString("yyyy-MM-dd")));

                string host = "https://devwiser.sas-autoparts.com";
                using (var db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_AppSetting_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@Key", SqlDbType.VarChar, "Wiser_Host"));
                    DataTable dtbl = db.Commands[0].ExecuteDataTable();

                    if (dtbl.Rows.Count > 0) host = dtbl.Rows[0]["Value"].ToString();
                    else throw new Exception("Wiser belum di setting");
                }

                string apiu = host;
                if (curp == tabPage1) apiu += "/api/salesorderps/synch/" + InitGudang;
                else if (curp == tabPage2) apiu += "/sas-api/v1/synch/" + InitGudang;
                else throw new Exception("Tidak dapat mengambil data");

                bool except = false;
                XNet xn = new XNet(apiu, XNetMode.Synchronous);
                XNetThread xnt = xn.Get(opt, c =>
                {
                    if (bgw.CancellationPending) return;

                    try
                    {
                        if (c.Error != null) throw new Exception("Terjadi error: " + c.Error.Message);
                        else if (c.Output.Length > 0)
                        {
                            JSON jdat = JSON.Parse(c.Output);
                            if (jdat.Type == JSONType.Object)
                            {
                                if (jdat.ObjExists("Result") && jdat["Result"].BoolValue)
                                {
                                    if (jdat.ObjExists("Data"))
                                    {
                                        DataTable dtbl0 = new DataTable();
                                        DataTable dtbl1 = new DataTable();

                                        dtbl0.Columns.Add("check");
                                        foreach (string k in jdat["Data"].ObjKeys)
                                        {
                                            JSON cur = jdat["Data"][k];
                                            List<object> itm = new List<object>();

                                            itm.Add(true);
                                            foreach (string k2 in cur.ObjKeys)
                                            {
                                                switch (k2)
                                                {
                                                    case "details":
                                                        // do nothing
                                                        break;
                                                    default:
                                                        if (dtbl0.Rows.Count <= 0)
                                                        {
                                                            switch (k2)
                                                            {
                                                                case "int":
                                                                    dtbl0.Columns.Add(k2, typeof(int));
                                                                    break;

                                                                case "total": case "count":
                                                                    dtbl0.Columns.Add(k2, typeof(double));
                                                                    break;

                                                                default:
                                                                    dtbl0.Columns.Add(k2);
                                                                    break;
                                                            }
                                                        }
                                                        itm.Add(cur[k2].Value);
                                                        break;
                                                }
                                            }

                                            dtbl0.Rows.Add(itm.ToArray());
                                            foreach (string k2 in cur["details"].ObjKeys)
                                            {
                                                JSON cur2 = cur["details"][k2];
                                                itm = new List<object>();
                                                foreach (string k3 in cur2.ObjKeys)
                                                {
                                                    switch (k3)
                                                    {
                                                        default:
                                                            if (dtbl1.Rows.Count <= 0)
                                                            {
                                                                switch (k2)
                                                                {
                                                                    case "int":
                                                                        dtbl1.Columns.Add(k3, typeof(int));
                                                                        break;

                                                                    default:
                                                                        dtbl1.Columns.Add(k3);
                                                                        break;
                                                                }
                                                            }
                                                            itm.Add(cur2[k3].Value);
                                                            break;
                                                    }
                                                }
                                                dtbl1.Rows.Add(itm.ToArray());
                                            }
                                        }

                                        dset = new DataSet();
                                        mdat = jdat["Data"];
                                        dset.Tables.Add(dtbl0);
                                        dset.Tables.Add(dtbl1);

                                        if (curp == tabPage1)
                                        {
                                            GV01.Invoke(new Action(() => GV01.DataSource = dset.Tables[0]));
                                        }
                                        else if (curp == tabPage2)
                                        {
                                            GV02.Invoke(new Action(() => GV02.DataSource = dset.Tables[0]));
                                        }

                                        b.Result = true;
                                        return;
                                    }
                                    throw new Exception("Response server is not expected");
                                }
                                else
                                {
                                    if (jdat.ObjExists("Msg")) throw new Exception("Server error: " + jdat["Msg"]);
                                    else throw new Exception("Server error: " + jdat.ToString());
                                }
                            }
                            else throw new Exception("Server error: " + c.Output);
                        }
                        else throw new Exception("Tidak ada response dari server");
                    }
                    catch (Exception ex)
                    {
                        except = true;
                        b.Result = ex.Message;
                    }
                });

                while (xnt.OnWorking) {
                    if (bgw.CancellationPending)
                    {
                        b.Cancel = true;
                        xnt.Cancel();
                        break;
                    }
                    else if (except) break;
                };
                if (b.Result != null && !b.Result.Equals(true)) throw new Exception(b.Result.ToString());
            };
            bgw.RunWorkerCompleted += (a, b) =>
            {
                bool r = false;
                if (b.Cancelled) MessageBox.Show(thisx, "Operasi di gagalkan");
                else if (b.Error != null) MessageBox.Show(thisx, b.Error.Message);
                else r = true;

                if (r)
                {
                    if (mainTab.SelectedTab == tabPage1) gvLoads[0] = true;
                    else if (mainTab.SelectedTab == tabPage2) gvLoads[1] = true;
                }
                ipProgress.Close(r);
            };

            ipProgress.OpenDialog(this, a =>
            {
            }, () => bgw.CancelAsync());
            bgw.RunWorkerAsync();
        }

        private void ImportData(int[] ids)
        {
            TabPage curp = mainTab.SelectedTab;
            using (var db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_AppSetting_LIST]"));
                db.Commands[0].Parameters.Add(new Parameter("@Key", SqlDbType.VarChar, "Wiser_Host"));
                DataTable dtbl2 = db.Commands[0].ExecuteDataTable();

                string host = "https://devwiser.sas-autoparts.com";
                if (dtbl2.Rows.Count > 0) host = dtbl2.Rows[0]["Value"].ToString();
                else
                {
                    MessageBox.Show("Download gagal, Wiser belum di setting");
                    return;
                }

                List<int> scs = new List<int>();
                foreach (int i in ids)
                {
                    JSON cur = mdat[i.ToString()];
                    List<Parameter> cmdl = new List<Parameter>();
                    db.Commands.Clear();

                    try
                    {
                        JSON jdat = null;
                        if (curp == tabPage1) jdat = this.ImportDataGV01("header", cur, new JSON());
                        else if (curp == tabPage2) jdat = this.ImportDataGV02("header", cur, new JSON());
                        else
                        {
                            MessageBox.Show("Data tidak dapat dapat di proses");
                            return;
                        }
                        if (jdat == null) continue;
                        if (jdat.Type == JSONType.String) throw new Exception(jdat.StringValue);
                        cmdl = (List<Parameter>)jdat["params"].Value;

                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("[usp_OrderPenjualan_WISER_SET]"));
                        db.Commands[0].Parameters = cmdl;
                        DataTable dtbl = db.Commands[0].ExecuteDataTable();

                        if (dtbl.Rows.Count > 0)
                        {
                            if (dtbl.Rows[0]["Result"].ToString() == "1")
                            {
                                Guid id = (Guid)dtbl.Rows[0]["RowID"];

                                int cid = 0;
                                bool itOk = true;
                                bool itTrasaction = false;

                                try
                                {
                                    db.Commands.Clear();
                                    foreach (string ck in cur["details"].ObjKeys)
                                    {
                                        JSON curd = cur["details"][ck];

                                        jdat["header"] = cur;
                                        jdat["id"] = new JSON(id);
                                        jdat["cid"] = new JSON(cid);

                                        JSON jdat2 = null;
                                        if (curp == tabPage1) jdat2 = this.ImportDataGV01("detail", curd, jdat);
                                        else if (curp == tabPage2) jdat2 = this.ImportDataGV02("detail", curd, jdat);
                                        else throw new Exception("Data tidak dapat di proses");

                                        if (jdat2 == null) continue;
                                        if (jdat2["error", JSON.Null].StringValue.Length > 0)
                                        {
                                            MessageBox.Show(jdat2["error"].StringValue);
                                            itOk = false;
                                            break;
                                        }

                                        if (jdat2.Type == JSONType.String) throw new Exception(jdat2.StringValue);
                                        cmdl = (List<Parameter>)jdat2["params"].Value;

                                        db.Commands.Add(db.CreateCommand("[usp_OrderPenjualanDetail_WISER_SET]"));
                                        db.Commands[cid].Parameters = cmdl;
                                        cid += 1;
                                    }

                                    if (itOk)
                                    {
                                        itTrasaction = true;
                                        db.BeginTransaction();
                                        foreach (Command cmd in db.Commands)
                                        {
                                            try
                                            {
                                                cmd.ExecuteNonQuery();
                                            }
                                            catch (Exception ex)
                                            {
                                                if (itTrasaction) db.RollbackTransaction();
                                                Error.LogError(ex);
                                                itOk = false;
                                                break;
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Error.LogError(ex);
                                    itOk = false;
                                }

                                if (itOk)
                                {
                                    if (itTrasaction) db.CommitTransaction();
                                    foreach (string ck in cur["details"].ObjKeys)
                                    {
                                        JSON curd = cur["details"][ck];

                                        try
                                        {
                                            db.Commands.Clear();
                                            db.Commands.Add(db.CreateCommand("[psp_StokGudang_Recalculation]"));
                                            db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, GlobalVar.Gudang));
                                            db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, curd["kodebarang"].StringValue));
                                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                            db.Commands[0].ExecuteNonQuery();
                                        }
                                        catch (Exception)
                                        {
                                            // do nothing
                                        }
                                    }

                                    try
                                    {
                                        db.Commands.Clear();
                                        db.Commands.Add(db.CreateCommand("[psp_OrderPenjualan_RefreshSummary_DODetailID]"));
                                        db.Commands[0].Parameters.Add(new Parameter("@DODetailID", SqlDbType.UniqueIdentifier, DBNull.Value));
                                        db.Commands[0].Parameters.Add(new Parameter("@DOHeaderID", SqlDbType.UniqueIdentifier, id));
                                        db.Commands[0].ExecuteNonQuery();
                                    }
                                    catch (Exception)
                                    {
                                        // do nothing
                                    }

                                    scs.Add((int)cur["id"].NumberValue);
                                }
                                else
                                {
                                    try
                                    {
                                        db.Commands.Clear();
                                        db.Commands.Add(db.CreateCommand("[usp_OrderPenjualan_WISER_DELETE]"));
                                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, id));
                                        db.Commands[0].Parameters.Add(new Parameter("@WiserID", SqlDbType.Int, cur["id"].NumberValue));

                                        db.Commands[0].ExecuteNonQuery();
                                    }
                                    catch (Exception) { }
                                }
                            }
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Error: " + ex);
                    }
                }

                if (scs.Count > 0)
                {
                    if (!hasSynch) hasSynch = true;
                    this.MarkAsSuccess(scs.ToArray());

                    JSON opt = new JSON(JSONType.Object);
                    JSON lst = new JSON(JSONType.Array);
                    foreach (int ix in scs) lst.ArrAdd(new JSON(ix));
                    opt.ObjAdd("mark", new JSON(true));
                    opt.ObjAdd("ids", lst);

                    string errm = "";

                    string apiu = host;
                    if (curp == tabPage1) apiu += "/api/salesorder/synch/" + InitGudang;
                    else if (curp == tabPage2) apiu += "/sas-api/v1/synch/" + InitGudang;
                    else
                    {
                        MessageBox.Show("Unknown marking method");
                        return;
                    }

                    XNet xn = new XNet(apiu, XNetMode.Synchronous);
                    XNetThread xnt = xn.Get(opt, r =>
                    {
                        if (r.Error != null) errm = r.Error.Message;
                        else if (r.Output.Length > 0)
                        {
                            JSON jres = JSON.Parse(r.Output);
                            if (jres.Type == JSONType.Object)
                            {
                                if (jres.ObjExists("Result") && jres["Result"].BoolValue) errm = "";
                                else if (jres.ObjExists("Msg")) errm = jres["Msg"].StringValue;
                                else errm = "Marking to server failed";
                                return;
                            }
                        }
                        errm = "Marking to server failed";
                    });

                    if (errm.Length > 0) MessageBox.Show("Server message:\n" + errm);
                    if (scs.Count == mdat.Count) this.Close();
                }
                else MessageBox.Show("Synch gagal");
            }
        }

        private JSON ImportDataGV01(string typ, JSON cur, JSON jdat)
        {
            JSON res = new JSON(JSONType.Object);
            switch (typ)
            {
                case "header":
                    List<Parameter> cmdl = new List<Parameter>();

                    string cb3 = "01";
                    if (cur["kirimcabang"].StringValue.Length > 2) cb3 = cur["kirimcabang"].StringValue.Substring(2);

                    string htrid = FingerPrintWiser(cur["id"].StringValue);
                    cmdl.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, cur["isarowid"].GuidValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@HtrID", SqlDbType.VarChar, htrid));
                    cmdl.Add(new Parameter("@Cabang1", SqlDbType.VarChar, cur["omsetcabang"].StringValue));
                    cmdl.Add(new Parameter("@Cabang2", SqlDbType.VarChar, cur["kirimcabang"].StringValue));
                    cmdl.Add(new Parameter("@Cabang3", SqlDbType.VarChar, cb3));
                    cmdl.Add(new Parameter("@NoRequest", SqlDbType.VarChar, cur["noso"].StringValue));
                    cmdl.Add(new Parameter("@TglRequest", SqlDbType.DateTime, cur["tglpickinglist"].DateTimeValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@NoDO", SqlDbType.VarChar, cur["nopickinglist"].StringValue));
                    cmdl.Add(new Parameter("@TglDO", SqlDbType.DateTime, cur["tglso"].DateTimeValue(DBNull.Value)));

                    string statusajuanhrg11 = cur["statusajuanhrg11"].StringValue;
                    if (statusajuanhrg11.Contains("SUDAH ACC")) statusajuanhrg11 = statusajuanhrg11.Replace("SUDAH ACC", ""); else statusajuanhrg11 = "";
                    cmdl.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, statusajuanhrg11));

                    double plafon = Class.TokoPlafon.Plafon(cur["kodetoko"].StringValue, cur["tipetransaksi"].StringValue);
                    double piutTerakhir = Class.TokoPlafon.Piutang(cur["kodetoko"].StringValue, cur["tipetransaksi"].StringValue);
                    double giroTolak = Class.TokoPlafon.GiroTolak(cur["kodetoko"].StringValue, cur["tipetransaksi"].StringValue);
                    double piutOverdue = Class.TokoOverdue.Overdue(cur["kodetoko"].StringValue);
                    double plafonSisa = plafon - cur["rpaccpiutang"].NumberValue;

                    cmdl.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, cur["namakaryawan"].StringValue));
                    cmdl.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, cur["noaccpiutang"].StringValue));
                    cmdl.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, cur["tglaccpiutang"].DateTimeValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@RpACCPiutang", SqlDbType.Money, cur["rpaccpiutang"].NumberValue));
                    cmdl.Add(new Parameter("@RpPlafonToko", SqlDbType.Money, (plafonSisa < 0 ? 0 : plafonSisa)));
                    cmdl.Add(new Parameter("@RpPiutangTerakhir", SqlDbType.Money, piutTerakhir)); // cur["rpsaldopiutang"].NumberValue
                    cmdl.Add(new Parameter("@RpGiroTolakTerakhir", SqlDbType.Money, giroTolak)); // 0
                    cmdl.Add(new Parameter("@RpOverdue", SqlDbType.Money, piutOverdue)); // cur["rpsaldooverdue"].NumberValue
                    cmdl.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, string.Empty));
                    cmdl.Add(new Parameter("@TokoID", SqlDbType.VarChar, cur["tokoid"].StringValue));
                    cmdl.Add(new Parameter("@KodeToko", SqlDbType.VarChar, cur["kodetoko"].StringValue));
                    cmdl.Add(new Parameter("@KodeSales", SqlDbType.VarChar, cur["kodesales"].StringValue));
                    cmdl.Add(new Parameter("@StsToko", SqlDbType.VarChar, cur["statustoko"].StringValue));
                    cmdl.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, cur["alamat"].StringValue));
                    cmdl.Add(new Parameter("@Kota", SqlDbType.VarChar, cur["kota"].StringValue));
                    cmdl.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, "    "));
                    cmdl.Add(new Parameter("@Disc1", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@Disc2", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@Disc3", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@isClosed", SqlDbType.Bit, 0));
                    cmdl.Add(new Parameter("@Catatan1", SqlDbType.VarChar, cur["catatanpenjualan"].StringValue));
                    cmdl.Add(new Parameter("@Catatan2", SqlDbType.VarChar, cur["catatanpembayaran"].StringValue));
                    cmdl.Add(new Parameter("@Catatan3", SqlDbType.VarChar, cur["catatanpengiriman"].StringValue));
                    cmdl.Add(new Parameter("@Catatan4", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@Catatan5", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, string.Empty));
                    cmdl.Add(new Parameter("@StatusBO", SqlDbType.Bit, 0));
                    cmdl.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    cmdl.Add(new Parameter("@LinkID", SqlDbType.VarChar, string.Empty));
                    cmdl.Add(new Parameter("@SumRpNet", SqlDbType.Money, cur["total"].NumberValue));
                    cmdl.Add(new Parameter("@SumRpJual", SqlDbType.Money, cur["total"].NumberValue));
                    cmdl.Add(new Parameter("@SumQtyDO", SqlDbType.Int, cur["count"].NumberValue));
                    //cmdl.Add(new Parameter("@SumQtySJ", SqlDbType.Int, cur["count"].NumberValue));
                    cmdl.Add(new Parameter("@TransactionType", SqlDbType.VarChar, cur["tipetransaksi"].StringValue));
                    cmdl.Add(new Parameter("@Expedisi", SqlDbType.VarChar, cur["kodeexpedisi"].StringValue));
                    cmdl.Add(new Parameter("@HariKredit", SqlDbType.Int, cur["temponota"].NumberValue));
                    cmdl.Add(new Parameter("@HariKirim", SqlDbType.Int, cur["tempokirim"].NumberValue));
                    cmdl.Add(new Parameter("@HariSales", SqlDbType.Int, cur["temposalesman"].NumberValue));
                    cmdl.Add(new Parameter("@NPrint", SqlDbType.Int, cur["print"].NumberValue));
                    cmdl.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, cur["lastupdatedby"].StringValue));
                    cmdl.Add(new Parameter("@TglPrintDO", SqlDbType.DateTime, cur["tglprintpickinglist"].DateTimeValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@TanggalTerimaDO", SqlDbType.DateTime, cur["tglterimapilpiutang"].DateTimeValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@StatusProsesDO", SqlDbType.VarChar, cur["statusajuanhrg11"].StringValue));
                    cmdl.Add(new Parameter("@BOMurni", SqlDbType.DateTime, cur["bomurni"].DateTimeValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@TglPJkeGudang", SqlDbType.DateTime, cur["tglpjkegudang"].DateTimeValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@AlasanTerlambatPJkeGudang", SqlDbType.VarChar, cur["alasanterlambatpjkegudang"].StringValue));
                    cmdl.Add(new Parameter("@WiserID", SqlDbType.Int, cur["id"].NumberValue));
                    cmdl.Add(new Parameter("@WiserTag", SqlDbType.Int, DBNull.Value));

                    res["cb3"] = new JSON(cb3);
                    res["htrid"] = new JSON(htrid);
                    res["tglso"] = new JSON(cur["tglso"].StringValue);
                    res["kodetoko"] = new JSON(cur["kodetoko"].StringValue);
                    res["omsetcabang"] = new JSON(cur["omsetcabang"].StringValue);
                    res["statusajuanhrg11"] = new JSON(statusajuanhrg11);
                    res["params"] = new JSON(JSONType.Unknown, cmdl);
                    break;

                case "detail":
                    cmdl = new List<Parameter>();
                    cmdl.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, cur["isarowid"].GuidValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, jdat["id"].GuidValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@RecordID", SqlDbType.VarChar, FingerPrintWiser(cur["id"].StringValue)));
                    cmdl.Add(new Parameter("@HtrID", SqlDbType.VarChar, jdat["htrid"].StringValue));
                    cmdl.Add(new Parameter("@BarangID", SqlDbType.VarChar, cur["kodebarang"].StringValue));
                    cmdl.Add(new Parameter("@QtyRequest", SqlDbType.Int, cur["qtyso"].NumberValue));
                    cmdl.Add(new Parameter("@HrgJual", SqlDbType.Money, cur["hrgsatuanbrutto"].NumberValue));
                    cmdl.Add(new Parameter("@Disc1", SqlDbType.Money, cur["disc1"].NumberValue));
                    cmdl.Add(new Parameter("@Disc2", SqlDbType.Money, cur["disc2"].NumberValue));
                    cmdl.Add(new Parameter("@Disc3", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@Pot", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@NoACC", SqlDbType.VarChar, cur["noacc11"].StringValue));
                    cmdl.Add(new Parameter("@Catatan", SqlDbType.VarChar, cur["catatan"].StringValue));
                    cmdl.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    cmdl.Add(new Parameter("@NBOPrint", SqlDbType.VarChar, 0));
                    cmdl.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, cur["lastupdatedby"].StringValue));
                    cmdl.Add(new Parameter("@QtyStock", SqlDbType.Int, cur["qtystockgudang"].NumberValue));
                    cmdl.Add(new Parameter("@PINACCHarga", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@PublicKeyACCHarga", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@KomisiKhusus", SqlDbType.Money, null));
                    cmdl.Add(new Parameter("@WiserID", SqlDbType.Int, cur["id"].NumberValue));
                    cmdl.Add(new Parameter("@WiserHeaderID", SqlDbType.Int, cur["orderpenjualanid"].NumberValue));
                    cmdl.Add(new Parameter("@WiserTag", SqlDbType.Int, DBNull.Value));

                    DataTable dtbmk = new DataTable();
                    using (Database db2 = new Database())
                    {
                        db2.Commands.Add(db2.CreateCommand("dbo.usp_GetInfoHrgJualDepo"));
                        db2.Commands[0].Parameters.Add(new Parameter("@TglDo", SqlDbType.DateTime, jdat["tglso"].DateTimeValue(DBNull.Value)));
                        db2.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, cur["kodebarang"].StringValue));
                        db2.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, jdat["kodetoko"].StringValue));
                        db2.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, jdat["omsetcabang"].StringValue));
                        dtbmk = db2.Commands[0].ExecuteDataTable();
                    }

                    double _hrgB, _hrgM, _hrgK;
                    double _hrgJual;

                    if (dtbmk.Rows.Count > 0)
                    {
                        _hrgB = Convert.ToDouble(dtbmk.Rows[0]["HrgB"]);
                        _hrgM = Convert.ToDouble(dtbmk.Rows[0]["HrgM"]);
                        _hrgK = Convert.ToDouble(dtbmk.Rows[0]["HrgK"]);
                        _hrgJual = cur["hrgsatuanbrutto"].NumberValue;
                    }
                    else throw new Exception("Barang " + cur["kodebarang"].StringValue + " tidak ada informasi jual");

                    if (
                           (Tools.Left(jdat["header"]["statustoko"].StringValue, 1) == "B" && _hrgJual >= _hrgB)
                        || (Tools.Left(jdat["header"]["statustoko"].StringValue, 1) == "M" && _hrgJual >= _hrgM)
                        || (Tools.Left(jdat["header"]["statustoko"].StringValue, 1) == "K" && _hrgJual >= _hrgK)
                    )
                    {
                        cmdl.Add(new Parameter("@QtyDO", SqlDbType.Int, cur["qtyso"].NumberValue));
                        /*cmdl.Add(new Parameter("@QtyAcc11", SqlDbType.Int, cur["qtysoacc"].NumberValue));
                        cmdl.Add(new Parameter("@QtySOCekStock", SqlDbType.Int, cur["qtysoacc"].NumberValue));
                        cmdl.Add(new Parameter("@QtyDO", SqlDbType.Int, cur["qtysoacc"].NumberValue));*/
                    }
                    else cmdl.Add(new Parameter("@QtyDO", SqlDbType.Int, 0));
                    res["params"] = new JSON(JSONType.Unknown, cmdl);
                    break;
            }
            return res;
        }
        private JSON ImportDataGV02(string typ, JSON cur, JSON jdat)
        {
            JSON res = new JSON(JSONType.Object);
            switch (typ)
            {
                case "header":
                    List<Parameter> cmdl = new List<Parameter>();

                    string cb3 = "01";
                    if (cur["kirimcabang"].StringValue.Length > 2) cb3 = cur["kirimcabang"].StringValue.Substring(2);

                    string htrid = FingerPrintWiser(cur["id"].StringValue);
                    cmdl.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, DBNull.Value));
                    cmdl.Add(new Parameter("@HtrID", SqlDbType.VarChar, htrid));
                    cmdl.Add(new Parameter("@Cabang1", SqlDbType.VarChar, cur["omsetcabang"].StringValue));
                    cmdl.Add(new Parameter("@Cabang2", SqlDbType.VarChar, cur["kirimcabang"].StringValue));
                    cmdl.Add(new Parameter("@Cabang3", SqlDbType.VarChar, cb3));
                    cmdl.Add(new Parameter("@NoRequest", SqlDbType.VarChar, cur["docno"].StringValue));
                    cmdl.Add(new Parameter("@TglRequest", SqlDbType.DateTime, cur["tglpickinglist"].DateTimeValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@NoDO", SqlDbType.VarChar, cur["nopickinglist"].StringValue));
                    cmdl.Add(new Parameter("@TglDO", SqlDbType.DateTime, cur["docdate"].DateTimeValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, cur["namasales"].StringValue));
                    cmdl.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, DBNull.Value));
                    cmdl.Add(new Parameter("@RpACCPiutang", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@RpPlafonToko", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@RpPiutangTerakhir", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@RpGiroTolakTerakhir", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@RpOverdue", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@TokoID", SqlDbType.VarChar, cur["tokoid"].StringValue));
                    cmdl.Add(new Parameter("@KodeToko", SqlDbType.VarChar, cur["kodetoko"].StringValue));
                    cmdl.Add(new Parameter("@KodeSales", SqlDbType.VarChar, cur["kodesales"].StringValue));
                    cmdl.Add(new Parameter("@StsToko", SqlDbType.VarChar, cur["sasstatusbmk"].StringValue));
                    cmdl.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, cur["alamat"].StringValue));
                    cmdl.Add(new Parameter("@Kota", SqlDbType.VarChar, cur["kota"].StringValue));
                    cmdl.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@Disc1", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@Disc2", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@Disc3", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@isClosed", SqlDbType.Bit, 0));
                    cmdl.Add(new Parameter("@Catatan1", SqlDbType.VarChar, cur["remark"].StringValue));
                    cmdl.Add(new Parameter("@Catatan2", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@Catatan3", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@Catatan4", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@Catatan5", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@StatusBO", SqlDbType.Bit, 0));
                    cmdl.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    cmdl.Add(new Parameter("@LinkID", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@SumRpNet", SqlDbType.Money, cur["total"].NumberValue));
                    cmdl.Add(new Parameter("@SumRpJual", SqlDbType.Money, cur["total"].NumberValue));
                    cmdl.Add(new Parameter("@SumQtyDO", SqlDbType.Int, cur["count"].NumberValue));
                    //cmdl.Add(new Parameter("@SumQtySJ", SqlDbType.Int, cur["count"].NumberValue));
                    cmdl.Add(new Parameter("@TransactionType", SqlDbType.VarChar, cur["tipetransaksi"].StringValue));
                    cmdl.Add(new Parameter("@Expedisi", SqlDbType.VarChar, cur["expedisi"].StringValue));
                    cmdl.Add(new Parameter("@HariKredit", SqlDbType.Int, cur["temponota"].NumberValue));
                    cmdl.Add(new Parameter("@HariKirim", SqlDbType.Int, cur["tempokirim"].NumberValue));
                    cmdl.Add(new Parameter("@HariSales", SqlDbType.Int, cur["temposales"].NumberValue));
                    cmdl.Add(new Parameter("@NPrint", SqlDbType.Int, cur["nprint"].NumberValue));
                    //cmdl.Add(new Parameter("@SumTglSuratJalan", SqlDbType.DateTime, cur["tglpickinglist"].DateTimeValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, cur["lastupdatedby"].StringValue));
                    cmdl.Add(new Parameter("@TglPrintDO", SqlDbType.DateTime, cur["tglprint"].DateTimeValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@TanggalTerimaDO", SqlDbType.DateTime, DBNull.Value));
                    cmdl.Add(new Parameter("@StatusProsesDO", SqlDbType.VarChar, "SUDAH ACC"));
                    cmdl.Add(new Parameter("@BOMurni", SqlDbType.DateTime, DBNull.Value));
                    cmdl.Add(new Parameter("@TglPJkeGudang", SqlDbType.DateTime, DBNull.Value));
                    cmdl.Add(new Parameter("@AlasanTerlambatPJkeGudang", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@WiserID", SqlDbType.Int, cur["id"].NumberValue));
                    cmdl.Add(new Parameter("@WiserTag", SqlDbType.Int, cur["tag"].StringValue));

                    res["cb3"] = new JSON(cb3);
                    res["htrid"] = new JSON(htrid);
                    res["tag"] = new JSON(cur["tag"].StringValue);
                    res["params"] = new JSON(JSONType.Unknown, cmdl);
                    break;

                case "detail":
                    cmdl = new List<Parameter>();
                    cmdl.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, DBNull.Value));
                    cmdl.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, jdat["id"].GuidValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@RecordID", SqlDbType.VarChar, FingerPrintWiser(cur["id"].StringValue)));
                    cmdl.Add(new Parameter("@HtrID", SqlDbType.VarChar, jdat["htrid"].StringValue));
                    cmdl.Add(new Parameter("@BarangID", SqlDbType.VarChar, cur["productcode"].StringValue));
                    cmdl.Add(new Parameter("@QtyRequest", SqlDbType.Int, cur["qty"].NumberValue));
                    cmdl.Add(new Parameter("@QtyDO", SqlDbType.Int, cur["qty"].NumberValue));
                    cmdl.Add(new Parameter("@HrgJual", SqlDbType.Money, cur["hrgsatuan"].NumberValue));
                    cmdl.Add(new Parameter("@Disc1", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@Disc2", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@Disc3", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@Pot", SqlDbType.Money, 0));
                    cmdl.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@NoACC", SqlDbType.VarChar, "ACCOTMS"));
                    cmdl.Add(new Parameter("@Catatan", SqlDbType.VarChar, cur["keterangan"].StringValue));
                    cmdl.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    cmdl.Add(new Parameter("@NBOPrint", SqlDbType.VarChar, 0));
                    cmdl.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, cur["lastupdatedby"].StringValue));
                    cmdl.Add(new Parameter("@QtyStock", SqlDbType.Int, 0));
                    cmdl.Add(new Parameter("@PINACCHarga", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@PublicKeyACCHarga", SqlDbType.VarChar, ""));
                    cmdl.Add(new Parameter("@KomisiKhusus", SqlDbType.Money, DBNull.Value));
                    cmdl.Add(new Parameter("@WiserID", SqlDbType.Int, cur["id"].NumberValue));
                    cmdl.Add(new Parameter("@WiserHeaderID", SqlDbType.Int, cur["assignorderpembelianid"].NumberValue));
                    cmdl.Add(new Parameter("@WiserTag", SqlDbType.Int, jdat["tag"].StringValue));

                    /*DataTable dtbmk = new DataTable();
                    using (Database db2 = new Database())
                    {
                        db2.Commands.Add(db2.CreateCommand("usp_GetInfoHrgJual"));
                        db2.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, jdat["header"]["tglpickinglist"].DateTimeValue(DBNull.Value)));
                        db2.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, cur["productcode"].StringValue));
                        db2.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, jdat["header"]["kodetoko"].StringValue));
                        db2.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, jdat["header"]["omsetcabang"].StringValue));
                        dtbmk = db2.Commands[0].ExecuteDataTable();
                    }

                    double _hrgB, _hrgM, _hrgK;
                    double _hrgJual;

                    if (dtbmk.Rows.Count > 0)
                    {
                        _hrgB = Convert.ToDouble(dtbmk.Rows[0]["HrgB"]);
                        _hrgM = Convert.ToDouble(dtbmk.Rows[0]["HrgM"]);
                        _hrgK = Convert.ToDouble(dtbmk.Rows[0]["HrgK"]);
                        _hrgJual = cur["hrgsatuan"].NumberValue;
                    }
                    else throw new Exception("Barang " + cur["productcode"].StringValue + " tidak ada informasi jual");

                    cmdl.Add(new Parameter("@QtyAcc11", SqlDbType.Int, cur["qty"].NumberValue));
                    cmdl.Add(new Parameter("@QtySOCekStock", SqlDbType.Int, cur["qty"].NumberValue));
                    cmdl.Add(new Parameter("@QtyDO", SqlDbType.Int, cur["qty"].NumberValue));

                    if (Tools.Left(jdat["header"]["sasstatusbmk"].StringValue, 1) == "M")
                    {
                        if (_hrgJual < _hrgB && _hrgJual >= (_hrgB - ((_hrgB * 5) / 100)))
                        {
                            cmdl.Add(new Parameter("@PINACCHargaKaCab", SqlDbType.VarChar, ISA.Pin.Generator.CreateKey(GlobalVar.Gudang + PinId.ModulId.ACCDOKaCab)));
                        }
                    }*/

                    res["params"] = new JSON(JSONType.Unknown, cmdl);
                    break;
            }
            return res;
        }

        private string FingerPrintWiser(string id)
        {
            string ids = id.PadLeft(10, '0');
            string FingerPrint = GlobalVar.PerusahaanID + DateTime.Now.ToString("yyMMdd") + ids + "WISR";
            return FingerPrint;
        }

        private void MarkAsSuccess(int[] ids)
        {
            DataGridView GV = null;
            if (mainTab.SelectedTab == tabPage1) GV = GV01;
            else if (mainTab.SelectedTab == tabPage2) GV = GV02;
            else return;

            List<int> idx = new List<int>(ids);
            foreach (DataGridViewRow row in GV.Rows)
            {
                if (idx.IndexOf(int.Parse(row.Cells[(GV == GV01 ? "colid" : "col2id")].Value.ToString())) >= 0)
                {
                    foreach (DataGridViewColumn cl in row.DataGridView.Columns) {
                        if (cl.Name == (GV == GV01 ? "colCheck" : "col2Check"))
                        {
                            row.Cells[cl.Name].Value = false;
                            row.Cells[cl.Name].Tag = true;
                        }
                        row.Cells[cl.Name].Style.BackColor = Color.FromArgb(221, 255, 181);
                    }
                }
            }
        }

        private void GV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView GV = (DataGridView)sender;
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewCell cur = GV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cur.Tag != null && cur.Tag.Equals(true)) return;
                cur.Value = !Boolean.Parse(cur.Value.ToString());
            }
        }

        public void TolakOtomatis()
        {
            /*try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_WISER_TOLAK_OTOMATIS"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, (DateTime)rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, (DateTime)rangeDateBox1.ToDate));
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
            }*/
        }

        bool[] gvLoads = new bool[] { false, false };
        private void Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTab.SelectedTab == tabPage1)
            {
                if (!gvLoads[0]) this.GetData();
            }
            else if (mainTab.SelectedTab == tabPage2)
            {
                if (!gvLoads[1]) this.GetData();
            }
        }

    }
}
