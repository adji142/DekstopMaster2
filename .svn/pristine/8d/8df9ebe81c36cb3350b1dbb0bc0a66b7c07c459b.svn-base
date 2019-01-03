using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using ISA.Toko.Class;

namespace ISA.Toko.Kasir
{
    public partial class frmKasbonUpdate : ISA.Toko.BaseForm
    {
        enum enumformMode { New, Update };
        enumformMode formMode;
        Guid _RowID;
        string _RecordID;
        DataTable dtKasbon;
        double total, nominal, selisih;
        DataTable dtVoucher = new DataTable();

        string bankID = "", bankAsal = "", nomor = "";

        public frmKasbonUpdate()
        {
            InitializeComponent();
        }
        

        public frmKasbonUpdate(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
            formMode = enumformMode.New;
        }

        public frmKasbonUpdate(Form caller, DataTable dtKasbon)
        {
            InitializeComponent();
            this.Caller = caller;
            formMode = enumformMode.Update;
            this.dtKasbon = dtKasbon;
            
        }

        private void lookupPegawai1_SelectData(object sender, EventArgs e)
        {
            tbDivisi.Text = "";
            tbNip.Text = lookupPegawai1.Kode;
        }

        private void frmKasbonUpdate_Load(object sender, EventArgs e)
        {
            lookupPerkiraanKoneksi1.Header = "BS";
            this.Title = formMode == enumformMode.New ? this.Title + " Insert" : this.Title + " Update";
            if (formMode == enumformMode.New)
            {
                groupBox2.Enabled = false;
                groupBox1.Enabled = true;
                tbTanggal.DateValue = DateTime.Today;
                tbDue.DateValue = DateTime.Today;
                tbHari.Focus();
            }
            else
            {
                DataColumn dc1 = new DataColumn("RowID", System.Type.GetType("System.Guid"));
                DataColumn dc2 = new DataColumn("RecordID", System.Type.GetType("System.String"));
                DataColumn dc3 = new DataColumn("TglVoucher", System.Type.GetType("System.DateTime"));
                DataColumn dc4 = new DataColumn("NoPerkiraan", System.Type.GetType("System.String"));
                DataColumn dc5 = new DataColumn("Keterangan", System.Type.GetType("System.String"));
                DataColumn dc6 = new DataColumn("NoAcc", System.Type.GetType("System.String"));
                DataColumn dc7 = new DataColumn("Debet", System.Type.GetType("System.Double"));
               
                dtVoucher.Columns.Add(dc1);
                dtVoucher.Columns.Add(dc2);
                dtVoucher.Columns.Add(dc3);
                dtVoucher.Columns.Add(dc4);
                dtVoucher.Columns.Add(dc5);
                dtVoucher.Columns.Add(dc6);
                dtVoucher.Columns.Add(dc7);

                _RowID = (Guid)dtKasbon.Rows[0]["RowID"];
                _RecordID = dtKasbon.Rows[0]["RecordID"].ToString();
                TBNoKasbon.Text = dtKasbon.Rows[0]["NoBukti"].ToString();
                tbTanggal.DateValue = (DateTime)dtKasbon.Rows[0]["Tgl"];
                tbHari.Text = dtKasbon.Rows[0]["Hari"].ToString();
                tbDue.DateValue = ((DateTime)tbTanggal.DateValue).AddDays(Convert.ToDouble(tbHari.Text));
                lookupPegawai1.Nama = dtKasbon.Rows[0]["Nama"].ToString();
                lookupPegawai1.Kode = dtKasbon.Rows[0]["NIP"].ToString();
                //lookupPegawai1.Unitkerja = dtKasbon.Rows[0]["UnitKerja"].ToString();
                tbNip.Text = lookupPegawai1.Kode;
                //tbDivisi.Text = lookupPegawai1.Unitkerja;
                tbKeperluan.Text = dtKasbon.Rows[0]["Keperluan"].ToString().Trim();
                tbNoBkk.Text = dtKasbon.Rows[0]["BKKNo1"].ToString();
                lookupPerkiraanKoneksi1.NoPerkiraan = dtKasbon.Rows[0]["NoPerkiraan"].ToString();
                tbNominal.Text = dtKasbon.Rows[0]["BKKRp1"].ToString();
                tbSisa.Text = dtKasbon.Rows[0]["BKKRp1"].ToString();
                selisih = Convert.ToDouble(dtKasbon.Rows[0]["BKKRp1"].ToString());
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                cbBkk.Enabled = false;
                cbBkm.Enabled = true;
                cbTrm.Enabled = true;
                tbRpTrm.Enabled = false;
                tbBKK.Enabled = false;
                tbBKM.Enabled = false;
                cmdDetailTransfer.Enabled = false;
                gridVoucher.Focus();
            }
        }

        private void tbHari_TextChanged(object sender, EventArgs e)
        {
            int i=0;
            if (int.TryParse(tbHari.Text, out i))
            {

                if (tbHari.GetDoubleValue > 0)
                    tbDue.DateValue = DateTime.Today.AddDays(Convert.ToDouble(tbHari.Text));
                else
                    tbDue.DateValue = DateTime.Today;
            }
            else
            {
                tbHari.Text = "0";
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validate()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (tbHari.Text == "" || tbHari.GetIntValue<0)
            {
                errorProvider1.SetError(tbHari, "Jumlah Hari Harus Diisi, Minimal 0");
                valid = false;
            }

            if (tbNominal.Text == "" || tbNominal.Text == "0" || tbNominal.GetDoubleValue<0)
            {
                errorProvider1.SetError(tbNominal, "Nominal Harus Lebih Besar Dari 0");
                valid = false;
            }
            
                       
            if (tbNip.Text == "" )
            {
                errorProvider1.SetError(lookupPegawai1, "Data Pegawai Harus Diisi Dengan Benar");
                valid = false;
            }
            
            if (tbKeperluan.Text == "")
            {
                errorProvider1.SetError(tbKeperluan, "Keperluan Harus Diisi");
                valid = false;
            }

            if (lookupPerkiraanKoneksi1.NamaPerkiraan == "" || lookupPerkiraanKoneksi1.NoPerkiraan == "" || lookupPerkiraanKoneksi1.NoPerkiraan == "[CODE]")
            {
                errorProvider1.SetError(lookupPerkiraanKoneksi1, "Perkiraan Harus Diisi");
                valid = false;
            }


            return valid;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            bool isPrinted = LookupInfoValue.CekPrintBs();
            
            if (formMode == enumformMode.New)
            {
                if (!validate())
                    return;
                DateTime _Tanggal = (DateTime)tbTanggal.DateValue;
                if (PeriodeClosing.IsKasirClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing!");
                    return;
                }
                _RowID = Guid.NewGuid();
                string _RecordID = Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial, 1);
                string _RecordIDBKKDetail = Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial, 2);
                string _NoBKK = Numerator.BookNumerator("BKK");
                string _NoBukti = Numerator.BookNumerator("BON");
                try
                {
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Kasbon_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecordID));
                        db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, lookupPegawai1.Kode));
                        db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, lookupPegawai1.Nama));
                        //db.Commands[0].Parameters.Add(new Parameter("@UnitKerja", SqlDbType.VarChar, lookupPegawai1.Unitkerja));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, _NoBukti));
                        db.Commands[0].Parameters.Add(new Parameter("@Tgl", SqlDbType.DateTime, tbTanggal.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Keperluan", SqlDbType.VarChar, tbKeperluan.Text.Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@BKKNo1", SqlDbType.VarChar, _NoBKK));
                        db.Commands[0].Parameters.Add(new Parameter("@BKKRp1", SqlDbType.Money, tbNominal.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Total1", SqlDbType.Money, tbNominal.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@Hari", SqlDbType.VarChar, tbHari.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, lookupPerkiraanKoneksi1.NoPerkiraan));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.BeginTransaction();
                        db.Commands[0].ExecuteNonQuery();
                        BKK.AddHeader(db, _RowID,_RowID, BKK.GetRecordIDBukti(_RecordID,"BSA"), _NoBKK, "","BSA", (DateTime)tbTanggal.DateValue, lookupPegawai1.Nama, "", "", SecurityManager.UserName, "");
                        BKK.AddDetail(db, Guid.NewGuid(),_RowID, _RecordIDBKKDetail, BKK.GetRecordIDBukti(_RecordID, "BSA"), "", "", "", "", lookupPerkiraanKoneksi1.NoPerkiraan, tbKeperluan.Text.Trim() + " (" + _NoBukti + ")", tbNominal.Text);
                        db.CommitTransaction();
                    }
                    string nominal = tbNominal.GetDoubleValue.ToString("#,###");
                    
                    if (isPrinted)
                    {
                        cetakLaporan(_NoBKK, tbKeperluan.Text.Trim() + " (" + _NoBukti + ")", nominal, tbTanggal.DateValue.Value.ToString("dd/MM/yyyy"), "K");
                    }
                    frmKasbonBrowse frm = new frmKasbonBrowse();
                    frm = (frmKasbonBrowse)Caller;
                    //frm.KasbonRefresh(_RowID);
                    frm.KasbonRefresh();
                    frm.KasbonFindRow("RowID", _RowID.ToString());
                    this.Close();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                if (tbSisa.Text != "0")
                {
                    MessageBox.Show("Masih ada sisa BS, tidak boleh di update.");
                    return;
                }
                if (tbRpTrm.Text != "0" && bankID=="")
                {
                    MessageBox.Show("Detail transfer belum diisi.");
                    return;
                }

                string noVJU = "", noBKK3 = "", noBKM3 = "", noTRM3 = "";
                double rpVJU = 0, rpBKK3 = 0, rpBKM3 = 0, rpTRM3 = 0, rpTotle = 0, rpTotku = 0;

                if (dtVoucher.Rows.Count > 0)
                {
                    noVJU = Numerator.BookNumerator("VJU");
                    rpVJU = Convert.ToDouble(tbTotal.Text);
                }
                if (selisih < 0)
                {
                    rpTotku = selisih*-1;
                    rpBKK3 = Convert.ToDouble(tbBKK.Text);
                    noBKK3 = Numerator.BookNumerator("BKK");
                }
                else 
                {
                    rpTotle = Convert.ToDouble(tbBKM.Text) + Convert.ToDouble(tbRpTrm.Text);
                    if (cbBkm.Checked == true)
                    {
                        rpBKM3 = Convert.ToDouble(tbBKM.Text);
                        noBKM3 = Numerator.BookNumerator("BKM");
                    }

                    if (cbTrm.Checked == true)
                    {
                        rpTRM3 = Convert.ToDouble(tbRpTrm.Text);
                        noTRM3 = Numerator.BookNumerator("BBM");
                    }

                    
                }

                try
                {
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        db.BeginTransaction();

                        db.Commands.Add(db.CreateCommand("usp_Kasbon_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@JVNo1", SqlDbType.VarChar, noVJU));
                        db.Commands[0].Parameters.Add(new Parameter("@BKKNo3", SqlDbType.VarChar, noBKK3));
                        db.Commands[0].Parameters.Add(new Parameter("@BKMNo3", SqlDbType.VarChar, noBKM3));
                        db.Commands[0].Parameters.Add(new Parameter("@TRNNo3", SqlDbType.VarChar, noTRM3));
                        db.Commands[0].Parameters.Add(new Parameter("@JVRp1", SqlDbType.Money, rpVJU));
                        db.Commands[0].Parameters.Add(new Parameter("@Total2", SqlDbType.Money, Convert.ToDouble(tbTotal.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@BKKRp3", SqlDbType.Money, rpBKK3));
                        db.Commands[0].Parameters.Add(new Parameter("@BKMRp3", SqlDbType.Money, rpBKM3));
                        db.Commands[0].Parameters.Add(new Parameter("@TRNRp3", SqlDbType.Money, rpTRM3));
                        db.Commands[0].Parameters.Add(new Parameter("@Totle3", SqlDbType.Money, rpTotle));
                        db.Commands[0].Parameters.Add(new Parameter("@Totku3", SqlDbType.Money, rpTotku));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                        if (dtVoucher.Rows.Count > 0)
                        {

                            string vjRecID = _RecordID + "X";

                            VoucherJournal.AddHeader(db, _RowID, _RowID, vjRecID, "UM", DateTime.Today, noVJU, tbKeperluan.Text.Trim() + " (" + TBNoKasbon.Text + ")", "", "", SecurityManager.UserName, "", "", "", "", 0, true);

                            foreach (DataRow dr in dtVoucher.Rows)
                            {
                                VoucherJournal.AddDetail(db, (Guid)dr["RowID"], _RowID, dr["RecordID"].ToString(), vjRecID, "", "", dr["NoAcc"].ToString(), "", dr["NoPerkiraan"].ToString(), dr["Keterangan"].ToString() + " (" + TBNoKasbon.Text + ")", (Double)dr["Debet"], 0, true);
                            }

                            if (isPrinted)
                            {
                                cetakLaporanVju(noVJU, String.Format("{0:dd/MM/yyyy}", DateTime.Today));
                            }
                        }

                        if (cbBkm.Checked == true)
                        { 
                            Guid rowID = Guid.NewGuid();
                            string recIDD = Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial,2);
                            string uraian = "KELEBIHAN BS " + tbKeperluan.Text.Trim() + " (" + TBNoKasbon.Text + ")";
                            BKM.AddHeader(db, rowID,_RowID,  BKM.GetRecordIDBukti(_RecordID,"BSL"), noBKM3, "","BSL", DateTime.Today, lookupPegawai1.Nama, "", "", SecurityManager.UserName, "");
                            BKM.AddDetail(db, Guid.NewGuid(), rowID, recIDD, BKM.GetRecordIDBukti(_RecordID, "BSL"), "", "", "", "", "", uraian, rpBKM3.ToString());

                            if (isPrinted)
                            {
                                cetakLaporan(noBKM3, uraian, rpBKM3.ToString("#,###"), String.Format("{0:dd/MM/yyyy}", DateTime.Today), "M");
                            }
                        }

                        if (cbBkk.Checked == true)
                        {
                            Guid rowID = Guid.NewGuid();
                            string recIDD = Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial,2);
                            string uraian = "KEKURANGAN BS " + tbKeperluan.Text.Trim() + " (" + TBNoKasbon.Text + ")";
                            BKK.AddHeader(db, rowID,_RowID, BKK.GetRecordIDBukti(_RecordID, "BSK"), noBKK3, "","BSK", DateTime.Today, lookupPegawai1.Nama, "", "", SecurityManager.UserName, "");
                            BKK.AddDetail(db, Guid.NewGuid(), rowID, recIDD, BKK.GetRecordIDBukti(_RecordID, "BSK"), "", "", "", "", "", uraian, rpBKK3.ToString());

                            if (isPrinted)
                            {
                                cetakLaporan(noBKK3, uraian, rpBKK3.ToString("#,###"), String.Format("{0:dd/MM/yyyy}", DateTime.Today), "K");
                            }
                        }

                        if (cbTrm.Checked == true)
                        {
                            Guid rowID = _RowID;
                            string uraian = "KELEBIHAN BS " + tbKeperluan.Text.Trim() + " (" + TBNoKasbon.Text + ")";

                            TransferBank.addHeader(db, rowID,_RowID, _RecordID.TrimEnd()+"8", DateTime.Today, noTRM3, "M",bankID, bankAsal, "", "", SecurityManager.UserName, lookupPegawai1.Nama);
                            TransferBank.addDetail(db, rowID, rowID, _RecordID.TrimEnd() + "8", _RecordID.TrimEnd() + "8", "", uraian, bankAsal, "", nomor, DateTime.Today, rpTRM3.ToString(), "", "", "", "", bankID, "", "");

                            Bank.AddBankDetail(db, rowID, Guid.Empty, noTRM3, "", Guid.Empty, "", DateTime.Today, "BBM", "TRANSFER DARI : " + uraian, "IDR", rpTRM3.ToString(), "0", DateTime.Today, DateTime.Today, "", "", "", "", "", bankID, _RecordID.TrimEnd() + "8");
                        }

                        db.CommitTransaction();
                        

                    }

                    frmKasbonBrowse frm = new frmKasbonBrowse();
                    frm = (frmKasbonBrowse)Caller;
                    frm.KasbonRefresh(_RowID);
                    frm.KasbonFindRow("RowID", _RowID.ToString());
                    this.Close();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }


        

        private void gridVoucher_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Insert)
                {
                    frmVoucherJournalUmumUpdate frm = new frmVoucherJournalUmumUpdate(this, tbKeperluan.Text.Trim());
                    frm.ShowDialog();
                }
                else if (e.KeyCode == Keys.Space)
                {
                    if (gridVoucher.SelectedCells.Count > 0)
                    {
                        int index = (int)gridVoucher.SelectedCells[0].RowIndex;
                        string noPerkiraan = gridVoucher.SelectedCells[0].OwningRow.Cells["NoPerkiraan"].Value.ToString();
                        string keterangan = gridVoucher.SelectedCells[0].OwningRow.Cells["Keterangan"].Value.ToString();
                        string NoAcc = gridVoucher.SelectedCells[0].OwningRow.Cells["NoAcc"].Value.ToString();
                        string jumlah = gridVoucher.SelectedCells[0].OwningRow.Cells["Jumlah"].Value.ToString();
                        frmVoucherJournalUmumUpdate frm = new frmVoucherJournalUmumUpdate(this,noPerkiraan,keterangan,NoAcc,jumlah, index);
                        frm.ShowDialog();
                    }
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    if (gridVoucher.SelectedCells.Count > 0)
                    {
                        int index = (int)gridVoucher.SelectedCells[0].RowIndex;
                        dtVoucher.Rows[index].Delete();
                        dtVoucher.AcceptChanges();
                        VoucherRefresh();
                    }
                }
            
        }

        public void VoucherRefresh()
        {
            dtVoucher.DefaultView.Sort = "RecordID";
            gridVoucher.DataSource = dtVoucher.DefaultView.ToTable();
            total = Convert.ToDouble(dtVoucher.Compute("Sum(Debet)", ""));
            nominal = Convert.ToDouble(tbNominal.Text);
            selisih = nominal - total;

            cbBkk.Checked = false;
            tbBKK.Clear();
            cbBkm.Checked = false;
            tbBKM.Clear();
            cbTrm.Checked = false;
            tbRpTrm.Clear();
            if (selisih < 0)
            {
                cbBkk.Enabled = true;
                cbBkk.Checked = true;
                tbBKK.Enabled = true;
                tbBKK.Text = (selisih * -1).ToString();

                cbBkm.Enabled = false;
                cbTrm.Enabled = false;
                tbBKM.Enabled = false;
                tbRpTrm.Enabled = false;
                cmdDetailTransfer.Enabled = false;
            }
            else if (selisih > 0)
            {
                cbBkm.Enabled = true;
                cbBkm.Checked = true;
                tbBKM.Enabled = true;
                tbBKM.Text = selisih.ToString();

                cbBkk.Enabled = false;
                cbTrm.Enabled = false;
                tbBKK.Enabled = false;
                tbRpTrm.Enabled = false;
                cmdDetailTransfer.Enabled = false;
            }
            else
            {
                cbBkm.Enabled = false;
                cbBkm.Checked = false;
                tbBKM.Enabled = false;
                cbBkk.Enabled = false;
                cbTrm.Enabled = false;
                tbBKK.Enabled = false;
                tbRpTrm.Enabled = false;
                cmdDetailTransfer.Enabled = false;
                tbSisa.Text = "0";
            }
            tbTotal.Text = total.ToString();
            tbPengembalian.Text = selisih.ToString();
        }

        public void InsertGridVoucher(Guid RowID, string RecordID, DateTime Tgl, string NoPerk, string uraian, string noACC, Double nilai)
        {
            dtVoucher.Rows.Add(RowID, RecordID, Tgl, NoPerk, uraian, noACC, nilai);
            dtVoucher.AcceptChanges();
        }
        public void UpdateGridVoucher(int index, string NoPerk, string uraian, string noACC, Double nilai)
        {
            dtVoucher.Rows[index].BeginEdit();
            dtVoucher.Rows[index]["NoPerkiraan"] = NoPerk;
            dtVoucher.Rows[index]["Keterangan"] = uraian;
            dtVoucher.Rows[index]["NoAcc"] = noACC;
            dtVoucher.Rows[index]["Debet"] = nilai;
            dtVoucher.Rows[index].EndEdit();
            dtVoucher.AcceptChanges();
        }

        private void cbBkk_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBkk.Checked == false)
            {
                tbBKK.Clear();
                tbPengembalian.Clear();
                tbSisa.Text = selisih.ToString();
            }
            else
            {
                tbSisa.Clear();
                tbBKK.Text = (selisih * -1).ToString();
                tbPengembalian.Text = selisih.ToString();
            }
        }

        private void tbBKK_TextChanged(object sender, EventArgs e)
        {
            if (tbBKK.Text == "")
                tbBKK.Text = "0";

            tbPengembalian.Text = (Convert.ToDouble(tbBKK.Text) * -1).ToString();
            tbSisa.Text = (selisih + Convert.ToDouble(tbBKK.Text)).ToString();
        }

        private void cbBkm_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBkm.Checked == false)
            {
                tbPengembalian.Text = (Convert.ToDouble(tbPengembalian.Text)-Convert.ToDouble(tbBKM.Text)).ToString();
                tbSisa.Text = (selisih - Convert.ToDouble(tbPengembalian.Text)).ToString();
                tbBKM.Clear();

                if (tbSisa.Text != "0" && cbTrm.Enabled == false)
                {

                    cbTrm.Enabled = true;
                    
                }
            }
            else
            {
                tbBKM.Text = Convert.ToDouble(tbSisa.Text).ToString();
                tbPengembalian.Clear();
                tbPengembalian.Text = (Convert.ToDouble(tbBKM.Text) + Convert.ToDouble(tbRpTrm.Text)).ToString();
                tbSisa.Clear();
                tbBKM.Enabled = true;
                if (Convert.ToDouble(tbBKM.Text) == selisih)
                {
                    cbTrm.Enabled = false;
                    tbRpTrm.Enabled = false;
                    cmdDetailTransfer.Enabled = false;
                }
            }
        }

        private void tbBKM_TextChanged(object sender, EventArgs e)
        {
            if (tbBKM.Text == "")
                tbBKM.Text = "0";

            tbPengembalian.Text = (Convert.ToDouble(tbBKM.Text) + Convert.ToDouble(tbRpTrm.Text)).ToString();
            tbSisa.Text = (selisih - Convert.ToDouble(tbPengembalian.Text)).ToString();

            if (tbSisa.Text != "0" && cbTrm.Enabled == false)
            {

                cbTrm.Enabled = true;
                cmdDetailTransfer.Enabled = true;
            }
            else if (Convert.ToDouble(tbBKM.Text) == selisih)
            {
                cbTrm.Enabled = false;
                tbRpTrm.Enabled = false;
                cmdDetailTransfer.Enabled = false;
            }
        }

        private void cbTrm_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTrm.Checked == false)
            {
                tbRpTrm.Clear();
                tbPengembalian.Text = (Convert.ToDouble(tbBKM.Text) + Convert.ToDouble(tbRpTrm.Text)).ToString();
                tbSisa.Text = (selisih - Convert.ToDouble(tbPengembalian.Text)).ToString();
                
                cmdDetailTransfer.Enabled = false;
                this.bankID = "";
                this.bankAsal = "";
                this.nomor = "";
                pictureBox1.Visible = false;
                if (tbSisa.Text != "0" && cbBkm.Enabled == false)
                {

                    cbBkm.Enabled = true;
                    
                }
            }
            else
            {
                tbRpTrm.Text = Convert.ToDouble(tbSisa.Text).ToString();
                tbPengembalian.Text = (Convert.ToDouble(tbBKM.Text) + Convert.ToDouble(tbRpTrm.Text)).ToString();
                tbSisa.Clear();
                tbRpTrm.Enabled = true;
                cmdDetailTransfer.Enabled = true;
                if (Convert.ToDouble(tbRpTrm.Text) == selisih)
                {
                    cbBkm.Enabled = false;
                    tbBKM.Enabled = false;
                }
            }
        }

        private void tbRpTrm_TextChanged(object sender, EventArgs e)
        {
            if (tbRpTrm.Text == "")
                tbRpTrm.Text = "0";

            tbPengembalian.Text = (Convert.ToDouble(tbBKM.Text) + Convert.ToDouble(tbRpTrm.Text)).ToString();
            tbSisa.Text = (selisih - Convert.ToDouble(tbPengembalian.Text)).ToString();

            if (tbSisa.Text != "0" && cbBkm.Enabled == false)
            {
                cbBkm.Enabled = true;
            }
            else if (Convert.ToDouble(tbRpTrm.Text) == selisih)
            {
                cbBkm.Enabled = false;
                tbBKM.Enabled = false;
            }
        }

        private void cmdDetailTransfer_Click(object sender, EventArgs e)
        {
            this.bankAsal = "";
            this.bankID = "";
            this.nomor = "";
            pictureBox1.Visible = false;
            frmLookupDetailTransfer frm = new frmLookupDetailTransfer(this);
            frm.ShowDialog();
        }

        public void DetailTransfer(string BankID, string AsalBank, string Nomor)
        {
            this.bankAsal = AsalBank;
            this.bankID = BankID;
            this.nomor = Nomor;
            if(this.bankID!="" && this.bankID!="[CODE]" )
                pictureBox1.Visible = true;
        }


        #region cetak laporan
        public void cetakLaporan(string _NoBukti, string uraian, string total, string _Tanggal, string MK)
        {
            string _judul = "", _h2 = "", _penerima = "";
            if (MK == "M")
            {
                _judul = "[BUKTI KAS MASUK]";
                _h2 = "Di Terima Dari : ";
                _penerima = "Penyetor";
            }
            else
            {
                _judul = "[BUKTI KAS KELUAR]";
                _h2 = "Kepada : ";
                _penerima = "Penerima";
            }
            string _Kepada ="", _Kasir;
            _Kepada = lookupPegawai1.Nama.Trim();
            _Kasir = SecurityManager.UserName;
            uraian=uraian.Trim();
            try
            {
                BuildString lap = new BuildString();
                lap.Initialize();

                lap.PageLLine(33);
                lap.LeftMargin(1);
                lap.FontCPI(12);
                lap.LineSpacing("1/6");
                lap.DoubleWidth(true);
                lap.PROW(true, 1, _judul);
                lap.DoubleWidth(false);

                lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp()
                + lap.PrintHorizontalLine(41) + lap.PrintTopRightCorner());
                lap.PROW(true, 1, lap.PrintVerticalLine() + _h2.PadRight(41) +
                    lap.PrintVerticalLine() + ("Nomor   : " + _NoBukti).PadRight(41) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + _Kepada.PadRight(41) + lap.PrintVerticalLine() + ("Tanggal : " +
                    _Tanggal).PadRight(30) + ("Hal : 1/1").PadRight(11) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                    + lap.PrintHorizontalLine(41) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "No. Prk".PadRight(10) + lap.PadCenter(58, "URAIAN") + lap.SPACE(15) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

                lap.PROW(true, 1, lap.PrintVerticalLine() + "".ToString().Trim().PadRight(10) + uraian.ToString().ToUpper().PadRight(58).Substring(0, 58) + total.PadLeft(15) + lap.PrintVerticalLine());
                    

                
                for (int j = 0; j < 9; j++)
                {
                    lap.PROW(true, 1, lap.PrintVerticalLine() + lap.SPACE(83) + lap.PrintVerticalLine());
                }


                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "Terbilang".PadRight(58) + "Jumlah Rp.".PadRight(10) +
                    total.PadLeft(15) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + Tools.Terbilang(Convert.ToDouble(total)).PadRight(83) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTTOp()
                    + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "Pembukuan") + lap.PrintVerticalLine() + lap.PadCenter(20, "Mengetahui")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "Kasir") + lap.PrintVerticalLine() + lap.PadCenter(20, _penerima) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "") + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "")
                    + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kasir.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kepada.Trim()).Substring(0, 18) + ")" +
                    lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom()
                    + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintBottomRightCorner());
                lap.PROW(true, 1, String.Format("{0:yyyyMMddhhmmss}", DateTime.Now) + " " + SecurityManager.UserName);
                lap.Eject();

                using (Database db = new Database("ISADBDepoFinance"))
                {
                    db.Commands.Add(db.CreateCommand("rsp_CetakBukti"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                lap.SendToPrinter("laporan.txt");
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        #endregion

        #region cetak laporan vju
        public void cetakLaporanVju(string _NoBukti, string _Tanggal)
        {
            
            int i = 0;
            double total = 0, jumlah;
            string _Kepada, _Kasir;
            _Kepada = TBNoKasbon.Text + " Rp." + tbNominal.Text;
            _Kasir = SecurityManager.UserName;
            try
            {
                BuildString lap = new BuildString();
                lap.Initialize();

                lap.PageLLine(33);
                lap.LeftMargin(1);
                lap.FontCPI(12);
                lap.LineSpacing("1/6");
                lap.DoubleWidth(true);
                lap.PROW(true, 1, "[BUKTI KAS KELUAR]");
                lap.DoubleWidth(false);

                lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp()
                + lap.PrintHorizontalLine(41) + lap.PrintTopRightCorner());
                lap.PROW(true, 1, lap.PrintVerticalLine() + ("Di Terima Dari : "+lookupPegawai1.Nama.Trim()).PadRight(41) +
                    lap.PrintVerticalLine() + ("Nomor   : " + _NoBukti).PadRight(41) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + _Kepada.PadRight(41) + lap.PrintVerticalLine() + ("Tanggal : " +
                    _Tanggal).PadRight(30) + ("Hal : 1/1").PadRight(11) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                    + lap.PrintHorizontalLine(41) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "No. Prk".PadRight(10) + lap.PadCenter(58, "URAIAN") + lap.SPACE(15) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

                foreach (DataRow dr in dtVoucher.Rows)
                {
                    string uraian = dr["Keterangan"].ToString().Trim();
                    if (dr["NoACC"].ToString() != "")
                        uraian += " ACC " + dr["NoACC"].ToString().Trim();
                    jumlah = Convert.ToDouble(dr["Debet"].ToString());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + "".ToString().Trim().PadRight(10) + (uraian + " (" + TBNoKasbon.Text + ")").ToUpper().PadRight(58).Substring(0, 58) + jumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                    
                    total += Convert.ToDouble(dr["Debet"].ToString());
                    i++;
                }
                if (i < 10)
                {
                    for (int j = 0; j < 10 - i; j++)
                    {
                        lap.PROW(true, 1, lap.PrintVerticalLine() + lap.SPACE(83) + lap.PrintVerticalLine());
                    }
                }
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "Terbilang".PadRight(58) + "Jumlah Rp.".PadRight(10) +
                    total.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + Tools.Terbilang(total).PadRight(83) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTTOp()
                    + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "Pembukuan") + lap.PrintVerticalLine() + lap.PadCenter(20, "Mengetahui")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "Kasir") + lap.PrintVerticalLine() + lap.PadCenter(20, "Penerima") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "") + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "")
                    + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kasir.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "".Trim()) + ")" +
                    lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom()
                    + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintBottomRightCorner());
                lap.PROW(true, 1, String.Format("{0:yyyyMMddhhmmss}", DateTime.Now) + " " + SecurityManager.UserName);
                lap.Eject();

                lap.SendToPrinter("laporan.txt");


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        #endregion

      
    }
}
