using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ISA.Toko;
using ISA.Controls;
using ISA.DAL;
using ISA.Toko.Controls;

namespace ISA.Toko.DO
{
    public partial class FrmBarcodeDO :ISA.Toko.BaseForm
    {
        string idbarangpilih;
        string KreditGenuine="";

        //untuk ambil barang sesuai jenis transaksi
        string _kelompok;
        string JenisTransact;
        //end

        public FrmBarcodeDO(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
            //this.JenisTransact = jenistransaksi;
            //this._kelompok = jenistransaksi.ToString().Substring(0, 2);
            //if (flagkg != "")
            //{
            //    KreditGenuine = flagkg.ToString();
            //}
            //else
            //{
            //    KreditGenuine = "KG";
            //}
        }

        public FrmBarcodeDO(Form caller, string jenistransaksi )
        {
            InitializeComponent();
            this.Caller = caller;
            this._kelompok = jenistransaksi;
            lblfilter.Visible = true;
            lbljw.Visible = true;
            lbljw.Text = _kelompok.ToString();
        }

        public FrmBarcodeDO(Form caller, string jenistransaksi, DataTable dt, String kataKunci)
        {
            InitializeComponent();
            this.Caller = caller;
            this._kelompok = jenistransaksi;
           // this._kelompok = jenistransaksi.ToString().Substring(0, 2);
            CGBarang.DataSource = dt;
            txtCari.Text = kataKunci;
            //if (flagkg != "")
            //{
            //    KreditGenuine = flagkg.ToString();
            //}
            //else
            //{
            //    KreditGenuine = "KG";
            //}
        }

        private void FrmBarcode_Load(object sender, EventArgs e)
        {
            txtCari.Focus();
            button1.Select();
        }

        public void CariData(string kelompok)
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH2_perKode"));
                db.Commands[0].Parameters.Add(new Parameter("@katakunci", SqlDbType.VarChar, txtCari.Text.ToString()));
                db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, _kelompok.ToString()));
                //db.Commands[0].Parameters.Add(new Parameter("@TransactionTypeRowID", SqlDbType.UniqueIdentifier, JenisTransact));
                dt = db.Commands[0].ExecuteDataTable();
                CGBarang.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    CGBarang.Focus();
                }
            }
        }

        public void TampilData(string kelompok)
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH2_perKode"));
                db.Commands[0].Parameters.Add(new Parameter("@katakunci", SqlDbType.VarChar, txtCari.Text.ToString()));
                db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, _kelompok.ToString()));
                //db.Commands[0].Parameters.Add(new Parameter("@TransactionTypeRowID", SqlDbType.UniqueIdentifier, JenisTransact));
                dt = db.Commands[0].ExecuteDataTable();
                CGBarang.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    CGBarang.Focus();
                }
            }
        }
        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            //if (customGridView1.SelectedCells.Count == 1)
            //{
                ConfirmSelect();
            //}
        }
        private void ConfirmSelect()
        {
            
            int stokbrg = Convert.ToInt32(Tools.isNull(CGBarang.SelectedCells[0].OwningRow.Cells["StokBarang"].Value,0));

            if (stokbrg <= 0)
            {
                MessageBox.Show("Stok Barang Kosong");
                return;
            }
            //else
            //{
                idbarangpilih = CGBarang.SelectedCells[0].OwningRow.Cells["IdBarang"].Value.ToString();
                int stok = Convert.ToInt32(CGBarang.SelectedCells[0].OwningRow.Cells["StokBarang"].Value);
          
                if (this.Caller is DO.FrmDO2803)
                {
                    DO.FrmDO2803 frmCaller = (DO.FrmDO2803)this.Caller;
                    frmCaller.TxtBarcode.Text = idbarangpilih;
                    frmCaller.AmbilBarang2();
                }
                else
                {
                    DO.FrmDO frmCaller = (DO.FrmDO)this.Caller;
                    frmCaller.TxtBarcode.Text = idbarangpilih;
                    frmCaller.AmbilBarang2(stok);
                }
                //}
          
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCari.Text == "" || txtCari.Text.Contains("Nama Stok, Barcode, ID Barang"))
            {
                txtCari.Text = "";
                button1.Enabled = false;
                TampilData(_kelompok);
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                CariData(_kelompok);
                button1.Enabled = true;
            }
        }

        private void txtCari_Click(object sender, EventArgs e)
        {
            txtCari.Text = "";
            txtCari.ForeColor = Color.Black;
        }

        private void txtCari_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(sender, e);
            }
        }

        private void CBStok_CheckedChanged(object sender, EventArgs e)
        {
            if (CBStok.Checked == true)
            {

                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH2_perKode"));
                    db.Commands[0].Parameters.Add(new Parameter("@katakunci", SqlDbType.VarChar, txtCari.Text.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, _kelompok.ToString()));
                    //db.Commands[0].Parameters.Add(new Parameter("@TransactionTypeRowID", SqlDbType.UniqueIdentifier, JenisTransact));
                    CGBarang.DataSource = dt;
                    if (dt.Rows.Count > 0)
                    {
                        CGBarang.Focus();
                    }
                }

            }
            else
            {
                TampilData(_kelompok);
            }
        }

        private void CGBarang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && CGBarang.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        public void keluarHarga()
        {
            string barangid = CGBarang.SelectedCells[0].OwningRow.Cells["IdBarang"].Value.ToString();
            if (this.Caller is FrmDO)
            {
                DO.FrmDO frmCaller = (DO.FrmDO)this.Caller;
                frmCaller.CekHargaBMK(barangid);
                lblNamaBarang.Text = CGBarang.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
                lblHarga.Text = frmCaller.lblBMK.Text.ToString();
                //LblNota.Text = frmCaller.LblNoNota.Text.ToString();
            }

        }

        private void CGBarang_SelectionChanged(object sender, EventArgs e)
        {
            if (CGBarang.SelectedCells.Count > 0)
            {
                keluarHarga();
            }
            else
            {
                return;
            }

        }

        private void FrmBarcodeDO_Activated(object sender, EventArgs e)
        {
            txtCari.Focus();
        }

        private void CGBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
            


     
    }
}
