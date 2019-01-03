using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Toko.VACCDO_Pos
{
    public partial class frmPlafonPosISA : ISA.Toko.BaseForm
    {
        string _kodeToko;
        bool start=false;
        Guid _headerID;
        string docNO = "NOMOR_ACC_DO";
        DateTime _tglDo;
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string initPerusahaan = GlobalVar.PerusahaanID;
        double _RpNet3 = 0,_RpGiroTolak=0;
        string noNota=string.Empty;
        double Plafon = 0, RpJual = 0, Saldo = 0, Gbc = 0, Tolak = 0, Ovd = 0, Debet = 0, Kredit = 0, _RpDO=0;
        string depan = string.Empty;
        public frmPlafonPosISA(Form caller, Guid headerID, string kodeToko, DateTime tglDO)
        {
            InitializeComponent();
             formMode = enumFormMode.New;
             _headerID = headerID;
             _kodeToko = kodeToko;
             _tglDo = tglDO;
            this.Caller = caller;
           
        }



        private void frmPlafonPosISA_Load(object sender, EventArgs e)
        {
            rdbPenuh.Checked = true; 
            
            string noACCDO;
          
           
            if (formMode == enumFormMode.New)
            {
                try
                {
                    DataTable dt = new DataTable();
                    DataTable dtOP = new DataTable();
                    DataTable dtT = new DataTable();

                    using (Database db = new Database())
                    {

                        //db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_GetHrgNet"));
                        //db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                        //_RpDO = Convert.ToDouble(db.Commands[0].ExecuteScalar());
                        //txtNilaiDO.Text = _RpDO.ToString("#,##0");

                        db.Commands.Add(db.CreateCommand("usp_ACCDOPos_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _headerID));
                        dtOP = db.Commands[0].ExecuteDataTable();


                        _RpDO = Convert.ToDouble(dtOP.Rows[0]["HrgNet"]);
                        noNota = Tools.isNull(dtOP.Rows[0]["NoACCPiutang"], "").ToString();
                        _RpNet3 = Convert.ToDouble(Tools.isNull(dtOP.Rows[0]["RpACCPiutang"], "0").ToString());
                       
                        db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                        db.Commands[1].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                        dtT = db.Commands[1].ExecuteDataTable();
                        Plafon = Convert.ToDouble(dtT.Rows[0]["Plafon"]);

                    }
                    if (noNota != "")
                    {
                        noACCDO = Tools.isNull(dtOP.Rows[0]["NoACCPiutang"], "").ToString();
                        _RpGiroTolak = Convert.ToDouble(Tools.isNull(dtOP.Rows[0]["RpGiroTolakTerakhir"], "0").ToString());
                        Plafon = Convert.ToDouble(dtOP.Rows[0]["RpPlafonToko"]);
                        Saldo = Convert.ToDouble(dtOP.Rows[0]["RpPiutangTerakhir"]);
                        Tolak = Convert.ToDouble(dtOP.Rows[0]["RpGiroTolakTerakhir"]);
                        Ovd = Convert.ToDouble(dtOP.Rows[0]["RpOverdue"]);
                        txtPlafon.Text = Plafon.ToString();
                        txtSaldoAkhir.Text = (Saldo + Tolak).ToString();
                        txtSisaPlafon.Text = (Plafon - Saldo).ToString();
                        txtNilaiOverdue.Text = Ovd.ToString();

                        txtACCOleh.Text = SecurityManager.UserID;
                        txtNilaiDO.Text = _RpDO.ToString("#,##0");
                    }
                    else
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_fnCekPlafon"));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));
                            Plafon = Convert.ToDouble(db.Commands[0].ExecuteScalar());


                            db.Commands.Add(db.CreateCommand("usp_RpJualkartuPiutang"));
                            db.Commands[1].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                            RpJual = Convert.ToDouble(db.Commands[1].ExecuteScalar());

                            DataTable dtG = new DataTable();
                            db.Commands.Add(db.CreateCommand("[usp_GetNominalgiro]"));
                            db.Commands[2].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                            dtG = db.Commands[2].ExecuteDataTable();

                            Gbc = Convert.ToDouble(dtG.Rows[0]["RpGiro"]);
                            Tolak = Convert.ToDouble(dtG.Rows[0]["RpGiroTolakDebet"]) - Convert.ToDouble(dtG.Rows[0]["RpGiroTolakKredit"]);


                            db.Commands.Add(db.CreateCommand("[usp_GetOVD]"));
                            db.Commands[3].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                            db.Commands[3].Parameters.Add(new Parameter("@tgljatuhTempo", SqlDbType.DateTime, _tglDo));
                            Ovd = Convert.ToDouble(db.Commands[3].ExecuteScalar());

                            RpJual = RpJual + Gbc;

                            txtPlafon.Text = Plafon.ToString("#,##0");
                            txtSaldoAkhir.Text = (RpJual + Tolak).ToString("#,##0");
                            txtSisaPlafon.Text = (Plafon-RpJual).ToString("#,##0");
                            txtNilaiDO.Text = _RpDO.ToString("#,##0");
                            txtACCOleh.Text = SecurityManager.UserID;
                            txtNilaiOverdue.Text = Ovd.ToString("#,##0");

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
           
            
            txtRpACC.Text = "0";
            if (rdbPenuh.Checked == true)
            {
                depan = "F";
                txtRpACC.Text = txtNilaiDO.Text;
                txtRpACC.Enabled = false;
                txtACCOleh.Focus();
                txtCatatan.Text = "ACC FULL";
            }
            else if (rdbSebagian.Checked == true)
            {
                depan = "S";
              
                txtRpACC.Text = "0";
                txtRpACC.Text = _RpNet3.ToString("#,##0");

                txtRpACC.Enabled = true;
                txtRpACC.Focus();
                txtCatatan.Text = "ACC SEBAGIAN";
                
            }
            else
            {
                depan = "T";
                txtRpACC.Text = "0";
                txtRpACC.Enabled = false;
                txtACCOleh.Focus();
                txtCatatan.Text = "ACC DITOLAK";

            }
           
            string Nomor = string.Empty;
            if (noNota != "" )
            {
                Nomor = noNota.Substring(2,noNota.Length-2);// SUBSTR(hhtransj.no_nota,2,6)
                txtNoACC.Text = depan + Nomor;
            }
            else
            {
                DataTable dtNum = Tools.GetGeneralNumerator(docNO);
                int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                //string depan = Tools.GeneralInitial();
                string belakang = dtNum.Rows[0]["Belakang"].ToString();
                iNomor++;
                Nomor = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                txtNoACC.Text = Nomor;
            }
            txtTglACC.Text = DateTime.Today.ToString("dd/MM/yyyy");

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
                if(initPerusahaan.Substring(1,0)=="0")
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
                   // string depan = Tools.GeneralInitial();
                    string belakang = dtNum.Rows[0]["Belakang"].ToString();
                    iNomor++;
                    string strNoACC = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                    
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[usp_ACCDOPOS_UPDATE]"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));
                        db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, strNoACC));
                        db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, txtTglACC.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@RpACCPiutang", SqlDbType.Money, txtRpACC.GetDoubleValue ));
                        db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, txtACCOleh.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, txtCatatan.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@RpPlafonToko", SqlDbType.Money, Convert.ToDouble(txtPlafon.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@RpPiutangTerakhir", SqlDbType.Money, txtSaldoAkhir.GetDoubleValue));//Convert.ToDouble(txtSaldoAkhir.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@RpGiroTolakTerakhir", SqlDbType.Money, 0));//Convert.ToDouble(txtSaldoAkhir.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@RpOverdue", SqlDbType.Money, txtNilaiOverdue.GetDoubleValue));//Convert.ToDouble(txtNilaiOverdue.Text)));
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
                    MessageBox.Show(Messages.Confirm.UpdateSuccess  + "\nNo Acc: " + strNoACC );
                    this.DialogResult = DialogResult.OK;
                    frmACCDOPosBrowseISA frmCaller = (frmACCDOPosBrowseISA)this.Caller;
                    frmCaller.RefreshRowDataDO(_headerID.ToString());
                   // frmCaller.RefreshDataSeluruhnya ();
                    this.Close();
                    //frmCaller.Show();
                }
            }
 
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
