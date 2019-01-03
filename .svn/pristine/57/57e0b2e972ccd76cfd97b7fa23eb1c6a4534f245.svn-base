using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Finance
{
    public partial class frmClosingPJTools : ISA.Toko.BaseForm
    {
        public frmClosingPJTools()
        {
            InitializeComponent();
        }

        private void frmClosingPJTools_Load(object sender, EventArgs e)
        {
            tbBulan.Text = (DateTime.Now.Month - 1).ToString();
            tbTahun.Text = DateTime.Now.Year.ToString();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime awal = new DateTime(tbTahun.GetIntValue, tbBulan.GetIntValue, 01);
                int days = DateTime.DaysInMonth(tbTahun.GetIntValue, tbBulan.GetIntValue);
                DateTime akhir = new DateTime(tbTahun.GetIntValue, tbBulan.GetIntValue, days);

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ClosingStok_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tipe", SqlDbType.VarChar, "PJT"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAwal", SqlDbType.DateTime, awal));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAkhir", SqlDbType.DateTime, akhir));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedby", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }

                MessageBox.Show("Closing PJT berhasil");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
