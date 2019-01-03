using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Persediaan
{
    public partial class frmStandarStokHitungAll : ISA.Toko.BaseForm
    {


        #region "Var & Function"
        DataTable dts, dt1,dt2,dt3,dt4 = new DataTable();
        public enum enumFormMode { One, All };
        enumFormMode formMode;
      

        string _KodeBarang, _NamaStok, _KodeRak, _KodeRak1, _KodeRak2, _SatSolo, _Bundle, _Kendaraan, _SatJual;
        Guid _RowID, RowIDStok;
        bool _StatusPasif;
        int _AVG, lamaKirim, hariRata2;


        public frmStandarStokHitungAll(Form caller, string KodeBarang)
        {
            _KodeBarang = KodeBarang;
            this.Caller = caller;
            InitializeComponent();
           
        }

        private void RefreshData()
        {
            frmStandarStok frmCaller = (frmStandarStok)this.Caller;
            frmCaller.RefreshData1(_KodeBarang);
            
        }

        private void InsertAllRecord(string KodeBarang, int AVG)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_StandarStok_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglMT", SqlDbType.DateTime, txtTgl.DateValue.Value));                
                    db.Commands[0].Parameters.Add(new Parameter("@Var1", SqlDbType.Float, txtMin.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Var2", SqlDbType.Float, txtMax.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, KodeBarang));
                    db.Commands[0].Parameters.Add(new Parameter("@AVGHari", SqlDbType.Int, AVG));
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

        private int GetRate(string KodeBarang,int nRate)
        {


            int val = 0;

            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("usp_StandarStok_Recalculate"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, txtTgl.DateValue.Value.AddMonths(-6)));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, txtTgl.DateValue.Value.AddDays(-1)));
                db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, KodeBarang));
                db.Commands[0].Parameters.Add(new Parameter("@QOPN", SqlDbType.Int, nRate));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));

                val = Convert.ToInt32(db.Commands[0].ExecuteScalar());

            }

            return val;
        }

        private bool ChekStd()
        {

        
                int val = 0;
              
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("[fsp_HasStandarStok]"));
                    db.Commands[0].Parameters.Add(new Parameter("@checkDate", SqlDbType.DateTime, txtTgl.DateValue.Value));
                    val = Convert.ToInt32(db.Commands[0].ExecuteScalar());

                }

                if (val>0)
                {
                    return false;
                }else
                {
                    return true;
                }
               
               
           

        }

        private void GetStok()
        {
           
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("[usp_StandarStok_Get]"));
                dts=db.Commands[0].ExecuteDataTable();

            }
            
        }

        #endregion

        public frmStandarStokHitungAll()
        {
            InitializeComponent();
        }

        private void frmStandarStokHitungAll_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(GlobalVar.DateOfServer.AddMonths(-6).Year, GlobalVar.DateOfServer.AddMonths(-6).Month, 1); // new DateTime(DateTime.Now.Year, DateTime.Now.Month-3, 1); edited by SLA
            rangeDateBox1.ToDate = new DateTime(GlobalVar.DateOfServer.AddMonths(-1).Year, GlobalVar.DateOfServer.AddMonths(-1).Month, DateTime.DaysInMonth(GlobalVar.DateOfServer.AddMonths(-1).Year, GlobalVar.DateOfServer.AddMonths(-1).Month)); // DateTime.Today.Year, DateTime.Today.Month-1, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month-1)); edited by SLA
            txtTgl.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtTgl.ReadOnly = true;
            progressBar1.Value = 0;
            lblStok.Text = string.Empty;
            progressBar1.Visible = false;
            rbRata2Jual.Checked = true;
       
        }

        private void cekBuffer()
        {
            int jarak = 0;
            int fromdate = Convert.ToInt32(rangeDateBox1.FromDate.Value.Month);
            int todate = Convert.ToInt32(rangeDateBox1.ToDate.Value.Month);
            jarak = (todate - fromdate)+1;

            //radiobutton1
            if (rbRata2Jual.Checked == true)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[fsp_CekBuffer_rata2JualPerbulan]"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@jarak", SqlDbType.Int, jarak));
                        dt1 = db.Commands[0].ExecuteDataTable();
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }

            //radiobutton2
            if (RbJualTinggi.Checked == true)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[fsp_CekBuffer_PenjualanTertinggi]"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                        dt2 = db.Commands[0].ExecuteDataTable();
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }


            //radiobutton3
            if (rbjualxlt.Checked == true)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[fsp_CekBuffer_RataJualLatetime]"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                        dt3 = db.Commands[0].ExecuteDataTable();
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }

            //radiobutton4
            if (rbjualperbulanxlt.Checked == true)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[fsp_CekBuffer_RataJualperbulanLatetime]"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                        dt4 = db.Commands[0].ExecuteDataTable();
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            getBuffer(dt1,dt2,dt3,dt4);
        }


        private void getBuffer(DataTable dt1, DataTable dt2, DataTable dt3, DataTable dt4)
        {
            int nAvgJual = 0;
            int nQbuffer = 0;
            int ncolly = 0;
            int nHari = 0;
            int jarak = 0;
            string barangid;
            string barangidstok;
            string namastok;
            int fromdate = Convert.ToInt32(rangeDateBox1.FromDate.Value.Month);
            int todate = Convert.ToInt32(rangeDateBox1.ToDate.Value.Month);
            jarak = (todate - fromdate) + 1;
            #region radiobutton1
            //radiobutton1
            if (rbRata2Jual.Checked == true)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    barangid = dt1.Rows[i]["BarangID"].ToString();
                    barangidstok = dts.Rows[i]["BarangID"].ToString();

                    nAvgJual = Convert.ToInt32(dt1.Rows[i]["njual"]);
                    nQbuffer = Convert.ToInt32(dt1.Rows[i]["njual"]);
                    decimal nbuffer;
                    if (barangid == barangidstok)
                    {
                        namastok = dts.Rows[i]["NamaStok"].ToString();
                        if (namastok.Contains("BUSI"))
                        {
                            if (nQbuffer > 0 && nQbuffer < 10)
                            {
                                nQbuffer = 10;
                            }
                            else
                            {
                                nbuffer = Convert.ToDecimal(nQbuffer / 10);
                                ncolly = Convert.ToInt32(Math.Round(nbuffer, 0));
                                nQbuffer = ncolly * 10;
                            }
                        }

                        else if (namastok.Contains("OLI") || namastok.Contains("TOP 1"))
                        {
                            if (nQbuffer > 0 && nQbuffer < 24)
                            {
                                nQbuffer = 24;
                            }
                            else
                            {
                                nbuffer = Convert.ToDecimal(nQbuffer / 24);
                                ncolly = Convert.ToInt32(Math.Round(nbuffer, 0));
                                nQbuffer = ncolly * 24;
                            }
                        }
                        else
                        {
                            if (nQbuffer > 0 && nQbuffer < 5)
                            {
                                nQbuffer = 5;
                            }
                            else
                            {
                                nbuffer = Convert.ToDecimal(nQbuffer / 5);
                                ncolly = Convert.ToInt32(Math.Round(nbuffer, 0));
                                nQbuffer = ncolly * 5;
                            }
                        }
                    }

                    if (nQbuffer >= 1 && nAvgJual >= 1)
                    {
                        try
                        {
                            //update kalo barang uda punya buffer ganti tmt2 nya aja
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("[usp_StokBuffer_update]"));
                                db.Commands[0].Parameters.Add(new Parameter("@barangid", SqlDbType.VarChar, barangid));
                              //  db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, txtTgl.Text.ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, txtTgl.DateValue.Value));
                                db.Commands[0].Parameters.Add(new Parameter("@kdgudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@lastupdateby", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                        try
                        {
                            //insert kalo barang belum punya buffer
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("[usp_stokBuffer_insert]"));
                                db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                                db.Commands[0].Parameters.Add(new Parameter("@barangid", SqlDbType.VarChar, barangid));
                                //db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, txtTgl.Text.ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, txtTgl.DateValue.Value));
                                db.Commands[0].Parameters.Add(new Parameter("@qbuffer", SqlDbType.NChar, nQbuffer));
                                db.Commands[0].Parameters.Add(new Parameter("@kd_gdg", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@avgjual", SqlDbType.NChar, nAvgJual));
                                db.Commands[0].Parameters.Add(new Parameter("@lastupdateBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }

                    }
                }
            }
            #endregion
            
            #region radiobutton2
            //radiobutton2
            if (RbJualTinggi.Checked == true)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    barangid = dt2.Rows[i]["BarangID"].ToString();
                    barangidstok = dts.Rows[i]["BarangID"].ToString();

                    nAvgJual = Convert.ToInt32(dt2.Rows[i]["njual"]);
                    nQbuffer = Convert.ToInt32(dt2.Rows[i]["njual"]);
                    decimal nbuffer;
                    if (barangid == barangidstok)
                    {
                        namastok = dts.Rows[i]["NamaStok"].ToString();
                        if (namastok.Contains("BUSI"))
                        {
                            if (nQbuffer > 0 && nQbuffer < 10)
                            {
                                nQbuffer = 10;
                            }
                            else
                            {
                                nbuffer = Convert.ToDecimal(nQbuffer / 10);
                                ncolly = Convert.ToInt32(Math.Round(nbuffer, 0));
                                nQbuffer = ncolly * 10;
                            }
                        }

                        else if (namastok.Contains("OLI") || namastok.Contains("TOP 1"))
                        {
                            if (nQbuffer > 0 && nQbuffer < 24)
                            {
                                nQbuffer = 24;
                            }
                            else
                            {
                                nbuffer = Convert.ToDecimal(nQbuffer / 24);
                                ncolly = Convert.ToInt32(Math.Round(nbuffer, 0));
                                nQbuffer = ncolly * 24;
                            }
                        }
                        else
                        {
                            if (nQbuffer > 0 && nQbuffer < 5)
                            {
                                nQbuffer = 5;
                            }
                            else
                            {
                                nbuffer = Convert.ToDecimal(nQbuffer / 5);
                                ncolly = Convert.ToInt32(Math.Round(nbuffer, 0));
                                nQbuffer = ncolly * 5;
                            }
                        }
                    }

                    if (nQbuffer >= 1 && nAvgJual >= 1)
                    {
                        try
                        {
                            //update kalo barang uda punya buffer ganti tmt2 nya aja
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("[usp_StokBuffer_update]"));
                                db.Commands[0].Parameters.Add(new Parameter("@barangid", SqlDbType.VarChar, barangid));
                                //db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, txtTgl.Text.ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, txtTgl.DateValue.Value));
                                db.Commands[0].Parameters.Add(new Parameter("@kdgudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@lastupdateby", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }


                            //insert kalo barang belum punya buffer
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("[usp_stokBuffer_insert]"));
                                db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                                db.Commands[0].Parameters.Add(new Parameter("@barangid", SqlDbType.VarChar, barangid));
                                //db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, txtTgl.Text.ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, txtTgl.DateValue.Value));
                                db.Commands[0].Parameters.Add(new Parameter("@qbuffer", SqlDbType.NChar, nQbuffer));
                                db.Commands[0].Parameters.Add(new Parameter("@kd_gdg", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@avgjual", SqlDbType.NChar, nAvgJual));
                                db.Commands[0].Parameters.Add(new Parameter("@lastupdateBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }
                }
            }
            #endregion

            #region radiobutton3
            //radiobutton3

            if (rbjualxlt.Checked == true)
            {
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                barangid = dt3.Rows[i]["BarangID"].ToString();
                barangidstok = dts.Rows[i]["BarangID"].ToString();
                
                    nAvgJual = Convert.ToInt32(dt3.Rows[i]["njual"]);
                    nQbuffer = Convert.ToInt32(dt3.Rows[i]["njual"]);
                    nHari = 25;
                    decimal nbuffer;
                    if (barangid == barangidstok)
                    {
                        namastok = dts.Rows[i]["NamaStok"].ToString();
                        if (namastok.Contains("BUSI"))
                        {
                            if (nQbuffer > 0 && nQbuffer < 10)
                            {
                                nQbuffer = 10;
                            }
                            else
                            {
                                nbuffer = Convert.ToDecimal(nQbuffer / 10);
                                ncolly = Convert.ToInt32(Math.Round(nbuffer, 0));
                                nQbuffer = ncolly * 10;
                            }
                        }

                        else if (namastok.Contains("OLI") || namastok.Contains("TOP 1"))
                        {
                            if (nQbuffer > 0 && nQbuffer < 24)
                            {
                                nQbuffer = 24;
                            }
                            else
                            {
                                nbuffer = Convert.ToDecimal(nQbuffer / 24);
                                ncolly = Convert.ToInt32(Math.Round(nbuffer, 0));
                                nQbuffer = ncolly * 24;
                            }
                        }
                        else
                        {
                            if (nQbuffer > 0 && nQbuffer < 5)
                            {
                                nQbuffer = 5;
                            }
                            else
                            {
                                nbuffer = Convert.ToDecimal(nQbuffer / 5);
                                ncolly = Convert.ToInt32(Math.Round(nbuffer, 0));
                                nQbuffer = ncolly * 5;
                            }
                        }
                    }

                    nAvgJual = nAvgJual / (nHari * jarak);
                    if (barangid.Substring(0, 2) == "FB" || barangid.Substring(0, 2) == "FE")
                    {
                        nQbuffer = nAvgJual * 57;
                    }
                    else
                    {
                        nQbuffer = nAvgJual * 17;
                    }


                    if (nQbuffer >= 1 && nAvgJual >= 1)
                    {
                        try
                        {
                            //update kalo barang uda punya buffer ganti tmt2 nya aja
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("[usp_StokBuffer_update]"));
                                db.Commands[0].Parameters.Add(new Parameter("@barangid", SqlDbType.VarChar, barangid));
                                db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, txtTgl.Text.ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@kdgudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@lastupdateby", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }


                            //insert kalo barang belum punya buffer
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("[usp_stokBuffer_insert]"));
                                db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                                db.Commands[0].Parameters.Add(new Parameter("@barangid", SqlDbType.VarChar, barangid));
                                db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, txtTgl.Text.ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@qbuffer", SqlDbType.NChar, nQbuffer));
                                db.Commands[0].Parameters.Add(new Parameter("@kd_gdg", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@avgjual", SqlDbType.NChar, nAvgJual));
                                db.Commands[0].Parameters.Add(new Parameter("@lastupdateBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }
                }
            }
            #endregion

            #region radiobutton4

            //radiobutton4
            if (rbjualperbulanxlt.Checked == true)
            {
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                barangid = dt4.Rows[i]["BarangID"].ToString();
                barangidstok = dts.Rows[i]["BarangID"].ToString();
                
                    nAvgJual = Convert.ToInt32(dt4.Rows[i]["njual"]);
                    nQbuffer = Convert.ToInt32(dt4.Rows[i]["njual"]);
                    nHari = 25;
                    decimal nbuffer;
                    if (barangid == barangidstok)
                    {
                        namastok = dts.Rows[i]["NamaStok"].ToString();
                        if (namastok.Contains("BUSI"))
                        {
                            if (nQbuffer > 0 && nQbuffer < 10)
                            {
                                nQbuffer = 10;
                            }
                            else
                            {
                                nbuffer = Convert.ToDecimal(nQbuffer / 10);
                                ncolly = Convert.ToInt32(Math.Round(nbuffer, 0));
                                nQbuffer = ncolly * 10;
                            }
                        }

                        else if (namastok.Contains("OLI") || namastok.Contains("TOP 1"))
                        {
                            if (nQbuffer > 0 && nQbuffer < 24)
                            {
                                nQbuffer = 24;
                            }
                            else
                            {
                                nbuffer = Convert.ToDecimal(nQbuffer / 24);
                                ncolly = Convert.ToInt32(Math.Round(nbuffer, 0));
                                nQbuffer = ncolly * 24;
                            }
                        }
                        else
                        {
                            if (nQbuffer > 0 && nQbuffer < 5)
                            {
                                nQbuffer = 5;
                            }
                            else
                            {
                                nbuffer = Convert.ToDecimal(nQbuffer / 5);
                                ncolly = Convert.ToInt32(Math.Round(nbuffer, 0));
                                nQbuffer = ncolly * 5;
                            }
                        }
                    }
                    nAvgJual = nAvgJual / nHari;
                    if (barangid.Substring(0, 2) == "FB" || barangid.Substring(0, 2) == "FE")
                    {
                        nQbuffer = nAvgJual * 57;
                    }
                    else
                    {
                        nQbuffer = nAvgJual * 17;
                    }

                    if (nQbuffer >= 1 && nAvgJual >= 1)
                    {

                        try
                        {
                            //update kalo barang uda punya buffer ganti tmt2 nya aja
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("[usp_StokBuffer_update]"));
                                db.Commands[0].Parameters.Add(new Parameter("@barangid", SqlDbType.VarChar, barangid));
                                db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, txtTgl.Text.ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@kdgudang", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@lastupdateby", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }


                            //insert kalo barang belum punya buffer
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("[usp_stokBuffer_insert]"));
                                db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                                db.Commands[0].Parameters.Add(new Parameter("@barangid", SqlDbType.VarChar, barangid));
                                db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, txtTgl.Text.ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@qbuffer", SqlDbType.NChar, nQbuffer));
                                db.Commands[0].Parameters.Add(new Parameter("@kd_gdg", SqlDbType.VarChar, GlobalVar.Gudang));
                                db.Commands[0].Parameters.Add(new Parameter("@avgjual", SqlDbType.NChar, nAvgJual));
                                db.Commands[0].Parameters.Add(new Parameter("@lastupdateBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }
                }
            }
            #endregion
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {

            if (txtMax.GetDoubleValue <= 0 || txtMax.GetDoubleValue<txtMin.GetDoubleValue)
            {
                txtMax.Focus();
                return;
            }

            if (txtMin.GetDoubleValue <= 0 || txtMin.GetDoubleValue>txtMax.GetDoubleValue)
            {
                txtMin.Focus();
                return;
            }

            if (MessageBox.Show("Proses perhitungan Standar Stok , \n Periode : " + rangeDateBox1.FromDate.Value.ToString("dd-MMM-yyyy") + " s/d" + rangeDateBox1.ToDate.Value.ToString("dd-MMM-yyyy"), "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (ChekStd() == false)
            {
                MessageBox.Show("Sudah Di Hitung Pada Bulan Ini");
                return;
            }
          

            try
            {
                this.Cursor = Cursors.WaitCursor;
                progressBar1.Value = 0;
                progressBar1.Minimum = 0; 
                
                progressBar1.Visible = true;
                
                GetStok();
                cekBuffer();
                progressBar1.Maximum = dts.Rows.Count;

                int val = 0;
                int i = 0;
                foreach (DataRow dr in dts.Rows)
                {
                    lblStok.Text = dr["NamaStok"].ToString();
                    val = 0;
                   // val = GetRate(dr["BarangID"].ToString(), Convert.ToInt32(dr["HariRataRata"]));

                    val = GetRate(dr["BarangID"].ToString(), 6);

                    
                        InsertAllRecord(dr["BarangID"].ToString(), val);
                    
                    progressBar1.Value = i; ;
                    Application.DoEvents();
                    this.Invalidate();
                    i++;
                }

                progressBar1.Visible = false;
                lblStok.Text = string.Empty;
                this.Close();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                
                this.Cursor = Cursors.Default;
            }

        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMax_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

     

    }
}
