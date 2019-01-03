using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using System.Data.SqlTypes;
using ISA.Toko.Class;

namespace ISA.Toko.Kasir
{
    public partial class frmIndenSubDetailUpdate : ISA.Toko.BaseForm
    {
        double teridentifikasi;
        Guid RowIDI, RowIDID;
        string RecordIDID, chbg,_KodeCollector;
        DateTime tglKasirInden;
        DataTable dtBPP = new DataTable();

        public frmIndenSubDetailUpdate(Form caller, double teridentifikasi, Guid HeaderID, Guid IndenID, string HRecordID, string CHBG, DateTime tglKasirInden, string KodeCollector)
        {
            InitializeComponent();
            this.Caller = caller;
            this.teridentifikasi = teridentifikasi;
            this.RowIDID = HeaderID;
            this.RowIDI = IndenID;
            this.RecordIDID = HRecordID;
            this.chbg=CHBG;
            this.tglKasirInden = tglKasirInden;
            this._KodeCollector = KodeCollector;
        }

        //private void lookupToko_Leave(object sender, EventArgs e)
        //{
        //    if (lookupToko.KodeToko != "[CODE]")
        //    {
        //        string kodeToko = lookupToko.KodeToko;
        //        try
        //        {
        //            DataTable dt = new DataTable();
        //            using (Database db = new Database(GlobalVar.DBFinance))
        //            {
        //                db.Commands.Add(db.CreateCommand("usp_GetPiutangToko"));
        //                db.Commands[0].Parameters.Add(new Parameter("@KodeToko",SqlDbType.VarChar,kodeToko));
        //                dt=db.Commands[0].ExecuteDataTable();
        //            }
        //            tbSisaPiutang.Text = dt.Rows[0]["RpNota"].ToString();
        //            tbPembayaran.Text = dt.Rows[0]["RpBayar"].ToString();
        //            tbTotalTagihan.Text = dt.Rows[0]["RpTagih"].ToString();
        //        }
        //        catch (Exception ex)
        //        {
        //            Error.LogError(ex);
        //        }

        //    }
        //}

        private void cbNonPiut_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNonPiut.Checked == true)
            {
                lookupToko.Visible = false;
                tbNamaToko.Visible = true;
                tbTglBPP.Enabled = false;
                tbNoBPP.Enabled = false;
                tbNoRegister.Enabled = false;
                tbTeidentifikasi.Enabled = false;
            }
            else
            {
                tbNamaToko.Visible = false;
                lookupToko.Visible = true;
                tbTglBPP.Enabled = true;
                tbNoBPP.Enabled = true;
                tbNoRegister.Enabled = true;
                tbTeidentifikasi.Enabled = true;
            }
        }

        private void frmIndenSubDetailUpdate_Load(object sender, EventArgs e)
        {
            tbTglBPP.DateValue = DateTime.Today;
            tbTglKasir.DateValue = DateTime.Today;
            tbTeidentifikasi.Text = teridentifikasi.ToString();
            lookupToko.Focus();
        }

        private void tbNoRegister_Leave(object sender, EventArgs e)
        {
            if (GlobalVar.Gudang != "2803")
            {
                if (tbNoRegister.Text != "" && lookupToko.KodeToko != "[CODE]")
                {
                    string kodeToko = lookupToko.KodeToko;
                    string noreg = tbNoRegister.Text;
                    string hasil;
                    try
                    {
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            db.Commands.Add(db.CreateCommand("usp_CekNoReg"));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodeToko));
                            db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, noreg));
                            hasil = db.Commands[0].ExecuteScalar().ToString();
                        }

                        if (hasil != "OK")
                        {
                            MessageBox.Show(hasil);
                            tbNoRegister.Clear();
                            tbNoRegister.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Guid RowID;
            try
            {
                if (cbNonPiut.Checked == true)
                {
                    if (tbNamaToko.Text == "")
                    {
                        MessageBox.Show("Nama Toko Belum Diisi");
                        tbNamaToko.Focus();
                        return;
                    }
                    if (tbTeidentifikasi.GetDoubleValue > teridentifikasi)
                    {
                        MessageBox.Show("Nominal tidak boleh lebih dari " + teridentifikasi.ToString("#,###"));
                        tbTeidentifikasi.Focus();
                        return;
                    }
                    if (tbTeidentifikasi.GetDoubleValue == 0)
                    {
                        MessageBox.Show("Nominal tidak boleh 0");
                        tbTeidentifikasi.Focus();
                        return;
                    }
                    if (tbTglKasir.Text == "")
                    {
                        MessageBox.Show("Tanggal Kasir Belum Diisi");
                        tbTglKasir.Focus();
                        return;
                    }

                    //ga pengaruh periode closing,, harus >=tglkasir
                    DateTime tglKasir = (DateTime)tbTglKasir.DateValue;
                    if (PeriodeClosing.IsPJTClosed(tglKasir))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }

                    if (tglKasir < tglKasirInden)
                    {
                        MessageBox.Show("Tanggal Identifikasi Tidak Boleh Lebih Kecil Dari Tanggal Kasir.");
                        return;
                    }
                    string namaToko = tbNamaToko.Text;
                    
                    DateTime tglBPP = (DateTime)tbTglBPP.DateValue;
                    string nominal = tbTeidentifikasi.Text;
                    RowID = Guid.NewGuid();
                    Guid RowIDSup = Guid.NewGuid();
                    string RecordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                    string RecordIDSup = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);

                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        db.BeginTransaction();
                        addIndenSubDetail(db, RowID, RowIDID, RowIDI, RecordID, RecordIDID, "", namaToko, "", "", tglBPP, tglKasir, nominal);
                        addIndenSuperDetail(db, RowIDSup, RowID, RowIDI, RowIDID, RecordIDSup, RecordID, Guid.Empty, "", Guid.Empty, "", "NP", tglBPP, "", chbg, "", tglKasir, (DateTime)SqlDateTime.Null, "", "", "", nominal, "0", "0");
                        db.CommitTransaction();
                    }

                }
                else
                {
                    if (lookupToko.KodeToko == "[CODE]")
                    {
                        MessageBox.Show("Nama Toko Belum Diisi");
                        lookupToko.Focus();
                        return;
                    }
                    if (tbTeidentifikasi.GetDoubleValue > teridentifikasi)
                    {
                        MessageBox.Show("Nominal tidak boleh lebih dari " + teridentifikasi.ToString("#,###"));
                        tbTeidentifikasi.Focus();
                        return;
                    }
                    if (tbTglBPP.Text == "")
                    {
                        MessageBox.Show("Tanggal BPP Belum Diisi");
                        tbTglBPP.Focus();
                        return;
                    }

                    if (tbTglKasir.Text == "")
                    {
                        MessageBox.Show("Tanggal Kasir Belum Diisi");
                        tbTglKasir.Focus();
                        return;
                    }
                    
                    //if (tbNoBPP.Text == "")
                    //{
                    //    MessageBox.Show("No BPP Belum Diisi");
                    //    tbNoBPP.Focus();
                    //    return;
                    //}

                    //if (GlobalVar.Gudang != "2803")
                    //{
                    //    if (tbNoRegister.Text == "")
                    //    {
                    //        MessageBox.Show("No Reg Belum Diisi");
                    //        tbNoRegister.Focus();
                    //        return;
                    //    }
                    //}

                    //ga pengaruh periode closing,, harus >=tglkasir
                    DateTime tglKasir = (DateTime)tbTglKasir.DateValue;
                    if (PeriodeClosing.IsPJTClosed(tglKasir))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }

                    if (tglKasir < tglKasirInden)
                    {
                        MessageBox.Show("Tanggal Identifikasi Tidak Boleh Lebih Kecil Dari Tanggal Kasir.");
                        return;
                    }

                    string namaToko = lookupToko.NamaToko;
                    string kodeToko = lookupToko.KodeToko;
                    string noReg = tbNoRegister.Text;
                    string noBPP = tbNoBPP.Text;
                    DateTime tglBPP = (DateTime)tbTglBPP.DateValue;
                    string nominal = tbTeidentifikasi.Text;
                    RowID = Guid.NewGuid();
                    string RecordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);

                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        db.BeginTransaction();
                        addIndenSubDetail(db, RowID, RowIDID, RowIDI, RecordID, RecordIDID, kodeToko, namaToko, noReg, noBPP, tglBPP, tglKasir, nominal);
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_Giro_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, RowIDID));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodeToko));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        db.CommitTransaction();
                    }

                }

                frmPenerimaanBelumTeridentifikasiBrowse frm = new frmPenerimaanBelumTeridentifikasiBrowse();
                frm = (frmPenerimaanBelumTeridentifikasiBrowse)Caller;
                frm.IndenRowRefresh(RowIDI);
                frm.IndenDetailRowRefresh(RowIDID);
                frm.IndenSubDetailRowRefresh(RowID);
                frm.IndenSubDetailFindRow("RowIDISD", RowID.ToString());
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void addIndenSubDetail(
                Database db,
                Guid RowID, 
		        Guid HeaderID, 
		        Guid IndenID, 
		        string RecordID, 
		        string HRecordID, 
		        string KodeToko,
                string NamaToko,
		        string NoReg, 
		        string NoBPP, 
		        DateTime TglBPP,
                DateTime TglKasir, 
		        string RpNominal
            )
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_IndenSubDetail_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID));
            db.Commands[0].Parameters.Add(new Parameter("@IndenID", SqlDbType.UniqueIdentifier, IndenID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, HRecordID));
            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko));
            db.Commands[0].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, NamaToko));
            db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, NoReg));
            db.Commands[0].Parameters.Add(new Parameter("@NoBPP", SqlDbType.VarChar, NoBPP));
            db.Commands[0].Parameters.Add(new Parameter("@TglBPP", SqlDbType.DateTime, TglBPP));
            db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, TglKasir));
            db.Commands[0].Parameters.Add(new Parameter("@RpNominal", SqlDbType.Money, RpNominal));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }

        private void addIndenSuperDetail(
                Database db,
                Guid RowID, 
		        Guid HeaderID, 
		        Guid IndenID, 
		        Guid IndenDetailID,
		        string RecordID, 
		        string HRecordID,   
		        Guid TagihDetailID, 
		        string TagihDetailRecID, 
		        Guid KPID, 
		        string KPrecID, 
                string Src,
		        DateTime TglBPP, 
		        string NoReg, 
		        string Ref, 
		        string NoBukti, 
		        DateTime TglInden, 
		        DateTime TglJatuhTempo, 
		        string Kode, 
		        string Sub, 
		        string NoPerk, 
		        string RpInden, 
		        string RpNota, 
		        string RpTagih
            )
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_IndenSuperDetail_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID));
            db.Commands[0].Parameters.Add(new Parameter("@IndenID", SqlDbType.UniqueIdentifier, IndenID));
            db.Commands[0].Parameters.Add(new Parameter("@IndenDetailID", SqlDbType.UniqueIdentifier, IndenDetailID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, HRecordID));
            db.Commands[0].Parameters.Add(new Parameter("@TagihDetailID", SqlDbType.UniqueIdentifier, TagihDetailID));
            db.Commands[0].Parameters.Add(new Parameter("@TagihDetailRecID", SqlDbType.VarChar, TagihDetailRecID));
            db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.UniqueIdentifier, KPID));
            db.Commands[0].Parameters.Add(new Parameter("@KPrecID", SqlDbType.VarChar, KPrecID));
            db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Src));
            db.Commands[0].Parameters.Add(new Parameter("@TglBPP", SqlDbType.VarChar, TglBPP));
            db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, NoReg));
            db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, Ref));
            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoBukti));
            db.Commands[0].Parameters.Add(new Parameter("@TglInden", SqlDbType.VarChar, TglInden));
            db.Commands[0].Parameters.Add(new Parameter("@TglJatuhTempo", SqlDbType.VarChar, TglJatuhTempo));
            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Kode));
            db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, Sub));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerk", SqlDbType.VarChar, NoPerk));
            db.Commands[0].Parameters.Add(new Parameter("@RpInden", SqlDbType.VarChar, RpInden));
            db.Commands[0].Parameters.Add(new Parameter("@RpNota", SqlDbType.VarChar, RpNota));
            db.Commands[0].Parameters.Add(new Parameter("@RpTagih", SqlDbType.VarChar, RpTagih));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lookupToko_SelectData(object sender, EventArgs e)
        {
            if (lookupToko.KodeToko != "[CODE]")
            {
                string kodeToko = lookupToko.KodeToko;
                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetPiutangToko"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodeToko));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    tbSisaPiutang.Text = dt.Rows[0]["RpNota"].ToString();
                    tbPembayaran.Text = dt.Rows[0]["RpBayar"].ToString();
                    tbTotalTagihan.Text = dt.Rows[0]["RpTagih"].ToString();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }

            }
        }

        private void LoadBPP()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_LoadBPP_Lookup"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, tbNoBPP.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeCollector", SqlDbType.VarChar, _KodeCollector));

                    dtBPP = db.Commands[0].ExecuteDataTable();
                }

                if (dtBPP.Rows.Count == 1)
                {

                    tbNoBPP.Text = Tools.isNull(dtBPP.Rows[0]["NoBPP"], "").ToString();
                }
                else
                {
                    frmLookupBPP frm = new frmLookupBPP(tbNoBPP.Text, dtBPP, GlobalVar.Gudang,_KodeCollector);
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        GetDialogResult(frm);
                    }
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void tbNoBPP_Leave(object sender, EventArgs e)
        {
            LoadBPP();
        }

        private void GetDialogResult(frmLookupBPP dialogForm)
        {
            tbNoBPP.Text = dialogForm.BPP;
            
        }
        
    }
}
