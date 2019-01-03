using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.Class;

namespace ISA.Trading.Master
{
    public partial class frmStokOpnameBrowse : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;

        public frmStokOpnameBrowse()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();

                //using (Database db = new Database())
                //{
                //    db.Commands.Add(db.CreateCommand("usp_StokOpname_LIST"));
                //    dt = db.Commands[0].ExecuteDataTable();
                //}

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtSearch.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                customGridView1.DataSource = dt;
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

        public void RefreshDataDetail()
        {
            try
            {
                if (customGridView1.SelectedCells.Count > 0)
                {
                    string _barangID = customGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        if (checkBox1.Checked)
                        {
                            db.Commands.Add(db.CreateCommand("usp_OpnameHistory_LIST"));
                        }
                        else
                        {
                            db.Commands.Add(db.CreateCommand("[usp_OpnameClosing_LIST]"));

                        }

                        db.Commands[0].Parameters.Add(new Parameter("@kodeBarang", SqlDbType.VarChar, _barangID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    dt.DefaultView.Sort = "TglOpname DESC";
                    customGridView2.DataSource = dt.DefaultView;
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

        private void frmStokOpnameBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
            RefreshDataDetail();
        }

        
        private void customGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                cmdAdd.PerformClick();
                //if (customGridView1.SelectedCells.Count > 0)
                //{
                //    string kodeBarang = customGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();
                //    string sat = customGridView1.SelectedCells[0].OwningRow.Cells["SatJual"].Value.ToString();
                //    Master.frmStokOpnameHarian ifrmChild = new Master.frmStokOpnameHarian(this, kodeBarang, sat);
                //    ifrmChild.MdiParent = Program.MainForm;
                //    Program.MainForm.RegisterChild(ifrmChild);
                //    ifrmChild.Show();
                //}
            }
        }

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.Shift == true && e.KeyCode == Keys.P)
            {
                if (customGridView1.SelectedCells.Count > 0)
                {
                    string namaStok = customGridView1.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
                    string satJual = customGridView1.SelectedCells[0].OwningRow.Cells["SatJual"].Value.ToString();
                    string kodeBarang = customGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();
                    printOpname(namaStok, satJual, kodeBarang);
                }

            }
        }

        private void printOpname(string namaStok, string satJual, string kodeBarang)
        {

            BuildString op = new BuildString();
            double saldoAwal = 0;
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_getSaldoAwal"));
                db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, DateTime.Now));
                db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, kodeBarang));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                dt = db.Commands[0].ExecuteDataTable();
                saldoAwal = Convert.ToDouble(Tools.isNull(dt.Rows[0][0], "0").ToString());
            }

            op.LeftMargin(3);
            op.FontBold(true);
            op.FontCPI(20);
            op.PROW(true, 0, "FORM OPNAME HARIAN 0000");
            op.PROW(true, 1, "");
            op.FontCondensed(true);
            op.FontBold(false);
            op.PROW(true, 1, "Tgl. Opname     " + String.Format("{0:dd-MMM-yyyy}", DateTime.Now) +
                op.SPACE(5) + "(Saldo Awal : " + saldoAwal.ToString() + ")");
            op.PROW(true, 1, "");
            op.PROW(true, 1, "");
            op.PROW(true, 1, op.PrintTopLeftCorner() + op.PrintHorizontalLine(128) + op.PrintTopRightCorner());
            op.PROW(true, 1, op.PrintVerticalLine() + op.PadCenter(15, "Nama barang") + op.PrintVerticalLine() +
                namaStok.PadRight(112) + op.PrintVerticalLine());
            op.PROW(true, 1, op.PrintVerticalLine() + op.PrintHorizontalLine(128) + op.PrintVerticalLine());
            op.PROW(true, 1, op.PrintVerticalLine() + op.SPACE(15) + op.PrintVerticalLine() + op.SPACE(112) + op.PrintVerticalLine());
            op.PROW(true, 1, op.PrintVerticalLine() + "QTY".PadLeft(15) + op.PrintVerticalLine() + op.SPACE(20) +
                satJual.PadRight(92) + op.PrintVerticalLine());
            op.PROW(true, 1, op.PrintVerticalLine() + op.SPACE(15) + op.PrintVerticalLine() + op.SPACE(112) + op.PrintVerticalLine());
            op.PROW(true, 1, op.PrintBottomLeftCorner() + op.PrintHorizontalLine(128) + op.PrintBottomRightCorner());
            op.PROW(true, 1, "");

            op.PROW(true, 1, op.PrintTopLeftCorner() + op.PrintHorizontalLine(128) + op.PrintTopRightCorner());
            op.PROW(true, 1, op.PrintVerticalLine() + op.PadCenter(42, "Penghitung") + op.PrintVerticalLine() +
                op.PadCenter(42, "Ka. gudang") + op.PrintVerticalLine() + op.PadCenter(42, "Accounting") + op.PrintVerticalLine());
            op.PROW(true, 1, op.PrintVerticalLine() + op.PadCenter(42, "Mengajukan") + op.PrintVerticalLine() +
                op.PadCenter(42, "Menyetujui") + op.PrintVerticalLine() + op.PadCenter(42, "Mengetahui") + op.PrintVerticalLine());
            op.PROW(true, 1, op.PrintVerticalLine() + op.PrintHorizontalLine(128) + op.PrintVerticalLine());
            op.PROW(true, 1, op.PrintVerticalLine() + op.SPACE(42) + op.PrintVerticalLine() + op.SPACE(42) +
                op.PrintVerticalLine() + op.SPACE(42) + op.PrintVerticalLine());
            op.PROW(true, 1, op.PrintVerticalLine() + op.SPACE(42) + op.PrintVerticalLine() + op.SPACE(42) +
                op.PrintVerticalLine() + op.SPACE(42) + op.PrintVerticalLine());
            op.PROW(true, 1, op.PrintVerticalLine() + op.SPACE(42) + op.PrintVerticalLine() + op.SPACE(42) +
                op.PrintVerticalLine() + op.SPACE(42) + op.PrintVerticalLine());
            op.PROW(true, 1, op.PrintVerticalLine() + op.SPACE(42) + op.PrintVerticalLine() + op.SPACE(42) +
                op.PrintVerticalLine() + op.SPACE(42) + op.PrintVerticalLine());
            op.PROW(true, 1, op.PrintVerticalLine() + op.PrintHorizontalLine(128) + op.PrintVerticalLine());
            op.PROW(true, 1, op.PrintVerticalLine() + "  (" + op.SPACE(36) + ")  " + op.PrintVerticalLine() +
                "  (" + op.SPACE(36) + ")  " + op.PrintVerticalLine() + "  (" + op.SPACE(36) + ")  " + op.PrintVerticalLine());
            op.PROW(true, 1, op.PrintBottomLeftCorner() + op.PrintHorizontalLine(128) + op.PrintBottomRightCorner());
            op.PROW(true, 1, String.Format("{0:dd-MMM-yyy-hh-mm-ss}", DateTime.Now) + ", " + SecurityManager.UserName);
            op.Eject();
            op.SendToPrinter("notaJual.txt");

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            RefreshDataDetail();
        }

        private void customGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdAddSampling_Click(object sender, EventArgs e)
        {


        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Gudang.Substring(0, 2) == "28")
            {
                if (!lUserAccess())
                {
                    MessageBox.Show("Belum ada wewenang.");
                    return;
                }
            }

            if (customGridView1.SelectedCells.Count > 0)
            {
                bool isAllowIED;
                if (GlobalVar.Gudang.Substring(0, 2) == "28")
                    isAllowIED = CekFlagOpnameMutasi();
                else
                    isAllowIED = true;
                
                if (isAllowIED)
                {
                    string kodeBarang = customGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();
                    string sat = customGridView1.SelectedCells[0].OwningRow.Cells["SatJual"].Value.ToString();
                    Master.frmStokOpnameHarian ifrmChild = new Master.frmStokOpnameHarian(this, kodeBarang, sat);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                else
                {
                    MessageBox.Show("Silahkan Ijin ke HO untuk melakukan Sampling Opname");
                }
            }
        }

        private bool lUserAccess()
        {
            Boolean x = true;
            if (SecurityManager.UserName != "MANAGER")
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dtUser = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_UserAccess_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, "SAMPLING OPNAME"));
                        db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, SecurityManager.UserID));
                        dtUser = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtUser.Rows.Count > 0)
                    {
                        if (Tools.isNull(dtUser.Rows[0]["Value"], "0").ToString() == "0")
                        {
                            x = false;
                        }
                    }
                    else
                    {
                        x = false;
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
            return x;
        }


        public static bool CekFlagOpnameMutasi()
        {
            Boolean avb = false;
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_getAppSetting_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "OPNAME_MUTASI"));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        if (Tools.isNull(dt.Rows[0]["Value"], "").ToString() == "1")
                        {
                            avb = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return avb;
        }


        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
            RefreshDataDetail();
        }

        private void customGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                if (customGridView1.SelectedCells[0].RowIndex != prevGrid1Row)
                {
                    RefreshDataDetail();

                    lblNamaStok.Text = "\"" + customGridView1.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString() + "\" "
                        + customGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();
                }
                prevGrid1Row = (customGridView1.SelectedCells[0].RowIndex);
            }
            else
            {
                prevGrid1Row = -1;
                lblNamaStok.Text = "";
            }
        }

        
        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Gudang.Substring(0, 2) == "28")
            {
                if (!lUserAccess())
                {
                    MessageBox.Show("Belum ada wewenang.");
                    return;
                }
            }

            if (customGridView2.SelectedCells.Count > 0)
            {
                bool isAllowIED;
                if (GlobalVar.Gudang.Substring(0, 2) == "28")
                    isAllowIED = CekFlagOpnameMutasi();
                else
                    isAllowIED = true;

                if (isAllowIED)
                {
                    string kodeBarang = customGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();
                    string sat = customGridView1.SelectedCells[0].OwningRow.Cells["SatJual"].Value.ToString();
                    Guid rowID = (Guid)customGridView2.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    DateTime tglOpname = (DateTime)customGridView2.SelectedCells[0].OwningRow.Cells["TglOpname"].Value;
                    int qtyOpname = Convert.ToInt32(customGridView2.SelectedCells[0].OwningRow.Cells["QtyOpname"].Value);
                    string keterangan = customGridView2.SelectedCells[0].OwningRow.Cells["Keterangan"].Value.ToString(); ;

                    Master.frmStokOpnameHarian ifrmChild = new Master.frmStokOpnameHarian(this, rowID, kodeBarang, sat, tglOpname, qtyOpname, keterangan);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                else
                {
                    MessageBox.Show("Silahkan Ijin ke HO untuk melakukan Sampling Opname");
                }
            }
        }


        private int GetCountDO()
        {
            int rowCount = 0;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                string kodeBarang = customGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();

                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST_FILTER_BarangOpname"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, kodeBarang));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                rowCount = dt.Rows.Count;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return rowCount;
        }

        private int GetCountAG()
        {
            int rowCount = 0;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                string kodeBarang = customGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();

                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AntarGudangDetail_LIST_BarangOpname"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeBarang", SqlDbType.VarChar, kodeBarang));
                    db.Commands[0].Parameters.Add(new Parameter("@dariGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                rowCount = dt.Rows.Count;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return rowCount;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (!lUserAccess())
            {
                MessageBox.Show("Belum ada wewenang.");
                return;
            }

            if (customGridView2.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string kodeBarang = customGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();
                    Guid rowID = (Guid)customGridView2.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    DateTime tglOpname = (DateTime)customGridView2.SelectedCells[0].OwningRow.Cells["TglOpname"].Value;

                    if (tglOpname != DateTime.Today)
                    {
                        MessageBox.Show("Tanggal Opname hari ini yang bisa dihapus.");
                        return;
                    }

                    //if (GetCountDO() > 0)
                    //{
                    //    MessageBox.Show("Tidak bisa dihapus karena ada DO untuk barang tersebut hari ini.");
                    //    return;
                    //}

                    if (GetCountAG() > 0)
                    {
                        MessageBox.Show("Tidak bisa dihapus karena ada AG Kirim untuk barang tersebut hari ini.");
                        return;
                    }

                    bool isAllowIED = CekFlagOpnameMutasi();
                    if (isAllowIED)
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_OpnameHistory_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, kodeBarang));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        RefreshDataDetail();
                        MessageBox.Show("Berhasil dihapus.");
                    }
                    else
                    {
                        MessageBox.Show("Silahkan Ijin ke HO untuk melakukan Sampling Opname");
                    }
                }
            }
        }
    }
}