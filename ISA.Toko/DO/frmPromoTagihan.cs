using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.DO
{
    public partial class frmPromoTagihan : ISA.Toko.BaseForm
    {
        DataTable dtTagihan1;
       
        public frmPromoTagihan(Form caller, DataTable dtTagihan)
        {
            InitializeComponent();
            this.Caller = caller;
            dtTagihan1 = dtTagihan;

        }
        public frmPromoTagihan()
        {
            InitializeComponent();
        }

        private void frmPromoTagihan_Load(object sender, EventArgs e)
        {
            datagridviewBarangPromo.DataSource = dtTagihan1;
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cbSave_Click(object sender, EventArgs e)
        {
            DO.FrmDO frmCaller = (DO.FrmDO)this.Caller;
            if (datagridviewBarangPromo.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in datagridviewBarangPromo.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["pilih"].Value) == true)
                    {
                        DataTable dtetap = new DataTable();
                        dtetap.Columns.Add("id_brg");
                        dtetap.Columns.Add("nama_stok");
                        dtetap.Columns.Add("qty_bns");
                        dtetap.Columns.Add("satuan");
                        dtetap.Columns.Add("h_jual");
                        dtetap.Rows.Add(row.Cells["IDbarang"].Value, row.Cells["BarangP"].Value, Convert.ToInt32(row.Cells["QtyBonus"].Value).ToString(), row.Cells["sat"].Value, row.Cells["h_jual"].Value);

                        if (!frmCaller.savepromo(dtetap))
                            MessageBox.Show("Barang sudah ada.");
                    }
                }
            }
            this.Close();
        }
    }
}
