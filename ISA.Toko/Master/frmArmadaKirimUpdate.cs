using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmArmadaKirimUpdate : ISA.Controls.BaseForm
    {
        public frmArmadaKirimUpdate()
        {
            InitializeComponent();
        }

        public frmArmadaKirimUpdate(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
            txtKodeArmada.Text=Numerator.GetNextNumeratorNew("ARK");
        }

        private void frmArmadaKirimUpdate_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtKendaraan.Text=="")
            {
                MessageBox.Show("Kendaraan belum diisi");
                txtKendaraan.Focus();
                return;
            }

            if (txtNomorPolisi.Text == "")
            {
                MessageBox.Show("NomorPolisi belum diisi");
                txtNomorPolisi.Focus();
                return;
            }
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ArmadaKirim"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeArmada", SqlDbType.VarChar, txtKodeArmada.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Kendaraan", SqlDbType.VarChar, txtKendaraan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@NomorPolisi", SqlDbType.VarChar, txtNomorPolisi.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@TripMeterKM", SqlDbType.Int, txtTripMeterKM.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@KMPerLiter", SqlDbType.Int, txtKMPerLiter.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, "add"));
                    db.Commands[0].ExecuteNonQuery();
                }

                txtKodeArmada.Text=Numerator.BookNumeratorNew("ARK");
                frmArmadaKirim frm = new frmArmadaKirim();
                frm = (frmArmadaKirim)Caller;
                frm.RefreshData();
                this.Close();
            }
            catch(Exception ex)
            {
                Error.LogError(ex);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
