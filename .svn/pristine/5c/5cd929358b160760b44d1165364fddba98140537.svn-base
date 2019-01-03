using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Toko.VACCDO
{
    public partial class frmPlafon : ISA.Toko.BaseForm
    {
        string _kodeToko;
        bool start;
        Guid _headerID;
        string docNO = "NOMOR_ACC_DO";
        DateTime _tglDo;
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string initPerusahaan = GlobalVar.PerusahaanID;

        public frmPlafon(Form caller, Guid headerID, string kodeToko, DateTime tglDO)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _headerID = headerID;
            _kodeToko = kodeToko;
            _tglDo = tglDO;
            this.Caller = caller;
            MessageBox.Show(_kodeToko);
        }

        //public frmPlafon(Form caller,Guid headerID)
        //{
        //    InitializeComponent();
        //    formMode = enumFormMode.Update;
        //    _headerID=headerID;
        //    this.Caller = caller;
        //}

        private void frmPlafon_Load(object sender, EventArgs e)
        {
            rdbPenuh.Checked = true;
            string noNota;
            string noACCDO;
            double Plafon, RpJual, Saldo, Gbc, Tolak, Ovd, Debet, Kredit;

            if (formMode == enumFormMode.New)
            {
                try
                {
                    DataTable dt = new DataTable();
                    DataTable dtOP = new DataTable();
                    DataTable dtT = new DataTable();

                    using (Database db = new Database())
                    {

                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST_FILTER_HEADERID"));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                        dt = db.Commands[0].ExecuteDataTable();

                        if (dt.Rows.Count == 0)
                        {
                            txtNilaiDO.Text = "0";
                        }
                        else
                        {
                            txtNilaiDO.Text = dt.Compute("SUM(HrgNet)", "").ToString();//Tools.isNull(dt.Rows[0]["HrgNet"], "").ToString();
                        }

                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST"));
                        db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _headerID));
                        dtOP = db.Commands[1].ExecuteDataTable();
                        noNota = Tools.isNull(dtOP.Rows[0]["NoACCPiutang"], "").ToString();

                        db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                        db.Commands[2].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                        dtT = db.Commands[2].ExecuteDataTable();
                        Plafon = Convert.ToDouble(dtT.Rows[0]["Plafon"]);

                    }
                    if (noNota != "")
                    {
                        noACCDO = Tools.isNull(dtOP.Rows[0]["NoACCPiutang"], "").ToString();
                        Plafon = Convert.ToDouble(dtOP.Rows[0]["RpPlafonToko"]);
                        Saldo = Convert.ToDouble(dtOP.Rows[0]["RpPiutangTerakhir"]);
                        Tolak = Convert.ToDouble(dtOP.Rows[0]["RpGiroTolakTerakhir"]);
                        Ovd = Convert.ToDouble(dtOP.Rows[0]["RpOverdue"]);
                        txtPlafon.Text = Plafon.ToString();
                        txtSaldoAkhir.Text = (Saldo + Tolak).ToString();
                        txtSisaPlafon.Text = (Plafon - Saldo).ToString();
                        txtNilaiOverdue.Text = Ovd.ToString();

                        txtACCOleh.Text = SecurityManager.UserID;
                    }
                    else
                    {
                        Tolak = 0;
                        DataTable dt1 = new DataTable();
                        try
                        {

                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                                dt1 = db.Commands[0].ExecuteDataTable();

                                if (dt1.Rows.Count > 0)
                                {
                                    db.Commands.Add(db.CreateCommand("usp_fnCekPlafon"));
                                    db.Commands[1].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                                    db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));
                                    dt1 = db.Commands[1].ExecuteDataTable();
                                    if (dt1.Rows.Count > 0)
                                    {
                                        Plafon = Convert.ToDouble(dt1.Rows[0]["Plafon"]);
                                    }
                                    //Plafon = 2000000;

                                }
                                db.Commands.Add(db.CreateCommand("usp_vwRpJualkartuPiutang"));
                                db.Commands[2].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                                dt1 = db.Commands[2].ExecuteDataTable();
                                if (dt1.Rows.Count > 0)
                                {//RpJual
                                    RpJual = Convert.ToDouble(dt1.Rows[0]["RpJual"]);
                                }
                                else
                                {
                                    RpJual = 0;
                                }

                                db.Commands.Add(db.CreateCommand("usp_vwDebetKreditDetailPiutang"));
                                db.Commands[3].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                                dt1 = db.Commands[3].ExecuteDataTable();
                                if (dt1.Rows.Count > 0)
                                {
                                    Debet = Convert.ToDouble(dt1.Rows[0]["Debet"]);
                                    Kredit = Convert.ToDouble(dt1.Rows[0]["Kredit"]);
                                }
                                else
                                {
                                    Debet = 0;
                                    Kredit = 0;
                                }
                                //Saldo
                                Saldo = (RpJual + Debet) - Kredit;

                                db.Commands.Add(db.CreateCommand("usp_vwNominalgiro"));
                                db.Commands[4].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                                dt1 = db.Commands[4].ExecuteDataTable();
                                if (dt1.Rows.Count > 0)
                                {
                                    Gbc = Convert.ToDouble(dt1.Rows[0]["Gbc"]);
                                }
                                else
                                {
                                    Gbc = 0;
                                }

                                db.Commands.Add(db.CreateCommand("usp_vwDebetDibayarbankGiroTolak"));
                                db.Commands[5].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                                dt1 = db.Commands[5].ExecuteDataTable();
                                double dDebet, dDibayar;
                                if (dt1.Rows.Count > 0)
                                {
                                    dDebet = Convert.ToDouble(dt1.Rows[0]["Debet"]);
                                    dDibayar = Convert.ToDouble(dt1.Rows[0]["Dibayar"]);
                                }
                                else
                                {
                                    dDebet = 0;
                                    dDibayar = 0;
                                }

                                if (dDebet - dDibayar > 0)
                                {
                                    Gbc = Gbc + dDebet;
                                }

                                //Saldo
                                Saldo = Saldo + (Gbc - dDibayar);

                                db.Commands.Add(db.CreateCommand("usp_vwOVD"));
                                db.Commands[6].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                                db.Commands[6].Parameters.Add(new Parameter("@tgljatuhTempo", SqlDbType.VarChar, _tglDo));
                                dt1 = db.Commands[6].ExecuteDataTable();
                                if (dt1.Rows.Count > 0)
                                {
                                    Ovd = Convert.ToDouble(dt1.Rows[0]["OVD"]);
                                }
                                else
                                {
                                    Ovd = 0;
                                }
                                //Ovd
                                Ovd = Ovd + (RpJual - Kredit);

                                //else
                                //{

                                //    Plafon = 2000000;
                                //    Saldo = 2000000;
                                //    Tolak = 0;
                                //    Ovd = 0;
                                //}

                                txtPlafon.Text = Plafon.ToString();
                                txtSaldoAkhir.Text = (Saldo + Tolak).ToString();
                                txtSisaPlafon.Text = (Plafon - Saldo).ToString();
                                txtNilaiOverdue.Text = Ovd.ToString();

                                txtACCOleh.Text = SecurityManager.UserID;
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST_FILTER_HEADERID"));
                db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                dt = db.Commands[0].ExecuteDataTable();


            }
            txtRpACC.Text = "0";
            if (rdbPenuh.Checked == true)
            {
                //depan = "F";
                txtRpACC.Text = txtNilaiDO.Text;
                txtRpACC.Enabled = false;
                txtACCOleh.Focus();
                txtCatatan.Text = "ACC FULL";
            }
            else if (rdbSebagian.Checked == true)
            {
                //depan = "S";
                //if (dt.Rows.Count != 0)
                //{
                //    txtRpACC.Text = Tools.isNull(dt.Rows[0]["HrgNet"], "").ToString();
                //}
                //else
                //{
                txtRpACC.Text = "0";
                //}

                txtRpACC.Enabled = true;
                txtRpACC.Focus();
                txtCatatan.Text = "ACC SEBAGIAN";

            }
            else
            {
                //depan = "T";
                txtRpACC.Text = "0";
                txtRpACC.Enabled = false;
                txtACCOleh.Focus();
                txtCatatan.Text = "ACC DITOLAK";

            }
            //string noNota = dt.Rows[0]["NoACCPiutang"].ToString();
            //if ( noNota != "")
            //{
            //    Nomor = noNota.Substring(2,6);// SUBSTR(hhtransj.no_nota,2,6)
            //}
            txtTglACC.Text = DateTime.Today.ToString("dd/MM/yyyy");
            //txtNoACC.Text = depan + nomor;

            start = true;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (start != true)
            {
                MessageBox.Show("Anda belum proses ACC ; Klik Tombol Start");
            }
            else
            {
                if (initPerusahaan.Substring(1, 0) == "0")
                {
                    initPerusahaan = "C";
                }
                else
                {
                    initPerusahaan = "0";
                }

                if (rdbSebagian.Checked == true & (Convert.ToDouble(txtRpACC.Text) >= Convert.ToDouble(txtNilaiDO.Text)))
                {
                    MessageBox.Show("Nilai ACC tidak boleh melebihi dan sama dengan Nilai DO");
                }
                else
                {
                    DataTable dt = new DataTable();
                    //GENERATE Nomor Acc
                    DataTable dtNum = Tools.GetGeneralNumerator(docNO);
                    int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                    int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                    string depan = Tools.GeneralInitial();
                    string belakang = dtNum.Rows[0]["Belakang"].ToString();
                    iNomor++;
                    string strNoACC = Tools.FormatNumerator(iNomor, lebar, depan, belakang);

                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_ACCDO_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));
                        db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, strNoACC));
                        db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, txtTglACC.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@RpACCPiutang", SqlDbType.Money, Convert.ToDouble(txtRpACC.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, txtACCOleh.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, txtCatatan.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@RpPlafonToko", SqlDbType.Money, Convert.ToDouble(txtPlafon.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@RpPiutangTerakhir", SqlDbType.Money, 0));//Convert.ToDouble(txtSaldoAkhir.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@RpGiroTolakTerakhir", SqlDbType.Money, 0));//Convert.ToDouble(txtSaldoAkhir.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@RpOverdue", SqlDbType.Money, 0));//Convert.ToDouble(txtNilaiOverdue.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, initPerusahaan));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));


                        db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                        db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNO));
                        db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                        db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                        db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                        db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                        db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.BeginTransaction();
                        db.Commands[0].ExecuteNonQuery();
                        db.Commands[1].ExecuteNonQuery();
                        db.CommitTransaction();
                    }
                    start = false;
                    txtNoACC.Text = strNoACC;
                    MessageBox.Show(Messages.Confirm.UpdateSuccess + "\nNo Acc: " + strNoACC);
                    this.DialogResult = DialogResult.OK;
                    frmACCDOBrowse frmCaller = (frmACCDOBrowse)this.Caller;
                    frmCaller.RefreshDataSeluruhnya();
                    this.Close();
                    frmCaller.Show();
                }
            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
