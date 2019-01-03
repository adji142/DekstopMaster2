using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Penjualan
{
    public partial class frmPenjualanPotonganBrowser : ISA.Trading.BaseForm
    {
        DataTable dt = new DataTable();
        bool filterF3 = false;
        bool filterF4 = false;
        bool filterF5 = false;

        public frmPenjualanPotonganBrowser()
        {
            InitializeComponent();
        }

        private void frmPenjualanPotonganBrowser_Load(object sender, EventArgs e)
        {
            if (SecurityManager.HasRight("TRD.PENGAJUAN_POTONGAN"))
            {
                cmdAdd.Enabled = true;
                cmdEdit.Enabled = true;
                cmdDelete.Enabled = true;
            }

            dataGridView1.AutoGenerateColumns = false;
            rgbTgl.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTgl.ToDate = DateTime.Now;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        
        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {                    
                    db.Commands.Add(db.CreateCommand("usp_PenjualanPotongan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTgl.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTgl.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dataGridView1.DataSource = dt;
                filterF3 = false;
                filterF4 = false;
                filterF5 = false;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //TODO: ADD Potongan Rights
            //if(SecurityManager.AppRole == "004")
            //{
            //    if(indexing != Tgl_pot)
            //    {
            //        if (dataGridView1.SelectedCells.Count > 0)
            //            {
            try
            {
                if (DateTime.Now <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(String.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }
                Penjualan.frmPenjualanPotonganUpdate ifrmChild = new Penjualan.frmPenjualanPotonganUpdate(this);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
                           
            //            }

            //    }
            //}
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.RowCount > 0)
            {
                try
                {
                    //GlobalVar.LastClosingDate = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglPot"].Value;
                    //if ((DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglPot"].Value <= GlobalVar.LastClosingDate)
                    //{
                    //    throw new Exception(String.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    //}

                    if (dataGridView1.SelectedCells[0].OwningRow.Cells["IDLink"].Value.ToString() != "")
                    {

                        MessageBox.Show("Sudah Link ke Piutang, tidak bisa Edit data", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    //if (SecurityManager.HasRight("004") || SecurityManager.HasRight("005"))
                    //{
                    //    return;

                    //}

                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    Penjualan.frmPenjualanPotonganUpdate ifrmChild = new Penjualan.frmPenjualanPotonganUpdate(this, rowID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (SecurityManager.HasRight("TRD.PENGAJUAN_POTONGAN"))
            {
                if (SecurityManager.AskPasswordManager())
                {
                    DeletePenjualanPotongan();
                }
            }
            else
            {
                DeletePenjualanPotongan();
            }
        }

        private void DeletePenjualanPotongan()
        {
            if (dataGridView1.SelectedCells[0].OwningRow.Cells["IdLink"].Value.ToString() == "")
            {
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    try
                    {
                        GlobalVar.LastClosingDate = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglPot"].Value;
                        if ((DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglPot"].Value <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(String.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }

                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_PenjualanPotongan_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));

                            db.Commands[0].ExecuteNonQuery();

                        }

                        MessageBox.Show("Record telah dihapus");
                        this.RefreshData();
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
            else
            {
                MessageBox.Show(Messages.Error.LinkPiutang);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void rgbTgl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           if (double.Parse(dataGridView1.Rows[e.RowIndex].Cells["DILACC"].Value.ToString()) > 0)
           {
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
           }
           else{
               if(double.Parse(dataGridView1.Rows[e.RowIndex].Cells["DILMinta"].Value.ToString()) > 0)
               {
                    if(dataGridView1.Rows[e.RowIndex].Cells["TglACC"].Value.ToString() == "")
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(255,0,255);
                    }
                    else{
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor  = Color.FromArgb(255,0,0);
                    }
               }
               else{
                       dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor  = Color.FromArgb(0,0,0);
                    }
               }
           }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                label2.Text = "\"" + dataGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + "\" "
                    + dataGridView1.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString() + " "+ dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();
            }
            else
            {
                label2.Text = " ";
            }
        }

        private void frmPenjualanPotonganBrowser_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dt != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.F3:
                        //filter Toko
                        if (!filterF3)
                        {
                            if (dataGridView1.SelectedCells.Count > 0)
                            {
                                string strFilter = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString().Replace("'","''");
                                dt.DefaultView.RowFilter = "NamaToko='" + strFilter + "'";
                            }
                            filterF3 = true;
                        }
                        else
                        {
                            dt.DefaultView.RowFilter = "";
                            filterF3 = false;
                        }
                        break;
                    case Keys.F4:
                        //filter Nota
                        if (!filterF4)
                        {
                            if (dataGridView1.SelectedCells.Count > 0)
                            {
                                string strFilter = dataGridView1.SelectedCells[0].OwningRow.Cells["NoNota"].Value.ToString().Replace("'", "''");
                                dt.DefaultView.RowFilter = "NoNota='" + strFilter + "'";
                            }
                            filterF4 = true;
                        }
                        else
                        {
                            dt.DefaultView.RowFilter = "";
                            filterF4 = false;
                        }
                        break;
                    case Keys.F5:
                        //filter Belum link
                        if (!filterF5)
                        {                            
                            dt.DefaultView.RowFilter = "StatusACC=0";
                            filterF5 = true;
                        }
                        else
                        {
                            dt.DefaultView.RowFilter = "";
                            filterF5 = false;
                        }
                        break;
                    case Keys.F6:
                        if (!SecurityManager.IsAuditor())
                        {
                            LinkToPiutang();
                        }
                        break;
                }
            }
        }

        private void LinkToPiutang()
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }

            // TODO: 
            //if (!accesright('005'))
            //{
            //    MessageBox.Show("'Bukan Wewenang Anda Link ke Piutang", "Perhatian");
            //    return;
            //}

            if (dataGridView1.SelectedCells[0].OwningRow.Cells["IDLink"].Value.ToString() != "")
            {
                MessageBox.Show("Sudah Link ke Piutang", "Perhatian");
                return;
            }

            if (double.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells["DILACC"].Value.ToString()) == 0)
            {
                MessageBox.Show("Potongan belum  di ACC", "Perhatian");
                return;
            }

            if (MessageBox.Show("Link ke piutang....?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Guid potID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Guid notaJualID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["NotaJualID"].Value;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dtLinkPot = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_Potongan_LinkToPiutang"));
                        db.Commands[0].Parameters.Add(new Parameter("@potID", SqlDbType.UniqueIdentifier, potID));
                        db.Commands[0].Parameters.Add(new Parameter("@notaJualID", SqlDbType.UniqueIdentifier, notaJualID));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        dtLinkPot = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtLinkPot.Rows[0]["cekNota"].ToString() == "0")
                        MessageBox.Show("Nota tidak ada", "Perhatian");
                    else
                    {
                        RefreshData();
                       FindRow("RowID", potID.ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, toolTip1.GetToolTip(button1));
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }
    }
}

