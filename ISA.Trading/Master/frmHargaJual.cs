using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Excel=Microsoft.Office.Interop.Excel;
namespace ISA.Trading.Master
{
    public partial class frmHargaJual : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;

        public frmHargaJual()
        {
            InitializeComponent();
        }

        private void InitializeComponents()
        {
            this.Location = new Point(50, 50);
        }


        public void RefreshDataStok()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtStok = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_Stok_HargaJual_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtSearch.Text));
                    dtStok = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dtStok;
                }
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    RefreshDataBMK();
                    RefreshDataBMK2();
                    RefreshDataHargaPromo();
                    lblInfoBarang.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
                }else
                {
                    dataGridView2.DataSource = null;
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

                    string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
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


        public void RefreshDataBMK()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtBMK = new DataTable();

                    //string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
                    string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();

                    db.Commands.Add(db.CreateCommand("usp_HistoryBMKDepo_HargaJual_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    dtBMK = db.Commands[0].ExecuteDataTable();
                    dataGridView2.DataSource = dtBMK;
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
                    string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();

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
            this.Title = "";
            this.Text = "Harga Jual";
            dataGridView3.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.VirtualMode = true;
            RefreshDataStok();

            if (GlobalVar.Gudang.ToString().Trim().Substring(0, 2) != "28")
            {
                cmdAdd.Visible = true;
                cmdEdit.Visible = true;
                cmdDelete.Visible = true;
                cmdDownload.Visible = false;
                cmdGetSync2801.Visible = false;
                dataGridView3.Visible = false;
                dataGridView3.Height = 400;
            }
            else
            {
                cmdAdd.Visible = false;
                cmdEdit.Visible = false;
                cmdDelete.Visible = false;
                cmdDownload.Visible = true;
                cmdGetSync2801.Visible = true;
            }
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
           

            if (e.KeyCode == Keys.F3 && dataGridView1.Rows.Count>1)
            {
                

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dtBMK = new DataTable();
                    using (Database db = new Database())
                    {
                       
                        //string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
                        string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();

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
            if (dataGridView1.SelectedCells.Count > 0)
            {
                RefreshDataBMK();
                RefreshDataBMK2();
                RefreshDataHargaPromo();
                lblInfoBarang.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();

            }
            else
            {
                dataGridView2.DataSource = null;
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

        private void cmdGetSync2801_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Gudang == "2803")
            {
                if (MessageBox.Show("Sync Harga dari 2801?", "Sync", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_HistoryBMKDepo_UPDATE"));
                            db.Commands[0].ExecuteNonQuery();
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        if (dt.Rows.Count > 0)
                            MessageBox.Show("Proses selesai");
                        else
                            MessageBox.Show("Tidak ada data yang diDowmload.");
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hanya untuk depo 2803.");
                return;
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            InputHarga1(Class.Enums.enumClsState.New);
        }

        void InputHarga1(Class.Enums.enumClsState tState) {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    DataRow dr = null;
                    frmHargaJualBMK frm = null;
                    switch (tState)
                    {
                        case Class.Enums.enumClsState.New:
                            dr = (DataRow)(dataGridView1.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                            frm = new frmHargaJualBMK(tState,dr["RecordID"].ToString());
                            break;
                        case Class.Enums.enumClsState.Update:
                            if (dataGridView2.SelectedCells.Count > 0)
                            {
                                dr = (DataRow)(dataGridView2.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                                frm = new frmHargaJualBMK(tState, (Guid)dr["RowID"]);
                            }
                            break;
                    }
                    if (dr != null && frm!=null)
                    {
                        //frm.MdiParent = this.MdiParent;
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                        {
                            RefreshDataBMK();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            InputHarga1(Class.Enums.enumClsState.Update);
        }
    }
}
