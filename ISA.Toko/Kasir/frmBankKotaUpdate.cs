using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Kasir
{
    public partial class frmBankKotaUpdate : ISA.Toko.BaseForm
    {
        public frmBankKotaUpdate(Form caller)
        {
            Caller = caller;
            InitializeComponent();
        }

        private void frmBankKotaUpdate_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                string nama = tbNama.Text;
                string lokasi = tbLokasi.Text;
                
                

                Guid rowID=Guid.NewGuid();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_BankKota_CEKBANK"));
                    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, nama));
                    db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, lokasi));
                    int cekrow=(int)db.Commands[0].ExecuteScalar();

                    if (cekrow>0)
                    {
                        MessageBox.Show("Nama Bank " + nama + " Dengan Lokasi " + lokasi + " Sudah Ada");
                        tbNama.Focus();
                        return;
                    }
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_BankKota_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, nama));
                    db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, lokasi));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }

                ISA.Toko.Controls.frmBankAsalLookup frm = new ISA.Toko.Controls.frmBankAsalLookup();
                frm = (ISA.Toko.Controls.frmBankAsalLookup)Caller;
                frm.RefreshRowData(rowID);
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }
    }
}
