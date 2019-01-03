using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Trading.xpdc
{
    public partial class frm_header_xpdc : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        Guid rID;
        string docNoPengiriman = "NOMOR_PENGIRIMAN";
        DataTable dt;

        DataTable dtNum;
        int lebar, iNomor;
        string depan, belakang;
        string panjang = string.Empty;
        int pnj;

        public frm_header_xpdc(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frm_header_xpdc(Form caller,Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            rID = rowID;
            this.Caller = caller;
        }

        private void Header_xpdc_Load(object sender, EventArgs e)
        {
            Tglkrm.DateValue = GlobalVar.DateOfServer;

            docNoPengiriman = "NOMOR_PENGIRIMAN_XPDC";
            DataTable dtNum = Tools.GetGeneralNumerator(docNoPengiriman);
            int lebar = 5;
            int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
            string depan = dtNum.Rows[0]["Depan"].ToString().Trim();     //Tools.GeneralInitial();

            //panjang = depan;
            //pnj = panjang.Length;
            //MessageBox.Show(iNomor.ToString());
            
            string belakang = dtNum.Rows[0]["Belakang"].ToString();
            iNomor++;
            string strNumerator = Tools.FormatNumerator(iNomor, lebar, depan, belakang);

            Spk();
            TujuanExp();

            if (formMode == enumFormMode.New)
            {
                //Tglkirim.Format = DateTimePickerFormat.Custom;
                //Tglkirim.CustomFormat = " dd,MMMM,yyyy";
                cboSopir.SelectedIndex = -1;
                cboKernet.SelectedIndex = -1;
                cboTujuan.SelectedIndex = -1;
            }
            else
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanEkspedisi_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                Tglkrm.Text = string.Format("{0:dd-MM-yyyy}", dt.Rows[0]["TglKirim"]);
                NoSj.Text = Tools.isNull(dt.Rows[0]["NoKirim"], "").ToString();
                JamKirim.Text = Tools.isNull(dt.Rows[0]["JamKirim"], "").ToString();
                KmBerangkat.Text = Tools.isNull(dt.Rows[0]["KMBerangkat"], "").ToString();
                cboSopir.SelectedValue = Tools.isNull(dt.Rows[0]["Sopir"], "").ToString();
                cboKernet.SelectedValue = Tools.isNull(dt.Rows[0]["Kernet"], "").ToString();
                cboTujuan.SelectedValue = Tools.isNull(dt.Rows[0]["Tujuan"], "").ToString();
                NoPolisi.Text = Tools.isNull(dt.Rows[0]["NoPolisi"], "").ToString();
                lookupExpedisi1.NamaExpedisi = Tools.isNull(dt.Rows[0]["NamaExpedisi"], "").ToString();
                lookupExpedisi1.KodeExpedisi = Tools.isNull(dt.Rows[0]["KodeExpedisi"], "").ToString();
                bool bAtk = false;
                bAtk = bool.Parse(Tools.isNull(dt.Rows[0]["Atk"], false).ToString());
                if (bAtk == false)
                    cbAtk.Checked = false;
                else
                    cbAtk.Checked = true;
            }
        }

        private void Spk()
        {
            using (Database db = new Database())
            {
                DataTable dtPD = new DataTable();
                DataTable dtPD2 = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Sopir_LIST"));
                dtPD = db.Commands[0].ExecuteDataTable();
                dtPD2 = db.Commands[0].ExecuteDataTable();

                cboSopir.ValueMember = "Nama";
                cboSopir.DisplayMember = "Nama";
                cboSopir.DataSource = dtPD;

                cboKernet.ValueMember = "Nama";
                cboKernet.DisplayMember = "Nama";
                cboKernet.DataSource = dtPD2;

            }
        }

        private void TujuanExp()
        {
            using (Database db = new Database())
            {
                DataTable dtt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_TujuanExpedisi_LIST"));
                dtt = db.Commands[0].ExecuteDataTable();

                cboTujuan.ValueMember = "Tujuan";
                cboTujuan.DisplayMember = "Tujuan";
                cboTujuan.DataSource = dtt;
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HeaderSave_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.New:
                    if (InsertHeader())
                    {
                        if (this.Caller is frm_kirim)
                        {
                            frm_kirim frmCaller = (frm_kirim)this.Caller;
                            frmCaller.RefreshDataXpdc();
                        }
                        this.Close();
                    }
                    break;
                case enumFormMode.Update:
                    if (UpdateHeader())
                    {
                        if (this.Caller is frm_kirim)
                        {
                            frm_kirim frmCaller = (frm_kirim)this.Caller;
                            frmCaller.RefreshDataXpdc();
                        }
                        this.Close();
                    }
                    break;
                    
                    //xpdc.frm_kirim frmCaller = new xpdc.frm_kirim(this,rID);
                    //frmCaller.RefreshDataXpdc();
                    //frmCaller.FindHeader("RowID", _rowID.ToString());
                    //this.Close();
                    //frmCaller.Show();
            }

        }

        private bool InsertHeader()
        {
            bool retVal = false;

            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                try
                {
                    DataTable dtNum = Tools.GetGeneralNumerator(docNoPengiriman);
                    int lebar = 5;
                    int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                    string depan = "SJ";    // Tools.GeneralInitial();
                    string belakang = dtNum.Rows[0]["Belakang"].ToString();
                    iNomor++;
                    string strNumerator = Tools.FormatNumerator(iNomor, lebar, depan, belakang);

                    bool _Atk = false;
                    if (cbAtk.Checked)
                    {
                        _Atk = true;
                    }

                    _rowID = Guid.NewGuid();
                    db.BeginTransaction();
                    db.Commands.Add(db.CreateCommand("usp_PengirimanXpdc_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@trID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@noKirim", SqlDbType.VarChar, strNumerator));
                    db.Commands[0].Parameters.Add(new Parameter("@tglKirim", SqlDbType.DateTime, Tglkrm.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglKembali", SqlDbType.DateTime, SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@tujuan", SqlDbType.VarChar, cboTujuan.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@sopir", SqlDbType.VarChar, cboSopir.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@kernet", SqlDbType.VarChar, cboKernet.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@noPolisi", SqlDbType.VarChar, NoPolisi.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kasBon", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@bbmltr", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@bbmRp", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@umSopir", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@umKernet", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@parkir", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@tol", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@kuli", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lain", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@ketLain", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@tarikan", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@jamKirim", SqlDbType.VarChar, JamKirim.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@jamKembali", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@kmBerangkat", SqlDbType.Int, (string.IsNullOrEmpty(KmBerangkat.Text) == true ? 0 : int.Parse(KmBerangkat.Text))));
                    db.Commands[0].Parameters.Add(new Parameter("@kmKirim", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@izinMasuk", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@timbangan", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@inTepatWaktu", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@inPengiriman", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeExpedisi", SqlDbType.VarChar, Tools.isNull(lookupExpedisi1.KodeExpedisi,"").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaExpedisi", SqlDbType.VarChar, Tools.isNull(lookupExpedisi1.NamaExpedisi,"").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Atk", SqlDbType.Bit, _Atk));

                    //MessageBox.Show("masuk ke sp1");

                    // update numerator
                    db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                    db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoPengiriman));
                    db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                    db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                    db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                    db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //MessageBox.Show("masuk ke sp2");

                    db.Commands[0].ExecuteNonQuery();
                    db.Commands[1].ExecuteNonQuery();
                    db.CommitTransaction();

                    retVal = true;

                    MessageBox.Show("Data Berhasil Di simpan");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    db.RollbackTransaction();
                    MessageBox.Show("Gagal Menyimpan Data");
                }

                return retVal;
            }
        }


        private bool UpdateHeader()
        {
            bool retVal = false;
            bool _Atk = false;
            if (cbAtk.Checked)
            {
                _Atk = true;
            }

            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                try
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanXpdc_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rID));
                    db.Commands[0].Parameters.Add(new Parameter("@trID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@noKirim", SqlDbType.VarChar, NoSj.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@tglKirim", SqlDbType.DateTime, Tglkrm.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglKembali", SqlDbType.DateTime, SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@tujuan", SqlDbType.VarChar, cboTujuan.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@sopir", SqlDbType.VarChar, cboSopir.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@kernet", SqlDbType.VarChar, cboKernet.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@noPolisi", SqlDbType.VarChar, NoPolisi.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kasBon", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@bbmltr", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@bbmRp", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@umSopir", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@umKernet", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@parkir", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@tol", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@kuli", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lain", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@ketLain", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@tarikan", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@jamKirim", SqlDbType.VarChar, JamKirim.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@jamKembali", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@kmBerangkat", SqlDbType.Int, (string.IsNullOrEmpty(KmBerangkat.Text) == true ? 0 : int.Parse(KmBerangkat.Text))));
                    db.Commands[0].Parameters.Add(new Parameter("@kmKirim", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@izinMasuk", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@timbangan", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@inTepatWaktu", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@inPengiriman", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeExpedisi", SqlDbType.VarChar, Tools.isNull(lookupExpedisi1.KodeExpedisi, "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaExpedisi", SqlDbType.VarChar, Tools.isNull(lookupExpedisi1.NamaExpedisi, "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Atk", SqlDbType.Bit, _Atk));
                    db.Commands[0].ExecuteNonQuery();

                    retVal = true;

                    MessageBox.Show(Messages.Confirm.UpdateSuccess);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    db.RollbackTransaction();
                    MessageBox.Show("Gagal Menyimpan Data");
                }

                return retVal;
            }
        }
    }
}
