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
    public partial class FrmBarcode :ISA.Trading.BaseForm
    {
        string idbarangpilih;
        string initCab = GlobalVar.CabangID;
        string klpbrg = "";
        //double _hargaFinal;
        double _Het, _hrgB = 0, _hrgM = 0, _hrgK = 0, _hrgAkhir = 0, _hrgNet = 0, _hrgHPP = 0;

        public FrmBarcode(Form caller )
        {
            InitializeComponent();
            this.Caller = caller;
        }

        public FrmBarcode(Form caller, string Jnstr)
        {
            InitializeComponent();
            this.Caller = caller;
            if (Jnstr == "TB")
            {
                klpbrg = "FAB";
            }
        }

        public void CariData()
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH"));
                db.Commands[0].Parameters.Add(new Parameter("@katakunci", SqlDbType.VarChar, txtCari.Text.ToString()));
                if (Tools.isNull(klpbrg, "").ToString() == "FAB")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, klpbrg));
                }
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
            if (GlobalVar.Gudang != "2808")
            {
                int stokbrg = Convert.ToInt32(customGridView1.SelectedCells[0].OwningRow.Cells["StokAkhir"].Value);

                if (stokbrg <= 0)
                {

                    DataTable dtAppSet;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "POS"));
                        dtAppSet = db.Commands[0].ExecuteDataTable();
                    }

                    if (GlobalVar.Gudang.Substring(0, 2) == "28")
                    {
                        if (dtAppSet.Rows.Count > 0)
                        {
                            if (dtAppSet.Rows[0]["Value"].ToString() == "1")
                            {
                                MessageBox.Show("Stok minus, sebaiknya dilakukan sampling opname stok");
                            }
                            //else
                            //{
                            //    MessageBox.Show("Stok minus, tidak dapat melanjutkan Penjualan Tunai, hubungi supervisor");
                            //    return;
                            //}
                        }

                        //else
                        //{
                        //    MessageBox.Show("Stok minus, tidak dapat melanjutkan Penjualan Tunai, hubungi supervisor");
                        //    return;

                        //}
                    }

                }
            }
            
            idbarangpilih = customGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
            if (this.Caller is POS.FrmPOS)
            {
              POS.FrmPOS frmCaller = (POS.FrmPOS) this.Caller;
              frmCaller.TxtBarcode.Text = idbarangpilih;   
              //frmCaller.TxtBarcode.Focus();
              frmCaller.AmbilBarang2();
            }
            else if (this.Caller is POS.FrmPOS0401)
            {
                POS.FrmPOS0401 frmCaller = (POS.FrmPOS0401)this.Caller;
                frmCaller.TxtBarcode.Text = idbarangpilih;
                //frmCaller.TxtBarcode.Focus();
                frmCaller.AmbilBarang2();
            }
            else if (this.Caller is POS.FrmPOSbengkel)
            {
                POS.FrmPOSbengkel frmCaller = (POS.FrmPOSbengkel)this.Caller;
                frmCaller.TxtBarcode.Text = idbarangpilih;
                //frmCaller.TxtBarcode.Focus();
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
    
       
        private void FrmBarcode_Load(object sender, EventArgs e)
       {
           txtCari.SelectAll();
           txtCari.Focus();
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
           else if (this.Caller is FrmPOSbengkel)
           {
               POS.FrmPOSbengkel frmCaller = (POS.FrmPOSbengkel)this.Caller;
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

       private void customGridView1_SelectionRowChanged(object sender, EventArgs e)
       {
           string kodebarang = Tools.isNull(customGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value, string.Empty).ToString();
           if (kodebarang != string.Empty)
           {
               CekHargaBMK(kodebarang);
               GetHargaHpp(kodebarang);

               //"C: " + _hrgB.ToString("N0") + "  T: " + _hrgM.ToString("N0") + "  E: " + _hrgK.ToString("N0") + "  Harga Akhir: " + _hrgAkhir.ToString("N0") + "  Harga Net: " + _hrgNet.ToString("N0");
               //nRowGridView = DataGridDO.CurrentRow.Index;
           }
       }

       public void CekHargaBMK(string _barangid)
       {
           try
           {
               DataTable dtGetHrgBMK = new DataTable();
               using (Database db = new Database())
               {
                   db.Commands.Add(db.CreateCommand("[usp_GetHargaJual]"));
                   db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, DateTime.Now));
                   db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangid));
                   db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, "28"));
                   dtGetHrgBMK = db.Commands[0].ExecuteDataTable();
               }
               if (dtGetHrgBMK.Rows.Count > 0)
               {
                   _Het = Convert.ToDouble(dtGetHrgBMK.Rows[0]["Hrgnet"]);
                   _hrgB = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgB"]);
                   _hrgM = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgM"]);
                   _hrgK = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgK"]);
               }
               else
               {
                   _Het = 0;
                   _hrgB = 0;
                   _hrgM = 0;
                   _hrgK = 0;
               }

               nHet.Text = _Het.ToString();
               ncash.Text = _hrgB.ToString();
               ntop10.Text = _hrgM.ToString();
               nuser.Text = _hrgK.ToString();
           }
           catch (Exception ex)
           {
               Error.LogError(ex);
           }
       }

       public void GetHargaHpp(string barangID)
       {
           try
           {
               DataTable dtGetHargaHPP = new DataTable();
               using (Database db = new Database())
               {
                   db.Commands.Add(db.CreateCommand("usp_cekHargaHPP"));
                   db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                   dtGetHargaHPP = db.Commands[0].ExecuteDataTable();
               }

               if (dtGetHargaHPP.Rows.Count > 0)
               {
                   _hrgHPP = Convert.ToDouble(dtGetHargaHPP.Rows[0]["HPP"]);
               }
               else
               {
                   if (barangID == "FXBBISKUITKL" || barangID == "FXBSOFTDRINK" || barangID == "FXBKURSIBKSO" || barangID == "FXBTSHIRTOBL")
                   {
                       _hrgHPP = 0;
                   }
                   else
                   {
                       //MessageBox.Show("Barang Belum punya history harga hpp, segera hubungi HO");
                   }
               }
           }
           catch (Exception ex)
           {
               Error.LogError(ex);
           }
           nhpp.Text = _hrgHPP.ToString();
       }

       private void label7_Click(object sender, EventArgs e)
       {

       }
    
    
    }
}
