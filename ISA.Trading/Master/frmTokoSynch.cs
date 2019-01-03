using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Utility;
using ISA.DAL;

namespace ISA.Trading.Master
{
    public partial class frmTokoSynch : ISA.Trading.BaseForm
    {
        string InitGudang;
        bool hasSynch = false;
        public DialogResult Result
        {
            get { return (hasSynch ? DialogResult.OK : DialogResult.Cancel); }
        }

        public frmTokoSynch()
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

        private void frmTokoSynch_Load(object sender, EventArgs e)
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
                foreach (DataGridViewRow row in GV01.Rows)
                {
                    if (Boolean.Parse(row.Cells["colCheck"].Value.ToString()))
                    {
                        idx.Add(int.Parse(row.Cells["colid"].Value.ToString()));
                    }
                }

                if (idx.Count > 0)
                {
                    ImportData(idx.ToArray());
                }
                else
                {
                    MessageBox.Show("Tidak ada item untuk di download");
                }
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
                apiu += "/api/toko/synch/" + GlobalVar.Gudang;

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

                                                                case "total":
                                                                case "count":
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
                                        }

                                        dset = new DataSet();
                                        mdat = jdat["Data"];
                                        dset.Tables.Add(dtbl0);
                                        GV01.Invoke(new Action(() => GV01.DataSource = dset.Tables[0]));

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

                while (xnt.OnWorking)
                {
                    if (bgw.CancellationPending)
                    {
                        b.Cancel = true;
                        xnt.Cancel();
                        break;
                    }
                };
                if (b.Result != null && !b.Result.Equals(true)) throw new Exception(b.Result.ToString());
            };
            bgw.RunWorkerCompleted += (a, b) =>
            {
                bool r = false;
                if (b.Cancelled) MessageBox.Show(thisx, "Operasi di gagalkan");
                else if (b.Error != null) MessageBox.Show(thisx, b.Error.Message);
                //else if (dtbl0.Rows.Count == 0) { MessageBox.Show("Tidak Ada Data"); return; }
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
                foreach (int i in ids)
                {
                    JSON cur = mdat[i.ToString()];
                    List<Parameter> cmdl = new List<Parameter>();
                    List<Parameter> cmd2 = new List<Parameter>();

                    JSON jdat, jdat2 = null;
                    jdat = this.ImportDataToko(cur, new JSON());
                    jdat2 = this.ImportDataStatus(cur, new JSON());

                    cmdl = (List<Parameter>)jdat["params"].Value;
                    cmd2 = (List<Parameter>)jdat2["params"].Value;

                    try
                    {
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("[usp_PullTokoWiser_V2]"));
                        db.Commands[0].Parameters = cmdl;
                        db.Commands[0].ExecuteNonQuery();

                        DataTable dtbl = db.Commands[0].ExecuteDataTable();
                        if (dtbl.Rows.Count > 0)
                        {
                            DataRow dr = dtbl.Rows[0];
                            if (dr["Result"].ToString() == "1") MessageBox.Show("Data Toko berhasil di download");
                            else MessageBox.Show("Error Toko : " + dr["Msg"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Toko : " + ex);
                    }

                    try
                    {
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("[usp_PullStatusTokoWiser_V2]"));
                        db.Commands[0].Parameters = cmd2;
                        db.Commands[0].ExecuteNonQuery();

                        DataTable dtbl2 = db.Commands[0].ExecuteDataTable();
                        if (dtbl2.Rows.Count > 0)
                        {
                            DataRow dr2 = dtbl2.Rows[0];
                            if (dr2["Result"].ToString() == "1") MessageBox.Show("Data Status Toko berhasil di download");
                            else MessageBox.Show("Error Status Toko : " + dr2["Msg"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Status Toko : " + ex);
                    }
                }
            }
        }

        private JSON ImportDataToko(JSON cur, JSON jdat)
        {
            JSON res = new JSON(JSONType.Object);
            List<Parameter> cmdl = new List<Parameter>();

            cmdl.Add(new Parameter("@KodeToko", SqlDbType.VarChar, cur["kodetoko"].StringValue));
            cmdl.Add(new Parameter("@TokoID", SqlDbType.VarChar, cur["tokoidwarisan"].StringValue));
            cmdl.Add(new Parameter("@NamaToko", SqlDbType.VarChar, cur["namatoko"].StringValue));
            cmdl.Add(new Parameter("@Alamat", SqlDbType.VarChar, cur["alamat"].StringValue));
            cmdl.Add(new Parameter("@Propinsi", SqlDbType.VarChar, cur["propinsi"].StringValue));
            cmdl.Add(new Parameter("@Kota", SqlDbType.VarChar, cur["kota"].StringValue));
            cmdl.Add(new Parameter("@Kecamatan", SqlDbType.VarChar, cur["kecamatan"].StringValue));
            cmdl.Add(new Parameter("@CustomWilayah", SqlDbType.VarChar, cur["customwilayah"].StringValue));
            cmdl.Add(new Parameter("@Telp", SqlDbType.VarChar, cur["telp"].StringValue));
            cmdl.Add(new Parameter("@Fax", SqlDbType.VarChar, cur["fax"].StringValue));
            cmdl.Add(new Parameter("@Penanggungjawab", SqlDbType.VarChar, cur["penanggungjawab"].StringValue));
            cmdl.Add(new Parameter("@TglDob", SqlDbType.DateTime, cur["tgldob"].DateTimeValue(DBNull.Value)));
            cmdl.Add(new Parameter("@Catatan", SqlDbType.VarChar, cur["catatan"].StringValue));
            cmdl.Add(new Parameter("@Pemilik", SqlDbType.VarChar, cur["pemilik"].StringValue));
            cmdl.Add(new Parameter("@Gender", SqlDbType.VarChar, cur["gender"].StringValue));
            cmdl.Add(new Parameter("@TempatLahir", SqlDbType.VarChar, cur["tempatlahir"].StringValue));
            cmdl.Add(new Parameter("@TglLahir", SqlDbType.DateTime, cur["tgllahir"].DateTimeValue(DBNull.Value)));
            cmdl.Add(new Parameter("@Email", SqlDbType.VarChar, cur["email"].StringValue));
            cmdl.Add(new Parameter("@NoRekening", SqlDbType.VarChar, cur["norekening"].StringValue));
            cmdl.Add(new Parameter("@NamaBank", SqlDbType.VarChar, cur["namabank"].StringValue));
            cmdl.Add(new Parameter("@NoNPWP", SqlDbType.VarChar, cur["nonpwp"].StringValue));
            cmdl.Add(new Parameter("@TipeBisnis", SqlDbType.VarChar, cur["tipebisnis"].StringValue));
            cmdl.Add(new Parameter("@HP", SqlDbType.VarChar, cur["hp"].StringValue));
            cmdl.Add(new Parameter("@NoKTP", SqlDbType.VarChar, cur["no_ktp"].StringValue));
            cmdl.Add(new Parameter("@PiutangB", SqlDbType.Money, cur["piutangb"].NumberValue));
            cmdl.Add(new Parameter("@PiutangJ", SqlDbType.Money, cur["piutangj"].NumberValue));
            cmdl.Add(new Parameter("@Plafon", SqlDbType.Money, cur["plafon"].NumberValue));
            cmdl.Add(new Parameter("@JangkaWaktuKredit", SqlDbType.Int, cur["jangkawaktukredit"].NumberValue));
            cmdl.Add(new Parameter("@ClassID", SqlDbType.VarChar, cur["classid"].StringValue));
            cmdl.Add(new Parameter("@HariKirim", SqlDbType.Int, cur["harikirim"].NumberValue));
            cmdl.Add(new Parameter("@KodePos", SqlDbType.VarChar, cur["kodepos"].StringValue));
            cmdl.Add(new Parameter("@Grade", SqlDbType.VarChar, cur["grade"].StringValue));
            cmdl.Add(new Parameter("@Plafon1st", SqlDbType.Money, cur["plafon1st"].NumberValue));
            cmdl.Add(new Parameter("@StatusAktif", SqlDbType.Bit, cur["statusaktif"].Value));
            cmdl.Add(new Parameter("@HariSales", SqlDbType.Int, cur["harisales"].NumberValue));
            cmdl.Add(new Parameter("@Daerah", SqlDbType.VarChar, cur["daerah"].StringValue));
            cmdl.Add(new Parameter("@AlamatRumah", SqlDbType.VarChar, cur["alamatrumah"].StringValue));
            cmdl.Add(new Parameter("@Pengelola", SqlDbType.VarChar, cur["pengelola"].StringValue));
            cmdl.Add(new Parameter("@ThnBerdiri", SqlDbType.VarChar, cur["thnberdiri"].StringValue));
            cmdl.Add(new Parameter("@StatusRuko", SqlDbType.Bit, cur["statusruko"].Value));
            cmdl.Add(new Parameter("@JmlCabang", SqlDbType.Int, cur["jmlcabang"].NumberValue));
            cmdl.Add(new Parameter("@JmlSales", SqlDbType.Int, cur["jmlsales"].NumberValue));
            cmdl.Add(new Parameter("@Kinerja", SqlDbType.VarChar, cur["kinerja"].StringValue));
            cmdl.Add(new Parameter("@I_Spart", SqlDbType.VarChar, cur["i_spart"].StringValue));
            cmdl.Add(new Parameter("@Bangunan", SqlDbType.VarChar, cur["bangunan"].StringValue));
            cmdl.Add(new Parameter("@Habis_Kontrak", SqlDbType.DateTime, cur["habis_kontrak"].DateTimeValue(DBNull.Value)));
            cmdl.Add(new Parameter("@Jenis_Produk", SqlDbType.VarChar, cur["jenis_produk"].StringValue));
            cmdl.Add(new Parameter("@StatusWilayah", SqlDbType.VarChar, cur["statuswilayah"].StringValue));
            cmdl.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            res["params"] = new JSON(JSONType.Unknown, cmdl);

            return res;
        }

        private JSON ImportDataStatus(JSON cur, JSON jdat)
        {
            JSON res = new JSON(JSONType.Object);
            List<Parameter> cmdl = new List<Parameter>();

            cmdl.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, cur["isarowid"].GuidValue(DBNull.Value)));
            cmdl.Add(new Parameter("@cabangid", SqlDbType.VarChar, cur["kodecabang"].StringValue));
            cmdl.Add(new Parameter("@KodeToko", SqlDbType.VarChar, cur["kodetoko"].StringValue));
            cmdl.Add(new Parameter("@TglAktif", SqlDbType.DateTime, cur["tglaktif"].DateTimeValue(DBNull.Value)));
            cmdl.Add(new Parameter("@Status", SqlDbType.VarChar, cur["status"].StringValue));
            cmdl.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
            cmdl.Add(new Parameter("@Keterangan", SqlDbType.VarChar, cur["keterangan"].StringValue));
            cmdl.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
            cmdl.Add(new Parameter("@KStatus", SqlDbType.VarChar, cur["kstatus"].StringValue));
            cmdl.Add(new Parameter("@WilID", SqlDbType.VarChar, cur["customwilayah"].StringValue));
            cmdl.Add(new Parameter("@TglPasif", SqlDbType.DateTime, cur["tglpasif"].DateTimeValue(DBNull.Value)));
            cmdl.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            cmdl.Add(new Parameter("@LastUpdatedTime", SqlDbType.DateTime, GlobalVar.DateTimeOfServer));
            cmdl.Add(new Parameter("@Roda", SqlDbType.VarChar, cur["roda"].StringValue));
            cmdl.Add(new Parameter("@tglaktifjw", SqlDbType.DateTime, cur["tglaktifjw"].DateTimeValue(DBNull.Value)));
            cmdl.Add(new Parameter("@jwbe", SqlDbType.Int, cur["jw"].NumberValue));
            cmdl.Add(new Parameter("@jxbe", SqlDbType.Int, cur["jx"].NumberValue));
            cmdl.Add(new Parameter("@jsbe", SqlDbType.Int, cur["js"].NumberValue));

            res["params"] = new JSON(JSONType.Unknown, cmdl);

            return res;
        }

        private void GV01_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView GV = (DataGridView)sender;
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewCell cur = GV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cur.Tag != null && cur.Tag.Equals(true)) return;
                cur.Value = !Boolean.Parse(cur.Value.ToString());
            }
        }

        private void GV01_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int rowIndex = 0; rowIndex < GV01.Rows.Count; rowIndex++)
            {
                if (Convert.ToBoolean(GV01.Rows[rowIndex].Cells["colstatusaktif"].Value.ToString()) == true)
                    GV01.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                else
                    GV01.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
        }
    }
}
