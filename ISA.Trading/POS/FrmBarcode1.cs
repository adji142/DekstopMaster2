using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ISA.Trading;
using ISA.Controls;
using ISA.DAL;
using ISA.Trading.Controls;


namespace ISA.Trading.POS
{
    public partial class FrmBarcode1 :ISA.Trading.BaseForm
    {
        string idbarangpilih;
        //double _hargaFinal;
        public FrmBarcode1(Form caller )
        {
            InitializeComponent();
            this.Caller = caller;
           
        }


        public void CariData()
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH"));
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

                db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_LIST"));
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
            //if (customGridView1.SelectedCells.Count == 1)
            //{
                ConfirmSelect();
            //}
        }
        public void ConfirmSelect()
        {
            int stokbrg = Convert.ToInt32(customGridView1.SelectedCells[0].OwningRow.Cells["StokAkhir"].Value);

            if (stokbrg <= 0)
            {
                return;
            }
            
            idbarangpilih = customGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
            if (this.Caller is POS.FrmPOS)
            {
              POS.FrmPOS frmCaller = (POS.FrmPOS) this.Caller;
              frmCaller.TxtBarcode.Text = idbarangpilih;   
              frmCaller.TxtBarcode.Focus();
              frmCaller.AmbilBarang2();
            }
            else if (this.Caller is POS.FrmPOS0401)
            {
                POS.FrmPOS0401 frmCaller = (POS.FrmPOS0401)this.Caller;
                frmCaller.TxtBarcode.Text = idbarangpilih;
                frmCaller.TxtBarcode.Focus();
                frmCaller.AmbilBarang2();
            }
            else if (this.Caller is POS.FrmPOSbengkel)
            {
                POS.FrmPOSbengkel frmCaller = (POS.FrmPOSbengkel)this.Caller;
                frmCaller.TxtBarcode.Text = idbarangpilih;
                frmCaller.TxtBarcode.Focus();
                frmCaller.AmbilBarang2();
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
    
       private void FrmBarcode1_Load(object sender, EventArgs e)
       {
           button1.Select();
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

                                db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_LIST_MASIH"));
                                dt = db.Commands[0].ExecuteDataTable();
                                customGridView1.DataSource = dt;
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

       private void FrmBarcode1_Load_1(object sender, EventArgs e)
       {
           txtCari.Focus();
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

     
     
    }
}
