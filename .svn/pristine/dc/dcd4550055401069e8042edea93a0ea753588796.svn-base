using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Trading.Penjualan
{
    public partial class frmPenjualanPotonganUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string docNoDO = "NOMOR_POTONGAN";
        Guid _rowID, _row;
        string trID, potID;
        string tokoID, nama, alamat, kota;
        DataTable dt = new DataTable();
        double netto;
        bool ajukan=false, acc=false;
        public frmPenjualanPotonganUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
          
        }

        public frmPenjualanPotonganUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            this.Caller = caller;
            _rowID = rowID;
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                   
                    DataTable dts = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_PenjualanPotongan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();

                    txtNamaToko.TokoID = Tools.isNull(dt.Rows[0]["KodeToko"], "").ToString();
                   
                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                    db.Commands[1].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dt.Rows[0]["KodeToko"]));
                    dts = db.Commands[1].ExecuteDataTable();

                    _row = (Guid) dt.Rows[0]["NotaPenjualanID"];
                    trID = Tools.isNull(dt.Rows[0]["TrID"], "").ToString();
                    potID = Tools.isNull(dt.Rows[0]["PotID"], "").ToString();
                    
                    txtNamaToko.NamaToko = Tools.isNull(dts.Rows[0]["NamaToko"],"").ToString();
                    txtAlamatKirim.Text = Tools.isNull(dts.Rows[0]["Alamat"], "").ToString();
                    txtKota.Text = Tools.isNull(dts.Rows[0]["Kota"], "").ToString();
                    txtIDWil.Text = Tools.isNull(dts.Rows[0]["WilID"], "").ToString();

                    txtNoPot.Text = Tools.isNull(dt.Rows[0]["NoPot"], "").ToString();
                    txtNoNota.Text = Tools.isNull(dt.Rows[0]["NoNota"], "").ToString();
                    txtTglNota.DateValue = (DateTime?)dt.Rows[0]["TglNota"];
                    txtNilaiNota.Text= Tools.isNull(dt.Rows[0]["RpNet"], "").ToString();
                    txtDisc1.Text = Tools.isNull(dt.Rows[0]["Disc1"], "").ToString();
                    txtDisc2.Text = Tools.isNull(dt.Rows[0]["Disc2"], "").ToString(); 
                    txtDisc3.Text = Tools.isNull(dt.Rows[0]["Disc3"], "").ToString();
                    txtDiscValue.Text = (Convert.ToDouble(dt.Rows[0]["RpNet"]) - Convert.ToDouble(dt.Rows[0]["RpNet"])).ToString();
                    txtRetur.Text = (Convert.ToDouble(dt.Rows[0]["RpNet"]) - Convert.ToDouble(dt.Rows[0]["RpNet"])).ToString();//Thisform.TextRetur.Value = Htransj.Rp_Net3-Hpotj.Rp_Net
                    //Thisform.TextRetur.Value = Htransj.Rp_Net3-Hpotj.Rp_Net
                    txtNetto.Text = Tools.isNull(dt.Rows[0]["RpNet"], "").ToString();
                    //Thisform.TextRp_Net.Value = Hpotj.Rp_Net
                    netto = Convert.ToDouble(dt.Rows[0]["RpNet"]);
                    if (Convert.ToDouble(dt.Rows[0]["Dil"]) > 0)
                    {
                        if (Convert.ToDouble(dt.Rows[0]["RpNet"]) != 0)
                        {
                            txtPotLumPersen.Text = (Convert.ToDouble(dt.Rows[0]["Dil"]) / Convert.ToDouble(dt.Rows[0]["RpNet"]) * 100).ToString();
                        }
                        else
                        {
                            txtPotLumPersen.Text = "0";
                        }
                    }
                    else{
                        txtPotLumPersen.Text = Tools.isNull(dt.Rows[0]["Disc"], "").ToString();
                    }
                    txtPotLumRp.Text=  Tools.isNull(dt.Rows[0]["Dil"], "").ToString();
                    txtCatPot.Text= Tools.isNull(dt.Rows[0]["Catatan"], "").ToString();
                    txtTglPot.DateValue = (DateTime?)dt.Rows[0]["TglPot"];
                    txtACCPersen.Text =Tools.isNull(dt.Rows[0]["DiscACC"], "").ToString();
                    txtACCRp.Text =Tools.isNull(dt.Rows[0]["DilACC"], "").ToString();
                    txtCatACC.Text =Tools.isNull(dt.Rows[0]["CatACC"], "").ToString();
                    
                    DateTime _tglAcc;

                    if (DateTime.TryParse(dt.Rows[0]["TglACC"].ToString(), out _tglAcc))
                    {
                        txtTglACC.DateValue = _tglAcc; // (DateTime?)dt.Rows[0]["TglACC"];
                    }
                    else
                    {
                        txtTglACC.Text = "";
                    }

                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void frmPenjualanPotonganUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.Update)
            {
                //DO CASE
                //CASE AccessRight('004') AND !EMPTY(Hpotj.Tgl_acc)
                //  Thisform.CommandgroupSB.CommandSimpan.Enabled = .F. 
                //  Thisform.CommandgroupSB.CommandBatal.Enabled = .F.
                //  Thisform.TextBoxIsi
                //CASE AccessRight('004')
                //  lAjukan = .T.
                //CASE AccessRight('005') AND RIGHT(cInitGdg,2)='01'
                //  lAcc = .T.
                //ENDCASE
                
                //if(SecurityManager.AppRole == "004" )
                //{
                //    cmdSave.Enabled=false;
                    
                //}
                //if (SecurityManager.AppRole == "004")
                //{
                //    ajukan = true;
                //}
                //if (SecurityManager.AppRole == "005" && Right(GlobalVar.Gudang,2)=="01")
                //{
                //    acc = true;
                //}

                cmdSave.Enabled = true;
                acc = true;
                if (ajukan == true)
                {
                    txtNamaToko.Enabled = true;
                    txtNoNota.Enabled = true;
                    txtPotLumRp.Enabled = true;
                    txtCatPot.Enabled = true;
                    txtTglPot.Enabled = true;
                    RefreshData();
                    txtNamaToko.Focus();
                }
                else if(acc==true)
                {
                    txtACCPersen.Enabled = true;
                    txtCatACC.Enabled = true;
                    RefreshData();
                    txtTglACC.DateValue = DateTime.Now;
                    txtACCPersen.Focus();
                }
                //IF lAjukan    
                //   Thisform.TextNm_toko.Enabled = .T.
                //   Thisform.TextNo_nota.Enabled = .T.       
                //   Thisform.TextDisc.Enabled = .T.
                //   Thisform.TextCatatan.Enabled = .T. 
                //   Thisform.TextTglPot.Enabled = .T.    
                //   Thisform.CommandTglPot.Enabled = .T.
                //   Thisform.TextBoxIsi
                //   Thisform.TextNm_toko.SetFocus
                //ELSE
                //   IF lAcc
                //      Thisform.TextDisc_acc.Enabled = .T. 
                //      Thisform.TextCat_Acc.Enabled = .T.
                //      Thisform.TextBoxIsi
                //      Thisform.TextTgl_Acc.Value = DATE()
                //      Thisform.TextDisc_acc.SetFocus
                //   ENDIF    
                //ENDIF    
            }
            else
            {
                //IF AccessRight('004')
                //   StartNumerator()
                //   AmbilNumerator()
                //   cNopot = cNomor
                //   lAddEdit=.T.
                //   lTambah=.T.
                //   Thisform.TextNopot.Value = cNopot
                //   Thisform.TextNm_toko.Enabled = .T.
                //   Thisform.TextNo_nota.Enabled = .T.
                //   Thisform.TextNm_toko.SetFocus
                //   Thisform.TextDisc.Enabled = .T.
                //   Thisform.TextCatatan.Enabled = .T. 
                //   Thisform.TextTglPot.Enabled = .T.
                //   Thisform.TextRp_Net.Value = 0
                //   Thisform.TextDisc.Value = 0       
                //   Thisform.TextTglPot.Value = DATE()
                //   Thisform.CommandTglPot.Enabled = .T.
                //ENDIF
                // if (SecurityManager.AppRole == "004")
                //{
                     //GENERATE Nomor DO
                       DataTable dtNum = Tools.GetGeneralNumerator(docNoDO);
                       int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                       txtNoPot.Text = iNomor.ToString();
                     txtNamaToko.Enabled= true;
                     txtNoNota.Enabled=true;
                     txtNamaToko.Focus();
                     txtPotLumPersen.Enabled=true;
                     txtCatPot.Enabled=true;
                     txtTglPot.Enabled=true;
                     txtNetto.Text = "0";
                     txtDiscValue.Text="0";
                     txtTglPot.DateValue = DateTime.Now;

                //}


            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //if (SecurityManager.AppRole == "004")
            //    {
            if (IsValid())
            {
                try
                {
                    switch (formMode)
                    {
                        case enumFormMode.New:

                            using (Database db = new Database())
                            {
                                _rowID = Guid.NewGuid();
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_PenjualanPotongan_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@notaPenjualanID", SqlDbType.UniqueIdentifier, _row));
                                db.Commands[0].Parameters.Add(new Parameter("@trID", SqlDbType.VarChar, trID));
                                db.Commands[0].Parameters.Add(new Parameter("@potID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                                db.Commands[0].Parameters.Add(new Parameter("@noPot", SqlDbType.VarChar, txtNoPot.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@tglPot", SqlDbType.DateTime, txtTglPot.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@dil", SqlDbType.Money, Convert.ToDouble(txtPotLumRp.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@disc", SqlDbType.Money, Convert.ToDouble(txtPotLumPersen.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@rpNet", SqlDbType.Money, Convert.ToDouble(txtNetto.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatPot.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@tglACC", SqlDbType.DateTime, SqlDateTime.Null));
                                db.Commands[0].Parameters.Add(new Parameter("@dilACC", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@catACC", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@discACC", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@idLink", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@statusACC", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();

                            }

                            //);

                            break;

                        case enumFormMode.Update:
                            if (txtTglACC.DateValue.HasValue)
                            {
                                GlobalVar.LastClosingDate = (DateTime)txtTglACC.DateValue;
                                if ((DateTime)txtTglACC.DateValue <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(String.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }
                            }
                           
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_PenjualanPotongan_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@notaPenjualanID", SqlDbType.UniqueIdentifier, _row));
                                db.Commands[0].Parameters.Add(new Parameter("@trID", SqlDbType.VarChar, trID));
                                db.Commands[0].Parameters.Add(new Parameter("@potID", SqlDbType.VarChar, potID));
                                db.Commands[0].Parameters.Add(new Parameter("@noPot", SqlDbType.VarChar, txtNoPot.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@tglPot", SqlDbType.DateTime, txtTglPot.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@dil", SqlDbType.Money, Convert.ToDouble(txtPotLumRp.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@disc", SqlDbType.Money, Convert.ToDouble(txtPotLumPersen.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@rpNet", SqlDbType.Money, Convert.ToDouble(txtNetto.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatPot.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@tglACC", SqlDbType.DateTime, txtTglACC.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@dilACC", SqlDbType.Money, Math.Round(Convert.ToDouble(txtACCRp.Text), 0)));
                                db.Commands[0].Parameters.Add(new Parameter("@catACC", SqlDbType.VarChar, txtCatACC.Text));
                                if (ajukan == true)
                                {
                                    db.Commands[0].Parameters.Add(new Parameter("@statusACC", SqlDbType.Bit, 0));
                                }
                                else if (acc == true)
                                {
                                    //cAcc = IIF(nDil_acc > 0,'v',' ')
                                    if (txtACCRp.GetDoubleValue > 0)
                                    {
                                        db.Commands[0].Parameters.Add(new Parameter("@statusACC", SqlDbType.Bit, 1));
                                       // LinkToPiutang();
                                        
                                    }
                                    else
                                    {
                                        db.Commands[0].Parameters.Add(new Parameter("@statusACC", SqlDbType.Bit, 0));
                                    }
                                }
                                db.Commands[0].Parameters.Add(new Parameter("@discACC", SqlDbType.Decimal, Convert.ToDecimal(txtACCPersen.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@idLink", SqlDbType.VarChar, ""));

                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();

                            }

                            if (ajukan == false)
                            {
                                if (acc == true)
                                {
                                    //cAcc = IIF(nDil_acc > 0,'v',' ')
                                    if (txtACCRp.GetDoubleValue > 0)
                                    {
                                        LinkToPiutang();
                                    }
                                   
                                }
                            }
                            
                            break;
                    }
                    MessageBox.Show("Data telah tersimpan");
                    this.DialogResult = DialogResult.OK;
                    
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    frmPenjualanPotonganBrowser frmCaller = (frmPenjualanPotonganBrowser)this.Caller;


                    frmCaller.RefreshData();
                    frmCaller.FindRow("RowID", _rowID.ToString());
                    this.Close();
                    frmCaller.Show();
                }
                
               
                
            }

            //}

           
        }

        public bool IsValid()
        {
            bool valid = true;
         
            if (txtNoNota.Text == "" || txtNilaiNota.Text  == "")
            {
                errorProvider1.SetError(txtNoNota, Messages.Error.InputRequired);
                txtNoNota.Focus();
                valid = false;
            }
            return valid;
        }

        private void txtNamaToko_SelectData(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Toko_SEARCH"));

                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNamaToko.TokoID.ToString()));
                    dt = db.Commands[0].ExecuteDataTable();
                    nama = Tools.isNull(dt.Rows[0]["NamaToko"],"").ToString();
                    alamat = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    txtAlamatKirim.Text = alamat;
                    kota= Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                    txtKota.Text = kota; 
                    txtIDWil.Text = Tools.isNull(dt.Rows[0]["WilID"],"").ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void txtNoNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void ShowDialogForm()
        {
            /*frmPotonganVNotaBrowse ifrmDialog = new frmPotonganVNotaBrowse(this, tokoID);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }*/
        }

       /* private void GetDialogResult(frmPotonganVNotaBrowse dialogForm)
        {
            _row = dialogForm.rowId;
            MessageBox.Show(_row.ToString());
            txtNoNota.Text = dialogForm.noNota;
            //txtTglNota.DateValue = dialogForm.tglNota;
            //txtNetto.Text = dialogForm.rpNetto.ToString();
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }*/

        private void txtPotLumPersen_TextChanged(object sender, EventArgs e)
        {
            if (txtPotLumPersen.Text != "")
            {
                txtPotLumRp.Text = ((Convert.ToDouble(txtPotLumPersen.Text)/100) * netto).ToString();
            }
        }

        private void txtACCPersen_TextChanged(object sender, EventArgs e)
        {
            if (txtACCPersen.Text != "")
            {
                txtACCRp.Text = ((Convert.ToDouble(txtACCPersen.Text) / 100) * netto).ToString();
            }
        }

        private void frmPenjualanPotonganUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmPenjualanPotonganBrowser)
                {
                    frmPenjualanPotonganBrowser frmCaller = (frmPenjualanPotonganBrowser)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("RowID", _rowID.ToString());
                }
            }
        }

        private void txtNoNota_Leave(object sender, EventArgs e)
        {
            if (txtNoNota.Text != string.Empty && txtNamaToko.KodeToko != string.Empty)
            {
                DataTable dt = new DataTable();
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetRowIDNota"));

                        db.Commands[0].Parameters.Add(new Parameter("@nonota", SqlDbType.VarChar, txtNoNota.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@kdToko", SqlDbType.VarChar, txtNamaToko.KodeToko));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count > 0)
                        {
                            _row = (Guid)dt.Rows[0]["RowID"];
                            if (formMode == enumFormMode.New)
                            {
                                if (txtNoNota.Text != "")
                                {
                                    DataTable dt2 = new DataTable();
                                    try
                                    {
                                        using (Database db2 = new Database())
                                        {
                                            db2.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_RowID"));

                                            db2.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _row));
                                            dt2 = db2.Commands[0].ExecuteDataTable();
                                            trID = Tools.isNull(dt2.Rows[0]["RecordID"], "").ToString();

                                            txtTglNota.DateValue = (DateTime?)dt2.Rows[0]["TglNota"];
                                            txtNilaiNota.Text = Tools.isNull(dt2.Rows[0]["RpJual3"], "").ToString();
                                            txtDisc1.Text = Tools.isNull(dt2.Rows[0]["Disc1"], "").ToString();
                                            txtDisc2.Text = Tools.isNull(dt2.Rows[0]["Disc2"], "").ToString();
                                            txtDisc3.Text = Tools.isNull(dt2.Rows[0]["Disc3"], "").ToString();
                                            double discvalue = Convert.ToDouble(dt2.Rows[0]["RpJual3"]) - Convert.ToDouble(dt2.Rows[0]["RpNet3"]);
                                            txtDiscValue.Text = discvalue.ToString();
                                            txtRetur.Text = discvalue.ToString();
                                            netto = Convert.ToDouble(dt2.Rows[0]["RpNet3"]);
                                            txtNetto.Text = netto.ToString();

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Error.LogError(ex);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tidak ada nota dengan nomor tersebut.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNoNota.Focus();
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void txtACCPersen_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtACCRp.Text) > 100.00)
            {

                txtACCRp.Focus();

            }
        }

        private void txtPotLumPersen_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPotLumPersen.Text) > 100.00)
            {

                txtPotLumPersen.Focus();

            }
        }

        private void LinkToPiutang()
        {




            if (Tools.isNull(dt.Rows[0]["idLink"], "").ToString() != "")
            {
                MessageBox.Show("Sudah Link ke Piutang", "Perhatian");
                return;
            }

            if (txtACCRp.GetDoubleValue == 0)
            {
                MessageBox.Show("Potongan belum  di ACC", "Perhatian");
                return;
            }

            if (MessageBox.Show("Link ke piutang....?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Guid potID = _rowID;
                Guid notaJualID = _row;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dtLinkPot = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_Potongan_LinkToPiutang"));
                        db.Commands[0].Parameters.Add(new Parameter("@potID", SqlDbType.UniqueIdentifier, potID));
                        db.Commands[0].Parameters.Add(new Parameter("@notaJualID", SqlDbType.UniqueIdentifier, notaJualID));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        dtLinkPot = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtLinkPot.Rows[0]["cekNota"].ToString() == "0")
                        MessageBox.Show("Nota tidak ada", "Perhatian");
                   
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
        }
    }
    }
