using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Excel=Microsoft.Office.Interop.Excel;
namespace ISA.Toko.Master
{
    public partial class frmHargaJual : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;

        public frmHargaJual()
        {
            InitializeComponent();
        }

        private void InitializeComponents()
        {
            //this.Location = new Point(50, 50);
            this.WindowState = FormWindowState.Maximized;
        }


        public void RefreshDataStok()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtStok = new DataTable();

                    //db.Commands.Add(db.CreateCommand("usp_Stok_HargaJual_LIST"));
                    //db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtSearch.Text));
                    //dtStok = db.Commands[0].ExecuteDataTable();

                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtSearch.Text));
                    dtStok = db.Commands[0].ExecuteDataTable();
                    datagridviewBarang.DataSource = dtStok;
                }
                if (datagridviewBarang.SelectedCells.Count > 0)
                {
                    RefreshDataBMK();
                   // RefreshDataBMK2();
                    //RefreshDataHargaPromo();
                    lblInfoBarang.Text = datagridviewBarang.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
                }else
                {
                    datagridviewHarga.DataSource = null;
                    dataGridView3.DataSource = null;
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

        private void RefreshDataHargaPromo()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtHP = new DataTable();

                    string _barangID = datagridviewBarang.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
                   // string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();

                    db.Commands.Add(db.CreateCommand("usp_Harga_Promo_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    dtHP = db.Commands[0].ExecuteDataTable();
                    customGridView1.DataSource = dtHP;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void FindRow(string columnName, string value)
        {
            datagridviewBarang.FindRow(columnName, value);
        }
        public void FindRow1(string columnName, string value)
        {
          datagridviewHarga.FindRow(columnName, value);
        }
        public void RefreshDataBMK()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtBMK = new DataTable();

                    //string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
                    string _barangID = datagridviewBarang.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();

                    db.Commands.Add(db.CreateCommand("usp_HistoryBMKDepo_HargaJual_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    dtBMK = db.Commands[0].ExecuteDataTable();
                    datagridviewHarga.DataSource = dtBMK;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshDataBMK2()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtBMK = new DataTable();

                    //string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
                    string _barangID = datagridviewBarang.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();

                    db.Commands.Add(db.CreateCommand("usp_HistoryBMK2Depo_HargaJual_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    dtBMK = db.Commands[0].ExecuteDataTable();
                    dataGridView3.DataSource = dtBMK;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataStok();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void frmHargaJual_Load(object sender, EventArgs e)
        {
            InitializeComponents();
            //this.Title = "";
            //this.Text = "Harga Jual";
            //dataGridView3.AutoGenerateColumns = false;
            //datagridviewHarga.AutoGenerateColumns = false;
            //datagridviewBarang.AutoGenerateColumns = false;
            //datagridviewBarang.VirtualMode = true;
            RefreshDataStok();

            this.WindowState = FormWindowState.Maximized;
        }

#region "Excell Generator"
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void GenerateExcel(DataTable dt)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            int x = dt.Rows.Count;
            
            xlWorkSheet.Cells[1, 1] = "Nama Barang";
            xlWorkSheet.Cells[1, 2] = "Kode Barang";
            xlWorkSheet.Cells[1, 3] = "Harga B";
            xlWorkSheet.Cells[1, 4] = "Harga M";
            xlWorkSheet.Cells[1, 5] = "Harga K";
            
            int i = 1;
            for ( i = 1; i <= dt.Rows.Count ; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    DataRow dr = dt.Rows[i-1];
                    xlWorkSheet.Cells[i + 1, j + 1] = dr[j].ToString();
                }
            }

            //xlWorkSheet.Cells[2, 1] = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value;
            //xlWorkSheet.Cells[2, 2] = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value;
            //xlWorkSheet.Cells[2, 3] = dataGridView2.Rows[0].Cells["HJualB"].Value;
            //xlWorkSheet.Cells[2, 4] = dataGridView2.Rows[0].Cells["HJualM"].Value;
            //xlWorkSheet.Cells[2, 5] = dataGridView2.Rows[0].Cells["HJualK"].Value;

            xlWorkBook.SaveAs(GlobalVar.DbfDownload+"\\HargaBMK.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file "+GlobalVar.DbfDownload+"\\HargaBMK.xls");
        }
#endregion

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
           

            if (e.KeyCode == Keys.F3 && datagridviewBarang.Rows.Count>1)
            {
                

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dtBMK = new DataTable();
                    using (Database db = new Database())
                    {
                       
                        //string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
                        string _barangID = datagridviewBarang.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();

                        db.Commands.Add(db.CreateCommand("usp_BMKDepoToExcel"));
                        if (txtSearch.Text.Trim()!="")
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtSearch.Text.Trim()));
                        }
                        
                        dtBMK = db.Commands[0].ExecuteDataTable();
                       
                    }
                    GenerateExcel(dtBMK);
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

        }

        private void dataGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            if (datagridviewBarang.SelectedCells.Count > 0)
            {
                //RefreshDataStok();
                RefreshDataBMK();
                //RefreshDataBMK2();
                //RefreshDataHargaPromo();
                lblInfoBarang.Text = datagridviewBarang.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();

            }
            else
            {
                datagridviewHarga.DataSource = null;
                dataGridView3.DataSource = null;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            Master.FrmHargaJualDownload ifrmChild = new Master.FrmHargaJualDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdDownloadPromo_Click(object sender, EventArgs e)
        {
            Master.frmHargaPromoDownload ifrmChild = new Master.frmHargaPromoDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        //private void commandButton1_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Price List");
        //}

        private void cmdPriceList_Click(object sender, EventArgs e)
        {
            Master.frmPriceList ifrmChild = new Master.frmPriceList();
            ifrmChild.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Master.frmHargaPromoDownload ifrmChild = new Master.frmHargaPromoDownload();
            ifrmChild.ShowDialog();

            //Master.frmHargaPromoDownload ifrmChild = new Master.frmHargaPromoDownload();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();

        }

        public bool GetHargaHpp(string barangID)
        {
            bool value = false;
                DataTable dtGetHargaHPP = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cekHargaHPP"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                    dtGetHargaHPP = db.Commands[0].ExecuteDataTable();
                }
                if (dtGetHargaHPP.Rows.Count > 0)
                {
                    value = true;
                }
                else
                {
                    MessageBox.Show("Isi harga Beli atau isi Pembelian terlebih dahulu.");
                }
                return value;
        }


        private void cmdADD_Click(object sender, EventArgs e)
        {
            if (datagridviewBarang.SelectedCells.Count > 0)
            {
                
                //string _RecordID = datagridviewBarang.SelectedCells[0].OwningRow.Cells[RecordID.Name].Value.ToString();
                string _KodeBarang = datagridviewBarang.SelectedCells[0].OwningRow.Cells[KodeBarang.Name].Value.ToString();
                if (!GetHargaHpp(_KodeBarang)) return;
                Master.frmHargaJualUpdate ifrmChild = new Master.frmHargaJualUpdate(this,  _KodeBarang,"");
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
        }

        private void frmHargaJual_VisibleChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmHargaJual_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if ((DateTime)datagridviewHarga.SelectedCells[0].OwningRow.Cells[TMT.Name].Value < GlobalVar.DateOfServer) 
            {
                MessageBox.Show( "TMT kurang dari Datetime Server : "+GlobalVar.DateOfServer.ToString());
                return;
            }

            if (datagridviewHarga.SelectedCells.Count > 0)
            {
                Guid _RowID = new Guid(datagridviewHarga.SelectedCells[0].OwningRow.Cells["RowID1"].Value.ToString());
                string _KodeBarang = datagridviewBarang.SelectedCells[0].OwningRow.Cells[KodeBarang.Name].Value.ToString();

                Master.frmHargaJualUpdate ifrmChild = new Master.frmHargaJualUpdate(this, _KodeBarang, _RowID);
                ifrmChild.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tidak ada data yag di pilih");
                return;
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (datagridviewHarga.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Hapus Harga?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Guid _RowID = (Guid)datagridviewHarga.SelectedCells[0].OwningRow.Cells["RowID1"].Value;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_HargaJualBMK_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Record telah dihapus");
                        this.RefreshDataBMK();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
        }

        private void datagridviewHarga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmHargaJual_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    this.cmdADD.PerformClick();
                    break;
                case Keys.Delete:
                    //this.cmdDELETE.PerformClick();
                    break;
                case Keys.Space:
                    this.cmdEDIT.PerformClick();
                    break;
                case Keys.F5:
                    RefreshDataStok();
                    break;
            }
        }
    }
}
