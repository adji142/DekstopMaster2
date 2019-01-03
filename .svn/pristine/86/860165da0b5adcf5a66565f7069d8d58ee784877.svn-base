using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using ISA.Toko.Class;

namespace ISA.Toko.Bonus
{
    public partial class frmPerolehanBonusBrowser : ISA.Toko.BaseForm
    {
        public frmPerolehanBonusBrowser()
        {
            InitializeComponent();
        }

        private void frmPerolehanBonusBrowser_Load(object sender, EventArgs e)
        {
            this.Title = "Tabel Perolehan Bonus";
            this.Text = "Bonus";
            dataGridSales.AutoGenerateColumns = false;
            dataGridPerolehanBns.AutoGenerateColumns = false;
            RefreshDataSales();
        }

        private void RefreshDataSales()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Sales_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dataGridSales.DataSource = dt;
                if (dataGridSales.SelectedCells.Count > 0)
                {
                    RefreshDataPerolehanBonus();
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

        private void RefreshDataPerolehanBonus()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string kodeSales = dataGridSales.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PerolehanBonusSales_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, kodeSales));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dataGridPerolehanBns.DataSource = dt;

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

        private void dataGridPerolehanBns_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    /* Cetak slip bonus */
                    CetakSlipBonus();
                    break;
            }
        }

        private void CetakSlipBonus()
        {
            if (dataGridSales.SelectedCells.Count == 0 || dataGridPerolehanBns.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }

            if ((int)dataGridPerolehanBns.SelectedCells[0].OwningRow.Cells["nPrint"].Value > 0)
            {
                MessageBox.Show("Sudah cetak slip", "Perhatian");
                return;
            }

            if (dataGridPerolehanBns.SelectedCells[0].OwningRow.Cells["NoACC"].Value.ToString() == "")
            {
                MessageBox.Show("Belum di acc !!!", "Perhatian");
                return;
            }
            string
                kodeSales = dataGridSales.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString(),
                namaSales = dataGridSales.SelectedCells[0].OwningRow.Cells["NamaSales"].Value.ToString(),
                periode = dataGridPerolehanBns.SelectedCells[0].OwningRow.Cells["Periode"].Value.ToString(),
                noACC = dataGridPerolehanBns.SelectedCells[0].OwningRow.Cells["NoACC"].Value.ToString();               
            double rpACC = double.Parse(dataGridPerolehanBns.SelectedCells[0].OwningRow.Cells["RpACC"].Value.ToString());
            DateTime tanggal = (DateTime)dataGridPerolehanBns.SelectedCells[0].OwningRow.Cells["Tanggal"].Value;

            if (noACC.Substring(0, 3) == "DIS")
            {
                return;
            }

            BuildString data = new BuildString();

            string typePrinter = data.GetPrinterName();

            data.Initialize();
            data.PageLLine(33);
            data.LeftMargin(3);
            data.LetterQuality(true);
            data.FontBold(true);
            data.PROW(true, 1, "");
            data.DoubleHeight(true);
            data.DoubleWidth(true);    
            data.PROW(true, 1, data.SPACE(13) + "SLIP BONUS SALESMAN");
            data.DoubleWidth(false);
            data.DoubleHeight(false);
            data.FontCPI(12);
            data.PROW(true, 1, "");            
            //@ PROW()+1,1 SAY CHR(27)+CHR(33)+CHR(12)
            data.PROW(true, 1, data.PrintHorizontalLine(77));
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "   BULAN            : " + periode);
            data.PROW(true, 1, ""); 
            data.PROW(true, 1, "   DICETAK TANGGAL  : " + tanggal.ToString("dd-MMM-yyyy"));
            data.PROW(true, 1, "");
            data.PROW(true, 1, "   SALESMAN         : " + kodeSales + "    " + namaSales);
            data.PROW(true, 1, "");
            data.PROW(true, 1, "   NO. ACC          : " + noACC);
            data.PROW(true, 1, "");
            data.PROW(true, 1, "   BONUS PENJUALAN BARANG PRODUKSI & MEREK HTS");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "   NOMINAL          : Rp." + rpACC.ToString("#,###").PadLeft(9) + ",-");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "            Ka.ADM,                                   Penerima,");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "         (          )                               (           )");
            data.PROW(true, 1, data.PrintHorizontalLine(77));
            data.PROW(true, 1, "");
            data.Eject();

            data.SendToPrinter("slipBonus.txt");
        }

        private void UpdatedNPrint()
        {
 
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            RefreshDataSales();
           // this.Close();
        }

        private void dataGridSales_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridSales.SelectedCells.Count > 0)
            {
                RefreshDataPerolehanBonus();
            }
        }
    }
}
