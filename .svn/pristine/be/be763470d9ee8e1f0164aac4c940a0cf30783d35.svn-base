using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading;
using System.Data.SqlTypes;
 
namespace ISA.Trading.Penjualan
{
    public partial class frmDOUpdate : ISA.Trading.BaseForm
    {
        string initCab = GlobalVar.CabangID;
        //string initPerusahaan = GlobalVar.PerusahaanID ;
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string HtrId;
        string docNoDO = "NOMOR_DO";
        string noAccPiutang = "", noAccPusat = "";
        object _TglACCPiutang, _TglReorder;
        int nprint = 0;
        string _noRQAwal = "";

        DataTable dtTrans = new DataTable();

        public frmDOUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }
        string _totalDO , _totalNota;
        //string no, depan, belakang;
        //int nomor,lebar;

        public frmDOUpdate(Form caller,Guid rowID, string totalDo, string totalNota)
        {
            InitializeComponent();
            formMode = enumFormMode.Update ;
            if (totalDo== string.Empty & totalNota == string.Empty)
            {
                totalDo = "0";
                totalNota = "0";
            }
            
            _totalDO = totalDo;
            _totalNota = totalNota;
            _rowID = rowID;
            this.Caller = caller;

        }
        

        private void frmDOUpdate_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtExp = new DataTable();
                
                using (Database db = new Database())
                {
                    //display Expedisi List
                    db.Commands.Add(db.CreateCommand("usp_ExpedisiCbo_LIST")); // cek heri
                    dtExp = db.Commands[0].ExecuteDataTable();
                    cboExpedisi.DataSource = dtExp;
                    cboExpedisi.DisplayMember = "Expedisi";
                    cboExpedisi.ValueMember = "KodeExpedisi";
                    cboExpedisi.SelectedValue = "SAS";

                    //Display Jenis Transaksi List
                    db.Commands.Add(db.CreateCommand("usp_TransactionType_LIST")); //cek heri
                    dtTrans = db.Commands[1].ExecuteDataTable();


                    if (formMode == enumFormMode.Update)
                    {
                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST")); //cek heri
                        db.Commands[2].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[2].ExecuteDataTable();
                        nprint = int.Parse(dt.Rows[0]["NPrint"].ToString());
                        noAccPiutang = dt.Rows[0]["NoACCPiutang"].ToString();
                        noAccPusat = dt.Rows[0]["NoACCPusat"].ToString();
                        _TglACCPiutang = dt.Rows[0]["TglACCPiutang"];
                        _TglReorder = dt.Rows[0]["TglACCPiutang"];

                        txtSales.Enabled = false;
                    }
                }
                txtCatatan1.CharacterCasing = CharacterCasing.Upper;
                txtCatatan2.CharacterCasing = CharacterCasing.Upper;
                txtCatatan3.CharacterCasing = CharacterCasing.Upper;
                txtCatatan4.CharacterCasing = CharacterCasing.Upper;
                txtTransactionType.CharacterCasing = CharacterCasing.Upper;

                if (Tools.Left(GlobalVar.Gudang.ToString(), 1) == "9")
                {
                    txtCabang2.Enabled = true;
                }
                else
                {
                    txtCabang2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


             if (formMode == enumFormMode.Update)
             {
                 //Display Data
                 //txtSales.NamaSales = Tools.isNull(dt.Rows[0]["NamaSales"], "").ToString();
                
                 txtSales.SetNamaSales(Tools.isNull(dt.Rows[0]["NamaSales"], "").ToString());
                 txtSales.SalesID = Tools.isNull(dt.Rows[0]["KodeSales"], "").ToString();
                 txtCabang1.Text = Tools.isNull(dt.Rows[0]["Cabang1"], "").ToString();
                 txtCabang2.NamaGudang = Tools.isNull(dt.Rows[0]["Cabang2"], "").ToString();
                 txtCabang2.GudangID = Tools.isNull(dt.Rows[0]["Cabang2"], "").ToString();
                 txtCabang3.Text = Tools.isNull(dt.Rows[0]["Cabang3"], "").ToString();
                 _noRQAwal = Tools.isNull(dt.Rows[0]["NoRequest"], "").ToString();
                 txtNoRequest.Text = Tools.isNull(dt.Rows[0]["NoRequest"], "").ToString();
                 txtTglRequest.DateValue = (DateTime?)dt.Rows[0]["TglRequest"];
                 txtNoDO.Text = Tools.isNull(dt.Rows[0]["NoDO"], "").ToString();
                 txtTglNoDo.DateValue = (DateTime?)dt.Rows[0]["TglDO"];
                 txtStatusBatal.Text = Tools.isNull(dt.Rows[0]["StatusBatal"], "").ToString();
                 txtHariKredit.Text = Tools.isNull(dt.Rows[0]["HariKredit"], "").ToString();
                 txtCicil.Text = Tools.isNull(dt.Rows[0]["Cicil"], "").ToString();
                 txtToko.TokoID = Tools.isNull(dt.Rows[0]["TokoID"], "").ToString();
                 txtToko.WilID = Tools.isNull(dt.Rows[0]["WilID"], "").ToString();
                 txtToko.KodeToko = Tools.isNull(dt.Rows[0]["KodeToko"], "").ToString();
                 //txtToko.NamaToko = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
                 txtToko.SetNamaToko(Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString());
                 txtStatus.Text = Tools.isNull(dt.Rows[0]["StsToko"], "").ToString();
                 txtAlamatKirim.Text = Tools.isNull(dt.Rows[0]["AlamatKirim"], "").ToString();
                 txtKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                 txtTotalDO.Text = _totalDO;
                 txtTotalNota.Text = _totalNota;
                 txtDisc1.Text = Tools.isNull(dt.Rows[0]["Disc1"], "").ToString();
                 txtDisc2.Text = Tools.isNull(dt.Rows[0]["Disc2"], "").ToString();
                 txtDisc3.Text = Tools.isNull(dt.Rows[0]["Disc3"], "").ToString();
                 txtCatatan1.Text = Tools.isNull(dt.Rows[0]["Catatan1"], "").ToString();
                 txtCatatan2.Text = Tools.isNull(dt.Rows[0]["Catatan2"], "").ToString();
                 txtCatatan3.Text = Tools.isNull(dt.Rows[0]["Catatan3"], "").ToString();
                 txtCatatan4.Text = Tools.isNull(dt.Rows[0]["Catatan4"], "").ToString();
                 txtTransactionType.Text = Tools.isNull(dt.Rows[0]["TransactionType"], "").ToString();
                 cboExpedisi.SelectedValue = Tools.isNull(dt.Rows[0]["Expedisi"], "").ToString();
                 txtHariSales.Text = Tools.isNull(dt.Rows[0]["HariSales"], "").ToString();
                 txthariKirim.Text = Tools.isNull(dt.Rows[0]["HariKirim"], "").ToString();
                 HtrId = Tools.isNull(dt.Rows[0]["HtrID"], "").ToString();
                 txtToko.SetToko(Tools.isNull(dt.Rows[0]["KodeToko"], "").ToString());
                 txtToko.SetNamaToko(Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString());

                 txtTglRequest.Enabled = false;
                 txtCabang2.Enabled = false;
                 txtCabang3.Enabled = false;
                 txtToko.Enabled = false;
                 txtCicil.Enabled = false;
                 txtCatatan3.Enabled = false;
                 txtCatatan4.Enabled = false;

                 txthariKirim.Enabled = false;
                 txtHariKredit.Enabled = false;
                 txtHariKredit.Enabled = false;
                 txtTransactionType.Enabled = false;
                 txtCicil.Enabled = false;

                 txtDisc1.Enabled = false;
                 txtDisc2.Enabled = false;
                 txtDisc3.Enabled = false;
                 txtTotalNota.Enabled = false;
                 txtTotalDO.Enabled = false;

                 if (noAccPusat.Trim().Length!=0)
                 {
                     txtToko.Enabled = false;
                 }

                 try
                 {
                     using (Database db = new Database())
                     {
                         DataTable dtStok = new DataTable();

                         db.Commands.Add(db.CreateCommand("usp_Gudang_SEARCH"));
                         db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtCabang2.GudangID+txtCabang3.Text));
                         dtStok = db.Commands[0].ExecuteDataTable();
                         if (dtStok.Rows.Count == 1)
                         {
                             txtCabang2.GudangID = Tools.isNull(dtStok.Rows[0]["GudangID"], "").ToString();
                             txtCabang2.NamaGudang = Tools.isNull(dtStok.Rows[0]["NamaGudang"], "").ToString();
                         }
                         else
                         {
                             //ShowDialogForm(txtCabang2.GudangID, dtStok);
                         }
                     }
                 }
                 catch (Exception ex)
                 {
                     Error.LogError(ex);
                 }

                 //get status Toko
                 //try
                 //{
                 //    this.Cursor = Cursors.WaitCursor;
                 //    using (Database db = new Database())
                 //    {
                 //        db.Commands.Add(db.CreateCommand("usp_GetStatusToko"));
                 //        db.Commands[0].Parameters.Add(new Parameter("@tglDO", SqlDbType.DateTime, txtTglNoDo.DateValue));
                 //        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, txtToko.TokoID));
                 //        db.Commands[0].Parameters.Add(new Parameter("@c1", SqlDbType.VarChar, txtCabang1.Text));
                 //        object stsToko = db.Commands[0].ExecuteScalar();
                 //        if (stsToko != null)
                 //        {
                 //            txtStatus.Text = stsToko.ToString();
                 //        }
                 //        else
                 //        {
                 //            MessageBox.Show("Toko " + txtToko.NamaToko.Trim() + "di " + txtCabang1.Text + "belum ada statusnya");
                 //        }
                 //    }
                 //}
                 //catch (Exception ex)
                 //{
                 //    Error.LogError(ex);
                 //}
                 //finally
                 //{
                 //    this.Cursor = Cursors.Default;
                 //}
             }
             else
             {
                 txtTglRequest.Text = DateTime.Today.ToString("dd/MM/yyyy");
                 txtTglNoDo.Text = DateTime.Today.ToString("dd/MM/yyyy");
                 txtDisc1.Text = "0.00";
                 txtDisc2.Text = "0.00";
                 txtDisc3.Text = "0.00";
                 txtTotalNota.Text = "0";
                 txtTotalNota.Enabled = false;
                 txtTotalDO.Text = "0";
                 txtTotalDO.Enabled = false;
                 txtHariKredit.Text = "0";
                 txthariKirim.Text = "0";
                 txtHariSales.Text = "0";
                 HtrId = Tools.CreateFingerPrint();
                 //txtHariSales.Text = Tools.GetHariSales(txtTransactionType.Text, txtToko.HariSales).ToString();

                 txtSales.Focus();
             }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSales_SelectData(object sender, EventArgs e)
        {

            /*if (txtSales.SalesID != "")
            {
                txtCabang1.Text = txtSales.SalesID.Substring(0, 2);
                if (txtSales.SalesID.Substring(0, 2) == initCab)
                {
                    txtCabang2.GudangID = txtSales.SalesID.Substring(0, 2);
                    txtCabang2.NamaGudang = txtSales.SalesID.Substring(0, 2);

                }
                else
                {
                    txtCabang2.GudangID = "    ";
                }

                if (txtCabang2.GudangID != "")
                {
                    if (txtCabang1.Text.Trim() != txtCabang2.GudangID.Trim())
                    {
                        txtCabang2.Enabled = true;
                    }
                    //else
                    //{
                    //    txtCabang2.Enabled = false;
                    //    txtCabang2.GudangID = txtCabang2.GudangID.Substring(0, 2);
                    //    txtCabang3.Text = txtCabang2.GudangID.Substring(2, 2);
                    //    txtCabang2.Visible = true;
                    //}
                }
            }*/
        }

        private void txtToko_SelectData(object sender, EventArgs e)
        {
            try
            {
                DataTable dtToko = new DataTable();
                DataTable dtStsToko = new DataTable();
                object stsToko; 

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetStatusToko")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@tglDO", SqlDbType.DateTime, txtTglNoDo.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, txtToko.KodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@c1", SqlDbType.VarChar, txtCabang1.Text));
                    stsToko = db.Commands[0].ExecuteScalar();                    
                    
                    db.Commands.Add(db.CreateCommand("usp_StsToko_LIST")); //cek heri
                    db.Commands[1].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, txtToko.KodeToko));
                    dtStsToko = db.Commands[1].ExecuteDataTable();
                }

                string stsTk = stsToko.ToString();
                //if (stsTk == "" || stsTk == null)
                //{
                //    MessageBox.Show("Toko " + txtToko.NamaToko.Trim() + " di " + txtCabang1.Text + " belum ada statusnya");
                //    txtStatus.Text = "";
                //    txtAlamatKirim.Text = "";
                //    txtKota.Text = "";
                //    return;
                //}

                int jml = dtStsToko.Rows.Count;
                for (int i = 0; i < jml; i++)
                {
                    string cabang1 = dtStsToko.Rows[i]["CabangID"].ToString();
                    if (cabang1 != initCab)
                    {
                        MessageBox.Show("Toko ini bentrok dengan " + cabang1);
                    }
                }

                txtStatus.Text = stsToko.ToString();
                txtAlamatKirim.Text = txtToko.Alamat;
                txtKota.Text = txtToko.Kota;
                //txtHariSales.Text = txtToko.HariSales.ToString();//Tools.GetHariSales(txtTransactionType.Text, txtToko.HariSales).ToString();
                txthariKirim.Text = GetHariKirim().ToString();
            }
            catch(Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private int GetHariKirim()
        {
            int hari = 0;
            try
            {
                if (cboExpedisi.SelectedValue.ToString() == "SAS" ||
                   txtTransactionType.Text.Trim() == "")
                {
                    hari = 0;
                }
                else
                {
                    hari = 0;
                    if (txtTransactionType.Text.Trim().Substring(0, 1) == "K")
                    {
                        hari = txtToko.HariKirim;
                    }
                }
            }
            catch (System.Exception ex)
            {
                hari = 0;
            }

           
            return hari;
        }


        //private void GetHariSales()
        //{
        //    if (txtTransactionType.Text.Trim() == "" || txtTransactionType.Text.Substring(0,1) == "T")
        //    {
        //        txtHariSales.Text = "0";
        //    }
        //    else
        //    {
        //        if (txtTransactionType.Text == "KH" || txtTransactionType.Text == "KB" || 
        //            txtTransactionType.Text == "KV" ||
        //            txtTransactionType.Text == "KT" || txtTransactionType.Text == "KA")
        //        {
        //            txtHariSales.Text = "30";
        //        }
        //        else if (txtTransactionType.Text == "KL")
        //        {
        //            txtHariSales.Text = "40";
        //        }
        //        else if (txtTransactionType.Text == "KJ")
        //        {
        //            txtHariSales.Text = "14";
        //        }
        //        else if (txtTransactionType.Text == "KG")
        //        {
        //            txtHariSales.Text = "21";
        //        }
        //        else if (txtTransactionType.Text == "KZ")
        //        {
        //            txtHariSales.Text = "60";
        //        }
        //        else
        //        {
        //            if (txtToko.HariSales == 0)
        //            {
        //                txtHariSales.Text = "60";
        //            }
        //            else
        //            {
        //                txtHariSales.Text = txtToko.HariSales.ToString();
        //            }
        //        }
        //    }
        //}

        private void txtHariKredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (Convert.ToDouble(txtHariKredit.Text) >= 0 && Convert.ToDouble(txtHariKredit.Text) <= 30)
                {
                    txthariKirim.Focus();
                    txthariKirim.SelectAll();
                }
                else
                {
                    txtHariKredit.Focus();
                    txtHariKredit.SelectAll();
                }
            }
        }
    
            //cIdhtr = StampUser()

            
        //tombol Save di FoxPro
        //LOCAL cIdhtr,cCab1,cCab2,cCab3,cNo_rq,dTgl_rq,cNo_do,dTgl_do,cNm_toko,cAl_kirim,cKota,;
        //cExpedisi,nDisc_1,nDisc_2,nDisc_3,cId_tr,nHr_krdt,nHari_krm,nHari_sls,cCatatan1,cCatatan2,;
        //cCatatan3,cCatatan4,lLaudit,cId_disc,cId_match
        //*
        //DO CASE
        //CASE EMPTY(Thisform.TextKd_sales.Value)
        //  MESSAGEBOX('Kode salesman tidak boleh kosong',48,'Perhatian')
        //  Thisform.TextKd_sales.SetFocus
        //  RETURN
        //CASE EMPTY(Thisform.TextCab2.Value)
        //  MESSAGEBOX('Cabang pengirim tidak boleh kosong',48,'Perhatian')
        //  Thisform.TextCab2.SetFocus
        //  RETURN
        //CASE EMPTY(Thisform.TextNo_rq.Value)
        //  MESSAGEBOX('No.Sales order tidak boleh kosong',48,'Perhatian')
        //  Thisform.TextNo_rq.SetFocus
        //  RETURN
        //CASE EMPTY(Thisform.TextTgl_rq.Value)
        //  MESSAGEBOX('Tgl S/O tidak boleh kosong',48,'Perhatian')
        //  Thisform.TextTgl_rq.SetFocus
        //  RETURN
        //CASE EMPTY(Thisform.TextNm_toko.Value)
        //  MESSAGEBOX('Nama toko tidak boleh kosong',48,'Perhatian')
        //  Thisform.TextNm_toko.SetFocus
        //  RETURN
        //CASE EMPTY(Thisform.ComboExpedisi.Value)
        //  MESSAGEBOX('Expedisi tidak boleh kosong',48,'Perhatian')
        //  Thisform.ComboExpedisi.SetFocus
        //  RETURN
        //CASE EMPTY(Thisform.ComboId_tr.Value)
        //  MESSAGEBOX('Jenis Transaksi tidak boleh kosong',48,'Perhatian')
        //  Thisform.ComboId_tr.SetFocus
        //  RETURN
        //CASE !lKd_sales
        //  ?CHR(7)
        //  Thisform.TextKd_sales.SetFocus
        //  RETURN
        //CASE !lCab2
        //  ?CHR(7)
        //  Thisform.TextCab2.SetFocus
        //  RETURN
        //CASE !lNm_toko
        //  ?CHR(7)
        //  Thisform.TextNm_toko.SetFocus
        //  RETURN
        //CASE !lId_tr
        //  ?CHR(7)
        //  Thisform.ComboId_tr.SetFocus
        //  RETURN
        //ENDCASE
        //*
        //*cKd_sales
        //*cKd_toko
        //*
        //cIdhtr = StampUser()
        //cCab1 = Thisform.TextCab1.Value
        //cCab2 = ALLTRIM(Thisform.TextCab2.Value)
        //cCab3 = IIF(cModus ='A',SPACE(2),Hhtransj.Cab3)

        //IF cCab2 <> cInitCab
        //   cCab3 = RIGHT(cCab2,2)
        //   cCab2 = LEFT(cCab2,2)    
        //ENDIF

        //cNo_rq = Thisform.TextNo_rq.Value
        //dTgl_rq = Thisform.TextTgl_rq.Value
        //cNo_do = Thisform.TextNo_do.Value
        //dTgl_do = Thisform.TextTgl_do.Value
        //cNm_toko = Thisform.TextNm_toko.Value
        //cAl_kirim = Thisform.TextAl_kirim.Value
        //cKota = Thisform.TextKota.Value
        //cExpedisi = Thisform.ComboExpedisi.Value
        //nDisc_1 = Thisform.TextDisc_1.Value
        //nDisc_2 = Thisform.TextDisc_2.Value
        //nDisc_3 = Thisform.TextDisc_3.Value
        //cId_tr = Thisform.ComboId_tr.Value
        //nHr_krdt = Thisform.TextHr_krdt.Value
        //nHari_krm = Thisform.TextHari_krm.Value
        //*nHari_sls = IIF(cId_tr='KA' OR cId_tr='KB' OR cId_tr='KV',30,CursToko.Hari_sls)
        //nHari_sls = Thisform.TextHari_sls.Value && 091130
        //cCatatan1 = Thisform.TextCatatan1.Value
        //cCatatan2 = Thisform.TextCatatan2.Value
        //cCatatan3 = Thisform.TextCatatan3.Value
        //cCatatan4 = Thisform.TextCatatan4.Value
        //lLaudit = IIF(cModus = 'A',.F.,Hhtransj.lAudit)
        //cId_disc = IIF(cModus = 'A',SPACE(7),Hhtransj.Id_disc)
        //cId_match = '0'
        //*
        //IF '!'$cNo_rq AND EMPTY(Hhtransj.No_Nota) AND Hhtransj.Cab1=cInitCab
        //   MESSAGEBOX('No_RQ utk. DO URGENT (!)'+CHR(13)+'Diisi setelah di ACC PIUTANG !!!',48,'Perhatian')
        //   cModus = ''
        //   lAddEdit = .F.
        //   Thisform.Release
        //   RETURN 
        //ENDIF
        //*
        //IF cModus = 'A'
        //   *cIdhtr='C092010111114:14:45VER '
        //   DO WHILE .T.
        //      IF !INDEXSEEK(cIdhtr,.F.,'Hhtransj','Idhtr')
        //         EXIT
        //      ELSE
        //         *WAIT WINDOW 'Found..'
        //      ENDIF
        //      cIdhtr = StampUser()
        //   ENDDO
        //   INSERT INTO Hhtransj (Idhtr,Kd_sales,Cab1,Cab2,Cab3,No_rq,Tgl_rq,No_do,Tgl_do,Kd_toko,;
        //   Nm_toko,Al_kirim,Kota,Expedisi,Disc_1,Disc_2,Disc_3,Id_tr,Hr_krdt,Hari_krm,Hari_sls,;
        //   Catatan1,Catatan2,Catatan3,Catatan4,Laudit,Id_disc,Id_match) VALUES ;
        //   (cIdhtr,cKd_sales,cCab1,cCab2,cCab3,cNo_rq,dTgl_rq,cNo_do,dTgl_do,cKd_toko,cNm_toko,;
        //   cAl_kirim,cKota,cExpedisi,nDisc_1,nDisc_2,nDisc_3,cId_tr,nHr_krdt,nHari_krm,nHari_sls,;
        //   cCatatan1,cCatatan2,cCatatan3,cCatatan4,lLaudit,cId_disc,cId_match)
        //ELSE
        //   REPLACE Hhtransj.Kd_sales WITH cKd_sales,Hhtransj.Cab1 WITH cCab1,;
        //   Hhtransj.Cab2 WITH cCab2,Hhtransj.Cab3 WITH cCab3,Hhtransj.No_rq WITH cNo_rq,;
        //   Hhtransj.Tgl_rq WITH dTgl_rq,Hhtransj.No_do WITH cNo_do,;
        //   Hhtransj.Tgl_do WITH dTgl_do,Hhtransj.Kd_toko WITH cKd_toko,;
        //   Hhtransj.Nm_toko WITH cNm_toko,Hhtransj.Al_kirim WITH cAl_kirim,Hhtransj.Kota WITH cKota,;
        //   Hhtransj.Expedisi WITH cExpedisi,Hhtransj.Disc_1 WITH nDisc_1,;
        //   Hhtransj.Disc_2 WITH nDisc_2,Hhtransj.Disc_3 WITH nDisc_3,Hhtransj.Id_tr WITH cId_tr,;
        //   Hhtransj.Hr_krdt WITH nHr_krdt,Hhtransj.Hari_krm WITH nHari_krm,;
        //   Hhtransj.Hari_sls WITH nHari_sls,Hhtransj.Catatan1 WITH cCatatan1,;
        //   Hhtransj.Catatan2 WITH cCatatan2,Hhtransj.Catatan3 WITH cCatatan3,;
        //   Hhtransj.Catatan4 WITH cCatatan4,Hhtransj.Laudit WITH lLaudit,;
        //   Hhtransj.Id_disc  WITH cId_disc,Hhtransj.Id_match WITH cId_match IN Hhtransj
        //   *
        //   *UpdateLog(Hhtransj.Idhtr,'HHTRANSJ','UPD')
        //   *
        //   Thisform.UpdHtransj()
        //   IF cLastKd_toko <> cKd_toko
        //      Thisform.UpdKdToko()
        //   ENDIF
        //ENDIF
        //*
        //cModus = ''
        //lTambah = .F.
        //lAddEdit = .F.
        //Thisform.Release
        //RETURN


        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Tools.Left(GlobalVar.Gudang.ToString(), 1) == "9")
            {
                if (Tools.Left(txtCabang2.GudangID.ToString(), 2)==GlobalVar.CabangID)
                {
                    MessageBox.Show("Penjualan Rsopac, Cabang pengirim harus beda dengan Cabang penjual");
                    return;
                }
            }

            //if(txtTransactionType.Text.Contains("K") && int.Parse(txtHariKredit.Text) < 1)
            //{
            //    MessageBox.Show("Untuk jenis transaksi kredit, jangka waktu kredit harus lebih besar dari 0 (nol)");
            //    txtHariKredit.SelectAll();
            //    txtHariKredit.Focus();
            //    return;
            //}

            if (txtTransactionType.Text.Contains("T") && int.Parse(txtHariKredit.Text) > 0)
            {
                MessageBox.Show("Untuk jenis transaksi tunai, jangka waktu kredit harus 0 (nol)");
                txtHariKredit.SelectAll();
                txtHariKredit.Focus();
                return;
            }

            if (txtToko.KodeToko.ToString()!="" && txtToko.WilID=="")
            {
                MessageBox.Show("Toko "+txtToko.NamaToko+ " \n Belum mempunyai WilID");
                txtToko.Focus();
                return;
            }

            if (txtCicil.GetIntValue == 1)
            {
                MessageBox.Show("Isi 0 atau > 1");
                txtCicil.Focus();
                return;
            }

            
            string cab1 = txtCabang1.Text;
            string cab2 = txtCabang2.GudangID.Substring(0, 2);
            string cab3;
            //string cab2 = txtCabang2.GudangID.Trim();

            //GENERATE Nomor DO
            DataTable dtNum = Tools.GetGeneralNumerator(docNoDO, Tools.GeneralInitial());
            int lebar = int.Parse( dtNum.Rows[0]["Lebar"].ToString());
            int iNomor = int.Parse( dtNum.Rows[0]["Nomor"].ToString());
            string depan = Tools.GeneralInitial();
            string belakang =dtNum.Rows[0]["Belakang"].ToString();
            iNomor++;
            string strNoDO = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
            //Proses DO
            if (formMode == enumFormMode.New)
            {
                HtrId = Tools.CreateFingerPrint();

                if (cab2 != initCab)
                {
                    cab3 = txtCabang2.GudangID.Substring(2, 2);
                    cab2 = txtCabang2.GudangID.Substring(0, 2);
                }
                else
                {
                    cab3 = "";
                }
            }
            else
            {
                cab3 = txtCabang3.Text;
                cab2 = txtCabang2.GudangID.Substring(0,2);
                //cab2 = txtCabang2.GudangID.Trim();
            }

            if(IsValid())
            {
                try
                {
                    GlobalVar.LastClosingDate = (DateTime)txtTglNoDo.DateValue;
                    if ((DateTime)txtTglNoDo.DateValue <= GlobalVar.LastClosingDate)
                    {
                        throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    }
                    switch (formMode)
                    {
                        case enumFormMode.New:
                            using (Database db = new Database())
                            {
                                _rowID = Guid.NewGuid();
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_INSERT")); //cek heri
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, HtrId));
                                db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, cab1));
                                db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, cab2));
                                db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, cab3));
                                db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, txtNoRequest.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, txtTglRequest.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, strNoDO));
                                db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, txtTglNoDo.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, string.Empty));
                                db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, string.Empty));
                                db.Commands[0].Parameters.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, string.Empty));
                                db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, int.Parse(txtHariKredit.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, txtToko.KodeToko));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, txtSales.SalesID));
                                db.Commands[0].Parameters.Add(new Parameter("@StsToko", SqlDbType.VarChar, txtStatus.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, txtAlamatKirim.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, txtKota.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, "    "));
                                db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Decimal, Convert.ToDecimal(txtDisc1.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Decimal, Convert.ToDecimal(txtDisc2.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Decimal, Convert.ToDecimal(txtDisc3.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, false));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, txtCatatan1.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, txtCatatan2.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, txtCatatan3.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, txtCatatan4.Text));

                                db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, string.Empty));
                                db.Commands[0].Parameters.Add(new Parameter("@StatusBO", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, txtTransactionType.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, cboExpedisi.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, int.Parse(txthariKirim.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, int.Parse(txtHariSales.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, string.Empty));
                                db.Commands[0].Parameters.Add(new Parameter("@Cicil", SqlDbType.Int, int.Parse(txtCicil.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, string.Empty));

                                // tambahan fefe
                                db.Commands[0].Parameters.Add(new Parameter("@RpACCPiutang", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@RpPlafonToko", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@RpPiutangTerakhir", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@RpGiroTolakTerakhir", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@RpOverdue", SqlDbType.Money, 0));
                                //db.Commands[0].Parameters.Add(new Parameter("@Plafon", SqlDbType.Money, 0));
                                //db.Commands[0].Parameters.Add(new Parameter("@SaldoPiutang", SqlDbType.Money, 0));
                                //db.Commands[0].Parameters.Add(new Parameter("@Overdue", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@Shift", SqlDbType.VarChar, "1"));

                                db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));//cek heri
                                db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoDO));
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

                            this.Close();

                            Guid _headerID;

                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_GetRowIDDO")); //cek heri
                                db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, HtrId));
                                dt = db.Commands[0].ExecuteDataTable();
                                _headerID = (Guid)dt.Rows[0]["RowID"];
                            }
                            string _namatoko = txtToko.NamaToko.ToString();
                            string _jenistrans = txtTransactionType.Text.ToString();
                            Penjualan.frmDODetailUpdate ifrmChild2 = new Penjualan.frmDODetailUpdate(this, _headerID, _namatoko,_jenistrans);
                            //ifrmChild2.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild2);
                            ifrmChild2.ShowDialog();

                            break;

                        case enumFormMode.Update:

                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_UPDATE")); //cek heri
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, HtrId));
                                db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, cab1));
                                db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, cab2));
                                db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, cab3));
                                db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, txtNoRequest.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, txtTglRequest.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, txtNoDO.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, txtTglNoDo.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, noAccPusat));
                                db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, noAccPiutang));
                                db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, _TglACCPiutang));
                                db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, int.Parse(txtHariKredit.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, txtToko.KodeToko));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, txtSales.SalesID));
                                db.Commands[0].Parameters.Add(new Parameter("@StsToko", SqlDbType.VarChar, txtStatus.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, txtAlamatKirim.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, txtKota.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, "    "));
                                db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Decimal, Convert.ToDecimal(txtDisc1.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Decimal, Convert.ToDecimal(txtDisc2.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Decimal, Convert.ToDecimal(txtDisc3.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, false));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, txtCatatan1.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, txtCatatan2.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, txtCatatan3.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, txtCatatan4.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, string.Empty));
                                db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, string.Empty));
                                db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, string.Empty));
                                db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, txtTransactionType.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, cboExpedisi.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, int.Parse(txthariKirim.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, int.Parse(txtHariSales.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@StatusBO", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@Cicil", SqlDbType.Int, int.Parse(txtCicil.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, nprint));
                                db.Commands[0].Parameters.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, txtStatusBatal.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@TglReorder", SqlDbType.DateTime, _TglReorder));

                                //if (!_noRQAwal.Contains("!") && txtNoRequest.Text.Contains("!"))
                                if (txtNoRequest.Text.Contains("!"))
                                {
                                    db.Commands.Add(db.CreateCommand("asp_DOGantiSyncFlag")); //cek heri
                                    db.Commands[1].Parameters.Add(new Parameter("@DOID", SqlDbType.UniqueIdentifier, _rowID));
                                    db.Commands[1].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                                }

                                db.BeginTransaction();
                                for (int i = 0; i < db.Commands.Count; i++)
                                {
                                    db.Commands[i].ExecuteNonQuery();
                                }
                                db.CommitTransaction();
                            }

                            #region umur piutang
                            //// Cari umur piutang > 90 hari berdasarkan kode sales
                            //DataTable dtPiutangSales = new DataTable();
                            //using (Database db = new Database())
                            //{
                            //    db.Commands.Add(db.CreateCommand("usp_KartuPiutang_LIST_KodeSales"));
                            //    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, txtSales.SalesID));
                            //    dtPiutangSales = db.Commands[0].ExecuteDataTable();
                            //}

                            //if (dtPiutangSales.Rows.Count > 0)
                            //{
                            //    DataTable dt = new DataTable();
                            //    using (Database db = new Database())
                            //    {
                            //        db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                            //        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            //        db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, PinId.Bagian.SalesBL));
                            //        db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, string.Empty));
                            //        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            //        dt = db.Commands[0].ExecuteDataTable();
                            //        db.Commands[0].ExecuteNonQuery();
                            //    }
                            //}
                            //else if (dtPiutangSales.Rows.Count == 0 && noAccPiutang == "SALESBL")
                            //{
                            //    DataTable dt = new DataTable();
                            //    using (Database db = new Database())
                            //    {
                            //        db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                            //        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            //        db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, 0));
                            //        db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, string.Empty));
                            //        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            //        db.Commands[0].Parameters.Add(new Parameter("@noACCPiutang", SqlDbType.VarChar, "FULLACC"));
                            //        dt = db.Commands[0].ExecuteDataTable();
                            //        db.Commands[0].ExecuteNonQuery();
                            //    }
                            //}
                            #endregion

                            MessageBox.Show("Data telah tersimpan");
                            //this.DialogResult = DialogResult.OK;

                            TabelDO frmCaller = (TabelDO)this.Caller;
                            frmCaller.RefreshDataDO();
                            //frmCaller.RefreshRowDataDO(_rowID.ToString());
                            frmCaller.FindHeader("HtrID", HtrId.ToString());

                            this.Close();
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
                
            }
        }

        public bool IsValid()
        {
            bool valid = true;
            if (txtTransactionType.Text == "")
            {
                errorProvider1.SetError(txtTransactionType, Messages.Error.InputRequired);
                txtTransactionType.Focus();
                valid = false;
            }
            else
            {
                valid = false;
                foreach (DataRow dr in dtTrans.Rows)
                {
                    if (txtTransactionType.Text == dr["Kode"].ToString())
                    {
                        valid = true;
                        break;
                    }
                }
                if (!valid)
                {
                    errorProvider1.SetError(txtTransactionType, Messages.Error.NotFound);
                    txtTransactionType.Focus();
                }
            }

            if (txtSales.SalesID == "" || txtSales.NamaSales == "")
            {
                errorProvider1.SetError(txtSales, Messages.Error.InputRequired);
                txtSales.Focus();
                valid = false;
            }
            
            if (txtCabang2.GudangID == "" || txtCabang2.NamaGudang == "")
            {
                errorProvider1.SetError(txtCabang2, Messages.Error.InputRequired);
                txtCabang2.Focus();
                valid = false;
            }

            if (txtNoRequest.Text == "")
            {
                errorProvider1.SetError(txtNoRequest, Messages.Error.InputRequired);
                txtNoRequest.Focus();
                valid = false;
            }

            if (txtTglRequest.Text == "")
            {
                errorProvider1.SetError(txtTglRequest, Messages.Error.InputRequired);
                valid = false;
                txtTglRequest.Focus();
            }
            
            if (txtToko.TokoID == "" || txtToko.KodeToko == "" || txtToko.NamaToko == "")
            {
                errorProvider1.SetError(txtToko, Messages.Error.InputRequired); 
                txtToko.Focus();
                valid = false;
            }
            
            if (cboExpedisi.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboExpedisi, Messages.Error.InputRequired); 
                cboExpedisi.Focus();
                valid = false;
            }

            if (formMode == enumFormMode.New & txtNoRequest.Text.Contains("!"))
            {
                errorProvider1.SetError(txtNoRequest, Messages.Error.NoRequestUrgent);
                valid = false;
            }

            if (formMode == enumFormMode.Update & txtNoRequest.Text.Contains("!") & noAccPiutang.Equals(string.Empty))
            {
                errorProvider1.SetError(txtNoRequest, Messages.Error.NoRequestUrgent);
                valid = false;
            }
            return valid;
        }

        private void txtTransactionType_Validated(object sender, EventArgs e)
        {
            string TR4 = "KO-KC-KJ-KG-K2-K4-KH-KT-KA-KB-KL-KZ-KV-T1-T2-T3-T4";
            if (!txtTransactionType.Equals(string.Empty) && txtTransactionType.Text.Trim().Length==2)
            {
                if (TR4.Contains(txtTransactionType.Text.Trim().ToUpper()))
                {
                    HariSales(txtTransactionType.Text.Trim().ToUpper());
                }else
                {
                    txtTransactionType.Focus();
                    txtTransactionType.SelectAll();
                }
               
               // txtHariSales.Text = Tools.GetHariSales(txtTransactionType.Text, txtToko.HariSales).ToString();

            }
            
            else //(txtTransactionType.Text.Trim()=="")
            {
                //txtTransactionType.Focus(); matiin by heri
                //txtTransactionType.SelectAll();
            }
        }

        private void txtNoRequest_Leave(object sender, EventArgs e)
        {
            if (noAccPiutang.Equals(string.Empty) && txtNoRequest.Text.Contains("!"))
            {
                MessageBox.Show("No. RQ DO Urgent (!) diisi setelah ACC Piutang !!!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNoRequest_Validated(object sender, EventArgs e)
        {
            if (txtNoRequest.Text.Trim() != "" && (noAccPusat.Trim().Length == 0))
            {
                if (txtNoRequest.Text.ToString().Contains("!"))
                {
                    txtToko.Enabled = false;
                }else
                {
                    txtToko.Enabled = true;
                }

            }

            if (formMode==enumFormMode.Update)
            {
                if (txtNoRequest.Text.Trim() != "" && txtNoRequest.Text.ToString().Contains("!"))
                {
                    if (!ChekHarga(_rowID))
                    {
                        MessageBox.Show("Nilai DO Kosong");
                        txtNoRequest.Focus();
                    }
                }
            }
        }

        private void frmDOUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.formMode == enumFormMode.Update)
            {
                if (this.DialogResult == DialogResult.OK)
                {
                    if (this.Caller is TabelDO)
                    {
                        TabelDO frmCaller = (TabelDO)this.Caller;
                        //frmCaller.RefreshDataDO();
                        frmCaller.RefreshRowDataDO(_rowID.ToString());
                        //frmCaller.FindHeader("RowID", _rowID.ToString());
                    }
                }
            }
        }

        private void txtToko_Validating(object sender, CancelEventArgs e)
        {
            //if (txtStatus.Text.Trim() == "" && txtToko.NamaToko.Trim() != "")
            //{
            //    txtToko.SearchToko();
            //    txtToko.Focus();
            //}
        }

        private void cboExpedisi_SelectedValueChanged(object sender, EventArgs e)
        {
            txthariKirim.Text = GetHariKirim().ToString();
        }

        private void txtHariKredit_Validating(object sender, CancelEventArgs e)
        {
            //if (txtHariKredit.Text.Trim() == "")
            //{
            //    txtHariKredit.Text = "0";
            //}

            //int _hrKrdt = int.Parse(txtHariKredit.Text);

            //if (txtTransactionType.Text == "KL" && (_hrKrdt < 1 || _hrKrdt > 30))
            //{
            //    MessageBox.Show("Kode Transaksi KL jangka waktu pembayarannya harus antara 1 sampai 30", "Perhatian");
            //    txtHariKredit.Focus();
            //}
        }

        private void txtNoRequest_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && (formMode == enumFormMode.Update))
            {
               
                string temp;
                int ronde;
                temp = txtNoRequest.Text;
                if (temp.Length > 3)
                {
                    MessageBox.Show("No Request tidak boleh lebih dari 3 huruf");
                    txtNoRequest.Focus();
                    return;
                }
                using(Database db=new Database())
                {
                    db.Commands.Add(db.CreateCommand("Ronde_List"));
                    ronde=(int)db.Commands[0].ExecuteScalar(); 
                }
                temp += "!" + DateTime.Now.Day + Convert.ToString((char)ronde);
                txtNoRequest.Text = temp;
                txtNoRequest.Focus();
                return; 
            }
        }

        private bool ChekHarga(Guid RowID_)
        {
            bool valid = false;
            int NominalNota = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_OrderPenjualan_ChekHarga]")); // cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, RowID_));
                    NominalNota = (int)db.Commands[0].ExecuteScalar();
                }
                valid = (NominalNota > 0) ? true : false;
            }
            catch (System.Exception ex) 
            {
                Error.LogError(ex);
            }
           

            return valid;
        }

        private void HariSales(string Tr)
        {
            string TR1 = "KO-KC-KJ-KG-K2-K4";
            string TR2 = "KH-KT-KA-KB-KL";
            string TR3 = "KZ-KV";

            if (TR1.Contains(Tr))
            {
                txtHariKredit.ReadOnly = false;
                txtHariSales.Text = txtToko.HariSales.ToString();
                txtHariSales.ReadOnly = true;
                
            }

            if (TR2.Contains(Tr))
            {
                txtHariKredit.ReadOnly = true;
                txtHariSales.Text = txtToko.HariSales.ToString();
                txtHariSales.ReadOnly = false;
                txtHariSales.Focus();
                txtHariSales.SelectAll();
                

            }

            if (TR3.Contains(Tr))
            {
                txtHariKredit.ReadOnly = true;
                txtHariKredit.Text = "30";
                txtHariSales.ReadOnly = true;
                txtHariSales.Text = "60";
              
          
            }

            if (Tr.Substring(0, 1) == "T")
            {
                txtHariKredit.ReadOnly = true;
                txtHariKredit.Text = "0";
                txtHariSales.ReadOnly = true;
                txtHariSales.Text = "0";

                txtCicil.ReadOnly = true;
                txtCicil.Text = "0";
               

            }
            else
            {
                txtCicil.ReadOnly = false;
                txtCicil.Text = "0";
                
            }
        }

        private void txtHariSales_Validated(object sender, EventArgs e)
        {
            string TR2 = "KH-KT-KA-KB-KL";
            if (txtHariSales.ReadOnly==false)
            {
                if (txtHariSales.Text.Trim().Length >= 1)
                {
                    if (TR2.Contains(txtTransactionType.Text))
                    {
                        txtHariKredit.Text = txtHariSales.Text;
                    }
                }
                else
                {
                    txtHariSales.Focus();
                    txtHariSales.SelectAll();
                }
            }
           
           

        }

        private void txtHariKredit_Validating_1(object sender, CancelEventArgs e)
        {

        }

        private void txtNoNota_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtToko_Load(object sender, EventArgs e)
        {

        }

        private void cboExpedisi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTransactionType_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoRequest_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
