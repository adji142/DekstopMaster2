using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Master
{
    public partial class frmStokPartBrowse : ISA.Trading.BaseForm
    {
        enum enumSelectedGrid { Header,Detail };
        enumSelectedGrid selectedGrid;
        DataTable dt = new DataTable();
        DataTable dtsp = new DataTable();
        Guid _rowID;
        DataTable dtStokPart = new DataTable();
        DataSet dsData = new DataSet();

        public frmStokPartBrowse()
        {
            InitializeComponent();
        }

        private void frmStokPartBrowse_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void RefreshDataStok()
        {
            dataGridView1.AutoGenerateColumns = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtSearch.Text));

                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    RefreshDataStokPart();
                    lblNamaBarang.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["namaStok"].Value.ToString();
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

        public void RefreshDataStokPart()
        {
            try
            {
                using (Database db = new Database())
                {
                    
                    string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["IDBarang"].Value.ToString();

                    db.Commands.Add(db.CreateCommand("usp_StokPart_List"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    dtStokPart = db.Commands[0].ExecuteDataTable();
                    dataGridView2.DataSource = dtStokPart;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        public void GetDataStok()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetDataStok"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count==0)
                {
                    MessageBox.Show(dt.Rows.Count.ToString());
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


        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataStok();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                RefreshDataStokPart();
                lblNamaBarang.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["namaStok"].Value.ToString();

            }
        }

        //private void cmdAdd_Click(object sender, EventArgs e)
        //{
            
        //}

        //private void cmdEdit_Click(object sender, EventArgs e)
        //{
        //    //ArusStock.frmUpdateMutasiDetail ifrmChild = new ArusStock.frmUpdateMutasiDetail(this, _rowIDD);
        //    //ifrmChild.MdiParent = Program.MainForm;
        //    //Program.MainForm.RegisterChild(ifrmChild);
        //    //ifrmChild.Show();
        //}

        private void cmdDelete_Click(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAdd_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView1.SelectedCells[0].OwningRow.Cells["IDBarang"].Value.ToString());
            string _idBarang = dataGridView1.SelectedCells[0].OwningRow.Cells["IDBarang"].Value.ToString();
            string _Header = dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
            if (dtStokPart.Rows.Count > 0)
            {
                MessageBox.Show("ID Barang " + _idBarang + " sudah memiliki StokPart");
            }
            else
            {
                Master.frmStokPartUpdate ifrmChild = new Master.frmStokPartUpdate(this, _Header, _idBarang);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
        }

        private void cmdEdit_Click_1(object sender, EventArgs e)
        {
            
            Guid _rowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["row"].Value;
            //MessageBox.Show(_rowID.ToString());
            string _idBarang = dataGridView1.SelectedCells[0].OwningRow.Cells["IDBarang"].Value.ToString();
            string _namaStok = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
            Master.frmStokPartUpdate ifrmChild = new Master.frmStokPartUpdate(this, _rowID, _idBarang, _namaStok);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hapusData()
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                Guid RowID_ = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["row"].Value;
                if (MessageBox.Show("Hapus Data : " + RowID_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_StokPart_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, RowID_));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Record telah dihapus");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void cmdDelete_Click_1(object sender, EventArgs e)
        {
            hapusData();
            RefreshDataStokPart();
        }
        private void cmdClose_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblNamaBarang_Click(object sender, EventArgs e)
        {

        }

        //private void cmdRefresh_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        using (Database db = new Database())
        //        {

        //            db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
        //            db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, ""));
        //            dt = db.Commands[0].ExecuteDataTable();
        //        }
        //        if (dt.Rows.Count > 0)
        //        {
        //            MessageBox.Show(dt.Rows.Count.ToString());
        //        }
        //        else
        //        {
        //            MessageBox.Show("luput");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Error.LogError(ex);
        //    }
        //    finally
        //    {
        //        this.Cursor = Cursors.Default;
        //    }
        //}

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST_REFRESH"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, ""));
                    dsData = db.Commands[0].ExecuteDataSet();
                }
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsData.Tables[0].Rows)
                    {
                        string kel = "";
                        if (Tools.isNull(dr["BarangID"], "").ToString().Substring(0,3) == "FB2")
                            kel = "K2";
                        else
                            if (Tools.isNull(dr["BarangID"], "").ToString().Substring(0,3) == "FB4")
                                kel = "K4";
                            else
                                if (Tools.isNull(dr["BarangID"], "").ToString().Substring(0,3) == "FA2" ||
                                    Tools.isNull(dr["BarangID"], "").ToString().Substring(0,3) == "FA4")
                                    kel = "KV";
                                else
                                    kel = "KG";

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_StokPart_INS"));
                            //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                            db.Commands[0].Parameters.Add(new Parameter("@header", SqlDbType.VarChar, Tools.isNull(dr["RowID"], "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, Tools.isNull(dr["NamaStok"], "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, Tools.isNull(dr["BarangID"], "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, Tools.isNull(dr["SatJual"], "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@merek", SqlDbType.VarChar, Tools.isNull(dr["Merek"], "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, Tools.isNull(dr["BarangID"], "").ToString().Substring(0,3)));
                            db.Commands[0].Parameters.Add(new Parameter("@suplier", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@idtr", SqlDbType.VarChar, kel));
                            db.Commands[0].Parameters.Add(new Parameter("@pasif", SqlDbType.VarChar, Tools.isNull(dr["StatusPasif"], "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@cash", SqlDbType.NChar, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@top", SqlDbType.NChar, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@enduser", SqlDbType.NChar, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            db.CommitTransaction();
                            //db.Dispose();
                            //MessageBox.Show(Tools.isNull(dr["NamaStok"], "").ToString());
                        }
                    }
                    RefreshDataStokPart();
                    MessageBox.Show("Proses selesai..");
                }
                else
                {
                    MessageBox.Show("Stokpart sudah Update");
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

    }
}
