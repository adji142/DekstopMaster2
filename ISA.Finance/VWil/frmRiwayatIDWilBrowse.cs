using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.DataTemplates;
using ISA.Finance.Class;

namespace ISA.Finance.VWil
{
    public partial class frmRiwayatIDWilBrowse : ISA.Finance.BaseForm
    {
        int prevGrid1Row = -1;

        dsJurnal.JournalDataTable dtJurnalH = new dsJurnal.JournalDataTable();
        dsJurnal.JournalDetailDataTable dtJurnalD = new dsJurnal.JournalDetailDataTable();


        public frmRiwayatIDWilBrowse()
        {
            InitializeComponent();
        }

        private void frmRiwayatIDWilBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (prevGrid1Row != dataGridView1.SelectedCells[0].OwningRow.Index)
                {                    
                    RefreshGridDetail();
                }
                prevGrid1Row = dataGridView1.SelectedCells[0].OwningRow.Index;
            }            
        }

        public void RefreshData()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
               
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    RefreshDataDetail();
                    label1.Text = (dataGridView1.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString())
                  + "  "
                  + (dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString());

                }
                else
                {
                    dataGridView2.DataSource = null;
                    label1.Text = "";
                }
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        public void RefreshRowData(string kodeToko)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodeToko));
                    dt = db.Commands[0].ExecuteDataTable();
                    
                }
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.RefreshDataRow(dt.Rows[0], "KodeToko", kodeToko);                 
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshDataDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    
                    //Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string kodeToko = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                    db.Commands.Add(db.CreateCommand("usp_ReIDWil_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodeToko));
                    dt = db.Commands[0].ExecuteDataTable();
                    
                }

                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    dataGridView2.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshRowDetail(string rowID)
        {
            try
            {

                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReIDWil_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, new Guid(rowID)));
                    dt = db.Commands[0].ExecuteDataTable();

                }

                if (dt.Rows.Count > 0)
                {
                    dataGridView2.RefreshDataRow(dt.Rows[0], "RowID", rowID);
                }
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                if (Convert.ToBoolean(dataGridView2.SelectedCells[0].OwningRow.Cells["upd"].Value) == false && dataGridView2.SelectedCells[0].OwningRow.Cells["IdWilBaru"].Value.ToString() != "")
                {

                    Guid tokoID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["TokoID"].Value;
                    string wilID = dataGridView1.SelectedCells[0].OwningRow.Cells["IdWilBaru"].Value.ToString();
                    Guid rowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Toko_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, tokoID));
                        db.Commands[0].Parameters.Add(new Parameter("@wilID", SqlDbType.VarChar, wilID));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        

                        //db.Commands.Add(db.CreateCommand("usp_ReIDWil_UPDATE"));
                        //db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        //db.Commands[0].Parameters.Add(new Parameter("@lRefresh", SqlDbType.VarChar, wilID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {             

                if (dataGridView1.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString() != "")
                {
                    
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string kodeToko = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                    string idwil = dataGridView1.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString();
                    //string lrefresh = dataGridView2.SelectedCells[0].OwningRow.Cells["LRefresh"].Value.ToString();
                    DataTable dtUnProcessed;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("[usp_ReIDWil_LIST]"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodeToko));
                        db.Commands[0].Parameters.Add(new Parameter("@lRefresh", SqlDbType.VarChar, '0'));

                        dtUnProcessed = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtUnProcessed.Rows.Count > 0)
                    {
                        MessageBox.Show("Tidak bisa Add, masih ada item yang belum diproses");
                        return;
                    }

                    VWil.frmRiwayatIDWilUpdate ifrmChild = new VWil.frmRiwayatIDWilUpdate(this, kodeToko, idwil);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                if (Convert.ToBoolean(dataGridView2.SelectedCells[0].OwningRow.Cells["Upd"].Value) == false)
                {
                    Guid rowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["Row"].Value;
                    VWil.frmRiwayatIDWilUpdate ifrmChild = new VWil.frmRiwayatIDWilUpdate(this, rowID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                else
                {
                    MessageBox.Show("Data sudah di proses, tidak bisa edit lagi");
                    cmdEdit.Enabled = false;
                }
            }
            
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                if (Convert.ToBoolean(dataGridView2.SelectedCells[0].OwningRow.Cells["Upd"].Value) == false)
                {
                    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Guid rowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["Row"].Value;
                        try
                        {
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_ReIDWil_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                dt = db.Commands[0].ExecuteDataTable();
                            }

                            
                            DataRowView drv = (DataRowView)dataGridView2.SelectedCells[0].OwningRow.DataBoundItem;
                            drv.Delete();
                            MessageBox.Show("Record telah dihapus");
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Data sudah di proses, tidak bisa delete");
                    cmdDelete.Enabled = false;
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridView2.FindRow(columnName, value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0 && dataGridView2.SelectedCells.Count > 0)
            {
                if (Convert.ToBoolean(dataGridView2.SelectedCells[0].OwningRow.Cells["upd"].Value) == false && dataGridView2.SelectedCells[0].OwningRow.Cells["IdWilBaru"].Value.ToString() != "")
                {
                    string kodeToko = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                    string namaToko = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();

                    string idWilBaru = dataGridView2.SelectedCells[0].OwningRow.Cells["IdWilBaru"].Value.ToString();
                    string idWilLama = dataGridView2.SelectedCells[0].OwningRow.Cells["IdWilLama"].Value.ToString();
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    Guid reWilRowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["Row"].Value;

                    DataTable dtVwil = new DataTable();
                    
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        
                        db.Commands.Add(db.CreateCommand("psp_VWIL_GetData"));                        
                        db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                        dtVwil = db.Commands[0].ExecuteDataTable();
                        //RefreshData();


                        //DataTable dt = new DataTable();
                        //db.Commands.Add(db.CreateCommand("usp_Toko_UPDATE"));
                        //db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        //db.Commands[0].Parameters.Add(new Parameter("@wilID", SqlDbType.VarChar, wilID));
                        //db.Commands[0].Parameters.Add(new Parameter("@reWilRowID", SqlDbType.UniqueIdentifier, reWilRowID));
                        //db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        //db.Commands[0].ExecuteNonQuery();
                        //RefreshData();
                        
                    }

                    DataTemplates.dsJurnal.JournalDataTable dtHeader = new ISA.Finance.DataTemplates.dsJurnal.JournalDataTable();
                    DataTemplates.dsJurnal.JournalDetailDataTable dtDetail = new ISA.Finance.DataTemplates.dsJurnal.JournalDetailDataTable();
                    double rpSisa = 0;

                    if (dtVwil.Rows.Count == 1)
                    {
                        Guid jRowID = Guid.NewGuid();
                        string jRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                        DateTime jTanggal = DateTime.Now.Date;
                        string jReff = Numerator.BookNumerator("ADJ");
                        string jUraian = "PINDAH WILAYAH TOKO " + namaToko + " DARI " + idWilLama + " KE " + idWilBaru;
                        rpSisa = Convert.ToDouble( dtVwil.Rows[0]["RpSisa"]);
                       
                        string dNoPerk = "";
                        string kNoPerk = "";

                        string NoPerkBaru = Perkiraan.GetPerkiraanKoneksiDetail("COL" + idWilBaru.Substring(0, 1)).Rows[0]["NoPerkiraan"].ToString();
                        string NoPerkLama = Perkiraan.GetPerkiraanKoneksiDetail("COL" + idWilLama.Substring(0, 1)).Rows[0]["NoPerkiraan"].ToString();


                        if (rpSisa >= 0)
                        {
                            dNoPerk = NoPerkBaru;
                            kNoPerk = NoPerkLama;

                        }
                        else
                        {
                            dNoPerk = NoPerkLama;
                            kNoPerk = NoPerkBaru;
                        }
                        if (rpSisa > 0)
                        {
                            dtJurnalH.Rows.Clear();
                            dtJurnalD.Rows.Clear();

                            InsertJournalHeader(jRowID, rowID, jRecID, jTanggal, jReff, jUraian, "WIL", GlobalVar.Gudang, false, rpSisa, rpSisa);
                            InsertJournalDetail(Guid.NewGuid(), rowID, jRowID, Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial), jRecID, dNoPerk, jUraian, rpSisa, 0, "D");
                            InsertJournalDetail(Guid.NewGuid(), rowID, jRowID, Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial), jRecID, kNoPerk, jUraian, 0, rpSisa, "K");
                        }
                    }
                    VWil.frmProsesIDWilExecute ifrmChild = new VWil.frmProsesIDWilExecute(kodeToko, reWilRowID, dtJurnalH, dtJurnalD);
                    ifrmChild.Caller = this;
                    ifrmChild.ShowDialog();
                    //MessageBox.Show("Refresh data transaksi telah selesai");
                }
                else
                {
                    MessageBox.Show("Record ini sudah diupload");
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }


        private void RefreshGridDetail()
        {
            cmdAdd.Enabled = false;
            cmdEdit.Enabled = false;
            cmdDelete.Enabled = false;

            dataGridView2.DataSource = null;
            label1.Text = "";
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (dataGridView1.SelectedCells[0].RowIndex != prevGrid1Row)
                {
                    RefreshDataDetail();
                    label1.Text = (dataGridView1.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString())
                     + "  "
                     + (dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString());
                }
                prevGrid1Row = dataGridView1.SelectedCells[0].RowIndex;


            }
            else
            {
                dataGridView2.DataSource = null;
                label1.Text = "";
            }
        }

        private void RefreshButtonGridDetail()
        {
            cmdAdd.Enabled = true;
            if (dataGridView2.SelectedCells.Count > 0)
            {
                if (Convert.ToBoolean(dataGridView2.SelectedCells[0].OwningRow.Cells["Upd"].Value) == false)
                {
                    cmdEdit.Enabled = true;
                    cmdDelete.Enabled = true;
                }
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            RefreshButtonGridDetail();
        }


        private DataRow InsertJournalHeader(Guid rowID, Guid RefRowID, string recordID, DateTime tanggal, string noReff, string uraian, string src, string kodeGudang, bool syncFlag, double debet, double kredit)
        {
            dsJurnal.JournalRow hdrNew = (dsJurnal.JournalRow)dtJurnalH.NewRow();

            hdrNew.RefRowID = RefRowID;
            hdrNew.RowID = rowID;
            hdrNew.RecordID = recordID;
            hdrNew.Tanggal = tanggal;
            hdrNew.NoReff = noReff;
            hdrNew.Uraian = uraian;
            hdrNew.Src = src;
            hdrNew.KodeGudang = kodeGudang;
            hdrNew.SyncFlag = syncFlag;
            hdrNew.Debet = debet;
            hdrNew.Kredit = kredit;
            dtJurnalH.Rows.Add(hdrNew);
            return (DataRow)hdrNew;
        }

        private DataRow InsertJournalDetail(Guid rowID, Guid RefRowID, Guid headerID, string recordID, string hRecordID, string noPerkiraan, string uraian, double debet, double kredit, string DK)
        {
            dsJurnal.JournalDetailRow dtlNew = (dsJurnal.JournalDetailRow)dtJurnalD.NewRow();

            dtlNew.RefRowID = RefRowID;
            dtlNew.RowID = rowID;
            dtlNew.HeaderID = headerID;
            dtlNew.RecordID = recordID;
            dtlNew.HRecordID = hRecordID;
            dtlNew.NoPerkiraan = noPerkiraan;
            dtlNew.Uraian = uraian;
            dtlNew.Debet = debet;
            dtlNew.Kredit = kredit;
            dtlNew.DK = DK;
            dtJurnalD.Rows.Add(dtlNew);
            return (DataRow)dtlNew;
        }

        private void dataGridView2_Enter(object sender, EventArgs e)
        {
            dataGridView2_SelectionChanged(sender, e);
        }
            
    }
}
