using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Finance.Piutang
{
    public partial class frmpotonganpenjualanidentifikasi : ISA.Finance.BaseForm
    {
        Guid _RowID;
        double _saldo;
        public Double NomIden {
            get { return TxtNomIdentifikasi.GetDoubleValue; }
        }
        public Double NomPotSisa {
            get { return txtNomPotSisa.GetDoubleValue; }
        }
        public frmpotonganpenjualanidentifikasi()
        {
            InitializeComponent();
        }
        public frmpotonganpenjualanidentifikasi(Guid RowID,double saldo)
        {
            _RowID = RowID;
            _saldo = saldo;
            InitializeComponent();
        }

        private void frmpotonganpenjualanidentifikasi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database()) {
                    db.Commands.Add(db.CreateCommand("usp_PenjualanPotongan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0) {
                    txttglPI.Text = dt.Rows[0]["TglSuratJalan"].ToString();
                    txtTglTerima.Text = dt.Rows[0]["TglTerima"].ToString();
                    txtToko.Text = dt.Rows[0]["NamaToko"].ToString();
                    txtIDWill.Text = dt.Rows[0]["WilID"].ToString();
                    txtalamat.Text = dt.Rows[0]["Alamat"].ToString();
                    txtKota.Text = dt.Rows[0]["Kota"].ToString();
                    txttglacc.Text = dt.Rows[0]["TglACC"].ToString();
                    txtNoPotongan.Text = dt.Rows[0]["NoPot"].ToString();
                    txtNomPotACC.Text = dt.Rows[0]["DilACC"].ToString();
                    txtNomPotSisa.Text = dt.Rows[0]["SisaIden"].ToString();
                    txtNoNota.Text = dt.Rows[0]["NoNota"].ToString();
                    TxtNomIdentifikasi.Text = _saldo.ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            double nomSisa = txtNomPotSisa.GetDoubleValue;
            double NomIden = TxtNomIdentifikasi.GetDoubleValue;
            if (NomIden > nomSisa) {
                MessageBox.Show("Nominal Identifikasi Tidak bisa lebih dari Nominal Sisa");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
