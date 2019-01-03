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

namespace ISA.Toko.Kasir
{
    public partial class frmIndenSuperDetail_NonNota_UPDATE : ISA.Toko.BaseForm
    {
        Guid RowIDISD, RowIDI, RowIDID;
        string RecordIDISD, chbg;
        double nominalSisa;

        public frmIndenSuperDetail_NonNota_UPDATE()
        {
            InitializeComponent();
        }

        public frmIndenSuperDetail_NonNota_UPDATE(Form caller, Guid rowIDISD, Guid RowIDI, Guid RowIDID, string RecordIDISD, string chbg, double nominalSisa)
        {
            InitializeComponent();
            this.Caller = caller;
            this.RowIDI = RowIDI;
            this.RowIDID = RowIDID;
            this.RowIDISD = rowIDISD;
            this.RecordIDISD = RecordIDISD;
            this.chbg = chbg;
            this.nominalSisa = nominalSisa;
        }

        private void frmIndenSuperDetail_NonNota_UPDATE_Load(object sender, EventArgs e)
        {
            tbTglInden.DateValue = DateTime.Today;
            tbNominal.Text = nominalSisa.ToString();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string nominal = tbNominal.Text;
            Guid RowID = Guid.NewGuid();
            string RecordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);

            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.BeginTransaction();
                addIndenSuperDetail(db, RowID, RowIDISD, RowIDI, RowIDID, RecordID, RecordIDISD, Guid.Empty, "", Guid.Empty, "", "NP", tbTglInden.DateValue.Value, "", chbg, "", tbTglInden.DateValue.Value, (DateTime)SqlDateTime.Null, "", "", "?", nominal, "0", "0");
                db.CommitTransaction();
            }
            frmPenerimaanBelumTeridentifikasiBrowse frm = new frmPenerimaanBelumTeridentifikasiBrowse();
            frm = (frmPenerimaanBelumTeridentifikasiBrowse)Caller;
            frm.IndenRowRefresh(RowIDI);
            frm.IndenDetailRowRefresh(RowIDID);
            frm.IndenSubDetailRowRefresh(RowIDISD);
            frm.IndenSuperDetailRowRefresh(RowID);
            frm.IndenSuperDetailFindRow("RowIDISSD", RowID.ToString());
            this.Close();
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

        

    }
}
