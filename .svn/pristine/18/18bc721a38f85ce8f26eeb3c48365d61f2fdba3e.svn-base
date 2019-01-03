using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Expedisi
{
    public partial class frmPenyelesaianEkspedisiUpdate : ISA.Trading.BaseForm
    {
        Guid _rowID;
        string TrID, NoKirim, Tujuan, Sopir, Kernet, NoPolisi, KetLain, JamKirim;
        DateTime TglKirim;
        int NPrint;
        double KMBerangkat;
        DateTime Dateback;

        public  DateTime TglKembali
        {
            get { return Dateback; }
            set { Dateback = value; }
        }
        public frmPenyelesaianEkspedisiUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            this.Caller = caller;
            _rowID = rowID;
        }

        private void frmPenyelesaianEkspedisiUpdate_Load(object sender, EventArgs e)
        {
            txtTglKembali.DateValue = DateTime.Today;
            txtTglKembali.Focus();
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanEkspedisi_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                double TotKel = Convert.ToDouble(dt.Rows[0]["BBMRp"]) + Convert.ToDouble(dt.Rows[0]["UMSopir"])+ Convert.ToDouble(dt.Rows[0]["UMKernet"]) + Convert.ToDouble(dt.Rows[0]["Parkir"])+ Convert.ToDouble(dt.Rows[0]["Tol"]) + Convert.ToDouble(dt.Rows[0]["Kuli"])+ Convert.ToDouble(dt.Rows[0]["IzinMasuk"]) + Convert.ToDouble(dt.Rows[0]["Timbangan"])+ Convert.ToDouble(dt.Rows[0]["InTepatWaktu"]) + Convert.ToDouble(dt.Rows[0]["InPengiriman"]) + Convert.ToDouble(dt.Rows[0]["Lain"]);
                //nSisa = Hxpdckp.KasBon-nTotKel
                double Sisa = Convert.ToDouble(dt.Rows[0]["KasBon"]) - TotKel;

                DateTime TglKembali = new DateTime();
                string TglKembali2;
                if (!DateTime.TryParse(dt.Rows[0]["TglKembali"].ToString(), out TglKembali))
                {
                    TglKembali2 = DateTime.Today.ToString("dd/MM/yyyy");
                }
                else
                {
                    TglKembali2 = TglKembali.ToString("dd/MM/yyyy");
                }
                txtTglKembali.Text = TglKembali2;
                txtJamKembali.Text = Tools.isNull(dt.Rows[0]["JamKembali"], "").ToString();
                txtKMKembali.Text = Tools.isNull(dt.Rows[0]["KMKirim"], "").ToString();
                txtBrgTarikan.Text = Tools.isNull(dt.Rows[0]["Tarikan"], "").ToString();
                txtKasBon.Text = Tools.isNull(dt.Rows[0]["KasBon"], "").ToString();
                txtBBMLtr.Text = Tools.isNull(dt.Rows[0]["BBMLtr"], "").ToString();
                txtBBMRp.Text = Tools.isNull(dt.Rows[0]["BBMRp"], "").ToString();
                txtumSopir.Text = Tools.isNull(dt.Rows[0]["UMSopir"], "").ToString();
                txtUmKernet.Text = Tools.isNull(dt.Rows[0]["UMKernet"], "").ToString();
                txtParkir.Text = Tools.isNull(dt.Rows[0]["Parkir"], "").ToString();
                txtTol.Text = Tools.isNull(dt.Rows[0]["Tol"], "").ToString();
                txtKuli.Text = Tools.isNull(dt.Rows[0]["Kuli"], "").ToString();
                txtBiayaIzinMasuk.Text = Tools.isNull(dt.Rows[0]["IzinMasuk"], "").ToString();
                txtBiayaTimbangan.Text = Tools.isNull(dt.Rows[0]["Timbangan"], "").ToString();
                txtInTepatWaktu .Text = Tools.isNull(dt.Rows[0]["InTepatWaktu"], "").ToString();
                txtInPengiriman.Text = Tools.isNull(dt.Rows[0]["InPengiriman"], "").ToString();
                txtLain.Text = Tools.isNull(dt.Rows[0]["Lain"], "").ToString();
                txtTolKel.Text = TotKel.ToString();
                txtSisa.Text = Sisa.ToString();

                TrID  = dt.Rows[0]["TrID"].ToString();
                NoKirim = dt.Rows[0]["NoKirim"].ToString();
                TglKirim = (DateTime)dt.Rows[0]["TglKirim"];
                Tujuan = dt.Rows[0]["Tujuan"].ToString();
                Sopir = dt.Rows[0]["Sopir"].ToString();
                Kernet = dt.Rows[0]["Kernet"].ToString();
                NoPolisi = dt.Rows[0]["NoPolisi"].ToString();
                KetLain = dt.Rows[0]["KetLain"].ToString();
                NPrint = Convert.ToInt32(dt.Rows[0]["NPrint"]);
                JamKirim = dt.Rows[0]["JamKirim"].ToString();
                KMBerangkat = Convert.ToDouble(dt.Rows[0]["KMBerangkat"]);
    
            }
            catch(Exception ex)
            {
                Error.LogError(ex);
            }


        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (txtTglKembali.DateValue.HasValue==false)
            {
                ErrorProvider err = new ErrorProvider();
                err.SetError(txtTglKembali,"Harus Di Isi !!");
                return;
            }

             if (txtTglKembali.DateValue.Value<TglKirim)
            {
                ErrorProvider err = new ErrorProvider();
                err.SetError(txtTglKembali,"Tidak Boleh Lebih Kecil Dari Tanggal Kirim!!");
                return;
            }

            
            try
            {
                GlobalVar.LastClosingDate = (DateTime)txtTglKembali.DateValue;
                if (txtTglKembali.DateValue <= GlobalVar.LastClosingDate)
                {
                    ErrorProvider ep = new ErrorProvider();
                    ep.SetError(txtTglKembali, "Telah Closing");
                    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));

                }
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanEkspedisi_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID ));
                            
                    db.Commands[0].Parameters.Add(new Parameter("@trID", SqlDbType.VarChar, TrID));
                    db.Commands[0].Parameters.Add(new Parameter("@noKirim", SqlDbType.VarChar, NoKirim ));
                    db.Commands[0].Parameters.Add(new Parameter("@tglKirim", SqlDbType.DateTime, TglKirim));
                    db.Commands[0].Parameters.Add(new Parameter("@tglKembali", SqlDbType.DateTime, txtTglKembali.DateValue ));
                    db.Commands[0].Parameters.Add(new Parameter("@tujuan", SqlDbType.VarChar, Tujuan));
                    db.Commands[0].Parameters.Add(new Parameter("@sopir", SqlDbType.VarChar, Sopir));
                    db.Commands[0].Parameters.Add(new Parameter("@kernet", SqlDbType.VarChar, Kernet));
                    db.Commands[0].Parameters.Add(new Parameter("@noPolisi", SqlDbType.VarChar, NoPolisi));
                    db.Commands[0].Parameters.Add(new Parameter("@kasBon", SqlDbType.Money, txtKasBon.GetDoubleValue ));
                    db.Commands[0].Parameters.Add(new Parameter("@bbmltr", SqlDbType.Money, Convert.ToDouble(txtBBMLtr.Text) ));
                    db.Commands[0].Parameters.Add(new Parameter("@bbmRp", SqlDbType.Money, txtBBMRp.GetDoubleValue));//Convert.ToDouble(txtBBMRp.Text)
                    db.Commands[0].Parameters.Add(new Parameter("@umSopir", SqlDbType.Money, txtumSopir.GetDoubleValue));// Convert.ToDouble(txtumSopir.Text)
                    db.Commands[0].Parameters.Add(new Parameter("@umKernet", SqlDbType.Money, txtUmKernet.GetDoubleValue));// Convert.ToDouble(txtUmKernet.Text)
                    db.Commands[0].Parameters.Add(new Parameter("@parkir", SqlDbType.Money, txtParkir.GetDoubleValue ));
                    db.Commands[0].Parameters.Add(new Parameter("@tol", SqlDbType.Money, Convert.ToDouble(txtTol.Text)));
                    db.Commands[0].Parameters.Add(new Parameter("@kuli", SqlDbType.Money, Convert.ToDouble(txtKuli.Text) ));
                    db.Commands[0].Parameters.Add(new Parameter("@lain", SqlDbType.Money, Convert.ToDouble(txtLain.Text) ));
                    db.Commands[0].Parameters.Add(new Parameter("@ketLain", SqlDbType.VarChar, KetLain));
                    db.Commands[0].Parameters.Add(new Parameter("@tarikan", SqlDbType.Money, Convert.ToDouble(txtBrgTarikan.Text )));
                    db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, NPrint ));
                    db.Commands[0].Parameters.Add(new Parameter("@jamKirim", SqlDbType.VarChar, JamKirim ));
                    db.Commands[0].Parameters.Add(new Parameter("@jamKembali", SqlDbType.VarChar, txtJamKembali.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kmBerangkat", SqlDbType.Money, KMBerangkat));
                    db.Commands[0].Parameters.Add(new Parameter("@kmKirim", SqlDbType.Money, txtKMKembali.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@izinMasuk", SqlDbType.Money,  txtBiayaIzinMasuk.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@timbangan", SqlDbType.Money, txtBiayaTimbangan.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@inTepatWaktu", SqlDbType.Money, txtInTepatWaktu.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@inPengiriman", SqlDbType.Money, txtInPengiriman.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                }
                //MessageBox.Show(Messages.Confirm.UpdateSuccess);
                Dateback = txtTglKembali.DateValue.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            //REPLACE Hxpdckp.Tgl_kbl WITH dTgl_kbl,Hxpdckp.Jam_kbl WITH cJam_kbl,;
            //Hxpdckp.Km_kbl WITH nKm_kbl,Hxpdckp.J_tarikan WITH nJ_tarikan,Hxpdckp.Kasbon WITH nKasbon,;
            //Hxpdckp.Bbm_llr WITH nBbm_llr,Hxpdckp.Bbm_rp WITH nBbm_rp,Hxpdckp.Um_sopir WITH nUm_sopir,;
            //Hxpdckp.Um_kernet WITH nUm_kernet,Hxpdckp.Parkir WITH nParkir,Hxpdckp.Tol WITH nTol,;
            //Hxpdckp.Kuli WITH nKuli,Hxpdckp.Izin_msk WITH nIzin_msk,Hxpdckp.Timbangan WITH nTimbangan,;
            //Hxpdckp.In_tpt_wtk WITH nI_tpt_wtk,Hxpdckp.In_pgrm WITH nI_pgrm,Hxpdckp.Lain WITH nLain
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calculated()
        {
            double kasbon = 0;
            double bbm = 0;
            double umSopir = 0;
            double umKernet = 0;
            double parkir = 0;
            double tol = 0;
            double kuli = 0;
            double ijinMasuk = 0;
            double timbangan = 0;
            double insTepatWaktu = 0;
            double insPengiriman = 0;
            double lain = 0;

            if (!txtKasBon.Text.Equals(string.Empty))
            {
               kasbon  = double.Parse(txtKasBon.Text);
            }
            if (!txtBBMRp.Text.Equals(string.Empty))
            {
                bbm = double.Parse(txtBBMRp.Text);
            }
            if (!txtumSopir.Text.Equals(string.Empty))
            {
                umSopir = double.Parse(txtumSopir.Text);
            }
            if (!txtUmKernet.Text.Equals(string.Empty))
            {
                umKernet = double.Parse(txtUmKernet.Text);
            }
            if (!txtParkir.Text.Equals(string.Empty))
            {
                parkir = double.Parse(txtParkir.Text);
            }
            if (!txtTol.Text.Equals(string.Empty))
            {
                tol = double.Parse(txtTol.Text);
            }
            if (!txtKuli.Text.Equals(string.Empty))
            {
                kuli = double.Parse(txtKuli.Text);
            }
            if (!txtBiayaIzinMasuk.Text.Equals(string.Empty))
            {
                ijinMasuk = double.Parse(txtBiayaIzinMasuk.Text);
            }
            if (!txtBiayaTimbangan.Text.Equals(string.Empty))
            {
                timbangan = double.Parse(txtBiayaTimbangan.Text);
            }
            if (!txtInTepatWaktu.Text.Equals(string.Empty))
            {
                insTepatWaktu = double.Parse(txtInTepatWaktu.Text);
            }
            if (!txtInPengiriman.Text.Equals(string.Empty))
            {
                insPengiriman = double.Parse(txtInPengiriman.Text);
            }
            if (!txtLain.Text.Equals(string.Empty))
            {
                lain = double.Parse(txtLain.Text);
            }

            double totalPengeluaran = bbm + umSopir + umKernet + parkir + tol + kuli + ijinMasuk + timbangan + insTepatWaktu + insPengiriman + lain;
            double sisa = kasbon - totalPengeluaran;

            txtTolKel.Text = totalPengeluaran.ToString("#,###");
            txtSisa.Text = sisa.ToString("#,###");
        }

        private void txtKasBon_TextChanged(object sender, EventArgs e)
        {
            calculated();
        }

        private void txtBBMRp_TextChanged(object sender, EventArgs e)
        {
            calculated();
        }

        private void txtumSopir_TextChanged(object sender, EventArgs e)
        {
            calculated();
        }

        private void txtUmKernet_TextChanged(object sender, EventArgs e)
        {
            calculated();
        }

        private void txtParkir_TextChanged(object sender, EventArgs e)
        {
            calculated();
        }

        private void txtTol_TextChanged(object sender, EventArgs e)
        {
            calculated();
        }

        private void txtKuli_TextChanged(object sender, EventArgs e)
        {
            calculated();
        }

        private void txtBiayaIzinMasuk_TextChanged(object sender, EventArgs e)
        {
            calculated();
        }

        private void txtBiayaTimbangan_TextChanged(object sender, EventArgs e)
        {
            calculated();
        }

        private void txtInTepatWaktu_TextChanged(object sender, EventArgs e)
        {
            calculated();
        }

        private void txtInPengiriman_TextChanged(object sender, EventArgs e)
        {
            calculated();
        }

        private void txtLain_TextChanged(object sender, EventArgs e)
        {
            calculated();
        }
    }
}
