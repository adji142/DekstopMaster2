using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Utility;
using ISA.DAL;
using System.Globalization;

namespace ISA.Trading.PJ3
{
    public partial class frmKoreksiJualSynch : ISA.Trading.BaseForm
    {
        string InitGudang;
        bool hasSynch = false;

        string cab1 = "", cab2 = "";
        string docNoKoreksi = "KOREKSI PENJUALAN";
        int lebar;
        int iNomor;
        string depan;
        string belakang;
        string strNoKoreksi;

        DataTable dtNota;

        public DialogResult Result
        {
            get { return (hasSynch ? DialogResult.OK : DialogResult.Cancel); }
        }

        public frmKoreksiJualSynch()
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

        private void frmNotaPenjualanSynch_Load(object sender, EventArgs e)
        {
            if (InitGudang == null || InitGudang == "") this.Close();
            rangeDateBox1.FromDate = rangeDateBox1.ToDate = DateTime.Now;
            GVHeader.AutoGenerateColumns = false;
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
                    else { 
                        MessageBox.Show("Wiser belum di setting");
                        return;
                    }
                }

                XNet xn = new XNet(host + "/api/koreksipenjualan/get", XNetMethod.GET);
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
                                                    case "Details":
                                                        // do nothing
                                                        break;
                                                    default:
                                                        if (dtbl0.Rows.Count <= 0) dtbl0.Columns.Add(k2);
                                                        itm.Add(cur[k2].Value);
                                                        break;
                                                }
                                            }

                                            dtbl0.Rows.Add(itm.ToArray());
                                        }

                                        dset = new DataSet();
                                        mdat = jdat["Data"];
                                        dset.Tables.Add(dtbl0);

                                        GVHeader.Invoke(new Action(() => GVHeader.DataSource = dset.Tables[0]));

                                        b.Result = true;
                                        return;
                                    }
                                    throw new Exception("Response server is not expected");
                                }
                                else
                                {
                                    if (jdat.ObjExists("Msg")) throw new Exception("Server error: " + jdat["Msg"]);
                                    else throw new Exception(jdat.ToString());
                                }
                            }
                            else throw new Exception(c.Output);
                        }
                        else throw new Exception("Tidak ada response dari server");
                    }
                    catch (Exception ex)
                    {
                        b.Result = ex.Message;
                    }
                });

                while (xnt.OnWorking)
                {
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
            Form thisx = this;

            if (ipProgress == null) ipProgress = new InPopup(this, pnlProgress);
            if (fpProgress == null) fpProgress = new FakeProgress(progbProgress);

            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += (a, b) =>
            {
                fpProgress.Start();

                using (var db = new Database())
                {
                    if (bgw.CancellationPending) return;

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

                    Guid _headerRowID, _detailID;
                    List<int> scs = new List<int>();
                    foreach (int i in ids)
                    {
                        JSON cur = mdat[i.ToString()];
                        List<Parameter> cmdl = new List<Parameter>();
                        db.Commands.Clear();

                        //DateTime tTerima = DateTime.ParseExact(cur["TglTerima"].StringValue, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        //MessageBox.Show(cur["NotaRowID"].GuidValue(DBNull.Value).ToString());
                        //return;
                        
                        generateNoKoreksi();

                        _headerRowID = Guid.NewGuid();
                        cmdl.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _headerRowID));
                        cmdl.Add(new Parameter("@RecordID", SqlDbType.VarChar, FingerPrintWiser(cur["wiserid"].StringValue)));
                        cmdl.Add(new Parameter("@NotaJualDetailWiserID", SqlDbType.Int, cur["NotaJualDetailWiserID"].NumberValue));
                        cmdl.Add(new Parameter("@TglKoreksi", SqlDbType.DateTime, cur["TglKoreksi"].DateTimeValue(DBNull.Value)));
                        cmdl.Add(new Parameter("@NoKoreksi", SqlDbType.VarChar, strNoKoreksi));
                        cmdl.Add(new Parameter("@BarangID", SqlDbType.VarChar, cur["BarangID"].StringValue));
                        cmdl.Add(new Parameter("@QtyNotaBaru", SqlDbType.Int, cur["QtyNotaBaru"].NumberValue));
                        cmdl.Add(new Parameter("@HrgJualBaru", SqlDbType.Money, cur["HrgJualBaru"].NumberValue));
                        cmdl.Add(new Parameter("@Catatan", SqlDbType.VarChar, cur["Catatan"].StringValue));
                        cmdl.Add(new Parameter("@KodeToko", SqlDbType.VarChar, cur["KodeToko"].StringValue));
                        cmdl.Add(new Parameter("@Sumber", SqlDbType.VarChar, cur["Sumber"].StringValue));
                        cmdl.Add(new Parameter("@HrgJualKoreksi", SqlDbType.Int, cur["HrgJualKoreksi"].NumberValue));
                        cmdl.Add(new Parameter("@QtyNotaKoreksi", SqlDbType.Int, cur["QtyNotaKoreksi"].NumberValue));
                        cmdl.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                        //cmdl.Add(new Parameter("@LinkID", SqlDbType.VarChar, ""));
                        cmdl.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, cur["LastUpdatedBy"].StringValue));
                        cmdl.Add(new Parameter("@wiserid", SqlDbType.Int, cur["wiserid"].NumberValue));
                        cmdl.Add(new Parameter("@WiserTag", SqlDbType.VarChar, "WISERDC"));
                        
                        try
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_KoreksiPenjualan_WISERDC_SET"));
                            db.Commands[0].Parameters = cmdl;
                            db.Commands[0].ExecuteNonQuery();

                            db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                            db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoKoreksi));
                            db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                            db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                            db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                            db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                            db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            db.Commands[1].ExecuteNonQuery();

                            scs.Add((int)cur["wiserid"].NumberValue);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex);
                        }
                    }

                    if (scs.Count > 0)
                    {
                        MessageBox.Show("DATA BERHASIL DITAMBAHKAN");
                    }
                    else MessageBox.Show("Synch gagal");

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

                        XNet xn = new XNet(host + "/api/koreksipenjualan/synch", XNetMethod.GET);
                        XNetThread xnt = xn.Send(opt, r =>
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
                    }
                    else MessageBox.Show("Synch gagal");

                    b.Result = true;
                    return;
                }
                if (b.Result != null && !b.Result.Equals(true))
                {
                    MessageBox.Show(b.Result.ToString());
                    return;
                }
            };
            bgw.RunWorkerCompleted += (a, b) =>
            {
                bool r = false;
                if (b.Cancelled) MessageBox.Show(thisx, "Operasi di gagalkan");
                else if (b.Error != null) MessageBox.Show(thisx, b.Error.Message);
                else r = true;

                ipProgress.Close(r);
                this.Close();
            };

            ipProgress.OpenDialog(this, a =>
            {
            }, () => bgw.CancelAsync());
            bgw.RunWorkerAsync();
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
                    foreach (DataGridViewColumn cl in row.DataGridView.Columns)
                    {
                        if (cl.Name == "colCheck")
                        {
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

        private void generateNoKoreksi()
        {
            DataTable dtNum = Tools.GetGeneralNumerator(docNoKoreksi);
            lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
            iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
            depan = dtNum.Rows[0]["Depan"].ToString();
            belakang = dtNum.Rows[0]["Belakang"].ToString();
            iNomor++;
            strNoKoreksi = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
        }

    }
}
