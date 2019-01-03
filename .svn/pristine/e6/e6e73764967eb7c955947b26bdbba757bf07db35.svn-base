using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;
using ISA.Trading.Class;
using System.Globalization;


namespace ISA.Trading.POS
{
    public partial class FrmTabelPOS : ISA.Trading.BaseForm
    {
        #region variabel

        int prevGrid1Row = -1;
        enum enumSelectedGrid { DOSelected, DetailDOSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.DOSelected;
        DataTable dtDO, dtDetailDO;
        bool _acak;
        int _nCetak;
        DateTime _fromDate, _toDate;
        double JmlHrgTot = 0.00, HrgNetTot = 0.00, JmlHPPTot = 0.00, JmlPotTot = 0.00;
        string StatausToko_ = string.Empty;
         //DateTime _fromDate, _toDate;
        //DataTable dtDO;

        #endregion


        public FrmTabelPOS()
        {
            InitializeComponent();
        }

        private void FrmTabelPOS_Load(object sender, EventArgs e)
        {
            DGVHeaderPenjualan.AutoGenerateColumns = false;

            rangeDateBox1.FromDate = DateTime.Now; 
            rangeDateBox1.ToDate  = DateTime.Now;
            CultureInfo culture;
            culture = new CultureInfo("id-ID");
            string tgl =  System.DateTime.Today.ToString("dddd, dd MMMM yyyy", culture);
            label1.Text = Convert.ToString(tgl);

            DateTime waktu = DateTime.Now;
            timer1.Enabled = true;

            CmdAdd.GenerateRowNumber = true;
            DGVHeaderPenjualan.GenerateRowNumber = true;

            commandButton1.Enabled = false;
            cmdDel.Enabled = false;
            CmdEdit.Enabled = false;
        }

        #region dataheader
        public void RefreshDataDO()
        {
          

            _fromDate = Convert.ToDateTime(rangeDateBox1.FromDate.Value);
            _toDate = Convert.ToDateTime(rangeDateBox1.ToDate.Value);

         

            try
            {
                this.Cursor = Cursors.WaitCursor;
               dtDO = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST_FILTER_TglDO3"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    dtDO = db.Commands[0].ExecuteDataTable();
                }
                // -----------tampil data ke detail

                          

                dtDO.DefaultView.Sort = "TglDO, NoDOAndFlag";
                DGVHeaderPenjualan.DataSource = dtDO.DefaultView;
               
                
                if (DGVHeaderPenjualan.SelectedCells.Count > 0)
                {
                RefreshDataDetailDO();
                 lblHeader.Text = "\"" + DGVHeaderPenjualan.SelectedCells[0].OwningRow.Cells["HeadTokoCust"].Value.ToString() + "\" "
                     + DGVHeaderPenjualan.SelectedCells[0].OwningRow.Cells["HeadAlamatKirim"].Value.ToString();
                DGVHeaderPenjualan.Focus();
                }
                else
                {
                CmdAdd.DataSource = null;
                 lblHeader.Text = " ";
                txtJumlahHarga2.Text = "";
                txtJumlahPotongan2.Text = "";
                txtHargaNett2.Text = "";
                txtJumlahHPP2.Text = "";
                }

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
        

        #endregion


        #region datadetail
        public void RefreshDataDetailDO()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    dtDetailDO = new DataTable();
                    Guid _headerID = (Guid)DGVHeaderPenjualan.SelectedCells[0].OwningRow.Cells["HeadRowID"].Value;
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST_FILTER_HEADERID"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtDetailDO = db.Commands[0].ExecuteDataTable();
                }
                dtDetailDO.DefaultView.Sort = "RecordID";
                CmdAdd.DataSource = dtDetailDO;

                if (CmdAdd.SelectedCells.Count > 0)
                {
                    lblDetail.Text = CmdAdd.SelectedCells[0].OwningRow.Cells["DetNamaStok"].Value.ToString();

                    // Selalu update RpJual dan RpNet di Header, untuk antisipasi perubahan pada detail
                    // Contoh: setelah batal do detail QtyDO berubah maka RpJual dan RpNet di Header juga berubah
                    DGVHeaderPenjualan.SelectedCells[0].OwningRow.Cells["HeadRpJual"].Value = dtDetailDO.Compute("SUM(JmlHrg)", string.Empty);
                    DGVHeaderPenjualan.SelectedCells[0].OwningRow.Cells["HeadRpNet"].Value = dtDetailDO.Compute("SUM(HrgNet)", string.Empty);
                }
                else
                {
                    lblDetail.Text = " ";

                    DGVHeaderPenjualan.SelectedCells[0].OwningRow.Cells["HeadRpJual"].Value = 0;
                    DGVHeaderPenjualan.SelectedCells[0].OwningRow.Cells["HeadRpNet"].Value = 0;
                }
                AcakTampilTextBox();
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


        #endregion

        private void AcakTampilTextBox()
        {
            if (dtDetailDO != null)
            {
                if (dtDetailDO.Compute("SUM(JmlHrg)", string.Empty).ToString().Equals(string.Empty))
                {
                    JmlHrgTot = 0;
                }
                else
                {
                    JmlHrgTot = double.Parse(dtDetailDO.Compute("SUM(JmlHrg)", string.Empty).ToString());
                }
                if (dtDetailDO.Compute("SUM(JmlPot)", string.Empty).ToString().Equals(string.Empty))
                {
                    JmlPotTot = 0;
                }
                else
                {
                    JmlPotTot = double.Parse(dtDetailDO.Compute("SUM(JmlPot)", string.Empty).ToString());
                }
                if (dtDetailDO.Compute("SUM(HrgNet)", string.Empty).ToString().Equals(string.Empty))
                {
                    HrgNetTot = 0;
                }
                else
                {
                    HrgNetTot = double.Parse(dtDetailDO.Compute("SUM(HrgNet)", string.Empty).ToString());
                }
                if (dtDetailDO.Compute("SUM(JmlHPP)", string.Empty).ToString().Equals(string.Empty))
                {
                    JmlHPPTot = 0;
                }
                else
                {
                    JmlHPPTot = double.Parse(dtDetailDO.Compute("SUM(JmlHPP)", string.Empty).ToString());
                }
            }
            if (_acak)
            {
                txtJumlahHarga2.Text = Tools.GetAntiNumeric(JmlHrgTot.ToString("#,##0"));
                txtJumlahPotongan2.Text = Tools.GetAntiNumeric(JmlPotTot.ToString("#,##0"));
                txtHargaNett2.Text = Tools.GetAntiNumeric(HrgNetTot.ToString("#,##0"));
                txtJumlahHPP2.Text = Tools.GetAntiNumeric(JmlHPPTot.ToString("#,##0"));
            }
            else
            {
                txtJumlahHarga2.Text = JmlHrgTot.ToString("#,##0");
                txtJumlahPotongan2.Text = JmlPotTot.ToString("#,##0");
                txtHargaNett2.Text = HrgNetTot.ToString("#,##0");
                txtJumlahHPP2.Text = JmlHPPTot.ToString("#,##0");
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataDO();
            DGVHeaderPenjualan.Focus();
            selectedGrid = enumSelectedGrid.DOSelected;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime waktu = DateTime.Now;
            string wkt = waktu.ToString("HH:mm:ss");
            label8.Text = wkt;

        }

        private void DGVHeaderPenjualan_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void DGVHeaderPenjualan_SelectionRowChanged(object sender, EventArgs e)
        {

            if (DGVHeaderPenjualan.SelectedCells.Count > 0)
            {
                RefreshDataDetailDO();

                lblHeader.Text = "\"" + DGVHeaderPenjualan.SelectedCells[0].OwningRow.Cells["HeadTokoCust"].Value.ToString() + "\" "
                    + DGVHeaderPenjualan.SelectedCells[0].OwningRow.Cells["HeadAlamatkirim"].Value.ToString();
            }
            else
            {
                lblHeader.Text = " ";
            }
        }

        private void DGVHeaderPenjualan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGVDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TglAkhir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void DGVDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        //    double _hrgJual = 0;
        //    double _hrgBMK = 0;
        //    double _hppSolo = 0;

        //    if(DGVDetail.Rows[e.RowIndex].Cells["DetHrgJual"].Value.ToString() != "")
        //        _hrgJual = double.Parse(DGVDetail.Rows[e.RowIndex].Cells["DetHrgJual"].Value.ToString());
        //    if(DGVDetail.Rows[e.RowIndex].Cells["DetHrgBMK"].Value.ToString() != "")            
        //        _hrgBMK = double.Parse(DGVDetail.Rows[e.RowIndex].Cells["DetHrgBMK"].Value.ToString());
        //    if(DGVDetail.Rows[e.RowIndex].Cells["DetHPPSolo"].Value.ToString() != "")           
        //        _hppSolo = double.Parse(DGVDetail.Rows[e.RowIndex].Cells["DetHPPSolo"].Value.ToString());

        //    // If HrgJual < HrgBMK
        //    if (_hrgJual < _hrgBMK && _hrgBMK != 0)
        //    {
        //        DGVDetail.Rows[e.RowIndex].Cells["DetHrgBMK"].Style.ForeColor = Color.Red;
        //        DGVDetail.Rows[e.RowIndex].Cells["DetHrgBMK"].Style.SelectionForeColor = Color.Red;
        //    }

        //    // If HrgJual < HPPSolo
        //    if (_hrgJual < _hppSolo && _hppSolo != 0)
        //    {
        //        //DGVDetail.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
        //        DGVDetail.Rows[e.RowIndex].Cells["DetHPPSolo"].Style.ForeColor = Color.Red;
        //        DGVDetail.Rows[e.RowIndex].Cells["DetHPPSolo"].Style.SelectionForeColor = Color.Red;
        //    }
            

        //    // If HrgJual < HPPSolo AND HrgJual > HrgBMK
        //    if ((_hrgJual < _hppSolo) && (_hrgJual > _hrgBMK) && (_hppSolo != 0) && (_hrgBMK != 0))
        //    {
        //        DGVDetail.Rows[e.RowIndex].Cells["DetHrgJual"].Style.ForeColor = Color.Red;
        //        DGVDetail.Rows[e.RowIndex].Cells["DetHrgJual"].Style.SelectionForeColor = Color.Red;
        //    }
            

        //    // If NoACC = 'BATAL00' AND QtyDO = 0 -- DO Detail Batal
        //    /*Edited
        //    if (DGVDetail.Rows[e.RowIndex].Cells["DetailNoACC"].Value.ToString().Trim() == "BATAL00"
        //            &&
        //        (int)DGVDetail.Rows[e.RowIndex].Cells["QtyDO"].Value == 0)
        //    {
        //        DGVDetail.Rows[e.RowIndex].Cells["NamaStok"].Style.ForeColor = Color.Orange;
        //        DGVDetail.Rows[e.RowIndex].Cells["NamaStok"].Style.SelectionForeColor = Color.Orange;
        //    }*/
            

        //    // If NoACC = "" AND QtyDO = 0 -- Harga Ditolak
        //    /*Edit
        //    if (DGVDetail.Rows[e.RowIndex].Cells["DetailNoACC"].Value.ToString().Trim() == ""
        //            &&
        //        (int)DGVDetail.Rows[e.RowIndex].Cells["QtyDO"].Value == 0)
        //    {
        //        DGVDetail.Rows[e.RowIndex].Cells["NamaStok"].Style.ForeColor = Color.Purple;
        //        DGVDetail.Rows[e.RowIndex].Cells["NamaStok"].Style.SelectionForeColor = Color.Purple;
        //    }
        //    else
        //    {
        //        DGVDetail.Rows[e.RowIndex].Cells["NamaStok"].Style.ForeColor = Color.Black;
        //        DGVDetail.Rows[e.RowIndex].Cells["NamaStok"].Style.SelectionForeColor = Color.White;
        //    }
        //    */

        //    if ((int)DGVDetail.Rows[e.RowIndex].Cells["DetQtyDO"].Value == 0)
        //    {
        //        if (DGVDetail.Rows[e.RowIndex].Cells["DetailNoACC"].Value.ToString().Trim() == "BATAL00")
        //        {
        //            DGVDetail.Rows[e.RowIndex].Cells["DetNamaStok"].Style.ForeColor = Color.Orange;
        //            DGVDetail.Rows[e.RowIndex].Cells["DetNamaStok"].Style.SelectionForeColor = Color.Orange;
        //        }
        //        else if (DGVDetail.Rows[e.RowIndex].Cells["DetailNoACC"].Value.ToString().Trim() == "")
        //        {
        //            DGVDetail.Rows[e.RowIndex].Cells["DetNamaStok"].Style.ForeColor = Color.Purple;
        //            DGVDetail.Rows[e.RowIndex].Cells["DetNamaStok"].Style.SelectionForeColor = Color.Purple;
        //        }
        //        else
        //        {
        //            DGVDetail.Rows[e.RowIndex].Cells["DetNamaStok"].Style.ForeColor = Color.Black;
        //            DGVDetail.Rows[e.RowIndex].Cells["DetNamaStok"].Style.SelectionForeColor = Color.White;
        //        }

        //    } 
        //    else
        //    {
        //        DGVDetail.Rows[e.RowIndex].Cells["DetNamaStok"].Style.ForeColor = Color.Black;
        //        DGVDetail.Rows[e.RowIndex].Cells["DetNamaStok"].Style.SelectionForeColor = Color.White;
        //    }

        //    double HrgBMK = double.Parse(Tools.isNull(DGVDetail.Rows[e.RowIndex].Cells["DetHrgBMK"].Value, 0).ToString());
        //    double HrgJual = double.Parse(Tools.isNull(DGVDetail.Rows[e.RowIndex].Cells["DetHrgJual"].Value, 0).ToString());
        //    double JmlHarga = double.Parse(Tools.isNull(DGVDetail.Rows[e.RowIndex].Cells["DetJmlHarga"].Value, 0).ToString());
        //    double Pot = double.Parse(Tools.isNull(DGVDetail.Rows[e.RowIndex].Cells["DetPot"].Value, 0).ToString());
        //    double JmlPot = double.Parse(Tools.isNull(DGVDetail.Rows[e.RowIndex].Cells["DetJmlPot"].Value, 0).ToString());
        //    double HrgNet = double.Parse(Tools.isNull(DGVDetail.Rows[e.RowIndex].Cells["DetHrgNet"].Value, 0).ToString());
        //    double HPPSolo = double.Parse(Tools.isNull(DGVDetail.Rows[e.RowIndex].Cells["DetHPPSolo"].Value, 0).ToString());
        //    double JmlHPP = double.Parse(Tools.isNull(DGVDetail.Rows[e.RowIndex].Cells["DetJmlHPP"].Value, 0).ToString());

        //    DGVDetail.Rows[e.RowIndex].Cells["HrgBMKAck"].Value = Tools.GetAntiNumeric(HrgBMK.ToString("#,##0"));
        //    DGVDetail.Rows[e.RowIndex].Cells["HrgJualAck"].Value = Tools.GetAntiNumeric(HrgJual.ToString("#,##0"));
        //    DGVDetail.Rows[e.RowIndex].Cells["JmlHrgAck"].Value = Tools.GetAntiNumeric(JmlHarga.ToString("#,##0"));
        //    DGVDetail.Rows[e.RowIndex].Cells["PotAck"].Value = Tools.GetAntiNumeric(Pot.ToString("#,##0"));
        //    DGVDetail.Rows[e.RowIndex].Cells["JmlPotAck"].Value = Tools.GetAntiNumeric(JmlPot.ToString("#,##0"));
        //    DGVDetail.Rows[e.RowIndex].Cells["HrgNetAck"].Value = Tools.GetAntiNumeric(HrgNet.ToString("#,##0"));
        //    DGVDetail.Rows[e.RowIndex].Cells["HPPSoloAck"].Value = Tools.GetAntiNumeric(HPPSolo.ToString("#,##0"));
        //    DGVDetail.Rows[e.RowIndex].Cells["JmlHPPAck"].Value = Tools.GetAntiNumeric(JmlHPP.ToString("#,##0"));

        //    DGVDetail.Rows[e.RowIndex].Cells["HrgBMKAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    DGVDetail.Rows[e.RowIndex].Cells["HrgJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    DGVDetail.Rows[e.RowIndex].Cells["JmlHrgAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    DGVDetail.Rows[e.RowIndex].Cells["PotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    DGVDetail.Rows[e.RowIndex].Cells["JmlPotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    DGVDetail.Rows[e.RowIndex].Cells["HrgNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    DGVDetail.Rows[e.RowIndex].Cells["HPPSoloAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    DGVDetail.Rows[e.RowIndex].Cells["JmlHPPAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void DGVDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailDOSelected;
        }

        private void DGVDetail_SelectionRowChanged(object sender, EventArgs e)
        {
            if (CmdAdd.SelectedCells.Count > 0)
            {
                lblDetail.Text = CmdAdd.SelectedCells[0].OwningRow.Cells["DetNamaStok"].Value.ToString();
            }
            else
            {
                lblDetail.Text = " ";
            }
        }

       
        private void CmdKeluar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void rangeDateBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }



    }
}
