using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Toko.Class;
using ISA.DAL;
using ISA.Common;

namespace ISA.Toko.Kasir
{
    public partial class frmVoucherGiroTitipUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid RowID;
        
        public frmVoucherGiroTitipUpdate(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
            formMode = enumFormMode.New;
        }

        public frmVoucherGiroTitipUpdate(Form caller, DataTable dtEdit)
        {
            InitializeComponent();
            this.Caller = caller;
            formMode = enumFormMode.Update;
            this.RowID =(Guid) dtEdit.Rows[0]["RowID"];
            lookupBank1.BankID = dtEdit.Rows[0]["BankID"].ToString();
            lookupBank1.NamaBank = dtEdit.Rows[0]["NamaBank"].ToString();
            tbUraian1.Text = dtEdit.Rows[0]["Uraian1"].ToString();
            tbUraian2.Text = dtEdit.Rows[0]["Uraian2"].ToString();
            tbUraian3.Text = dtEdit.Rows[0]["Uraian3"].ToString();
            tbDibuat.Text = dtEdit.Rows[0]["Dibuat"].ToString();
            tbDibukukan.Text = dtEdit.Rows[0]["Dibukukan"].ToString();
            tbMengetahui.Text = dtEdit.Rows[0]["Mengetahui"].ToString();
            tbNominal.Text = dtEdit.Rows[0]["Nilai"].ToString();
            tbNoVch.Text = dtEdit.Rows[0]["NoVoucher"].ToString();
            tbTanggal.DateValue = (DateTime)dtEdit.Rows[0]["TglVoucher"];
        }

        private void frmVoucherGiroTitipUpdate_Load(object sender, EventArgs e)
        {
            tbTanggal.DateValue = DateTime.Today;
            tbDibuat.Text = SecurityManager.UserName;
            tbNoVch.Text = Numerator.GetNextNumeratorNew("VTG");
            
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookupBank1.BankID == "" || lookupBank1.BankID == "[CODE]")
                {
                    MessageBox.Show(Messages.Error.InputRequired);
                    lookupBank1.Focus();
                    return;
                }
                if (formMode == enumFormMode.New)
                {
                    DateTime _Tanggal = tbTanggal.DateValue.Value;
                    if (PeriodeClosing.IsKasirClosed(_Tanggal))
                    {
                        MessageBox.Show("Sudah Closing!");
                        return;
                    }
                    RowID = Guid.NewGuid();
                    string RecordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        VoucherJournal.AddHeader(db, RowID, Guid.Empty, RecordID, "TT", (DateTime)tbTanggal.DateValue, Numerator.BookNumerator("VTG"), tbUraian1.Text, tbUraian2.Text, tbUraian3.Text, tbDibuat.Text, tbDibukukan.Text, tbMengetahui.Text, lookupBank1.BankID, lookupBank1.NamaBank, 0, true);
                    }
                }
                else
                {
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        db.Commands.Add(db.CreateCommand("usp_VoucherJournal_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, lookupBank1.BankID));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, lookupBank1.NamaBank));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian1", SqlDbType.VarChar, tbUraian1.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian2", SqlDbType.VarChar, tbUraian2.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian3", SqlDbType.VarChar, tbUraian3.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Dibukukan", SqlDbType.VarChar, tbDibukukan.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Mengetahui", SqlDbType.VarChar, tbMengetahui.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.Commands.Add(db.CreateCommand("usp_GIRO_Titip_UPDATE"));
                        db.Commands[1].Parameters.Add(new Parameter("@TitipID", SqlDbType.UniqueIdentifier, RowID));
                        db.Commands[1].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, lookupBank1.BankID));
                        db.Commands[1].Parameters.Add(new Parameter("@NamaBanki", SqlDbType.VarChar, lookupBank1.NamaBank));
                        db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.BeginTransaction();
                        db.Commands[0].ExecuteNonQuery();
                        db.Commands[1].ExecuteNonQuery();
                        db.CommitTransaction();

                    }
                }

                frmVoucherGiroTitipanBrowse frm = new frmVoucherGiroTitipanBrowse();
                frm = (frmVoucherGiroTitipanBrowse)Caller;
                frm.HeaderRowRefresh(RowID);
                frm.HeaderFindRow("hdrRowID", RowID.ToString());
                this.Close();


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

     
    }
}
