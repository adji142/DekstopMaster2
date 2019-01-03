using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Utility;
using ISA.DAL;

namespace ISA.Trading.ArusStock
{
    public partial class frmAntarGudangSynch : ISA.Trading.BaseForm
    {
        string InitGudang;
        bool hasSynch = false;
        public DialogResult Result
        {
            get { return (hasSynch ? DialogResult.OK : DialogResult.Cancel); }
        }

        public frmAntarGudangSynch()
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
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            if (sender.Equals(btnSearch)) GetData();
            else if (sender.Equals(btnClose)) this.Close();
            else if (sender.Equals(btnDownload))
            {
                List<int> idx = new List<int>();
                foreach (DataGridViewRow row in GVHeader.Rows)
                {
                    if (Boolean.Parse(row.Cells["colCheck"].Value.ToString())) idx.Add(int.Parse(row.Cells["colid"].Value.ToString()));
                }

                if (idx.Count > 0) ImportData(idx.ToArray());
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

            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += (a, b) =>
            {
                fpProgress.Start();

                JSON opt = new JSON(JSONType.Object);
                opt.ObjAdd("gudang", new JSON(InitGudang));
                opt.ObjAdd("fromdate", new JSON(rangeDateBox1.FromDate.Value.ToString("yyyy-MM-dd")));
                opt.ObjAdd("todate", new JSON(rangeDateBox1.ToDate.Value.ToString("yyyy-MM-dd")));

                string host = "http://devwiserdc.sas-autoparts.com:8000";
                using (var db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_AppSetting_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@Key", SqlDbType.VarChar, "WiserDC_Host"));
                    DataTable dtbl = db.Commands[0].ExecuteDataTable();

                    if (dtbl.Rows.Count > 0) host = dtbl.Rows[0]["Value"].ToString();
                    else throw new Exception("Wiser belum di setting");
                }

                XNet xn = new XNet(host + "/api/antargudang/get", XNetMethod.GET);
                //XNet xn = new XNet("https://postman-echo.com/get", XNetMethod.GET);
                XNetThread xnt = xn.Send(opt, c =>
                {
                    if (bgw.CancellationPending) return;
                    ///return;
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
                                        //return;
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
                                                        if (dtbl0.Rows.Count <= 0) dtbl0.Columns.Add(k2);
                                                        itm.Add(cur[k2].Value);
                                                        break;
                                                }
                                            }

                                            dtbl0.Rows.Add(itm.ToArray());
                                            foreach (string k2 in cur["Details"].ObjKeys)
                                            {
                                                JSON cur2 = cur["Details"][k2];
                                                itm = new List<object>();
                                                foreach (string k3 in cur2.ObjKeys)
                                                {
                                                    switch (k3)
                                                    {
                                                        default:
                                                            if (dtbl1.Rows.Count <= 0) dtbl1.Columns.Add(k3);
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

                                        GVHeader.Invoke(new Action(() => GVHeader.DataSource = dset.Tables[0]));

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
                };
                if (b.Result != null && !b.Result.Equals(true)) 
                {
                    MessageBox.Show(b.Result.ToString());
                    return;
                } //throw new Exception(b.Result.ToString());
            };
            bgw.RunWorkerCompleted += (a, b) =>
            {
                bool r = false;
                if (b.Cancelled) MessageBox.Show(thisx, "Operasi di gagalkan");
                else if (b.Error != null) MessageBox.Show(thisx, b.Error.Message);
                else r = true;

                ipProgress.Close(r);
            };

            ipProgress.OpenDialog(this, a =>
            {
            }, () => bgw.CancelAsync());
            bgw.RunWorkerAsync();
        }

        private void ImportData(int[] ids)
        {
            using (var db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_AppSetting_LIST]"));
                db.Commands[0].Parameters.Add(new Parameter("@Key", SqlDbType.VarChar, "WiserDC_Host"));
                DataTable dtbl2 = db.Commands[0].ExecuteDataTable();

                string host = "http://devwiserdc.sas-autoparts.com:8000";
                if (dtbl2.Rows.Count > 0) host = dtbl2.Rows[0]["Value"].ToString();
                else
                {
                    MessageBox.Show("Download gagal, Wiser belum di setting");
                    return;
                }

                Guid HeaderID, DetailID;

                List<int> scs = new List<int>();
                foreach (int i in ids)
                {
                    JSON cur = mdat[i.ToString()];
                    List<Parameter> cmdl = new List<Parameter>();
                    db.Commands.Clear();

                    if (cur["isarowid"].GuidValue(DBNull.Value) == DBNull.Value)
                    {
                        HeaderID = Guid.NewGuid();
                    }
                    else
                    {
                        HeaderID = (Guid)cur["isarowid"].GuidValue(DBNull.Value);
                    }

                    cmdl.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, HeaderID));
                    cmdl.Add(new Parameter("@RecordID", SqlDbType.VarChar, FingerPrintWiser(cur["wiserid"].StringValue)));
                    cmdl.Add(new Parameter("@DrGudang", SqlDbType.VarChar, cur["DrGudang"].StringValue));
                    cmdl.Add(new Parameter("@KeGudang", SqlDbType.VarChar, cur["KeGudang"].StringValue));
                    cmdl.Add(new Parameter("@TglKirim", SqlDbType.DateTime, cur["TglKirim"].DateTimeValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@TglTerima", SqlDbType.DateTime, cur["TglTerima"].DateTimeValue(DBNull.Value)));
                    cmdl.Add(new Parameter("@NoAG", SqlDbType.VarChar, cur["NoAG"].StringValue));
                    cmdl.Add(new Parameter("@Pengirim", SqlDbType.VarChar, cur["Pengirim"].StringValue));
                    cmdl.Add(new Parameter("@Penerima", SqlDbType.VarChar, cur["Penerima"].StringValue));
                    cmdl.Add(new Parameter("@DrCheck1", SqlDbType.VarChar, cur["DrCheck1"].StringValue));
                    cmdl.Add(new Parameter("@DrCheck2", SqlDbType.VarChar, cur["DrCheck2"].StringValue));
                    cmdl.Add(new Parameter("@KeCheck1", SqlDbType.VarChar, cur["KeCheck1"].StringValue));
                    cmdl.Add(new Parameter("@KeCheck2", SqlDbType.VarChar, cur["KeCheck2"].StringValue));
                    cmdl.Add(new Parameter("@Catatan", SqlDbType.VarChar, cur["Catatan"].StringValue));
                    cmdl.Add(new Parameter("@expedisi", SqlDbType.VarChar, cur["Expedisi"].StringValue));
                    cmdl.Add(new Parameter("@NoKendaraan", SqlDbType.VarChar, cur["NoKendaraan"].StringValue));
                    cmdl.Add(new Parameter("@NamaSopir", SqlDbType.VarChar, cur["NamaSopir"].StringValue));
                    cmdl.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, cur["LastUpdatedBy"].StringValue));
                    cmdl.Add(new Parameter("@wiserid", SqlDbType.Int, cur["wiserid"].NumberValue));
                    cmdl.Add(new Parameter("@WiserTag", SqlDbType.VarChar, "WISERDC"));

                    try
                    {
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("[usp_AntarGudang_WISERDC_SET]"));
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
                                    foreach (string ck in cur["Details"].ObjKeys)
                                    {
                                        /*
                                         * 
							            "wiserid"		=> $row2->id,
							            "KodeBarang" 	=> $row2->barang->kodebarang,
							            "QtyKirim" 		=> $row2->qtynotaag,
							            "QtyTerima" 	=> 0,
							            "Catatan" 		=> $row2->catatan,
							            "Ongkos" 		=> null,
							            "SyncFlag" 		=> 1,
							            "QtyDO" 		=> $row2->qtyrqag,
							            "isarowid"		=> $row2->isarowid,
							            "LastUpdatedBy" => $tmp["LastUpdatedBy"],
							            "LastUpdatedTime" => $tmp["LastUpdatedTime"],
							            "HrgBeli" 		=> 0
                                         */
                                        JSON curd = cur["Details"][ck];

                                        if (curd["isarowid"].GuidValue(DBNull.Value) == DBNull.Value)
                                        {
                                            DetailID = Guid.NewGuid();
                                        }
                                        else
                                        {
                                            DetailID = (Guid)curd["isarowid"].GuidValue(DBNull.Value);
                                        }

                                        cmdl = new List<Parameter>();
                                        cmdl.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, DetailID));
                                        cmdl.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, id));
                                        cmdl.Add(new Parameter("@RecordID", SqlDbType.VarChar, FingerPrintWiser(curd["wiserid"].StringValue)));
                                        cmdl.Add(new Parameter("@TransactionID", SqlDbType.VarChar, FingerPrintWiser(curd["wiserid"].StringValue)));
                                        cmdl.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, curd["KodeBarang"].StringValue));
                                        cmdl.Add(new Parameter("@QtyKirim", SqlDbType.Int, curd["QtyKirim"].NumberValue));
                                        cmdl.Add(new Parameter("@QtyTerima", SqlDbType.Int, curd["QtyTerima"].NumberValue));
                                        cmdl.Add(new Parameter("@QtyDO", SqlDbType.Int, curd["QtyDO"].NumberValue));
                                        cmdl.Add(new Parameter("@Ongkos", SqlDbType.Money, curd["Ongkos"].NumberValue));
                                        cmdl.Add(new Parameter("@HrgBeli", SqlDbType.Money, curd["HrgBeli"].NumberValue));
                                        cmdl.Add(new Parameter("@Catatan", SqlDbType.VarChar, curd["Catatan"].StringValue));
                                        cmdl.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                                        cmdl.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, curd["LastUpdatedBy"].StringValue));
                                        cmdl.Add(new Parameter("@WiserID", SqlDbType.Int, curd["wiserid"].NumberValue));
                                        cmdl.Add(new Parameter("@WiserHeaderID", SqlDbType.Int, curd["wiserheaderid"].NumberValue));
                                        cmdl.Add(new Parameter("@WiserTag", SqlDbType.VarChar, "WISERDC"));

                                        db.Commands.Add(db.CreateCommand("[usp_AntarGudangDetail_WISERDC_SET]"));
                                        db.Commands[cid].Parameters = cmdl;
                                        cid += 1;
                                    }

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
                                            Error.LogError(ex);
                                            if (itTrasaction) db.RollbackTransaction();
                                            itOk = false;
                                            break;
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    itOk = false;
                                }

                                if (itOk)
                                {
                                    if (itTrasaction) db.CommitTransaction();
                                    scs.Add((int)cur["wiserid"].NumberValue);
                                }
                                else
                                {
                                    try
                                    {
                                        db.Commands.Clear();
                                        db.Commands.Add(db.CreateCommand("[usp_AntarGudang_WISERDC_DELETE]"));
                                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, id));
                                        db.Commands[0].Parameters.Add(new Parameter("@WiserID", SqlDbType.Int, cur["wiserid"].NumberValue));

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
                    MarkAsSuccess(scs.ToArray());

                    JSON opt = new JSON(JSONType.Object);
                    JSON lst = new JSON(JSONType.Array);
                    foreach (int ix in scs) lst.ArrAdd(new JSON(ix));
                    opt.ObjAdd("mark", new JSON(true));
                    opt.ObjAdd("ids", lst);

                    string errm = "";

                    XNet xn = new XNet(host + "/api/antargudang/synch", XNetMethod.GET);
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

        private string FingerPrintWiser(string id)
        {
            string ids = id.PadLeft(10, '0');
            string FingerPrint = "SAS" + DateTime.Now.ToString("yyMMdd") + ids + "SYNC";
            return FingerPrint;
        }

        private void MarkAsSuccess(int[] ids)
        {
            List<int> idx = new List<int>(ids);
            foreach (DataGridViewRow row in GVHeader.Rows)
            {
                if (idx.IndexOf(int.Parse(row.Cells["colid"].Value.ToString())) >= 0)
                {
                    foreach (DataGridViewColumn cl in row.DataGridView.Columns) {
                        if (cl.Name == "colCheck") {
                            row.Cells[cl.Name].Value = false;
                            row.Cells[cl.Name].Tag = true;
                        }
                        row.Cells[cl.Name].Style.BackColor = Color.FromArgb(221, 255, 181);
                    }
                }
            }
        }

        private void GVHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewCell cur = GVHeader.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cur.Tag != null && cur.Tag.Equals(true)) return;
                cur.Value = !Boolean.Parse(cur.Value.ToString());
            }
        }

    }
}
