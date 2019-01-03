using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Penjualan
{
    public partial class frmInfoStok : ISA.Trading.BaseForm
    {
        string _kodeBarang, _namaBarang;

        public frmInfoStok(Form caller, string kodeBarang, string namaBarang)
        {
            InitializeComponent();
            _kodeBarang = kodeBarang;
            _namaBarang = namaBarang;
            this.Caller = caller;
        }

        private void frmInfoStok_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            this.Title = "Info Stok";
            this.Text = _namaBarang;
            GetInfoStok();            
        }

        private void GetInfoStok()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_StokGudang_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _kodeBarang));
                    db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, GlobalVar.Gudang));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dataGridView1.DataSource = dt;
                txtQtyStok.Text = dt.Compute("SUM(Stok)", string.Empty).ToString();
                txtQtyAwal.Text = dt.Compute("SUM(QtyAwal)", string.Empty).ToString();
                txtQtyJual.Text = dt.Compute("SUM(QtyJual)", string.Empty).ToString();
                txtQtyBeli.Text = dt.Compute("SUM(QtyBeli)", string.Empty).ToString();
                txtQtyRetJ.Text = dt.Compute("SUM(QtyRetJual)", string.Empty).ToString();
                txtQtyRetB.Text = dt.Compute("SUM(QtyRetBeli)", string.Empty).ToString();
                txtQtyKoreksi.Text = dt.Compute("SUM(QtyKoreksi)", string.Empty).ToString();
                txtQtyAntarGudang.Text = dt.Compute("SUM(QtyAntarGudang)", string.Empty).ToString();
                txtQtySelisih.Text = dt.Compute("SUM(QtySelisih)", string.Empty).ToString();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
