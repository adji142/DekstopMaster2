using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Finance.Class;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.Kasir
{
    public partial class frmBuktiHILink : ISA.Finance.BaseForm
    {
        DateTime tglBukti;
        double jumlah;
        Guid refRowIDHeader, refRowIDDetail;
        string DK, refTipe, CD, src, cabang, refNoBukti, noPerkiraan, uraian, namaSP, refRecordIDHeader, refRecordIDDetail;

        public frmBuktiHILink(Form caller, string DK, string refTipe, string CD, string src, DateTime tglBukti, string refNoBukti, 
            Guid refRowIDHeader, string noPerkiraan, string uraian, double jumlah, Guid refRowIDDetail, string namaSP, 
            string refRecordIDHeader, string refRecordIDDetail)
        {
            InitializeComponent();
            this.Caller = caller;
            this.tglBukti = tglBukti;
            this.noPerkiraan = noPerkiraan;
            this.uraian = uraian;
            this.jumlah = jumlah;
            this.refRowIDHeader = refRowIDHeader;
            this.refRowIDDetail = refRowIDDetail;
            this.refNoBukti = refNoBukti;
            this.DK = DK; 
            this.refTipe = refTipe; 
            this.CD = CD;
            this.src = src;
            this.namaSP = namaSP;
            this.refRecordIDHeader = refRecordIDHeader;
            this.refRecordIDDetail = refRecordIDDetail;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void cmdOK_Click(object sender, EventArgs e)
        //{
        //    if (CabangDKN.Text == "")
        //    {
        //        MessageBox.Show("Cabang belum diisi.");
        //        CabangDKN.Focus();
        //        return;
        //    }

        //    if (tbRpIdentifikasi.GetDoubleValue == 0)
        //    {
        //        MessageBox.Show("Rp Identifikasi Tidak Boleh 0.");
        //        tbRpIdentifikasi.Focus();
        //        return;
        //    }

        //    if (tbRpIdentifikasi.GetDoubleValue > jumlah)
        //    {
        //        MessageBox.Show("Rp Identifikasi Tidak Boleh lebih dari " + jumlah.ToString("#,###"));
        //        tbRpIdentifikasi.Focus();
        //        return;
        //    }

        //    cabang = CabangDKN.Text;
        //    double rpIdentifikasi = tbRpIdentifikasi.GetDoubleValue;

        //    DataTable dtCek = new DataTable();
        //    dtCek = DKN.CekLinkDKN(refRowIDHeader, cabang);

            
        //    Guid _rowID = new Guid();
        //    String _recordID = "";
        //    using (Database db = new Database(GlobalVar.DBName))
        //    {
        //        db.BeginTransaction();
        //        if (dtCek.Rows.Count == 0)
        //        {
        //            _rowID = Guid.NewGuid();
        //            _recordID =  refRecordIDHeader.Trim()+ cabang.Substring(0, 2);
        //            DKN.DKNInsert(db, _rowID, _recordID, DK, refTipe, CD, src, DateTime.Today, cabang, refNoBukti, refRowIDHeader);
        //        }
        //        else
        //        {
        //            DataTable dtCekDet = new DataTable();
        //            dtCekDet = dtCek.Copy();
        //            dtCekDet.DefaultView.RowFilter = "RefRowID='" + refRowIDDetail.ToString() + "'";
        //            if (dtCekDet.DefaultView.Count > 0)
        //            {
        //                MessageBox.Show("Sudah Pernah Link ke Cabang " + cabang + ".");
        //                return;
        //            }
        //            _rowID = (Guid)dtCek.Rows[0][0];
        //            _recordID = dtCek.Rows[0][1].ToString();
        //        }

        //        DKN.DKNDetailInsert(db, _rowID, _recordID, noPerkiraan, uraian, rpIdentifikasi, refRowIDDetail, refRecordIDDetail.Trim() + cabang.Substring(0, 2), "", "", Guid.Empty,Guid.Empty,"");
        //        DKN.DKNDetailInsert(db, rowIDdetail, _HeaderID, HRecordID, NoPerkiraan, Uraian, Jumlah, refRowID, refRecordID, KodeKolektor, bankID, _BankTujuanRowID, _BankKotaRowID, _KodeToko);

        //        DKN.UpdateKodeLink(db, refRowIDDetail, "#", namaSP,"");
        //        db.CommitTransaction();
        //    }
        //    this.Close();


        //}
                
                //finally
                //{

                //    if (this.Caller.Name=="frmBKMBrowse")
                //    {
                //        frmBKMBrowse frm = new frmBKMBrowse();
                //        frm = (frmBKMBrowse)this.Caller;
                //        frm.DetailRefresh();
                //        frm.FindRowDetail("rowIDD", refRowIDDetail.ToString());
                //    }
                //    else if (this.Caller.Name == "frmBKKBrowse")
                //    {
                //        frmBKKBrowse frm = new frmBKKBrowse();
                //        frm = (frmBKKBrowse)this.Caller;
                //        
                //    }
                //    else if (this.Caller.Name == "frmVoucherJournalBrowse")
                //    {
                //        frmVoucherJournalBrowse frm = new frmVoucherJournalBrowse();
                //        frm = (frmVoucherJournalBrowse)this.Caller;
                //        frm.RefreshDetail();
                //        frm.FindRowDetail("dtlRowID", refRowIDDetail.ToString());
                //    }
                //    this.Close();
                //}

            
        

        private void frmBuktiHILink_Load(object sender, EventArgs e)
        {
            
            try
            {
                DataTable dtCabang = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_DKNCabang_List"));
                    dtCabang = db.Commands[0].ExecuteDataTable();
                }
                dtCabang.DefaultView.Sort = "KodeCabang";
                CabangDKN.DataSource = dtCabang.DefaultView.ToTable();
                CabangDKN.DisplayMember = "KodeCabang";
                tbRpIdentifikasi.Text = jumlah.ToString();
                CabangDKN.Focus();

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
    }
}
