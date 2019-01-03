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


namespace ISA.Toko.POS
{
    public partial class FrmBarcode :ISA.Toko.BaseForm
    {
        string idbarangpilih, _kelompok;
        //double _hargaFinal;
        double _hrgB = 0, _hrgM = 0, _hrgK = 0, _hrgAkhir = 0, _hrgNet = 0;
        DataTable temporari = new DataTable();
        public FrmBarcode(Form caller, string kelompok )
        {
            _kelompok = kelompok;
            InitializeComponent();
            this.Caller = caller;
           
        }

        public FrmBarcode(Form caller, DataTable dt, String Keyword)
        {
            InitializeComponent();
            this.Caller = caller;
            txtCari.Text = Keyword;
            temporari = dt;
        }


        public void CariData()
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH2_perKode_pos"));
                db.Commands[0].Parameters.Add(new Parameter("@katakunci", SqlDbType.VarChar, txtCari.Text.ToString()));
                dt = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    
                    customGridView1.Focus();
                }
            }
        }
       
        public void TampilData()
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("[usp_STOK_STOKBARCODE_SEARCH2_perKode_pos]"));
                db.Commands[0].Parameters.Add(new Parameter("@katakunci", SqlDbType.VarChar, txtCari.Text.ToString()));
                dt = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    customGridView1.Focus();                
                }
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }
        public void ConfirmSelect()
        {
            String BarangID = customGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();

            if (BarangID.Length == 13)
            {
                //if ((Convert.ToInt32(customGridView1.SelectedCells[0].OwningRow.Cells["StokAkhir"].Value) <=0 ))
                //{
                //    return;
                //}
                int stokbrg = Convert.ToInt32(customGridView1.SelectedCells[0].OwningRow.Cells["StokAkhir"].Value);

                if (stokbrg > 0)
                {

                    DataTable dtAppSet;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "POS"));
                        dtAppSet = db.Commands[0].ExecuteDataTable();
                    }

                    if (dtAppSet.Rows.Count > 0)
                    {
                        if (dtAppSet.Rows[0]["Value"].ToString() == "1")
                        {
                            MessageBox.Show("Stok minus, sebaiknya dilakukan sampling opname stok");
                        }
                        else
                        {
                            MessageBox.Show("Nilai stok barang <= 0. Tidak bisa bertransaksi. Hubungi Manager Anda.");
                            return;
                        }
                    }

                    
                    idbarangpilih = customGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
                    //if (this.Caller is POS.FrmPOS)
                    //{
                    POS.FrmPOS frmCaller = (POS.FrmPOS)this.Caller;
                    frmCaller.TxtBarcode.Text = idbarangpilih;
                    frmCaller.TxtBarcode.Focus();
                    frmCaller.AmbilBarang2(stokbrg);
                }
                else
                {
                    MessageBox.Show("Nilai stok barang <= 0. Tidak bisa bertransaksi. Hubungi Manager Anda.");
                    return;
                }
            }
            else
            {
                idbarangpilih = customGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
                //if (this.Caller is POS.FrmPOS)
                //{
                POS.FrmPOS frmCaller = (POS.FrmPOS)this.Caller;
                frmCaller.TxtBarcode.Text = idbarangpilih;
                frmCaller.TxtBarcode.Focus();
                frmCaller.AmbilBarangJasa();
                //}

            }
            this.Close();
        }

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtCari.Text == "" || txtCari.Text=="Nama Stok, Barcode, ID Barang")
            {
                txtCari.Text = "";
                button1.Enabled = false;               
                TampilData();
                button1.Enabled = true;
              
            }
            else
            {
                button1.Enabled = false;            
                CariData();
                button1.Enabled = true;
            }
            

        }  
    
       private void FrmBarcode_Load(object sender, EventArgs e)
       {
           txtCari.SelectAll();
           txtCari.Focus();
           customGridView1.DataSource = temporari;
           //button1.Select();
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
                                dt = db.Commands[0].ExecuteDataTable();
                                if (dt.Rows.Count > 0)
                                {
                                    customGridView1.Focus();                
                                }
                            }
            
           }
           else
           {
               TampilData();
           }
       }


       private void customGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
       {
           //string barangid = customGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
           //if (this.Caller is FrmPOS)
           //{
           //    POS.FrmPOS frmCaller = (POS.FrmPOS)this.Caller;
           //    frmCaller.CekHargaBMK(barangid);
           //    lblKet.Text = customGridView1.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
           //    lblBMK.Text = frmCaller.lblBMK.Text.ToString();
           //    //LblNota.Text = frmCaller.LblNoNota.Text.ToString();
           //}

       }

       public void keluarHarga()
       {
           string barangid = customGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
           if (this.Caller is FrmPOS)
           {
               POS.FrmPOS frmCaller = (POS.FrmPOS)this.Caller;
               frmCaller.CekHargaBMK(barangid);
               lblKet.Text = customGridView1.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
               lblBMK.Text = frmCaller.lblBMK.Text.ToString();
               //LblNota.Text = frmCaller.LblNoNota.Text.ToString();
           }

       }

       private void customGridView1_SelectionChanged(object sender, EventArgs e)
       {
           if (customGridView1.SelectedCells.Count > 0)
           {
               keluarHarga();
           }
           else
           {
               return;
           }
       }

       private void FrmBarcode_Activated(object sender, EventArgs e)
       {
           //txtCari.SelectAll();
           //txtCari.Focus();
       }
        
     
     
     
    }
}
