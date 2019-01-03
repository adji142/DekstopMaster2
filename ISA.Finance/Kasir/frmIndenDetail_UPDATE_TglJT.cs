using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Finance.Kasir
{
    public partial class frmIndenDetail_UPDATE_TglJT : ISA.Finance.BaseForm
    {
        DateTime tglJT;
        Guid IndenDetailID;
        public frmIndenDetail_UPDATE_TglJT(Form caller, DateTime tglJT, Guid IndenDetailID)
        {
            InitializeComponent();
            this.Caller = caller;
            this.tglJT = tglJT;
            this.IndenDetailID = IndenDetailID;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIndenDetail_UPDATE_TglJT_Load(object sender, EventArgs e)
        {
            tbTglJT.DateValue = tglJT;
            tbTglJT.Focus();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (tbTglJT.Text == "")
            {
                MessageBox.Show("Tanggal J.Tempo Tidak Boleh Kosong");
                tbTglJT.Focus();
                return;
            }

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_IndenDetail_UPDATE_TglJT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, IndenDetailID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglJT", SqlDbType.DateTime, (DateTime)tbTglJT.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }

                MessageBox.Show("Update Tanggal J.Tempo Berhasil");
                frmPenerimaanBelumTeridentifikasiBrowse frm = new frmPenerimaanBelumTeridentifikasiBrowse();
                frm = (frmPenerimaanBelumTeridentifikasiBrowse)Caller;
                frm.IndenDetailRowRefresh(IndenDetailID);
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }



        }
    }
}
