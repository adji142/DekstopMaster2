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
    public partial class frmBukuBank_UPDATE_Tgl : ISA.Finance.BaseForm
    {
        DateTime tglJT;
        Guid IndenDetailID;
        public frmBukuBank_UPDATE_Tgl(Form caller, DateTime tglJT, Guid IndenDetailID)
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
        public DateTime TglRK
        {
            get { return tglJT; }
        }

        private void frmBukuBank_UPDATE_Tgl_Load(object sender, EventArgs e)
        {
            tbTglJT.DateValue = tglJT;
            tbTglJT.Focus();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (tbTglJT.DateValue.HasValue == false)
            {
                MessageBox.Show("Tanggal Rk Tidak Boleh Kosong");
                tbTglJT.Focus();
                return;
            }

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                 
                    db.Commands.Add(db.CreateCommand("[usp_BankDetail_update_tgl]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, IndenDetailID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglJT", SqlDbType.DateTime, (DateTime)tbTglJT.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                tglJT = tbTglJT.DateValue.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }



        }
    }
}
