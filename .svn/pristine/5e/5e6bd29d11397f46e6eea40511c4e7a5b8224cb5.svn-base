using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;


namespace ISA.Finance.Piutang
{
    public partial class frmBarcodeNotaBrowse : ISA.Finance.BaseForm
    {
        int flag = 0;

        DataTable dt = new DataTable();
        public frmBarcodeNotaBrowse()
        {
            InitializeComponent();
        }

        private void frmBarcodeNotaBrowse_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            lblinfo.Text = "";
        }




        private void Refresh()
        {
            
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_NotaBarcode_list"));
                db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
            }
            gridHeader.DataSource = dt;

        }

        public void RefreshFind(Guid _RowID)
        {
            Refresh();
            gridHeader.FindRow("NotaRowID", _RowID.ToString());
            
        }

        public void RefreshRowDataReturJual(Guid _rowID)
        {
            Guid rowID = _rowID;
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaBarcodeUpdate_list"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    gridHeader.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
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


        public void RefreshDetail()
        {
            DataTable dt = new DataTable();
            String RowID_ = gridHeader.SelectedCells[0].OwningRow.Cells["BarcodeID"].Value.ToString();
            if (RowID_ == "")
            {
                try
                {
                    // String RowID_ = gridHeader.SelectedCells[0].OwningRow.Cells["BarcodeID"].Value.ToString();

                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Barcodedetail_list"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, new Guid()));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    gridDetail.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    // String RowID_ = gridHeader.SelectedCells[0].OwningRow.Cells["BarcodeID"].Value.ToString();
                   
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Barcodedetail_list"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, new Guid(RowID_)));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    gridDetail.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmdcari_Click(object sender, EventArgs e)
        {
            Refresh();
            comboBox1.Focus();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdisibarcode_Click(object sender, EventArgs e)
        {
            if (gridHeader.SelectedCells.Count > 0)
            {
                String Barcode = gridHeader.SelectedCells[0].OwningRow.Cells["Barcode"].Value.ToString();

                if (Barcode != "")
                {
                    MessageBox.Show("Barcode Sudah Terisi", "Informasi");
                }
                else
                {
                    Guid RowID_ = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["NotaRowID"].Value;
                    Piutang.frmBarcodeUpdate ifrmChild = new Piutang.frmBarcodeUpdate(this, RowID_);
                    ifrmChild.WindowState = FormWindowState.Normal;
                    ifrmChild.ShowDialog();
                    //txtOpnameNota.Focus();
                    //Refresh();
                }
                
            }
            
        }

               private void gridHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshDetail();
        }

       

       

        private void txtOpnameNota_Leave(object sender, EventArgs e)
        {
            //if ((txtOpnameNota.Text == "") && ((lblinfo.Text.Substring(0, 12) == "Opname Gagal") ||(lblinfo.Text=="")))
            //{
            //    lblinfo.Text = "";
            //}

            if (txtOpnameNota.Text == "")
            {
                lblinfo.Text = "";
            }

            if (comboBox1.Text == "")
            {
                MessageBox.Show("Isi Keterangan Terlebih Dahulu");
                return;
            }

            
            
            if ((txtOpnameNota.Text != "") &&(flag == 0))
            {
                if (txtOpnameNota.Text.Length < 12)
                {
                    MessageBox.Show("Barcode Kurang dari 12 digit");
                    return;
                }

                DataTable dtcek = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_BarcodeNota_CekDouble")); //ngecek enek no barcode nek header ora
                    db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, txtOpnameNota.Text.Substring(0,12)));
                    dtcek = db.Commands[0].ExecuteDataTable();
                }

                if (dtcek.Rows.Count == 0)
                {
                    lblinfo.Text = "Opname Gagal! Tidak ada No Barcode diNota";
                }
                else
                {
                    Guid HeaderID = new Guid(dtcek.Rows[0]["BarcodeID"].ToString());
                    DataTable dtcekdetail = new DataTable();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_BarcodeDetail_Cek"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID));
                        dtcekdetail = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtcekdetail.Rows.Count > 0)
                    {
                        MessageBox.Show("Sudah Scan", "Informasi");
                        txtOpnameNota.Text = "";
                        txtOpnameNota.Focus();
                    }

                    else
                    {
                      
                        

                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_BarcodeNotaDetail_Insert"));
                            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID));
                            db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, comboBox1.Text.ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }

                        lblinfo.Text = "Berhasil Save Barcode untuk nota " + dtcek.Rows[0]["NoNota"].ToString();


                        Refresh();
                        flag = 1;
                        gridHeader.FindRow("BarcodeID", HeaderID.ToString());
                        RefreshDetail();

                        txtOpnameNota.Text = "";
                        txtOpnameNota.Focus();
                        flag = 0;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Piutang.frmBarcodeTambahNota ifrmChild = new Piutang.frmBarcodeTambahNota();
            //ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

       

        private void gridHeader_SelectionChanged(object sender, EventArgs e)
        {
            //if (gridHeader.RowCount > 0)
            //{
            //    RefreshDetail();
            //}
        }
    }
}
