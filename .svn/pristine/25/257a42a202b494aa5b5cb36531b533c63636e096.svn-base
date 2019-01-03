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

namespace ISA.Trading.DO
{
    public partial class FrmBarcodeDO :ISA.Trading.BaseForm
    {
        string idbarangpilih;
        string KreditGenuine="";

        //untuk ambil barang sesuai jenis transaksi
        string _kelompok;
        //end
        string initCab = GlobalVar.CabangID;
        string initgudang = GlobalVar.Gudang;

        double _Het, _hrgB, _hrgM, _hrgK, _hrgHPP;
        
        public FrmBarcodeDO(Form caller, string jenistransaksi, string flagkg )
        {
            InitializeComponent();
            this.Caller = caller;
            this._kelompok = jenistransaksi.ToString().Substring(0, 2);
            if (flagkg != "")
            {
                KreditGenuine = flagkg.ToString();
            }
        }

        private void FrmBarcode_Load(object sender, EventArgs e)
        {
            txtCari.Focus();
            button1.Select();
            lblNamaBarang.Visible = false;
            lblHarga.Visible = false;

        }

        public void CariData(string kelompok)
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                if (GlobalVar.Gudang != "2808")
                    db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH2_perKode"));
                else
                    db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH2_perKode2808"));

                db.Commands[0].Parameters.Add(new Parameter("@katakunci", SqlDbType.VarChar, txtCari.Text.ToString()));
                db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, kelompok.ToString()));
                db.Commands[0].Parameters.Add(new Parameter("@flagkg", SqlDbType.VarChar, Tools.isNull(KreditGenuine,"")));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0)
                {
                    CGBarang.DataSource = dt;
                    CGBarang.Focus();
                }
            }
        }

        public void TampilData(string kelompok)
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_LIST_perKode"));
                db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, kelompok.ToString()));
                db.Commands[0].Parameters.Add(new Parameter("@flagkg", SqlDbType.VarChar, KreditGenuine));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0)
                {
                    CGBarang.DataSource = dt;
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
            int stokbrg = Convert.ToInt32(CGBarang.SelectedCells[0].OwningRow.Cells["StokBarang"].Value);

            //if (stokbrg <= 0)
            //{
            //    return;
            //}
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
                else if (this.Caller is DO.FrmDO2828)
                {
                    DO.FrmDO2828 frmCaller = (DO.FrmDO2828)this.Caller;
                    frmCaller.TxtBarcode.Text = idbarangpilih;
                    frmCaller.AmbilBarang2();
                }
                else
                {
                    DO.FrmDO frmCaller = (DO.FrmDO)this.Caller;
                    frmCaller.TxtBarcode.Text = idbarangpilih;
                    frmCaller.AmbilBarang2();
                }

                //}
          
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCari.Text == "" || txtCari.Text == "Nama Stok, Barcode, ID Barang")
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

                    db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_LIST_MASIH_perKode"));
                    db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, _kelompok.ToString()));
                    dt = db.Commands[0].ExecuteDataTable();
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
            string barangid = Tools.isNull(CGBarang.SelectedCells[0].OwningRow.Cells["IdBarang"].Value,"").ToString();
            //string nmbarang = CGBarang.SelectedCells[0].OwningRow.Cells["IdBarang"].Value.ToString();
            if (this.Caller is FrmDO)
            {
                DO.FrmDO frmCaller = (DO.FrmDO)this.Caller;
                frmCaller.CekHargaBMK(barangid);
                //lblNamaBarang.Text = CGBarang.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
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

        private void CGBarang_SelectionRowChanged(object sender, EventArgs e)
        {
            string kodebarang = Tools.isNull(CGBarang.SelectedCells[0].OwningRow.Cells["IdBarang"].Value, string.Empty).ToString();
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
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, initCab));
                    dtGetHrgBMK = db.Commands[0].ExecuteDataTable();
                }
                if (dtGetHrgBMK.Rows.Count > 0)
                {
                    _Het = Convert.ToDouble(dtGetHrgBMK.Rows[0]["Hrgnet"]);
                    _hrgB = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgB"]);
                    _hrgM = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgM"]);
                    _hrgK = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgK"]);
                    //_hrgAkhir = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgTerakhir"]);
                    //_hrgNet = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgNet"]);
                }
                else
                {
                    _Het = 0;
                    _hrgB = 0;
                    _hrgM = 0;
                    _hrgK = 0;
                    //_hrgAkhir = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgTerakhir"]);
                    //_hrgNet = Convert.ToDouble(dtGetHrgBMK.Rows[0]["HrgNet"]);
                }

                nHet.Text = _Het.ToString();
                ncash.Text = _hrgB.ToString();
                ntop10.Text = _hrgM.ToString();
                nuser.Text = _hrgK.ToString();


                //if (_hrgAkhir > 0)
                //{
                //    if (dtGetHrgBMK.Rows.Count > 0)
                //    {
                //        _tglAkhir = (DateTime)dtGetHrgBMK.Rows[0]["TglTerakhir"];
                //    }
                //    else
                //    {
                //        _tglAkhir = new DateTime(1900, 1, 1);
                //    }

                //}

                //if (_hrgB > 0 && _hrgM > 0 && _hrgK > 0)
                //{
                //lblBMK.Text = "C: " + _hrgB.ToString("N0") + "  T: " + _hrgM.ToString("N0") + "  E: " + _hrgK.ToString("N0") + "  Harga Akhir: " + _hrgAkhir.ToString("N0") + "  Harga Net: " + _hrgNet.ToString("N0");
                //}
                //else
                //{
                //    lblBMK.Text = "Belum ada harga CTE";
                //}
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void GetHargaHpp(string barangID)
        {
            _hrgHPP = 0;
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
                    _hrgHPP = Convert.ToDouble(Tools.isNull(dtGetHargaHPP.Rows[0]["HPP"],"0").ToString());
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
