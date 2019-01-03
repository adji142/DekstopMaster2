using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using System.Data.SqlTypes;
using ISA.Toko.Class;

namespace ISA.Toko.Kasir
{
    public partial class frmIndenUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, update };
        enumFormMode formMode;
        Guid RowIDI;
        DataTable dtIndenRow;
        string noBukti, CollectorID="", RpCash, RpTrf, RpGiro, RpCrd, RpDbt, Acc, NamaCollector="";
        DateTime TglKasir;

        public event EventHandler SelectData;


        public frmIndenUpdate(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
            formMode = enumFormMode.New;
            this.Text = "Tambah Inden";
        }

        public frmIndenUpdate(Form caller, Guid RowIDI, DataTable dtInden)
        {
            InitializeComponent();
            this.Caller = caller;
            this.RowIDI = RowIDI;
            formMode = enumFormMode.update;
            this.Text = "Edit Inden";
            dtIndenRow = dtInden.Copy();
            
        }

        private void frmIndenUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.New)
            {
                tbTanggal.DateValue = DateTime.Today;
                tbTanggal.Focus();
                tbTanggal.SelectAll();
            }
            else
            {
                dtIndenRow.DefaultView.RowFilter = @"RowID='" + RowIDI.ToString() + "'";

                tbNoBukti.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["NoBukti"].ToString();
                tbTanggal.DateValue = (DateTime)dtIndenRow.DefaultView.ToTable().Rows[0]["TglKasir"];
                lookupStafAdm1.Nama = dtIndenRow.DefaultView.ToTable().Rows[0]["NamaCollector"].ToString();
                tbTunai.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["RpCash"].ToString();
                tbTransfer.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["RpTrf"].ToString();
                tbGiro.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["RpGiro"].ToString();
                tbCrd.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["RpCrd"].ToString();
                tbDbt.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["RpDbt"].ToString();
                tbKasir.Text = dtIndenRow.DefaultView.ToTable().Rows[0]["Kasir"].ToString();
                lookupStafAdm2.Kode = dtIndenRow.DefaultView.ToTable().Rows[0]["CollectorID"].ToString();
                CollectorID = dtIndenRow.DefaultView.ToTable().Rows[0]["CollectorID"].ToString();
                lookupStafAdm1.Kode = dtIndenRow.DefaultView.ToTable().Rows[0]["CollectorID"].ToString();
            }
        }

        private void clearForm()
        {
            tbNoBukti.Clear();
            tbTanggal.Clear();
            lookupStafAdm1.Kode = "";
            tbCrd.Clear();
            tbDbt.Clear();
            tbGiro.Clear();
            tbKasir.Clear();
            lookupStafAdm2.Kode = "";
            tbTransfer.Clear();
            tbTunai.Clear();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbTanggal.DateValue.ToString() != "" && lookupStafAdm1.Nama != "")
                {
                    TglKasir = (DateTime)tbTanggal.DateValue;
                    Acc = lookupStafAdm2.Kode;
                    NamaCollector = lookupStafAdm1.Nama;
                    if (formMode == enumFormMode.New)
                    {
                        
                        if (PeriodeClosing.IsKasirClosed(TglKasir))
                        {
                            MessageBox.Show("Sudah Closing!");
                            return;
                        }
                        noBukti = Numerator.BookNumerator("IND");
                        RowIDI = Guid.NewGuid();
                        string RecordIDI = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);

                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Inden_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDI));
                            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordIDI));
                            db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, TglKasir));
                            db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, SecurityManager.UserName));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, noBukti));
                            db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, CollectorID));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaCollector", SqlDbType.VarChar, NamaCollector));
                            db.Commands[0].Parameters.Add(new Parameter("@Acc", SqlDbType.VarChar, Acc));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();

                        }

                        frmPenerimaanBelumTeridentifikasiBrowse frm = new frmPenerimaanBelumTeridentifikasiBrowse();
                        frm = (frmPenerimaanBelumTeridentifikasiBrowse)Caller;
                        frm.IndenRefresh();
                        frm.IndenFindRow("RowIDI", RowIDI.ToString());
                        this.Close();
                    }


                    else
                    {
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Inden_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDI));
                            db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, TglKasir));
                            db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, SecurityManager.UserName));
                            db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, CollectorID));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaCollector", SqlDbType.VarChar, NamaCollector));
                            db.Commands[0].Parameters.Add(new Parameter("@Acc", SqlDbType.VarChar, Acc));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();

                        }

                        frmPenerimaanBelumTeridentifikasiBrowse frm = new frmPenerimaanBelumTeridentifikasiBrowse();
                        frm = (frmPenerimaanBelumTeridentifikasiBrowse)Caller;
                        frm.IndenRefresh();
                        frm.IndenFindRow("RowIDI", RowIDI.ToString());
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(Messages.Error.InputRequired);
                    return;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        //private void lookupCollectorDialog()
        //{
        //    frmLookupCollector ifrmDialog = new frmLookupCollector(tbCollector.Text);
        //    ifrmDialog.ShowDialog();
        //    if (ifrmDialog.DialogResult == DialogResult.OK)
        //    {
        //        GetDialogResult(ifrmDialog);
        //    }
        //}

        //private void GetDialogResult(frmLookupCollector dialogForm)
        //{
        //    this.CollectorID = dialogForm.KodeCollector;
        //    this.NamaCollector = dialogForm.NamaCollector;
        //    tbCollector.Text = NamaCollector;

        //    if (this.SelectData != null)
        //    {
        //        this.SelectData(this, new EventArgs());
        //    }

        //}

        private void tbCollector_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    lookupCollectorDialog();
            //}
        }

 

    }
}
